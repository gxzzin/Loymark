//Root ViewModel for page Users (List of Users)...
class IndexUserViewModel {
    constructor(data) {

        //#region ViewModel Properties

        const self = this;

        self.searchUserViewModel = ko.observable(new SearchUserViewModel());

        self.availableUsers = ko.observableArray([]);

        self.loadingUsers = ko.observable(false);

        self.availableCountries = ko.observableArray([]);
        
        self.loadingCountries = ko.observable(false);

        //#endregion

        
        //#region ViewModel Public Functions

        self.searchUsers = function () {
            UsersControlWebApp.apiCalls.getUsers({
                data: $.param(ko.toJS(self.searchUserViewModel)),
                beforeSend: () => {
                    self.loadingUsers(true);
                },
                complete: () => {
                    self.loadingUsers(false);
                }
            }).then(function (response) {
                let users = response.users.map(x => new UserReadViewModel(x));
                self.availableUsers(users);
                self.searchUserViewModel().page(response.page)
                    .totalRecords(response.totalRecords)
                    .totalPages(response.totalPages);
            });
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

        //#endregion

    }
}


//When document ready..
$(function () {
    const rootViewModel = new IndexUserViewModel(); //Create a new instance of root..
    rootViewModel.getCountries(); //Get avaible countries for filtering...
    ko.applyBindings(rootViewModel); //Apply all bindings to the page...
});