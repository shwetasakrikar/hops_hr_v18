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

namespace GeneratorBase.MVC.Views.T_AllFacilitiesUnit
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_AllFacilitiesUnit/ShowHideColumns.cshtml")]
    public partial class ShowHideColumns : GeneratorBase.MVC.CustomWebViewPage<dynamic>
    {
        public ShowHideColumns()
        {
        }
        public override void Execute()
        {
WriteLiteral("<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(document).ready(function ()\r\n    {\r\n         var usrName = \"");

            
            #line 4 "..\..\Views\T_AllFacilitiesUnit\ShowHideColumns.cshtml"
                   Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
WriteLiteral("\";\r\n        var myCookie = usrName + \"T_AllFacilitiesUnit\" + \"");

            
            #line 5 "..\..\Views\T_AllFacilitiesUnit\ShowHideColumns.cshtml"
                                                     Write(ViewData["AssociatedType"]);

            
            #line default
            #line hidden
WriteLiteral("\";\r\n        var host = \"#T_AllFacilitiesUnit\";\r\n        if (\"");

            
            #line 7 "..\..\Views\T_AllFacilitiesUnit\ShowHideColumns.cshtml"
        Write(ViewData["AssociatedType"]);

            
            #line default
            #line hidden
WriteLiteral("\".length > 0)\r\n            host = \"#\" + \"");

            
            #line 8 "..\..\Views\T_AllFacilitiesUnit\ShowHideColumns.cshtml"
                     Write(ViewData["AssociatedType"]);

            
            #line default
            #line hidden
WriteLiteral(@""";
        if ($.cookie(myCookie) != null) {
            var column = $.cookie(myCookie).split(',');
            for (var i = 0; i < column.length; i++) {
                if (column[i] == ""col1"")
                    continue;
                $('input[name=' + column[i] + ']', $(host)).attr('checked', false);
                var index = column[i].substr(3)
               //index--;
                $('table tr', $(host)).each(function () {
                    $('td:eq(' + index + ')', this).toggle();
                });
                $('th.' + column[i], $(host)).toggle();
            }
        }
    });
</script>           
<div");

WriteLiteral(" id=\"ColumnShowHideT_AllFacilitiesUnit\"");

WriteLiteral(" class=\"collapse\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\'col-sm-12\'");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n                    <h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">Show / Hide Table  Column </h3>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n\t\t\t\t\t<p");

WriteLiteral(" id=\"lblT_AllFacilitiesUnit\"");

WriteLiteral(" class=\"label label-success \"");

WriteLiteral(" style=\"display:none; width:100%; padding:5px; text-align:left; font-size:13px\"");

WriteLiteral(">Table display format successfully saved.</p>\r\n\t\t\t\t\t<p");

WriteLiteral(" id=\"lblWarningT_AllFacilitiesUnit\"");

WriteLiteral(" class=\"label label-warning \"");

WriteLiteral(" style=\"display:none; width:100%; padding:5px; text-align:left; font-size:13px\"");

WriteLiteral(">Select at least one property to display on grid.</p>\r\n                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n\t\t\t\t\t\t    ");

WriteLiteral("\r\n                            <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"col1\"");

WriteLiteral(" checked=\"checked\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" />\r\n\t<input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"col2\"");

WriteLiteral(" checked=\"checked\"");

WriteLiteral(" onclick=\"ColumnClick(event,\'T_AllFacilitiesUnit\')\"");

WriteLiteral(" /> Name\r\n\t<input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"col3\"");

WriteLiteral(" checked=\"checked\"");

WriteLiteral(" onclick=\"ColumnClick(event,\'T_AllFacilitiesUnit\')\"");

WriteLiteral(" /> Description\r\n<input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"col4\"");

WriteLiteral(" checked=\"checked\"");

WriteLiteral(" onclick=\"ColumnClick(event,\'T_AllFacilitiesUnit\')\"");

WriteLiteral(" /> Facility\r\n                        </div>\r\n                       <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"btnSave\"");

WriteLiteral(" value=\"Set as Default\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2539), Tuple.Create("\"", 2660)
, Tuple.Create(Tuple.Create("", 2549), Tuple.Create("showhideSaveCookies(event,", 2549), true)
, Tuple.Create(Tuple.Create(" ", 2575), Tuple.Create("\'T_AllFacilitiesUnit\',", 2576), true)
, Tuple.Create(Tuple.Create(" ", 2598), Tuple.Create("\'", 2599), true)
            
            #line 43 "..\..\Views\T_AllFacilitiesUnit\ShowHideColumns.cshtml"
                                                            , Tuple.Create(Tuple.Create("", 2600), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 2600), false)
, Tuple.Create(Tuple.Create("", 2627), Tuple.Create("\',\'", 2627), true)
            
            #line 43 "..\..\Views\T_AllFacilitiesUnit\ShowHideColumns.cshtml"
                                                                                          , Tuple.Create(Tuple.Create("", 2630), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 2630), false)
, Tuple.Create(Tuple.Create("", 2657), Tuple.Create("\');", 2657), true)
);

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" />\r\n                    </div>\r\n                </div>\r\n            </div>\r\n    " +
"    </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
