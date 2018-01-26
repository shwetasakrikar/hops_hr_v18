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

namespace GeneratorBase.MVC.Views.T_TypeOfRestrictions
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
    
    #line 2 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_TypeOfRestrictions/DetailsContent.cshtml")]
    public partial class DetailsContent : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_TypeOfRestrictions>
    {
        public DetailsContent()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
  
    ViewBag.Title = "View Type Of Restrictions";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_TypeOfRestrictions");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Type Of Restrictions";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TypeOfRestrictionsIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_TypeOfRestrictionsIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                                                           ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TypeOfRestrictionsIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_TypeOfRestrictionsIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
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

            
            #line 36 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
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

            
            #line 38 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
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

            
            #line 46 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                     if ( User.CanEdit("T_TypeOfRestrictions"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1941), Tuple.Create("\"", 2221)
            
            #line 48 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 1948), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_TypeOfRestrictions", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1948), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                     if ( User.CanDelete("T_TypeOfRestrictions"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2460), Tuple.Create("\"", 2743)
            
            #line 54 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2467), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_TypeOfRestrictions", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2467), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
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

WriteAttribute("href", Tuple.Create(" href=\"", 3067), Tuple.Create("\"", 3174)
            
            #line 62 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3074), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Comment", new {sourceEntity="T_TypeOfRestrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3074), false)
);

WriteLiteral(">Comment</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3206), Tuple.Create("\"", 3318)
            
            #line 65 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3213), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_LeaveProfile", new {sourceEntity="T_TypeOfRestrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3213), false)
);

WriteLiteral(">Leave</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3348), Tuple.Create("\"", 3461)
            
            #line 68 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3355), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Accommodation", new {sourceEntity="T_TypeOfRestrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3355), false)
);

WriteLiteral(">Accommodation</a>\r\n</li>\r\n</ul>\r\n</li>\r\n\t\t\t</ul>\r\n</div>\r\n\t\t</h2>\r\n    </div>\r\n " +
"   <!-- /.col-lg-12 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3681), Tuple.Create("\"", 3746)
, Tuple.Create(Tuple.Create("", 3691), Tuple.Create("ClearTabCookie(\'", 3691), true)
            
            #line 80 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3707), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3707), false)
            
            #line 80 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
               , Tuple.Create(Tuple.Create("", 3734), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 3734), false)
, Tuple.Create(Tuple.Create("", 3743), Tuple.Create("\');", 3743), true)
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

            
            #line 90 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
 if(User.CanView("T_TypeOfRestrictions","T_RestrictionsID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Restrictions\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_RestrictionsID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 96 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
 
            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
  if (Model.t_restrictions!=null && !string.IsNullOrEmpty(Model.t_restrictions.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 99 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_restrictions.DisplayValue).ToString(), "Details", "T_Restrictions", new { Id = Html.DisplayFor(model => model.t_restrictions.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 101 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 105 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 106 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
 if(User.CanView("T_TypeOfRestrictions","T_EmployeeInjuryID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_EmployeeInjury\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 110 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_EmployeeInjuryID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 112 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
 
            
            #line default
            #line hidden
            
            #line 112 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
  if (Model.t_employeeinjury!=null && !string.IsNullOrEmpty(Model.t_employeeinjury.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 115 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_employeeinjury.DisplayValue).ToString(), "Details", "T_EmployeeInjury", new { Id = Html.DisplayFor(model => model.t_employeeinjury.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 117 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 121 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 129 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 130 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 130 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                      if ( User.CanEdit("T_TypeOfRestrictions"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 132 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 132 "..\..\Views\T_TypeOfRestrictions\DetailsContent.cshtml"
                                                                                                                                                                                                                                                                                                                                     
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>    \r\n\t</div>    \r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<b" +
"r/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
