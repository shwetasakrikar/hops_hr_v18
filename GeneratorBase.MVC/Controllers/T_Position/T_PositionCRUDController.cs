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
    public partial class T_PositionController : BaseController
    {
        // GET: /T_Position/
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
			var lstT_Position = from s in db.T_Positions
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Position = searchRecords(lstT_Position, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Position = sortRecords(lstT_Position, sortBy, isAsc);
            }
            else lstT_Position = lstT_Position.OrderBy(c=>c.T_PositionFill);
			lstT_Position = CustomSorting(lstT_Position);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Position"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Position"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Position"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Position"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_Position = lstT_Position.Include(t=>t.t_facilityassignedto).Include(t=>t.t_typeofposition).Include(t=>t.t_associatedpositionstatus).Include(t=>t.t_positionidentifier).Include(t=>t.t_positionworkingtitleassociation).Include(t=>t.t_positionrolecode).Include(t=>t.t_positionsoccode).Include(t=>t.t_positionclasscode).Include(t=>t.t_workerscompcodeposition).Include(t=>t.t_positioncostcenterassociation).Include(t=>t.t_positionshiftmealtime).Include(t=>t.t_positionshifttime).Include(t=>t.t_positionshiftduration).Include(t=>t.t_positionovertimeeligibility).Include(t=>t.t_positionstatusforposting);
		 if (HostingEntity == "T_Facility" && AssociatedType == "T_FacilityAssignedTo")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_FacilityAssignedToID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_FacilityAssignedToID == null);
         }
		 if (HostingEntity == "T_PositionType" && AssociatedType == "T_TypeOfPosition")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_TypeOfPositionID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_TypeOfPositionID == null);
         }
		 if (HostingEntity == "T_Positionstatus" && AssociatedType == "T_AssociatedPositionStatus")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_AssociatedPositionStatusID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_AssociatedPositionStatusID == null);
         }
		 if (HostingEntity == "T_PositionLevel" && AssociatedType == "T_PositionIdentifier")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionIdentifierID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionIdentifierID == null);
         }
		 if (HostingEntity == "T_WorkingTitle" && AssociatedType == "T_PositionWorkingTitleAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionWorkingTitleAssociationID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionWorkingTitleAssociationID == null);
         }
		 if (HostingEntity == "T_RoleCode" && AssociatedType == "T_PositionRoleCode")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionRoleCodeID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionRoleCodeID == null);
         }
		 if (HostingEntity == "T_SocCode" && AssociatedType == "T_PositionSOCCode")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionSOCCodeID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionSOCCodeID == null);
         }
		 if (HostingEntity == "T_ClassCode" && AssociatedType == "T_PositionClassCode")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionClassCodeID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionClassCodeID == null);
         }
		 if (HostingEntity == "T_WCCode" && AssociatedType == "T_WorkersCompCodePosition")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_WorkersCompCodePositionID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_WorkersCompCodePositionID == null);
         }
		 if (HostingEntity == "T_CostCenter" && AssociatedType == "T_PositionCostCenterAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionCostCenterAssociationID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionCostCenterAssociationID == null);
         }
		 if (HostingEntity == "T_ShiftMealTime" && AssociatedType == "T_PositionShiftMealTime")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionShiftMealTimeID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionShiftMealTimeID == null);
         }
		 if (HostingEntity == "T_ShiftTime" && AssociatedType == "T_PositionShiftTime")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionShiftTimeID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionShiftTimeID == null);
         }
		 if (HostingEntity == "T_ShiftDuration" && AssociatedType == "T_PositionShiftDuration")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionShiftDurationID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionShiftDurationID == null);
         }
		 if (HostingEntity == "T_OvertimeEligibility" && AssociatedType == "T_PositionOvertimeEligibility")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionOvertimeEligibilityID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionOvertimeEligibilityID == null);
         }
		 if (HostingEntity == "T_PositionPostStatus" && AssociatedType == "T_PositionStatusforPosting")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Position = _T_Position.Where(p => p.T_PositionStatusforPostingID == hostid);
			 }
			 else
			     _T_Position = _T_Position.Where(p => p.T_PositionStatusforPostingID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_Position", User) || !User.CanView("T_Position"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_Position.Count() > 0)
                    pageSize = _T_Position.Count();
                return View("ExcelExport", _T_Position.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Position.Count();
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
				var list = _T_Position.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_PositionDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_Positionlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_Position = _fad.FilterDropdown<T_Position>(User,  _T_Position, "T_Position", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_Position.Except(_T_Position),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_Position.Except(_T_Position).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_Position.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_Position.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_Position.Count() == 0 ? 1 : _T_Position.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_Position.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_PositionDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Positionlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_Position.Count() == 0 ? 1 : _T_Position.Count();
                            }
							var list = _T_Position.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_PositionDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Positionlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_Position/Details/5
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
            T_Position t_position = db.T_Positions.Find(id);
            if (t_position == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_position);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_position, AssociatedType);
            ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnDetails", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnDetails", true);
			ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnDetails");
			return View(ViewBag.TemplatesName,t_position);
        }
        // GET: /T_Position/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_Position") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_PositionParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnCreate", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnCreate", true);
		  ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnCreate");
          return View();
        }
		// GET: /T_Position/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_Position") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_PositionParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnCreate", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnCreate", true);
			 ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnCreate");
            return View();
        }
		// POST: /T_Position/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_FacilityAssignedToID,T_PositionNumber,T_TypeOfPositionID,T_AssociatedPositionStatusID,T_PositionIdentifierID,T_PositionFill,T_QuasiFill,T_PositionWorkingTitleAssociationID,T_EffectiveDate,T_PositionRoleCodeID,T_SalaryBand,T_PositionSOCCodeID,T_PositionClassCodeID,T_WorkersCompCodePositionID,T_CardApprvr,T_PositionCostCenterAssociationID,T_ShiftStart,T_ShiftEnd,T_PositionShiftMealTimeID,T_PositionShiftTimeID,T_PositionShiftDurationID,T_PositionOvertimeEligibilityID,T_DualIncumbent,T_DualIncumbentStartDate,T_DualIncumbentEndDate,T_PositionStatusforPostingID,T_Funded,T_EstablishedDate,T_AbolishDate")] T_Position t_position, string UrlReferrer)
        {
			CheckBeforeSave(t_position);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_position,out customcreate_hasissues,"Create"))
                {
                    db.T_Positions.Add(t_position);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_position,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_position);
			ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnCreate", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnCreate", true);
			ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnCreate");	
            return View(t_position);
        }
		 // GET: /T_Position/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_Position") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_PositionParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnCreate", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnCreate", true);
			ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnCreate");
            return View();
        }
		  // POST: /T_Position/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_FacilityAssignedToID,T_PositionNumber,T_TypeOfPositionID,T_AssociatedPositionStatusID,T_PositionIdentifierID,T_PositionFill,T_PositionWorkingTitleAssociationID,T_EffectiveDate,T_PositionRoleCodeID,T_SalaryBand,T_PositionSOCCodeID,T_PositionClassCodeID,T_WorkersCompCodePositionID,T_PositionCostCenterAssociationID,T_ShiftStart,T_ShiftEnd,T_PositionShiftMealTimeID,T_PositionShiftTimeID,T_PositionShiftDurationID,T_PositionOvertimeEligibilityID,T_PositionStatusforPostingID,T_EstablishedDate")] T_Position t_position,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_position);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_position,out customcreate_hasissues,"Create"))
                {
                    db.T_Positions.Add(t_position);
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
			LoadViewDataAfterOnCreate(t_position);
			ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnCreate", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnCreate", true);
			ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_position, AssociatedEntity);
			return View(t_position);
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
        // POST: /T_Position/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_FacilityAssignedToID,T_PositionNumber,T_TypeOfPositionID,T_AssociatedPositionStatusID,T_PositionIdentifierID,T_PositionFill,T_QuasiFill,T_PositionWorkingTitleAssociationID,T_EffectiveDate,T_PositionRoleCodeID,T_SalaryBand,T_PositionSOCCodeID,T_PositionClassCodeID,T_WorkersCompCodePositionID,T_CardApprvr,T_PositionCostCenterAssociationID,T_ShiftStart,T_ShiftEnd,T_PositionShiftMealTimeID,T_PositionShiftTimeID,T_PositionShiftDurationID,T_PositionOvertimeEligibilityID,T_DualIncumbent,T_DualIncumbentStartDate,T_DualIncumbentEndDate,T_PositionStatusforPostingID,T_Funded,T_EstablishedDate,T_AbolishDate")] T_Position t_position, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_position, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_position,out customcreate_hasissues,command))
                {
                    db.T_Positions.Add(t_position);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_position,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_position.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_position);
			ViewData["T_PositionParentUrl"] = UrlReferrer;
			ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnCreate", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnCreate", true);
			ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnCreate");
            return View(t_position);
        }
		// GET: /T_Position/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Position") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_Position t_position = db.T_Positions.Find(id);
            if (t_position == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_PositionParentUrl"] = UrlReferrer;
		if(ViewData["T_PositionParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Position")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Position/Edit/" + t_position.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Position/Create"))
			ViewData["T_PositionParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_position);
		   ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnEdit", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnEdit", true);
		   ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnEdit");
		    var objT_Position = new List<T_Position>();
            ViewBag.T_PositionDD = new SelectList(objT_Position, "ID", "DisplayValue"); 
          return View(t_position);
        }
		// POST: /T_Position/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_FacilityAssignedToID,T_PositionNumber,T_TypeOfPositionID,T_AssociatedPositionStatusID,T_PositionIdentifierID,T_PositionFill,T_QuasiFill,T_PositionWorkingTitleAssociationID,T_EffectiveDate,T_PositionRoleCodeID,T_SalaryBand,T_PositionSOCCodeID,T_PositionClassCodeID,T_WorkersCompCodePositionID,T_CardApprvr,T_PositionCostCenterAssociationID,T_ShiftStart,T_ShiftEnd,T_PositionShiftMealTimeID,T_PositionShiftTimeID,T_PositionShiftDurationID,T_PositionOvertimeEligibilityID,T_DualIncumbent,T_DualIncumbentStartDate,T_DualIncumbentEndDate,T_PositionStatusforPostingID,T_Funded,T_EstablishedDate,T_AbolishDate")] T_Position t_position,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_position, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_position,out customsave_hasissues,command))
                {
					db.Entry(t_position).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_position);
			ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnEdit", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnEdit", true);
			ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnEdit");
            return View(t_position);
        }
        // GET: /T_Position/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_Position") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Position t_position = db.T_Positions.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Positionlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Positions.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_PositionDisplayValueEdit = TempData["T_Positionlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Positionlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_PositionDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_position == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_Position/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_position.DisplayValue, Value = t_position.Id.ToString() }));
                ViewBag.EntityT_PositionDisplayValueEdit = newList;
				TempData["T_Positionlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_position.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_position.DisplayValue;
                    newList[0].Value = t_position.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_position.DisplayValue, Value = t_position.Id.ToString() }));
                }
                ViewBag.EntityT_PositionDisplayValueEdit = newList;
				TempData["T_Positionlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_PositionParentUrl"] = UrlReferrer;
		if(ViewData["T_PositionParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Position")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Position/Edit/" + t_position.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Position/Create"))
			ViewData["T_PositionParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_position);
		   ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnEdit", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnEdit", true);
		   ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnEdit");
          return View(t_position);
        }
        // POST: /T_Position/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_FacilityAssignedToID,T_PositionNumber,T_TypeOfPositionID,T_AssociatedPositionStatusID,T_PositionIdentifierID,T_PositionFill,T_QuasiFill,T_PositionWorkingTitleAssociationID,T_EffectiveDate,T_PositionRoleCodeID,T_SalaryBand,T_PositionSOCCodeID,T_PositionClassCodeID,T_WorkersCompCodePositionID,T_CardApprvr,T_PositionCostCenterAssociationID,T_ShiftStart,T_ShiftEnd,T_PositionShiftMealTimeID,T_PositionShiftTimeID,T_PositionShiftDurationID,T_PositionOvertimeEligibilityID,T_DualIncumbent,T_DualIncumbentStartDate,T_DualIncumbentEndDate,T_PositionStatusforPostingID,T_Funded,T_EstablishedDate,T_AbolishDate")] T_Position t_position,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_position, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_position,out customsave_hasissues,command))
            {
				db.Entry(t_position).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_position,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_position.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_Positionlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Positions.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_PositionDisplayValueEdit = TempData["T_Positionlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Positionlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_PositionDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_position);
			 ViewData["T_PositionParentUrl"] = UrlReferrer;
			ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnEdit", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnEdit", true);
			ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnEdit");
            return View(t_position);
        }
		// GET: /T_Position/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Position") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_Position t_position = db.T_Positions.Find(id);
            if (t_position == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_PositionParentUrl"] = UrlReferrer;
		if(ViewData["T_PositionParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Position"))
			ViewData["T_PositionParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_position);
			 ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnEdit", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnEdit", true);
			 ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnEdit");
          return View(t_position);
        }
        // POST: /T_Position/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_FacilityAssignedToID,T_PositionNumber,T_TypeOfPositionID,T_AssociatedPositionStatusID,T_PositionIdentifierID,T_PositionFill,T_QuasiFill,T_PositionWorkingTitleAssociationID,T_EffectiveDate,T_PositionRoleCodeID,T_SalaryBand,T_PositionSOCCodeID,T_PositionClassCodeID,T_WorkersCompCodePositionID,T_CardApprvr,T_PositionCostCenterAssociationID,T_ShiftStart,T_ShiftEnd,T_PositionShiftMealTimeID,T_PositionShiftTimeID,T_PositionShiftDurationID,T_PositionOvertimeEligibilityID,T_DualIncumbent,T_DualIncumbentStartDate,T_DualIncumbentEndDate,T_PositionStatusforPostingID,T_Funded,T_EstablishedDate,T_AbolishDate")] T_Position t_position,string UrlReferrer)
        {
			CheckBeforeSave(t_position);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_position,out customsave_hasissues,"Save"))
            {
				db.Entry(t_position).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_position,"Edit","");
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
			LoadViewDataAfterOnEdit(t_position);
			ViewBag.T_PositionIsHiddenRule = checkHidden("T_Position", "OnEdit", false);
			ViewBag.T_PositionIsGroupsHiddenRule = checkHidden("T_Position", "OnEdit", true);
			ViewBag.T_PositionIsSetValueUIRule = checkSetValueUIRule("T_Position", "OnEdit");
            return View(t_position);
        }
        // GET: /T_Position/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_Position") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_Position t_position = db.T_Positions.Find(id);
            if (t_position == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_PositionParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Position"))
			 ViewData["T_PositionParentUrl"] = Request.UrlReferrer;
            return View(t_position);
        }
        // POST: /T_Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_Position t_position, string UrlReferrer)
        {
			if (!User.CanDelete("T_Position"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_position))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_position, out customdelete_hasissues, "Delete"))
                {
            var listT_PositionJobAssignment = db.T_JobAssignments.Where(p => p.T_PositionJobAssignmentID == t_position.Id);
            foreach (var lst in listT_PositionJobAssignment)
               db.T_JobAssignments.Remove(lst);
           db.SaveChanges();
			db.Entry(t_position).State = EntityState.Deleted;
            db.T_Positions.Remove(t_position);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_PositionParentUrl"] != null)
					{
						string parentUrl = ViewData["T_PositionParentUrl"].ToString();
						ViewData["T_PositionParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_position);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Facility" && AssociatedType == "T_FacilityAssignedTo")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_FacilityAssignedToID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_PositionType" && AssociatedType == "T_TypeOfPosition")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_TypeOfPositionID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Positionstatus" && AssociatedType == "T_AssociatedPositionStatus")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_AssociatedPositionStatusID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_PositionLevel" && AssociatedType == "T_PositionIdentifier")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionIdentifierID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_WorkingTitle" && AssociatedType == "T_PositionWorkingTitleAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionWorkingTitleAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_RoleCode" && AssociatedType == "T_PositionRoleCode")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionRoleCodeID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_SocCode" && AssociatedType == "T_PositionSOCCode")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionSOCCodeID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_ClassCode" && AssociatedType == "T_PositionClassCode")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionClassCodeID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_WCCode" && AssociatedType == "T_WorkersCompCodePosition")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_WorkersCompCodePositionID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_CostCenter" && AssociatedType == "T_PositionCostCenterAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionCostCenterAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_ShiftMealTime" && AssociatedType == "T_PositionShiftMealTime")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionShiftMealTimeID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_ShiftTime" && AssociatedType == "T_PositionShiftTime")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionShiftTimeID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_ShiftDuration" && AssociatedType == "T_PositionShiftDuration")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionShiftDurationID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_OvertimeEligibility" && AssociatedType == "T_PositionOvertimeEligibility")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionOvertimeEligibilityID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_PositionPostStatus" && AssociatedType == "T_PositionStatusforPosting")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Position obj = db.T_Positions.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PositionStatusforPostingID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_Position", User) || !User.CanDelete("T_Position")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_Position t_position = db.T_Positions.Find(id);
		if (CheckBeforeDelete(t_position))
        {
            if (!CustomDelete(t_position, out customdelete_hasissues, "DeleteBulk"))
            {
            var listT_PositionJobAssignment = db.T_JobAssignments.Where(p => p.T_PositionJobAssignmentID == id);
            foreach (var lst in listT_PositionJobAssignment)
               db.T_JobAssignments.Remove(lst);
           db.SaveChanges();
                db.Entry(t_position).State = EntityState.Deleted;
                db.T_Positions.Remove(t_position);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_Position", User) || !User.CanEdit("T_Position") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_PositionParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_FacilityAssignedToID,T_PositionNumber,T_TypeOfPositionID,T_AssociatedPositionStatusID,T_PositionIdentifierID,T_PositionFill,T_QuasiFill,T_PositionWorkingTitleAssociationID,T_EffectiveDate,T_PositionRoleCodeID,T_SalaryBand,T_PositionSOCCodeID,T_PositionClassCodeID,T_WorkersCompCodePositionID,T_CardApprvr,T_PositionCostCenterAssociationID,T_ShiftStart,T_ShiftEnd,T_PositionShiftMealTimeID,T_PositionShiftTimeID,T_PositionShiftDurationID,T_PositionOvertimeEligibilityID,T_DualIncumbent,T_DualIncumbentStartDate,T_DualIncumbentEndDate,T_PositionStatusforPostingID,T_Funded,T_EstablishedDate,T_AbolishDate")] T_Position t_position,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_Position target = db.T_Positions.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_position, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_facilityassignedto != null)
							  db.Entry(target.t_facilityassignedto).State = EntityState.Unchanged;
							if (target.t_typeofposition != null)
							  db.Entry(target.t_typeofposition).State = EntityState.Unchanged;
							if (target.t_associatedpositionstatus != null)
							  db.Entry(target.t_associatedpositionstatus).State = EntityState.Unchanged;
							if (target.t_positionidentifier != null)
							  db.Entry(target.t_positionidentifier).State = EntityState.Unchanged;
							if (target.t_positionworkingtitleassociation != null)
							  db.Entry(target.t_positionworkingtitleassociation).State = EntityState.Unchanged;
							if (target.t_positionrolecode != null)
							  db.Entry(target.t_positionrolecode).State = EntityState.Unchanged;
							if (target.t_positionsoccode != null)
							  db.Entry(target.t_positionsoccode).State = EntityState.Unchanged;
							if (target.t_positionclasscode != null)
							  db.Entry(target.t_positionclasscode).State = EntityState.Unchanged;
							if (target.t_workerscompcodeposition != null)
							  db.Entry(target.t_workerscompcodeposition).State = EntityState.Unchanged;
							if (target.t_positioncostcenterassociation != null)
							  db.Entry(target.t_positioncostcenterassociation).State = EntityState.Unchanged;
							if (target.t_positionshiftmealtime != null)
							  db.Entry(target.t_positionshiftmealtime).State = EntityState.Unchanged;
							if (target.t_positionshifttime != null)
							  db.Entry(target.t_positionshifttime).State = EntityState.Unchanged;
							if (target.t_positionshiftduration != null)
							  db.Entry(target.t_positionshiftduration).State = EntityState.Unchanged;
							if (target.t_positionovertimeeligibility != null)
							  db.Entry(target.t_positionovertimeeligibility).State = EntityState.Unchanged;
							if (target.t_positionstatusforposting != null)
							  db.Entry(target.t_positionstatusforposting).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_position,"BulkUpdate","");
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
