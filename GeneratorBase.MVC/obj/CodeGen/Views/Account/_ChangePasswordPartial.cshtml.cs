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

namespace GeneratorBase.MVC.Views.Account
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
    
    #line 1 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
    using Microsoft.AspNet.Identity;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/_ChangePasswordPartial.cshtml")]
    public partial class ChangePasswordPartial : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.ManageUserViewModel>
    {
        public ChangePasswordPartial()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
  
    Layout = "~/Views/Shared/_Layoutpwd.cshtml";
    var msg = String.IsNullOrEmpty(ViewBag.StatusMessage) ? "" : ViewBag.StatusMessage;
    var changemsg = String.IsNullOrEmpty(ViewBag.ChangeMessage) ? "" : ViewBag.ChangeMessage;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(" style=\"padding:0px; margin:0px;\"");

WriteLiteral(">\r\n");

            
            #line 14 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
     if (ViewBag.token == null)
    {

            
            #line default
            #line hidden
WriteLiteral("        <label");

WriteLiteral(" class=\"label label-primary\"");

WriteLiteral(" style=\"display:block; text-align:left; padding:8px; margin-bottom:8px; font-size" +
":14px;\"");

WriteLiteral(">You\'re logged in as <strong>");

            
            #line 16 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                                                                                                                          Write(User.Identity.Name);

            
            #line default
            #line hidden
WriteLiteral("</strong></label>\r\n");

            
            #line 17 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    <label");

WriteLiteral(" id=\'lblMsg\'");

WriteLiteral(">");

            
            #line 18 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                  Write(msg);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 20 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
        
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
         using (Html.BeginForm("Manage", "Account", FormMethod.Post, new { @class = "form-horizontal", role = "form", id = "frmChangePassword" }))
        {
            
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                    ;
            
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
       Write(Html.ValidationSummary());

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                     ;
                                     Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"panel-heading clearfix \"");

WriteLiteral(" style=\"margin:0px; padding:8px;\"");

WriteLiteral(">\r\n                                                Change Password Form\r\n        " +
"                                    </div>\r\n                                    " +
"        <div");

WriteLiteral(" class=\"panel-body  AppForm\"");

WriteLiteral(">\r\n");

            
            #line 31 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                 if (ViewBag.token == null)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                        ");

            
            #line 34 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                   Write(Html.LabelFor(m => m.OldPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                        <div");

WriteLiteral(" class=\"col-md-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                            ");

            
            #line 36 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                       Write(Html.PasswordFor(m => m.OldPassword, new { @class = "form-control", @required = "required" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                        </div>\r\n               " +
"                                     </div>\r\n");

            
            #line 39 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                }
                                                else
                                                {
                                                    
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                               Write(Html.Hidden("OldPassword", "OldPassword"));

            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                                                              
                                                    
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                               Write(Html.HiddenFor(m => m.token, new { @Value = ViewBag.token }));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                                                                                 
                                                    
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                               Write(Html.HiddenFor(m => m.provider, new { @Value = ViewBag.provider }));

            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                                                                                       
                                                }

            
            #line default
            #line hidden
WriteLiteral("                                                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                    ");

            
            #line 47 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                               Write(Html.LabelFor(m => m.NewPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    <div");

WriteLiteral(" class=\"col-md-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                        ");

            
            #line 49 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                   Write(Html.PasswordFor(m => m.NewPassword, new { @class = "form-control", @required = "required" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </div>\r\n                   " +
"                             </div>\r\n                                           " +
"     <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                    ");

            
            #line 53 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                               Write(Html.LabelFor(m => m.ConfirmPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    <div");

WriteLiteral(" class=\"col-md-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                        ");

            
            #line 55 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                   Write(Html.PasswordFor(m => m.ConfirmPassword, new { @class = "form-control", @required = "required" }));

            
            #line default
            #line hidden
WriteLiteral(@"
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!--Islahuddin-->
                                        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"btnchangepassword\"");

WriteLiteral(" value=\"Change password\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" onclick=\"changepassword(this);\"");

WriteLiteral(" />\r\n                                        ");

WriteLiteral("\r\n");

            
            #line 63 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 63 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                         if (ViewBag.token == null)
                                        {
                                            
            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                       Write(Html.ActionLink("Home", "Index", "Home", null, new { @class = "btn btn-default btn-sm" }));

            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                                                                                                                                      
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </div>\r\n");

            
            #line 68 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n    <br /><br />\r\n</div>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 4703), Tuple.Create("\"", 4744)
            
            #line 74 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
, Tuple.Create(Tuple.Create("", 4709), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 4709), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 4787), Tuple.Create("\"", 4826)
            
            #line 75 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
, Tuple.Create(Tuple.Create("", 4793), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 4793), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@"></script>
<script>
    //$(""input[type='button']"").click(function (event) {
    //$('#changepasword').click(function () {
    //$('#changepassword').bind('click', function () {
    //    $('#textToReset').text('');
    //    return false;
    //})
    $(document).ready(function () {
        var message = '");

            
            #line 84 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                  Write(changemsg);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n        if (message == \"OK\") {\r\n            $(\"#lblMsg\").text(\"Your password " +
"has been changed successfully.\");\r\n            alert(\'Your password has been cha" +
"nged successfully.\');\r\n            window.location.href = \'");

            
            #line 88 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                               Write(Url.Action("Index","Home"));

            
            #line default
            #line hidden
WriteLiteral(@"';
        } else if (message == ""OK1"") {
            $(""#lblMsg"").text(""Your password has been changed successfully. Please Log in application."");
            alert('Your password has been changed successfully. Please Log in application.');
            window.location.href = '");

            
            #line 92 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                               Write(Url.Action("Index","Home"));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n        }\r\n    });\r\n    function changepassword(e) {\r\n        e.preventDefaul" +
"t();\r\n        $(\"#lblMsg\").text(\'\');\r\n        if (!($(\'#frmChangePassword\').vali" +
"d())) return;\r\n        $.ajax({\r\n            url: \'");

            
            #line 100 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
             Write(Url.Action("Manage", "Account"));

            
            #line default
            #line hidden
WriteLiteral("\',\r\n            type: \"POST\",\r\n            cache: false,\r\n            data: $(\'#f" +
"rmChangePassword\').serialize(),\r\n            success: function (result) {\r\n     " +
"           var message = \'");

            
            #line 105 "..\..\Views\Account\_ChangePasswordPartial.cshtml"
                          Write(changemsg);

            
            #line default
            #line hidden
WriteLiteral(@"';
                if (result == ""OK"") {
                    $(""#lblMsg"").text(""Your password has been changed successfully."");
                    alert('Your password has been changed successfully.');
                    window.location = '/Home';
                }
                else {
                    window.location = '/Account/Manage';
                    $(""#lblMsg"").text(result.Errors.toString());
                }
            },
            error: function () {
                alert('error');
            }
        });
        //var isValid = $('#frmChangePassword').valid();
        //if (!isValid) {
        //    event.preventDefault();
        //}
        //else {

        //    alert(""Password changed successfully !"");
        //    //event.preventDefault();
        //}
    }
</script>
");

        }
    }
}
#pragma warning restore 1591
