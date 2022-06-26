//Registrar custom binding para deshabilitar todos los elementos de entra de usuario...
ko.bindingHandlers.disableInputs = {
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        let disabled = ko.unwrap(valueAccessor()); //Bandera para habilitar o deshabilitar....
        $(element).find("input, select, textarea, button, a").each(function () {
            if (!$(this).hasClass("exclude-disabled") ) {
                if (disabled) {
                    $(this).attr("disabled", "disabled");
                    $(this).addClass("disabled");
    
                } else {
                    $(this).removeAttr("disabled");
                    $(this).removeClass("disabled");
                }
            }
        });
    }
};