'use strict';

angular.module('uncTrxApp')
  .controller('HomeCtrl', function ($scope, $http, ApiBaseUrl) {

    $http.get(ApiBaseUrl + '/dashboard').success(function(data) {
      $scope.patients = data.patients;
      $scope.studies = data.studies;
    });
  });
