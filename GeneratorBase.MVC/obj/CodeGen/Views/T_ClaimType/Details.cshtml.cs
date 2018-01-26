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

namespace GeneratorBase.MVC.Views.T_ClaimType
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
    
    #line 2 "..\..\Views\T_ClaimType\Details.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ClaimType/Details.cshtml")]
    public partial class Details : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_ClaimType>
    {
        public Details()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_ClaimType\Details.cshtml"
  
    ViewBag.Title = "View Claim Type";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ClaimType");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Claim Type";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_ClaimType\Details.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_ClaimType\Details.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_ClaimType\Details.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_ClaimType\Details.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_ClaimType\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClaimTypeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_ClaimType\Details.cshtml"
   Write(Html.Raw(ViewBag.T_ClaimTypeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_ClaimType\Details.cshtml"
                                                  ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_ClaimType\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClaimTypeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_ClaimType\Details.cshtml"
   Write(Html.Raw(ViewBag.T_ClaimTypeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_ClaimType\Details.cshtml"
                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_ClaimType\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClaimTypeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_ClaimType\Details.cshtml"
   Write(Html.Raw(ViewBag.T_ClaimTypeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_ClaimType\Details.cshtml"
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

            
            #line 36 "..\..\Views\T_ClaimType\Details.cshtml"
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

            
            #line 38 "..\..\Views\T_ClaimType\Details.cshtml"
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

            
            #line 46 "..\..\Views\T_ClaimType\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_ClaimType\Details.cshtml"
                     if ( User.CanEdit("T_ClaimType"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1823), Tuple.Create("\"", 2098)
            
            #line 48 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 1830), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_ClaimType", new {UrlReferrer = Request.UrlReferrer,id = Model.Id,AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1830), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_ClaimType\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_ClaimType\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_ClaimType\Details.cshtml"
                     if ( User.CanDelete("T_ClaimType"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2328), Tuple.Create("\"", 2609)
            
            #line 54 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2335), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_ClaimType", new { UrlReferrer = Request.UrlReferrer,id = Model.Id, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2335), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_ClaimType\Details.cshtml"
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

WriteAttribute("href", Tuple.Create(" href=\"", 2933), Tuple.Create("\"", 3034)
            
            #line 62 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2940), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Department", new {sourceEntity="T_ClaimType",id=Model.Id}, null)
            
            #line default
            #line hidden
, 2940), false)
);

WriteLiteral(">Department</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3069), Tuple.Create("\"", 3168)
            
            #line 65 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3076), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Position", new {sourceEntity="T_ClaimType",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3076), false)
);

WriteLiteral(">Position</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3201), Tuple.Create("\"", 3300)
            
            #line 68 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3208), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Employee", new {sourceEntity="T_ClaimType",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3208), false)
);

WriteLiteral(">Employee</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3333), Tuple.Create("\"", 3438)
            
            #line 71 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3340), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_DepartmentArea", new {sourceEntity="T_ClaimType",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3340), false)
);

WriteLiteral(">Department Area</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3478), Tuple.Create("\"", 3581)
            
            #line 74 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3485), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Restrictions", new {sourceEntity="T_ClaimType",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3485), false)
);

WriteLiteral(">Restrictions</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3618), Tuple.Create("\"", 3714)
            
            #line 77 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3625), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_UnitX", new {sourceEntity="T_ClaimType",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3625), false)
);

WriteLiteral(">UnitX</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3744), Tuple.Create("\"", 3839)
            
            #line 80 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3751), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Unit", new {sourceEntity="T_ClaimType",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3751), false)
);

WriteLiteral(">Unit</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3868), Tuple.Create("\"", 3970)
            
            #line 83 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3875), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_SalaryRange", new {sourceEntity="T_ClaimType",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3875), false)
);

WriteLiteral(">Salary Range</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4007), Tuple.Create("\"", 4119)
            
            #line 86 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 4014), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_FacilityConfiguration", new {sourceEntity="T_ClaimType",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4014), false)
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4344), Tuple.Create("\"", 4409)
, Tuple.Create(Tuple.Create("", 4354), Tuple.Create("ClearTabCookie(\'", 4354), true)
            
            #line 99 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 4370), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4370), false)
            
            #line 99 "..\..\Views\T_ClaimType\Details.cshtml"
               , Tuple.Create(Tuple.Create("", 4397), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4397), false)
, Tuple.Create(Tuple.Create("", 4406), Tuple.Create("\');", 4406), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 100 "..\..\Views\T_ClaimType\Details.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4514), Tuple.Create("\"", 4800)
, Tuple.Create(Tuple.Create("", 4524), Tuple.Create("LoadTab(\'JournalEntryToT_ClaimTypeRelation\',\'", 4524), true)
            
            #line 100 "..\..\Views\T_ClaimType\Details.cshtml"
                                                , Tuple.Create(Tuple.Create("", 4569), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4569), false)
            
            #line 100 "..\..\Views\T_ClaimType\Details.cshtml"
                                                                           , Tuple.Create(Tuple.Create("", 4596), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4596), false)
, Tuple.Create(Tuple.Create("", 4605), Tuple.Create("\',\'", 4605), true)
            
            #line 100 "..\..\Views\T_ClaimType\Details.cshtml"
                                                                                       , Tuple.Create(Tuple.Create("", 4608), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_ClaimType", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 4608), false)
, Tuple.Create(Tuple.Create("", 4798), Tuple.Create("\')", 4798), true)
);

WriteLiteral(" href=\"#JournalEntryToT_ClaimTypeRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Claim Type Journal</a></li>\r\n    </ul>\r\n");

WriteLiteral("\t  ");

            
            #line 102 "..\..\Views\T_ClaimType\Details.cshtml"
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

            
            #line 110 "..\..\Views\T_ClaimType\Details.cshtml"
 if(User.CanView("T_ClaimType","T_ClaimTypeFacilityAssociationID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_ClaimTypeFacilityAssociation\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 114 "..\..\Views\T_ClaimType\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_ClaimTypeFacilityAssociationID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 116 "..\..\Views\T_ClaimType\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 116 "..\..\Views\T_ClaimType\Details.cshtml"
  if (Model.t_claimtypefacilityassociation!=null && !string.IsNullOrEmpty(Model.t_claimtypefacilityassociation.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(" id=\"lblT_ClaimTypeFacilityAssociation\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 119 "..\..\Views\T_ClaimType\Details.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_claimtypefacilityassociation.DisplayValue).ToString(), "Details", "T_Facility", new { Id = Html.DisplayFor(model => model.t_claimtypefacilityassociation.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 121 "..\..\Views\T_ClaimType\Details.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 125 "..\..\Views\T_ClaimType\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 126 "..\..\Views\T_ClaimType\Details.cshtml"
 if(User.CanView("T_ClaimType","T_Name"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 6137), Tuple.Create("\"", 6158)
            
            #line 129 "..\..\Views\T_ClaimType\Details.cshtml"
, Tuple.Create(Tuple.Create("", 6145), Tuple.Create<System.Object, System.Int32>(Model.T_Name
            
            #line default
            #line hidden
, 6145), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 130 "..\..\Views\T_ClaimType\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" id=\"lblT_Name\"");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 134 "..\..\Views\T_ClaimType\Details.cshtml"
                                               Write(Model.T_Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 139 "..\..\Views\T_ClaimType\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n");

            
            #line 141 "..\..\Views\T_ClaimType\Details.cshtml"
			
            
            #line default
            #line hidden
            
            #line 141 "..\..\Views\T_ClaimType\Details.cshtml"
             if ( (User.CanView("T_EmployeeInjury") && User.CanView("T_TypeofClaim")))
                            {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-sm-12 col-md-12 col-sx-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(" style=\"margin:0px; padding:4px 10px;\"");

WriteLiteral(">\r\n                                    Employee Injury\r\n                         " +
"       </div>\r\n                                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(" style=\"margin:0px; padding:8px;\"");

WriteLiteral(">\r\n");

            
            #line 150 "..\..\Views\T_ClaimType\Details.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\T_ClaimType\Details.cshtml"
                                     foreach (var chkitem in Model.T_EmployeeInjury_T_TypeofClaim)
                                    {
										if ((Model.SelectedT_EmployeeInjury_T_TypeofClaim.Contains(chkitem.Id)))
										{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" disabled");

WriteLiteral(" name=\"SelectedT_EmployeeInjury_T_TypeofClaim\"");

WriteAttribute("value", Tuple.Create(" value=\"", 7319), Tuple.Create("\"", 7338)
            
            #line 154 "..\..\Views\T_ClaimType\Details.cshtml"
                                                 , Tuple.Create(Tuple.Create("", 7327), Tuple.Create<System.Object, System.Int32>(chkitem.Id
            
            #line default
            #line hidden
, 7327), false)
);

WriteLiteral(" checked");

WriteAttribute("title", Tuple.Create(" title=\"", 7347), Tuple.Create("\"", 7376)
            
            #line 154 "..\..\Views\T_ClaimType\Details.cshtml"
                                                                             , Tuple.Create(Tuple.Create("", 7355), Tuple.Create<System.Object, System.Int32>(chkitem.DisplayValue
            
            #line default
            #line hidden
, 7355), false)
);

WriteLiteral("/> ");

            
            #line 154 "..\..\Views\T_ClaimType\Details.cshtml"
                                                                                                                                                                                      
            
            #line default
            #line hidden
            
            #line 154 "..\..\Views\T_ClaimType\Details.cshtml"
                                                                                                                                                                                 Write(chkitem.DisplayValue);

            
            #line default
            #line hidden
            
            #line 154 "..\..\Views\T_ClaimType\Details.cshtml"
                                                                                                                                                                                                           
										}
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </div>\r\n                            </div>\r\n     " +
"                   </div>\r\n                    </div>\r\n");

            
            #line 161 "..\..\Views\T_ClaimType\Details.cshtml"
					}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm pull-left formbuttonfix\"");

WriteAttribute("Onclick", Tuple.Create(" Onclick=\"", 7759), Tuple.Create("\"", 7814)
, Tuple.Create(Tuple.Create("", 7769), Tuple.Create("goBack(\'", 7769), true)
            
            #line 167 "..\..\Views\T_ClaimType\Details.cshtml"
           , Tuple.Create(Tuple.Create("", 7777), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_ClaimType")
            
            #line default
            #line hidden
, 7777), false)
, Tuple.Create(Tuple.Create("", 7811), Tuple.Create("\');", 7811), true)
);

WriteLiteral(">Back</a>\r\n\t\t\t\t");

WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 170 "..\..\Views\T_ClaimType\Details.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 170 "..\..\Views\T_ClaimType\Details.cshtml"
                      if ( User.CanEdit("T_ClaimType"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 172 "..\..\Views\T_ClaimType\Details.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { UrlReferrer = Request.UrlReferrer, id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 172 "..\..\Views\T_ClaimType\Details.cshtml"
                                                                                                                                                                                                                                                                                                                                                                        
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   \r\n");

            
            #line 175 "..\..\Views\T_ClaimType\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 175 "..\..\Views\T_ClaimType\Details.cshtml"
    var dropmenubottom = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dropdown pull-left formbuttonfix\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" id=\"AddAssociationdropmenubottomT_ClaimType\"");

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

            
            #line 184 "..\..\Views\T_ClaimType\Details.cshtml"
 if(!dropmenubottom)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenubottomT_ClaimType\").hide();\r\n    " +
"</script>\r\n");

            
            #line 189 "..\..\Views\T_ClaimType\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</div> \r\n\t\t\t</div><div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_ClaimTypeRelation\"");

WriteLiteral(">\r\n");

            
            #line 194 "..\..\Views\T_ClaimType\Details.cshtml"
            
            
            #line default
            #line hidden
            
            #line 194 "..\..\Views\T_ClaimType\Details.cshtml"
             if ( User.CanView("JournalEntry"))
		   {
			//	Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_ClaimType", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
		   }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_TypeofClaim_T_ClaimType\"");

WriteLiteral(">\r\n   </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
