function MenuTypeNavigation(id, name, url, image) {
    Navigation(id, name, url, image);

    $.get("/Framework/Ajax/SystemModule.ashx", { meetid: id }, function sellerList(data) {
        alert(data);
        //var obj = eval("(" + data + ")"); //转换后的JSON对象 
        $("#div_left_menu").html(obj.CellerList);
    }, "html"); 
}
