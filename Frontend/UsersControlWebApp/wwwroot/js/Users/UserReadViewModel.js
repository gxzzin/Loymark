class UserReadViewModel {
    constructor(data) {
        data = data || {};
        const self = this;
        self.id = ko.observable(data.id);
        self.name = ko.observable(data.name);
        self.lastName = ko.observable(data.lastName);
        self.email = ko.observable(data.email);
        self.birthday = ko.observable(data.birthday);
        self.telephoneNumber = ko.observable(data.telephoneNumber);
        self.sendNews = ko.observable(data.sendNews);
        self.countryNameAndCode = ko.observable(data.countryNameAndCode);
    }
}