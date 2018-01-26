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
    public partial class T_ServiceRecordController : BaseController
    {
        // GET: /T_ServiceRecord/
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
			var lstT_ServiceRecord = from s in db.T_ServiceRecords
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_ServiceRecord = searchRecords(lstT_ServiceRecord, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_ServiceRecord = sortRecords(lstT_ServiceRecord, sortBy, isAsc);
            }
            else lstT_ServiceRecord = lstT_ServiceRecord.OrderByDescending(c => c.Id);
			lstT_ServiceRecord = CustomSorting(lstT_ServiceRecord);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_ServiceRecord"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_ServiceRecord"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_ServiceRecord"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_ServiceRecord"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_ServiceRecord = lstT_ServiceRecord.Include(t=>t.t_employeeemploymentprofile).Include(t=>t.t_employmentrecordemployeetype).Include(t=>t.t_employmentrecordhiredatfacility).Include(t=>t.t_employeeterminationreason).Include(t=>t.t_employeerecordterminationfacility);
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeEmploymentProfile")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_ServiceRecord = _T_ServiceRecord.Where(p => p.T_EmployeeEmploymentProfileID == hostid);
			 }
			 else
			     _T_ServiceRecord = _T_ServiceRecord.Where(p => p.T_EmployeeEmploymentProfileID == null);
         }
		 if (HostingEntity == "T_EmployeeType" && AssociatedType == "T_EmploymentRecordEmployeeType")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_ServiceRecord = _T_ServiceRecord.Where(p => p.T_EmploymentRecordEmployeeTypeID == hostid);
			 }
			 else
			     _T_ServiceRecord = _T_ServiceRecord.Where(p => p.T_EmploymentRecordEmployeeTypeID == null);
         }
		 if (HostingEntity == "T_AllFacilities" && AssociatedType == "T_EmploymentRecordHiredAtFacility")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_ServiceRecord = _T_ServiceRecord.Where(p => p.T_EmploymentRecordHiredAtFacilityID == hostid);
			 }
			 else
			     _T_ServiceRecord = _T_ServiceRecord.Where(p => p.T_EmploymentRecordHiredAtFacilityID == null);
         }
		 if (HostingEntity == "T_TerminationReason" && AssociatedType == "T_EmployeeTerminationReason")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_ServiceRecord = _T_ServiceRecord.Where(p => p.T_EmployeeTerminationReasonID == hostid);
			 }
			 else
			     _T_ServiceRecord = _T_ServiceRecord.Where(p => p.T_EmployeeTerminationReasonID == null);
         }
		 if (HostingEntity == "T_AllFacilities" && AssociatedType == "T_EmployeeRecordTerminationFacility")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_ServiceRecord = _T_ServiceRecord.Where(p => p.T_EmployeeRecordTerminationFacilityID == hostid);
			 }
			 else
			     _T_ServiceRecord = _T_ServiceRecord.Where(p => p.T_EmployeeRecordTerminationFacilityID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_ServiceRecord", User) || !User.CanView("T_ServiceRecord"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_ServiceRecord.Count() > 0)
                    pageSize = _T_ServiceRecord.Count();
                return View("ExcelExport", _T_ServiceRecord.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_ServiceRecord.Count();
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
				var list = _T_ServiceRecord.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_ServiceRecordDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_ServiceRecordlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_ServiceRecord = _fad.FilterDropdown<T_ServiceRecord>(User,  _T_ServiceRecord, "T_ServiceRecord", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_ServiceRecord.Except(_T_ServiceRecord),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_ServiceRecord.Except(_T_ServiceRecord).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_ServiceRecord.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_ServiceRecord.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_ServiceRecord.Count() == 0 ? 1 : _T_ServiceRecord.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_ServiceRecord.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_ServiceRecordDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_ServiceRecordlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_ServiceRecord.Count() == 0 ? 1 : _T_ServiceRecord.Count();
                            }
							var list = _T_ServiceRecord.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_ServiceRecordDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_ServiceRecordlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_ServiceRecord/Details/5
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
            T_ServiceRecord t_servicerecord = db.T_ServiceRecords.Find(id);
            if (t_servicerecord == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_servicerecord);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_servicerecord, AssociatedType);
            ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnDetails", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnDetails", true);
			ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnDetails");
			return View(ViewBag.TemplatesName,t_servicerecord);
        }
        // GET: /T_ServiceRecord/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_ServiceRecord") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_ServiceRecordParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", true);
		  ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnCreate");
          return View();
        }
		// GET: /T_ServiceRecord/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_ServiceRecord") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_ServiceRecordParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", true);
			 ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnCreate");
            return View();
        }
		// POST: /T_ServiceRecord/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmploymentProfileID,T_EmploymentRecordEmployeeTypeID,T_IsCurrent,T_EmploymentRecordHiredAtFacilityID,T_HireDate,T_TerminationDate,T_ThreeMonthDue,T_ThreeMonthReviewCompleted,T_SixMonthDue,T_SixMonthReviewCompleted,T_TwelveMonthDue,T_TwelveMonthReviewCompleted,T_ProbationaryExtensionDate,T_ExtensionReviewCompleted,T_EmployeeTerminationReasonID,T_EmployeeRecordTerminationFacilityID,T_TwoWeekNoticeGiven,T_NoticeGivenDate,T_ThirtyDaysSinceTermination,T_ThirteenWeeksSinceTermination,T_EligibleForRehire,T_ProbationNotes,T_TerminationNotes")] T_ServiceRecord t_servicerecord, string UrlReferrer)
        {
			CheckBeforeSave(t_servicerecord);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_servicerecord,out customcreate_hasissues,"Create"))
                {
                    db.T_ServiceRecords.Add(t_servicerecord);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_servicerecord,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_servicerecord);
			ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", true);
			ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnCreate");	
            return View(t_servicerecord);
        }
		 // GET: /T_ServiceRecord/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_ServiceRecord") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_ServiceRecordParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", true);
			ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnCreate");
            return View();
        }
		  // POST: /T_ServiceRecord/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmploymentProfileID,T_EmploymentRecordEmployeeTypeID,T_IsCurrent,T_EmploymentRecordHiredAtFacilityID,T_HireDate,T_TerminationDate,T_ThreeMonthDue,T_ThreeMonthReviewCompleted,T_EmployeeTerminationReasonID,T_EmployeeRecordTerminationFacilityID,T_EligibleForRehire")] T_ServiceRecord t_servicerecord,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_servicerecord);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_servicerecord,out customcreate_hasissues,"Create"))
                {
                    db.T_ServiceRecords.Add(t_servicerecord);
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
			LoadViewDataAfterOnCreate(t_servicerecord);
			ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", true);
			ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_servicerecord, AssociatedEntity);
			return View(t_servicerecord);
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
        // POST: /T_ServiceRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmploymentProfileID,T_EmploymentRecordEmployeeTypeID,T_IsCurrent,T_EmploymentRecordHiredAtFacilityID,T_HireDate,T_TerminationDate,T_ThreeMonthDue,T_ThreeMonthReviewCompleted,T_SixMonthDue,T_SixMonthReviewCompleted,T_TwelveMonthDue,T_TwelveMonthReviewCompleted,T_ProbationaryExtensionDate,T_ExtensionReviewCompleted,T_EmployeeTerminationReasonID,T_EmployeeRecordTerminationFacilityID,T_TwoWeekNoticeGiven,T_NoticeGivenDate,T_ThirtyDaysSinceTermination,T_ThirteenWeeksSinceTermination,T_EligibleForRehire,T_ProbationNotes,T_TerminationNotes")] T_ServiceRecord t_servicerecord, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_servicerecord, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_servicerecord,out customcreate_hasissues,command))
                {
                    db.T_ServiceRecords.Add(t_servicerecord);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_servicerecord,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_servicerecord.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_servicerecord);
			ViewData["T_ServiceRecordParentUrl"] = UrlReferrer;
			ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnCreate", true);
			ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnCreate");
            return View(t_servicerecord);
        }
		// GET: /T_ServiceRecord/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_ServiceRecord") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_ServiceRecord t_servicerecord = db.T_ServiceRecords.Find(id);
            if (t_servicerecord == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_ServiceRecordParentUrl"] = UrlReferrer;
		if(ViewData["T_ServiceRecordParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ServiceRecord")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ServiceRecord/Edit/" + t_servicerecord.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ServiceRecord/Create"))
			ViewData["T_ServiceRecordParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_servicerecord);
		   ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", true);
		   ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnEdit");
		    var objT_ServiceRecord = new List<T_ServiceRecord>();
            ViewBag.T_ServiceRecordDD = new SelectList(objT_ServiceRecord, "ID", "DisplayValue"); 
          return View(t_servicerecord);
        }
		// POST: /T_ServiceRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmploymentProfileID,T_EmploymentRecordEmployeeTypeID,T_IsCurrent,T_EmploymentRecordHiredAtFacilityID,T_HireDate,T_TerminationDate,T_ThreeMonthDue,T_ThreeMonthReviewCompleted,T_SixMonthDue,T_SixMonthReviewCompleted,T_TwelveMonthDue,T_TwelveMonthReviewCompleted,T_ProbationaryExtensionDate,T_ExtensionReviewCompleted,T_EmployeeTerminationReasonID,T_EmployeeRecordTerminationFacilityID,T_TwoWeekNoticeGiven,T_NoticeGivenDate,T_ThirtyDaysSinceTermination,T_ThirteenWeeksSinceTermination,T_EligibleForRehire,T_ProbationNotes,T_TerminationNotes")] T_ServiceRecord t_servicerecord,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_servicerecord, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_servicerecord,out customsave_hasissues,command))
                {
					db.Entry(t_servicerecord).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_servicerecord);
			ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", true);
			ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnEdit");
            return View(t_servicerecord);
        }
        // GET: /T_ServiceRecord/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_ServiceRecord") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_ServiceRecord t_servicerecord = db.T_ServiceRecords.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_ServiceRecordlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_ServiceRecords.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_ServiceRecordDisplayValueEdit = TempData["T_ServiceRecordlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_ServiceRecordlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_ServiceRecordDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_servicerecord == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_ServiceRecord/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_servicerecord.DisplayValue, Value = t_servicerecord.Id.ToString() }));
                ViewBag.EntityT_ServiceRecordDisplayValueEdit = newList;
				TempData["T_ServiceRecordlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_servicerecord.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_servicerecord.DisplayValue;
                    newList[0].Value = t_servicerecord.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_servicerecord.DisplayValue, Value = t_servicerecord.Id.ToString() }));
                }
                ViewBag.EntityT_ServiceRecordDisplayValueEdit = newList;
				TempData["T_ServiceRecordlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_ServiceRecordParentUrl"] = UrlReferrer;
		if(ViewData["T_ServiceRecordParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ServiceRecord")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ServiceRecord/Edit/" + t_servicerecord.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ServiceRecord/Create"))
			ViewData["T_ServiceRecordParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_servicerecord);
		   ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", true);
		   ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnEdit");
          return View(t_servicerecord);
        }
        // POST: /T_ServiceRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmploymentProfileID,T_EmploymentRecordEmployeeTypeID,T_IsCurrent,T_EmploymentRecordHiredAtFacilityID,T_HireDate,T_TerminationDate,T_ThreeMonthDue,T_ThreeMonthReviewCompleted,T_SixMonthDue,T_SixMonthReviewCompleted,T_TwelveMonthDue,T_TwelveMonthReviewCompleted,T_ProbationaryExtensionDate,T_ExtensionReviewCompleted,T_EmployeeTerminationReasonID,T_EmployeeRecordTerminationFacilityID,T_TwoWeekNoticeGiven,T_NoticeGivenDate,T_ThirtyDaysSinceTermination,T_ThirteenWeeksSinceTermination,T_EligibleForRehire,T_ProbationNotes,T_TerminationNotes")] T_ServiceRecord t_servicerecord,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_servicerecord, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_servicerecord,out customsave_hasissues,command))
            {
				db.Entry(t_servicerecord).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_servicerecord,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_servicerecord.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_ServiceRecordlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_ServiceRecords.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_ServiceRecordDisplayValueEdit = TempData["T_ServiceRecordlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_ServiceRecordlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_ServiceRecordDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_servicerecord);
			 ViewData["T_ServiceRecordParentUrl"] = UrlReferrer;
			ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", true);
			ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnEdit");
            return View(t_servicerecord);
        }
		// GET: /T_ServiceRecord/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_ServiceRecord") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_ServiceRecord t_servicerecord = db.T_ServiceRecords.Find(id);
            if (t_servicerecord == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_ServiceRecordParentUrl"] = UrlReferrer;
		if(ViewData["T_ServiceRecordParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ServiceRecord"))
			ViewData["T_ServiceRecordParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_servicerecord);
			 ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", true);
			 ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnEdit");
          return View(t_servicerecord);
        }
        // POST: /T_ServiceRecord/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmploymentProfileID,T_EmploymentRecordEmployeeTypeID,T_IsCurrent,T_EmploymentRecordHiredAtFacilityID,T_HireDate,T_TerminationDate,T_ThreeMonthDue,T_ThreeMonthReviewCompleted,T_SixMonthDue,T_SixMonthReviewCompleted,T_TwelveMonthDue,T_TwelveMonthReviewCompleted,T_ProbationaryExtensionDate,T_ExtensionReviewCompleted,T_EmployeeTerminationReasonID,T_EmployeeRecordTerminationFacilityID,T_TwoWeekNoticeGiven,T_NoticeGivenDate,T_ThirtyDaysSinceTermination,T_ThirteenWeeksSinceTermination,T_EligibleForRehire,T_ProbationNotes,T_TerminationNotes")] T_ServiceRecord t_servicerecord,string UrlReferrer)
        {
			CheckBeforeSave(t_servicerecord);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_servicerecord,out customsave_hasissues,"Save"))
            {
				db.Entry(t_servicerecord).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_servicerecord,"Edit","");
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
			LoadViewDataAfterOnEdit(t_servicerecord);
			ViewBag.T_ServiceRecordIsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", false);
			ViewBag.T_ServiceRecordIsGroupsHiddenRule = checkHidden("T_ServiceRecord", "OnEdit", true);
			ViewBag.T_ServiceRecordIsSetValueUIRule = checkSetValueUIRule("T_ServiceRecord", "OnEdit");
            return View(t_servicerecord);
        }
        // GET: /T_ServiceRecord/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_ServiceRecord") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_ServiceRecord t_servicerecord = db.T_ServiceRecords.Find(id);
            if (t_servicerecord == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_ServiceRecordParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ServiceRecord"))
			 ViewData["T_ServiceRecordParentUrl"] = Request.UrlReferrer;
            return View(t_servicerecord);
        }
        // POST: /T_ServiceRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_ServiceRecord t_servicerecord, string UrlReferrer)
        {
			if (!User.CanDelete("T_ServiceRecord"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_servicerecord))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_servicerecord, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_servicerecord).State = EntityState.Deleted;
            db.T_ServiceRecords.Remove(t_servicerecord);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_ServiceRecordParentUrl"] != null)
					{
						string parentUrl = ViewData["T_ServiceRecordParentUrl"].ToString();
						ViewData["T_ServiceRecordParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_servicerecord);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeEmploymentProfile")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_ServiceRecord obj = db.T_ServiceRecords.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeEmploymentProfileID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_EmployeeType" && AssociatedType == "T_EmploymentRecordEmployeeType")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_ServiceRecord obj = db.T_ServiceRecords.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmploymentRecordEmployeeTypeID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_AllFacilities" && AssociatedType == "T_EmploymentRecordHiredAtFacility")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_ServiceRecord obj = db.T_ServiceRecords.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmploymentRecordHiredAtFacilityID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_TerminationReason" && AssociatedType == "T_EmployeeTerminationReason")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_ServiceRecord obj = db.T_ServiceRecords.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeTerminationReasonID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_AllFacilities" && AssociatedType == "T_EmployeeRecordTerminationFacility")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_ServiceRecord obj = db.T_ServiceRecords.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeRecordTerminationFacilityID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_ServiceRecord", User) || !User.CanDelete("T_ServiceRecord")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_ServiceRecord t_servicerecord = db.T_ServiceRecords.Find(id);
		if (CheckBeforeDelete(t_servicerecord))
        {
            if (!CustomDelete(t_servicerecord, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_servicerecord).State = EntityState.Deleted;
                db.T_ServiceRecords.Remove(t_servicerecord);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_ServiceRecord", User) || !User.CanEdit("T_ServiceRecord") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_ServiceRecordParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmploymentProfileID,T_EmploymentRecordEmployeeTypeID,T_IsCurrent,T_EmploymentRecordHiredAtFacilityID,T_HireDate,T_TerminationDate,T_ThreeMonthDue,T_ThreeMonthReviewCompleted,T_SixMonthDue,T_SixMonthReviewCompleted,T_TwelveMonthDue,T_TwelveMonthReviewCompleted,T_ProbationaryExtensionDate,T_ExtensionReviewCompleted,T_EmployeeTerminationReasonID,T_EmployeeRecordTerminationFacilityID,T_TwoWeekNoticeGiven,T_NoticeGivenDate,T_ThirtyDaysSinceTermination,T_ThirteenWeeksSinceTermination,T_EligibleForRehire,T_ProbationNotes,T_TerminationNotes")] T_ServiceRecord t_servicerecord,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_ServiceRecord target = db.T_ServiceRecords.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_servicerecord, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_employeeemploymentprofile != null)
							  db.Entry(target.t_employeeemploymentprofile).State = EntityState.Unchanged;
							if (target.t_employmentrecordemployeetype != null)
							  db.Entry(target.t_employmentrecordemployeetype).State = EntityState.Unchanged;
							if (target.t_employmentrecordhiredatfacility != null)
							  db.Entry(target.t_employmentrecordhiredatfacility).State = EntityState.Unchanged;
							if (target.t_employeeterminationreason != null)
							  db.Entry(target.t_employeeterminationreason).State = EntityState.Unchanged;
							if (target.t_employeerecordterminationfacility != null)
							  db.Entry(target.t_employeerecordterminationfacility).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_servicerecord,"BulkUpdate","");
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
