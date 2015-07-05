angular.module('controller').controller('menu', [
    '$scope', '$location', function($scope, $location) {

        $scope.setDifficulty = function(level) {
            $location.search('difficulty', level);
        };

        $scope.setMode = function(mode) {
            $location.search('mode', mode);
        };
    }
]);