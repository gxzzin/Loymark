class CRUDViewModel {
    constructor(data) {
        data = data || {};
        const self = this;

        self.Action = ko.observable(data.Action || "");

        self.AntiForgeryToken = ko.observable(data.AntiForgeryToken);

        self.SaveButtonText = ko.computed(function () {
            let result = "Save";
            if (self.Action().toLowerCase() === "create") {
                result = "Save";

            } else if (self.Action().toLowerCase() === "edit") {
                result = "Save Changes";

            } else if (self.Action().toLowerCase() === "delete") {
                result = "Yes, Delete";

            }

            return result;
        });

        self.SaveButtonIconClass = ko.computed(function () {
            let result = "fas fa-save";
            if (self.Action().toLowerCase() === "create" || self.Action().toLowerCase() === "edit") {
                result = "fas fa-save";

            } else if (self.Action().toLowerCase() === "delete") {
                result = "fas fa-trash-alt";
                
            } else if (self.Action().toLowerCase() === "verify") {
                result = "fas fa-check";

            }

            return result;
        });

        self.SaveButtonBackgroundClass = ko.computed(function () {
            let result = "btn btn-info";
            if (self.Action().toLowerCase() === "create") {
                result = "btn btn-primary";

            } else if (self.Action().toLowerCase() === "edit") {
                result = "btn btn-success";

            } else if (self.Action().toLowerCase() === "delete") {
                result = "btn btn-danger";
            }

            return result;
        });

        self.DataViewModel = ko.observable(data.DataViewModel); //ViewModel del Modelo Principal...
        
        self.ProcessingAction = ko.observable(false);
        
        self.DisableUserInput = ko.observable(false);

        self.ModelName = ko.observable(data.ModelName || "");

        self.ModalHeaderTitle = ko.observable("");

        self.ModalBackgroundColorClass = ko.computed(() => {
            let result = "bg-info text-dark";
            if(self.Action().toLowerCase() === "create"){
                result = "bg-primary text-white";
                self.ModalHeaderTitle("Create " + self.ModelName());
                self.DisableUserInput(true);
            }
            else if(self.Action().toLowerCase() === "edit"){
                result = "bg-success text-white";
                self.ModalHeaderTitle("Update " + self.ModelName());
                self.DisableUserInput(true);
            }
            else if(self.Action().toLowerCase() === "delete"){
                result = "bg-danger text-white";
                self.ModalHeaderTitle("Delete " + self.ModelName());
            }
            else if(self.Action().toLowerCase() === "details"){
                result = "bg-secondary text-white";
                self.ModalHeaderTitle("Details " + self.ModelName());
            }
            
            return result;
        });
    };
};