/// <reference path="/Scripts/jquery-1.7.2.min.js" />
$(document).ready(function () {
    datePick = function (elem) {
        jQuery(elem).datepicker({ dateFormat: 'yy-mm-dd' });
    }
});
function aa() {
    var length = $("#list").css("width");
    length = length.substring(0, length.length - 2);
    $("#list").setGridWidth(1360);
}
function persist(grid) {
    var colModel = grid.getGridParam('colModel');
    var value = "";
    $(colModel).each(function (i, n) {
        if (n.hidden && n.hidden != false) {
            value += n.name + "_";
        }
    });
    value = value.substring(0, value.length - 1);
    $.get(SetJqGridColumn, { colModel: value });
}
function setSelectColModel(gridId) {
    var grid = $("#" + gridId);
    var colModel = grid.getGridParam('colModel');
    var value = "";
    $(colModel).each(function (i, n) {
        if (n.hidden == false) {
            value += n.name + "_";
        }
    });
    value = value.substring(0, value.length - 1);
    grid.jqGrid('appendPostData', { colModel: value });
}