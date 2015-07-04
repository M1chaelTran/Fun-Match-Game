(function () {
    'use strict';

    var app = 'funmatchgame';
    var dependencies = ['controller'];

    angular.module(app, dependencies);

    angular.element(document).ready(function() {
        angular.bootstrap(document, [app]);
    });
})();