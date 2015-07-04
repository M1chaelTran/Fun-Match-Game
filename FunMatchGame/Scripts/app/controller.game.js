angular.module('controller').controller('game', [
    '$scope', '$http', function ($scope, $http) {

        function getCards(size) {

        };

        $scope.arrangeCard = function(index) {

        };

        var flip = function(card) {
            if (card) card.flipped = !card.flipped;
        };

        var reset = function() {
            flip($scope.first);
            flip($scope.second);

            $scope.first = null;
            $scope.second = null;
        };

        $scope.try = function(card) {
            if (card.solved) return;

            if ($scope.first && $scope.second) {
                flip($scope.first);
                flip($scope.second);

                $scope.first = null;
                $scope.second = null;

                return;
            }

            var first = $scope.first;
            var second = $scope.second;

            if (!first) {
                $scope.first = first = card;
            } else if (card != first && card != second) {
                $scope.second = second = card;
            } else {
                return;
            }

            flip(card);

            if (first && second && first.id == second.id) {
                first.solved = true;
                second.solved = true;
                $scope.first = null;
                $scope.second = null;
            }
        };

        $http.get('api/games/sets/1/cards/4').success(function(cards) {
            $scope.decks = [_.shuffle(cards), _.shuffle(angular.copy(cards))];
        });
    }
]);