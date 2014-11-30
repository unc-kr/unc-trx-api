'use strict';

angular.module('uncTrxApp')
  .controller('StudiesCtrl', function ($scope, $location, Studies) {
    var refresh = function() {
      $scope.studies = Studies.query();
    }
    refresh();

    $scope.newStudy = function() {
      $location.path('/studies/new');
    };
  });
