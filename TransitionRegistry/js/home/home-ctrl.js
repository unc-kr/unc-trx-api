'use strict';

angular.module('uncTrxApp')
  .controller('HomeCtrl', function ($scope, $http, ApiBaseUrl, _, Patient) {
    $http.get(ApiBaseUrl + '/dashboard').success(function(data) {
      $scope.patients = _.map(data.patients, function(p) {return new Patient(p);});
      $scope.studies = data.studies;
    });
  });
