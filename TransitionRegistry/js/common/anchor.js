'use strict';

angular.module('uncTrxApp')
  .directive('anchor', function() {
    return {
      restrict: 'A',
      require: '?ngModel',
      link: function(scope, elem, attrs, ngModel) {
        return elem.bind('click', function() {
          //other stuff ...
          var el;
          el = document.getElementById(attrs['anchor']);
          return el.scrollIntoView();
        });      
      }
    };
  });
