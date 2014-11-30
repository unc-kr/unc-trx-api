'use strict';

angular.module('uncTrxApp')
  .controller('StudyNewCtrl', function ($rootScope, $scope, $routeParams, $location, Studies) {
    $scope.study = {};

    $scope.submit = function() {
      Studies.save($scope.study, $scope.study, function(study){
        $location.path('/studies/' + study.id);
      });
    }
  });
