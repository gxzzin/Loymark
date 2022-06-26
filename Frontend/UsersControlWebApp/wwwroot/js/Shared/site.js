/*!
 * En este archivo podemos especificar configuraciones globales para toda la aplicación.
 * Tambien se define un objeto el cual se usa como namespace para acceder a variables globales.
 */

//Object namespace principal...
const UsersControlWebApp = {
    apiUrl: (function () {
        let input = $("#apiurl");
        let value = input.val();
        input.remove();
        return value;
    })()
};

//Agregar llamadas del web api...
(function () {
    if (typeof UsersControlWebApp != "undefined") {
        UsersControlWebApp.apiCalls = {
            getUsers: function (params) {
                params.url = params.url || "Users";

                return $.ajax({
                    url: UsersControlWebApp.apiUrl + params.url,
                    method: params.method || "get",
                    data: params.data,
                    dataType: params.dataType || "json",
                    beforeSend: params.beforeSend,
                    complete: params.complete
                });
            },
            getCountries: function (params) {
                params.url = params.url || "Countries";

                return $.ajax({
                    url: UsersControlWebApp.apiUrl + params.url,
                    method: params.method || "get",
                    data: params.data,
                    dataType: params.dataType || "json",
                    beforeSend: params.beforeSend,
                    complete: params.complete
                });
            },
        }
    }
})();