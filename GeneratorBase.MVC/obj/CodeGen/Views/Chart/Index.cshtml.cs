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

namespace GeneratorBase.MVC.Views.Chart
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Chart/Index.cshtml")]
    public partial class Index : GeneratorBase.MVC.CustomWebViewPage<IEnumerable<GeneratorBase.MVC.Models.T_Chart>>
    {
        public Index()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Chart\Index.cshtml"
  
    ViewBag.Title = "Application Charts";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-save text-primary\"");

WriteLiteral("></i> Application Charts\r\n            <div");

WriteLiteral(" class=\"btn btn-default btn-sm dropdown pull-right\"");

WriteLiteral(" style=\"border: 0px solid #c3ddec !important; font-size:12px;\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral("> Add Chart <b");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></b></a>\r\n                <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                    <li><a");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 697), Tuple.Create("\"", 876)
            
            #line 13 "..\..\Views\Chart\Index.cshtml"
                     , Tuple.Create(Tuple.Create("", 707), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Application Chart','dvPopup','" + Url.Action("CreateQuick", "Chart", new { UrlReferrer = Request.Url, TS = DateTime.Now }) + "')")
            
            #line default
            #line hidden
, 707), false)
);

WriteLiteral("> Add Chart</a></li>\r\n                </ul>\r\n            </div>\r\n        </h1>\r\n " +
"   </div>\r\n</div>\r\n");

            
            #line 19 "..\..\Views\Chart\Index.cshtml"
Write(Html.Partial("~/Views/Chart/IndexPartial.cshtml", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591