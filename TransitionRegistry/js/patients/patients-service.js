'use strict';

angular.module('uncTrxApp')
  .factory('Patients', function($resource, Patient, _, moment, ApiBaseUrl) {
    var mapPatient = function(data) {
      var patient = angular.fromJson(data);
      return new Patient(patient);
    };

    var mapPatients = function(data) {
      var patients = angular.fromJson(data);
      return _.map(patients, mapPatient);
    }

    return $resource(ApiBaseUrl + '/patients/:id', { id: '@_id',}, {
      'get':    {method:'GET', transformResponse: mapPatient},
      'save':   {method:'POST'},
      'query':  {method:'GET', isArray:true, transformResponse: mapPatients},
      'remove': {method:'DELETE'},
      'delete': {method:'DELETE'},
      'update': {method:'PUT' }
    });
  });
