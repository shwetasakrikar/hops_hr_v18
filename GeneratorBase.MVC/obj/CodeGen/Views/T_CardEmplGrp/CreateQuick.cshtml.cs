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

namespace GeneratorBase.MVC.Views.T_CardEmplGrp
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_CardEmplGrp/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_CardEmplGrp>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
  
    ViewBag.Title = "Create CardEmplGrp";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CardEmplGrpIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CardEmplGrpIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CardEmplGrpIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CardEmplGrpIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CardEmplGrpIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CardEmplGrpIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
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
            
            #line 53 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1602), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1602), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_CardEmplGrp",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                 if(User.CanView("T_CardEmplGrp","T_Name"))
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

            
            #line 84 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
					
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                     if(User.CanView("T_CardEmplGrp","T_Description"))
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

            
            #line 98 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 99 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 103 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
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

            
            #line 110 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_CardEmplGrp").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4660), Tuple.Create("\"", 4843)
, Tuple.Create(Tuple.Create("", 4670), Tuple.Create("QuickAdd(event,\'T_CardEmplGrp\',\'", 4670), true)
            
            #line 117 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                        , Tuple.Create(Tuple.Create("", 4702), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4702), false)
, Tuple.Create(Tuple.Create("", 4715), Tuple.Create("\',", 4715), true)
            
            #line 117 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                       , Tuple.Create(Tuple.Create("", 4717), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 4717), false)
, Tuple.Create(Tuple.Create("", 4736), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 4736), true)
            
            #line 117 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                              , Tuple.Create(Tuple.Create("", 4772), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 4772), false)
, Tuple.Create(Tuple.Create("", 4791), Tuple.Create("\',\'", 4791), true)
            
            #line 117 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                    , Tuple.Create(Tuple.Create("", 4794), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 4794), false)
, Tuple.Create(Tuple.Create("", 4817), Tuple.Create("\',\'", 4817), true)
            
            #line 117 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                                              , Tuple.Create(Tuple.Create("", 4820), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 4820), false)
, Tuple.Create(Tuple.Create("", 4840), Tuple.Create("\');", 4840), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4952), Tuple.Create("\"", 5135)
, Tuple.Create(Tuple.Create("", 4962), Tuple.Create("QuickAdd(event,\'T_CardEmplGrp\',\'", 4962), true)
            
            #line 118 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                 , Tuple.Create(Tuple.Create("", 4994), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 4994), false)
, Tuple.Create(Tuple.Create("", 5007), Tuple.Create("\',", 5007), true)
            
            #line 118 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                , Tuple.Create(Tuple.Create("", 5009), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5009), false)
, Tuple.Create(Tuple.Create("", 5028), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5028), true)
            
            #line 118 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                       , Tuple.Create(Tuple.Create("", 5064), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5064), false)
, Tuple.Create(Tuple.Create("", 5083), Tuple.Create("\',\'", 5083), true)
            
            #line 118 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                                             , Tuple.Create(Tuple.Create("", 5086), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5086), false)
, Tuple.Create(Tuple.Create("", 5109), Tuple.Create("\',\'", 5109), true)
            
            #line 118 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                                                                       , Tuple.Create(Tuple.Create("", 5112), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5112), false)
, Tuple.Create(Tuple.Create("", 5132), Tuple.Create("\');", 5132), true)
);

WriteLiteral(" />\r\n");

            
            #line 119 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5228), Tuple.Create("\"", 5455)
, Tuple.Create(Tuple.Create("", 5238), Tuple.Create("QuickAddFromIndex(event,true,\'T_CardEmplGrp\',\'", 5238), true)
            
            #line 122 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 5284), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5284), false)
, Tuple.Create(Tuple.Create("", 5311), Tuple.Create("\',\'", 5311), true)
            
            #line 122 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                    , Tuple.Create(Tuple.Create("", 5314), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5314), false)
, Tuple.Create(Tuple.Create("", 5327), Tuple.Create("\',", 5327), true)
            
            #line 122 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                   , Tuple.Create(Tuple.Create("", 5329), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5329), false)
, Tuple.Create(Tuple.Create("", 5348), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5348), true)
            
            #line 122 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                                          , Tuple.Create(Tuple.Create("", 5384), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5384), false)
, Tuple.Create(Tuple.Create("", 5403), Tuple.Create("\',\'", 5403), true)
            
            #line 122 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 5406), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5406), false)
, Tuple.Create(Tuple.Create("", 5429), Tuple.Create("\',\'", 5429), true)
            
            #line 122 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 5432), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5432), false)
, Tuple.Create(Tuple.Create("", 5452), Tuple.Create("\');", 5452), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5563), Tuple.Create("\"", 5790)
, Tuple.Create(Tuple.Create("", 5573), Tuple.Create("QuickAddFromIndex(event,true,\'T_CardEmplGrp\',\'", 5573), true)
            
            #line 123 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                              , Tuple.Create(Tuple.Create("", 5619), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5619), false)
, Tuple.Create(Tuple.Create("", 5646), Tuple.Create("\',\'", 5646), true)
            
            #line 123 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                            , Tuple.Create(Tuple.Create("", 5649), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5649), false)
, Tuple.Create(Tuple.Create("", 5662), Tuple.Create("\',", 5662), true)
            
            #line 123 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                           , Tuple.Create(Tuple.Create("", 5664), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5664), false)
, Tuple.Create(Tuple.Create("", 5683), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5683), true)
            
            #line 123 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 5719), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5719), false)
, Tuple.Create(Tuple.Create("", 5738), Tuple.Create("\',\'", 5738), true)
            
            #line 123 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                                                                                        , Tuple.Create(Tuple.Create("", 5741), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5741), false)
, Tuple.Create(Tuple.Create("", 5764), Tuple.Create("\',\'", 5764), true)
            
            #line 123 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
                                                                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 5767), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5767), false)
, Tuple.Create(Tuple.Create("", 5787), Tuple.Create("\');", 5787), true)
);

WriteLiteral(" />\r\n");

            
            #line 124 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5811), Tuple.Create("\"", 5852)
            
            #line 126 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5817), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 5817), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 5895), Tuple.Create("\"", 5934)
            
            #line 127 "..\..\Views\T_CardEmplGrp\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 5901), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 5901), false)
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
