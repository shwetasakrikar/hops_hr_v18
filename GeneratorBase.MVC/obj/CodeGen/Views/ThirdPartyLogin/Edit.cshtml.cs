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

namespace GeneratorBase.MVC.Views.ThirdPartyLogin
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ThirdPartyLogin/Edit.cshtml")]
    public partial class Edit : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.ThirdPartyLogin>
    {
        
        #line 5 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        return new { @class = "form-control" };
    }

        #line default
        #line hidden
        
        public Edit()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
  
    ViewBag.Title = "Edit Third Party Login Settings";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-edit text-primary\"");

WriteLiteral("></i> Third Party Login Settings Information  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span>Edit</span>\r\n        </h1>\r\n    </div>\r\n</div>\r\n");

            
            #line 18 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
 using (Html.BeginForm("Edit", "ThirdPartyLogin", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                            

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(" style=\"margin:0px; padding:0px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">GooglePlus Credentials </h3> <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default pull-right btnsmall\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-target=\"#GoogleHelp\"");

WriteLiteral("> Help <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></button>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"GoogleHelp\"");

WriteLiteral(" class=\"collapse\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-sm-12 col-md-12\"");

WriteLiteral(" style=\"margin:-20px 0px 0px 0px; padding:0px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"alert-message alert-message-warning\"");

WriteLiteral(@">
                            <h4>
                                Steps to create a client ID and client secret key:
                            </h4>
                            <ul>
                                <li>Create a Google Developers Console project</li>
                                <li>Enable the Google+ API, create an OAuth 2.0 client ID</li>
                                <li>Register your JavaScript origins and redirect URI</li>
                            </ul>
                            For more details follow Step1 of this <a");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(" href=\"https://developers.google.com/+/web/signin/redirect-uri-flow\"");

WriteLiteral(@">URL</a>
                            <br /><br />
                            <ul>
                                <li>
                                    <b>App Domains </b>should be your domain name e.g.
                                    <b>mvc.turanto.com</b>
                                </li>
                                <li><b>Site URL </b> should be <b>http://DomainName/ </b> e.g. <b>http://mvc.turanto.com/</b></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n                <div");

WriteLiteral(" class=\"alert alert-success\"");

WriteLiteral(">\r\n                    Please add GooglePlus third party authentication credentia" +
"ls for your application.\r\n                </div>\r\n                <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(">");

            
            #line 56 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                                                              Write(Html.LabelFor(model => model.GooglePlusId));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span> </label>\r\n                        <div");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 58 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                       Write(Html.TextBoxFor(model => model.GooglePlusId, getHtmlAttributes("GooglePlusId")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 59 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                       Write(Html.ValidationMessageFor(model => model.GooglePlusId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n                <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(">");

            
            #line 65 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                                                              Write(Html.LabelFor(model => model.GooglePlusSecretKey));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span> </label>\r\n                        <div");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 67 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                       Write(Html.TextBoxFor(model => model.GooglePlusSecretKey, getHtmlAttributes("GooglePlusSecretKey")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 68 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                       Write(Html.ValidationMessageFor(model => model.GooglePlusSecretKey));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n            </div>\r\n                                </div>\r\n               " +
"             </div>\r\n");

WriteLiteral("                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n                                            <h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">Facebook Credentials </h3> <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default pull-right btnsmall\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-target=\"#FacebookHelp\"");

WriteLiteral("> Help <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></button>\r\n                                        </div>\r\n              " +
"                          <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" id=\"FacebookHelp\"");

WriteLiteral(" class=\"collapse\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"col-sm-12 col-md-12\"");

WriteLiteral(" style=\"margin:-20px 0px 0px 0px; padding:0px;\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\"alert-message alert-message-warning\"");

WriteLiteral(@">
                                                        <h4>
                                                            Steps to create a client ID and client secret key:
                                                        </h4>
                                                        <ul>
                                                            <li><strong>Create New App : </strong> Fill all details under Settings option</li>
                                                        </ul>
                                                                        For more details visit this
                                                                   <a");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(" href=\"http://www.asp.net/mvc/overview/security/create-an-aspnet-mvc-5-app-with-f" +
"acebook-and-google-oauth2-and-openid-sign-on#fb\"");

WriteLiteral(@">URL</a>
                                                        <br /><br />
                                                        <ul>
                                                            <li>
                                                                <b>App Domains </b>should be your domain name e.g.
                                                                <b>mvc.turanto.com</b>
                                                            </li>
                                                            <li><b>Site URL </b> should be <b>http://DomainName/ </b> e.g. <b>http://mvc.turanto.com/</b></li>
                                                        </ul>
                                                     </div>
                                                </div>
                                            </div>
                                            <div");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n                                            <div");

WriteLiteral(" class=\"alert alert-success\"");

WriteLiteral(">\r\n                                                Please add Facebook third part" +
"y authentication credentials for your application.\r\n                            " +
"                </div>\r\n                                            <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                    <label");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(">");

            
            #line 110 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                                                                                          Write(Html.LabelFor(model => model.FacebookId));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span> </label>\r\n                                                    <div");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                        ");

            
            #line 112 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                                                   Write(Html.TextBoxFor(model => model.FacebookId, getHtmlAttributes("FacebookId")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                        ");

            
            #line 113 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.FacebookId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </div>\r\n                   " +
"                             </div>\r\n                                           " +
" </div>\r\n                                            <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                    <label");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(">");

            
            #line 119 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                                                                                          Write(Html.LabelFor(model => model.FacebookSecretKey));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span> </label>\r\n                                                    <div");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                        ");

            
            #line 121 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                                                   Write(Html.TextBoxFor(model => model.FacebookSecretKey, getHtmlAttributes("FacebookSecretKey")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                        ");

            
            #line 122 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.FacebookSecretKey));

            
            #line default
            #line hidden
WriteLiteral(@"
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
");

            
            #line 130 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 130 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                       Write(Html.ActionLink("Back to Admin Settings", "Index", "Admin", null, new { @class = "btn btn-default btn-sm" }));

            
            #line default
            #line hidden
            
            #line 130 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
                                                                                                                                         

            
            #line default
            #line hidden
WriteLiteral("                            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" /> ");

WriteLiteral("<br />");

WriteLiteral("<br />\r\n");

            
            #line 132 "..\..\Views\ThirdPartyLogin\Edit.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
