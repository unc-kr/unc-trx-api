'use strict';

angular.module('uncTrxApp')
  .controller('PatientCtrl', function ($scope, $routeParams, $location, Patients) {
    Patients.get({id: $routeParams.id}, function(patient) {
      $scope.patient = patient;
      $scope.studies = patient.studies;
    })

    $scope.editPatient = function() {
      $location.path('/patients/' + $scope.patient.id + '/edit');
    }

    $scope.deletePatient = function() {
      if(confirm("Are you sure?")) {
        Patients.delete($scope.patient, function() {
          $location.path('/patients');
        });
      }
    }
  });
