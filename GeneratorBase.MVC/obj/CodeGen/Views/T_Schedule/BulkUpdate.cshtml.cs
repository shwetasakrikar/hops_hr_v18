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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Schedule/BulkUpdate.cshtml")]
    public partial class BulkUpdate : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Schedule>
    {
        public BulkUpdate()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
  
 ViewBag.Title = "Bulk Update Schedule";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral(@"';
                 $('#' + hostingEntityName + 'ID').attr(""lock"",""true"");
            }
        }
        catch (ex) { }
    });
</script>
<script>
    $(document).ready(function () {
        $('.form-control:input').change(function () {
            var $this = $(this);
            $(""input[type=checkbox][value="" + $this.attr('id') + ""]"").prop(""checked"", $this.val() != '' ? true : false);

            var ChildDDids = $this.attr('ChildDDids');
            if (ChildDDids != undefined) {
                var ids = ChildDDids.split("","");
                for (var i = 0; i < ids.length; i++) {
                    $(""input[type=checkbox][value="" + ids[i] + ""]"").prop(""checked"", $this.val() != '' ? true : false);
                }
               
            }
        })
    });
</script>
<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1195), Tuple.Create("\"", 1244)
, Tuple.Create(Tuple.Create("", 1202), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1202), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1272), Tuple.Create("\"", 1315)
            
            #line 36 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
, Tuple.Create(Tuple.Create("", 1279), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1279), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 37 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
 using (Html.BeginForm("BulkUpdate", "T_Schedule", new { UrlReferrer = Convert.ToString(ViewData["T_ScheduleParentUrl"]), IsDDAdd = ViewBag.IsDDAdd }, FormMethod.Post, new { enctype = "multipart/form-data" }))
{
   
            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
                           ;
   
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
Write(Html.Hidden("BulkUpdate", (object)ViewBag.BulkUpdate));

            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
                                                         ;

            
            #line default
            #line hidden
WriteLiteral("\t<div");

WriteLiteral(" class=\"alert alert-info\"");

WriteLiteral(" style=\"margin-top:-10px;\"");

WriteLiteral(@">
        <strong>Warning!</strong> This action updates all the selected records in this list.
        Select the desired properties using check boxes in the pop-up window.
        This is an irreversible action, which results in modification of all the selected properties.
        If you want to proceed with the action on the selected records, click ""Update"".
    </div>
");

WriteLiteral("\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                   <table");

WriteLiteral(" class=\"table table-striped table-bordered table-hover table-condensed\"");

WriteLiteral(@">
                        <thead>
                            <tr>
                                <th>Update</th>
                                <th>Property</th>
                                <th>Set Value</th>
                            </tr>
							<tr>
                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_Name\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 60 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td> ");

            
            #line 61 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
                Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("</td></tr>\r\n<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_Description\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 64 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n <td>");

            
            #line 65 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("</td></tr>\r\n<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_AssociatedScheduleTypeID\"");

WriteLiteral(" /></td>\r\n\t\t\t\t<td>");

            
            #line 68 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_AssociatedScheduleTypeID));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n");

WriteLiteral("\t\t");

            
            #line 70 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
   Write(Html.DropDownList("T_AssociatedScheduleTypeID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_Scheduletype", @dataurl = Url.Action("GetAllValue", "T_Scheduletype",new { caller = "T_AssociatedScheduleTypeID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t</td></tr>\r\n\t\t\t<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_StartDateTime\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 74 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_StartDateTime));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td> <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_StartDateTime\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 76 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.TextBoxFor(model => model.T_StartDateTime, new {@class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <span");

WriteLiteral(" class=\"input-group-addon btn-default calendar\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-calendar\"");

WriteLiteral("></i>\r\n                    </span>\r\n                </div>\r\n            <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n                $(function () {\r\n                    $(\'#datetimepickerT_Start" +
"DateTime\').datetimepicker();\r\n\t\t\t\t\t$(\'#T_StartDateTime\').datetimepicker();\r\n    " +
"            });\r\n            </script>\r\n\t\t\t</td>\r\n            </tr>\r\n<tr>\r\n     " +
"           <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_AssociatedRecurringScheduleDetailsTypeID\"");

WriteLiteral(" /></td>\r\n\t\t\t\t<td>");

            
            #line 91 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_AssociatedRecurringScheduleDetailsTypeID));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n");

WriteLiteral("\t\t");

            
            #line 93 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
   Write(Html.DropDownList("T_AssociatedRecurringScheduleDetailsTypeID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_RecurringScheduleDetailstype", @dataurl = Url.Action("GetAllValue", "T_RecurringScheduleDetailstype",new { caller = "T_AssociatedRecurringScheduleDetailsTypeID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t</td></tr>\r\n<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_RecurringRepeatFrequencyID\"");

WriteLiteral(" /></td>\r\n\t\t\t\t<td>");

            
            #line 97 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_RecurringRepeatFrequencyID));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n");

WriteLiteral("\t\t");

            
            #line 99 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
   Write(Html.DropDownList("T_RecurringRepeatFrequencyID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_RecurringFrequency", @dataurl = Url.Action("GetAllValue", "T_RecurringFrequency",new { caller = "T_RecurringRepeatFrequencyID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t</td></tr>\r\n<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_RepeatByID\"");

WriteLiteral(" /></td>\r\n\t\t\t\t<td>");

            
            #line 103 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_RepeatByID));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n");

WriteLiteral("\t\t");

            
            #line 105 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
   Write(Html.DropDownList("T_RepeatByID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_MonthlyRepeatType", @dataurl = Url.Action("GetAllValue", "T_MonthlyRepeatType",new { caller = "T_RepeatByID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t</td></tr>\r\n<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_RecurringTaskEndTypeID\"");

WriteLiteral(" /></td>\r\n\t\t\t\t<td>");

            
            #line 109 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_RecurringTaskEndTypeID));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n");

WriteLiteral("\t\t");

            
            #line 111 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
   Write(Html.DropDownList("T_RecurringTaskEndTypeID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_RecurringEndType", @dataurl = Url.Action("GetAllValue", "T_RecurringEndType",new { caller = "T_RecurringTaskEndTypeID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t</td></tr>\r\n\t\t\t<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_EndDate\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 115 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_EndDate));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td> <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_EndDate\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 117 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.TextBoxFor(model => model.T_EndDate, new {@class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <span");

WriteLiteral(" class=\"input-group-addon btn-default calendar\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-calendar\"");

WriteLiteral("></i>\r\n                    </span>\r\n                </div>\r\n            <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
                $(function () {
                    $('#datetimepickerT_EndDate').datetimepicker({ pickTime:false});
					$('#T_EndDate').datetimepicker({ pickTime:false});
                });
            </script>
			</td>
            </tr>
<tr>
                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_OccurrenceLimitCount\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 132 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_OccurrenceLimitCount));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td> ");

            
            #line 133 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
                Write(Html.TextBoxFor(model => model.T_OccurrenceLimitCount, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("</td></tr>\r\n<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_Summary\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 136 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_Summary));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n <td>");

            
            #line 137 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
Write(Html.TextAreaFor(model => model.T_Summary, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("</td></tr>\r\n                        </thead>\r\n                    </table>\r\n </di" +
"v> \r\n </div>\r\n  </div>\r\n   </div>\r\n");

WriteLiteral("   <button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

            
            #line 145 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
    if (ViewBag.IsDDAdd == null && User.CanEdit("T_Schedule"))
    {

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Update\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" />\r\n");

            
            #line 148 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    <br />");

WriteLiteral("<br />\r\n");

            
            #line 150 "..\..\Views\T_Schedule\BulkUpdate.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 8327), Tuple.Create("\"", 8367)
, Tuple.Create(Tuple.Create("", 8333), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Common3/chosen.jquery.js")
, 8333), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    var config = {
        '.chosen-select': {},
        '.chosen-select-deselect': { allow_single_deselect: true },
        '.chosen-select-no-single': { disable_search_threshold: 10 },
        '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
        '.chosen-select-width': { width: ""95%"" }
    }
    for (var selector in config) {
        $(selector).chosen(config[selector]);
    }
</script>
<script>
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

        }
    }
}
#pragma warning restore 1591