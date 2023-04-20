var app = (function (app, document, window) {

    /**
     * validation icons
     */
    var validatorIcons = {
        valid: "glyphicon glyphicon-ok",
        invalid: "glyphicon glyphicon-remove",
        validating: "glyphicon glyphicon-refresh"
    };
    
    /**
     * determine that development environment is local or not
     */
    function isDebug() {
        return window.location.hostname === "localhost";
    }

    /**
     * build a validator for input
     * @param {name} is input name
     * @param {required} is determine that input is required or not
     * @param {max} check the maximum length for input
     * @param {lenmsg} 
     * @param {min} required the minimum length for input
     * @param {group} for custom group selector (default is `.form-group`)
     * @param {regex} the regular expression validation
     */
    function validatorBuilder(name, required, max, min, group, regex) {
        var validators = {};

        if (required) {
            if (typeof required === "object" && required.msg) {
                validators.notEmpty = { message: required.msg };
            } else {
                validators.notEmpty = { message: name + " không được để trống" };
            }
        }

        if (max) {
            if (typeof max === "object" && max.msg) {
                validators.stringLength = { max: Number(max.val), message: max.msg };
            } else {
                validators.stringLength.max = Number(max);
            }

            if (min) {
                validators.stringLength.min = Number(min);
            }
        }

        if (regex) {
            validators.regexp = regex;
        }

        group = group || ".form-group";
        return {
            group: group,
            validators: validators
        };
    }

    /**
     * create validator for form
     * @param {formId} is id of form
     */
    app.buildFormValidation = function(formId) {
        formId = formId || "form";
        var fields = $(formId).find("[data-val='true']").not("[type=hidden], :checkbox, :radio");

        if (fields.length === 0) {
            return null;
        }

        var validators = {};
        $(fields).each(function (idx, field) {
            var $field = $(field);
            var require = $field.attr("data-val-required");
            var max = $field.attr("data-val-length-max");
            var min = $field.attr("data-val-length-min");
            var lenmsg = $field.attr("data-val-length");
            var regex = $field.attr("data-val-regex");
            var regex_pattern = $field.attr("data-val-regex-pattern");
            var groupClass = $field.closest("div").attr("class") || "";
            var group = groupClass.indexOf("form-group") < 0 ? ".form-group" : $field.data("group-class");
            var name = field.name;

            validators[name] = new validatorBuilder(
                name,
                require ? { msg: require } : null,
                max ? { val: max, msg: lenmsg } : null,
                min,
                group,
                regex_pattern ? { regexp: regex_pattern, message: regex } : null);
        });

        var option = {
            icons: validatorIcons,
            fields: validators
        };

        if (isDebug()) {
            console.log(option);
        }

        return $(formId).bootstrapValidator(option);
    }
        
    /**
     * execute function by name, depend on context provide
     * @param {functionName} is a string of function name
     * @param {context} is context of execution
     */
    app.executeFunction = function(functionName, context) {
        var args = [].slice.call(arguments).splice(2);
        var namespaces = functionName.split(".");
        var func = namespaces.pop();

        context = context || window;

        for (var i = 0; i < namespaces.length; i++) {
            context = context[namespaces[i]];
        }

        return context[func].apply(context, args);
    }

    app.serverError = function() {
        if (toastr && toastr.error)
            toastr.error("Lỗi server. Vui lòng thử lại sau!");
    }

    app.buildDataTable = function(selector, disable_order_columns) {
        selector = selector || "table";
        var $table = $(selector);

        if (disable_order_columns != null && disable_order_columns.length === 0) {
            disable_order_columns.push($table.find("thead").children("th").length - 1);
        } else {
            disable_order_columns = disable_order_columns || [];
        }
        return $table.DataTable({
            "lengthChange": false,
            "info": false,
            "columnDefs": [
                { "orderable": false, "targets": disable_order_columns },
                // { "searchable": false, "targets": [5] }
            ],
            language: {
                searchPlaceholder: "Tìm kiếm",
                search: "_INPUT_",
                zeroRecords: "Không tìm thấy dữ liệu",
                emptyTable: "Chưa có dữ liệu",
                paginate: {
                    first: "Trang đầu",
                    previous: "Trang trước",
                    next: "Trang kế",
                    last: "Trang cuối"
                }
            },
            searchDelay: 450
        });
    };

    return app;

})(app || {}, document, window);