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

namespace GeneratorBase.MVC.Views.T_Commenttype
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Commenttype/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Commenttype>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Comment Type";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CommenttypeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CommenttypeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CommenttypeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CommenttypeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CommenttypeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CommenttypeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1519), Tuple.Create("\"", 1568)
, Tuple.Create(Tuple.Create("", 1526), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1526), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1596), Tuple.Create("\"", 1639)
            
            #line 53 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1603), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1603), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_Commenttype",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                 if(User.CanView("T_Commenttype","T_Name"))
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 84 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
					
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                     if(User.CanView("T_Commenttype","T_Description"))
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 98 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 99 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 103 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
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

            
            #line 110 "..\..\Views\T_Commenttype\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_Commenttype").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4646), Tuple.Create("\"", 4829)
, Tuple.Create(Tuple.Create("", 4656), Tuple.Create("QuickAdd(event,\'T_Commenttype\',\'", 4656), true)
            
            #line 117 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                        , Tuple.Create(Tuple.Create("", 4688), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4688), false)
, Tuple.Create(Tuple.Create("", 4701), Tuple.Create("\',", 4701), true)
            
            #line 117 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                       , Tuple.Create(Tuple.Create("", 4703), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4703), false)
, Tuple.Create(Tuple.Create("", 4722), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4722), true)
            
            #line 117 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                              , Tuple.Create(Tuple.Create("", 4758), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4758), false)
, Tuple.Create(Tuple.Create("", 4777), Tuple.Create("\',\'", 4777), true)
            
            #line 117 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                    , Tuple.Create(Tuple.Create("", 4780), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4780), false)
, Tuple.Create(Tuple.Create("", 4803), Tuple.Create("\',\'", 4803), true)
            
            #line 117 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                                              , Tuple.Create(Tuple.Create("", 4806), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4806), false)
, Tuple.Create(Tuple.Create("", 4826), Tuple.Create("\');", 4826), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4938), Tuple.Create("\"", 5121)
, Tuple.Create(Tuple.Create("", 4948), Tuple.Create("QuickAdd(event,\'T_Commenttype\',\'", 4948), true)
            
            #line 118 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                 , Tuple.Create(Tuple.Create("", 4980), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4980), false)
, Tuple.Create(Tuple.Create("", 4993), Tuple.Create("\',", 4993), true)
            
            #line 118 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                , Tuple.Create(Tuple.Create("", 4995), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4995), false)
, Tuple.Create(Tuple.Create("", 5014), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5014), true)
            
            #line 118 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                       , Tuple.Create(Tuple.Create("", 5050), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5050), false)
, Tuple.Create(Tuple.Create("", 5069), Tuple.Create("\',\'", 5069), true)
            
            #line 118 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                                             , Tuple.Create(Tuple.Create("", 5072), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5072), false)
, Tuple.Create(Tuple.Create("", 5095), Tuple.Create("\',\'", 5095), true)
            
            #line 118 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                                                                       , Tuple.Create(Tuple.Create("", 5098), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5098), false)
, Tuple.Create(Tuple.Create("", 5118), Tuple.Create("\');", 5118), true)
);

WriteLiteral(" />\r\n");

            
            #line 119 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5214), Tuple.Create("\"", 5441)
, Tuple.Create(Tuple.Create("", 5224), Tuple.Create("QuickAddFromIndex(event,true,\'T_Commenttype\',\'", 5224), true)
            
            #line 122 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 5270), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5270), false)
, Tuple.Create(Tuple.Create("", 5297), Tuple.Create("\',\'", 5297), true)
            
            #line 122 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                    , Tuple.Create(Tuple.Create("", 5300), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5300), false)
, Tuple.Create(Tuple.Create("", 5313), Tuple.Create("\',", 5313), true)
            
            #line 122 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                   , Tuple.Create(Tuple.Create("", 5315), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5315), false)
, Tuple.Create(Tuple.Create("", 5334), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5334), true)
            
            #line 122 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                                          , Tuple.Create(Tuple.Create("", 5370), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5370), false)
, Tuple.Create(Tuple.Create("", 5389), Tuple.Create("\',\'", 5389), true)
            
            #line 122 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 5392), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5392), false)
, Tuple.Create(Tuple.Create("", 5415), Tuple.Create("\',\'", 5415), true)
            
            #line 122 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 5418), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5418), false)
, Tuple.Create(Tuple.Create("", 5438), Tuple.Create("\');", 5438), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5549), Tuple.Create("\"", 5776)
, Tuple.Create(Tuple.Create("", 5559), Tuple.Create("QuickAddFromIndex(event,true,\'T_Commenttype\',\'", 5559), true)
            
            #line 123 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                              , Tuple.Create(Tuple.Create("", 5605), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5605), false)
, Tuple.Create(Tuple.Create("", 5632), Tuple.Create("\',\'", 5632), true)
            
            #line 123 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                            , Tuple.Create(Tuple.Create("", 5635), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5635), false)
, Tuple.Create(Tuple.Create("", 5648), Tuple.Create("\',", 5648), true)
            
            #line 123 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                           , Tuple.Create(Tuple.Create("", 5650), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5650), false)
, Tuple.Create(Tuple.Create("", 5669), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5669), true)
            
            #line 123 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 5705), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5705), false)
, Tuple.Create(Tuple.Create("", 5724), Tuple.Create("\',\'", 5724), true)
            
            #line 123 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                                                                                        , Tuple.Create(Tuple.Create("", 5727), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5727), false)
, Tuple.Create(Tuple.Create("", 5750), Tuple.Create("\',\'", 5750), true)
            
            #line 123 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
                                                                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 5753), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5753), false)
, Tuple.Create(Tuple.Create("", 5773), Tuple.Create("\');", 5773), true)
);

WriteLiteral(" />\r\n");

            
            #line 124 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5797), Tuple.Create("\"", 5838)
            
            #line 126 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5803), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5803), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5881), Tuple.Create("\"", 5920)
            
            #line 127 "..\..\Views\T_Commenttype\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5887), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 5887), false)
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