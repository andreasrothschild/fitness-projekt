app.directive('gridIsotope', function () {
    return {
        restrict: 'AE',
        link: function (scope, element, attrs) {
            var iso = new Isotope(element[0], {
                itemSelector: '.grid__item',
                layoutMode: 'masonry'
            });
        }
    };
});