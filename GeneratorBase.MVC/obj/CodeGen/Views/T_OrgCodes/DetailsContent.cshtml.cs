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

namespace GeneratorBase.MVC.Views.T_OrgCodes
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
    
    #line 2 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_OrgCodes/DetailsContent.cshtml")]
    public partial class DetailsContent : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_OrgCodes>
    {
        public DetailsContent()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
  
    ViewBag.Title = "View Org Codes";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_OrgCodes");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Org Codes";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_OrgCodesIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_OrgCodesIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_OrgCodesIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_OrgCodesIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                                       ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_OrgCodesIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_OrgCodesIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
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

            
            #line 36 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
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

            
            #line 38 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
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

            
            #line 46 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                     if ( User.CanEdit("T_OrgCodes"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1829), Tuple.Create("\"", 2099)
            
            #line 48 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 1836), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_OrgCodes", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1836), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                     if ( User.CanDelete("T_OrgCodes"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2328), Tuple.Create("\"", 2601)
            
            #line 54 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2335), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_OrgCodes", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2335), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
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

            
            #line 61 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
				
            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                 if ( User.CanAdd("T_UnitX"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 2999), Tuple.Create("", 3267)
            
            #line 64 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3008), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_UnitX", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_WardOrgCode", 
							HostingEntityName = "T_OrgCodes",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 3008), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Ward\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 72 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3551), Tuple.Create("\"", 3616)
, Tuple.Create(Tuple.Create("", 3561), Tuple.Create("ClearTabCookie(\'", 3561), true)
            
            #line 83 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3577), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3577), false)
            
            #line 83 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
               , Tuple.Create(Tuple.Create("", 3604), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 3604), false)
, Tuple.Create(Tuple.Create("", 3613), Tuple.Create("\');", 3613), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 84 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
         Write(!User.CanView("T_UnitX")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3716), Tuple.Create("\"", 3982)
, Tuple.Create(Tuple.Create("", 3726), Tuple.Create("LoadTab(\'T_WardOrgCode\',\'", 3726), true)
            
            #line 84 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                       , Tuple.Create(Tuple.Create("", 3751), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3751), false)
            
            #line 84 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                                  , Tuple.Create(Tuple.Create("", 3778), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 3778), false)
, Tuple.Create(Tuple.Create("", 3787), Tuple.Create("\',\'", 3787), true)
            
            #line 84 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                                              , Tuple.Create(Tuple.Create("", 3790), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_UnitX", new {RenderPartial=true, HostingEntity ="T_OrgCodes", HostingEntityID = @Model.Id, AssociatedType = "T_WardOrgCode",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 3790), false)
, Tuple.Create(Tuple.Create("", 3980), Tuple.Create("\')", 3980), true)
);

WriteLiteral(" href=\"#T_WardOrgCode\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Ward\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_WardOrgCode\"");

WriteLiteral(">");

            
            #line 86 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                                              Write(ViewBag.T_WardOrgCodeCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 88 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4222), Tuple.Create("\"", 4506)
, Tuple.Create(Tuple.Create("", 4232), Tuple.Create("LoadTab(\'JournalEntryToT_OrgCodesRelation\',\'", 4232), true)
            
            #line 88 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                               , Tuple.Create(Tuple.Create("", 4276), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4276), false)
            
            #line 88 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                                                          , Tuple.Create(Tuple.Create("", 4303), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4303), false)
, Tuple.Create(Tuple.Create("", 4312), Tuple.Create("\',\'", 4312), true)
            
            #line 88 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                                                                      , Tuple.Create(Tuple.Create("", 4315), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_OrgCodes", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 4315), false)
, Tuple.Create(Tuple.Create("", 4504), Tuple.Create("\')", 4504), true)
);

WriteLiteral(" href=\"#JournalEntryToT_OrgCodesRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Org Codes Journal</a></li>\r\n    </ul>\r\n\t    <div");

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

            
            #line 98 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
 if(User.CanView("T_OrgCodes","T_OrgCode"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_OrgCode\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Org  Code\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 102 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_OrgCode));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 106 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                Write(Model.T_OrgCode);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 111 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 112 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
 if(User.CanView("T_OrgCodes","T_CodeDescription"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_CodeDescription\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Code  Description\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 116 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_CodeDescription));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 118 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                        Write(Model.T_CodeDescription);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 122 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 130 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 131 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 131 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                      if ( User.CanEdit("T_OrgCodes"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 133 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 133 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
                                                                                                                                                                                                                                                                                                                                     
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

            
            #line 145 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
			
            
            #line default
            #line hidden
            
            #line 145 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
             if ( User.CanAdd("T_UnitX"))
            {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t <li>\r\n\t\t\t\t <a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 6910), Tuple.Create("", 7224)
            
            #line 148 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 6919), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_UnitX",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_WardOrgCode", 
						HostingEntityName = "T_OrgCodes",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 6919), false)
);

WriteLiteral(" style=\"margin-top:5px;\"");

WriteLiteral(">\r\n                   Add  Ward</a>\r\n\t\t\t</li>\r\n");

            
            #line 156 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\r\n\r\n        </ul>\r\n\r\n\t\t\t</div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_WardOrgCode\"");

WriteLiteral(">\r\n");

            
            #line 164 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
     
            
            #line default
            #line hidden
            
            #line 164 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
      if ( User.CanView("T_UnitX"))
	{
	  // Html.RenderAction("Index", "T_UnitX", new {RenderPartial=true, HostingEntity = "T_OrgCodes", HostingEntityID = @Model.Id, AssociatedType = "T_WardOrgCode" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_OrgCodesRelation\"");

WriteLiteral(">\r\n");

            
            #line 170 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
            
            
            #line default
            #line hidden
            
            #line 170 "..\..\Views\T_OrgCodes\DetailsContent.cshtml"
             if ( User.CanView("JournalEntry"))
		   {
			//	Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_OrgCodes", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
		   }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
