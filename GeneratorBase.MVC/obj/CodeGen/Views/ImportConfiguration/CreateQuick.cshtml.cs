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

namespace GeneratorBase.MVC.Views.ImportConfiguration
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ImportConfiguration/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.ImportConfiguration>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Import Configuration";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 137), Tuple.Create("\"", 186)
, Tuple.Create(Tuple.Create("", 144), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 144), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 214), Tuple.Create("\"", 257)
            
            #line 7 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 221), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 221), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 8 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "ImportConfiguration", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(">\r\n                                    <i");

WriteLiteral(" class=\"icon-calendar\"");

WriteLiteral("></i>\r\n                                    <h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">General</h3>\r\n                                </div>\r\n                          " +
"      <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label>");

            
            #line 27 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                              Write(Html.LabelFor(model => model.TableColumn));

            
            #line default
            #line hidden
WriteLiteral("  </label>\r\n");

WriteLiteral("                                            ");

            
            #line 28 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.TextBoxFor(model => model.TableColumn, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                            ");

            
            #line 29 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.TableColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </div>\r\n                               " +
"     </div>\r\n                                    <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label>");

            
            #line 34 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                              Write(Html.LabelFor(model => model.SheetColumn));

            
            #line default
            #line hidden
WriteLiteral("  </label>\r\n");

WriteLiteral("                                            ");

            
            #line 35 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.TextBoxFor(model => model.SheetColumn, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                            ");

            
            #line 36 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.SheetColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </div>\r\n                               " +
"     </div>\r\n                                    <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label>");

            
            #line 41 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                              Write(Html.LabelFor(model => model.UniqueColumn));

            
            #line default
            #line hidden
WriteLiteral("  </label>\r\n");

WriteLiteral("                                            ");

            
            #line 42 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.TextBoxFor(model => model.UniqueColumn, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                            ");

            
            #line 43 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.UniqueColumn));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </div>\r\n                               " +
"     </div>\r\n                                    <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label>");

            
            #line 48 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                              Write(Html.LabelFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("  </label>\r\n");

WriteLiteral("                                            ");

            
            #line 49 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.TextBoxFor(model => model.Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                            ");

            
            #line 50 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </div>\r\n                               " +
"     </div>\r\n                                    <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label>");

            
            #line 55 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                              Write(Html.LabelFor(model => model.MappingName));

            
            #line default
            #line hidden
WriteLiteral("  </label>\r\n");

WriteLiteral("                                            ");

            
            #line 56 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.TextBoxFor(model => model.MappingName, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                            ");

            
            #line 57 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.MappingName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </div>\r\n                               " +
"     </div>\r\n                                    <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                            <label>");

            
            #line 62 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                              Write(Html.LabelFor(model => model.IsDefaultMapping));

            
            #line default
            #line hidden
WriteLiteral("  </label>\r\n");

WriteLiteral("                                            ");

            
            #line 63 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.CheckBoxFor(model => model.IsDefaultMapping));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                            ");

            
            #line 64 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                       Write(Html.ValidationMessageFor(model => model.IsDefaultMapping));

            
            #line default
            #line hidden
WriteLiteral(@"
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
");

WriteLiteral("    <button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

            
            #line 76 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
    var busineesrule = User.businessrules.Where(p => p.EntityName == "ImportConfiguration").ToList();
    if (ViewBag.IsAddPop != null)
    {

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4977), Tuple.Create("\"", 5039)
, Tuple.Create(Tuple.Create("", 4987), Tuple.Create("QuickAdd(event,\'", 4987), true)
            
            #line 79 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                    , Tuple.Create(Tuple.Create("", 5003), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5003), false)
, Tuple.Create(Tuple.Create("", 5016), Tuple.Create("\',", 5016), true)
            
            #line 79 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                   , Tuple.Create(Tuple.Create("", 5018), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5018), false)
, Tuple.Create(Tuple.Create("", 5037), Tuple.Create(");", 5037), true)
);

WriteLiteral(" />\r\n");

            
            #line 80 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5143), Tuple.Create("\"", 5271)
, Tuple.Create(Tuple.Create("", 5153), Tuple.Create("QuickAddFromIndex(event,true,\'ImportConfiguration\',\'", 5153), true)
            
            #line 83 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 5205), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5205), false)
, Tuple.Create(Tuple.Create("", 5232), Tuple.Create("\',\'", 5232), true)
            
            #line 83 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                                                                      , Tuple.Create(Tuple.Create("", 5235), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5235), false)
, Tuple.Create(Tuple.Create("", 5248), Tuple.Create("\',", 5248), true)
            
            #line 83 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
                                                                                                     , Tuple.Create(Tuple.Create("", 5250), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5250), false)
, Tuple.Create(Tuple.Create("", 5269), Tuple.Create(");", 5269), true)
);

WriteLiteral(" />\r\n");

            
            #line 84 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
    }
}

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\ImportConfiguration\CreateQuick.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5334), Tuple.Create("\"", 5374)
, Tuple.Create(Tuple.Create("", 5340), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Common3/chosen.jquery.js")
, 5340), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    var config = {
        '.chosen-select': {},
        '.chosen-select-deselect': { allow_single_deselect: true },
        '.chosen-select-no-single': { disable_search_threshold: 10 },
        '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
        '.chosen-select-width': { width: ""95%"" }
    }
    for (var selector in config) {
        $(selector).chosen(config[selector]);
    }
</script>


");

        }
    }
}
#pragma warning restore 1591