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

namespace GeneratorBase.MVC.Views.T_ClassCode
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
    
    #line 2 "..\..\Views\T_ClassCode\Details.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ClassCode/Details.cshtml")]
    public partial class Details : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_ClassCode>
    {
        public Details()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_ClassCode\Details.cshtml"
  
    ViewBag.Title = "View Class Code";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ClassCode");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Class Code";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_ClassCode\Details.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_ClassCode\Details.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_ClassCode\Details.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_ClassCode\Details.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_ClassCode\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClassCodeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_ClassCode\Details.cshtml"
   Write(Html.Raw(ViewBag.T_ClassCodeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_ClassCode\Details.cshtml"
                                                  ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_ClassCode\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClassCodeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_ClassCode\Details.cshtml"
   Write(Html.Raw(ViewBag.T_ClassCodeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_ClassCode\Details.cshtml"
                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_ClassCode\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClassCodeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_ClassCode\Details.cshtml"
   Write(Html.Raw(ViewBag.T_ClassCodeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_ClassCode\Details.cshtml"
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

            
            #line 36 "..\..\Views\T_ClassCode\Details.cshtml"
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

            
            #line 38 "..\..\Views\T_ClassCode\Details.cshtml"
                                                                 Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n\t\t\t<div");

WriteLiteral(" class=\"btn-group pull-right fixactionbut\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" class=\"btn btn-xs dropdown-toggle pull-right\"");

WriteLiteral(">\r\n                Action\r\n                <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral(">    </span>\r\n            </button>\r\n\t\t\t<ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">               \r\n\t\t\t\t<li>\r\n");

            
            #line 46 "..\..\Views\T_ClassCode\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_ClassCode\Details.cshtml"
                     if ( User.CanEdit("T_ClassCode"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1823), Tuple.Create("\"", 2098)
            
            #line 48 "..\..\Views\T_ClassCode\Details.cshtml"
, Tuple.Create(Tuple.Create("", 1830), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_ClassCode", new {UrlReferrer = Request.UrlReferrer,id = Model.Id,AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1830), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_ClassCode\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_ClassCode\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_ClassCode\Details.cshtml"
                     if ( User.CanDelete("T_ClassCode"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2328), Tuple.Create("\"", 2609)
            
            #line 54 "..\..\Views\T_ClassCode\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2335), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_ClassCode", new { UrlReferrer = Request.UrlReferrer,id = Model.Id, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2335), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_ClassCode\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t<li");

WriteLiteral(" class=\"divider\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></li>\r\n\t<li");

WriteLiteral(" class=\"dropdown-submenu pull-left\"");

WriteLiteral(" id=\"AddAssociationdropmenuT_ClassCode\"");

WriteLiteral(">\r\n");

            
            #line 59 "..\..\Views\T_ClassCode\Details.cshtml"
	 
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\T_ClassCode\Details.cshtml"
        var dropmenu = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n\t<a");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"margin-bottom:10px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fam-anchor small\"");

WriteLiteral("></i> Add</a>\r\n    <ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">\r\n");

            
            #line 62 "..\..\Views\T_ClassCode\Details.cshtml"
				
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\T_ClassCode\Details.cshtml"
                 if ( User.CanAdd("T_Position"))
				{ dropmenu = true;

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 3096), Tuple.Create("", 3374)
            
            #line 65 "..\..\Views\T_ClassCode\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3105), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Position", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_PositionClassCode", 
							HostingEntityName = "T_ClassCode",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 3105), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Position\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 73 "..\..\Views\T_ClassCode\Details.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</ul>\r\n</li>\r\n");

            
            #line 76 "..\..\Views\T_ClassCode\Details.cshtml"
 if(!dropmenu)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenuT_ClassCode\").hide();\r\n    </scri" +
"pt>\r\n");

            
            #line 81 "..\..\Views\T_ClassCode\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</ul>\r\n\r\n\r\n\t\t</h2>\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3766), Tuple.Create("\"", 3831)
, Tuple.Create(Tuple.Create("", 3776), Tuple.Create("ClearTabCookie(\'", 3776), true)
            
            #line 91 "..\..\Views\T_ClassCode\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3792), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3792), false)
            
            #line 91 "..\..\Views\T_ClassCode\Details.cshtml"
               , Tuple.Create(Tuple.Create("", 3819), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 3819), false)
, Tuple.Create(Tuple.Create("", 3828), Tuple.Create("\');", 3828), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 92 "..\..\Views\T_ClassCode\Details.cshtml"
         Write(!User.CanView("T_Position") ?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3935), Tuple.Create("\"", 4217)
, Tuple.Create(Tuple.Create("", 3945), Tuple.Create("LoadTab(\'T_PositionClassCode\',\'", 3945), true)
            
            #line 92 "..\..\Views\T_ClassCode\Details.cshtml"
                                 , Tuple.Create(Tuple.Create("", 3976), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3976), false)
            
            #line 92 "..\..\Views\T_ClassCode\Details.cshtml"
                                                            , Tuple.Create(Tuple.Create("", 4003), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4003), false)
, Tuple.Create(Tuple.Create("", 4012), Tuple.Create("\',\'", 4012), true)
            
            #line 92 "..\..\Views\T_ClassCode\Details.cshtml"
                                                                        , Tuple.Create(Tuple.Create("", 4015), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_Position", new {RenderPartial=true, HostingEntity ="T_ClassCode", HostingEntityID = @Model.Id, AssociatedType = "T_PositionClassCode",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 4015), false)
, Tuple.Create(Tuple.Create("", 4215), Tuple.Create("\')", 4215), true)
);

WriteLiteral(" href=\"#T_PositionClassCode\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Position\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_PositionClassCode\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\T_ClassCode\Details.cshtml"
                                                                    Write(ViewBag.T_PositionClassCodeCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 96 "..\..\Views\T_ClassCode\Details.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4479), Tuple.Create("\"", 4765)
, Tuple.Create(Tuple.Create("", 4489), Tuple.Create("LoadTab(\'JournalEntryToT_ClassCodeRelation\',\'", 4489), true)
            
            #line 96 "..\..\Views\T_ClassCode\Details.cshtml"
                                                , Tuple.Create(Tuple.Create("", 4534), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4534), false)
            
            #line 96 "..\..\Views\T_ClassCode\Details.cshtml"
                                                                           , Tuple.Create(Tuple.Create("", 4561), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4561), false)
, Tuple.Create(Tuple.Create("", 4570), Tuple.Create("\',\'", 4570), true)
            
            #line 96 "..\..\Views\T_ClassCode\Details.cshtml"
                                                                                       , Tuple.Create(Tuple.Create("", 4573), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_ClassCode", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 4573), false)
, Tuple.Create(Tuple.Create("", 4763), Tuple.Create("\')", 4763), true)
);

WriteLiteral(" href=\"#JournalEntryToT_ClassCodeRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Class Code Journal</a></li>\r\n    </ul>\r\n");

WriteLiteral("\t  ");

            
            #line 98 "..\..\Views\T_ClassCode\Details.cshtml"
 Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t    <div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n\t\t   <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"Details\"");

WriteLiteral(">\r\n\t\t\t\t <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n\t\t\t\t\t<div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                                  \r\n\t\t\t\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 106 "..\..\Views\T_ClassCode\Details.cshtml"
 if(User.CanView("T_ClassCode","T_Code"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Code\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 5264), Tuple.Create("\"", 5285)
            
            #line 109 "..\..\Views\T_ClassCode\Details.cshtml"
, Tuple.Create(Tuple.Create("", 5272), Tuple.Create<System.Object, System.Int32>(Model.T_Code
            
            #line default
            #line hidden
, 5272), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 110 "..\..\Views\T_ClassCode\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Code));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" id=\"lblT_Code\"");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 114 "..\..\Views\T_ClassCode\Details.cshtml"
                                               Write(Model.T_Code);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 119 "..\..\Views\T_ClassCode\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 120 "..\..\Views\T_ClassCode\Details.cshtml"
 if(User.CanView("T_ClassCode","T_Title"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Title\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 5683), Tuple.Create("\"", 5705)
            
            #line 123 "..\..\Views\T_ClassCode\Details.cshtml"
, Tuple.Create(Tuple.Create("", 5691), Tuple.Create<System.Object, System.Int32>(Model.T_Title
            
            #line default
            #line hidden
, 5691), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 124 "..\..\Views\T_ClassCode\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Title));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" id=\"lblT_Title\"");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 128 "..\..\Views\T_ClassCode\Details.cshtml"
                                                Write(Model.T_Title);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 133 "..\..\Views\T_ClassCode\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 134 "..\..\Views\T_ClassCode\Details.cshtml"
 if(User.CanView("T_ClassCode","T_ClassEEOCodeID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_ClassEEOCode\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 138 "..\..\Views\T_ClassCode\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_ClassEEOCodeID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 140 "..\..\Views\T_ClassCode\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 140 "..\..\Views\T_ClassCode\Details.cshtml"
  if (Model.t_classeeocode!=null && !string.IsNullOrEmpty(Model.t_classeeocode.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(" id=\"lblT_ClassEEOCode\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 143 "..\..\Views\T_ClassCode\Details.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_classeeocode.DisplayValue).ToString(), "Details", "T_EEOCode", new { Id = Html.DisplayFor(model => model.t_classeeocode.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 145 "..\..\Views\T_ClassCode\Details.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 149 "..\..\Views\T_ClassCode\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm pull-left formbuttonfix\"");

WriteAttribute("Onclick", Tuple.Create(" Onclick=\"", 6856), Tuple.Create("\"", 6911)
, Tuple.Create(Tuple.Create("", 6866), Tuple.Create("goBack(\'", 6866), true)
            
            #line 156 "..\..\Views\T_ClassCode\Details.cshtml"
           , Tuple.Create(Tuple.Create("", 6874), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_ClassCode")
            
            #line default
            #line hidden
, 6874), false)
, Tuple.Create(Tuple.Create("", 6908), Tuple.Create("\');", 6908), true)
);

WriteLiteral(">Back</a>\r\n\t\t\t\t");

WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 159 "..\..\Views\T_ClassCode\Details.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 159 "..\..\Views\T_ClassCode\Details.cshtml"
                      if ( User.CanEdit("T_ClassCode"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 161 "..\..\Views\T_ClassCode\Details.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { UrlReferrer = Request.UrlReferrer, id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 161 "..\..\Views\T_ClassCode\Details.cshtml"
                                                                                                                                                                                                                                                                                                                                                                        
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   \r\n");

            
            #line 164 "..\..\Views\T_ClassCode\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 164 "..\..\Views\T_ClassCode\Details.cshtml"
    var dropmenubottom = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dropdown pull-left formbuttonfix\"");

WriteLiteral(" style=\"\"");

WriteLiteral(" id=\"AddAssociationdropmenubottomT_ClassCode\"");

WriteLiteral(">\r\n<button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-sm dropdown-toggle\"");

WriteLiteral(" id=\"dropdownMenu1\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n            Add Association\r\n            <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span>\r\n        </button>\r\n\t\t <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(" role=\"menu\"");

WriteLiteral(" aria-labelledby=\"dropdownMenu1\"");

WriteLiteral(">\r\n");

            
            #line 171 "..\..\Views\T_ClassCode\Details.cshtml"
			
            
            #line default
            #line hidden
            
            #line 171 "..\..\Views\T_ClassCode\Details.cshtml"
             if (User.CanAdd("T_Position"))
            {
			    dropmenubottom = true;

            
            #line default
            #line hidden
WriteLiteral("                <li><a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 8063), Tuple.Create("", 8387)
            
            #line 174 "..\..\Views\T_ClassCode\Details.cshtml"
, Tuple.Create(Tuple.Create("", 8072), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Position",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_PositionClassCode", 
						HostingEntityName = "T_ClassCode",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 8072), false)
);

WriteLiteral(">\r\n                   Add  Position\r\n                </a>\r\n\t\t\t\t</li>\r\n");

            
            #line 183 "..\..\Views\T_ClassCode\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\r\n</ul>\r\n</div>\r\n");

            
            #line 188 "..\..\Views\T_ClassCode\Details.cshtml"
 if(!dropmenubottom)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenubottomT_ClassCode\").hide();\r\n    " +
"</script>\r\n");

            
            #line 193 "..\..\Views\T_ClassCode\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</div> \r\n\t\t\t</div><div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_PositionClassCode\"");

WriteLiteral(">\r\n");

            
            #line 198 "..\..\Views\T_ClassCode\Details.cshtml"
     
            
            #line default
            #line hidden
            
            #line 198 "..\..\Views\T_ClassCode\Details.cshtml"
      if ( User.CanView("T_Position"))
	{
	  // Html.RenderAction("Index", "T_Position", new {RenderPartial=true, HostingEntity = "T_ClassCode", HostingEntityID = @Model.Id, AssociatedType = "T_PositionClassCode" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_ClassCodeRelation\"");

WriteLiteral(">\r\n");

            
            #line 204 "..\..\Views\T_ClassCode\Details.cshtml"
            
            
            #line default
            #line hidden
            
            #line 204 "..\..\Views\T_ClassCode\Details.cshtml"
             if ( User.CanView("JournalEntry"))
		   {
			//	Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_ClassCode", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
		   }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
