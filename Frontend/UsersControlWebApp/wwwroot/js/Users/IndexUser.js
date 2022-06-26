//Root ViewModel for page Users (List of Users)...
class IndexUserViewModel {
    constructor(data) {

        //#region ViewModel Properties

        const self = this;

        self.searchUserViewModel = ko.observable(new SearchUserViewModel()); //ViewModel for users search...

        self.availableUsers = ko.observableArray([]);

        self.loadingUsers = ko.observable(false); //Flag: loading user (?)...

        self.loadingUniqueUser = ko.observable(false); //Flag: loading an unique user (?)...

        self.availableCountries = ko.observableArray([]);

        self.loadingCountries = ko.observable(false); //Flag: loading countries (?)...

        self.crudUserViewModel = ko.observable(null); //ViewModel for CRUD on User...

        self.confirmActionModal = ko.observable(null); //ViewModel for confirm action modal component...

        self.paginationUsersViewModel = ko.observable(new PaginationViewModel({ //Instancia del ViewModel de paginacion...
            TotalPages: self.searchUserViewModel().totalPages, //EL total de paginas se envia como referencia para controlarlo desde este nivel...
            CurrentPage: self.searchUserViewModel().page, //Igualmente la pagina actual se pasa como referencia...
            TotalDisplayedPages: 5, //Numero de links de paginas mostrados a la vez...
            OnCurrentPageChange: getUsers //Callback al paginar...
        }));


        //#endregion


        //#region ViewModel Public Functions

        self.searchUsers = function () {
            self.availableUsers.removeAll();
            getUsers(true);
        };

        self.getCountries = function () {
            UsersControlWebApp.apiCalls.getCountries({
                beforeSend: () => {
                    self.loadingCountries(true);
                },
                complete: () => {
                    self.loadingCountries(false);
                }
            }).then(function (response) {
                self.availableCountries(response);
            });
        };

        self.showCRUDUserModal = function (action, user) {
            if (action === "create") {
                showCRUDUserModal(action, user);
            } else {
                UsersControlWebApp.apiCalls.getUserById({
                    url: "Users/" + ko.unwrap(user.id),
                    beforeSend: () => {
                        self.loadingUniqueUser(true);
                    },
                    complete: () => {
                        self.loadingUniqueUser(false);
                    }
                }).then(function (response) {
                    showCRUDUserModal(action, new UserViewModel(response));
                });
            }
        };

        //#endregion


        //#region ViewModel Private Functions

        function getUsers(resetPage) {

            if (resetPage) {
                self.paginationUsersViewModel().TriggerOnCurrentPageChange(false);
                self.searchUserViewModel().page(1);
            }

            return UsersControlWebApp.apiCalls.getUsers({
                data: $.param(ko.toJS(self.searchUserViewModel)),
                beforeSend: () => {
                    self.loadingUsers(true);
                },
                complete: () => {
                    self.loadingUsers(false);
                }
            }).then(function (response) {
                //Map each user response and push it to the list...
                let users = response.users.map(x => new UserViewModel(x));
                self.availableUsers(users);

                //Dado que el servidor puede retornar una pagina diferente en base a la cantidad de registros y el criterio de filtrado
                //Se debe evitar que actualizar la pagina actua con la pagina en la response del servidor
                //Dispare nuevamente esta peticion y genere un ciclo infinito...
                self.paginationUsersViewModel().TriggerOnCurrentPageChange(false);

                //Update pagination properties...
                self.searchUserViewModel().page(response.page)
                    .totalRecords(response.totalRecords)
                    .totalPages(response.totalPages);
            });
        };

        function showCRUDUserModal(action, user) {

            //Configure crud viewModel...
            self.crudUserViewModel(new CRUDUserViewModel({
                ModelName: "User",
                Action: action,
                DataViewModel: user || new UserViewModel(),
                AvailableCountries: self.availableCountries()
            }));

            //Variables de configuracion del modal de confirmacion...
            let message = "",
                messageClass = "",
                modalHeaderIcon = "",
                modalConfirmButtonIcon = "<span class='fas fa-save'></span>",
                showConfirmButton = true,
                cancelButtonText = "Cancel";

            if (action.toLowerCase() === "create") {
                modalHeaderIcon = "<span class='fas fa-plus-circle fa-2x'></span>";

            } else if (action.toLowerCase() === "edit") {
                modalHeaderIcon = "<span class='fas fa-edit fa-2x'></span>";

            } else if (action.toLowerCase() === "details") {
                modalHeaderIcon = "<span class='fas fa-info-circle fa-2x'></span>";
                showConfirmButton = false;
            }
            else if (action.toLowerCase() === "delete") {
                modalHeaderIcon = "<span class='fas fa-trash-alt fa-2x'></span>";
                message = "Are you sure about delete this record?";
                messageClass = "text-danger text-center font-weight-bold";
            }

            //Actualizar la instancia del componente.. 
            self.confirmActionModal(new ko.ConfirmAction.viewModel({
                modalId: "crud-user-modal",
                title: self.crudUserViewModel().ModalHeaderTitle(),
                message: message,
                modalCentered: false,
                template: { name: "crud-users-template", data: self.crudUserViewModel(), afterRender: (els) => UsersControlWebApp.ParseDynamicContent(els.filter(e => e.nodeType === 1)) },
                confirmButtonText: self.crudUserViewModel().SaveButtonText(),
                cancelButtonText: cancelButtonText,
                hideOnConfirm: false,
                // animateIn: true,
                // animateOut: true,
                showConfirmButton: showConfirmButton,
                AutoFocusConfirmButton: false,
                css: {
                    messageClass: messageClass,
                    modalHeaderBgClass: self.crudUserViewModel().ModalBackgroundColorClass(),
                    modalHeaderIcon: modalHeaderIcon,
                    messageAlignmentClass: "text-justify",
                    modalConfirmButtonClass: self.crudUserViewModel().SaveButtonBackgroundClass(),
                    modalConfirmButtonIcon: modalConfirmButtonIcon,
                    // animationInClass: "fadeIn faster",
                    // animationOutClass: "fadeOut faster"
                },
                events: {
                    "shown.bs.modal": function () {
                        // GestionInstitucional.AutoResizeTextarea();
                        // self.CRUDControlInternoViewModel().ControlInterno().DescripcionControlInterno.HasFocus(true);
                    }
                },
                confirmAction: (modal) => { confirmActionOnUser(modal, action); }
            }));

            //Mostrar componente...
            self.confirmActionModal().showConfirmationModal();
        };

        function confirmActionOnUser(modal, action) {
            const form = $(modal).find("form");
            const user = ko.toJS(self.crudUserViewModel().DataViewModel);
            const dataToSend = ko.toJSON(self.crudUserViewModel().DataViewModel);
            const onBeforeSend = () => { self.crudUserViewModel().ProcessingAction(true); };
            const onComplete = () => { self.crudUserViewModel().ProcessingAction(false); };
            const onSuccess = (response) => {
                alert("Action Completed!");
                $(modal).modal("hide");
                self.searchUsers();
            };

            //Fire input validation and ensure there is not acction being proccesed...
            if (form.valid() && !self.crudUserViewModel().ProcessingAction()) {
                if (action === "create") {
                    UsersControlWebApp.apiCalls.createUser({
                        data: dataToSend,
                        beforeSend: onBeforeSend,
                        complete: onComplete
                    }).then(onSuccess);
                }
                else if (action === "edit") {
                    UsersControlWebApp.apiCalls.updateUser({
                        url: "Users/" + ko.unwrap(user.id),
                        data: dataToSend,
                        beforeSend: onBeforeSend,
                        complete: onComplete
                    }).then(onSuccess);
                }
                else if (action === "delete") {
                    UsersControlWebApp.apiCalls.deleteUser({
                        url: "Users/" + ko.unwrap(user.id),
                        beforeSend: onBeforeSend,
                        complete: onComplete
                    }).then(onSuccess);
                }
            } else {
                alert("Please verify info or be patient, there could be an action being processed.!");
            }
        };

        //#endregion

    }
}


//When document ready..
$(function () {
    const rootViewModel = new IndexUserViewModel(); //Create a new instance of root..
    rootViewModel.getCountries(); //Get avaible countries for filtering...
    ko.applyBindings(rootViewModel); //Apply all bindings to the page...
});