'use strict';

angular.module('uncTrxApp')
  .factory('Patients', function($resource, ApiBaseUrl) {
    return $resource(ApiBaseUrl + '/patients/:id', { id: '@_id',}, {
      'update': { method:'PUT' }
    });
  });
