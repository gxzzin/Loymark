class SearchViewModel {
    constructor(data) {
        const self = this;
        data = data || {};
        self.page = ko.observable(data.page || 1);
        self.sortColumn = ko.observable(data.sortColumn || "Id");
        self.sortDirection = ko.observable(data.sortDirection || "ASC");
        self.recordsPerPage = ko.observable(data.recordsPerPage || 10);
        self.totalRecords = ko.observable(data.totalRecords || 0);
        self.totalPages = ko.observable(data.totalPages || 0);
    }
    ResetDefault(except) {
        this.page(except.includes("page") ? this.page() : 1);
        this.sortColumn(except.includes("sortColumn") ? this.sortColumn() : "Id");
        this.sortDirection(except.includes("sortDirection") ? this.sortDirection() : "Asc");
        this.recordsPerPage(except.includes("recordsPerPage") ? this.recordsPerPage() : 10);
        this.totalRecords(except.includes("totalRecords") ? this.totalRecords() : 0);
        this.totalPages(except.includes("totalPages") ? this.totalPages() : 0);
    }
};