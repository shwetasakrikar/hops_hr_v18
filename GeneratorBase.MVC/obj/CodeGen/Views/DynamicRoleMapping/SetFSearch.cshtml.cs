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

namespace GeneratorBase.MVC.Views.DynamicRoleMapping
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DynamicRoleMapping/SetFSearch.cshtml")]
    public partial class SetFSearch : GeneratorBase.MVC.CustomWebViewPage<IEnumerable<GeneratorBase.MVC.Models.DynamicRoleMapping>>
    {
        public SetFSearch()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
  
    ViewBag.Title = "Set Search Criteria";
	var parentUrl = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);

            
            #line default
            #line hidden
WriteLiteral(@"
<script>
    function keypressHandler(e) {
        if (e.which == 13) {
            $(this).blur();
            $('#fSearchDynamicRoleMapping').focus().click();
        }
    }
 $(document).keypress(keypressHandler);
 $(document).ready(function () {
  if (""");

            
            #line 15 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
  Write(parentUrl);

            
            #line default
            #line hidden
WriteLiteral("\".length > 0) {\r\n\t\t\t document.getElementById(\"FSearch\").value = \"");

            
            #line 16 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                                                    Write(parentUrl["search"]);

            
            #line default
            #line hidden
WriteLiteral("\";\r\ndocument.getElementById(\"Flag\").value = \"");

            
            #line 17 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                                    Write(parentUrl["Flag"]);

            
            #line default
            #line hidden
WriteLiteral("\";\r\n }\r\n    });\r\n</script>\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-search text-primary\"");

WriteLiteral("></i> DynamicRoleMapping <i");

WriteLiteral(" class=\"glyphicon glyphicon-chevron-right small\"");

WriteLiteral("></i> <span>Faceted Search</span>\r\n        </h1>\r\n    </div>\r\n    <!-- /.col-lg-1" +
"2 -->\r\n</div>\r\n\t\t\t <div");

WriteLiteral(" class=\"fsearch\"");

WriteLiteral(">\r\n\t\t\t\t<div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n\t\t\t\t\t\t   <div");

WriteLiteral(" class=\"panel-body fsearchbg\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\'col-sm-9 small\'");

WriteLiteral(">\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-4\'");

WriteLiteral(">\r\n                                    <label");

WriteLiteral(" class=\'col-sm-12\'");

WriteLiteral("> General Criteria </label>\r\n");

            
            #line 35 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
									
            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                                      
									var txtGenCriteria = String.IsNullOrEmpty(Convert.ToString(ViewBag.CurrentFilter)) ? "" : Convert.ToString(ViewBag.CurrentFilter);
									
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"FSearch\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"General Criteria\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1504), Tuple.Create("\"", 1527)
            
            #line 38 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                                               , Tuple.Create(Tuple.Create("", 1512), Tuple.Create<System.Object, System.Int32>(txtGenCriteria
            
            #line default
            #line hidden
, 1512), false)
);

WriteLiteral(" />\r\n                             </div>\r\n\t\t\t<div");

WriteLiteral(" class=\'col-sm-4\'");

WriteLiteral(" style=\"height:55px;\"");

WriteLiteral(">\r\n                                    <label");

WriteLiteral(" class=\'col-sm-12\'");

WriteLiteral("> Flag </label>\r\n                                       <select");

WriteLiteral(" id=\"Flag\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                        <option");

WriteLiteral(" value=\"All\"");

WriteLiteral(">All</option>\r\n                                        <option");

WriteLiteral(" value=\"true\"");

WriteLiteral(">true</option>\r\n                                        <option");

WriteLiteral(" value=\"false\"");

WriteLiteral(">false</option>\r\n                                    </select>\r\n\t\t\t</div>\r\n\t\t\t\t\t " +
"</div>\r\n\t\t<div");

WriteLiteral(" class=\'col-sm-3\'");

WriteLiteral(" style=\"padding:10px; background:white; border:1px solid #c3ddec !important\"");

WriteLiteral(">\r\n");

            
            #line 50 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                
            
            #line default
            #line hidden
            
            #line 50 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                 if ( User.CanView("DynamicRoleMapping"))
                { 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<button");

WriteLiteral(" class=\"btn btn-xs  btn-default tip-top pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-original-title=\"Full Add\"");

WriteLiteral(" data-placement=\"top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 2385), Tuple.Create("", 2474)
            
            #line 52 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                                                                         , Tuple.Create(Tuple.Create("", 2394), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Index", "DynamicRoleMapping") + "');")
            
            #line default
            #line hidden
, 2394), false)
);

WriteLiteral(" style=\"padding:4px 10px 7px 10px; height:30px !important; margin-bottom:5px; wid" +
"th:100%; text-align:left;\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-list\"");

WriteLiteral("></span> List\r\n\t\t\t\t\t</button>\r\n");

            
            #line 55 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t");

            
            #line 56 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                 if ( User.CanAdd("DynamicRoleMapping"))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <button");

WriteLiteral(" class=\"btn btn-xs  btn-default tip-top\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-original-title=\"Create New\"");

WriteLiteral(" data-placement=\"top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 2866), Tuple.Create("", 3172)
            
            #line 58 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                                                                , Tuple.Create(Tuple.Create("", 2875), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "DynamicRoleMapping", new { UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null) + "');")
            
            #line default
            #line hidden
, 2875), false)
);

WriteLiteral(" style=\"padding:4px 10px 7px 10px; height:30px !important; margin-bottom:5px; wid" +
"th:100%; text-align:left;\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"fam-world-add\"");

WriteLiteral("></span> Create New\r\n                    </button>\r\n");

            
            #line 61 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\t\t");

            
            #line 62 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
         if (ViewBag.FavoriteItem != null)
        {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div");

WriteLiteral(" class=\"col-lg-12 col-sm-12 col-sx-12\"");

WriteLiteral(" style=\"padding:0px; \"");

WriteLiteral(">\r\n                    <table");

WriteLiteral(" class=\"table table-striped table-bordered table-hover table-condensed \"");

WriteLiteral(">\r\n                        <thead>\r\n                            <tr>\r\n           " +
"                     <th");

WriteLiteral(" colspan=\"2\"");

WriteLiteral(">Favorite Items</th>\r\n                            </tr>\r\n                        " +
"</thead>\r\n");

            
            #line 71 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 71 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                         foreach (GeneratorBase.MVC.Models.FavoriteItem fItem in ViewBag.FavoriteItem)
                        {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t<tr>\r\n                            <td>\r\n                                <a");

WriteAttribute("href", Tuple.Create(" href=\'", 4041), Tuple.Create("\'", 4136)
, Tuple.Create(Tuple.Create("", 4048), Tuple.Create("/", 4048), true)
            
            #line 75 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 4049), Tuple.Create<System.Object, System.Int32>(GeneratorBase.MVC.Models.CommonFunction.Instance.AppURL().ToString()
            
            #line default
            #line hidden
, 4049), false)
            
            #line 75 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                               , Tuple.Create(Tuple.Create("", 4118), Tuple.Create<System.Object, System.Int32>(fItem.LinkAddress
            
            #line default
            #line hidden
, 4118), false)
);

WriteLiteral(" style=\"color:black\"");

WriteLiteral(">");

            
            #line 75 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                                                                                                                                                  Write(fItem.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                            </td>\r\n                        </tr>           " +
"                \r\n");

            
            #line 78 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                </table>\r\n            </div>\r\n");

            
            #line 81 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n\t\t\t\t\t  </div>\r\n                                        </div>" +
"\r\n                                    </div>\r\n   <a");

WriteAttribute("href", Tuple.Create(" href=\"", 4484), Tuple.Create("\"", 4511)
            
            #line 86 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 4491), Tuple.Create<System.Object, System.Int32>(Url.Action("Index")
            
            #line default
            #line hidden
, 4491), false)
);

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral("> Cancel</a>\r\n<button");

WriteLiteral(" id=\"fSearchDynamicRoleMapping\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" type=\"button\"");

WriteAttribute("dataurl", Tuple.Create(" dataurl=\"", 4640), Tuple.Create("\"", 4703)
            
            #line 87 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
              , Tuple.Create(Tuple.Create("", 4650), Tuple.Create<System.Object, System.Int32>(Url.Action("FSearch", "DynamicRoleMapping", null) 
            
            #line default
            #line hidden
, 4650), false)
);

WriteAttribute("onclick", Tuple.Create("\r\n        onclick=\"", 4704), Tuple.Create("\"", 4919)
            
            #line 88 "..\..\Views\DynamicRoleMapping\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 4723), Tuple.Create<System.Object, System.Int32>(Html.Raw("FacetedSearch('DynamicRoleMapping','','Flag','"
    +  Convert.ToString(Request.QueryString["sortBy"]) +"','"
     + Convert.ToString(Request.QueryString["isAsc"]) + "','" + "'); ")
            
            #line default
            #line hidden
, 4723), false)
);

WriteLiteral(">\r\n    Search\r\n</button>\r\n<script>\r\n    $(document).ready(function () {\r\n    });\r" +
"\n</script>\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
