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
    
    #line 2 "..\..\Views\T_City\EditQuick.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_City/EditQuick.cshtml")]
    public partial class EditQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_City>
    {
        
        #line 10 "..\..\Views\T_City\EditQuick.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        if (User.CanEdit("T_City", Property))
        {
            return new { @class = "form-control" };
        } return new { @class = "form-control", @readonly = "readonly" };
    }

        #line default
        #line hidden
        
        public EditQuick()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_City\EditQuick.cshtml"
  
    ViewBag.Title = "Edit City";
	var EditPermission = User.CanEditItem("T_City", Model, User);
	var DeletePermission = User.CanDeleteItem("T_City", Model, User);
	Layout = null;
	

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral(@"<script>
    $(document).ready(function () {
        try {
		 if ($('#EntityT_CityDisplayValue').has('option').length > 0) {
			var RecId = $(""#Id"").val()
            $(""#T_CityDD"").append($(""#EntityT_CityDisplayValue"").html());
            $(""#T_CityDD"").val(RecId);

			var text = $(""option:selected"", $(""#T_CityDD"")).text();
            $(""#T_CityDD"").attr('data-toggle', 'tooltip')
            $(""#T_CityDD"").attr('title', text);

            var lastOptionVal = $('#T_CityDD option:last-child').val();
            var fristOptionVal = $('#T_CityDD option:first-child').val();
            if (lastOptionVal == RecId)
			{
                $('#next').hide();
				$('#SaveAndContinue').hide();
				}

            if (fristOptionVal == RecId)
                $('#prev').hide();
			} else {  $('#dvsavenext').hide(); $('#SaveAndContinue').hide(); }
            var hostingEntityName = """";
            if ('");

            
            #line 43 "..\..\Views\T_City\EditQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 44 "..\..\Views\T_City\EditQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t\t\tif( \'");

            
            #line 45 "..\..\Views\T_City\EditQuick.cshtml"
                Write(Convert.ToBoolean(ViewData["IsFilter"]));

            
            #line default
            #line hidden
WriteLiteral(@"'!=""False"")
				$('#' + hostingEntityName + 'ID').attr(""lock"",""true"");
				$('#' + hostingEntityName + 'ID').trigger(""change"");
				 $(""input[type='radio'][name='"" + hostingEntityName + ""ID']"").each(function () {
                    if (!this.checked)
                        this.closest(""li"").style.display = ""none"";
                });		
						
            }
        }
        catch (ex) { }
    });
</script>
<script");

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

            
            #line 71 "..\..\Views\T_City\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CityIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_City\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CityIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_City\EditQuick.cshtml"
                                             ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 77 "..\..\Views\T_City\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CityIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_City\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CityIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_City\EditQuick.cshtml"
                                                   ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 83 "..\..\Views\T_City\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CityIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_City\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_CityIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_City\EditQuick.cshtml"
                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 2944), Tuple.Create("\"", 2993)
, Tuple.Create(Tuple.Create("", 2951), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 2951), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        ");

WriteLiteral("\r\n\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" />\r\n\t\t<div");

WriteLiteral(" id=\"errorContainerEdit\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"errorsMsgEdit\"");

WriteLiteral("></div>\r\n            <div");

WriteLiteral(" id=\"errorsEdit\"");

WriteLiteral("></div>\r\n        </div>\r\n     <div");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(" style=\"margin-top: -12px;\"");

WriteLiteral(">\r\n            <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" id=\"HostingEntityDisplayValue\"");

WriteLiteral(">");

            
            #line 100 "..\..\Views\T_City\EditQuick.cshtml"
                                                Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </h2>\r\n        </div>\r\n");

            
            #line 103 "..\..\Views\T_City\EditQuick.cshtml"
        
            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\T_City\EditQuick.cshtml"
         if (EditPermission)
            {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"col-sm-6 col-md-6 col-xs-12\"");

WriteLiteral(" id=\"dvsavenext\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"next\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3844), Tuple.Create("\"", 3884)
            
            #line 106 "..\..\Views\T_City\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 3854), Tuple.Create<System.Object, System.Int32>(Html.Raw("nextFun('T_City')")
            
            #line default
            #line hidden
, 3854), false)
);

WriteLiteral(">Next >></button>\r\n");

WriteLiteral("                ");

            
            #line 107 "..\..\Views\T_City\EditQuick.cshtml"
           Write(Html.DropDownList("T_CityDD", null, null, new { @onchange = "FillDisplayValueQEdit('T_City')", @required = "required", @class = "pull-right", @Style = "height: 22px;width: 170px;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"prev\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4180), Tuple.Create("\"", 4220)
            
            #line 108 "..\..\Views\T_City\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4190), Tuple.Create<System.Object, System.Int32>(Html.Raw("prevFun('T_City')")
            
            #line default
            #line hidden
, 4190), false)
);

WriteLiteral("><< Prev</button>\r\n            </div>\r\n");

            
            #line 110 "..\..\Views\T_City\EditQuick.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n    <!-- /.col-lg-12 -->\r\n\t<div");

WriteLiteral(" id=\"divDisplayBRmsgBeforeSaveProp\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"divDisplayBRmsgMandatory\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"divDisplayLockRecord\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"divDisplayBRReadOnly\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n</div>\r\n<br/>\r\n</div>\r\n\t\r\n");

            
            #line 124 "..\..\Views\T_City\EditQuick.cshtml"
 using (Html.BeginForm("EditQuick","T_City",new {UrlReferrer =Convert.ToString(ViewData["T_CityParentUrl"])}, FormMethod.Post, new { enctype = "multipart/form-data", @id = "frmQEditT_City" }))
{
     Html.ValidationSummary(true);
                Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_City\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_City\EditQuick.cshtml"
                                      
	
            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_City\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_City\EditQuick.cshtml"
                                                  

            
            #line default
            #line hidden
WriteLiteral("\t <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(" style=\"padding:0px; margin:0px;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t    ");

            
            #line 134 "..\..\Views\T_City\EditQuick.cshtml"
                       Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 136 "..\..\Views\T_City\EditQuick.cshtml"
				
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_City\EditQuick.cshtml"
                 if(User.CanView("T_City","T_Name"))
{



            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Name\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<label  >");

            
            #line 142 "..\..\Views\T_City\EditQuick.cshtml"
                                    Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("  <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span> </label>\r\n                                \r\n\t\t\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 145 "..\..\Views\T_City\EditQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name,  getHtmlAttributes("T_Name")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 146 "..\..\Views\T_City\EditQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 151 "..\..\Views\T_City\EditQuick.cshtml"

				
					


} else { 
            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_City\EditQuick.cshtml"
    Write(Html.HiddenFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                }

            
            #line default
            #line hidden
            
            #line 157 "..\..\Views\T_City\EditQuick.cshtml"
 if(User.CanView("T_City","T_Description"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Description\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<label  >");

            
            #line 161 "..\..\Views\T_City\EditQuick.cshtml"
                                    Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                                \r\n");

WriteLiteral("\t\t\t\t\t\t\t\t");

            
            #line 163 "..\..\Views\T_City\EditQuick.cshtml"
                           Write(Html.TextAreaFor(model => model.T_Description, getHtmlAttributes("T_Description")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 164 "..\..\Views\T_City\EditQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 168 "..\..\Views\T_City\EditQuick.cshtml"
} else { 
            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\T_City\EditQuick.cshtml"
    Write(Html.HiddenFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                       }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t");

            
            #line 169 "..\..\Views\T_City\EditQuick.cshtml"
                 if(User.CanView("T_City","T_CityCountryID"))
				{


            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_CityCountryID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label  >");

            
            #line 174 "..\..\Views\T_City\EditQuick.cshtml"
                                Write(Html.LabelFor(model => model.T_CityCountryID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\t\t\t\t\t\t\t\t\t\r\n");

            
            #line 177 "..\..\Views\T_City\EditQuick.cshtml"
									
            
            #line default
            #line hidden
            
            #line 177 "..\..\Views\T_City\EditQuick.cshtml"
                                     if (User.CanEdit("T_City", "T_CityCountryID"))
		{
			
            
            #line default
            #line hidden
            
            #line 179 "..\..\Views\T_City\EditQuick.cshtml"
       Write(Html.DropDownList("T_CityCountryID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_Country", @dataurl = Url.Action("GetAllValue", "T_Country",new { caller = "T_CityCountryID" }) }));

            
            #line default
            #line hidden
            
            #line 179 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                                                                                                             
		}
		else
		{
			
            
            #line default
            #line hidden
            
            #line 183 "..\..\Views\T_City\EditQuick.cshtml"
       Write(Html.HiddenFor(model => model.T_CityCountryID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 183 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                            
			
            
            #line default
            #line hidden
            
            #line 184 "..\..\Views\T_City\EditQuick.cshtml"
       Write(Html.DropDownList("T_CityCountryID", null, "-- Select --", new {     @class = "chosen-select form-control", @disabled="disabled", @HostingName = "T_Country", @dataurl = Url.Action("GetAllValue", "T_Country",new { caller = "T_CityCountryID" }) }));

            
            #line default
            #line hidden
            
            #line 184 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                                                                                                                                  
		}

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 186 "..\..\Views\T_City\EditQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_CityCountryID));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t \r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\r\n                        </div>\r\n            " +
"        </div>\r\n");

            
            #line 192 "..\..\Views\T_City\EditQuick.cshtml"
                 
					} else { 
            
            #line default
            #line hidden
            
            #line 193 "..\..\Views\T_City\EditQuick.cshtml"
                        Write(Html.HiddenFor(model => model.T_CityCountryID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 193 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                             }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t");

            
            #line 194 "..\..\Views\T_City\EditQuick.cshtml"
                 if(User.CanView("T_City","T_CityStateID"))
				{


            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_CityStateID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label  >");

            
            #line 199 "..\..\Views\T_City\EditQuick.cshtml"
                                Write(Html.LabelFor(model => model.T_CityStateID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\t\t\t\t\t\t\t\t\t\r\n");

            
            #line 202 "..\..\Views\T_City\EditQuick.cshtml"
									
            
            #line default
            #line hidden
            
            #line 202 "..\..\Views\T_City\EditQuick.cshtml"
                                     if (User.CanEdit("T_City", "T_CityStateID"))
		{
			
            
            #line default
            #line hidden
            
            #line 204 "..\..\Views\T_City\EditQuick.cshtml"
       Write(Html.DropDownList("T_CityStateID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_State", @dataurl = Url.Action("GetAllValue", "T_State",new { caller = "T_CityStateID" }) }));

            
            #line default
            #line hidden
            
            #line 204 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                                                                                                     
		}
		else
		{
			
            
            #line default
            #line hidden
            
            #line 208 "..\..\Views\T_City\EditQuick.cshtml"
       Write(Html.HiddenFor(model => model.T_CityStateID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 208 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                          
			
            
            #line default
            #line hidden
            
            #line 209 "..\..\Views\T_City\EditQuick.cshtml"
       Write(Html.DropDownList("T_CityStateID", null, "-- Select --", new {     @class = "chosen-select form-control", @disabled="disabled", @HostingName = "T_State", @dataurl = Url.Action("GetAllValue", "T_State",new { caller = "T_CityStateID" }) }));

            
            #line default
            #line hidden
            
            #line 209 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                                                                                                                          
		}

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 211 "..\..\Views\T_City\EditQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_CityStateID));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t \r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\r\n                        </div>\r\n            " +
"        </div>\r\n");

            
            #line 217 "..\..\Views\T_City\EditQuick.cshtml"
                 
					} else { 
            
            #line default
            #line hidden
            
            #line 218 "..\..\Views\T_City\EditQuick.cshtml"
                        Write(Html.HiddenFor(model => model.T_CityStateID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 218 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                           }

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n\r\n\r\n\t            </div>\r\n        </div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 226 "..\..\Views\T_City\EditQuick.cshtml"
		 
            
            #line default
            #line hidden
            
            #line 226 "..\..\Views\T_City\EditQuick.cshtml"
    Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 226 "..\..\Views\T_City\EditQuick.cshtml"
                                 ;
		 var businessrule1 = User.businessrules.Where(p => p.EntityName == "T_City").ToList();
		 var lstinlineentityname = "";
		 var lstinlineassocdispname ="";
		 var lstinlineassocname = "";

            
            #line default
            #line hidden
WriteLiteral("\t\t <button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

            
            #line 232 "..\..\Views\T_City\EditQuick.cshtml"
		 if (EditPermission)
         {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t    <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"command\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save & Close\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9654), Tuple.Create("\"", 9872)
, Tuple.Create(Tuple.Create("", 9664), Tuple.Create("QuickEditFromGrid(event,true,\'T_City\',\'", 9664), true)
            
            #line 234 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                     , Tuple.Create(Tuple.Create("", 9703), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 9703), false)
, Tuple.Create(Tuple.Create("", 9730), Tuple.Create("\',false,\'", 9730), true)
            
            #line 234 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                         , Tuple.Create(Tuple.Create("", 9739), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 9739), false)
, Tuple.Create(Tuple.Create("", 9753), Tuple.Create("\',", 9753), true)
            
            #line 234 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                         , Tuple.Create(Tuple.Create("", 9755), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 9755), false)
, Tuple.Create(Tuple.Create("", 9775), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 9775), true)
            
            #line 234 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                                                       , Tuple.Create(Tuple.Create("", 9801), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 9801), false)
, Tuple.Create(Tuple.Create("", 9820), Tuple.Create("\',\'", 9820), true)
            
            #line 234 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                                                                             , Tuple.Create(Tuple.Create("", 9823), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 9823), false)
, Tuple.Create(Tuple.Create("", 9846), Tuple.Create("\',\'", 9846), true)
            
            #line 234 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                                                                                                       , Tuple.Create(Tuple.Create("", 9849), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 9849), false)
, Tuple.Create(Tuple.Create("", 9869), Tuple.Create("\');", 9869), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"sevranBtn\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9998), Tuple.Create("\"", 10223)
, Tuple.Create(Tuple.Create("", 10008), Tuple.Create("QuickEditFromGrid(event,true,\'T_City\',\'", 10008), true)
            
            #line 235 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                    , Tuple.Create(Tuple.Create("", 10047), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 10047), false)
, Tuple.Create(Tuple.Create("", 10074), Tuple.Create("\',false,\'", 10074), true)
            
            #line 235 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                        , Tuple.Create(Tuple.Create("", 10083), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 10083), false)
, Tuple.Create(Tuple.Create("", 10097), Tuple.Create("\',", 10097), true)
            
            #line 235 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                        , Tuple.Create(Tuple.Create("", 10099), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 10099), false)
, Tuple.Create(Tuple.Create("", 10119), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 10119), true)
            
            #line 235 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 10145), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 10145), false)
, Tuple.Create(Tuple.Create("", 10164), Tuple.Create("\',\'", 10164), true)
            
            #line 235 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 10167), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 10167), false)
, Tuple.Create(Tuple.Create("", 10190), Tuple.Create("\',\'", 10190), true)
            
            #line 235 "..\..\Views\T_City\EditQuick.cshtml"
                                                                                                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 10193), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 10193), false)
, Tuple.Create(Tuple.Create("", 10213), Tuple.Create("\',\'True\');", 10213), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"SaveAndContinue\"");

WriteLiteral(" name=\"SaveAndContinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 10341), Tuple.Create("\"", 10399)
            
            #line 236 "..\..\Views\T_City\EditQuick.cshtml"
                                         , Tuple.Create(Tuple.Create("", 10351), Tuple.Create<System.Object, System.Int32>(Html.Raw("SaveAndContinueEdit('T_City',event)")
            
            #line default
            #line hidden
, 10351), false)
);

WriteLiteral(">Save & Next</button>\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

            
            #line 238 "..\..\Views\T_City\EditQuick.cshtml"
  		 }	
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 10498), Tuple.Create("\"", 10539)
            
            #line 240 "..\..\Views\T_City\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 10504), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 10504), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 10582), Tuple.Create("\"", 10621)
            
            #line 241 "..\..\Views\T_City\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 10588), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 10588), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n<script>\r\n    $(\"input[type=\'submit\']\").click(function (event) {\r\n\t" +
"if (!$(\"#frmQEditT_City\").valid()) return;\r\n\t\r\n        var $this = $(this);\r\n   " +
"     $(\'input:hidden[name=\"hdncommand\"]\').val($this.val());\r\n    });\r\n</script>\r" +
"\n");

            
            #line 251 "..\..\Views\T_City\EditQuick.cshtml"
  
var businessrule = User.businessrules.Where(p => p.EntityName == "T_City").ToList();


	


if ((businessrule != null && businessrule.Count > 0) )
{
var ruleids = businessrule.Select(q => q.Id).ToList();
var typelist  = string.Join(",", (new GeneratorBase.MVC.Models.RuleActionContext()).RuleActions.Where(p => ruleids.Contains(p.RuleActionID.Value) && p.associatedactiontype.TypeNo.HasValue).Select(p => p.associatedactiontype.TypeNo.Value).Distinct().ToList());


            
            #line default
            #line hidden
WriteLiteral(@"    <script>
    $(document).ready(function () {
	document.getElementById(""ErrMsg"").innerHTML = """";
		 var flag = true;
                var dataurl = """";
                var form = """";
                var inlinecount = ""0"";

				 form = $(""#frmQEditT_City"").serialize();
					 dataurl = """);

            
            #line 272 "..\..\Views\T_City\EditQuick.cshtml"
                           Write(Url.Action("businessruletype", "T_City", new { ruleType = "OnEdit"}));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            ApplyBusinessRuleOnPageLoad(\"");

            
            #line 273 "..\..\Views\T_City\EditQuick.cshtml"
                                    Write(typelist);

            
            #line default
            #line hidden
WriteLiteral("\",dataurl, \"T_City\", false, \"ErrMsg\", form);\r\n\t\t\t//business rules on inline assoc" +
"iations\r\n    });\r\n</script>\r\n");

WriteLiteral("<script>\r\n    $(\"form\").submit(function (event) {\r\n\tif (!$(\"#frmQEditT_City\").val" +
"id()) return;\r\n\tdocument.getElementById(\"ErrMsg\").innerHTML = \"\";\r\n            v" +
"ar flag = true;\r\n\t\tvar form = $(\"#frmQEditT_City\").serialize();\r\n\t\t\t\t\t});\r\n</scr" +
"ipt>\r\n");

            
            #line 285 "..\..\Views\T_City\EditQuick.cshtml"
}
 

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<script");

WriteLiteral(" type=\'text/javascript\'");

WriteLiteral(@">
    $(document).ready(function () {
        try {
            document.getElementsByTagName(""body"")[0].focus();
            $(""#addPopup"").removeAttr(""tabindex"");
            var cltcoll = $(""#dvPopup"").find('input[type=text]:not([class=hidden]):not([readonly]),textarea:not([readonly])')
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
                setTimeout(function () { $(cltid).focus(); }, 500)
        }
        catch (ex) { }
    });
</script>

");

        }
    }
}
#pragma warning restore 1591
