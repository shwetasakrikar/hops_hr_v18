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

namespace GeneratorBase.MVC.Views.Permission
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Permission/Delete.cshtml")]
    public partial class Delete : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.Permission>
    {
        public Delete()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Permission\Delete.cshtml"
  
    ViewBag.Title = "Delete";

            
            #line default
            #line hidden
WriteLiteral("\r\n<h2>Delete</h2>\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4" +
">Permission</h4>\r\n    <hr />\r\n    <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EntityName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EntityName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 18 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.RoleName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 21 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayFor(model => model.RoleName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CanEdit));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CanEdit));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 30 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CanDelete));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 33 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CanDelete));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 36 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CanView));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 39 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CanView));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 42 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CanAdd));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 45 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CanAdd));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");

            
            #line 48 "..\..\Views\Permission\Delete.cshtml"
    
            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\Permission\Delete.cshtml"
     using (Html.BeginForm())
    {
        
            
            #line default
            #line hidden
            
            #line 50 "..\..\Views\Permission\Delete.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 50 "..\..\Views\Permission\Delete.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form-actions no-color\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" /> |\r\n");

WriteLiteral("            ");

            
            #line 53 "..\..\Views\Permission\Delete.cshtml"
       Write(Html.ActionLink("Back to List", "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

            
            #line 55 "..\..\Views\Permission\Delete.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591
