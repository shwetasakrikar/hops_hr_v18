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
    
    #line 2 "..\..\Views\T_ClaimType\EditQuick.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ClaimType/EditQuick.cshtml")]
    public partial class EditQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_ClaimType>
    {
        
        #line 10 "..\..\Views\T_ClaimType\EditQuick.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        if (User.CanEdit("T_ClaimType", Property))
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
            
            #line 3 "..\..\Views\T_ClaimType\EditQuick.cshtml"
  
    ViewBag.Title = "Edit Claim Type";
	var EditPermission = User.CanEditItem("T_ClaimType", Model, User);
	var DeletePermission = User.CanDeleteItem("T_ClaimType", Model, User);
	Layout = null;
	

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral(@"<script>
    $(document).ready(function () {
        try {
		 if ($('#EntityT_ClaimTypeDisplayValue').has('option').length > 0) {
			var RecId = $(""#Id"").val()
            $(""#T_ClaimTypeDD"").append($(""#EntityT_ClaimTypeDisplayValue"").html());
            $(""#T_ClaimTypeDD"").val(RecId);

			var text = $(""option:selected"", $(""#T_ClaimTypeDD"")).text();
            $(""#T_ClaimTypeDD"").attr('data-toggle', 'tooltip')
            $(""#T_ClaimTypeDD"").attr('title', text);

            var lastOptionVal = $('#T_ClaimTypeDD option:last-child').val();
            var fristOptionVal = $('#T_ClaimTypeDD option:first-child').val();
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

            
            #line 43 "..\..\Views\T_ClaimType\EditQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 44 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t\t\tif( \'");

            
            #line 45 "..\..\Views\T_ClaimType\EditQuick.cshtml"
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

            
            #line 71 "..\..\Views\T_ClaimType\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClaimTypeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_ClaimType\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ClaimTypeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                  ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 77 "..\..\Views\T_ClaimType\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClaimTypeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_ClaimType\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ClaimTypeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 83 "..\..\Views\T_ClaimType\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ClaimTypeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_ClaimType\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_ClaimTypeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                      ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 3045), Tuple.Create("\"", 3094)
, Tuple.Create(Tuple.Create("", 3052), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 3052), false)
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

            
            #line 100 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </h2>\r\n        </div>\r\n");

            
            #line 103 "..\..\Views\T_ClaimType\EditQuick.cshtml"
        
            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\T_ClaimType\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3945), Tuple.Create("\"", 3990)
            
            #line 106 "..\..\Views\T_ClaimType\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 3955), Tuple.Create<System.Object, System.Int32>(Html.Raw("nextFun('T_ClaimType')")
            
            #line default
            #line hidden
, 3955), false)
);

WriteLiteral(">Next >></button>\r\n");

WriteLiteral("                ");

            
            #line 107 "..\..\Views\T_ClaimType\EditQuick.cshtml"
           Write(Html.DropDownList("T_ClaimTypeDD", null, null, new { @onchange = "FillDisplayValueQEdit('T_ClaimType')", @required = "required", @class = "pull-right", @Style = "height: 22px;width: 170px;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"prev\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4296), Tuple.Create("\"", 4341)
            
            #line 108 "..\..\Views\T_ClaimType\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4306), Tuple.Create<System.Object, System.Int32>(Html.Raw("prevFun('T_ClaimType')")
            
            #line default
            #line hidden
, 4306), false)
);

WriteLiteral("><< Prev</button>\r\n            </div>\r\n");

            
            #line 110 "..\..\Views\T_ClaimType\EditQuick.cshtml"
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

            
            #line 124 "..\..\Views\T_ClaimType\EditQuick.cshtml"
 using (Html.BeginForm("EditQuick","T_ClaimType",new {UrlReferrer =Convert.ToString(ViewData["T_ClaimTypeParentUrl"])}, FormMethod.Post, new { enctype = "multipart/form-data", @id = "frmQEditT_ClaimType" }))
{
     Html.ValidationSummary(true);
                Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_ClaimType\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                      
	
            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_ClaimType\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                  

            
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

            
            #line 134 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                       Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 136 "..\..\Views\T_ClaimType\EditQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                 if(User.CanView("T_ClaimType","T_ClaimTypeFacilityAssociationID"))
				{


            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_ClaimTypeFacilityAssociationID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label  >");

            
            #line 141 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                Write(Html.LabelFor(model => model.T_ClaimTypeFacilityAssociationID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\t\t\t\t\t\t\t\t\t\r\n");

            
            #line 144 "..\..\Views\T_ClaimType\EditQuick.cshtml"
									
            
            #line default
            #line hidden
            
            #line 144 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                     if (User.CanEdit("T_ClaimType", "T_ClaimTypeFacilityAssociationID"))
		{
			
            
            #line default
            #line hidden
            
            #line 146 "..\..\Views\T_ClaimType\EditQuick.cshtml"
       Write(Html.DropDownList("T_ClaimTypeFacilityAssociationID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_Facility", @dataurl = Url.Action("GetAllValue", "T_Facility",new { caller = "T_ClaimTypeFacilityAssociationID" }) }));

            
            #line default
            #line hidden
            
            #line 146 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                                                                                                                                                                 
		}
		else
		{
			
            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\T_ClaimType\EditQuick.cshtml"
       Write(Html.HiddenFor(model => model.T_ClaimTypeFacilityAssociationID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                             
			
            
            #line default
            #line hidden
            
            #line 151 "..\..\Views\T_ClaimType\EditQuick.cshtml"
       Write(Html.DropDownList("T_ClaimTypeFacilityAssociationID", null, "-- Select --", new {     @class = "chosen-select form-control", @disabled="disabled", @HostingName = "T_Facility", @dataurl = Url.Action("GetAllValue", "T_Facility",new { caller = "T_ClaimTypeFacilityAssociationID" }) }));

            
            #line default
            #line hidden
            
            #line 151 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                                                                                                                                                                                      
		}

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 153 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_ClaimTypeFacilityAssociationID));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t \r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\r\n                        </div>\r\n            " +
"        </div>\r\n");

            
            #line 159 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                 
					} else { 
            
            #line default
            #line hidden
            
            #line 160 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                        Write(Html.HiddenFor(model => model.T_ClaimTypeFacilityAssociationID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 160 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                              }

            
            #line default
            #line hidden
            
            #line 161 "..\..\Views\T_ClaimType\EditQuick.cshtml"
 if(User.CanView("T_ClaimType","T_Name"))
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

            
            #line 167 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                    Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("  <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span> </label>\r\n                                \r\n\t\t\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 170 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name,  getHtmlAttributes("T_Name")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 171 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 176 "..\..\Views\T_ClaimType\EditQuick.cshtml"

				
					


} else { 
            
            #line default
            #line hidden
            
            #line 181 "..\..\Views\T_ClaimType\EditQuick.cshtml"
    Write(Html.HiddenFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 181 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                }

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n\r\n\r\n");

            
            #line 185 "..\..\Views\T_ClaimType\EditQuick.cshtml"
	
            
            #line default
            #line hidden
            
            #line 185 "..\..\Views\T_ClaimType\EditQuick.cshtml"
     if ( (User.CanEdit("T_EmployeeInjury") && User.CanEdit("T_TypeofClaim")))
                    {

            
            #line default
            #line hidden
WriteLiteral("\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-sm-12 col-md-12 col-sx-12\"");

WriteLiteral(" id=\"dvT_ClaimType\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(" style=\"margin:0px; padding:8px;\"");

WriteLiteral(">\r\n                                     Employee Injury\r\n                        " +
"        </div>\r\n\t\t\t\t\t\t\t\t <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t ");

            
            #line 194 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                Write(Html.DropDownList("SelectedT_EmployeeInjury_T_TypeofClaim", null, new { @multiple = "multiple", @HostingName = "T_EmployeeInjury", @dataurl = Url.Action("GetAllMultiSelectValue", "T_EmployeeInjury", null) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n                    </div>\r\n             </div>\r\n" +
"");

WriteLiteral("\t\t\t <script>\r\n\t\t\t$(document).ready(function () {\r\n\t\t\t \t $(\'#SelectedT_EmployeeInj" +
"ury_T_TypeofClaim\').multiselect({ buttonWidth: \'100%\'});\r\n\t\t\t});\r\n\t\t</script>\r\n");

            
            #line 204 "..\..\Views\T_ClaimType\EditQuick.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        </div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 209 "..\..\Views\T_ClaimType\EditQuick.cshtml"
		 
            
            #line default
            #line hidden
            
            #line 209 "..\..\Views\T_ClaimType\EditQuick.cshtml"
    Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 209 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                 ;
		 var businessrule1 = User.businessrules.Where(p => p.EntityName == "T_ClaimType").ToList();
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

            
            #line 215 "..\..\Views\T_ClaimType\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9106), Tuple.Create("\"", 9329)
, Tuple.Create(Tuple.Create("", 9116), Tuple.Create("QuickEditFromGrid(event,true,\'T_ClaimType\',\'", 9116), true)
            
            #line 217 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                          , Tuple.Create(Tuple.Create("", 9160), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 9160), false)
, Tuple.Create(Tuple.Create("", 9187), Tuple.Create("\',false,\'", 9187), true)
            
            #line 217 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                              , Tuple.Create(Tuple.Create("", 9196), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 9196), false)
, Tuple.Create(Tuple.Create("", 9210), Tuple.Create("\',", 9210), true)
            
            #line 217 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                              , Tuple.Create(Tuple.Create("", 9212), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 9212), false)
, Tuple.Create(Tuple.Create("", 9232), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 9232), true)
            
            #line 217 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 9258), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 9258), false)
, Tuple.Create(Tuple.Create("", 9277), Tuple.Create("\',\'", 9277), true)
            
            #line 217 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 9280), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 9280), false)
, Tuple.Create(Tuple.Create("", 9303), Tuple.Create("\',\'", 9303), true)
            
            #line 217 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 9306), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 9306), false)
, Tuple.Create(Tuple.Create("", 9326), Tuple.Create("\');", 9326), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"sevranBtn\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9455), Tuple.Create("\"", 9685)
, Tuple.Create(Tuple.Create("", 9465), Tuple.Create("QuickEditFromGrid(event,true,\'T_ClaimType\',\'", 9465), true)
            
            #line 218 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                          , Tuple.Create(Tuple.Create("", 9509), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 9509), false)
, Tuple.Create(Tuple.Create("", 9536), Tuple.Create("\',false,\'", 9536), true)
            
            #line 218 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                              , Tuple.Create(Tuple.Create("", 9545), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 9545), false)
, Tuple.Create(Tuple.Create("", 9559), Tuple.Create("\',", 9559), true)
            
            #line 218 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                                              , Tuple.Create(Tuple.Create("", 9561), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 9561), false)
, Tuple.Create(Tuple.Create("", 9581), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 9581), true)
            
            #line 218 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 9607), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 9607), false)
, Tuple.Create(Tuple.Create("", 9626), Tuple.Create("\',\'", 9626), true)
            
            #line 218 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                                                                                                                  , Tuple.Create(Tuple.Create("", 9629), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 9629), false)
, Tuple.Create(Tuple.Create("", 9652), Tuple.Create("\',\'", 9652), true)
            
            #line 218 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                                                                                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 9655), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 9655), false)
, Tuple.Create(Tuple.Create("", 9675), Tuple.Create("\',\'True\');", 9675), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"SaveAndContinue\"");

WriteLiteral(" name=\"SaveAndContinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9803), Tuple.Create("\"", 9866)
            
            #line 219 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                          , Tuple.Create(Tuple.Create("", 9813), Tuple.Create<System.Object, System.Int32>(Html.Raw("SaveAndContinueEdit('T_ClaimType',event)")
            
            #line default
            #line hidden
, 9813), false)
);

WriteLiteral(">Save & Next</button>\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

            
            #line 221 "..\..\Views\T_ClaimType\EditQuick.cshtml"
  		 }	
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 9965), Tuple.Create("\"", 10006)
            
            #line 223 "..\..\Views\T_ClaimType\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 9971), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 9971), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 10049), Tuple.Create("\"", 10088)
            
            #line 224 "..\..\Views\T_ClaimType\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 10055), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 10055), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n<script>\r\n    $(\"input[type=\'submit\']\").click(function (event) {\r\n\t" +
"if (!$(\"#frmQEditT_ClaimType\").valid()) return;\r\n\t\r\n        var $this = $(this);" +
"\r\n        $(\'input:hidden[name=\"hdncommand\"]\').val($this.val());\r\n    });\r\n</scr" +
"ipt>\r\n");

            
            #line 234 "..\..\Views\T_ClaimType\EditQuick.cshtml"
  
var businessrule = User.businessrules.Where(p => p.EntityName == "T_ClaimType").ToList();


	


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

				 form = $(""#frmQEditT_ClaimType"").serialize();
					 dataurl = """);

            
            #line 255 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                           Write(Url.Action("businessruletype", "T_ClaimType", new { ruleType = "OnEdit"}));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            ApplyBusinessRuleOnPageLoad(\"");

            
            #line 256 "..\..\Views\T_ClaimType\EditQuick.cshtml"
                                    Write(typelist);

            
            #line default
            #line hidden
WriteLiteral("\",dataurl, \"T_ClaimType\", false, \"ErrMsg\", form);\r\n\t\t\t//business rules on inline " +
"associations\r\n    });\r\n</script>\r\n");

WriteLiteral(@"<script>
    $(""form"").submit(function (event) {
	if (!$(""#frmQEditT_ClaimType"").valid()) return;
	document.getElementById(""ErrMsg"").innerHTML = """";
            var flag = true;
		var form = $(""#frmQEditT_ClaimType"").serialize();
					});
</script>
");

            
            #line 268 "..\..\Views\T_ClaimType\EditQuick.cshtml"
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
