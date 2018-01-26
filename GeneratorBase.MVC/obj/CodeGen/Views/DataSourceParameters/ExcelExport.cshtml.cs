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

namespace GeneratorBase.MVC.Views.DataSourceParameters
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
    
    #line 2 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DataSourceParameters/ExcelExport.cshtml")]
    public partial class ExcelExport : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.DataSourceParameters>>
    {
        public ExcelExport()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
  
    ViewBag.Title = "Index";
    Layout = null;
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment; filename=Data Source Parameters.xls");

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <table>\r\n                            <tr>\r\n");

            
            #line 11 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","ArgumentName"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Argument Name</th>\r\n");

            
            #line 14 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","ArgumentValue"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Argument Value</th>\r\n");

            
            #line 18 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","HostingEntity"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Hosting Entity</th>\r\n");

            
            #line 22 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","flag"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>flag</th>\r\n");

            
            #line 26 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","other"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>other</th>\r\n");

            
            #line 30 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","EntityDataSourceParametersID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 33 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "EntityDataSource"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Entity Data Source</th>\r\n");

            
            #line 34 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n");

            
            #line 36 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 foreach (var item in Model) {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n");

            
            #line 38 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
	
            
            #line default
            #line hidden
            
            #line 38 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
     if(User.CanView("DataSourceParameters","ArgumentName"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 41 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.ArgumentName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 43 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","ArgumentValue"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 47 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.ArgumentValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 49 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 50 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","HostingEntity"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 53 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.HostingEntity));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 55 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","flag"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 59 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.flag));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 61 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","other"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 65 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.other));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 67 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 68 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
 if(User.CanView("DataSourceParameters","EntityDataSourceParametersID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 70 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "EntityDataSource"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 71 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.entitydatasourceparameters.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 73 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("                                </tr>\r\n");

            
            #line 75 "..\..\Views\DataSourceParameters\ExcelExport.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n               \r\n");

        }
    }
}
#pragma warning restore 1591