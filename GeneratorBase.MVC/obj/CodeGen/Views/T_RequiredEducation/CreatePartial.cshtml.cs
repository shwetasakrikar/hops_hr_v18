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

namespace GeneratorBase.MVC.Views.T_RequiredEducation
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_RequiredEducation/CreatePartial.cshtml")]
    public partial class CreatePartial : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_RequiredEducation>
    {
        public CreatePartial()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RequiredEducationIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.T_RequiredEducationIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 8 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RequiredEducationIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.T_RequiredEducationIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                                                                ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 14 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_RequiredEducationIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.T_RequiredEducationIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                                                              ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 20 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
 using (Html.BeginForm("Create", "T_RequiredEducation",new {UrlReferrer = Convert.ToString(ViewData["T_RequiredEducationParentUrl"]), IsDDAdd = ViewBag.IsDDAdd }, FormMethod.Post, new { enctype = "multipart/form-data",id="frmT_RequiredEducation" }))
{
   
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                           ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" />\r\n");

            
            #line 26 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
	
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                                                                                                                                    

            
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

            
            #line 31 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
	 

            
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

            
            #line 40 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"


            
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

            
            #line 47 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
 if(User.CanView("T_RequiredEducation","T_RoleCodeRequiredEducationID"))
	{

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_RoleCodeRequiredEducationID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 51 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                                                                  Write(Html.LabelFor(model => model.T_RoleCodeRequiredEducationID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 54 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                               Write(Html.DropDownList("T_RoleCodeRequiredEducationID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_RoleCode", @dataurl = Url.Action("GetAllValue", "T_RoleCode",new { caller = "T_RoleCodeRequiredEducationID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 55 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
       Write(Html.ValidationMessageFor(model => model.T_RoleCodeRequiredEducationID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 56 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
			
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
             if ( User.CanAdd("T_RoleCode"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn ie8fix\"");

WriteLiteral(" id=\"addT_RoleCode\"");

WriteLiteral("  data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2676), Tuple.Create("\"", 2980)
            
            #line 59 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                          , Tuple.Create(Tuple.Create("", 2686), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Role Code','dvPopup','" + Url.Action("CreateQuick", "T_RoleCode", new { UrlReferrer = Request.Url, HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]), IsAddPop=true }) + "')")
            
            #line default
            #line hidden
, 2686), false)
);

WriteLiteral(">\r\n\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-plus-sign\"");

WriteLiteral("></span>\r\n\t\t\t\t</a>\r\n\t\t\t</div>\r\n");

            
            #line 63 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t                                \r\n                            </div>\r\n\t\t\t\t\t\t\t</" +
"div>\r\n                        </div>\r\n                    </div>\r\n");

            
            #line 69 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
}

            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
  
            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
   if(User.CanView("T_RequiredEducation","T_RequiredEducationSOCCodeID"))
	{

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_RequiredEducationSOCCodeID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 74 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                                                                  Write(Html.LabelFor(model => model.T_RequiredEducationSOCCodeID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 77 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                               Write(Html.DropDownList("T_RequiredEducationSOCCodeID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_SocCode", @dataurl = Url.Action("GetAllValue", "T_SocCode",new { caller = "T_RequiredEducationSOCCodeID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 78 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
       Write(Html.ValidationMessageFor(model => model.T_RequiredEducationSOCCodeID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 79 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
			
            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
             if ( User.CanAdd("T_SocCode"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn ie8fix\"");

WriteLiteral(" id=\"addT_SocCode\"");

WriteLiteral("  data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4212), Tuple.Create("\"", 4514)
            
            #line 82 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                         , Tuple.Create(Tuple.Create("", 4222), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','SOC Code','dvPopup','" + Url.Action("CreateQuick", "T_SocCode", new { UrlReferrer = Request.Url, HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]), IsAddPop=true }) + "')")
            
            #line default
            #line hidden
, 4222), false)
);

WriteLiteral(">\r\n\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-plus-sign\"");

WriteLiteral("></span>\r\n\t\t\t\t</a>\r\n\t\t\t</div>\r\n");

            
            #line 86 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t                                \r\n                            </div>\r\n\t\t\t\t\t\t\t</" +
"div>\r\n                        </div>\r\n                    </div>\r\n");

            
            #line 92 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("  ");

            
            #line 93 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
   if(User.CanView("T_RequiredEducation","T_RequiredEducationEducationLevelID"))
	{

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_RequiredEducationEducationLevelID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 97 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                                                                  Write(Html.LabelFor(model => model.T_RequiredEducationEducationLevelID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 100 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                               Write(Html.DropDownList("T_RequiredEducationEducationLevelID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_EducationLevel", @dataurl = Url.Action("GetAllValue", "T_EducationLevel",new { caller = "T_RequiredEducationEducationLevelID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 101 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
       Write(Html.ValidationMessageFor(model => model.T_RequiredEducationEducationLevelID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 102 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
			
            
            #line default
            #line hidden
            
            #line 102 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
             if ( User.CanAdd("T_EducationLevel"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn ie8fix\"");

WriteLiteral(" id=\"addT_EducationLevel\"");

WriteLiteral("  data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5816), Tuple.Create("\"", 6132)
            
            #line 105 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                                , Tuple.Create(Tuple.Create("", 5826), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Education Level','dvPopup','" + Url.Action("CreateQuick", "T_EducationLevel", new { UrlReferrer = Request.Url, HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]), IsAddPop=true }) + "')")
            
            #line default
            #line hidden
, 5826), false)
);

WriteLiteral(">\r\n\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-plus-sign\"");

WriteLiteral("></span>\r\n\t\t\t\t</a>\r\n\t\t\t</div>\r\n");

            
            #line 109 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t                                \r\n                            </div>\r\n\t\t\t\t\t\t\t</" +
"div>\r\n                        </div>\r\n                    </div>\r\n");

            
            #line 115 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("  \t\t\t\t\t\t");

            
            #line 116 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                         if(User.CanView("T_RequiredEducation","T_Description"))
								{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"Education Details\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 120 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                                    ");

            
            #line 122 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                               Write(Html.TextAreaFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 123 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 127 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n                        </div>\r\n                    </div>\r\n      " +
"          </div>\r\n        </div>\r\n");

WriteLiteral("\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7242), Tuple.Create("\"", 7305)
, Tuple.Create(Tuple.Create("", 7252), Tuple.Create("goBack(\'", 7252), true)
            
            #line 133 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
, Tuple.Create(Tuple.Create("", 7260), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_RequiredEducation")
            
            #line default
            #line hidden
, 7260), false)
, Tuple.Create(Tuple.Create("", 7302), Tuple.Create("\');", 7302), true)
);

WriteLiteral(" alt=\"Cancel\"");

WriteLiteral(" title=\"Cancel\"");

WriteLiteral(">Cancel</a>\r\n");

            
            #line 134 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
          
            
            #line default
            #line hidden
            
            #line 134 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                                                                                                                                                                            

            
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

            
            #line 136 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
    if (ViewBag.IsDDAdd == null && User.CanEdit("T_RequiredEducation"))
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

            
            #line 139 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
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

            
            #line 142 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
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

            
            #line 163 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
  
		var businessrule = User.businessrules.Where(p => p.EntityName == "T_RequiredEducation").ToList();
		
if ((businessrule != null && businessrule.Count > 0) )
    {

            
            #line default
            #line hidden
WriteLiteral(@"        <script>
            $(""form"").submit(function (event) {
			if (!$(""#frmT_RequiredEducation"").valid()) return;
			var flag = true;
							document.getElementById(""ErrMsg"").innerHTML = """";
                var dataurl = """";
                var form = """";
                var inlinecount = ""0"";
                //var form = $(this).serialize();
 form = $(""#frmT_RequiredEducation"").serialize();
  
                dataurl = """);

            
            #line 179 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
                      Write(Url.Action("businessruletype", "T_RequiredEducation", new { ruleType = "OnCreate"}));

            
            #line default
            #line hidden
WriteLiteral(@""";
                flag = ApplyBusinessRuleOnSubmit(dataurl, ""T_RequiredEducation"", false, ""ErrMsg"", form);
				//business rules on inline associations
				if (flag) {
				                    $('input:hidden[name=""hdncommand""]').val($(document.activeElement).val());

					 $(""#frmT_RequiredEducation"").find(':input').removeAttr('disabled');
                }
				return flag;
			 });	
        </script>
");

            
            #line 190 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral(@"	<script>
            $(""input[type='submit']"").click(function (event) {
			if (!$(""#frmT_RequiredEducation"").valid()) return;
                var $this = $(this);
                $('input:hidden[name=""hdncommand""]').val($this.val());
            });
	</script>
");

            
            #line 200 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
           
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n<script");

WriteLiteral(" type=\'text/javascript\'");

WriteLiteral(@">
    $(document).ready(function () {
        try {
		 focusOnControl('frmT_RequiredEducation');
        }
        catch (ex) { }
    });
</script>
<script>
    $(document).ready(function () {
        try {
            var hostingEntityName = """";
            if ('");

            
            #line 217 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\'.length > 0) {\r\n                hostingEntityName = \'");

            
            #line 218 "..\..\Views\T_RequiredEducation\CreatePartial.cshtml"
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
