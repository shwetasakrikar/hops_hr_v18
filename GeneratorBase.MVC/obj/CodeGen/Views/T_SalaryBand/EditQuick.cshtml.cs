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

namespace GeneratorBase.MVC.Views.T_SalaryBand
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
    
    #line 2 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_SalaryBand/EditQuick.cshtml")]
    public partial class EditQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_SalaryBand>
    {
        
        #line 10 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        if (User.CanEdit("T_SalaryBand", Property))
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
            
            #line 3 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
  
    ViewBag.Title = "Edit Salary Band";
	var EditPermission = User.CanEditItem("T_SalaryBand", Model, User);
	var DeletePermission = User.CanDeleteItem("T_SalaryBand", Model, User);
	Layout = null;
	

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral(@"<script>
    $(document).ready(function () {
        try {
		 if ($('#EntityT_SalaryBandDisplayValue').has('option').length > 0) {
			var RecId = $(""#Id"").val()
            $(""#T_SalaryBandDD"").append($(""#EntityT_SalaryBandDisplayValue"").html());
            $(""#T_SalaryBandDD"").val(RecId);

			var text = $(""option:selected"", $(""#T_SalaryBandDD"")).text();
            $(""#T_SalaryBandDD"").attr('data-toggle', 'tooltip')
            $(""#T_SalaryBandDD"").attr('title', text);

            var lastOptionVal = $('#T_SalaryBandDD option:last-child').val();
            var fristOptionVal = $('#T_SalaryBandDD option:first-child').val();
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

            
            #line 43 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 44 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t\t\tif( \'");

            
            #line 45 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
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

            
            #line 71 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_SalaryBandIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_SalaryBandIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                   ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 77 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_SalaryBandIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_SalaryBandIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                         ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 83 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_SalaryBandIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_SalaryBandIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                       ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 3065), Tuple.Create("\"", 3114)
, Tuple.Create(Tuple.Create("", 3072), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 3072), false)
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

            
            #line 100 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </h2>\r\n        </div>\r\n");

            
            #line 103 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
        
            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3965), Tuple.Create("\"", 4011)
            
            #line 106 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 3975), Tuple.Create<System.Object, System.Int32>(Html.Raw("nextFun('T_SalaryBand')")
            
            #line default
            #line hidden
, 3975), false)
);

WriteLiteral(">Next >></button>\r\n");

WriteLiteral("                ");

            
            #line 107 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
           Write(Html.DropDownList("T_SalaryBandDD", null, null, new { @onchange = "FillDisplayValueQEdit('T_SalaryBand')", @required = "required", @class = "pull-right", @Style = "height: 22px;width: 170px;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"prev\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4319), Tuple.Create("\"", 4365)
            
            #line 108 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4329), Tuple.Create<System.Object, System.Int32>(Html.Raw("prevFun('T_SalaryBand')")
            
            #line default
            #line hidden
, 4329), false)
);

WriteLiteral("><< Prev</button>\r\n            </div>\r\n");

            
            #line 110 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
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

            
            #line 124 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
 using (Html.BeginForm("EditQuick","T_SalaryBand",new {UrlReferrer =Convert.ToString(ViewData["T_SalaryBandParentUrl"])}, FormMethod.Post, new { enctype = "multipart/form-data", @id = "frmQEditT_SalaryBand" }))
{
     Html.ValidationSummary(true);
                Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                      
	
            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                  

            
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

            
            #line 134 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                       Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 136 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
				
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                 if(User.CanView("T_SalaryBand","T_Name"))
{



            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Band\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<label  >");

            
            #line 142 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                    Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("  <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span> </label>\r\n                                \r\n\t\t\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 145 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name,  getHtmlAttributes("T_Name")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 146 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 151 "..\..\Views\T_SalaryBand\EditQuick.cshtml"

				
					


} else { 
            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
    Write(Html.HiddenFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                }

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n\r\n\r\n\t            </div>\r\n        </div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 164 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
		 
            
            #line default
            #line hidden
            
            #line 164 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
    Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 164 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                 ;
		 var businessrule1 = User.businessrules.Where(p => p.EntityName == "T_SalaryBand").ToList();
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

            
            #line 170 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6663), Tuple.Create("\"", 6887)
, Tuple.Create(Tuple.Create("", 6673), Tuple.Create("QuickEditFromGrid(event,true,\'T_SalaryBand\',\'", 6673), true)
            
            #line 172 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                           , Tuple.Create(Tuple.Create("", 6718), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 6718), false)
, Tuple.Create(Tuple.Create("", 6745), Tuple.Create("\',false,\'", 6745), true)
            
            #line 172 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                                               , Tuple.Create(Tuple.Create("", 6754), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 6754), false)
, Tuple.Create(Tuple.Create("", 6768), Tuple.Create("\',", 6768), true)
            
            #line 172 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                                                               , Tuple.Create(Tuple.Create("", 6770), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 6770), false)
, Tuple.Create(Tuple.Create("", 6790), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 6790), true)
            
            #line 172 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                                                                                                             , Tuple.Create(Tuple.Create("", 6816), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 6816), false)
, Tuple.Create(Tuple.Create("", 6835), Tuple.Create("\',\'", 6835), true)
            
            #line 172 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                                                                                                                                   , Tuple.Create(Tuple.Create("", 6838), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 6838), false)
, Tuple.Create(Tuple.Create("", 6861), Tuple.Create("\',\'", 6861), true)
            
            #line 172 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                                                                                                                                                             , Tuple.Create(Tuple.Create("", 6864), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 6864), false)
, Tuple.Create(Tuple.Create("", 6884), Tuple.Create("\');", 6884), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"sevranBtn\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7013), Tuple.Create("\"", 7244)
, Tuple.Create(Tuple.Create("", 7023), Tuple.Create("QuickEditFromGrid(event,true,\'T_SalaryBand\',\'", 7023), true)
            
            #line 173 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                           , Tuple.Create(Tuple.Create("", 7068), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 7068), false)
, Tuple.Create(Tuple.Create("", 7095), Tuple.Create("\',false,\'", 7095), true)
            
            #line 173 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                                                               , Tuple.Create(Tuple.Create("", 7104), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 7104), false)
, Tuple.Create(Tuple.Create("", 7118), Tuple.Create("\',", 7118), true)
            
            #line 173 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                                                                               , Tuple.Create(Tuple.Create("", 7120), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 7120), false)
, Tuple.Create(Tuple.Create("", 7140), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 7140), true)
            
            #line 173 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                                                                                                                             , Tuple.Create(Tuple.Create("", 7166), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 7166), false)
, Tuple.Create(Tuple.Create("", 7185), Tuple.Create("\',\'", 7185), true)
            
            #line 173 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                                                                                                                                                   , Tuple.Create(Tuple.Create("", 7188), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 7188), false)
, Tuple.Create(Tuple.Create("", 7211), Tuple.Create("\',\'", 7211), true)
            
            #line 173 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                                                                                                                                                                                                                                             , Tuple.Create(Tuple.Create("", 7214), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 7214), false)
, Tuple.Create(Tuple.Create("", 7234), Tuple.Create("\',\'True\');", 7234), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"SaveAndContinue\"");

WriteLiteral(" name=\"SaveAndContinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7362), Tuple.Create("\"", 7426)
            
            #line 174 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                          , Tuple.Create(Tuple.Create("", 7372), Tuple.Create<System.Object, System.Int32>(Html.Raw("SaveAndContinueEdit('T_SalaryBand',event)")
            
            #line default
            #line hidden
, 7372), false)
);

WriteLiteral(">Save & Next</button>\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

            
            #line 176 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
  		 }	
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7525), Tuple.Create("\"", 7566)
            
            #line 178 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 7531), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 7531), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7609), Tuple.Create("\"", 7648)
            
            #line 179 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 7615), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 7615), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n<script>\r\n    $(\"input[type=\'submit\']\").click(function (event) {\r\n\t" +
"if (!$(\"#frmQEditT_SalaryBand\").valid()) return;\r\n\t\r\n        var $this = $(this)" +
";\r\n        $(\'input:hidden[name=\"hdncommand\"]\').val($this.val());\r\n    });\r\n</sc" +
"ript>\r\n");

            
            #line 189 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
  
var businessrule = User.businessrules.Where(p => p.EntityName == "T_SalaryBand").ToList();


	


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

				 form = $(""#frmQEditT_SalaryBand"").serialize();
					 dataurl = """);

            
            #line 210 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                           Write(Url.Action("businessruletype", "T_SalaryBand", new { ruleType = "OnEdit"}));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            ApplyBusinessRuleOnPageLoad(\"");

            
            #line 211 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
                                    Write(typelist);

            
            #line default
            #line hidden
WriteLiteral("\",dataurl, \"T_SalaryBand\", false, \"ErrMsg\", form);\r\n\t\t\t//business rules on inline" +
" associations\r\n    });\r\n</script>\r\n");

WriteLiteral(@"<script>
    $(""form"").submit(function (event) {
	if (!$(""#frmQEditT_SalaryBand"").valid()) return;
	document.getElementById(""ErrMsg"").innerHTML = """";
            var flag = true;
		var form = $(""#frmQEditT_SalaryBand"").serialize();
					});
</script>
");

            
            #line 223 "..\..\Views\T_SalaryBand\EditQuick.cshtml"
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
