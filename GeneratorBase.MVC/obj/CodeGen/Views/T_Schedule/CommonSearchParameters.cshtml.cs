#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeneratorBase.MVC.Views.T_Schedule
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using GeneratorBase.MVC;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Schedule/CommonSearchParameters.cshtml")]
    public partial class CommonSearchParameters : GeneratorBase.MVC.CustomWebViewPage<Int32>
    {
        public CommonSearchParameters()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"\"");

WriteLiteral(">\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n<script>\r\n\r\n    function SearchCalendar(obj)" +
"\r\n    {\r\n        var dataurl = $(obj).attr(\"dataurl\");\r\n        \r\n        locati" +
"on.href = dataurl;\r\n    }\r\n\t\r\n     $(document).ready(function () {\r\n        $(\'." +
"fc-agendaWeek-button\').click();\r\n        $(\'select[multiple=\"multiple\"]\').each(f" +
"unction () {\r\n            $(this).multiselect({ buttonWidth: \'100%\', nonSelected" +
"Text: \'ALL\' });\r\n            var assocId = $(this).attr(\'id\');\r\n            fill" +
"MultiSelectAssociation(assocId);\r\n        });\r\n\t\t      });\r\n\t  function urlParam" +
"(name) {\r\n        var results = new RegExp(\'[\\?&]\' + name + \'=([^&#]*)\').exec(wi" +
"ndow.location.href);\r\n        var value = \"\";\r\n        if (results != null && re" +
"sults!=undefined)\r\n            value = results[1]\r\n        return value;\r\n    }\r" +
"\n\t function fillMultiSelectAssociation(assocId) {\r\n        if ($(\"#\" + assocId)." +
"length > 0) {\r\n            var resObj = AntiSanitizeURLString(urlParam(assocId))" +
".split(\",\");\r\n            var eleObj = document.getElementById(assocId);\r\n      " +
"      FillMultiSelectDropDown(resObj, eleObj, assocId);\r\n        }\r\n\t}\r\n\tvar ope" +
"nfalg = false;\r\n    function FillMultiSelectDropDown(result, element, elementNam" +
"e) {\r\n\t if (element == null || element == undefined)\r\n            return false;\r" +
"\n\r\n        var isHaveNullSelect = false;\r\n        var countoptions = 0;\r\n\t\t var " +
"itmseleted = 0;\r\n        for (var o = 0; o < element.options.length; o++) {\r\n   " +
"         if (result.indexOf(element.options[o].value)!=-1)\r\n                elem" +
"ent.options[o].selected = true;\r\n            else if (result.indexOf(\"NULL\")!=-1" +
")\r\n                isHaveNullSelect = true;\r\n            countoptions++;\r\n      " +
"  }\r\n\r\n\t\tif (itmseleted > 0) {\r\n            if (!openfalg) {\r\n                $(" +
"\"#A\" + $(\"#\" + elementName).closest(\'.panel-collapse\').attr(\'id\')).click();\r\n   " +
"             openfalg = true;\r\n            }\r\n        }\r\n\r\n         var opt = do" +
"cument.createElement(\'option\');\r\n        opt.value = \"NULL\";\r\n        opt.innerH" +
"TML = \"None\";\r\n        if (isHaveNullSelect) {\r\n            opt.selected = true;" +
"\r\n            element.insertBefore(opt, element.firstChild);\r\n        }\r\n\t\t//if " +
"(!isHaveNullSelect) {\r\n        if ($(\"#\" + elementName + \" option[value=NULL]\")." +
"length == 0) {\r\n            element.insertBefore(opt, element.firstChild);\r\n    " +
"    }\r\n        $(\"#\" + elementName).multiselect(\"rebuild\");\r\n        if (countop" +
"tions >= 10) {\r\n            var hostingentity = elementName;\r\n            var ur" +
"lGetAll = $(\'#\' + hostingentity).attr(\"dataurl\").replace(\"GetAllMultiSelectValue" +
"\", \"Index\") + \"?BulkOperation=multiple\";\r\n            var dispName = ($(\"label[f" +
"or=\\\"\" + hostingentity + \"\\\"]\").text());\r\n            var link = \"<a onclick=\\\"\"" +
" + \"OpenPopUpBulkOperation(\'PopupBulkOperation\',\'\" + hostingentity + \"\',\'\" + dis" +
"pName + \"\',\'dvPopupBulkOperation\',\'\" + urlGetAll + \"\')\\\">View All</a>\";\r\n       " +
"     var getall = \"<li class=\'disabled-result disabled-result\' style=\'font-style" +
":Italic;text-decoration:underline;\' >\" + link + \"</li>\";\r\n            var $ul = " +
"$(\"ul\", \"#dv\" + elementName);\r\n            $(\"#dv\" + elementName).find(\"ul\").app" +
"end($(getall))\r\n\r\n        }\r\n    }\r\n\r\n</script>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591