
//#region Logica del componente
(function () {
    ko.ConfirmAction = {
        viewModel: function (params) {
            var self = this;

            //#region Validar parametros obligatorios

            if (!params.confirmAction) {
                throw new Error('La función callback "confirmAction" no se ha especificado.');
            }

            params.css = params.css || {};

            //#endregion


            //#region unbind jquery events before bind them again

            $("body").off("show.bs.modal", "#" + ko.unwrap(params.modalId));
            $("body").off("hide.bs.modal", "#" + ko.unwrap(params.modalId));
            $("body").off("shown.bs.modal", "#" + ko.unwrap(params.modalId));
            $("body").off("hidden.bs.modal", "#" + ko.unwrap(params.modalId));

            //#endregion


            //#region Campos o Propiedades

            self.title = ko.observable(params.title);
            self.message = ko.observable(params.message || null);
            self.template = ko.observable(params.template || null);
            self.modalSizeClass = ko.observable(params.modalSizeClass || "");
            self.modalCentered = ko.observable((typeof params.modalCentered === "boolean") ? params.modalCentered : true);
            self.ModalFullscreen = ko.observable((typeof params.ModalFullscreen === "boolean") ? params.ModalFullscreen : false);
            self.ShowConfirmButton = ko.observable((typeof params.showConfirmButton === "boolean") ? params.showConfirmButton : true);
            self.AutoFocusConfirmButton = ko.observable((typeof params.AutoFocusConfirmButton === "boolean") ? params.AutoFocusConfirmButton : true);

            self.confirmButtonText = ko.observable(params.confirmButtonText || "Confirmar");
            self.cancelButtonText = ko.observable(params.cancelButtonText || "Cancelar");
            self.modalId = ko.observable(params.modalId);
            self.hideOnConfirm = params.hideOnConfirm;
            self.modalHeaderBgClass = params.css.modalHeaderBgClass || "bg-danger";
            self.modalConfirmButtonClass = params.css.modalConfirmButtonClass || "btn btn-danger";
            self.modalConfirmButtonIcon = params.css.modalConfirmButtonIcon || '<span class="fas fa-check"></span>';
            self.messageAlignmentClass = params.css.messageAlignmentClass || "text-center";
            self.messageClass = params.css.messageClass || "h5 font-weight-bold mb-0";
            self.modalHeaderIcon = params.css.modalHeaderIcon || '<span class="fas fa-info-circle fa-2x"></span>';
            self.animateIn = params.animateIn ? true : false;
            self.animateOut = params.animateOut ? true : false;
            self.animationInClass = params.css.animationInClass || "bounceIn fast";
            self.animationOutClass = params.css.animationOutClass || "bounceOut fast";
            self.confirm = params.confirmAction;
            self.cancel = params.cancelAction;

            //#endregion


            //#region Funciones publicas

            self.confirmAction = function (data, event) {
                var modal = $("#" + self.modalId());
                if (self.hideOnConfirm) {
                    if (ko.unwrap(self.animateOut)) {
                        modal.animateCss(ko.unwrap(self.animationOutClass), function () {
                            modal.modal("hide");
                            self.confirm();
                        });
                    } else {
                        self.confirm();
                    }
                } else {
                    self.confirm(modal);
                }
            };


            self.cancelAction = function (data, event) {
                var modal = $("#" + self.modalId());
                if (ko.unwrap(self.animateOut)) {
                    modal.animateCss(ko.unwrap(self.animationOutClass), function () {
                        modal.modal("hide");
                    });
                } else {
                    modal.modal("hide");
                }

                if (self.cancel && typeof self.cancel === "function") {
                    self.cancel(modal);
                }

            };


            self.showConfirmationModal = function () {
                var modal = $("#" + self.modalId());
                modal.modal("show");
                if (ko.unwrap(self.animateIn)) {
                    modal.animateCss(ko.unwrap(self.animationInClass));
                }
            };


            self.hideConfirmationModal = function () {
                var modal = $("#" + self.modalId());
                if (ko.unwrap(self.animateOut)) {
                    modal.animateCss(ko.unwrap(self.animationOutClass), function () {
                        modal.modal("hide");
                    });
                } else {
                    modal.modal("hide");
                }
            };

            //#endregion


            //#region eventos

            //Recorrer eventos para enlazarlos al modal...
            if (params.events) {
                for (const key in params.events) {
                    if (params.events.hasOwnProperty(key)) {
                        const e = params.events[key];
                        $("body").on(key, "#" + ko.unwrap(self.modalId), e);
                    }
                }
            }

            //Si el autofoco en el boton confirmar es true entonces mandar el foco al mostrar el modal...
            if (self.AutoFocusConfirmButton()) {
                //Enlazarnos al evento cuando se muestre el modal..
                $("body").on("shown.bs.modal", "#" + ko.unwrap(self.modalId), function (event) {
                    var modal = $(this);
                    modal.find("#btnConfirm").trigger("focus");
                   
                    //Desenlazarnos del evento una vez realizado lo requerido...
                    $("body").off("shown.bs.modal", "#" + ko.unwrap(params.modalId));
                });
            }

            //#endregion
        }
    }
})();
//#endregion


//#region Registrar componente
ko.components.register("confirm-action-modal", {
    template: { element: "confirm-action-modal-template" },
    viewModel: function (params) {
        var self = this;
        self.ConfirmActionViewModel = params.viewModel;
    }
});
//#endregion
