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

namespace GeneratorBase.MVC.Views.T_BodyPartsAffected
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_BodyPartsAffected/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_BodyPartsAffected>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Body Parts Affected";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_BodyPartsAffectedIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_BodyPartsAffectedIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_BodyPartsAffectedIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_BodyPartsAffectedIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_BodyPartsAffectedIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_BodyPartsAffectedIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                              ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1568), Tuple.Create("\"", 1617)
, Tuple.Create(Tuple.Create("", 1575), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1575), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1645), Tuple.Create("\"", 1688)
            
            #line 53 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1652), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1652), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_BodyPartsAffected",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                 if(User.CanView("T_BodyPartsAffected","T_Name"))
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

            
            #line 84 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
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

            
            #line 100 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_BodyPartsAffected").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4157), Tuple.Create("\"", 4346)
, Tuple.Create(Tuple.Create("", 4167), Tuple.Create("QuickAdd(event,\'T_BodyPartsAffected\',\'", 4167), true)
            
            #line 107 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                              , Tuple.Create(Tuple.Create("", 4205), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4205), false)
, Tuple.Create(Tuple.Create("", 4218), Tuple.Create("\',", 4218), true)
            
            #line 107 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                             , Tuple.Create(Tuple.Create("", 4220), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4220), false)
, Tuple.Create(Tuple.Create("", 4239), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4239), true)
            
            #line 107 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                    , Tuple.Create(Tuple.Create("", 4275), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4275), false)
, Tuple.Create(Tuple.Create("", 4294), Tuple.Create("\',\'", 4294), true)
            
            #line 107 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                          , Tuple.Create(Tuple.Create("", 4297), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4297), false)
, Tuple.Create(Tuple.Create("", 4320), Tuple.Create("\',\'", 4320), true)
            
            #line 107 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 4323), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4323), false)
, Tuple.Create(Tuple.Create("", 4343), Tuple.Create("\');", 4343), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4455), Tuple.Create("\"", 4644)
, Tuple.Create(Tuple.Create("", 4465), Tuple.Create("QuickAdd(event,\'T_BodyPartsAffected\',\'", 4465), true)
            
            #line 108 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                       , Tuple.Create(Tuple.Create("", 4503), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4503), false)
, Tuple.Create(Tuple.Create("", 4516), Tuple.Create("\',", 4516), true)
            
            #line 108 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                      , Tuple.Create(Tuple.Create("", 4518), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4518), false)
, Tuple.Create(Tuple.Create("", 4537), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4537), true)
            
            #line 108 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                             , Tuple.Create(Tuple.Create("", 4573), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4573), false)
, Tuple.Create(Tuple.Create("", 4592), Tuple.Create("\',\'", 4592), true)
            
            #line 108 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                                                   , Tuple.Create(Tuple.Create("", 4595), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4595), false)
, Tuple.Create(Tuple.Create("", 4618), Tuple.Create("\',\'", 4618), true)
            
            #line 108 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                                                                             , Tuple.Create(Tuple.Create("", 4621), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4621), false)
, Tuple.Create(Tuple.Create("", 4641), Tuple.Create("\');", 4641), true)
);

WriteLiteral(" />\r\n");

            
            #line 109 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4737), Tuple.Create("\"", 4970)
, Tuple.Create(Tuple.Create("", 4747), Tuple.Create("QuickAddFromIndex(event,true,\'T_BodyPartsAffected\',\'", 4747), true)
            
            #line 112 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                            , Tuple.Create(Tuple.Create("", 4799), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 4799), false)
, Tuple.Create(Tuple.Create("", 4826), Tuple.Create("\',\'", 4826), true)
            
            #line 112 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                          , Tuple.Create(Tuple.Create("", 4829), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4829), false)
, Tuple.Create(Tuple.Create("", 4842), Tuple.Create("\',", 4842), true)
            
            #line 112 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                         , Tuple.Create(Tuple.Create("", 4844), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4844), false)
, Tuple.Create(Tuple.Create("", 4863), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4863), true)
            
            #line 112 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                                                , Tuple.Create(Tuple.Create("", 4899), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4899), false)
, Tuple.Create(Tuple.Create("", 4918), Tuple.Create("\',\'", 4918), true)
            
            #line 112 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 4921), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4921), false)
, Tuple.Create(Tuple.Create("", 4944), Tuple.Create("\',\'", 4944), true)
            
            #line 112 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 4947), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4947), false)
, Tuple.Create(Tuple.Create("", 4967), Tuple.Create("\');", 4967), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5078), Tuple.Create("\"", 5311)
, Tuple.Create(Tuple.Create("", 5088), Tuple.Create("QuickAddFromIndex(event,true,\'T_BodyPartsAffected\',\'", 5088), true)
            
            #line 113 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                    , Tuple.Create(Tuple.Create("", 5140), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5140), false)
, Tuple.Create(Tuple.Create("", 5167), Tuple.Create("\',\'", 5167), true)
            
            #line 113 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                  , Tuple.Create(Tuple.Create("", 5170), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5170), false)
, Tuple.Create(Tuple.Create("", 5183), Tuple.Create("\',", 5183), true)
            
            #line 113 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                 , Tuple.Create(Tuple.Create("", 5185), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5185), false)
, Tuple.Create(Tuple.Create("", 5204), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5204), true)
            
            #line 113 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                                                                        , Tuple.Create(Tuple.Create("", 5240), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5240), false)
, Tuple.Create(Tuple.Create("", 5259), Tuple.Create("\',\'", 5259), true)
            
            #line 113 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 5262), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5262), false)
, Tuple.Create(Tuple.Create("", 5285), Tuple.Create("\',\'", 5285), true)
            
            #line 113 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
                                                                                                                                                                                                                                        , Tuple.Create(Tuple.Create("", 5288), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5288), false)
, Tuple.Create(Tuple.Create("", 5308), Tuple.Create("\');", 5308), true)
);

WriteLiteral(" />\r\n");

            
            #line 114 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5332), Tuple.Create("\"", 5373)
            
            #line 116 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5338), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5338), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5416), Tuple.Create("\"", 5455)
            
            #line 117 "..\..\Views\T_BodyPartsAffected\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5422), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 5422), false)
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
