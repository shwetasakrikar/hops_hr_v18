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

namespace GeneratorBase.MVC.Views.Error
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Error/ConcurrencyError.cshtml")]
    public partial class ConcurrencyError : GeneratorBase.MVC.CustomWebViewPage<dynamic>
    {
        public ConcurrencyError()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\Error\ConcurrencyError.cshtml"
  
    ViewBag.Title = "Concurrency Alert";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-exclamation-sign text-primary\"");

WriteLiteral("></i> Concurrency Alert \r\n        </h1>\r\n        <label");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" class=\"text-primary small pull-right\"");

WriteLiteral(" style=\"color:red; vertical-align:middle; font-weight:100;\"");

WriteLiteral("></label>\r\n        <p");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\Error\ConcurrencyError.cshtml"
                           Write(ViewData["ConcurrencyMessage"]);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("        ");

            
            #line 11 "..\..\Views\Error\ConcurrencyError.cshtml"
   Write(Html.ActionLink("Get updated record", "ConcurrencyButton", new { UrlReferrer = ViewData["ConcurrencyReferrer"] },new {@class = "btn btn-default btn-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
