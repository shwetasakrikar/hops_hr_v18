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

namespace GeneratorBase.MVC.Views.T_EmployeeStatusCode
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
    
    #line 2 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_EmployeeStatusCode/DetailsContent.cshtml")]
    public partial class DetailsContent : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_EmployeeStatusCode>
    {
        public DetailsContent()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
  
    ViewBag.Title = "View Employee Status Code";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeStatusCode");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Employee Status Code";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_EmployeeStatusCodeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_EmployeeStatusCodeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                           ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_EmployeeStatusCodeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_EmployeeStatusCodeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_EmployeeStatusCodeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_EmployeeStatusCodeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
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

            
            #line 36 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
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

            
            #line 38 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
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

            
            #line 46 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                     if ( User.CanEdit("T_EmployeeStatusCode"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1941), Tuple.Create("\"", 2221)
            
            #line 48 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 1948), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_EmployeeStatusCode", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1948), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                     if ( User.CanDelete("T_EmployeeStatusCode"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2460), Tuple.Create("\"", 2743)
            
            #line 54 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2467), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_EmployeeStatusCode", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2467), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
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

            
            #line 61 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
				
            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                 if ( User.CanAdd("T_Employee"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 3144), Tuple.Create("", 3428)
            
            #line 64 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3153), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Employee", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_EmployeeStatus", 
							HostingEntityName = "T_EmployeeStatusCode",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 3153), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Employees\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 72 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</ul>\r\n</li>\r\n\t\t\t</ul>\r\n</div>\r\n\t\t</h2>\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r" +
"\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3717), Tuple.Create("\"", 3782)
, Tuple.Create(Tuple.Create("", 3727), Tuple.Create("ClearTabCookie(\'", 3727), true)
            
            #line 83 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3743), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3743), false)
            
            #line 83 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
               , Tuple.Create(Tuple.Create("", 3770), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 3770), false)
, Tuple.Create(Tuple.Create("", 3779), Tuple.Create("\');", 3779), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 84 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
         Write(!User.CanView("T_Employee")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3885), Tuple.Create("\"", 4170)
, Tuple.Create(Tuple.Create("", 3895), Tuple.Create("LoadTab(\'T_EmployeeStatus\',\'", 3895), true)
            
            #line 84 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                             , Tuple.Create(Tuple.Create("", 3923), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3923), false)
            
            #line 84 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 3950), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 3950), false)
, Tuple.Create(Tuple.Create("", 3959), Tuple.Create("\',\'", 3959), true)
            
            #line 84 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                                    , Tuple.Create(Tuple.Create("", 3962), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_Employee", new {RenderPartial=true, HostingEntity ="T_EmployeeStatusCode", HostingEntityID = @Model.Id, AssociatedType = "T_EmployeeStatus",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 3962), false)
, Tuple.Create(Tuple.Create("", 4168), Tuple.Create("\')", 4168), true)
);

WriteLiteral(" href=\"#T_EmployeeStatus\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Employees\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_EmployeeStatus\"");

WriteLiteral(">");

            
            #line 86 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                                 Write(ViewBag.T_EmployeeStatusCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 88 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4424), Tuple.Create("\"", 4728)
, Tuple.Create(Tuple.Create("", 4434), Tuple.Create("LoadTab(\'JournalEntryToT_EmployeeStatusCodeRelation\',\'", 4434), true)
            
            #line 88 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                         , Tuple.Create(Tuple.Create("", 4488), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4488), false)
            
            #line 88 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                                                    , Tuple.Create(Tuple.Create("", 4515), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4515), false)
, Tuple.Create(Tuple.Create("", 4524), Tuple.Create("\',\'", 4524), true)
            
            #line 88 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                                                                , Tuple.Create(Tuple.Create("", 4527), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_EmployeeStatusCode", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 4527), false)
, Tuple.Create(Tuple.Create("", 4726), Tuple.Create("\')", 4726), true)
);

WriteLiteral(" href=\"#JournalEntryToT_EmployeeStatusCodeRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Employee Status Code Journal</a></li>\r\n    </ul>\r\n\t    <div");

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

            
            #line 98 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
 if(User.CanView("T_EmployeeStatusCode","T_Name"))
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

            
            #line 102 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 106 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                Write(Model.T_Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 111 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 112 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
 if(User.CanView("T_EmployeeStatusCode","T_Description"))
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

            
            #line 116 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 118 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                        Write(Model.T_Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 122 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 130 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 131 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 131 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                      if ( User.CanEdit("T_EmployeeStatusCode"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 133 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 133 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
                                                                                                                                                                                                                                                                                                                                     
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

            
            #line 145 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
			
            
            #line default
            #line hidden
            
            #line 145 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
             if ( User.CanAdd("T_Employee"))
            {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t <li>\r\n\t\t\t\t <a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 7147), Tuple.Create("", 7477)
            
            #line 148 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 7156), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Employee",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_EmployeeStatus", 
						HostingEntityName = "T_EmployeeStatusCode",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 7156), false)
);

WriteLiteral(" style=\"margin-top:5px;\"");

WriteLiteral(">\r\n                   Add  Employees</a>\r\n\t\t\t</li>\r\n");

            
            #line 156 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\r\n\r\n        </ul>\r\n\r\n\t\t\t</div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_EmployeeStatus\"");

WriteLiteral(">\r\n");

            
            #line 164 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
     
            
            #line default
            #line hidden
            
            #line 164 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
      if ( User.CanView("T_Employee"))
	{
	  // Html.RenderAction("Index", "T_Employee", new {RenderPartial=true, HostingEntity = "T_EmployeeStatusCode", HostingEntityID = @Model.Id, AssociatedType = "T_EmployeeStatus" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_EmployeeStatusCodeRelation\"");

WriteLiteral(">\r\n");

            
            #line 170 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
            
            
            #line default
            #line hidden
            
            #line 170 "..\..\Views\T_EmployeeStatusCode\DetailsContent.cshtml"
             if ( User.CanView("JournalEntry"))
		   {
			//	Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_EmployeeStatusCode", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
		   }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
