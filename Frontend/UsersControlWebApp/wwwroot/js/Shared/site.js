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
    })(),
    //Funcion que parse validaciones jquery en contenido dinamico agregado al documento.
    ParseDynamicContent: function (selector) {
        if ($.validator) {
            $.validator.unobtrusive.parseDynamicContent(selector)
        }
    },
};

//Agregar llamadas del web api...
(function () {
    if (typeof UsersControlWebApp != "undefined") {
        UsersControlWebApp.apiCalls = {
            getUsers: function (params) {
                params.url = params.url || "Users";

                return $.ajax({
                    url: UsersControlWebApp.apiUrl + params.url,
                    method: "get",
                    data: params.data,
                    dataType: "json",
                    beforeSend: params.beforeSend,
                    complete: params.complete
                });
            },
            getUserById: function (params) {
                params.url = params.url || "Users";

                return $.ajax({
                    url: UsersControlWebApp.apiUrl + params.url,
                    method: "get",
                    data: params.data,
                    dataType: "json",
                    beforeSend: params.beforeSend,
                    complete: params.complete
                });
            },
            createUser: function (params) {
                params.url = params.url || "Users";

                return $.ajax({
                    url: UsersControlWebApp.apiUrl + params.url,
                    method: "post",
                    data: params.data,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: params.beforeSend,
                    complete: params.complete
                });
            },
            updateUser: function (params) {
                params.url = params.url || "Users";

                return $.ajax({
                    url: UsersControlWebApp.apiUrl + params.url,
                    method: "put",
                    data: params.data,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: params.beforeSend,
                    complete: params.complete
                });
            },
            deleteUser: function (params) {
                params.url = params.url || "Users";

                return $.ajax({
                    url: UsersControlWebApp.apiUrl + params.url,
                    method: "delete",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
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