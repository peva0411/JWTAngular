angular.module('psJwtApp')
    .controller('RegisterCtrl', function($scope, $http, alert) {
    $scope.submit = function() {

        var url = '/bad';
        var user = {};

        $http.post(url, user)
            .success(function(res) {
                alert('success', 'OK!', 'You are now registered.');
            })
            .error(function(err) {
                alert('warning', 'Opps!', 'Could not register');
            });

        console.log("test");
    };
})