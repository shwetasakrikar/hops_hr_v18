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

namespace GeneratorBase.MVC.Views.T_ResultsForDrugTest
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ResultsForDrugTest/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_ResultsForDrugTest>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Results For Drug Test";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n                 $(\'#\' + hostingEntityName + \'ID\').attr(\"lock\",\"true\");\r\n\t\t\t\t" +
"  $(\'#\' + hostingEntityName + \'ID\').trigger(\"change\");\r\n            }\r\n\t\t\t\r\n    " +
"    }\r\n        catch (ex) { }\r\n\t\t\r\n\t\t \r\n    });\r\n</script>\r\n<script");

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

            
            #line 34 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ResultsForDrugTestIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ResultsForDrugTestIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                           ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ResultsForDrugTestIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ResultsForDrugTestIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ResultsForDrugTestIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ResultsForDrugTestIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                               ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1577), Tuple.Create("\"", 1626)
, Tuple.Create(Tuple.Create("", 1584), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1584), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1654), Tuple.Create("\"", 1697)
            
            #line 53 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1661), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1661), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_ResultsForDrugTest",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                            

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" id=\"errorContainerQuickAdd\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"errorsMsgQuickAdd\"");

WriteLiteral("></div>\r\n        <div");

WriteLiteral(" id=\"errorsQuickAdd\"");

WriteLiteral("></div>\r\n    </div>\r\n");

WriteLiteral("\t<div");

WriteLiteral(" id=\"divDisplayThresholdLimit\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n\t</div>\r\n");

WriteLiteral("\t <div");

WriteLiteral(" id=\"divDisplayBRmsgMandatory\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n\t</div>\r\n");

WriteLiteral("\t<div");

WriteLiteral(" id=\"divDisplayBRmsgBeforeSaveProp\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n\t</div>\r\n");

WriteLiteral("\t\t    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

WriteLiteral("\t");

            
            #line 72 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityID", Convert.ToString(ViewData["HostingEntityID"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n               \t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t        \r\n");

            
            #line 80 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                 if(User.CanView("T_ResultsForDrugTest","T_Name"))
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Name\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 84 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
					
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                     if(User.CanView("T_ResultsForDrugTest","T_Description"))
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Description\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 98 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 99 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 103 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
							}

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n                        </div>\r\n                    </div>\r\n      " +
"          </div>\r\n        </div>\r\n");

WriteLiteral("\t\t<button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

            
            #line 110 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_ResultsForDrugTest").ToList();
		 var lstinlineentityname = "";
		 var lstinlineassocdispname ="";
		 var lstinlineassocname = "";
        if (ViewBag.IsAddPop != null)
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4747), Tuple.Create("\"", 4937)
, Tuple.Create(Tuple.Create("", 4757), Tuple.Create("QuickAdd(event,\'T_ResultsForDrugTest\',\'", 4757), true)
            
            #line 117 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                               , Tuple.Create(Tuple.Create("", 4796), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4796), false)
, Tuple.Create(Tuple.Create("", 4809), Tuple.Create("\',", 4809), true)
            
            #line 117 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                              , Tuple.Create(Tuple.Create("", 4811), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4811), false)
, Tuple.Create(Tuple.Create("", 4830), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4830), true)
            
            #line 117 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                     , Tuple.Create(Tuple.Create("", 4866), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4866), false)
, Tuple.Create(Tuple.Create("", 4885), Tuple.Create("\',\'", 4885), true)
            
            #line 117 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                           , Tuple.Create(Tuple.Create("", 4888), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4888), false)
, Tuple.Create(Tuple.Create("", 4911), Tuple.Create("\',\'", 4911), true)
            
            #line 117 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                                                     , Tuple.Create(Tuple.Create("", 4914), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4914), false)
, Tuple.Create(Tuple.Create("", 4934), Tuple.Create("\');", 4934), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5046), Tuple.Create("\"", 5236)
, Tuple.Create(Tuple.Create("", 5056), Tuple.Create("QuickAdd(event,\'T_ResultsForDrugTest\',\'", 5056), true)
            
            #line 118 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                        , Tuple.Create(Tuple.Create("", 5095), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5095), false)
, Tuple.Create(Tuple.Create("", 5108), Tuple.Create("\',", 5108), true)
            
            #line 118 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                       , Tuple.Create(Tuple.Create("", 5110), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5110), false)
, Tuple.Create(Tuple.Create("", 5129), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5129), true)
            
            #line 118 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                              , Tuple.Create(Tuple.Create("", 5165), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5165), false)
, Tuple.Create(Tuple.Create("", 5184), Tuple.Create("\',\'", 5184), true)
            
            #line 118 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 5187), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5187), false)
, Tuple.Create(Tuple.Create("", 5210), Tuple.Create("\',\'", 5210), true)
            
            #line 118 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 5213), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5213), false)
, Tuple.Create(Tuple.Create("", 5233), Tuple.Create("\');", 5233), true)
);

WriteLiteral(" />\r\n");

            
            #line 119 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5329), Tuple.Create("\"", 5563)
, Tuple.Create(Tuple.Create("", 5339), Tuple.Create("QuickAddFromIndex(event,true,\'T_ResultsForDrugTest\',\'", 5339), true)
            
            #line 122 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                             , Tuple.Create(Tuple.Create("", 5392), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5392), false)
, Tuple.Create(Tuple.Create("", 5419), Tuple.Create("\',\'", 5419), true)
            
            #line 122 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                           , Tuple.Create(Tuple.Create("", 5422), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5422), false)
, Tuple.Create(Tuple.Create("", 5435), Tuple.Create("\',", 5435), true)
            
            #line 122 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                          , Tuple.Create(Tuple.Create("", 5437), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5437), false)
, Tuple.Create(Tuple.Create("", 5456), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5456), true)
            
            #line 122 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                                                 , Tuple.Create(Tuple.Create("", 5492), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5492), false)
, Tuple.Create(Tuple.Create("", 5511), Tuple.Create("\',\'", 5511), true)
            
            #line 122 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                                                                       , Tuple.Create(Tuple.Create("", 5514), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5514), false)
, Tuple.Create(Tuple.Create("", 5537), Tuple.Create("\',\'", 5537), true)
            
            #line 122 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                                                                                                 , Tuple.Create(Tuple.Create("", 5540), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5540), false)
, Tuple.Create(Tuple.Create("", 5560), Tuple.Create("\');", 5560), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5671), Tuple.Create("\"", 5905)
, Tuple.Create(Tuple.Create("", 5681), Tuple.Create("QuickAddFromIndex(event,true,\'T_ResultsForDrugTest\',\'", 5681), true)
            
            #line 123 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                     , Tuple.Create(Tuple.Create("", 5734), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5734), false)
, Tuple.Create(Tuple.Create("", 5761), Tuple.Create("\',\'", 5761), true)
            
            #line 123 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                   , Tuple.Create(Tuple.Create("", 5764), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5764), false)
, Tuple.Create(Tuple.Create("", 5777), Tuple.Create("\',", 5777), true)
            
            #line 123 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                  , Tuple.Create(Tuple.Create("", 5779), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5779), false)
, Tuple.Create(Tuple.Create("", 5798), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5798), true)
            
            #line 123 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                                                                         , Tuple.Create(Tuple.Create("", 5834), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5834), false)
, Tuple.Create(Tuple.Create("", 5853), Tuple.Create("\',\'", 5853), true)
            
            #line 123 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                                                                                               , Tuple.Create(Tuple.Create("", 5856), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5856), false)
, Tuple.Create(Tuple.Create("", 5879), Tuple.Create("\',\'", 5879), true)
            
            #line 123 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
                                                                                                                                                                                                                                         , Tuple.Create(Tuple.Create("", 5882), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5882), false)
, Tuple.Create(Tuple.Create("", 5902), Tuple.Create("\');", 5902), true)
);

WriteLiteral(" />\r\n");

            
            #line 124 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5926), Tuple.Create("\"", 5967)
            
            #line 126 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5932), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5932), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 6010), Tuple.Create("\"", 6049)
            
            #line 127 "..\..\Views\T_ResultsForDrugTest\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 6016), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 6016), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n\r\n<script");

WriteLiteral(" type=\'text/javascript\'");

WriteLiteral(@">
    $(document).ready(function () {
        try {
            document.getElementsByTagName(""body"")[0].focus();
            $(""#addPopup"").removeAttr(""tabindex"");
            var cltcoll = $(""#dvPopup"").find('input[type=text]:not([class=hidden]):not([readonly]),textarea:not([readonly])');
            var cltid = """";
            $(cltcoll).each(function () {
			  if ($(this).attr(""id"") == undefined)
                    return
                var dvhidden = $(""#dv"" + $(this).attr(""id""));
				var dvDate = $(""#datetimepicker"" + $(this).attr(""id"")).attr(""id"");

                if (!(dvhidden.css('display') == 'none') && dvDate == undefined) {
                    cltid = $(this);
                    return false;
                }
            });
            if (cltid != """" && cltid != undefined)
                setTimeout(function () { $(cltid).focus(); }, 500);
			var ctrlReadonly = $(""#dvPopup"").find('input[type=text][readonly],textarea[readonly]');
            $(ctrlReadonly).each(function () {
                $(ctrlReadonly).attr(""tabindex"", ""-1"");
            });
        }
        catch (ex) { }
    });
</script>

");

        }
    }
}
#pragma warning restore 1591
