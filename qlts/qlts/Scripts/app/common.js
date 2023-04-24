(function(){

})();

function toastServer() {
    $('.toast-server').each(function (i, input) {
        var $input = $(input);
        var val = $input.val();
        console.log(val);
        if (val) {
            toastr.options = toastr.options || {};
            toastr.options.closeButton = true;
            toastr[$input.data('type')](val);
        }
    });
}

/*
(function () {
    var input = document.getElementById('autocomplete');
    var options = {
        types: ['address'],
        componentRestrictions: { country: 'vn' }
    };
    autocomplete = new google.maps.places.Autocomplete(input, options);
})();
*/

(function () {

    if ($.fn.bootbox)
        bootbox.setLocale("vi_VN");

    toastServer();


    $(".focus").focus();

    if ($.fn.summernote) {
        $(".editor").summernote({
            height: 300
        });
    }

    if ($.fn.mask) {
        $('.money').mask('000,000,000,000,000', { reverse: true });
    }

    if ($.fn.datepicker) {
        $(".datepicker").datepicker({ language: "vi", format: "dd/mm/yyyy", todayHighlight: true, clearBtn: true });
    }

    if ($.fn.select2) {
        $(".select-control").select2({ language: "vi" });
    }


    $('.delete-container').on('click', '.delete-button', function (e) {
        e.preventDefault();

        var self = $(this);
        var url = self.data('url');

        if (!url) {
            toastr.error('url not found!');
            return;
        }

        bootbox.confirm({
            message: 'Bạn chắn chắn muốn xóa?',
            buttons: {
                confirm: {
                    label: 'Đồng ý',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'Hủy',
                    className: 'btn-default'
                }
            },
            callback: function (yes) {

                if (!yes) {
                    return;
                }

                var req = $.ajax({
                    url: url,
                    method: 'post'
                });

                req.then(function (resp) {
                    if (resp != null && resp.Success) {
                        var $table = self.closest('.dataTable');
                        var $tr = self.closest('tr');
                        if ($table.length === 0) { // normal table
                            if ($tr.length === 0) { // not a table
                                var $parent = self.closest(self.data("parent"));
                                if ($parent.length > 0) // has parent
                                    $parent.remove();
                                var handle = self.data("handle");
                                if (handle)
                                    app.executeFunction(handle);
                            } else {
                                $tr.remove();
                            }
                        } else { // datatable
                            var table = $table.DataTable();
                            table && table.row($tr).remove().draw(false);
                        }

                        toastr.success(resp.Message || 'Xóa thành công');
                    } else {
                        toastr.error(resp.Message || "Không thể xóa");
                    }

                }, app.serverError);
            }
        });
    });

    // device return

    $('.delete-container').on('click', '.devicereturn-button', function (e) {
        e.preventDefault();

        var self = $(this);
        var url = self.data('device');

        if (!url) {
            toastr.error('url not found!');
            return;
        }

        bootbox.confirm({
            message: 'Bạn chắn chắn muốn trả thiết bị?',
            buttons: {
                confirm: {
                    label: 'Đồng ý',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'Hủy',
                    className: 'btn-default'
                }
            },
            callback: function (yes) {

                if (!yes) {
                    return;
                }

                var req = $.ajax({
                    url: url,
                    method: 'post'
                });
                req.then(function (resp) {
                    if (resp != null && resp.Success) {
                        var $table = self.closest('.dataTable');
                        var $tr = self.closest('tr');
                        if ($table.length === 0) { // normal table
                            if ($tr.length === 0) { // not a table
                                var $parent = self.closest(self.data("parent"));
                                if ($parent.length > 0) // has parent
                                    $parent.remove();
                                var handle = self.data("handle");
                                if (handle)
                                    app.executeFunction(handle);
                            } else {
                                $tr.remove();
                            }
                        } else { // datatable
                            var table = $table.DataTable();
                            table && table.row($tr).remove().draw(false);
                        }

                        toastr.success('Trả thiết bị thành công');
                    } else {
                        toastr.error(resp.Message || "Không thể xóa");
                    }

                }, app.serverError);
            }
        });
    });
})();