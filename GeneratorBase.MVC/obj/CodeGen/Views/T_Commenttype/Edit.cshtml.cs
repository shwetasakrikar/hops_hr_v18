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

namespace GeneratorBase.MVC.Views.T_Commenttype
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
    
    #line 2 "..\..\Views\T_Commenttype\Edit.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Commenttype/Edit.cshtml")]
    public partial class Edit : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Commenttype>
    {
        
        #line 10 "..\..\Views\T_Commenttype\Edit.cshtml"
            
    object getHtmlAttributes(string Property)
    {
        if (User.CanEdit("T_Commenttype", Property))
        {
            return new { @class = "form-control" };
        } return new { @class = "form-control", @readonly = "readonly" };
    }

        #line default
        #line hidden
        
        public Edit()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_Commenttype\Edit.cshtml"
  
    ViewBag.Title = "Edit Comment Type";
	var EditPermission = User.CanEditItem("T_Commenttype", Model, User);
	var DeletePermission = User.CanDeleteItem("T_Commenttype", Model, User);
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Commenttype");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Comment Type";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var hos" +
"tingEntityName = \"\";\r\n             if (\'");

            
            #line 23 "..\..\Views\T_Commenttype\Edit.cshtml"
             Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\'.length > 0) {\r\n                hostingEntityName = \'");

            
            #line 24 "..\..\Views\T_Commenttype\Edit.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral(@"';
				$('#' + hostingEntityName + 'ID').attr(""lock"",""true"");
				// $('#' + hostingEntityName + 'ID').trigger(""change"");
				  $(""input[type='radio'][name='"" + hostingEntityName + ""ID']"").each(function () {
                    if (!this.checked)
                        this.closest(""li"").style.display = ""none"";
                });
            }
			if ($.cookie('");

            
            #line 32 "..\..\Views\T_Commenttype\Edit.cshtml"
                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 33 "..\..\Views\T_Commenttype\Edit.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t}\r\n\t\t\t \r\n        }\r\n        catch (ex) { }\r" +
"\n    });\r\n</script>\r\n");

            
            #line 40 "..\..\Views\T_Commenttype\Edit.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CommenttypeIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Commenttype\Edit.cshtml"
   Write(Html.Raw(ViewBag.T_CommenttypeIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                    ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\T_Commenttype\Edit.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CommenttypeIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Commenttype\Edit.cshtml"
   Write(Html.Raw(ViewBag.T_CommenttypeIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                          ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 53 "..\..\Views\T_Commenttype\Edit.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_CommenttypeIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Commenttype\Edit.cshtml"
   Write(Html.Raw(ViewBag.T_CommenttypeIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                        ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(" >\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-edit text-primary\"");

WriteLiteral("></i> ");

            
            #line 62 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                             Write(EntityDisplayName);

            
            #line default
            #line hidden
WriteLiteral("  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span>Edit</span>\r\n\r\n\t\t\t   <div");

WriteLiteral(" class=\"btn-group pull-right\"");

WriteLiteral(" style=\"margin-top:3px;\"");

WriteLiteral(">\r\n\t\t\t  \r\n\r\n\r\n            <a");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" class=\"btn btn-xs dropdown-toggle\"");

WriteLiteral(" alt=\"Action\"");

WriteLiteral(" title=\"Action\"");

WriteLiteral(">\r\n                Action\r\n                <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral(" style=\"margin-bottom:2px\"");

WriteLiteral(">    </span>\r\n            </a>\r\n\t\t\t<ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">\r\n\t\t\t\r\n\t\t\t\t<li>\r\n");

            
            #line 75 "..\..\Views\T_Commenttype\Edit.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\T_Commenttype\Edit.cshtml"
                     if (EditPermission)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2774), Tuple.Create("\"", 3055)
            
            #line 77 "..\..\Views\T_Commenttype\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2781), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_Commenttype", new { id = Model.Id,  UrlReferrer = Request.UrlReferrer, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 2781), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 78 "..\..\Views\T_Commenttype\Edit.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 81 "..\..\Views\T_Commenttype\Edit.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 81 "..\..\Views\T_Commenttype\Edit.cshtml"
                     if (EditPermission && User.CanDelete("T_Commenttype"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 3304), Tuple.Create("\"", 3587)
            
            #line 83 "..\..\Views\T_Commenttype\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3311), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_Commenttype", new {UrlReferrer = Request.UrlReferrer, id = Model.Id, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 3311), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 84 "..\..\Views\T_Commenttype\Edit.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t\t\t</ul>\r\n\t\t</div>\r\n\r\n        </h1>\r\n\r\n     <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(" style=\"padding:0px 5px 15px 0px\"");

WriteLiteral(">\r\n\t  <span");

WriteLiteral(" id=\"HostingEntityDisplayValue\"");

WriteLiteral(" class=\"EntityDisplayName\"");

WriteAttribute("title", Tuple.Create(" title=\"", 3865), Tuple.Create("\"", 3918)
            
            #line 92 "..\..\Views\T_Commenttype\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3873), Tuple.Create<System.Object, System.Int32>(Html.DisplayFor(model => model.DisplayValue)
            
            #line default
            #line hidden
, 3873), false)
);

WriteLiteral(">");

            
            #line 92 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                                                                                      Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

            
            #line 93 "..\..\Views\T_Commenttype\Edit.cshtml"
			
            
            #line default
            #line hidden
            
            #line 93 "..\..\Views\T_Commenttype\Edit.cshtml"
             if (EditPermission)
			{	

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(" style=\"margin-top:-3px\"");

WriteLiteral(">\r\n\t\t\t\t\t<button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"nextEdit\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4128), Tuple.Create("\"", 4201)
            
            #line 96 "..\..\Views\T_Commenttype\Edit.cshtml"
             , Tuple.Create(Tuple.Create("", 4138), Tuple.Create<System.Object, System.Int32>(Html.Raw("nextFunEdit('T_Commenttype',event,'hdnNextPrevId')")
            
            #line default
            #line hidden
, 4138), false)
);

WriteLiteral(" alt=\"Next\"");

WriteLiteral(" title=\"Next\"");

WriteLiteral(">Next >></button>\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 97 "..\..\Views\T_Commenttype\Edit.cshtml"
               Write(Html.DropDownList("EntityT_CommenttypeDisplayValueEdit", null, null, new { @onchange = "FillDisplayValueEditPage('T_Commenttype','frmT_Commenttype','" + Model.Id + "',event)", @class = "pull-right", @Style = "height: 22px;width: 170px; font-size:12px; color:#333;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t<button");

WriteLiteral(" class=\"btn btn-default btn-xs pull-right\"");

WriteLiteral(" id=\"prevEdit\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4588), Tuple.Create("\"", 4661)
            
            #line 98 "..\..\Views\T_Commenttype\Edit.cshtml"
             , Tuple.Create(Tuple.Create("", 4598), Tuple.Create<System.Object, System.Int32>(Html.Raw("prevFunEdit('T_Commenttype',event,'hdnNextPrevId')")
            
            #line default
            #line hidden
, 4598), false)
);

WriteLiteral(" alt=\"Prev\"");

WriteLiteral(" title=\"Prev\"");

WriteLiteral("><< Prev</button>\r\n\t\t\t\t</div>\r\n");

            
            #line 100 "..\..\Views\T_Commenttype\Edit.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t </h2>\r\n\t\t\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r\n</div>\r\n<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" />\r\n<div");

WriteLiteral(" id=\"errorContainerEdit\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"errorsMsgEdit\"");

WriteLiteral("></div>\r\n            <div");

WriteLiteral(" id=\"errorsEdit\"");

WriteLiteral("></div>\r\n        </div>\r\n\r\n<div");

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

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"divDisplayCodeFragment\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n</div>\r\n <div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5411), Tuple.Create("\"", 5476)
, Tuple.Create(Tuple.Create("", 5421), Tuple.Create("ClearTabCookie(\'", 5421), true)
            
            #line 124 "..\..\Views\T_Commenttype\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 5437), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 5437), false)
            
            #line 124 "..\..\Views\T_Commenttype\Edit.cshtml"
               , Tuple.Create(Tuple.Create("", 5464), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5464), false)
, Tuple.Create(Tuple.Create("", 5473), Tuple.Create("\');", 5473), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" alt=\"Details\"");

WriteLiteral(" title=\"Details\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 125 "..\..\Views\T_Commenttype\Edit.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5611), Tuple.Create("\"", 5901)
, Tuple.Create(Tuple.Create("", 5621), Tuple.Create("LoadTab(\'JournalEntryToT_CommenttypeRelation\',\'", 5621), true)
            
            #line 125 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                  , Tuple.Create(Tuple.Create("", 5668), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 5668), false)
            
            #line 125 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                                             , Tuple.Create(Tuple.Create("", 5695), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5695), false)
, Tuple.Create(Tuple.Create("", 5704), Tuple.Create("\',\'", 5704), true)
            
            #line 125 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                                                         , Tuple.Create(Tuple.Create("", 5707), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_Commenttype", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 5707), false)
, Tuple.Create(Tuple.Create("", 5899), Tuple.Create("\')", 5899), true)
);

WriteLiteral(" href=\"#JournalEntryToT_CommenttypeRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(" alt=\"Comment Type Journal\"");

WriteLiteral(" title=\"Comment Type Journal\"");

WriteLiteral(">\r\n\t\t Comment Type Journal\r\n\t\t </a></li>\r\n\r\n    </ul>\r\n\t\t<div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"Details\"");

WriteLiteral(">\r\n");

            
            #line 132 "..\..\Views\T_Commenttype\Edit.cshtml"
 using (Html.BeginForm("Edit","T_Commenttype",new {UrlReferrer =Convert.ToString(ViewData["T_CommenttypeParentUrl"])}, FormMethod.Post, new { enctype = "multipart/form-data",@id="frmT_Commenttype" }))
{
     Html.ValidationSummary(true);
                Html.EnableClientValidation();
    
            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_Commenttype\Edit.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 136 "..\..\Views\T_Commenttype\Edit.cshtml"
                                      
	
            
            #line default
            #line hidden
            
            #line 137 "..\..\Views\T_Commenttype\Edit.cshtml"
Write(Html.HiddenFor(model => model.ConcurrencyKey));

            
            #line default
            #line hidden
            
            #line 137 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                  

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(" style=\"padding:0px; margin:0px;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 143 "..\..\Views\T_Commenttype\Edit.cshtml"
				
            
            #line default
            #line hidden
            
            #line 143 "..\..\Views\T_Commenttype\Edit.cshtml"
                 if(User.CanView("T_Commenttype","T_Name"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Name\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 147 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                                       Write(Html.LabelFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("  <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span> </label>\r\n                                <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 150 "..\..\Views\T_Commenttype\Edit.cshtml"
                               Write(Html.TextBoxFor(model => model.T_Name,  getHtmlAttributes("T_Name")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 151 "..\..\Views\T_Commenttype\Edit.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t</div>\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 155 "..\..\Views\T_Commenttype\Edit.cshtml"
										
} else { 
            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_Commenttype\Edit.cshtml"
    Write(Html.HiddenFor(model => model.T_Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                                                }

            
            #line default
            #line hidden
            
            #line 157 "..\..\Views\T_Commenttype\Edit.cshtml"
 if(User.CanView("T_Commenttype","T_Description"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_Description\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 161 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                                       Write(Html.LabelFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n                                <div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t");

            
            #line 163 "..\..\Views\T_Commenttype\Edit.cshtml"
                           Write(Html.TextAreaFor(model => model.T_Description, getHtmlAttributes("T_Description")));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 164 "..\..\Views\T_Commenttype\Edit.cshtml"
                               Write(Html.ValidationMessageFor(model => model.T_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t</div>\r\n                             </div>\r\n\t\t\t\t\t\t</div>\r\n");

            
            #line 168 "..\..\Views\T_Commenttype\Edit.cshtml"
} else { 
            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\T_Commenttype\Edit.cshtml"
    Write(Html.HiddenFor(model => model.T_Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 168 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                                                       }

            
            #line default
            #line hidden
WriteLiteral("       </div>\r\n            </div>\r\n        </div>\r\n\t\t</div>\r\n");

            
            #line 173 "..\..\Views\T_Commenttype\Edit.cshtml"
		 
            
            #line default
            #line hidden
            
            #line 173 "..\..\Views\T_Commenttype\Edit.cshtml"
    Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 173 "..\..\Views\T_Commenttype\Edit.cshtml"
                                 ;

            
            #line default
            #line hidden
WriteLiteral("\t\t <a");

WriteLiteral(" class=\"btn btn-default btn-sm pull-left formbuttonfix\"");

WriteAttribute("Onclick", Tuple.Create(" Onclick=\"", 8294), Tuple.Create("\"", 8351)
, Tuple.Create(Tuple.Create("", 8304), Tuple.Create("goBack(\'", 8304), true)
            
            #line 174 "..\..\Views\T_Commenttype\Edit.cshtml"
    , Tuple.Create(Tuple.Create("", 8312), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_Commenttype")
            
            #line default
            #line hidden
, 8312), false)
, Tuple.Create(Tuple.Create("", 8348), Tuple.Create("\');", 8348), true)
);

WriteLiteral(" alt=\"Cancel\"");

WriteLiteral(" title=\"Cancel\"");

WriteLiteral(">Cancel</a>\r\n");

            
            #line 175 "..\..\Views\T_Commenttype\Edit.cshtml"
		 
            
            #line default
            #line hidden
            
            #line 175 "..\..\Views\T_Commenttype\Edit.cshtml"
                                                                                                                                                                                                                             
		 if (EditPermission)
         {

            
            #line default
            #line hidden
WriteLiteral(" \t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-primary btn-sm pull-left formbuttonfix\"");

WriteLiteral("  alt=\"Save\"");

WriteLiteral(" title=\"Save\"");

WriteLiteral("/>\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"sevranBtnEdit\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"SaveNextPrev\"");

WriteLiteral(" alt=\"SaveNextPrev\"");

WriteLiteral(" title=\"SaveNextPrev\"");

WriteLiteral("/>\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Save & Stay\"");

WriteLiteral(" class=\"btn btn-primary btn-sm pull-left formbuttonfix\"");

WriteLiteral(" alt=\"Save & Stay\"");

WriteLiteral(" title=\"Save & Stay\"");

WriteLiteral("/>\r\n");

            
            #line 181 "..\..\Views\T_Commenttype\Edit.cshtml"
		}	

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

WriteLiteral("\t\t\t\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdnNextPrevId\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

            
            #line 184 "..\..\Views\T_Commenttype\Edit.cshtml"
}

            
            #line default
            #line hidden
            
            #line 185 "..\..\Views\T_Commenttype\Edit.cshtml"
 
            
            #line default
            #line hidden
            
            #line 185 "..\..\Views\T_Commenttype\Edit.cshtml"
    var dropmenubottom = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dropdown pull-left formbuttonfix\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(" id=\"AddAssociationdropmenubottomT_Commenttype\"");

WriteLiteral(">\r\n<button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-sm dropdown-toggle\"");

WriteLiteral(" id=\"dropdownMenu1\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" alt=\"Add Association\"");

WriteLiteral(" title=\"Add Association\"");

WriteLiteral(">\r\n            Add Association\r\n            <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span>\r\n        </button>\r\n\t\t <ul");

WriteLiteral(" class=\"dropdown-menu \"");

WriteLiteral(" role=\"menu\"");

WriteLiteral(" aria-labelledby=\"dropdownMenu1\"");

WriteLiteral(">\r\n</ul>\r\n</div>\r\n");

            
            #line 194 "..\..\Views\T_Commenttype\Edit.cshtml"
 if(!dropmenubottom || !EditPermission)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenubottomT_Commenttype\").hide();\r\n  " +
"  </script>\r\n");

            
            #line 199 "..\..\Views\T_Commenttype\Edit.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(" style=\"clear:both; margin-bottom:8px\"");

WriteLiteral("></div>\r\n</div>\r\n <div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_CommenttypeRelation\"");

WriteLiteral(">\r\n");

            
            #line 203 "..\..\Views\T_Commenttype\Edit.cshtml"
			 
            
            #line default
            #line hidden
            
            #line 203 "..\..\Views\T_Commenttype\Edit.cshtml"
              if (User.CanView("JournalEntry"))
			 {
			  // Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_Commenttype", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
			 }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\r\n</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n\t<script>\r\n\t</sc" +
"ript>\r\n\t\r\n\r\n");

            
            #line 217 "..\..\Views\T_Commenttype\Edit.cshtml"
  
var businessrule = User.businessrules.Where(p => p.EntityName == "T_Commenttype").ToList();

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

 form = $(""#frmT_Commenttype"").serialize();
				dataurl = """);

            
            #line 234 "..\..\Views\T_Commenttype\Edit.cshtml"
                      Write(Url.Action("businessruletype", "T_Commenttype", new { ruleType = "OnEdit"}));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n                ApplyBusinessRuleOnPageLoad(\"");

            
            #line 235 "..\..\Views\T_Commenttype\Edit.cshtml"
                                        Write(typelist);

            
            #line default
            #line hidden
WriteLiteral("\",dataurl, \"T_Commenttype\", false, \"ErrMsg\", form);\r\n\t\t\t\t//business rules on inli" +
"ne associations\r\n\r\n    });\r\n</script>\r\n");

WriteLiteral(@"<script>
    $(""form"").submit(function (event) {
	if (!$(""#frmT_Commenttype"").valid()) return;
			document.getElementById(""ErrMsg"").innerHTML = """";
            var flag = true;
            var dataurl = """";
            var form = """";
            var inlinecount = ""0"";
 form = $(""#frmT_Commenttype"").serialize();
    
				 dataurl = """);

            
            #line 250 "..\..\Views\T_Commenttype\Edit.cshtml"
                       Write(Url.Action("businessruletype", "T_Commenttype", new { ruleType = "OnEdit"}));

            
            #line default
            #line hidden
WriteLiteral(@""";
                 flag = ApplyBusinessRuleOnSubmit(dataurl, ""T_Commenttype"", false, ""ErrMsg"", form);

  				 //business rules on inline associations
               
			 if (flag)
				{
				                    $('input:hidden[name=""hdncommand""]').val($(this.id).context.activeElement.value);
					if ($(document.activeElement).attr('id') == ""nextEdit"" || $(document.activeElement).attr('id') == ""prevEdit"")
			         $('input:hidden[name=""hdncommand""]').val(""SaveNextPrev"");
					 $(""#frmT_Commenttype"").find(':input').removeAttr('disabled');
					}
            return flag;
		});
</script>
");

            
            #line 265 "..\..\Views\T_Commenttype\Edit.cshtml"
}
 else
    {

            
            #line default
            #line hidden
WriteLiteral(@"       <script>
    $(""input[type='submit']"").click(function (event) {
	if (!$(""#frmT_Commenttype"").valid()) return;
        var $this = $(this);
                var actionName = $this.attr(""actionName"")
                if (actionName == undefined)
                    actionName = $this.val();
                $('input:hidden[name=""hdncommand""]').val(actionName);
    });
	</script>
");

            
            #line 278 "..\..\Views\T_Commenttype\Edit.cshtml"
    }
 

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<script");

WriteLiteral(" type=\'text/javascript\'");

WriteLiteral(@">
    $(document).ready(function () {
        try {
		focusOnControl('frmT_Commenttype');
        }
        catch (ex) { }
    });
	 $(document).ready(function () {
		var RecIdEdit = $(""#frmT_Commenttype"").find(""input:hidden[name='Id']"").val();
        $(""#EntityT_CommenttypeDisplayValueEdit"").val(RecIdEdit);

		var textedit = $(""option:selected"", $(""#EntityT_CommenttypeDisplayValueEdit"")).text();
		$(""#EntityT_CommenttypeDisplayValueEdit"").attr('data-toggle', 'tooltip')
		$(""#EntityT_CommenttypeDisplayValueEdit"").attr('title', textedit);

        var lastOptionValEdit = $('#EntityT_CommenttypeDisplayValueEdit option:last-child').val();
        var fristOptionValEdit = $('#EntityT_CommenttypeDisplayValueEdit option:first-child').val();
        if (lastOptionValEdit == RecIdEdit) {
            $('#nextEdit').attr({ ""disabled"": ""true"", ""style"": ""background-color:#eeeeee !important; color:#969696 !important; border-color:#ccc !important"" });
        }
        if (fristOptionValEdit == RecIdEdit)
            $('#prevEdit').attr({ ""disabled"": ""true"", ""style"": ""background-color:#eeeeee !important; color:#969696 !important; border-color:#ccc !important"" });
    });
</script>


");

        }
    }
}
#pragma warning restore 1591