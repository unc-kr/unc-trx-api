'use strict';

angular.module('uncTrxApp')
  .factory('Patient', function($injector) {
    return function(patient) {
      for (var key in patient) {
        this[key] = patient[key];
      }

      this.age = moment().diff(moment(this.birthday.slice(0, this.birthday.indexOf('T'))), 'years');
      if(this.studies) {
        var Study = $injector.get('Study');
        this.studies = _.map(this.studies, function(study) {
          return new Study(study);
        });
      }
    }
  });