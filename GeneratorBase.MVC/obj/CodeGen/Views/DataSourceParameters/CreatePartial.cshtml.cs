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

namespace GeneratorBase.MVC.Views.DataSourceParameters
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DataSourceParameters/CreatePartial.cshtml")]
    public partial class CreatePartial : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.DataSourceParameters>
    {
        public CreatePartial()
        {
        }
        public override void Execute()
        {
WriteLiteral("<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var hos" +
"tingEntityName = \"\";\r\n            if (\'");

            
            #line 6 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 7 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n                 $(\'#\' + hostingEntityName + \'ID\').attr(\"lock\",\"true\");\r\n\t\t\t\t" +
"  $(\'#\' + hostingEntityName + \'ID\').trigger(\"change\");\r\n            }\r\n        }" +
"\r\n        catch (ex) { }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.DataSourceParametersIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.DataSourceParametersIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                                                           ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
 using (Html.BeginForm("Create", "DataSourceParameters",new {UrlReferrer = Convert.ToString(ViewData["DataSourceParametersParentUrl"]), IsDDAdd = ViewBag.IsDDAdd }, FormMethod.Post, new { enctype = "multipart/form-data" }))
{
   
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
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

WriteLiteral(" id=\"errorContainer\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"errorsMsg\"");

WriteLiteral("></div>\r\n        <div");

WriteLiteral(" id=\"errors\"");

WriteLiteral("></div>\r\n    </div>\r\n");

            
            #line 31 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
	

            
            #line default
            #line hidden
WriteLiteral("\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n               <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">         \r\n\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvArgumentName\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 39 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.ArgumentName));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 42 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.TextBoxFor(model => model.ArgumentName, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 43 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.ArgumentName));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<div" +
"");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvArgumentValue\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 49 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.ArgumentValue));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 52 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.TextBoxFor(model => model.ArgumentValue, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 53 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.ArgumentValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<div" +
"");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvHostingEntity\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 59 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.HostingEntity));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 62 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.TextBoxFor(model => model.HostingEntity, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 63 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.HostingEntity));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n         " +
"                   <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvflag\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >\r\n");

WriteLiteral("                                    ");

            
            #line 70 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.LabelFor(model => model.flag));

            
            #line default
            #line hidden
WriteLiteral(" \r\n                                </label>\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                                    ");

WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 74 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.CheckBox("flag", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 75 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.flag));

            
            #line default
            #line hidden
WriteLiteral("\t\t\r\n\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n                     " +
"       </div>\r\n\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvother\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 81 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.other));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 84 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.TextBoxFor(model => model.other, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 85 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.other));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t <div" +
"");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvEntityDataSourceParametersID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 91 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                                                                  Write(Html.LabelFor(model => model.EntityDataSourceParametersID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 94 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                               Write(Html.DropDownList("EntityDataSourceParametersID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "EntityDataSource", @dataurl = Url.Action("GetAllValue", "EntityDataSource",new { caller = "EntityDataSourceParametersID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 95 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                           Write(Html.ValidationMessageFor(model => model.EntityDataSourceParametersID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 96 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
								
            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                                 if ( User.CanAdd("EntityDataSource"))
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                <div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn ie8fix\"");

WriteLiteral("  data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5641), Tuple.Create("\"", 5960)
            
            #line 99 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                           , Tuple.Create(Tuple.Create("", 5651), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Entity Data Source','dvPopup','" + Url.Action("CreateQuick", "EntityDataSource", new { UrlReferrer = Request.Url, HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]), IsAddPop=true }) + "')")
            
            #line default
            #line hidden
, 5651), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-plus-sign\"");

WriteLiteral("></span>\r\n                                    </a>\r\n                             " +
"   </div>\r\n");

            
            #line 103 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
								}

            
            #line default
            #line hidden
WriteLiteral("                            </div>\r\n\t\t\t\t\t\t\t</div>\r\n                        </div>" +
"\r\n                    </div>\r\n       </div>\r\n                        </div>\r\n   " +
"                 </div>\r\n                </div>\r\n        </div>\r\n");

            
            #line 113 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
          
            
            #line default
            #line hidden
            
            #line 113 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
     Write(Html.ActionLink("Cancel", "Cancel", new { UrlReferrer = ViewData["DataSourceParametersParentUrl"] }, new { @onclick = "", @class = "btn btn-default btn-sm" }));

            
            #line default
            #line hidden
            
            #line 113 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                                                                                                                                                                         

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" />\r\n");

            
            #line 115 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
    if (ViewBag.IsDDAdd == null && User.CanEdit("DataSourceParameters"))
    {

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" />\r\n");

            
            #line 118 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("\t <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

WriteLiteral("\t<br/>");

WriteLiteral("<br/>\r\n");

            
            #line 121 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
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
	<script>
            $(""input[type='submit']"").click(function () {
                var $this = $(this);
                $('input:hidden[name=""hdncommand""]').val($this.val());
            });
	</script>
");

            
            #line 147 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
  
    var businessrule = User.businessrules.Where(p => p.EntityName == "DataSourceParameters").ToList();
    if ((businessrule != null && businessrule.Count > 0))
    {

            
            #line default
            #line hidden
WriteLiteral("        <script>\r\n            $(\"form\").submit(function () {\r\n                var" +
" flag = true;\r\n                \r\n                $.ajax({\r\n                    a" +
"sync: false,\r\n                    type: \"GET\",\r\n                    url: \"");

            
            #line 158 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
                     Write(Url.Action("GetMandatoryProperties", "DataSourceParameters"));

            
            #line default
            #line hidden
WriteLiteral(@""",
                    data: $(this).serialize(),
                     success: function (data) {
                        $('[businessrule=""mandatory""]').each(function () {
                            $(this).removeAttr('required');
                        });
                        document.getElementById('ErrMsg').innerHTML = """";
                        for (var key in data) {
                            if ($.trim($('#' + key).val()).length == 0 && $.trim($(""input[type='radio'][name='"" + key + ""']:checked"").val()).length == 0)
                            {
                                $('#' + key).attr('required', 'required');
                                $('#' + key).attr('businessrule', 'mandatory');
                                $(""input[type='radio'][name='"" + key + ""']"").attr('required', 'required');
                                $(""input[type='radio'][name='"" + key + ""']"").attr('businessrule', 'mandatory');
                                flag = false;
                                document.getElementById('ErrMsg').innerHTML += data[key] + "" is Mandatory.<br/>"";
                            }
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                    }
                });
                return flag;
            });
        </script>
");

            
            #line 183 "..\..\Views\DataSourceParameters\CreatePartial.cshtml"
    }
    else
    {
           
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591