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

namespace GeneratorBase.MVC.Views.RuleAction
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/RuleAction/SetFSearch.cshtml")]
    public partial class SetFSearch : GeneratorBase.MVC.CustomWebViewPage<dynamic>
    {
        public SetFSearch()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\RuleAction\SetFSearch.cshtml"
  
    ViewBag.Title = "Set Search Criteria";
    Layout = null;
    var parentUrl = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 154), Tuple.Create("\"", 212)
            
            #line 6 "..\..\Views\RuleAction\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 161), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/bootstrap-multiselect.css")
            
            #line default
            #line hidden
, 161), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 258), Tuple.Create("\"", 317)
            
            #line 7 "..\..\Views\RuleAction\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 264), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/bootstrap-datetimepicker.js")
            
            #line default
            #line hidden
, 264), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script>\r\n    $(document).ready(function () {\r\n        if (\"");

            
            #line 10 "..\..\Views\RuleAction\SetFSearch.cshtml"
        Write(parentUrl);

            
            #line default
            #line hidden
WriteLiteral("\".length > 0) {\r\n            document.getElementById(\"FSearch\").value = \"");

            
            #line 11 "..\..\Views\RuleAction\SetFSearch.cshtml"
                                                   Write(parentUrl["search"]);

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            if (\"");

            
            #line 12 "..\..\Views\RuleAction\SetFSearch.cshtml"
            Write(parentUrl["ruleaction"]);

            
            #line default
            #line hidden
WriteLiteral("\" != null && \"");

            
            #line 12 "..\..\Views\RuleAction\SetFSearch.cshtml"
                                                  Write(parentUrl["ruleaction"]);

            
            #line default
            #line hidden
WriteLiteral("\".length > 0) {\r\n                var resRuleAction = \"");

            
            #line 13 "..\..\Views\RuleAction\SetFSearch.cshtml"
                                Write(parentUrl["ruleaction"]);

            
            #line default
            #line hidden
WriteLiteral(@""".split("","");
                var eleRuleAction = document.getElementById(""ruleaction"");
                for (i = 0; i < resRuleAction.length; i++) {
                    for (var o = 0; o < eleRuleAction.options.length; o++) {
                        if (eleRuleAction.options[o].value == resRuleAction[i])
                            eleRuleAction.options[o].selected = true;
                    }
                }
            }
            if (""");

            
            #line 22 "..\..\Views\RuleAction\SetFSearch.cshtml"
            Write(parentUrl["associatedactiontype"]);

            
            #line default
            #line hidden
WriteLiteral("\" != null && \"");

            
            #line 22 "..\..\Views\RuleAction\SetFSearch.cshtml"
                                                            Write(parentUrl["associatedactiontype"]);

            
            #line default
            #line hidden
WriteLiteral("\".length > 0) {\r\n                var resAssociatedActionType = \"");

            
            #line 23 "..\..\Views\RuleAction\SetFSearch.cshtml"
                                          Write(parentUrl["associatedactiontype"]);

            
            #line default
            #line hidden
WriteLiteral("\".split(\",\");\r\n                var eleAssociatedActionType = document.getElementB" +
"yId(\"associatedactiontype\");\r\n                for (i = 0; i < resAssociatedActio" +
"nType.length; i++) {\r\n                    for (var o = 0; o < eleAssociatedActio" +
"nType.options.length; o++) {\r\n                        if (eleAssociatedActionTyp" +
"e.options[o].value == resAssociatedActionType[i])\r\n                            e" +
"leAssociatedActionType.options[o].selected = true;\r\n                    }\r\n     " +
"           }\r\n            }\r\n        }\r\n    });\r\n    function FacetedSearch(Enti" +
"ty, Asso, Prop) {\r\n        var urlstring = $(\"#\" + \"fSearch\" + Entity).attr(\"dat" +
"aurl\");\r\n        var association = Asso.split(\",\");\r\n        var property = Prop" +
".split(\",\");\r\n        var firstparam = 0;\r\n        for (i = 0; i < association.l" +
"ength; i++) {\r\n            var vals = \"\";\r\n            ele = document.getElement" +
"ById(association[i]);\r\n            if (ele != null)\r\n                for (var o " +
"= 0; o < ele.options.length; o++) {\r\n                    if (ele.options[o].sele" +
"cted)\r\n                        vals += ele.options[o].value + \",\";\r\n            " +
"    }\r\n            if (vals.length > 0) {\r\n                if (firstparam == 0)\r" +
"\n                    urlstring += \"?\" + association[i] + \"=\" + vals;\r\n          " +
"      else\r\n                    urlstring += \"&\" + association[i] + \"=\" + vals;\r" +
"\n                firstparam = 1;\r\n            }\r\n        }\r\n        for (i = 0; " +
"i < property.length; i++) {\r\n            ele = document.getElementById(property[" +
"i]);\r\n            if (ele != null)\r\n                if (ele.value.length > 0) {\r" +
"\n                    if (firstparam == 0)\r\n                        urlstring += " +
"\"?\" + property[i] + \"=\" + ele.value;\r\n                    else\r\n                " +
"        urlstring += \"&\" + property[i] + \"=\" + ele.value;\r\n                    f" +
"irstparam = 1;\r\n                }\r\n        }\r\n        var currentFilter = \'");

            
            #line 66 "..\..\Views\RuleAction\SetFSearch.cshtml"
                        Write(Convert.ToString(ViewBag.CurrentFilter));

            
            #line default
            #line hidden
WriteLiteral(@"';
        if (currentFilter != '') {
            if (firstparam == 0)
                urlstring += ""?searchString="" + currentFilter;
            else
                urlstring += ""&searchString="" + currentFilter;
        }
        if (firstparam == 0)
            urlstring += ""?search="" + document.getElementById(""FSearch"").value;
        else
            urlstring += ""&search="" + document.getElementById(""FSearch"").value;
        window.location = (urlstring);
    }
</script>
<div");

WriteLiteral(" class=\"fsearch\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(" style=\"padding: 5px 5px\"");

WriteLiteral(">\r\n            <h3");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"glyphicon glyphicon-search\"");

WriteLiteral("></span> Faceted Search\r\n            </h3>\r\n            <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"padding: 3px 5px 6px 5px;\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("><span");

WriteLiteral(" class=\"glyphicon glyphicon-remove\"");

WriteLiteral("></span> <span");

WriteLiteral(" class=\"hidespan\"");

WriteLiteral(">Cancel</span></button>\r\n                <button");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"padding: 3px 5px 6px 5px;\"");

WriteLiteral(" id=\"fSearchRuleAction\"");

WriteAttribute("dataurl", Tuple.Create(" dataurl=", 4410), Tuple.Create("", 4461)
            
            #line 88 "..\..\Views\RuleAction\SetFSearch.cshtml"
                                 , Tuple.Create(Tuple.Create("", 4419), Tuple.Create<System.Object, System.Int32>(Url.Action("FSearch", "RuleAction", null)
            
            #line default
            #line hidden
, 4419), false)
);

WriteAttribute("onclick", Tuple.Create(" onclick=", 4461), Tuple.Create("", 4548)
            
            #line 88 "..\..\Views\RuleAction\SetFSearch.cshtml"
                                                                                    , Tuple.Create(Tuple.Create("", 4470), Tuple.Create<System.Object, System.Int32>(Html.Raw("FacetedSearch('RuleAction','ruleaction,associatedactiontype','');")
            
            #line default
            #line hidden
, 4470), false)
);

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"glyphicon glyphicon-search\"");

WriteLiteral("></span> <span");

WriteLiteral(" class=\"hidespan\"");

WriteLiteral(">Search</span>\r\n                </button>\r\n            </div>\r\n        </div>\r\n  " +
"      <div");

WriteLiteral(" class=\"panel-body fsearchbg\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\'col-sm-12 small\'");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\'col-sm-3\'");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\'col-sm-12\'");

WriteLiteral("> General Criteria </label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"FSearch\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"General Criteria\"");

WriteLiteral(" />\r\n                </div>\r\n");

            
            #line 99 "..\..\Views\RuleAction\SetFSearch.cshtml"
                
            
            #line default
            #line hidden
            
            #line 99 "..\..\Views\RuleAction\SetFSearch.cshtml"
                 if (ViewBag.ruleaction != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\'col-sm-3\'");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\'col-sm-12\'");

WriteLiteral("> Business Rule</label>\r\n");

WriteLiteral("                        ");

            
            #line 103 "..\..\Views\RuleAction\SetFSearch.cshtml"
                   Write(Html.DropDownList("ruleaction", null, new { @multiple = "multiple" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");

            
            #line 105 "..\..\Views\RuleAction\SetFSearch.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("                ");

            
            #line 106 "..\..\Views\RuleAction\SetFSearch.cshtml"
                 if (ViewBag.associatedactiontype != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\'col-sm-3\'");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\'col-sm-12\'");

WriteLiteral("> Action Type</label>\r\n");

WriteLiteral("                        ");

            
            #line 110 "..\..\Views\RuleAction\SetFSearch.cshtml"
                   Write(Html.DropDownList("associatedactiontype", null, new { @multiple = "multiple" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");

            
            #line 112 "..\..\Views\RuleAction\SetFSearch.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"panel-footer clearfix\"");

WriteLiteral(" style=\"padding-right:5px;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"padding: 3px 5px 6px 5px;\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("><span");

WriteLiteral(" class=\"glyphicon glyphicon-remove\"");

WriteLiteral("></span> <span");

WriteLiteral(" class=\"hidespan\"");

WriteLiteral(">Cancel</span></button>\r\n                <button");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"padding: 3px 5px 6px 5px;\"");

WriteLiteral(" id=\"fSearchRuleAction\"");

WriteAttribute("dataurl", Tuple.Create(" dataurl=", 6211), Tuple.Create("", 6262)
            
            #line 118 "..\..\Views\RuleAction\SetFSearch.cshtml"
                                 , Tuple.Create(Tuple.Create("", 6220), Tuple.Create<System.Object, System.Int32>(Url.Action("FSearch", "RuleAction", null)
            
            #line default
            #line hidden
, 6220), false)
);

WriteAttribute("onclick", Tuple.Create(" onclick=", 6262), Tuple.Create("", 6349)
            
            #line 118 "..\..\Views\RuleAction\SetFSearch.cshtml"
                                                                                    , Tuple.Create(Tuple.Create("", 6271), Tuple.Create<System.Object, System.Int32>(Html.Raw("FacetedSearch('RuleAction','ruleaction,associatedactiontype','');")
            
            #line default
            #line hidden
, 6271), false)
);

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"glyphicon glyphicon-search\"");

WriteLiteral("></span> <span");

WriteLiteral(" class=\"hidespan\"");

WriteLiteral(">Search</span>\r\n                </button>\r\n            </div>\r\n        </div>\r\n  " +
"  </div>\r\n</div>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 6549), Tuple.Create("\"", 6613)
            
            #line 125 "..\..\Views\RuleAction\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 6555), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/Common2/bootstrap-multiselect.js")
            
            #line default
            #line hidden
, 6555), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@"></script>
<script>
    $(document).ready(function () {
        $('#ruleaction').multiselect({
            buttonWidth: '100%'
        });
        $('#associatedactiontype').multiselect({
            buttonWidth: '100%'
        });
    });
</script>


");

        }
    }
}
#pragma warning restore 1591
