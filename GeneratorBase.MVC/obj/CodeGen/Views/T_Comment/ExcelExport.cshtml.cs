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

namespace GeneratorBase.MVC.Views.T_Comment
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
    
    #line 2 "..\..\Views\T_Comment\ExcelExport.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Comment/ExcelExport.cshtml")]
    public partial class ExcelExport : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.T_Comment>>
    {
        public ExcelExport()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_Comment\ExcelExport.cshtml"
  
    ViewBag.Title = "Index";
    Layout = null;
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment; filename=Comment.xls");

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <table>\r\n                            <tr>\r\n");

            
            #line 11 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_WhoandWhen"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Who and When</th>\r\n");

            
            #line 14 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_EmployeeCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 17 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Employee"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Employee </th>\r\n");

            
            #line 18 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_Summary"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Notes</th>\r\n");

            
            #line 22 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_AccommodationCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 25 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Accommodation"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Accommodation</th>\r\n");

            
            #line 26 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_DrugAlcoholTestCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 29 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_DrugAlcoholTest"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Drug & Alcohol Test</th>\r\n");

            
            #line 30 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_EducationCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 33 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Education"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Education</th>\r\n");

            
            #line 34 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_InjuryCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 37 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_EmployeeInjury"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Employee Injury</th>\r\n");

            
            #line 38 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_JobAssignmentCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 41 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_JobAssignment"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Job Assignment</th>\r\n");

            
            #line 42 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_LeaveCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 45 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_LeaveProfile"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Leave</th>\r\n");

            
            #line 46 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_LicensesCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 49 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Licenses"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Licenses</th>\r\n");

            
            #line 50 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_SalaryCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 53 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_PayDetails"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Pay Details </th>\r\n");

            
            #line 54 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 55 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_PreemploymentCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 57 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_BackgroundCheck"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Pre Employment Checks</th>\r\n");

            
            #line 58 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_ServiceRecordCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 61 "..\..\Views\T_Comment\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_ServiceRecord"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Service Record</th>\r\n");

            
            #line 62 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 63 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_WhoandWhenUser"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Who and WhenUser</th>\r\n");

            
            #line 66 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n");

            
            #line 68 "..\..\Views\T_Comment\ExcelExport.cshtml"
 foreach (var item in Model) {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n");

            
            #line 70 "..\..\Views\T_Comment\ExcelExport.cshtml"
	
            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\T_Comment\ExcelExport.cshtml"
     if(User.CanView("T_Comment","T_WhoandWhen"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 73 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_WhoandWhen));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 75 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 76 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_EmployeeCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 78 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Employee"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 79 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_employeecomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 81 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 82 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_Summary"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 85 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_Summary));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 87 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 88 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_AccommodationCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 90 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Accommodation"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 91 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_accommodationcomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 93 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_DrugAlcoholTestCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 96 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_DrugAlcoholTest"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 97 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_drugalcoholtestcomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 99 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 100 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_EducationCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 102 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Education"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 103 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_educationcomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 105 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 106 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_InjuryCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 108 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_EmployeeInjury"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 109 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_injurycomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 111 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 112 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_JobAssignmentCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 114 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_JobAssignment"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 115 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_jobassignmentcomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 117 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 118 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_LeaveCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 120 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_LeaveProfile"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 121 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_leavecomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 123 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 124 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_LicensesCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 126 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Licenses"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 127 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_licensescomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 129 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 130 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_SalaryCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 132 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_PayDetails"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 133 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_salarycomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 135 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_PreemploymentCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 138 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_BackgroundCheck"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 139 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_preemploymentcomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 141 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 142 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_ServiceRecordCommentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 144 "..\..\Views\T_Comment\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_ServiceRecord"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 145 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_servicerecordcomments.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 147 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 148 "..\..\Views\T_Comment\ExcelExport.cshtml"
 if(User.CanView("T_Comment","T_WhoandWhenUser"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 151 "..\..\Views\T_Comment\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_WhoandWhenUser));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 153 "..\..\Views\T_Comment\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("                                </tr>\r\n");

            
            #line 155 "..\..\Views\T_Comment\ExcelExport.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n               \r\n");

        }
    }
}
#pragma warning restore 1591