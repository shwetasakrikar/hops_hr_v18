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

namespace GeneratorBase.MVC.Views.BusinessRule
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/BusinessRule/Delete.cshtml")]
    public partial class Delete : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.BusinessRule>
    {
        public Delete()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\BusinessRule\Delete.cshtml"
  
    ViewBag.Title = "Delete Business Rule";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-hand-down text-primary\"");

WriteLiteral("></i>Delete Business Rule  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i>\r\n            <span");

WriteLiteral(" style=\"color:red;\"");

WriteLiteral(">  Are you sure you want to delete this?</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\BusinessRule\Delete.cshtml"
                            Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 17 "..\..\Views\BusinessRule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.RuleName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 20 "..\..\Views\BusinessRule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.RuleName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 23 "..\..\Views\BusinessRule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EntityName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Views\BusinessRule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EntityName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 29 "..\..\Views\BusinessRule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Roles));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 32 "..\..\Views\BusinessRule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Roles));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 35 "..\..\Views\BusinessRule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DateCreated1));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 38 "..\..\Views\BusinessRule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DateCreated1));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 41 "..\..\Views\BusinessRule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Disable));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 44 "..\..\Views\BusinessRule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Disable));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        ");

WriteLiteral("\r\n    </dl>\r\n    <br />\r\n");

            
            #line 60 "..\..\Views\BusinessRule\Delete.cshtml"
    
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\BusinessRule\Delete.cshtml"
     using (Html.BeginForm())
    {
        
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\BusinessRule\Delete.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\BusinessRule\Delete.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 65 "..\..\Views\BusinessRule\Delete.cshtml"
           Write(Html.ActionLink("Back to List", "Index", null, new { @class = "btn btn-default btn-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Delete\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n");

            
            #line 69 "..\..\Views\BusinessRule\Delete.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591
