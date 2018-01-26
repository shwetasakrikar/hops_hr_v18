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

namespace GeneratorBase.MVC.Views.Shared
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
    
    #line 1 "..\..\Views\Shared\_Layoutpwd.cshtml"
    using Microsoft.AspNet.Identity;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Layoutpwd.cshtml")]
    public partial class Layoutpwd : GeneratorBase.MVC.CustomWebViewPage<dynamic>
    {
        public Layoutpwd()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Shared\_Layoutpwd.cshtml"
  
    DisplayModeProvider.Instance.RequireConsistentDisplayMode = true;
    var currentController = ViewContext.RouteData.Values["controller"].ToString();
    var commonObj = GeneratorBase.MVC.Models.CommonFunction.Instance;
    var AppName = commonObj.AppName();
    var Compprofile = commonObj.getCompanyProfile(User);
    var timeoutAlert = commonObj.ApplicationSessionTimeOutAlert();
    var onloadEvent = timeoutAlert == "true" ? "onload=initSession()".ToString() : "";

    var MainEntityValue = "All";
    if (User.MultiTenantLoginSelected != null && User.MultiTenantLoginSelected.Count() > 0)
    {
        MainEntityValue = User.MultiTenantLoginSelected[0].T_MainEntityValue;
    }
    var tenantSuffix = "";
    if (Compprofile.TenantId.HasValue && Compprofile.TenantId.Value > 0)
    {
        tenantSuffix = Convert.ToString(Compprofile.TenantId.Value);
    }
    var url = Url.Content("~/logo/logo" + tenantSuffix + ".gif");
    if (HttpContext.Current.Request.Url.Host == "localhost")
    { url = Url.Content("~/logo/logo" + tenantSuffix + ".gif"); }
    var AppIcon = url;
    var AppIconWidth = Compprofile.IconWidth == null ? "28px" : Compprofile.IconWidth;
    var AppIconHeight = Compprofile.IconHeight == null ? "28px" : Compprofile.IconHeight;

            
            #line default
            #line hidden
WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n\r\n<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" http-equiv=\"x-ua-compatible\"");

WriteLiteral(" content=\"IE=Edge\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1.0\"");

WriteLiteral(">\r\n    <title>");

            
            #line 35 "..\..\Views\Shared\_Layoutpwd.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("-");

            
            #line 35 "..\..\Views\Shared\_Layoutpwd.cshtml"
                     Write(AppName.ToString());

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n    <link");

WriteLiteral(" rel=\"icon\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1605), Tuple.Create("\"", 1640)
, Tuple.Create(Tuple.Create("", 1612), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/turanto.ico")
, 1612), false)
);

WriteLiteral(" type=\"image/x-icon\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"shortcut icon\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1693), Tuple.Create("\"", 1728)
, Tuple.Create(Tuple.Create("", 1700), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/turanto.ico")
, 1700), false)
);

WriteLiteral(" type=\"image/x-icon\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 38 "..\..\Views\Shared\_Layoutpwd.cshtml"
Write(Styles.Render("~/Content/css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1798), Tuple.Create("\"", 1869)
            
            #line 39 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 1805), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/" + commonObj.getTenantSiteScript(User))
            
            #line default
            #line hidden
, 1805), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

WriteLiteral("    ");

            
            #line 40 "..\..\Views\Shared\_Layoutpwd.cshtml"
Write(Styles.Render("~/Content/fontawesome"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 41 "..\..\Views\Shared\_Layoutpwd.cshtml"
Write(Styles.Render("~/Content/csstheme"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 42 "..\..\Views\Shared\_Layoutpwd.cshtml"
Write(Scripts.Render("~/bundles/modernizr"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2050), Tuple.Create("\"", 2102)
            
            #line 43 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 2056), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/jquery-1.10.2.min.js")
            
            #line default
            #line hidden
, 2056), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2149), Tuple.Create("\"", 2190)
            
            #line 44 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 2155), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/Entity.js")
            
            #line default
            #line hidden
, 2155), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2237), Tuple.Create("\"", 2265)
, Tuple.Create(Tuple.Create("", 2243), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery-ui.js")
, 2243), false)
);

WriteLiteral("></script>\r\n");

WriteLiteral("    ");

            
            #line 46 "..\..\Views\Shared\_Layoutpwd.cshtml"
Write(Scripts.Render("~/bundles/common1"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <!--[if IE 8]>\r\n            <link href=\"");

            
            #line 49 "..\..\Views\Shared\_Layoutpwd.cshtml"
                   Write(Url.Content("~/Content/IE8/ie8.css"));

            
            #line default
            #line hidden
WriteLiteral("\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <![endif]-->\r\n    <script>\r\n        va" +
"r isClose = false;\r\n        $(document).ready(function () {\r\n            $(windo" +
"w).resize(responsive);\r\n            $(window).trigger(\'resize\');\r\n            if" +
" (\'");

            
            #line 56 "..\..\Views\Shared\_Layoutpwd.cshtml"
            Write(ViewBag.ApplicationError);

            
            #line default
            #line hidden
WriteLiteral("\'.length > 0) {\r\n                //alert(\'");

            
            #line 57 "..\..\Views\Shared\_Layoutpwd.cshtml"
                    Write(ViewBag.ApplicationError);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n                $(\"#ErrMsg\").text(\'");

            
            #line 58 "..\..\Views\Shared\_Layoutpwd.cshtml"
                              Write(ViewBag.ApplicationError);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n                $(\"#ErrMsgQuickAdd\").text(\'");

            
            #line 59 "..\..\Views\Shared\_Layoutpwd.cshtml"
                                      Write(ViewBag.ApplicationError);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n\r\n                $(\"#divDisplayCodeFragment\").removeAttr(\"style\");\r\n       " +
"         $(\"#divDisplayCodeFragment\").html(getMsgTableCodeFragment());\r\n        " +
"        $(\"#ErrmsgtrCodeFragment\").text(\'");

            
            #line 63 "..\..\Views\Shared\_Layoutpwd.cshtml"
                                            Write(ViewBag.ApplicationError);

            
            #line default
            #line hidden
WriteLiteral(@"');
            }
        });
        $.ajaxSetup({
            beforeSend: function () {
                $('body').css({ 'cursor': 'wait' })

            },
            complete: function (xhr, status) {
                $('body').css({ 'cursor': 'default' });

                LoginRequired(xhr.status);
            }
        });

        function LoginRequired(response_data) {
            if (response_data == ""400"")
                window.location.href = """);

            
            #line 80 "..\..\Views\Shared\_Layoutpwd.cshtml"
                                   Write(Url.Action("Login","Account"));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n\r\n        }\r\n        function favorite() {\r\n            var thelink = \"");

            
            #line 84 "..\..\Views\Shared\_Layoutpwd.cshtml"
                      Write(Url.Action("FavoriteSave", "Home"));

            
            #line default
            #line hidden
WriteLiteral(@""";
            var data = $('#Favorite').val();
            $.ajax({
                url: thelink,
                cache: false,
                data: { Id: $('#hdnFavorite').val(), Name: $('#Favorite').val() },
                success: function (data) {
                    if (data == ""success"") {
                        $('.fa.fa-1x.fa-star').css('color', '#F90');
                        $('#liFavorite').addClass(""dropdown"").removeClass(""dropdown open"");
                    }
                    if (data == ""error"") {
                        $('.fa.fa-1x.fa-star').css('color', '#FFF');
                        $('#lblFavoriteSuceeess').addClass(""warning"").removeClass(""success"");
                        $('#lblFavoriteSuceeess').text(""Url not added in favourite."");
                    }
                }
            })
            return false;
        }
    </script>
    <script>
        $(function () {
            $("".limit"").each(function (i) {
                len = $(this).text().length;
                if (len > 2) {
                    $(this).text($(this).text().substr(0, 1));
                }
            });
        });

    </script>
</head>
<body");

WriteAttribute("id", Tuple.Create(" id=\"", 4929), Tuple.Create("\"", 4954)
            
            #line 117 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 4934), Tuple.Create<System.Object, System.Int32>(ViewBag.CurrentPage
            
            #line default
            #line hidden
, 4934), false)
);

WriteLiteral(" ");

            
            #line 117 "..\..\Views\Shared\_Layoutpwd.cshtml"
                           Write(onloadEvent);

            
            #line default
            #line hidden
WriteLiteral(" style=\"background-color:white;\">\r\n");

            
            #line 118 "..\..\Views\Shared\_Layoutpwd.cshtml"
    
            
            #line default
            #line hidden
            
            #line 118 "..\..\Views\Shared\_Layoutpwd.cshtml"
     if (commonObj.EnablePrototypingTool() == "true" && User.Identity.IsAuthenticated && User.CanAdd("ApplicationFeedback"))
    {
        var EntName = GeneratorBase.MVC.Controllers.BaseController.FavoriteUrlEntityName;
        var PageUrl = GeneratorBase.MVC.Controllers.BaseController.FavoriteUrl;
        string actionName = HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();
        var prototypeurl = Url.Action("CreateQuick", "ApplicationFeedback", new { EntityName = EntName, FieldName = "_FieldName", PageName = actionName, UIControlName = "_UIControlName", TS = DateTime.Now });

            
            #line default
            #line hidden
WriteLiteral("        <script");

WriteAttribute("src", Tuple.Create(" src=\"", 5644), Tuple.Create("\"", 5698)
            
            #line 124 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 5650), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/PrototypeCommenting.js")
            
            #line default
            #line hidden
, 5650), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n");

WriteLiteral("        <script>\r\n            document.onmousedown = function (e) {\r\n            " +
"    e = e || window.event;\r\n                if (e.which == 3) {\r\n               " +
"     PrototypeCommenting(\'");

            
            #line 129 "..\..\Views\Shared\_Layoutpwd.cshtml"
                                    Write(Html.Raw(prototypeurl));

            
            #line default
            #line hidden
WriteLiteral("\', isClose, e);\r\n                }\r\n            }\r\n        </script>\r\n");

            
            #line 133 "..\..\Views\Shared\_Layoutpwd.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"navbar navbar-inverse navbar-static-top\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"navbar-header\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"navbar-toggle\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-target=\".sidebar-collapse\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">Toggle navigation</span>\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                </button>\r\n                <img");

WriteAttribute("src", Tuple.Create(" src=\"", 6568), Tuple.Create("\"", 6582)
            
            #line 144 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 6574), Tuple.Create<System.Object, System.Int32>(AppIcon
            
            #line default
            #line hidden
, 6574), false)
);

WriteAttribute("style", Tuple.Create(" style=\"", 6583), Tuple.Create("\"", 6634)
, Tuple.Create(Tuple.Create("", 6591), Tuple.Create("width:", 6591), true)
            
            #line 144 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 6597), Tuple.Create<System.Object, System.Int32>(AppIconWidth
            
            #line default
            #line hidden
, 6597), false)
, Tuple.Create(Tuple.Create("", 6610), Tuple.Create(";", 6610), true)
, Tuple.Create(Tuple.Create(" ", 6611), Tuple.Create("height:", 6612), true)
            
            #line 144 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 6619), Tuple.Create<System.Object, System.Int32>(AppIconHeight
            
            #line default
            #line hidden
, 6619), false)
, Tuple.Create(Tuple.Create("", 6633), Tuple.Create(";", 6633), true)
);

WriteLiteral(" class=\"logoimg\"");

WriteLiteral(" />\r\n");

WriteLiteral("                ");

            
            #line 145 "..\..\Views\Shared\_Layoutpwd.cshtml"
           Write(Html.ActionLink(AppName.ToString(), "Index", "Home", null, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n\r\n    <div>\r\n        <div");

WriteLiteral(" class=\"container-fluid xyz\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n                    <br />\r\n");

WriteLiteral("                    ");

            
            #line 156 "..\..\Views\Shared\_Layoutpwd.cshtml"
               Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <br /> <br />\r\n                </div>\r\n            </div>\r\n" +
"        </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n");

            
            #line 164 "..\..\Views\Shared\_Layoutpwd.cshtml"
    
            
            #line default
            #line hidden
            
            #line 164 "..\..\Views\Shared\_Layoutpwd.cshtml"
     if (commonObj.IsPrivacyPolicy(User))
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" id=\"footer\"");

WriteLiteral(">\r\n            <footer");

WriteLiteral(" class=\"footer\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"text-muted pull-left\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 170 "..\..\Views\Shared\_Layoutpwd.cshtml"
                   Write(commonObj.CreatedBy(User));

            
            #line default
            #line hidden
WriteLiteral(" <a");

WriteAttribute("href", Tuple.Create(" href=\"", 7423), Tuple.Create("\"", 7460)
            
            #line 170 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 7430), Tuple.Create<System.Object, System.Int32>(commonObj.CreatedByLink(User)
            
            #line default
            #line hidden
, 7430), false)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">");

            
            #line 170 "..\..\Views\Shared\_Layoutpwd.cshtml"
                                                                                                       Write(commonObj.CreatedByName(User));

            
            #line default
            #line hidden
WriteLiteral("</a> |\r\n");

WriteLiteral("                        ");

            
            #line 171 "..\..\Views\Shared\_Layoutpwd.cshtml"
                   Write(commonObj.Emailto(User));

            
            #line default
            #line hidden
WriteLiteral(":<a");

WriteAttribute("href", Tuple.Create(" href=\"", 7567), Tuple.Create("\"", 7627)
            
            #line 171 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 7574), Tuple.Create<System.Object, System.Int32>(Html.Raw("mailto:" + commonObj.EmailtoAddress(User))
            
            #line default
            #line hidden
, 7574), false)
);

WriteLiteral(">");

            
            #line 171 "..\..\Views\Shared\_Layoutpwd.cshtml"
                                                                                                            Write(commonObj.EmailtoAddress(User));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    </span>\r\n                    <span");

WriteLiteral(" class=\"text-muted pull-right\"");

WriteLiteral(">\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 7779), Tuple.Create("\"", 7847)
            
            #line 174 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 7786), Tuple.Create<System.Object, System.Int32>(Html.Raw(commonObj.getBaseUri() + commonObj.LegalLink(User))
            
            #line default
            #line hidden
, 7786), false)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">");

            
            #line 174 "..\..\Views\Shared\_Layoutpwd.cshtml"
                                                                                                           Write(commonObj.Legal(User));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        | <a");

WriteAttribute("href", Tuple.Create(" href=\"", 7921), Tuple.Create("\"", 7989)
            
            #line 175 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 7928), Tuple.Create<System.Object, System.Int32>(Html.Raw(commonObj.getBaseUri() + commonObj.TermsLink(User))
            
            #line default
            #line hidden
, 7928), false)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 176 "..\..\Views\Shared\_Layoutpwd.cshtml"
                       Write(commonObj.Terms(User));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a> | <a");

WriteAttribute("href", Tuple.Create(" href=\"", 8094), Tuple.Create("\"", 8163)
            
            #line 177 "..\..\Views\Shared\_Layoutpwd.cshtml"
, Tuple.Create(Tuple.Create("", 8101), Tuple.Create<System.Object, System.Int32>(Html.Raw(commonObj.getBaseUri() + commonObj.PolicyLink(User))
            
            #line default
            #line hidden
, 8101), false)
);

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 178 "..\..\Views\Shared\_Layoutpwd.cshtml"
                       Write(commonObj.Policy(User));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n                    </span>\r\n                </di" +
"v>\r\n            </footer>\r\n        </div>\r\n");

            
            #line 184 "..\..\Views\Shared\_Layoutpwd.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" id=\"footer\"");

WriteLiteral(">\r\n            <ul");

WriteLiteral(" class=\"footer\"");

WriteLiteral(">\r\n                <li>Created With <a");

WriteLiteral(" href=\"http://www.turanto.com\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">Turanto</a></li>&nbsp;&nbsp; | &nbsp;&nbsp;\r\n                <li>Email:<a");

WriteLiteral(" href=\"mailto:contact@turanto.com\"");

WriteLiteral(">contact@turanto.com</a></li>\r\n            </ul>\r\n        </div>\r\n");

            
            #line 193 "..\..\Views\Shared\_Layoutpwd.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 194 "..\..\Views\Shared\_Layoutpwd.cshtml"
Write(Scripts.Render("~/bundles/bootstrap"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 195 "..\..\Views\Shared\_Layoutpwd.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 196 "..\..\Views\Shared\_Layoutpwd.cshtml"
Write(Scripts.Render("~/bundles/common2"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 197 "..\..\Views\Shared\_Layoutpwd.cshtml"
Write(Scripts.Render("~/bundles/common3"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 8887), Tuple.Create("\"", 8935)
, Tuple.Create(Tuple.Create("", 8893), Tuple.Create<System.Object, System.Int32>(Href("~/Content/dist/js/bootstrap-colorpicker.js")
, 8893), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 8959), Tuple.Create("\"", 8989)
, Tuple.Create(Tuple.Create("", 8965), Tuple.Create<System.Object, System.Int32>(Href("~/Content/src/js/docs.js")
, 8965), false)
);

WriteLiteral("></script>\r\n    <script");

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

    <script>

        document.onkeydown = checkKeycode
        function checkKeycode(e) {
            var keycode;
            if (window.event)
                keycode = window.event.keyCode;
            else if (e)
                keycode = e.which;
            if (keycode == 116) {
                isClose = true;
            }
        }
        function SetClose() {
            isClose = true;
        }
        function bodyUnload() {
            if (isClose == false) {
                var request = GetRequest();
                request.open(""GET"", """);

            
            #line 232 "..\..\Views\Shared\_Layoutpwd.cshtml"
                                Write(Url.Action("BrowserClose", "Account"));

            
            #line default
            #line hidden
WriteLiteral(@""", false);
                request.send();
            }
        }
        function GetRequest() {
            var xmlhttp;
            if (window.XMLHttpRequest) {
                xmlhttp = new XMLHttpRequest();
            }
            else {
                xmlhttp = new ActiveXObject(""Microsoft.XMLHTTP"");
            }
            return xmlhttp;
        }
    </script>
");

            
            #line 247 "..\..\Views\Shared\_Layoutpwd.cshtml"
    
            
            #line default
            #line hidden
            
            #line 247 "..\..\Views\Shared\_Layoutpwd.cshtml"
     if (timeoutAlert == "true")
    {
        var expirationMinutes = commonObj.ApplicationSessionTimeOut();

            
            #line default
            #line hidden
WriteLiteral("        <script>\r\n            var sess_expirationMinutes = parseInt(");

            
            #line 251 "..\..\Views\Shared\_Layoutpwd.cshtml"
                                             Write(expirationMinutes);

            
            #line default
            #line hidden
WriteLiteral(")\r\n            var sess_warningMinutes = sess_expirationMinutes - 5;\r\n           " +
" var sess_pollInterval = 60000;\r\n            if (sess_expirationMinutes <= 5)\r\n " +
"               sess_warningMinutes = sess_expirationMinutes - 1;\r\n\r\n        </sc" +
"ript>\r\n");

            
            #line 258 "..\..\Views\Shared\_Layoutpwd.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral(@"    <script>
        jQuery('body').on('focus', '.chosen-container-single input', function () {
            if (!jQuery(this).closest('.chosen-container').hasClass('chosen-container-active')) {
                jQuery(this).closest('.chosen-container').prev().trigger('chosen:open');
            }
        });
        $('.modal-dialog').draggable({
            handle: "".modal-title""
        });
    </script>
</body>
</html>");

        }
    }
}
#pragma warning restore 1591