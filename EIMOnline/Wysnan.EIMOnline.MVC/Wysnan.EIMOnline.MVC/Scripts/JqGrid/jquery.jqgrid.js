// This file should be used if you want to debug
function jqGridInclude() {
    var pathtojsfiles = "http://localhost:65437"; // need to be ajusted
    // set include to false if you do not want some modules to be included
    //grid.base.js; jquery.fmatter.js; grid.custom.js; grid.common.js; grid.formedit.js; grid.filter.js; grid.inlinedit.js; grid.celledit.js; jqModal.js; 
    //jqDnR.js; grid.subgrid.js; grid.grouping.js; grid.treegrid.js; grid.import.js; JsonXml.js; grid.tbltogrid.js; grid.jqueryui.js; 
    var modules = [
    //{ include: false, incfile: '/Scripts/JqGrid/src/i18n/grid.locale-cn.js' }, // jqGrid translation
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.base.js' }, // jqGrid base
    //        {include: true, incfile: '/Scripts/JqGrid/src/jquery.fmatter.js' }, //jqGrid formater
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.custom.js' }, //jqGrid custom 
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.common.js' }, // jqGrid common for editing
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.formedit.js' }, // jqGrid Form editing
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.filter.js' }, // filter Plugin
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.inlinedit.js' }, // jqGrid inline editing
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.celledit.js' }, // jqGrid cell editing
    //    //{include: true, incfile: '/Scripts/JqGrid/src/jqModal.js' }, 
    //    //{include: true, incfile: '/Scripts/JqGrid/src/jqDnR.js' }, 
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.subgrid.js' }, //jqGrid subgrid
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.grouping.js' }, //jqGrid grouping
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.treegrid.js' }, //jqGrid treegrid
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.import.js' }, //jqGrid import
    //        {include: true, incfile: '/Scripts/JqGrid/src/JsonXml.js' }, //xmljson utils
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.tbltogrid.js' }, //jqGrid table to grid
    //        {include: true, incfile: '/Scripts/JqGrid/src/grid.jqueryui.js' }, //jQuery UI utils
        {include: true, incfile: '/Scripts/JqGrid/plugins/grid.postext.js' }
    ];
    var filename;
    for (var i = 0; i < modules.length; i++) {
        if (modules[i].include === true) {
            filename = pathtojsfiles + modules[i].incfile;
            document.writeln("<script type='text/javascript' src='" + filename + "'></script>");
            /*
            if(jQuery.browser.safari) {
            jQuery.ajax({url:filename,dataType:'script', async:false, cache: true});
            } else {
            IncludeJavaScript(filename);
            }
            */
        }
    }
    function IncludeJavaScript(jsFile) {
        var oHead = document.getElementsByTagName('head')[0];
        var oScript = document.createElement('script');
        oScript.type = 'text/javascript';
        oScript.charset = 'utf-8';
        oScript.src = jsFile;
        oHead.appendChild(oScript);
    };
};
jqGridInclude();