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
    
    #line 2 "..\..\Views\T_ShiftTime\Details.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ShiftTime/Details.cshtml")]
    public partial class Details : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_ShiftTime>
    {
        public Details()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_ShiftTime\Details.cshtml"
  
    ViewBag.Title = "View Shift Time";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ShiftTime");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Shift Time";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_ShiftTime\Details.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_ShiftTime\Details.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_ShiftTime\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ShiftTimeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_ShiftTime\Details.cshtml"
   Write(Html.Raw(ViewBag.T_ShiftTimeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                  ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_ShiftTime\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ShiftTimeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_ShiftTime\Details.cshtml"
   Write(Html.Raw(ViewBag.T_ShiftTimeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_ShiftTime\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ShiftTimeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_ShiftTime\Details.cshtml"
   Write(Html.Raw(ViewBag.T_ShiftTimeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_ShiftTime\Details.cshtml"
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

            
            #line 36 "..\..\Views\T_ShiftTime\Details.cshtml"
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

            
            #line 38 "..\..\Views\T_ShiftTime\Details.cshtml"
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

            
            #line 46 "..\..\Views\T_ShiftTime\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_ShiftTime\Details.cshtml"
                     if ( User.CanEdit("T_ShiftTime"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1823), Tuple.Create("\"", 2098)
            
            #line 48 "..\..\Views\T_ShiftTime\Details.cshtml"
, Tuple.Create(Tuple.Create("", 1830), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_ShiftTime", new {UrlReferrer = Request.UrlReferrer,id = Model.Id,AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1830), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_ShiftTime\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_ShiftTime\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_ShiftTime\Details.cshtml"
                     if ( User.CanDelete("T_ShiftTime"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2328), Tuple.Create("\"", 2609)
            
            #line 54 "..\..\Views\T_ShiftTime\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2335), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_ShiftTime", new { UrlReferrer = Request.UrlReferrer,id = Model.Id, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2335), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_ShiftTime\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t<li");

WriteLiteral(" class=\"divider\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></li>\r\n\t<li");

WriteLiteral(" class=\"dropdown-submenu pull-left\"");

WriteLiteral(" id=\"AddAssociationdropmenuT_ShiftTime\"");

WriteLiteral(">\r\n");

            
            #line 59 "..\..\Views\T_ShiftTime\Details.cshtml"
	 
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\T_ShiftTime\Details.cshtml"
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

            
            #line 62 "..\..\Views\T_ShiftTime\Details.cshtml"
				
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\T_ShiftTime\Details.cshtml"
                 if ( User.CanAdd("T_Position"))
				{ dropmenu = true;

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 3096), Tuple.Create("", 3374)
            
            #line 65 "..\..\Views\T_ShiftTime\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3105), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Position", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_PositionShiftTime", 
							HostingEntityName = "T_ShiftTime",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 3105), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Associated Positions\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 73 "..\..\Views\T_ShiftTime\Details.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t");

            
            #line 74 "..\..\Views\T_ShiftTime\Details.cshtml"
                             if ( User.CanAdd("T_EmployeeInjury"))
				{ dropmenu = true;

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 3569), Tuple.Create("", 3849)
            
            #line 77 "..\..\Views\T_ShiftTime\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3578), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_EmployeeInjury", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_AccidentShift", 
							HostingEntityName = "T_ShiftTime",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 3578), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Employee Injury\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 85 "..\..\Views\T_ShiftTime\Details.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</ul>\r\n</li>\r\n");

            
            #line 88 "..\..\Views\T_ShiftTime\Details.cshtml"
 if(!dropmenu)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenuT_ShiftTime\").hide();\r\n    </scri" +
"pt>\r\n");

            
            #line 93 "..\..\Views\T_ShiftTime\Details.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4248), Tuple.Create("\"", 4313)
, Tuple.Create(Tuple.Create("", 4258), Tuple.Create("ClearTabCookie(\'", 4258), true)
            
            #line 103 "..\..\Views\T_ShiftTime\Details.cshtml"
, Tuple.Create(Tuple.Create("", 4274), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4274), false)
            
            #line 103 "..\..\Views\T_ShiftTime\Details.cshtml"
               , Tuple.Create(Tuple.Create("", 4301), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4301), false)
, Tuple.Create(Tuple.Create("", 4310), Tuple.Create("\');", 4310), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 104 "..\..\Views\T_ShiftTime\Details.cshtml"
         Write(!User.CanView("T_Position") ?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4417), Tuple.Create("\"", 4699)
, Tuple.Create(Tuple.Create("", 4427), Tuple.Create("LoadTab(\'T_PositionShiftTime\',\'", 4427), true)
            
            #line 104 "..\..\Views\T_ShiftTime\Details.cshtml"
                                 , Tuple.Create(Tuple.Create("", 4458), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4458), false)
            
            #line 104 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                            , Tuple.Create(Tuple.Create("", 4485), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4485), false)
, Tuple.Create(Tuple.Create("", 4494), Tuple.Create("\',\'", 4494), true)
            
            #line 104 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                                        , Tuple.Create(Tuple.Create("", 4497), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_Position", new {RenderPartial=true, HostingEntity ="T_ShiftTime", HostingEntityID = @Model.Id, AssociatedType = "T_PositionShiftTime",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 4497), false)
, Tuple.Create(Tuple.Create("", 4697), Tuple.Create("\')", 4697), true)
);

WriteLiteral(" href=\"#T_PositionShiftTime\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Associated Positions\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_PositionShiftTime\"");

WriteLiteral(">");

            
            #line 106 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                                    Write(ViewBag.T_PositionShiftTimeCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 108 "..\..\Views\T_ShiftTime\Details.cshtml"
         Write(!User.CanView("T_EmployeeInjury") ?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4978), Tuple.Create("\"", 5258)
, Tuple.Create(Tuple.Create("", 4988), Tuple.Create("LoadTab(\'T_AccidentShift\',\'", 4988), true)
            
            #line 108 "..\..\Views\T_ShiftTime\Details.cshtml"
                                   , Tuple.Create(Tuple.Create("", 5015), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 5015), false)
            
            #line 108 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                              , Tuple.Create(Tuple.Create("", 5042), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5042), false)
, Tuple.Create(Tuple.Create("", 5051), Tuple.Create("\',\'", 5051), true)
            
            #line 108 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                                          , Tuple.Create(Tuple.Create("", 5054), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_EmployeeInjury", new {RenderPartial=true, HostingEntity ="T_ShiftTime", HostingEntityID = @Model.Id, AssociatedType = "T_AccidentShift",TabToken = DateTime.Now.Ticks,}))
            
            #line default
            #line hidden
, 5054), false)
, Tuple.Create(Tuple.Create("", 5256), Tuple.Create("\')", 5256), true)
);

WriteLiteral(" href=\"#T_AccidentShift\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Employee Injury\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_T_AccidentShift\"");

WriteLiteral(">");

            
            #line 110 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                                Write(ViewBag.T_AccidentShiftCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 112 "..\..\Views\T_ShiftTime\Details.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5515), Tuple.Create("\"", 5801)
, Tuple.Create(Tuple.Create("", 5525), Tuple.Create("LoadTab(\'JournalEntryToT_ShiftTimeRelation\',\'", 5525), true)
            
            #line 112 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                , Tuple.Create(Tuple.Create("", 5570), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 5570), false)
            
            #line 112 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                                           , Tuple.Create(Tuple.Create("", 5597), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5597), false)
, Tuple.Create(Tuple.Create("", 5606), Tuple.Create("\',\'", 5606), true)
            
            #line 112 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                                                       , Tuple.Create(Tuple.Create("", 5609), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_ShiftTime", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 5609), false)
, Tuple.Create(Tuple.Create("", 5799), Tuple.Create("\')", 5799), true)
);

WriteLiteral(" href=\"#JournalEntryToT_ShiftTimeRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Shift Time Journal</a></li>\r\n    </ul>\r\n");

WriteLiteral("\t  ");

            
            #line 114 "..\..\Views\T_ShiftTime\Details.cshtml"
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

            
            #line 122 "..\..\Views\T_ShiftTime\Details.cshtml"
 if(User.CanView("T_ShiftTime","T_Name"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 6300), Tuple.Create("\"", 6321)
            
            #line 125 "..\..\Views\T_ShiftTime\Details.cshtml"
, Tuple.Create(Tuple.Create("", 6308), Tuple.Create<System.Object, System.Int32>(Model.T_Name
            
            #line default
            #line hidden
, 6308), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 126 "..\..\Views\T_ShiftTime\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" id=\"lblT_Name\"");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 130 "..\..\Views\T_ShiftTime\Details.cshtml"
                                               Write(Model.T_Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 135 "..\..\Views\T_ShiftTime\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_ShiftTime\Details.cshtml"
 if(User.CanView("T_ShiftTime","T_Description"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 6731), Tuple.Create("\"", 6759)
            
            #line 139 "..\..\Views\T_ShiftTime\Details.cshtml"
, Tuple.Create(Tuple.Create("", 6739), Tuple.Create<System.Object, System.Int32>(Model.T_Description
            
            #line default
            #line hidden
, 6739), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 140 "..\..\Views\T_ShiftTime\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabelmultiline\"");

WriteLiteral(">");

            
            #line 142 "..\..\Views\T_ShiftTime\Details.cshtml"
                                 Write(Model.T_Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 146 "..\..\Views\T_ShiftTime\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm pull-left formbuttonfix\"");

WriteAttribute("Onclick", Tuple.Create(" Onclick=\"", 7183), Tuple.Create("\"", 7238)
, Tuple.Create(Tuple.Create("", 7193), Tuple.Create("goBack(\'", 7193), true)
            
            #line 153 "..\..\Views\T_ShiftTime\Details.cshtml"
           , Tuple.Create(Tuple.Create("", 7201), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_ShiftTime")
            
            #line default
            #line hidden
, 7201), false)
, Tuple.Create(Tuple.Create("", 7235), Tuple.Create("\');", 7235), true)
);

WriteLiteral(">Back</a>\r\n\t\t\t\t");

WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 156 "..\..\Views\T_ShiftTime\Details.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_ShiftTime\Details.cshtml"
                      if ( User.CanEdit("T_ShiftTime"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 158 "..\..\Views\T_ShiftTime\Details.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { UrlReferrer = Request.UrlReferrer, id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 158 "..\..\Views\T_ShiftTime\Details.cshtml"
                                                                                                                                                                                                                                                                                                                                                                        
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   \r\n");

            
            #line 161 "..\..\Views\T_ShiftTime\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 161 "..\..\Views\T_ShiftTime\Details.cshtml"
    var dropmenubottom = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dropdown pull-left formbuttonfix\"");

WriteLiteral(" style=\"\"");

WriteLiteral(" id=\"AddAssociationdropmenubottomT_ShiftTime\"");

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

            
            #line 168 "..\..\Views\T_ShiftTime\Details.cshtml"
			
            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\T_ShiftTime\Details.cshtml"
             if (User.CanAdd("T_Position"))
            {
			    dropmenubottom = true;

            
            #line default
            #line hidden
WriteLiteral("                <li><a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 8390), Tuple.Create("", 8714)
            
            #line 171 "..\..\Views\T_ShiftTime\Details.cshtml"
, Tuple.Create(Tuple.Create("", 8399), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_Position",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_PositionShiftTime", 
						HostingEntityName = "T_ShiftTime",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 8399), false)
);

WriteLiteral(">\r\n                   Add  Associated Positions\r\n                </a>\r\n\t\t\t\t</li>\r" +
"\n");

            
            #line 180 "..\..\Views\T_ShiftTime\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\r\n");

            
            #line 183 "..\..\Views\T_ShiftTime\Details.cshtml"
			
            
            #line default
            #line hidden
            
            #line 183 "..\..\Views\T_ShiftTime\Details.cshtml"
             if (User.CanAdd("T_EmployeeInjury"))
            {
			    dropmenubottom = true;

            
            #line default
            #line hidden
WriteLiteral("                <li><a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 8928), Tuple.Create("", 9254)
            
            #line 186 "..\..\Views\T_ShiftTime\Details.cshtml"
, Tuple.Create(Tuple.Create("", 8937), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "T_EmployeeInjury",
						new { UrlReferrer = Request.Url,
								AssociatedType ="T_AccidentShift", 
						HostingEntityName = "T_ShiftTime",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 8937), false)
);

WriteLiteral(">\r\n                   Add  Employee Injury\r\n                </a>\r\n\t\t\t\t</li>\r\n");

            
            #line 195 "..\..\Views\T_ShiftTime\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\r\n</ul>\r\n</div>\r\n");

            
            #line 200 "..\..\Views\T_ShiftTime\Details.cshtml"
 if(!dropmenubottom)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenubottomT_ShiftTime\").hide();\r\n    " +
"</script>\r\n");

            
            #line 205 "..\..\Views\T_ShiftTime\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</div> \r\n\t\t\t</div><div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_PositionShiftTime\"");

WriteLiteral(">\r\n");

            
            #line 210 "..\..\Views\T_ShiftTime\Details.cshtml"
     
            
            #line default
            #line hidden
            
            #line 210 "..\..\Views\T_ShiftTime\Details.cshtml"
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

            
            #line 216 "..\..\Views\T_ShiftTime\Details.cshtml"
     
            
            #line default
            #line hidden
            
            #line 216 "..\..\Views\T_ShiftTime\Details.cshtml"
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

            
            #line 222 "..\..\Views\T_ShiftTime\Details.cshtml"
            
            
            #line default
            #line hidden
            
            #line 222 "..\..\Views\T_ShiftTime\Details.cshtml"
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
