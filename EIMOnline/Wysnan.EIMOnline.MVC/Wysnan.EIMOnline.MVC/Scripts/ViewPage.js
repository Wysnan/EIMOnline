$(document).ready(
function () {
    $("#tabs").tabs();
    $("input:submit, a,input:button", ".div_title").button();
    require(['/Scripts/jquery/jquery.validate.unobtrusive.min.js'], function () { });
    $(":text[data-val-required]").attr("class", "Required");
    $("input:submit").click(function () {
        setTimeout('showError()', 500);
    });
});
$(document).ready(
function () {
    $("#tabs").tabs();
    $("input:submit, a,input:button", ".div_titleAttence").button();
    require(['/Scripts/jquery/jquery.validate.unobtrusive.min.js'], function () { });
    $(":text[data-val-required]").attr("class", "Required");
    $("input:submit").click(function () {
        setTimeout('showError()', 500);
    });
});
function showError() {
    if ($(".TableData [class*='input-validation-error']").length > 0) {
        $("#dialog_error").append($("#div_error").html());
        $("#dialog_error").dialog("open");
    }
}