using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeneratorBase.MVC.Models;
using PagedList;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq.Expressions;
using System.IO;
namespace GeneratorBase.MVC.Controllers
{
    public class CompanyProfileController : Controller
    {
        private ICompanyProfileRepository _repository;
        public CompanyProfileController()
            : this(new CompanyProfileRepository())
        {
        }
        public CompanyProfileController(ICompanyProfileRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Edit(long? tenantId)
        {
            if (((CustomPrincipal)User).CanEditAdminFeature("UserInterfaceSetting"))
            {
                CompanyProfile cp = _repository.GetCompanyProfile(((CustomPrincipal)User),tenantId);
                if (cp == null)
                    return RedirectToAction("Index");

                ViewBag.TenantList = _repository.SetViewBag((CustomPrincipal)User,tenantId); //new SelectList(list, "Key", "Value", tenantId);

                return View(cp);
            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Edit(CompanyProfile cp, HttpPostedFileBase Icon, HttpPostedFileBase Logo, HttpPostedFileBase LegalInformationAttach, HttpPostedFileBase PrivacyPolicyAttach, HttpPostedFileBase TermsOfServiceAttach)
        {
            if (((CustomPrincipal)User).CanEditAdminFeature("UserInterfaceSetting"))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        string path = Server.MapPath("~/logo/");
                        string pathPolicyAndService = Server.MapPath("~/PolicyAndService/");

                        var tenantSuffix = "";
                        if(cp.TenantId.HasValue && cp.TenantId.Value > 0)
                        {
                            tenantSuffix =Convert.ToString(cp.TenantId.Value);
                        }

                        if (Icon != null)
                        {
                            cp.Icon = "logo" + tenantSuffix + ".gif";
                            Icon.SaveAs(path + "logo" + tenantSuffix + ".gif");
                        }
                        if (Logo != null)
                        {
                            cp.Logo = "logo_white" + tenantSuffix + ".gif";
                            Logo.SaveAs(path + "logo_white" + tenantSuffix + ".png");
                        }
                        if (LegalInformationAttach != null)
                        {
                            cp.LegalInformation = "logo_white" + tenantSuffix + ".gif";
                            LegalInformationAttach.SaveAs(pathPolicyAndService + tenantSuffix + "Licensing.pdf");

                        }
                        if (PrivacyPolicyAttach != null)
                        {
                            cp.LegalInformation = "logo_white" + tenantSuffix + ".gif";
                            LegalInformationAttach.SaveAs(pathPolicyAndService + tenantSuffix + "PrivacyPolicy.pdf");

                        }
                        if (TermsOfServiceAttach != null)
                        {
                            cp.LegalInformation = "logo_white" + tenantSuffix + ".gif";
                            TermsOfServiceAttach.SaveAs(pathPolicyAndService + tenantSuffix + "Terms_Of_Service.pdf");

                        }
                        _repository.EditCompanyProfile(cp);
                        //journaling
                        DoAuditEntry.AddJournalEntryCommon(((CustomPrincipal)User),null,"Company Profile Data Modified","Company Profile");
                        return RedirectToAction("Index", "Admin");
                    }
                    catch (Exception ex)
                    {
                        //error msg for failed edit in XML file
                        ModelState.AddModelError("", "Error editing record. " + ex.Message);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

