$(document).ready(function () {

    $(".ball").hover(function () {
        $(this).css("cursor", "pointer")
    });

    $(".ball").click(function () {
        var id = $(this).children(".ball-text").attr("id");
        var idQ = $(".idQuestion").val();

        $.ajax({
            url: "CheckAnswer",
            data: { idAnswer: id, idQuestion: idQ },
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
            }
        });
    });
});

