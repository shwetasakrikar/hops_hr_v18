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

namespace GeneratorBase.MVC.Views.T_TypeofClaim
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
    
    #line 2 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_TypeofClaim/EditQuick.cshtml")]
    public partial class EditQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_TypeofClaim>
    {
        
        #line 10 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        if (User.CanEdit("T_TypeofClaim", Property))
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
            
            #line 3 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
  
    ViewBag.Title = "Edit Type of Claim";
	var EditPermission = User.CanEditItem("T_TypeofClaim", Model, User);
	var DeletePermission = User.CanDeleteItem("T_TypeofClaim", Model, User);
	Layout = null;
	

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral(@"<script>
    $(document).ready(function () {
        try {
		 if ($('#EntityT_TypeofClaimDisplayValue').has('option').length > 0) {
			var RecId = $(""#Id"").val()
            $(""#T_TypeofClaimDD"").append($(""#EntityT_TypeofClaimDisplayValue"").html());
            $(""#T_TypeofClaimDD"").val(RecId);

			var text = $(""option:selected"", $(""#T_TypeofClaimDD"")).text();
            $(""#T_TypeofClaimDD"").attr('data-toggle', 'tooltip')
            $(""#T_TypeofClaimDD"").attr('title', text);

            var lastOptionVal = $('#T_TypeofClaimDD option:last-child').val();
            var fristOptionVal = $('#T_TypeofClaimDD option:first-child').val();
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

            
            #line 43 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 44 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t\t\tif( \'");

            
            #line 45 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
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

            
            #line 71 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TypeofClaimIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_TypeofClaimIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 77 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TypeofClaimIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_TypeofClaimIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 83 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_TypeofClaimIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_TypeofClaimIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 3086), Tuple.Create("\"", 3135)
, Tuple.Create(Tuple.Create("", 3093), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 3093), false)
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

            
            #line 100 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </h2>\r\n        </div>\r\n");

            
            #line 103 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
        
            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3986), Tuple.Create("\"", 4033)
            
            #line 106 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 3996), Tuple.Create<System.Object, System.Int32>(Html.Raw("nextFun('T_TypeofClaim')")
            
            #line default
            #line hidden
, 3996), false)
);

WriteLiteral(">Next >></button>\r\n");

WriteLiteral("                ");

            
            #line 107 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
           Write(Html.DropDownList("T_TypeofClaimDD", null, null, new { @onchange = "FillDisplayValueQEdit('T_TypeofClaim')", @required = "required", @class = "pull-right", @Style = "height: 22px;width: 170px;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"prev\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4343), Tuple.Create("\"", 4390)
            
            #line 108 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4353), Tuple.Create<System.Object, System.Int32>(Html.Raw("prevFun('T_TypeofClaim')")
            
            #line default
            #line hidden
, 4353), false)
);

WriteLiteral("><< Prev</button>\r\n            </div>\r\n");

            
            #line 110 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
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

            
            #line 124 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
 using (Html.BeginForm("EditQuick","T_TypeofClaim",new {UrlReferrer =Convert.ToString(ViewData["T_TypeofClaimParentUrl"])}, FormMethod.Post, new { enctype = "multipart/form-data", @id = "frmQEditT_TypeofClaim" }))
{
     Html.ValidationSummary(true);
                Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                      
	
            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                  

            
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

            
            #line 134 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                       Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 136 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
								
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                 if(User.CanView("T_TypeofClaim","T_ClaimTypeID"))
				{


            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_ClaimTypeID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label  >");

            
            #line 141 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                Write(Html.LabelFor(model => model.T_ClaimTypeID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\t\t\t\t\t\t\t\t\t\r\n");

            
            #line 144 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
									
            
            #line default
            #line hidden
            
            #line 144 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                     if (User.CanEdit("T_TypeofClaim", "T_ClaimTypeID"))
		{
			
            
            #line default
            #line hidden
            
            #line 146 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
       Write(Html.DropDownList("T_ClaimTypeID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_ClaimType", @dataurl = Url.Action("GetAllValue", "T_ClaimType",new { caller = "T_ClaimTypeID" }) }));

            
            #line default
            #line hidden
            
            #line 146 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                                                                                             
		}
		else
		{
			
            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
       Write(Html.HiddenFor(model => model.T_ClaimTypeID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                          
			
            
            #line default
            #line hidden
            
            #line 151 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
       Write(Html.DropDownList("T_ClaimTypeID", null, "-- Select --", new {     @class = "chosen-select form-control", @disabled="disabled", @HostingName = "T_ClaimType", @dataurl = Url.Action("GetAllValue", "T_ClaimType",new { caller = "T_ClaimTypeID" }) }));

            
            #line default
            #line hidden
            
            #line 151 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                                                                                                                  
		}

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 153 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_ClaimTypeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t \r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\r\n                        </div>\r\n            " +
"        </div>\r\n");

            
            #line 159 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                 
					} else { 
            
            #line default
            #line hidden
            
            #line 160 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                        Write(Html.HiddenFor(model => model.T_ClaimTypeID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 160 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                           }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t");

            
            #line 161 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                 if(User.CanView("T_TypeofClaim","T_EmployeeInjuryID"))
				{


            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_EmployeeInjuryID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label  >");

            
            #line 166 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                Write(Html.LabelFor(model => model.T_EmployeeInjuryID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\t\t\t\t\t\t\t\t\t\r\n");

            
            #line 169 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
									
            
            #line default
            #line hidden
            
            #line 169 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                     if (User.CanEdit("T_TypeofClaim", "T_EmployeeInjuryID"))
		{
			
            
            #line default
            #line hidden
            
            #line 171 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
       Write(Html.DropDownList("T_EmployeeInjuryID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_EmployeeInjury", @dataurl = Url.Action("GetAllValue", "T_EmployeeInjury",new { caller = "T_EmployeeInjuryID" }) }));

            
            #line default
            #line hidden
            
            #line 171 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                                                                                                                 
		}
		else
		{
			
            
            #line default
            #line hidden
            
            #line 175 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
       Write(Html.HiddenFor(model => model.T_EmployeeInjuryID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 175 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                               
			
            
            #line default
            #line hidden
            
            #line 176 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
       Write(Html.DropDownList("T_EmployeeInjuryID", null, "-- Select --", new {     @class = "chosen-select form-control", @disabled="disabled", @HostingName = "T_EmployeeInjury", @dataurl = Url.Action("GetAllValue", "T_EmployeeInjury",new { caller = "T_EmployeeInjuryID" }) }));

            
            #line default
            #line hidden
            
            #line 176 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                                                                                                                                      
		}

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 178 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_EmployeeInjuryID));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t \r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\r\n                        </div>\r\n            " +
"        </div>\r\n");

            
            #line 184 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                 
					} else { 
            
            #line default
            #line hidden
            
            #line 185 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                        Write(Html.HiddenFor(model => model.T_EmployeeInjuryID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 185 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                }

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n\r\n\r\n\t            </div>\r\n        </div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 193 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
		 
            
            #line default
            #line hidden
            
            #line 193 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
    Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 193 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                 ;
		 var businessrule1 = User.businessrules.Where(p => p.EntityName == "T_TypeofClaim").ToList();
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

            
            #line 199 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8750), Tuple.Create("\"", 8975)
, Tuple.Create(Tuple.Create("", 8760), Tuple.Create("QuickEditFromGrid(event,true,\'T_TypeofClaim\',\'", 8760), true)
            
            #line 201 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                            , Tuple.Create(Tuple.Create("", 8806), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 8806), false)
, Tuple.Create(Tuple.Create("", 8833), Tuple.Create("\',false,\'", 8833), true)
            
            #line 201 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                , Tuple.Create(Tuple.Create("", 8842), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 8842), false)
, Tuple.Create(Tuple.Create("", 8856), Tuple.Create("\',", 8856), true)
            
            #line 201 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                , Tuple.Create(Tuple.Create("", 8858), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 8858), false)
, Tuple.Create(Tuple.Create("", 8878), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 8878), true)
            
            #line 201 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 8904), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 8904), false)
, Tuple.Create(Tuple.Create("", 8923), Tuple.Create("\',\'", 8923), true)
            
            #line 201 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 8926), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 8926), false)
, Tuple.Create(Tuple.Create("", 8949), Tuple.Create("\',\'", 8949), true)
            
            #line 201 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 8952), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 8952), false)
, Tuple.Create(Tuple.Create("", 8972), Tuple.Create("\');", 8972), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"sevranBtn\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9101), Tuple.Create("\"", 9333)
, Tuple.Create(Tuple.Create("", 9111), Tuple.Create("QuickEditFromGrid(event,true,\'T_TypeofClaim\',\'", 9111), true)
            
            #line 202 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                            , Tuple.Create(Tuple.Create("", 9157), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 9157), false)
, Tuple.Create(Tuple.Create("", 9184), Tuple.Create("\',false,\'", 9184), true)
            
            #line 202 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                , Tuple.Create(Tuple.Create("", 9193), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 9193), false)
, Tuple.Create(Tuple.Create("", 9207), Tuple.Create("\',", 9207), true)
            
            #line 202 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                , Tuple.Create(Tuple.Create("", 9209), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 9209), false)
, Tuple.Create(Tuple.Create("", 9229), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 9229), true)
            
            #line 202 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 9255), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 9255), false)
, Tuple.Create(Tuple.Create("", 9274), Tuple.Create("\',\'", 9274), true)
            
            #line 202 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                                                                                    , Tuple.Create(Tuple.Create("", 9277), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 9277), false)
, Tuple.Create(Tuple.Create("", 9300), Tuple.Create("\',\'", 9300), true)
            
            #line 202 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                                                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 9303), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 9303), false)
, Tuple.Create(Tuple.Create("", 9323), Tuple.Create("\',\'True\');", 9323), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"SaveAndContinue\"");

WriteLiteral(" name=\"SaveAndContinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9451), Tuple.Create("\"", 9516)
            
            #line 203 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                          , Tuple.Create(Tuple.Create("", 9461), Tuple.Create<System.Object, System.Int32>(Html.Raw("SaveAndContinueEdit('T_TypeofClaim',event)")
            
            #line default
            #line hidden
, 9461), false)
);

WriteLiteral(">Save & Next</button>\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

            
            #line 205 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
  		 }	
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 9615), Tuple.Create("\"", 9656)
            
            #line 207 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 9621), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 9621), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 9699), Tuple.Create("\"", 9738)
            
            #line 208 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 9705), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 9705), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n<script>\r\n    $(\"input[type=\'submit\']\").click(function (event) {\r\n\t" +
"if (!$(\"#frmQEditT_TypeofClaim\").valid()) return;\r\n\t\r\n        var $this = $(this" +
");\r\n        $(\'input:hidden[name=\"hdncommand\"]\').val($this.val());\r\n    });\r\n</s" +
"cript>\r\n");

            
            #line 218 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
  
var businessrule = User.businessrules.Where(p => p.EntityName == "T_TypeofClaim").ToList();


	


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

				 form = $(""#frmQEditT_TypeofClaim"").serialize();
					 dataurl = """);

            
            #line 239 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                           Write(Url.Action("businessruletype", "T_TypeofClaim", new { ruleType = "OnEdit"}));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            ApplyBusinessRuleOnPageLoad(\"");

            
            #line 240 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
                                    Write(typelist);

            
            #line default
            #line hidden
WriteLiteral("\",dataurl, \"T_TypeofClaim\", false, \"ErrMsg\", form);\r\n\t\t\t//business rules on inlin" +
"e associations\r\n    });\r\n</script>\r\n");

WriteLiteral(@"<script>
    $(""form"").submit(function (event) {
	if (!$(""#frmQEditT_TypeofClaim"").valid()) return;
	document.getElementById(""ErrMsg"").innerHTML = """";
            var flag = true;
		var form = $(""#frmQEditT_TypeofClaim"").serialize();
					});
</script>
");

            
            #line 252 "..\..\Views\T_TypeofClaim\EditQuick.cshtml"
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
