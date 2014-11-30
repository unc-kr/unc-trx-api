'use strict';

angular.module('uncTrxApp')
  .controller('StudyArchiveCtrl', function ($scope, $routeParams, $location, Studies) {
    Studies.get({id: $routeParams.id}, function(study) {
      $scope.study = study;
    });

    $scope.submit = function() {
      if(confirm("Are you sure?")) {
        $scope.study.archived = true;
        if($scope.study.archiveDescriptionOption == 'Other') {
          $scope.study.archiveDescription = $scope.study.archiveDescriptionOther
        } else {
          $scope.study.archiveDescription = $scope.study.archiveDescriptionOption;
        }
        Studies.update($scope.study, $scope.study, function(study) {
          $location.path('/studies');
        });
      }
    }
  });
