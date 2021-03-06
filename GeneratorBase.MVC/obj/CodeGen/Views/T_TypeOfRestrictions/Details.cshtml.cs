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
    
    #line 2 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_TypeOfRestrictions/Details.cshtml")]
    public partial class Details : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_TypeOfRestrictions>
    {
        public Details()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
  
    ViewBag.Title = "View Type Of Restrictions";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_TypeOfRestrictions");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Type Of Restrictions";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TypeOfRestrictionsIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
   Write(Html.Raw(ViewBag.T_TypeOfRestrictionsIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                                                           ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
   Write(Html.Raw(ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TypeOfRestrictionsIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
   Write(Html.Raw(ViewBag.T_TypeOfRestrictionsIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
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

            
            #line 36 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
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

            
            #line 38 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
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

            
            #line 46 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                     if ( User.CanEdit("T_TypeOfRestrictions"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1924), Tuple.Create("\"", 2208)
            
            #line 48 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 1931), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_TypeOfRestrictions", new {UrlReferrer = Request.UrlReferrer,id = Model.Id,AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1931), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                     if ( User.CanDelete("T_TypeOfRestrictions"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2447), Tuple.Create("\"", 2737)
            
            #line 54 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2454), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_TypeOfRestrictions", new { UrlReferrer = Request.UrlReferrer,id = Model.Id, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2454), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
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

WriteAttribute("href", Tuple.Create(" href=\"", 3061), Tuple.Create("\"", 3168)
            
            #line 62 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3068), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Comment", new {sourceEntity="T_TypeOfRestrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3068), false)
);

WriteLiteral(">Comment</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3200), Tuple.Create("\"", 3312)
            
            #line 65 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3207), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_LeaveProfile", new {sourceEntity="T_TypeOfRestrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3207), false)
);

WriteLiteral(">Leave</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3342), Tuple.Create("\"", 3455)
            
            #line 68 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3349), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Accommodation", new {sourceEntity="T_TypeOfRestrictions",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3349), false)
);

WriteLiteral(">Accommodation</a>\r\n</li>\r\n</ul>\r\n</li>\r\n\t\t\t</ul>\r\n\r\n\r\n\t\t</h2>\r\n    </div>\r\n    <" +
"!-- /.col-lg-12 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3671), Tuple.Create("\"", 3736)
, Tuple.Create(Tuple.Create("", 3681), Tuple.Create("ClearTabCookie(\'", 3681), true)
            
            #line 81 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3697), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3697), false)
            
            #line 81 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
               , Tuple.Create(Tuple.Create("", 3724), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 3724), false)
, Tuple.Create(Tuple.Create("", 3733), Tuple.Create("\');", 3733), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n    </ul>\r\n");

WriteLiteral("\t  ");

            
            #line 83 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
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

            
            #line 91 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
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

            
            #line 95 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_RestrictionsID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 97 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 97 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
  if (Model.t_restrictions!=null && !string.IsNullOrEmpty(Model.t_restrictions.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(" id=\"lblT_Restrictions\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 100 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_restrictions.DisplayValue).ToString(), "Details", "T_Restrictions", new { Id = Html.DisplayFor(model => model.t_restrictions.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 102 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 106 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 107 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
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

            
            #line 111 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_EmployeeInjuryID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 113 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 113 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
  if (Model.t_employeeinjury!=null && !string.IsNullOrEmpty(Model.t_employeeinjury.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(" id=\"lblT_EmployeeInjury\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 116 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_employeeinjury.DisplayValue).ToString(), "Details", "T_EmployeeInjury", new { Id = Html.DisplayFor(model => model.t_employeeinjury.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 118 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 122 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm pull-left formbuttonfix\"");

WriteAttribute("Onclick", Tuple.Create(" Onclick=\"", 5689), Tuple.Create("\"", 5753)
, Tuple.Create(Tuple.Create("", 5699), Tuple.Create("goBack(\'", 5699), true)
            
            #line 129 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
           , Tuple.Create(Tuple.Create("", 5707), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_TypeOfRestrictions")
            
            #line default
            #line hidden
, 5707), false)
, Tuple.Create(Tuple.Create("", 5750), Tuple.Create("\');", 5750), true)
);

WriteLiteral(">Back</a>\r\n\t\t\t\t");

WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 132 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 132 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                      if ( User.CanEdit("T_TypeOfRestrictions"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 134 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { UrlReferrer = Request.UrlReferrer, id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 134 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
                                                                                                                                                                                                                                                                                                                                                                        
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   \r\n");

            
            #line 137 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 137 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
    var dropmenubottom = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dropdown pull-left formbuttonfix\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" id=\"AddAssociationdropmenubottomT_TypeOfRestrictions\"");

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

            
            #line 146 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
 if(!dropmenubottom)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenubottomT_TypeOfRestrictions\").hide" +
"();\r\n    </script>\r\n");

            
            #line 151 "..\..\Views\T_TypeOfRestrictions\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</div> \r\n\t\t\t</div><div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n\t</div>    \r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
