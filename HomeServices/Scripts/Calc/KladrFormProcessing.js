$(document).ready(function () {
    // Kladr api call on the input field is invoked from here
$(function () {
    // Forms to process:
    $('[name="From"]').kladr({
        type: $.kladr.type.city
    });

    $('[name="To"]').kladr({
        type: $.kladr.type.city
    });
});

});
