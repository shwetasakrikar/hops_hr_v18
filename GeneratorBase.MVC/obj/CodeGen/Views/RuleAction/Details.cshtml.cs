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

namespace GeneratorBase.MVC.Views.RuleAction
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
    
    #line 2 "..\..\Views\RuleAction\Details.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/RuleAction/Details.cshtml")]
    public partial class Details : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.RuleAction>
    {
        public Details()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\RuleAction\Details.cshtml"
  
    ViewBag.Title = "View Rule Action";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-hand-down text-primary\"");

WriteLiteral("></i> Rule Action  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span>View</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\RuleAction\Details.cshtml"
                            Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n        <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n        <li ");

            
            #line 18 "..\..\Views\RuleAction\Details.cshtml"
        Write(!User.CanView("ActionArgs") || Model.associatedactiontype.TypeNo <= 1 ? "style=display:none;" : "");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteLiteral(" href=\"#ActionArguments\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Action Args</a></li>\r\n    </ul>\r\n    <div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"Details\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-sm-12 col-md-12 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 27 "..\..\Views\RuleAction\Details.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\RuleAction\Details.cshtml"
                                 if (User.CanView("RuleAction", "ActionName"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\RuleAction\Details.cshtml"
                                                                                  Write(Html.DisplayNameFor(model => model.ActionName));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                                                <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 33 "..\..\Views\RuleAction\Details.cshtml"
                                                                Write(Model.ActionName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                            </div>\r\n                       " +
"                 </div>\r\n                                    </div>\r\n");

            
            #line 37 "..\..\Views\RuleAction\Details.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 38 "..\..\Views\RuleAction\Details.cshtml"
                                 if (User.CanView("RuleAction", "ErrorMessage"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 42 "..\..\Views\RuleAction\Details.cshtml"
                                                                                  Write(Html.DisplayNameFor(model => model.ErrorMessage));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                                                <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 44 "..\..\Views\RuleAction\Details.cshtml"
                                                                Write(Model.ErrorMessage);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                            </div>\r\n                       " +
"                 </div>\r\n                                    </div>\r\n");

            
            #line 48 "..\..\Views\RuleAction\Details.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 49 "..\..\Views\RuleAction\Details.cshtml"
                                 if (User.CanView("RuleAction", "RuleActionID"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 53 "..\..\Views\RuleAction\Details.cshtml"
                                                                                  Write(Html.DisplayNameFor(model => model.RuleActionID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 55 "..\..\Views\RuleAction\Details.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 55 "..\..\Views\RuleAction\Details.cshtml"
                                                 if (@Model.RuleActionID == 0 || @Model.RuleActionID == null || @Model.ruleaction == null)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral("></p>\r\n");

            
            #line 58 "..\..\Views\RuleAction\Details.cshtml"
                                                }
                                                else
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 61 "..\..\Views\RuleAction\Details.cshtml"
                                                                    Write(Model.ruleaction.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 62 "..\..\Views\RuleAction\Details.cshtml"
                                                }

            
            #line default
            #line hidden
WriteLiteral("                                            </div>\r\n                             " +
"           </div>\r\n                                    </div>\r\n");

            
            #line 66 "..\..\Views\RuleAction\Details.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 67 "..\..\Views\RuleAction\Details.cshtml"
                                 if (User.CanView("RuleAction", "AssociatedActionTypeID"))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 71 "..\..\Views\RuleAction\Details.cshtml"
                                                                                  Write(Html.DisplayNameFor(model => model.AssociatedActionTypeID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                                            <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 73 "..\..\Views\RuleAction\Details.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 73 "..\..\Views\RuleAction\Details.cshtml"
                                                 if (@Model.AssociatedActionTypeID == 0 || @Model.AssociatedActionTypeID == null || @Model.associatedactiontype == null)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral("></p>\r\n");

            
            #line 76 "..\..\Views\RuleAction\Details.cshtml"
                                                }
                                                else
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 79 "..\..\Views\RuleAction\Details.cshtml"
                                                                    Write(Model.associatedactiontype.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 80 "..\..\Views\RuleAction\Details.cshtml"
                                                }

            
            #line default
            #line hidden
WriteLiteral("                                            </div>\r\n                             " +
"           </div>\r\n                                    </div>\r\n");

            
            #line 84 "..\..\Views\RuleAction\Details.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </div>\r\n                        </div>\r\n             " +
"       </div>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 92 "..\..\Views\RuleAction\Details.cshtml"
               Write(Html.ActionLink("Back to List", "Index", null, new { @class = "btn btn-default btn-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 93 "..\..\Views\RuleAction\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 93 "..\..\Views\RuleAction\Details.cshtml"
                     if ( User.CanEdit("RuleAction"))
                    {
                        
            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\RuleAction\Details.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }, new { @class = "btn btn-primary btn-sm" }));

            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\RuleAction\Details.cshtml"
                                                                                                                          
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"ActionArguments\"");

WriteLiteral(">\r\n");

            
            #line 101 "..\..\Views\RuleAction\Details.cshtml"
            
            
            #line default
            #line hidden
            
            #line 101 "..\..\Views\RuleAction\Details.cshtml"
             if ( User.CanView("ActionArgs"))
            {
                Html.RenderAction("Index", "ActionArgs", new { HostingEntity = "RuleAction", HostingEntityID = @Model.Id, AssociatedType = "ActionArguments" });
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div> <!-- /tab-content --><br />\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591