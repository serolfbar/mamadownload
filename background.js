'use strict';

let background = {
  config: {},
  init: function() {
    chrome.webNavigation.onCompleted.addListener(function() {
    }, {url: [{urlContains : 'youtube.com'}]});
  },
}

background.init();
