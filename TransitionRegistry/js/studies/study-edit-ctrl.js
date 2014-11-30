'use strict';

angular.module('uncTrxApp')
  .controller('StudyEditCtrl', function ($scope, $routeParams, $location, Studies) {
    Studies.get({id: $routeParams.id}, function(study) {
      $scope.study = study;
    });

    $scope.submit = function() {
      Studies.update($scope.study, $scope.study, function(study) {
        $location.path('/studies/' + study.id);
      });
    }
  });
