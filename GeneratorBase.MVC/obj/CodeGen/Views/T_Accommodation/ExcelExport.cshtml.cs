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

namespace GeneratorBase.MVC.Views.T_Accommodation
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
    
    #line 2 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Accommodation/ExcelExport.cshtml")]
    public partial class ExcelExport : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.T_Accommodation>>
    {
        public ExcelExport()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
  
    ViewBag.Title = "Index";
    Layout = null;
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment; filename=Accommodation.xls");

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <table>\r\n                            <tr>\r\n");

            
            #line 11 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_EmployeeAccomodationID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 13 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Employee"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Employee</th>\r\n");

            
            #line 14 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_AccommodationInjuryID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 17 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_EmployeeInjury"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Employee Injury</th>\r\n");

            
            #line 18 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_AccommodationStartDate"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Accommodation Start Date</th>\r\n");

            
            #line 22 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_AccommodationEndDate"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Accommodation End Date</th>\r\n");

            
            #line 26 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_NinetyDaysSinceAccommodation"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Ninety Days Since Accommodation</th>\r\n");

            
            #line 30 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_TemporaryAccommodation"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Temporary Accommodation</th>\r\n");

            
            #line 34 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_DateLetterGivenToEmployee"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Date Letter Given To Employee</th>\r\n");

            
            #line 38 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_Restriction"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Restriction</th>\r\n");

            
            #line 42 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_AccommodationNotes"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Accommodation Notes</th>\r\n");

            
            #line 46 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n");

            
            #line 48 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 foreach (var item in Model) {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n");

            
            #line 50 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
	
            
            #line default
            #line hidden
            
            #line 50 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
     if(User.CanView("T_Accommodation","T_EmployeeAccomodationID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 52 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Employee"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 53 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_employeeaccomodation.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 55 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_AccommodationInjuryID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 58 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_EmployeeInjury"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 59 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_accommodationinjury.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 61 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_AccommodationStartDate"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 65 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_AccommodationStartDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 67 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 68 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_AccommodationEndDate"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 71 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_AccommodationEndDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 73 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_NinetyDaysSinceAccommodation"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 77 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_NinetyDaysSinceAccommodation));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 79 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_TemporaryAccommodation"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 83 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_TemporaryAccommodation));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 85 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_DateLetterGivenToEmployee"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 89 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_DateLetterGivenToEmployee));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 91 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 92 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_Restriction"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 95 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_Restriction));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 97 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 98 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
 if(User.CanView("T_Accommodation","T_AccommodationNotes"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 101 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_AccommodationNotes));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 103 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("                                </tr>\r\n");

            
            #line 105 "..\..\Views\T_Accommodation\ExcelExport.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n               \r\n");

        }
    }
}
#pragma warning restore 1591
