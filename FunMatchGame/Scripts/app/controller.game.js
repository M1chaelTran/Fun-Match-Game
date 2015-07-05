angular.module('controller').controller('game', [
    '$scope', '$http', '$location', function($scope, $http, $location) {


        var game = {
            levels: [{ id: 1, label: 'Easy' }, { id: 2, label: 'Normal' }, { id: 3, label: 'Hard' }],
            solved: false,
            rows: 2,
            columns: 4,

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

        var createDeck = function() {
            $http.get('api/games/sets/1/cards/' + (game.rows * game.columns) / 2).success(function(cards) {
                // duplicate cards to make pairs and create deck;
                $scope.decks = _.chain(cards)
                    .union(angular.copy(cards))
                    .shuffle()
                    .groupBy(function(e, i) {
                        return Math.floor(i / game.columns);
                    })
                    .toArray()
                    .value();
            });
        };

        $scope.getWidth = function() {
            switch (game.level) {
            case 1:
                return 'col-md-3';
            default:
                return 'col-md-2';
            }
        };

        $scope.getHeight = function() {
            switch (game.level) {
                case 3:
                    return 'small';
                case 2:
                    return 'medium';
                default:
                    return 'large';
            }
        };

        var setDifficulty = function(level) {
            switch (level) {
            case 3:
                game.rows = 4;
                game.columns = 6;
                break;
            case 2:
                game.rows = 3;
                game.columns = 4;
                break;
            default:
                game.rows = 2;
                game.columns = 4;
                break;
            }
            game.level = level;
        };

        var setMode = function(mode) {
        };

        $scope.$on('$locationChangeSuccess', function() {
            setDifficulty($location.search().difficulty);
            setMode($location.search().mode);

            createDeck();
        });
    }
]);