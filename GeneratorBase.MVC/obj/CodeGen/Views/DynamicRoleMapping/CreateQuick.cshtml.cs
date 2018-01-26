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

namespace GeneratorBase.MVC.Views.DynamicRoleMapping
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DynamicRoleMapping/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.DynamicRoleMapping>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
  
    ViewBag.Title = "Create DynamicRoleMapping";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteLiteral(" language=\"JavaScript\"");

WriteLiteral(">\r\n    function FillRelations() {\r\n        var SelectedText = $(\'#EntityName\').va" +
"l();\r\n        var url = $(\'#EntityName\').attr(\"dataurl\");\r\n        $.ajax({\r\n   " +
"         url: \'");

            
            #line 11 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
             Write(Url.Action("GetUserAssociation","BusinessRule"));

            
            #line default
            #line hidden
WriteLiteral(@"' + '?Entity=' + SelectedText,
            type: ""GET"",
            cache: false,
            success: function (result) {
                var optionDOM = """";
                for (i = 0; i < result.length; i++) {
                    if (result[i].Key == ""Owner"") continue;
                    optionDOM += '<option value=""' + result[i].Key + '"">' + result[i].Value + '</option>';
                }
                $(""#"" + ""UserRelation"").html(optionDOM);
                //$(""#"" + ""cmbNotifyTo"").multiselect('rebuild');
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(""error"");
            }
        })
        $.ajax({
            url: '");

            
            #line 28 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
             Write(Url.Action("GetPropertiesofEntity", "BusinessRule"));

            
            #line default
            #line hidden
WriteLiteral(@"' + '?Entity=' + SelectedText,
            type: ""GET"",
            cache: false,
            success: function (result) {
                var optionDOM = """";
                for (i = 0; i < result.length; i++) {
                    optionDOM += '<option value=""' + result[i].Name + '"">' + result[i].DisplayName + '</option>';
                }
                $(""#"" + ""Condition"").html(optionDOM);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(""error"");
            }
        })
    }
</script>
<script>
    $(document).ready(function () {
        try {
            var hostingEntityName = """";
            if ('");

            
            #line 48 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 49 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n                $(\"#dv\" + hostingEntityName + \"ID\").hide();\r\n            }\r\n " +
"       }\r\n        catch (ex) { }\r\n    });\r\n</script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 2108), Tuple.Create("\"", 2157)
, Tuple.Create(Tuple.Create("", 2115), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 2115), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 2185), Tuple.Create("\"", 2228)
            
            #line 57 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 2192), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 2192), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 58 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "DynamicRoleMapping", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
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

            
            #line 70 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                  Write(Html.LabelFor(model => model.EntityName));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n                                ");

WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 72 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                           Write(Html.DropDownList("EntityName", null, "-- Select --", new { @onchange = "FillRelations();",@dataurl = Url.Action("UserBasedSecurity", "Permission", null) , @required = "required", @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 73 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.EntityName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"             <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                <label>Map To Role<span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n                                ");

WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 80 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                           Write(Html.DropDownList("RoleId", null, "-- Select --", new { @required = "required", @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 81 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.RoleId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"             <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                        <label>Entity Column<span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n                                        ");

WriteLiteral("\r\n");

WriteLiteral("                                        ");

            
            #line 90 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                   Write(Html.DropDownList("Condition", null, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                        ");

            
            #line 91 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.Condition));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </div>\r\n                                </d" +
"iv>\r\n                                <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 96 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                   Write(Html.LabelFor(model => model.Value));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span>\r\n");

WriteLiteral("                                        ");

            
            #line 97 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                   Write(Html.TextBoxFor(model => model.Value, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                        ");

            
            #line 98 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </div>\r\n                                </d" +
"iv>\r\n                            </div>\r\n                        </div>\r\n       " +
"                 <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n");

WriteLiteral("                               ");

            
            #line 105 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                          Write(Html.LabelFor(model => model.UserRelation));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span>\r\n                                ");

WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 107 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                           Write(Html.DropDownList("UserRelation", null, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 108 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.UserRelation));

            
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

            
            #line 133 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
    var busineesrule = User.businessrules.Where(p => p.EntityName == "DynamicRoleMapping").ToList();
    if (ViewBag.IsAddPop != null)
    {

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7344), Tuple.Create("\"", 7406)
, Tuple.Create(Tuple.Create("", 7354), Tuple.Create("QuickAdd(event,\'", 7354), true)
            
            #line 136 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                    , Tuple.Create(Tuple.Create("", 7370), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 7370), false)
, Tuple.Create(Tuple.Create("", 7383), Tuple.Create("\',", 7383), true)
            
            #line 136 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                   , Tuple.Create(Tuple.Create("", 7385), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 7385), false)
, Tuple.Create(Tuple.Create("", 7404), Tuple.Create(");", 7404), true)
);

WriteLiteral(" />\r\n");

            
            #line 137 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7510), Tuple.Create("\"", 7637)
, Tuple.Create(Tuple.Create("", 7520), Tuple.Create("QuickAddFromIndex(event,true,\'DynamicRoleMapping\',\'", 7520), true)
            
            #line 140 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                                       , Tuple.Create(Tuple.Create("", 7571), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 7571), false)
, Tuple.Create(Tuple.Create("", 7598), Tuple.Create("\',\'", 7598), true)
            
            #line 140 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                                                                     , Tuple.Create(Tuple.Create("", 7601), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 7601), false)
, Tuple.Create(Tuple.Create("", 7614), Tuple.Create("\',", 7614), true)
            
            #line 140 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
                                                                                                    , Tuple.Create(Tuple.Create("", 7616), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 7616), false)
, Tuple.Create(Tuple.Create("", 7635), Tuple.Create(");", 7635), true)
);

WriteLiteral(" />\r\n");

            
            #line 141 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
    }
}

            
            #line default
            #line hidden
            
            #line 143 "..\..\Views\DynamicRoleMapping\CreateQuick.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7700), Tuple.Create("\"", 7740)
, Tuple.Create(Tuple.Create("", 7706), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Common3/chosen.jquery.js")
, 7706), false)
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

        }
    }
}
#pragma warning restore 1591