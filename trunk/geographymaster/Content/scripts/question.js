$(document).ready(function () {
    $(".hint-preview").hide();
    $(".new-badge").hide();
    $(".master-badge").hide();
    $(".info-box-preview").hide();
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
                $(".info-box-preview").hide();
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
    /*infobox*/
    var isInfoBoxClicked = false;
    $(".info-box").hover(function () {
        $(this).css("cursor", "pointer")
    });

    $(".info-box").click(function () {

        $.ajax({
            url: "GetInfoBox",
            data: { idQuestion: GetQuestionId() },
            success: function (data) {
                if (data.success != "") {
                    $(".hint-preview").hide();
                    $(".continent").css("z-index", -1);
                    $(".info-box-preview-items").append("<p>" + data.success + "</p>");
                    $(".info-box-preview-items").css("z-index", 1);
                    $(".info-box-preview").show();
                    $(".info-box-preview").css("z-index", 1);
                }
            }
        });

    });

    $(".info-box-preview").click(function () {
        $(this).hide();
    });
    $(".master-badge-items").click(function () {
        $(".master-badge").remove();
    });
    $(".new-badge-items").click(function () {
        $(".new-badge").remove();
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

                if (data.master == true) {
                    $(".master-badge").show().animate({ left: '500px' });
                    $(".master-badge-items").append("<img src='/Content/photos/category/masterAllCategories.png'/>")
                }
                else if (data.badge == true) {
                    $(".new-badge").show().animate({ left: '500px' });
                    $(".new-badge-items").append("<img src='/Content/photos/category/masterOfContinent.png'/>")
                    
                }

                $(".score").text(data.score);
            }
        });
    });
   
    function GetQuestionId() {
        return $(".idQuestion").val();
    }
});

