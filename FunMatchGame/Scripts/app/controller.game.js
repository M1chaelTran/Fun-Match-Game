angular.module('controller').controller('game', [
    '$scope', '$timeout', function($scope, $timeout) {

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
        $scope.decks = [
            [
                { id: '1', 'title': 'A nice day!', src: "http://lorempixel.com/400/400/nature/1" },
                { id: '2', 'title': 'A nice day!', src: "http://lorempixel.com/400/400/nature/2" },
                { id: '3', 'title': 'A nice day!', src: "http://lorempixel.com/400/400/nature/3" },
                { id: '4', 'title': 'A nice day!', src: "http://lorempixel.com/400/400/nature/4" }
            ],
            [
                { id: '1', 'title': 'A nice day!', src: "http://lorempixel.com/400/400/nature/1" },
                { id: '2', 'title': 'A nice day!', src: "http://lorempixel.com/400/400/nature/2" },
                { id: '3', 'title': 'A nice day!', src: "http://lorempixel.com/400/400/nature/3" },
                { id: '4', 'title': 'A nice day!', src: "http://lorempixel.com/400/400/nature/4" }
            ]
        ];
    }
]);