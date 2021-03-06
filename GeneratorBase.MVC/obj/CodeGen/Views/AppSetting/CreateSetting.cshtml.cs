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

namespace GeneratorBase.MVC.Views.AppSetting
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/AppSetting/CreateSetting.cshtml")]
    public partial class CreateSetting : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.AppSetting>
    {
        public CreateSetting()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\AppSetting\CreateSetting.cshtml"
  
    ViewBag.Title = "Create Application Setting";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 127), Tuple.Create("\"", 170)
            
            #line 6 "..\..\Views\AppSetting\CreateSetting.cshtml"
, Tuple.Create(Tuple.Create("", 134), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 134), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 7 "..\..\Views\AppSetting\CreateSetting.cshtml"
 using (Html.BeginForm("CreateSetting", "AppSetting", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\AppSetting\CreateSetting.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\AppSetting\CreateSetting.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("    <div");

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

            
            #line 19 "..\..\Views\AppSetting\CreateSetting.cshtml"
                                  Write(Html.LabelFor(model => model.Key));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

WriteLiteral("                                ");

            
            #line 20 "..\..\Views\AppSetting\CreateSetting.cshtml"
                           Write(Html.TextBoxFor(model => model.Key, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 21 "..\..\Views\AppSetting\CreateSetting.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"             <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                <label>");

            
            #line 26 "..\..\Views\AppSetting\CreateSetting.cshtml"
                                  Write(Html.LabelFor(model => model.Value));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

WriteLiteral("                                ");

            
            #line 27 "..\..\Views\AppSetting\CreateSetting.cshtml"
                           Write(Html.TextBoxFor(model => model.Value, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 28 "..\..\Views\AppSetting\CreateSetting.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"             <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                <label>");

            
            #line 33 "..\..\Views\AppSetting\CreateSetting.cshtml"
                                  Write(Html.LabelFor(model => model.AssociatedAppSettingGroupID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                                <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 35 "..\..\Views\AppSetting\CreateSetting.cshtml"
                               Write(Html.DropDownList("AssociatedAppSettingGroupID", null, "-- Select --", new { @class = "chosen-select form-control", @HostingName = "AppSetting", @dataurl = Url.Action("GetAllValue", "AppSetting", new { caller = "AssociatedAppSettingGroupID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 36 "..\..\Views\AppSetting\CreateSetting.cshtml"
                               Write(Html.ValidationMessageFor(model => model.AssociatedAppSettingGroupID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n   " +
"                     </div>\r\n                        <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                <label>");

            
            #line 42 "..\..\Views\AppSetting\CreateSetting.cshtml"
                                  Write(Html.LabelFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("                                ");

            
            #line 43 "..\..\Views\AppSetting\CreateSetting.cshtml"
                           Write(Html.TextAreaFor(model => model.Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 44 "..\..\Views\AppSetting\CreateSetting.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"             ");

WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n       " +
" </div>\r\n    </div>\r\n");

WriteLiteral("    <button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

WriteLiteral("    <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" onclick=\"QuickAddFromIndex(event,true,\'AppSetting\',\'null\',\'null\',0);\"");

WriteLiteral(" />\r\n");

            
            #line 61 "..\..\Views\AppSetting\CreateSetting.cshtml"
}

            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\AppSetting\CreateSetting.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 3775), Tuple.Create("\"", 3815)
, Tuple.Create(Tuple.Create("", 3781), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Common3/chosen.jquery.js")
, 3781), false)
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
