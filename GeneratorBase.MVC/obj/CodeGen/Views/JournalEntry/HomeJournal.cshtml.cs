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

namespace GeneratorBase.MVC.Views.JournalEntry
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/JournalEntry/HomeJournal.cshtml")]
    public partial class HomeJournal : GeneratorBase.MVC.CustomWebViewPage<IEnumerable<GeneratorBase.MVC.Models.JournalEntry>>
    {
        public HomeJournal()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\JournalEntry\HomeJournal.cshtml"
 foreach (var item in Model)
{

            
            #line default
            #line hidden
WriteLiteral("    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 98), Tuple.Create("\"", 168)
            
            #line 4 "..\..\Views\JournalEntry\HomeJournal.cshtml"
, Tuple.Create(Tuple.Create("", 105), Tuple.Create<System.Object, System.Int32>(Url.Action("Edit", item.EntityName, new { id = item.RecordId})
            
            #line default
            #line hidden
, 105), false)
);

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"JournalList\"");

WriteLiteral(">\r\n                <h2");

WriteLiteral(" style=\"margin-top: 0px; color: #4083a9;\"");

WriteLiteral(">");

            
            #line 7 "..\..\Views\JournalEntry\HomeJournal.cshtml"
                                                        Write(Html.DisplayFor(modelItem => item.EntityName));

            
            #line default
            #line hidden
WriteLiteral("  <span");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(" style=\"color: #555; font-size: 12px; margin-top: 5px;\"");

WriteLiteral(">");

            
            #line 7 "..\..\Views\JournalEntry\HomeJournal.cshtml"
                                                                                                                                                                                        Write(Html.DisplayFor(modelItem => item.DateTimeOfEntry));

            
            #line default
            #line hidden
WriteLiteral("</span></h2>\r\n                <span");

WriteLiteral(" class=\"label label-default\"");

WriteLiteral(" style=\"font-size:11px;\"");

WriteLiteral(">");

            
            #line 8 "..\..\Views\JournalEntry\HomeJournal.cshtml"
                                                                     Write(Html.DisplayFor(modelItem => item.Type));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                <span>\r\n                    RecordInfo <span");

WriteLiteral(" class=\"fontcolor\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\JournalEntry\HomeJournal.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.RecordInfo));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    PropertyName - <span");

WriteLiteral(" class=\"fontcolor\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\JournalEntry\HomeJournal.cshtml"
                                                      Write(Html.DisplayFor(modelItem => item.PropertyName));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    Old Value <span");

WriteLiteral(" class=\"fontcolor\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\JournalEntry\HomeJournal.cshtml"
                                                 Write(Html.DisplayFor(modelItem => item.OldValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    New Value - <span");

WriteLiteral(" class=\"fontcolor\"");

WriteLiteral(">");

            
            #line 13 "..\..\Views\JournalEntry\HomeJournal.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.NewValue));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                </span>\r\n            </div>\r\n            <!-- List group" +
" -->\r\n        </div>\r\n    </a>\r\n");

            
            #line 19 "..\..\Views\JournalEntry\HomeJournal.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
