'use strict';

var app = angular.module('uncTrxApp');

app.constant('_', window._);
app.constant('moment', window.moment);
app.run(function ($rootScope) {
  $rootScope._ = window._;
  $rootScope.moment = window.moment;
});
