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

namespace GeneratorBase.MVC.Views.Chart
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Chart/Edit.cshtml")]
    public partial class Edit : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Chart>
    {
        public Edit()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Chart\Edit.cshtml"
  
    ViewBag.Title = "Edit Application Chart";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 120), Tuple.Create("\"", 163)
            
            #line 6 "..\..\Views\Chart\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 127), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 127), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 7 "..\..\Views\Chart\Edit.cshtml"
 using (Html.BeginForm("EditQuick", "Chart", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\Chart\Edit.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\Chart\Edit.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Chart\Edit.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Chart\Edit.cshtml"
                                      
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Chart\Edit.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Chart\Edit.cshtml"
                                                  

            
            #line default
            #line hidden
WriteLiteral("   <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                <label>");

            
            #line 21 "..\..\Views\Chart\Edit.cshtml"
                                  Write(Html.LabelFor(model => model.EntityName));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

WriteLiteral("                                ");

            
            #line 22 "..\..\Views\Chart\Edit.cshtml"
                           Write(Html.DropDownList("EntityName", null, "-- Select --", new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 23 "..\..\Views\Chart\Edit.cshtml"
                           Write(Html.ValidationMessageFor(model => model.EntityName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"             <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                <label>");

            
            #line 28 "..\..\Views\Chart\Edit.cshtml"
                                  Write(Html.LabelFor(model => model.ChartTitle));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

WriteLiteral("                                ");

            
            #line 29 "..\..\Views\Chart\Edit.cshtml"
                           Write(Html.TextBoxFor(model => model.ChartTitle, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 30 "..\..\Views\Chart\Edit.cshtml"
                           Write(Html.ValidationMessageFor(model => model.ChartTitle));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"             <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                <label>");

            
            #line 35 "..\..\Views\Chart\Edit.cshtml"
                                  Write(Html.LabelFor(model => model.ChartType));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                                <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 37 "..\..\Views\Chart\Edit.cshtml"
                               Write(Html.DropDownList("ChartType", null, "-- Select --", new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 38 "..\..\Views\Chart\Edit.cshtml"
                               Write(Html.ValidationMessageFor(model => model.ChartType));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                     </div>\r\n                        <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                <label>");

            
            #line 44 "..\..\Views\Chart\Edit.cshtml"
                                  Write(Html.LabelFor(model => model.XAxis));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("                                ");

            
            #line 45 "..\..\Views\Chart\Edit.cshtml"
                           Write(Html.DropDownList("XAxis", null, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 46 "..\..\Views\Chart\Edit.cshtml"
                           Write(Html.ValidationMessageFor(model => model.XAxis));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"             <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                <label>");

            
            #line 51 "..\..\Views\Chart\Edit.cshtml"
                                  Write(Html.LabelFor(model => model.YAxis));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("                                ");

            
            #line 52 "..\..\Views\Chart\Edit.cshtml"
                           Write(Html.DropDownList("YAxis", null, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 53 "..\..\Views\Chart\Edit.cshtml"
                           Write(Html.ValidationMessageFor(model => model.YAxis));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"             <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                <label>");

            
            #line 58 "..\..\Views\Chart\Edit.cshtml"
                                  Write(Html.LabelFor(model => model.ShowInDashBoard));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                ");

            
            #line 59 "..\..\Views\Chart\Edit.cshtml"
                           Write(Html.CheckBoxFor(model => model.ShowInDashBoard, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 60 "..\..\Views\Chart\Edit.cshtml"
                           Write(Html.ValidationMessageFor(model => model.ShowInDashBoard));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"         </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n   " +
" </div>\r\n");

WriteLiteral("    <button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

WriteLiteral("    <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" onclick=\"QuickAddFromIndex(event,true,\'T_Chart\',\'null\',\'null\',0);\"");

WriteLiteral(" />\r\n");

            
            #line 70 "..\..\Views\Chart\Edit.cshtml"
}

            
            #line default
            #line hidden
            
            #line 71 "..\..\Views\Chart\Edit.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 4084), Tuple.Create("\"", 4124)
, Tuple.Create(Tuple.Create("", 4090), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Common3/chosen.jquery.js")
, 4090), false)
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
</script>");

        }
    }
}
#pragma warning restore 1591
