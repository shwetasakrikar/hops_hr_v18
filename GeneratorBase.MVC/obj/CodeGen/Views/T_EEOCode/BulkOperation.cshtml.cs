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

namespace GeneratorBase.MVC.Views.T_EEOCode
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
    
    #line 2 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_EEOCode/BulkOperation.cshtml")]
    public partial class BulkOperation : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.T_EEOCode>>
    {
        
        #line 97 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                    
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
            
            #line 3 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
  
    var ActionNameUrl = "Index";
    if (HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString().ToUpper() == "FSEARCH")
    {
        ActionNameUrl = "FSearch";
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 10 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
Write(Scripts.Render("~/bundles/select2js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 11 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
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

            
            #line 36 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
               Write(Url.Action("BulkAssociate"));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t var entity = \'T_EEOCode\';\r\n        var host = \'");

            
            #line 38 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
               Write(ViewData["AssociatedType"]);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n        $.ajax({\r\n            type: \"POST\",\r\n            data: { ids: selecte" +
"dvalues, AssociatedType: \'");

            
            #line 41 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                     Write(ViewData["AssociatedType"]);

            
            #line default
            #line hidden
WriteLiteral("\', HostingEntity: \'");

            
            #line 41 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                                                                   Write(ViewData["HostingEntity"]);

            
            #line default
            #line hidden
WriteLiteral("\', HostingEntityID: \'");

            
            #line 41 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
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

            
            #line 55 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
 if (ViewData["BulkAssociate"] != null)
{
    
            
            #line default
            #line hidden
            
            #line 57 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
Write(Html.Hidden("idvalues"));

            
            #line default
            #line hidden
            
            #line 57 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                            
}

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" id=\"T_EEOCode\"");

WriteLiteral(" class=\"T_EEOCode\"");

WriteLiteral(">\r\n");

            
            #line 60 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
    
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
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

            
            #line 77 "..\..\Views\T_EEOCode\BulkOperation.cshtml"



            
            #line default
            #line hidden
WriteLiteral("\t\t <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
            $(document).ready(function () {
                $("".pagination a"").click(function (e) {
                    PaginationClick(e, 'T_EEOCode');
                })

                $(""#dvPopupBulkOperation input[name=SearchStringT_EEOCode]"").keypress(function (e) {
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

            
            #line 96 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
        
        
            
            #line default
            #line hidden
            
            #line 142 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
         

            
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

            
            #line 149 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                           Write(Html.TextBox("SearchStringT_EEOCode", ViewBag.CurrentFilter as string, null, new { @class = "form-control fixsearchbox", @placeholder = "Search" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" id=\"T_EEOCodeSearch\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6696), Tuple.Create("\"", 7215)
, Tuple.Create(Tuple.Create("", 6706), Tuple.Create("SearchClick(event,", 6706), true)
, Tuple.Create(Tuple.Create(" ", 6724), Tuple.Create("\'T_EEOCode\',", 6725), true)
, Tuple.Create(Tuple.Create(" ", 6737), Tuple.Create("\'", 6738), true)
            
            #line 151 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                      , Tuple.Create(Tuple.Create("", 6739), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_EEOCode", new { BulkAssociate = ViewData["BulkAssociate"], caller = ViewData["caller"],IsFilter = ViewData["IsFilter"], IsDeepSearch = false, searchString = "_SearchString", HostingEntity = Convert.ToString(ViewData["HostingEntity"]), BulkOperation = ViewData["BulkOperation"], HostingEntityID = Convert.ToString(ViewData["HostingEntityID"]), AssociatedType = Convert.ToString(ViewData["AssociatedType"]), SearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 6739), false)
, Tuple.Create(Tuple.Create("", 7212), Tuple.Create("\');", 7212), true)
);

WriteLiteral(" data-original-title=\"Grid Search\"");

WriteLiteral(" class=\"btn btn-default btn-default tip-top bulk\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral("><span");

WriteLiteral(" class=\"fam-zoom\"");

WriteLiteral("></span></a>\r\n                                    <button");

WriteLiteral(" id=\"T_EEOCodeCancel\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-default collapse-data-btn tip-top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7501), Tuple.Create("\"", 7922)
, Tuple.Create(Tuple.Create("", 7511), Tuple.Create("CancelSearchBulk(\'T_EEOCode\',\'", 7511), true)
            
            #line 152 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                                                                    , Tuple.Create(Tuple.Create("", 7541), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_EEOCode", new {caller = ViewData["caller"], BulkOperation = ViewData["BulkOperation"], IsFilter=ViewData["IsFilter"], HostingEntity = Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = Convert.ToString(ViewData["HostingEntityID"]), AssociatedType = Convert.ToString(ViewData["AssociatedType"]), ClearSearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 7541), false)
, Tuple.Create(Tuple.Create("", 7920), Tuple.Create("\')", 7920), true)
);

WriteLiteral(" data-original-title=\"Clear Search\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral(">\r\n                                        <span");

WriteLiteral(" class=\"fam-delete\"");

WriteLiteral("></span>\r\n                                    </button>\r\n                        " +
"            <button");

WriteLiteral(" id=\"T_EEOCodeSearchCancel\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-default collapse-data-btn tip-top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8274), Tuple.Create("\"", 8739)
, Tuple.Create(Tuple.Create("", 8284), Tuple.Create("CancelSearchBulk(\'T_EEOCode\',\'", 8284), true)
            
            #line 155 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                                                                          , Tuple.Create(Tuple.Create("", 8314), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_EEOCode", new { BulkAssociate = ViewData["BulkAssociate"], caller = ViewData["caller"],IsFilter = ViewData["IsFilter"],HostingEntity = Convert.ToString(ViewData["HostingEntity"]), BulkOperation = ViewData["BulkOperation"], HostingEntityID = Convert.ToString(ViewData["HostingEntityID"]), AssociatedType = Convert.ToString(ViewData["AssociatedType"]), ClearSearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 8314), false)
, Tuple.Create(Tuple.Create("", 8737), Tuple.Create("\')", 8737), true)
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

            
            #line 170 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 170 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                         if (User.CanView("T_EEOCode"))
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <th");

WriteLiteral(" class=\"col2\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 173 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                           Write(Html.ActionLink("Display Value", ActionNameUrl, "T_EEOCode", getSortHtmlAttributes("DisplayValue", false, null, false), new { @onclick = "SortLinkClick(event,'T_EEOCode');" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 174 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 174 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                 if (ViewBag.IsAsc == "DESC" && ViewBag.CurrentSort == "DisplayValue")
                                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-desc\"");

WriteLiteral("></i>");

            
            #line 175 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                                                }

            
            #line default
            #line hidden
WriteLiteral("                                                ");

            
            #line 176 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                 if (ViewBag.IsAsc == "ASC" && ViewBag.CurrentSort == "DisplayValue")
                                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-asc\"");

WriteLiteral("></i>");

            
            #line 177 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                                               }

            
            #line default
            #line hidden
WriteLiteral("                                            </th>\r\n");

            
            #line 179 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </tr>\r\n");

            
            #line 181 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 181 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                     foreach (var item in Model)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <tr>\r\n");

            
            #line 184 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                            
            
            #line default
            #line hidden
            
            #line 184 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                             if(Convert.ToString(ViewData["BulkOperation"]) == "multiple")
                                            {
												if (ViewData["BulkAssociate"] != null)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <td>\r\n                       " +
"                                 <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 11103), Tuple.Create("\"", 11158)
, Tuple.Create(Tuple.Create("", 11113), Tuple.Create("Update(this,\'", 11113), true)
            
            #line 189 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                    , Tuple.Create(Tuple.Create("", 11126), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 11126), false)
, Tuple.Create(Tuple.Create("", 11134), Tuple.Create("\',\'", 11134), true)
            
            #line 189 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                               , Tuple.Create(Tuple.Create("", 11137), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 11137), false)
, Tuple.Create(Tuple.Create("", 11155), Tuple.Create("\');", 11155), true)
);

WriteLiteral(" />\r\n                                                    </td>\r\n");

            
            #line 191 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                }
                                                else
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <td>\r\n                       " +
"                                 <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 11515), Tuple.Create("\"", 11567)
, Tuple.Create(Tuple.Create("", 11525), Tuple.Create("Set(this,\'", 11525), true)
            
            #line 195 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                 , Tuple.Create(Tuple.Create("", 11535), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 11535), false)
, Tuple.Create(Tuple.Create("", 11543), Tuple.Create("\',\'", 11543), true)
            
            #line 195 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                            , Tuple.Create(Tuple.Create("", 11546), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 11546), false)
, Tuple.Create(Tuple.Create("", 11564), Tuple.Create("\');", 11564), true)
);

WriteLiteral(" />\r\n                                                    </td>\r\n");

            
            #line 197 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 11924), Tuple.Create("\"", 11982)
, Tuple.Create(Tuple.Create("", 11934), Tuple.Create("SetSingle(this,\'", 11934), true)
            
            #line 202 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                               , Tuple.Create(Tuple.Create("", 11950), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 11950), false)
, Tuple.Create(Tuple.Create("", 11958), Tuple.Create("\',\'", 11958), true)
            
            #line 202 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                                          , Tuple.Create(Tuple.Create("", 11961), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 11961), false)
, Tuple.Create(Tuple.Create("", 11979), Tuple.Create("\');", 11979), true)
);

WriteLiteral(" />\r\n\t\t\t\t\t\t\t\t\t\t\t\t</td> \r\n");

            
            #line 204 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                            ");

            
            #line 205 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                             if (User.CanView("T_EEOCode"))
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <td>\r\n");

WriteLiteral("                                                    ");

            
            #line 208 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </td>\r\n");

            
            #line 210 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                        </tr>\r\n");

            
            #line 212 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                            </table>\r\n                        </div>\r\n           " +
"             <ul");

WriteLiteral(" id=\"Mob_List\"");

WriteLiteral(" class=\"list-group\"");

WriteLiteral(">\r\n");

            
            #line 216 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 216 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                             foreach (var item in Model)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li");

WriteLiteral(" class=\"list-group-item\"");

WriteLiteral(">\r\n");

            
            #line 219 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 219 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                     if (User.CanView("T_EEOCode"))
                                    {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t\t\t<p>\r\n                                            <span");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral("> Select </span> : <span>\r\n");

            
            #line 223 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                            
            
            #line default
            #line hidden
            
            #line 223 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                             if(Convert.ToString(ViewData["BulkOperation"]) == "multiple")
                                            {
												if (ViewData["BulkAssociate"] != null)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 13363), Tuple.Create("\"", 13418)
, Tuple.Create(Tuple.Create("", 13373), Tuple.Create("Update(this,\'", 13373), true)
            
            #line 227 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                    , Tuple.Create(Tuple.Create("", 13386), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 13386), false)
, Tuple.Create(Tuple.Create("", 13394), Tuple.Create("\',\'", 13394), true)
            
            #line 227 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                               , Tuple.Create(Tuple.Create("", 13397), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 13397), false)
, Tuple.Create(Tuple.Create("", 13415), Tuple.Create("\');", 13415), true)
);

WriteLiteral(" />\r\n");

            
            #line 228 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                }
                                                else
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 13658), Tuple.Create("\"", 13710)
, Tuple.Create(Tuple.Create("", 13668), Tuple.Create("Set(this,\'", 13668), true)
            
            #line 231 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                 , Tuple.Create(Tuple.Create("", 13678), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 13678), false)
, Tuple.Create(Tuple.Create("", 13686), Tuple.Create("\',\'", 13686), true)
            
            #line 231 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                            , Tuple.Create(Tuple.Create("", 13689), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 13689), false)
, Tuple.Create(Tuple.Create("", 13707), Tuple.Create("\');", 13707), true)
);

WriteLiteral(" />\r\n");

            
            #line 232 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 13989), Tuple.Create("\"", 14047)
, Tuple.Create(Tuple.Create("", 13999), Tuple.Create("SetSingle(this,\'", 13999), true)
            
            #line 236 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                           , Tuple.Create(Tuple.Create("", 14015), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 14015), false)
, Tuple.Create(Tuple.Create("", 14023), Tuple.Create("\',\'", 14023), true)
            
            #line 236 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                                      , Tuple.Create(Tuple.Create("", 14026), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 14026), false)
, Tuple.Create(Tuple.Create("", 14044), Tuple.Create("\');", 14044), true)
);

WriteLiteral(" />\r\n");

            
            #line 237 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
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

            
            #line 242 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </span>\r\n                          " +
"              </p>\r\n");

            
            #line 245 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </li>\r\n");

            
            #line 247 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </ul>\r\n");

            
            #line 249 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 249 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                         if (Model.Count > 0)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" id=\"pagination\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 252 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                           Write(Html.PagedListPager(Model, page => Url.Action(ActionNameUrl, "T_EEOCode", getSortHtmlAttributes(null, true, page, false))));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"fixPageSize\"");

WriteLiteral(">\r\n                                    Page Size :\r\n");

WriteLiteral("                                    ");

            
            #line 255 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                               Write(Html.DropDownList("PageSize", new SelectList(new Dictionary<string, int> { { "10", 10 }, { "20", 20 }, { "50", 50 }, { "100", 100 } }, "Key", "Value"), new { @id = "pagesizelistT_EEOCode", 
									@onchange = "pagesizelistChange(event,'T_EEOCode')", 
									@Url = Html.Raw(@Url.Action(ActionNameUrl, "T_EEOCode", 
									getSortHtmlAttributes(ViewBag.CurrentSort, ViewBag.Pages == 1 ? false : true,
									null, false), null)) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    <span");

WriteLiteral(" style=\"text-align:right;\"");

WriteLiteral("> Total Count: ");

            
            #line 260 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                                                                              Write(Model.TotalItemCount);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                </div>\r\n                            </di" +
"v>\r\n");

            
            #line 263 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        <" +
"/div>\r\n");

            
            #line 268 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
		if (ViewData["BulkAssociate"] != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-sm fixbulkbutton\"");

WriteAttribute("value", Tuple.Create(" value=\"", 15991), Tuple.Create("\"", 16116)
, Tuple.Create(Tuple.Create("", 15999), Tuple.Create("Associate", 15999), true)
, Tuple.Create(Tuple.Create(" ", 16008), Tuple.Create("with", 16009), true)
            
            #line 270 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
                  , Tuple.Create(Tuple.Create(" ", 16013), Tuple.Create<System.Object, System.Int32>(GeneratorBase.MVC.Models.ModelConversion.GetDisplayNameOfEntity(ViewData["HostingEntity"].ToString())
            
            #line default
            #line hidden
, 16014), false)
);

WriteLiteral(" onclick=\"UpdateRecords();\"");

WriteLiteral(" />\r\n");

            
            #line 271 "..\..\Views\T_EEOCode\BulkOperation.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n  \r\n");

        }
    }
}
#pragma warning restore 1591
