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

namespace GeneratorBase.MVC.Views.T_RetainTable
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_RetainTable/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_RetainTable>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
  
    ViewBag.Title = "Create RetainTable";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RetainTableIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_RetainTableIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RetainTableIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_RetainTableIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RetainTableIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_RetainTableIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1518), Tuple.Create("\"", 1567)
, Tuple.Create(Tuple.Create("", 1525), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1525), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1595), Tuple.Create("\"", 1638)
            
            #line 53 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1602), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1602), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_RetainTable",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                 if(User.CanView("T_RetainTable","T_Name"))
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

            
            #line 84 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n       </div>\r\n                        </div>\r\n                    <" +
"/div>\r\n                </div>\r\n        </div>\r\n");

WriteLiteral("\t\t<button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

            
            #line 100 "..\..\Views\T_RetainTable\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_RetainTable").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4089), Tuple.Create("\"", 4272)
, Tuple.Create(Tuple.Create("", 4099), Tuple.Create("QuickAdd(event,\'T_RetainTable\',\'", 4099), true)
            
            #line 107 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                        , Tuple.Create(Tuple.Create("", 4131), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4131), false)
, Tuple.Create(Tuple.Create("", 4144), Tuple.Create("\',", 4144), true)
            
            #line 107 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                       , Tuple.Create(Tuple.Create("", 4146), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4146), false)
, Tuple.Create(Tuple.Create("", 4165), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4165), true)
            
            #line 107 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                              , Tuple.Create(Tuple.Create("", 4201), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4201), false)
, Tuple.Create(Tuple.Create("", 4220), Tuple.Create("\',\'", 4220), true)
            
            #line 107 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                    , Tuple.Create(Tuple.Create("", 4223), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4223), false)
, Tuple.Create(Tuple.Create("", 4246), Tuple.Create("\',\'", 4246), true)
            
            #line 107 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                                              , Tuple.Create(Tuple.Create("", 4249), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4249), false)
, Tuple.Create(Tuple.Create("", 4269), Tuple.Create("\');", 4269), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4381), Tuple.Create("\"", 4564)
, Tuple.Create(Tuple.Create("", 4391), Tuple.Create("QuickAdd(event,\'T_RetainTable\',\'", 4391), true)
            
            #line 108 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                 , Tuple.Create(Tuple.Create("", 4423), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4423), false)
, Tuple.Create(Tuple.Create("", 4436), Tuple.Create("\',", 4436), true)
            
            #line 108 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                , Tuple.Create(Tuple.Create("", 4438), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4438), false)
, Tuple.Create(Tuple.Create("", 4457), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4457), true)
            
            #line 108 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                       , Tuple.Create(Tuple.Create("", 4493), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4493), false)
, Tuple.Create(Tuple.Create("", 4512), Tuple.Create("\',\'", 4512), true)
            
            #line 108 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                                             , Tuple.Create(Tuple.Create("", 4515), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4515), false)
, Tuple.Create(Tuple.Create("", 4538), Tuple.Create("\',\'", 4538), true)
            
            #line 108 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                                                                       , Tuple.Create(Tuple.Create("", 4541), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4541), false)
, Tuple.Create(Tuple.Create("", 4561), Tuple.Create("\');", 4561), true)
);

WriteLiteral(" />\r\n");

            
            #line 109 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4657), Tuple.Create("\"", 4884)
, Tuple.Create(Tuple.Create("", 4667), Tuple.Create("QuickAddFromIndex(event,true,\'T_RetainTable\',\'", 4667), true)
            
            #line 112 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 4713), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 4713), false)
, Tuple.Create(Tuple.Create("", 4740), Tuple.Create("\',\'", 4740), true)
            
            #line 112 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                    , Tuple.Create(Tuple.Create("", 4743), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4743), false)
, Tuple.Create(Tuple.Create("", 4756), Tuple.Create("\',", 4756), true)
            
            #line 112 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                   , Tuple.Create(Tuple.Create("", 4758), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4758), false)
, Tuple.Create(Tuple.Create("", 4777), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4777), true)
            
            #line 112 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                                          , Tuple.Create(Tuple.Create("", 4813), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4813), false)
, Tuple.Create(Tuple.Create("", 4832), Tuple.Create("\',\'", 4832), true)
            
            #line 112 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 4835), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4835), false)
, Tuple.Create(Tuple.Create("", 4858), Tuple.Create("\',\'", 4858), true)
            
            #line 112 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 4861), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4861), false)
, Tuple.Create(Tuple.Create("", 4881), Tuple.Create("\');", 4881), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4992), Tuple.Create("\"", 5219)
, Tuple.Create(Tuple.Create("", 5002), Tuple.Create("QuickAddFromIndex(event,true,\'T_RetainTable\',\'", 5002), true)
            
            #line 113 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                              , Tuple.Create(Tuple.Create("", 5048), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5048), false)
, Tuple.Create(Tuple.Create("", 5075), Tuple.Create("\',\'", 5075), true)
            
            #line 113 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                            , Tuple.Create(Tuple.Create("", 5078), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5078), false)
, Tuple.Create(Tuple.Create("", 5091), Tuple.Create("\',", 5091), true)
            
            #line 113 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                           , Tuple.Create(Tuple.Create("", 5093), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5093), false)
, Tuple.Create(Tuple.Create("", 5112), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5112), true)
            
            #line 113 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 5148), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5148), false)
, Tuple.Create(Tuple.Create("", 5167), Tuple.Create("\',\'", 5167), true)
            
            #line 113 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                                                                                        , Tuple.Create(Tuple.Create("", 5170), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5170), false)
, Tuple.Create(Tuple.Create("", 5193), Tuple.Create("\',\'", 5193), true)
            
            #line 113 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
                                                                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 5196), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5196), false)
, Tuple.Create(Tuple.Create("", 5216), Tuple.Create("\');", 5216), true)
);

WriteLiteral(" />\r\n");

            
            #line 114 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5240), Tuple.Create("\"", 5281)
            
            #line 116 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5246), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5246), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5324), Tuple.Create("\"", 5363)
            
            #line 117 "..\..\Views\T_RetainTable\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5330), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 5330), false)
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