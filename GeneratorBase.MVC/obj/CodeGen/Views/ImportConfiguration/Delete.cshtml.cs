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

namespace GeneratorBase.MVC.Views.ImportConfiguration
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ImportConfiguration/Delete.cshtml")]
    public partial class Delete : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.ImportConfiguration>
    {
        public Delete()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\ImportConfiguration\Delete.cshtml"
  
    ViewBag.Title = "Delete Import Configuration";

            
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

WriteLiteral("></i>Delete Import Configuration  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i>\r\n            <span");

WriteLiteral(" style=\"color:red;\"");

WriteLiteral(">  Are you sure you want to delete this?</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\ImportConfiguration\Delete.cshtml"
                            Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\ImportConfiguration\Delete.cshtml"
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\ImportConfiguration\Delete.cshtml"
     using (Html.BeginForm())
    {
        
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\ImportConfiguration\Delete.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\ImportConfiguration\Delete.cshtml"
                                
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\ImportConfiguration\Delete.cshtml"
   Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\ImportConfiguration\Delete.cshtml"
                                                      
        
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\ImportConfiguration\Delete.cshtml"
   Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\ImportConfiguration\Delete.cshtml"
                                          

            
            #line default
            #line hidden
WriteLiteral("        <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n            <dt>\r\n");

WriteLiteral("                ");

            
            #line 22 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.TableColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dt>\r\n            <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 25 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayFor(model => model.TableColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.SheetColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dt>\r\n            <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 31 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayFor(model => model.SheetColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n");

WriteLiteral("                ");

            
            #line 34 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.UniqueColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dt>\r\n            <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 37 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayFor(model => model.UniqueColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n");

WriteLiteral("                ");

            
            #line 40 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.LastUpdate));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dt>\r\n            <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 43 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayFor(model => model.LastUpdate));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n");

WriteLiteral("                ");

            
            #line 46 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.LastUpdateUser));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dt>\r\n            <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 49 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayFor(model => model.LastUpdateUser));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n");

WriteLiteral("                ");

            
            #line 52 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dt>\r\n            <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 55 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n");

WriteLiteral("                ");

            
            #line 58 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.MappingName));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dt>\r\n            <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 61 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayFor(model => model.MappingName));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n");

WriteLiteral("                ");

            
            #line 64 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.IsDefaultMapping));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dt>\r\n            <dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 67 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.DisplayFor(model => model.IsDefaultMapping));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n");

WriteLiteral("        <br />\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row deletefix\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 73 "..\..\Views\ImportConfiguration\Delete.cshtml"
           Write(Html.ActionLink("Back to List", "Index", null, new { @class = "btn btn-default btn-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Delete\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n");

            
            #line 77 "..\..\Views\ImportConfiguration\Delete.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591