'use strict';

angular.module('uncTrxApp')
  .controller('StudyCtrl', function ($scope, $routeParams, $location, Studies) {
    Studies.get({id: $routeParams.id}, function(study) {
      $scope.study = study;
      $scope.patients = study.patients;
    });

    $scope.editStudy = function() {
      $location.path('/studies/' + $scope.study.id + '/edit');
    }

    $scope.editEnrollments = function() {
      $location.path('/studies/' + $scope.study.id + '/enrollments');
    }

    $scope.deleteStudy = function() {
      if(confirm("Are you sure?")) {
        Studies.delete($scope.study, function() {
          $location.path('/studies');
        });
      }
    }
  });