'use strict';

var app = angular.module('uncTrxApp', [
  'ngAnimate',
  'ngCookies',
  'ngResource',
  'ngRoute',
  'ngSanitize',
  'ngTouch',
  'ngInputDate'
]);

app.config(function ($routeProvider) {
  $routeProvider
    .when('/home', {
      templateUrl: 'js/home/home-view.html',
      controller: 'HomeCtrl'
    })
    .when('/patients', {
      templateUrl: 'js/patients/patients-view.html',
      controller: 'PatientsCtrl'
    })
    .when('/patients/new', {
      templateUrl: 'js/patients/patient-form-view.html',
      controller: 'PatientNewCtrl'
    })
    .when('/patients/:id', {
      templateUrl: 'js/patients/patient-view.html',
      controller: 'PatientCtrl'
    })
    .when('/patients/:id/edit', {
      templateUrl: 'js/patients/patient-form-view.html',
      controller: 'PatientEditCtrl'
    })
    .when('/studies', {
      templateUrl: 'js/studies/studies-view.html',
      controller: 'StudiesCtrl'
    })
    .when('/studies/new', {
      templateUrl: 'js/studies/study-form-view.html',
      controller: 'StudyNewCtrl'
    })
    .when('/studies/:id', {
      templateUrl: 'js/studies/study-view.html',
      controller: 'StudyCtrl'
    })
    .when('/studies/:id/edit', {
      templateUrl: 'js/studies/study-form-view.html',
      controller: 'StudyEditCtrl'
    })
    .when('/studies/:id/enrollments', {
      templateUrl: 'js/studies/study-enroll-view.html',
      controller: 'StudyEnrollCtrl'
    })
    .when('/help', {
      templateUrl: 'js/help/help-view.html',
      controller: 'HelpCtrl'
    })
    .otherwise({
      redirectTo: '/home'
    });
});

app.run(function ($route, $rootScope, $location, $window) {
  $rootScope.loc = $location.path;
  $rootScope.back = function() {
    $window.history.back();
  };
});
