'use strict';

angular.module('uncTrxApp')
  .filter('rangeFilter', function(_) {
    return function(vals, min, max, property) {
      min = parseInt(min);
      max = parseInt(max);

      if(min > max) {
        max = NaN
      } else if(max < min) {
        min = NaN
      }

      return _.filter(vals, function(val) {
        var val = parseInt(val[property]);
        return !((!isNaN(min) && val < min) || (!isNaN(max) && val > max))
      })
    }
  });