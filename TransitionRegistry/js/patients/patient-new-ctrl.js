'use strict';

angular.module('uncTrxApp')
  .controller('PatientNewCtrl', function ($rootScope, $scope, $routeParams, $location, Patients) {
    $scope.patient = {};

    $scope.submit = function() {
      Patients.save($scope.patient, $scope.patient, function(patient){
        $location.path('/patients/' + patient.id);
      });
    }
  });
