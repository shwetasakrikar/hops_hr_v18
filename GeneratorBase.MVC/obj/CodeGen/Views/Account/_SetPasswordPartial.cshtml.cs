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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/_SetPasswordPartial.cshtml")]
    public partial class SetPasswordPartial : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.ManageUserViewModel>
    {
        public SetPasswordPartial()
        {
        }
        public override void Execute()
        {
WriteLiteral("<p");

WriteLiteral(" class=\"text-info\"");

WriteLiteral(">\n    You do not have a local username/password for this site. Add a local\n    ac" +
"count so you can log in without an external login.\n</p>\n\n");

            
            #line 8 "..\..\Views\Account\_SetPasswordPartial.cshtml"
 using (Html.BeginForm("Manage", "Account", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
{
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Account\_SetPasswordPartial.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Account\_SetPasswordPartial.cshtml"
                            


            
            #line default
            #line hidden
WriteLiteral("    <h4>Create Local Login</h4>\n");

WriteLiteral("    <hr />\n");

            
            #line 14 "..\..\Views\Account\_SetPasswordPartial.cshtml"
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Account\_SetPasswordPartial.cshtml"
Write(Html.ValidationSummary());

            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Account\_SetPasswordPartial.cshtml"
                             

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\n");

WriteLiteral("        ");

            
            #line 16 "..\..\Views\Account\_SetPasswordPartial.cshtml"
   Write(Html.LabelFor(m => m.NewPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\n");

WriteLiteral("            ");

            
            #line 18 "..\..\Views\Account\_SetPasswordPartial.cshtml"
       Write(Html.PasswordFor(m => m.NewPassword, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\n        </div>\n    </div>\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\n");

WriteLiteral("        ");

            
            #line 22 "..\..\Views\Account\_SetPasswordPartial.cshtml"
   Write(Html.LabelFor(m => m.ConfirmPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\Account\_SetPasswordPartial.cshtml"
       Write(Html.PasswordFor(m => m.ConfirmPassword, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\n        </div>\n    </div>\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\n            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Set password\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\n        </div>\n    </div>\n");

            
            #line 32 "..\..\Views\Account\_SetPasswordPartial.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591