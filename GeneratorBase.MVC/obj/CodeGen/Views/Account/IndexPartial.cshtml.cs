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

namespace GeneratorBase.MVC.Views.Account
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
    
    #line 2 "..\..\Views\Account\IndexPartial.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/IndexPartial.cshtml")]
    public partial class IndexPartial : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.EditUserViewModel>>
    {
        
        #line 51 "..\..\Views\Account\IndexPartial.cshtml"
                
        object getSortHtmlAttributes(string sortby, bool IsPaging, int? page, bool? IsExport)
        {
            if (IsPaging)
            {
                return new
                {
                    page,
                    sortBy = ViewBag.CurrentSort,
                    isAsc = ViewBag.IsAsc,
                    currentFilter = ViewBag.CurrentFilter,
                    IsExport = IsExport,
                    search = Request.QueryString["search"],
                };
            }
            else
            {
                return new
                {
                    sortBy = sortby,
                    currentFilter = Request.QueryString["currentFilter"],
                    searchString = Request.QueryString["searchString"],
                    isAsc = (ViewBag.IsAsc == "ASC" ? "DESC" : ""),
                    page = ViewBag.Pages,
                    IsExport = IsExport,
                    search = Request.QueryString["search"],
                };
            }
        }

    
        #line default
        #line hidden
        
        public IndexPartial()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Account\IndexPartial.cshtml"
  
    var ActionNameUrl = "Index";
    if (HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString().ToUpper() == "FSEARCH")
    {
        ActionNameUrl = "FSearch";
    }
    var BackUrl = Request.Url;
    if (ViewData["HostingEntity"] != null && Request.QueryString["TabToken"] != null)
    {
        BackUrl = Request.UrlReferrer;
    }
    ApplicationContext db = new ApplicationContext(new GeneratorBase.MVC.Models.SystemUser());

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" id=\"Account\"");

WriteLiteral(@">
    <style>
        .table-responsive > .fixed-column {
            position: absolute;
            display: block;
            width: auto;
            border: 0px solid transparent;
            border-top: 1px solid #c3ddec;
        }

        .fixed-column th {
            background: #fff;
        }

        .fixed-column td {
            background: #fff;
        }
    </style>
    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $(document).ready(function () {\r\n            $(\".pagination a\").click(" +
"function (e) {\r\n                PaginationClick(e, \'Account\', \'");

            
            #line 37 "..\..\Views\Account\IndexPartial.cshtml"
                                          Write(User.JavaScriptEncodedName);

            
            #line default
            #line hidden
WriteLiteral(@"')
            })
            $(""#SearchStringAccount"").keypress(function (e) {
                if ((e.which && e.which == 13) || (e.keyCode && e.keyCode == 13)) {
                    $(""#AccountSearch"").bind(""click"", (function () {
                    }));
                    $('#AccountSearch').trigger(""click"");
                    return false;
                }
            })

        });
    </script>

");

            
            #line 51 "..\..\Views\Account\IndexPartial.cshtml"
    
            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\'col-sm-12 col-md-12 col-xs-12\'");

WriteLiteral(" style=\"padding:0px; margin:5px 0px 0px 0px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"input-group col-sm-12 col-md-12 col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 85 "..\..\Views\Account\IndexPartial.cshtml"
           Write(Html.TextBox("SearchStringAccount", ViewBag.CurrentFilter as string, null, new { @class = "form-control fixsearchbox", @placeholder = "Search" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" id=\"AccountSearch\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3141), Tuple.Create("\"", 3326)
, Tuple.Create(Tuple.Create("", 3151), Tuple.Create("SearchClick(event,", 3151), true)
, Tuple.Create(Tuple.Create(" ", 3169), Tuple.Create("\'Account\',", 3170), true)
, Tuple.Create(Tuple.Create(" ", 3180), Tuple.Create("\'", 3181), true)
            
            #line 87 "..\..\Views\Account\IndexPartial.cshtml"
  , Tuple.Create(Tuple.Create("", 3182), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "Account", new {searchString = "_SearchString",SearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 3182), false)
, Tuple.Create(Tuple.Create("", 3293), Tuple.Create("\',\'", 3293), true)
            
            #line 87 "..\..\Views\Account\IndexPartial.cshtml"
                                                                                                                    , Tuple.Create(Tuple.Create("", 3296), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3296), false)
, Tuple.Create(Tuple.Create("", 3323), Tuple.Create("\');", 3323), true)
);

WriteLiteral("\r\n                       data-original-title=\"Grid Search\"");

WriteLiteral(" class=\"btn btn-default btn-default tip-top\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral("><span");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></span></a>\r\n                    <button");

WriteLiteral(" id=\"AccountCancel\"");

WriteLiteral(" type=\"button\"");

WriteLiteral("\r\n                            class=\"btn btn-default btn-default collapse-data-bt" +
"n tip-top\"");

WriteAttribute("onclick", Tuple.Create("\r\n                            onclick=\"", 3646), Tuple.Create("\"", 3827)
, Tuple.Create(Tuple.Create("", 3685), Tuple.Create("CancelSearch(\'Account\',\'", 3685), true)
            
            #line 91 "..\..\Views\Account\IndexPartial.cshtml"
, Tuple.Create(Tuple.Create("", 3709), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "Account", new { ClearSearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 3709), false)
, Tuple.Create(Tuple.Create("", 3795), Tuple.Create("\',\'", 3795), true)
            
            #line 91 "..\..\Views\Account\IndexPartial.cshtml"
                                                                      , Tuple.Create(Tuple.Create("", 3798), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 3798), false)
, Tuple.Create(Tuple.Create("", 3825), Tuple.Create("\')", 3825), true)
);

WriteLiteral(" data-original-title=\"Clear Search\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"fa fa-minus-circle\"");

WriteLiteral("></span>\r\n                    </button>\r\n                </div>\r\n            </di" +
"v>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-sx-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default \"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(" style=\"margin:0px; padding:8px;\"");

WriteLiteral(">\r\n");

            
            #line 102 "..\..\Views\Account\IndexPartial.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 102 "..\..\Views\Account\IndexPartial.cshtml"
                     if (User.CanAddAdminFeature("User"))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <button");

WriteLiteral(" class=\"btn btn-default tip-top\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" data-original-title=\"Add New User\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" data-target=\"#quickaddUser\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 4566), Tuple.Create("", 4628)
            
            #line 104 "..\..\Views\Account\IndexPartial.cshtml"
                                                                                                                         , Tuple.Create(Tuple.Create("", 4575), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenQuickQddPopUp('dvQAddquickaddUser');")
            
            #line default
            #line hidden
, 4575), false)
);

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"fa fa-plus-circle\"");

WriteLiteral("></span> Create User\r\n                        </button>\r\n");

WriteLiteral("\t\t\t<button");

WriteLiteral(" class=\"btn btn-default tip-top\"");

WriteLiteral("  data-original-title=\"Import Users\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 4850), Tuple.Create("", 4933)
            
            #line 107 "..\..\Views\Account\IndexPartial.cshtml"
                                         , Tuple.Create(Tuple.Create("", 4859), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("UploadUser", "Account") + "');")
            
            #line default
            #line hidden
, 4859), false)
);

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"fa fa-upload\"");

WriteLiteral("></span> Import Excel\r\n                        </button>\r\n");

            
            #line 110 "..\..\Views\Account\IndexPartial.cshtml"
                        if (GeneratorBase.MVC.Models.CommonFunction.Instance.NeedSharedUserSystem() == "yes")
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 5216), Tuple.Create("\"", 5414)
, Tuple.Create(Tuple.Create("", 5223), Tuple.Create("http://", 5223), true)
            
            #line 112 "..\..\Views\Account\IndexPartial.cshtml"
, Tuple.Create(Tuple.Create("", 5230), Tuple.Create<System.Object, System.Int32>(GeneratorBase.MVC.Models.CommonFunction.Instance.Server()
            
            #line default
            #line hidden
, 5230), false)
, Tuple.Create(Tuple.Create("", 5288), Tuple.Create("/Authentication/Account/Register?AppName=", 5288), true)
            
            #line 112 "..\..\Views\Account\IndexPartial.cshtml"
                                                               , Tuple.Create(Tuple.Create("", 5329), Tuple.Create<System.Object, System.Int32>(Url.Action("Login","Account",null,Url.RequestContext.HttpContext.Request.Url.Scheme)
            
            #line default
            #line hidden
, 5329), false)
);

WriteLiteral(" class=\"btn\"");

WriteLiteral(">Create User in Shared User System</a>\r\n");

            
            #line 113 "..\..\Views\Account\IndexPartial.cshtml"
                        }
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n\r\n                <div");

WriteLiteral(" id=\"Des_Table\"");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(" style=\"overflow-x:auto;\"");

WriteLiteral(">\r\n                    <table");

WriteLiteral(" class=\"table table-striped table-bordered table-hover table-condensed\"");

WriteLiteral(">\r\n                        <tr>\r\n                            <th>Action</th>\r\n   " +
"                         <th");

WriteLiteral(" class=\"col2\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 122 "..\..\Views\Account\IndexPartial.cshtml"
                           Write(Html.ActionLink("User Name", ActionNameUrl, "Account", getSortHtmlAttributes("UserName", false, null, false), new { @onclick = "SortLinkClick(event,'Account');" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 123 "..\..\Views\Account\IndexPartial.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 123 "..\..\Views\Account\IndexPartial.cshtml"
                                 if (ViewBag.IsAsc == "DESC" && ViewBag.CurrentSort == "UserName")
                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-desc\"");

WriteLiteral("></i>");

            
            #line 124 "..\..\Views\Account\IndexPartial.cshtml"
                                                                }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 125 "..\..\Views\Account\IndexPartial.cshtml"
                                 if (ViewBag.IsAsc == "ASC" && ViewBag.CurrentSort == "UserName")
                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-asc\"");

WriteLiteral("></i>");

            
            #line 126 "..\..\Views\Account\IndexPartial.cshtml"
                                                               }

            
            #line default
            #line hidden
WriteLiteral("                            </th>\r\n                            <th");

WriteLiteral(" class=\"col3\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 129 "..\..\Views\Account\IndexPartial.cshtml"
                           Write(Html.ActionLink("First Name", ActionNameUrl, "Account", getSortHtmlAttributes("FirstName", false, null, false), new { @onclick = "SortLinkClick(event,'Account');" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 130 "..\..\Views\Account\IndexPartial.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 130 "..\..\Views\Account\IndexPartial.cshtml"
                                 if (ViewBag.IsAsc == "DESC" && ViewBag.CurrentSort == "FirstName")
                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-desc\"");

WriteLiteral("></i>");

            
            #line 131 "..\..\Views\Account\IndexPartial.cshtml"
                                                                }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 132 "..\..\Views\Account\IndexPartial.cshtml"
                                 if (ViewBag.IsAsc == "ASC" && ViewBag.CurrentSort == "FirstName")
                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-asc\"");

WriteLiteral("></i>");

            
            #line 133 "..\..\Views\Account\IndexPartial.cshtml"
                                                               }

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </th>\r\n                            <th");

WriteLiteral(" class=\"col4\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 137 "..\..\Views\Account\IndexPartial.cshtml"
                           Write(Html.ActionLink("Last Name", ActionNameUrl, "Account", getSortHtmlAttributes("LastName", false, null, false), new { @onclick = "SortLinkClick(event,'Account');" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 138 "..\..\Views\Account\IndexPartial.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 138 "..\..\Views\Account\IndexPartial.cshtml"
                                 if (ViewBag.IsAsc == "DESC" && ViewBag.CurrentSort == "LastName")
                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-desc\"");

WriteLiteral("></i>");

            
            #line 139 "..\..\Views\Account\IndexPartial.cshtml"
                                                                }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 140 "..\..\Views\Account\IndexPartial.cshtml"
                                 if (ViewBag.IsAsc == "ASC" && ViewBag.CurrentSort == "LastName")
                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-asc\"");

WriteLiteral("></i>");

            
            #line 141 "..\..\Views\Account\IndexPartial.cshtml"
                                                               }

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </th>\r\n                            <th");

WriteLiteral(" class=\"col5\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 145 "..\..\Views\Account\IndexPartial.cshtml"
                           Write(Html.ActionLink("Email", ActionNameUrl, "Account", getSortHtmlAttributes("Email", false, null, false), new { @onclick = "SortLinkClick(event,'Account');" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 146 "..\..\Views\Account\IndexPartial.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 146 "..\..\Views\Account\IndexPartial.cshtml"
                                 if (ViewBag.IsAsc == "DESC" && ViewBag.CurrentSort == "Email")
                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-desc\"");

WriteLiteral("></i>");

            
            #line 147 "..\..\Views\Account\IndexPartial.cshtml"
                                                                }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 148 "..\..\Views\Account\IndexPartial.cshtml"
                                 if (ViewBag.IsAsc == "ASC" && ViewBag.CurrentSort == "Email")
                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-asc\"");

WriteLiteral("></i>");

            
            #line 149 "..\..\Views\Account\IndexPartial.cshtml"
                                                               }

            
            #line default
            #line hidden
WriteLiteral("                            </th>\r\n                            <th>Api Token</th>" +
"\r\n                            <th>User\'s Status</th>\r\n                        </" +
"tr>\r\n");

            
            #line 154 "..\..\Views\Account\IndexPartial.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 154 "..\..\Views\Account\IndexPartial.cshtml"
                         foreach (var item in Model)
                        {
                            var userId = item.Id;
                            var token = db.ApiTokens.FirstOrDefault(p => p.T_UsersID == userId);

            
            #line default
            #line hidden
WriteLiteral("                            <tr>\r\n                                <td>\r\n\r\n       " +
"                             <div");

WriteLiteral(" style=\"width:60px; margin-top:-2px;\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(" style=\"position:absolute;\"");

WriteLiteral(">\r\n                                            <button");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" class=\"btn btn-xs dropdown-toggle btn-default\"");

WriteLiteral(">\r\n                                                Action\r\n                      " +
"                          <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral(">    </span>\r\n                                            </button>\r\n");

            
            #line 167 "..\..\Views\Account\IndexPartial.cshtml"
                                            
            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\Account\IndexPartial.cshtml"
                                             if (User.Name != item.UserName && !((GeneratorBase.MVC.Models.CustomPrincipal)User).IsAdminUser(item.UserName))
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">\r\n");

            
            #line 170 "..\..\Views\Account\IndexPartial.cshtml"
                                                    
            
            #line default
            #line hidden
            
            #line 170 "..\..\Views\Account\IndexPartial.cshtml"
                                                     if (User.CanViewAdminFeature("AssignUserRole"))
                                                    {

            
            #line default
            #line hidden
WriteLiteral("                                                        <li>\r\n                   " +
"                                         <a");

WriteAttribute("href", Tuple.Create(" href=\"", 9744), Tuple.Create("\"", 9807)
            
            #line 173 "..\..\Views\Account\IndexPartial.cshtml"
, Tuple.Create(Tuple.Create("", 9751), Tuple.Create<System.Object, System.Int32>(Url.Action("UserRoles", "Account", new { id = item.Id})
            
            #line default
            #line hidden
, 9751), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-eye-open\"");

WriteLiteral("></i>  Roles</a>\r\n                                                        </li>\r\n" +
"");

            
            #line 175 "..\..\Views\Account\IndexPartial.cshtml"
                                                    }

            
            #line default
            #line hidden
WriteLiteral("                                                    ");

            
            #line 176 "..\..\Views\Account\IndexPartial.cshtml"
                                                     if (User.CanEditAdminFeature("User"))
                                                    {

            
            #line default
            #line hidden
WriteLiteral("                                                        <li>\r\n                   " +
"                                         <a");

WriteAttribute("href", Tuple.Create(" href=\"", 10255), Tuple.Create("\"", 10320)
            
            #line 179 "..\..\Views\Account\IndexPartial.cshtml"
, Tuple.Create(Tuple.Create("", 10262), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit", "Account", new { id = item.Id }, null)
            
            #line default
            #line hidden
, 10262), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n                                                        </li>\r\n");

            
            #line 181 "..\..\Views\Account\IndexPartial.cshtml"
                                                    }

            
            #line default
            #line hidden
WriteLiteral("                                                    ");

            
            #line 182 "..\..\Views\Account\IndexPartial.cshtml"
                                                     if (User.CanDeleteAdminFeature("User"))
                                                    {

            
            #line default
            #line hidden
WriteLiteral("                                                        <li>\r\n                   " +
"                                         <a");

WriteAttribute("href", Tuple.Create(" href=\"", 10765), Tuple.Create("\"", 10832)
            
            #line 185 "..\..\Views\Account\IndexPartial.cshtml"
, Tuple.Create(Tuple.Create("", 10772), Tuple.Create<System.Object, System.Int32>(Url.Action("Delete", "Account", new { id = item.Id }, null)
            
            #line default
            #line hidden
, 10772), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n                                                        </li>\r" +
"\n");

            
            #line 187 "..\..\Views\Account\IndexPartial.cshtml"
                                                    }

            
            #line default
            #line hidden
WriteLiteral("                                                    ");

            
            #line 188 "..\..\Views\Account\IndexPartial.cshtml"
                                                     if (item.LockoutEndDateUtc > DateTime.UtcNow || item.LockoutEndDateUtc != null)
                                                    {
                                                        if (User.CanEditAdminFeature("User"))
                                                        {

            
            #line default
            #line hidden
WriteLiteral("                                                            <li>\r\n               " +
"                                                 <a");

WriteLiteral(" onclick=\"return confirm(\'Are you sure?\')\"");

WriteAttribute("href", Tuple.Create(" href=\"", 11530), Tuple.Create("\"", 11620)
            
            #line 193 "..\..\Views\Account\IndexPartial.cshtml"
                                  , Tuple.Create(Tuple.Create("", 11537), Tuple.Create<System.Object, System.Int32>(Url.Action("LockUnLockUser", "Account", new { id = item.Id,lockuser=false }, null)
            
            #line default
            #line hidden
, 11537), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  UnLock User</a>\r\n                                                         " +
"   </li>\r\n");

            
            #line 195 "..\..\Views\Account\IndexPartial.cshtml"
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (User.CanEditAdminFeature("User"))
                                                        {

            
            #line default
            #line hidden
WriteLiteral("                                                            <li>\r\n               " +
"                                                 <a");

WriteLiteral(" onclick=\"return confirm(\'Are you sure?\')\"");

WriteAttribute("href", Tuple.Create(" href=\"", 12310), Tuple.Create("\"", 12399)
            
            #line 202 "..\..\Views\Account\IndexPartial.cshtml"
                                  , Tuple.Create(Tuple.Create("", 12317), Tuple.Create<System.Object, System.Int32>(Url.Action("LockUnLockUser", "Account", new { id = item.Id,lockuser=true }, null)
            
            #line default
            #line hidden
, 12317), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Lock User</a>\r\n                                                           " +
" </li>\r\n");

            
            #line 204 "..\..\Views\Account\IndexPartial.cshtml"
                                                        }
                                                    }

            
            #line default
            #line hidden
WriteLiteral("                                                </ul>\r\n");

            
            #line 207 "..\..\Views\Account\IndexPartial.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                        </div>\r\n                                 " +
"   </div>\r\n\r\n                                </td>\r\n                            " +
"    <td>\r\n");

WriteLiteral("                                    ");

            
            #line 213 "..\..\Views\Account\IndexPartial.cshtml"
                               Write(Html.DisplayFor(modelItem => item.UserName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 216 "..\..\Views\Account\IndexPartial.cshtml"
                               Write(Html.DisplayFor(modelItem => item.FirstName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 219 "..\..\Views\Account\IndexPartial.cshtml"
                               Write(Html.DisplayFor(modelItem => item.LastName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 222 "..\..\Views\Account\IndexPartial.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");

            
            #line 225 "..\..\Views\Account\IndexPartial.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 225 "..\..\Views\Account\IndexPartial.cshtml"
                                     if (token != null)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <label>");

            
            #line 227 "..\..\Views\Account\IndexPartial.cshtml"
                                          Write(token.T_AuthToken);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

            
            #line 228 "..\..\Views\Account\IndexPartial.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </td>\r\n                                <td>\r\n");

            
            #line 231 "..\..\Views\Account\IndexPartial.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 231 "..\..\Views\Account\IndexPartial.cshtml"
                                     if (item.LockoutEndDateUtc > DateTime.UtcNow || item.LockoutEndDateUtc != null)
                                    {
                                        
            
            #line default
            #line hidden
            
            #line 233 "..\..\Views\Account\IndexPartial.cshtml"
                                   Write(Html.Label("Locked"));

            
            #line default
            #line hidden
            
            #line 233 "..\..\Views\Account\IndexPartial.cshtml"
                                                             
                                    }
                                    else
                                    {
                                        
            
            #line default
            #line hidden
            
            #line 237 "..\..\Views\Account\IndexPartial.cshtml"
                                   Write(Html.Label("UnLocked"));

            
            #line default
            #line hidden
            
            #line 237 "..\..\Views\Account\IndexPartial.cshtml"
                                                               
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </td>\r\n                            </tr>\r\n");

            
            #line 241 "..\..\Views\Account\IndexPartial.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </table>\r\n                </div>\r\n\r\n            </div>\r\n");

            
            #line 246 "..\..\Views\Account\IndexPartial.cshtml"
            
            
            #line default
            #line hidden
            
            #line 246 "..\..\Views\Account\IndexPartial.cshtml"
             if (Model.Count > 0)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" id=\"pagination\"");

WriteLiteral(" class=\"MyPagination1\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 249 "..\..\Views\Account\IndexPartial.cshtml"
               Write(Html.PagedListPager(Model, page => Url.Action(ActionNameUrl, "Account", getSortHtmlAttributes(null, true, page, false))));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"fixPageSize\"");

WriteLiteral(">\r\n                        Page Size :\r\n");

WriteLiteral("                        ");

            
            #line 252 "..\..\Views\Account\IndexPartial.cshtml"
                   Write(Html.DropDownList("PageSize", new SelectList(new Dictionary<string, int> { { "10", 10 }, { "20", 20 }, { "50", 50 }, { "100", 100 } }, "Key", "Value")
                            , new
                            {
                                @id = "pagesizelisAccount",
                                @onchange = @Html.Raw("pagesizelistChange(event,'Account','"
                                 + @User.JavaScriptEncodedName + "')"),
                                @Url = Html.Raw(@Url.Action(ActionNameUrl, "Account",
                                getSortHtmlAttributes(ViewBag.CurrentSort, ViewBag.Pages == 1 ? false : true,
                                null, false), null))
                            }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <span");

WriteLiteral(" style=\"text-align:right;\"");

WriteLiteral("> Total Count: ");

            
            #line 262 "..\..\Views\Account\IndexPartial.cshtml"
                                                                  Write(Model.TotalItemCount);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </div>\r\n                </div>\r\n");

            
            #line 265 "..\..\Views\Account\IndexPartial.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" id=\"quickaddUser\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" role=\"dialog\"");

WriteLiteral(" aria-labelledby=\"quickaddUserLabel\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">&times;</button>\r\n                    <h4");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral(" id=\"quickaddUserLabel\"");

WriteLiteral("> Create User</h4>\r\n                </div>\r\n                <div");

WriteLiteral(" id=\"dvQAddquickaddUser\"");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(" data-url=\"");

            
            #line 275 "..\..\Views\Account\IndexPartial.cshtml"
                                                                     Write(Url.Action("CreateUser", "Account"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>" +
"");

        }
    }
}
#pragma warning restore 1591
