'use strict';

angular.module('uncTrxApp')
  .controller('PatientsCtrl', function ($rootScope, $scope, $location, $http, _, ApiBaseUrl, Patients) {
    var refresh = function() {
      $scope.patients = Patients.query();
    }
    refresh();

    $scope.newPatient = function() {
      $location.path('/patients/new');
    }
  });
