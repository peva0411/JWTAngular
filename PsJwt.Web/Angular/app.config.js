angular.module('psJwtApp').config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('main', {
            url: '/',
            templateUrl: '/Angular/views/main.html'
        })
        .state('register', {
        url: '/register',
        templateUrl: '/Angular/views/register.html',
        controller:'RegisterCtrl'
    });
})