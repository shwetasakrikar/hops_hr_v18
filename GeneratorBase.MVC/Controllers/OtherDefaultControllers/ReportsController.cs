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
using System.Configuration;
using GeneratorBase.MVC.WebReference;
using System.Text;
using System.Security.Principal;
namespace GeneratorBase.MVC.Controllers
{
    public class ReportsController : BaseController
    {
        public ActionResult ResultShow(string ReportName, string id)
        {
            var rptName = ReportName.Substring(ReportName.LastIndexOf('/') + 1);
            ViewBag.Name = ReportName.Split('&')[0]; ;
            int param = ReportName.Split('&').Length;
            ViewBag.IsAuthenticated = false;
            if (param == 1)
			{
                ViewBag.ReportName = ReportName;
				if (!User.IsAdmin)
					ViewBag.IsAuthenticated = GetAllReport(rptName, true).Count() > 0 ? true : false;
			}
            else
                ViewBag.ReportName = ConfigurationManager.AppSettings["ReportFolder"] + "/" + ReportName;

            return View();
        }
        public ActionResult Index(int? page, string searchString, int? itemsPerPage)
        {
            var items = GetAllReport(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            var _Reports = items.OrderBy(o => o.Name);
            if (Request.IsAjaxRequest())
            {
                return PartialView("IndexPartial", _Reports.ToPagedList(pageNumber, pageSize));
            }
            return View(_Reports.ToPagedList(pageNumber, pageSize));
        }

        public IEnumerable<CatalogItem> GetAllReport(string searchString, bool IsReportName = false)
        {
            var items = new HashSet<CatalogItem>();
            var log = new StringBuilder();
            log.AppendLine("Report Log:");
            try
            {
                var rs = new ReportingService2005();
                rs.Url = CommonFunction.Instance.ReportPath() + @"/ReportService2005.asmx";
                log.AppendLine(String.Format("\tTarget: {0}", rs.Url));
                rs.Credentials = new System.Net.NetworkCredential(
                    CommonFunction.Instance.ReportUser(),
                    CommonFunction.Instance.ReportPass()
                );
                log.AppendLine("Credentials set.");
                var root = CommonFunction.Instance.ReportFolder();
                log.AppendLine(String.Format("Listing children under: {0}", CommonFunction.Instance.ReportFolder()));
                var children = rs.ListChildren(root, true)
                                 .Where(c => c.Type == ItemTypeEnum.Report)
                                 .Where(c => !c.Hidden);

                log.AppendLine(String.Format("Retrieved {0} items.", children.Count()));

                var filtered = FilterItemsByString(children, log, searchString, IsReportName);
                items = FilterItemsByRole(filtered, log);
            }
            catch (Exception ex)
            {
                var exLog = new StringBuilder(log.ToString());
                exLog.AppendLine("Credentials:");
                exLog.AppendLine(String.Format("\tUser: {0}", CommonFunction.Instance.ReportUser()));
                exLog.AppendLine(String.Format("\tPassword: {0}", CommonFunction.Instance.ReportPass()));
                exLog.AppendLine(String.Format("\tDomain: {0}", CommonFunction.Instance.DomainName()));

                Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception(exLog.ToString(), ex));

                items = new HashSet<CatalogItem>();
            }
            log.AppendLine(String.Format("Found {0} reports.", items.Count));
            ViewBag.Log = log.ToString();
            return items;
        }

        private IEnumerable<CatalogItem> FilterItemsByString(IEnumerable<CatalogItem> children, StringBuilder log, string searchString, bool IsReportName = false)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.CurrentFilter = searchString;
                if (IsReportName)
                {
                    children = children.Where(c => (!String.IsNullOrEmpty(c.Name) && c.Name == searchString));
                    return children;
                }
                children = children.Where(c => (!String.IsNullOrEmpty(c.Name) && c.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                                            || (!String.IsNullOrEmpty(c.Description) && c.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0));
            }
            return children;
        }
        private HashSet<CatalogItem> FilterItemsByRole(IEnumerable<CatalogItem> children, StringBuilder log)
        {
            var items = new HashSet<CatalogItem>();
            if (!this.User.IsAdmin)
            {
                log.AppendLine("Not an admin.");
                var roles = this.User.GetRoles();
                foreach (var role in roles)
                {
                    log.AppendLine(String.Format("Get Id for: {0}", role));
                    var RoleList = (new GeneratorBase.MVC.Models.CustomRoleProvider()).GetAllRolesReport();
                    var RoleName = RoleList.FirstOrDefault(r => r.Value == role);
                    if (RoleName.Value != null)
                    {
                        var reportinroles = db.ReportsInRoles.Where(r => r.RoleId == RoleName.Key).Select(s => s.ReportId);
                        log.AppendLine(String.Format("Finding matching reports for: {0}", role));
                        foreach (var child in children.Where(c => reportinroles.Contains(c.ID)))
                        {
                            log.AppendLine(String.Format("\tMatch found: {0}", child.Name));
                            items.Add(child);
                        }
                    }
                }
            }
            else
            {
                log.AppendLine("Admin!");
                items = new HashSet<CatalogItem>(children);
            }
            return items;
        }

        public ActionResult Edit(string id, string UrlReferrer, bool? IsAddPop)
        {
            if (!User.CanAdd("Reports"))
            {
                return RedirectToAction("Index", "Error");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportsInRole objreportsinrole = new ReportsInRole();
            var reportsinrole = db.ReportsInRoles.Where(p => p.ReportId == id);
            objreportsinrole.ReportId = id;
            if (reportsinrole.Count() > 0)
                objreportsinrole.SelectedRoleId = reportsinrole.Select(r => r.RoleId).ToArray();

            var RoleList = (new GeneratorBase.MVC.Models.CustomRoleProvider()).GetAllRolesReport();
            ViewBag.RoleId = RoleList;
            ViewBag.IsAddPop = IsAddPop;
            ViewData["ReportsInRoleParentUrl"] = UrlReferrer;
            return View(objreportsinrole);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,ReportId,RoleId,SelectedRoleId")] ReportsInRole reportsinrole, string UrlReferrer, bool? IsAddPop)
        {
            if (ModelState.IsValid || reportsinrole.Id == 0)
            {
                var objreportinrole = db.ReportsInRoles.Where(r => r.ReportId == reportsinrole.ReportId).ToList();
                foreach (var obj in objreportinrole)
                {
                    db.ReportsInRoles.Remove(obj);
                    db.SaveChanges();
                }
                if (reportsinrole.SelectedRoleId != null)
                {
                    foreach (var role in reportsinrole.SelectedRoleId)
                    {
                        ReportsInRole objreportinroleadd = new ReportsInRole();
                        objreportinroleadd.ReportId = reportsinrole.ReportId;
                        objreportinroleadd.RoleId = role;
                        db.Entry(objreportinroleadd).State = EntityState.Added;
                        db.ReportsInRoles.Add(objreportinroleadd);
                    }
                    db.SaveChanges();
                }
                return Json("FROMPOPUP", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errors = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors += error.ErrorMessage + ".  ";
                    }
                }
                return Json(errors, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
    }
}

