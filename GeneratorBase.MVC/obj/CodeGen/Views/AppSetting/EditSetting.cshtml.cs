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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/AppSetting/EditSetting.cshtml")]
    public partial class EditSetting : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.AppSetting>
    {
        
        #line 6 "..\..\Views\AppSetting\EditSetting.cshtml"
            
    object getHtmlAttributes()
    {
        if (Model.IsDefault)
            return new { @class = "form-control", @readonly = "readonly" };
        else
            return new { @class = "form-control" };
    }

        #line default
        #line hidden
        
        public EditSetting()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\AppSetting\EditSetting.cshtml"
  
    ViewBag.Title = "Edit Application Setting";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("<link");

WriteAttribute("href", Tuple.Create(" href=\"", 362), Tuple.Create("\"", 405)
            
            #line 15 "..\..\Views\AppSetting\EditSetting.cshtml"
, Tuple.Create(Tuple.Create("", 369), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 369), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 16 "..\..\Views\AppSetting\EditSetting.cshtml"
 using (Html.BeginForm("EditSetting", "AppSetting", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\AppSetting\EditSetting.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\AppSetting\EditSetting.cshtml"
                            ;
                            Html.ValidationSummary(true);
                            Html.EnableClientValidation();
                            
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\AppSetting\EditSetting.cshtml"
                       Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                              
                            
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\AppSetting\EditSetting.cshtml"
                       Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                          

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 30 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                          Write(Html.LabelFor(model => model.Key));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

WriteLiteral("                                                        ");

            
            #line 31 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                   Write(Html.TextBoxFor(model => model.Key, getHtmlAttributes()));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                        ");

            
            #line 32 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </div>\r\n                   " +
"                             </div>\r\n                                           " +
"     <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 37 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                          Write(Html.LabelFor(model => model.Value));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

            
            #line 38 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                        
            
            #line default
            #line hidden
            
            #line 38 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                         if (@Model.Key.ToLower() == "reportpass")
                                                        {
                                                            
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                       Write(Html.PasswordFor(model => model.Value, new { @value = Model.Value, @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                                                                                          
                                                        }
                                                        else
                                                        {
                                                            if (Model.Value.ToLower() == "yes")
                                                            {


            
            #line default
            #line hidden
WriteLiteral("                                                                <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"appsettingSelectBox\"");

WriteLiteral(" >\r\n                                                                    <option");

WriteAttribute("value", Tuple.Create(" value=\"", 2963), Tuple.Create("\"", 2983)
            
            #line 48 "..\..\Views\AppSetting\EditSetting.cshtml"
   , Tuple.Create(Tuple.Create("", 2971), Tuple.Create<System.Object, System.Int32>(Model.Value
            
            #line default
            #line hidden
, 2971), false)
);

WriteLiteral(">");

            
            #line 48 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                            Write(Model.Value);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                                                                    <o" +
"ption");

WriteLiteral(" value=\"No\"");

WriteLiteral(">No</option>\r\n                                                                </s" +
"elect>\r\n");

            
            #line 51 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                           Write(Html.Hidden("Value"));

            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                     
                                                            }
                                                            else if (Model.Value.ToLower() == "no")
                                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                                <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"appsettingSelectBox\"");

WriteLiteral(" >\r\n                                                                    <option");

WriteAttribute("value", Tuple.Create("  value=\"", 3693), Tuple.Create("\"", 3714)
            
            #line 56 "..\..\Views\AppSetting\EditSetting.cshtml"
    , Tuple.Create(Tuple.Create("", 3702), Tuple.Create<System.Object, System.Int32>(Model.Value
            
            #line default
            #line hidden
, 3702), false)
);

WriteLiteral(">");

            
            #line 56 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                             Write(Model.Value);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                                                                    <o" +
"ption");

WriteLiteral(" value=\"Yes\"");

WriteLiteral(">Yes</option>\r\n                                                                </" +
"select>\r\n");

            
            #line 59 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                           Write(Html.Hidden("Value"));

            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                     
                                                            }
                                                            else if (Model.Value.ToLower() == "true")
                                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                                <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"appsettingSelectBox\"");

WriteLiteral(" >\r\n                                                                    <option");

WriteAttribute("value", Tuple.Create(" value=\"", 4428), Tuple.Create("\"", 4448)
            
            #line 64 "..\..\Views\AppSetting\EditSetting.cshtml"
   , Tuple.Create(Tuple.Create("", 4436), Tuple.Create<System.Object, System.Int32>(Model.Value
            
            #line default
            #line hidden
, 4436), false)
);

WriteLiteral(">");

            
            #line 64 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                            Write(Model.Value);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                                                                    <o" +
"ption");

WriteLiteral(" value=\"false\"");

WriteLiteral(">false</option>\r\n                                                                " +
"</select>\r\n");

            
            #line 67 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                
            
            #line default
            #line hidden
            
            #line 67 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                           Write(Html.Hidden("Value"));

            
            #line default
            #line hidden
            
            #line 67 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                     
                                                            }
                                                            else if (Model.Value.ToLower() == "false")
                                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                                <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"appsettingSelectBox\"");

WriteLiteral(" >\r\n                                                                    <option");

WriteAttribute("value", Tuple.Create(" value=\"", 5167), Tuple.Create("\"", 5187)
            
            #line 72 "..\..\Views\AppSetting\EditSetting.cshtml"
   , Tuple.Create(Tuple.Create("", 5175), Tuple.Create<System.Object, System.Int32>(Model.Value
            
            #line default
            #line hidden
, 5175), false)
);

WriteLiteral(">");

            
            #line 72 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                            Write(Model.Value);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                                                                    <o" +
"ption");

WriteLiteral(" value=\"true\"");

WriteLiteral(">true</option>\r\n                                                                <" +
"/select>\r\n");

            
            #line 75 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                           Write(Html.Hidden("Value"));

            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                     
                                                            }
                                                            else if (Model.Value.ToLower() == "on")
                                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                                <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"appsettingSelectBox\"");

WriteLiteral(" >\r\n                                                                    <option");

WriteAttribute("value", Tuple.Create(" value=\"", 5901), Tuple.Create("\"", 5921)
            
            #line 80 "..\..\Views\AppSetting\EditSetting.cshtml"
   , Tuple.Create(Tuple.Create("", 5909), Tuple.Create<System.Object, System.Int32>(Model.Value
            
            #line default
            #line hidden
, 5909), false)
);

WriteLiteral(">");

            
            #line 80 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                            Write(Model.Value);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                                                                    <o" +
"ption");

WriteLiteral(" value=\"Off\"");

WriteLiteral(">Off</option>\r\n                                                                </" +
"select>\r\n");

            
            #line 83 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                
            
            #line default
            #line hidden
            
            #line 83 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                           Write(Html.Hidden("Value"));

            
            #line default
            #line hidden
            
            #line 83 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                     
                                                            }
                                                            else if (Model.Value.ToLower() == "off")
                                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                                <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"appsettingSelectBox\"");

WriteLiteral(" >\r\n                                                                    <option");

WriteAttribute("value", Tuple.Create(" value=\"", 6634), Tuple.Create("\"", 6654)
            
            #line 88 "..\..\Views\AppSetting\EditSetting.cshtml"
   , Tuple.Create(Tuple.Create("", 6642), Tuple.Create<System.Object, System.Int32>(Model.Value
            
            #line default
            #line hidden
, 6642), false)
);

WriteLiteral(">");

            
            #line 88 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                            Write(Model.Value);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                                                                    <o" +
"ption");

WriteLiteral(" value=\"On\"");

WriteLiteral(">On</option>\r\n                                                                </s" +
"elect>\r\n");

            
            #line 91 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                
            
            #line default
            #line hidden
            
            #line 91 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                           Write(Html.Hidden("Value"));

            
            #line default
            #line hidden
            
            #line 91 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                     
                                                            }
                                                            else
                                                            {
                                                                
            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                           Write(Html.TextBoxFor(model => model.Value, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                                                                                                       
                                                            }
                                                        }

            
            #line default
            #line hidden
WriteLiteral("                                                        ");

            
            #line 98 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </div>\r\n                   " +
"                             </div>\r\n                                           " +
"     <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 103 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                          Write(Html.LabelFor(model => model.AssociatedAppSettingGroupID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                                                        <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                            ");

            
            #line 105 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                       Write(Html.DropDownList("AssociatedAppSettingGroupID", null, "-- Select --", new { @class = "chosen-select form-control", @HostingName = "AppSetting", @dataurl = Url.Action("GetAllValue", "AppSetting", new { caller = "AssociatedAppSettingGroupID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                            ");

            
            #line 106 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                       Write(Html.ValidationMessageFor(model => model.AssociatedAppSettingGroupID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                        </div>\r\n               " +
"                                     </div>\r\n                                   " +
"             </div>\r\n                                                <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 112 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                          Write(Html.LabelFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("                                                        ");

            
            #line 113 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                   Write(Html.TextAreaFor(model => model.Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                        ");

            
            #line 114 "..\..\Views\AppSetting\EditSetting.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </div>\r\n                   " +
"                             </div>\r\n");

WriteLiteral("                                                ");

            
            #line 117 "..\..\Views\AppSetting\EditSetting.cshtml"
                                           Write(Html.HiddenFor(model => model.IsDefault));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </div>\r\n                           " +
"             </div>\r\n                                    </div>\r\n               " +
"                 </div>\r\n                            </div>\r\n");

WriteLiteral("                            <button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

WriteLiteral("                            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" onclick=\"QuickAddFromIndex(event,true,\'AppSetting\',\'null\',\'null\',0);\"");

WriteLiteral(" />\r\n");

            
            #line 125 "..\..\Views\AppSetting\EditSetting.cshtml"
}

            
            #line default
            #line hidden
            
            #line 126 "..\..\Views\AppSetting\EditSetting.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 9936), Tuple.Create("\"", 9976)
, Tuple.Create(Tuple.Create("", 9942), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Common3/chosen.jquery.js")
, 9942), false)
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
");

            
            #line 140 "..\..\Views\AppSetting\EditSetting.cshtml"
 if (Model.Value.ToLower() == "yes" || Model.Value.ToLower() == "no" || Model.Value.ToLower() == "true" || Model.Value.ToLower() == "false" || Model.Value.ToLower() == "on" || Model.Value.ToLower() == "off")
{

            
            #line default
            #line hidden
WriteLiteral(@"    <script>
        $(document).ready(function () {
            $(""#Value"").val($(""#appsettingSelectBox option:selected"").text());
            $(""#appsettingSelectBox"").on(""change"", function () {
                $(""#Value"").val($(""#appsettingSelectBox option:selected"").text());
            });
        });
    </script>
");

            
            #line 150 "..\..\Views\AppSetting\EditSetting.cshtml"

}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
