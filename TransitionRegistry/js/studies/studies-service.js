'use strict';

angular.module('uncTrxApp')
  .factory('Studies', function($resource, ApiBaseUrl) {
    return $resource(ApiBaseUrl + '/studies/:id', null, {
      'update': { method:'PUT' }
    });
  });
