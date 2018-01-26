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

namespace GeneratorBase.MVC.Views.T_LanguageCertifiedIn
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
    
    #line 2 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_LanguageCertifiedIn/DetailsContent.cshtml")]
    public partial class DetailsContent : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_LanguageCertifiedIn>
    {
        public DetailsContent()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
  
    ViewBag.Title = "View Language Certified In";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_LanguageCertifiedIn");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Language Certified In";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_LanguageCertifiedInIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_LanguageCertifiedInIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                                                            ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                                                                  ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_LanguageCertifiedInIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_LanguageCertifiedInIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
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

            
            #line 36 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
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

            
            #line 38 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
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

            
            #line 46 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                     if ( User.CanEdit("T_LanguageCertifiedIn"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1952), Tuple.Create("\"", 2233)
            
            #line 48 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 1959), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_LanguageCertifiedIn", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1959), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                     if ( User.CanDelete("T_LanguageCertifiedIn"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2473), Tuple.Create("\"", 2757)
            
            #line 54 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2480), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_LanguageCertifiedIn", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2480), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
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

WriteAttribute("href", Tuple.Create(" href=\"", 3081), Tuple.Create("\"", 3192)
            
            #line 62 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3088), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "FileDocument", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3088), false)
);

WriteLiteral(">Document</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3225), Tuple.Create("\"", 3334)
            
            #line 65 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3232), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Licenses", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3232), false)
);

WriteLiteral(">Licenses</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3367), Tuple.Create("\"", 3481)
            
            #line 68 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3374), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_ServiceRecord", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3374), false)
);

WriteLiteral(">Service Record</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3520), Tuple.Create("\"", 3628)
            
            #line 71 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3527), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Comment", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3527), false)
);

WriteLiteral(">Comment</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3660), Tuple.Create("\"", 3776)
            
            #line 74 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3667), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_DrugAlcoholTest", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3667), false)
);

WriteLiteral(">Drug & Alcohol Test</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3820), Tuple.Create("\"", 3926)
            
            #line 77 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3827), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_UnitX", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3827), false)
);

WriteLiteral(">UnitX</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3956), Tuple.Create("\"", 4070)
            
            #line 80 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3963), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_JobAssignment", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3963), false)
);

WriteLiteral(">Job Assignment</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4109), Tuple.Create("\"", 4222)
            
            #line 83 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4116), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_LeaveProfile", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4116), false)
);

WriteLiteral(">Leave</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4252), Tuple.Create("\"", 4367)
            
            #line 86 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4259), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_EmployeeInjury", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4259), false)
);

WriteLiteral(">Employee Injury</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4407), Tuple.Create("\"", 4523)
            
            #line 89 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4414), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_BackgroundCheck", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4414), false)
);

WriteLiteral(">Background Check</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4564), Tuple.Create("\"", 4674)
            
            #line 92 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4571), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Education", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4571), false)
);

WriteLiteral(">Education</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4708), Tuple.Create("\"", 4822)
            
            #line 95 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4715), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Accommodation", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4715), false)
);

WriteLiteral(">Accommodation</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4860), Tuple.Create("\"", 4971)
            
            #line 98 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4867), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_PayDetails", new {sourceEntity="T_LanguageCertifiedIn",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4867), false)
);

WriteLiteral(">Pay Details </a>\r\n</li>\r\n</ul>\r\n</li>\r\n\t\t\t</ul>\r\n</div>\r\n\t\t</h2>\r\n    </div>\r\n  " +
"  <!-- /.col-lg-12 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5190), Tuple.Create("\"", 5255)
, Tuple.Create(Tuple.Create("", 5200), Tuple.Create("ClearTabCookie(\'", 5200), true)
            
            #line 110 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 5216), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 5216), false)
            
            #line 110 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
               , Tuple.Create(Tuple.Create("", 5243), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5243), false)
, Tuple.Create(Tuple.Create("", 5252), Tuple.Create("\');", 5252), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n    </ul>\r\n\t    <div");

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

            
            #line 120 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
 if(User.CanView("T_LanguageCertifiedIn","T_EmployeeID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Employee\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 124 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_EmployeeID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 126 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
 
            
            #line default
            #line hidden
            
            #line 126 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
  if (Model.t_employee!=null && !string.IsNullOrEmpty(Model.t_employee.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 129 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_employee.DisplayValue).ToString(), "Details", "T_Employee", new { Id = Html.DisplayFor(model => model.t_employee.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 131 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 135 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
 if(User.CanView("T_LanguageCertifiedIn","T_LangaugeID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Langauge\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 140 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_LangaugeID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 142 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
 
            
            #line default
            #line hidden
            
            #line 142 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
  if (Model.t_langauge!=null && !string.IsNullOrEmpty(Model.t_langauge.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 145 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_langauge.DisplayValue).ToString(), "Details", "T_Langauge", new { Id = Html.DisplayFor(model => model.t_langauge.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 147 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 151 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 159 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 160 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 160 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                      if ( User.CanEdit("T_LanguageCertifiedIn"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 162 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 162 "..\..\Views\T_LanguageCertifiedIn\DetailsContent.cshtml"
                                                                                                                                                                                                                                                                                                                                     
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>    \r\n\t</div>    \r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<b" +
"r/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
