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

namespace GeneratorBase.MVC.Views.T_Licenses
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Licenses/Create.cshtml")]
    public partial class Create : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Licenses>
    {
        public Create()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Licenses\Create.cshtml"
  
    ViewBag.Title = "Create Licenses";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Licenses");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Licenses";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(" style=\"margin-bottom:10px\"");

WriteLiteral(">\r\n");

            
            #line 10 "..\..\Views\T_Licenses\Create.cshtml"
		
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_Licenses\Create.cshtml"
          
                var hostingValue = "";
                if (ViewBag.DisplayVal != null)
                {
                    hostingValue = " - " + ViewBag.DisplayVal;
                }
            
            
            #line default
            #line hidden
WriteLiteral("\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-save text-primary\"");

WriteLiteral("></i> ");

            
            #line 17 "..\..\Views\T_Licenses\Create.cshtml"
                                                             Write(EntityDisplayName);

            
            #line default
            #line hidden
WriteLiteral("  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span> Add Licenses ");

            
            #line 17 "..\..\Views\T_Licenses\Create.cshtml"
                                                                                                                                                             Write(hostingValue);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n<div");

WriteLiteral(" class=\"btn-group pull-right\"");

WriteLiteral(" style=\"margin-top:3px; margin-right:3px\"");

WriteLiteral(">\r\n\r\n");

            
            #line 20 "..\..\Views\T_Licenses\Create.cshtml"
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\T_Licenses\Create.cshtml"
     if (ViewData["HostingEntity"]==null)
	{ 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t <a");

WriteAttribute("href", Tuple.Create(" href=\"", 951), Tuple.Create("\"", 1017)
            
            #line 22 "..\..\Views\T_Licenses\Create.cshtml"
, Tuple.Create(Tuple.Create("", 958), Tuple.Create<System.Object, System.Int32>(Url.Action("SetFSearch", "T_Licenses")+Request.Url.Query
            
            #line default
            #line hidden
, 958), false)
);

WriteLiteral(" data-original-title=\"Faceted Search\"");

WriteLiteral("  class=\"btn btn-xs\"");

WriteLiteral(" alt=\"Search\"");

WriteLiteral(" title=\"Search\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-search\"");

WriteLiteral("></i> Search</a>\r\n");

            
            #line 23 "..\..\Views\T_Licenses\Create.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<a");

WriteLiteral(" class=\"btn btn-xs pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-original-title=\"List View\"");

WriteLiteral(" data-placement=\"top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 1265), Tuple.Create("", 1346)
            
            #line 24 "..\..\Views\T_Licenses\Create.cshtml"
                                        , Tuple.Create(Tuple.Create("", 1274), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Index", "T_Licenses") + "');")
            
            #line default
            #line hidden
, 1274), false)
);

WriteLiteral(" alt=\"Search\"");

WriteLiteral(" title=\"List\"");

WriteLiteral(">\r\n\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-list\"");

WriteLiteral("></i> List\r\n\t\t\t</a>\r\n\t\t\t</div>\r\n\t   \r\n<div");

WriteLiteral(" class=\"btn-group pull-right\"");

WriteLiteral(" style=\"margin-top:3px; margin-right:3px\"");

WriteLiteral(">\r\n\t <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"btn btn-xs closeall\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-up\"");

WriteLiteral("></i> Collapse All</a> \r\n\t <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"btn btn-xs openall\"");

WriteLiteral(" style=\"margin-right:5px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-down\"");

WriteLiteral("></i> Expand All</a>\r\n</div>\r\n\t\r\n\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 36 "..\..\Views\T_Licenses\Create.cshtml"
                            Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n");

            
            #line 40 "..\..\Views\T_Licenses\Create.cshtml"
Write(Html.Partial("~/Views/T_Licenses/CreatePartial.cshtml", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
