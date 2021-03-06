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

namespace GeneratorBase.MVC.Views.EntityDataSource
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
    
    #line 2 "..\..\Views\EntityDataSource\Details.cshtml"
    using PagedList;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EntityDataSource/Details.cshtml")]
    public partial class Details : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.EntityDataSource>
    {
        public Details()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\EntityDataSource\Details.cshtml"
  
    ViewBag.Title = "View Entity Data Source";

            
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

WriteLiteral("></i> Entity Data Source  <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span>View</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral("><span");

WriteLiteral(" id=\"HostingEntityDisplayValue\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\EntityDataSource\Details.cshtml"
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

            
            #line 19 "..\..\Views\EntityDataSource\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\EntityDataSource\Details.cshtml"
                     if ( User.CanEdit("EntityDataSource"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 937), Tuple.Create("\"", 1213)
            
            #line 21 "..\..\Views\EntityDataSource\Details.cshtml"
, Tuple.Create(Tuple.Create("", 944), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit","EntityDataSource", new { id = Model.Id,  UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) },null)
            
            #line default
            #line hidden
, 944), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 22 "..\..\Views\EntityDataSource\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>             \r\n\t\t\t\t<li>\r\n");

            
            #line 25 "..\..\Views\EntityDataSource\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\EntityDataSource\Details.cshtml"
                     if ( User.CanDelete("EntityDataSource"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1448), Tuple.Create("\"", 1727)
            
            #line 27 "..\..\Views\EntityDataSource\Details.cshtml"
, Tuple.Create(Tuple.Create("", 1455), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "EntityDataSource", new { id = Model.Id, UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null)
            
            #line default
            #line hidden
, 1455), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 28 "..\..\Views\EntityDataSource\Details.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </li>\r\n\t<li");

WriteLiteral(" class=\"divider\"");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></li>\r\n\t<li");

WriteLiteral(" class=\"dropdown-submenu pull-left\"");

WriteLiteral(">\r\n\t<a");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"margin-bottom:10px;\"");

WriteLiteral(">Add Association</a>\r\n    <ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">\r\n");

            
            #line 34 "..\..\Views\EntityDataSource\Details.cshtml"
				
            
            #line default
            #line hidden
            
            #line 34 "..\..\Views\EntityDataSource\Details.cshtml"
                 if ( User.CanAdd("DataSourceParameters"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 2117), Tuple.Create("", 2417)
            
            #line 37 "..\..\Views\EntityDataSource\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2126), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "DataSourceParameters", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="EntityDataSourceParameters", 
							HostingEntityName = "EntityDataSource",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 2126), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Data Source Parameters\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 45 "..\..\Views\EntityDataSource\Details.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t");

            
            #line 46 "..\..\Views\EntityDataSource\Details.cshtml"
                             if ( User.CanAdd("PropertyMapping"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<li>\r\n\t\t\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 2596), Tuple.Create("", 2886)
            
            #line 49 "..\..\Views\EntityDataSource\Details.cshtml"
, Tuple.Create(Tuple.Create("", 2605), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "PropertyMapping", 
						new { UrlReferrer = Request.Url,
								AssociatedType ="EntityPropertyMapping", 
							HostingEntityName = "EntityDataSource",
							HostingEntityID = @Convert.ToString(Model.Id) }, null) + "');")
            
            #line default
            #line hidden
, 2605), false)
);

WriteLiteral(">\r\n\t\t\t\t\t\t\t<i");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></i>  Property Mapping\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t</li>\r\n");

            
            #line 57 "..\..\Views\EntityDataSource\Details.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</ul>\r\n</li>\r\n\t\t\t</ul>\r\n</div>\r\n\t\t</h2>\r\n    </div>\r\n    <!-- /.col-lg-12 -->\r" +
"\n</div>\r\n<div");

WriteLiteral(" class=\"tabbable responsive\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n\t <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" href=\"#Details\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">Details</a></li>\r\n\t\t <li ");

            
            #line 69 "..\..\Views\EntityDataSource\Details.cshtml"
         Write(!User.CanView("DataSourceParameters")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3294), Tuple.Create("\"", 3556)
, Tuple.Create(Tuple.Create("", 3304), Tuple.Create("LoadTab(\'EntityDataSourceParameters\',\'", 3304), true)
            
            #line 69 "..\..\Views\EntityDataSource\Details.cshtml"
                                                 , Tuple.Create(Tuple.Create("", 3342), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "DataSourceParameters", new {RenderPartial=true, HostingEntity ="EntityDataSource", HostingEntityID = @Model.Id, AssociatedType = "EntityDataSourceParameters",TabToken = DateTime.Now.Ticks,})
            
            #line default
            #line hidden
, 3342), false)
, Tuple.Create(Tuple.Create("", 3554), Tuple.Create("\')", 3554), true)
);

WriteLiteral(" href=\"#EntityDataSourceParameters\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Data Source Parameters\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_EntityDataSourceParameters\"");

WriteLiteral(">");

            
            #line 71 "..\..\Views\EntityDataSource\Details.cshtml"
                                                                           Write(ViewBag.EntityDataSourceParametersCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n\t\t <li ");

            
            #line 73 "..\..\Views\EntityDataSource\Details.cshtml"
         Write(!User.CanView("PropertyMapping")?"style=display:none;":"");

            
            #line default
            #line hidden
WriteLiteral("><a");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3856), Tuple.Create("\"", 4103)
, Tuple.Create(Tuple.Create("", 3866), Tuple.Create("LoadTab(\'EntityPropertyMapping\',\'", 3866), true)
            
            #line 73 "..\..\Views\EntityDataSource\Details.cshtml"
                                       , Tuple.Create(Tuple.Create("", 3899), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "PropertyMapping", new {RenderPartial=true, HostingEntity ="EntityDataSource", HostingEntityID = @Model.Id, AssociatedType = "EntityPropertyMapping",TabToken = DateTime.Now.Ticks,})
            
            #line default
            #line hidden
, 3899), false)
, Tuple.Create(Tuple.Create("", 4101), Tuple.Create("\')", 4101), true)
);

WriteLiteral(" href=\"#EntityPropertyMapping\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">\r\n\t\t Property Mapping\r\n\t\t <span");

WriteLiteral(" class=\"badge bg-blue\"");

WriteLiteral("><div");

WriteLiteral(" id=\"dvcnt_EntityPropertyMapping\"");

WriteLiteral(">");

            
            #line 75 "..\..\Views\EntityDataSource\Details.cshtml"
                                                                      Write(ViewBag.EntityPropertyMappingCount);

            
            #line default
            #line hidden
WriteLiteral("</div></span>\r\n\t\t \t\t </a></li>\r\n    </ul>\r\n\t    <div");

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

            
            #line 86 "..\..\Views\EntityDataSource\Details.cshtml"
 if(User.CanView("EntityDataSource","EntityName"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 90 "..\..\Views\EntityDataSource\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.EntityName));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 93 "..\..\Views\EntityDataSource\Details.cshtml"
                                Write(Model.EntityName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 97 "..\..\Views\EntityDataSource\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 98 "..\..\Views\EntityDataSource\Details.cshtml"
 if(User.CanView("EntityDataSource","DataSource"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 102 "..\..\Views\EntityDataSource\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.DataSource));

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 104 "..\..\Views\EntityDataSource\Details.cshtml"
                        Write(Model.DataSource);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 108 "..\..\Views\EntityDataSource\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 109 "..\..\Views\EntityDataSource\Details.cshtml"
 if(User.CanView("EntityDataSource","SourceType"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 113 "..\..\Views\EntityDataSource\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.SourceType));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 116 "..\..\Views\EntityDataSource\Details.cshtml"
                                Write(Model.SourceType);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 120 "..\..\Views\EntityDataSource\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 121 "..\..\Views\EntityDataSource\Details.cshtml"
 if(User.CanView("EntityDataSource","MethodType"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 125 "..\..\Views\EntityDataSource\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.MethodType));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 128 "..\..\Views\EntityDataSource\Details.cshtml"
                                Write(Model.MethodType);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 132 "..\..\Views\EntityDataSource\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 133 "..\..\Views\EntityDataSource\Details.cshtml"
 if(User.CanView("EntityDataSource","Action"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 137 "..\..\Views\EntityDataSource\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.Action));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 140 "..\..\Views\EntityDataSource\Details.cshtml"
                                Write(Model.Action);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 144 "..\..\Views\EntityDataSource\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 145 "..\..\Views\EntityDataSource\Details.cshtml"
 if(User.CanView("EntityDataSource","flag"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 149 "..\..\Views\EntityDataSource\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.flag));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n");

WriteLiteral("\t\t\t\t");

            
            #line 152 "..\..\Views\EntityDataSource\Details.cshtml"
           Write(Html.DisplayFor(model => model.flag));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 156 "..\..\Views\EntityDataSource\Details.cshtml"
}

            
            #line default
            #line hidden
            
            #line 157 "..\..\Views\EntityDataSource\Details.cshtml"
 if(User.CanView("EntityDataSource","other"))
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 161 "..\..\Views\EntityDataSource\Details.cshtml"
                                              Write(Html.DisplayNameFor(model => model.other));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\r\n\t\t\t\t<p");

WriteLiteral(" class=\"viewlabel\"");

WriteLiteral(">");

            
            #line 164 "..\..\Views\EntityDataSource\Details.cshtml"
                                Write(Model.other);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");

            
            #line 168 "..\..\Views\EntityDataSource\Details.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t");

            
            #line 176 "..\..\Views\EntityDataSource\Details.cshtml"
               Write(Html.ActionLink("Back", "Cancel", new { UrlReferrer = Request.UrlReferrer }, new { @class = "btn btn-default btn-sm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 177 "..\..\Views\EntityDataSource\Details.cshtml"
					 
            
            #line default
            #line hidden
            
            #line 177 "..\..\Views\EntityDataSource\Details.cshtml"
                      if ( User.CanEdit("EntityDataSource"))
                     {
                          
            
            #line default
            #line hidden
            
            #line 179 "..\..\Views\EntityDataSource\Details.cshtml"
                     Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id, AssociatedType = ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, new { @class = "btn btn-primary btn-sm" }));

            
            #line default
            #line hidden
            
            #line 179 "..\..\Views\EntityDataSource\Details.cshtml"
                                                                                                                                                                                                                                                                                                             
                     }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>    \r\n");

            
            #line 183 "..\..\Views\EntityDataSource\Details.cshtml"
			
            
            #line default
            #line hidden
            
            #line 183 "..\..\Views\EntityDataSource\Details.cshtml"
             if ( User.CanAdd("DataSourceParameters"))
            {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 7883), Tuple.Create("", 8229)
            
            #line 185 "..\..\Views\EntityDataSource\Details.cshtml"
, Tuple.Create(Tuple.Create("", 7892), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "DataSourceParameters",
						new { UrlReferrer = Request.Url,
								AssociatedType ="EntityDataSourceParameters", 
						HostingEntityName = "EntityDataSource",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 7892), false)
);

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" style=\"margin-top:5px;\"");

WriteLiteral(">\r\n                   Add  Data Source Parameters\r\n                </a>\r\n");

            
            #line 193 "..\..\Views\EntityDataSource\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t");

            
            #line 194 "..\..\Views\EntityDataSource\Details.cshtml"
             if ( User.CanAdd("PropertyMapping"))
            {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<a");

WriteAttribute("onclick", Tuple.Create(" onclick=", 8435), Tuple.Create("", 8771)
            
            #line 196 "..\..\Views\EntityDataSource\Details.cshtml"
, Tuple.Create(Tuple.Create("", 8444), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "PropertyMapping",
						new { UrlReferrer = Request.Url,
								AssociatedType ="EntityPropertyMapping", 
						HostingEntityName = "EntityDataSource",
                              HostingEntityID = @Convert.ToString(Model.Id)
                        }, null) + "');")
            
            #line default
            #line hidden
, 8444), false)
);

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" style=\"margin-top:5px;\"");

WriteLiteral(">\r\n                   Add  Property Mapping\r\n                </a>\r\n");

            
            #line 204 "..\..\Views\EntityDataSource\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\t</div>    \r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"EntityDataSourceParameters\"");

WriteLiteral(">\r\n");

            
            #line 207 "..\..\Views\EntityDataSource\Details.cshtml"
     
            
            #line default
            #line hidden
            
            #line 207 "..\..\Views\EntityDataSource\Details.cshtml"
      if ( User.CanView("DataSourceParameters"))
	{
	  // Html.RenderAction("Index", "DataSourceParameters", new {RenderPartial=true, HostingEntity = "EntityDataSource", HostingEntityID = @Model.Id, AssociatedType = "EntityDataSourceParameters" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n<div");

WriteLiteral(" class=\"tab-pane fade in\"");

WriteLiteral(" id=\"EntityPropertyMapping\"");

WriteLiteral(">\r\n");

            
            #line 213 "..\..\Views\EntityDataSource\Details.cshtml"
     
            
            #line default
            #line hidden
            
            #line 213 "..\..\Views\EntityDataSource\Details.cshtml"
      if ( User.CanView("PropertyMapping"))
	{
	  // Html.RenderAction("Index", "PropertyMapping", new {RenderPartial=true, HostingEntity = "EntityDataSource", HostingEntityID = @Model.Id, AssociatedType = "EntityPropertyMapping" }); 
	}

            
            #line default
            #line hidden
WriteLiteral("  </div>\r\n\t</div> <!-- /tab-content --><br />\r\n<br/>\r\n</div>\r\n \r\n");

        }
    }
}
#pragma warning restore 1591
