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

namespace GeneratorBase.MVC.Views.T_Floor
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
    
    #line 2 "..\..\Views\T_Floor\DetailsContent.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Floor/DetailsContent.cshtml")]
    public partial class DetailsContent : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Floor>
    {
        public DetailsContent()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_Floor\DetailsContent.cshtml"
  
    ViewBag.Title = "View Floor";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Floor");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Floor";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_Floor\DetailsContent.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_Floor\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_FloorIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_Floor\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_FloorIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                              ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_Floor\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_FloorIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_Floor\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_FloorIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_Floor\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_FloorIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_Floor\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_FloorIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                                  ;
    }

            
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

WriteLiteral("></i> ");

            
            #line 36 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                                                  Write(EntityDisplayName);

            
            #line default
            #line hidden
WriteLiteral("  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span>View</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral("><span");

WriteLiteral(" id=\"HostingEntityDisplayValue\"");

WriteLiteral(">");

            
            #line 38 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                                                 Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n\t\t\t<div");

WriteLiteral(" class=\"btn-group pull-right fixactionbut\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" class=\"btn btn-xs dropdown-toggle btn-default pull-right\"");

WriteLiteral(">\r\n                Action\r\n                <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral(">    </span>\r\n            </button>\r\n\t\t\t<ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">               \r\n\t\t\t\t<li>\r\n");

            
            #line 46 "..\..\Views\T_Floor\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_Floor\DetailsContent.cshtml"
                     if ( User.CanEdit("T_Floor"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1794), Tuple.Create("\"", 2061)
            
            #line 48 "..\..\Views\T_Floor\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 1801), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_Floor", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1801), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_Floor\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_Floor\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_Floor\DetailsContent.cshtml"
                     if ( User.CanDelete("T_Floor"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2287), Tuple.Create("\"", 2557)
            
            #line 54 "..\..\Views\T_Floor\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2294), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_Floor", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2294), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_Floor\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t\t\t</ul>\r\n</div>\r\n\t\t</h2>\r\n    </div>\r\n    <!-- /.col-lg-1" +
"2 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2844), Tuple.Create("\"", 2909)
, Tuple.Create(Tuple.Create("", 2854), Tuple.Create("ClearTabCookie(\'", 2854), true)
            
            #line 65 "..\..\Views\T_Floor\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2870), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 2870), false)
            
            #line 65 "..\..\Views\T_Floor\DetailsContent.cshtml"
               , Tuple.Create(Tuple.Create("", 2897), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 2897), false)
, Tuple.Create(Tuple.Create("", 2906), Tuple.Create("\');", 2906), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 66 "..\..\Views\T_Floor\DetailsContent.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3014), Tuple.Create("\"", 3292)
, Tuple.Create(Tuple.Create("", 3024), Tuple.Create("LoadTab(\'JournalEntryToT_FloorRelation\',\'", 3024), true)
            
            #line 66 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                            , Tuple.Create(Tuple.Create("", 3065), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3065), false)
            
            #line 66 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                                                       , Tuple.Create(Tuple.Create("", 3092), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 3092), false)
, Tuple.Create(Tuple.Create("", 3101), Tuple.Create("\',\'", 3101), true)
            
            #line 66 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                                                                   , Tuple.Create(Tuple.Create("", 3104), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_Floor", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 3104), false)
, Tuple.Create(Tuple.Create("", 3290), Tuple.Create("\')", 3290), true)
);

WriteLiteral(" href=\"#JournalEntryToT_FloorRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Floor Journal</a></li>\r\n    </ul>\r\n\t    <div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n\t\t   <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"Details\"");

WriteLiteral(">\r\n\t\t\t\t <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n\t\t\t\t\t<div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                                  \r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-sm-12 col-md-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 76 "..\..\Views\T_Floor\DetailsContent.cshtml"
 if(User.CanView("T_Floor","T_Name"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Name\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 80 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 84 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                Write(Model.T_Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 89 "..\..\Views\T_Floor\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 90 "..\..\Views\T_Floor\DetailsContent.cshtml"
 if(User.CanView("T_Floor","T_Description"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Description\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 96 "..\..\Views\T_Floor\DetailsContent.cshtml"
                        Write(Model.T_Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 100 "..\..\Views\T_Floor\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 108 "..\..\Views\T_Floor\DetailsContent.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 109 "..\..\Views\T_Floor\DetailsContent.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 109 "..\..\Views\T_Floor\DetailsContent.cshtml"
                      if ( User.CanEdit("T_Floor"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 111 "..\..\Views\T_Floor\DetailsContent.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 111 "..\..\Views\T_Floor\DetailsContent.cshtml"
                                                                                                                                                                                                                                                                                                                                     
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>    \r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_FloorRelation\"");

WriteLiteral(">\r\n");

            
            #line 117 "..\..\Views\T_Floor\DetailsContent.cshtml"
            
            
            #line default
            #line hidden
            
            #line 117 "..\..\Views\T_Floor\DetailsContent.cshtml"
             if ( User.CanView("JournalEntry"))
		   {
			//	Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_Floor", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
		   }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591