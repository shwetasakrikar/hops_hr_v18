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

namespace GeneratorBase.MVC.Views.T_VeteranStatus
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_VeteranStatus/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_VeteranStatus>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Veteran Status";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_VeteranStatusIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_VeteranStatusIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                      ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_VeteranStatusIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_VeteranStatusIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                            ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_VeteranStatusIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_VeteranStatusIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1535), Tuple.Create("\"", 1584)
, Tuple.Create(Tuple.Create("", 1542), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1542), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1612), Tuple.Create("\"", 1655)
            
            #line 53 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1619), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1619), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_VeteranStatus",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                 if(User.CanView("T_VeteranStatus","T_Name"))
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

            
            #line 84 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
					
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                     if(User.CanView("T_VeteranStatus","T_Description"))
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

            
            #line 98 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 99 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 103 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
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

            
            #line 110 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_VeteranStatus").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4685), Tuple.Create("\"", 4870)
, Tuple.Create(Tuple.Create("", 4695), Tuple.Create("QuickAdd(event,\'T_VeteranStatus\',\'", 4695), true)
            
            #line 117 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                          , Tuple.Create(Tuple.Create("", 4729), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4729), false)
, Tuple.Create(Tuple.Create("", 4742), Tuple.Create("\',", 4742), true)
            
            #line 117 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                         , Tuple.Create(Tuple.Create("", 4744), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4744), false)
, Tuple.Create(Tuple.Create("", 4763), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4763), true)
            
            #line 117 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                , Tuple.Create(Tuple.Create("", 4799), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4799), false)
, Tuple.Create(Tuple.Create("", 4818), Tuple.Create("\',\'", 4818), true)
            
            #line 117 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                      , Tuple.Create(Tuple.Create("", 4821), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4821), false)
, Tuple.Create(Tuple.Create("", 4844), Tuple.Create("\',\'", 4844), true)
            
            #line 117 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                                                , Tuple.Create(Tuple.Create("", 4847), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4847), false)
, Tuple.Create(Tuple.Create("", 4867), Tuple.Create("\');", 4867), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4979), Tuple.Create("\"", 5164)
, Tuple.Create(Tuple.Create("", 4989), Tuple.Create("QuickAdd(event,\'T_VeteranStatus\',\'", 4989), true)
            
            #line 118 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                   , Tuple.Create(Tuple.Create("", 5023), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5023), false)
, Tuple.Create(Tuple.Create("", 5036), Tuple.Create("\',", 5036), true)
            
            #line 118 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                  , Tuple.Create(Tuple.Create("", 5038), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5038), false)
, Tuple.Create(Tuple.Create("", 5057), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5057), true)
            
            #line 118 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                         , Tuple.Create(Tuple.Create("", 5093), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5093), false)
, Tuple.Create(Tuple.Create("", 5112), Tuple.Create("\',\'", 5112), true)
            
            #line 118 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                                               , Tuple.Create(Tuple.Create("", 5115), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5115), false)
, Tuple.Create(Tuple.Create("", 5138), Tuple.Create("\',\'", 5138), true)
            
            #line 118 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                                                                         , Tuple.Create(Tuple.Create("", 5141), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5141), false)
, Tuple.Create(Tuple.Create("", 5161), Tuple.Create("\');", 5161), true)
);

WriteLiteral(" />\r\n");

            
            #line 119 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5257), Tuple.Create("\"", 5486)
, Tuple.Create(Tuple.Create("", 5267), Tuple.Create("QuickAddFromIndex(event,true,\'T_VeteranStatus\',\'", 5267), true)
            
            #line 122 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 5315), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5315), false)
, Tuple.Create(Tuple.Create("", 5342), Tuple.Create("\',\'", 5342), true)
            
            #line 122 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                      , Tuple.Create(Tuple.Create("", 5345), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5345), false)
, Tuple.Create(Tuple.Create("", 5358), Tuple.Create("\',", 5358), true)
            
            #line 122 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                     , Tuple.Create(Tuple.Create("", 5360), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5360), false)
, Tuple.Create(Tuple.Create("", 5379), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5379), true)
            
            #line 122 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                                            , Tuple.Create(Tuple.Create("", 5415), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5415), false)
, Tuple.Create(Tuple.Create("", 5434), Tuple.Create("\',\'", 5434), true)
            
            #line 122 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 5437), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5437), false)
, Tuple.Create(Tuple.Create("", 5460), Tuple.Create("\',\'", 5460), true)
            
            #line 122 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 5463), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5463), false)
, Tuple.Create(Tuple.Create("", 5483), Tuple.Create("\');", 5483), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5594), Tuple.Create("\"", 5823)
, Tuple.Create(Tuple.Create("", 5604), Tuple.Create("QuickAddFromIndex(event,true,\'T_VeteranStatus\',\'", 5604), true)
            
            #line 123 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                , Tuple.Create(Tuple.Create("", 5652), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5652), false)
, Tuple.Create(Tuple.Create("", 5679), Tuple.Create("\',\'", 5679), true)
            
            #line 123 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                              , Tuple.Create(Tuple.Create("", 5682), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5682), false)
, Tuple.Create(Tuple.Create("", 5695), Tuple.Create("\',", 5695), true)
            
            #line 123 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                             , Tuple.Create(Tuple.Create("", 5697), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5697), false)
, Tuple.Create(Tuple.Create("", 5716), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5716), true)
            
            #line 123 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 5752), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5752), false)
, Tuple.Create(Tuple.Create("", 5771), Tuple.Create("\',\'", 5771), true)
            
            #line 123 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 5774), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5774), false)
, Tuple.Create(Tuple.Create("", 5797), Tuple.Create("\',\'", 5797), true)
            
            #line 123 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
                                                                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 5800), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5800), false)
, Tuple.Create(Tuple.Create("", 5820), Tuple.Create("\');", 5820), true)
);

WriteLiteral(" />\r\n");

            
            #line 124 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5844), Tuple.Create("\"", 5885)
            
            #line 126 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5850), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5850), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5928), Tuple.Create("\"", 5967)
            
            #line 127 "..\..\Views\T_VeteranStatus\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5934), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 5934), false)
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