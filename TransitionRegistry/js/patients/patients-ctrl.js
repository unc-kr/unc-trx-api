'use strict';

angular.module('uncTrxApp')
  .controller('PatientsCtrl', function ($rootScope, $scope, $location, $http, _, ApiBaseUrl, Patients) {
    var refresh = function() {
      Patients.query(function(patients) {
        $scope.patients = patients; 
        _.forEach($scope.patients, function(patient) {
          patient.age = moment().diff(moment(patient.birthday.slice(0, patient.birthday.indexOf('T'))), 'years');
        }); 
      });
    }
    refresh();

    $scope.newPatient = function() {
      $location.path('/patients/new');
    }
  });
