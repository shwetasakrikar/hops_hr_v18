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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Schedule/Delete.cshtml")]
    public partial class Delete : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Schedule>
    {
        public Delete()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Schedule\Delete.cshtml"
  
    ViewBag.Title = "Delete Schedule";

            
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

WriteLiteral("></i>Delete Schedule  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> \r\n            <span");

WriteLiteral(" style=\"color:red;\"");

WriteLiteral(">  Are you sure you want to delete this?</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\T_Schedule\Delete.cshtml"
                            Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n<label");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" class=\"text-primary small\"");

WriteLiteral(" style=\"color:red; vertical-align:middle; font-weight:100;\"");

WriteLiteral("></label>\r\n");

            
            #line 16 "..\..\Views\T_Schedule\Delete.cshtml"
 using (Html.BeginForm())
{
    
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_Schedule\Delete.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_Schedule\Delete.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\T_Schedule\Delete.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\T_Schedule\Delete.cshtml"
                                                  
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\T_Schedule\Delete.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\T_Schedule\Delete.cshtml"
                                      
                                  

            
            #line default
            #line hidden
WriteLiteral("    <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n\t\t  <dt>\t\t   \r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 28 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.HiddenFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t <dt>\r\n");

WriteLiteral("            ");

            
            #line 31 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_AssociatedRecurringScheduleDetailsTypeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 34 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.t_associatedrecurringscheduledetailstype.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t ");

            
            #line 35 "..\..\Views\T_Schedule\Delete.cshtml"
        Write(Html.HiddenFor(model => model.T_AssociatedRecurringScheduleDetailsTypeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t  <dt>\t\t   \r\n");

WriteLiteral("            ");

            
            #line 38 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 41 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 42 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.HiddenFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t <dt>\r\n");

WriteLiteral("            ");

            
            #line 45 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_RecurringRepeatFrequencyID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 48 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.t_recurringrepeatfrequency.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t ");

            
            #line 49 "..\..\Views\T_Schedule\Delete.cshtml"
        Write(Html.HiddenFor(model => model.T_RecurringRepeatFrequencyID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t <dt>\r\n");

WriteLiteral("            ");

            
            #line 52 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_AssociatedScheduleTypeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 55 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.t_associatedscheduletype.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t ");

            
            #line 56 "..\..\Views\T_Schedule\Delete.cshtml"
        Write(Html.HiddenFor(model => model.T_AssociatedScheduleTypeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t <dt>\r\n");

WriteLiteral("            ");

            
            #line 59 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_RepeatByID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 62 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.t_repeatby.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t ");

            
            #line 63 "..\..\Views\T_Schedule\Delete.cshtml"
        Write(Html.HiddenFor(model => model.T_RepeatByID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t  <dt>\t\t   \r\n");

WriteLiteral("            ");

            
            #line 66 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_StartDateTime));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 69 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.T_StartDateTime));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 70 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.HiddenFor(model => model.T_StartDateTime));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t <dt>\r\n");

WriteLiteral("            ");

            
            #line 73 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_RecurringTaskEndTypeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 76 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.t_recurringtaskendtype.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t ");

            
            #line 77 "..\..\Views\T_Schedule\Delete.cshtml"
        Write(Html.HiddenFor(model => model.T_RecurringTaskEndTypeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t  <dt>\t\t   \r\n");

WriteLiteral("            ");

            
            #line 80 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_EndDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 83 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.T_EndDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 84 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.HiddenFor(model => model.T_EndDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t  <dt>\t\t   \r\n");

WriteLiteral("            ");

            
            #line 87 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_OccurrenceLimitCount));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 90 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.T_OccurrenceLimitCount));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 91 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.HiddenFor(model => model.T_OccurrenceLimitCount));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\t\t  <dt>\t\t   \r\n");

WriteLiteral("            ");

            
            #line 94 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.T_Summary));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\t\t<dd");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 97 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.DisplayFor(model => model.T_Summary));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 98 "..\..\Views\T_Schedule\Delete.cshtml"
       Write(Html.HiddenFor(model => model.T_Summary));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");

WriteLiteral("\t<br/>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"row deletefix\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 104 "..\..\Views\T_Schedule\Delete.cshtml"
   Write(Html.ActionLink("Back", "Index", null, new { @class = "btn btn-default btn-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n \r\n");

            
            #line 106 "..\..\Views\T_Schedule\Delete.cshtml"
	
            
            #line default
            #line hidden
            
            #line 106 "..\..\Views\T_Schedule\Delete.cshtml"
     if ( User.CanDelete("T_Schedule"))
     {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Delete\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" /> \r\n");

            
            #line 109 "..\..\Views\T_Schedule\Delete.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n            </div>\r\n");

            
            #line 112 "..\..\Views\T_Schedule\Delete.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591
