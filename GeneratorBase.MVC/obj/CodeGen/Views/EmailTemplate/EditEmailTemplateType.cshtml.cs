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

namespace GeneratorBase.MVC.Views.EmailTemplate
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EmailTemplate/EditEmailTemplateType.cshtml")]
    public partial class EditEmailTemplateType : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.EmailTemplateType>
    {
        public EditEmailTemplateType()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
  
    ViewBag.Title = "Edit Email Template Type";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
 using (Html.BeginForm("EditEmailTemplateType", "EmailTemplate", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                                      
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                                                  

            
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

            
            #line 20 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                                  Write(Html.LabelFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

            
            #line 21 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                                 if (!Model.IsDefault)
                                {
                                    
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                               Write(Html.TextBoxFor(model => model.Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                                                                                                          
                                    
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                               Write(Html.ValidationMessageFor(model => model.Name));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                                                                                   
                                }
                                else
                                {
                                    
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                               Write(Html.DisplayFor(model => model.Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                                                                                                          
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </div>\r\n                        </div>\r\n");

WriteLiteral("                        ");

            
            #line 32 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
                   Write(Html.HiddenFor(model => model.IsDefault));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        ");

WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n       " +
" </div>\r\n    </div>\r\n");

WriteLiteral("    <button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

WriteLiteral("    <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" onclick=\"QuickAddFromIndex(event,true,\'EmailTemplate\',\'null\',\'null\',0);\"");

WriteLiteral(" />\r\n");

            
            #line 47 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
}

            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\EmailTemplate\EditEmailTemplateType.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
