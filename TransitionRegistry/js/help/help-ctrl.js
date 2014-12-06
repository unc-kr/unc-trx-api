'use strict';

angular.module('uncTrxApp')
  .directive('anchor', function() {
    return {
      restrict: 'A',
      link: function(scope, $elm, attrs) {
        var idToScroll = attrs.anchor;
        $elm.on('click', function() {
          var target = document.getElementById(idToScroll);
          window.scrollTo(target.offsetTop || target.clientTop, 0);
        });
      }
    }
  })
  .controller('HelpCtrl', function ($scope) {

  });
