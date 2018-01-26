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

namespace GeneratorBase.MVC.Views.PropertyMapping
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/PropertyMapping/SetFSearch.cshtml")]
    public partial class SetFSearch : GeneratorBase.MVC.CustomWebViewPage<IEnumerable<GeneratorBase.MVC.Models.PropertyMapping>>
    {
        public SetFSearch()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
  
    ViewBag.Title = "Set Search Criteria";
	var parentUrl = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);

            
            #line default
            #line hidden
WriteLiteral(@"
<script>
    function keypressHandler(e) {
        if (e.which == 13) {
            $(this).blur();
            $('#fSearchPropertyMapping').focus().click();
        }
    }
 $(document).keypress(keypressHandler);
 $(document).ready(function () {
  if (""");

            
            #line 15 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
  Write(parentUrl);

            
            #line default
            #line hidden
WriteLiteral("\".length > 0) {\r\n\t\t\t document.getElementById(\"FSearch\").value = \"");

            
            #line 16 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                                                    Write(parentUrl["search"]);

            
            #line default
            #line hidden
WriteLiteral("\";\r\n if (\"");

            
            #line 17 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
 Write(parentUrl["entitypropertymapping"]);

            
            #line default
            #line hidden
WriteLiteral("\" != null && \"");

            
            #line 17 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                                                  Write(parentUrl["entitypropertymapping"]);

            
            #line default
            #line hidden
WriteLiteral("\".length > 0) {\r\n            var resEntityPropertyMapping = \"");

            
            #line 18 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                                       Write(parentUrl["entitypropertymapping"]);

            
            #line default
            #line hidden
WriteLiteral(@""".split("","");
            var eleEntityPropertyMapping = document.getElementById(""entitypropertymapping"");
            for (i = 0; i < resEntityPropertyMapping.length; i++) {
                for (var o = 0; o < eleEntityPropertyMapping.options.length; o++) {
                    if (eleEntityPropertyMapping.options[o].value == resEntityPropertyMapping[i])
                        eleEntityPropertyMapping.options[o].selected = true;
                }
            }
	}
 }
    });
</script>
<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"page-title\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"glyphicon glyphicon-search text-primary\"");

WriteLiteral("></i> Property Mapping <i");

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

            
            #line 44 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
									
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                                      
									var txtGenCriteria = String.IsNullOrEmpty(Convert.ToString(ViewBag.CurrentFilter)) ? "" : Convert.ToString(ViewBag.CurrentFilter);
									
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"FSearch\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"General Criteria\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2097), Tuple.Create("\"", 2120)
            
            #line 47 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                                               , Tuple.Create(Tuple.Create("", 2105), Tuple.Create<System.Object, System.Int32>(txtGenCriteria
            
            #line default
            #line hidden
, 2105), false)
);

WriteLiteral(" />\r\n                             </div>\r\n");

            
            #line 49 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
    
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
     if (ViewBag.entitypropertymapping!=null)
	{ 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-4\'");

WriteLiteral(" style=\"height:55px;\"");

WriteLiteral(" >\r\n                                    <label");

WriteLiteral(" class=\'col-sm-12\'");

WriteLiteral(" for=\"entitypropertymapping\"");

WriteLiteral("> Entity Data Source</label>\r\n\t\t\r\n");

WriteLiteral("\t ");

            
            #line 54 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
Write(Html.DropDownList("entitypropertymapping", null, new {   @multiple = "multiple", @HostingName = "EntityDataSource", @dataurl = Url.Action("GetAllMultiSelectValue", "EntityDataSource",null) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t</div>\r\n");

            
            #line 56 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("  \r\n\t\t\t\t\t </div>\r\n\t\t<div");

WriteLiteral(" class=\'col-sm-3\'");

WriteLiteral(" style=\"padding:10px; background:white; border:1px solid #c3ddec !important\"");

WriteLiteral(">\r\n");

            
            #line 60 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                 if ( User.CanView("PropertyMapping"))
                { 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<button");

WriteLiteral(" class=\"btn btn-xs  btn-default tip-top pull-right\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-original-title=\"Full Add\"");

WriteLiteral(" data-placement=\"top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 2930), Tuple.Create("", 3016)
            
            #line 62 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                                                                         , Tuple.Create(Tuple.Create("", 2939), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Index", "PropertyMapping") + "');")
            
            #line default
            #line hidden
, 2939), false)
);

WriteLiteral(" style=\"padding:4px 10px 7px 10px; height:30px !important; margin-bottom:5px; wid" +
"th:100%; text-align:left;\"");

WriteLiteral(">\r\n\t\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-list\"");

WriteLiteral("></span> List\r\n\t\t\t\t\t</button>\r\n");

            
            #line 65 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t");

            
            #line 66 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                 if ( User.CanAdd("PropertyMapping"))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <button");

WriteLiteral(" class=\"btn btn-xs  btn-default tip-top\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-original-title=\"Create New\"");

WriteLiteral(" data-placement=\"top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 3405), Tuple.Create("", 3708)
            
            #line 68 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                                                                , Tuple.Create(Tuple.Create("", 3414), Tuple.Create<System.Object, System.Int32>(Html.Raw("NavigateToUrl('" + Url.Action("Create", "PropertyMapping", new { UrlReferrer = Request.Url, AssociatedType=ViewData["AssociatedType"], HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]) }, null) + "');")
            
            #line default
            #line hidden
, 3414), false)
);

WriteLiteral(" style=\"padding:4px 10px 7px 10px; height:30px !important; margin-bottom:5px; wid" +
"th:100%; text-align:left;\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"fam-world-add\"");

WriteLiteral("></span> Create New\r\n                    </button>\r\n");

            
            #line 71 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t <button");

WriteLiteral(" class=\"btn btn-default tip-top\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" data-original-title=\"Show Graph\"");

WriteLiteral(" style=\"padding:4px 10px 7px 10px; height:30px !important; margin-bottom:5px; wid" +
"th:100%; text-align:left;\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" data-target=\"#ShowGraphPropertyMapping\"");

WriteAttribute("onclick", Tuple.Create(" onclick=", 4205), Tuple.Create("", 4271)
            
            #line 72 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                                                                                                                                                                                                              , Tuple.Create(Tuple.Create("", 4214), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenDashBoard('dvShowGraphPropertyMapping');")
            
            #line default
            #line hidden
, 4214), false)
);

WriteLiteral(">\r\n                                <span");

WriteLiteral(" class=\"fam-chart-bar\"");

WriteLiteral("></span> Dashboard\r\n                 </button>\r\n");

            
            #line 75 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
		
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
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

            
            #line 84 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 84 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                         foreach (GeneratorBase.MVC.Models.FavoriteItem fItem in ViewBag.FavoriteItem)
                        {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t<tr>\r\n                            <td>\r\n                                <a");

WriteAttribute("href", Tuple.Create(" href=\'", 5018), Tuple.Create("\'", 5113)
, Tuple.Create(Tuple.Create("", 5025), Tuple.Create("/", 5025), true)
            
            #line 88 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 5026), Tuple.Create<System.Object, System.Int32>(GeneratorBase.MVC.Models.CommonFunction.Instance.AppURL().ToString()
            
            #line default
            #line hidden
, 5026), false)
            
            #line 88 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                               , Tuple.Create(Tuple.Create("", 5095), Tuple.Create<System.Object, System.Int32>(fItem.LinkAddress
            
            #line default
            #line hidden
, 5095), false)
);

WriteLiteral(">");

            
            #line 88 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                                                                                                                              Write(fItem.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                            </td>\r\n                        </tr>           " +
"                \r\n");

            
            #line 91 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                </table>\r\n            </div>\r\n");

            
            #line 94 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n\t\t\t\t\t  </div>\r\n                                        </div>" +
"\r\n                                    </div>\r\n   <a");

WriteAttribute("href", Tuple.Create(" href=\"", 5441), Tuple.Create("\"", 5468)
            
            #line 99 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 5448), Tuple.Create<System.Object, System.Int32>(Url.Action("Index")
            
            #line default
            #line hidden
, 5448), false)
);

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral("> Cancel</a>\r\n<button");

WriteLiteral(" id=\"fSearchPropertyMapping\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" type=\"button\"");

WriteAttribute("dataurl", Tuple.Create(" dataurl=\"", 5594), Tuple.Create("\"", 5654)
            
            #line 100 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
           , Tuple.Create(Tuple.Create("", 5604), Tuple.Create<System.Object, System.Int32>(Url.Action("FSearch", "PropertyMapping", null) 
            
            #line default
            #line hidden
, 5604), false)
);

WriteAttribute("onclick", Tuple.Create("\r\n        onclick=\"", 5655), Tuple.Create("\"", 5884)
            
            #line 101 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
, Tuple.Create(Tuple.Create("", 5674), Tuple.Create<System.Object, System.Int32>(Html.Raw("FacetedSearch('PropertyMapping','entitypropertymapping','','"
    +  Convert.ToString(Request.QueryString["sortBy"]) +"','"
     + Convert.ToString(Request.QueryString["isAsc"]) + "','" + "'); ")
            
            #line default
            #line hidden
, 5674), false)
);

WriteLiteral(">\r\n    Search\r\n</button>\r\n<script>\r\n    $(document).ready(function () {\r\n\t $(\'#en" +
"titypropertymapping\').multiselect({\r\n            buttonWidth: \'100%\'\r\n        })" +
";\r\n    });\r\n</script>\r\n    <div");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" id=\"ShowGraphPropertyMapping\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" role=\"dialog\"");

WriteLiteral(" aria-labelledby=\"ShowGraphPropertyMappingLabel\"");

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

WriteLiteral(" id=\"ShowGraphPropertyMappingLabel\"");

WriteLiteral(">Dashboard Property Mapping</h4>\r\n                </div>\r\n                <div");

WriteLiteral(" id=\"dvShowGraphPropertyMapping\"");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(" data-url=\"");

            
            #line 120 "..\..\Views\PropertyMapping\SetFSearch.cshtml"
                                                                             Write(Url.Action("ShowGraph", "PropertyMapping"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591