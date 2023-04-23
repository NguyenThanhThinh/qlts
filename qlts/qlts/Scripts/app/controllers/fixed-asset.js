var fixedAssetsController = function () {
    var self = this;
    window.checkedRowFixedAsset = [];
    this.initialize = function () {
        registerEvents();
    };

    function registerEvents() {

        document.addEventListener("DOMContentLoaded",
            function () {

                const checkboxAll = $("#checkbox-all");
                var checkListItemCheckbox = $('input[name="checklist[]"]');

                // checkbox all
                checkboxAll.change(function () {
                    var isCheckedAll = $(this).prop("checked");
                    checkListItemCheckbox.prop("checked", isCheckedAll);
                });

                checkListItemCheckbox.change(function () {
                    var isCheckedAll = checkListItemCheckbox.length === $('input[name="checklist[]"]:checked').length;
                    checkboxAll.prop("checked", isCheckedAll);
                });

                var transferButton = document.getElementById("btn_transfer");
                transferButton.onclick = function () {
                    window.checkedRowFixedAsset = [];
                    $('input[type=checkbox]').each(function (index) {
                        if ($(this)[0].checked) {
                            window.checkedRowFixedAsset.push($(this).data('id'));
                        }
                    });
                    if (window.checkedRowFixedAsset.length == 0) {
                        toastr.error("Vui lòng click chọn tài sản !");
                        return;
                    }
                    var $Modal = $('#myModal');
                    $Modal.modal('show');
                };
            });

        $('body').on('click', '.btn_save', function (e) {
            e.preventDefault();
            save();
        });

        function save() {

            var warehouseId = $('#WarehouseId').val();
            var fixedAssetDate = $('#FixedAssetDate').val();
            var note = $('#Note').val();
            if (warehouseId == 0 || warehouseId == undefined) {
                toastr.error("Vui lòng chọn kho !");
                return;
            }
            if (note == '' || note == undefined) {
                toastr.error("Vui lòng nhập nội dung điều chuyển !");
                return;
            }
                $.ajax({
                    type: "POST",
                    url: "/AssetsTransfer/CreateTransfer",
                    data: {
                        WarehouseId: warehouseId,
                        FixedAssetDate: fixedAssetDate,
                        Note: note,
                        AssetIds: window.checkedRowFixedAsset
                    },
                    dataType: "json",
                    success: function (response) {
                        toastr.success("Điều chuyển tài sản thành công !")
                        $('#myModal').modal('hide');
                        window.location.reload();

                    },
                    error: function () {
                        toastr.error("Điều chuyển tài sản không thành công !");
                    }
                });
        }

    };

}