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

namespace GeneratorBase.MVC.Views.T_SocCode
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
    
    #line 2 "..\..\Views\T_SocCode\EditQuick.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_SocCode/EditQuick.cshtml")]
    public partial class EditQuick : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_SocCode>
    {
        
        #line 10 "..\..\Views\T_SocCode\EditQuick.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        if (User.CanEdit("T_SocCode", Property))
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
            
            #line 3 "..\..\Views\T_SocCode\EditQuick.cshtml"
  
    ViewBag.Title = "Edit SOC Code";
	var EditPermission = User.CanEditItem("T_SocCode", Model, User);
	var DeletePermission = User.CanDeleteItem("T_SocCode", Model, User);
	Layout = null;
	

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral(@"<script>
    $(document).ready(function () {
        try {
		 if ($('#EntityT_SocCodeDisplayValue').has('option').length > 0) {
			var RecId = $(""#Id"").val()
            $(""#T_SocCodeDD"").append($(""#EntityT_SocCodeDisplayValue"").html());
            $(""#T_SocCodeDD"").val(RecId);

			var text = $(""option:selected"", $(""#T_SocCodeDD"")).text();
            $(""#T_SocCodeDD"").attr('data-toggle', 'tooltip')
            $(""#T_SocCodeDD"").attr('title', text);

            var lastOptionVal = $('#T_SocCodeDD option:last-child').val();
            var fristOptionVal = $('#T_SocCodeDD option:first-child').val();
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

            
            #line 43 "..\..\Views\T_SocCode\EditQuick.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 44 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t\t\tif( \'");

            
            #line 45 "..\..\Views\T_SocCode\EditQuick.cshtml"
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

            
            #line 71 "..\..\Views\T_SocCode\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_SocCodeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_SocCode\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_SocCodeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 77 "..\..\Views\T_SocCode\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_SocCodeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_SocCode\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_SocCodeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                      ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 83 "..\..\Views\T_SocCode\EditQuick.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_SocCodeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_SocCode\EditQuick.cshtml"
   Write(Html.Raw(ViewBag.T_SocCodeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 3005), Tuple.Create("\"", 3054)
, Tuple.Create(Tuple.Create("", 3012), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 3012), false)
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

            
            #line 100 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </h2>\r\n        </div>\r\n");

            
            #line 103 "..\..\Views\T_SocCode\EditQuick.cshtml"
        
            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\T_SocCode\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3905), Tuple.Create("\"", 3948)
            
            #line 106 "..\..\Views\T_SocCode\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 3915), Tuple.Create<System.Object, System.Int32>(Html.Raw("nextFun('T_SocCode')")
            
            #line default
            #line hidden
, 3915), false)
);

WriteLiteral(">Next >></button>\r\n");

WriteLiteral("                ");

            
            #line 107 "..\..\Views\T_SocCode\EditQuick.cshtml"
           Write(Html.DropDownList("T_SocCodeDD", null, null, new { @onchange = "FillDisplayValueQEdit('T_SocCode')", @required = "required", @class = "pull-right", @Style = "height: 22px;width: 170px;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"prev\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4250), Tuple.Create("\"", 4293)
            
            #line 108 "..\..\Views\T_SocCode\EditQuick.cshtml"
     , Tuple.Create(Tuple.Create("", 4260), Tuple.Create<System.Object, System.Int32>(Html.Raw("prevFun('T_SocCode')")
            
            #line default
            #line hidden
, 4260), false)
);

WriteLiteral("><< Prev</button>\r\n            </div>\r\n");

            
            #line 110 "..\..\Views\T_SocCode\EditQuick.cshtml"
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

            
            #line 124 "..\..\Views\T_SocCode\EditQuick.cshtml"
 using (Html.BeginForm("EditQuick","T_SocCode",new {UrlReferrer =Convert.ToString(ViewData["T_SocCodeParentUrl"])}, FormMethod.Post, new { enctype = "multipart/form-data", @id = "frmQEditT_SocCode" }))
{
     Html.ValidationSummary(true);
                Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_SocCode\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                      
	
            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_SocCode\EditQuick.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 129 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                  

            
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

            
            #line 134 "..\..\Views\T_SocCode\EditQuick.cshtml"
                       Write(Html.Hidden("AssociatedEntity", Convert.ToString(ViewData["AssociatedType"])));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 136 "..\..\Views\T_SocCode\EditQuick.cshtml"
				
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_SocCode\EditQuick.cshtml"
                 if(User.CanView("T_SocCode","T_Code"))
{



            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Code\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Code\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<label  >");

            
            #line 142 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                    Write(Html.LabelFor(model => model.T_Code));

            
            #line default
            #line hidden
WriteLiteral("   </label>\r\n                                \r\n\t\t\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 145 "..\..\Views\T_SocCode\EditQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Code,  getHtmlAttributes("T_Code")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 146 "..\..\Views\T_SocCode\EditQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 151 "..\..\Views\T_SocCode\EditQuick.cshtml"

				
					


} else { 
            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_SocCode\EditQuick.cshtml"
    Write(Html.HiddenFor(model => model.T_Code, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                }

            
            #line default
            #line hidden
            
            #line 157 "..\..\Views\T_SocCode\EditQuick.cshtml"
 if(User.CanView("T_SocCode","T_Title"))
{



            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Title\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Title\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<label  >");

            
            #line 163 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                    Write(Html.LabelFor(model => model.T_Title));

            
            #line default
            #line hidden
WriteLiteral("   </label>\r\n                                \r\n\t\t\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 166 "..\..\Views\T_SocCode\EditQuick.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Title,  getHtmlAttributes("T_Title")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 167 "..\..\Views\T_SocCode\EditQuick.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 172 "..\..\Views\T_SocCode\EditQuick.cshtml"

				
					


} else { 
            
            #line default
            #line hidden
            
            #line 177 "..\..\Views\T_SocCode\EditQuick.cshtml"
    Write(Html.HiddenFor(model => model.T_Title, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 177 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                 }

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n\r\n\r\n\t            </div>\r\n        </div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 185 "..\..\Views\T_SocCode\EditQuick.cshtml"
		 
            
            #line default
            #line hidden
            
            #line 185 "..\..\Views\T_SocCode\EditQuick.cshtml"
    Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 185 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                 ;
		 var businessrule1 = User.businessrules.Where(p => p.EntityName == "T_SocCode").ToList();
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

            
            #line 191 "..\..\Views\T_SocCode\EditQuick.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7130), Tuple.Create("\"", 7351)
, Tuple.Create(Tuple.Create("", 7140), Tuple.Create("QuickEditFromGrid(event,true,\'T_SocCode\',\'", 7140), true)
            
            #line 193 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                        , Tuple.Create(Tuple.Create("", 7182), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 7182), false)
, Tuple.Create(Tuple.Create("", 7209), Tuple.Create("\',false,\'", 7209), true)
            
            #line 193 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                                            , Tuple.Create(Tuple.Create("", 7218), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 7218), false)
, Tuple.Create(Tuple.Create("", 7232), Tuple.Create("\',", 7232), true)
            
            #line 193 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                                                            , Tuple.Create(Tuple.Create("", 7234), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 7234), false)
, Tuple.Create(Tuple.Create("", 7254), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 7254), true)
            
            #line 193 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 7280), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 7280), false)
, Tuple.Create(Tuple.Create("", 7299), Tuple.Create("\',\'", 7299), true)
            
            #line 193 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 7302), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 7302), false)
, Tuple.Create(Tuple.Create("", 7325), Tuple.Create("\',\'", 7325), true)
            
            #line 193 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 7328), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 7328), false)
, Tuple.Create(Tuple.Create("", 7348), Tuple.Create("\');", 7348), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"sevranBtn\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7477), Tuple.Create("\"", 7705)
, Tuple.Create(Tuple.Create("", 7487), Tuple.Create("QuickEditFromGrid(event,true,\'T_SocCode\',\'", 7487), true)
            
            #line 194 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                        , Tuple.Create(Tuple.Create("", 7529), Tuple.Create<System.Object, System.Int32>(ViewData["AssociatedType"]
            
            #line default
            #line hidden
, 7529), false)
, Tuple.Create(Tuple.Create("", 7556), Tuple.Create("\',false,\'", 7556), true)
            
            #line 194 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                                                            , Tuple.Create(Tuple.Create("", 7565), Tuple.Create<System.Object, System.Int32>(businessrule1
            
            #line default
            #line hidden
, 7565), false)
, Tuple.Create(Tuple.Create("", 7579), Tuple.Create("\',", 7579), true)
            
            #line 194 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                                                                            , Tuple.Create(Tuple.Create("", 7581), Tuple.Create<System.Object, System.Int32>(businessrule1.Count
            
            #line default
            #line hidden
, 7581), false)
, Tuple.Create(Tuple.Create("", 7601), Tuple.Create(",\'OnEdit\',\'ErrMsg\',false,\'", 7601), true)
            
            #line 194 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 7627), Tuple.Create<System.Object, System.Int32>(lstinlineassocname
            
            #line default
            #line hidden
, 7627), false)
, Tuple.Create(Tuple.Create("", 7646), Tuple.Create("\',\'", 7646), true)
            
            #line 194 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                                                                                                                                                , Tuple.Create(Tuple.Create("", 7649), Tuple.Create<System.Object, System.Int32>(lstinlineassocdispname
            
            #line default
            #line hidden
, 7649), false)
, Tuple.Create(Tuple.Create("", 7672), Tuple.Create("\',\'", 7672), true)
            
            #line 194 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                                                                                                                                                                                                                                          , Tuple.Create(Tuple.Create("", 7675), Tuple.Create<System.Object, System.Int32>(lstinlineentityname
            
            #line default
            #line hidden
, 7675), false)
, Tuple.Create(Tuple.Create("", 7695), Tuple.Create("\',\'True\');", 7695), true)
);

WriteLiteral(" />\r\n");

WriteLiteral("                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"SaveAndContinue\"");

WriteLiteral(" name=\"SaveAndContinue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7823), Tuple.Create("\"", 7884)
            
            #line 195 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                          , Tuple.Create(Tuple.Create("", 7833), Tuple.Create<System.Object, System.Int32>(Html.Raw("SaveAndContinueEdit('T_SocCode',event)")
            
            #line default
            #line hidden
, 7833), false)
);

WriteLiteral(">Save & Next</button>\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

            
            #line 197 "..\..\Views\T_SocCode\EditQuick.cshtml"
  		 }	
}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 7983), Tuple.Create("\"", 8024)
            
            #line 199 "..\..\Views\T_SocCode\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 7989), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/jqueryval")
            
            #line default
            #line hidden
, 7989), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 8067), Tuple.Create("\"", 8106)
            
            #line 200 "..\..\Views\T_SocCode\EditQuick.cshtml"
, Tuple.Create(Tuple.Create("", 8073), Tuple.Create<System.Object, System.Int32>(Url.Content("~/bundles/common3")
            
            #line default
            #line hidden
, 8073), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n<script>\r\n    $(\"input[type=\'submit\']\").click(function (event) {\r\n\t" +
"if (!$(\"#frmQEditT_SocCode\").valid()) return;\r\n\t\r\n        var $this = $(this);\r\n" +
"        $(\'input:hidden[name=\"hdncommand\"]\').val($this.val());\r\n    });\r\n</scrip" +
"t>\r\n");

            
            #line 210 "..\..\Views\T_SocCode\EditQuick.cshtml"
  
var businessrule = User.businessrules.Where(p => p.EntityName == "T_SocCode").ToList();


	


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

				 form = $(""#frmQEditT_SocCode"").serialize();
					 dataurl = """);

            
            #line 231 "..\..\Views\T_SocCode\EditQuick.cshtml"
                           Write(Url.Action("businessruletype", "T_SocCode", new { ruleType = "OnEdit"}));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            ApplyBusinessRuleOnPageLoad(\"");

            
            #line 232 "..\..\Views\T_SocCode\EditQuick.cshtml"
                                    Write(typelist);

            
            #line default
            #line hidden
WriteLiteral("\",dataurl, \"T_SocCode\", false, \"ErrMsg\", form);\r\n\t\t\t//business rules on inline as" +
"sociations\r\n    });\r\n</script>\r\n");

WriteLiteral("<script>\r\n    $(\"form\").submit(function (event) {\r\n\tif (!$(\"#frmQEditT_SocCode\")." +
"valid()) return;\r\n\tdocument.getElementById(\"ErrMsg\").innerHTML = \"\";\r\n          " +
"  var flag = true;\r\n\t\tvar form = $(\"#frmQEditT_SocCode\").serialize();\r\n\t\t\t\t\t});\r" +
"\n</script>\r\n");

            
            #line 244 "..\..\Views\T_SocCode\EditQuick.cshtml"
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
