'use strict';

angular.module('uncTrxApp')
  .controller('PatientEditCtrl', function ($scope, $routeParams, $location, Patients) {
    Patients.get({id: $routeParams.id}, function(patient) {
      $scope.patient = patient;
    });

    $scope.submit = function() {
      Patients.update($scope.patient, $scope.patient, function(patient) {
        $location.path('/patients/' + patient.id);
      });
    };
  });
