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

namespace GeneratorBase.MVC.Views.T_City
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_City/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_City>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_City\CreateQuick.cshtml"
  
    ViewBag.Title = "Create City";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_City\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_City\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_City\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CityIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_City\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CityIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_City\CreateQuick.cshtml"
                                             ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_City\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CityIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_City\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CityIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_City\CreateQuick.cshtml"
                                                   ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_City\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CityIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_City\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CityIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_City\CreateQuick.cshtml"
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
            
            #line 53 "..\..\Views\T_City\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1546), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1546), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_City\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_City",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_City\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_City\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_City\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_City\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_City\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_City\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_City\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_City\CreateQuick.cshtml"
                                 if(User.CanView("T_City","T_Name"))
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

            
            #line 84 "..\..\Views\T_City\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_City\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_City\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_City\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_City\CreateQuick.cshtml"
					
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_City\CreateQuick.cshtml"
                     if(User.CanView("T_City","T_Description"))
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

            
            #line 98 "..\..\Views\T_City\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n");

WriteLiteral("                                    ");

            
            #line 99 "..\..\Views\T_City\CreateQuick.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_City\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 103 "..\..\Views\T_City\CreateQuick.cshtml"
							}

            
            #line default
            #line hidden
WriteLiteral("                                    \r\n\r\n");

            
            #line 106 "..\..\Views\T_City\CreateQuick.cshtml"
			
            
            #line default
            #line hidden
            
            #line 106 "..\..\Views\T_City\CreateQuick.cshtml"
             if(User.CanView("T_City","T_CityCountryID"))
				{
					

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral("  id=\"dvT_CityCountryID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label>");

            
            #line 111 "..\..\Views\T_City\CreateQuick.cshtml"
                              Write(Html.LabelFor(model => model.T_CityCountryID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 113 "..\..\Views\T_City\CreateQuick.cshtml"
                               Write(Html.DropDownList("T_CityCountryID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_Country", @dataurl = Url.Action("GetAllValue", "T_Country",new { caller = "T_CityCountryID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n ");

WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 119 "..\..\Views\T_City\CreateQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_CityCountryID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"         </div>\r\n");

            
            #line 123 "..\..\Views\T_City\CreateQuick.cshtml"
     
		}

            
            #line default
            #line hidden
WriteLiteral("                                    \r\n\r\n");

            
            #line 127 "..\..\Views\T_City\CreateQuick.cshtml"
			
            
            #line default
            #line hidden
            
            #line 127 "..\..\Views\T_City\CreateQuick.cshtml"
             if(User.CanView("T_City","T_CityStateID"))
				{
					

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral("  id=\"dvT_CityStateID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label>");

            
            #line 132 "..\..\Views\T_City\CreateQuick.cshtml"
                              Write(Html.LabelFor(model => model.T_CityStateID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 134 "..\..\Views\T_City\CreateQuick.cshtml"
                               Write(Html.DropDownList("T_CityStateID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_State", @dataurl = Url.Action("GetAllValue", "T_State",new { caller = "T_CityStateID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n ");

WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 140 "..\..\Views\T_City\CreateQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_CityStateID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"         </div>\r\n");

            
            #line 144 "..\..\Views\T_City\CreateQuick.cshtml"
     
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

            
            #line 152 "..\..\Views\T_City\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_City").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6366), Tuple.Create("\"", 6542)
, Tuple.Create(Tuple.Create("", 6376), Tuple.Create("QuickAdd(event,\'T_City\',\'", 6376), true)
            
            #line 159 "..\..\Views\T_City\CreateQuick.cshtml"
                                 , Tuple.Create(Tuple.Create("", 6401), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 6401), false)
, Tuple.Create(Tuple.Create("", 6414), Tuple.Create("\',", 6414), true)
            
            #line 159 "..\..\Views\T_City\CreateQuick.cshtml"
                                                , Tuple.Create(Tuple.Create("", 6416), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 6416), false)
, Tuple.Create(Tuple.Create("", 6435), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 6435), true)
            
            #line 159 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                       , Tuple.Create(Tuple.Create("", 6471), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 6471), false)
, Tuple.Create(Tuple.Create("", 6490), Tuple.Create("\',\'", 6490), true)
            
            #line 159 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                             , Tuple.Create(Tuple.Create("", 6493), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 6493), false)
, Tuple.Create(Tuple.Create("", 6516), Tuple.Create("\',\'", 6516), true)
            
            #line 159 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                                       , Tuple.Create(Tuple.Create("", 6519), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 6519), false)
, Tuple.Create(Tuple.Create("", 6539), Tuple.Create("\');", 6539), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6651), Tuple.Create("\"", 6827)
, Tuple.Create(Tuple.Create("", 6661), Tuple.Create("QuickAdd(event,\'T_City\',\'", 6661), true)
            
            #line 160 "..\..\Views\T_City\CreateQuick.cshtml"
                                                          , Tuple.Create(Tuple.Create("", 6686), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 6686), false)
, Tuple.Create(Tuple.Create("", 6699), Tuple.Create("\',", 6699), true)
            
            #line 160 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                         , Tuple.Create(Tuple.Create("", 6701), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 6701), false)
, Tuple.Create(Tuple.Create("", 6720), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 6720), true)
            
            #line 160 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                , Tuple.Create(Tuple.Create("", 6756), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 6756), false)
, Tuple.Create(Tuple.Create("", 6775), Tuple.Create("\',\'", 6775), true)
            
            #line 160 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                                      , Tuple.Create(Tuple.Create("", 6778), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 6778), false)
, Tuple.Create(Tuple.Create("", 6801), Tuple.Create("\',\'", 6801), true)
            
            #line 160 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 6804), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 6804), false)
, Tuple.Create(Tuple.Create("", 6824), Tuple.Create("\');", 6824), true)
);

WriteLiteral(" />\r\n");

            
            #line 161 "..\..\Views\T_City\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6920), Tuple.Create("\"", 7140)
, Tuple.Create(Tuple.Create("", 6930), Tuple.Create("QuickAddFromIndex(event,true,\'T_City\',\'", 6930), true)
            
            #line 164 "..\..\Views\T_City\CreateQuick.cshtml"
                                               , Tuple.Create(Tuple.Create("", 6969), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 6969), false)
, Tuple.Create(Tuple.Create("", 6996), Tuple.Create("\',\'", 6996), true)
            
            #line 164 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                             , Tuple.Create(Tuple.Create("", 6999), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 6999), false)
, Tuple.Create(Tuple.Create("", 7012), Tuple.Create("\',", 7012), true)
            
            #line 164 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                            , Tuple.Create(Tuple.Create("", 7014), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 7014), false)
, Tuple.Create(Tuple.Create("", 7033), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 7033), true)
            
            #line 164 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                                   , Tuple.Create(Tuple.Create("", 7069), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 7069), false)
, Tuple.Create(Tuple.Create("", 7088), Tuple.Create("\',\'", 7088), true)
            
            #line 164 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                                                         , Tuple.Create(Tuple.Create("", 7091), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 7091), false)
, Tuple.Create(Tuple.Create("", 7114), Tuple.Create("\',\'", 7114), true)
            
            #line 164 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                                                                                   , Tuple.Create(Tuple.Create("", 7117), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 7117), false)
, Tuple.Create(Tuple.Create("", 7137), Tuple.Create("\');", 7137), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7248), Tuple.Create("\"", 7468)
, Tuple.Create(Tuple.Create("", 7258), Tuple.Create("QuickAddFromIndex(event,true,\'T_City\',\'", 7258), true)
            
            #line 165 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                       , Tuple.Create(Tuple.Create("", 7297), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 7297), false)
, Tuple.Create(Tuple.Create("", 7324), Tuple.Create("\',\'", 7324), true)
            
            #line 165 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                     , Tuple.Create(Tuple.Create("", 7327), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 7327), false)
, Tuple.Create(Tuple.Create("", 7340), Tuple.Create("\',", 7340), true)
            
            #line 165 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                    , Tuple.Create(Tuple.Create("", 7342), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 7342), false)
, Tuple.Create(Tuple.Create("", 7361), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 7361), true)
            
            #line 165 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                                                           , Tuple.Create(Tuple.Create("", 7397), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 7397), false)
, Tuple.Create(Tuple.Create("", 7416), Tuple.Create("\',\'", 7416), true)
            
            #line 165 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                                                                                 , Tuple.Create(Tuple.Create("", 7419), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 7419), false)
, Tuple.Create(Tuple.Create("", 7442), Tuple.Create("\',\'", 7442), true)
            
            #line 165 "..\..\Views\T_City\CreateQuick.cshtml"
                                                                                                                                                                                                                           , Tuple.Create(Tuple.Create("", 7445), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 7445), false)
, Tuple.Create(Tuple.Create("", 7465), Tuple.Create("\');", 7465), true)
);

WriteLiteral(" />\r\n");

            
            #line 166 "..\..\Views\T_City\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7489), Tuple.Create("\"", 7530)
            
            #line 168 "..\..\Views\T_City\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 7495), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 7495), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7573), Tuple.Create("\"", 7612)
            
            #line 169 "..\..\Views\T_City\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 7579), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 7579), false)
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