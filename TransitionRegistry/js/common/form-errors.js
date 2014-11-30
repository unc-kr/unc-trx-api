'use strict';

angular.module('uncTrxApp')
  .constant('checkForm', function(form, fn) {
    if(form.$valid) {
      fn();
    } else {
      alert("There are errors in the form. Please correct them before resubmitting.");
    }
  });
