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

namespace GeneratorBase.MVC.Views.T_Schedule
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
    
    #line 2 "..\..\Views\T_Schedule\DetailsContent.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Schedule/DetailsContent.cshtml")]
    public partial class DetailsContent : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Schedule>
    {
        public DetailsContent()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_Schedule\DetailsContent.cshtml"
  
    ViewBag.Title = "View Schedule";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 8 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 9 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-hand-down text-primary\"");

WriteLiteral("></i> Schedule  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span>View</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral("><span");

WriteLiteral(" id=\"HostingEntityDisplayValue\"");

WriteLiteral(">");

            
            #line 18 "..\..\Views\T_Schedule\DetailsContent.cshtml"
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

            
            #line 26 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                     if ( User.CanEdit("T_Schedule"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1145), Tuple.Create("\"", 1415)
            
            #line 28 "..\..\Views\T_Schedule\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 1152), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_Schedule", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1152), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 29 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 32 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                     if ( User.CanEdit("T_Schedule"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1642), Tuple.Create("\"", 1918)
            
            #line 34 "..\..\Views\T_Schedule\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 1649), Tuple.Create<System.Object, System.Int32>(Url.Action("EditWizard","T_Schedule", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1649), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-share\"");

WriteLiteral("></i>  Wizard</a>\r\n");

            
            #line 35 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t\t\t\t<li>\r\n");

            
            #line 38 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 38 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                     if ( User.CanDelete("T_Schedule"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2137), Tuple.Create("\"", 2410)
            
            #line 40 "..\..\Views\T_Schedule\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2144), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_Schedule", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2144), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 41 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t\t\t</ul>\r\n</div>\r\n\t\t</h2>\r\n    </div>\r\n    <!-- /.col-lg-1" +
"2 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

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

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n\t\t\t\t\t<i");

WriteLiteral(" class=\"icon-calendar\"");

WriteLiteral("></i>\r\n\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t<h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">Basic Details</h3>\r\n\t\t\t\t\t\t\t\t</div>\r\n                                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n");

            
            #line 67 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_Name"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Name\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 71 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 74 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                Write(Model.T_Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 78 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_Description"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Description\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 83 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 85 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                        Write(Model.T_Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 89 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 90 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_AssociatedScheduleTypeID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_AssociatedScheduleTypeID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 96 "..\..\Views\T_Schedule\DetailsContent.cshtml"
		
            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\T_Schedule\DetailsContent.cshtml"
         if (@Model.T_AssociatedScheduleTypeID == 0 || @Model.T_AssociatedScheduleTypeID == null || @Model.t_associatedscheduletype == null)
		{

            
            #line default
            #line hidden
WriteLiteral("\t         <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral("></p>\r\n");

            
            #line 99 "..\..\Views\T_Schedule\DetailsContent.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t     <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 102 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                             Write(Model.t_associatedscheduletype.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 103 "..\..\Views\T_Schedule\DetailsContent.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 107 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 108 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_StartDateTime"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Start Date Time\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 112 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_StartDateTime));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 115 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                Write(String.Format("{0:MM/dd/yyyy hh:mm tt}", Model.T_StartDateTime));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 119 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral(" \r\n\t\t\t</div>\r\n        </div>\r\n\t\t\t<div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n\t\t\t\t\t<i");

WriteLiteral(" class=\"icon-calendar\"");

WriteLiteral("></i>\r\n\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t<h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">Recurrence Detail</h3>\r\n\t\t\t\t\t\t\t\t</div>\r\n                                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n");

            
            #line 130 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_AssociatedRecurringScheduleDetailsTypeID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 134 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_AssociatedRecurringScheduleDetailsTypeID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 136 "..\..\Views\T_Schedule\DetailsContent.cshtml"
		
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_Schedule\DetailsContent.cshtml"
         if (@Model.T_AssociatedRecurringScheduleDetailsTypeID == 0 || @Model.T_AssociatedRecurringScheduleDetailsTypeID == null || @Model.t_associatedrecurringscheduledetailstype == null)
		{

            
            #line default
            #line hidden
WriteLiteral("\t         <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral("></p>\r\n");

            
            #line 139 "..\..\Views\T_Schedule\DetailsContent.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t     <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 142 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                             Write(Model.t_associatedrecurringscheduledetailstype.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 143 "..\..\Views\T_Schedule\DetailsContent.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 147 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 148 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_RecurringRepeatFrequencyID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 152 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_RecurringRepeatFrequencyID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 154 "..\..\Views\T_Schedule\DetailsContent.cshtml"
		
            
            #line default
            #line hidden
            
            #line 154 "..\..\Views\T_Schedule\DetailsContent.cshtml"
         if (@Model.T_RecurringRepeatFrequencyID == 0 || @Model.T_RecurringRepeatFrequencyID == null || @Model.t_recurringrepeatfrequency == null)
		{

            
            #line default
            #line hidden
WriteLiteral("\t         <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral("></p>\r\n");

            
            #line 157 "..\..\Views\T_Schedule\DetailsContent.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t     <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 160 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                             Write(Model.t_recurringrepeatfrequency.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 161 "..\..\Views\T_Schedule\DetailsContent.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 165 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 166 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_RepeatByID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 170 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_RepeatByID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 172 "..\..\Views\T_Schedule\DetailsContent.cshtml"
		
            
            #line default
            #line hidden
            
            #line 172 "..\..\Views\T_Schedule\DetailsContent.cshtml"
         if (@Model.T_RepeatByID == 0 || @Model.T_RepeatByID == null || @Model.t_repeatby == null)
		{

            
            #line default
            #line hidden
WriteLiteral("\t         <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral("></p>\r\n");

            
            #line 175 "..\..\Views\T_Schedule\DetailsContent.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t     <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 178 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                             Write(Model.t_repeatby.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 179 "..\..\Views\T_Schedule\DetailsContent.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 183 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 184 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_RecurringTaskEndTypeID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 188 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_RecurringTaskEndTypeID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 190 "..\..\Views\T_Schedule\DetailsContent.cshtml"
		
            
            #line default
            #line hidden
            
            #line 190 "..\..\Views\T_Schedule\DetailsContent.cshtml"
         if (@Model.T_RecurringTaskEndTypeID == 0 || @Model.T_RecurringTaskEndTypeID == null || @Model.t_recurringtaskendtype == null)
		{

            
            #line default
            #line hidden
WriteLiteral("\t         <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral("></p>\r\n");

            
            #line 193 "..\..\Views\T_Schedule\DetailsContent.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t     <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 196 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                             Write(Model.t_recurringtaskendtype.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 197 "..\..\Views\T_Schedule\DetailsContent.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 201 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 202 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_EndDate"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"End Date\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 206 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_EndDate));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 209 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                Write(String.Format("{0:MM/dd/yyyy}", Model.T_EndDate));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 213 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 214 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_OccurrenceLimitCount"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Occurrence Limit Count\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 218 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_OccurrenceLimitCount));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 221 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                Write(Model.T_OccurrenceLimitCount);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 225 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 226 "..\..\Views\T_Schedule\DetailsContent.cshtml"
 if(User.CanView("T_Schedule","T_Summary"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Summary\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 230 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_Summary));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 232 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                        Write(Model.T_Summary);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 236 "..\..\Views\T_Schedule\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral(" \r\n\t\t\t</div>\r\n        </div>\r\n\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-sm-12 col-md-12 col-sx-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(" style=\"margin:0px; padding:8px;\"");

WriteLiteral(">\r\n                                    Recurrence Days\r\n                         " +
"       </div>\r\n                                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(" style=\"margin:0px; padding:8px;\"");

WriteLiteral(">\r\n");

            
            #line 247 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 247 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                     foreach (var chkitem in Model.T_RecurrenceDays_T_RepeatOn)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" disabled");

WriteLiteral(" name=\"SelectedT_RecurrenceDays_T_RepeatOn\"");

WriteAttribute("value", Tuple.Create(" value=\"", 9932), Tuple.Create("\"", 9951)
            
            #line 249 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                          , Tuple.Create(Tuple.Create("", 9940), Tuple.Create<System.Object, System.Int32>(chkitem.Id
            
            #line default
            #line hidden
, 9940), false)
);

WriteLiteral(" ");

            
            #line 249 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                                                                                                                   Write(Model.SelectedT_RecurrenceDays_T_RepeatOn.Contains(chkitem.Id) ? "checked" : "");

            
            #line default
            #line hidden
WriteLiteral(" /> ");

            
            #line 249 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                                                                                                                                                                                                             
            
            #line default
            #line hidden
            
            #line 249 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                                                                                                                                                                                                        Write(chkitem.DisplayValue);

            
            #line default
            #line hidden
            
            #line 249 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                                                                                                                                                                                                                                  
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </div>\r\n                            </div>\r\n     " +
"                   </div>\r\n                    </div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t" +
"</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 261 "..\..\Views\T_Schedule\DetailsContent.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 262 "..\..\Views\T_Schedule\DetailsContent.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 262 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                      if ( User.CanEdit("T_Schedule"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 264 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm" }));

            
            #line default
            #line hidden
            
            #line 264 "..\..\Views\T_Schedule\DetailsContent.cshtml"
                                                                                                                                                                                                                                                                                                             
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>    \r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"T_RepeatOn_T_Schedule\"");

WriteLiteral(">\r\n   </div>\r\n\t</div> <!-- /tab-content --><br />\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
