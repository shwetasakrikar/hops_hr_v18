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

namespace GeneratorBase.MVC.Views.T_ReasonforHire
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ReasonforHire/CreatePartial.cshtml")]
    public partial class CreatePartial : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_ReasonforHire>
    {
        public CreatePartial()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ReasonforHireIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.T_ReasonforHireIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                                                      ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 8 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ReasonforHireIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.T_ReasonforHireIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                                                            ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 14 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_ReasonforHireIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.T_ReasonforHireIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 20 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
 using (Html.BeginForm("Create", "T_ReasonforHire",new {UrlReferrer = Convert.ToString(ViewData["T_ReasonforHireParentUrl"]), IsDDAdd = ViewBag.IsDDAdd }, FormMethod.Post, new { enctype = "multipart/form-data",id="frmT_ReasonforHire" }))
{
   
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                           ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" />\r\n");

            
            #line 26 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
	
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                                                                                                                                    

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" id=\"errorContainer\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"errorsMsg\"");

WriteLiteral("></div>\r\n        <div");

WriteLiteral(" id=\"errors\"");

WriteLiteral("></div>\r\n    </div>\r\n");

            
            #line 31 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
	 

            
            #line default
            #line hidden
WriteLiteral("\t <div");

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

WriteLiteral("\t<div");

WriteLiteral(" id=\"divDisplayCodeFragment\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n\t</div>\r\n");

            
            #line 40 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"


            
            #line default
            #line hidden
WriteLiteral("\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"AppForm\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"\"");

WriteLiteral(">\r\n               \t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t       \r\n");

            
            #line 47 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
			 
            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
              if(User.CanView("T_ReasonforHire","T_Name"))
								{

            
            #line default
            #line hidden
WriteLiteral("     <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Name\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 51 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 54 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 55 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 59 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 62 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
						
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                         if(User.CanView("T_ReasonforHire","T_Description"))
								{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Description\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 66 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 68 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 69 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 73 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n                        </div>\r\n                    </div>\r\n      " +
"          </div>\r\n        </div>\r\n");

WriteLiteral("\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3212), Tuple.Create("\"", 3271)
, Tuple.Create(Tuple.Create("", 3222), Tuple.Create("goBack(\'", 3222), true)
            
            #line 79 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
, Tuple.Create(Tuple.Create("", 3230), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_ReasonforHire")
            
            #line default
            #line hidden
, 3230), false)
, Tuple.Create(Tuple.Create("", 3268), Tuple.Create("\');", 3268), true)
);

WriteLiteral(" alt=\"Cancel\"");

WriteLiteral(" title=\"Cancel\"");

WriteLiteral(">Cancel</a>\r\n");

            
            #line 80 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
          
            
            #line default
            #line hidden
            
            #line 80 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                                                                                                                                                                        

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" alt=\"Create\"");

WriteLiteral(" title=\"Create\"");

WriteLiteral("/>\r\n");

            
            #line 82 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
    if (ViewBag.IsDDAdd == null && User.CanEdit("T_ReasonforHire"))
    {

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" alt=\"Create & Continue\"");

WriteLiteral(" title=\"Create & Continue\"");

WriteLiteral("/>\r\n");

            
            #line 85 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("\t <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

WriteLiteral("\t<br/>");

WriteLiteral("<br/>\r\n");

            
            #line 88 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral(@"	<script>
	    $(function () {
        var userAgent = navigator.userAgent.toLowerCase();
        // Figure out what browser is being used
        var browser = {
            version: (userAgent.match(/.+(?:rv|it|ra|ie)[\/: ]([\d.]+)/) || [])[1],
            safari: /webkit/.test(userAgent),
            opera: /opera/.test(userAgent),
            msie: /msie/.test(userAgent) && !/opera/.test(userAgent),
            mozilla: /mozilla/.test(userAgent) && !/(compatible|webkit)/.test(userAgent)
        };
        if (!browser.msie) {
            $('form').areYouSure();
        }
        else if (browser.version > 8.0) {
            $('form').areYouSure();
        }
    });
</script>
	
");

            
            #line 109 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
  
		var businessrule = User.businessrules.Where(p => p.EntityName == "T_ReasonforHire").ToList();
		
if ((businessrule != null && businessrule.Count > 0) )
    {

            
            #line default
            #line hidden
WriteLiteral(@"        <script>
            $(""form"").submit(function (event) {
			if (!$(""#frmT_ReasonforHire"").valid()) return;
			var flag = true;
							document.getElementById(""ErrMsg"").innerHTML = """";
                var dataurl = """";
                var form = """";
                var inlinecount = ""0"";
                //var form = $(this).serialize();
 form = $(""#frmT_ReasonforHire"").serialize();
  
                dataurl = """);

            
            #line 125 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                      Write(Url.Action("businessruletype", "T_ReasonforHire", new { ruleType = "OnCreate"}));

            
            #line default
            #line hidden
WriteLiteral(@""";
                flag = ApplyBusinessRuleOnSubmit(dataurl, ""T_ReasonforHire"", false, ""ErrMsg"", form);
				//business rules on inline associations
				if (flag) {
				                    $('input:hidden[name=""hdncommand""]').val($(document.activeElement).val());

					 $(""#frmT_ReasonforHire"").find(':input').removeAttr('disabled');
                }
				return flag;
			 });	
        </script>
");

            
            #line 136 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral(@"	<script>
            $(""input[type='submit']"").click(function (event) {
			if (!$(""#frmT_ReasonforHire"").valid()) return;
                var $this = $(this);
                $('input:hidden[name=""hdncommand""]').val($this.val());
            });
	</script>
");

            
            #line 146 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
           
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n<script");

WriteLiteral(" type=\'text/javascript\'");

WriteLiteral(@">
    $(document).ready(function () {
        try {
		 focusOnControl('frmT_ReasonforHire');
        }
        catch (ex) { }
    });
</script>
<script>
    $(document).ready(function () {
        try {
            var hostingEntityName = """";
            if ('");

            
            #line 163 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\'.length > 0) {\r\n                hostingEntityName = \'");

            
            #line 164 "..\..\Views\T_ReasonforHire\CreatePartial.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n                 $(\'#\' + hostingEntityName + \'ID\').attr(\"lock\",\"true\");\r\n\t\t\t\t" +
"  $(\'#\' + hostingEntityName + \'ID\').trigger(\"change\");\r\n            }\r\n\t\t\t\r\n    " +
"    }\r\n        catch (ex) { }\r\n\t\t});\r\n</script>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
