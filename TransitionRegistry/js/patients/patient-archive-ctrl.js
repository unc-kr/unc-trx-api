'use strict';

angular.module('uncTrxApp')
  .controller('PatientArchiveCtrl', function ($scope, $routeParams, $location, Patients) {
    Patients.get({id: $routeParams.id}, function(patient) {
      $scope.patient = patient;
    });

    $scope.submit = function() {
      if(confirm("Are you sure?")) {
        $scope.patient.archived = true;
        if($scope.patient.archiveDescriptionOption == 'Other') {
          $scope.patient.archiveDescription = $scope.patient.archiveDescriptionOther
        } else {
          $scope.patient.archiveDescription = $scope.patient.archiveDescriptionOption;
        }
        Patients.update($scope.patient, $scope.patient, function(patient) {
          $location.path('/patients');
        });
      }
    }
  });
