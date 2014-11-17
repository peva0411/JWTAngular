angular.module('psJwtApp').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('main', {
            url: '/',
            templateUrl: '/Angular/views/main.html'
        })
        .state('jobs', {
            url: '/jobs',
            templateUrl: '/Angular/views/jobs.html',
            controller: 'JobsCtrl'
        })
        .state('register', {
        url: '/register',
        templateUrl: '/Angular/views/register.html',
        controller: 'RegisterCtrl'
        
        })
    .state('logout', {
            url: '/logout',
            controller: 'LogoutCtrl'
    });

    $httpProvider.interceptors.push('authIntercepter');

})