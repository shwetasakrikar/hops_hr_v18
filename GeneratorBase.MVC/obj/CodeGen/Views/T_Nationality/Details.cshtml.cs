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

namespace GeneratorBase.MVC.Views.T_Nationality
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
    
    #line 2 "..\..\Views\T_Nationality\Details.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Nationality/Details.cshtml")]
    public partial class Details : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Nationality>
    {
        public Details()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_Nationality\Details.cshtml"
  
    ViewBag.Title = "View Nationality";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Nationality");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Nationality";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_Nationality\Details.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_Nationality\Details.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_Nationality\Details.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_Nationality\Details.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_Nationality\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_NationalityIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_Nationality\Details.cshtml"
   Write(Html.Raw(ViewBag.T_NationalityIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_Nationality\Details.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_Nationality\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_NationalityIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_Nationality\Details.cshtml"
   Write(Html.Raw(ViewBag.T_NationalityIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_Nationality\Details.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_Nationality\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_NationalityIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_Nationality\Details.cshtml"
   Write(Html.Raw(ViewBag.T_NationalityIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_Nationality\Details.cshtml"
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

            
            #line 36 "..\..\Views\T_Nationality\Details.cshtml"
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

            
            #line 38 "..\..\Views\T_Nationality\Details.cshtml"
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

            
            #line 46 "..\..\Views\T_Nationality\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_Nationality\Details.cshtml"
                     if ( User.CanEdit("T_Nationality"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1843), Tuple.Create("\"", 2120)
            
            #line 48 "..\..\Views\T_Nationality\Details.cshtml"
, Tuple.Create(Tuple.Create("", 1850), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_Nationality", new {UrlReferrer = Request.UrlReferrer,id = Model.Id,AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1850), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_Nationality\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_Nationality\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_Nationality\Details.cshtml"
                     if ( User.CanDelete("T_Nationality"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2352), Tuple.Create("\"", 2635)
            
            #line 54 "..\..\Views\T_Nationality\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2359), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_Nationality", new { UrlReferrer = Request.UrlReferrer,id = Model.Id, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2359), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_Nationality\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t<li");

WriteLiteral(" class=\"divider\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></li>\r\n\t<li");

WriteLiteral(" class=\"dropdown-submenu pull-left\"");

WriteLiteral(" id=\"AddAssociationdropmenuT_Nationality\"");

WriteLiteral(">\r\n");

            
            #line 59 "..\..\Views\T_Nationality\Details.cshtml"
	 
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\T_Nationality\Details.cshtml"
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

            
            #line 62 "..\..\Views\T_Nationality\Details.cshtml"
				
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\T_Nationality\Details.cshtml"
                 if ( User.CanAdd("T_Employee"))
				{ dropmenu = true;

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 3124), Tuple.Create("", 3417)
            
            #line 65 "..\..\Views\T_Nationality\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3133), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Employee", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_EmployeeNationalityAssociation", 
							HostingEntityName = "T_Nationality",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 3133), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Employee\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 73 "..\..\Views\T_Nationality\Details.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</ul>\r\n</li>\r\n");

            
            #line 76 "..\..\Views\T_Nationality\Details.cshtml"
 if(!dropmenu)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenuT_Nationality\").hide();\r\n    </sc" +
"ript>\r\n");

            
            #line 81 "..\..\Views\T_Nationality\Details.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3811), Tuple.Create("\"", 3876)
, Tuple.Create(Tuple.Create("", 3821), Tuple.Create("ClearTabCookie(\'", 3821), true)
            
            #line 91 "..\..\Views\T_Nationality\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3837), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3837), false)
            
            #line 91 "..\..\Views\T_Nationality\Details.cshtml"
               , Tuple.Create(Tuple.Create("", 3864), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 3864), false)
, Tuple.Create(Tuple.Create("", 3873), Tuple.Create("\');", 3873), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 92 "..\..\Views\T_Nationality\Details.cshtml"
         Write(!User.CanView("T_Employee") ?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3980), Tuple.Create("\"", 4290)
, Tuple.Create(Tuple.Create("", 3990), Tuple.Create("LoadTab(\'T_EmployeeNationalityAssociation\',\'", 3990), true)
            
            #line 92 "..\..\Views\T_Nationality\Details.cshtml"
                                              , Tuple.Create(Tuple.Create("", 4034), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4034), false)
            
            #line 92 "..\..\Views\T_Nationality\Details.cshtml"
                                                                         , Tuple.Create(Tuple.Create("", 4061), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4061), false)
, Tuple.Create(Tuple.Create("", 4070), Tuple.Create("\',\'", 4070), true)
            
            #line 92 "..\..\Views\T_Nationality\Details.cshtml"
                                                                                     , Tuple.Create(Tuple.Create("", 4073), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_Employee", new {RenderPartial=true, HostingEntity ="T_Nationality", HostingEntityID = @Model.Id, AssociatedType = "T_EmployeeNationalityAssociation",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 4073), false)
, Tuple.Create(Tuple.Create("", 4288), Tuple.Create("\')", 4288), true)
);

WriteLiteral(" href=\"#T_EmployeeNationalityAssociation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Employee\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_EmployeeNationalityAssociation\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\T_Nationality\Details.cshtml"
                                                                                 Write(ViewBag.T_EmployeeNationalityAssociationCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n    </ul>\r\n");

WriteLiteral("\t  ");

            
            #line 97 "..\..\Views\T_Nationality\Details.cshtml"
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

            
            #line 105 "..\..\Views\T_Nationality\Details.cshtml"
 if(User.CanView("T_Nationality","T_Name"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 4934), Tuple.Create("\"", 4955)
            
            #line 108 "..\..\Views\T_Nationality\Details.cshtml"
, Tuple.Create(Tuple.Create("", 4942), Tuple.Create<System.Object, System.Int32>(Model.T_Name
            
            #line default
            #line hidden
, 4942), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 109 "..\..\Views\T_Nationality\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" id=\"lblT_Name\"");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 113 "..\..\Views\T_Nationality\Details.cshtml"
                                               Write(Model.T_Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 118 "..\..\Views\T_Nationality\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 119 "..\..\Views\T_Nationality\Details.cshtml"
 if(User.CanView("T_Nationality","T_Description"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 5367), Tuple.Create("\"", 5395)
            
            #line 122 "..\..\Views\T_Nationality\Details.cshtml"
, Tuple.Create(Tuple.Create("", 5375), Tuple.Create<System.Object, System.Int32>(Model.T_Description
            
            #line default
            #line hidden
, 5375), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 123 "..\..\Views\T_Nationality\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabelmultiline\"");

WriteLiteral(">");

            
            #line 125 "..\..\Views\T_Nationality\Details.cshtml"
                                 Write(Model.T_Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 129 "..\..\Views\T_Nationality\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm pull-left formbuttonfix\"");

WriteAttribute("Onclick", Tuple.Create(" Onclick=\"", 5819), Tuple.Create("\"", 5876)
, Tuple.Create(Tuple.Create("", 5829), Tuple.Create("goBack(\'", 5829), true)
            
            #line 136 "..\..\Views\T_Nationality\Details.cshtml"
           , Tuple.Create(Tuple.Create("", 5837), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_Nationality")
            
            #line default
            #line hidden
, 5837), false)
, Tuple.Create(Tuple.Create("", 5873), Tuple.Create("\');", 5873), true)
);

WriteLiteral(">Back</a>\r\n\t\t\t\t");

WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 139 "..\..\Views\T_Nationality\Details.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 139 "..\..\Views\T_Nationality\Details.cshtml"
                      if ( User.CanEdit("T_Nationality"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 141 "..\..\Views\T_Nationality\Details.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { UrlReferrer = Request.UrlReferrer, id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 141 "..\..\Views\T_Nationality\Details.cshtml"
                                                                                                                                                                                                                                                                                                                                                                        
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   \r\n");

            
            #line 144 "..\..\Views\T_Nationality\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 144 "..\..\Views\T_Nationality\Details.cshtml"
    var dropmenubottom = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dropdown pull-left formbuttonfix\"");

WriteLiteral(" style=\"\"");

WriteLiteral(" id=\"AddAssociationdropmenubottomT_Nationality\"");

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

            
            #line 151 "..\..\Views\T_Nationality\Details.cshtml"
			
            
            #line default
            #line hidden
            
            #line 151 "..\..\Views\T_Nationality\Details.cshtml"
             if (User.CanAdd("T_Employee"))
            {
			    dropmenubottom = true;

            
            #line default
            #line hidden
WriteLiteral("                <li><a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 7032), Tuple.Create("", 7371)
            
            #line 154 "..\..\Views\T_Nationality\Details.cshtml"
, Tuple.Create(Tuple.Create("", 7041), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Employee",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_EmployeeNationalityAssociation", 
						HostingEntityName = "T_Nationality",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 7041), false)
);

WriteLiteral(">\r\n                   Add  Employee\r\n                </a>\r\n\t\t\t\t</li>\r\n");

            
            #line 163 "..\..\Views\T_Nationality\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\r\n</ul>\r\n</div>\r\n");

            
            #line 168 "..\..\Views\T_Nationality\Details.cshtml"
 if(!dropmenubottom)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenubottomT_Nationality\").hide();\r\n  " +
"  </script>\r\n");

            
            #line 173 "..\..\Views\T_Nationality\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</div> \r\n\t\t\t</div><div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_EmployeeNationalityAssociation\"");

WriteLiteral(">\r\n");

            
            #line 178 "..\..\Views\T_Nationality\Details.cshtml"
     
            
            #line default
            #line hidden
            
            #line 178 "..\..\Views\T_Nationality\Details.cshtml"
      if ( User.CanView("T_Employee"))
	{
	  // Html.RenderAction("Index", "T_Employee", new {RenderPartial=true, HostingEntity = "T_Nationality", HostingEntityID = @Model.Id, AssociatedType = "T_EmployeeNationalityAssociation" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
