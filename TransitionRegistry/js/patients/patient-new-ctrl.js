'use strict';

angular.module('uncTrxApp')
  .controller('PatientNewCtrl', function ($rootScope, $scope, $routeParams, $location, Patients, growl) {
    $scope.patient = {};

    $scope.submit = function() {
      $scope.patient.birthday = [$scope.patient.year, $scope.patient.month, $scope.patient.day].join('-');
      Patients.save($scope.patient, $scope.patient, function(patient){
        $location.path('/patients/' + patient.id);
      });
    }
  });
