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

namespace GeneratorBase.MVC.Views.DataSourceParameters
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DataSourceParameters/Index.cshtml")]
    public partial class Index : GeneratorBase.MVC.CustomWebViewPage<IEnumerable<GeneratorBase.MVC.Models.DataSourceParameters>>
    {
        public Index()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\DataSourceParameters\Index.cshtml"
  
    ViewBag.Title = "Data Source Parameters List";
	Layout ="~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-thumbs-up text-primary\"");

WriteLiteral(" style=\"margin-bottom:-20px;\"");

WriteLiteral("></i> Data Source Parameters  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i>  <span>List</span>\r\n</h1>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" id=\"dvDataSourceParametersFilter\"");

WriteLiteral("></div>\r\n");

            
            #line 14 "..\..\Views\DataSourceParameters\Index.cshtml"
Write(Html.Partial("~/Views/DataSourceParameters/IndexPartial.cshtml", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
