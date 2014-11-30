'use strict';

angular.module('uncTrxApp')
  .controller('StudyEnrollCtrl', function ($scope, $routeParams, $location, $http, Studies, Patients, _, ApiBaseUrl) {
    $scope.refresh = function() {
       Studies.get({id: $routeParams.id}, function(study) {
         $scope.study = study;

         Patients.query(function(patients) {
           var patientIds = _.pluck($scope.study.patients, 'id');
           $scope.patients = _.map(patients, function(patient){
             patient.enrolled = _.contains(patientIds, patient.id)
             return patient;
           });
           console.log($scope.patients)
         });
       });   
    };
    $scope.refresh();

    $scope.enrollPatient = function(patient) {
      $http.post(ApiBaseUrl + 'api/studies/' + $scope.study.id + '/patients/' + patient.id).then(function() {
        $scope.refresh();
      });
    };

    $scope.unenrollPatient = function(patient) {
      $http['delete'](ApiBaseUrl + 'api/studies/' + $scope.study.id + '/patients/' + patient.id).then(function() {
        $scope.refresh();
      });
    };
  });
