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

namespace GeneratorBase.MVC.Views.T_BackgroundCheck
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
    
    #line 2 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_BackgroundCheck/ExcelExport.cshtml")]
    public partial class ExcelExport : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.T_BackgroundCheck>>
    {
        public ExcelExport()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
  
    ViewBag.Title = "Index";
    Layout = null;
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment; filename=Background Check.xls");

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <table>\r\n                            <tr>\r\n");

            
            #line 11 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_EmployeeCriminalBackgroundCheckID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 13 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Employee"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Employee</th>\r\n");

            
            #line 14 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_RetainTablePreEmploymentCheckID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 17 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_RetainTable"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Employment Decision</th>\r\n");

            
            #line 18 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_DateFingerPrintTaken"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Date Finger Print Taken</th>\r\n");

            
            #line 22 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_DateInformationReceivedFromCBC"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>VSP Response Rcvd Date</th>\r\n");

            
            #line 26 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_PreEmploymentCheckResultsVAStateID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 29 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_ResultsTable"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">VSP Initial Results</th>\r\n");

            
            #line 30 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_BackgroundDispositionDate"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>FBI Record Received Date </th>\r\n");

            
            #line 34 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_ReviewDate"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Review Date</th>\r\n");

            
            #line 38 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_ReviewerID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 41 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Employee"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Reviewer </th>\r\n");

            
            #line 42 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_DateCheckInitiated"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Date Check Initiated</th>\r\n");

            
            #line 46 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_DateCPSResultReceived"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Date CPS Result Received</th>\r\n");

            
            #line 50 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_CPSResultID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 53 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_CPSResults"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">CPS Result </th>\r\n");

            
            #line 54 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 55 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_CPSReviewDate"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>CPS Review Date</th>\r\n");

            
            #line 58 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_Notes"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Notes</th>\r\n");

            
            #line 62 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n");

            
            #line 64 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 foreach (var item in Model) {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n");

            
            #line 66 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
	
            
            #line default
            #line hidden
            
            #line 66 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
     if(User.CanView("T_BackgroundCheck","T_EmployeeCriminalBackgroundCheckID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 68 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Employee"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 69 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_employeecriminalbackgroundcheck.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 71 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 72 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_RetainTablePreEmploymentCheckID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 74 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_RetainTable"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 75 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_retaintablepreemploymentcheck.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 77 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 78 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_DateFingerPrintTaken"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 81 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_DateFingerPrintTaken));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 83 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 84 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_DateInformationReceivedFromCBC"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 87 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_DateInformationReceivedFromCBC));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 89 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 90 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_PreEmploymentCheckResultsVAStateID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 92 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_ResultsTable"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 93 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_preemploymentcheckresultsvastate.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 95 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_BackgroundDispositionDate"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 99 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_BackgroundDispositionDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 101 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 102 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_ReviewDate"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 105 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_ReviewDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 107 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 108 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_ReviewerID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 110 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Employee"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 111 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_reviewer.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 113 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 114 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_DateCheckInitiated"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 117 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_DateCheckInitiated));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 119 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 120 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_DateCPSResultReceived"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 123 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_DateCPSResultReceived));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 125 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 126 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_CPSResultID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 128 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_CPSResults"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 129 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_cpsresult.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 131 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 132 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_CPSReviewDate"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 135 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_CPSReviewDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 137 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 138 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
 if(User.CanView("T_BackgroundCheck","T_Notes"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 141 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_Notes));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 143 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("                                </tr>\r\n");

            
            #line 145 "..\..\Views\T_BackgroundCheck\ExcelExport.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n               \r\n");

        }
    }
}
#pragma warning restore 1591