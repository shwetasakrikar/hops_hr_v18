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

namespace GeneratorBase.MVC.Views.T_Fund
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Fund/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Fund>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Fund\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Fund";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_Fund\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_Fund\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_Fund\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_FundIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_Fund\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_FundIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                             ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_Fund\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_FundIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Fund\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_FundIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                   ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_Fund\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_FundIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Fund\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_FundIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1462), Tuple.Create("\"", 1511)
, Tuple.Create(Tuple.Create("", 1469), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1469), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1539), Tuple.Create("\"", 1582)
            
            #line 53 "..\..\Views\T_Fund\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1546), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1546), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_Fund\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_Fund",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Fund\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Fund\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_Fund\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_Fund\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_Fund\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_Fund\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_Fund\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                 if(User.CanView("T_Fund","T_Code"))
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvT_Code\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Code\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 84 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Code));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_Fund\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Code, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_Fund\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_Fund\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_Fund\CreateQuick.cshtml"
					
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_Fund\CreateQuick.cshtml"
                     if(User.CanView("T_Fund","T_Description"))
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

            
            #line 98 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 99 "..\..\Views\T_Fund\CreateQuick.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_Fund\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 103 "..\..\Views\T_Fund\CreateQuick.cshtml"
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

            
            #line 110 "..\..\Views\T_Fund\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_Fund").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4576), Tuple.Create("\"", 4752)
, Tuple.Create(Tuple.Create("", 4586), Tuple.Create("QuickAdd(event,\'T_Fund\',\'", 4586), true)
            
            #line 117 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                 , Tuple.Create(Tuple.Create("", 4611), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4611), false)
, Tuple.Create(Tuple.Create("", 4624), Tuple.Create("\',", 4624), true)
            
            #line 117 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                , Tuple.Create(Tuple.Create("", 4626), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4626), false)
, Tuple.Create(Tuple.Create("", 4645), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4645), true)
            
            #line 117 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                       , Tuple.Create(Tuple.Create("", 4681), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4681), false)
, Tuple.Create(Tuple.Create("", 4700), Tuple.Create("\',\'", 4700), true)
            
            #line 117 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                             , Tuple.Create(Tuple.Create("", 4703), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4703), false)
, Tuple.Create(Tuple.Create("", 4726), Tuple.Create("\',\'", 4726), true)
            
            #line 117 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                                       , Tuple.Create(Tuple.Create("", 4729), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4729), false)
, Tuple.Create(Tuple.Create("", 4749), Tuple.Create("\');", 4749), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4861), Tuple.Create("\"", 5037)
, Tuple.Create(Tuple.Create("", 4871), Tuple.Create("QuickAdd(event,\'T_Fund\',\'", 4871), true)
            
            #line 118 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                          , Tuple.Create(Tuple.Create("", 4896), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4896), false)
, Tuple.Create(Tuple.Create("", 4909), Tuple.Create("\',", 4909), true)
            
            #line 118 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                         , Tuple.Create(Tuple.Create("", 4911), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4911), false)
, Tuple.Create(Tuple.Create("", 4930), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4930), true)
            
            #line 118 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                , Tuple.Create(Tuple.Create("", 4966), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4966), false)
, Tuple.Create(Tuple.Create("", 4985), Tuple.Create("\',\'", 4985), true)
            
            #line 118 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                                      , Tuple.Create(Tuple.Create("", 4988), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4988), false)
, Tuple.Create(Tuple.Create("", 5011), Tuple.Create("\',\'", 5011), true)
            
            #line 118 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 5014), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5014), false)
, Tuple.Create(Tuple.Create("", 5034), Tuple.Create("\');", 5034), true)
);

WriteLiteral(" />\r\n");

            
            #line 119 "..\..\Views\T_Fund\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5130), Tuple.Create("\"", 5350)
, Tuple.Create(Tuple.Create("", 5140), Tuple.Create("QuickAddFromIndex(event,true,\'T_Fund\',\'", 5140), true)
            
            #line 122 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                               , Tuple.Create(Tuple.Create("", 5179), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5179), false)
, Tuple.Create(Tuple.Create("", 5206), Tuple.Create("\',\'", 5206), true)
            
            #line 122 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                             , Tuple.Create(Tuple.Create("", 5209), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5209), false)
, Tuple.Create(Tuple.Create("", 5222), Tuple.Create("\',", 5222), true)
            
            #line 122 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                            , Tuple.Create(Tuple.Create("", 5224), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5224), false)
, Tuple.Create(Tuple.Create("", 5243), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5243), true)
            
            #line 122 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                                   , Tuple.Create(Tuple.Create("", 5279), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5279), false)
, Tuple.Create(Tuple.Create("", 5298), Tuple.Create("\',\'", 5298), true)
            
            #line 122 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                                                         , Tuple.Create(Tuple.Create("", 5301), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5301), false)
, Tuple.Create(Tuple.Create("", 5324), Tuple.Create("\',\'", 5324), true)
            
            #line 122 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                                                                                   , Tuple.Create(Tuple.Create("", 5327), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5327), false)
, Tuple.Create(Tuple.Create("", 5347), Tuple.Create("\');", 5347), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5458), Tuple.Create("\"", 5678)
, Tuple.Create(Tuple.Create("", 5468), Tuple.Create("QuickAddFromIndex(event,true,\'T_Fund\',\'", 5468), true)
            
            #line 123 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                       , Tuple.Create(Tuple.Create("", 5507), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5507), false)
, Tuple.Create(Tuple.Create("", 5534), Tuple.Create("\',\'", 5534), true)
            
            #line 123 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                     , Tuple.Create(Tuple.Create("", 5537), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5537), false)
, Tuple.Create(Tuple.Create("", 5550), Tuple.Create("\',", 5550), true)
            
            #line 123 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                    , Tuple.Create(Tuple.Create("", 5552), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5552), false)
, Tuple.Create(Tuple.Create("", 5571), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5571), true)
            
            #line 123 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                                                           , Tuple.Create(Tuple.Create("", 5607), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5607), false)
, Tuple.Create(Tuple.Create("", 5626), Tuple.Create("\',\'", 5626), true)
            
            #line 123 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                                                                                 , Tuple.Create(Tuple.Create("", 5629), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5629), false)
, Tuple.Create(Tuple.Create("", 5652), Tuple.Create("\',\'", 5652), true)
            
            #line 123 "..\..\Views\T_Fund\CreateQuick.cshtml"
                                                                                                                                                                                                                           , Tuple.Create(Tuple.Create("", 5655), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5655), false)
, Tuple.Create(Tuple.Create("", 5675), Tuple.Create("\');", 5675), true)
);

WriteLiteral(" />\r\n");

            
            #line 124 "..\..\Views\T_Fund\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5699), Tuple.Create("\"", 5740)
            
            #line 126 "..\..\Views\T_Fund\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5705), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5705), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5783), Tuple.Create("\"", 5822)
            
            #line 127 "..\..\Views\T_Fund\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5789), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 5789), false)
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
