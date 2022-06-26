/*
 *Establecer configuración predeterminada para jquery.validate
 */
(function ($) {
    var defaultOptions = {
        errorElement: "span",
        validClass: 'valid',
        errorClass: 'invalid',
        errorPlacement: function (error, element) { //Sobreescribir el valor por defecto jquery.validate ya que posiciona el error inmediatamente despues del elemento.
            var elementId = $(element).attr("id");
            $('*[data-valmsg-for=' + elementId + ']').html(error); //Con esto quedaria el mismo resultado que jquery.validate.unobtrusive...
        }
        // ignore: []
    };

    $.validator.setDefaults(defaultOptions);

    $.validator.messages.required = "Este campo es obligatorio";

    $.validator.unobtrusive.options = {
        errorClass: defaultOptions.errorClass,
        validClass: defaultOptions.validClass
        // ignore: defaultOptions.ignore
    };


    //Agregar una funcion a jquery.validate para parsear un formulario 
    //y aplicar las reglas de jquery.validete.unobstrusive...
    $.validator.unobtrusive.parseDynamicContent = function (selector) {
        //use the normal unobstrusive.parse method
        $.validator.unobtrusive.parse(selector);

        //get the relevant form
        var form = $(selector).first().closest('form');

        //get the collections of unobstrusive validators, and jquery validators
        //and compare the two
        var unobtrusiveValidation = form.data('unobtrusiveValidation');
        var validator = form.validate();

        if (unobtrusiveValidation) {
            $.each(unobtrusiveValidation.options.rules, function (elname, elrules) {
                if (validator.settings.rules[elname] == undefined) {
                    var args = {};
                    $.extend(args, elrules);
                    args.messages = unobtrusiveValidation.options.messages[elname];
                    //edit:use quoted strings for the name selector
                    $("[name='" + elname + "']").rules("add", args);
                } else {
                    $.each(elrules, function (rulename, data) {
                        if (validator.settings.rules[elname][rulename] == undefined) {
                            var args = {};
                            args[rulename] = data;
                            args.messages = unobtrusiveValidation.options.messages[elname][rulename];
                            //edit:use quoted strings for the name selector
                            $("[name='" + elname + "']").rules("add", args);
                        }
                    });
                }
            });
        }
    }


    //Agregar regla de validación de formato de fechas para el datepicker...
    $.validator.addMethod('date', function (value, element, params) {
        if (this.optional(element)) {
            return true;
        }
        var ok = true;
        try {
            $.datepicker.parseDate('dd/mm/yy', value);
        }
        catch (err) {
            ok = false;
        }
        return ok;

    });

})(jQuery);
