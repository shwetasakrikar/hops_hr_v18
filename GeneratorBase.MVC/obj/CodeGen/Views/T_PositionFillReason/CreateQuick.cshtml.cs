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

namespace GeneratorBase.MVC.Views.T_PositionFillReason
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_PositionFillReason/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_PositionFillReason>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Position Fill Reason";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_PositionFillReasonIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_PositionFillReasonIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                           ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_PositionFillReasonIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_PositionFillReasonIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_PositionFillReasonIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_PositionFillReasonIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                               ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1576), Tuple.Create("\"", 1625)
, Tuple.Create(Tuple.Create("", 1583), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1583), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1653), Tuple.Create("\"", 1696)
            
            #line 53 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1660), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1660), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_PositionFillReason",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                 if(User.CanView("T_PositionFillReason","T_Name"))
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

            
            #line 84 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
					
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                     if(User.CanView("T_PositionFillReason","T_Description"))
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

            
            #line 98 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 99 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 103 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
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

            
            #line 110 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_PositionFillReason").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4746), Tuple.Create("\"", 4936)
, Tuple.Create(Tuple.Create("", 4756), Tuple.Create("QuickAdd(event,\'T_PositionFillReason\',\'", 4756), true)
            
            #line 117 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                               , Tuple.Create(Tuple.Create("", 4795), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4795), false)
, Tuple.Create(Tuple.Create("", 4808), Tuple.Create("\',", 4808), true)
            
            #line 117 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                              , Tuple.Create(Tuple.Create("", 4810), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4810), false)
, Tuple.Create(Tuple.Create("", 4829), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4829), true)
            
            #line 117 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                     , Tuple.Create(Tuple.Create("", 4865), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4865), false)
, Tuple.Create(Tuple.Create("", 4884), Tuple.Create("\',\'", 4884), true)
            
            #line 117 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                           , Tuple.Create(Tuple.Create("", 4887), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4887), false)
, Tuple.Create(Tuple.Create("", 4910), Tuple.Create("\',\'", 4910), true)
            
            #line 117 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                                                     , Tuple.Create(Tuple.Create("", 4913), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4913), false)
, Tuple.Create(Tuple.Create("", 4933), Tuple.Create("\');", 4933), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5045), Tuple.Create("\"", 5235)
, Tuple.Create(Tuple.Create("", 5055), Tuple.Create("QuickAdd(event,\'T_PositionFillReason\',\'", 5055), true)
            
            #line 118 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                        , Tuple.Create(Tuple.Create("", 5094), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5094), false)
, Tuple.Create(Tuple.Create("", 5107), Tuple.Create("\',", 5107), true)
            
            #line 118 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                       , Tuple.Create(Tuple.Create("", 5109), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5109), false)
, Tuple.Create(Tuple.Create("", 5128), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5128), true)
            
            #line 118 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                              , Tuple.Create(Tuple.Create("", 5164), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5164), false)
, Tuple.Create(Tuple.Create("", 5183), Tuple.Create("\',\'", 5183), true)
            
            #line 118 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 5186), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5186), false)
, Tuple.Create(Tuple.Create("", 5209), Tuple.Create("\',\'", 5209), true)
            
            #line 118 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 5212), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5212), false)
, Tuple.Create(Tuple.Create("", 5232), Tuple.Create("\');", 5232), true)
);

WriteLiteral(" />\r\n");

            
            #line 119 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5328), Tuple.Create("\"", 5562)
, Tuple.Create(Tuple.Create("", 5338), Tuple.Create("QuickAddFromIndex(event,true,\'T_PositionFillReason\',\'", 5338), true)
            
            #line 122 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                             , Tuple.Create(Tuple.Create("", 5391), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5391), false)
, Tuple.Create(Tuple.Create("", 5418), Tuple.Create("\',\'", 5418), true)
            
            #line 122 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                           , Tuple.Create(Tuple.Create("", 5421), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5421), false)
, Tuple.Create(Tuple.Create("", 5434), Tuple.Create("\',", 5434), true)
            
            #line 122 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                          , Tuple.Create(Tuple.Create("", 5436), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5436), false)
, Tuple.Create(Tuple.Create("", 5455), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5455), true)
            
            #line 122 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                                                 , Tuple.Create(Tuple.Create("", 5491), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5491), false)
, Tuple.Create(Tuple.Create("", 5510), Tuple.Create("\',\'", 5510), true)
            
            #line 122 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                                                                       , Tuple.Create(Tuple.Create("", 5513), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5513), false)
, Tuple.Create(Tuple.Create("", 5536), Tuple.Create("\',\'", 5536), true)
            
            #line 122 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                                                                                                 , Tuple.Create(Tuple.Create("", 5539), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5539), false)
, Tuple.Create(Tuple.Create("", 5559), Tuple.Create("\');", 5559), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5670), Tuple.Create("\"", 5904)
, Tuple.Create(Tuple.Create("", 5680), Tuple.Create("QuickAddFromIndex(event,true,\'T_PositionFillReason\',\'", 5680), true)
            
            #line 123 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                     , Tuple.Create(Tuple.Create("", 5733), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5733), false)
, Tuple.Create(Tuple.Create("", 5760), Tuple.Create("\',\'", 5760), true)
            
            #line 123 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                   , Tuple.Create(Tuple.Create("", 5763), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5763), false)
, Tuple.Create(Tuple.Create("", 5776), Tuple.Create("\',", 5776), true)
            
            #line 123 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                  , Tuple.Create(Tuple.Create("", 5778), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5778), false)
, Tuple.Create(Tuple.Create("", 5797), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5797), true)
            
            #line 123 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                                                                         , Tuple.Create(Tuple.Create("", 5833), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5833), false)
, Tuple.Create(Tuple.Create("", 5852), Tuple.Create("\',\'", 5852), true)
            
            #line 123 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                                                                                               , Tuple.Create(Tuple.Create("", 5855), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5855), false)
, Tuple.Create(Tuple.Create("", 5878), Tuple.Create("\',\'", 5878), true)
            
            #line 123 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
                                                                                                                                                                                                                                         , Tuple.Create(Tuple.Create("", 5881), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5881), false)
, Tuple.Create(Tuple.Create("", 5901), Tuple.Create("\');", 5901), true)
);

WriteLiteral(" />\r\n");

            
            #line 124 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5925), Tuple.Create("\"", 5966)
            
            #line 126 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5931), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5931), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 6009), Tuple.Create("\"", 6048)
            
            #line 127 "..\..\Views\T_PositionFillReason\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 6015), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 6015), false)
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
