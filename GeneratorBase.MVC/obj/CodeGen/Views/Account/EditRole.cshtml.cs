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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/EditRole.cshtml")]
    public partial class EditRole : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.EditRoleViewModel>
    {
        public EditRole()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Account\EditRole.cshtml"
  
    ViewBag.Title = "Edit";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-edit text-primary\"");

WriteLiteral("></i> Admin   <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span>Edit Role</span>\r\n        </h1>\r\n    </div>\r\n    <!-- /.col-lg-12 -->" +
"\r\n</div>\r\n<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(" style=\"padding:0px; margin:5px 0px 0px 0px;\"");

WriteLiteral(">\r\n");

            
            #line 14 "..\..\Views\Account\EditRole.cshtml"
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Account\EditRole.cshtml"
     using (Html.BeginForm())
    {
        
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Account\EditRole.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Account\EditRole.cshtml"
                                

            
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

WriteLiteral(">");

            
            #line 22 "..\..\Views\Account\EditRole.cshtml"
                                           Write(Model.Name);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n                    </div>\r\n");

WriteLiteral("                    ");

            
            #line 24 "..\..\Views\Account\EditRole.cshtml"
               Write(Html.HiddenFor(model => model.OriginalName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 27 "..\..\Views\Account\EditRole.cshtml"
                       Write(Html.ValidationSummary(true));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                            ");

WriteLiteral("\r\n\r\n                            <div");

WriteLiteral(" class=\"form-group col-lg-12\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"col-lg-6\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 39 "..\..\Views\Account\EditRole.cshtml"
                                      Write(Html.LabelFor(m => m.Name));

            
            #line default
            #line hidden
WriteLiteral("  <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

WriteLiteral("                                    ");

            
            #line 40 "..\..\Views\Account\EditRole.cshtml"
                               Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"col-lg-6\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 43 "..\..\Views\Account\EditRole.cshtml"
                                      Write(Html.LabelFor(m => m.Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 44 "..\..\Views\Account\EditRole.cshtml"
                               Write(Html.TextBoxFor(m => m.Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n");

WriteLiteral("                            ");

            
            #line 47 "..\..\Views\Account\EditRole.cshtml"
                       Write(Html.HiddenFor(m => m.RoleType));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 48 "..\..\Views\Account\EditRole.cshtml"
                       Write(Html.HiddenFor(m => m.TenantId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 49 "..\..\Views\Account\EditRole.cshtml"
                       Write(Html.Hidden("UrlReferrer", Request.UrlReferrer));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n            </div>\r\n        </div>\r\n");

            
            #line 55 "..\..\Views\Account\EditRole.cshtml"
        if (Request.UrlReferrer != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2708), Tuple.Create("\"", 2735)
            
            #line 57 "..\..\Views\Account\EditRole.cshtml"
, Tuple.Create(Tuple.Create("", 2715), Tuple.Create<System.Object, System.Int32>(Request.UrlReferrer
            
            #line default
            #line hidden
, 2715), false)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">Back to List</a>\r\n");

            
            #line 58 "..\..\Views\Account\EditRole.cshtml"
        }
        else
        {
            
            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\Account\EditRole.cshtml"
       Write(Html.ActionLink("Back to List", "RoleList", "Account", null, new { @class = "btn btn-default" }));

            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\Account\EditRole.cshtml"
                                                                                                             
        }

        if (User.CanEditAdminFeature("Role"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" />\r\n");

            
            #line 67 "..\..\Views\Account\EditRole.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 71 "..\..\Views\Account\EditRole.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
