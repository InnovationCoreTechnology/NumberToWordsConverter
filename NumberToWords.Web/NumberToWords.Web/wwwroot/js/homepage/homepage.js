$(document).ready(function () {

    $("#open").click(function () {

        $("#envelope")
            .addClass("open")
            .removeClass("close");

        setTimeout(function () {
            window.location.href = "/NumberToWords/NumberToWordsIndex";
        }, 1900);

    });

});