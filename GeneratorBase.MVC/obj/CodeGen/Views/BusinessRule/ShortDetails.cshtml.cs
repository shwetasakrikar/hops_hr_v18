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

namespace GeneratorBase.MVC.Views.BusinessRule
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
    
    #line 2 "..\..\Views\BusinessRule\ShortDetails.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/BusinessRule/ShortDetails.cshtml")]
    public partial class ShortDetails : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.BusinessRule>
    {
        public ShortDetails()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\BusinessRule\ShortDetails.cshtml"
  
    ViewBag.Title = "View Business Rule";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(\"#shortdetails\").on(\"mouseleave\", function () {\r\n        $(\"#cl" +
"oseshortdetails\").click();\r\n    })\r\n</script>\r\n<div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n        Roles : ");

            
            #line 14 "..\..\Views\BusinessRule\ShortDetails.cshtml"
           Write(Model.Roles);

            
            #line default
            #line hidden
WriteLiteral("<br />\r\n");

            
            #line 15 "..\..\Views\BusinessRule\ShortDetails.cshtml"
        
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\BusinessRule\ShortDetails.cshtml"
         foreach (var cond in Model.ruleconditions)
        {
            if (cond.PropertyName == "Id" && cond.Operator == ">" && cond.Value == "0")
            {

            
            #line default
            #line hidden
WriteLiteral("                <span>Condition : </span>");

WriteLiteral("<b>Always  </b>");

WriteLiteral("<br />\r\n");

            
            #line 20 "..\..\Views\BusinessRule\ShortDetails.cshtml"
            }
            else
            {

            
            #line default
            #line hidden
WriteLiteral("                <span>Condition : </span>");

WriteLiteral("<b>");

            
            #line 23 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                       Write(cond.PropertyName);

            
            #line default
            #line hidden
WriteLiteral("  ");

            
            #line 23 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                                           Write(cond.Operator);

            
            #line default
            #line hidden
WriteLiteral("  ");

            
            #line 23 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                                                           Write(cond.Value);

            
            #line default
            #line hidden
WriteLiteral("  </b>");

WriteLiteral("<br />\r\n");

            
            #line 24 "..\..\Views\BusinessRule\ShortDetails.cshtml"
            }
        }

            
            #line default
            #line hidden
WriteLiteral("        <br />\r\n");

            
            #line 27 "..\..\Views\BusinessRule\ShortDetails.cshtml"
        
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\BusinessRule\ShortDetails.cshtml"
         if (Model.ruleaction != null)
        {
            foreach (var act in Model.ruleaction)
            {
                if (act.associatedactiontype != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <b><span>Action : </span>");

            
            #line 33 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                        Write(act.associatedactiontype.DisplayValue);

            
            #line default
            #line hidden
WriteLiteral(" </b>\r\n");

WriteLiteral("                    <br />\r\n");

WriteLiteral("                    <b><span>Is Else Action : </span>");

            
            #line 35 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                                Write(act.IsElseAction);

            
            #line default
            #line hidden
WriteLiteral("</b>\r\n");

            
            #line 36 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                }
                if (act.actionarguments != null && act.actionarguments.Count() > 0)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" id=\"Des_Table\"");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(" style=\"overflow-x:auto;\"");

WriteLiteral(">\r\n                        <table");

WriteLiteral(" class=\"table table-striped table-bordered table-hover table-condensed\"");

WriteLiteral(">\r\n                            <thead>\r\n                                <tr>\r\n   " +
"                                 <th");

WriteLiteral(" class=\"col1\"");

WriteLiteral(">Parameter Name</th>\r\n                                    <th");

WriteLiteral(" class=\"col1\"");

WriteLiteral(">Value</th>\r\n                                </tr>\r\n                            <" +
"/thead>\r\n");

            
            #line 47 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                             foreach (var args in act.actionarguments)
                            {
                                var paramName = args.ParameterName;
                                if (args.ParameterValue == "GroupsHidden")
                                {
                                    paramName = args.ParameterName.Remove(0, args.ParameterName.IndexOf('|') + 1);
                                }

            
            #line default
            #line hidden
WriteLiteral("                                <tr>\r\n                                    <td>\r\n");

WriteLiteral("                                        ");

            
            #line 56 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                   Write(paramName);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td>\r\n");

            
            #line 59 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                         if (args.ParameterName == "NotifyToRole")
                                        {
                                            
            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                       Write(act.getRolesNameById(args.ParameterValue));

            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                                                                      ;
                                        }
                                        else
                                        {
                                            
            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                       Write(args.ParameterValue);

            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                                                                
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\r\n                                </tr>\r" +
"\n");

            
            #line 69 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </table>\r\n                    </div>\r\n");

WriteLiteral("                    <br />\r\n");

            
            #line 73 "..\..\Views\BusinessRule\ShortDetails.cshtml"
                }
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
