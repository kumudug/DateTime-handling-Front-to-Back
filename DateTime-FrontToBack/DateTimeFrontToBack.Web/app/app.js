(function () {
    'use strict';

    var app = angular.module('mainApp', [
        // Angular modules 
        'ngResource',

        // Custom modules 

        // 3rd Party Modules
        'ui.router',
        'mgcrea.ngStrap'
    ]);

    function config($stateProvider, $urlRouterProvider, $locationProvider) {
        
        $urlRouterProvider.otherwise("/");

        $stateProvider
            .state('home', {
                url: "/",
                templateUrl: "app/views/home-view.tpl.html",
                controller: "homeCtrl",
                controllerAs: "vm"
            });
    }

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

    app.config(config);

    app.constant('settings', {
        apiBaseUrl: 'http://localhost:37764'
    });
})();