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

namespace GeneratorBase.MVC.Views.FileDocument
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/FileDocument/CreatePartial.cshtml")]
    public partial class CreatePartial : GeneratorBase.MVC.CustomWebViewPage<GeneratorBase.MVC.Models.FileDocument>
    {
        public CreatePartial()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\FileDocument\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.FileDocumentIsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\FileDocument\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.FileDocumentIsHiddenRule));

            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                   ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 8 "..\..\Views\FileDocument\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.FileDocumentIsGroupsHiddenRule))
    {
        
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\FileDocument\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.FileDocumentIsGroupsHiddenRule));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                         ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 14 "..\..\Views\FileDocument\CreatePartial.cshtml"
  
    if (!string.IsNullOrEmpty(ViewBag.FileDocumentIsSetValueUIRule))
    {
        
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\FileDocument\CreatePartial.cshtml"
   Write(Html.Raw(ViewBag.FileDocumentIsSetValueUIRule));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                       ;
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 20 "..\..\Views\FileDocument\CreatePartial.cshtml"
 using (Html.BeginForm("Create", "FileDocument",new {UrlReferrer = Convert.ToString(ViewData["FileDocumentParentUrl"]), IsDDAdd = ViewBag.IsDDAdd }, FormMethod.Post, new { enctype = "multipart/form-data",id="frmFileDocument" }))
{
   
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\FileDocument\CreatePartial.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\FileDocument\CreatePartial.cshtml"
                           ;
    Html.ValidationSummary(true);
    Html.EnableClientValidation();

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ErrMsg\"");

WriteLiteral(" />\r\n");

            
            #line 26 "..\..\Views\FileDocument\CreatePartial.cshtml"
	
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                                                                                                    

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" id=\"errorContainer\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"errorsMsg\"");

WriteLiteral("></div>\r\n        <div");

WriteLiteral(" id=\"errors\"");

WriteLiteral("></div>\r\n    </div>\r\n");

            
            #line 31 "..\..\Views\FileDocument\CreatePartial.cshtml"
	 

            
            #line default
            #line hidden
WriteLiteral("\t <div");

WriteLiteral(" id=\"divDisplayThresholdLimit\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n\t</div>\r\n");

WriteLiteral("\t <div");

WriteLiteral(" id=\"divDisplayBRmsgMandatory\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n\t</div>\r\n");

WriteLiteral("\t<div");

WriteLiteral(" id=\"divDisplayBRmsgBeforeSaveProp\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n\t</div>\r\n");

WriteLiteral("\t<div");

WriteLiteral(" id=\"divDisplayCodeFragment\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n\t</div>\r\n");

            
            #line 40 "..\..\Views\FileDocument\CreatePartial.cshtml"


            
            #line default
            #line hidden
WriteLiteral("\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12 col-sm-12 col-xs-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"AppForm\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"\"");

WriteLiteral(">\r\n               \t\t\t\t\t<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t\t\t\t       \r\n");

            
            #line 47 "..\..\Views\FileDocument\CreatePartial.cshtml"
			 
            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\FileDocument\CreatePartial.cshtml"
              if(User.CanView("FileDocument","DocumentName"))
								{

            
            #line default
            #line hidden
WriteLiteral("     <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvDocumentName\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 51 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.DocumentName));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 54 "..\..\Views\FileDocument\CreatePartial.cshtml"
                               Write(Html.TextBoxFor(model => model.DocumentName, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 55 "..\..\Views\FileDocument\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.DocumentName));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 59 "..\..\Views\FileDocument\CreatePartial.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 62 "..\..\Views\FileDocument\CreatePartial.cshtml"
			 
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\FileDocument\CreatePartial.cshtml"
              if(User.CanView("FileDocument","Description"))
								{

            
            #line default
            #line hidden
WriteLiteral("     <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvDescription\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n                                   <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 66 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                                          Write(Html.LabelFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\r\n");

WriteLiteral("                                    ");

            
            #line 69 "..\..\Views\FileDocument\CreatePartial.cshtml"
                               Write(Html.TextBoxFor(model => model.Description, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 70 "..\..\Views\FileDocument\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\t\t\t\t</div>\r\n");

            
            #line 74 "..\..\Views\FileDocument\CreatePartial.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\r\n");

            
            #line 77 "..\..\Views\FileDocument\CreatePartial.cshtml"
				 
            
            #line default
            #line hidden
            
            #line 77 "..\..\Views\FileDocument\CreatePartial.cshtml"
                  if(User.CanAdd("Document"))
                 { 
				   if(User.CanView("FileDocument","AttachDocument") && User.CanView("Document"))
								{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvAttachDocument\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t\t<label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 83 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                                                   Write(Html.LabelFor(model => model.AttachDocument));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div");

WriteLiteral(" style=\"position:relative;\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<a");

WriteLiteral(" class=\'btn btn-primary btnupload\'");

WriteLiteral(" href=\'javascript:;\'");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tUpload File\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<input");

WriteLiteral(" id=\"AttachDocument\"");

WriteLiteral("  type=\"file\"");

WriteLiteral(" style=\'position:absolute;z-index:2;top:0;left:0;filter: alpha(opacity=0);-ms-fil" +
"ter:\"progid:DXImageTransform.Microsoft.Alpha(Opacity=0)\";opacity:0;background-co" +
"lor:transparent;color:transparent;width:105px;\'");

WriteLiteral(" name=\"AttachDocument\"");

WriteLiteral(" onchange=\'$(\"#upload-file-infoAttachDocument\").html($(this).val());\'");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t\t\t\t\t&nbsp;\r\n\t\t\t\t\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\'label uploadlblFix\'");

WriteLiteral(" id=\"upload-file-infoAttachDocument\"");

WriteLiteral("></span>\r\n\t\t\t\t\t\t\t\t\t\t\t</div> \r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r" +
"\n");

            
            #line 96 "..\..\Views\FileDocument\CreatePartial.cshtml"
	   }

				  
				 }

            
            #line default
            #line hidden
WriteLiteral("   ");

            
            #line 100 "..\..\Views\FileDocument\CreatePartial.cshtml"
    if(User.CanView("FileDocument","DateCreated"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t  <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvDateCreated\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 103 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                                       Write(Html.LabelFor(model => model.DateCreated));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n                                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerDateCreated\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 107 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                   Write(Html.TextBoxFor(model => model.DateCreated, new { @class = "form-control" ,@Value = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") ,@format = "MM/DD/YYYY hh:mm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        \r\n\t\t\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"input-group-addon btn-default calendar\"");

WriteLiteral(">\r\n                                           <i");

WriteLiteral(" class=\"fa fa-calendar\"");

WriteLiteral("></i>\r\n                                        </span>\r\n                         " +
"           </div>\r\n");

WriteLiteral("                                    ");

            
            #line 113 "..\..\Views\FileDocument\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.DateCreated));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\r\n                  " +
"              <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
                                    $(function () {
										$('#DateCreated').datetimepicker({IsRequired: true});
                                        $('#datetimepickerDateCreated').datetimepicker({IsRequired: true});
                                    });
                                </script>
                            </div>
");

            
            #line 125 "..\..\Views\FileDocument\CreatePartial.cshtml"
							}

            
            #line default
            #line hidden
WriteLiteral("\t\t  \r\n                          \r\n");

            
            #line 128 "..\..\Views\FileDocument\CreatePartial.cshtml"
   
            
            #line default
            #line hidden
            
            #line 128 "..\..\Views\FileDocument\CreatePartial.cshtml"
    if(User.CanView("FileDocument","DateLastUpdated"))
{

            
            #line default
            #line hidden
WriteLiteral("\t\t  <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvDateLastUpdated\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(" >");

            
            #line 131 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                                       Write(Html.LabelFor(model => model.DateLastUpdated));

            
            #line default
            #line hidden
WriteLiteral(" <span");

WriteLiteral(" class=\"text-danger-reg\"");

WriteLiteral(">*</span></label>\r\n                                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" id=\"datetimepickerDateLastUpdated\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 135 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                   Write(Html.TextBoxFor(model => model.DateLastUpdated, new { @class = "form-control" ,@Value = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") ,@format = "MM/DD/YYYY hh:mm" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        \r\n\t\t\t\t\t\t\t\t\t\t<span");

WriteLiteral(" class=\"input-group-addon btn-default calendar\"");

WriteLiteral(">\r\n                                           <i");

WriteLiteral(" class=\"fa fa-calendar\"");

WriteLiteral("></i>\r\n                                        </span>\r\n                         " +
"           </div>\r\n");

WriteLiteral("                                    ");

            
            #line 141 "..\..\Views\FileDocument\CreatePartial.cshtml"
                               Write(Html.ValidationMessageFor(model => model.DateLastUpdated));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\t\t\t\t\t\t\t\t</div>\r\n                                </div>\r\n\t\r\n                  " +
"              <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
                                    $(function () {
										$('#DateLastUpdated').datetimepicker({IsRequired: true});
                                        $('#datetimepickerDateLastUpdated').datetimepicker({IsRequired: true});
                                    });
                                </script>
                            </div>
");

            
            #line 153 "..\..\Views\FileDocument\CreatePartial.cshtml"
							}

            
            #line default
            #line hidden
WriteLiteral("\t\t  \r\n                          \r\n");

            
            #line 156 "..\..\Views\FileDocument\CreatePartial.cshtml"
 if(User.CanView("FileDocument","T_EmployeeDocumentsID"))
	{

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\'col-sm-6 col-md-6 col-xs-12\'");

WriteLiteral(" id=\"dvT_EmployeeDocumentsID\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\'form-group\'");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"col-sm-5 col-md-5 col-xs-12\"");

WriteLiteral(">");

            
            #line 160 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                                  Write(Html.LabelFor(model => model.T_EmployeeDocumentsID));

            
            #line default
            #line hidden
WriteLiteral(" </label>\r\n\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"input-group col-sm-7 col-md-7 col-xs-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(">\r\n");

WriteLiteral("\t\t\t\t\t\t\t\t\t");

            
            #line 163 "..\..\Views\FileDocument\CreatePartial.cshtml"
                               Write(Html.DropDownList("T_EmployeeDocumentsID", null, "-- Select --", new {       @class = "chosen-select form-control", @HostingName = "T_Employee", @dataurl = Url.Action("GetAllValue", "T_Employee",new { caller = "T_EmployeeDocumentsID" }) }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\t\t\t");

            
            #line 164 "..\..\Views\FileDocument\CreatePartial.cshtml"
       Write(Html.ValidationMessageFor(model => model.T_EmployeeDocumentsID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 165 "..\..\Views\FileDocument\CreatePartial.cshtml"
			
            
            #line default
            #line hidden
            
            #line 165 "..\..\Views\FileDocument\CreatePartial.cshtml"
             if ( User.CanAdd("T_Employee"))
				{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n\t\t\t\t<a");

WriteLiteral(" class=\"btn btn-default btn ie8fix\"");

WriteLiteral(" id=\"addT_Employee\"");

WriteLiteral("  data-target=\"#dvPopup\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8404), Tuple.Create("\"", 8707)
            
            #line 168 "..\..\Views\FileDocument\CreatePartial.cshtml"
                          , Tuple.Create(Tuple.Create("", 8414), Tuple.Create<System.Object, System.Int32>(Html.Raw("OpenPopUpEntity('addPopup','Employee','dvPopup','" + Url.Action("CreateQuick", "T_Employee", new { UrlReferrer = Request.Url, HostingEntityName = @Convert.ToString(ViewData["HostingEntity"]), HostingEntityID = @Convert.ToString(ViewData["HostingEntityID"]), IsAddPop=true }) + "')")
            
            #line default
            #line hidden
, 8414), false)
);

WriteLiteral(">\r\n\t\t\t\t\t<span");

WriteLiteral(" class=\"glyphicon glyphicon-plus-sign\"");

WriteLiteral("></span>\r\n\t\t\t\t</a>\r\n\t\t\t</div>\r\n");

            
            #line 172 "..\..\Views\FileDocument\CreatePartial.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t                                \r\n                            </div>\r\n\t\t\t\t\t\t\t</" +
"div>\r\n                        </div>\r\n                    </div>\r\n");

            
            #line 178 "..\..\Views\FileDocument\CreatePartial.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("         </div>\r\n                        </div>\r\n                    </div>\r\n    " +
"            </div>\r\n        </div>\r\n");

WriteLiteral("\t\t<a");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9098), Tuple.Create("\"", 9154)
, Tuple.Create(Tuple.Create("", 9108), Tuple.Create("goBack(\'", 9108), true)
            
            #line 184 "..\..\Views\FileDocument\CreatePartial.cshtml"
, Tuple.Create(Tuple.Create("", 9116), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","FileDocument")
            
            #line default
            #line hidden
, 9116), false)
, Tuple.Create(Tuple.Create("", 9151), Tuple.Create("\');", 9151), true)
);

WriteLiteral(" alt=\"Cancel\"");

WriteLiteral(" title=\"Cancel\"");

WriteLiteral(">Cancel</a>\r\n");

            
            #line 185 "..\..\Views\FileDocument\CreatePartial.cshtml"
          
            
            #line default
            #line hidden
            
            #line 185 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                                                                                                                                                     

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" alt=\"Create\"");

WriteLiteral(" title=\"Create\"");

WriteLiteral("/>\r\n");

            
            #line 187 "..\..\Views\FileDocument\CreatePartial.cshtml"
    if (ViewBag.IsDDAdd == null && User.CanEdit("FileDocument"))
    {

            
            #line default
            #line hidden
WriteLiteral("\t<input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"command\"");

WriteLiteral(" value=\"Create & Continue\"");

WriteLiteral(" class=\"btn btn-primary btn-sm\"");

WriteLiteral(" alt=\"Create & Continue\"");

WriteLiteral(" title=\"Create & Continue\"");

WriteLiteral("/>\r\n");

            
            #line 190 "..\..\Views\FileDocument\CreatePartial.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("\t <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"hdncommand\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n");

WriteLiteral("\t<br/>");

WriteLiteral("<br/>\r\n");

            
            #line 193 "..\..\Views\FileDocument\CreatePartial.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral(@"	<script>
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

            
            #line 214 "..\..\Views\FileDocument\CreatePartial.cshtml"
  
		var businessrule = User.businessrules.Where(p => p.EntityName == "FileDocument").ToList();
		
if ((businessrule != null && businessrule.Count > 0) )
    {

            
            #line default
            #line hidden
WriteLiteral(@"        <script>
            $(""form"").submit(function (event) {
			if (!$(""#frmFileDocument"").valid()) return;
			var flag = true;
							document.getElementById(""ErrMsg"").innerHTML = """";
                var dataurl = """";
                var form = """";
                var inlinecount = ""0"";
                //var form = $(this).serialize();
 form = $(""#frmFileDocument"").serialize();
  
                dataurl = """);

            
            #line 230 "..\..\Views\FileDocument\CreatePartial.cshtml"
                      Write(Url.Action("businessruletype", "FileDocument", new { ruleType = "OnCreate"}));

            
            #line default
            #line hidden
WriteLiteral(@""";
                flag = ApplyBusinessRuleOnSubmit(dataurl, ""FileDocument"", false, ""ErrMsg"", form);
				//business rules on inline associations
				if (flag) {
				                    $('input:hidden[name=""hdncommand""]').val($(document.activeElement).val());

					 $(""#frmFileDocument"").find(':input').removeAttr('disabled');
                }
				return flag;
			 });	
        </script>
");

            
            #line 241 "..\..\Views\FileDocument\CreatePartial.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral(@"	<script>
            $(""input[type='submit']"").click(function (event) {
			if (!$(""#frmFileDocument"").valid()) return;
                var $this = $(this);
                $('input:hidden[name=""hdncommand""]').val($this.val());
            });
	</script>
");

            
            #line 251 "..\..\Views\FileDocument\CreatePartial.cshtml"
           
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n<script");

WriteLiteral(" type=\'text/javascript\'");

WriteLiteral(@">
    $(document).ready(function () {
        try {
		 focusOnControl('frmFileDocument');
        }
        catch (ex) { }
    });
</script>
<script>
    $(document).ready(function () {
        try {
            var hostingEntityName = """";
            if ('");

            
            #line 268 "..\..\Views\FileDocument\CreatePartial.cshtml"
            Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\'.length > 0) {\r\n                hostingEntityName = \'");

            
            #line 269 "..\..\Views\FileDocument\CreatePartial.cshtml"
                                Write(Convert.ToString(ViewData["AssociatedType"]));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n                 $(\'#\' + hostingEntityName + \'ID\').attr(\"lock\",\"true\");\r\n\t\t\t\t" +
"  $(\'#\' + hostingEntityName + \'ID\').trigger(\"change\");\r\n            }\r\n\t\t\t\r\n    " +
"    }\r\n        catch (ex) { }\r\n\t\t});\r\n</script>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591