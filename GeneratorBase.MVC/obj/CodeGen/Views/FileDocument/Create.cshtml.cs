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

namespace GeneratorBase.MVC.Views.FileDocument
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/FileDocument/Create.cshtml")]
    public partial class Create : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.FileDocument>
    {
        public Create()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\FileDocument\Create.cshtml"
  
    ViewBag.Title = "Create Document";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "FileDocument");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Document";

            
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

            
            #line 10 "..\..\Views\FileDocument\Create.cshtml"
		
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\FileDocument\Create.cshtml"
          
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

            
            #line 17 "..\..\Views\FileDocument\Create.cshtml"
                                                             Write(EntityDisplayName);

            
            #line default
            #line hidden
WriteLiteral("  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span> Add Document ");

            
            #line 17 "..\..\Views\FileDocument\Create.cshtml"
                                                                                                                                                             Write(hostingValue);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n<div");

WriteLiteral(" class=\"btn-group pull-right\"");

WriteLiteral(" style=\"margin-top:3px; margin-right:3px\"");

WriteLiteral(">\r\n\r\n");

            
            #line 20 "..\..\Views\FileDocument\Create.cshtml"
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\FileDocument\Create.cshtml"
     if (ViewData["HostingEntity"]==null)
	{ 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t <a");

WriteAttribute("href", Tuple.Create(" href=\"", 955), Tuple.Create("\"", 1023)
            
            #line 22 "..\..\Views\FileDocument\Create.cshtml"
, Tuple.Create(Tuple.Create("", 962), Tuple.Create<System.Object, System.Int32>(Url.Action("SetFSearch", "FileDocument")+Request.Url.Query
            
            #line default
            #line hidden
, 962), false)
);

WriteLiteral(" data-original-title=\"Faceted Search\"");

WriteLiteral("  class=\"btn btn-xs\"");

WriteLiteral(" alt=\"Search\"");

WriteLiteral(" title=\"Search\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-search\"");

WriteLiteral("></i> Search</a>\r\n");

            
            #line 23 "..\..\Views\FileDocument\Create.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<a");

WriteLiteral(" class=\"btn btn-xs pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-original-title=\"List View\"");

WriteLiteral(" data-placement=\"top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 1271), Tuple.Create("", 1354)
            
            #line 24 "..\..\Views\FileDocument\Create.cshtml"
                                        , Tuple.Create(Tuple.Create("", 1280), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Index", "FileDocument") + "');")
            
            #line default
            #line hidden
, 1280), false)
);

WriteLiteral(" alt=\"Search\"");

WriteLiteral(" title=\"List\"");

WriteLiteral(">\r\n\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-list\"");

WriteLiteral("></i> List\r\n\t\t\t</a>\r\n\t\t\t</div>\r\n\t\r\n\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\FileDocument\Create.cshtml"
                            Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n");

            
            #line 35 "..\..\Views\FileDocument\Create.cshtml"
Write(Html.Partial("~/Views/FileDocument/CreatePartial.cshtml", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
