$(document).ready(function () {
    $(".hint-preview").hide();
    /*help balloon*/
    var isHelpBalloonClicked = false;
    $(".help-balloon").hide();
    $(".help-balloon").hover(function () {
        $(this).css("cursor", "pointer")
    });
    var interval = setInterval(function () {
        $(".help-balloon").toggle("slow");
    }, 6000);
    $(".help-balloon").click(function () {

        $.ajax({
            url: "GetHints",
            data: { idQuestion: GetQuestionId() },
            success: function (data) {
                for (var i = 0; i < data.success.length; i++) {
                    $(".continent").css("z-index", -1);
                    $(".hint-preview-items").append("<p>" + data.success[i] + "</p>");
                    $(".hint-preview-items").css("z-index", 1);
                    $(".hint-preview").show();
                    $(".hint-preview").css("z-index", 1);

                }
                $(".help-balloon").hide();
                clearInterval(interval);
            }
        });
    });
    $(".hint-preview").hover(function () {
        $(this).css("cursor", "pointer")
    });
    $(".hint-preview").click(function () {
        $(this).hide();
    });
    /*ball*/
    $(".ball").hover(function () {
        $(this).css("cursor", "pointer")
    });
    $(".ball").click(function () {
        var id = $(this).children(".ball-text").attr("id");

        $.ajax({
            url: "CheckAnswer",
            data: { idAnswer: id, idQuestion: GetQuestionId() },
            success: function (data) {
                if (data.success) {
                    $("#" + id).css({
                        "background-image": "url('/Content/photos/correct.png')",
                        "background-repeat": "no-repeat"
                    });

                    document.getElementById("audioElementCorrect").play();

                }
                else {
                    $("#" + id).css({
                        "background-image": "url('/Content/photos/incorrect.png')",
                        "background-repeat": "no-repeat"
                    });

                    document.getElementById("audioElementIncorrect").play();
                }

                $(".score").text(data.score);
            }
        });
    });

    function GetQuestionId() {
        return $(".idQuestion").val();
    }
});

