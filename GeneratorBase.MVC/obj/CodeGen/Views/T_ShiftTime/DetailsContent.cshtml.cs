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

namespace GeneratorBase.MVC.Views.T_ShiftTime
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
    
    #line 2 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ShiftTime/DetailsContent.cshtml")]
    public partial class DetailsContent : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_ShiftTime>
    {
        public DetailsContent()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
  
    ViewBag.Title = "View Shift Time";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ShiftTime");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Shift Time";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ShiftTimeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_ShiftTimeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                  ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ShiftTimeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_ShiftTimeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ShiftTimeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.T_ShiftTimeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
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

            
            #line 36 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
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

            
            #line 38 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
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

            
            #line 46 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                     if ( User.CanEdit("T_ShiftTime"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1840), Tuple.Create("\"", 2111)
            
            #line 48 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 1847), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_ShiftTime", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1847), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                     if ( User.CanDelete("T_ShiftTime"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2341), Tuple.Create("\"", 2615)
            
            #line 54 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2348), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_ShiftTime", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2348), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
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

            
            #line 61 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
				
            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                 if ( User.CanAdd("T_Position"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 3016), Tuple.Create("", 3294)
            
            #line 64 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3025), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Position", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_PositionShiftTime", 
							HostingEntityName = "T_ShiftTime",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 3025), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Associated Positions\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 72 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t");

            
            #line 73 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                             if ( User.CanAdd("T_EmployeeInjury"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 3472), Tuple.Create("", 3752)
            
            #line 76 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3481), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_EmployeeInjury", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_AccidentShift", 
							HostingEntityName = "T_ShiftTime",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 3481), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Employee Injury\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 84 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4047), Tuple.Create("\"", 4112)
, Tuple.Create(Tuple.Create("", 4057), Tuple.Create("ClearTabCookie(\'", 4057), true)
            
            #line 95 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4073), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4073), false)
            
            #line 95 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
               , Tuple.Create(Tuple.Create("", 4100), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4100), false)
, Tuple.Create(Tuple.Create("", 4109), Tuple.Create("\');", 4109), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 96 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
         Write(!User.CanView("T_Position")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4215), Tuple.Create("\"", 4497)
, Tuple.Create(Tuple.Create("", 4225), Tuple.Create("LoadTab(\'T_PositionShiftTime\',\'", 4225), true)
            
            #line 96 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                , Tuple.Create(Tuple.Create("", 4256), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4256), false)
            
            #line 96 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                           , Tuple.Create(Tuple.Create("", 4283), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4283), false)
, Tuple.Create(Tuple.Create("", 4292), Tuple.Create("\',\'", 4292), true)
            
            #line 96 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                                       , Tuple.Create(Tuple.Create("", 4295), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_Position", new {RenderPartial=true, HostingEntity ="T_ShiftTime", HostingEntityID = @Model.Id, AssociatedType = "T_PositionShiftTime",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 4295), false)
, Tuple.Create(Tuple.Create("", 4495), Tuple.Create("\')", 4495), true)
);

WriteLiteral(" href=\"#T_PositionShiftTime\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Associated Positions\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_PositionShiftTime\"");

WriteLiteral(">");

            
            #line 98 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                                    Write(ViewBag.T_PositionShiftTimeCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 100 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
         Write(!User.CanView("T_EmployeeInjury")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4775), Tuple.Create("\"", 5055)
, Tuple.Create(Tuple.Create("", 4785), Tuple.Create("LoadTab(\'T_AccidentShift\',\'", 4785), true)
            
            #line 100 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                  , Tuple.Create(Tuple.Create("", 4812), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4812), false)
            
            #line 100 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                             , Tuple.Create(Tuple.Create("", 4839), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4839), false)
, Tuple.Create(Tuple.Create("", 4848), Tuple.Create("\',\'", 4848), true)
            
            #line 100 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                                         , Tuple.Create(Tuple.Create("", 4851), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_EmployeeInjury", new {RenderPartial=true, HostingEntity ="T_ShiftTime", HostingEntityID = @Model.Id, AssociatedType = "T_AccidentShift",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 4851), false)
, Tuple.Create(Tuple.Create("", 5053), Tuple.Create("\')", 5053), true)
);

WriteLiteral(" href=\"#T_AccidentShift\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Employee Injury\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_AccidentShift\"");

WriteLiteral(">");

            
            #line 102 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                                Write(ViewBag.T_AccidentShiftCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 104 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5312), Tuple.Create("\"", 5598)
, Tuple.Create(Tuple.Create("", 5322), Tuple.Create("LoadTab(\'JournalEntryToT_ShiftTimeRelation\',\'", 5322), true)
            
            #line 104 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                , Tuple.Create(Tuple.Create("", 5367), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 5367), false)
            
            #line 104 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                                           , Tuple.Create(Tuple.Create("", 5394), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5394), false)
, Tuple.Create(Tuple.Create("", 5403), Tuple.Create("\',\'", 5403), true)
            
            #line 104 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                                                       , Tuple.Create(Tuple.Create("", 5406), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_ShiftTime", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 5406), false)
, Tuple.Create(Tuple.Create("", 5596), Tuple.Create("\')", 5596), true)
);

WriteLiteral(" href=\"#JournalEntryToT_ShiftTimeRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Shift Time Journal</a></li>\r\n    </ul>\r\n\t    <div");

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

            
            #line 114 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
 if(User.CanView("T_ShiftTime","T_Name"))
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

            
            #line 118 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 122 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                Write(Model.T_Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 127 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
 if(User.CanView("T_ShiftTime","T_Description"))
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

            
            #line 132 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 134 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                        Write(Model.T_Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 138 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 146 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 147 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 147 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                      if ( User.CanEdit("T_ShiftTime"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 149 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 149 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
                                                                                                                                                                                                                                                                                                                                     
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

            
            #line 161 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
			
            
            #line default
            #line hidden
            
            #line 161 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
             if ( User.CanAdd("T_Position"))
            {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t <li>\r\n\t\t\t\t <a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 7971), Tuple.Create("", 8295)
            
            #line 164 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 7980), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Position",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_PositionShiftTime", 
						HostingEntityName = "T_ShiftTime",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 7980), false)
);

WriteLiteral(" style=\"margin-top:5px;\"");

WriteLiteral(">\r\n                   Add  Associated Positions</a>\r\n\t\t\t</li>\r\n");

            
            #line 172 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\r\n\r\n        </ul>\r\n\r\n\t\t\t</div>\r\n\r\n<div");

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

            
            #line 186 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
			
            
            #line default
            #line hidden
            
            #line 186 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
             if ( User.CanAdd("T_EmployeeInjury"))
            {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t <li>\r\n\t\t\t\t <a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 8894), Tuple.Create("", 9220)
            
            #line 189 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 8903), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_EmployeeInjury",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_AccidentShift", 
						HostingEntityName = "T_ShiftTime",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 8903), false)
);

WriteLiteral(" style=\"margin-top:5px;\"");

WriteLiteral(">\r\n                   Add  Employee Injury</a>\r\n\t\t\t</li>\r\n");

            
            #line 197 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\r\n\r\n        </ul>\r\n\r\n\t\t\t</div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_PositionShiftTime\"");

WriteLiteral(">\r\n");

            
            #line 205 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
     
            
            #line default
            #line hidden
            
            #line 205 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
      if ( User.CanView("T_Position"))
	{
	  // Html.RenderAction("Index", "T_Position", new {RenderPartial=true, HostingEntity = "T_ShiftTime", HostingEntityID = @Model.Id, AssociatedType = "T_PositionShiftTime" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_AccidentShift\"");

WriteLiteral(">\r\n");

            
            #line 211 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
     
            
            #line default
            #line hidden
            
            #line 211 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
      if ( User.CanView("T_EmployeeInjury"))
	{
	  // Html.RenderAction("Index", "T_EmployeeInjury", new {RenderPartial=true, HostingEntity = "T_ShiftTime", HostingEntityID = @Model.Id, AssociatedType = "T_AccidentShift" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_ShiftTimeRelation\"");

WriteLiteral(">\r\n");

            
            #line 217 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
            
            
            #line default
            #line hidden
            
            #line 217 "..\..\Views\T_ShiftTime\DetailsContent.cshtml"
             if ( User.CanView("JournalEntry"))
		   {
			//	Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_ShiftTime", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
		   }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
