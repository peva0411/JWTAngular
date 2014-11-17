angular.module('psJwtApp')
    .controller('JobsCtrl', function ($scope, $http, alert) {
    $http.get('/api/jobs').success(function(jobs) {
        $scope.jobs = jobs;
    }).error(function(err) {
        alert('warning', "Unable to get jobs", err.message);
    });
})