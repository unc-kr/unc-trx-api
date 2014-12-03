'use strict';

angular.module('uncTrxApp')
  .controller('PatientsCtrl', function ($rootScope, $scope, $location, $http, _, ApiBaseUrl, Patients) {
    var refresh = function() {
      Patients.query(function(patients) {
        $scope.patients = patients; 
      });
    }
    refresh();

    $scope.newPatient = function() {
      $location.path('/patients/new');
    }
  });
