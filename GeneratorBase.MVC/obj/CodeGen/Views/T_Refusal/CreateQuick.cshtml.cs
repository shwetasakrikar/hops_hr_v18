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

namespace GeneratorBase.MVC.Views.T_Refusal
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Refusal/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Refusal>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Refusal\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Refusal";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_Refusal\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_Refusal\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_Refusal\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RefusalIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_Refusal\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_RefusalIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_Refusal\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RefusalIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Refusal\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_RefusalIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                      ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_Refusal\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RefusalIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Refusal\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_RefusalIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1486), Tuple.Create("\"", 1535)
, Tuple.Create(Tuple.Create("", 1493), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1493), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1563), Tuple.Create("\"", 1606)
            
            #line 53 "..\..\Views\T_Refusal\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1570), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1570), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_Refusal\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_Refusal",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Refusal\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_Refusal\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_Refusal\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_Refusal\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_Refusal\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_Refusal\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                 if(User.CanView("T_Refusal","T_Name"))
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

            
            #line 84 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_Refusal\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_Refusal\CreateQuick.cshtml"
					
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                     if(User.CanView("T_Refusal","T_Description"))
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

            
            #line 98 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 99 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 103 "..\..\Views\T_Refusal\CreateQuick.cshtml"
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

            
            #line 110 "..\..\Views\T_Refusal\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_Refusal").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4612), Tuple.Create("\"", 4791)
, Tuple.Create(Tuple.Create("", 4622), Tuple.Create("QuickAdd(event,\'T_Refusal\',\'", 4622), true)
            
            #line 117 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                    , Tuple.Create(Tuple.Create("", 4650), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4650), false)
, Tuple.Create(Tuple.Create("", 4663), Tuple.Create("\',", 4663), true)
            
            #line 117 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                   , Tuple.Create(Tuple.Create("", 4665), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4665), false)
, Tuple.Create(Tuple.Create("", 4684), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4684), true)
            
            #line 117 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                          , Tuple.Create(Tuple.Create("", 4720), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4720), false)
, Tuple.Create(Tuple.Create("", 4739), Tuple.Create("\',\'", 4739), true)
            
            #line 117 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                , Tuple.Create(Tuple.Create("", 4742), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4742), false)
, Tuple.Create(Tuple.Create("", 4765), Tuple.Create("\',\'", 4765), true)
            
            #line 117 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                                          , Tuple.Create(Tuple.Create("", 4768), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4768), false)
, Tuple.Create(Tuple.Create("", 4788), Tuple.Create("\');", 4788), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4900), Tuple.Create("\"", 5079)
, Tuple.Create(Tuple.Create("", 4910), Tuple.Create("QuickAdd(event,\'T_Refusal\',\'", 4910), true)
            
            #line 118 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                             , Tuple.Create(Tuple.Create("", 4938), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4938), false)
, Tuple.Create(Tuple.Create("", 4951), Tuple.Create("\',", 4951), true)
            
            #line 118 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                            , Tuple.Create(Tuple.Create("", 4953), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4953), false)
, Tuple.Create(Tuple.Create("", 4972), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4972), true)
            
            #line 118 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                   , Tuple.Create(Tuple.Create("", 5008), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5008), false)
, Tuple.Create(Tuple.Create("", 5027), Tuple.Create("\',\'", 5027), true)
            
            #line 118 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                                         , Tuple.Create(Tuple.Create("", 5030), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5030), false)
, Tuple.Create(Tuple.Create("", 5053), Tuple.Create("\',\'", 5053), true)
            
            #line 118 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                                                                   , Tuple.Create(Tuple.Create("", 5056), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5056), false)
, Tuple.Create(Tuple.Create("", 5076), Tuple.Create("\');", 5076), true)
);

WriteLiteral(" />\r\n");

            
            #line 119 "..\..\Views\T_Refusal\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5172), Tuple.Create("\"", 5395)
, Tuple.Create(Tuple.Create("", 5182), Tuple.Create("QuickAddFromIndex(event,true,\'T_Refusal\',\'", 5182), true)
            
            #line 122 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                  , Tuple.Create(Tuple.Create("", 5224), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5224), false)
, Tuple.Create(Tuple.Create("", 5251), Tuple.Create("\',\'", 5251), true)
            
            #line 122 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                , Tuple.Create(Tuple.Create("", 5254), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5254), false)
, Tuple.Create(Tuple.Create("", 5267), Tuple.Create("\',", 5267), true)
            
            #line 122 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                               , Tuple.Create(Tuple.Create("", 5269), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5269), false)
, Tuple.Create(Tuple.Create("", 5288), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5288), true)
            
            #line 122 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                                      , Tuple.Create(Tuple.Create("", 5324), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5324), false)
, Tuple.Create(Tuple.Create("", 5343), Tuple.Create("\',\'", 5343), true)
            
            #line 122 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 5346), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5346), false)
, Tuple.Create(Tuple.Create("", 5369), Tuple.Create("\',\'", 5369), true)
            
            #line 122 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 5372), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5372), false)
, Tuple.Create(Tuple.Create("", 5392), Tuple.Create("\');", 5392), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5503), Tuple.Create("\"", 5726)
, Tuple.Create(Tuple.Create("", 5513), Tuple.Create("QuickAddFromIndex(event,true,\'T_Refusal\',\'", 5513), true)
            
            #line 123 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                          , Tuple.Create(Tuple.Create("", 5555), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5555), false)
, Tuple.Create(Tuple.Create("", 5582), Tuple.Create("\',\'", 5582), true)
            
            #line 123 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                        , Tuple.Create(Tuple.Create("", 5585), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5585), false)
, Tuple.Create(Tuple.Create("", 5598), Tuple.Create("\',", 5598), true)
            
            #line 123 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                       , Tuple.Create(Tuple.Create("", 5600), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5600), false)
, Tuple.Create(Tuple.Create("", 5619), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5619), true)
            
            #line 123 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 5655), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5655), false)
, Tuple.Create(Tuple.Create("", 5674), Tuple.Create("\',\'", 5674), true)
            
            #line 123 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 5677), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5677), false)
, Tuple.Create(Tuple.Create("", 5700), Tuple.Create("\',\'", 5700), true)
            
            #line 123 "..\..\Views\T_Refusal\CreateQuick.cshtml"
                                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 5703), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5703), false)
, Tuple.Create(Tuple.Create("", 5723), Tuple.Create("\');", 5723), true)
);

WriteLiteral(" />\r\n");

            
            #line 124 "..\..\Views\T_Refusal\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5747), Tuple.Create("\"", 5788)
            
            #line 126 "..\..\Views\T_Refusal\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5753), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5753), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5831), Tuple.Create("\"", 5870)
            
            #line 127 "..\..\Views\T_Refusal\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5837), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 5837), false)
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
