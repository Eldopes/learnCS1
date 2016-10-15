/*
    Scripts for showing and hiding different tab content
*/
$(document).ready(function () {

    $('ul.tabs li').click(function () { // Showing and hiding "i know" and "i don't know" tabs
        var tab_id = $(this).attr('data-tab');

        $('ul.tabs li').removeClass('current');
        $('.tab-content').removeClass('current');

        $(this).addClass('current');
        $("#" + tab_id).addClass('current');
    })

    $("#show-button").click(function () { // Showing and hiding database results 
        if ($("#database-results").is(":visible")) {
            $("#database-results").hide("fast");
            document.getElementById("show-button").innerHTML = 'Show &raquo;';
        } else {
            $("#database-results").show("slow");
            document.getElementById("show-button").innerHTML = 'Hide &laquo;';
        }      
    });

})