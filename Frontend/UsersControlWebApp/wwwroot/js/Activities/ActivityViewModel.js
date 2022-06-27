class ActivityViewModel {
    constructor(data) {
        data = data || {};
        const self = this;
        self.createDate = ko.observable(data.createDate);
        self.activityDescription = ko.observable(data.activityDescription);
        self.user = ko.observable(data.user);

    }
}