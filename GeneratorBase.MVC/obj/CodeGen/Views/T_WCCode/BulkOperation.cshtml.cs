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

namespace GeneratorBase.MVC.Views.T_WCCode
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
    
    #line 2 "..\..\Views\T_WCCode\BulkOperation.cshtml"
    using PagedList.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/T_WCCode/BulkOperation.cshtml")]
    public partial class BulkOperation : GeneratorBase.MVC.CustomWebViewPage<PagedList.IPagedList<GeneratorBase.MVC.Models.T_WCCode>>
    {
        
        #line 97 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                    
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
            
            #line 3 "..\..\Views\T_WCCode\BulkOperation.cshtml"
  
    var ActionNameUrl = "Index";
    if (HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString().ToUpper() == "FSEARCH")
    {
        ActionNameUrl = "FSearch";
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 10 "..\..\Views\T_WCCode\BulkOperation.cshtml"
Write(Scripts.Render("~/bundles/select2js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 11 "..\..\Views\T_WCCode\BulkOperation.cshtml"
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

            
            #line 36 "..\..\Views\T_WCCode\BulkOperation.cshtml"
               Write(Url.Action("BulkAssociate"));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n\t\t var entity = \'T_WCCode\';\r\n        var host = \'");

            
            #line 38 "..\..\Views\T_WCCode\BulkOperation.cshtml"
               Write(ViewData["AssociatedType"]);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n        $.ajax({\r\n            type: \"POST\",\r\n            data: { ids: selecte" +
"dvalues, AssociatedType: \'");

            
            #line 41 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                     Write(ViewData["AssociatedType"]);

            
            #line default
            #line hidden
WriteLiteral("\', HostingEntity: \'");

            
            #line 41 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                                                                   Write(ViewData["HostingEntity"]);

            
            #line default
            #line hidden
WriteLiteral("\', HostingEntityID: \'");

            
            #line 41 "..\..\Views\T_WCCode\BulkOperation.cshtml"
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

            
            #line 55 "..\..\Views\T_WCCode\BulkOperation.cshtml"
 if (ViewData["BulkAssociate"] != null)
{
    
            
            #line default
            #line hidden
            
            #line 57 "..\..\Views\T_WCCode\BulkOperation.cshtml"
Write(Html.Hidden("idvalues"));

            
            #line default
            #line hidden
            
            #line 57 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                            
}

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" id=\"T_WCCode\"");

WriteLiteral(" class=\"T_WCCode\"");

WriteLiteral(">\r\n");

            
            #line 60 "..\..\Views\T_WCCode\BulkOperation.cshtml"
    
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\T_WCCode\BulkOperation.cshtml"
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

            
            #line 77 "..\..\Views\T_WCCode\BulkOperation.cshtml"



            
            #line default
            #line hidden
WriteLiteral("\t\t <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
            $(document).ready(function () {
                $("".pagination a"").click(function (e) {
                    PaginationClick(e, 'T_WCCode');
                })

                $(""#dvPopupBulkOperation input[name=SearchStringT_WCCode]"").keypress(function (e) {
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

            
            #line 96 "..\..\Views\T_WCCode\BulkOperation.cshtml"
        
        
            
            #line default
            #line hidden
            
            #line 142 "..\..\Views\T_WCCode\BulkOperation.cshtml"
         

            
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

            
            #line 149 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                           Write(Html.TextBox("SearchStringT_WCCode", ViewBag.CurrentFilter as string, null, new { @class = "form-control fixsearchbox", @placeholder = "Search" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" id=\"T_WCCodeSearch\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6688), Tuple.Create("\"", 7205)
, Tuple.Create(Tuple.Create("", 6698), Tuple.Create("SearchClick(event,", 6698), true)
, Tuple.Create(Tuple.Create(" ", 6716), Tuple.Create("\'T_WCCode\',", 6717), true)
, Tuple.Create(Tuple.Create(" ", 6728), Tuple.Create("\'", 6729), true)
            
            #line 151 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                    , Tuple.Create(Tuple.Create("", 6730), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_WCCode", new { BulkAssociate = ViewData["BulkAssociate"], caller = ViewData["caller"],IsFilter = ViewData["IsFilter"], IsDeepSearch = false, searchString = "_SearchString", HostingEntity = Convert.ToString(ViewData["HostingEntity"]), BulkOperation = ViewData["BulkOperation"], HostingEntityID = Convert.ToString(ViewData["HostingEntityID"]), AssociatedType = Convert.ToString(ViewData["AssociatedType"]), SearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 6730), false)
, Tuple.Create(Tuple.Create("", 7202), Tuple.Create("\');", 7202), true)
);

WriteLiteral(" data-original-title=\"Grid Search\"");

WriteLiteral(" class=\"btn btn-default btn-default tip-top bulk\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral("><span");

WriteLiteral(" class=\"fam-zoom\"");

WriteLiteral("></span></a>\r\n                                    <button");

WriteLiteral(" id=\"T_WCCodeCancel\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-default collapse-data-btn tip-top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7490), Tuple.Create("\"", 7909)
, Tuple.Create(Tuple.Create("", 7500), Tuple.Create("CancelSearchBulk(\'T_WCCode\',\'", 7500), true)
            
            #line 152 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                                                                  , Tuple.Create(Tuple.Create("", 7529), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_WCCode", new {caller = ViewData["caller"], BulkOperation = ViewData["BulkOperation"], IsFilter=ViewData["IsFilter"], HostingEntity = Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = Convert.ToString(ViewData["HostingEntityID"]), AssociatedType = Convert.ToString(ViewData["AssociatedType"]), ClearSearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 7529), false)
, Tuple.Create(Tuple.Create("", 7907), Tuple.Create("\')", 7907), true)
);

WriteLiteral(" data-original-title=\"Clear Search\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" style=\"padding:3px 5px;\"");

WriteLiteral(">\r\n                                        <span");

WriteLiteral(" class=\"fam-delete\"");

WriteLiteral("></span>\r\n                                    </button>\r\n                        " +
"            <button");

WriteLiteral(" id=\"T_WCCodeSearchCancel\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-default collapse-data-btn tip-top\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8260), Tuple.Create("\"", 8723)
, Tuple.Create(Tuple.Create("", 8270), Tuple.Create("CancelSearchBulk(\'T_WCCode\',\'", 8270), true)
            
            #line 155 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                                                                        , Tuple.Create(Tuple.Create("", 8299), Tuple.Create<System.Object, System.Int32>(Html.Raw(Url.Action("Index", "T_WCCode", new { BulkAssociate = ViewData["BulkAssociate"], caller = ViewData["caller"],IsFilter = ViewData["IsFilter"],HostingEntity = Convert.ToString(ViewData["HostingEntity"]), BulkOperation = ViewData["BulkOperation"], HostingEntityID = Convert.ToString(ViewData["HostingEntityID"]), AssociatedType = Convert.ToString(ViewData["AssociatedType"]), ClearSearchTimeStamp = DateTime.Now }))
            
            #line default
            #line hidden
, 8299), false)
, Tuple.Create(Tuple.Create("", 8721), Tuple.Create("\')", 8721), true)
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

            
            #line 170 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 170 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                         if (User.CanView("T_WCCode"))
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <th");

WriteLiteral(" class=\"col2\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 173 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                           Write(Html.ActionLink("Display Value", ActionNameUrl, "T_WCCode", getSortHtmlAttributes("DisplayValue", false, null, false), new { @onclick = "SortLinkClick(event,'T_WCCode');" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 174 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 174 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                 if (ViewBag.IsAsc == "DESC" && ViewBag.CurrentSort == "DisplayValue")
                                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-desc\"");

WriteLiteral("></i>");

            
            #line 175 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                                                }

            
            #line default
            #line hidden
WriteLiteral("                                                ");

            
            #line 176 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                 if (ViewBag.IsAsc == "ASC" && ViewBag.CurrentSort == "DisplayValue")
                                                {
            
            #line default
            #line hidden
WriteLiteral("<i");

WriteLiteral(" class=\"fa fa-sort-asc\"");

WriteLiteral("></i>");

            
            #line 177 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                                               }

            
            #line default
            #line hidden
WriteLiteral("                                            </th>\r\n");

            
            #line 179 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </tr>\r\n");

            
            #line 181 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 181 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                     foreach (var item in Model)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <tr>\r\n");

            
            #line 184 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                            
            
            #line default
            #line hidden
            
            #line 184 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                             if(Convert.ToString(ViewData["BulkOperation"]) == "multiple")
                                            {
												if (ViewData["BulkAssociate"] != null)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <td>\r\n                       " +
"                                 <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 11084), Tuple.Create("\"", 11139)
, Tuple.Create(Tuple.Create("", 11094), Tuple.Create("Update(this,\'", 11094), true)
            
            #line 189 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                    , Tuple.Create(Tuple.Create("", 11107), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 11107), false)
, Tuple.Create(Tuple.Create("", 11115), Tuple.Create("\',\'", 11115), true)
            
            #line 189 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                               , Tuple.Create(Tuple.Create("", 11118), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 11118), false)
, Tuple.Create(Tuple.Create("", 11136), Tuple.Create("\');", 11136), true)
);

WriteLiteral(" />\r\n                                                    </td>\r\n");

            
            #line 191 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                }
                                                else
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <td>\r\n                       " +
"                                 <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 11496), Tuple.Create("\"", 11548)
, Tuple.Create(Tuple.Create("", 11506), Tuple.Create("Set(this,\'", 11506), true)
            
            #line 195 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                 , Tuple.Create(Tuple.Create("", 11516), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 11516), false)
, Tuple.Create(Tuple.Create("", 11524), Tuple.Create("\',\'", 11524), true)
            
            #line 195 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                            , Tuple.Create(Tuple.Create("", 11527), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 11527), false)
, Tuple.Create(Tuple.Create("", 11545), Tuple.Create("\');", 11545), true)
);

WriteLiteral(" />\r\n                                                    </td>\r\n");

            
            #line 197 "..\..\Views\T_WCCode\BulkOperation.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 11905), Tuple.Create("\"", 11963)
, Tuple.Create(Tuple.Create("", 11915), Tuple.Create("SetSingle(this,\'", 11915), true)
            
            #line 202 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                               , Tuple.Create(Tuple.Create("", 11931), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 11931), false)
, Tuple.Create(Tuple.Create("", 11939), Tuple.Create("\',\'", 11939), true)
            
            #line 202 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                                          , Tuple.Create(Tuple.Create("", 11942), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 11942), false)
, Tuple.Create(Tuple.Create("", 11960), Tuple.Create("\');", 11960), true)
);

WriteLiteral(" />\r\n\t\t\t\t\t\t\t\t\t\t\t\t</td> \r\n");

            
            #line 204 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                            ");

            
            #line 205 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                             if (User.CanView("T_WCCode"))
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <td>\r\n");

WriteLiteral("                                                    ");

            
            #line 208 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </td>\r\n");

            
            #line 210 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                        </tr>\r\n");

            
            #line 212 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                            </table>\r\n                        </div>\r\n           " +
"             <ul");

WriteLiteral(" id=\"Mob_List\"");

WriteLiteral(" class=\"list-group\"");

WriteLiteral(">\r\n");

            
            #line 216 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 216 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                             foreach (var item in Model)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li");

WriteLiteral(" class=\"list-group-item\"");

WriteLiteral(">\r\n");

            
            #line 219 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 219 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                     if (User.CanView("T_WCCode"))
                                    {

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t\t\t<p>\r\n                                            <span");

WriteLiteral(" class=\"text-primary\"");

WriteLiteral("> Select </span> : <span>\r\n");

            
            #line 223 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                            
            
            #line default
            #line hidden
            
            #line 223 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                             if(Convert.ToString(ViewData["BulkOperation"]) == "multiple")
                                            {
												if (ViewData["BulkAssociate"] != null)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 13342), Tuple.Create("\"", 13397)
, Tuple.Create(Tuple.Create("", 13352), Tuple.Create("Update(this,\'", 13352), true)
            
            #line 227 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                    , Tuple.Create(Tuple.Create("", 13365), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 13365), false)
, Tuple.Create(Tuple.Create("", 13373), Tuple.Create("\',\'", 13373), true)
            
            #line 227 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                               , Tuple.Create(Tuple.Create("", 13376), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 13376), false)
, Tuple.Create(Tuple.Create("", 13394), Tuple.Create("\');", 13394), true)
);

WriteLiteral(" />\r\n");

            
            #line 228 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                }
                                                else
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 13637), Tuple.Create("\"", 13689)
, Tuple.Create(Tuple.Create("", 13647), Tuple.Create("Set(this,\'", 13647), true)
            
            #line 231 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                 , Tuple.Create(Tuple.Create("", 13657), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 13657), false)
, Tuple.Create(Tuple.Create("", 13665), Tuple.Create("\',\'", 13665), true)
            
            #line 231 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                            , Tuple.Create(Tuple.Create("", 13668), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 13668), false)
, Tuple.Create(Tuple.Create("", 13686), Tuple.Create("\');", 13686), true)
);

WriteLiteral(" />\r\n");

            
            #line 232 "..\..\Views\T_WCCode\BulkOperation.cshtml"
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

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 13968), Tuple.Create("\"", 14026)
, Tuple.Create(Tuple.Create("", 13978), Tuple.Create("SetSingle(this,\'", 13978), true)
            
            #line 236 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                           , Tuple.Create(Tuple.Create("", 13994), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 13994), false)
, Tuple.Create(Tuple.Create("", 14002), Tuple.Create("\',\'", 14002), true)
            
            #line 236 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                                      , Tuple.Create(Tuple.Create("", 14005), Tuple.Create<System.Object, System.Int32>(item.DisplayValue
            
            #line default
            #line hidden
, 14005), false)
, Tuple.Create(Tuple.Create("", 14023), Tuple.Create("\');", 14023), true)
);

WriteLiteral(" />\r\n");

            
            #line 237 "..\..\Views\T_WCCode\BulkOperation.cshtml"
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

            
            #line 242 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.DisplayValue));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </span>\r\n                          " +
"              </p>\r\n");

            
            #line 245 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </li>\r\n");

            
            #line 247 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </ul>\r\n");

            
            #line 249 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 249 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                         if (Model.Count > 0)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" id=\"pagination\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 252 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                           Write(Html.PagedListPager(Model, page => Url.Action(ActionNameUrl, "T_WCCode", getSortHtmlAttributes(null, true, page, false))));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <div");

WriteLiteral(" class=\"fixPageSize\"");

WriteLiteral(">\r\n                                    Page Size :\r\n");

WriteLiteral("                                    ");

            
            #line 255 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                               Write(Html.DropDownList("PageSize", new SelectList(new Dictionary<string, int> { { "10", 10 }, { "20", 20 }, { "50", 50 }, { "100", 100 } }, "Key", "Value"), new { @id = "pagesizelistT_WCCode", 
									@onchange = "pagesizelistChange(event,'T_WCCode')", 
									@Url = Html.Raw(@Url.Action(ActionNameUrl, "T_WCCode", 
									getSortHtmlAttributes(ViewBag.CurrentSort, ViewBag.Pages == 1 ? false : true,
									null, false), null)) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    <span");

WriteLiteral(" style=\"text-align:right;\"");

WriteLiteral("> Total Count: ");

            
            #line 260 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                                                                              Write(Model.TotalItemCount);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                </div>\r\n                            </di" +
"v>\r\n");

            
            #line 263 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        <" +
"/div>\r\n");

            
            #line 268 "..\..\Views\T_WCCode\BulkOperation.cshtml"
		if (ViewData["BulkAssociate"] != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-sm fixbulkbutton\"");

WriteAttribute("value", Tuple.Create(" value=\"", 15966), Tuple.Create("\"", 16091)
, Tuple.Create(Tuple.Create("", 15974), Tuple.Create("Associate", 15974), true)
, Tuple.Create(Tuple.Create(" ", 15983), Tuple.Create("with", 15984), true)
            
            #line 270 "..\..\Views\T_WCCode\BulkOperation.cshtml"
                  , Tuple.Create(Tuple.Create(" ", 15988), Tuple.Create<System.Object, System.Int32>(GeneratorBase.MVC.Models.ModelConversion.GetDisplayNameOfEntity(ViewData["HostingEntity"].ToString())
            
            #line default
            #line hidden
, 15989), false)
);

WriteLiteral(" onclick=\"UpdateRecords();\"");

WriteLiteral(" />\r\n");

            
            #line 271 "..\..\Views\T_WCCode\BulkOperation.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n  \r\n");

        }
    }
}
#pragma warning restore 1591
