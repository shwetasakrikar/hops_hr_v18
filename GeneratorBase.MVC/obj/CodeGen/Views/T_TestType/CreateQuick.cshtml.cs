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

namespace GeneratorBase.MVC.Views.T_TestType
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_TestType/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_TestType>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_TestType\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Test Type";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_TestType\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_TestType\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_TestType\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TestTypeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_TestType\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_TestTypeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_TestType\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TestTypeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_TestType\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_TestTypeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                       ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_TestType\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TestTypeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_TestType\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_TestTypeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                     ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1495), Tuple.Create("\"", 1544)
, Tuple.Create(Tuple.Create("", 1502), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1502), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1572), Tuple.Create("\"", 1615)
            
            #line 53 "..\..\Views\T_TestType\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1579), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1579), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_TestType\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_TestType",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_TestType\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_TestType\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_TestType\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_TestType\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_TestType\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_TestType\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_TestType\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                 if(User.CanView("T_TestType","T_Name"))
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

            
            #line 84 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_TestType\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_TestType\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_TestType\CreateQuick.cshtml"
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

            
            #line 100 "..\..\Views\T_TestType\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_TestType").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4057), Tuple.Create("\"", 4237)
, Tuple.Create(Tuple.Create("", 4067), Tuple.Create("QuickAdd(event,\'T_TestType\',\'", 4067), true)
            
            #line 107 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                     , Tuple.Create(Tuple.Create("", 4096), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4096), false)
, Tuple.Create(Tuple.Create("", 4109), Tuple.Create("\',", 4109), true)
            
            #line 107 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                    , Tuple.Create(Tuple.Create("", 4111), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4111), false)
, Tuple.Create(Tuple.Create("", 4130), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4130), true)
            
            #line 107 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                           , Tuple.Create(Tuple.Create("", 4166), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4166), false)
, Tuple.Create(Tuple.Create("", 4185), Tuple.Create("\',\'", 4185), true)
            
            #line 107 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                 , Tuple.Create(Tuple.Create("", 4188), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4188), false)
, Tuple.Create(Tuple.Create("", 4211), Tuple.Create("\',\'", 4211), true)
            
            #line 107 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                                           , Tuple.Create(Tuple.Create("", 4214), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4214), false)
, Tuple.Create(Tuple.Create("", 4234), Tuple.Create("\');", 4234), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4346), Tuple.Create("\"", 4526)
, Tuple.Create(Tuple.Create("", 4356), Tuple.Create("QuickAdd(event,\'T_TestType\',\'", 4356), true)
            
            #line 108 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                              , Tuple.Create(Tuple.Create("", 4385), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4385), false)
, Tuple.Create(Tuple.Create("", 4398), Tuple.Create("\',", 4398), true)
            
            #line 108 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                             , Tuple.Create(Tuple.Create("", 4400), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4400), false)
, Tuple.Create(Tuple.Create("", 4419), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4419), true)
            
            #line 108 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                    , Tuple.Create(Tuple.Create("", 4455), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4455), false)
, Tuple.Create(Tuple.Create("", 4474), Tuple.Create("\',\'", 4474), true)
            
            #line 108 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                                          , Tuple.Create(Tuple.Create("", 4477), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4477), false)
, Tuple.Create(Tuple.Create("", 4500), Tuple.Create("\',\'", 4500), true)
            
            #line 108 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 4503), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4503), false)
, Tuple.Create(Tuple.Create("", 4523), Tuple.Create("\');", 4523), true)
);

WriteLiteral(" />\r\n");

            
            #line 109 "..\..\Views\T_TestType\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4619), Tuple.Create("\"", 4843)
, Tuple.Create(Tuple.Create("", 4629), Tuple.Create("QuickAddFromIndex(event,true,\'T_TestType\',\'", 4629), true)
            
            #line 112 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                   , Tuple.Create(Tuple.Create("", 4672), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 4672), false)
, Tuple.Create(Tuple.Create("", 4699), Tuple.Create("\',\'", 4699), true)
            
            #line 112 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                 , Tuple.Create(Tuple.Create("", 4702), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4702), false)
, Tuple.Create(Tuple.Create("", 4715), Tuple.Create("\',", 4715), true)
            
            #line 112 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                , Tuple.Create(Tuple.Create("", 4717), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4717), false)
, Tuple.Create(Tuple.Create("", 4736), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4736), true)
            
            #line 112 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                                       , Tuple.Create(Tuple.Create("", 4772), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4772), false)
, Tuple.Create(Tuple.Create("", 4791), Tuple.Create("\',\'", 4791), true)
            
            #line 112 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                                                             , Tuple.Create(Tuple.Create("", 4794), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4794), false)
, Tuple.Create(Tuple.Create("", 4817), Tuple.Create("\',\'", 4817), true)
            
            #line 112 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                                                                                       , Tuple.Create(Tuple.Create("", 4820), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4820), false)
, Tuple.Create(Tuple.Create("", 4840), Tuple.Create("\');", 4840), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4951), Tuple.Create("\"", 5175)
, Tuple.Create(Tuple.Create("", 4961), Tuple.Create("QuickAddFromIndex(event,true,\'T_TestType\',\'", 4961), true)
            
            #line 113 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                           , Tuple.Create(Tuple.Create("", 5004), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5004), false)
, Tuple.Create(Tuple.Create("", 5031), Tuple.Create("\',\'", 5031), true)
            
            #line 113 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                         , Tuple.Create(Tuple.Create("", 5034), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5034), false)
, Tuple.Create(Tuple.Create("", 5047), Tuple.Create("\',", 5047), true)
            
            #line 113 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                        , Tuple.Create(Tuple.Create("", 5049), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5049), false)
, Tuple.Create(Tuple.Create("", 5068), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5068), true)
            
            #line 113 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                                                               , Tuple.Create(Tuple.Create("", 5104), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5104), false)
, Tuple.Create(Tuple.Create("", 5123), Tuple.Create("\',\'", 5123), true)
            
            #line 113 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                                                                                     , Tuple.Create(Tuple.Create("", 5126), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5126), false)
, Tuple.Create(Tuple.Create("", 5149), Tuple.Create("\',\'", 5149), true)
            
            #line 113 "..\..\Views\T_TestType\CreateQuick.cshtml"
                                                                                                                                                                                                                               , Tuple.Create(Tuple.Create("", 5152), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5152), false)
, Tuple.Create(Tuple.Create("", 5172), Tuple.Create("\');", 5172), true)
);

WriteLiteral(" />\r\n");

            
            #line 114 "..\..\Views\T_TestType\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5196), Tuple.Create("\"", 5237)
            
            #line 116 "..\..\Views\T_TestType\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5202), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5202), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5280), Tuple.Create("\"", 5319)
            
            #line 117 "..\..\Views\T_TestType\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5286), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 5286), false)
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