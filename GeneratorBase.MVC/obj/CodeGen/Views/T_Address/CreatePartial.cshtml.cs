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

namespace GeneratorBase.MVC.Views.T_Address
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Address/CreatePartial.cshtml")]
    public partial class CreatePartial : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Address>
    {
        public CreatePartial()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Address\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_AddressIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\T_Address\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.T_AddressIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 8 "..\..\Views\T_Address\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_AddressIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_Address\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.T_AddressIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                      ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 14 "..\..\Views\T_Address\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_AddressIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\T_Address\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.T_AddressIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 20 "..\..\Views\T_Address\CreatePartial.cshtml"
 using (Html.BeginForm("Create", "T_Address",new {UrlReferrer = Convert.ToString(ViewData["T_AddressParentUrl"]), IsDDAdd = ViewBag.IsDDAdd }, FormMethod.Post, new { enctype = "multipart/form-data",id="frmT_Address" }))
{
   
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\T_Address\CreatePartial.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\T_Address\CreatePartial.cshtml"
                           ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" />\r\n");

            
            #line 26 "..\..\Views\T_Address\CreatePartial.cshtml"
	
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                                                                                                    

            
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

            
            #line 31 "..\..\Views\T_Address\CreatePartial.cshtml"
	 

            
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

            
            #line 40 "..\..\Views\T_Address\CreatePartial.cshtml"


            
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

            
            #line 47 "..\..\Views\T_Address\CreatePartial.cshtml"
			 
            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\T_Address\CreatePartial.cshtml"
              if(User.CanView("T_Address","T_AddressLine1"))
								{

            
            #line default
            #line hidden
WriteLiteral("     <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_AddressLine1\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"AddressLine1\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 51 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_AddressLine1));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 54 "..\..\Views\T_Address\CreatePartial.cshtml"
                               Write(Html.TextBoxFor(model => model.T_AddressLine1, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 55 "..\..\Views\T_Address\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_AddressLine1));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 59 "..\..\Views\T_Address\CreatePartial.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 62 "..\..\Views\T_Address\CreatePartial.cshtml"
			 
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\T_Address\CreatePartial.cshtml"
              if(User.CanView("T_Address","T_AddressLine2"))
								{

            
            #line default
            #line hidden
WriteLiteral("     <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_AddressLine2\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"AddressLine2\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 66 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_AddressLine2));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 69 "..\..\Views\T_Address\CreatePartial.cshtml"
                               Write(Html.TextBoxFor(model => model.T_AddressLine2, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 70 "..\..\Views\T_Address\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_AddressLine2));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 74 "..\..\Views\T_Address\CreatePartial.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 77 "..\..\Views\T_Address\CreatePartial.cshtml"
			 
            
            #line default
            #line hidden
            
            #line 77 "..\..\Views\T_Address\CreatePartial.cshtml"
              if(User.CanView("T_Address","T_ZipCode"))
								{

            
            #line default
            #line hidden
WriteLiteral("     <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_ZipCode\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"ZipCode\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 81 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.T_ZipCode));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 84 "..\..\Views\T_Address\CreatePartial.cshtml"
                               Write(Html.TextBoxFor(model => model.T_ZipCode, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 85 "..\..\Views\T_Address\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_ZipCode));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 89 "..\..\Views\T_Address\CreatePartial.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 92 "..\..\Views\T_Address\CreatePartial.cshtml"
 if(User.CanView("T_Address","T_AddressCountryID"))
	{

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_AddressCountryID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 96 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                                  Write(Html.LabelFor(model => model.T_AddressCountryID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 99 "..\..\Views\T_Address\CreatePartial.cshtml"
                               Write(Html.DropDownList("T_AddressCountryID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_Country", @dataurl = Url.Action("GetAllValue", "T_Country",new { caller = "T_AddressCountryID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 100 "..\..\Views\T_Address\CreatePartial.cshtml"
       Write(Html.ValidationMessageFor(model => model.T_AddressCountryID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 101 "..\..\Views\T_Address\CreatePartial.cshtml"
			
            
            #line default
            #line hidden
            
            #line 101 "..\..\Views\T_Address\CreatePartial.cshtml"
             if ( User.CanAdd("T_Country"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn ie8fix\"");

WriteLiteral(" id=\"addT_Country\"");

WriteLiteral("  data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4632), Tuple.Create("\"", 4941)
            
            #line 104 "..\..\Views\T_Address\CreatePartial.cshtml"
                         , Tuple.Create(Tuple.Create("", 4642), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Address Country','dvPopup','" + Url.Action("CreateQuick", "T_Country", new { UrlReferrer = Request.Url, HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]), IsAddPop=true }) + "')")
            
            #line default
            #line hidden
, 4642), false)
);

WriteLiteral(">\r\n\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-plus-sign\"");

WriteLiteral("></span>\r\n\t\t\t\t</a>\r\n\t\t\t</div>\r\n");

            
            #line 108 "..\..\Views\T_Address\CreatePartial.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t                                \r\n                            </div>\r\n\t\t\t\t\t\t\t</" +
"div>\r\n                        </div>\r\n                    </div>\r\n");

            
            #line 114 "..\..\Views\T_Address\CreatePartial.cshtml"
}

            
            #line default
            #line hidden
            
            #line 115 "..\..\Views\T_Address\CreatePartial.cshtml"
  
            
            #line default
            #line hidden
            
            #line 115 "..\..\Views\T_Address\CreatePartial.cshtml"
   if(User.CanView("T_Address","T_AddressStateID"))
	{

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_AddressStateID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 119 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                                  Write(Html.LabelFor(model => model.T_AddressStateID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 122 "..\..\Views\T_Address\CreatePartial.cshtml"
                               Write(Html.DropDownList("T_AddressStateID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_State", @dataurl = Url.Action("GetAllValue", "T_State",new { caller = "T_AddressStateID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 123 "..\..\Views\T_Address\CreatePartial.cshtml"
       Write(Html.ValidationMessageFor(model => model.T_AddressStateID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 124 "..\..\Views\T_Address\CreatePartial.cshtml"
			
            
            #line default
            #line hidden
            
            #line 124 "..\..\Views\T_Address\CreatePartial.cshtml"
             if ( User.CanAdd("T_State"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn ie8fix\"");

WriteLiteral(" id=\"addT_State\"");

WriteLiteral("  data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6083), Tuple.Create("\"", 6388)
            
            #line 127 "..\..\Views\T_Address\CreatePartial.cshtml"
                       , Tuple.Create(Tuple.Create("", 6093), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Address State','dvPopup','" + Url.Action("CreateQuick", "T_State", new { UrlReferrer = Request.Url, HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]), IsAddPop=true }) + "')")
            
            #line default
            #line hidden
, 6093), false)
);

WriteLiteral(">\r\n\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-plus-sign\"");

WriteLiteral("></span>\r\n\t\t\t\t</a>\r\n\t\t\t</div>\r\n");

            
            #line 131 "..\..\Views\T_Address\CreatePartial.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t                                \r\n                            </div>\r\n\t\t\t\t\t\t\t</" +
"div>\r\n                        </div>\r\n                    </div>\r\n");

            
            #line 137 "..\..\Views\T_Address\CreatePartial.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("  ");

            
            #line 138 "..\..\Views\T_Address\CreatePartial.cshtml"
   if(User.CanView("T_Address","T_AddressCityID"))
	{

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_AddressCityID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 142 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                                  Write(Html.LabelFor(model => model.T_AddressCityID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 145 "..\..\Views\T_Address\CreatePartial.cshtml"
                               Write(Html.DropDownList("T_AddressCityID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_City", @dataurl = Url.Action("GetAllValue", "T_City",new { caller = "T_AddressCityID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 146 "..\..\Views\T_Address\CreatePartial.cshtml"
       Write(Html.ValidationMessageFor(model => model.T_AddressCityID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 147 "..\..\Views\T_Address\CreatePartial.cshtml"
			
            
            #line default
            #line hidden
            
            #line 147 "..\..\Views\T_Address\CreatePartial.cshtml"
             if ( User.CanAdd("T_City"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn ie8fix\"");

WriteLiteral(" id=\"addT_City\"");

WriteLiteral("  data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7520), Tuple.Create("\"", 7823)
            
            #line 150 "..\..\Views\T_Address\CreatePartial.cshtml"
                      , Tuple.Create(Tuple.Create("", 7530), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Address City','dvPopup','" + Url.Action("CreateQuick", "T_City", new { UrlReferrer = Request.Url, HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]), IsAddPop=true }) + "')")
            
            #line default
            #line hidden
, 7530), false)
);

WriteLiteral(">\r\n\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-plus-sign\"");

WriteLiteral("></span>\r\n\t\t\t\t</a>\r\n\t\t\t</div>\r\n");

            
            #line 154 "..\..\Views\T_Address\CreatePartial.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t                                \r\n                            </div>\r\n\t\t\t\t\t\t\t</" +
"div>\r\n                        </div>\r\n                    </div>\r\n");

            
            #line 160 "..\..\Views\T_Address\CreatePartial.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("         </div>\r\n                        </div>\r\n                    </div>\r\n    " +
"            </div>\r\n        </div>\r\n");

WriteLiteral("\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8214), Tuple.Create("\"", 8267)
, Tuple.Create(Tuple.Create("", 8224), Tuple.Create("goBack(\'", 8224), true)
            
            #line 166 "..\..\Views\T_Address\CreatePartial.cshtml"
, Tuple.Create(Tuple.Create("", 8232), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_Address")
            
            #line default
            #line hidden
, 8232), false)
, Tuple.Create(Tuple.Create("", 8264), Tuple.Create("\');", 8264), true)
);

WriteLiteral(" alt=\"Cancel\"");

WriteLiteral(" title=\"Cancel\"");

WriteLiteral(">Cancel</a>\r\n");

            
            #line 167 "..\..\Views\T_Address\CreatePartial.cshtml"
          
            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\T_Address\CreatePartial.cshtml"
                                                                                                                                                                  

            
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

            
            #line 169 "..\..\Views\T_Address\CreatePartial.cshtml"
    if (ViewBag.IsDDAdd == null && User.CanEdit("T_Address"))
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

            
            #line 172 "..\..\Views\T_Address\CreatePartial.cshtml"
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

            
            #line 175 "..\..\Views\T_Address\CreatePartial.cshtml"
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

            
            #line 196 "..\..\Views\T_Address\CreatePartial.cshtml"
  
		var businessrule = User.businessrules.Where(p => p.EntityName == "T_Address").ToList();
		
if ((businessrule != null && businessrule.Count > 0) )
    {

            
            #line default
            #line hidden
WriteLiteral(@"        <script>
            $(""form"").submit(function (event) {
			if (!$(""#frmT_Address"").valid()) return;
			var flag = true;
							document.getElementById(""ErrMsg"").innerHTML = """";
                var dataurl = """";
                var form = """";
                var inlinecount = ""0"";
                //var form = $(this).serialize();
 form = $(""#frmT_Address"").serialize();
  
                dataurl = """);

            
            #line 212 "..\..\Views\T_Address\CreatePartial.cshtml"
                      Write(Url.Action("businessruletype", "T_Address", new { ruleType = "OnCreate"}));

            
            #line default
            #line hidden
WriteLiteral(@""";
                flag = ApplyBusinessRuleOnSubmit(dataurl, ""T_Address"", false, ""ErrMsg"", form);
				//business rules on inline associations
				if (flag) {
				                    $('input:hidden[name=""hdncommand""]').val($(document.activeElement).val());

					 $(""#frmT_Address"").find(':input').removeAttr('disabled');
                }
				return flag;
			 });	
        </script>
");

            
            #line 223 "..\..\Views\T_Address\CreatePartial.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral(@"	<script>
            $(""input[type='submit']"").click(function (event) {
			if (!$(""#frmT_Address"").valid()) return;
                var $this = $(this);
                $('input:hidden[name=""hdncommand""]').val($this.val());
            });
	</script>
");

            
            #line 233 "..\..\Views\T_Address\CreatePartial.cshtml"
           
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n<script");

WriteLiteral(" type=\'text/javascript\'");

WriteLiteral(@">
    $(document).ready(function () {
        try {
		 focusOnControl('frmT_Address');
        }
        catch (ex) { }
    });
</script>
<script>
    $(document).ready(function () {
        try {
            var hostingEntityName = """";
            if ('");

            
            #line 250 "..\..\Views\T_Address\CreatePartial.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\'.length > 0) {\r\n                hostingEntityName = \'");

            
            #line 251 "..\..\Views\T_Address\CreatePartial.cshtml"
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