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

namespace GeneratorBase.MVC.Views.T_MedicalFacilityForTreatment
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
    
    #line 2 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_MedicalFacilityForTreatment/EditQuick.cshtml")]
    public partial class EditQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_MedicalFacilityForTreatment>
    {
        
        #line 10 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        if (User.CanEdit("T_MedicalFacilityForTreatment", Property))
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
            
            #line 3 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
  
    ViewBag.Title = "Edit Medical Facility For Treatment";
	var EditPermission = User.CanEditItem("T_MedicalFacilityForTreatment", Model, User);
	var DeletePermission = User.CanDeleteItem("T_MedicalFacilityForTreatment", Model, User);
	Layout = null;
	

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral(@"<script>
    $(document).ready(function () {
        try {
		 if ($('#EntityT_MedicalFacilityForTreatmentDisplayValue').has('option').length > 0) {
			var RecId = $(""#Id"").val()
            $(""#T_MedicalFacilityForTreatmentDD"").append($(""#EntityT_MedicalFacilityForTreatmentDisplayValue"").html());
            $(""#T_MedicalFacilityForTreatmentDD"").val(RecId);

			var text = $(""option:selected"", $(""#T_MedicalFacilityForTreatmentDD"")).text();
            $(""#T_MedicalFacilityForTreatmentDD"").attr('data-toggle', 'tooltip')
            $(""#T_MedicalFacilityForTreatmentDD"").attr('title', text);

            var lastOptionVal = $('#T_MedicalFacilityForTreatmentDD option:last-child').val();
            var fristOptionVal = $('#T_MedicalFacilityForTreatmentDD option:first-child').val();
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

            
            #line 43 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 44 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t\t\tif( \'");

            
            #line 45 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
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

            
            #line 71 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_MedicalFacilityForTreatmentIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_MedicalFacilityForTreatmentIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 77 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_MedicalFacilityForTreatmentIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_MedicalFacilityForTreatmentIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 83 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_MedicalFacilityForTreatmentIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_MedicalFacilityForTreatmentIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 3407), Tuple.Create("\"", 3456)
, Tuple.Create(Tuple.Create("", 3414), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 3414), false)
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

            
            #line 100 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </h2>\r\n        </div>\r\n");

            
            #line 103 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
        
            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4307), Tuple.Create("\"", 4370)
            
            #line 106 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4317), Tuple.Create<System.Object, System.Int32>(Html.Raw("nextFun('T_MedicalFacilityForTreatment')")
            
            #line default
            #line hidden
, 4317), false)
);

WriteLiteral(">Next >></button>\r\n");

WriteLiteral("                ");

            
            #line 107 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
           Write(Html.DropDownList("T_MedicalFacilityForTreatmentDD", null, null, new { @onchange = "FillDisplayValueQEdit('T_MedicalFacilityForTreatment')", @required = "required", @class = "pull-right", @Style = "height: 22px;width: 170px;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"prev\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4712), Tuple.Create("\"", 4775)
            
            #line 108 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4722), Tuple.Create<System.Object, System.Int32>(Html.Raw("prevFun('T_MedicalFacilityForTreatment')")
            
            #line default
            #line hidden
, 4722), false)
);

WriteLiteral("><< Prev</button>\r\n            </div>\r\n");

            
            #line 110 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
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

            
            #line 124 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
 using (Html.BeginForm("EditQuick","T_MedicalFacilityForTreatment",new {UrlReferrer =Convert.ToString(ViewData["T_MedicalFacilityForTreatmentParentUrl"])}, FormMethod.Post, new { enctype = "multipart/form-data", @id = "frmQEditT_MedicalFacilityForTreatment" }))
{
     Html.ValidationSummary(true);
                Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                      
	
            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                  

            
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

            
            #line 134 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                       Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 136 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
				
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                 if(User.CanView("T_MedicalFacilityForTreatment","T_Name"))
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

            
            #line 142 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                    Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("  <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span> </label>\r\n                                \r\n\t\t\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 145 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name,  getHtmlAttributes("T_Name")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 146 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 151 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"

				
					


} else { 
            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
    Write(Html.HiddenFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                }

            
            #line default
            #line hidden
            
            #line 157 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
 if(User.CanView("T_MedicalFacilityForTreatment","T_Description"))
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

            
            #line 161 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                    Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                                \r\n");

WriteLiteral("\t\t\t\t\t\t\t\t");

            
            #line 163 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                           Write(Html.TextAreaFor(model => model.T_Description, getHtmlAttributes("T_Description")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 164 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 168 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
} else { 
            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
    Write(Html.HiddenFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                       }

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n\r\n\r\n\t            </div>\r\n        </div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 176 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
		 
            
            #line default
            #line hidden
            
            #line 176 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
    Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 176 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                 ;
		 var businessrule1 = User.businessrules.Where(p => p.EntityName == "T_MedicalFacilityForTreatment").ToList();
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

            
            #line 182 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7769), Tuple.Create("\"", 8010)
, Tuple.Create(Tuple.Create("", 7779), Tuple.Create("QuickEditFromGrid(event,true,\'T_MedicalFacilityForTreatment\',\'", 7779), true)
            
            #line 184 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                            , Tuple.Create(Tuple.Create("", 7841), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 7841), false)
, Tuple.Create(Tuple.Create("", 7868), Tuple.Create("\',false,\'", 7868), true)
            
            #line 184 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                                                , Tuple.Create(Tuple.Create("", 7877), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 7877), false)
, Tuple.Create(Tuple.Create("", 7891), Tuple.Create("\',", 7891), true)
            
            #line 184 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                                                                , Tuple.Create(Tuple.Create("", 7893), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 7893), false)
, Tuple.Create(Tuple.Create("", 7913), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 7913), true)
            
            #line 184 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 7939), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 7939), false)
, Tuple.Create(Tuple.Create("", 7958), Tuple.Create("\',\'", 7958), true)
            
            #line 184 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 7961), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 7961), false)
, Tuple.Create(Tuple.Create("", 7984), Tuple.Create("\',\'", 7984), true)
            
            #line 184 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 7987), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 7987), false)
, Tuple.Create(Tuple.Create("", 8007), Tuple.Create("\');", 8007), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"sevranBtn\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8136), Tuple.Create("\"", 8384)
, Tuple.Create(Tuple.Create("", 8146), Tuple.Create("QuickEditFromGrid(event,true,\'T_MedicalFacilityForTreatment\',\'", 8146), true)
            
            #line 185 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                            , Tuple.Create(Tuple.Create("", 8208), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 8208), false)
, Tuple.Create(Tuple.Create("", 8235), Tuple.Create("\',false,\'", 8235), true)
            
            #line 185 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                                                                , Tuple.Create(Tuple.Create("", 8244), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 8244), false)
, Tuple.Create(Tuple.Create("", 8258), Tuple.Create("\',", 8258), true)
            
            #line 185 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 8260), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 8260), false)
, Tuple.Create(Tuple.Create("", 8280), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 8280), true)
            
            #line 185 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 8306), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 8306), false)
, Tuple.Create(Tuple.Create("", 8325), Tuple.Create("\',\'", 8325), true)
            
            #line 185 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 8328), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 8328), false)
, Tuple.Create(Tuple.Create("", 8351), Tuple.Create("\',\'", 8351), true)
            
            #line 185 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                                                                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 8354), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 8354), false)
, Tuple.Create(Tuple.Create("", 8374), Tuple.Create("\',\'True\');", 8374), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"SaveAndContinue\"");

WriteLiteral(" name=\"SaveAndContinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8502), Tuple.Create("\"", 8583)
            
            #line 186 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                          , Tuple.Create(Tuple.Create("", 8512), Tuple.Create<System.Object, System.Int32>(Html.Raw("SaveAndContinueEdit('T_MedicalFacilityForTreatment',event)")
            
            #line default
            #line hidden
, 8512), false)
);

WriteLiteral(">Save & Next</button>\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

            
            #line 188 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
  		 }	
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 8682), Tuple.Create("\"", 8723)
            
            #line 190 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 8688), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 8688), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 8766), Tuple.Create("\"", 8805)
            
            #line 191 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 8772), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 8772), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@"></script>

<script>
    $(""input[type='submit']"").click(function (event) {
	if (!$(""#frmQEditT_MedicalFacilityForTreatment"").valid()) return;
	
        var $this = $(this);
        $('input:hidden[name=""hdncommand""]').val($this.val());
    });
</script>
");

            
            #line 201 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
  
var businessrule = User.businessrules.Where(p => p.EntityName == "T_MedicalFacilityForTreatment").ToList();


	


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

				 form = $(""#frmQEditT_MedicalFacilityForTreatment"").serialize();
					 dataurl = """);

            
            #line 222 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                           Write(Url.Action("businessruletype", "T_MedicalFacilityForTreatment", new { ruleType = "OnEdit"}));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            ApplyBusinessRuleOnPageLoad(\"");

            
            #line 223 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
                                    Write(typelist);

            
            #line default
            #line hidden
WriteLiteral("\",dataurl, \"T_MedicalFacilityForTreatment\", false, \"ErrMsg\", form);\r\n\t\t\t//busines" +
"s rules on inline associations\r\n    });\r\n</script>\r\n");

WriteLiteral(@"<script>
    $(""form"").submit(function (event) {
	if (!$(""#frmQEditT_MedicalFacilityForTreatment"").valid()) return;
	document.getElementById(""ErrMsg"").innerHTML = """";
            var flag = true;
		var form = $(""#frmQEditT_MedicalFacilityForTreatment"").serialize();
					});
</script>
");

            
            #line 235 "..\..\Views\T_MedicalFacilityForTreatment\EditQuick.cshtml"
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