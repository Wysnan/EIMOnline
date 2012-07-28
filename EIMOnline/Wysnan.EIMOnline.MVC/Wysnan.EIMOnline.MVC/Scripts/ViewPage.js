$(document).ready(
function () {
    $(".tabs").tabs();
    $("input:submit,.button,input:button,.div_title").button();
    require(['/Scripts/jquery/jquery.validate.unobtrusive.min.js'], function () { });
    $(":text[data-val-required]").attr("class", "Required");
    $("input:submit").click(function () {
        setTimeout('showError()', 500);
    });

    $(":button[class*='back']").click(function () {
        GlobalObj.RemovePage(GlobalObj.currentPage);
    });

    var dateControl = $(":input[class*='Wdate']");
    if (dateControl) {
        dateControl.each(function (i, n) {
            //yyyy - MM - dd
            $(n).attr("onfocus")
            //alert($(n).val());
        });
    }
});

function showError() {
    if ($(".TableData [class*='input-validation-error']").length > 0) {
        $("#dialog_error").append($("#div_error").html());
        $("#dialog_error").dialog("open");
    }
}