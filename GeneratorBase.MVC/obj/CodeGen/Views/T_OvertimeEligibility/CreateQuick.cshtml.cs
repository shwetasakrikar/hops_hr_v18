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

namespace GeneratorBase.MVC.Views.T_OvertimeEligibility
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_OvertimeEligibility/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_OvertimeEligibility>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Overtime Eligibility";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_OvertimeEligibilityIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_OvertimeEligibilityIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                            ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_OvertimeEligibilityIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_OvertimeEligibilityIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                  ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_OvertimeEligibilityIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_OvertimeEligibilityIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1583), Tuple.Create("\"", 1632)
, Tuple.Create(Tuple.Create("", 1590), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1590), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1660), Tuple.Create("\"", 1703)
            
            #line 53 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1667), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1667), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_OvertimeEligibility",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                 if(User.CanView("T_OvertimeEligibility","T_Name"))
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

            
            #line 84 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                 if(User.CanView("T_OvertimeEligibility","T_Description"))
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Description\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 98 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 101 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 105 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
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

            
            #line 114 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_OvertimeEligibility").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4789), Tuple.Create("\"", 4980)
, Tuple.Create(Tuple.Create("", 4799), Tuple.Create("QuickAdd(event,\'T_OvertimeEligibility\',\'", 4799), true)
            
            #line 121 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                , Tuple.Create(Tuple.Create("", 4839), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4839), false)
, Tuple.Create(Tuple.Create("", 4852), Tuple.Create("\',", 4852), true)
            
            #line 121 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                               , Tuple.Create(Tuple.Create("", 4854), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4854), false)
, Tuple.Create(Tuple.Create("", 4873), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4873), true)
            
            #line 121 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                      , Tuple.Create(Tuple.Create("", 4909), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4909), false)
, Tuple.Create(Tuple.Create("", 4928), Tuple.Create("\',\'", 4928), true)
            
            #line 121 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                            , Tuple.Create(Tuple.Create("", 4931), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4931), false)
, Tuple.Create(Tuple.Create("", 4954), Tuple.Create("\',\'", 4954), true)
            
            #line 121 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 4957), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4957), false)
, Tuple.Create(Tuple.Create("", 4977), Tuple.Create("\');", 4977), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5089), Tuple.Create("\"", 5280)
, Tuple.Create(Tuple.Create("", 5099), Tuple.Create("QuickAdd(event,\'T_OvertimeEligibility\',\'", 5099), true)
            
            #line 122 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                         , Tuple.Create(Tuple.Create("", 5139), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5139), false)
, Tuple.Create(Tuple.Create("", 5152), Tuple.Create("\',", 5152), true)
            
            #line 122 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                        , Tuple.Create(Tuple.Create("", 5154), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5154), false)
, Tuple.Create(Tuple.Create("", 5173), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5173), true)
            
            #line 122 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                               , Tuple.Create(Tuple.Create("", 5209), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5209), false)
, Tuple.Create(Tuple.Create("", 5228), Tuple.Create("\',\'", 5228), true)
            
            #line 122 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                                                     , Tuple.Create(Tuple.Create("", 5231), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5231), false)
, Tuple.Create(Tuple.Create("", 5254), Tuple.Create("\',\'", 5254), true)
            
            #line 122 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                                                                               , Tuple.Create(Tuple.Create("", 5257), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5257), false)
, Tuple.Create(Tuple.Create("", 5277), Tuple.Create("\');", 5277), true)
);

WriteLiteral(" />\r\n");

            
            #line 123 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5373), Tuple.Create("\"", 5608)
, Tuple.Create(Tuple.Create("", 5383), Tuple.Create("QuickAddFromIndex(event,true,\'T_OvertimeEligibility\',\'", 5383), true)
            
            #line 126 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                              , Tuple.Create(Tuple.Create("", 5437), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5437), false)
, Tuple.Create(Tuple.Create("", 5464), Tuple.Create("\',\'", 5464), true)
            
            #line 126 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                            , Tuple.Create(Tuple.Create("", 5467), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5467), false)
, Tuple.Create(Tuple.Create("", 5480), Tuple.Create("\',", 5480), true)
            
            #line 126 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                           , Tuple.Create(Tuple.Create("", 5482), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5482), false)
, Tuple.Create(Tuple.Create("", 5501), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5501), true)
            
            #line 126 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 5537), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5537), false)
, Tuple.Create(Tuple.Create("", 5556), Tuple.Create("\',\'", 5556), true)
            
            #line 126 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                                                                        , Tuple.Create(Tuple.Create("", 5559), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5559), false)
, Tuple.Create(Tuple.Create("", 5582), Tuple.Create("\',\'", 5582), true)
            
            #line 126 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 5585), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5585), false)
, Tuple.Create(Tuple.Create("", 5605), Tuple.Create("\');", 5605), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5716), Tuple.Create("\"", 5951)
, Tuple.Create(Tuple.Create("", 5726), Tuple.Create("QuickAddFromIndex(event,true,\'T_OvertimeEligibility\',\'", 5726), true)
            
            #line 127 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                      , Tuple.Create(Tuple.Create("", 5780), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5780), false)
, Tuple.Create(Tuple.Create("", 5807), Tuple.Create("\',\'", 5807), true)
            
            #line 127 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                    , Tuple.Create(Tuple.Create("", 5810), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5810), false)
, Tuple.Create(Tuple.Create("", 5823), Tuple.Create("\',", 5823), true)
            
            #line 127 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                   , Tuple.Create(Tuple.Create("", 5825), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5825), false)
, Tuple.Create(Tuple.Create("", 5844), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5844), true)
            
            #line 127 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 5880), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5880), false)
, Tuple.Create(Tuple.Create("", 5899), Tuple.Create("\',\'", 5899), true)
            
            #line 127 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 5902), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5902), false)
, Tuple.Create(Tuple.Create("", 5925), Tuple.Create("\',\'", 5925), true)
            
            #line 127 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
                                                                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 5928), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5928), false)
, Tuple.Create(Tuple.Create("", 5948), Tuple.Create("\');", 5948), true)
);

WriteLiteral(" />\r\n");

            
            #line 128 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5972), Tuple.Create("\"", 6013)
            
            #line 130 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5978), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5978), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 6056), Tuple.Create("\"", 6095)
            
            #line 131 "..\..\Views\T_OvertimeEligibility\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 6062), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 6062), false)
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
