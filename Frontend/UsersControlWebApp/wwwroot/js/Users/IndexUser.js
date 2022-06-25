class IndexUserViewModel {
    constructor(data) {
        const self = this;
        self.helloMessage = ko.observable("Hello from knockout!");
    }
}


$(function () {
    ko.applyBindings(new IndexUserViewModel());
});