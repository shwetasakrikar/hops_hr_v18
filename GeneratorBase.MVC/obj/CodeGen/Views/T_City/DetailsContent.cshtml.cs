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

namespace GeneratorBase.MVC.Views.T_City
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
    
    #line 2 "..\..\Views\T_City\DetailsContent.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_City/DetailsContent.cshtml")]
    public partial class DetailsContent : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_City>
    {
        public DetailsContent()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_City\DetailsContent.cshtml"
  
    ViewBag.Title = "View City";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_City");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "City";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_City\DetailsContent.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_City\DetailsContent.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_City\DetailsContent.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_City\DetailsContent.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_City\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CityIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_City\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_CityIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_City\DetailsContent.cshtml"
                                             ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_City\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CityIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_City\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_CityIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_City\DetailsContent.cshtml"
                                                   ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_City\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CityIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_City\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_CityIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_City\DetailsContent.cshtml"
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

            
            #line 36 "..\..\Views\T_City\DetailsContent.cshtml"
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

            
            #line 38 "..\..\Views\T_City\DetailsContent.cshtml"
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

            
            #line 46 "..\..\Views\T_City\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_City\DetailsContent.cshtml"
                     if ( User.CanEdit("T_City"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1783), Tuple.Create("\"", 2049)
            
            #line 48 "..\..\Views\T_City\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 1790), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_City", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1790), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_City\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_City\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_City\DetailsContent.cshtml"
                     if ( User.CanDelete("T_City"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2274), Tuple.Create("\"", 2543)
            
            #line 54 "..\..\Views\T_City\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2281), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_City", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2281), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_City\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t<li");

WriteLiteral(" class=\"divider\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></li>\r\n\t<li");

WriteLiteral(" class=\"dropdown-submenu pull-left\"");

WriteLiteral(">\r\n\t<a");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"margin-bottom:10px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fam-anchor small\"");

WriteLiteral("></i> Add</a>\r\n    <ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">\r\n");

            
            #line 61 "..\..\Views\T_City\DetailsContent.cshtml"
				
            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\T_City\DetailsContent.cshtml"
                 if ( User.CanAdd("T_Address"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 2943), Tuple.Create("", 3209)
            
            #line 64 "..\..\Views\T_City\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2952), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Address", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_AddressCity", 
							HostingEntityName = "T_City",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 2952), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Address City\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 72 "..\..\Views\T_City\DetailsContent.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</ul>\r\n</li>\r\n <li");

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

WriteAttribute("href", Tuple.Create(" href=\"", 3538), Tuple.Create("\"", 3629)
            
            #line 80 "..\..\Views\T_City\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3545), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_State", new {sourceEntity="T_City",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3545), false)
);

WriteLiteral(">State</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3659), Tuple.Create("\"", 3752)
            
            #line 83 "..\..\Views\T_City\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3666), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Address", new {sourceEntity="T_City",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3666), false)
);

WriteLiteral(">Address</a>\r\n</li>\r\n</ul>\r\n</li>\r\n\t\t\t</ul>\r\n</div>\r\n\t\t</h2>\r\n    </div>\r\n    <!-" +
"- /.col-lg-12 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3966), Tuple.Create("\"", 4031)
, Tuple.Create(Tuple.Create("", 3976), Tuple.Create("ClearTabCookie(\'", 3976), true)
            
            #line 95 "..\..\Views\T_City\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3992), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3992), false)
            
            #line 95 "..\..\Views\T_City\DetailsContent.cshtml"
               , Tuple.Create(Tuple.Create("", 4019), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4019), false)
, Tuple.Create(Tuple.Create("", 4028), Tuple.Create("\');", 4028), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 96 "..\..\Views\T_City\DetailsContent.cshtml"
         Write(!User.CanView("T_Address")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4133), Tuple.Create("\"", 4397)
, Tuple.Create(Tuple.Create("", 4143), Tuple.Create("LoadTab(\'T_AddressCity\',\'", 4143), true)
            
            #line 96 "..\..\Views\T_City\DetailsContent.cshtml"
                         , Tuple.Create(Tuple.Create("", 4168), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4168), false)
            
            #line 96 "..\..\Views\T_City\DetailsContent.cshtml"
                                                    , Tuple.Create(Tuple.Create("", 4195), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4195), false)
, Tuple.Create(Tuple.Create("", 4204), Tuple.Create("\',\'", 4204), true)
            
            #line 96 "..\..\Views\T_City\DetailsContent.cshtml"
                                                                , Tuple.Create(Tuple.Create("", 4207), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_Address", new {RenderPartial=true, HostingEntity ="T_City", HostingEntityID = @Model.Id, AssociatedType = "T_AddressCity",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 4207), false)
, Tuple.Create(Tuple.Create("", 4395), Tuple.Create("\')", 4395), true)
);

WriteLiteral(" href=\"#T_AddressCity\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Address City\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_AddressCity\"");

WriteLiteral(">");

            
            #line 98 "..\..\Views\T_City\DetailsContent.cshtml"
                                                              Write(ViewBag.T_AddressCityCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 100 "..\..\Views\T_City\DetailsContent.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4645), Tuple.Create("\"", 4921)
, Tuple.Create(Tuple.Create("", 4655), Tuple.Create("LoadTab(\'JournalEntryToT_CityRelation\',\'", 4655), true)
            
            #line 100 "..\..\Views\T_City\DetailsContent.cshtml"
                                           , Tuple.Create(Tuple.Create("", 4695), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4695), false)
            
            #line 100 "..\..\Views\T_City\DetailsContent.cshtml"
                                                                      , Tuple.Create(Tuple.Create("", 4722), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4722), false)
, Tuple.Create(Tuple.Create("", 4731), Tuple.Create("\',\'", 4731), true)
            
            #line 100 "..\..\Views\T_City\DetailsContent.cshtml"
                                                                                  , Tuple.Create(Tuple.Create("", 4734), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_City", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 4734), false)
, Tuple.Create(Tuple.Create("", 4919), Tuple.Create("\')", 4919), true)
);

WriteLiteral(" href=\"#JournalEntryToT_CityRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">City Journal</a></li>\r\n    </ul>\r\n\t    <div");

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

            
            #line 110 "..\..\Views\T_City\DetailsContent.cshtml"
 if(User.CanView("T_City","T_Name"))
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

            
            #line 114 "..\..\Views\T_City\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 118 "..\..\Views\T_City\DetailsContent.cshtml"
                                Write(Model.T_Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 123 "..\..\Views\T_City\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 124 "..\..\Views\T_City\DetailsContent.cshtml"
 if(User.CanView("T_City","T_Description"))
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

            
            #line 128 "..\..\Views\T_City\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 130 "..\..\Views\T_City\DetailsContent.cshtml"
                        Write(Model.T_Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 134 "..\..\Views\T_City\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 135 "..\..\Views\T_City\DetailsContent.cshtml"
 if(User.CanView("T_City","T_CityCountryID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_CityCountry\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 139 "..\..\Views\T_City\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_CityCountryID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 141 "..\..\Views\T_City\DetailsContent.cshtml"
		
            
            #line default
            #line hidden
            
            #line 141 "..\..\Views\T_City\DetailsContent.cshtml"
         if (@Model.T_CityCountryID == 0 || @Model.T_CityCountryID == null || @Model.t_citycountry == null)
		{

            
            #line default
            #line hidden
WriteLiteral("\t         <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral("></p>\r\n");

            
            #line 144 "..\..\Views\T_City\DetailsContent.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t     <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 147 "..\..\Views\T_City\DetailsContent.cshtml"
                             Write(Model.t_citycountry.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 148 "..\..\Views\T_City\DetailsContent.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 152 "..\..\Views\T_City\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 153 "..\..\Views\T_City\DetailsContent.cshtml"
 if(User.CanView("T_City","T_CityStateID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_CityState\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 157 "..\..\Views\T_City\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_CityStateID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 159 "..\..\Views\T_City\DetailsContent.cshtml"
		
            
            #line default
            #line hidden
            
            #line 159 "..\..\Views\T_City\DetailsContent.cshtml"
         if (@Model.T_CityStateID == 0 || @Model.T_CityStateID == null || @Model.t_citystate == null)
		{

            
            #line default
            #line hidden
WriteLiteral("\t         <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral("></p>\r\n");

            
            #line 162 "..\..\Views\T_City\DetailsContent.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t     <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 165 "..\..\Views\T_City\DetailsContent.cshtml"
                             Write(Model.t_citystate.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 166 "..\..\Views\T_City\DetailsContent.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 170 "..\..\Views\T_City\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 178 "..\..\Views\T_City\DetailsContent.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 179 "..\..\Views\T_City\DetailsContent.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 179 "..\..\Views\T_City\DetailsContent.cshtml"
                      if ( User.CanEdit("T_City"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 181 "..\..\Views\T_City\DetailsContent.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 181 "..\..\Views\T_City\DetailsContent.cshtml"
                                                                                                                                                                                                                                                                                                                                     
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>    \r\n\r\n<div");

WriteLiteral(" class=\"dropdown pull-left formbuttonfix\"");

WriteLiteral(" style=\"margin-top:-30px; margin-left:102px;\"");

WriteLiteral(">\r\n<button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-sm dropdown-toggle\"");

WriteLiteral(" id=\"dropdownMenu1\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n            Add Association\r\n            <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span>\r\n        </button>\r\n\t\t <ul");

WriteLiteral(" class=\"dropdown-menu \"");

WriteLiteral(" role=\"menu\"");

WriteLiteral(" aria-labelledby=\"dropdownMenu1\"");

WriteLiteral(">\r\n           \r\n");

            
            #line 193 "..\..\Views\T_City\DetailsContent.cshtml"
			
            
            #line default
            #line hidden
            
            #line 193 "..\..\Views\T_City\DetailsContent.cshtml"
             if ( User.CanAdd("T_Address"))
            {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t <li>\r\n\t\t\t\t <a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 8443), Tuple.Create("", 8755)
            
            #line 196 "..\..\Views\T_City\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 8452), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Address",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_AddressCity", 
						HostingEntityName = "T_City",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 8452), false)
);

WriteLiteral(" style=\"margin-top:5px;\"");

WriteLiteral(">\r\n                   Add  Address City</a>\r\n\t\t\t</li>\r\n");

            
            #line 204 "..\..\Views\T_City\DetailsContent.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\r\n\r\n        </ul>\r\n\r\n\t\t\t</div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_CityRelation\"");

WriteLiteral(">\r\n");

            
            #line 212 "..\..\Views\T_City\DetailsContent.cshtml"
            
            
            #line default
            #line hidden
            
            #line 212 "..\..\Views\T_City\DetailsContent.cshtml"
             if ( User.CanView("JournalEntry"))
		   {
			//	Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_City", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
		   }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_AddressCity\"");

WriteLiteral(">\r\n");

            
            #line 218 "..\..\Views\T_City\DetailsContent.cshtml"
     
            
            #line default
            #line hidden
            
            #line 218 "..\..\Views\T_City\DetailsContent.cshtml"
      if ( User.CanView("T_Address"))
	{
	  // Html.RenderAction("Index", "T_Address", new {RenderPartial=true, HostingEntity = "T_City", HostingEntityID = @Model.Id, AssociatedType = "T_AddressCity" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
