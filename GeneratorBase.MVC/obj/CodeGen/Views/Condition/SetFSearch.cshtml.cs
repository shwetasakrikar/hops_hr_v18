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

namespace GeneratorBase.MVC.Views.Condition
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Condition/SetFSearch.cshtml")]
    public partial class SetFSearch : GeneratorBase.MVC.CustomWebViewPage<dynamic>
    {
        public SetFSearch()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\Condition\SetFSearch.cshtml"
  
    ViewBag.Title = "Set Search Criteria";
    Layout = null;
    var parentUrl = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 154), Tuple.Create("\"", 212)
            
            #line 6 "..\..\Views\Condition\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 161), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/bootstrap-multiselect.css")
            
            #line default
            #line hidden
, 161), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 258), Tuple.Create("\"", 317)
            
            #line 7 "..\..\Views\Condition\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 264), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/bootstrap-datetimepicker.js")
            
            #line default
            #line hidden
, 264), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script>\r\n    $(document).ready(function () {\r\n        if (\"");

            
            #line 10 "..\..\Views\Condition\SetFSearch.cshtml"
        Write(parentUrl);

            
            #line default
            #line hidden
WriteLiteral("\".length > 0) {\r\n            document.getElementById(\"FSearch\").value = \"");

            
            #line 11 "..\..\Views\Condition\SetFSearch.cshtml"
                                                   Write(parentUrl["search"]);

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            if (\"");

            
            #line 12 "..\..\Views\Condition\SetFSearch.cshtml"
            Write(parentUrl["ruleconditions"]);

            
            #line default
            #line hidden
WriteLiteral("\" != null && \"");

            
            #line 12 "..\..\Views\Condition\SetFSearch.cshtml"
                                                      Write(parentUrl["ruleconditions"]);

            
            #line default
            #line hidden
WriteLiteral("\".length > 0) {\r\n                var resRuleConditions = \"");

            
            #line 13 "..\..\Views\Condition\SetFSearch.cshtml"
                                    Write(parentUrl["ruleconditions"]);

            
            #line default
            #line hidden
WriteLiteral("\".split(\",\");\r\n                var eleRuleConditions = document.getElementById(\"r" +
"uleconditions\");\r\n                for (i = 0; i < resRuleConditions.length; i++)" +
" {\r\n                    for (var o = 0; o < eleRuleConditions.options.length; o+" +
"+) {\r\n                        if (eleRuleConditions.options[o].value == resRuleC" +
"onditions[i])\r\n                            eleRuleConditions.options[o].selected" +
" = true;\r\n                    }\r\n                }\r\n            }\r\n        }\r\n  " +
"  });\r\n    function FacetedSearch(Entity, Asso, Prop) {\r\n        var urlstring =" +
" $(\"#\" + \"fSearch\" + Entity).attr(\"dataurl\");\r\n        var association = Asso.sp" +
"lit(\",\");\r\n        var property = Prop.split(\",\");\r\n        var firstparam = 0;\r" +
"\n        for (i = 0; i < association.length; i++) {\r\n            var vals = \"\";\r" +
"\n            ele = document.getElementById(association[i]);\r\n            if (ele" +
" != null)\r\n                for (var o = 0; o < ele.options.length; o++) {\r\n     " +
"               if (ele.options[o].selected)\r\n                        vals += ele" +
".options[o].value + \",\";\r\n                }\r\n            if (vals.length > 0) {\r" +
"\n                if (firstparam == 0)\r\n                    urlstring += \"?\" + as" +
"sociation[i] + \"=\" + vals;\r\n                else\r\n                    urlstring " +
"+= \"&\" + association[i] + \"=\" + vals;\r\n                firstparam = 1;\r\n        " +
"    }\r\n        }\r\n        for (i = 0; i < property.length; i++) {\r\n            e" +
"le = document.getElementById(property[i]);\r\n            if (ele != null)\r\n      " +
"          if (ele.value.length > 0) {\r\n                    if (firstparam == 0)\r" +
"\n                        urlstring += \"?\" + property[i] + \"=\" + ele.value;\r\n    " +
"                else\r\n                        urlstring += \"&\" + property[i] + \"" +
"=\" + ele.value;\r\n                    firstparam = 1;\r\n                }\r\n       " +
" }\r\n        var currentFilter = \'");

            
            #line 56 "..\..\Views\Condition\SetFSearch.cshtml"
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

WriteLiteral(" id=\"fSearchCondition\"");

WriteAttribute("dataurl", Tuple.Create(" dataurl=", 3746), Tuple.Create("", 3796)
            
            #line 78 "..\..\Views\Condition\SetFSearch.cshtml"
                                , Tuple.Create(Tuple.Create("", 3755), Tuple.Create<System.Object, System.Int32>(Url.Action("FSearch", "Condition", null)
            
            #line default
            #line hidden
, 3755), false)
);

WriteAttribute("onclick", Tuple.Create(" onclick=", 3796), Tuple.Create("", 3865)
            
            #line 78 "..\..\Views\Condition\SetFSearch.cshtml"
                                                                                  , Tuple.Create(Tuple.Create("", 3805), Tuple.Create<System.Object, System.Int32>(Html.Raw("FacetedSearch('Condition','ruleconditions','');")
            
            #line default
            #line hidden
, 3805), false)
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

            
            #line 89 "..\..\Views\Condition\SetFSearch.cshtml"
                
            
            #line default
            #line hidden
            
            #line 89 "..\..\Views\Condition\SetFSearch.cshtml"
                 if (ViewBag.ruleconditions != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\'col-sm-3\'");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\'col-sm-12\'");

WriteLiteral("> Business Rule</label>\r\n");

WriteLiteral("                        ");

            
            #line 93 "..\..\Views\Condition\SetFSearch.cshtml"
                   Write(Html.DropDownList("ruleconditions", null, new { @multiple = "multiple" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");

            
            #line 95 "..\..\Views\Condition\SetFSearch.cshtml"
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

WriteLiteral(" id=\"fSearchCondition\"");

WriteAttribute("dataurl", Tuple.Create(" dataurl=", 5188), Tuple.Create("", 5238)
            
            #line 101 "..\..\Views\Condition\SetFSearch.cshtml"
                                , Tuple.Create(Tuple.Create("", 5197), Tuple.Create<System.Object, System.Int32>(Url.Action("FSearch", "Condition", null)
            
            #line default
            #line hidden
, 5197), false)
);

WriteAttribute("onclick", Tuple.Create(" onclick=", 5238), Tuple.Create("", 5307)
            
            #line 101 "..\..\Views\Condition\SetFSearch.cshtml"
                                                                                  , Tuple.Create(Tuple.Create("", 5247), Tuple.Create<System.Object, System.Int32>(Html.Raw("FacetedSearch('Condition','ruleconditions','');")
            
            #line default
            #line hidden
, 5247), false)
);

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"glyphicon glyphicon-search\"");

WriteLiteral("></span> <span");

WriteLiteral(" class=\"hidespan\"");

WriteLiteral(">Search</span>\r\n                </button>\r\n            </div>\r\n        </div>\r\n  " +
"  </div>\r\n</div>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5507), Tuple.Create("\"", 5571)
            
            #line 108 "..\..\Views\Condition\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 5513), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/Common2/bootstrap-multiselect.js")
            
            #line default
            #line hidden
, 5513), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'#rulecondit" +
"ions\').multiselect({\r\n            buttonWidth: \'100%\'\r\n        });\r\n    });\r\n</s" +
"cript>\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591