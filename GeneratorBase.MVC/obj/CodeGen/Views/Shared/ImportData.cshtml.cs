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

namespace GeneratorBase.MVC.Views.Shared
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/ImportData.cshtml")]
    public partial class ImportData : GeneratorBase.MVC.CustomWebViewPage<string>
    {
        public ImportData()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Shared\ImportData.cshtml"
 using (Html.BeginForm("ImportData", Model, FormMethod.Post, new { enctype = "multipart/form-data" }))
{

            
            #line default
            #line hidden
WriteLiteral("    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $(document).ready(function () {\r\n            $(\'#myModalConfirm\').moda" +
"l(\'show\');\r\n        });\r\n    </script>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" id=\"myModalConfirm\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" role=\"dialog\"");

WriteLiteral(" aria-labelledby=\"myModalLabel\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" data-keyboard=\"false\"");

WriteLiteral(" data-backdrop=\"static\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(" style=\"margin: 0px; padding: 8px; font-weight: bold;\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 15 "..\..\Views\Shared\ImportData.cshtml"
                       Write(ViewBag.DetailMessage);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdnFilePath\"");

WriteAttribute("value", Tuple.Create(" value=\"", 887), Tuple.Create("\"", 912)
            
            #line 17 "..\..\Views\Shared\ImportData.cshtml"
, Tuple.Create(Tuple.Create("", 895), Tuple.Create<System.Object, System.Int32>(ViewBag.FilePath
            
            #line default
            #line hidden
, 895), false)
);

WriteLiteral(" />\r\n                        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdnColumnList\"");

WriteAttribute("value", Tuple.Create(" value=\"", 983), Tuple.Create("\"", 1010)
            
            #line 18 "..\..\Views\Shared\ImportData.cshtml"
, Tuple.Create(Tuple.Create("", 991), Tuple.Create<System.Object, System.Int32>(ViewBag.ColumnList
            
            #line default
            #line hidden
, 991), false)
);

WriteLiteral(" />\r\n                        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdnSelectedList\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1083), Tuple.Create("\"", 1112)
            
            #line 19 "..\..\Views\Shared\ImportData.cshtml"
, Tuple.Create(Tuple.Create("", 1091), Tuple.Create<System.Object, System.Int32>(ViewBag.SelectedList
            
            #line default
            #line hidden
, 1091), false)
);

WriteLiteral(" />\r\n                        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(" style=\"margin:0px; padding:8px; overflow-x:scroll\"");

WriteLiteral(">\r\n                            <table");

WriteLiteral(" class=\"table table-striped table-bordered table-hover table-condensed table-resp" +
"onsive\"");

WriteLiteral(">\r\n                                <thead>\r\n                                    <" +
"tr>\r\n");

            
            #line 24 "..\..\Views\Shared\ImportData.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Shared\ImportData.cshtml"
                                         for (int i = 0; i < ((System.Data.DataTable)ViewBag.ConfirmImportData).Columns.Count; i++)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <th>");

            
            #line 26 "..\..\Views\Shared\ImportData.cshtml"
                                            Write(((System.Data.DataTable)ViewBag.ConfirmImportData).Columns[i].Caption);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n");

            
            #line 27 "..\..\Views\Shared\ImportData.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </tr>\r\n");

            
            #line 29 "..\..\Views\Shared\ImportData.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\ImportData.cshtml"
                                     for (int i = 0; i < ((System.Data.DataTable)ViewBag.ConfirmImportData).Rows.Count; i++)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <tr>\r\n");

            
            #line 32 "..\..\Views\Shared\ImportData.cshtml"
                                            
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Shared\ImportData.cshtml"
                                             foreach (var cell in ((System.Data.DataTable)ViewBag.ConfirmImportData).Rows[i].ItemArray)
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <td>");

            
            #line 34 "..\..\Views\Shared\ImportData.cshtml"
                                                Write(cell.ToString());

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 35 "..\..\Views\Shared\ImportData.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                        </tr>\r\n");

            
            #line 37 "..\..\Views\Shared\ImportData.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </thead>\r\n                            </table>\r\n " +
"                       </div>\r\n                    </div>\r\n");

            
            #line 42 "..\..\Views\Shared\ImportData.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Shared\ImportData.cshtml"
                     if (ViewBag.AssoUnique != null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" class=\"panel-group\"");

WriteLiteral(" id=\"accordion\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n                                    <h4");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-parent=\"#accordion\"");

WriteLiteral(" href=\"#collapseAssociatedList\"");

WriteLiteral(" style=\"text-decoration:none;\"");

WriteLiteral("> Following records also have to be added to create new ");

            
            #line 48 "..\..\Views\Shared\ImportData.cshtml"
                                                                                                                                                                                                          Write(Model);

            
            #line default
            #line hidden
WriteLiteral(". Please Review.</a>\r\n                                    </h4>\r\n                " +
"                </div>\r\n                                <div");

WriteLiteral(" id=\"collapseAssociatedList\"");

WriteLiteral(" class=\"panel-collapse collapse\"");

WriteLiteral(">\r\n");

            
            #line 52 "..\..\Views\Shared\ImportData.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Shared\ImportData.cshtml"
                                     foreach (var AssoUnique in ViewBag.AssoUnique)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(" style=\"margin-top:5px;\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(" style=\"margin:0px; padding:8px;\"");

WriteLiteral(">\r\n                                                New ");

            
            #line 56 "..\..\Views\Shared\ImportData.cshtml"
                                                Write((AssoUnique.Key as GeneratorBase.MVC.ModelReflector.Association).DisplayName);

            
            #line default
            #line hidden
WriteLiteral(" records found. Import these as well ");

            
            #line 56 "..\..\Views\Shared\ImportData.cshtml"
                                                                                                                                                                   Write(Html.CheckBox((AssoUnique.Key as GeneratorBase.MVC.ModelReflector.Association).AssociationProperty, true));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </div>\r\n                           " +
"                 <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                                                <table");

WriteLiteral(" class=\"table table-striped table-bordered table-hover table-condensed table-resp" +
"onsive\"");

WriteLiteral(" style=\"margin-bottom:0px !important; \"");

WriteLiteral(">\r\n                                                    <thead>\r\n");

            
            #line 61 "..\..\Views\Shared\ImportData.cshtml"
                                                        
            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\Shared\ImportData.cshtml"
                                                         foreach (string item in (AssoUnique.Value as List<String>))
                                                        {

            
            #line default
            #line hidden
WriteLiteral("                                                            <tr>\r\n               " +
"                                                 <td>\r\n");

WriteLiteral("                                                                    ");

            
            #line 65 "..\..\Views\Shared\ImportData.cshtml"
                                                               Write(item);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                                </td>\r\n        " +
"                                                    </tr>\r\n");

            
            #line 68 "..\..\Views\Shared\ImportData.cshtml"
                                                        }

            
            #line default
            #line hidden
WriteLiteral("                                                    </thead>\r\n                   " +
"                             </table>\r\n                                         " +
"   </div>\r\n                                        </div>\r\n");

            
            #line 73 "..\..\Views\Shared\ImportData.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </div>\r\n                            </div>\r\n     " +
"                   </div>\r\n");

            
            #line 77 "..\..\Views\Shared\ImportData.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 78 "..\..\Views\Shared\ImportData.cshtml"
                     if (ViewBag.Confirm == null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Confirm & Continue Import\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" />\r\n");

            
            #line 81 "..\..\Views\Shared\ImportData.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 5505), Tuple.Create("\"", 5539)
            
            #line 82 "..\..\Views\Shared\ImportData.cshtml"
, Tuple.Create(Tuple.Create("", 5512), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", Model)
            
            #line default
            #line hidden
, 5512), false)
);

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(">Cancel and Return</a>\r\n                </div>\r\n            </div>\r\n        </div" +
">\r\n    </div>\r\n");

            
            #line 87 "..\..\Views\Shared\ImportData.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591