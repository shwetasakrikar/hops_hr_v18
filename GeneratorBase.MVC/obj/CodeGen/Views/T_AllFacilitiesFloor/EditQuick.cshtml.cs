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

namespace GeneratorBase.MVC.Views.T_AllFacilitiesFloor
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
    
    #line 2 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_AllFacilitiesFloor/EditQuick.cshtml")]
    public partial class EditQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_AllFacilitiesFloor>
    {
        
        #line 10 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        if (User.CanEdit("T_AllFacilitiesFloor", Property))
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
            
            #line 3 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
  
    ViewBag.Title = "Edit All Facilities Floor";
	var EditPermission = User.CanEditItem("T_AllFacilitiesFloor", Model, User);
	var DeletePermission = User.CanDeleteItem("T_AllFacilitiesFloor", Model, User);
	Layout = null;
	

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral(@"<script>
    $(document).ready(function () {
        try {
		 if ($('#EntityT_AllFacilitiesFloorDisplayValue').has('option').length > 0) {
			var RecId = $(""#Id"").val()
            $(""#T_AllFacilitiesFloorDD"").append($(""#EntityT_AllFacilitiesFloorDisplayValue"").html());
            $(""#T_AllFacilitiesFloorDD"").val(RecId);

			var text = $(""option:selected"", $(""#T_AllFacilitiesFloorDD"")).text();
            $(""#T_AllFacilitiesFloorDD"").attr('data-toggle', 'tooltip')
            $(""#T_AllFacilitiesFloorDD"").attr('title', text);

            var lastOptionVal = $('#T_AllFacilitiesFloorDD option:last-child').val();
            var fristOptionVal = $('#T_AllFacilitiesFloorDD option:first-child').val();
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

            
            #line 43 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 44 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t\t\tif( \'");

            
            #line 45 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
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

            
            #line 71 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_AllFacilitiesFloorIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_AllFacilitiesFloorIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                           ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 77 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_AllFacilitiesFloorIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_AllFacilitiesFloorIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                 ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 83 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_AllFacilitiesFloorIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_AllFacilitiesFloorIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                               ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 3226), Tuple.Create("\"", 3275)
, Tuple.Create(Tuple.Create("", 3233), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 3233), false)
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

            
            #line 100 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </h2>\r\n        </div>\r\n");

            
            #line 103 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
        
            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4126), Tuple.Create("\"", 4180)
            
            #line 106 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4136), Tuple.Create<System.Object, System.Int32>(Html.Raw("nextFun('T_AllFacilitiesFloor')")
            
            #line default
            #line hidden
, 4136), false)
);

WriteLiteral(">Next >></button>\r\n");

WriteLiteral("                ");

            
            #line 107 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
           Write(Html.DropDownList("T_AllFacilitiesFloorDD", null, null, new { @onchange = "FillDisplayValueQEdit('T_AllFacilitiesFloor')", @required = "required", @class = "pull-right", @Style = "height: 22px;width: 170px;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"prev\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4504), Tuple.Create("\"", 4558)
            
            #line 108 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4514), Tuple.Create<System.Object, System.Int32>(Html.Raw("prevFun('T_AllFacilitiesFloor')")
            
            #line default
            #line hidden
, 4514), false)
);

WriteLiteral("><< Prev</button>\r\n            </div>\r\n");

            
            #line 110 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
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

            
            #line 124 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
 using (Html.BeginForm("EditQuick","T_AllFacilitiesFloor",new {UrlReferrer =Convert.ToString(ViewData["T_AllFacilitiesFloorParentUrl"])}, FormMethod.Post, new { enctype = "multipart/form-data", @id = "frmQEditT_AllFacilitiesFloor" }))
{
     Html.ValidationSummary(true);
                Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                      
	
            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                  

            
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

            
            #line 134 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                       Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 136 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
				
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                 if(User.CanView("T_AllFacilitiesFloor","T_Name"))
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

            
            #line 142 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                    Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("  <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span> </label>\r\n                                \r\n\t\t\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 145 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name,  getHtmlAttributes("T_Name")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 146 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 151 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"

				
					


} else { 
            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
    Write(Html.HiddenFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                }

            
            #line default
            #line hidden
            
            #line 157 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
 if(User.CanView("T_AllFacilitiesFloor","T_Description"))
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

            
            #line 161 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                    Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                                \r\n");

WriteLiteral("\t\t\t\t\t\t\t\t");

            
            #line 163 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                           Write(Html.TextAreaFor(model => model.T_Description, getHtmlAttributes("T_Description")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 164 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 168 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
} else { 
            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
    Write(Html.HiddenFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                       }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t");

            
            #line 169 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                 if(User.CanView("T_AllFacilitiesFloor","T_AllUnitsFloorID"))
				{


            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_AllUnitsFloorID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label  >");

            
            #line 174 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                Write(Html.LabelFor(model => model.T_AllUnitsFloorID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\t\t\t\t\t\t\t\t\t\r\n");

            
            #line 177 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
									
            
            #line default
            #line hidden
            
            #line 177 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                     if (User.CanEdit("T_AllFacilitiesFloor", "T_AllUnitsFloorID"))
		{
			
            
            #line default
            #line hidden
            
            #line 179 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
       Write(Html.DropDownList("T_AllUnitsFloorID", null, "-- Select --", new {      @class = "chosen-select form-control", @HostingName = "T_AllFacilitiesUnit", @dataurl = Url.Action("GetAllValue", "T_AllFacilitiesUnit",new { caller = "T_AllUnitsFloorID" }) }));

            
            #line default
            #line hidden
            
            #line 179 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                                                                                                                                     
		}
		else
		{
			
            
            #line default
            #line hidden
            
            #line 183 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
       Write(Html.HiddenFor(model => model.T_AllUnitsFloorID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 183 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                              
			
            
            #line default
            #line hidden
            
            #line 184 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
       Write(Html.DropDownList("T_AllUnitsFloorID", null, "-- Select --", new {     @class = "chosen-select form-control", @disabled="disabled", @HostingName = "T_AllFacilitiesUnit", @dataurl = Url.Action("GetAllValue", "T_AllFacilitiesUnit",new { caller = "T_AllUnitsFloorID" }) }));

            
            #line default
            #line hidden
            
            #line 184 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                                                                                                                                                          
		}

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 186 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                           Write(Html.ValidationMessageFor(model => model.T_AllUnitsFloorID));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t \r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\r\n                        </div>\r\n            " +
"        </div>\r\n");

            
            #line 192 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                 
					} else { 
            
            #line default
            #line hidden
            
            #line 193 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                        Write(Html.HiddenFor(model => model.T_AllUnitsFloorID, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 193 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                               }

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n\r\n\r\n\t            </div>\r\n        </div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 201 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
		 
            
            #line default
            #line hidden
            
            #line 201 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
    Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 201 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                 ;
		 var businessrule1 = User.businessrules.Where(p => p.EntityName == "T_AllFacilitiesFloor").ToList();
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

            
            #line 207 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8892), Tuple.Create("\"", 9124)
, Tuple.Create(Tuple.Create("", 8902), Tuple.Create("QuickEditFromGrid(event,true,\'T_AllFacilitiesFloor\',\'", 8902), true)
            
            #line 209 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                   , Tuple.Create(Tuple.Create("", 8955), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 8955), false)
, Tuple.Create(Tuple.Create("", 8982), Tuple.Create("\',false,\'", 8982), true)
            
            #line 209 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                       , Tuple.Create(Tuple.Create("", 8991), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 8991), false)
, Tuple.Create(Tuple.Create("", 9005), Tuple.Create("\',", 9005), true)
            
            #line 209 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                       , Tuple.Create(Tuple.Create("", 9007), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 9007), false)
, Tuple.Create(Tuple.Create("", 9027), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 9027), true)
            
            #line 209 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                                                                     , Tuple.Create(Tuple.Create("", 9053), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 9053), false)
, Tuple.Create(Tuple.Create("", 9072), Tuple.Create("\',\'", 9072), true)
            
            #line 209 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                                                                                           , Tuple.Create(Tuple.Create("", 9075), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 9075), false)
, Tuple.Create(Tuple.Create("", 9098), Tuple.Create("\',\'", 9098), true)
            
            #line 209 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                                                                                                                     , Tuple.Create(Tuple.Create("", 9101), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 9101), false)
, Tuple.Create(Tuple.Create("", 9121), Tuple.Create("\');", 9121), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"sevranBtn\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9250), Tuple.Create("\"", 9489)
, Tuple.Create(Tuple.Create("", 9260), Tuple.Create("QuickEditFromGrid(event,true,\'T_AllFacilitiesFloor\',\'", 9260), true)
            
            #line 210 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                   , Tuple.Create(Tuple.Create("", 9313), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 9313), false)
, Tuple.Create(Tuple.Create("", 9340), Tuple.Create("\',false,\'", 9340), true)
            
            #line 210 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                       , Tuple.Create(Tuple.Create("", 9349), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 9349), false)
, Tuple.Create(Tuple.Create("", 9363), Tuple.Create("\',", 9363), true)
            
            #line 210 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                                       , Tuple.Create(Tuple.Create("", 9365), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 9365), false)
, Tuple.Create(Tuple.Create("", 9385), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 9385), true)
            
            #line 210 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                                                                                     , Tuple.Create(Tuple.Create("", 9411), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 9411), false)
, Tuple.Create(Tuple.Create("", 9430), Tuple.Create("\',\'", 9430), true)
            
            #line 210 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                                                                                                           , Tuple.Create(Tuple.Create("", 9433), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 9433), false)
, Tuple.Create(Tuple.Create("", 9456), Tuple.Create("\',\'", 9456), true)
            
            #line 210 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                                                                                                                                                                                                                                                     , Tuple.Create(Tuple.Create("", 9459), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 9459), false)
, Tuple.Create(Tuple.Create("", 9479), Tuple.Create("\',\'True\');", 9479), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"SaveAndContinue\"");

WriteLiteral(" name=\"SaveAndContinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9607), Tuple.Create("\"", 9679)
            
            #line 211 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                          , Tuple.Create(Tuple.Create("", 9617), Tuple.Create<System.Object, System.Int32>(Html.Raw("SaveAndContinueEdit('T_AllFacilitiesFloor',event)")
            
            #line default
            #line hidden
, 9617), false)
);

WriteLiteral(">Save & Next</button>\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

            
            #line 213 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
  		 }	
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 9778), Tuple.Create("\"", 9819)
            
            #line 215 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 9784), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 9784), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 9862), Tuple.Create("\"", 9901)
            
            #line 216 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 9868), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 9868), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@"></script>

<script>
    $(""input[type='submit']"").click(function (event) {
	if (!$(""#frmQEditT_AllFacilitiesFloor"").valid()) return;
	
        var $this = $(this);
        $('input:hidden[name=""hdncommand""]').val($this.val());
    });
</script>
");

            
            #line 226 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
  
var businessrule = User.businessrules.Where(p => p.EntityName == "T_AllFacilitiesFloor").ToList();


	


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

				 form = $(""#frmQEditT_AllFacilitiesFloor"").serialize();
					 dataurl = """);

            
            #line 247 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                           Write(Url.Action("businessruletype", "T_AllFacilitiesFloor", new { ruleType = "OnEdit"}));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            ApplyBusinessRuleOnPageLoad(\"");

            
            #line 248 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
                                    Write(typelist);

            
            #line default
            #line hidden
WriteLiteral("\",dataurl, \"T_AllFacilitiesFloor\", false, \"ErrMsg\", form);\r\n\t\t\t//business rules o" +
"n inline associations\r\n    });\r\n</script>\r\n");

WriteLiteral(@"<script>
    $(""form"").submit(function (event) {
	if (!$(""#frmQEditT_AllFacilitiesFloor"").valid()) return;
	document.getElementById(""ErrMsg"").innerHTML = """";
            var flag = true;
		var form = $(""#frmQEditT_AllFacilitiesFloor"").serialize();
					});
</script>
");

            
            #line 260 "..\..\Views\T_AllFacilitiesFloor\EditQuick.cshtml"
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