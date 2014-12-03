'use strict';

angular.module('uncTrxApp')
  .factory('Study', function($injector) {
    return function(study) {
      for (var key in study) {
        this[key] = study[key];
      }

      if(this.patients) {
        var Patient = $injector.get('Patient');
        this.patients = _.map(this.patients, function(patient) {
          return new Patient(patient);
        });
      }
    }
  });