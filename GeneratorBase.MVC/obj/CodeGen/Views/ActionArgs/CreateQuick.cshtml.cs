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

namespace GeneratorBase.MVC.Views.ActionArgs
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ActionArgs/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.ActionArgs>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\ActionArgs\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Action Args";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\ActionArgs\CreateQuick.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 159), Tuple.Create("\"", 208)
, Tuple.Create(Tuple.Create("", 166), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 166), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 236), Tuple.Create("\"", 279)
            
            #line 8 "..\..\Views\ActionArgs\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 243), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 243), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 325), Tuple.Create("\"", 389)
            
            #line 9 "..\..\Views\ActionArgs\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 331), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/Common2/bootstrap-multiselect.js")
            
            #line default
            #line hidden
, 331), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 430), Tuple.Create("\"", 488)
            
            #line 10 "..\..\Views\ActionArgs\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 437), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/bootstrap-multiselect.css")
            
            #line default
            #line hidden
, 437), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" language=\"javascript\"");

WriteLiteral(">\r\n    $(document).ready(function () {\r\n        if (\"");

            
            #line 13 "..\..\Views\ActionArgs\CreateQuick.cshtml"
        Write(ViewBag.MandatoryRule);

            
            #line default
            #line hidden
WriteLiteral("\".toUpperCase() == \"TRUE\") {\r\n            $(\'#ParameterValue\').val(\"Set as Mandat" +
"ory\");\r\n            $(\'#ParameterValue\').attr(\'readonly\', \'readonly\');\r\n        " +
"}\r\n        if (\"");

            
            #line 17 "..\..\Views\ActionArgs\CreateQuick.cshtml"
        Write(ViewBag.ReadonlyRule);

            
            #line default
            #line hidden
WriteLiteral("\".toUpperCase() == \"TRUE\") {\r\n            $(\'#ParameterValue\').val(\"Set as Readon" +
"ly\");\r\n            $(\'#ParameterValue\').attr(\'readonly\', \'readonly\');\r\n        }" +
"\r\n        // Sanjeev\r\n        if (\"");

            
            #line 22 "..\..\Views\ActionArgs\CreateQuick.cshtml"
        Write(ViewBag.HiddenRule);

            
            #line default
            #line hidden
WriteLiteral("\".toUpperCase() == \"TRUE\") {\r\n            $(\'#ParameterValue\').val(\"Set as Hidden" +
"\");\r\n            $(\'#ParameterValue\').attr(\'readonly\', \'readonly\');\r\n        }\r\n" +
"        if (\"");

            
            #line 26 "..\..\Views\ActionArgs\CreateQuick.cshtml"
        Write(ViewBag.GroupsHiddenRule);

            
            #line default
            #line hidden
WriteLiteral("\".toUpperCase() == \"TRUE\") {\r\n            $(\'#ParameterValue\').val(\"Set as Hidden" +
" Groups\");\r\n            $(\'#ParameterValue\').attr(\'readonly\', \'readonly\');\r\n    " +
"    }\r\n        //\r\n    });\r\n    if (\"");

            
            #line 32 "..\..\Views\ActionArgs\CreateQuick.cshtml"
    Write(ViewBag.Parameters);

            
            #line default
            #line hidden
WriteLiteral("\" != null) {\r\n        var pramname = \"");

            
            #line 33 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                   Write(ViewBag.Parameters);

            
            #line default
            #line hidden
WriteLiteral(@""".split("","");
        var PropNameEle = document.getElementById(""PropertyListActionArg"");
        for (i = 0; i < pramname.length; i++) {
            if (pramname[i] == """")
                break;
            for (var o = 0; o < PropNameEle.options.length; o++) {
                if (PropNameEle.options[o].value == pramname[i]) {
                    PropNameEle.options[o].setAttribute('selected', ""selected"");
                    //$(""#ParameterName"").val($(""#ParameterName"").val() + "","" + PropNameEle.val());
                }
            }
        }
    }
    selectedProperties = ($('#PropertyListActionArg option:selected'));
    $(selectedProperties).each(function (index, prop) {
        $(""#ParameterName"").val($(""#ParameterName"").val() + "","" + [$(this).val()]);
    });
</script>
");

            
            #line 51 "..\..\Views\ActionArgs\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "ActionArgs", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\ActionArgs\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                            ;
                            Html.ValidationSummary(true);
                            Html.EnableClientValidation();

            
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

            
            #line 63 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                          Write(Html.LabelFor(model => model.ParameterName));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n                                                        <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" id=\"dvPropList\"");

WriteLiteral(" name=\"PropList\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                            ");

            
            #line 65 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                       Write(Html.DropDownList("PropertyListActionArg", null, new { @multiple = "multiple" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                            ");

            
            #line 66 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                       Write(Html.TextBoxFor(model => model.ParameterName, new { style = "border:none !important;Width:0px !important;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                            ");

            
            #line 67 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                       Write(Html.ValidationMessageFor(model => model.ParameterName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                        </div>\r\n               " +
"                                     </div>\r\n                                   " +
"             </div>\r\n                                                <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 73 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                          Write(Html.LabelFor(model => model.ParameterValue));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

WriteLiteral("                                                        ");

            
            #line 74 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                   Write(Html.TextBoxFor(model => model.ParameterValue, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                        ");

            
            #line 75 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.ParameterValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </div>\r\n                   " +
"                             </div>\r\n                                           " +
"     <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" style=\"visibility:hidden;\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 80 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                          Write(Html.LabelFor(model => model.ActionArgumentsID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                                                        <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                            ");

            
            #line 82 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                       Write(Html.DropDownList("ActionArgumentsID", null, "--Select Action--",
                                        new
                                        {
                                            @class = "chosen-select form-control",
                                            @HostingName = "RuleAction",
                                            @dataurl = Url.Action("GetAllValue", "RuleAction", null),
                                        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                            ");

            
            #line 89 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                       Write(Html.ValidationMessageFor(model => model.ActionArgumentsID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                            <div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                                                                <a");

WriteLiteral(" class=\"btn btn-default btn ie8fix\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                                                                    <span");

WriteLiteral(" class=\"glyphicon glyphicon-plus-sign\"");

WriteLiteral(@"></span>
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
");

WriteLiteral("                            <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

            
            #line 104 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\ActionArgs\CreateQuick.cshtml"
                                                                                                                                                                                     

            
            #line default
            #line hidden
WriteLiteral("                            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" />\r\n");

            
            #line 106 "..\..\Views\ActionArgs\CreateQuick.cshtml"
}

            
            #line default
            #line hidden
            
            #line 107 "..\..\Views\ActionArgs\CreateQuick.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7012), Tuple.Create("\"", 7076)
            
            #line 108 "..\..\Views\ActionArgs\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 7018), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/Common2/bootstrap-multiselect.js")
            
            #line default
            #line hidden
, 7018), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 7117), Tuple.Create("\"", 7175)
            
            #line 109 "..\..\Views\ActionArgs\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 7124), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/bootstrap-multiselect.css")
            
            #line default
            #line hidden
, 7124), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7221), Tuple.Create("\"", 7285)
            
            #line 110 "..\..\Views\ActionArgs\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 7227), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/Common2/bootstrap-multiselect.js")
            
            #line default
            #line hidden
, 7227), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    var config = {\r\n        \'.chosen-select\': {},\r\n        \'.chosen-select-des" +
"elect\': { allow_single_deselect: true },\r\n        \'.chosen-select-no-single\': { " +
"disable_search_threshold: 10 },\r\n        \'.chosen-select-no-results\': { no_resul" +
"ts_text: \'Oops, nothing found!\' },\r\n        \'.chosen-select-width\': { width: \"95" +
"%\" }\r\n    }\r\n    for (var selector in config) {\r\n        $(selector).chosen(conf" +
"ig[selector]);\r\n    }\r\n</script>\r\n<script>\r\n    $(document).ready(function () {\r" +
"\n        $(\'#PropertyListActionArg\').multiselect({\r\n            buttonWidth: \'10" +
"0%\'\r\n        });\r\n    });\r\n</script>\r\n<script>\r\n    $(\"form\").submit(function ()" +
" {\r\n        $(\'div[name=PropList]\').each(function (e) {\r\n            $(\"#Paramet" +
"erName\").val(\'\');\r\n            catname = $(this).attr(\'id\');\r\n            var se" +
"lectedProperties = ($(\'#PropertyListActionArg option:selected\'));\r\n            v" +
"ar firstInput = $(\"#\" + catname).find(\'input[type=text],input[type=password],inp" +
"ut[type=radio],input[type=checkbox],textarea,select\').filter(\':visible:first\');\r" +
"\n            var firstButton = $(\"#\" + catname).find(\'button\').filter(\':first\');" +
"\r\n            var txtid = firstInput.attr(\'id\');\r\n            var btntitle = fir" +
"stButton.attr(\'title\');\r\n            if (firstButton != null) {\r\n               " +
" if (btntitle != \'None selected\') {\r\n                    $(selectedProperties).e" +
"ach(function (index, prop) {\r\n                        $(\"#\" + txtid).val($(\"#\" +" +
" txtid).val() + \",\" + [$(this).val()]);\r\n                    });\r\n              " +
"  }\r\n                else\r\n                    $(\"#\" + txtid).val(\'\');\r\n        " +
"    }\r\n        });\r\n        if ($(this).find(\'.input-validation-error\').length =" +
"= 0) {\r\n            $(this).find(\':submit\').attr(\'disabled\', \'disabled\');\r\n     " +
"   }\r\n    });\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591