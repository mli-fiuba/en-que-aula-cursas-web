var btnVolver = function () {
    $('.btn-volver').prepend('<span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span> &nbsp;&nbsp;&nbsp;');
}

var scrollTop = function () {
    $("html, body").animate({ scrollTop: 0 }, "slow");
}