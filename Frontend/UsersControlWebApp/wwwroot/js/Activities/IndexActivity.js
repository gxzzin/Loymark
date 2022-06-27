//Root ViewModel for page Activities (List of User Activities)...
class IndexActivityViewModel {
    constructor(initialData) {

        //#region ViewModel Properties

        const self = this;

        self.loadingUser = ko.observable(false); //Flag: loading user (?)...

        self.selectedUserViewModel = ko.observable(null); //The selected user to load activities...

        self.searchActivityViewModel = ko.observable(new SearchActivityViewModel()); //ViewModel for activity search...

        self.availableActivities = ko.observableArray([]);

        self.loadingActivities = ko.observable(false); //Flag: loading activities (?)...

        self.paginationActivitiesViewModel = ko.observable(new PaginationViewModel({ //Instancia del ViewModel de paginacion...
            TotalPages: self.searchActivityViewModel().totalPages, //EL total de paginas se envia como referencia para controlarlo desde este nivel...
            CurrentPage: self.searchActivityViewModel().page, //Igualmente la pagina actual se pasa como referencia...
            TotalDisplayedPages: 5, //Numero de links de paginas mostrados a la vez...
            OnCurrentPageChange: getActivities //Callback al paginar...
        }));

        
        //#endregion


        //#region Manual Subscriptions

        self.selectedUserViewModel.extend({ notify: "always" }).subscribe(function (user) {
            if (user) {
                self.searchActivityViewModel().userId(ko.unwrap(user.id));
                getActivities();
            }
        });

        self.searchActivityViewModel().activityType.extend({ notify: "always" }).subscribe(function (activityType) {
            self.paginationActivitiesViewModel().TriggerOnCurrentPageChange(false);
            self.paginationActivitiesViewModel().CurrentPage(1);
            getActivities();
        });

        //#endregion


        //#region ViewModel Public Functions

        self.getUser = function (userId) {
            UsersControlWebApp.apiCalls.getUserById({
                url: "Users/" + ko.unwrap(userId),
                beforeSend: () => {
                    self.loadingUser(true);
                },
                complete: () => {
                    self.loadingUser(false);
                }
            }).then(function (response) {
                self.selectedUserViewModel(new UserViewModel(response));
            });
        };


        self.getActivities = function () {
            self.availableActivities.removeAll();
            getActivities(true);
        };

        //#endregion


        //#region ViewModel Private Functions

        function getActivities(resetPage) {

            if (resetPage) {
                self.paginationActivitiesViewModel().TriggerOnCurrentPageChange(false);
                self.searchActivityViewModel().page(1);
            }

            return UsersControlWebApp.apiCalls.getActivities({
                data: $.param(ko.toJS(self.searchActivityViewModel)),
                beforeSend: () => {
                    self.loadingActivities(true);
                },
                complete: () => {
                    self.loadingActivities(false);
                }
            }).then(function (response) {
                //Map each user response and push it to the list...
                let activities = response.activities.map(x => new ActivityViewModel(x));
                self.availableActivities(activities);

                //Dado que el servidor puede retornar una pagina diferente en base a la cantidad de registros y el criterio de filtrado
                //Se debe evitar que actualizar la pagina actua con la pagina en la response del servidor
                //Dispare nuevamente esta peticion y genere un ciclo infinito...
                self.paginationActivitiesViewModel().TriggerOnCurrentPageChange(false);

                //Update pagination properties...
                self.searchActivityViewModel().page(response.page)
                    .totalRecords(response.totalRecords)
                    .totalPages(response.totalPages);
            });
        };

        //#endregion


        //Load initially the user send (if send)...
        if (initialData.userId && parseInt(initialData.userId) > 0) {
            self.getUser(initialData.userId); //Then load its activities...
        } else {
            self.getActivities(); //If no user specified, well loads all activities...
        }

    }
}


//When document ready..
$(function () {
    const initialData = JSON.parse($("#JsonData").val());
    const rootViewModel = new IndexActivityViewModel(initialData); //Create a new instance of root..
    ko.applyBindings(rootViewModel); //Apply all bindings to the page...
});