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

namespace GeneratorBase.MVC.Views.T_PositionLevel
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_PositionLevel/Delete.cshtml")]
    public partial class Delete : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_PositionLevel>
    {
        public Delete()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_PositionLevel\Delete.cshtml"
  
    ViewBag.Title = "Delete Position Level";

            
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

WriteLiteral("></i>Delete Position Level  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> \r\n            <span");

WriteLiteral(" style=\"color:red;\"");

WriteLiteral(">  Are you sure you want to delete this?</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\T_PositionLevel\Delete.cshtml"
                            Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n<label");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" class=\"text-primary small\"");

WriteLiteral(" style=\"color:red; vertical-align:middle; font-weight:100;\"");

WriteLiteral("></label>\r\n");

            
            #line 16 "..\..\Views\T_PositionLevel\Delete.cshtml"
 using (Html.BeginForm())
{
    
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_PositionLevel\Delete.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_PositionLevel\Delete.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\T_PositionLevel\Delete.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\T_PositionLevel\Delete.cshtml"
                                                  
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\T_PositionLevel\Delete.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\T_PositionLevel\Delete.cshtml"
                                      
                                  

            
            #line default
            #line hidden
WriteLiteral("    <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n\t\t  <dt>\t\t   \r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\T_PositionLevel\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Views\T_PositionLevel\Delete.cshtml"
       Write(Html.DisplayFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 28 "..\..\Views\T_PositionLevel\Delete.cshtml"
       Write(Html.HiddenFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t  <dt>\t\t   \r\n");

WriteLiteral("            ");

            
            #line 31 "..\..\Views\T_PositionLevel\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 34 "..\..\Views\T_PositionLevel\Delete.cshtml"
       Write(Html.DisplayFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 35 "..\..\Views\T_PositionLevel\Delete.cshtml"
       Write(Html.HiddenFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");

WriteLiteral("\t<br/>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row deletefix\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"small alert-danger\"");

WriteLiteral(" style=\"padding:3px; margin-top:5px; display:block;\"");

WriteLiteral(">All Position Identifier will be deleted associated with ");

            
            #line 41 "..\..\Views\T_PositionLevel\Delete.cshtml"
                                                                                                                                                 Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("!</label>\r\n         <a");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteAttribute("Onclick", Tuple.Create(" Onclick=\"", 1707), Tuple.Create("\"", 1766)
, Tuple.Create(Tuple.Create("", 1717), Tuple.Create("goBack(\'", 1717), true)
            
            #line 42 "..\..\Views\T_PositionLevel\Delete.cshtml"
, Tuple.Create(Tuple.Create("", 1725), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_PositionLevel")
            
            #line default
            #line hidden
, 1725), false)
, Tuple.Create(Tuple.Create("", 1763), Tuple.Create("\');", 1763), true)
);

WriteLiteral(">Back</a>\r\n        ");

WriteLiteral("\r\n \r\n");

            
            #line 45 "..\..\Views\T_PositionLevel\Delete.cshtml"
	
            
            #line default
            #line hidden
            
            #line 45 "..\..\Views\T_PositionLevel\Delete.cshtml"
     if ( User.CanDelete("T_PositionLevel"))
     {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Delete\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" /> \r\n");

            
            #line 48 "..\..\Views\T_PositionLevel\Delete.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n            </div>\r\n");

            
            #line 51 "..\..\Views\T_PositionLevel\Delete.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591