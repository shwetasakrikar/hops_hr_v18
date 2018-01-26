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

namespace GeneratorBase.MVC.Views.ApiHelp.DisplayTemplates
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    
    #line 1 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
    using System.Web.Http;
    
    #line default
    #line hidden
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using GeneratorBase.MVC;
    
    #line 2 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
    using GeneratorBase.MVC.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ApiHelp/DisplayTemplates/HelpPageApiModel.cshtml")]
    public partial class _HelpPageApiModel : GeneratorBase.MVC.CustomWebViewPage<HelpPageApiModel>
    {
        public _HelpPageApiModel()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
   
    Layout = "~/Views/Shared/_LayoutWebApi.cshtml";
   
    var description = Model.ApiDescription;
    bool hasParameters = description.ParameterDescriptions.Count > 0;
    bool hasRequestSamples = Model.SampleRequests.Count > 0;
    bool hasResponseSamples = Model.SampleResponses.Count > 0;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\r\n<h1>");

            
            #line 13 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
Write(description.HttpMethod.Method);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 13 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
                              Write(description.RelativePath);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n<div>\r\n");

            
            #line 15 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
     if (description.Documentation != null)
    {

            
            #line default
            #line hidden
WriteLiteral("        <p>");

            
            #line 17 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
      Write(description.Documentation);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 18 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <p>No documentation available.</p>\r\n");

            
            #line 22 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 24 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
    
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
     if (hasParameters || hasRequestSamples)
    {

            
            #line default
            #line hidden
WriteLiteral("        <h2>Request Information</h2>\r\n");

            
            #line 27 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
        if (hasParameters)
        {

            
            #line default
            #line hidden
WriteLiteral("            <h3>Parameters</h3>\r\n");

            
            #line 30 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
            
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
       Write(Html.DisplayFor(apiModel => apiModel.ApiDescription.ParameterDescriptions, "Parameters"));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
                                                                                                     
        }
        if (hasRequestSamples)
        {

            
            #line default
            #line hidden
WriteLiteral("            <h3>Request body formats</h3>\r\n");

            
            #line 35 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
            
            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
       Write(Html.DisplayFor(apiModel => apiModel.SampleRequests, "Samples"));

            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
                                                                            
        }
    } 

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 39 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
    
            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
     if (hasResponseSamples)
    {

            
            #line default
            #line hidden
WriteLiteral("        <h2>Response Information</h2> \r\n");

WriteLiteral("        <h3>Response body formats</h3>\r\n");

            
            #line 43 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
        
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
   Write(Html.DisplayFor(apiModel => apiModel.SampleResponses, "Samples"));

            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
                                                                         
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("   ");

            
            #line 47 "..\..\Views\ApiHelp\DisplayTemplates\HelpPageApiModel.cshtml"
Write(Scripts.Render("~/bundles/WebApi"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591