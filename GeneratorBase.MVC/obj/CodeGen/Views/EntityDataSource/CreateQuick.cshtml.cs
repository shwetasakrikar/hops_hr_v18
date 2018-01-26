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

namespace GeneratorBase.MVC.Views.EntityDataSource
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EntityDataSource/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.EntityDataSource>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Entity Data Source";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n                $(\'#\' + hostingEntityName + \'ID\').attr(\"lock\", \"true\");\r\n    " +
"            $(\'#\' + hostingEntityName + \'ID\').trigger(\"change\");\r\n            }\r" +
"\n        }\r\n        catch (ex) { }\r\n    });\r\n</script>\r\n");

            
            #line 19 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.EntityDataSourceIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.EntityDataSourceIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                       ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 759), Tuple.Create("\"", 808)
, Tuple.Create(Tuple.Create("", 766), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 766), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 836), Tuple.Create("\"", 879)
            
            #line 26 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 843), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 843), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 27 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "EntityDataSource", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                            ;
                            Html.ValidationSummary(true);
                            Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("                            <label");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" class=\"text-primary small pull-right\"");

WriteLiteral(" style=\"color:red; vertical-align:middle; font-weight:100;\"");

WriteLiteral("></label>\r\n");

WriteLiteral("                            <div");

WriteLiteral(" id=\"errorContainerQuickAdd\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" id=\"errorsMsgQuickAdd\"");

WriteLiteral("></div>\r\n                                <div");

WriteLiteral(" id=\"errorsQuickAdd\"");

WriteLiteral("></div>\r\n                            </div>\r\n");

WriteLiteral("                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 38 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                           Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                                ");

WriteLiteral("\r\n                                                <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"cmbEntity\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>Select Entity<s" +
"pan");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n");

WriteLiteral("                                                        ");

            
            #line 55 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.DropDownList("EntityName", null, "-- Select --", new { @required = "required", @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                        ");

            
            #line 56 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.EntityName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </div>\r\n                   " +
"                             </div>\r\n                                           " +
"     <div");

WriteLiteral(" class=\'col-sm-12\'");

WriteLiteral(" id=\"dvDataSource\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 61 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                          Write(Html.LabelFor(model => model.DataSource));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                                        ");

            
            #line 62 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.TextAreaFor(model => model.DataSource, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                        ");

            
            #line 63 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.DataSource));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </div>\r\n                   " +
"                             </div>\r\n                                           " +
"     <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvSourceType\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 68 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                          Write(Html.LabelFor(model => model.SourceType));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\r\n                                                        ");

WriteLiteral("\r\n                                                        <select");

WriteLiteral(" id=\"SourceType\"");

WriteLiteral(" name=\"SourceType\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                                            <option");

WriteLiteral(" value=\"JSON\"");

WriteLiteral(">Json</option>\r\n                                                            <opti" +
"on");

WriteLiteral(" value=\"XML\"");

WriteLiteral(">XML</option>\r\n                                                            <optio" +
"n");

WriteLiteral(" value=\"DATABASE\"");

WriteLiteral(">Database</option>\r\n                                                        </sel" +
"ect>\r\n");

WriteLiteral("                                                        ");

            
            #line 76 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.SourceType));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                                                    </div>\r\n                 " +
"                               </div>\r\n                                         " +
"       <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvMethodType\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 82 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                          Write(Html.LabelFor(model => model.MethodType));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\r\n                                                        ");

WriteLiteral("\r\n                                                        <select");

WriteLiteral(" id=\"MethodType\"");

WriteLiteral(" name=\"MethodType\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                                            <option");

WriteLiteral(" value=\"GET\"");

WriteLiteral(">GET</option>\r\n                                                            <optio" +
"n");

WriteLiteral(" value=\"POST\"");

WriteLiteral(">POST</option>\r\n                                                        </select>" +
"\r\n");

WriteLiteral("                                                        ");

            
            #line 89 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.MethodType));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                                                    </div>\r\n                 " +
"                               </div>\r\n                                         " +
"       <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvAction\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 95 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                          Write(Html.LabelFor(model => model.Action));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\r\n                                                        ");

WriteLiteral("\r\n                                                        <select");

WriteLiteral(" id=\"Action\"");

WriteLiteral(" name=\"Action\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                                            <option");

WriteLiteral(" value=\"GETLIST\"");

WriteLiteral(">GetList</option>\r\n                                                            <o" +
"ption");

WriteLiteral(" value=\"CREATE\"");

WriteLiteral(">Create</option>\r\n                                                            <op" +
"tion");

WriteLiteral(" value=\"UPDATE\"");

WriteLiteral(">Update</option>\r\n                                                            <op" +
"tion");

WriteLiteral(" value=\"GETITEM\"");

WriteLiteral(">GetItem</option>\r\n                                                        </sele" +
"ct>\r\n");

WriteLiteral("                                                        ");

            
            #line 104 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.Action));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                                                    </div>\r\n                 " +
"                               </div>\r\n                                         " +
"       <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvother\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                                                        <label>");

            
            #line 110 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                          Write(Html.LabelFor(model => model.other));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\r\n");

WriteLiteral("                                                        ");

            
            #line 112 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.TextBoxFor(model => model.other, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                        ");

            
            #line 113 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.other));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                                                    </div>\r\n                 " +
"                               </div>\r\n                                         " +
"       <div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvflag\"");

WriteLiteral(">\r\n                                                    <label>\r\n");

WriteLiteral("                                                        ");

            
            #line 119 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.LabelFor(model => model.flag));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </label>\r\n                 " +
"                                   <div>\r\n                                      " +
"                  ");

WriteLiteral("\r\n");

WriteLiteral("                                                        ");

            
            #line 123 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.CheckBox("flag", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                                        ");

            
            #line 124 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                   Write(Html.ValidationMessageFor(model => model.flag));

            
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
");

WriteLiteral("                            <button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

            
            #line 134 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                            var busineesrule = User.businessrules.Where(p => p.EntityName == "EntityDataSource").ToList();
                            if (ViewBag.IsAddPop != null)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9653), Tuple.Create("\"", 9715)
, Tuple.Create(Tuple.Create("", 9663), Tuple.Create("QuickAdd(event,\'", 9663), true)
            
            #line 137 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                            , Tuple.Create(Tuple.Create("", 9679), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 9679), false)
, Tuple.Create(Tuple.Create("", 9692), Tuple.Create("\',", 9692), true)
            
            #line 137 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                           , Tuple.Create(Tuple.Create("", 9694), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 9694), false)
, Tuple.Create(Tuple.Create("", 9713), Tuple.Create(");", 9713), true)
);

WriteLiteral(" />\r\n");

            
            #line 138 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                            }
                            else
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9915), Tuple.Create("\"", 10040)
, Tuple.Create(Tuple.Create("", 9925), Tuple.Create("QuickAddFromIndex(event,true,\'EntityDataSource\',\'", 9925), true)
            
            #line 141 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                                             , Tuple.Create(Tuple.Create("", 9974), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 9974), false)
, Tuple.Create(Tuple.Create("", 10001), Tuple.Create("\',\'", 10001), true)
            
            #line 141 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                                                                          , Tuple.Create(Tuple.Create("", 10004), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 10004), false)
, Tuple.Create(Tuple.Create("", 10017), Tuple.Create("\',", 10017), true)
            
            #line 141 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                                                                                                                         , Tuple.Create(Tuple.Create("", 10019), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 10019), false)
, Tuple.Create(Tuple.Create("", 10038), Tuple.Create(");", 10038), true)
);

WriteLiteral(" />\r\n");

            
            #line 142 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
                            }
}

            
            #line default
            #line hidden
            
            #line 144 "..\..\Views\EntityDataSource\CreateQuick.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 10127), Tuple.Create("\"", 10167)
, Tuple.Create(Tuple.Create("", 10133), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Common3/chosen.jquery.js")
, 10133), false)
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
