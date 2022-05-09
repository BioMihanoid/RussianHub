// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



/*VIDEO JS*/

$(function () {
    var $refreshButton = $('#refresh');
    var $results = $('#css_result');

    function refresh() {
        var css = $('style.cp-pen-styles').text();
        $results.html(css);
    }

    refresh();
    $refreshButton.click(refresh);

    // Select all the contents when clicked
    $results.click(function () {
        $(this).select();
    });
});



