'use strict';

var app = angular.module('uncTrxApp', [
  'ngAnimate',
  'ngCookies',
  'ngResource',
  'ngRoute',
  'ngSanitize',
  'ngTouch',
  'ngInputDate',
  'ngQuickDate',
  'ng.httpLoader'
]);

app.config(function (ngQuickDateDefaultsProvider) {
    // Configure with icons from font-awesome
    return ngQuickDateDefaultsProvider.set({
        closeButtonHtml: "<i class='fa fa-times'></i>",
        buttonIconHtml: "<i class='fa fa-calendar'></i>",
        nextLinkHtml: "<i class='fa fa-chevron-right'></i>",
        prevLinkHtml: "<i class='fa fa-chevron-left'></i>"
    });
});

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
    .when('/patients/:id/archive', {
      templateUrl: 'js/patients/patient-archive-form.html',
      controller: 'PatientArchiveCtrl'
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
    .when('/studies/:id/archive', {
      templateUrl: 'js/studies/study-archive-form.html',
      controller: 'StudyArchiveCtrl'
    })
    .when('/help', {
      templateUrl: 'js/help/help-view.html',
      controller: 'HelpCtrl'
    })
    .otherwise({
      redirectTo: '/home'
    });
});

app.config(function (httpMethodInterceptorProvider) {
  httpMethodInterceptorProvider.whitelistDomain('');
});

app.run(function ($route, $rootScope, $location, $window, checkForm) {
  $rootScope.loc = $location.path;
  $rootScope.back = function() {
    $window.history.back();
  };
  $rootScope.checkForm = checkForm;
});
