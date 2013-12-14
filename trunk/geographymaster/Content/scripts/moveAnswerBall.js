$(document).ready(function () {
    $(".ball:first").animate({
        left: $(window).width()
    }, {
        duration: 1000,
        step: function (now, fx) {
            $(".ball:gt(0)").css("left", now);
        }
    });
});

