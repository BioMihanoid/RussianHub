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

$(function () {
    $('.burger').click(function (event) {
        $('.burger, .log, .home, .hidden_category, .Navbar').toggleClass('active');
        $('.Category, .Navbar-nav-top_menu, .form, .content-container, .log').toggleClass('visible');
    });
});


$(function () {
    $('.hidden_category').click(function (event) {
        $('.Category').toggleClass('hidden_menu');
    });
});

$(".hidden_sort_top").hover(function () {
    $('#sort_id_1').show();
}, function () {
    $('#sort_id_1').hide();
});

$(".hidden_sort_view").hover(function () {
    $('#sort_id_2').show();
}, function () {
    $('#sort_id_2').hide();
});




$("#sort_id_3").hover(function () {
    $('.hidden_sort_sex').show();
}, function () {
    $('.hidden_sort_sex').hide();
});

$("#sort_id_4").hover(function () {
    $('.hidden_sort_value').show();
}, function () {
    $('.hidden_sort_value').hide();
});

