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
    public partial class T_BackgroundCheckController : BaseController
    {
        // GET: /T_BackgroundCheck/
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
			var lstT_BackgroundCheck = from s in db.T_BackgroundChecks
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_BackgroundCheck = searchRecords(lstT_BackgroundCheck, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_BackgroundCheck = sortRecords(lstT_BackgroundCheck, sortBy, isAsc);
            }
            else lstT_BackgroundCheck = lstT_BackgroundCheck.OrderByDescending(c => c.Id);
			lstT_BackgroundCheck = CustomSorting(lstT_BackgroundCheck);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_BackgroundCheck"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_BackgroundCheck"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_BackgroundCheck"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_BackgroundCheck"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_BackgroundCheck = lstT_BackgroundCheck.Include(t=>t.t_employeecriminalbackgroundcheck).Include(t=>t.t_retaintablepreemploymentcheck).Include(t=>t.t_preemploymentcheckresultsvastate).Include(t=>t.t_reviewer).Include(t=>t.t_cpsresult);
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeCriminalBackgroundCheck")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_BackgroundCheck = _T_BackgroundCheck.Where(p => p.T_EmployeeCriminalBackgroundCheckID == hostid);
			 }
			 else
			     _T_BackgroundCheck = _T_BackgroundCheck.Where(p => p.T_EmployeeCriminalBackgroundCheckID == null);
         }
		 if (HostingEntity == "T_RetainTable" && AssociatedType == "T_RetainTablePreEmploymentCheck")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_BackgroundCheck = _T_BackgroundCheck.Where(p => p.T_RetainTablePreEmploymentCheckID == hostid);
			 }
			 else
			     _T_BackgroundCheck = _T_BackgroundCheck.Where(p => p.T_RetainTablePreEmploymentCheckID == null);
         }
		 if (HostingEntity == "T_ResultsTable" && AssociatedType == "T_PreEmploymentCheckResultsVAState")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_BackgroundCheck = _T_BackgroundCheck.Where(p => p.T_PreEmploymentCheckResultsVAStateID == hostid);
			 }
			 else
			     _T_BackgroundCheck = _T_BackgroundCheck.Where(p => p.T_PreEmploymentCheckResultsVAStateID == null);
         }
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_Reviewer")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_BackgroundCheck = _T_BackgroundCheck.Where(p => p.T_ReviewerID == hostid);
			 }
			 else
			     _T_BackgroundCheck = _T_BackgroundCheck.Where(p => p.T_ReviewerID == null);
         }
		 if (HostingEntity == "T_CPSResults" && AssociatedType == "T_CPSResult")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_BackgroundCheck = _T_BackgroundCheck.Where(p => p.T_CPSResultID == hostid);
			 }
			 else
			     _T_BackgroundCheck = _T_BackgroundCheck.Where(p => p.T_CPSResultID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_BackgroundCheck", User) || !User.CanView("T_BackgroundCheck"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_BackgroundCheck.Count() > 0)
                    pageSize = _T_BackgroundCheck.Count();
                return View("ExcelExport", _T_BackgroundCheck.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_BackgroundCheck.Count();
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
				var list = _T_BackgroundCheck.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_BackgroundCheckDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_BackgroundChecklist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_BackgroundCheck = _fad.FilterDropdown<T_BackgroundCheck>(User,  _T_BackgroundCheck, "T_BackgroundCheck", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_BackgroundCheck.Except(_T_BackgroundCheck),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_BackgroundCheck.Except(_T_BackgroundCheck).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_BackgroundCheck.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_BackgroundCheck.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_BackgroundCheck.Count() == 0 ? 1 : _T_BackgroundCheck.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_BackgroundCheck.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_BackgroundCheckDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_BackgroundChecklist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_BackgroundCheck.Count() == 0 ? 1 : _T_BackgroundCheck.Count();
                            }
							var list = _T_BackgroundCheck.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_BackgroundCheckDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_BackgroundChecklist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_BackgroundCheck/Details/5
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
            T_BackgroundCheck t_backgroundcheck = db.T_BackgroundChecks.Find(id);
            if (t_backgroundcheck == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_backgroundcheck);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_backgroundcheck, AssociatedType);
            ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnDetails", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnDetails", true);
			ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnDetails");
			return View(ViewBag.TemplatesName,t_backgroundcheck);
        }
        // GET: /T_BackgroundCheck/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_BackgroundCheck") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_BackgroundCheckParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", true);
		  ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnCreate");
          return View();
        }
		// GET: /T_BackgroundCheck/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_BackgroundCheck") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_BackgroundCheckParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", true);
			 ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnCreate");
            return View();
        }
		// POST: /T_BackgroundCheck/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeCriminalBackgroundCheckID,T_RetainTablePreEmploymentCheckID,T_DateFingerPrintTaken,T_DateInformationReceivedFromCBC,T_PreEmploymentCheckResultsVAStateID,T_BackgroundDispositionDate,T_ReviewDate,T_ReviewerID,T_DateCheckInitiated,T_DateCPSResultReceived,T_CPSResultID,T_CPSReviewDate,T_Notes")] T_BackgroundCheck t_backgroundcheck, string UrlReferrer)
        {
			CheckBeforeSave(t_backgroundcheck);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_backgroundcheck,out customcreate_hasissues,"Create"))
                {
                    db.T_BackgroundChecks.Add(t_backgroundcheck);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_backgroundcheck,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_backgroundcheck);
			ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", true);
			ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnCreate");	
            return View(t_backgroundcheck);
        }
		 // GET: /T_BackgroundCheck/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_BackgroundCheck") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_BackgroundCheckParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", true);
			ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnCreate");
            return View();
        }
		  // POST: /T_BackgroundCheck/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeCriminalBackgroundCheckID,T_RetainTablePreEmploymentCheckID,T_DateFingerPrintTaken,T_DateInformationReceivedFromCBC,T_PreEmploymentCheckResultsVAStateID,T_ReviewerID,T_DateCPSResultReceived,T_CPSResultID")] T_BackgroundCheck t_backgroundcheck,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_backgroundcheck);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_backgroundcheck,out customcreate_hasissues,"Create"))
                {
                    db.T_BackgroundChecks.Add(t_backgroundcheck);
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
			LoadViewDataAfterOnCreate(t_backgroundcheck);
			ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", true);
			ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_backgroundcheck, AssociatedEntity);
			return View(t_backgroundcheck);
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
        // POST: /T_BackgroundCheck/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_EmployeeCriminalBackgroundCheckID,T_RetainTablePreEmploymentCheckID,T_DateFingerPrintTaken,T_DateInformationReceivedFromCBC,T_PreEmploymentCheckResultsVAStateID,T_BackgroundDispositionDate,T_ReviewDate,T_ReviewerID,T_DateCheckInitiated,T_DateCPSResultReceived,T_CPSResultID,T_CPSReviewDate,T_Notes")] T_BackgroundCheck t_backgroundcheck, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_backgroundcheck, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_backgroundcheck,out customcreate_hasissues,command))
                {
                    db.T_BackgroundChecks.Add(t_backgroundcheck);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_backgroundcheck,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_backgroundcheck.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_backgroundcheck);
			ViewData["T_BackgroundCheckParentUrl"] = UrlReferrer;
			ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnCreate", true);
			ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnCreate");
            return View(t_backgroundcheck);
        }
		// GET: /T_BackgroundCheck/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_BackgroundCheck") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_BackgroundCheck t_backgroundcheck = db.T_BackgroundChecks.Find(id);
            if (t_backgroundcheck == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_BackgroundCheckParentUrl"] = UrlReferrer;
		if(ViewData["T_BackgroundCheckParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_BackgroundCheck")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_BackgroundCheck/Edit/" + t_backgroundcheck.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_BackgroundCheck/Create"))
			ViewData["T_BackgroundCheckParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_backgroundcheck);
		   ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", true);
		   ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnEdit");
		    var objT_BackgroundCheck = new List<T_BackgroundCheck>();
            ViewBag.T_BackgroundCheckDD = new SelectList(objT_BackgroundCheck, "ID", "DisplayValue"); 
          return View(t_backgroundcheck);
        }
		// POST: /T_BackgroundCheck/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeCriminalBackgroundCheckID,T_RetainTablePreEmploymentCheckID,T_DateFingerPrintTaken,T_DateInformationReceivedFromCBC,T_PreEmploymentCheckResultsVAStateID,T_BackgroundDispositionDate,T_ReviewDate,T_ReviewerID,T_DateCheckInitiated,T_DateCPSResultReceived,T_CPSResultID,T_CPSReviewDate,T_Notes")] T_BackgroundCheck t_backgroundcheck,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_backgroundcheck, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_backgroundcheck,out customsave_hasissues,command))
                {
					db.Entry(t_backgroundcheck).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_backgroundcheck);
			ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", true);
			ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnEdit");
            return View(t_backgroundcheck);
        }
        // GET: /T_BackgroundCheck/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_BackgroundCheck") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_BackgroundCheck t_backgroundcheck = db.T_BackgroundChecks.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_BackgroundChecklist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_BackgroundChecks.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_BackgroundCheckDisplayValueEdit = TempData["T_BackgroundChecklist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_BackgroundChecklist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_BackgroundCheckDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_backgroundcheck == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_BackgroundCheck/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_backgroundcheck.DisplayValue, Value = t_backgroundcheck.Id.ToString() }));
                ViewBag.EntityT_BackgroundCheckDisplayValueEdit = newList;
				TempData["T_BackgroundChecklist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_backgroundcheck.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_backgroundcheck.DisplayValue;
                    newList[0].Value = t_backgroundcheck.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_backgroundcheck.DisplayValue, Value = t_backgroundcheck.Id.ToString() }));
                }
                ViewBag.EntityT_BackgroundCheckDisplayValueEdit = newList;
				TempData["T_BackgroundChecklist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_BackgroundCheckParentUrl"] = UrlReferrer;
		if(ViewData["T_BackgroundCheckParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_BackgroundCheck")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_BackgroundCheck/Edit/" + t_backgroundcheck.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_BackgroundCheck/Create"))
			ViewData["T_BackgroundCheckParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_backgroundcheck);
		   ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", true);
		   ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnEdit");
          return View(t_backgroundcheck);
        }
        // POST: /T_BackgroundCheck/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_EmployeeCriminalBackgroundCheckID,T_RetainTablePreEmploymentCheckID,T_DateFingerPrintTaken,T_DateInformationReceivedFromCBC,T_PreEmploymentCheckResultsVAStateID,T_BackgroundDispositionDate,T_ReviewDate,T_ReviewerID,T_DateCheckInitiated,T_DateCPSResultReceived,T_CPSResultID,T_CPSReviewDate,T_Notes")] T_BackgroundCheck t_backgroundcheck,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_backgroundcheck, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_backgroundcheck,out customsave_hasissues,command))
            {
				db.Entry(t_backgroundcheck).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_backgroundcheck,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_backgroundcheck.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_BackgroundChecklist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_BackgroundChecks.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_BackgroundCheckDisplayValueEdit = TempData["T_BackgroundChecklist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_BackgroundChecklist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_BackgroundCheckDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_backgroundcheck);
			 ViewData["T_BackgroundCheckParentUrl"] = UrlReferrer;
			ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", true);
			ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnEdit");
            return View(t_backgroundcheck);
        }
		// GET: /T_BackgroundCheck/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_BackgroundCheck") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_BackgroundCheck t_backgroundcheck = db.T_BackgroundChecks.Find(id);
            if (t_backgroundcheck == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_BackgroundCheckParentUrl"] = UrlReferrer;
		if(ViewData["T_BackgroundCheckParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_BackgroundCheck"))
			ViewData["T_BackgroundCheckParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_backgroundcheck);
			 ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", true);
			 ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnEdit");
          return View(t_backgroundcheck);
        }
        // POST: /T_BackgroundCheck/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeCriminalBackgroundCheckID,T_RetainTablePreEmploymentCheckID,T_DateFingerPrintTaken,T_DateInformationReceivedFromCBC,T_PreEmploymentCheckResultsVAStateID,T_BackgroundDispositionDate,T_ReviewDate,T_ReviewerID,T_DateCheckInitiated,T_DateCPSResultReceived,T_CPSResultID,T_CPSReviewDate,T_Notes")] T_BackgroundCheck t_backgroundcheck,string UrlReferrer)
        {
			CheckBeforeSave(t_backgroundcheck);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_backgroundcheck,out customsave_hasissues,"Save"))
            {
				db.Entry(t_backgroundcheck).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_backgroundcheck,"Edit","");
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
			LoadViewDataAfterOnEdit(t_backgroundcheck);
			ViewBag.T_BackgroundCheckIsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", false);
			ViewBag.T_BackgroundCheckIsGroupsHiddenRule = checkHidden("T_BackgroundCheck", "OnEdit", true);
			ViewBag.T_BackgroundCheckIsSetValueUIRule = checkSetValueUIRule("T_BackgroundCheck", "OnEdit");
            return View(t_backgroundcheck);
        }
        // GET: /T_BackgroundCheck/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_BackgroundCheck") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_BackgroundCheck t_backgroundcheck = db.T_BackgroundChecks.Find(id);
            if (t_backgroundcheck == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_BackgroundCheckParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_BackgroundCheck"))
			 ViewData["T_BackgroundCheckParentUrl"] = Request.UrlReferrer;
            return View(t_backgroundcheck);
        }
        // POST: /T_BackgroundCheck/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_BackgroundCheck t_backgroundcheck, string UrlReferrer)
        {
			if (!User.CanDelete("T_BackgroundCheck"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_backgroundcheck))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_backgroundcheck, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_backgroundcheck).State = EntityState.Deleted;
            db.T_BackgroundChecks.Remove(t_backgroundcheck);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_BackgroundCheckParentUrl"] != null)
					{
						string parentUrl = ViewData["T_BackgroundCheckParentUrl"].ToString();
						ViewData["T_BackgroundCheckParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_backgroundcheck);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeCriminalBackgroundCheck")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_BackgroundCheck obj = db.T_BackgroundChecks.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeCriminalBackgroundCheckID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_RetainTable" && AssociatedType == "T_RetainTablePreEmploymentCheck")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_BackgroundCheck obj = db.T_BackgroundChecks.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_RetainTablePreEmploymentCheckID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_ResultsTable" && AssociatedType == "T_PreEmploymentCheckResultsVAState")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_BackgroundCheck obj = db.T_BackgroundChecks.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PreEmploymentCheckResultsVAStateID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Employee" && AssociatedType == "T_Reviewer")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_BackgroundCheck obj = db.T_BackgroundChecks.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_ReviewerID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_CPSResults" && AssociatedType == "T_CPSResult")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_BackgroundCheck obj = db.T_BackgroundChecks.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_CPSResultID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_BackgroundCheck", User) || !User.CanDelete("T_BackgroundCheck")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_BackgroundCheck t_backgroundcheck = db.T_BackgroundChecks.Find(id);
		if (CheckBeforeDelete(t_backgroundcheck))
        {
            if (!CustomDelete(t_backgroundcheck, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_backgroundcheck).State = EntityState.Deleted;
                db.T_BackgroundChecks.Remove(t_backgroundcheck);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_BackgroundCheck", User) || !User.CanEdit("T_BackgroundCheck") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_BackgroundCheckParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_EmployeeCriminalBackgroundCheckID,T_RetainTablePreEmploymentCheckID,T_DateFingerPrintTaken,T_DateInformationReceivedFromCBC,T_PreEmploymentCheckResultsVAStateID,T_BackgroundDispositionDate,T_ReviewDate,T_ReviewerID,T_DateCheckInitiated,T_DateCPSResultReceived,T_CPSResultID,T_CPSReviewDate,T_Notes")] T_BackgroundCheck t_backgroundcheck,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_BackgroundCheck target = db.T_BackgroundChecks.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_backgroundcheck, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_employeecriminalbackgroundcheck != null)
							  db.Entry(target.t_employeecriminalbackgroundcheck).State = EntityState.Unchanged;
							if (target.t_retaintablepreemploymentcheck != null)
							  db.Entry(target.t_retaintablepreemploymentcheck).State = EntityState.Unchanged;
							if (target.t_preemploymentcheckresultsvastate != null)
							  db.Entry(target.t_preemploymentcheckresultsvastate).State = EntityState.Unchanged;
							if (target.t_reviewer != null)
							  db.Entry(target.t_reviewer).State = EntityState.Unchanged;
							if (target.t_cpsresult != null)
							  db.Entry(target.t_cpsresult).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_backgroundcheck,"BulkUpdate","");
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
