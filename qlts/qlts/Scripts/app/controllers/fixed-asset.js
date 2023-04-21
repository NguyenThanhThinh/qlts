var fixedAssetsController = function () {
    var self = this;

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

                var saveButton = document.getElementById("btn_sent");
                saveButton.onclick = function () {
                    var checkedRowIndices = [];
                    $('input[type=checkbox]').each(function (index) {
                        if ($(this)[0].checked) {
                            checkedRowIndices.push($(this).data('id'));
                        }
                    });
                    console.info(checkedRowIndices);
                    var $Modal = $('#myModal');     
                    $Modal.modal('show');
                };
            });




    };

}