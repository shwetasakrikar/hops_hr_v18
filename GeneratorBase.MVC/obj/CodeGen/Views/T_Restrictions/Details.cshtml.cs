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

namespace GeneratorBase.MVC.Views.T_Restrictions
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
    
    #line 2 "..\..\Views\T_Restrictions\Details.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Restrictions/Details.cshtml")]
    public partial class Details : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Restrictions>
    {
        public Details()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_Restrictions\Details.cshtml"
  
    ViewBag.Title = "View Restrictions";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Restrictions");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Restrictions";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_Restrictions\Details.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_Restrictions\Details.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_Restrictions\Details.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_Restrictions\Details.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_Restrictions\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RestrictionsIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_Restrictions\Details.cshtml"
   Write(Html.Raw(ViewBag.T_RestrictionsIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_Restrictions\Details.cshtml"
                                                     ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_Restrictions\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RestrictionsIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_Restrictions\Details.cshtml"
   Write(Html.Raw(ViewBag.T_RestrictionsIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_Restrictions\Details.cshtml"
                                                           ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_Restrictions\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RestrictionsIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_Restrictions\Details.cshtml"
   Write(Html.Raw(ViewBag.T_RestrictionsIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_Restrictions\Details.cshtml"
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

            
            #line 36 "..\..\Views\T_Restrictions\Details.cshtml"
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

            
            #line 38 "..\..\Views\T_Restrictions\Details.cshtml"
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

            
            #line 46 "..\..\Views\T_Restrictions\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_Restrictions\Details.cshtml"
                     if ( User.CanEdit("T_Restrictions"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1854), Tuple.Create("\"", 2132)
            
            #line 48 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 1861), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_Restrictions", new {UrlReferrer = Request.UrlReferrer,id = Model.Id,AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1861), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_Restrictions\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_Restrictions\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_Restrictions\Details.cshtml"
                     if ( User.CanDelete("T_Restrictions"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2365), Tuple.Create("\"", 2649)
            
            #line 54 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2372), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_Restrictions", new { UrlReferrer = Request.UrlReferrer,id = Model.Id, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2372), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_Restrictions\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n <li");

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

WriteAttribute("href", Tuple.Create(" href=\"", 2973), Tuple.Create("\"", 3077)
            
            #line 62 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2980), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Department", new {sourceEntity="T_Restrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 2980), false)
);

WriteLiteral(">Department</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3112), Tuple.Create("\"", 3214)
            
            #line 65 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3119), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Position", new {sourceEntity="T_Restrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3119), false)
);

WriteLiteral(">Position</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3247), Tuple.Create("\"", 3349)
            
            #line 68 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3254), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Employee", new {sourceEntity="T_Restrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3254), false)
);

WriteLiteral(">Employee</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3382), Tuple.Create("\"", 3490)
            
            #line 71 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3389), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_DepartmentArea", new {sourceEntity="T_Restrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3389), false)
);

WriteLiteral(">Department Area</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3530), Tuple.Create("\"", 3633)
            
            #line 74 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3537), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_ClaimType", new {sourceEntity="T_Restrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3537), false)
);

WriteLiteral(">Claim Type</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3668), Tuple.Create("\"", 3767)
            
            #line 77 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3675), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_UnitX", new {sourceEntity="T_Restrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3675), false)
);

WriteLiteral(">UnitX</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3797), Tuple.Create("\"", 3895)
            
            #line 80 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3804), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Unit", new {sourceEntity="T_Restrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3804), false)
);

WriteLiteral(">Unit</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3924), Tuple.Create("\"", 4029)
            
            #line 83 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3931), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_SalaryRange", new {sourceEntity="T_Restrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3931), false)
);

WriteLiteral(">Salary Range</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4066), Tuple.Create("\"", 4181)
            
            #line 86 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 4073), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_FacilityConfiguration", new {sourceEntity="T_Restrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4073), false)
);

WriteLiteral(">Facility Configuration</a>\r\n</li>\r\n</ul>\r\n</li>\r\n\t\t\t</ul>\r\n\r\n\r\n\t\t</h2>\r\n    </di" +
"v>\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4406), Tuple.Create("\"", 4471)
, Tuple.Create(Tuple.Create("", 4416), Tuple.Create("ClearTabCookie(\'", 4416), true)
            
            #line 99 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 4432), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4432), false)
            
            #line 99 "..\..\Views\T_Restrictions\Details.cshtml"
               , Tuple.Create(Tuple.Create("", 4459), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4459), false)
, Tuple.Create(Tuple.Create("", 4468), Tuple.Create("\');", 4468), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 100 "..\..\Views\T_Restrictions\Details.cshtml"
         Write(!User.CanView("T_TypeOfRestrictions") ?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4585), Tuple.Create("\"", 4912)
, Tuple.Create(Tuple.Create("", 4595), Tuple.Create("LoadTab(\'T_TypeOfRestrictions_T_Restrictions\',\'", 4595), true)
            
            #line 100 "..\..\Views\T_Restrictions\Details.cshtml"
                                                           , Tuple.Create(Tuple.Create("", 4642), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4642), false)
            
            #line 100 "..\..\Views\T_Restrictions\Details.cshtml"
                                                                                      , Tuple.Create(Tuple.Create("", 4669), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4669), false)
, Tuple.Create(Tuple.Create("", 4678), Tuple.Create("\',\'", 4678), true)
            
            #line 100 "..\..\Views\T_Restrictions\Details.cshtml"
                                                                                                  , Tuple.Create(Tuple.Create("", 4681), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_TypeOfRestrictions", new {RenderPartial=true, HostingEntity ="T_Restrictions", HostingEntityID = @Model.Id, AssociatedType = "T_TypeOfRestrictions_T_Restrictions",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 4681), false)
, Tuple.Create(Tuple.Create("", 4910), Tuple.Create("\')", 4910), true)
);

WriteLiteral(" href=\"#T_TypeOfRestrictions_T_Restrictions\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Employees Injuries\r\n\t\t </a></li>\r\n\t\t <li ");

            
            #line 103 "..\..\Views\T_Restrictions\Details.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5082), Tuple.Create("\"", 5374)
, Tuple.Create(Tuple.Create("", 5092), Tuple.Create("LoadTab(\'JournalEntryToT_RestrictionsRelation\',\'", 5092), true)
            
            #line 103 "..\..\Views\T_Restrictions\Details.cshtml"
                                                   , Tuple.Create(Tuple.Create("", 5140), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 5140), false)
            
            #line 103 "..\..\Views\T_Restrictions\Details.cshtml"
                                                                              , Tuple.Create(Tuple.Create("", 5167), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5167), false)
, Tuple.Create(Tuple.Create("", 5176), Tuple.Create("\',\'", 5176), true)
            
            #line 103 "..\..\Views\T_Restrictions\Details.cshtml"
                                                                                          , Tuple.Create(Tuple.Create("", 5179), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_Restrictions", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 5179), false)
, Tuple.Create(Tuple.Create("", 5372), Tuple.Create("\')", 5372), true)
);

WriteLiteral(" href=\"#JournalEntryToT_RestrictionsRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Restrictions Journal</a></li>\r\n    </ul>\r\n");

WriteLiteral("\t  ");

            
            #line 105 "..\..\Views\T_Restrictions\Details.cshtml"
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

            
            #line 113 "..\..\Views\T_Restrictions\Details.cshtml"
 if(User.CanView("T_Restrictions","T_RestrictionsFacilityAssociationID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_RestrictionsFacilityAssociation\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 117 "..\..\Views\T_Restrictions\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_RestrictionsFacilityAssociationID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 119 "..\..\Views\T_Restrictions\Details.cshtml"
		
            
            #line default
            #line hidden
            
            #line 119 "..\..\Views\T_Restrictions\Details.cshtml"
         if (@Model.T_RestrictionsFacilityAssociationID == 0 || @Model.T_RestrictionsFacilityAssociationID == null || @Model.t_restrictionsfacilityassociation == null)
		{

            
            #line default
            #line hidden
WriteLiteral("\t         <p");

WriteLiteral(" id=\"lblT_RestrictionsFacilityAssociationID\"");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral("></p>\r\n");

            
            #line 122 "..\..\Views\T_Restrictions\Details.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t     <p");

WriteLiteral(" id=\"lblT_RestrictionsFacilityAssociationID\"");

WriteLiteral(" class=\"viewlabel\"");

WriteAttribute("title", Tuple.Create(" title=\"", 6481), Tuple.Create("\"", 6542)
            
            #line 125 "..\..\Views\T_Restrictions\Details.cshtml"
     , Tuple.Create(Tuple.Create("", 6489), Tuple.Create<System.Object, System.Int32>(Model.t_restrictionsfacilityassociation.DisplayValue
            
            #line default
            #line hidden
, 6489), false)
);

WriteLiteral(">");

            
            #line 125 "..\..\Views\T_Restrictions\Details.cshtml"
                                                                                                                                       Write(Model.t_restrictionsfacilityassociation.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 126 "..\..\Views\T_Restrictions\Details.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 130 "..\..\Views\T_Restrictions\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 131 "..\..\Views\T_Restrictions\Details.cshtml"
 if(User.CanView("T_Restrictions","T_Name"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 6774), Tuple.Create("\"", 6795)
            
            #line 134 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 6782), Tuple.Create<System.Object, System.Int32>(Model.T_Name
            
            #line default
            #line hidden
, 6782), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 135 "..\..\Views\T_Restrictions\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" id=\"lblT_Name\"");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 139 "..\..\Views\T_Restrictions\Details.cshtml"
                                               Write(Model.T_Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 144 "..\..\Views\T_Restrictions\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 145 "..\..\Views\T_Restrictions\Details.cshtml"
 if(User.CanView("T_Restrictions","T_Description"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 7208), Tuple.Create("\"", 7236)
            
            #line 148 "..\..\Views\T_Restrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 7216), Tuple.Create<System.Object, System.Int32>(Model.T_Description
            
            #line default
            #line hidden
, 7216), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 149 "..\..\Views\T_Restrictions\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabelmultiline\"");

WriteLiteral(">");

            
            #line 151 "..\..\Views\T_Restrictions\Details.cshtml"
                                 Write(Model.T_Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 155 "..\..\Views\T_Restrictions\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm pull-left formbuttonfix\"");

WriteAttribute("Onclick", Tuple.Create(" Onclick=\"", 7660), Tuple.Create("\"", 7718)
, Tuple.Create(Tuple.Create("", 7670), Tuple.Create("goBack(\'", 7670), true)
            
            #line 162 "..\..\Views\T_Restrictions\Details.cshtml"
           , Tuple.Create(Tuple.Create("", 7678), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_Restrictions")
            
            #line default
            #line hidden
, 7678), false)
, Tuple.Create(Tuple.Create("", 7715), Tuple.Create("\');", 7715), true)
);

WriteLiteral(">Back</a>\r\n\t\t\t\t");

WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 165 "..\..\Views\T_Restrictions\Details.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 165 "..\..\Views\T_Restrictions\Details.cshtml"
                      if ( User.CanEdit("T_Restrictions"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\T_Restrictions\Details.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { UrlReferrer = Request.UrlReferrer, id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\T_Restrictions\Details.cshtml"
                                                                                                                                                                                                                                                                                                                                                                        
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   \r\n");

            
            #line 170 "..\..\Views\T_Restrictions\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 170 "..\..\Views\T_Restrictions\Details.cshtml"
    var dropmenubottom = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dropdown pull-left formbuttonfix\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" id=\"AddAssociationdropmenubottomT_Restrictions\"");

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

WriteLiteral(">\r\n</ul>\r\n</div>\r\n");

            
            #line 179 "..\..\Views\T_Restrictions\Details.cshtml"
 if(!dropmenubottom)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenubottomT_Restrictions\").hide();\r\n " +
"   </script>\r\n");

            
            #line 184 "..\..\Views\T_Restrictions\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</div> \r\n\t\t\t</div><div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_RestrictionsRelation\"");

WriteLiteral(">\r\n");

            
            #line 189 "..\..\Views\T_Restrictions\Details.cshtml"
            
            
            #line default
            #line hidden
            
            #line 189 "..\..\Views\T_Restrictions\Details.cshtml"
             if ( User.CanView("JournalEntry"))
		   {
			//	Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_Restrictions", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
		   }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_TypeOfRestrictions_T_Restrictions\"");

WriteLiteral(">\r\n");

            
            #line 195 "..\..\Views\T_Restrictions\Details.cshtml"
     
            
            #line default
            #line hidden
            
            #line 195 "..\..\Views\T_Restrictions\Details.cshtml"
      if ( User.CanView("T_TypeOfRestrictions"))
	{
	  // Html.RenderAction("Index", "T_TypeOfRestrictions", new {RenderPartial=true, HostingEntity = "T_Restrictions", HostingEntityID = @Model.Id, AssociatedType = "T_TypeOfRestrictions_T_Restrictions" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591