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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/UserRoles.cshtml")]
    public partial class UserRoles : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.SelectUserRolesViewModel>
    {
        public UserRoles()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Account\UserRoles.cshtml"
  
    ViewBag.Title = "User Roles";


            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-thumbs-up text-primary\"");

WriteLiteral(" style=\"margin-bottom:-20px;\"");

WriteLiteral("></i> Admin <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i>  <span> View </span> <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span>Roles for user ");

            
            #line 9 "..\..\Views\Account\UserRoles.cshtml"
                                                                                                                                                                                                                                                               Write(Html.DisplayFor(model => model.UserName));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        </h1>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(" style=\"padding:0px; margin:0px;\"");

WriteLiteral(">\r\n");

            
            #line 14 "..\..\Views\Account\UserRoles.cshtml"
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Account\UserRoles.cshtml"
     using (Html.BeginForm("UserRoles", "Account", FormMethod.Post, new { encType = "multipart/form-data", name = "myform" }))
    {
        
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Account\UserRoles.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Account\UserRoles.cshtml"
                                
        
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Account\UserRoles.cshtml"
   Write(Html.ValidationSummary(true));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Account\UserRoles.cshtml"
                                     

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"icon-calendar\"");

WriteLiteral("></i>\r\n                        <h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">Select Role Assignments</h3>\r\n                    </div>\r\n                    <d" +
"iv");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(" style=\"padding:8px; margin:0px;\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 26 "..\..\Views\Account\UserRoles.cshtml"
                   Write(Html.HiddenFor(model => model.UserName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <table");

WriteLiteral(" class=\"table table-striped table-bordered table-hover table-condensed\"");

WriteLiteral(">\r\n                            <tr>\r\n                                <th");

WriteLiteral(" style=\"width:50px; text-align:center;\"");

WriteLiteral(">\r\n                                    Select\r\n                                </" +
"th>\r\n                                <th>\r\n                                    R" +
"ole\r\n                                </th>\r\n                            </tr>\r\n");

WriteLiteral("                            ");

            
            #line 36 "..\..\Views\Account\UserRoles.cshtml"
                       Write(Html.EditorFor(model => model.Roles));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </table>\r\n                    </div>\r\n                <" +
"/div>\r\n            </div>\r\n        </div>\r\n");

            
            #line 42 "..\..\Views\Account\UserRoles.cshtml"
        
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Account\UserRoles.cshtml"
   Write(Html.Hidden("UrlReferrer", Request.UrlReferrer));

            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Account\UserRoles.cshtml"
                                                        
        if (Request.UrlReferrer != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2111), Tuple.Create("\"", 2138)
            
            #line 45 "..\..\Views\Account\UserRoles.cshtml"
, Tuple.Create(Tuple.Create("", 2118), Tuple.Create<System.Object, System.Int32>(Request.UrlReferrer
            
            #line default
            #line hidden
, 2118), false)
);

WriteLiteral(">Cancel</a>\r\n");

            
            #line 46 "..\..\Views\Account\UserRoles.cshtml"
        }
        else
        {
            
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\Account\UserRoles.cshtml"
       Write(Html.ActionLink("Back to List", "Index", null, new { @class = "btn btn-default" }));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\Account\UserRoles.cshtml"
                                                                                               
        }
        if (User.CanEditAdminFeature("AssignUserRole"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\Account\UserRoles.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n<div");

WriteLiteral(" style=\"clear:both; margin-bottom:20px;\"");

WriteLiteral("></div>\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
