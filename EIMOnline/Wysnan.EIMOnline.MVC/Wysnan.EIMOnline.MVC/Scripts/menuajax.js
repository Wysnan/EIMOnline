function persist(grid) {
   // var colModel = grid.getGridParam('colModel');
    var value = "";
    $(grid).each(function (i, n) {
        if (n.hidden && n.hidden != false) {
            value += n.name + "_";
        }
    });
    value = value.substring(0, value.length - 1);
    $.get(SetJqGridColumn, { colModel: value });
}

$(document).ready(function () {
    var obj = $("li[id*='menu_li_']");
    obj.click(function () {
        alert($(this).attr('id'));
        //        persist(this);
        //        alert("aa");
        if ($(".div_left_menu").width() == 200) {
            $(".div_left_menu").animate({ width: "20",
                height: "20"
            }, "slow");
        } else {
            $(".div_left_menu").animate({ width: "200",
                height: "650"
            }, "slow");
        }
    });
});