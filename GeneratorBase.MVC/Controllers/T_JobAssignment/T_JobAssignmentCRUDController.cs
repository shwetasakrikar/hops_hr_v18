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
    public partial class T_JobAssignmentController : BaseController
    {
        // GET: /T_JobAssignment/
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
			var lstT_JobAssignment = from s in db.T_JobAssignments
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_JobAssignment = searchRecords(lstT_JobAssignment, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_JobAssignment = sortRecords(lstT_JobAssignment, sortBy, isAsc);
            }
            else lstT_JobAssignment = lstT_JobAssignment.OrderByDescending(c => c.Id);
			lstT_JobAssignment = CustomSorting(lstT_JobAssignment);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_JobAssignment"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_JobAssignment"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_JobAssignment"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_JobAssignment"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_JobAssignment = lstT_JobAssignment.Include(t=>t.t_employeejobassignment).Include(t=>t.t_positionjobassignment).Include(t=>t.t_jobassignmentreason).Include(t=>t.t_jobassignmentunitx).Include(t=>t.t_jobassignmentmanageremployee).Include(t=>t.t_employeesupervisor);
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeJobAssignment")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_JobAssignment = _T_JobAssignment.Where(p => p.T_EmployeeJobAssignmentID == hostid);
			 }
			 else
			     _T_JobAssignment = _T_JobAssignment.Where(p => p.T_EmployeeJobAssignmentID == null);
         }
		 if (HostingEntity == "T_Position" && AssociatedType == "T_PositionJobAssignment")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_JobAssignment = _T_JobAssignment.Where(p => p.T_PositionJobAssignmentID == hostid);
			 }
			 else
			     _T_JobAssignment = _T_JobAssignment.Where(p => p.T_PositionJobAssignmentID == null);
         }
		 if (HostingEntity == "T_ReasonforHire" && AssociatedType == "T_JobAssignmentReason")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_JobAssignment = _T_JobAssignment.Where(p => p.T_JobAssignmentReasonID == hostid);
			 }
			 else
			     _T_JobAssignment = _T_JobAssignment.Where(p => p.T_JobAssignmentReasonID == null);
         }
		 if (HostingEntity == "T_UnitX" && AssociatedType == "T_JobAssignmentUnitX")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_JobAssignment = _T_JobAssignment.Where(p => p.T_JobAssignmentUnitXID == hostid);
			 }
			 else
			     _T_JobAssignment = _T_JobAssignment.Where(p => p.T_JobAssignmentUnitXID == null);
         }
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_JobAssignmentManagerEmployee")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_JobAssignment = _T_JobAssignment.Where(p => p.T_JobAssignmentManagerEmployeeID == hostid);
			 }
			 else
			     _T_JobAssignment = _T_JobAssignment.Where(p => p.T_JobAssignmentManagerEmployeeID == null);
         }
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeSupervisor")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_JobAssignment = _T_JobAssignment.Where(p => p.T_EmployeeSupervisorID == hostid);
			 }
			 else
			     _T_JobAssignment = _T_JobAssignment.Where(p => p.T_EmployeeSupervisorID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_JobAssignment", User) || !User.CanView("T_JobAssignment"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_JobAssignment.Count() > 0)
                    pageSize = _T_JobAssignment.Count();
                return View("ExcelExport", _T_JobAssignment.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_JobAssignment.Count();
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
				var list = _T_JobAssignment.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_JobAssignmentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_JobAssignmentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_JobAssignment = _fad.FilterDropdown<T_JobAssignment>(User,  _T_JobAssignment, "T_JobAssignment", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_JobAssignment.Except(_T_JobAssignment),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_JobAssignment.Except(_T_JobAssignment).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_JobAssignment.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_JobAssignment.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_JobAssignment.Count() == 0 ? 1 : _T_JobAssignment.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_JobAssignment.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_JobAssignmentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_JobAssignmentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_JobAssignment.Count() == 0 ? 1 : _T_JobAssignment.Count();
                            }
							var list = _T_JobAssignment.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_JobAssignmentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_JobAssignmentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_JobAssignment/Details/5
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
            T_JobAssignment t_jobassignment = db.T_JobAssignments.Find(id);
            if (t_jobassignment == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_jobassignment);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_jobassignment, AssociatedType);
            ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnDetails", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnDetails", true);
			ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnDetails");
			return View(ViewBag.TemplatesName,t_jobassignment);
        }
        // GET: /T_JobAssignment/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_JobAssignment") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_JobAssignmentParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", true);
		  ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnCreate");
          return View();
        }
		// GET: /T_JobAssignment/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_JobAssignment") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_JobAssignmentParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", true);
			 ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnCreate");
            return View();
        }
		// POST: /T_JobAssignment/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeJobAssignmentID,T_EmployeePercent,T_StartDate,T_EndDate,T_Primary,T_Active,T_PositionJobAssignmentID,T_PositionLevel,T_RoleCode,T_ClassCode,T_WorkersCompCode,T_SOCCode,T_OvertimeEligibility,T_JobAssignmentReasonID,T_JobAssignmentUnitXID,T_CostCenter,T_Program,T_DepartmentArea,T_Department,T_JobAssignmentManagerEmployeeID,T_EmployeeSupervisorID,T_SupervisorEmail,T_Notes")] T_JobAssignment t_jobassignment, string UrlReferrer)
        {
			CheckBeforeSave(t_jobassignment);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_jobassignment,out customcreate_hasissues,"Create"))
                {
                    db.T_JobAssignments.Add(t_jobassignment);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_jobassignment,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_jobassignment);
			ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", true);
			ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnCreate");	
            return View(t_jobassignment);
        }
		 // GET: /T_JobAssignment/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_JobAssignment") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_JobAssignmentParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", true);
			ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnCreate");
            return View();
        }
		  // POST: /T_JobAssignment/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeJobAssignmentID,T_EmployeePercent,T_StartDate,T_EndDate,T_Primary,T_Active,T_PositionJobAssignmentID,T_PositionLevel,T_RoleCode,T_ClassCode,T_JobAssignmentReasonID,T_JobAssignmentUnitXID,T_CostCenter,T_Program,T_JobAssignmentManagerEmployeeID,T_EmployeeSupervisorID")] T_JobAssignment t_jobassignment,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_jobassignment);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_jobassignment,out customcreate_hasissues,"Create"))
                {
                    db.T_JobAssignments.Add(t_jobassignment);
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
			LoadViewDataAfterOnCreate(t_jobassignment);
			ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", true);
			ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_jobassignment, AssociatedEntity);
			return View(t_jobassignment);
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
        // POST: /T_JobAssignment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_EmployeeJobAssignmentID,T_EmployeePercent,T_StartDate,T_EndDate,T_Primary,T_Active,T_PositionJobAssignmentID,T_PositionLevel,T_RoleCode,T_ClassCode,T_WorkersCompCode,T_SOCCode,T_OvertimeEligibility,T_JobAssignmentReasonID,T_JobAssignmentUnitXID,T_CostCenter,T_Program,T_DepartmentArea,T_Department,T_JobAssignmentManagerEmployeeID,T_EmployeeSupervisorID,T_SupervisorEmail,T_Notes")] T_JobAssignment t_jobassignment, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_jobassignment, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_jobassignment,out customcreate_hasissues,command))
                {
                    db.T_JobAssignments.Add(t_jobassignment);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_jobassignment,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_jobassignment.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_jobassignment);
			ViewData["T_JobAssignmentParentUrl"] = UrlReferrer;
			ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnCreate", true);
			ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnCreate");
            return View(t_jobassignment);
        }
		// GET: /T_JobAssignment/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_JobAssignment") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_JobAssignment t_jobassignment = db.T_JobAssignments.Find(id);
            if (t_jobassignment == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_JobAssignmentParentUrl"] = UrlReferrer;
		if(ViewData["T_JobAssignmentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_JobAssignment")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_JobAssignment/Edit/" + t_jobassignment.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_JobAssignment/Create"))
			ViewData["T_JobAssignmentParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_jobassignment);
		   ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", true);
		   ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnEdit");
		    var objT_JobAssignment = new List<T_JobAssignment>();
            ViewBag.T_JobAssignmentDD = new SelectList(objT_JobAssignment, "ID", "DisplayValue"); 
          return View(t_jobassignment);
        }
		// POST: /T_JobAssignment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeJobAssignmentID,T_EmployeePercent,T_StartDate,T_EndDate,T_Primary,T_Active,T_PositionJobAssignmentID,T_PositionLevel,T_RoleCode,T_ClassCode,T_WorkersCompCode,T_SOCCode,T_OvertimeEligibility,T_JobAssignmentReasonID,T_JobAssignmentUnitXID,T_CostCenter,T_Program,T_DepartmentArea,T_Department,T_JobAssignmentManagerEmployeeID,T_EmployeeSupervisorID,T_SupervisorEmail,T_Notes")] T_JobAssignment t_jobassignment,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_jobassignment, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_jobassignment,out customsave_hasissues,command))
                {
					db.Entry(t_jobassignment).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_jobassignment);
			ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", true);
			ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnEdit");
            return View(t_jobassignment);
        }
        // GET: /T_JobAssignment/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_JobAssignment") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_JobAssignment t_jobassignment = db.T_JobAssignments.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_JobAssignmentlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_JobAssignments.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_JobAssignmentDisplayValueEdit = TempData["T_JobAssignmentlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_JobAssignmentlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_JobAssignmentDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_jobassignment == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_JobAssignment/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_jobassignment.DisplayValue, Value = t_jobassignment.Id.ToString() }));
                ViewBag.EntityT_JobAssignmentDisplayValueEdit = newList;
				TempData["T_JobAssignmentlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_jobassignment.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_jobassignment.DisplayValue;
                    newList[0].Value = t_jobassignment.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_jobassignment.DisplayValue, Value = t_jobassignment.Id.ToString() }));
                }
                ViewBag.EntityT_JobAssignmentDisplayValueEdit = newList;
				TempData["T_JobAssignmentlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_JobAssignmentParentUrl"] = UrlReferrer;
		if(ViewData["T_JobAssignmentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_JobAssignment")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_JobAssignment/Edit/" + t_jobassignment.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_JobAssignment/Create"))
			ViewData["T_JobAssignmentParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_jobassignment);
		   ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", true);
		   ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnEdit");
          return View(t_jobassignment);
        }
        // POST: /T_JobAssignment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_EmployeeJobAssignmentID,T_EmployeePercent,T_StartDate,T_EndDate,T_Primary,T_Active,T_PositionJobAssignmentID,T_PositionLevel,T_RoleCode,T_ClassCode,T_WorkersCompCode,T_SOCCode,T_OvertimeEligibility,T_JobAssignmentReasonID,T_JobAssignmentUnitXID,T_CostCenter,T_Program,T_DepartmentArea,T_Department,T_JobAssignmentManagerEmployeeID,T_EmployeeSupervisorID,T_SupervisorEmail,T_Notes")] T_JobAssignment t_jobassignment,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_jobassignment, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_jobassignment,out customsave_hasissues,command))
            {
				db.Entry(t_jobassignment).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_jobassignment,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_jobassignment.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_JobAssignmentlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_JobAssignments.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_JobAssignmentDisplayValueEdit = TempData["T_JobAssignmentlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_JobAssignmentlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_JobAssignmentDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_jobassignment);
			 ViewData["T_JobAssignmentParentUrl"] = UrlReferrer;
			ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", true);
			ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnEdit");
            return View(t_jobassignment);
        }
		// GET: /T_JobAssignment/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_JobAssignment") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_JobAssignment t_jobassignment = db.T_JobAssignments.Find(id);
            if (t_jobassignment == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_JobAssignmentParentUrl"] = UrlReferrer;
		if(ViewData["T_JobAssignmentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_JobAssignment"))
			ViewData["T_JobAssignmentParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_jobassignment);
			 ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", true);
			 ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnEdit");
          return View(t_jobassignment);
        }
        // POST: /T_JobAssignment/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeJobAssignmentID,T_EmployeePercent,T_StartDate,T_EndDate,T_Primary,T_Active,T_PositionJobAssignmentID,T_PositionLevel,T_RoleCode,T_ClassCode,T_WorkersCompCode,T_SOCCode,T_OvertimeEligibility,T_JobAssignmentReasonID,T_JobAssignmentUnitXID,T_CostCenter,T_Program,T_DepartmentArea,T_Department,T_JobAssignmentManagerEmployeeID,T_EmployeeSupervisorID,T_SupervisorEmail,T_Notes")] T_JobAssignment t_jobassignment,string UrlReferrer)
        {
			CheckBeforeSave(t_jobassignment);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_jobassignment,out customsave_hasissues,"Save"))
            {
				db.Entry(t_jobassignment).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_jobassignment,"Edit","");
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
			LoadViewDataAfterOnEdit(t_jobassignment);
			ViewBag.T_JobAssignmentIsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", false);
			ViewBag.T_JobAssignmentIsGroupsHiddenRule = checkHidden("T_JobAssignment", "OnEdit", true);
			ViewBag.T_JobAssignmentIsSetValueUIRule = checkSetValueUIRule("T_JobAssignment", "OnEdit");
            return View(t_jobassignment);
        }
        // GET: /T_JobAssignment/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_JobAssignment") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_JobAssignment t_jobassignment = db.T_JobAssignments.Find(id);
            if (t_jobassignment == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_JobAssignmentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_JobAssignment"))
			 ViewData["T_JobAssignmentParentUrl"] = Request.UrlReferrer;
            return View(t_jobassignment);
        }
        // POST: /T_JobAssignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_JobAssignment t_jobassignment, string UrlReferrer)
        {
			if (!User.CanDelete("T_JobAssignment"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_jobassignment))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_jobassignment, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_jobassignment).State = EntityState.Deleted;
            db.T_JobAssignments.Remove(t_jobassignment);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_JobAssignmentParentUrl"] != null)
					{
						string parentUrl = ViewData["T_JobAssignmentParentUrl"].ToString();
						ViewData["T_JobAssignmentParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_jobassignment);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeJobAssignment")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_JobAssignment obj = db.T_JobAssignments.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeJobAssignmentID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Position" && AssociatedType == "T_PositionJobAssignment")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_JobAssignment obj = db.T_JobAssignments.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionJobAssignmentID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_ReasonforHire" && AssociatedType == "T_JobAssignmentReason")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_JobAssignment obj = db.T_JobAssignments.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_JobAssignmentReasonID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_UnitX" && AssociatedType == "T_JobAssignmentUnitX")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_JobAssignment obj = db.T_JobAssignments.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_JobAssignmentUnitXID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Employee" && AssociatedType == "T_JobAssignmentManagerEmployee")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_JobAssignment obj = db.T_JobAssignments.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_JobAssignmentManagerEmployeeID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeSupervisor")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_JobAssignment obj = db.T_JobAssignments.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeSupervisorID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_JobAssignment", User) || !User.CanDelete("T_JobAssignment")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_JobAssignment t_jobassignment = db.T_JobAssignments.Find(id);
		if (CheckBeforeDelete(t_jobassignment))
        {
            if (!CustomDelete(t_jobassignment, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_jobassignment).State = EntityState.Deleted;
                db.T_JobAssignments.Remove(t_jobassignment);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_JobAssignment", User) || !User.CanEdit("T_JobAssignment") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_JobAssignmentParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_EmployeeJobAssignmentID,T_EmployeePercent,T_StartDate,T_EndDate,T_Primary,T_Active,T_PositionJobAssignmentID,T_PositionLevel,T_RoleCode,T_ClassCode,T_WorkersCompCode,T_SOCCode,T_OvertimeEligibility,T_JobAssignmentReasonID,T_JobAssignmentUnitXID,T_CostCenter,T_Program,T_DepartmentArea,T_Department,T_JobAssignmentManagerEmployeeID,T_EmployeeSupervisorID,T_SupervisorEmail,T_Notes")] T_JobAssignment t_jobassignment,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_JobAssignment target = db.T_JobAssignments.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_jobassignment, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_employeejobassignment != null)
							  db.Entry(target.t_employeejobassignment).State = EntityState.Unchanged;
							if (target.t_positionjobassignment != null)
							  db.Entry(target.t_positionjobassignment).State = EntityState.Unchanged;
							if (target.t_jobassignmentreason != null)
							  db.Entry(target.t_jobassignmentreason).State = EntityState.Unchanged;
							if (target.t_jobassignmentunitx != null)
							  db.Entry(target.t_jobassignmentunitx).State = EntityState.Unchanged;
							if (target.t_jobassignmentmanageremployee != null)
							  db.Entry(target.t_jobassignmentmanageremployee).State = EntityState.Unchanged;
							if (target.t_employeesupervisor != null)
							  db.Entry(target.t_employeesupervisor).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_jobassignment,"BulkUpdate","");
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
