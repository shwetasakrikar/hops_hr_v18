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

namespace GeneratorBase.MVC.Views.DynamicRoleMapping
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DynamicRoleMapping/Create.cshtml")]
    public partial class Create : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.DynamicRoleMapping>
    {
        public Create()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\DynamicRoleMapping\Create.cshtml"
  
    ViewBag.Title = "Create DynamicRoleMapping";

            
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

WriteLiteral("></i> DynamicRoleMapping  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span> Add DynamicRoleMapping </span>\r\n\t\t\t<button");

WriteLiteral(" class=\"btn btn-xs  btn-default tip-top pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-original-title=\"List View\"");

WriteLiteral(" data-placement=\"top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 499), Tuple.Create("", 588)
            
            #line 9 "..\..\Views\DynamicRoleMapping\Create.cshtml"
                                                                   , Tuple.Create(Tuple.Create("", 508), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Index", "DynamicRoleMapping") + "');")
            
            #line default
            #line hidden
, 508), false)
);

WriteLiteral(" style=\"padding:4px 10px 7px 10px; height:25px !important; margin:2px 3px 0px 0px" +
"; text-align:left;\"");

WriteLiteral(">\r\n\t\t\t\t\t\t List\r\n\t\t\t</button>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 13 "..\..\Views\DynamicRoleMapping\Create.cshtml"
                            Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n");

            
            #line 17 "..\..\Views\DynamicRoleMapping\Create.cshtml"
Write(Html.Partial("~/Views/DynamicRoleMapping/CreatePartial.cshtml", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591