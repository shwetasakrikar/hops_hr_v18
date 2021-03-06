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

namespace GeneratorBase.MVC.Views.PropertyMapping
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
    
    #line 2 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/PropertyMapping/ExcelExport.cshtml")]
    public partial class ExcelExport : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.PropertyMapping>>
    {
        public ExcelExport()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
  
    ViewBag.Title = "Index";
    Layout = null;
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment; filename=Property Mapping.xls");

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <table>\r\n                            <tr>\r\n");

            
            #line 11 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","PropertyName"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Property Name</th>\r\n");

            
            #line 14 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","DataName"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Data Name</th>\r\n");

            
            #line 18 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","DataSource"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Data Source</th>\r\n");

            
            #line 22 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","SourceType"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Source Type</th>\r\n");

            
            #line 26 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","MethodType"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Method Type</th>\r\n");

            
            #line 30 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","Action"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th>Action</th>\r\n");

            
            #line 34 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","EntityPropertyMappingID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<th  ");

            
            #line 37 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
         Write(Convert.ToString(ViewData["HostingEntity"]) == "EntityDataSource"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">Entity Data Source</th>\r\n");

            
            #line 38 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n");

            
            #line 40 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 foreach (var item in Model) {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n");

            
            #line 42 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
	
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
     if(User.CanView("PropertyMapping","PropertyName"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 45 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.PropertyName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 47 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","DataName"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 51 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.DataName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 53 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 54 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","DataSource"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 57 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.DataSource));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 59 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","SourceType"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 63 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.SourceType));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 65 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 66 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","MethodType"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 69 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.MethodType));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 71 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 72 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","Action"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td>\r\n");

WriteLiteral("            ");

            
            #line 75 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.Action));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 77 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
            
            #line 78 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
 if(User.CanView("PropertyMapping","EntityPropertyMappingID"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t<td ");

            
            #line 80 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
        Write(Convert.ToString(ViewData["HostingEntity"]) == "EntityDataSource"?"hidden":"");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 81 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
       Write(Html.DisplayFor(modelItem => item.entitypropertymapping.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n");

            
            #line 83 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("                                </tr>\r\n");

            
            #line 85 "..\..\Views\PropertyMapping\ExcelExport.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n               \r\n");

        }
    }
}
#pragma warning restore 1591
