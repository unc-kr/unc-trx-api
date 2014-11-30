'use strict';

angular.module('uncTrxApp')
  .directive('activeLink', function ($location) {
    return {
      restrict: 'A',
      link: function(scope, element, attrs, controller) {
        var clazz = attrs.activeLink;
        var path = angular.element(element).children("a")[0].hash.substring(1);
        scope.location = $location;
        scope.$watch('location.path()', function(newPath) {
          if (newPath.indexOf(path) === 0) {
            element.addClass(clazz);
          } else {
            element.removeClass(clazz);
          }
        });
      }
    };
  });
