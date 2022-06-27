class SearchActivityViewModel extends SearchViewModel {
    constructor(data) {
        super(data);
        data = data || {};
        const self = this;

        self.userId = ko.observable();
        self.activityType = ko.observable("*");
    }
}