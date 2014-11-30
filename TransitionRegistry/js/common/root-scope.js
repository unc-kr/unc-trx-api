'use strict';

var app = angular.module('uncTrxApp');

app.run(function ($rootScope, $location) {
  $rootScope.stopPropagation = function(e) {
    e.stopPropagation();
  }

  $rootScope.loc = function(u) { $location.path(u) };
});
