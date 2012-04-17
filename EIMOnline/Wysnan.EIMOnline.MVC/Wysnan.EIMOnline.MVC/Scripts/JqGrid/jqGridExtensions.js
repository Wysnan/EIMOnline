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
    ///	<summary>
    ///		Persists column model to local storage.
    ///	</summary>
    ///	<param name="grid" optional="false" type="Object">The jqGrid whose column model is being persisted.</param>
    alert(grid);
    var colModel = grid.getGridParam('colModel');
    alert(colModel);
    //modules.storage.set(core.options.area + core.options.controller + grid.attr('data-token'), colModel, modules.storage.mode.local);
}