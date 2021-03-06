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

namespace GeneratorBase.MVC.Views.T_LanguageCertifiedIn
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
    
    #line 2 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_LanguageCertifiedIn/EditQuick.cshtml")]
    public partial class EditQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_LanguageCertifiedIn>
    {
        
        #line 10 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        if (User.CanEdit("T_LanguageCertifiedIn", Property))
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
            
            #line 3 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
  
    ViewBag.Title = "Edit Language Certified In";
	var EditPermission = User.CanEditItem("T_LanguageCertifiedIn", Model, User);
	var DeletePermission = User.CanDeleteItem("T_LanguageCertifiedIn", Model, User);
	Layout = null;
	

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral(@"<script>
    $(document).ready(function () {
        try {
		 if ($('#EntityT_LanguageCertifiedInDisplayValue').has('option').length > 0) {
			var RecId = $(""#Id"").val()
            $(""#T_LanguageCertifiedInDD"").append($(""#EntityT_LanguageCertifiedInDisplayValue"").html());
            $(""#T_LanguageCertifiedInDD"").val(RecId);

			var text = $(""option:selected"", $(""#T_LanguageCertifiedInDD"")).text();
            $(""#T_LanguageCertifiedInDD"").attr('data-toggle', 'tooltip')
            $(""#T_LanguageCertifiedInDD"").attr('title', text);

            var lastOptionVal = $('#T_LanguageCertifiedInDD option:last-child').val();
            var fristOptionVal = $('#T_LanguageCertifiedInDD option:first-child').val();
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

            
            #line 43 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 44 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t\t\tif( \'");

            
            #line 45 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
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

            
            #line 71 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_LanguageCertifiedInIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_LanguageCertifiedInIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                            ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 77 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                  ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 83 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_LanguageCertifiedInIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_LanguageCertifiedInIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 3246), Tuple.Create("\"", 3295)
, Tuple.Create(Tuple.Create("", 3253), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 3253), false)
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

            
            #line 100 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </h2>\r\n        </div>\r\n");

            
            #line 103 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
        
            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4146), Tuple.Create("\"", 4201)
            
            #line 106 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4156), Tuple.Create<System.Object, System.Int32>(Html.Raw("nextFun('T_LanguageCertifiedIn')")
            
            #line default
            #line hidden
, 4156), false)
);

WriteLiteral(">Next >></button>\r\n");

WriteLiteral("                ");

            
            #line 107 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
           Write(Html.DropDownList("T_LanguageCertifiedInDD", null, null, new { @onchange = "FillDisplayValueQEdit('T_LanguageCertifiedIn')", @required = "required", @class = "pull-right", @Style = "height: 22px;width: 170px;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"prev\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4527), Tuple.Create("\"", 4582)
            
            #line 108 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4537), Tuple.Create<System.Object, System.Int32>(Html.Raw("prevFun('T_LanguageCertifiedIn')")
            
            #line default
            #line hidden
, 4537), false)
);

WriteLiteral("><< Prev</button>\r\n            </div>\r\n");

            
            #line 110 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
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

            
            #line 124 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
 using (Html.BeginForm("EditQuick","T_LanguageCertifiedIn",new {UrlReferrer =Convert.ToString(ViewData["T_LanguageCertifiedInParentUrl"])}, FormMethod.Post, new { enctype = "multipart/form-data", @id = "frmQEditT_LanguageCertifiedIn" }))
{
     Html.ValidationSummary(true);
                Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                      
	
            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                  

            
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

            
            #line 134 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                       Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("\t\t\t");

            
            #line 136 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
       Write(Html.HiddenFor(model => model.T_EmployeeID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 137 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
       Write(Html.HiddenFor(model => model.T_LangaugeID, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\t            </div>\r\n        </div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 143 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
		 
            
            #line default
            #line hidden
            
            #line 143 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
    Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 143 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                 ;
		 var businessrule1 = User.businessrules.Where(p => p.EntityName == "T_LanguageCertifiedIn").ToList();
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

            
            #line 149 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6406), Tuple.Create("\"", 6639)
, Tuple.Create(Tuple.Create("", 6416), Tuple.Create("QuickEditFromGrid(event,true,\'T_LanguageCertifiedIn\',\'", 6416), true)
            
            #line 151 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                    , Tuple.Create(Tuple.Create("", 6470), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 6470), false)
, Tuple.Create(Tuple.Create("", 6497), Tuple.Create("\',false,\'", 6497), true)
            
            #line 151 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                                        , Tuple.Create(Tuple.Create("", 6506), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 6506), false)
, Tuple.Create(Tuple.Create("", 6520), Tuple.Create("\',", 6520), true)
            
            #line 151 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                                                        , Tuple.Create(Tuple.Create("", 6522), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 6522), false)
, Tuple.Create(Tuple.Create("", 6542), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 6542), true)
            
            #line 151 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 6568), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 6568), false)
, Tuple.Create(Tuple.Create("", 6587), Tuple.Create("\',\'", 6587), true)
            
            #line 151 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 6590), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 6590), false)
, Tuple.Create(Tuple.Create("", 6613), Tuple.Create("\',\'", 6613), true)
            
            #line 151 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 6616), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 6616), false)
, Tuple.Create(Tuple.Create("", 6636), Tuple.Create("\');", 6636), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"sevranBtn\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6765), Tuple.Create("\"", 7005)
, Tuple.Create(Tuple.Create("", 6775), Tuple.Create("QuickEditFromGrid(event,true,\'T_LanguageCertifiedIn\',\'", 6775), true)
            
            #line 152 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                    , Tuple.Create(Tuple.Create("", 6829), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 6829), false)
, Tuple.Create(Tuple.Create("", 6856), Tuple.Create("\',false,\'", 6856), true)
            
            #line 152 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                                                        , Tuple.Create(Tuple.Create("", 6865), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 6865), false)
, Tuple.Create(Tuple.Create("", 6879), Tuple.Create("\',", 6879), true)
            
            #line 152 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                                                                        , Tuple.Create(Tuple.Create("", 6881), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 6881), false)
, Tuple.Create(Tuple.Create("", 6901), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 6901), true)
            
            #line 152 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 6927), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 6927), false)
, Tuple.Create(Tuple.Create("", 6946), Tuple.Create("\',\'", 6946), true)
            
            #line 152 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                                                                                                                                            , Tuple.Create(Tuple.Create("", 6949), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 6949), false)
, Tuple.Create(Tuple.Create("", 6972), Tuple.Create("\',\'", 6972), true)
            
            #line 152 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                                                                                                                                                                                                                                                      , Tuple.Create(Tuple.Create("", 6975), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 6975), false)
, Tuple.Create(Tuple.Create("", 6995), Tuple.Create("\',\'True\');", 6995), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"SaveAndContinue\"");

WriteLiteral(" name=\"SaveAndContinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7123), Tuple.Create("\"", 7196)
            
            #line 153 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                          , Tuple.Create(Tuple.Create("", 7133), Tuple.Create<System.Object, System.Int32>(Html.Raw("SaveAndContinueEdit('T_LanguageCertifiedIn',event)")
            
            #line default
            #line hidden
, 7133), false)
);

WriteLiteral(">Save & Next</button>\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

            
            #line 155 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
  		 }	
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7295), Tuple.Create("\"", 7336)
            
            #line 157 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 7301), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 7301), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7379), Tuple.Create("\"", 7418)
            
            #line 158 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 7385), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 7385), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@"></script>

<script>
    $(""input[type='submit']"").click(function (event) {
	if (!$(""#frmQEditT_LanguageCertifiedIn"").valid()) return;
	
        var $this = $(this);
        $('input:hidden[name=""hdncommand""]').val($this.val());
    });
</script>
");

            
            #line 168 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
  
var businessrule = User.businessrules.Where(p => p.EntityName == "T_LanguageCertifiedIn").ToList();


	


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

				 form = $(""#frmQEditT_LanguageCertifiedIn"").serialize();
					 dataurl = """);

            
            #line 189 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                           Write(Url.Action("businessruletype", "T_LanguageCertifiedIn", new { ruleType = "OnEdit"}));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            ApplyBusinessRuleOnPageLoad(\"");

            
            #line 190 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
                                    Write(typelist);

            
            #line default
            #line hidden
WriteLiteral("\",dataurl, \"T_LanguageCertifiedIn\", false, \"ErrMsg\", form);\r\n\t\t\t//business rules " +
"on inline associations\r\n    });\r\n</script>\r\n");

WriteLiteral(@"<script>
    $(""form"").submit(function (event) {
	if (!$(""#frmQEditT_LanguageCertifiedIn"").valid()) return;
	document.getElementById(""ErrMsg"").innerHTML = """";
            var flag = true;
		var form = $(""#frmQEditT_LanguageCertifiedIn"").serialize();
					});
</script>
");

            
            #line 202 "..\..\Views\T_LanguageCertifiedIn\EditQuick.cshtml"
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
