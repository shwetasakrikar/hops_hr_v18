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

namespace GeneratorBase.MVC.Views.T_Race
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Race/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Race>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Race\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Race";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_Race\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_Race\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_Race\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RaceIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_Race\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_RaceIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_Race\CreateQuick.cshtml"
                                             ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_Race\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RaceIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Race\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_RaceIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                   ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_Race\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RaceIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Race\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_RaceIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Race\CreateQuick.cshtml"
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
            
            #line 53 "..\..\Views\T_Race\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1546), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1546), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_Race\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_Race",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Race\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Race\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_Race\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_Race\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_Race\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_Race\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_Race\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_Race\CreateQuick.cshtml"
                                 if(User.CanView("T_Race","T_Name"))
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

            
            #line 84 "..\..\Views\T_Race\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_Race\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_Race\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_Race\CreateQuick.cshtml"
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

            
            #line 100 "..\..\Views\T_Race\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_Race").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4012), Tuple.Create("\"", 4188)
, Tuple.Create(Tuple.Create("", 4022), Tuple.Create("QuickAdd(event,\'T_Race\',\'", 4022), true)
            
            #line 107 "..\..\Views\T_Race\CreateQuick.cshtml"
                                 , Tuple.Create(Tuple.Create("", 4047), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4047), false)
, Tuple.Create(Tuple.Create("", 4060), Tuple.Create("\',", 4060), true)
            
            #line 107 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                , Tuple.Create(Tuple.Create("", 4062), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4062), false)
, Tuple.Create(Tuple.Create("", 4081), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4081), true)
            
            #line 107 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                       , Tuple.Create(Tuple.Create("", 4117), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4117), false)
, Tuple.Create(Tuple.Create("", 4136), Tuple.Create("\',\'", 4136), true)
            
            #line 107 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                             , Tuple.Create(Tuple.Create("", 4139), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4139), false)
, Tuple.Create(Tuple.Create("", 4162), Tuple.Create("\',\'", 4162), true)
            
            #line 107 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                                       , Tuple.Create(Tuple.Create("", 4165), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4165), false)
, Tuple.Create(Tuple.Create("", 4185), Tuple.Create("\');", 4185), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4297), Tuple.Create("\"", 4473)
, Tuple.Create(Tuple.Create("", 4307), Tuple.Create("QuickAdd(event,\'T_Race\',\'", 4307), true)
            
            #line 108 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                          , Tuple.Create(Tuple.Create("", 4332), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4332), false)
, Tuple.Create(Tuple.Create("", 4345), Tuple.Create("\',", 4345), true)
            
            #line 108 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                         , Tuple.Create(Tuple.Create("", 4347), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4347), false)
, Tuple.Create(Tuple.Create("", 4366), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4366), true)
            
            #line 108 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                , Tuple.Create(Tuple.Create("", 4402), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4402), false)
, Tuple.Create(Tuple.Create("", 4421), Tuple.Create("\',\'", 4421), true)
            
            #line 108 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                                      , Tuple.Create(Tuple.Create("", 4424), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4424), false)
, Tuple.Create(Tuple.Create("", 4447), Tuple.Create("\',\'", 4447), true)
            
            #line 108 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 4450), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4450), false)
, Tuple.Create(Tuple.Create("", 4470), Tuple.Create("\');", 4470), true)
);

WriteLiteral(" />\r\n");

            
            #line 109 "..\..\Views\T_Race\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4566), Tuple.Create("\"", 4786)
, Tuple.Create(Tuple.Create("", 4576), Tuple.Create("QuickAddFromIndex(event,true,\'T_Race\',\'", 4576), true)
            
            #line 112 "..\..\Views\T_Race\CreateQuick.cshtml"
                                               , Tuple.Create(Tuple.Create("", 4615), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 4615), false)
, Tuple.Create(Tuple.Create("", 4642), Tuple.Create("\',\'", 4642), true)
            
            #line 112 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                             , Tuple.Create(Tuple.Create("", 4645), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4645), false)
, Tuple.Create(Tuple.Create("", 4658), Tuple.Create("\',", 4658), true)
            
            #line 112 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                            , Tuple.Create(Tuple.Create("", 4660), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4660), false)
, Tuple.Create(Tuple.Create("", 4679), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4679), true)
            
            #line 112 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                                   , Tuple.Create(Tuple.Create("", 4715), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4715), false)
, Tuple.Create(Tuple.Create("", 4734), Tuple.Create("\',\'", 4734), true)
            
            #line 112 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                                                         , Tuple.Create(Tuple.Create("", 4737), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4737), false)
, Tuple.Create(Tuple.Create("", 4760), Tuple.Create("\',\'", 4760), true)
            
            #line 112 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                                                                                   , Tuple.Create(Tuple.Create("", 4763), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4763), false)
, Tuple.Create(Tuple.Create("", 4783), Tuple.Create("\');", 4783), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4894), Tuple.Create("\"", 5114)
, Tuple.Create(Tuple.Create("", 4904), Tuple.Create("QuickAddFromIndex(event,true,\'T_Race\',\'", 4904), true)
            
            #line 113 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                       , Tuple.Create(Tuple.Create("", 4943), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 4943), false)
, Tuple.Create(Tuple.Create("", 4970), Tuple.Create("\',\'", 4970), true)
            
            #line 113 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                     , Tuple.Create(Tuple.Create("", 4973), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4973), false)
, Tuple.Create(Tuple.Create("", 4986), Tuple.Create("\',", 4986), true)
            
            #line 113 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                    , Tuple.Create(Tuple.Create("", 4988), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4988), false)
, Tuple.Create(Tuple.Create("", 5007), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5007), true)
            
            #line 113 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                                                           , Tuple.Create(Tuple.Create("", 5043), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5043), false)
, Tuple.Create(Tuple.Create("", 5062), Tuple.Create("\',\'", 5062), true)
            
            #line 113 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                                                                                 , Tuple.Create(Tuple.Create("", 5065), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5065), false)
, Tuple.Create(Tuple.Create("", 5088), Tuple.Create("\',\'", 5088), true)
            
            #line 113 "..\..\Views\T_Race\CreateQuick.cshtml"
                                                                                                                                                                                                                           , Tuple.Create(Tuple.Create("", 5091), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5091), false)
, Tuple.Create(Tuple.Create("", 5111), Tuple.Create("\');", 5111), true)
);

WriteLiteral(" />\r\n");

            
            #line 114 "..\..\Views\T_Race\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5135), Tuple.Create("\"", 5176)
            
            #line 116 "..\..\Views\T_Race\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5141), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5141), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5219), Tuple.Create("\"", 5258)
            
            #line 117 "..\..\Views\T_Race\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5225), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 5225), false)
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
