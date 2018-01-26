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

namespace GeneratorBase.MVC.Views.T_BackgroundCheck
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_BackgroundCheck/BulkUpdate.cshtml")]
    public partial class BulkUpdate : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_BackgroundCheck>
    {
        public BulkUpdate()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
  
 ViewBag.Title = "Bulk Update Background Check";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
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

WriteAttribute("href", Tuple.Create(" href=\"", 1210), Tuple.Create("\"", 1259)
, Tuple.Create(Tuple.Create("", 1217), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1217), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1287), Tuple.Create("\"", 1330)
            
            #line 36 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
, Tuple.Create(Tuple.Create("", 1294), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1294), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 37 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
 using (Html.BeginForm("BulkUpdate", "T_BackgroundCheck", new { UrlReferrer = Convert.ToString(ViewData["T_BackgroundCheckParentUrl"]), IsDDAdd = ViewBag.IsDDAdd }, FormMethod.Post, new { enctype = "multipart/form-data" }))
{
   
            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
                           ;
   
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
Write(Html.Hidden("BulkUpdate", (object)ViewBag.BulkUpdate));

            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
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

WriteLiteral(" value=\"T_RetainTablePreEmploymentCheckID\"");

WriteLiteral(" /></td>\r\n\t\t\t\t<td>");

            
            #line 60 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_RetainTablePreEmploymentCheckID));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n");

WriteLiteral("\t\t");

            
            #line 62 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
   Write(Html.DropDownList("T_RetainTablePreEmploymentCheckID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_RetainTable", @dataurl = Url.Action("GetAllValue", "T_RetainTable",new { caller = "T_RetainTablePreEmploymentCheckID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t</td></tr>\r\n\t\t\t<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_DateFingerPrintTaken\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 66 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_DateFingerPrintTaken));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td> <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_DateFingerPrintTaken\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 68 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.TextBoxFor(model => model.T_DateFingerPrintTaken, new {@class = "form-control" }));

            
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
                    $('#datetimepickerT_DateFingerPrintTaken').datetimepicker({ pickTime:false});
					$('#T_DateFingerPrintTaken').datetimepicker({ pickTime:false});
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

WriteLiteral(" value=\"T_DateInformationReceivedFromCBC\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 83 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_DateInformationReceivedFromCBC));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td> <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_DateInformationReceivedFromCBC\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 85 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.TextBoxFor(model => model.T_DateInformationReceivedFromCBC, new {@class = "form-control" }));

            
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
                    $('#datetimepickerT_DateInformationReceivedFromCBC').datetimepicker({ pickTime:false});
					$('#T_DateInformationReceivedFromCBC').datetimepicker({ pickTime:false});
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

WriteLiteral(" value=\"T_PreEmploymentCheckResultsVAStateID\"");

WriteLiteral(" /></td>\r\n\t\t\t\t<td>");

            
            #line 100 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_PreEmploymentCheckResultsVAStateID));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n");

WriteLiteral("\t\t");

            
            #line 102 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
   Write(Html.DropDownList("T_PreEmploymentCheckResultsVAStateID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_ResultsTable", @dataurl = Url.Action("GetAllValue", "T_ResultsTable",new { caller = "T_PreEmploymentCheckResultsVAStateID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t</td></tr>\r\n\t\t\t<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_BackgroundDispositionDate\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 106 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_BackgroundDispositionDate));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td> <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_BackgroundDispositionDate\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 108 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.TextBoxFor(model => model.T_BackgroundDispositionDate, new {@class = "form-control" }));

            
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
                    $('#datetimepickerT_BackgroundDispositionDate').datetimepicker({ pickTime:false});
					$('#T_BackgroundDispositionDate').datetimepicker({ pickTime:false});
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

WriteLiteral(" value=\"T_ReviewDate\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 123 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_ReviewDate));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td> <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_ReviewDate\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 125 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.TextBoxFor(model => model.T_ReviewDate, new {@class = "form-control" }));

            
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
                    $('#datetimepickerT_ReviewDate').datetimepicker({ pickTime:false});
					$('#T_ReviewDate').datetimepicker({ pickTime:false});
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

WriteLiteral(" value=\"T_ReviewerID\"");

WriteLiteral(" /></td>\r\n\t\t\t\t<td>");

            
            #line 140 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_ReviewerID));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n");

WriteLiteral("\t\t");

            
            #line 142 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
   Write(Html.DropDownList("T_ReviewerID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_Employee", @dataurl = Url.Action("GetAllValue", "T_Employee",new { caller = "T_ReviewerID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t</td></tr>\r\n\t\t\t<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_DateCheckInitiated\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 146 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_DateCheckInitiated));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td> <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_DateCheckInitiated\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 148 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.TextBoxFor(model => model.T_DateCheckInitiated, new {@class = "form-control" }));

            
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
                    $('#datetimepickerT_DateCheckInitiated').datetimepicker({ pickTime:false});
					$('#T_DateCheckInitiated').datetimepicker({ pickTime:false});
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

WriteLiteral(" value=\"T_DateCPSResultReceived\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 163 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_DateCPSResultReceived));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td> <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_DateCPSResultReceived\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 165 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.TextBoxFor(model => model.T_DateCPSResultReceived, new {@class = "form-control" }));

            
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
                    $('#datetimepickerT_DateCPSResultReceived').datetimepicker({ pickTime:false});
					$('#T_DateCPSResultReceived').datetimepicker({ pickTime:false});
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

WriteLiteral(" value=\"T_CPSResultID\"");

WriteLiteral(" /></td>\r\n\t\t\t\t<td>");

            
            #line 180 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_CPSResultID));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n");

WriteLiteral("\t\t");

            
            #line 182 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
   Write(Html.DropDownList("T_CPSResultID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_CPSResults", @dataurl = Url.Action("GetAllValue", "T_CPSResults",new { caller = "T_CPSResultID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t</td></tr>\r\n\t\t\t<tr>\r\n                <td");

WriteLiteral(" align=\"center\"");

WriteLiteral("><input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"chkUpdate\"");

WriteLiteral(" value=\"T_CPSReviewDate\"");

WriteLiteral(" /></td>\r\n                <td>");

            
            #line 186 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.LabelFor(model => model.T_CPSReviewDate));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td> <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerT_CPSReviewDate\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 188 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
               Write(Html.TextBoxFor(model => model.T_CPSReviewDate, new {@class = "form-control" }));

            
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
                    $('#datetimepickerT_CPSReviewDate').datetimepicker({ pickTime:false});
					$('#T_CPSReviewDate').datetimepicker({ pickTime:false});
                });
            </script>
			</td>
            </tr>
                        </thead>
                    </table>
 </div> 
 </div>
  </div>
   </div>
");

WriteLiteral("   <button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

            
            #line 208 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
    if (ViewBag.IsDDAdd == null && User.CanEdit("T_BackgroundCheck"))
    {

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Update\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" />\r\n");

            
            #line 211 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    <br />");

WriteLiteral("<br />\r\n");

            
            #line 213 "..\..\Views\T_BackgroundCheck\BulkUpdate.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 11331), Tuple.Create("\"", 11371)
, Tuple.Create(Tuple.Create("", 11337), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Common3/chosen.jquery.js")
, 11337), false)
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