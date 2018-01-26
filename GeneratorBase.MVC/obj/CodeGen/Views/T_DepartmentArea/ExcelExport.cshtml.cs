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

namespace GeneratorBase.MVC.Views.T_DepartmentArea
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
    
    #line 2 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_DepartmentArea/ExcelExport.cshtml")]
    public partial class ExcelExport : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.T_DepartmentArea>>
    {
        public ExcelExport()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
  
    ViewBag.Title = "Index";
    Layout = null;
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment; filename=Department Area.xls");

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <table>\r\n                            <tr>\r\n");

            
            #line 11 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
 if(User.CanView("T_DepartmentArea","T_DepartmentAreaEmployeeTypeAssociationID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 13 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Facility"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Facility</th>\r\n");

            
            #line 14 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
 if(User.CanView("T_DepartmentArea","T_Name"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Name</th>\r\n");

            
            #line 18 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
 if(User.CanView("T_DepartmentArea","T_Description"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Description</th>\r\n");

            
            #line 22 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n");

            
            #line 24 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
 foreach (var item in Model) {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n");

            
            #line 26 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
	
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
     if(User.CanView("T_DepartmentArea","T_DepartmentAreaEmployeeTypeAssociationID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 28 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "T_Facility"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 29 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.t_departmentareaemployeetypeassociation.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 31 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
 if(User.CanView("T_DepartmentArea","T_Name"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 35 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 37 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 38 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
 if(User.CanView("T_DepartmentArea","T_Description"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 41 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 43 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("                                </tr>\r\n");

            
            #line 45 "..\..\Views\T_DepartmentArea\ExcelExport.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n               \r\n");

        }
    }
}
#pragma warning restore 1591
