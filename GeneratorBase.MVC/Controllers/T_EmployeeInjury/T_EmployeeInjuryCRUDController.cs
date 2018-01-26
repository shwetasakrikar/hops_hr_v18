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
    public partial class T_EmployeeInjuryController : BaseController
    {
		
		
        // GET: /T_EmployeeInjury/
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
			var lstT_EmployeeInjury = from s in db.T_EmployeeInjurys
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_EmployeeInjury = searchRecords(lstT_EmployeeInjury, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_EmployeeInjury = sortRecords(lstT_EmployeeInjury, sortBy, isAsc);
            }
            else lstT_EmployeeInjury = lstT_EmployeeInjury.OrderByDescending(c => c.Id);
			lstT_EmployeeInjury = CustomSorting(lstT_EmployeeInjury);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_EmployeeInjury"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_EmployeeInjury"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_EmployeeInjury"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_EmployeeInjury"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_EmployeeInjury = lstT_EmployeeInjury.Include(t=>t.t_employeeemployeeinjury).Include(t=>t.t_typeofclaimmci).Include(t=>t.t_accidentshift).Include(t=>t.t_facilityaccidentoccured).Include(t=>t.t_unitwhereaccidentoccured).Include(t=>t.t_employeinjuryfloor).Include(t=>t.t_locationofaccident).Include(t=>t.t_employeeinjurycause).Include(t=>t.t_employeeinjurynature).Include(t=>t.t_employeeinjurybodypartsaffected).Include(t=>t.t_employeeinjurymachinetool).Include(t=>t.t_initialtreatmentlist).Include(t=>t.t_employeeinjurymedicalfacilityfortreatment).Include(t=>t.t_employeeinjuryrefusal);
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeEmployeeInjury")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeEmployeeInjuryID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeEmployeeInjuryID == null);
         }
		 if (HostingEntity == "T_ClaimTypeMCI" && AssociatedType == "T_TypeofClaimMCI")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_TypeofClaimMCIID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_TypeofClaimMCIID == null);
         }
		 if (HostingEntity == "T_ShiftTime" && AssociatedType == "T_AccidentShift")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_AccidentShiftID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_AccidentShiftID == null);
         }
		 if (HostingEntity == "T_AllFacilities" && AssociatedType == "T_FacilityAccidentOccured")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_FacilityAccidentOccuredID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_FacilityAccidentOccuredID == null);
         }
		 if (HostingEntity == "T_AllFacilitiesUnit" && AssociatedType == "T_UnitWhereAccidentOccured")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_UnitWhereAccidentOccuredID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_UnitWhereAccidentOccuredID == null);
         }
		 if (HostingEntity == "T_AllFacilitiesFloor" && AssociatedType == "T_EmployeInjuryFloor")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeInjuryFloorID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeInjuryFloorID == null);
         }
		 if (HostingEntity == "T_WCAccident" && AssociatedType == "T_LocationOfAccident")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_LocationOfAccidentID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_LocationOfAccidentID == null);
         }
		 if (HostingEntity == "T_InjuryCause" && AssociatedType == "T_EmployeeInjuryCause")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeInjuryCauseID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeInjuryCauseID == null);
         }
		 if (HostingEntity == "T_InjuryNature" && AssociatedType == "T_EmployeeInjuryNature")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeInjuryNatureID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeInjuryNatureID == null);
         }
		 if (HostingEntity == "T_BodyPartsAffected" && AssociatedType == "T_EmployeeInjuryBodyPartsAffected")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeInjuryBodyPartsAffectedID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeInjuryBodyPartsAffectedID == null);
         }
		 if (HostingEntity == "T_MachineTool" && AssociatedType == "T_EMployeeInjuryMachineTool")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EMployeeInjuryMachineToolID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EMployeeInjuryMachineToolID == null);
         }
		 if (HostingEntity == "T_InitialTreatment" && AssociatedType == "T_InitialTreatmentList")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_InitialTreatmentListID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_InitialTreatmentListID == null);
         }
		 if (HostingEntity == "T_MedicalFacilityForTreatment" && AssociatedType == "T_EmployeeInjuryMedicalFacilityForTreatment")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeInjuryMedicalFacilityForTreatmentID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeInjuryMedicalFacilityForTreatmentID == null);
         }
		 if (HostingEntity == "T_Refusal" && AssociatedType == "T_EmployeeInjuryRefusal")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeInjuryRefusalID == hostid);
			 }
			 else
			     _T_EmployeeInjury = _T_EmployeeInjury.Where(p => p.T_EmployeeInjuryRefusalID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_EmployeeInjury", User) || !User.CanView("T_EmployeeInjury"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_EmployeeInjury.Count() > 0)
                    pageSize = _T_EmployeeInjury.Count();
                return View("ExcelExport", _T_EmployeeInjury.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_EmployeeInjury.Count();
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
					var list = _T_EmployeeInjury.ToPagedList(pageNumber, pageSize);
					ViewBag.EntityT_EmployeeInjuryDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
					TempData["T_EmployeeInjurylist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
					return View(list);
				}
				 else
				 {
					if (BulkOperation != null && (BulkOperation == "single" || BulkOperation == "multiple"))
					{
						FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
                        _T_EmployeeInjury = _fad.FilterDropdown<T_EmployeeInjury>(User, _T_EmployeeInjury, "T_EmployeeInjury", caller);
						return PartialView("BulkOperation", _T_EmployeeInjury.OrderBy(p=>p.Id).ToPagedList(pageNumber, pageSize)); 
					}
					else
					{
						if (ViewBag.TemplatesName == null)
						{
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_EmployeeInjury.Count() == 0 ? 1 : _T_EmployeeInjury.Count();
                            }
							var list = _T_EmployeeInjury.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_EmployeeInjuryDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_EmployeeInjurylist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
						}
					    else
						{
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_EmployeeInjury.Count() == 0 ? 1 : _T_EmployeeInjury.Count();
                            }
							var list = _T_EmployeeInjury.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_EmployeeInjuryDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_EmployeeInjurylist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
						}
					}
				 }
        }
		 // GET: /T_EmployeeInjury/Details/5
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
            T_EmployeeInjury t_employeeinjury = db.T_EmployeeInjurys.Find(id);
            if (t_employeeinjury == null)
            {
                return HttpNotFound();
            }
		    t_employeeinjury.T_ClaimType_T_TypeofClaim = db.T_ClaimTypes.OrderBy(c => c.DisplayValue).ToList();
            t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_ClaimTypeID).ToList();
		    t_employeeinjury.T_Restrictions_T_TypeOfRestrictions = db.T_Restrictionss.OrderBy(c => c.DisplayValue).ToList();
            t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_RestrictionsID).ToList();
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_employeeinjury);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_employeeinjury, AssociatedType);
            ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnDetails", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnDetails", true);
			ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnDetails");
			return View(ViewBag.TemplatesName,t_employeeinjury);
        }
        // GET: /T_EmployeeInjury/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_EmployeeInjury") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		    ViewBag.T_ClaimType_T_TypeofClaim = db.T_ClaimTypes.OrderBy(c => c.DisplayValue).ToList();
		    ViewBag.T_Restrictions_T_TypeOfRestrictions = db.T_Restrictionss.OrderBy(c => c.DisplayValue).ToList();
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_EmployeeInjuryParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", true);
		  ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnCreate");
          return View();
        }
		// GET: /T_EmployeeInjury/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_EmployeeInjury") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		    ViewBag.T_ClaimType_T_TypeofClaim = db.T_ClaimTypes.OrderBy(x => x.DisplayValue).ToList();
		    ViewBag.T_Restrictions_T_TypeOfRestrictions = db.T_Restrictionss.OrderBy(x => x.DisplayValue).ToList();
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_EmployeeInjuryParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", true);
			 ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnCreate");
            return View();
        }
		// POST: /T_EmployeeInjury/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmployeeInjuryID,T_TypeofClaimMCIID,T_ClaimNo,T_OSHA,T_AccidentShiftID,T_Location,T_FacilityAccidentOccuredID,T_UnitWhereAccidentOccuredID,T_EmployeInjuryFloorID,T_LocationOfAccidentID,T_AccidentDate,T_DescribeHowInjuryOrIllnessOccurred,T_EmployeeInjuryCauseID,T_EmployeeInjuryNatureID,T_EmployeeInjuryBodyPartsAffectedID,T_EMployeeInjuryMachineToolID,T_InitialTreatmentListID,T_PatientInvolvedRegnoepi,T_EmployeeInjuryMedicalFacilityForTreatmentID,T_ExaminingPhysician,T_ReferringPhysician,T_Diagnosis,T_DaysOff,T_DaysRestricted,T_DetailsOfRestriction,T_RestrictionStartDate,T_RestrictionEndDate,T_EmployeeInjuryRefusalID,T_AccidentNotes,T_RestrictionNotes,SelectedT_ClaimType_T_TypeofClaim,SelectedT_Restrictions_T_TypeOfRestrictions")] T_EmployeeInjury t_employeeinjury, string UrlReferrer)
        {
			CheckBeforeSave(t_employeeinjury);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_employeeinjury,out customcreate_hasissues,"Create"))
                {
                    db.T_EmployeeInjurys.Add(t_employeeinjury);
					db.SaveChanges();
                }
                bool flagT_TypeofClaim = false; 
				var dblistT_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id);
				 if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim != null)
                    dblistT_TypeofClaim = dblistT_TypeofClaim.Where(a => !t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim.Contains(a.T_ClaimTypeID));
                foreach (var obj in dblistT_TypeofClaim)
                {
					 db.T_TypeofClaims.Remove(obj);
					  flagT_TypeofClaim = true; 
				}
				if (flagT_TypeofClaim)
					db.SaveChanges();
				flagT_TypeofClaim = false;
				if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim !=null)
				{
					foreach (var pgs in t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim)
					{
						if (db.T_TypeofClaims.FirstOrDefault(a => a.T_EmployeeInjuryID == t_employeeinjury.Id && a.T_ClaimTypeID == pgs) == null)
                        {
							T_TypeofClaim objT_TypeofClaim = new T_TypeofClaim();
							objT_TypeofClaim.T_EmployeeInjuryID = t_employeeinjury.Id;
							objT_TypeofClaim.T_ClaimTypeID = pgs;
							db.Entry(objT_TypeofClaim).State = EntityState.Added;
							db.T_TypeofClaims.Add(objT_TypeofClaim);
							flagT_TypeofClaim = true;
						}
					}
					if (flagT_TypeofClaim)
						db.SaveChanges();
				 }
                bool flagT_TypeOfRestrictions = false; 
				var dblistT_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id);
				 if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions != null)
                    dblistT_TypeOfRestrictions = dblistT_TypeOfRestrictions.Where(a => !t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions.Contains(a.T_RestrictionsID));
                foreach (var obj in dblistT_TypeOfRestrictions)
                {
					 db.T_TypeOfRestrictionss.Remove(obj);
					  flagT_TypeOfRestrictions = true; 
				}
				if (flagT_TypeOfRestrictions)
					db.SaveChanges();
				flagT_TypeOfRestrictions = false;
				if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions !=null)
				{
					foreach (var pgs in t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions)
					{
						if (db.T_TypeOfRestrictionss.FirstOrDefault(a => a.T_EmployeeInjuryID == t_employeeinjury.Id && a.T_RestrictionsID == pgs) == null)
                        {
							T_TypeOfRestrictions objT_TypeOfRestrictions = new T_TypeOfRestrictions();
							objT_TypeOfRestrictions.T_EmployeeInjuryID = t_employeeinjury.Id;
							objT_TypeOfRestrictions.T_RestrictionsID = pgs;
							db.Entry(objT_TypeOfRestrictions).State = EntityState.Added;
							db.T_TypeOfRestrictionss.Add(objT_TypeOfRestrictions);
							flagT_TypeOfRestrictions = true;
						}
					}
					if (flagT_TypeOfRestrictions)
						db.SaveChanges();
				 }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employeeinjury,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
		    t_employeeinjury.T_ClaimType_T_TypeofClaim = db.T_ClaimTypes.OrderBy(x => x.DisplayValue).ToList();
		    t_employeeinjury.T_Restrictions_T_TypeOfRestrictions = db.T_Restrictionss.OrderBy(x => x.DisplayValue).ToList();
	
			LoadViewDataAfterOnCreate(t_employeeinjury);
			ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", true);
			ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnCreate");	
            return View(t_employeeinjury);
        }
		 // GET: /T_EmployeeInjury/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_EmployeeInjury") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_EmployeeInjuryParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", true);
			ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnCreate");
            return View();
        }
		  // POST: /T_EmployeeInjury/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmployeeInjuryID,T_TypeofClaimMCIID,T_ClaimNo,T_OSHA,T_AccidentShiftID,T_Location,T_FacilityAccidentOccuredID,T_UnitWhereAccidentOccuredID,T_EmployeInjuryFloorID,T_LocationOfAccidentID,T_AccidentDate,T_EmployeeInjuryCauseID,T_EmployeeInjuryNatureID,T_EmployeeInjuryBodyPartsAffectedID,T_EMployeeInjuryMachineToolID,T_InitialTreatmentListID,T_EmployeeInjuryMedicalFacilityForTreatmentID,T_Diagnosis,T_DaysOff,T_DaysRestricted,T_EmployeeInjuryRefusalID")] T_EmployeeInjury t_employeeinjury,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_employeeinjury);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_employeeinjury,out customcreate_hasissues,"Create"))
                {
                    db.T_EmployeeInjurys.Add(t_employeeinjury);
					db.SaveChanges();
                }
				if (HostingEntityName == "T_ClaimType" && AssociatedEntity == "T_TypeofClaim_T_ClaimType")
                {
                    long hostingentityid;
                    if(Int64.TryParse(HostingEntityID,out hostingentityid) && hostingentityid >0)
                    {
                        db.T_TypeofClaims.Add(new T_TypeofClaim { T_ClaimTypeID = hostingentityid, T_EmployeeInjuryID = t_employeeinjury.Id });
                        db.SaveChanges();
                    }
                }
				if (HostingEntityName == "T_Restrictions" && AssociatedEntity == "T_TypeOfRestrictions_T_Restrictions")
                {
                    long hostingentityid;
                    if(Int64.TryParse(HostingEntityID,out hostingentityid) && hostingentityid >0)
                    {
                        db.T_TypeOfRestrictionss.Add(new T_TypeOfRestrictions { T_RestrictionsID = hostingentityid, T_EmployeeInjuryID = t_employeeinjury.Id });
                        db.SaveChanges();
                    }
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
			LoadViewDataAfterOnCreate(t_employeeinjury);
			ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", true);
			ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_employeeinjury, AssociatedEntity);
			return View(t_employeeinjury);
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
        // POST: /T_EmployeeInjury/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmployeeInjuryID,T_TypeofClaimMCIID,T_ClaimNo,T_OSHA,T_AccidentShiftID,T_Location,T_FacilityAccidentOccuredID,T_UnitWhereAccidentOccuredID,T_EmployeInjuryFloorID,T_LocationOfAccidentID,T_AccidentDate,T_DescribeHowInjuryOrIllnessOccurred,T_EmployeeInjuryCauseID,T_EmployeeInjuryNatureID,T_EmployeeInjuryBodyPartsAffectedID,T_EMployeeInjuryMachineToolID,T_InitialTreatmentListID,T_PatientInvolvedRegnoepi,T_EmployeeInjuryMedicalFacilityForTreatmentID,T_ExaminingPhysician,T_ReferringPhysician,T_Diagnosis,T_DaysOff,T_DaysRestricted,T_DetailsOfRestriction,T_RestrictionStartDate,T_RestrictionEndDate,T_EmployeeInjuryRefusalID,T_AccidentNotes,T_RestrictionNotes,SelectedT_ClaimType_T_TypeofClaim,SelectedT_Restrictions_T_TypeOfRestrictions")] T_EmployeeInjury t_employeeinjury, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_employeeinjury, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_employeeinjury,out customcreate_hasissues,command))
                {
                    db.T_EmployeeInjurys.Add(t_employeeinjury);
					db.SaveChanges();
                }
				bool flagT_TypeofClaim = false; 
				var dblistT_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id);
				 if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim != null)
                    dblistT_TypeofClaim = dblistT_TypeofClaim.Where(a => !t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim.Contains(a.T_ClaimTypeID));
                foreach (var obj in dblistT_TypeofClaim)
                {
					 db.T_TypeofClaims.Remove(obj);
					  flagT_TypeofClaim = true; 
				}
				if (flagT_TypeofClaim)
					db.SaveChanges();
				flagT_TypeofClaim = false;
				if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim !=null)
				{
					foreach (var pgs in t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim)
					{
						if (db.T_TypeofClaims.FirstOrDefault(a => a.T_EmployeeInjuryID == t_employeeinjury.Id && a.T_ClaimTypeID == pgs) == null)
                        {
							T_TypeofClaim objT_TypeofClaim = new T_TypeofClaim();
							objT_TypeofClaim.T_EmployeeInjuryID = t_employeeinjury.Id;
							objT_TypeofClaim.T_ClaimTypeID = pgs;
							db.Entry(objT_TypeofClaim).State = EntityState.Added;
							db.T_TypeofClaims.Add(objT_TypeofClaim);
							flagT_TypeofClaim = true;
						}
					}
					if (flagT_TypeofClaim)
						db.SaveChanges();
				 }
				bool flagT_TypeOfRestrictions = false; 
				var dblistT_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id);
				 if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions != null)
                    dblistT_TypeOfRestrictions = dblistT_TypeOfRestrictions.Where(a => !t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions.Contains(a.T_RestrictionsID));
                foreach (var obj in dblistT_TypeOfRestrictions)
                {
					 db.T_TypeOfRestrictionss.Remove(obj);
					  flagT_TypeOfRestrictions = true; 
				}
				if (flagT_TypeOfRestrictions)
					db.SaveChanges();
				flagT_TypeOfRestrictions = false;
				if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions !=null)
				{
					foreach (var pgs in t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions)
					{
						if (db.T_TypeOfRestrictionss.FirstOrDefault(a => a.T_EmployeeInjuryID == t_employeeinjury.Id && a.T_RestrictionsID == pgs) == null)
                        {
							T_TypeOfRestrictions objT_TypeOfRestrictions = new T_TypeOfRestrictions();
							objT_TypeOfRestrictions.T_EmployeeInjuryID = t_employeeinjury.Id;
							objT_TypeOfRestrictions.T_RestrictionsID = pgs;
							db.Entry(objT_TypeOfRestrictions).State = EntityState.Added;
							db.T_TypeOfRestrictionss.Add(objT_TypeOfRestrictions);
							flagT_TypeOfRestrictions = true;
						}
					}
					if (flagT_TypeOfRestrictions)
						db.SaveChanges();
				 }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employeeinjury,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_employeeinjury.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
		    t_employeeinjury.T_ClaimType_T_TypeofClaim = db.T_ClaimTypes.OrderBy(x => x.DisplayValue).ToList();
		    t_employeeinjury.T_Restrictions_T_TypeOfRestrictions = db.T_Restrictionss.OrderBy(x => x.DisplayValue).ToList();
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_employeeinjury);
			ViewData["T_EmployeeInjuryParentUrl"] = UrlReferrer;
			ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnCreate", true);
			ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnCreate");
            return View(t_employeeinjury);
        }
		// GET: /T_EmployeeInjury/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_EmployeeInjury") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_EmployeeInjury t_employeeinjury = db.T_EmployeeInjurys.Find(id);
            if (t_employeeinjury == null)
            {
                return HttpNotFound();
            }
		    t_employeeinjury.T_ClaimType_T_TypeofClaim = db.T_ClaimTypes.OrderBy(c => c.DisplayValue).ToList();
            t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_ClaimTypeID).ToList();
		    t_employeeinjury.T_Restrictions_T_TypeOfRestrictions = db.T_Restrictionss.OrderBy(c => c.DisplayValue).ToList();
            t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_RestrictionsID).ToList();
		if (UrlReferrer != null)
                ViewData["T_EmployeeInjuryParentUrl"] = UrlReferrer;
		if(ViewData["T_EmployeeInjuryParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeInjury")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeInjury/Edit/" + t_employeeinjury.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeInjury/Create"))
			ViewData["T_EmployeeInjuryParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_employeeinjury);
		   ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", true);
		   ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnEdit");
		    var objT_EmployeeInjury = new List<T_EmployeeInjury>();
            ViewBag.T_EmployeeInjuryDD = new SelectList(objT_EmployeeInjury, "ID", "DisplayValue"); 
          return View(t_employeeinjury);
        }
		// POST: /T_EmployeeInjury/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmployeeInjuryID,T_TypeofClaimMCIID,T_ClaimNo,T_OSHA,T_AccidentShiftID,T_Location,T_FacilityAccidentOccuredID,T_UnitWhereAccidentOccuredID,T_EmployeInjuryFloorID,T_LocationOfAccidentID,T_AccidentDate,T_DescribeHowInjuryOrIllnessOccurred,T_EmployeeInjuryCauseID,T_EmployeeInjuryNatureID,T_EmployeeInjuryBodyPartsAffectedID,T_EMployeeInjuryMachineToolID,T_InitialTreatmentListID,T_PatientInvolvedRegnoepi,T_EmployeeInjuryMedicalFacilityForTreatmentID,T_ExaminingPhysician,T_ReferringPhysician,T_Diagnosis,T_DaysOff,T_DaysRestricted,T_DetailsOfRestriction,T_RestrictionStartDate,T_RestrictionEndDate,T_EmployeeInjuryRefusalID,T_AccidentNotes,T_RestrictionNotes,SelectedT_ClaimType_T_TypeofClaim,SelectedT_Restrictions_T_TypeOfRestrictions")] T_EmployeeInjury t_employeeinjury,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_employeeinjury, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_employeeinjury,out customsave_hasissues,command))
                {
					db.Entry(t_employeeinjury).State = EntityState.Modified;
					db.SaveChanges();
                }
               bool flagT_TypeofClaim = false; 
				var dblistT_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id);
				 if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim != null)
                    dblistT_TypeofClaim = dblistT_TypeofClaim.Where(a => !t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim.Contains(a.T_ClaimTypeID));
                foreach (var obj in dblistT_TypeofClaim)
                {
					 db.T_TypeofClaims.Remove(obj);
					  flagT_TypeofClaim = true; 
				}
				if (flagT_TypeofClaim)
					db.SaveChanges();
				flagT_TypeofClaim = false;
				if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim !=null)
				{
					foreach (var pgs in t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim)
					{
						if (db.T_TypeofClaims.FirstOrDefault(a => a.T_EmployeeInjuryID == t_employeeinjury.Id && a.T_ClaimTypeID == pgs) == null)
                        {
							T_TypeofClaim objT_TypeofClaim = new T_TypeofClaim();
							objT_TypeofClaim.T_EmployeeInjuryID = t_employeeinjury.Id;
							objT_TypeofClaim.T_ClaimTypeID = pgs;
							db.Entry(objT_TypeofClaim).State = EntityState.Added;
							db.T_TypeofClaims.Add(objT_TypeofClaim);
							flagT_TypeofClaim = true;
						}
					}
					if (flagT_TypeofClaim)
						db.SaveChanges();
				 }
               bool flagT_TypeOfRestrictions = false; 
				var dblistT_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id);
				 if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions != null)
                    dblistT_TypeOfRestrictions = dblistT_TypeOfRestrictions.Where(a => !t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions.Contains(a.T_RestrictionsID));
                foreach (var obj in dblistT_TypeOfRestrictions)
                {
					 db.T_TypeOfRestrictionss.Remove(obj);
					  flagT_TypeOfRestrictions = true; 
				}
				if (flagT_TypeOfRestrictions)
					db.SaveChanges();
				flagT_TypeOfRestrictions = false;
				if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions !=null)
				{
					foreach (var pgs in t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions)
					{
						if (db.T_TypeOfRestrictionss.FirstOrDefault(a => a.T_EmployeeInjuryID == t_employeeinjury.Id && a.T_RestrictionsID == pgs) == null)
                        {
							T_TypeOfRestrictions objT_TypeOfRestrictions = new T_TypeOfRestrictions();
							objT_TypeOfRestrictions.T_EmployeeInjuryID = t_employeeinjury.Id;
							objT_TypeOfRestrictions.T_RestrictionsID = pgs;
							db.Entry(objT_TypeOfRestrictions).State = EntityState.Added;
							db.T_TypeOfRestrictionss.Add(objT_TypeOfRestrictions);
							flagT_TypeOfRestrictions = true;
						}
					}
					if (flagT_TypeOfRestrictions)
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
			
			LoadViewDataAfterOnEdit(t_employeeinjury);
			ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", true);
			ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnEdit");
            return View(t_employeeinjury);
        }
        // GET: /T_EmployeeInjury/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_EmployeeInjury") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_EmployeeInjury t_employeeinjury = db.T_EmployeeInjurys.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_EmployeeInjurylist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_EmployeeInjurys.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_EmployeeInjuryDisplayValueEdit = TempData["T_EmployeeInjurylist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_EmployeeInjurylist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_EmployeeInjuryDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_employeeinjury == null)
            {
                return HttpNotFound();
            }
		    t_employeeinjury.T_ClaimType_T_TypeofClaim = db.T_ClaimTypes.OrderBy(c => c.DisplayValue).ToList();
            t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_ClaimTypeID).ToList();
		    t_employeeinjury.T_Restrictions_T_TypeOfRestrictions = db.T_Restrictionss.OrderBy(c => c.DisplayValue).ToList();
            t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_RestrictionsID).ToList();
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeInjury/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_employeeinjury.DisplayValue, Value = t_employeeinjury.Id.ToString() }));
                ViewBag.EntityT_EmployeeInjuryDisplayValueEdit = newList;
				TempData["T_EmployeeInjurylist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_employeeinjury.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_employeeinjury.DisplayValue;
                    newList[0].Value = t_employeeinjury.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_employeeinjury.DisplayValue, Value = t_employeeinjury.Id.ToString() }));
                }
                ViewBag.EntityT_EmployeeInjuryDisplayValueEdit = newList;
				TempData["T_EmployeeInjurylist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_EmployeeInjuryParentUrl"] = UrlReferrer;
		if(ViewData["T_EmployeeInjuryParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeInjury")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeInjury/Edit/" + t_employeeinjury.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeInjury/Create"))
			ViewData["T_EmployeeInjuryParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_employeeinjury);
		   ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", true);
		   ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnEdit");
          return View(t_employeeinjury);
        }
        // POST: /T_EmployeeInjury/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmployeeInjuryID,T_TypeofClaimMCIID,T_ClaimNo,T_OSHA,T_AccidentShiftID,T_Location,T_FacilityAccidentOccuredID,T_UnitWhereAccidentOccuredID,T_EmployeInjuryFloorID,T_LocationOfAccidentID,T_AccidentDate,T_DescribeHowInjuryOrIllnessOccurred,T_EmployeeInjuryCauseID,T_EmployeeInjuryNatureID,T_EmployeeInjuryBodyPartsAffectedID,T_EMployeeInjuryMachineToolID,T_InitialTreatmentListID,T_PatientInvolvedRegnoepi,T_EmployeeInjuryMedicalFacilityForTreatmentID,T_ExaminingPhysician,T_ReferringPhysician,T_Diagnosis,T_DaysOff,T_DaysRestricted,T_DetailsOfRestriction,T_RestrictionStartDate,T_RestrictionEndDate,T_EmployeeInjuryRefusalID,T_AccidentNotes,T_RestrictionNotes,SelectedT_ClaimType_T_TypeofClaim,SelectedT_Restrictions_T_TypeOfRestrictions")] T_EmployeeInjury t_employeeinjury,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_employeeinjury, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_employeeinjury,out customsave_hasissues,command))
            {
				db.Entry(t_employeeinjury).State = EntityState.Modified;
				db.SaveChanges();
            }
               bool flagT_TypeofClaim = false; 
				var dblistT_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id);
				 if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim != null)
                    dblistT_TypeofClaim = dblistT_TypeofClaim.Where(a => !t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim.Contains(a.T_ClaimTypeID));
                foreach (var obj in dblistT_TypeofClaim)
                {
					 db.T_TypeofClaims.Remove(obj);
					  flagT_TypeofClaim = true; 
				}
				if (flagT_TypeofClaim)
					db.SaveChanges();
				flagT_TypeofClaim = false;
				if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim !=null)
				{
					foreach (var pgs in t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim)
					{
						if (db.T_TypeofClaims.FirstOrDefault(a => a.T_EmployeeInjuryID == t_employeeinjury.Id && a.T_ClaimTypeID == pgs) == null)
                        {
							T_TypeofClaim objT_TypeofClaim = new T_TypeofClaim();
							objT_TypeofClaim.T_EmployeeInjuryID = t_employeeinjury.Id;
							objT_TypeofClaim.T_ClaimTypeID = pgs;
							db.Entry(objT_TypeofClaim).State = EntityState.Added;
							db.T_TypeofClaims.Add(objT_TypeofClaim);
							flagT_TypeofClaim = true;
						}
					}
					if (flagT_TypeofClaim)
						db.SaveChanges();
				 }
               bool flagT_TypeOfRestrictions = false; 
				var dblistT_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id);
				 if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions != null)
                    dblistT_TypeOfRestrictions = dblistT_TypeOfRestrictions.Where(a => !t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions.Contains(a.T_RestrictionsID));
                foreach (var obj in dblistT_TypeOfRestrictions)
                {
					 db.T_TypeOfRestrictionss.Remove(obj);
					  flagT_TypeOfRestrictions = true; 
				}
				if (flagT_TypeOfRestrictions)
					db.SaveChanges();
				flagT_TypeOfRestrictions = false;
				if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions !=null)
				{
					foreach (var pgs in t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions)
					{
						if (db.T_TypeOfRestrictionss.FirstOrDefault(a => a.T_EmployeeInjuryID == t_employeeinjury.Id && a.T_RestrictionsID == pgs) == null)
                        {
							T_TypeOfRestrictions objT_TypeOfRestrictions = new T_TypeOfRestrictions();
							objT_TypeOfRestrictions.T_EmployeeInjuryID = t_employeeinjury.Id;
							objT_TypeOfRestrictions.T_RestrictionsID = pgs;
							db.Entry(objT_TypeOfRestrictions).State = EntityState.Added;
							db.T_TypeOfRestrictionss.Add(objT_TypeOfRestrictions);
							flagT_TypeOfRestrictions = true;
						}
					}
					if (flagT_TypeOfRestrictions)
						db.SaveChanges();
				 }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employeeinjury,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_employeeinjury.Id, UrlReferrer = UrlReferrer });
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
		    t_employeeinjury.T_ClaimType_T_TypeofClaim = db.T_ClaimTypes.OrderBy(x => x.DisplayValue).ToList();
            t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_ClaimTypeID).ToList();
		    t_employeeinjury.T_Restrictions_T_TypeOfRestrictions = db.T_Restrictionss.OrderBy(x => x.DisplayValue).ToList();
            t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_RestrictionsID).ToList();
			
			// NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_EmployeeInjurylist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_EmployeeInjurys.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_EmployeeInjuryDisplayValueEdit = TempData["T_EmployeeInjurylist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_EmployeeInjurylist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_EmployeeInjuryDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_employeeinjury);
			 ViewData["T_EmployeeInjuryParentUrl"] = UrlReferrer;
			ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", true);
			ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnEdit");
            return View(t_employeeinjury);
        }
		// GET: /T_EmployeeInjury/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_EmployeeInjury") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_EmployeeInjury t_employeeinjury = db.T_EmployeeInjurys.Find(id);
            if (t_employeeinjury == null)
            {
                return HttpNotFound();
            }
		    t_employeeinjury.T_ClaimType_T_TypeofClaim = db.T_ClaimTypes.OrderBy(c => c.DisplayValue).ToList();
            t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_ClaimTypeID).ToList();
		    t_employeeinjury.T_Restrictions_T_TypeOfRestrictions = db.T_Restrictionss.OrderBy(c => c.DisplayValue).ToList();
            t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_RestrictionsID).ToList();
	
		 if (UrlReferrer != null)
                ViewData["T_EmployeeInjuryParentUrl"] = UrlReferrer;
		if(ViewData["T_EmployeeInjuryParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeInjury"))
			ViewData["T_EmployeeInjuryParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_employeeinjury);
			 ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", true);
			 ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnEdit");
          return View(t_employeeinjury);
        }
        // POST: /T_EmployeeInjury/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmployeeInjuryID,T_TypeofClaimMCIID,T_ClaimNo,T_OSHA,T_AccidentShiftID,T_Location,T_FacilityAccidentOccuredID,T_UnitWhereAccidentOccuredID,T_EmployeInjuryFloorID,T_LocationOfAccidentID,T_AccidentDate,T_DescribeHowInjuryOrIllnessOccurred,T_EmployeeInjuryCauseID,T_EmployeeInjuryNatureID,T_EmployeeInjuryBodyPartsAffectedID,T_EMployeeInjuryMachineToolID,T_InitialTreatmentListID,T_PatientInvolvedRegnoepi,T_EmployeeInjuryMedicalFacilityForTreatmentID,T_ExaminingPhysician,T_ReferringPhysician,T_Diagnosis,T_DaysOff,T_DaysRestricted,T_DetailsOfRestriction,T_RestrictionStartDate,T_RestrictionEndDate,T_EmployeeInjuryRefusalID,T_AccidentNotes,T_RestrictionNotes,SelectedT_ClaimType_T_TypeofClaim,SelectedT_Restrictions_T_TypeOfRestrictions")] T_EmployeeInjury t_employeeinjury,string UrlReferrer)
        {
			CheckBeforeSave(t_employeeinjury);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_employeeinjury,out customsave_hasissues,"Save"))
            {
				db.Entry(t_employeeinjury).State = EntityState.Modified;
				db.SaveChanges();
            }
               bool flagT_TypeofClaim = false; 
				var dblistT_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id);
				 if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim != null)
                    dblistT_TypeofClaim = dblistT_TypeofClaim.Where(a => !t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim.Contains(a.T_ClaimTypeID));
                foreach (var obj in dblistT_TypeofClaim)
                {
					 db.T_TypeofClaims.Remove(obj);
					  flagT_TypeofClaim = true; 
				}
				if (flagT_TypeofClaim)
					db.SaveChanges();
				flagT_TypeofClaim = false;
				if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim !=null)
				{
					foreach (var pgs in t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim)
					{
						if (db.T_TypeofClaims.FirstOrDefault(a => a.T_EmployeeInjuryID == t_employeeinjury.Id && a.T_ClaimTypeID == pgs) == null)
                        {
							T_TypeofClaim objT_TypeofClaim = new T_TypeofClaim();
							objT_TypeofClaim.T_EmployeeInjuryID = t_employeeinjury.Id;
							objT_TypeofClaim.T_ClaimTypeID = pgs;
							db.Entry(objT_TypeofClaim).State = EntityState.Added;
							db.T_TypeofClaims.Add(objT_TypeofClaim);
							flagT_TypeofClaim = true;
						}
					}
					if (flagT_TypeofClaim)
						db.SaveChanges();
				 }
               bool flagT_TypeOfRestrictions = false; 
				var dblistT_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id);
				 if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions != null)
                    dblistT_TypeOfRestrictions = dblistT_TypeOfRestrictions.Where(a => !t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions.Contains(a.T_RestrictionsID));
                foreach (var obj in dblistT_TypeOfRestrictions)
                {
					 db.T_TypeOfRestrictionss.Remove(obj);
					  flagT_TypeOfRestrictions = true; 
				}
				if (flagT_TypeOfRestrictions)
					db.SaveChanges();
				flagT_TypeOfRestrictions = false;
				if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions !=null)
				{
					foreach (var pgs in t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions)
					{
						if (db.T_TypeOfRestrictionss.FirstOrDefault(a => a.T_EmployeeInjuryID == t_employeeinjury.Id && a.T_RestrictionsID == pgs) == null)
                        {
							T_TypeOfRestrictions objT_TypeOfRestrictions = new T_TypeOfRestrictions();
							objT_TypeOfRestrictions.T_EmployeeInjuryID = t_employeeinjury.Id;
							objT_TypeOfRestrictions.T_RestrictionsID = pgs;
							db.Entry(objT_TypeOfRestrictions).State = EntityState.Added;
							db.T_TypeOfRestrictionss.Add(objT_TypeOfRestrictions);
							flagT_TypeOfRestrictions = true;
						}
					}
					if (flagT_TypeOfRestrictions)
						db.SaveChanges();
				 }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employeeinjury,"Edit","");
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
		    t_employeeinjury.T_ClaimType_T_TypeofClaim = db.T_ClaimTypes.OrderBy(c => c.DisplayValue).ToList();
            t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_ClaimTypeID).ToList();
		    t_employeeinjury.T_Restrictions_T_TypeOfRestrictions = db.T_Restrictionss.OrderBy(c => c.DisplayValue).ToList();
            t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_employeeinjury.Id).Select(p => p.T_RestrictionsID).ToList();
			LoadViewDataAfterOnEdit(t_employeeinjury);
			ViewBag.T_EmployeeInjuryIsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", false);
			ViewBag.T_EmployeeInjuryIsGroupsHiddenRule = checkHidden("T_EmployeeInjury", "OnEdit", true);
			ViewBag.T_EmployeeInjuryIsSetValueUIRule = checkSetValueUIRule("T_EmployeeInjury", "OnEdit");
            return View(t_employeeinjury);
        }
        // GET: /T_EmployeeInjury/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_EmployeeInjury") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_EmployeeInjury t_employeeinjury = db.T_EmployeeInjurys.Find(id);
            if (t_employeeinjury == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_EmployeeInjuryParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeInjury"))
			 ViewData["T_EmployeeInjuryParentUrl"] = Request.UrlReferrer;
            return View(t_employeeinjury);
        }
        // POST: /T_EmployeeInjury/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_EmployeeInjury t_employeeinjury, string UrlReferrer)
        {
			if (!User.CanDelete("T_EmployeeInjury"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_employeeinjury))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_employeeinjury, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_employeeinjury).State = EntityState.Deleted;
            db.T_EmployeeInjurys.Remove(t_employeeinjury);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_EmployeeInjuryParentUrl"] != null)
					{
						string parentUrl = ViewData["T_EmployeeInjuryParentUrl"].ToString();
						ViewData["T_EmployeeInjuryParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_employeeinjury);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeEmployeeInjury")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeEmployeeInjuryID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_ClaimTypeMCI" && AssociatedType == "T_TypeofClaimMCI")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_TypeofClaimMCIID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_ShiftTime" && AssociatedType == "T_AccidentShift")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_AccidentShiftID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_AllFacilities" && AssociatedType == "T_FacilityAccidentOccured")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_FacilityAccidentOccuredID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_AllFacilitiesUnit" && AssociatedType == "T_UnitWhereAccidentOccured")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_UnitWhereAccidentOccuredID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_AllFacilitiesFloor" && AssociatedType == "T_EmployeInjuryFloor")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeInjuryFloorID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_WCAccident" && AssociatedType == "T_LocationOfAccident")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_LocationOfAccidentID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_InjuryCause" && AssociatedType == "T_EmployeeInjuryCause")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeInjuryCauseID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_InjuryNature" && AssociatedType == "T_EmployeeInjuryNature")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeInjuryNatureID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_BodyPartsAffected" && AssociatedType == "T_EmployeeInjuryBodyPartsAffected")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeInjuryBodyPartsAffectedID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_MachineTool" && AssociatedType == "T_EMployeeInjuryMachineTool")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EMployeeInjuryMachineToolID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_InitialTreatment" && AssociatedType == "T_InitialTreatmentList")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_InitialTreatmentListID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_MedicalFacilityForTreatment" && AssociatedType == "T_EmployeeInjuryMedicalFacilityForTreatment")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeInjuryMedicalFacilityForTreatmentID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Refusal" && AssociatedType == "T_EmployeeInjuryRefusal")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_EmployeeInjury obj = db.T_EmployeeInjurys.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeInjuryRefusalID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_EmployeeInjury", User) || !User.CanDelete("T_EmployeeInjury")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_EmployeeInjury t_employeeinjury = db.T_EmployeeInjurys.Find(id);
		if (CheckBeforeDelete(t_employeeinjury))
        {
            if (!CustomDelete(t_employeeinjury, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_employeeinjury).State = EntityState.Deleted;
                db.T_EmployeeInjurys.Remove(t_employeeinjury);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_EmployeeInjury", User) || !User.CanEdit("T_EmployeeInjury") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_EmployeeInjuryParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_EmployeeEmployeeInjuryID,T_TypeofClaimMCIID,T_ClaimNo,T_OSHA,T_AccidentShiftID,T_Location,T_FacilityAccidentOccuredID,T_UnitWhereAccidentOccuredID,T_EmployeInjuryFloorID,T_LocationOfAccidentID,T_AccidentDate,T_DescribeHowInjuryOrIllnessOccurred,T_EmployeeInjuryCauseID,T_EmployeeInjuryNatureID,T_EmployeeInjuryBodyPartsAffectedID,T_EMployeeInjuryMachineToolID,T_InitialTreatmentListID,T_PatientInvolvedRegnoepi,T_EmployeeInjuryMedicalFacilityForTreatmentID,T_ExaminingPhysician,T_ReferringPhysician,T_Diagnosis,T_DaysOff,T_DaysRestricted,T_DetailsOfRestriction,T_RestrictionStartDate,T_RestrictionEndDate,T_EmployeeInjuryRefusalID,T_AccidentNotes,T_RestrictionNotes,SelectedT_ClaimType_T_TypeofClaim,SelectedT_Restrictions_T_TypeOfRestrictions")] T_EmployeeInjury t_employeeinjury,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_EmployeeInjury target = db.T_EmployeeInjurys.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_employeeinjury, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_employeeemployeeinjury != null)
							  db.Entry(target.t_employeeemployeeinjury).State = EntityState.Unchanged;
							if (target.t_typeofclaimmci != null)
							  db.Entry(target.t_typeofclaimmci).State = EntityState.Unchanged;
							if (target.t_accidentshift != null)
							  db.Entry(target.t_accidentshift).State = EntityState.Unchanged;
							if (target.t_facilityaccidentoccured != null)
							  db.Entry(target.t_facilityaccidentoccured).State = EntityState.Unchanged;
							if (target.t_unitwhereaccidentoccured != null)
							  db.Entry(target.t_unitwhereaccidentoccured).State = EntityState.Unchanged;
							if (target.t_employeinjuryfloor != null)
							  db.Entry(target.t_employeinjuryfloor).State = EntityState.Unchanged;
							if (target.t_locationofaccident != null)
							  db.Entry(target.t_locationofaccident).State = EntityState.Unchanged;
							if (target.t_employeeinjurycause != null)
							  db.Entry(target.t_employeeinjurycause).State = EntityState.Unchanged;
							if (target.t_employeeinjurynature != null)
							  db.Entry(target.t_employeeinjurynature).State = EntityState.Unchanged;
							if (target.t_employeeinjurybodypartsaffected != null)
							  db.Entry(target.t_employeeinjurybodypartsaffected).State = EntityState.Unchanged;
							if (target.t_employeeinjurymachinetool != null)
							  db.Entry(target.t_employeeinjurymachinetool).State = EntityState.Unchanged;
							if (target.t_initialtreatmentlist != null)
							  db.Entry(target.t_initialtreatmentlist).State = EntityState.Unchanged;
							if (target.t_employeeinjurymedicalfacilityfortreatment != null)
							  db.Entry(target.t_employeeinjurymedicalfacilityfortreatment).State = EntityState.Unchanged;
							if (target.t_employeeinjuryrefusal != null)
							  db.Entry(target.t_employeeinjuryrefusal).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employeeinjury,"BulkUpdate","");
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
