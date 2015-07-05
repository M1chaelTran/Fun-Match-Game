angular.module('controller').controller('game', [
    '$scope', '$http', function($scope, $http) {

        var game = {
            solved: false,
            rows: 3,
            columns: 2,
        };

        $scope.game = game;

        var flip = function() {
            _.forEach(arguments, function(card) {
                if (card) card.flipped = !card.flipped;
            });
        };

        $scope.play = function(card) {
            if (card.solved) return;

            var first = $scope.first;
            var second = $scope.second;

            if (first) {
                if (card == first) return;
                if (second) {
                    if (card == second) return;

                    $scope.first = card;
                    $scope.second = null;

                    flip(first, second, card);
                } else {
                    $scope.second = second = card;

                    if (first.id == second.id) {
                        first.solved = second.solved = true;
                        $scope.first = $scope.second = null;
                    }

                    flip(second);
                }
            } else {
                $scope.first = first = card;
                flip(first);
            }
        };

        $http.get('api/games/sets/1/cards/' + (game.rows * game.columns) / 2).success(function(cards) {
            // duplicate cards to make pairs and create deck;
            $scope.decks = _.chain(cards)
                .union(angular.copy(cards))
                .shuffle()
                .groupBy(function(e, i) {
                    return Math.floor(i / game.rows);
                })
                .toArray()
                .value();
        });
    }
]);