/// <reference path="/Scripts/jquery-1.7.2.min.js" />
$(document).ready(function () {
    datePick = function (elem) {
        jQuery(elem).datepicker({
            // jQuery(elem).datetimepicker({ 
            dateFormat: 'yy-mm-dd',
            timeFormat: 'hh:mm:ss', //格式化时间
            stepHour: 1, //设置步长
            stepMinute: 1
        });
    }
});
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