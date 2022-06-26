class SearchUserViewModel extends SearchViewModel {
    constructor(data) {
        super(data);
        data = data || {};
        const self = this;

        self.name = ko.observable("");
        self.lastName = ko.observable("");
        self.countryId = ko.observable("");
    }
}