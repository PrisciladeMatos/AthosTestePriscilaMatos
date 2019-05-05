var ViewModel = function () {
    var self = this;
    var selfUsuario = this;
    self.condominios = ko.observableArray();
    selfUsuario.usuarios = ko.observableArray();
    self.administradoras = ko.observableArray();


    self.error = ko.observable();
    self.detail = ko.observable();
    selfUsuario.detailUsuario = ko.observable();


    self.newCondominio = {
        Nome_Condominio: ko.observable(),
        Administradora: ko.observable(),
        Tp_Usuario: ko.observable()
    }

    selfUsuario.newUsuario = {
        Nome: ko.observable(),
        Email: ko.observable(),
        Condominio: ko.observable(),
        Tp_Usuario: ko.observable()
    }


    var condominiosUri = '/api/condominios/';
    var administradorasUri = '/api/administradoras/';
    var usuariosUri = '/api/usuarios/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllCondominios() {
        ajaxHelper(condominiosUri, 'GET').done(function (data) {
            self.condominios(data);
        });
    }

    self.getCondominioDetail = function (item) {
        ajaxHelper(condominiosUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }


    function getAdministradoras() {
        ajaxHelper(administradorasUri, 'GET').done(function (data) {
            self.administradoras(data);
        });
    }

    self.addCondominio = function (formElement) {
        var condominio = {

            Administradora: self.newCondominio.Administradora().Administradora,
            Nome_Condominio: self.newCondominio.Nome_Condominio(),
            Tp_Usuario: self.newCondominio.Tp_Usuario()
        };

        ajaxHelper(condominiosUri, 'POST', condominio).done(function (item) {
            self.condominios.push(item);
        });
    }


    function getAllUsuarios() {
        ajaxHelper(usuariosUri, 'GET').done(function (data) {
            selfUsuario.usuarios(data);
        });
    }


    self.addUsuario = function (formElement) {
        var usuario = {

            Nome: self.newUsuario.Nome(),
            Email: self.newUsuario.Email(),
            Condominio: self.newUsuario.Condominio(),
            Tp_Usuario: self.newUsuario.Tp_Usuario()
        };

        ajaxHelper(usuariosUri, 'POST', usuario).done(function (item) {
            self.usuarios.push(item);
        });
    }

    self.getUsuarioDetail = function (item) {
        ajaxHelper(usuariosUri + item.Id, 'GET').done(function (data) {
            selfUsuario.detailUsuario(data);
        });
    }



    // Fetch the initial data.
    getAllUsuarios();
    getAllCondominios();
    getAdministradoras();

};

ko.applyBindings(new ViewModel());