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

namespace GeneratorBase.MVC.Views.T_Address
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Address/CreateQuick.cshtml")]
    public partial class CreateQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Address>
    {
        public CreateQuick()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Address\CreateQuick.cshtml"
  
    ViewBag.Title = "Create Address";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_Address\CreateQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_Address\CreateQuick.cshtml"
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

            
            #line 34 "..\..\Views\T_Address\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_AddressIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_Address\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_AddressIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 40 "..\..\Views\T_Address\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_AddressIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Address\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_AddressIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                      ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_Address\CreateQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_AddressIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Address\CreateQuick.cshtml"
   Write(Html.Raw(ViewBag.T_AddressIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Address\CreateQuick.cshtml"
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
            
            #line 53 "..\..\Views\T_Address\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 1570), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1570), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 54 "..\..\Views\T_Address\CreateQuick.cshtml"
 using (Html.BeginForm("CreateQuick", "T_Address",FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Address\CreateQuick.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Address\CreateQuick.cshtml"
                            ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsgQuickAdd\"");

WriteLiteral(" />\r\n");

            
            #line 60 "..\..\Views\T_Address\CreateQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                            

            
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

            
            #line 72 "..\..\Views\T_Address\CreateQuick.cshtml"
Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t");

            
            #line 73 "..\..\Views\T_Address\CreateQuick.cshtml"
Write(Html.Hidden("HostingEntityName", Convert.ToString(ViewData["HostingEntityName"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 74 "..\..\Views\T_Address\CreateQuick.cshtml"
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

            
            #line 80 "..\..\Views\T_Address\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_Address\CreateQuick.cshtml"
                                 if(User.CanView("T_Address","T_AddressLine1"))
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvT_AddressLine1\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"AddressLine1\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 84 "..\..\Views\T_Address\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_AddressLine1));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 86 "..\..\Views\T_Address\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_AddressLine1, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 87 "..\..\Views\T_Address\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_AddressLine1));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 91 "..\..\Views\T_Address\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 94 "..\..\Views\T_Address\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\T_Address\CreateQuick.cshtml"
                                 if(User.CanView("T_Address","T_AddressLine2"))
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvT_AddressLine2\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"AddressLine2\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 98 "..\..\Views\T_Address\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_AddressLine2));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 100 "..\..\Views\T_Address\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_AddressLine2, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 101 "..\..\Views\T_Address\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_AddressLine2));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 105 "..\..\Views\T_Address\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n");

            
            #line 108 "..\..\Views\T_Address\CreateQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 108 "..\..\Views\T_Address\CreateQuick.cshtml"
                                 if(User.CanView("T_Address","T_ZipCode"))
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral(" id=\"dvT_ZipCode\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"ZipCode\"");

WriteLiteral(">\r\n                                    <label>");

            
            #line 112 "..\..\Views\T_Address\CreateQuick.cshtml"
                                      Write(Html.LabelFor(model => model.T_ZipCode));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t \r\n");

WriteLiteral("                                    ");

            
            #line 114 "..\..\Views\T_Address\CreateQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_ZipCode, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 115 "..\..\Views\T_Address\CreateQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_ZipCode));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 119 "..\..\Views\T_Address\CreateQuick.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("     \r\n\t\t\t\t\r\n                                    \r\n\r\n");

            
            #line 124 "..\..\Views\T_Address\CreateQuick.cshtml"
			
            
            #line default
            #line hidden
            
            #line 124 "..\..\Views\T_Address\CreateQuick.cshtml"
             if(User.CanView("T_Address","T_AddressCountryID"))
				{
					

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral("  id=\"dvT_AddressCountryID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label>");

            
            #line 129 "..\..\Views\T_Address\CreateQuick.cshtml"
                              Write(Html.LabelFor(model => model.T_AddressCountryID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 131 "..\..\Views\T_Address\CreateQuick.cshtml"
                               Write(Html.DropDownList("T_AddressCountryID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_Country", @dataurl = Url.Action("GetAllValue", "T_Country",new { caller = "T_AddressCountryID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n ");

WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 137 "..\..\Views\T_Address\CreateQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_AddressCountryID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"         </div>\r\n");

            
            #line 141 "..\..\Views\T_Address\CreateQuick.cshtml"
     
		}

            
            #line default
            #line hidden
WriteLiteral("                                    \r\n\r\n");

            
            #line 145 "..\..\Views\T_Address\CreateQuick.cshtml"
			
            
            #line default
            #line hidden
            
            #line 145 "..\..\Views\T_Address\CreateQuick.cshtml"
             if(User.CanView("T_Address","T_AddressStateID"))
				{
					

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral("  id=\"dvT_AddressStateID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label>");

            
            #line 150 "..\..\Views\T_Address\CreateQuick.cshtml"
                              Write(Html.LabelFor(model => model.T_AddressStateID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 152 "..\..\Views\T_Address\CreateQuick.cshtml"
                               Write(Html.DropDownList("T_AddressStateID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_State", @dataurl = Url.Action("GetAllValue", "T_State",new { caller = "T_AddressStateID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n ");

WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 158 "..\..\Views\T_Address\CreateQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_AddressStateID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"         </div>\r\n");

            
            #line 162 "..\..\Views\T_Address\CreateQuick.cshtml"
     
		}

            
            #line default
            #line hidden
WriteLiteral("                                    \r\n\r\n");

            
            #line 166 "..\..\Views\T_Address\CreateQuick.cshtml"
			
            
            #line default
            #line hidden
            
            #line 166 "..\..\Views\T_Address\CreateQuick.cshtml"
             if(User.CanView("T_Address","T_AddressCityID"))
				{
					

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6\'");

WriteLiteral("  id=\"dvT_AddressCityID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label>");

            
            #line 171 "..\..\Views\T_Address\CreateQuick.cshtml"
                              Write(Html.LabelFor(model => model.T_AddressCityID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 173 "..\..\Views\T_Address\CreateQuick.cshtml"
                               Write(Html.DropDownList("T_AddressCityID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_City", @dataurl = Url.Action("GetAllValue", "T_City",new { caller = "T_AddressCityID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n ");

WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 179 "..\..\Views\T_Address\CreateQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_AddressCityID));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n           " +
"         </div>\r\n");

            
            #line 183 "..\..\Views\T_Address\CreateQuick.cshtml"
     
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

            
            #line 191 "..\..\Views\T_Address\CreateQuick.cshtml"

		var busineesrule = User.businessrules.Where(p => p.EntityName == "T_Address").ToList();
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7967), Tuple.Create("\"", 8146)
, Tuple.Create(Tuple.Create("", 7977), Tuple.Create("QuickAdd(event,\'T_Address\',\'", 7977), true)
            
            #line 198 "..\..\Views\T_Address\CreateQuick.cshtml"
                                    , Tuple.Create(Tuple.Create("", 8005), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 8005), false)
, Tuple.Create(Tuple.Create("", 8018), Tuple.Create("\',", 8018), true)
            
            #line 198 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                   , Tuple.Create(Tuple.Create("", 8020), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 8020), false)
, Tuple.Create(Tuple.Create("", 8039), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 8039), true)
            
            #line 198 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                          , Tuple.Create(Tuple.Create("", 8075), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 8075), false)
, Tuple.Create(Tuple.Create("", 8094), Tuple.Create("\',\'", 8094), true)
            
            #line 198 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                , Tuple.Create(Tuple.Create("", 8097), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 8097), false)
, Tuple.Create(Tuple.Create("", 8120), Tuple.Create("\',\'", 8120), true)
            
            #line 198 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                                          , Tuple.Create(Tuple.Create("", 8123), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 8123), false)
, Tuple.Create(Tuple.Create("", 8143), Tuple.Create("\');", 8143), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral("  value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8255), Tuple.Create("\"", 8434)
, Tuple.Create(Tuple.Create("", 8265), Tuple.Create("QuickAdd(event,\'T_Address\',\'", 8265), true)
            
            #line 199 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                             , Tuple.Create(Tuple.Create("", 8293), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 8293), false)
, Tuple.Create(Tuple.Create("", 8306), Tuple.Create("\',", 8306), true)
            
            #line 199 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                            , Tuple.Create(Tuple.Create("", 8308), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 8308), false)
, Tuple.Create(Tuple.Create("", 8327), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 8327), true)
            
            #line 199 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                   , Tuple.Create(Tuple.Create("", 8363), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 8363), false)
, Tuple.Create(Tuple.Create("", 8382), Tuple.Create("\',\'", 8382), true)
            
            #line 199 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                                         , Tuple.Create(Tuple.Create("", 8385), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 8385), false)
, Tuple.Create(Tuple.Create("", 8408), Tuple.Create("\',\'", 8408), true)
            
            #line 199 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                                                                   , Tuple.Create(Tuple.Create("", 8411), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 8411), false)
, Tuple.Create(Tuple.Create("", 8431), Tuple.Create("\');", 8431), true)
);

WriteLiteral(" />\r\n");

            
            #line 200 "..\..\Views\T_Address\CreateQuick.cshtml"
		}
		else
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8527), Tuple.Create("\"", 8750)
, Tuple.Create(Tuple.Create("", 8537), Tuple.Create("QuickAddFromIndex(event,true,\'T_Address\',\'", 8537), true)
            
            #line 203 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                  , Tuple.Create(Tuple.Create("", 8579), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 8579), false)
, Tuple.Create(Tuple.Create("", 8606), Tuple.Create("\',\'", 8606), true)
            
            #line 203 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                , Tuple.Create(Tuple.Create("", 8609), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 8609), false)
, Tuple.Create(Tuple.Create("", 8622), Tuple.Create("\',", 8622), true)
            
            #line 203 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                               , Tuple.Create(Tuple.Create("", 8624), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 8624), false)
, Tuple.Create(Tuple.Create("", 8643), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 8643), true)
            
            #line 203 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                                      , Tuple.Create(Tuple.Create("", 8679), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 8679), false)
, Tuple.Create(Tuple.Create("", 8698), Tuple.Create("\',\'", 8698), true)
            
            #line 203 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 8701), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 8701), false)
, Tuple.Create(Tuple.Create("", 8724), Tuple.Create("\',\'", 8724), true)
            
            #line 203 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 8727), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 8727), false)
, Tuple.Create(Tuple.Create("", 8747), Tuple.Create("\');", 8747), true)
);

WriteLiteral(" />\r\n");

WriteLiteral(" <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" btnval=\"createcontinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8858), Tuple.Create("\"", 9081)
, Tuple.Create(Tuple.Create("", 8868), Tuple.Create("QuickAddFromIndex(event,true,\'T_Address\',\'", 8868), true)
            
            #line 204 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                          , Tuple.Create(Tuple.Create("", 8910), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 8910), false)
, Tuple.Create(Tuple.Create("", 8937), Tuple.Create("\',\'", 8937), true)
            
            #line 204 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                        , Tuple.Create(Tuple.Create("", 8940), Tuple.Create<System.Object, System.Int32>(busineesrule
            
            #line default
            #line hidden
, 8940), false)
, Tuple.Create(Tuple.Create("", 8953), Tuple.Create("\',", 8953), true)
            
            #line 204 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                       , Tuple.Create(Tuple.Create("", 8955), Tuple.Create<System.Object, System.Int32>(busineesrule.Count
            
            #line default
            #line hidden
, 8955), false)
, Tuple.Create(Tuple.Create("", 8974), Tuple.Create(",\'OnCreate\',\'ErrMsgQuickAdd\',false,\'", 8974), true)
            
            #line 204 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 9010), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 9010), false)
, Tuple.Create(Tuple.Create("", 9029), Tuple.Create("\',\'", 9029), true)
            
            #line 204 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 9032), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 9032), false)
, Tuple.Create(Tuple.Create("", 9055), Tuple.Create("\',\'", 9055), true)
            
            #line 204 "..\..\Views\T_Address\CreateQuick.cshtml"
                                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 9058), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 9058), false)
, Tuple.Create(Tuple.Create("", 9078), Tuple.Create("\');", 9078), true)
);

WriteLiteral(" />\r\n");

            
            #line 205 "..\..\Views\T_Address\CreateQuick.cshtml"
		}
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 9102), Tuple.Create("\"", 9143)
            
            #line 207 "..\..\Views\T_Address\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 9108), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 9108), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 9186), Tuple.Create("\"", 9225)
            
            #line 208 "..\..\Views\T_Address\CreateQuick.cshtml"
, Tuple.Create(Tuple.Create("", 9192), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 9192), false)
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
