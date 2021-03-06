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

namespace GeneratorBase.MVC.Views.T_Patient
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
    
    #line 2 "..\..\Views\T_Patient\Details.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Patient/Details.cshtml")]
    public partial class Details : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Patient>
    {
        public Details()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_Patient\Details.cshtml"
  
    ViewBag.Title = "View Patient";
	var EntityDisplayNameReflector = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Patient");
    var EntityDisplayName = EntityDisplayNameReflector != null ? EntityDisplayNameReflector.DisplayName : "Patient";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\t\t\t if ($.cookie(\'");

            
            #line 10 "..\..\Views\T_Patient\Details.cshtml"
                      Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\T_Patient\Details.cshtml"
                                                 Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') != null) {\r\n\t\t\t\t$(\'a[href=\"#\' + $.cookie(\'");

            
            #line 11 "..\..\Views\T_Patient\Details.cshtml"
                                     Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\T_Patient\Details.cshtml"
                                                                Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\' + \'TabCookie\') + \'\"]\').click();\r\n\t\t\t }\r\n    });\r\n</script>\r\n");

            
            #line 15 "..\..\Views\T_Patient\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_PatientIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_Patient\Details.cshtml"
   Write(Html.Raw(ViewBag.T_PatientIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\T_Patient\Details.cshtml"
                                                ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 21 "..\..\Views\T_Patient\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_PatientIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_Patient\Details.cshtml"
   Write(Html.Raw(ViewBag.T_PatientIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\T_Patient\Details.cshtml"
                                                      ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 27 "..\..\Views\T_Patient\Details.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.T_PatientIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_Patient\Details.cshtml"
   Write(Html.Raw(ViewBag.T_PatientIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\T_Patient\Details.cshtml"
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

            
            #line 36 "..\..\Views\T_Patient\Details.cshtml"
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

            
            #line 38 "..\..\Views\T_Patient\Details.cshtml"
                                                                 Write(Html.DisplayFor(model => model.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n\t\t\t<div");

WriteLiteral(" class=\"btn-group pull-right fixactionbut\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" class=\"btn btn-xs dropdown-toggle pull-right\"");

WriteLiteral(">\r\n                Action\r\n                <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral(">    </span>\r\n            </button>\r\n\t\t\t<ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">               \r\n\t\t\t\t<li>\r\n");

            
            #line 46 "..\..\Views\T_Patient\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\T_Patient\Details.cshtml"
                     if ( User.CanEdit("T_Patient"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1799), Tuple.Create("\"", 2072)
            
            #line 48 "..\..\Views\T_Patient\Details.cshtml"
, Tuple.Create(Tuple.Create("", 1806), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","T_Patient", new {UrlReferrer = Request.UrlReferrer,id = Model.Id,AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 1806), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 49 "..\..\Views\T_Patient\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 52 "..\..\Views\T_Patient\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\T_Patient\Details.cshtml"
                     if ( User.CanDelete("T_Patient"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2300), Tuple.Create("\"", 2579)
            
            #line 54 "..\..\Views\T_Patient\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2307), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "T_Patient", new { UrlReferrer = Request.UrlReferrer,id = Model.Id, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 2307), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 55 "..\..\Views\T_Patient\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t\t\t</ul>\r\n\r\n\r\n\t\t</h2>\r\n    </div>\r\n    <!-- /.col-lg-12 --" +
">\r\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2862), Tuple.Create("\"", 2927)
, Tuple.Create(Tuple.Create("", 2872), Tuple.Create("ClearTabCookie(\'", 2872), true)
            
            #line 66 "..\..\Views\T_Patient\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2888), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 2888), false)
            
            #line 66 "..\..\Views\T_Patient\Details.cshtml"
               , Tuple.Create(Tuple.Create("", 2915), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 2915), false)
, Tuple.Create(Tuple.Create("", 2924), Tuple.Create("\');", 2924), true)
);

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 67 "..\..\Views\T_Patient\Details.cshtml"
         Write(!User.CanView("JournalEntry")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3032), Tuple.Create("\"", 3314)
, Tuple.Create(Tuple.Create("", 3042), Tuple.Create("LoadTab(\'JournalEntryToT_PatientRelation\',\'", 3042), true)
            
            #line 67 "..\..\Views\T_Patient\Details.cshtml"
                                              , Tuple.Create(Tuple.Create("", 3085), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3085), false)
            
            #line 67 "..\..\Views\T_Patient\Details.cshtml"
                                                                         , Tuple.Create(Tuple.Create("", 3112), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 3112), false)
, Tuple.Create(Tuple.Create("", 3121), Tuple.Create("\',\'", 3121), true)
            
            #line 67 "..\..\Views\T_Patient\Details.cshtml"
                                                                                     , Tuple.Create(Tuple.Create("", 3124), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_Patient", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry", TabToken = DateTime.Now.Ticks })
            
            #line default
            #line hidden
, 3124), false)
, Tuple.Create(Tuple.Create("", 3312), Tuple.Create("\')", 3312), true)
);

WriteLiteral(" href=\"#JournalEntryToT_PatientRelation\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Patient Journal</a></li>\r\n    </ul>\r\n");

WriteLiteral("\t  ");

            
            #line 69 "..\..\Views\T_Patient\Details.cshtml"
 Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t    <div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n\t\t   <div");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" id=\"Details\"");

WriteLiteral(">\r\n\t\t\t\t <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n\t\t\t\t\t<div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                                  \r\n\t\t\t\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 77 "..\..\Views\T_Patient\Details.cshtml"
 if(User.CanView("T_Patient","T_RegisterNumber"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_RegisterNumber\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 3826), Tuple.Create("\"", 3857)
            
            #line 80 "..\..\Views\T_Patient\Details.cshtml"
, Tuple.Create(Tuple.Create("", 3834), Tuple.Create<System.Object, System.Int32>(Model.T_RegisterNumber
            
            #line default
            #line hidden
, 3834), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 81 "..\..\Views\T_Patient\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_RegisterNumber));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" id=\"lblT_RegisterNumber\"");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 85 "..\..\Views\T_Patient\Details.cshtml"
                                                         Write(Model.T_RegisterNumber);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 90 "..\..\Views\T_Patient\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 91 "..\..\Views\T_Patient\Details.cshtml"
 if(User.CanView("T_Patient","T_PatientName"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_PatientName\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteAttribute("title", Tuple.Create(" title=\"", 4295), Tuple.Create("\"", 4323)
            
            #line 94 "..\..\Views\T_Patient\Details.cshtml"
, Tuple.Create(Tuple.Create("", 4303), Tuple.Create<System.Object, System.Int32>(Model.T_PatientName
            
            #line default
            #line hidden
, 4303), false)
);

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 95 "..\..\Views\T_Patient\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.T_PatientName));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t\r\n\t\t\t\t<p");

WriteLiteral(" id=\"lblT_PatientName\"");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 99 "..\..\Views\T_Patient\Details.cshtml"
                                                      Write(Model.T_PatientName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 104 "..\..\Views\T_Patient\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm pull-left formbuttonfix\"");

WriteAttribute("Onclick", Tuple.Create(" Onclick=\"", 4783), Tuple.Create("\"", 4836)
, Tuple.Create(Tuple.Create("", 4793), Tuple.Create("goBack(\'", 4793), true)
            
            #line 111 "..\..\Views\T_Patient\Details.cshtml"
           , Tuple.Create(Tuple.Create("", 4801), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","T_Patient")
            
            #line default
            #line hidden
, 4801), false)
, Tuple.Create(Tuple.Create("", 4833), Tuple.Create("\');", 4833), true)
);

WriteLiteral(">Back</a>\r\n\t\t\t\t");

WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 114 "..\..\Views\T_Patient\Details.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 114 "..\..\Views\T_Patient\Details.cshtml"
                      if ( User.CanEdit("T_Patient"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 116 "..\..\Views\T_Patient\Details.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { UrlReferrer = Request.UrlReferrer, id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm pull-left formbuttonfix" }));

            
            #line default
            #line hidden
            
            #line 116 "..\..\Views\T_Patient\Details.cshtml"
                                                                                                                                                                                                                                                                                                                                                                        
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t   \r\n");

            
            #line 119 "..\..\Views\T_Patient\Details.cshtml"
 
            
            #line default
            #line hidden
            
            #line 119 "..\..\Views\T_Patient\Details.cshtml"
    var dropmenubottom = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dropdown pull-left formbuttonfix\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(" id=\"AddAssociationdropmenubottomT_Patient\"");

WriteLiteral(">\r\n<button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-sm dropdown-toggle\"");

WriteLiteral(" id=\"dropdownMenu1\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n            Add Association\r\n            <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span>\r\n        </button>\r\n\t\t <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(" role=\"menu\"");

WriteLiteral(" aria-labelledby=\"dropdownMenu1\"");

WriteLiteral(">\r\n</ul>\r\n</div>\r\n");

            
            #line 128 "..\..\Views\T_Patient\Details.cshtml"
 if(!dropmenubottom)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        $(\"#AddAssociationdropmenubottomT_Patient\").hide();\r\n    </" +
"script>\r\n");

            
            #line 133 "..\..\Views\T_Patient\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</div> \r\n\t\t\t</div><div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"JournalEntryToT_PatientRelation\"");

WriteLiteral(">\r\n");

            
            #line 138 "..\..\Views\T_Patient\Details.cshtml"
            
            
            #line default
            #line hidden
            
            #line 138 "..\..\Views\T_Patient\Details.cshtml"
             if ( User.CanView("JournalEntry"))
		   {
			//	Html.RenderAction("Index", "JournalEntry", new { RenderPartial = true, HostingEntity = "T_Patient", HostingEntityID = @Model.Id, AssociatedType = "JournalEntry" });
		   }

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
