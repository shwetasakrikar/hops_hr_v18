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

namespace GeneratorBase.MVC.Views.Condition
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
    
    #line 2 "..\..\Views\Condition\ExcelExport.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Condition/ExcelExport.cshtml")]
    public partial class ExcelExport : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.Condition>>
    {
        public ExcelExport()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Condition\ExcelExport.cshtml"
  
    ViewBag.Title = "Index";
    Layout = null;
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment; filename=Condition.xls");

            
            #line default
            #line hidden
WriteLiteral("\r\n<table>\r\n    <tr>\r\n");

            
            #line 11 "..\..\Views\Condition\ExcelExport.cshtml"
        
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\Condition\ExcelExport.cshtml"
         if (User.CanView("Condition", "PropertyName"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>Property Name</th>\r\n");

            
            #line 14 "..\..\Views\Condition\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 15 "..\..\Views\Condition\ExcelExport.cshtml"
         if (User.CanView("Condition", "Operator"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>Operator</th>\r\n");

            
            #line 18 "..\..\Views\Condition\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 19 "..\..\Views\Condition\ExcelExport.cshtml"
         if (User.CanView("Condition", "Value"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>Value</th>\r\n");

            
            #line 22 "..\..\Views\Condition\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 23 "..\..\Views\Condition\ExcelExport.cshtml"
         if (User.CanView("Condition", "LogicalConnector"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>Logical Connector</th>\r\n");

            
            #line 26 "..\..\Views\Condition\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 27 "..\..\Views\Condition\ExcelExport.cshtml"
         if (User.CanView("Condition", "RuleConditionsID"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th ");

            
            #line 29 "..\..\Views\Condition\ExcelExport.cshtml"
            Write(Convert.ToString(ViewData["HostingEntity"]) == "BusinessRule" ? "hidden" : "");

            
            #line default
            #line hidden
WriteLiteral(">Business Rule</th>\r\n");

            
            #line 30 "..\..\Views\Condition\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n");

            
            #line 32 "..\..\Views\Condition\ExcelExport.cshtml"
    
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Condition\ExcelExport.cshtml"
     foreach (var item in Model)
    {

            
            #line default
            #line hidden
WriteLiteral("        <tr>\r\n");

            
            #line 35 "..\..\Views\Condition\ExcelExport.cshtml"
            
            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\Condition\ExcelExport.cshtml"
             if (User.CanView("Condition", "PropertyName"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td>\r\n");

WriteLiteral("                    ");

            
            #line 38 "..\..\Views\Condition\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.PropertyName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 40 "..\..\Views\Condition\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 41 "..\..\Views\Condition\ExcelExport.cshtml"
             if (User.CanView("Condition", "Operator"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td>\r\n");

WriteLiteral("                    ");

            
            #line 44 "..\..\Views\Condition\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.Operator));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 46 "..\..\Views\Condition\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 47 "..\..\Views\Condition\ExcelExport.cshtml"
             if (User.CanView("Condition", "Value"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td>\r\n");

WriteLiteral("                    ");

            
            #line 50 "..\..\Views\Condition\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 52 "..\..\Views\Condition\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 53 "..\..\Views\Condition\ExcelExport.cshtml"
             if (User.CanView("Condition", "LogicalConnector"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td>\r\n");

WriteLiteral("                    ");

            
            #line 56 "..\..\Views\Condition\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.LogicalConnector));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 58 "..\..\Views\Condition\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 59 "..\..\Views\Condition\ExcelExport.cshtml"
             if (User.CanView("Condition", "RuleConditionsID"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td ");

            
            #line 61 "..\..\Views\Condition\ExcelExport.cshtml"
                Write(Convert.ToString(ViewData["HostingEntity"]) == "BusinessRule" ? "hidden" : "");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 62 "..\..\Views\Condition\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.ruleconditions.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 64 "..\..\Views\Condition\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tr>\r\n");

            
            #line 66 "..\..\Views\Condition\ExcelExport.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n");

        }
    }
}
#pragma warning restore 1591
