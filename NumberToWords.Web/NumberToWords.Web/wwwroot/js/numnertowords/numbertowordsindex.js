$(document).ready(function () {

    $("#btnSubmit").click(function () {
        //debugger;

        const amount = $("#txtAmount").val() ? $("#txtAmount").val().trim() : "" ;

        if (!validateAmount(amount)) {
            return;
        }

        $.ajax({
            url: "../NumberToWords/NumberToWordsIndex",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ amount: amount }),
            beforeSend: function () {
                $("#loader").css("display", "flex");
                $("#resultBox").text("");
            },
            success: function (response) {
                debugger;
                if (response && response.success) {
                    $("#resultBox").text(response.data);
                }
                else {
                    $("#resultBox").text(response.message);
                }
            },
            error: function () {

                $("#resultBox").text("Error occurred while converting.");
            },
            complete: function () {       
                setTimeout(function () {
                    $("#loader").hide();
                }, 100);
            }
        });

    });

    $('.allowDecimalOnly').on("input", function () {
        /*debugger;*/

        let value = $(this).val();

        value = value.replace(/[^0-9.]/g, "");

        if (value.startsWith("0") &&
            value.length > 1 &&
            !value.startsWith("0.")) {

            value = value.replace(/^0+/, "");
        }

        const parts = value.split(".");

        if (parts.length > 2) {

            value = parts[0] + "." + parts[1];
        }

        if (parts[1]) {

            parts[1] = parts[1].substring(0, 2);

            value = parts[0] + "." + parts[1];
        }

        if (value.length > 18) {

            value = value.substring(0, 18);
        }

        $(this).val(value);

        validateAmount(value);

    });

});

function validateAmount(value) {
    /*debugger;*/

    $("#dspAmount").text("");

    if (value === "" || isNaN(value)) {
        $("#dspAmount").text("Please enter a valid amount (numbers).");
        return false;
    }

    if (/^0+(\.0{1,2})?$/.test(value)) {

        $("#dspAmount").text("Please enter a valid amount (numbers).");

        return false;
    }

    if (parseFloat(value) > 999999999999999.99) {

        $("#dspAmount").text(
            "Maximum allowed amount (numbers) is 999999999999999.99"
        );

        return false;
    }

    if (!/^\d+(\.\d{1,2})?$/.test(value)) {

        $("#dspAmount").text(
            "Only 2 decimal places are allowed."
        );

        return false;
    }

    return true;
}