﻿angular.module('psJwtApp')
    .controller('RegisterCtrl', function($scope, $http, alert, authToken) {
    $scope.submit = function() {

        var url = '/api/auth';
        var user = {email:'test@mail.com', password: '123'};

        $http.post(url, user)
            .success(function(res) {
                alert('success', 'OK!', 'You are now registered.');
                authToken.setToken(res.Token);
            })
            .error(function(err) {
                alert('warning', 'Opps!', 'Could not register');
            });

        console.log("test");
    };
})