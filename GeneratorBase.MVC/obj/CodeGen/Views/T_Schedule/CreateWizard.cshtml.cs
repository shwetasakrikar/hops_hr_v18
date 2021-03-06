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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Schedule/CreateWizard.cshtml")]
    public partial class CreateWizard : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Schedule>
    {
        public CreateWizard()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Schedule\CreateWizard.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ScheduleIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\T_Schedule\CreateWizard.cshtml"
   Write(Html.Raw(ViewBag.T_ScheduleIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 8 "..\..\Views\T_Schedule\CreateWizard.cshtml"
 using (Html.BeginForm("CreateWizard", "T_Schedule",new {UrlReferrer = Convert.ToString(ViewData["T_ScheduleParentUrl"])}, FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_Schedule\CreateWizard.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<label");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" class=\"text-primary small pull-right\"");

WriteLiteral(" style=\"color:red; vertical-align:middle; font-weight:100;\"");

WriteLiteral("></label>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t<br/>\r\n\t<div id = \"wizard\">\r\n\t<ol>\r\n\t\t<li>Basic Details</li>\r\n\t\t<li>Recurrenc" +
"e Detail</li>\r\n\t\r\n\t</ol>\r\n\t\t\t<div>\r\n               <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">         \r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n                                            <i");

WriteLiteral(" class=\"icon-calendar\"");

WriteLiteral("></i>\r\n                                            <h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">Basic Details</h3>\r\n                                        </div>\r\n            " +
"                            <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Name\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 33 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 36 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 37 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t\t<di" +
"v");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Description\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 43 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 45 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 46 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<" +
"div");

WriteLiteral(" class=\'col-sm-6 col-md-6  col-xs-12\'");

WriteLiteral(" id=\"dvT_AssociatedScheduleTypeID\"");

WriteLiteral(" style=\"min-height:35px;\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 51 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_AssociatedScheduleTypeID));

            
            #line default
            #line hidden
WriteLiteral("  <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group radiocontainer\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t\t");

            
            #line 54 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                   Write(Html.RadioButtonListFor(model => model.T_AssociatedScheduleTypeID, (SelectList)ViewBag.T_AssociatedScheduleTypeID, new {  @required ="required",    @dataurl = Url.Action("GetAllValueForRB", "T_Scheduletype",new { caller = "T_AssociatedScheduleTypeID" })}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t\t");

            
            #line 55 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.T_AssociatedScheduleTypeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n                            <d" +
"iv");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_StartDateTime\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 60 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                       Write(Html.LabelFor(model => model.T_StartDateTime));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n                                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(" title=\"Start Date Time\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_StartDateTime\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 64 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                   Write(Html.TextBoxFor(model => model.T_StartDateTime, new {@class = "form-control",@Value = DateTime.Now.ToString("MM/dd/yyyy hh:ss tt") }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        <span");

WriteLiteral(" class=\"input-group-addon btn-default calendar\"");

WriteLiteral(">\r\n                                           <i");

WriteLiteral(" class=\"fa fa-calendar\"");

WriteLiteral("></i>\r\n                                        </span>\r\n                         " +
"           </div>\r\n");

WriteLiteral("                                    ");

            
            #line 69 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_StartDateTime));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n                       " +
"         <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
                                    $(function () {
                                        $('#datetimepickerT_StartDateTime').datetimepicker();
										$('#T_StartDateTime').datetimepicker();
                                    });
                                </script>
                            </div>
							</div>
                         </div>
                      </div>
				  </div>
       </div>
			<div>
               <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">         \r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n                                            <i");

WriteLiteral(" class=\"icon-calendar\"");

WriteLiteral("></i>\r\n                                            <h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">Recurrence Detail</h3>\r\n                                        </div>\r\n        " +
"                                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6  col-xs-12\'");

WriteLiteral(" id=\"dvT_AssociatedRecurringScheduleDetailsTypeID\"");

WriteLiteral(" style=\"min-height:35px;\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_AssociatedRecurringScheduleDetailsTypeID));

            
            #line default
            #line hidden
WriteLiteral("  </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group radiocontainer\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t\t");

            
            #line 97 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                   Write(Html.RadioButtonListFor(model => model.T_AssociatedRecurringScheduleDetailsTypeID, (SelectList)ViewBag.T_AssociatedRecurringScheduleDetailsTypeID, new {    @dataurl = Url.Action("GetAllValueForRB", "T_RecurringScheduleDetailstype",new { caller = "T_AssociatedRecurringScheduleDetailsTypeID" })}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t\t");

            
            #line 98 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.T_AssociatedRecurringScheduleDetailsTypeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_RecurringRepeatFrequency\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 104 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                  Write(Html.LabelFor(model => model.T_RecurringRepeatFrequencyID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 107 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.DropDownList("T_RecurringRepeatFrequencyID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_RecurringFrequency", @dataurl = Url.Action("GetAllValue", "T_RecurringFrequency",new { caller = "T_RecurringRepeatFrequencyID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 108 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_RecurringRepeatFrequencyID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 109 "..\..\Views\T_Schedule\CreateWizard.cshtml"
								
            
            #line default
            #line hidden
            
            #line 109 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                 if ( User.CanAdd("T_RecurringFrequency"))
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                <div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn ie8fix\"");

WriteLiteral("  data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7309), Tuple.Create("\"", 7626)
            
            #line 112 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                           , Tuple.Create(Tuple.Create("", 7319), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Repeat Every','dvPopup','" + Url.Action("CreateQuick", "T_RecurringFrequency", new { UrlReferrer = Request.Url, HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]), IsAddPop=true }) + "')")
            
            #line default
            #line hidden
, 7319), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-plus-sign\"");

WriteLiteral("></span>\r\n                                    </a>\r\n                             " +
"   </div>\r\n");

            
            #line 116 "..\..\Views\T_Schedule\CreateWizard.cshtml"
								}

            
            #line default
            #line hidden
WriteLiteral("                            </div>\r\n\t\t\t\t\t\t\t</div>\r\n                        </div>" +
"\r\n                    </div>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6  col-xs-12\'");

WriteLiteral(" id=\"dvT_RepeatByID\"");

WriteLiteral(" style=\"min-height:35px;\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 122 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_RepeatByID));

            
            #line default
            #line hidden
WriteLiteral("  </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group radiocontainer\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t\t");

            
            #line 125 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                   Write(Html.RadioButtonListFor(model => model.T_RepeatByID, (SelectList)ViewBag.T_RepeatByID, new {    @dataurl = Url.Action("GetAllValueForRB", "T_MonthlyRepeatType",new { caller = "T_RepeatByID" })}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t\t");

            
            #line 126 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.T_RepeatByID));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6  col-xs-12\'");

WriteLiteral(" id=\"dvT_RecurringTaskEndTypeID\"");

WriteLiteral(" style=\"min-height:35px;\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 131 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_RecurringTaskEndTypeID));

            
            #line default
            #line hidden
WriteLiteral("  </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group radiocontainer\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t\t");

            
            #line 134 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                   Write(Html.RadioButtonListFor(model => model.T_RecurringTaskEndTypeID, (SelectList)ViewBag.T_RecurringTaskEndTypeID, new {    @dataurl = Url.Action("GetAllValueForRB", "T_RecurringEndType",new { caller = "T_RecurringTaskEndTypeID" })}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t\t");

            
            #line 135 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.T_RecurringTaskEndTypeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n                            <d" +
"iv");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_EndDate\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 140 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                       Write(Html.LabelFor(model => model.T_EndDate));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(" title=\"End Date\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_EndDate\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 144 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                   Write(Html.TextBoxFor(model => model.T_EndDate, new {@class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        <span");

WriteLiteral(" class=\"input-group-addon btn-default calendar\"");

WriteLiteral(">\r\n                                           <i");

WriteLiteral(" class=\"fa fa-calendar\"");

WriteLiteral("></i>\r\n                                        </span>\r\n                         " +
"           </div>\r\n");

WriteLiteral("                                    ");

            
            #line 149 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_EndDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n                       " +
"         <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
                                    $(function () {
                                        $('#datetimepickerT_EndDate').datetimepicker({ pickTime:false });
										$('#T_EndDate').datetimepicker({ pickTime:false });
                                    });
                                </script>
                            </div>
					<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_OccurrenceLimitCount\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Occurrence Limit Count\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 161 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_OccurrenceLimitCount));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 164 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.TextBoxFor(model => model.T_OccurrenceLimitCount, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 165 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_OccurrenceLimitCount));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t\t<di" +
"v");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Summary\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Summary\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 171 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_Summary));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 173 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Summary, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 174 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Summary));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<" +
"/div>\r\n                         </div>\r\n                      </div>\r\n\t\t\t\t  </di" +
"v>\r\n       </div>\r\n\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-sm-12 col-md-12 col-sx-12\"");

WriteLiteral(" id=\"dvT_Schedule\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(" style=\"margin:0px; padding:8px;\"");

WriteLiteral(">\r\n                                    Recurrence Days\r\n                         " +
"       </div>\r\n\t\t\t\t\t\t\t\t <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t ");

            
            #line 190 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                                Write(Html.DropDownList("SelectedT_RecurrenceDays_T_RepeatOn", null, new { @multiple = "multiple", @HostingName = "T_RecurrenceDays", @dataurl = Url.Action("GetAllMultiSelectValue", "T_RecurrenceDays", null) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n                    </div>\r\n             </div>\r\n" +
"\t\t\t <script>\r\n\t\t\t$(document).ready(function () {\r\n\t\t\t \t $(\'#SelectedT_Recurrence" +
"Days_T_RepeatOn\').multiselect({ buttonWidth: \'100%\'});\r\n\t\t\t});\r\n\t\t</script>\r\n\t</" +
"div>\r\n");

WriteLiteral("          ");

            
            #line 201 "..\..\Views\T_Schedule\CreateWizard.cshtml"
     Write(Html.ActionLink("C", "Cancel", new { UrlReferrer = ViewData["T_ScheduleParentUrl"] }, new { @id="cancel",@style="display:none;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t</div>\r\n");

WriteLiteral("\t\t\t<br/>\r\n");

            
            #line 204 "..\..\Views\T_Schedule\CreateWizard.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral(@"	<script>
    $(function () {
        var userAgent = navigator.userAgent.toLowerCase();
        // Figure out what browser is being used
        var browser = {
            version: (userAgent.match(/.+(?:rv|it|ra|ie)[\/: ]([\d.]+)/) || [])[1],
            safari: /webkit/.test(userAgent),
            opera: /opera/.test(userAgent),
            msie: /msie/.test(userAgent) && !/opera/.test(userAgent),
            mozilla: /mozilla/.test(userAgent) && !/(compatible|webkit)/.test(userAgent)
        };
        if (!browser.msie) {
            $('form').areYouSure();
        }
        else if (browser.version > 8.0) {
            $('form').areYouSure();
        }
    });
</script>
");

            
            #line 224 "..\..\Views\T_Schedule\CreateWizard.cshtml"
  
    var busineesrule = User.businessrules.Where(p => p.EntityName == "T_Schedule").ToList();
    if ((busineesrule != null && busineesrule.Count > 0))
    {

            
            #line default
            #line hidden
WriteLiteral("        <script>\r\n            $(\"form\").submit(function () {\r\n                   " +
" var flag = true;\r\n                    $.ajax({\r\n                        async: " +
"false,\r\n                        type: \"GET\",\r\n                        url: \"");

            
            #line 234 "..\..\Views\T_Schedule\CreateWizard.cshtml"
                         Write(Url.Action("GetMandatoryProperties", "T_Schedule"));

            
            #line default
            #line hidden
WriteLiteral("\",\r\n                        data: $(this).serialize(),\r\n                         " +
"success: function (data) {\r\n                        $(\'[businessrule=\"mandatory\"" +
"]\').each(function () {\r\n                            $(this).removeAttr(\'required" +
"\');\r\n                        });\r\n                        document.getElementByI" +
"d(\'ErrMsg\').innerHTML = \"\";\r\n                        for (var key in data) {\r\n  " +
"                          if ($.trim($(\'#\' + key).val()).length == 0 && $.trim($" +
"(\"input[type=\'radio\'][name=\'\" + key + \"\']:checked\").val()).length == 0)\r\n       " +
"                     {\r\n                                $(\'#\' + key).attr(\'requi" +
"red\', \'required\');\r\n                                $(\'#\' + key).attr(\'businessr" +
"ule\', \'mandatory\');\r\n                                $(\"input[type=\'radio\'][name" +
"=\'\" + key + \"\']\").attr(\'required\', \'required\');\r\n                               " +
" $(\"input[type=\'radio\'][name=\'\" + key + \"\']\").attr(\'businessrule\', \'mandatory\');" +
"\r\n                                flag = false;\r\n                               " +
" document.getElementById(\'ErrMsg\').innerHTML += data[key] + \" is Mandatory.<br/>" +
"\";\r\n                            }\r\n                        }\r\n                  " +
"  },\r\n                        error: function (jqXHR, textStatus, errorThrown) {" +
"\r\n                            alert(JSON.stringify(jqXHR));\r\n                   " +
"         alert(errorThrown);\r\n                        }\r\n                    });" +
"\r\n                    return flag;\r\n            });\r\n        </script>\r\n");

            
            #line 261 "..\..\Views\T_Schedule\CreateWizard.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
