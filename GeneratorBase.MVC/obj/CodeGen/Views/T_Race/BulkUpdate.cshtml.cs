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

namespace GeneratorBase.MVC.Views.T_Race
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_Race/BulkUpdate.cshtml")]
    public partial class BulkUpdate : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.T_Race>
    {
        public BulkUpdate()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\T_Race\BulkUpdate.cshtml"
  
 ViewBag.Title = "Bulk Update Race";
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        try {\r\n            var h" +
"ostingEntityName = \"\";\r\n            if (\'");

            
            #line 10 "..\..\Views\T_Race\BulkUpdate.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\' != null) {\r\n                hostingEntityName = \'");

            
            #line 11 "..\..\Views\T_Race\BulkUpdate.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral(@"';
                 $('#' + hostingEntityName + 'ID').attr(""lock"",""true"");
            }
        }
        catch (ex) { }
    });
</script>
<script>
    $(document).ready(function () {
        $('.form-control:input').change(function () {
            var $this = $(this);
            $(""input[type=checkbox][value="" + $this.attr('id') + ""]"").prop(""checked"", $this.val() != '' ? true : false);

            var ChildDDids = $this.attr('ChildDDids');
            if (ChildDDids != undefined) {
                var ids = ChildDDids.split("","");
                for (var i = 0; i < ids.length; i++) {
                    $(""input[type=checkbox][value="" + ids[i] + ""]"").prop(""checked"", $this.val() != '' ? true : false);
                }
               
            }
        })
    });
</script>
<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1187), Tuple.Create("\"", 1236)
, Tuple.Create(Tuple.Create("", 1194), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap-datetimepicker.min.css")
, 1194), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 1264), Tuple.Create("\"", 1307)
            
            #line 36 "..\..\Views\T_Race\BulkUpdate.cshtml"
, Tuple.Create(Tuple.Create("", 1271), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/chosen.css")
            
            #line default
            #line hidden
, 1271), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n");

            
            #line 37 "..\..\Views\T_Race\BulkUpdate.cshtml"
 using (Html.BeginForm("BulkUpdate", "T_Race", new { UrlReferrer = Convert.ToString(ViewData["T_RaceParentUrl"]), IsDDAdd = ViewBag.IsDDAdd }, FormMethod.Post, new { enctype = "multipart/form-data" }))
{
   
            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\T_Race\BulkUpdate.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\T_Race\BulkUpdate.cshtml"
                           ;
   
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\T_Race\BulkUpdate.cshtml"
Write(Html.Hidden("BulkUpdate", (object)ViewBag.BulkUpdate));

            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\T_Race\BulkUpdate.cshtml"
                                                         ;

            
            #line default
            #line hidden
WriteLiteral("\t<div");

WriteLiteral(" class=\"alert alert-info\"");

WriteLiteral(" style=\"margin-top:-10px;\"");

WriteLiteral(@">
        <strong>Warning!</strong> This action updates all the selected records in this list.
        Select the desired properties using check boxes in the pop-up window.
        This is an irreversible action, which results in modification of all the selected properties.
        If you want to proceed with the action on the selected records, click ""Update"".
    </div>
");

WriteLiteral("\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default AppForm\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                   <table");

WriteLiteral(" class=\"table table-striped table-bordered table-hover table-condensed\"");

WriteLiteral(@">
                        <thead>
                            <tr>
                                <th>Update</th>
                                <th>Property</th>
                                <th>Set Value</th>
                            </tr>
							                        </thead>
                    </table>
 </div> 
 </div>
  </div>
   </div>
");

WriteLiteral("   <button");

WriteLiteral(" id=\"CancelQuickAdd\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">Cancel</button>\r\n");

            
            #line 65 "..\..\Views\T_Race\BulkUpdate.cshtml"
    if (ViewBag.IsDDAdd == null && User.CanEdit("T_Race"))
    {

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Update\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" />\r\n");

            
            #line 68 "..\..\Views\T_Race\BulkUpdate.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    <br />");

WriteLiteral("<br />\r\n");

            
            #line 70 "..\..\Views\T_Race\BulkUpdate.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 3027), Tuple.Create("\"", 3067)
, Tuple.Create(Tuple.Create("", 3033), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Common3/chosen.jquery.js")
, 3033), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n<script");

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
    $(function () {
        var userAgent = navigator.userAgent.toLowerCase();
        // Figure out what browser is being used
        var browser = {
            version: (userAgent.match(/.+(?:rv|it|ra|ie)[\/: ]([\d.]+)/) || [])[1],
            safari: /webkit/.test(userAgent),
            opera: /opera/.test(userAgent),
            msie: /msie/.test(userAgent) && !/opera/.test(userAgent),
            mozilla: /mozilla/.test(userAgent) && !/(compatible|webkit)/.test(userAgent)
        };
        if (!browser.msie) {
            $('form').areYouSure();
        }
        else if (browser.version > 8.0) {
            $('form').areYouSure();
        }
    });
</script>
  
");

        }
    }
}
#pragma warning restore 1591
