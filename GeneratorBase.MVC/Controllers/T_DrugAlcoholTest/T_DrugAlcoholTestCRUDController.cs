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
using System.Drawing.Imaging;
using System.Web.Helpers;
namespace GeneratorBase.MVC.Controllers
{
[LocalDateTimeConverter]
    public partial class T_DrugAlcoholTestController : BaseController
    {
        // GET: /T_DrugAlcoholTest/
		[Audit("ViewList")]
        public ActionResult Index(string currentFilter, string searchString, string sortBy, string isAsc, int? page, int? itemsPerPage, string HostingEntity, int? HostingEntityID, string AssociatedType, bool? IsExport, bool? IsDeepSearch, bool? IsFilter, bool? RenderPartial, string BulkOperation,string parent,string Wfsearch,string caller, bool? BulkAssociate, string viewtype,string isMobileHome, bool? IsHomeList)
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
			CustomLoadViewDataListOnIndex(HostingEntity, HostingEntityID, AssociatedType);
			var lstT_DrugAlcoholTest = from s in db.T_DrugAlcoholTests
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_DrugAlcoholTest = searchRecords(lstT_DrugAlcoholTest, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_DrugAlcoholTest = sortRecords(lstT_DrugAlcoholTest, sortBy, isAsc);
            }
            else lstT_DrugAlcoholTest = lstT_DrugAlcoholTest.OrderByDescending(c => c.Id);
			lstT_DrugAlcoholTest = CustomSorting(lstT_DrugAlcoholTest);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_DrugAlcoholTest"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_DrugAlcoholTest"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_DrugAlcoholTest"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_DrugAlcoholTest"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_DrugAlcoholTest = lstT_DrugAlcoholTest.Include(t=>t.t_employeedrugalcoholtest).Include(t=>t.t_typeoftest).Include(t=>t.t_testreason).Include(t=>t.t_drugtestresults);
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeDrugAlcoholTest")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_DrugAlcoholTest = _T_DrugAlcoholTest.Where(p => p.T_EmployeeDrugAlcoholTestID == hostid);
			 }
			 else
			     _T_DrugAlcoholTest = _T_DrugAlcoholTest.Where(p => p.T_EmployeeDrugAlcoholTestID == null);
         }
		 if (HostingEntity == "T_TestType" && AssociatedType == "T_TypeOfTest")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_DrugAlcoholTest = _T_DrugAlcoholTest.Where(p => p.T_TypeOfTestID == hostid);
			 }
			 else
			     _T_DrugAlcoholTest = _T_DrugAlcoholTest.Where(p => p.T_TypeOfTestID == null);
         }
		 if (HostingEntity == "T_ReasonForDrugTest" && AssociatedType == "T_TestReason")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_DrugAlcoholTest = _T_DrugAlcoholTest.Where(p => p.T_TestReasonID == hostid);
			 }
			 else
			     _T_DrugAlcoholTest = _T_DrugAlcoholTest.Where(p => p.T_TestReasonID == null);
         }
		 if (HostingEntity == "T_DrugTestResult" && AssociatedType == "T_DrugTestResults")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_DrugAlcoholTest = _T_DrugAlcoholTest.Where(p => p.T_DrugTestResultsID == hostid);
			 }
			 else
			     _T_DrugAlcoholTest = _T_DrugAlcoholTest.Where(p => p.T_DrugTestResultsID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_DrugAlcoholTest", User) || !User.CanView("T_DrugAlcoholTest"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_DrugAlcoholTest.Count() > 0)
                    pageSize = _T_DrugAlcoholTest.Count();
                return View("ExcelExport", _T_DrugAlcoholTest.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_DrugAlcoholTest.Count();
                int quotient = totalListCount / pageSize;
                var remainder = totalListCount % pageSize;
                var maxpagenumber = quotient + (remainder > 0 ? 1 : 0);
                if (pageNumber > maxpagenumber)
                {
                    pageNumber = 1;
                }
			 }
            }			 
			 if (!(RenderPartial==null?false:RenderPartial.Value) && !Request.IsAjaxRequest())
			 {
				if (string.IsNullOrEmpty(viewtype))
                    viewtype = "IndexPartial";
                GetTemplatesForList(viewtype);
                if ((ViewBag.TemplatesName != null && viewtype != null) && ViewBag.TemplatesName != viewtype)
                    ViewBag.TemplatesName = viewtype;
				var list = _T_DrugAlcoholTest.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_DrugAlcoholTestDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_DrugAlcoholTestlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				return View(list);
			 }
			 else
				{
					if (BulkOperation != null && (BulkOperation == "single" || BulkOperation == "multiple"))
					{
						ViewData["BulkAssociate"] = BulkAssociate;
						if (!string.IsNullOrEmpty(caller))
						{
							FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
							_T_DrugAlcoholTest = _fad.FilterDropdown<T_DrugAlcoholTest>(User,  _T_DrugAlcoholTest, "T_DrugAlcoholTest", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_DrugAlcoholTest.Except(_T_DrugAlcoholTest),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_DrugAlcoholTest.Except(_T_DrugAlcoholTest).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_DrugAlcoholTest.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_DrugAlcoholTest.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_DrugAlcoholTest.Count() == 0 ? 1 : _T_DrugAlcoholTest.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_DrugAlcoholTest.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_DrugAlcoholTestDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_DrugAlcoholTestlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_DrugAlcoholTest.Count() == 0 ? 1 : _T_DrugAlcoholTest.Count();
                            }
							var list = _T_DrugAlcoholTest.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_DrugAlcoholTestDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_DrugAlcoholTestlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_DrugAlcoholTest/Details/5
		 		[Audit("View")]
		public ActionResult Details(int? id,string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			if (!CustomAuthorizationBeforeDetails(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            T_DrugAlcoholTest t_drugalcoholtest = db.T_DrugAlcoholTests.Find(id);
            if (t_drugalcoholtest == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_drugalcoholtest);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_drugalcoholtest, AssociatedType);
            ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnDetails", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnDetails", true);
			ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnDetails");
			return View(ViewBag.TemplatesName,t_drugalcoholtest);
        }
        // GET: /T_DrugAlcoholTest/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_DrugAlcoholTest") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_DrugAlcoholTestParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", true);
		  ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnCreate");
          return View();
        }
		// GET: /T_DrugAlcoholTest/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_DrugAlcoholTest") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_DrugAlcoholTestParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", true);
			 ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnCreate");
            return View();
        }
		// POST: /T_DrugAlcoholTest/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeDrugAlcoholTestID,T_TypeOfTestID,T_TestReasonID,T_DateOrdered,T_ReviewersInitials,T_DrugTestResultsID,T_ResultsReceivedDate,T_Notes")] T_DrugAlcoholTest t_drugalcoholtest, string UrlReferrer)
        {
			CheckBeforeSave(t_drugalcoholtest);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_drugalcoholtest,out customcreate_hasissues,"Create"))
                {
                    db.T_DrugAlcoholTests.Add(t_drugalcoholtest);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_drugalcoholtest,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_drugalcoholtest);
			ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", true);
			ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnCreate");	
            return View(t_drugalcoholtest);
        }
		 // GET: /T_DrugAlcoholTest/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_DrugAlcoholTest") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_DrugAlcoholTestParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", true);
			ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnCreate");
            return View();
        }
		  // POST: /T_DrugAlcoholTest/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeDrugAlcoholTestID,T_TypeOfTestID,T_TestReasonID,T_DateOrdered,T_DrugTestResultsID")] T_DrugAlcoholTest t_drugalcoholtest,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_drugalcoholtest);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_drugalcoholtest,out customcreate_hasissues,"Create"))
                {
                    db.T_DrugAlcoholTests.Add(t_drugalcoholtest);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
					return Json("FROMPOPUP", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            }
			else
			{
				var errors = "";
				foreach (ModelState modelState in ViewData.ModelState.Values)
				{
					foreach (ModelError error in modelState.Errors)
					{
						errors+=error.ErrorMessage+".  ";
					}
				}
				return Json(errors, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
			}
			LoadViewDataAfterOnCreate(t_drugalcoholtest);
			ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", true);
			ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_drugalcoholtest, AssociatedEntity);
			return View(t_drugalcoholtest);
        }
		public ActionResult Cancel(string UrlReferrer)
        {
                 if (!string.IsNullOrEmpty(UrlReferrer))
                 {
                     var uri = new Uri(UrlReferrer);
                     var query = HttpUtility.ParseQueryString(uri.Query);
                     if(Convert.ToBoolean(query.Get("IsFilter")) == true)
                         return RedirectToAction("Index");
                     else
                        return Redirect(UrlReferrer);
                 }
                 else
                     return RedirectToAction("Index");
        }
        // POST: /T_DrugAlcoholTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_EmployeeDrugAlcoholTestID,T_TypeOfTestID,T_TestReasonID,T_DateOrdered,T_ReviewersInitials,T_DrugTestResultsID,T_ResultsReceivedDate,T_Notes")] T_DrugAlcoholTest t_drugalcoholtest, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_drugalcoholtest, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_drugalcoholtest,out customcreate_hasissues,command))
                {
                    db.T_DrugAlcoholTests.Add(t_drugalcoholtest);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_drugalcoholtest,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_drugalcoholtest.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_drugalcoholtest);
			ViewData["T_DrugAlcoholTestParentUrl"] = UrlReferrer;
			ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnCreate", true);
			ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnCreate");
            return View(t_drugalcoholtest);
        }
		// GET: /T_DrugAlcoholTest/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_DrugAlcoholTest") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "EditQuick";
            GetTemplatesForEditQuick(viewtype);
            T_DrugAlcoholTest t_drugalcoholtest = db.T_DrugAlcoholTests.Find(id);
            if (t_drugalcoholtest == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_DrugAlcoholTestParentUrl"] = UrlReferrer;
		if(ViewData["T_DrugAlcoholTestParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_DrugAlcoholTest")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_DrugAlcoholTest/Edit/" + t_drugalcoholtest.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_DrugAlcoholTest/Create"))
			ViewData["T_DrugAlcoholTestParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_drugalcoholtest);
		   ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", true);
		   ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnEdit");
		    var objT_DrugAlcoholTest = new List<T_DrugAlcoholTest>();
            ViewBag.T_DrugAlcoholTestDD = new SelectList(objT_DrugAlcoholTest, "ID", "DisplayValue"); 
          return View(t_drugalcoholtest);
        }
		// POST: /T_DrugAlcoholTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeDrugAlcoholTestID,T_TypeOfTestID,T_TestReasonID,T_DateOrdered,T_ReviewersInitials,T_DrugTestResultsID,T_ResultsReceivedDate,T_Notes")] T_DrugAlcoholTest t_drugalcoholtest,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_drugalcoholtest, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_drugalcoholtest,out customsave_hasissues,command))
                {
					db.Entry(t_drugalcoholtest).State = EntityState.Modified;
					db.SaveChanges();
                }
			  var result = new { Result = "Succeed", UrlRefr =UrlReferrer };
			  if (!customsave_hasissues)
				return Json(result, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
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
				var result = new { Result = "fail", UrlRefr = errors };
                return Json(result, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            }
			
			LoadViewDataAfterOnEdit(t_drugalcoholtest);
			ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", true);
			ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnEdit");
            return View(t_drugalcoholtest);
        }
        // GET: /T_DrugAlcoholTest/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_DrugAlcoholTest") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_DrugAlcoholTest t_drugalcoholtest = db.T_DrugAlcoholTests.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_DrugAlcoholTestlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_DrugAlcoholTests.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_DrugAlcoholTestDisplayValueEdit = TempData["T_DrugAlcoholTestlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_DrugAlcoholTestlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_DrugAlcoholTestDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_drugalcoholtest == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_DrugAlcoholTest/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_drugalcoholtest.DisplayValue, Value = t_drugalcoholtest.Id.ToString() }));
                ViewBag.EntityT_DrugAlcoholTestDisplayValueEdit = newList;
				TempData["T_DrugAlcoholTestlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_drugalcoholtest.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_drugalcoholtest.DisplayValue;
                    newList[0].Value = t_drugalcoholtest.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_drugalcoholtest.DisplayValue, Value = t_drugalcoholtest.Id.ToString() }));
                }
                ViewBag.EntityT_DrugAlcoholTestDisplayValueEdit = newList;
				TempData["T_DrugAlcoholTestlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_DrugAlcoholTestParentUrl"] = UrlReferrer;
		if(ViewData["T_DrugAlcoholTestParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_DrugAlcoholTest")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_DrugAlcoholTest/Edit/" + t_drugalcoholtest.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_DrugAlcoholTest/Create"))
			ViewData["T_DrugAlcoholTestParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_drugalcoholtest);
		   ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", true);
		   ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnEdit");
          return View(t_drugalcoholtest);
        }
        // POST: /T_DrugAlcoholTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_EmployeeDrugAlcoholTestID,T_TypeOfTestID,T_TestReasonID,T_DateOrdered,T_ReviewersInitials,T_DrugTestResultsID,T_ResultsReceivedDate,T_Notes")] T_DrugAlcoholTest t_drugalcoholtest,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_drugalcoholtest, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_drugalcoholtest,out customsave_hasissues,command))
            {
				db.Entry(t_drugalcoholtest).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_drugalcoholtest,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_drugalcoholtest.Id, UrlReferrer = UrlReferrer });
			     }
                 if (!string.IsNullOrEmpty(UrlReferrer))
                 {
                     var uri = new Uri(UrlReferrer);
                     var query = HttpUtility.ParseQueryString(uri.Query);
                     if(Convert.ToBoolean(query.Get("IsFilter")) == true)
                         return RedirectToAction("Index");
                     else
                        return Redirect(UrlReferrer);
                 }
                 else
                     return RedirectToAction("Index");
			}
     }
			
			// NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_DrugAlcoholTestlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_DrugAlcoholTests.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_DrugAlcoholTestDisplayValueEdit = TempData["T_DrugAlcoholTestlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_DrugAlcoholTestlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_DrugAlcoholTestDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_drugalcoholtest);
			 ViewData["T_DrugAlcoholTestParentUrl"] = UrlReferrer;
			ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", true);
			ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnEdit");
            return View(t_drugalcoholtest);
        }
		// GET: /T_DrugAlcoholTest/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_DrugAlcoholTest") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "EditWizard";
            GetTemplatesForEditWizard(viewtype);
			            T_DrugAlcoholTest t_drugalcoholtest = db.T_DrugAlcoholTests.Find(id);
            if (t_drugalcoholtest == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_DrugAlcoholTestParentUrl"] = UrlReferrer;
		if(ViewData["T_DrugAlcoholTestParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_DrugAlcoholTest"))
			ViewData["T_DrugAlcoholTestParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_drugalcoholtest);
			 ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", true);
			 ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnEdit");
          return View(t_drugalcoholtest);
        }
        // POST: /T_DrugAlcoholTest/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeDrugAlcoholTestID,T_TypeOfTestID,T_TestReasonID,T_DateOrdered,T_ReviewersInitials,T_DrugTestResultsID,T_ResultsReceivedDate,T_Notes")] T_DrugAlcoholTest t_drugalcoholtest,string UrlReferrer)
        {
			CheckBeforeSave(t_drugalcoholtest);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_drugalcoholtest,out customsave_hasissues,"Save"))
            {
				db.Entry(t_drugalcoholtest).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_drugalcoholtest,"Edit","");
				 if (customRedirectAction != null) return customRedirectAction;
				 if (!string.IsNullOrEmpty(UrlReferrer))
                 {
                     var uri = new Uri(UrlReferrer);
                     var query = HttpUtility.ParseQueryString(uri.Query);
                     if(Convert.ToBoolean(query.Get("IsFilter")) == true)
                         return RedirectToAction("Index");
                     else
                        return Redirect(UrlReferrer);
                 }
                 else
                     return RedirectToAction("Index");
			}
     }
			LoadViewDataAfterOnEdit(t_drugalcoholtest);
			ViewBag.T_DrugAlcoholTestIsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", false);
			ViewBag.T_DrugAlcoholTestIsGroupsHiddenRule = checkHidden("T_DrugAlcoholTest", "OnEdit", true);
			ViewBag.T_DrugAlcoholTestIsSetValueUIRule = checkSetValueUIRule("T_DrugAlcoholTest", "OnEdit");
            return View(t_drugalcoholtest);
        }
        // GET: /T_DrugAlcoholTest/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_DrugAlcoholTest") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_DrugAlcoholTest t_drugalcoholtest = db.T_DrugAlcoholTests.Find(id);
            if (t_drugalcoholtest == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_DrugAlcoholTestParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_DrugAlcoholTest"))
			 ViewData["T_DrugAlcoholTestParentUrl"] = Request.UrlReferrer;
            return View(t_drugalcoholtest);
        }
        // POST: /T_DrugAlcoholTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_DrugAlcoholTest t_drugalcoholtest, string UrlReferrer)
        {
			if (!User.CanDelete("T_DrugAlcoholTest"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_drugalcoholtest))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_drugalcoholtest, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_drugalcoholtest).State = EntityState.Deleted;
            db.T_DrugAlcoholTests.Remove(t_drugalcoholtest);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_DrugAlcoholTestParentUrl"] != null)
					{
						string parentUrl = ViewData["T_DrugAlcoholTestParentUrl"].ToString();
						ViewData["T_DrugAlcoholTestParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_drugalcoholtest);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeDrugAlcoholTest")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_DrugAlcoholTest obj = db.T_DrugAlcoholTests.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeDrugAlcoholTestID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_TestType" && AssociatedType == "T_TypeOfTest")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_DrugAlcoholTest obj = db.T_DrugAlcoholTests.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_TypeOfTestID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_ReasonForDrugTest" && AssociatedType == "T_TestReason")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_DrugAlcoholTest obj = db.T_DrugAlcoholTests.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_TestReasonID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_DrugTestResult" && AssociatedType == "T_DrugTestResults")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_DrugAlcoholTest obj = db.T_DrugAlcoholTests.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_DrugTestResultsID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_DrugAlcoholTest", User) || !User.CanDelete("T_DrugAlcoholTest")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_DrugAlcoholTest t_drugalcoholtest = db.T_DrugAlcoholTests.Find(id);
		if (CheckBeforeDelete(t_drugalcoholtest))
        {
            if (!CustomDelete(t_drugalcoholtest, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_drugalcoholtest).State = EntityState.Deleted;
                db.T_DrugAlcoholTests.Remove(t_drugalcoholtest);
                try
                {
                    db.SaveChanges();
                }
                catch { }
			}
		}
				
			}
			return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
        public ActionResult BulkUpdate(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDUpdate)
        {
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_DrugAlcoholTest", User) || !User.CanEdit("T_DrugAlcoholTest") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_DrugAlcoholTestParentUrl"] = UrlReferrer;
            ViewData["AssociatedType"] = AssociatedType;
            ViewData["HostingEntityName"] = HostingEntityName;
            ViewData["HostingEntityID"] = HostingEntityID;
            LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
            string ids = string.Empty;
            if (Request.QueryString["ids"] != null)
                ids = Request.QueryString["ids"];
            ViewBag.BulkUpdate = ids;
            return View();
        }
        [HttpPost]
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_EmployeeDrugAlcoholTestID,T_TypeOfTestID,T_TestReasonID,T_DateOrdered,T_ReviewersInitials,T_DrugTestResultsID,T_ResultsReceivedDate,T_Notes")] T_DrugAlcoholTest t_drugalcoholtest,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_DrugAlcoholTest target = db.T_DrugAlcoholTests.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_drugalcoholtest, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_employeedrugalcoholtest != null)
							  db.Entry(target.t_employeedrugalcoholtest).State = EntityState.Unchanged;
							if (target.t_typeoftest != null)
							  db.Entry(target.t_typeoftest).State = EntityState.Unchanged;
							if (target.t_testreason != null)
							  db.Entry(target.t_testreason).State = EntityState.Unchanged;
							if (target.t_drugtestresults != null)
							  db.Entry(target.t_drugtestresults).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_drugalcoholtest,"BulkUpdate","");
			if (customRedirectAction != null) return customRedirectAction;
            if (!string.IsNullOrEmpty(UrlReferrer))
                return Redirect(UrlReferrer);
            else
                return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(db!=null) db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
