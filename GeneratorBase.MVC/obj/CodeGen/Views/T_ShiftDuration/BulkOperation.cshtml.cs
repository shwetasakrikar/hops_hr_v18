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

namespace GeneratorBase.MVC.Views.T_ShiftDuration
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
    
    #line 2 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_ShiftDuration/BulkOperation.cshtml")]
    public partial class BulkOperation : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.T_ShiftDuration>>
    {
        
        #line 97 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                    
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
                        HostingEntity = @Convert.ToString(ViewData["HostingEntity"]),
                        AssociatedType = @Convert.ToString(ViewData["AssociatedType"]),
                        HostingEntityID = ViewData["HostingEntityID"],
                        IsExport = IsExport,
                        FSFilter = ViewBag.FSFilter == null ? "Fsearch" : ViewBag.FSFilter,
                        IsFilter = @Convert.ToBoolean(ViewData["IsFilter"]),
                        BulkOperation = ViewData["BulkOperation"],
                        search = Request.QueryString["search"],
						caller = ViewData["caller"],
						BulkAssociate = ViewData["BulkAssociate"],
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
                        HostingEntity = @Convert.ToString(ViewData["HostingEntity"]),
                        HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]),
                        AssociatedType = @Convert.ToString(ViewData["AssociatedType"]),
                        IsExport = IsExport,
                        FSFilter = ViewBag.FSFilter == null ? "Fsearch" : ViewBag.FSFilter,
                        IsFilter = @Convert.ToBoolean(ViewData["IsFilter"]),
                        BulkOperation = ViewData["BulkOperation"],
                        search = Request.QueryString["search"],
						caller = ViewData["caller"],
   					    BulkAssociate = ViewData["BulkAssociate"],
                    };
                }
            }
        
        #line default
        #line hidden
        
        public BulkOperation()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
  
    var ActionNameUrl = "Index";
    if (HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString().ToUpper() == "FSEARCH")
    {
        ActionNameUrl = "FSearch";
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 10 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
Write(Scripts.Render("~/bundles/select2js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 11 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
Write(Styles.Render("~/Content/select2css"));

            
            #line default
            #line hidden
WriteLiteral(@"
<script>
	$("".js-example-basic-multiple"").select2({ placeholder: ""Select/Search"", allowClear: true });
    function SetSingle(source, id, DisplayValue) {
        var dropdown = ($('#PopupBulkOperationLabel').attr('class'));
        if ($('#' + dropdown + ' option[value=""' + id + '""]').length == 0) {
            $('#' + dropdown).append($('<option selected=\'selected\'></option>').val(id).html(DisplayValue));
            $(""#"" + dropdown).trigger('chosen:updated');
        }
        $(""#"" + dropdown).val(id);
        $(""#"" + dropdown).trigger('chosen:updated');
		 $(""#"" + dropdown).change();
        $(""#closePopupBulkOperation"").click();
    }
	function Update(source, id, DisplayValue) {
        val1 = $(""#idvalues"").val();
        if (source.checked) {
            $(""#idvalues"").val(val1 + "","" + id);
        }
        else {
            $(""#idvalues"").val(val1.replace("","" + id, """"));
        }
    }
    function UpdateRecords() {
        var selectedvalues = $(""#idvalues"").val().substr(1).split("","");
        var url1 = '");

            
            #line 36 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
               Write(Url.Action("BulkAssociate"));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t var entity = \'T_ShiftDuration\';\r\n        var host = \'");

            
            #line 38 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
               Write(ViewData["AssociatedType"]);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n        $.ajax({\r\n            type: \"POST\",\r\n            data: { ids: selecte" +
"dvalues, AssociatedType: \'");

            
            #line 41 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                     Write(ViewData["AssociatedType"]);

            
            #line default
            #line hidden
WriteLiteral("\', HostingEntity: \'");

            
            #line 41 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                                                                   Write(ViewData["HostingEntity"]);

            
            #line default
            #line hidden
WriteLiteral("\', HostingEntityID: \'");

            
            #line 41 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                                                                                                                  Write(ViewData["HostingEntityID"]);

            
            #line default
            #line hidden
WriteLiteral(@"' },
            url: url1,
			complete : function (msg) {
                $(""#closePopupBulkOperation"").click();
            },
            success: function (msg) {
				 if (host != undefined && host.length > 0 && $('#' + host).length > 0) {
                    $('#' + entity + 'SearchCancel', $('#' + host)).click();
                    $('#dvcnt_' + host).load(location.href + "" #dvcnt_"" + host);
                }
            }
        });
    }
</script>
");

            
            #line 55 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
 if (ViewData["BulkAssociate"] != null)
{
    
            
            #line default
            #line hidden
            
            #line 57 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
Write(Html.Hidden("idvalues"));

            
            #line default
            #line hidden
            
            #line 57 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                            
}

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" id=\"T_ShiftDuration\"");

WriteLiteral(" class=\"T_ShiftDuration\"");

WriteLiteral(">\r\n");

            
            #line 60 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
    
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
     if (ViewBag.ColumnMapping == null && ViewBag.ImportError == null && ViewBag.ConfirmImportData == null)
    {

            
            #line default
            #line hidden
WriteLiteral(@"		<style>
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
");

            
            #line 77 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"



            
            #line default
            #line hidden
WriteLiteral("\t\t <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
            $(document).ready(function () {
                $("".pagination a"").click(function (e) {
                    PaginationClick(e, 'T_ShiftDuration');
                })

                $(""#dvPopupBulkOperation input[name=SearchStringT_ShiftDuration]"").keypress(function (e) {
                    if ((e.which && e.which == 13) || (e.keyCode && e.keyCode == 13)) {

                        $('#dvPopupBulkOperation').find(""a.bulk"").bind(""click"", (function () {
                        }));
                        $('#dvPopupBulkOperation').find(""a.bulk"").trigger(""click"");
                        return false;
                    }
                })
            });
        </script>
");

            
            #line 96 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
        
        
            
            #line default
            #line hidden
            
            #line 142 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
         

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-sx-12\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel-heading clearfix\"");

WriteLiteral(" style=\"margin:0px; padding:8px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(" style=\"width:200px;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 149 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                           Write(Html.TextBox("SearchStringT_ShiftDuration", ViewBag.CurrentFilter as string, null, new { @class = "form-control fixsearchbox", @placeholder = "Search" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" id=\"T_ShiftDurationSearch\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6744), Tuple.Create("\"", 7275)
, Tuple.Create(Tuple.Create("", 6754), Tuple.Create("SearchClick(event,", 6754), true)
, Tuple.Create(Tuple.Create(" ", 6772), Tuple.Create("\'T_ShiftDuration\',", 6773), true)
, Tuple.Create(Tuple.Create(" ", 6791), Tuple.Create("\'", 6792), true)
            
            #line 151 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                  , Tuple.Create(Tuple.Create("", 6793), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_ShiftDuration", new { BulkAssociate = ViewData["BulkAssociate"], caller = ViewData["caller"],IsFilter = ViewData["IsFilter"], IsDeepSearch = false, searchString = "_SearchString", HostingEntity = Convert.ToString(ViewData["HostingEntity"]), BulkOperation = ViewData["BulkOperation"], HostingEntityID = Convert.ToString(ViewData["HostingEntityID"]), AssociatedType = Convert.ToString(ViewData["AssociatedType"]), SearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 6793), false)
, Tuple.Create(Tuple.Create("", 7272), Tuple.Create("\');", 7272), true)
);

WriteLiteral(" data-original-title=\"Grid Search\"");

WriteLiteral(" class=\"btn btn-default btn-default tip-top bulk\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral("><span");

WriteLiteral(" class=\"fam-zoom\"");

WriteLiteral("></span></a>\r\n                                    <button");

WriteLiteral(" id=\"T_ShiftDurationCancel\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-default collapse-data-btn tip-top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7567), Tuple.Create("\"", 8000)
, Tuple.Create(Tuple.Create("", 7577), Tuple.Create("CancelSearchBulk(\'T_ShiftDuration\',\'", 7577), true)
            
            #line 152 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                                                                                , Tuple.Create(Tuple.Create("", 7613), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_ShiftDuration", new {caller = ViewData["caller"], BulkOperation = ViewData["BulkOperation"], IsFilter=ViewData["IsFilter"], HostingEntity = Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = Convert.ToString(ViewData["HostingEntityID"]), AssociatedType = Convert.ToString(ViewData["AssociatedType"]), ClearSearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 7613), false)
, Tuple.Create(Tuple.Create("", 7998), Tuple.Create("\')", 7998), true)
);

WriteLiteral(" data-original-title=\"Clear Search\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral(">\r\n                                        <span");

WriteLiteral(" class=\"fam-delete\"");

WriteLiteral("></span>\r\n                                    </button>\r\n                        " +
"            <button");

WriteLiteral(" id=\"T_ShiftDurationSearchCancel\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-default collapse-data-btn tip-top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8358), Tuple.Create("\"", 8835)
, Tuple.Create(Tuple.Create("", 8368), Tuple.Create("CancelSearchBulk(\'T_ShiftDuration\',\'", 8368), true)
            
            #line 155 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                                                                                      , Tuple.Create(Tuple.Create("", 8404), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_ShiftDuration", new { BulkAssociate = ViewData["BulkAssociate"], caller = ViewData["caller"],IsFilter = ViewData["IsFilter"],HostingEntity = Convert.ToString(ViewData["HostingEntity"]), BulkOperation = ViewData["BulkOperation"], HostingEntityID = Convert.ToString(ViewData["HostingEntityID"]), AssociatedType = Convert.ToString(ViewData["AssociatedType"]), ClearSearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 8404), false)
, Tuple.Create(Tuple.Create("", 8833), Tuple.Create("\')", 8833), true)
);

WriteLiteral(" data-original-title=\"Refresh Grid\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral(">\r\n                                        <span");

WriteLiteral(" class=\"fam-arrow-refresh\"");

WriteLiteral("></span>\r\n                                    </button>\r\n                        " +
"        </div>\r\n                            </div>\r\n                        </di" +
"v>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(" style=\"margin:0px; padding:8px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" id=\"Des_Table\"");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(" style=\"overflow-x:auto;\"");

WriteLiteral(">\r\n                            <table");

WriteLiteral(" class=\"table table-striped table-bordered table-hover table-condensed\"");

WriteLiteral(">\r\n                                <thead>\r\n                                    <" +
"tr>\r\n                                        <th");

WriteLiteral(" class=\"col2\"");

WriteLiteral(">\r\n                                            Select\r\n                          " +
"              </th>\r\n");

            
            #line 170 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 170 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                         if (User.CanView("T_ShiftDuration"))
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <th");

WriteLiteral(" class=\"col2\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 173 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                           Write(Html.ActionLink("Display Value", ActionNameUrl, "T_ShiftDuration", getSortHtmlAttributes("DisplayValue", false, null, false), new { @onclick = "SortLinkClick(event,'T_ShiftDuration');" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 174 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 174 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                 if (ViewBag.IsAsc == "DESC" && ViewBag.CurrentSort == "DisplayValue")
                                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-desc\"");

WriteLiteral("></i>");

            
            #line 175 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                                                }

            
            #line default
            #line hidden
WriteLiteral("                                                ");

            
            #line 176 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                 if (ViewBag.IsAsc == "ASC" && ViewBag.CurrentSort == "DisplayValue")
                                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-asc\"");

WriteLiteral("></i>");

            
            #line 177 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                                               }

            
            #line default
            #line hidden
WriteLiteral("                                            </th>\r\n");

            
            #line 179 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </tr>\r\n");

            
            #line 181 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 181 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                     foreach (var item in Model)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <tr>\r\n");

            
            #line 184 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                            
            
            #line default
            #line hidden
            
            #line 184 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                             if(Convert.ToString(ViewData["BulkOperation"]) == "multiple")
                                            {
												if (ViewData["BulkAssociate"] != null)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <td>\r\n                       " +
"                                 <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 11217), Tuple.Create("\"", 11272)
, Tuple.Create(Tuple.Create("", 11227), Tuple.Create("Update(this,\'", 11227), true)
            
            #line 189 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                    , Tuple.Create(Tuple.Create("", 11240), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 11240), false)
, Tuple.Create(Tuple.Create("", 11248), Tuple.Create("\',\'", 11248), true)
            
            #line 189 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                               , Tuple.Create(Tuple.Create("", 11251), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 11251), false)
, Tuple.Create(Tuple.Create("", 11269), Tuple.Create("\');", 11269), true)
);

WriteLiteral(" />\r\n                                                    </td>\r\n");

            
            #line 191 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                }
                                                else
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <td>\r\n                       " +
"                                 <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 11629), Tuple.Create("\"", 11681)
, Tuple.Create(Tuple.Create("", 11639), Tuple.Create("Set(this,\'", 11639), true)
            
            #line 195 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                 , Tuple.Create(Tuple.Create("", 11649), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 11649), false)
, Tuple.Create(Tuple.Create("", 11657), Tuple.Create("\',\'", 11657), true)
            
            #line 195 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                            , Tuple.Create(Tuple.Create("", 11660), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 11660), false)
, Tuple.Create(Tuple.Create("", 11678), Tuple.Create("\');", 11678), true)
);

WriteLiteral(" />\r\n                                                    </td>\r\n");

            
            #line 197 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                }
                                            }
                                            else
                                            {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" value=\"Select\"");

WriteLiteral(" class=\"btn btn-primary btn-xs\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 12038), Tuple.Create("\"", 12096)
, Tuple.Create(Tuple.Create("", 12048), Tuple.Create("SetSingle(this,\'", 12048), true)
            
            #line 202 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                               , Tuple.Create(Tuple.Create("", 12064), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 12064), false)
, Tuple.Create(Tuple.Create("", 12072), Tuple.Create("\',\'", 12072), true)
            
            #line 202 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                                          , Tuple.Create(Tuple.Create("", 12075), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 12075), false)
, Tuple.Create(Tuple.Create("", 12093), Tuple.Create("\');", 12093), true)
);

WriteLiteral(" />\r\n\t\t\t\t\t\t\t\t\t\t\t\t</td> \r\n");

            
            #line 204 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                            ");

            
            #line 205 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                             if (User.CanView("T_ShiftDuration"))
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <td>\r\n");

WriteLiteral("                                                    ");

            
            #line 208 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </td>\r\n");

            
            #line 210 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                        </tr>\r\n");

            
            #line 212 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                            </table>\r\n                        </div>\r\n           " +
"             <ul");

WriteLiteral(" id=\"Mob_List\"");

WriteLiteral(" class=\"list-group\"");

WriteLiteral(">\r\n");

            
            #line 216 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 216 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                             foreach (var item in Model)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li");

WriteLiteral(" class=\"list-group-item\"");

WriteLiteral(">\r\n");

            
            #line 219 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 219 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                     if (User.CanView("T_ShiftDuration"))
                                    {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t\t\t<p>\r\n                                            <span");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral("> Select </span> : <span>\r\n");

            
            #line 223 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                            
            
            #line default
            #line hidden
            
            #line 223 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                             if(Convert.ToString(ViewData["BulkOperation"]) == "multiple")
                                            {
												if (ViewData["BulkAssociate"] != null)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 13489), Tuple.Create("\"", 13544)
, Tuple.Create(Tuple.Create("", 13499), Tuple.Create("Update(this,\'", 13499), true)
            
            #line 227 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                    , Tuple.Create(Tuple.Create("", 13512), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 13512), false)
, Tuple.Create(Tuple.Create("", 13520), Tuple.Create("\',\'", 13520), true)
            
            #line 227 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                               , Tuple.Create(Tuple.Create("", 13523), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 13523), false)
, Tuple.Create(Tuple.Create("", 13541), Tuple.Create("\');", 13541), true)
);

WriteLiteral(" />\r\n");

            
            #line 228 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                }
                                                else
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 13784), Tuple.Create("\"", 13836)
, Tuple.Create(Tuple.Create("", 13794), Tuple.Create("Set(this,\'", 13794), true)
            
            #line 231 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                 , Tuple.Create(Tuple.Create("", 13804), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 13804), false)
, Tuple.Create(Tuple.Create("", 13812), Tuple.Create("\',\'", 13812), true)
            
            #line 231 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                            , Tuple.Create(Tuple.Create("", 13815), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 13815), false)
, Tuple.Create(Tuple.Create("", 13833), Tuple.Create("\');", 13833), true)
);

WriteLiteral(" />\r\n");

            
            #line 232 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                }
                                            }
                                            else
                                            {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" value=\"Select\"");

WriteLiteral(" class=\"btn btn-primary btn-xs\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 14115), Tuple.Create("\"", 14173)
, Tuple.Create(Tuple.Create("", 14125), Tuple.Create("SetSingle(this,\'", 14125), true)
            
            #line 236 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                           , Tuple.Create(Tuple.Create("", 14141), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 14141), false)
, Tuple.Create(Tuple.Create("", 14149), Tuple.Create("\',\'", 14149), true)
            
            #line 236 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                                      , Tuple.Create(Tuple.Create("", 14152), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 14152), false)
, Tuple.Create(Tuple.Create("", 14170), Tuple.Create("\');", 14170), true)
);

WriteLiteral(" />\r\n");

            
            #line 237 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                            </span>\r\n                            " +
"            </p>\r\n");

WriteLiteral("                                        <p>\r\n                                    " +
"        <span");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral("> Display Value </span> : <span>\r\n");

WriteLiteral("                                                ");

            
            #line 242 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </span>\r\n                          " +
"              </p>\r\n");

            
            #line 245 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </li>\r\n");

            
            #line 247 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </ul>\r\n");

            
            #line 249 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 249 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                         if (Model.Count > 0)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" id=\"pagination\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 252 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                           Write(Html.PagedListPager(Model, page => Url.Action(ActionNameUrl, "T_ShiftDuration", getSortHtmlAttributes(null, true, page, false))));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"fixPageSize\"");

WriteLiteral(">\r\n                                    Page Size :\r\n");

WriteLiteral("                                    ");

            
            #line 255 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                               Write(Html.DropDownList("PageSize", new SelectList(new Dictionary<string, int> { { "10", 10 }, { "20", 20 }, { "50", 50 }, { "100", 100 } }, "Key", "Value"), new { @id = "pagesizelistT_ShiftDuration", 
									@onchange = "pagesizelistChange(event,'T_ShiftDuration')", 
									@Url = Html.Raw(@Url.Action(ActionNameUrl, "T_ShiftDuration", 
									getSortHtmlAttributes(ViewBag.CurrentSort, ViewBag.Pages == 1 ? false : true,
									null, false), null)) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    <span");

WriteLiteral(" style=\"text-align:right;\"");

WriteLiteral("> Total Count: ");

            
            #line 260 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                                                                              Write(Model.TotalItemCount);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                </div>\r\n                            </di" +
"v>\r\n");

            
            #line 263 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        <" +
"/div>\r\n");

            
            #line 268 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
		if (ViewData["BulkAssociate"] != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-sm fixbulkbutton\"");

WriteAttribute("value", Tuple.Create(" value=\"", 16141), Tuple.Create("\"", 16266)
, Tuple.Create(Tuple.Create("", 16149), Tuple.Create("Associate", 16149), true)
, Tuple.Create(Tuple.Create(" ", 16158), Tuple.Create("with", 16159), true)
            
            #line 270 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
                  , Tuple.Create(Tuple.Create(" ", 16163), Tuple.Create<System.Object, System.Int32>(GeneratorBase.MVC.Models.ModelConversion.GetDisplayNameOfEntity(ViewData["HostingEntity"].ToString())
            
            #line default
            #line hidden
, 16164), false)
);

WriteLiteral(" onclick=\"UpdateRecords();\"");

WriteLiteral(" />\r\n");

            
            #line 271 "..\..\Views\T_ShiftDuration\BulkOperation.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n  \r\n");

        }
    }
}
#pragma warning restore 1591