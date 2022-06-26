//Registrar componente...
ko.components.register("loading-spinner", {
    template: { element: "loading-spinner-template" },
    viewModel: function (params) {
        const self = this;
        params = params || {};
        self.loading = ko.isObservable(params.loading) ? params.loading : ko.observable(false); //Bandera: Se está cargando (?)...
        self.message = ko.observable(params.message || "Loading...");  //Mensaje a mostrar cuando se está cargando algo...

    }
})