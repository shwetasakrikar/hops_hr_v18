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

namespace GeneratorBase.MVC.Views.FeedbackSeverity
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/FeedbackSeverity/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.FeedbackSeverity>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Feedback Severity";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n                 $(\'#\' + hostingEntityName + \'ID\').attr(\"lock\",\"true\");\r\n    " +
"        }\r\n        }\r\n        catch (ex) { }\r\n    });\r\n</script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 539), Tuple.Create("\"", 588)
, Tuple.Create(Tuple.Create("", 546), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 546), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 616), Tuple.Create("\"", 659)
            
            #line 19 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 623), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 623), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 20 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "FeedbackSeverity",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
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

WriteLiteral(">\r\n               <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">         \r\n\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                    <label>");

            
            #line 32 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

WriteLiteral("                                    ");

            
            #line 33 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 34 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                    <label>");

            
            #line 39 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 40 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                               Write(Html.TextAreaFor(model => model.Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 41 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t\t\t</div>\r\n       </div>\r\n         " +
"               </div>\r\n                    </div>\r\n                </div>\r\n     " +
"   </div>\r\n");

WriteLiteral("\t\t<button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

            
            #line 50 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
		var busineesrule = User.businessrules.Where(p => p.EntityName == "FeedbackSeverity").ToList();
        if (ViewBag.IsAddPop != null)
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2502), Tuple.Create("\"", 2564)
, Tuple.Create(Tuple.Create("", 2512), Tuple.Create("QuickAdd(event,\'", 2512), true)
            
            #line 53 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                        , Tuple.Create(Tuple.Create("", 2528), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 2528), false)
, Tuple.Create(Tuple.Create("", 2541), Tuple.Create("\',", 2541), true)
            
            #line 53 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                                       , Tuple.Create(Tuple.Create("", 2543), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 2543), false)
, Tuple.Create(Tuple.Create("", 2562), Tuple.Create(");", 2562), true)
);

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2657), Tuple.Create("\"", 2782)
, Tuple.Create(Tuple.Create("", 2667), Tuple.Create("QuickAddFromIndex(event,true,\'FeedbackSeverity\',\'", 2667), true)
            
            #line 57 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                                                         , Tuple.Create(Tuple.Create("", 2716), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 2716), false)
, Tuple.Create(Tuple.Create("", 2743), Tuple.Create("\',\'", 2743), true)
            
            #line 57 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                                                                                       , Tuple.Create(Tuple.Create("", 2746), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 2746), false)
, Tuple.Create(Tuple.Create("", 2759), Tuple.Create("\',", 2759), true)
            
            #line 57 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
                                                                                                      , Tuple.Create(Tuple.Create("", 2761), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 2761), false)
, Tuple.Create(Tuple.Create("", 2780), Tuple.Create(");", 2780), true)
);

WriteLiteral(" />\r\n");

            
            #line 58 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\FeedbackSeverity\CreateQuick.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 2843), Tuple.Create("\"", 2883)
, Tuple.Create(Tuple.Create("", 2849), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Common3/chosen.jquery.js")
, 2849), false)
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
