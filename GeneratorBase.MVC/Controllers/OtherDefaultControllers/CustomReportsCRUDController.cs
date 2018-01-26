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
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.ComponentModel.DataAnnotations;
namespace GeneratorBase.MVC.Controllers
{
    public partial class CustomReportsController : BaseController
    {
        private ApplicationDbContext UserContext = new ApplicationDbContext();
        // GET: /CustomReports/
        public ActionResult Index(string currentFilter, string searchString, string sortBy, string isAsc, int? page, int? itemsPerPage, string HostingEntity, int? HostingEntityID, string AssociatedType, bool? IsExport, bool? IsDeepSearch, bool? IsFilter, bool? RenderPartial, string BulkOperation, string parent, string Wfsearch, string caller, bool? BulkAssociate, string viewtype, string isMobileHome)
        {
            if (string.IsNullOrEmpty(isAsc) && !string.IsNullOrEmpty(sortBy))
            {
                isAsc = "ASC";
            }
            ViewBag.isAsc = isAsc;
            ViewBag.CurrentSort = sortBy;
            ViewData["HostingEntity"] = HostingEntity;
            ViewData["HostingEntityID"] = HostingEntityID;
            ViewData["AssociatedType"] = AssociatedType;
            ViewData["IsFilter"] = IsFilter;
            ViewData["BulkOperation"] = BulkOperation;
            ViewData["caller"] = caller;
            if (!string.IsNullOrEmpty(viewtype))
            {
                viewtype = viewtype.Replace("?IsAddPop=true", "");
                ViewBag.TemplatesName = viewtype;
            }
            if (searchString != null)
                page = null;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
            var lstCustomReports = from s in db.CustomReportss
                                   select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstCustomReports = searchRecords(lstCustomReports, searchString.ToUpper(), IsDeepSearch);
            }
            if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstCustomReports = sortRecords(lstCustomReports, sortBy, isAsc);
            }
            else lstCustomReports = lstCustomReports.OrderByDescending(c => c.Id);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Pages = page;
            if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "CustomReports"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "CustomReports"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
            //Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "CustomReports"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "CustomReports"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
            var _CustomReports = lstCustomReports.Include(t => t.createdbyuser);

            if (Convert.ToBoolean(IsExport))
            {
                pageNumber = 1;
                if (_CustomReports.Count() > 0)
                    pageSize = _CustomReports.Count();
                return View("ExcelExport", _CustomReports.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                if (pageNumber > 1)
                {
                    var totalListCount = _CustomReports.Count();
                    int quotient = totalListCount / pageSize;
                    var remainder = totalListCount % pageSize;
                    var maxpagenumber = quotient + (remainder > 0 ? 1 : 0);
                    if (pageNumber > maxpagenumber)
                    {
                        pageNumber = 1;
                    }
                }
            }
            if (!(RenderPartial == null ? false : RenderPartial.Value) && !Request.IsAjaxRequest())
            {
                if (string.IsNullOrEmpty(viewtype))
                    viewtype = "IndexPartial";
                return View(_CustomReports.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                if (BulkOperation != null && (BulkOperation == "single" || BulkOperation == "multiple"))
                {
                    ViewData["BulkAssociate"] = BulkAssociate;
                    if (!string.IsNullOrEmpty(caller))
                    {
                        FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
                        _CustomReports = _fad.FilterDropdown<CustomReports>(User, _CustomReports, "CustomReports", caller);
                    }
                    if (Convert.ToBoolean(BulkAssociate))
                    {
                        if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
                            return PartialView("BulkOperation", sortRecords(lstCustomReports.Except(_CustomReports), sortBy, isAsc).ToPagedList(pageNumber, pageSize));
                        else
                            return PartialView("BulkOperation", lstCustomReports.Except(_CustomReports).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
                            return PartialView("BulkOperation", _CustomReports.ToPagedList(pageNumber, pageSize));
                        else
                            return PartialView("BulkOperation", _CustomReports.OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
                    }
                }
                else
                {

                    if (ViewBag.TemplatesName == null)
                    {
                        if (!string.IsNullOrEmpty(isMobileHome))
                        {
                            pageSize = _CustomReports.Count() == 0 ? 1 : _CustomReports.Count();

                        }
                        return PartialView("IndexPartial", _CustomReports.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(isMobileHome))
                        {
                            pageSize = _CustomReports.Count() == 0 ? 1 : _CustomReports.Count();
                        }
                        return PartialView(ViewBag.TemplatesName, _CustomReports.ToPagedList(pageNumber, pageSize));
                    }
                }
            }
        }
        // GET: /CustomReports/Details/5
        public ActionResult Details(int? id, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomReports customreports = db.CustomReportss.Find(id);
            if (customreports == null)
            {
                return HttpNotFound();
            }
            ViewData["AssociatedType"] = AssociatedType;
            ViewData["HostingEntityName"] = HostingEntityName;
            ViewBagForReportsEdit(customreports);
            LoadViewDataBeforeOnEdit(customreports);
            return View("Details", customreports);

        }
        public ActionResult Cancel(string UrlReferrer)
        {
            if (!string.IsNullOrEmpty(UrlReferrer))
            {
                return Redirect(UrlReferrer);
            }
            else
                return RedirectToAction("Index");
        }
        public void ViewBagForReports()
        {
            Dictionary<string, string> ResultPropertyDict = new Dictionary<string, string>();
            ViewBag.ResultPropertyDD = new SelectList(ResultPropertyDict, "Key", "Value");

            Dictionary<string, string> CrossTabRowDict = new Dictionary<string, string>();
            ViewBag.CrossTabRowDD = new SelectList(CrossTabRowDict, "Key", "Value");

            Dictionary<string, string> CrossTabColumnDict = new Dictionary<string, string>();
            ViewBag.CrossTabColumnDD = new SelectList(CrossTabColumnDict, "Key", "Value");

            Dictionary<string, string> AggregateEntityDict = new Dictionary<string, string>();
            ViewBag.AggregateEntityDD = new SelectList(AggregateEntityDict, "Key", "Value");

            Dictionary<string, string> AggregatePropertyDict = new Dictionary<string, string>();
            ViewBag.AggregatePropertyDD = new SelectList(AggregatePropertyDict, "Key", "Value");

            Dictionary<string, string> AggregateFunctionDict = new Dictionary<string, string>();
            ViewBag.AggregateFunctionDD = new SelectList(AggregateFunctionDict, "Key", "Value");

            Dictionary<string, string> FilterPropertyDict = new Dictionary<string, string>();
            ViewBag.FilterPropertyDD = new SelectList(FilterPropertyDict, "Key", "Value");

            Dictionary<string, string> FilterConditionDict = new Dictionary<string, string>();
            ViewBag.FilterConditionDD = new SelectList(FilterConditionDict, "Key", "Value");

            Dictionary<string, string> SelectPropertyDict = new Dictionary<string, string>();
            ViewBag.SelectPropertyDD = new SelectList(SelectPropertyDict, "Key", "Value");

            Dictionary<string, string> SelectValueFromListDict = new Dictionary<string, string>();
            ViewBag.SelectValueFromListDD = new SelectList(SelectValueFromListDict, "Key", "Value");

            ViewBag.EntityNameDD = new SelectList(EnityDictionary(), "Key", "Value");
        }
        // GET: /CustomReports/Create
        public ActionResult Create(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype)
        {
            ViewBagForReports();
            if (!User.CanAdd("CustomReports"))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
            if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            ViewData["CustomReportsParentUrl"] = UrlReferrer;
            ViewData["AssociatedType"] = AssociatedType;
            ViewData["HostingEntityName"] = HostingEntityName;
            ViewData["HostingEntityID"] = HostingEntityID;
            LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
            ViewBag.CustomReportsIsHiddenRule = checkHidden("CustomReports", "OnCreate");

            return View();
        }
        // POST: /CustomReports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ConcurrencyKey,ReportName,CreatedOn,ReportType,CreatedByUserID,Description,EntityName,ResultProperty,ColumnOrder,OrderBy,GroupBy,CrossTabRow,CrossTabColumn,AggregateEntity,AggregateProperty,AggregateFunction,FilterProperty,FilterCondition,FilterType,FilterValue,SelectValueFromList,SelectProperty,RelatedEntity,ForeignKeyEntity,RelationName,EntityValues,CrossTabPropertyValues,QueryConditionValues,RelationsValues,OtherValues")] CustomReports customreports, string UrlReferrer, bool? IsDDAdd)
        {
            ViewBagForReports();
            if (ModelState.IsValid)
            {
                string command = Request.Form["hdncommand"];
                db.CustomReportss.Add(customreports);
                db.SaveChanges();
                if (command == "Create & Continue")
                    return RedirectToAction("Edit", new { Id = customreports.Id, UrlReferrer = UrlReferrer });
                if (!string.IsNullOrEmpty(UrlReferrer))
                    return Redirect(UrlReferrer);
                else return RedirectToAction("Index");
            }

            if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
            LoadViewDataAfterOnCreate(customreports);
            return View(customreports);
        }
        // GET: /CustomReports/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {

            if (!User.CanEdit("CustomReports"))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomReports customreports = db.CustomReportss.Find(id);
            if (customreports == null)
            {
                return HttpNotFound();
            }
            if (UrlReferrer != null)
                ViewData["CustomReportsParentUrl"] = UrlReferrer;
            if (ViewData["CustomReportsParentUrl"] == null && Request.UrlReferrer != null && !Request.UrlReferrer.AbsolutePath.EndsWith("/CustomReports") && !Request.UrlReferrer.AbsolutePath.EndsWith("/CustomReports/Edit/" + customreports.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/CustomReports/Create"))
                ViewData["CustomReportsParentUrl"] = Request.UrlReferrer;
            ViewData["HostingEntityName"] = HostingEntityName;
            ViewData["AssociatedType"] = AssociatedType;
            LoadViewDataBeforeOnEdit(customreports);
            ViewBagForReportsEdit(customreports);

            ViewBag.CustomReportsIsHiddenRule = checkHidden("CustomReports", "OnEdit");
            return View(customreports);
        }
        public void ViewBagForReportsEdit(CustomReports customreports)
        {

            //ViewBag.AssociatedCustomerStatusID = new SelectList(db.Customerstatuss, "ID", "DisplayValue", customer.AssociatedCustomerStatusID);
            Dictionary<string, string> ResultPropertyDict = new Dictionary<string, string>();
            ViewBag.ResultPropertyDD = new SelectList(ResultPropertyDict, "Key", "Value");

            Dictionary<string, string> CrossTabRowDict = new Dictionary<string, string>();
            ViewBag.CrossTabRowDD = new SelectList(CrossTabRowDict, "Key", "Value");

            Dictionary<string, string> CrossTabColumnDict = new Dictionary<string, string>();
            ViewBag.CrossTabColumnDD = new SelectList(CrossTabColumnDict, "Key", "Value");

            Dictionary<string, string> AggregateEntityDict = new Dictionary<string, string>();
            ViewBag.AggregateEntityDD = new SelectList(AggregateEntityDict, "Key", "Value");

            Dictionary<string, string> AggregatePropertyDict = new Dictionary<string, string>();
            ViewBag.AggregatePropertyDD = new SelectList(AggregatePropertyDict, "Key", "Value");

            Dictionary<string, string> AggregateFunctionDict = new Dictionary<string, string>();
            ViewBag.AggregateFunctionDD = new SelectList(AggregateFunctionDict, "Key", "Value");

            Dictionary<string, string> FilterPropertyDict = new Dictionary<string, string>();
            ViewBag.FilterPropertyDD = new SelectList(FilterPropertyDict, "Key", "Value");

            Dictionary<string, string> FilterConditionDict = new Dictionary<string, string>();
            ViewBag.FilterConditionDD = new SelectList(FilterConditionDict, "Key", "Value");

            Dictionary<string, string> SelectPropertyDict = new Dictionary<string, string>();
            ViewBag.SelectPropertyDD = new SelectList(SelectPropertyDict, "Key", "Value");

            Dictionary<string, string> SelectValueFromListDict = new Dictionary<string, string>();
            ViewBag.SelectValueFromListDD = new SelectList(SelectValueFromListDict, "Key", "Value");

            ViewBag.EntityNameDD = new SelectList(EnityDictionary(), "Key", "Value");
        }
        // POST: /CustomReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ConcurrencyKey,ReportName,CreatedOn,ReportType,CreatedByUserID,Description,EntityName,ResultProperty,ColumnOrder,OrderBy,GroupBy,CrossTabRow,CrossTabColumn,AggregateEntity,AggregateProperty,AggregateFunction,FilterProperty,FilterCondition,FilterType,FilterValue,SelectValueFromList,SelectProperty,RelatedEntity,ForeignKeyEntity,RelationName,EntityValues,CrossTabPropertyValues,QueryConditionValues,RelationsValues,OtherValues")] CustomReports customreports, string UrlReferrer)
        {
            if (ModelState.IsValid)
            {
                string command = Request.Form["hdncommand"];
                db.Entry(customreports).State = EntityState.Modified;
                db.SaveChanges();
                if (command != "Save")
                    return RedirectToAction("Edit", new { Id = customreports.Id, UrlReferrer = UrlReferrer });
                if (!string.IsNullOrEmpty(UrlReferrer))
                {
                    var uri = new Uri(UrlReferrer);
                    var query = HttpUtility.ParseQueryString(uri.Query);
                    if (Convert.ToBoolean(query.Get("IsFilter")) == true)
                        return RedirectToAction("Index");
                    else
                        return Redirect(UrlReferrer);
                }
                else
                    return RedirectToAction("Index");
            }

            LoadViewDataAfterOnEdit(customreports);
            return View(customreports);
        }
        // GET: /CustomReports/Delete/5
        public ActionResult Delete(int id)
        {
            if (!User.CanDelete("CustomReports"))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomReports customreports = db.CustomReportss.Find(id);
            if (customreports == null)
            {
                throw (new Exception("Deleted"));
            }
            if (ViewData["CustomReportsParentUrl"] == null && Request.UrlReferrer != null && !Request.UrlReferrer.AbsolutePath.EndsWith("/CustomReports"))
                ViewData["CustomReportsParentUrl"] = Request.UrlReferrer;
            return View(customreports);
        }
        // POST: /CustomReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(CustomReports customreports, string UrlReferrer)
        {
            if (!User.CanDelete("CustomReports"))
            {
                return RedirectToAction("Index", "Error");
            }
            if (CheckBeforeDelete(customreports))
            {
                //Delete Document
                db.Entry(customreports).State = EntityState.Deleted;
                db.CustomReportss.Remove(customreports);
                db.SaveChanges();
                if (!string.IsNullOrEmpty(UrlReferrer))
                    return Redirect(UrlReferrer);
                if (ViewData["CustomReportsParentUrl"] != null)
                {
                    string parentUrl = ViewData["CustomReportsParentUrl"].ToString();
                    ViewData["CustomReportsParentUrl"] = null;
                    return Redirect(parentUrl);
                }
                else return RedirectToAction("Index");
            }
            return View(customreports);
        }
        public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
        {
            foreach (var id in ids.Where(p => p > 0))
            {
                CustomReports customreports = db.CustomReportss.Find(id);
                db.Entry(customreports).State = EntityState.Deleted;
                db.CustomReportss.Remove(customreports);
                try
                {
                    db.SaveChanges();
                }
                catch { }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
