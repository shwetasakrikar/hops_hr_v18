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

namespace GeneratorBase.MVC.Views.T_ClaimType
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ClaimType/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_ClaimType>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Claim Type";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClaimTypeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ClaimTypeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                  ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClaimTypeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ClaimTypeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClaimTypeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ClaimTypeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                      ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1503), Tuple.Create("\"", 1552)
, Tuple.Create(Tuple.Create("", 1510), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1510), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1580), Tuple.Create("\"", 1623)
            
            #line 53 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1587), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1587), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_ClaimType",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
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

WriteLiteral(">\r\n\t\t\t\t        \r\n                                    \r\n\r\n");

            
            #line 82 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
			
            
            #line default
            #line hidden
            
            #line 82 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
             if(User.CanView("T_ClaimType","T_ClaimTypeFacilityAssociationID"))
				{
					

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral("  id=\"dvT_ClaimTypeFacilityAssociationID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label>");

            
            #line 87 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                              Write(Html.LabelFor(model => model.T_ClaimTypeFacilityAssociationID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 89 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                               Write(Html.DropDownList("T_ClaimTypeFacilityAssociationID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_Facility", @dataurl = Url.Action("GetAllValue", "T_Facility",new { caller = "T_ClaimTypeFacilityAssociationID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n ");

WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 95 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_ClaimTypeFacilityAssociationID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"         </div>\r\n");

            
            #line 99 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
     
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t");

            
            #line 101 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                 if(User.CanView("T_ClaimType","T_Name"))
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

            
            #line 105 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 107 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 108 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 112 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
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

            
            #line 121 "..\..\Views\T_ClaimType\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_ClaimType").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5080), Tuple.Create("\"", 5261)
, Tuple.Create(Tuple.Create("", 5090), Tuple.Create("QuickAdd(event,\'T_ClaimType\',\'", 5090), true)
            
            #line 128 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                      , Tuple.Create(Tuple.Create("", 5120), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5120), false)
, Tuple.Create(Tuple.Create("", 5133), Tuple.Create("\',", 5133), true)
            
            #line 128 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                     , Tuple.Create(Tuple.Create("", 5135), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5135), false)
, Tuple.Create(Tuple.Create("", 5154), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5154), true)
            
            #line 128 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                            , Tuple.Create(Tuple.Create("", 5190), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5190), false)
, Tuple.Create(Tuple.Create("", 5209), Tuple.Create("\',\'", 5209), true)
            
            #line 128 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                  , Tuple.Create(Tuple.Create("", 5212), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5212), false)
, Tuple.Create(Tuple.Create("", 5235), Tuple.Create("\',\'", 5235), true)
            
            #line 128 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                                            , Tuple.Create(Tuple.Create("", 5238), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5238), false)
, Tuple.Create(Tuple.Create("", 5258), Tuple.Create("\');", 5258), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5370), Tuple.Create("\"", 5551)
, Tuple.Create(Tuple.Create("", 5380), Tuple.Create("QuickAdd(event,\'T_ClaimType\',\'", 5380), true)
            
            #line 129 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                               , Tuple.Create(Tuple.Create("", 5410), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5410), false)
, Tuple.Create(Tuple.Create("", 5423), Tuple.Create("\',", 5423), true)
            
            #line 129 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                              , Tuple.Create(Tuple.Create("", 5425), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5425), false)
, Tuple.Create(Tuple.Create("", 5444), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5444), true)
            
            #line 129 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                     , Tuple.Create(Tuple.Create("", 5480), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5480), false)
, Tuple.Create(Tuple.Create("", 5499), Tuple.Create("\',\'", 5499), true)
            
            #line 129 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                                           , Tuple.Create(Tuple.Create("", 5502), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5502), false)
, Tuple.Create(Tuple.Create("", 5525), Tuple.Create("\',\'", 5525), true)
            
            #line 129 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                                                                     , Tuple.Create(Tuple.Create("", 5528), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5528), false)
, Tuple.Create(Tuple.Create("", 5548), Tuple.Create("\');", 5548), true)
);

WriteLiteral(" />\r\n");

            
            #line 130 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5644), Tuple.Create("\"", 5869)
, Tuple.Create(Tuple.Create("", 5654), Tuple.Create("QuickAddFromIndex(event,true,\'T_ClaimType\',\'", 5654), true)
            
            #line 133 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                    , Tuple.Create(Tuple.Create("", 5698), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 5698), false)
, Tuple.Create(Tuple.Create("", 5725), Tuple.Create("\',\'", 5725), true)
            
            #line 133 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                  , Tuple.Create(Tuple.Create("", 5728), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 5728), false)
, Tuple.Create(Tuple.Create("", 5741), Tuple.Create("\',", 5741), true)
            
            #line 133 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                 , Tuple.Create(Tuple.Create("", 5743), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 5743), false)
, Tuple.Create(Tuple.Create("", 5762), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 5762), true)
            
            #line 133 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                                        , Tuple.Create(Tuple.Create("", 5798), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 5798), false)
, Tuple.Create(Tuple.Create("", 5817), Tuple.Create("\',\'", 5817), true)
            
            #line 133 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 5820), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 5820), false)
, Tuple.Create(Tuple.Create("", 5843), Tuple.Create("\',\'", 5843), true)
            
            #line 133 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                                                                                        , Tuple.Create(Tuple.Create("", 5846), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 5846), false)
, Tuple.Create(Tuple.Create("", 5866), Tuple.Create("\');", 5866), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5977), Tuple.Create("\"", 6202)
, Tuple.Create(Tuple.Create("", 5987), Tuple.Create("QuickAddFromIndex(event,true,\'T_ClaimType\',\'", 5987), true)
            
            #line 134 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                            , Tuple.Create(Tuple.Create("", 6031), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 6031), false)
, Tuple.Create(Tuple.Create("", 6058), Tuple.Create("\',\'", 6058), true)
            
            #line 134 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                          , Tuple.Create(Tuple.Create("", 6061), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 6061), false)
, Tuple.Create(Tuple.Create("", 6074), Tuple.Create("\',", 6074), true)
            
            #line 134 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                         , Tuple.Create(Tuple.Create("", 6076), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 6076), false)
, Tuple.Create(Tuple.Create("", 6095), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 6095), true)
            
            #line 134 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 6131), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 6131), false)
, Tuple.Create(Tuple.Create("", 6150), Tuple.Create("\',\'", 6150), true)
            
            #line 134 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 6153), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 6153), false)
, Tuple.Create(Tuple.Create("", 6176), Tuple.Create("\',\'", 6176), true)
            
            #line 134 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
                                                                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 6179), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 6179), false)
, Tuple.Create(Tuple.Create("", 6199), Tuple.Create("\');", 6199), true)
);

WriteLiteral(" />\r\n");

            
            #line 135 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 6223), Tuple.Create("\"", 6264)
            
            #line 137 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 6229), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 6229), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 6307), Tuple.Create("\"", 6346)
            
            #line 138 "..\..\Views\T_ClaimType\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 6313), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 6313), false)
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
