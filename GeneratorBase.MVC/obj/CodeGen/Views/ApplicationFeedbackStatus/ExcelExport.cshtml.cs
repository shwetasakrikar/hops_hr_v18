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

namespace GeneratorBase.MVC.Views.ApplicationFeedbackStatus
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
    
    #line 2 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ApplicationFeedbackStatus/ExcelExport.cshtml")]
    public partial class ExcelExport : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.ApplicationFeedbackStatus>>
    {
        public ExcelExport()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
  
    ViewBag.Title = "Index";
    Layout = null;
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment; filename=ApplicationFeedbackStatus.xls");

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <table>\r\n                            <tr>\r\n");

            
            #line 11 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
 if(User.CanView("ApplicationFeedbackStatus","Name"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Name</th>\r\n");

            
            #line 14 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
 if(User.CanView("ApplicationFeedbackStatus","Description"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Description</th>\r\n");

            
            #line 18 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n");

            
            #line 20 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
 foreach (var item in Model) {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n");

            
            #line 22 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
	
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
     if(User.CanView("ApplicationFeedbackStatus","Name"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 25 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 27 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
 if(User.CanView("ApplicationFeedbackStatus","Description"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 31 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 33 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("                                </tr>\r\n");

            
            #line 35 "..\..\Views\ApplicationFeedbackStatus\ExcelExport.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n               \r\n");

        }
    }
}
#pragma warning restore 1591