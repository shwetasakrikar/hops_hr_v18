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

namespace GeneratorBase.MVC.Views.T_ReasonforHire
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ReasonforHire/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_ReasonforHire>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Reason for Hire";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ReasonforHireIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ReasonforHireIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                      ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ReasonforHireIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ReasonforHireIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                            ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ReasonforHireIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ReasonforHireIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1536), Tuple.Create("\"", 1585)
, Tuple.Create(Tuple.Create("", 1543), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1543), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1613), Tuple.Create("\"", 1656)
            
            #line 53 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1620), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1620), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_ReasonforHire",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                 if(User.CanView("T_ReasonforHire","T_Name"))
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

            
            #line 84 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
					
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                     if(User.CanView("T_ReasonforHire","T_Description"))
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

            
            #line 98 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 99 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 103 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
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

            
            #line 110 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_ReasonforHire").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4686), Tuple.Create("\"", 4871)
, Tuple.Create(Tuple.Create("", 4696), Tuple.Create("QuickAdd(event,\'T_ReasonforHire\',\'", 4696), true)
            
            #line 117 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                          , Tuple.Create(Tuple.Create("", 4730), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4730), false)
, Tuple.Create(Tuple.Create("", 4743), Tuple.Create("\',", 4743), true)
            
            #line 117 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                         , Tuple.Create(Tuple.Create("", 4745), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4745), false)
, Tuple.Create(Tuple.Create("", 4764), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4764), true)
            
            #line 117 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                , Tuple.Create(Tuple.Create("", 4800), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4800), false)
, Tuple.Create(Tuple.Create("", 4819), Tuple.Create("\',\'", 4819), true)
            
            #line 117 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                      , Tuple.Create(Tuple.Create("", 4822), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4822), false)
, Tuple.Create(Tuple.Create("", 4845), Tuple.Create("\',\'", 4845), true)
            
            #line 117 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                                                , Tuple.Create(Tuple.Create("", 4848), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4848), false)
, Tuple.Create(Tuple.Create("", 4868), Tuple.Create("\');", 4868), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4980), Tuple.Create("\"", 5165)
, Tuple.Create(Tuple.Create("", 4990), Tuple.Create("QuickAdd(event,\'T_ReasonforHire\',\'", 4990), true)
            
            #line 118 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                   , Tuple.Create(Tuple.Create("", 5024), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5024), false)
, Tuple.Create(Tuple.Create("", 5037), Tuple.Create("\',", 5037), true)
            
            #line 118 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                  , Tuple.Create(Tuple.Create("", 5039), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5039), false)
, Tuple.Create(Tuple.Create("", 5058), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5058), true)
            
            #line 118 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                         , Tuple.Create(Tuple.Create("", 5094), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5094), false)
, Tuple.Create(Tuple.Create("", 5113), Tuple.Create("\',\'", 5113), true)
            
            #line 118 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                                               , Tuple.Create(Tuple.Create("", 5116), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5116), false)
, Tuple.Create(Tuple.Create("", 5139), Tuple.Create("\',\'", 5139), true)
            
            #line 118 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                                                                         , Tuple.Create(Tuple.Create("", 5142), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5142), false)
, Tuple.Create(Tuple.Create("", 5162), Tuple.Create("\');", 5162), true)
);

WriteLiteral(" />\r\n");

            
            #line 119 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5258), Tuple.Create("\"", 5487)
, Tuple.Create(Tuple.Create("", 5268), Tuple.Create("QuickAddFromIndex(event,true,\'T_ReasonforHire\',\'", 5268), true)
            
            #line 122 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 5316), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5316), false)
, Tuple.Create(Tuple.Create("", 5343), Tuple.Create("\',\'", 5343), true)
            
            #line 122 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                      , Tuple.Create(Tuple.Create("", 5346), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5346), false)
, Tuple.Create(Tuple.Create("", 5359), Tuple.Create("\',", 5359), true)
            
            #line 122 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                     , Tuple.Create(Tuple.Create("", 5361), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5361), false)
, Tuple.Create(Tuple.Create("", 5380), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5380), true)
            
            #line 122 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                                            , Tuple.Create(Tuple.Create("", 5416), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5416), false)
, Tuple.Create(Tuple.Create("", 5435), Tuple.Create("\',\'", 5435), true)
            
            #line 122 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 5438), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5438), false)
, Tuple.Create(Tuple.Create("", 5461), Tuple.Create("\',\'", 5461), true)
            
            #line 122 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 5464), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5464), false)
, Tuple.Create(Tuple.Create("", 5484), Tuple.Create("\');", 5484), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5595), Tuple.Create("\"", 5824)
, Tuple.Create(Tuple.Create("", 5605), Tuple.Create("QuickAddFromIndex(event,true,\'T_ReasonforHire\',\'", 5605), true)
            
            #line 123 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                , Tuple.Create(Tuple.Create("", 5653), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5653), false)
, Tuple.Create(Tuple.Create("", 5680), Tuple.Create("\',\'", 5680), true)
            
            #line 123 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                              , Tuple.Create(Tuple.Create("", 5683), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5683), false)
, Tuple.Create(Tuple.Create("", 5696), Tuple.Create("\',", 5696), true)
            
            #line 123 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                             , Tuple.Create(Tuple.Create("", 5698), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5698), false)
, Tuple.Create(Tuple.Create("", 5717), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5717), true)
            
            #line 123 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 5753), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5753), false)
, Tuple.Create(Tuple.Create("", 5772), Tuple.Create("\',\'", 5772), true)
            
            #line 123 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 5775), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5775), false)
, Tuple.Create(Tuple.Create("", 5798), Tuple.Create("\',\'", 5798), true)
            
            #line 123 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
                                                                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 5801), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5801), false)
, Tuple.Create(Tuple.Create("", 5821), Tuple.Create("\');", 5821), true)
);

WriteLiteral(" />\r\n");

            
            #line 124 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5845), Tuple.Create("\"", 5886)
            
            #line 126 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5851), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5851), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5929), Tuple.Create("\"", 5968)
            
            #line 127 "..\..\Views\T_ReasonforHire\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5935), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 5935), false)
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
