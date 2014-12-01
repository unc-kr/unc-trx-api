'use strict';

angular.module('uncTrxApp')
  .controller('PatientEditCtrl', function ($scope, $routeParams, $location, Patients, moment) {
    Patients.get({id: $routeParams.id}, function(patient) {
      $scope.patient = patient;
      var m = moment($scope.patient.birthday.slice(0, $scope.patient.birthday.indexOf('T')));
      $scope.patient.year = m.format("YYYY");
      $scope.patient.month = m.format("M");
      $scope.patient.day = m.format("D");
    });

    $scope.submit = function () {
      $scope.patient.birthday = [$scope.patient.year, $scope.patient.month, $scope.patient.day].join('-');
      Patients.update($scope.patient, $scope.patient, function(patient) {
        $location.path('/patients/' + patient.id);
      });
    };
  });
