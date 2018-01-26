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

namespace GeneratorBase.MVC.Views.Chart
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Chart/IndexPartial.cshtml")]
    public partial class IndexPartial : GeneratorBase.MVC.CustomWebViewPage<IEnumerable<GeneratorBase.MVC.Models.T_Chart>>
    {
        public IndexPartial()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" id=\"T_Chart\"");

WriteLiteral(">\r\n    <button");

WriteLiteral(" id=\"T_ChartSearchCancel\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" hidden");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 131), Tuple.Create("\"", 281)
, Tuple.Create(Tuple.Create("", 141), Tuple.Create("CancelSearch(\'T_Chart\',\'", 141), true)
            
            #line 3 "..\..\Views\Chart\IndexPartial.cshtml"
            , Tuple.Create(Tuple.Create("", 165), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "Chart", new { ClearSearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 165), false)
, Tuple.Create(Tuple.Create("", 249), Tuple.Create("\',\'", 249), true)
            
            #line 3 "..\..\Views\Chart\IndexPartial.cshtml"
                                                                                                   , Tuple.Create(Tuple.Create("", 252), Tuple.Create<System.Object, System.Int32>(User.JavaScriptEncodedName
            
            #line default
            #line hidden
, 252), false)
, Tuple.Create(Tuple.Create("", 279), Tuple.Create("\')", 279), true)
);

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral("></button>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(" style=\"margin-top: 5px;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(" style=\"padding: 6px 5px; \"");

WriteLiteral(">\r\n                    <h4");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral(">Charts List</h4>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"Des_Table\"");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(" style=\"overflow-x:auto;\"");

WriteLiteral(">\r\n                        <table");

WriteLiteral(" class=\"table table-bordered table-hover table-condensed\"");

WriteLiteral(">\r\n                            <thead>\r\n                                <tr>\r\n   " +
"                                 <th");

WriteLiteral(" class=\"col1\"");

WriteLiteral(" style=\"width:70px;\"");

WriteLiteral(">Actions</th>\r\n                                    <th");

WriteLiteral(" style=\"width:25%\"");

WriteLiteral(">Entity Name</th>\r\n                                    <th");

WriteLiteral(" style=\"width:35%\"");

WriteLiteral(">Chart Title</th>\r\n                                    <th");

WriteLiteral(" style=\"width:auto\"");

WriteLiteral(">Chart Type</th>\r\n                                    <th");

WriteLiteral(" style=\"width:auto\"");

WriteLiteral(">Show In Dashboard</th>\r\n                                </tr>\r\n                 " +
"           </thead>\r\n\r\n");

            
            #line 23 "..\..\Views\Chart\IndexPartial.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Chart\IndexPartial.cshtml"
                             foreach (var item in Model)
                            {
                                var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == item.EntityName);
                                var entityDP = item.EntityName;
                                if (entity != null)
                                {
                                    entityDP = entity.DisplayName;
                                }


            
            #line default
            #line hidden
WriteLiteral("                                <tr>\r\n                                    <td>\r\n\r" +
"\n                                        <div");

WriteLiteral(" style=\"width:60px; margin-top:-2px;\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(" style=\"position:absolute;\"");

WriteLiteral(">\r\n                                                <button");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" class=\"btn btn-xs dropdown-toggle btn-default\"");

WriteLiteral(">\r\n                                                    Action\r\n                  " +
"                                  <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span>\r\n                                                </button>\r\n            " +
"                                    <ul");

WriteLiteral(" class=\"dropdown-menu pull-left\"");

WriteLiteral(">\r\n                                                    <li>\r\n");

            
            #line 43 "..\..\Views\Chart\IndexPartial.cshtml"
                                                        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\Chart\IndexPartial.cshtml"
                                                         if (User.CanEdit("T_Chart"))
                                                        {

            
            #line default
            #line hidden
WriteLiteral("                                                            <a");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2889), Tuple.Create("\"", 3080)
            
            #line 45 "..\..\Views\Chart\IndexPartial.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 2899), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Edit Application Chart','dvPopup','" + Url.Action("Edit", "Chart", new { id = item.Id, UrlReferrer = Request.Url, TS = DateTime.Now }) + "')")
            
            #line default
            #line hidden
, 2899), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-edit\"");

WriteLiteral("></i>  Edit</a>\r\n");

            
            #line 46 "..\..\Views\Chart\IndexPartial.cshtml"
                                                        }

            
            #line default
            #line hidden
WriteLiteral("                                                    </li>\r\n                      " +
"                              <li>\r\n");

            
            #line 49 "..\..\Views\Chart\IndexPartial.cshtml"
                                                        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Views\Chart\IndexPartial.cshtml"
                                                         if (User.CanDelete("T_Chart"))
                                                        {

            
            #line default
            #line hidden
WriteLiteral("                                                            <a");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3584), Tuple.Create("\"", 3779)
            
            #line 51 "..\..\Views\Chart\IndexPartial.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 3594), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Delete Application Chart','dvPopup','" + Url.Action("Delete", "Chart", new { id = item.Id, UrlReferrer = Request.Url, TS = DateTime.Now }) + "')")
            
            #line default
            #line hidden
, 3594), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove-sign\"");

WriteLiteral("></i>  Delete</a>\r\n");

            
            #line 52 "..\..\Views\Chart\IndexPartial.cshtml"
                                                        }

            
            #line default
            #line hidden
WriteLiteral(@"                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </td>
                                    <td>");

            
            #line 58 "..\..\Views\Chart\IndexPartial.cshtml"
                                   Write(entityDP);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                    <td>");

            
            #line 59 "..\..\Views\Chart\IndexPartial.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ChartTitle));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                    <td>");

            
            #line 60 "..\..\Views\Chart\IndexPartial.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ChartType));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                    <td>");

            
            #line 61 "..\..\Views\Chart\IndexPartial.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ShowInDashBoard));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                </tr>\r\n");

            
            #line 63 "..\..\Views\Chart\IndexPartial.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </table>\r\n                    </div>\r\n                </d" +
"iv>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
