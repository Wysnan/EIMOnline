/// <reference path="/Scripts/jquery-1.7.2.min.js" />

$(document).ready(function () {
    $("#imgSet").click(function () {
        if ($(".div_tool").width() == 200) {
            $(".div_tool").animate({ width: "20",
                height: "20"
            }, "slow");
        } else {
            $(".div_tool").animate({ width: "200",
                height: "650"
            }, "slow");
        }
    });
    $("#img_leftSet").click(function () {
        if ($(".div_left").width() == 250) {
            $(".div_left").animate({ width: "20"
            }, "slow");
            $(".div_right").animate({ width: "1543" }, "slow");
        } else {
            $(".div_left").animate({ width: "250"
            }, "slow");
            $(".div_right").animate({ width: "1313" }, "slow");
        }
    });
    //    InitPage();
    //    GlobalObj.setPages();


});
function InitPage() {
    if (GlobalObj.page == null) {
        var pages = new Array();
        var page = new Page();
        page.name = "add";
        page.url = window.location.href;
        pages.push(page);
    }
}
var GlobalObj =
    {
        'pages': new Array(),
        'AddPage': function (obj) {
            var isExist = false;
            $(this.pages).each(function (i, n) {
                if (n.url == obj.url) {
                    isExist = true;
                }
            });
            if (isExist === false) {
                var div = "<div class=\"pageItemDiv\" id=\"item_" + obj.name + "\"><div class=\"pageItem\">" + obj.name + "</div><div class=\"pageItemClose\" onclick=\"ItemClose('item_" + obj.name + "')\">×</div></div>";
                $(".div_foot").append(div);
                this.pages.push(obj);
//                $("#WidgetColumn").append("<li id=\"li_t\"></li>");
//                $("#li_t").load(obj.url);
            }
        },
        'RemovePage': function (name) {
            $("#" + name).remove();
        }
    };
function Page(name) {
    this.name = name;
    this.url = null;
    this.image = null
};

function Navigation(name, url, image) {
    var page = new Page();
    page.name = name;
    page.url = url;
    page.image = image;
    GlobalObj.AddPage(page);
    //    alert("123");
    //    var innerHtml = "WidgetColumn";
    // div_main
}

function ItemClose(obj) {
    GlobalObj.RemovePage(obj);
}

