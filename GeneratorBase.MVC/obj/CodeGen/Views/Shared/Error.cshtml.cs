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

namespace GeneratorBase.MVC.Views.Shared
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Error.cshtml")]
    public partial class Error : GeneratorBase.MVC.CustomWebViewPage<System.Web.Mvc.HandleErrorInfo>
    {
        public Error()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Shared\Error.cshtml"
  
    ViewBag.Title = "Application Exception";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n        <i");

WriteLiteral(" class=\"glyphicon glyphicon-exclamation-sign text-primary\"");

WriteLiteral("></i> Exception Alert\r\n    </h1>\r\n    <p");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">\r\n        Entity :<b> ");

            
            #line 10 "..\..\Views\Shared\Error.cshtml"
               Write(Model.ControllerName);

            
            #line default
            #line hidden
WriteLiteral(" </b><br>\r\n        Action:<b> ");

            
            #line 11 "..\..\Views\Shared\Error.cshtml"
              Write(Model.ActionName);

            
            #line default
            #line hidden
WriteLiteral(" </b><br>\r\n        Exception:  ");

            
            #line 12 "..\..\Views\Shared\Error.cshtml"
                Write(Model.Exception.Message == "Deleted" ? "Record already deleted by another user !" : Model.Exception.GetType().Name+" : "+Model.Exception.Message);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </p>\r\n    <hr />\r\n    <p");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">\r\n");

            
            #line 16 "..\..\Views\Shared\Error.cshtml"
        
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Shared\Error.cshtml"
         if (Model.Exception is System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
        {
            if (Model.ActionName == "Edit")
            {

            
            #line default
            #line hidden
WriteLiteral("                <label");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">\r\n                    The record you attempted to modify was modified/deleted by" +
" another user after you got the original values.Click below button to get update" +
"d record.\r\n                </label>\r\n");

            
            #line 23 "..\..\Views\Shared\Error.cshtml"
            }
            if (Model.ActionName == "Delete")
            {

            
            #line default
            #line hidden
WriteLiteral("                <label>\r\n                    The record you attempted to delete w" +
"as modified/deleted by another user after you got the original values. Click bel" +
"ow button to get updated record.\r\n                </label>\r\n");

            
            #line 29 "..\..\Views\Shared\Error.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <a");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1359), Tuple.Create("\"", 1378)
            
            #line 30 "..\..\Views\Shared\Error.cshtml"
, Tuple.Create(Tuple.Create("", 1366), Tuple.Create<System.Object, System.Int32>(Request.Url
            
            #line default
            #line hidden
, 1366), false)
);

WriteLiteral(">Refresh</a>\r\n");

            
            #line 31 "..\..\Views\Shared\Error.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <a");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1474), Tuple.Create("\"", 1501)
            
            #line 34 "..\..\Views\Shared\Error.cshtml"
, Tuple.Create(Tuple.Create("", 1481), Tuple.Create<System.Object, System.Int32>(Request.UrlReferrer
            
            #line default
            #line hidden
, 1481), false)
);

WriteLiteral(">Go Back</a>\r\n");

            
            #line 35 "..\..\Views\Shared\Error.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </p>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
