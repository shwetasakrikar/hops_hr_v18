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

namespace GeneratorBase.MVC.Views.Preload
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Preload/Index.cshtml")]
    public partial class Index : GeneratorBase.MVC.CustomWebViewPage<dynamic>
    {
        public Index()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\Preload\Index.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width\"");

WriteLiteral(" />\r\n    <title>Loading</title>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 158), Tuple.Create("\"", 210)
            
            #line 9 "..\..\Views\Preload\Index.cshtml"
, Tuple.Create(Tuple.Create("", 164), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Scripts/jquery-1.10.2.min.js")
            
            #line default
            #line hidden
, 164), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $(document).ready(function () {\r\n            $.get(\"");

            
            #line 12 "..\..\Views\Preload\Index.cshtml"
              Write(Url.Action("Start", "Preload"));

            
            #line default
            #line hidden
WriteLiteral(@""")
            .done(function () {
                if (window.location.search.substring(0) == ""?Android=1&Android=1"" || window.location.search.substring(0) == ""?Android=1"") {
                    window.localStorage.setItem(""fromapk"", ""true"");
                }
                else
                    window.localStorage.setItem(""fromapk"", ""false"");
                window.location.replace(""");

            
            #line 19 "..\..\Views\Preload\Index.cshtml"
                                    Write(Url.Action("Index", "Home"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n            })\r\n            .fail(function () {\r\n                alert(\"Oops" +
", something went wrong.\");\r\n            });\r\n        });\r\n    </script>\r\n    <sc" +
"ript");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $.fn.preload = function () {\r\n            this.each(function () {\r\n   " +
"             $(\'<img/>\')[0].src = this;\r\n            });\r\n        }\r\n        // " +
"pre-cache icons\r\n        $([\'");

            
            #line 33 "..\..\Views\Preload\Index.cshtml"
       Write(Url.Content("~/Content/images/famfamfam-icons.png"));

            
            #line default
            #line hidden
WriteLiteral("\'\r\n        ]).preload();\r\n    </script>\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1281), Tuple.Create("\"", 1309)
, Tuple.Create(Tuple.Create("", 1288), Tuple.Create<System.Object, System.Int32>(Href("~/Content/loading.css")
, 1288), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(@" />
    <script>
        $(function () {
            $("".meter > span"").each(function () {
                $(this)
					.data(""origWidth"", $(this).width())
					.width(0)
					.animate({
					    width: $(this).data(""origWidth"")
					}, 1200);
            });
        });
    </script>
</head>
<body>
    <div");

WriteLiteral(" style=\"margin: auto; text-align: center; background-color: #edf5fa; padding: 20p" +
"x; border: 1px solid #c3ddec; margin:60px 20px 10px 20px; \"");

WriteLiteral(">\r\n        <h1>Please wait, Application is loading...</h1>\r\n        <div");

WriteLiteral(" class=\"meter red\"");

WriteLiteral(">\r\n            <span");

WriteLiteral(" style=\"width:%\"");

WriteLiteral("></span>\r\n        </div>\r\n        <pre><code></code></pre>\r\n    </div>\r\n</body>\r\n" +
"</html>\r\n");

        }
    }
}
#pragma warning restore 1591
