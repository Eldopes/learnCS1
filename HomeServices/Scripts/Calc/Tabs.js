/*
    Scripts for showing and hiding "I know" and "I don't know tabs"
    "Content/Calc/Tabs.css" file is needed 
*/
$(document).ready(function () {
    $('ul.tabs li').click(function () {
        var tab_id = $(this).attr('data-tab');

        $('ul.tabs li').removeClass('current');
        $('.tab-content').removeClass('current');

        $(this).addClass('current');
        $("#" + tab_id).addClass('current');
    })
})