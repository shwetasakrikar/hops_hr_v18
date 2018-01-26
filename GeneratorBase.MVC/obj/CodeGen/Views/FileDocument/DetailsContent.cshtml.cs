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

namespace GeneratorBase.MVC.Views.FileDocument
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
    
    #line 2 "..\..\Views\FileDocument\DetailsContent.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/FileDocument/DetailsContent.cshtml")]
    public partial class DetailsContent : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.FileDocument>
    {
        public DetailsContent()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\FileDocument\DetailsContent.cshtml"
  
    ViewBag.Title = "View Document";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "FileDocument");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Document";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\FileDocument\DetailsContent.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\FileDocument\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.FileDocumentIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\FileDocument\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.FileDocumentIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                   ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\FileDocument\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.FileDocumentIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\FileDocument\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.FileDocumentIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                         ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\FileDocument\DetailsContent.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.FileDocumentIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\FileDocument\DetailsContent.cshtml"
   Write(Html.Raw(ViewBag.FileDocumentIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                       ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-hand-down text-primary\"");

WriteLiteral("></i> ");

            
            #line 36 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                                  Write(EntityDisplayName);

            
            #line default
            #line hidden
WriteLiteral("  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span>View</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral("><span");

WriteLiteral(" id=\"HostingEntityDisplayValue\"");

WriteLiteral(">");

            
            #line 38 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                                 Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n\t\t\t<div");

WriteLiteral(" class=\"btn-group pull-right fixactionbut\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" class=\"btn btn-xs dropdown-toggle btn-default pull-right\"");

WriteLiteral(">\r\n                Action\r\n                <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral(">    </span>\r\n            </button>\r\n\t\t\t<ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">               \r\n\t\t\t\t<li>\r\n");

            
            #line 46 "..\..\Views\FileDocument\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\FileDocument\DetailsContent.cshtml"
                     if ( User.CanEdit("FileDocument"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1845), Tuple.Create("\"", 2117)
            
            #line 48 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 1852), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","FileDocument", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1852), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\FileDocument\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\FileDocument\DetailsContent.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\FileDocument\DetailsContent.cshtml"
                     if ( User.CanDelete("FileDocument"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2348), Tuple.Create("\"", 2623)
            
            #line 54 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2355), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "FileDocument", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2355), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\FileDocument\DetailsContent.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></li>\r\n <li");

WriteLiteral(" class=\"dropdown-submenu pull-left\"");

WriteLiteral(">\r\n\t<a");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"margin-bottom:10px;\"");

WriteLiteral(">Find Matching</a>\r\n    <ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 2947), Tuple.Create("\"", 3047)
            
            #line 62 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 2954), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Licenses", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 2954), false)
);

WriteLiteral(">Licenses</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3080), Tuple.Create("\"", 3185)
            
            #line 65 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3087), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_ServiceRecord", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3087), false)
);

WriteLiteral(">Service Record</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3224), Tuple.Create("\"", 3323)
            
            #line 68 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3231), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Comment", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3231), false)
);

WriteLiteral(">Comment</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3355), Tuple.Create("\"", 3462)
            
            #line 71 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3362), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_DrugAlcoholTest", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3362), false)
);

WriteLiteral(">Drug & Alcohol Test</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3506), Tuple.Create("\"", 3603)
            
            #line 74 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3513), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_UnitX", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3513), false)
);

WriteLiteral(">UnitX</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3633), Tuple.Create("\"", 3738)
            
            #line 77 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3640), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_JobAssignment", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3640), false)
);

WriteLiteral(">Job Assignment</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3777), Tuple.Create("\"", 3881)
            
            #line 80 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3784), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_LeaveProfile", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3784), false)
);

WriteLiteral(">Leave</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 3911), Tuple.Create("\"", 4017)
            
            #line 83 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 3918), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_EmployeeInjury", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 3918), false)
);

WriteLiteral(">Employee Injury</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4057), Tuple.Create("\"", 4164)
            
            #line 86 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4064), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_BackgroundCheck", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4064), false)
);

WriteLiteral(">Background Check</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4205), Tuple.Create("\"", 4306)
            
            #line 89 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4212), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Education", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4212), false)
);

WriteLiteral(">Education</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4340), Tuple.Create("\"", 4445)
            
            #line 92 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4347), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_Accommodation", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4347), false)
);

WriteLiteral(">Accommodation</a>\r\n</li>\r\n<li>\r\n\t\t<a");

WriteAttribute("href", Tuple.Create(" href=\"", 4483), Tuple.Create("\"", 4585)
            
            #line 95 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4490), Tuple.Create<System.Object, System.Int32>(Url.Action("FindFSearch", "T_PayDetails", new {sourceEntity="FileDocument",id=Model.Id}, null)
            
            #line default
            #line hidden
, 4490), false)
);

WriteLiteral(">Pay Details </a>\r\n</li>\r\n</ul>\r\n</li>\r\n\t\t\t</ul>\r\n</div>\r\n\t\t</h2>\r\n    </div>\r\n  " +
"  <!-- /.col-lg-12 -->\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4804), Tuple.Create("\"", 4869)
, Tuple.Create(Tuple.Create("", 4814), Tuple.Create("ClearTabCookie(\'", 4814), true)
            
            #line 107 "..\..\Views\FileDocument\DetailsContent.cshtml"
, Tuple.Create(Tuple.Create("", 4830), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 4830), false)
            
            #line 107 "..\..\Views\FileDocument\DetailsContent.cshtml"
               , Tuple.Create(Tuple.Create("", 4857), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 4857), false)
, Tuple.Create(Tuple.Create("", 4866), Tuple.Create("\');", 4866), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n    </ul>\r\n\t    <div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n\t\t   <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"Details\"");

WriteLiteral(">\r\n\t\t\t\t <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n\t\t\t\t\t<div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                                  \r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-sm-12 col-md-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 117 "..\..\Views\FileDocument\DetailsContent.cshtml"
 if(User.CanView("FileDocument","DocumentName"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvDocumentName\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 121 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.DocumentName));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 125 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                Write(Model.DocumentName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 130 "..\..\Views\FileDocument\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 131 "..\..\Views\FileDocument\DetailsContent.cshtml"
 if(User.CanView("FileDocument","Description"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvDescription\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 135 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 139 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                Write(Model.Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 144 "..\..\Views\FileDocument\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 145 "..\..\Views\FileDocument\DetailsContent.cshtml"
 if(User.CanView("FileDocument","AttachDocument") && User.CanView("Document"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvAttachDocument\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 149 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.AttachDocument));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral(">\r\n");

            
            #line 152 "..\..\Views\FileDocument\DetailsContent.cshtml"
		
            
            #line default
            #line hidden
            
            #line 152 "..\..\Views\FileDocument\DetailsContent.cshtml"
         if(!string.IsNullOrEmpty(Model.AttachDocument))
		{
				 
            
            #line default
            #line hidden
            
            #line 154 "..\..\Views\FileDocument\DetailsContent.cshtml"
            Write(Html.ActionLink(Model.AttachDocument, "Download", new { filename = Model.AttachDocument }));

            
            #line default
            #line hidden
            
            #line 154 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                                                                             
			 
				}else{
            
            #line default
            #line hidden
WriteLiteral("<label>NA</label>");

            
            #line 156 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                       }

            
            #line default
            #line hidden
WriteLiteral("\t\t</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 161 "..\..\Views\FileDocument\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 162 "..\..\Views\FileDocument\DetailsContent.cshtml"
 if(User.CanView("FileDocument","DateCreated"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvDateCreated\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 166 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.DateCreated));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(" id=\"timeDateCreated\"");

WriteLiteral(">");

            
            #line 170 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                     Write(String.Format("{0:MM/dd/yyyy hh:mm tt}", Model.DateCreated));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("\t\t");

            
            #line 171 "..\..\Views\FileDocument\DetailsContent.cshtml"
   Write(Html.Raw("<script> $(function () {$('timeDateCreated').datetimepickerIndex({divid:'timeDateCreated',format: 'MM/DD/YYYY hh:mm',val:'" + @Html.DisplayFor(model => model.DateCreated) + "'})});</script>"));

            
            #line default
            #line hidden
WriteLiteral("        \r\n\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 176 "..\..\Views\FileDocument\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 177 "..\..\Views\FileDocument\DetailsContent.cshtml"
 if(User.CanView("FileDocument","DateLastUpdated"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvDateLastUpdated\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 181 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.DateLastUpdated));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(" id=\"timeDateLastUpdated\"");

WriteLiteral(">");

            
            #line 185 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                         Write(String.Format("{0:MM/dd/yyyy hh:mm tt}", Model.DateLastUpdated));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

WriteLiteral("\t\t");

            
            #line 186 "..\..\Views\FileDocument\DetailsContent.cshtml"
   Write(Html.Raw("<script> $(function () {$('timeDateLastUpdated').datetimepickerIndex({divid:'timeDateLastUpdated',format: 'MM/DD/YYYY hh:mm',val:'" + @Html.DisplayFor(model => model.DateLastUpdated) + "'})});</script>"));

            
            #line default
            #line hidden
WriteLiteral("        \r\n\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 191 "..\..\Views\FileDocument\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
            
            #line 192 "..\..\Views\FileDocument\DetailsContent.cshtml"
 if(User.CanView("FileDocument","T_EmployeeDocumentsID"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_EmployeeDocuments\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" >\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 196 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_EmployeeDocumentsID));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n");

            
            #line 198 "..\..\Views\FileDocument\DetailsContent.cshtml"
 
            
            #line default
            #line hidden
            
            #line 198 "..\..\Views\FileDocument\DetailsContent.cshtml"
  if (Model.t_employeedocuments!=null && !string.IsNullOrEmpty(Model.t_employeedocuments.DisplayValue))
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t <p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t");

            
            #line 201 "..\..\Views\FileDocument\DetailsContent.cshtml"
   Write(Html.ActionLink(Html.DisplayFor(model => model.t_employeedocuments.DisplayValue).ToString(), "Details", "T_Employee", new { Id = Html.DisplayFor(model => model.t_employeedocuments.Id).ToString() }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</p>\r\n");

            
            #line 203 "..\..\Views\FileDocument\DetailsContent.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 207 "..\..\Views\FileDocument\DetailsContent.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 215 "..\..\Views\FileDocument\DetailsContent.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 216 "..\..\Views\FileDocument\DetailsContent.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 216 "..\..\Views\FileDocument\DetailsContent.cshtml"
                      if ( User.CanEdit("FileDocument"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 218 "..\..\Views\FileDocument\DetailsContent.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 218 "..\..\Views\FileDocument\DetailsContent.cshtml"
                                                                                                                                                                                                                                                                                                                                     
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>    \r\n\t</div>    \r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<b" +
"r/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
