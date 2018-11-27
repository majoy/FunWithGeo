(function (funwithgeo, $, undefined) {
    //Public Property
    funwithgeo.settings = {
        
    };

    //Public Methods
    funwithgeo.initialize = function () {
        initializeComponents();
        console.log("Done initializing...");
    };

    //Private Methods
    function initializeComponents() {
        $('[data-numeric-only]').each(function() {
            var $el = $(this);
            $el.keyup(function () {
                var valueReplaced = this.value.replace(/[^0-9\.]/g, '');
                if (this.value != valueReplaced) {
                    this.value = valueReplaced;
                }
            });
        });
    }
}(window.funwithgeo = window.funwithgeo || {}, jQuery));

$(document).ready(function() {
    window.funwithgeo.initialize();
});