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

namespace GeneratorBase.MVC.Views.T_ConversationalEmployeeForeignLanguage
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
    
    #line 2 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ConversationalEmployeeForeignLanguage/DetailsContent.cshtml")]
    public partial class DetailsContent : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_ConversationalEmployeeForeignLanguage>
    {
        public DetailsContent()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
  
    ViewBag.Title = "View Conversational Employee Foreign Language";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ConversationalEmployeeForeignLanguage");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Conversational Employee Foreign Language";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ConversationalEmployeeForeignLanguageIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_ConversationalEmployeeForeignLanguageIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                                                                              ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ConversationalEmployeeForeignLanguageIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_ConversationalEmployeeForeignLanguageIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                                                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ConversationalEmployeeForeignLanguageIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_ConversationalEmployeeForeignLanguageIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
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

            
            #line 36 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
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

            
            #line 38 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
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

            
            #line 46 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                     if ( User.CanEdit("T_ConversationalEmployeeForeignLanguage"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2152), Tuple.Create("\"", 2451)
            
            #line 48 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2159), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_ConversationalEmployeeForeignLanguage", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 2159), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                     if ( User.CanDelete("T_ConversationalEmployeeForeignLanguage"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2709), Tuple.Create("\"", 3011)
            
            #line 54 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2716), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_ConversationalEmployeeForeignLanguage", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2716), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
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

WriteAttribute("href", Tuple.Create(" href=\"", 3335), Tuple.Create("\"", 3464)
            
            #line 62 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3342), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "FileDocument", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3342), false)
);

WriteLiteral(">Document</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3497), Tuple.Create("\"", 3624)
            
            #line 65 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3504), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Licenses", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3504), false)
);

WriteLiteral(">Licenses</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3657), Tuple.Create("\"", 3789)
            
            #line 68 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3664), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_ServiceRecord", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3664), false)
);

WriteLiteral(">Service Record</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3828), Tuple.Create("\"", 3954)
            
            #line 71 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3835), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Comment", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3835), false)
);

WriteLiteral(">Comment</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3986), Tuple.Create("\"", 4120)
            
            #line 74 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3993), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_DrugAlcoholTest", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3993), false)
);

WriteLiteral(">Drug & Alcohol Test</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4164), Tuple.Create("\"", 4288)
            
            #line 77 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4171), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_UnitX", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4171), false)
);

WriteLiteral(">UnitX</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4318), Tuple.Create("\"", 4450)
            
            #line 80 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4325), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_JobAssignment", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4325), false)
);

WriteLiteral(">Job Assignment</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4489), Tuple.Create("\"", 4620)
            
            #line 83 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4496), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_LeaveProfile", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4496), false)
);

WriteLiteral(">Leave</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4650), Tuple.Create("\"", 4783)
            
            #line 86 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4657), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_EmployeeInjury", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4657), false)
);

WriteLiteral(">Employee Injury</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4823), Tuple.Create("\"", 4957)
            
            #line 89 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4830), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_BackgroundCheck", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4830), false)
);

WriteLiteral(">Background Check</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4998), Tuple.Create("\"", 5126)
            
            #line 92 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 5005), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Education", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 5005), false)
);

WriteLiteral(">Education</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 5160), Tuple.Create("\"", 5292)
            
            #line 95 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 5167), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Accommodation", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 5167), false)
);

WriteLiteral(">Accommodation</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 5330), Tuple.Create("\"", 5459)
            
            #line 98 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 5337), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_PayDetails", new {sourceEntity="T_ConversationalEmployeeForeignLanguage",id=Model.Id}, null)
            
            #line default
            #line hidden
, 5337), false)
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5678), Tuple.Create("\"", 5743)
, Tuple.Create(Tuple.Create("", 5688), Tuple.Create("ClearTabCookie(\'", 5688), true)
            
            #line 110 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 5704), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 5704), false)
            
            #line 110 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
               , Tuple.Create(Tuple.Create("", 5731), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5731), false)
, Tuple.Create(Tuple.Create("", 5740), Tuple.Create("\');", 5740), true)
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

            
            #line 120 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
 if(User.CanView("T_ConversationalEmployeeForeignLanguage","T_EmployeeID"))
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

            
            #line 124 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_EmployeeID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 126 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
 
            
            #line default
            #line hidden
            
            #line 126 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
  if (Model.t_employee!=null && !string.IsNullOrEmpty(Model.t_employee.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 129 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_employee.DisplayValue).ToString(), "Details", "T_Employee", new { Id = Html.DisplayFor(model => model.t_employee.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 131 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 135 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
 if(User.CanView("T_ConversationalEmployeeForeignLanguage","T_LangaugeID"))
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

            
            #line 140 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_LangaugeID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 142 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
 
            
            #line default
            #line hidden
            
            #line 142 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
  if (Model.t_langauge!=null && !string.IsNullOrEmpty(Model.t_langauge.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 145 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_langauge.DisplayValue).ToString(), "Details", "T_Langauge", new { Id = Html.DisplayFor(model => model.t_langauge.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 147 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 151 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 159 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 160 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 160 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                      if ( User.CanEdit("T_ConversationalEmployeeForeignLanguage"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 162 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 162 "..\..\Views\T_ConversationalEmployeeForeignLanguage\DetailsContent.cshtml"
                                                                                                                                                                                                                                                                                                                                     
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>    \r\n\t</div>    \r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<b" +
"r/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591