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

namespace GeneratorBase.MVC.Views.JournalEntry
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
    
    #line 2 "..\..\Views\JournalEntry\ExcelExport.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/JournalEntry/ExcelExport.cshtml")]
    public partial class ExcelExport : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.JournalEntry>>
    {
        public ExcelExport()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\JournalEntry\ExcelExport.cshtml"
  
    ViewBag.Title = "Index";
    Layout = null;
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment; filename=JournalEntry.xls");

            
            #line default
            #line hidden
WriteLiteral("\r\n<table>\r\n    <tr>\r\n");

            
            #line 11 "..\..\Views\JournalEntry\ExcelExport.cshtml"
        
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\JournalEntry\ExcelExport.cshtml"
         if (User.CanView("JournalEntry", "EntityName"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>Entity Name</th>\r\n");

            
            #line 14 "..\..\Views\JournalEntry\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 15 "..\..\Views\JournalEntry\ExcelExport.cshtml"
         if (User.CanView("JournalEntry", "Type"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>Type</th>\r\n");

            
            #line 18 "..\..\Views\JournalEntry\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 19 "..\..\Views\JournalEntry\ExcelExport.cshtml"
         if (User.CanView("JournalEntry", "DateTimeOfEntry"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>DateTime Of Entry</th>\r\n");

            
            #line 22 "..\..\Views\JournalEntry\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 23 "..\..\Views\JournalEntry\ExcelExport.cshtml"
         if (User.CanView("JournalEntry", "RecordInfo"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>Record Info</th>\r\n");

            
            #line 26 "..\..\Views\JournalEntry\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 27 "..\..\Views\JournalEntry\ExcelExport.cshtml"
         if (User.CanView("JournalEntry", "UserName"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>User Name</th>\r\n");

            
            #line 30 "..\..\Views\JournalEntry\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 31 "..\..\Views\JournalEntry\ExcelExport.cshtml"
         if (User.CanView("JournalEntry", "PropertyName"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>Property Name</th>\r\n");

            
            #line 34 "..\..\Views\JournalEntry\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 35 "..\..\Views\JournalEntry\ExcelExport.cshtml"
         if (User.CanView("JournalEntry", "OldValue"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>Old Value</th>\r\n");

            
            #line 38 "..\..\Views\JournalEntry\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 39 "..\..\Views\JournalEntry\ExcelExport.cshtml"
         if (User.CanView("JournalEntry", "	NewValue"))
        {

            
            #line default
            #line hidden
WriteLiteral("            <th>New Value</th>\r\n");

            
            #line 42 "..\..\Views\JournalEntry\ExcelExport.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n");

            
            #line 44 "..\..\Views\JournalEntry\ExcelExport.cshtml"
    
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\JournalEntry\ExcelExport.cshtml"
     foreach (var item in Model)
    {

            
            #line default
            #line hidden
WriteLiteral("        <tr>\r\n");

            
            #line 47 "..\..\Views\JournalEntry\ExcelExport.cshtml"
            
            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\JournalEntry\ExcelExport.cshtml"
             if (User.CanView("JournalEntry", "EntityName"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td>\r\n");

WriteLiteral("                    ");

            
            #line 50 "..\..\Views\JournalEntry\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.EntityName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 52 "..\..\Views\JournalEntry\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 53 "..\..\Views\JournalEntry\ExcelExport.cshtml"
             if (User.CanView("JournalEntry", "Type"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td>\r\n");

WriteLiteral("                    ");

            
            #line 56 "..\..\Views\JournalEntry\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.Type));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 58 "..\..\Views\JournalEntry\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 59 "..\..\Views\JournalEntry\ExcelExport.cshtml"
             if (User.CanView("JournalEntry", "DateTimeOfEntry"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td>\r\n");

WriteLiteral("                    ");

            
            #line 62 "..\..\Views\JournalEntry\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateTimeOfEntry));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 64 "..\..\Views\JournalEntry\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("           ");

            
            #line 65 "..\..\Views\JournalEntry\ExcelExport.cshtml"
            if (User.CanView("JournalEntry", "RecordInfo"))
           {

            
            #line default
            #line hidden
WriteLiteral("            <td>\r\n");

WriteLiteral("                ");

            
            #line 68 "..\..\Views\JournalEntry\ExcelExport.cshtml"
           Write(Html.DisplayFor(modelItem => item.RecordInfo));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n");

            
            #line 70 "..\..\Views\JournalEntry\ExcelExport.cshtml"
           }

            
            #line default
            #line hidden
WriteLiteral("           ");

            
            #line 71 "..\..\Views\JournalEntry\ExcelExport.cshtml"
            if (User.CanView("JournalEntry", "UserName"))
           {

            
            #line default
            #line hidden
WriteLiteral("            <td>\r\n");

WriteLiteral("                ");

            
            #line 74 "..\..\Views\JournalEntry\ExcelExport.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserName));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n");

            
            #line 76 "..\..\Views\JournalEntry\ExcelExport.cshtml"
           }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 77 "..\..\Views\JournalEntry\ExcelExport.cshtml"
             if (User.CanView("JournalEntry", "PropertyName"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td>\r\n");

WriteLiteral("                    ");

            
            #line 80 "..\..\Views\JournalEntry\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.PropertyName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 82 "..\..\Views\JournalEntry\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 83 "..\..\Views\JournalEntry\ExcelExport.cshtml"
             if (User.CanView("JournalEntry", "OldValue"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td>\r\n");

WriteLiteral("                    ");

            
            #line 86 "..\..\Views\JournalEntry\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.OldValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 88 "..\..\Views\JournalEntry\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 89 "..\..\Views\JournalEntry\ExcelExport.cshtml"
             if (User.CanView("JournalEntry", "NewValue"))
            {

            
            #line default
            #line hidden
WriteLiteral("                <td>\r\n");

WriteLiteral("                    ");

            
            #line 92 "..\..\Views\JournalEntry\ExcelExport.cshtml"
               Write(Html.DisplayFor(modelItem => item.NewValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 94 "..\..\Views\JournalEntry\ExcelExport.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tr>\r\n");

            
            #line 96 "..\..\Views\JournalEntry\ExcelExport.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n");

        }
    }
}
#pragma warning restore 1591