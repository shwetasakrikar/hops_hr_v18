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

namespace GeneratorBase.MVC.Views.ImportConfiguration
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
    
    #line 2 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ImportConfiguration/EditWizard.cshtml")]
    public partial class EditWizard : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.ImportConfiguration>
    {
        
        #line 6 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        if (User.CanEdit("ImportConfiguration", Property))
        {
            return new { @class = "form-control" };
        } return new { @class = "form-control", @readonly = "readonly" };
    }

        #line default
        #line hidden
        
        public EditWizard()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
  
    ViewBag.Title = "Edit Import Configuration";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 15 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
 using (Html.BeginForm("EditWizard", "ImportConfiguration", new { UrlReferrer = Convert.ToString(ViewData["ImportConfigurationParentUrl"]) }, FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                      
    
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                  

            
            #line default
            #line hidden
WriteLiteral("    <label");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" class=\"text-primary small pull-right\"");

WriteLiteral(" style=\"color:red; vertical-align:middle; font-weight:100;\"");

WriteLiteral("></label>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <br />\r\n        <div");

WriteLiteral(" id=wizard");

WriteLiteral(">\r\n            <ol>\r\n                <li>General</li>\r\n            </ol>\r\n       " +
"     <div");

WriteLiteral(" style=\"background-color:transparent; padding:0px;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"icon-calendar\"");

WriteLiteral("></i>\r\n                                <h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">General</h3>\r\n                            </div>\r\n                            <d" +
"iv");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n");

            
            #line 38 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 38 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                 if (User.CanView("ImportConfiguration", "TableColumn"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 42 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                  Write(Html.LabelFor(model => model.TableColumn));

            
            #line default
            #line hidden
WriteLiteral("   </label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 44 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.TextBoxFor(model => model.TableColumn, getHtmlAttributes("TableColumn")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                ");

            
            #line 45 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.TableColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </div>\r\n                           " +
"             </div>\r\n                                    </div>\r\n");

            
            #line 49 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                }
                                else
                                { 
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                             Write(Html.HiddenFor(model => model.TableColumn, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                                              }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 52 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                 if (User.CanView("ImportConfiguration", "SheetColumn"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 56 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                  Write(Html.LabelFor(model => model.SheetColumn));

            
            #line default
            #line hidden
WriteLiteral("   </label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 58 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.TextBoxFor(model => model.SheetColumn, getHtmlAttributes("SheetColumn")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                ");

            
            #line 59 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.SheetColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </div>\r\n                           " +
"             </div>\r\n                                    </div>\r\n");

            
            #line 63 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                }
                                else
                                { 
            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                             Write(Html.HiddenFor(model => model.SheetColumn, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                                              }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 66 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                 if (User.CanView("ImportConfiguration", "UniqueColumn"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 70 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                  Write(Html.LabelFor(model => model.UniqueColumn));

            
            #line default
            #line hidden
WriteLiteral("   </label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 72 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.TextBoxFor(model => model.UniqueColumn, getHtmlAttributes("UniqueColumn")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                ");

            
            #line 73 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.UniqueColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </div>\r\n                           " +
"             </div>\r\n                                    </div>\r\n");

            
            #line 77 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                }
                                else
                                { 
            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                             Write(Html.HiddenFor(model => model.UniqueColumn, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                                               }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 80 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                 if (User.CanView("ImportConfiguration", "LastUpdate"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 84 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                  Write(Html.LabelFor(model => model.LastUpdate));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(" id=\"datetimepickerLastUpdate\"");

WriteLiteral(" style=\"padding-left:0px; padding-right:5px\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                    ");

            
            #line 87 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                               Write(Html.TextBox("CurrentDateTime", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), new { @class = "form-control", @readonly = "readonly" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </div>\r\n                       " +
"                         <div");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(" style=\"padding-left:0px; padding-right:0px\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                    ");

            
            #line 90 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                               Write(Html.TextBox("CurrentUser", HttpContext.Current.User.Identity.Name, new { @class = "form-control", @readonly = "readonly" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </div>\r\n                       " +
"                     </div>\r\n                                        </div>\r\n   " +
"                                 </div>\r\n");

            
            #line 95 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 96 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                 if (User.CanView("ImportConfiguration", "Name"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 100 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                  Write(Html.LabelFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("   </label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 102 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.TextBoxFor(model => model.Name, getHtmlAttributes("Name")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                ");

            
            #line 103 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </div>\r\n                           " +
"             </div>\r\n                                    </div>\r\n");

            
            #line 107 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                }
                                else
                                { 
            
            #line default
            #line hidden
            
            #line 109 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                             Write(Html.HiddenFor(model => model.Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 109 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                                       }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 110 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                 if (User.CanView("ImportConfiguration", "MappingName"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 114 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                  Write(Html.LabelFor(model => model.MappingName));

            
            #line default
            #line hidden
WriteLiteral("   </label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 116 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.TextBoxFor(model => model.MappingName, getHtmlAttributes("MappingName")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                ");

            
            #line 117 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.MappingName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </div>\r\n                           " +
"             </div>\r\n                                    </div>\r\n");

            
            #line 121 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                }
                                else
                                { 
            
            #line default
            #line hidden
            
            #line 123 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                             Write(Html.HiddenFor(model => model.MappingName, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 123 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                                              }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 124 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                 if (User.CanView("ImportConfiguration", "IsDefaultMapping"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 128 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                  Write(Html.LabelFor(model => model.IsDefaultMapping));

            
            #line default
            #line hidden
WriteLiteral("   </label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 130 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.CheckBoxFor(model => model.IsDefaultMapping));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                ");

            
            #line 131 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                           Write(Html.ValidationMessageFor(model => model.IsDefaultMapping));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </div>\r\n                           " +
"             </div>\r\n                                    </div>\r\n");

            
            #line 135 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                }
                                else
                                { 
            
            #line default
            #line hidden
            
            #line 137 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                             Write(Html.HiddenFor(model => model.IsDefaultMapping, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 137 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                                                                                                                   }

            
            #line default
            #line hidden
WriteLiteral("                            </div>\r\n                        </div>\r\n             " +
"       </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        ");

            
            #line 144 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
   Write(Html.ActionLink("C", "Cancel", new { UrlReferrer = ViewData["ImportConfigurationParentUrl"] }, new { @id = "cancel", @style = "display:none;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n    </div>\r\n");

WriteLiteral("    <br />\r\n");

            
            #line 148 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral(@"<script>
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

            
            #line 174 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
  
    var busineesrule = User.businessrules.Where(p => p.EntityName == "ImportConfiguration").ToList();
    if ((busineesrule != null && busineesrule.Count > 0))
    {

            
            #line default
            #line hidden
WriteLiteral("        <script>\r\n            $(document).ready(function () {\r\n                $." +
"ajax({\r\n                    async: false,\r\n                    type: \"GET\",\r\n   " +
"                 url: \"");

            
            #line 183 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                     Write(Url.Action("GetLockBusinessRules", "ImportConfiguration"));

            
            #line default
            #line hidden
WriteLiteral(@""",
                    data: $(""form"").serialize(),
                    success: function (data) {
                        if (data.length > 0) {
                            $(':input:not([readonly])', 'form').attr('disabled', 'disabled').attr('readonly', 'readonly').trigger(""chosen:updated"");
                            document.getElementById('ErrMsg').innerHTML = data + "" Rules applied"";
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert(JSON.stringify(jqXHR));
                        alert(errorThrown);
                    }
                });
                $.ajax({
                    async: false,
                    type: ""GET"",
                    url: """);

            
            #line 199 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                     Write(Url.Action("GetReadOnlyProperties", "ImportConfiguration"));

            
            #line default
            #line hidden
WriteLiteral(@""",
                    data: $(""form"").serialize(),
                    success: function (data) {
                        for (var key in data) {
                            $('#' + key).attr('disabled', 'disabled').attr('readonly', 'readonly').trigger(""chosen:updated"");
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                    }
                });
            });
        </script>
");

WriteLiteral("        <script>\r\n            $(\"form\").submit(function () {\r\n                var" +
" flag = true;\r\n                $.ajax({\r\n                    async: false,\r\n    " +
"                type: \"GET\",\r\n                    url: \"");

            
            #line 217 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
                     Write(Url.Action("GetMandatoryProperties", "ImportConfiguration"));

            
            #line default
            #line hidden
WriteLiteral(@""",
                    data: $(this).serialize(),
                    success: function (data) {
                        document.getElementById('ErrMsg').innerHTML = """";
                        for (var key in data) {
                            if ($.trim($('#' + key).val()).length == 0) {
                                $('#' + key).attr('required', 'required');
                                flag = false;
                                document.getElementById('ErrMsg').innerHTML += data[key] + "" is Mandatory.<br/>"";
                            }
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                    }
                });
                if (flag)
                    $(""form"").find(':input').removeAttr('disabled');
                return flag;
            });
        </script>
");

            
            #line 237 "..\..\Views\ImportConfiguration\EditWizard.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
