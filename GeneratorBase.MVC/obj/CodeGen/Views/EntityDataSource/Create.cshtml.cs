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

namespace GeneratorBase.MVC.Views.EntityDataSource
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EntityDataSource/Create.cshtml")]
    public partial class Create : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.EntityDataSource>
    {
        public Create()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\EntityDataSource\Create.cshtml"
  
    ViewBag.Title = "Create Entity Data Source";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n");

            
            #line 8 "..\..\Views\EntityDataSource\Create.cshtml"
		
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\EntityDataSource\Create.cshtml"
          
                var hostingValue = "";
                if (ViewBag.DisplayVal != null)
                {
                    hostingValue = " - " + ViewBag.DisplayVal;
                }
            
            
            #line default
            #line hidden
WriteLiteral("\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-save text-primary\"");

WriteLiteral("></i> Entity Data Source  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span> Add Entity Data Source ");

            
            #line 15 "..\..\Views\EntityDataSource\Create.cshtml"
                                                                                                                                                                       Write(hostingValue);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

            
            #line 16 "..\..\Views\EntityDataSource\Create.cshtml"
    
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\EntityDataSource\Create.cshtml"
     if (ViewData["HostingEntity"]==null)
	{ 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t <a");

WriteLiteral(" style=\"padding:4px 10px 7px 10px; height:25px !important; margin:2px 0px 0px 0px" +
";   text-align:left;\"");

WriteAttribute("href", Tuple.Create(" href=\"", 750), Tuple.Create("\"", 822)
            
            #line 18 "..\..\Views\EntityDataSource\Create.cshtml"
                                              , Tuple.Create(Tuple.Create("", 757), Tuple.Create<System.Object, System.Int32>(Url.Action("SetFSearch", "EntityDataSource")+Request.Url.Query
            
            #line default
            #line hidden
, 757), false)
);

WriteLiteral(" data-original-title=\"Faceted Search\"");

WriteLiteral("  class=\"btn btn-xs  btn-default tip-top pull-right\"");

WriteLiteral(">Search</a>\r\n");

            
            #line 19 "..\..\Views\EntityDataSource\Create.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<button");

WriteLiteral(" class=\"btn btn-xs  btn-default tip-top pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-original-title=\"List View\"");

WriteLiteral(" data-placement=\"top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 1057), Tuple.Create("", 1144)
            
            #line 20 "..\..\Views\EntityDataSource\Create.cshtml"
                                                                  , Tuple.Create(Tuple.Create("", 1066), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Index", "EntityDataSource") + "');")
            
            #line default
            #line hidden
, 1066), false)
);

WriteLiteral(" style=\"padding:4px 10px 7px 10px; height:25px !important; margin:2px 3px 0px 0px" +
"; text-align:left;\"");

WriteLiteral(">\r\n\t\t\t\t\t\t List\r\n\t\t\t</button>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\EntityDataSource\Create.cshtml"
                            Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n");

            
            #line 28 "..\..\Views\EntityDataSource\Create.cshtml"
Write(Html.Partial("~/Views/EntityDataSource/CreatePartial.cshtml", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
