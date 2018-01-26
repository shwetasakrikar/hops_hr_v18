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

namespace GeneratorBase.MVC.Views.T_State
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
    
    #line 2 "..\..\Views\T_State\Details.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_State/Details.cshtml")]
    public partial class Details : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_State>
    {
        public Details()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_State\Details.cshtml"
  
    ViewBag.Title = "View State";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_State");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "State";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_State\Details.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_State\Details.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_State\Details.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_State\Details.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_State\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_StateIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_State\Details.cshtml"
   Write(Html.Raw(ViewBag.T_StateIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_State\Details.cshtml"
                                              ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_State\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_StateIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_State\Details.cshtml"
   Write(Html.Raw(ViewBag.T_StateIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_State\Details.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_State\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_StateIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_State\Details.cshtml"
   Write(Html.Raw(ViewBag.T_StateIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_State\Details.cshtml"
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

            
            #line 36 "..\..\Views\T_State\Details.cshtml"
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

            
            #line 38 "..\..\Views\T_State\Details.cshtml"
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

            
            #line 46 "..\..\Views\T_State\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_State\Details.cshtml"
                     if ( User.CanEdit("T_State"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1777), Tuple.Create("\"", 2048)
            
            #line 48 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 1784), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_State", new {UrlReferrer = Request.UrlReferrer,id = Model.Id,AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1784), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_State\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_State\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_State\Details.cshtml"
                     if ( User.CanDelete("T_State"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2274), Tuple.Create("\"", 2551)
            
            #line 54 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2281), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_State", new { UrlReferrer = Request.UrlReferrer,id = Model.Id, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2281), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_State\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t<li");

WriteLiteral(" class=\"divider\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></li>\r\n\t<li");

WriteLiteral(" class=\"dropdown-submenu pull-left\"");

WriteLiteral(" id=\"AddAssociationdropmenuT_State\"");

WriteLiteral(">\r\n");

            
            #line 59 "..\..\Views\T_State\Details.cshtml"
	 
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\T_State\Details.cshtml"
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

            
            #line 62 "..\..\Views\T_State\Details.cshtml"
				
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\T_State\Details.cshtml"
                 if ( User.CanAdd("T_City"))
				{ dropmenu = true;

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 3030), Tuple.Create("", 3292)
            
            #line 65 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3039), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_City", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_CityState", 
							HostingEntityName = "T_State",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 3039), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  City State\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 73 "..\..\Views\T_State\Details.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t");

            
            #line 74 "..\..\Views\T_State\Details.cshtml"
                             if ( User.CanAdd("T_Address"))
				{ dropmenu = true;

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 3470), Tuple.Create("", 3738)
            
            #line 77 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3479), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Address", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_AddressState", 
							HostingEntityName = "T_State",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 3479), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Address State\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 85 "..\..\Views\T_State\Details.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</ul>\r\n</li>\r\n");

            
            #line 88 "..\..\Views\T_State\Details.cshtml"
 if(!dropmenu)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenuT_State\").hide();\r\n    </script>\r" +
"\n");

            
            #line 93 "..\..\Views\T_State\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral(" <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></li>\r\n <li");

WriteLiteral(" class=\"dropdown-submenu pull-left\"");

WriteLiteral(">\r\n\t<a");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"margin-bottom:10px;\"");

WriteLiteral(">Find Matching</a>\r\n    <ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4172), Tuple.Create("\"", 4266)
            
            #line 99 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 4179), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Address", new {sourceEntity="T_State",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4179), false)
);

WriteLiteral(">Address</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4298), Tuple.Create("\"", 4389)
            
            #line 102 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 4305), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_City", new {sourceEntity="T_State",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4305), false)
);

WriteLiteral(">City</a>\r\n</li>\r\n</ul>\r\n</li>\r\n\t\t\t</ul>\r\n\r\n\r\n\t\t</h2>\r\n    </div>\r\n    <!-- /.col" +
"-lg-12 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4596), Tuple.Create("\"", 4661)
, Tuple.Create(Tuple.Create("", 4606), Tuple.Create("ClearTabCookie(\'", 4606), true)
            
            #line 115 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 4622), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4622), false)
            
            #line 115 "..\..\Views\T_State\Details.cshtml"
               , Tuple.Create(Tuple.Create("", 4649), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4649), false)
, Tuple.Create(Tuple.Create("", 4658), Tuple.Create("\');", 4658), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 116 "..\..\Views\T_State\Details.cshtml"
         Write(!User.CanView("T_City") ?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4761), Tuple.Create("\"", 5019)
, Tuple.Create(Tuple.Create("", 4771), Tuple.Create("LoadTab(\'T_CityState\',\'", 4771), true)
            
            #line 116 "..\..\Views\T_State\Details.cshtml"
                     , Tuple.Create(Tuple.Create("", 4794), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4794), false)
            
            #line 116 "..\..\Views\T_State\Details.cshtml"
                                                , Tuple.Create(Tuple.Create("", 4821), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4821), false)
, Tuple.Create(Tuple.Create("", 4830), Tuple.Create("\',\'", 4830), true)
            
            #line 116 "..\..\Views\T_State\Details.cshtml"
                                                            , Tuple.Create(Tuple.Create("", 4833), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_City", new {RenderPartial=true, HostingEntity ="T_State", HostingEntityID = @Model.Id, AssociatedType = "T_CityState",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 4833), false)
, Tuple.Create(Tuple.Create("", 5017), Tuple.Create("\')", 5017), true)
);

WriteLiteral(" href=\"#T_CityState\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t City State\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_CityState\"");

WriteLiteral(">");

            
            #line 118 "..\..\Views\T_State\Details.cshtml"
                                                            Write(ViewBag.T_CityStateCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 120 "..\..\Views\T_State\Details.cshtml"
         Write(!User.CanView("T_Address") ?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5257), Tuple.Create("\"", 5524)
, Tuple.Create(Tuple.Create("", 5267), Tuple.Create("LoadTab(\'T_AddressState\',\'", 5267), true)
            
            #line 120 "..\..\Views\T_State\Details.cshtml"
                           , Tuple.Create(Tuple.Create("", 5293), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 5293), false)
            
            #line 120 "..\..\Views\T_State\Details.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 5320), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5320), false)
, Tuple.Create(Tuple.Create("", 5329), Tuple.Create("\',\'", 5329), true)
            
            #line 120 "..\..\Views\T_State\Details.cshtml"
                                                                  , Tuple.Create(Tuple.Create("", 5332), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_Address", new {RenderPartial=true, HostingEntity ="T_State", HostingEntityID = @Model.Id, AssociatedType = "T_AddressState",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 5332), false)
, Tuple.Create(Tuple.Create("", 5522), Tuple.Create("\')", 5522), true)
);

WriteLiteral(" href=\"#T_AddressState\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Address State\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_AddressState\"");

WriteLiteral(">");

            
            #line 122 "..\..\Views\T_State\Details.cshtml"
                                                               Write(ViewBag.T_AddressStateCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 124 "..\..\Views\T_State\Details.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5776), Tuple.Create("\"", 6054)
, Tuple.Create(Tuple.Create("", 5786), Tuple.Create("LoadTab(\'JournalEntryToT_StateRelation\',\'", 5786), true)
            
            #line 124 "..\..\Views\T_State\Details.cshtml"
                                            , Tuple.Create(Tuple.Create("", 5827), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 5827), false)
            
            #line 124 "..\..\Views\T_State\Details.cshtml"
                                                                       , Tuple.Create(Tuple.Create("", 5854), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5854), false)
, Tuple.Create(Tuple.Create("", 5863), Tuple.Create("\',\'", 5863), true)
            
            #line 124 "..\..\Views\T_State\Details.cshtml"
                                                                                   , Tuple.Create(Tuple.Create("", 5866), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_State", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 5866), false)
, Tuple.Create(Tuple.Create("", 6052), Tuple.Create("\')", 6052), true)
);

WriteLiteral(" href=\"#JournalEntryToT_StateRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">State Journal</a></li>\r\n    </ul>\r\n");

WriteLiteral("\t  ");

            
            #line 126 "..\..\Views\T_State\Details.cshtml"
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

            
            #line 134 "..\..\Views\T_State\Details.cshtml"
 if(User.CanView("T_State","T_Name"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 6540), Tuple.Create("\"", 6561)
            
            #line 137 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 6548), Tuple.Create<System.Object, System.Int32>(Model.T_Name
            
            #line default
            #line hidden
, 6548), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 138 "..\..\Views\T_State\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" id=\"lblT_Name\"");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 142 "..\..\Views\T_State\Details.cshtml"
                                               Write(Model.T_Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 147 "..\..\Views\T_State\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 148 "..\..\Views\T_State\Details.cshtml"
 if(User.CanView("T_State","T_Description"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 6967), Tuple.Create("\"", 6995)
            
            #line 151 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 6975), Tuple.Create<System.Object, System.Int32>(Model.T_Description
            
            #line default
            #line hidden
, 6975), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 152 "..\..\Views\T_State\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabelmultiline\"");

WriteLiteral(">");

            
            #line 154 "..\..\Views\T_State\Details.cshtml"
                                 Write(Model.T_Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 158 "..\..\Views\T_State\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 159 "..\..\Views\T_State\Details.cshtml"
 if(User.CanView("T_State","T_StateCountryID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_StateCountry\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 163 "..\..\Views\T_State\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_StateCountryID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 165 "..\..\Views\T_State\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 165 "..\..\Views\T_State\Details.cshtml"
  if (Model.t_statecountry!=null && !string.IsNullOrEmpty(Model.t_statecountry.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(" id=\"lblT_StateCountry\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 168 "..\..\Views\T_State\Details.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_statecountry.DisplayValue).ToString(), "Details", "T_Country", new { Id = Html.DisplayFor(model => model.t_statecountry.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 170 "..\..\Views\T_State\Details.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 174 "..\..\Views\T_State\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm pull-left formbuttonfix\"");

WriteAttribute("Onclick", Tuple.Create(" Onclick=\"", 8124), Tuple.Create("\"", 8175)
, Tuple.Create(Tuple.Create("", 8134), Tuple.Create("goBack(\'", 8134), true)
            
            #line 181 "..\..\Views\T_State\Details.cshtml"
           , Tuple.Create(Tuple.Create("", 8142), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_State")
            
            #line default
            #line hidden
, 8142), false)
, Tuple.Create(Tuple.Create("", 8172), Tuple.Create("\');", 8172), true)
);

WriteLiteral(">Back</a>\r\n\t\t\t\t");

WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 184 "..\..\Views\T_State\Details.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 184 "..\..\Views\T_State\Details.cshtml"
                      if ( User.CanEdit("T_State"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 186 "..\..\Views\T_State\Details.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { UrlReferrer = Request.UrlReferrer, id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 186 "..\..\Views\T_State\Details.cshtml"
                                                                                                                                                                                                                                                                                                                                                                        
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   \r\n");

            
            #line 189 "..\..\Views\T_State\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 189 "..\..\Views\T_State\Details.cshtml"
    var dropmenubottom = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dropdown pull-left formbuttonfix\"");

WriteLiteral(" style=\"\"");

WriteLiteral(" id=\"AddAssociationdropmenubottomT_State\"");

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

            
            #line 196 "..\..\Views\T_State\Details.cshtml"
			
            
            #line default
            #line hidden
            
            #line 196 "..\..\Views\T_State\Details.cshtml"
             if (User.CanAdd("T_City"))
            {
			    dropmenubottom = true;

            
            #line default
            #line hidden
WriteLiteral("                <li><a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 9315), Tuple.Create("", 9623)
            
            #line 199 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 9324), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_City",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_CityState", 
						HostingEntityName = "T_State",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 9324), false)
);

WriteLiteral(">\r\n                   Add  City State\r\n                </a>\r\n\t\t\t\t</li>\r\n");

            
            #line 208 "..\..\Views\T_State\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\r\n");

            
            #line 211 "..\..\Views\T_State\Details.cshtml"
			
            
            #line default
            #line hidden
            
            #line 211 "..\..\Views\T_State\Details.cshtml"
             if (User.CanAdd("T_Address"))
            {
			    dropmenubottom = true;

            
            #line default
            #line hidden
WriteLiteral("                <li><a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 9820), Tuple.Create("", 10134)
            
            #line 214 "..\..\Views\T_State\Details.cshtml"
, Tuple.Create(Tuple.Create("", 9829), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Address",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_AddressState", 
						HostingEntityName = "T_State",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 9829), false)
);

WriteLiteral(">\r\n                   Add  Address State\r\n                </a>\r\n\t\t\t\t</li>\r\n");

            
            #line 223 "..\..\Views\T_State\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\r\n</ul>\r\n</div>\r\n");

            
            #line 228 "..\..\Views\T_State\Details.cshtml"
 if(!dropmenubottom)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenubottomT_State\").hide();\r\n    </sc" +
"ript>\r\n");

            
            #line 233 "..\..\Views\T_State\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</div> \r\n\t\t\t</div><div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_StateRelation\"");

WriteLiteral(">\r\n");

            
            #line 238 "..\..\Views\T_State\Details.cshtml"
            
            
            #line default
            #line hidden
            
            #line 238 "..\..\Views\T_State\Details.cshtml"
             if ( User.CanView("JournalEntry"))
		   {
			//	Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_State", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
		   }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_CityState\"");

WriteLiteral(">\r\n");

            
            #line 244 "..\..\Views\T_State\Details.cshtml"
     
            
            #line default
            #line hidden
            
            #line 244 "..\..\Views\T_State\Details.cshtml"
      if ( User.CanView("T_City"))
	{
	  // Html.RenderAction("Index", "T_City", new {RenderPartial=true, HostingEntity = "T_State", HostingEntityID = @Model.Id, AssociatedType = "T_CityState" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_AddressState\"");

WriteLiteral(">\r\n");

            
            #line 250 "..\..\Views\T_State\Details.cshtml"
     
            
            #line default
            #line hidden
            
            #line 250 "..\..\Views\T_State\Details.cshtml"
      if ( User.CanView("T_Address"))
	{
	  // Html.RenderAction("Index", "T_Address", new {RenderPartial=true, HostingEntity = "T_State", HostingEntityID = @Model.Id, AssociatedType = "T_AddressState" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591