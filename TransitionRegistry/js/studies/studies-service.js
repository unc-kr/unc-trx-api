'use strict';

angular.module('uncTrxApp')
  .factory('Studies', function($resource, Study, moment, _, ApiBaseUrl) {
    var mapStudy = function(data) {
      var study = angular.fromJson(data);
      return new Study(study);
    };

    var mapStudies = function(data) {
      var studies = angular.fromJson(data);
      return _.map(studies, mapStudy);
    }

    return $resource(ApiBaseUrl + '/studies/:id', null, {
      'get':    {method:'GET', transformResponse: mapStudy},
      'save':   {method:'POST'},
      'query':  {method:'GET', isArray:true, transformResponse: mapStudies},
      'remove': {method:'DELETE'},
      'delete': {method:'DELETE'},
      'update': {method:'PUT' }
    });
  });
