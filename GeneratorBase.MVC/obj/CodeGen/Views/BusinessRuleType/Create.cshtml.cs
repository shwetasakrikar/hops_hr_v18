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

namespace GeneratorBase.MVC.Views.BusinessRuleType
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/BusinessRuleType/Create.cshtml")]
    public partial class Create : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.BusinessRuleType>
    {
        public Create()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\BusinessRuleType\Create.cshtml"
  
    ViewBag.Title = "Create BusinessRule Type";

            
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

WriteLiteral("></i> BusinessRule Type  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span> Add BusinessRule Type </span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\BusinessRuleType\Create.cshtml"
                            Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n");

            
            #line 14 "..\..\Views\BusinessRuleType\Create.cshtml"
Write(Html.Partial("~/Views/BusinessRuleType/CreatePartial.cshtml", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
