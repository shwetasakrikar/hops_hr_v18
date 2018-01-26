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
    public partial class T_EmployeeController : BaseController
    {
			//private ApplicationDbContext UserContext = new ApplicationDbContext();
			 public ApplicationDbContext UserContext { get { return new ApplicationDbContext(User); } private set{} } 
		
		
        // GET: /T_Employee/
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
			var lstT_Employee = from s in db.T_Employees
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Employee = searchRecords(lstT_Employee, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Employee = sortRecords(lstT_Employee, sortBy, isAsc);
            }
            else lstT_Employee = lstT_Employee.OrderByDescending(c => c.Id);
			lstT_Employee = CustomSorting(lstT_Employee);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Employee"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Employee"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Employee"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Employee"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_Employee = lstT_Employee.Include(t=>t.t_employeeatfacility).Include(t=>t.t_employeestatus).Include(t=>t.t_currentemployeeemploymentprofile).Include(t=>t.t_currentemployeejobassignment).Include(t=>t.t_employeegender).Include(t=>t.t_employeerace).Include(t=>t.t_employeenationalityassociation).Include(t=>t.t_employeeveteranstatus).Include(t=>t.t_employeecardemplgrpassociation).Include(t=>t.t_employeecardlvplanassociation).Include(t=>t.t_employeeaddress).Include(t=>t.t_employeeuserlogin);
		 if (HostingEntity == "T_Facility" && AssociatedType == "T_EmployeeAtFacility")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_EmployeeAtFacilityID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_EmployeeAtFacilityID == null);
         }
		 if (HostingEntity == "T_EmployeeStatusCode" && AssociatedType == "T_EmployeeStatus")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_EmployeeStatusID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_EmployeeStatusID == null);
         }
		 if (HostingEntity == "T_ServiceRecord" && AssociatedType == "T_CurrentEmployeeEmploymentProfile")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_CurrentEmployeeEmploymentProfileID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_CurrentEmployeeEmploymentProfileID == null);
         }
		 if (HostingEntity == "T_JobAssignment" && AssociatedType == "T_CurrentEmployeeJobAssignment")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_CurrentEmployeeJobAssignmentID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_CurrentEmployeeJobAssignmentID == null);
         }
		 if (HostingEntity == "T_Gender" && AssociatedType == "T_EmployeeGender")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_EmployeeGenderID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_EmployeeGenderID == null);
         }
		 if (HostingEntity == "T_Race" && AssociatedType == "T_EmployeeRace")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_EmployeeRaceID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_EmployeeRaceID == null);
         }
		 if (HostingEntity == "T_Nationality" && AssociatedType == "T_EmployeeNationalityAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_EmployeeNationalityAssociationID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_EmployeeNationalityAssociationID == null);
         }
		 if (HostingEntity == "T_VeteranStatus" && AssociatedType == "T_EmployeeVeteranStatus")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_EmployeeVeteranStatusID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_EmployeeVeteranStatusID == null);
         }
		 if (HostingEntity == "T_CardEmplGrp" && AssociatedType == "T_EmployeeCardEmplGrpAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_EmployeeCardEmplGrpAssociationID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_EmployeeCardEmplGrpAssociationID == null);
         }
		 if (HostingEntity == "T_CardLvPlan" && AssociatedType == "T_EmployeeCardLvPlanAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_EmployeeCardLvPlanAssociationID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_EmployeeCardLvPlanAssociationID == null);
         }
		 if (HostingEntity == "T_Address" && AssociatedType == "T_EmployeeAddress")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Employee = _T_Employee.Where(p => p.T_EmployeeAddressID == hostid);
			 }
			 else
			     _T_Employee = _T_Employee.Where(p => p.T_EmployeeAddressID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_Employee", User) || !User.CanView("T_Employee"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_Employee.Count() > 0)
                    pageSize = _T_Employee.Count();
                return View("ExcelExport", _T_Employee.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Employee.Count();
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
					var list = _T_Employee.ToPagedList(pageNumber, pageSize);
					ViewBag.EntityT_EmployeeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
					TempData["T_Employeelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
					return View(list);
				}
				 else
				 {
					if (BulkOperation != null && (BulkOperation == "single" || BulkOperation == "multiple"))
					{
						FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
                        _T_Employee = _fad.FilterDropdown<T_Employee>(User, _T_Employee, "T_Employee", caller);
						return PartialView("BulkOperation", _T_Employee.OrderBy(p=>p.Id).ToPagedList(pageNumber, pageSize)); 
					}
					else
					{
						if (ViewBag.TemplatesName == null)
						{
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_Employee.Count() == 0 ? 1 : _T_Employee.Count();
                            }
							var list = _T_Employee.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_EmployeeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Employeelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
						}
					    else
						{
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_Employee.Count() == 0 ? 1 : _T_Employee.Count();
                            }
							var list = _T_Employee.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_EmployeeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Employeelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
						}
					}
				 }
        }
		 // GET: /T_Employee/Details/5
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
            T_Employee t_employee = db.T_Employees.Find(id);
            if (t_employee == null)
            {
                return HttpNotFound();
            }
		    t_employee.T_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
		    t_employee.T_Langauge_T_LanguageCertifiedIn = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_employee);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_employee, AssociatedType);
            ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnDetails", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnDetails", true);
			ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnDetails");
			return View(ViewBag.TemplatesName,t_employee);
        }
        // GET: /T_Employee/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_Employee") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		    ViewBag.T_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
		    ViewBag.T_Langauge_T_LanguageCertifiedIn = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_EmployeeParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnCreate", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnCreate", true);
		  ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnCreate");
          return View();
        }
		// GET: /T_Employee/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_Employee") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		    ViewBag.T_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_Langauges.OrderBy(x => x.DisplayValue).ToList();
		    ViewBag.T_Langauge_T_LanguageCertifiedIn = db.T_Langauges.OrderBy(x => x.DisplayValue).ToList();
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_EmployeeParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnCreate", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnCreate", true);
			 ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnCreate");
            return View();
        }
		// POST: /T_Employee/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeAtFacilityID,T_PID,T_SSN,T_DateOfBirth,T_EmployeeStatusID,T_SAMAccount,T_LastName,T_FirstName,T_MiddleName,T_Suffix,T_WorkEmail,T_CurrentEmployeeEmploymentProfileID,t_currentemployeeemploymentprofile,T_CurrentEmployeeJobAssignmentID,t_currentemployeejobassignment,T_StateHireDate,T_AdjustedHireDate,T_PriorServiceinmonths,T_CurrentServiceinmonths,T_EmployeeGenderID,T_EmployeeRaceID,T_EmployeeNationalityAssociationID,T_EmployeeVeteranStatusID,T_EmployeeCardEmplGrpAssociationID,T_EmployeeCardLvPlanAssociationID,T_EmployeeAddressID,t_employeeaddress,T_PersonalEmail,T_MobilePhone,T_HomePhone,T_EmployeeUserLoginID,T_EmergencyContactName,T_EmergencyContactRelationship,T_EmergencyMobilePhone,T_EmergencyWorkPhone,T_BadgeNumber,T_EffectiveDateTime,SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage,SelectedT_Langauge_T_LanguageCertifiedIn")] T_Employee t_employee, string UrlReferrer)
        {
			CheckBeforeSave(t_employee);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_employee,out customcreate_hasissues,"Create"))
                {
                    db.T_Employees.Add(t_employee);
					db.SaveChanges();
                }
                bool flagT_ConversationalEmployeeForeignLanguage = false; 
				var dblistT_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id);
				 if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage != null)
                    dblistT_ConversationalEmployeeForeignLanguage = dblistT_ConversationalEmployeeForeignLanguage.Where(a => !t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage.Contains(a.T_LangaugeID));
                foreach (var obj in dblistT_ConversationalEmployeeForeignLanguage)
                {
					 db.T_ConversationalEmployeeForeignLanguages.Remove(obj);
					  flagT_ConversationalEmployeeForeignLanguage = true; 
				}
				if (flagT_ConversationalEmployeeForeignLanguage)
					db.SaveChanges();
				flagT_ConversationalEmployeeForeignLanguage = false;
				if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage !=null)
				{
					foreach (var pgs in t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage)
					{
						if (db.T_ConversationalEmployeeForeignLanguages.FirstOrDefault(a => a.T_EmployeeID == t_employee.Id && a.T_LangaugeID == pgs) == null)
                        {
							T_ConversationalEmployeeForeignLanguage objT_ConversationalEmployeeForeignLanguage = new T_ConversationalEmployeeForeignLanguage();
							objT_ConversationalEmployeeForeignLanguage.T_EmployeeID = t_employee.Id;
							objT_ConversationalEmployeeForeignLanguage.T_LangaugeID = pgs;
							db.Entry(objT_ConversationalEmployeeForeignLanguage).State = EntityState.Added;
							db.T_ConversationalEmployeeForeignLanguages.Add(objT_ConversationalEmployeeForeignLanguage);
							flagT_ConversationalEmployeeForeignLanguage = true;
						}
					}
					if (flagT_ConversationalEmployeeForeignLanguage)
						db.SaveChanges();
				 }
                bool flagT_LanguageCertifiedIn = false; 
				var dblistT_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id);
				 if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn != null)
                    dblistT_LanguageCertifiedIn = dblistT_LanguageCertifiedIn.Where(a => !t_employee.SelectedT_Langauge_T_LanguageCertifiedIn.Contains(a.T_LangaugeID));
                foreach (var obj in dblistT_LanguageCertifiedIn)
                {
					 db.T_LanguageCertifiedIns.Remove(obj);
					  flagT_LanguageCertifiedIn = true; 
				}
				if (flagT_LanguageCertifiedIn)
					db.SaveChanges();
				flagT_LanguageCertifiedIn = false;
				if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn !=null)
				{
					foreach (var pgs in t_employee.SelectedT_Langauge_T_LanguageCertifiedIn)
					{
						if (db.T_LanguageCertifiedIns.FirstOrDefault(a => a.T_EmployeeID == t_employee.Id && a.T_LangaugeID == pgs) == null)
                        {
							T_LanguageCertifiedIn objT_LanguageCertifiedIn = new T_LanguageCertifiedIn();
							objT_LanguageCertifiedIn.T_EmployeeID = t_employee.Id;
							objT_LanguageCertifiedIn.T_LangaugeID = pgs;
							db.Entry(objT_LanguageCertifiedIn).State = EntityState.Added;
							db.T_LanguageCertifiedIns.Add(objT_LanguageCertifiedIn);
							flagT_LanguageCertifiedIn = true;
						}
					}
					if (flagT_LanguageCertifiedIn)
						db.SaveChanges();
				 }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employee,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
		    t_employee.T_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_Langauges.OrderBy(x => x.DisplayValue).ToList();
		    t_employee.T_Langauge_T_LanguageCertifiedIn = db.T_Langauges.OrderBy(x => x.DisplayValue).ToList();
	
			LoadViewDataAfterOnCreate(t_employee);
			ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnCreate", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnCreate", true);
			ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnCreate");	
            return View(t_employee);
        }
		 // GET: /T_Employee/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_Employee") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_EmployeeParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnCreate", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnCreate", true);
			ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnCreate");
            return View();
        }
		  // POST: /T_Employee/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeAtFacilityID,T_PID,T_DateOfBirth,T_EmployeeStatusID,T_LastName,T_FirstName,T_MiddleName,T_WorkEmail,T_CurrentEmployeeEmploymentProfileID,t_currentemployeeemploymentprofile,T_CurrentEmployeeJobAssignmentID,t_currentemployeejobassignment,T_EmployeeGenderID,T_EmployeeRaceID,T_EmployeeNationalityAssociationID,T_EmployeeVeteranStatusID,T_EmployeeCardEmplGrpAssociationID,T_EmployeeCardLvPlanAssociationID,T_EmployeeAddressID,T_EmployeeUserLoginID")] T_Employee t_employee,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_employee);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_employee,out customcreate_hasissues,"Create"))
                {
                    db.T_Employees.Add(t_employee);
					db.SaveChanges();
                }
				if (HostingEntityName == "T_Langauge" && AssociatedEntity == "T_ConversationalEmployeeForeignLanguage_T_Langauge")
                {
                    long hostingentityid;
                    if(Int64.TryParse(HostingEntityID,out hostingentityid) && hostingentityid >0)
                    {
                        db.T_ConversationalEmployeeForeignLanguages.Add(new T_ConversationalEmployeeForeignLanguage { T_LangaugeID = hostingentityid, T_EmployeeID = t_employee.Id });
                        db.SaveChanges();
                    }
                }
				if (HostingEntityName == "T_Langauge" && AssociatedEntity == "T_LanguageCertifiedIn_T_Langauge")
                {
                    long hostingentityid;
                    if(Int64.TryParse(HostingEntityID,out hostingentityid) && hostingentityid >0)
                    {
                        db.T_LanguageCertifiedIns.Add(new T_LanguageCertifiedIn { T_LangaugeID = hostingentityid, T_EmployeeID = t_employee.Id });
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
			LoadViewDataAfterOnCreate(t_employee);
			ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnCreate", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnCreate", true);
			ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_employee, AssociatedEntity);
			return View(t_employee);
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
        // POST: /T_Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_EmployeeAtFacilityID,T_PID,T_SSN,T_DateOfBirth,T_EmployeeStatusID,T_SAMAccount,T_LastName,T_FirstName,T_MiddleName,T_Suffix,T_WorkEmail,T_CurrentEmployeeEmploymentProfileID,t_currentemployeeemploymentprofile,T_CurrentEmployeeJobAssignmentID,t_currentemployeejobassignment,T_StateHireDate,T_AdjustedHireDate,T_PriorServiceinmonths,T_CurrentServiceinmonths,T_EmployeeGenderID,T_EmployeeRaceID,T_EmployeeNationalityAssociationID,T_EmployeeVeteranStatusID,T_EmployeeCardEmplGrpAssociationID,T_EmployeeCardLvPlanAssociationID,T_EmployeeAddressID,t_employeeaddress,T_PersonalEmail,T_MobilePhone,T_HomePhone,T_EmployeeUserLoginID,T_EmergencyContactName,T_EmergencyContactRelationship,T_EmergencyMobilePhone,T_EmergencyWorkPhone,T_BadgeNumber,T_EffectiveDateTime,SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage,SelectedT_Langauge_T_LanguageCertifiedIn")] T_Employee t_employee, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_employee, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_employee,out customcreate_hasissues,command))
                {
                    db.T_Employees.Add(t_employee);
					db.SaveChanges();
                }
				bool flagT_ConversationalEmployeeForeignLanguage = false; 
				var dblistT_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id);
				 if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage != null)
                    dblistT_ConversationalEmployeeForeignLanguage = dblistT_ConversationalEmployeeForeignLanguage.Where(a => !t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage.Contains(a.T_LangaugeID));
                foreach (var obj in dblistT_ConversationalEmployeeForeignLanguage)
                {
					 db.T_ConversationalEmployeeForeignLanguages.Remove(obj);
					  flagT_ConversationalEmployeeForeignLanguage = true; 
				}
				if (flagT_ConversationalEmployeeForeignLanguage)
					db.SaveChanges();
				flagT_ConversationalEmployeeForeignLanguage = false;
				if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage !=null)
				{
					foreach (var pgs in t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage)
					{
						if (db.T_ConversationalEmployeeForeignLanguages.FirstOrDefault(a => a.T_EmployeeID == t_employee.Id && a.T_LangaugeID == pgs) == null)
                        {
							T_ConversationalEmployeeForeignLanguage objT_ConversationalEmployeeForeignLanguage = new T_ConversationalEmployeeForeignLanguage();
							objT_ConversationalEmployeeForeignLanguage.T_EmployeeID = t_employee.Id;
							objT_ConversationalEmployeeForeignLanguage.T_LangaugeID = pgs;
							db.Entry(objT_ConversationalEmployeeForeignLanguage).State = EntityState.Added;
							db.T_ConversationalEmployeeForeignLanguages.Add(objT_ConversationalEmployeeForeignLanguage);
							flagT_ConversationalEmployeeForeignLanguage = true;
						}
					}
					if (flagT_ConversationalEmployeeForeignLanguage)
						db.SaveChanges();
				 }
				bool flagT_LanguageCertifiedIn = false; 
				var dblistT_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id);
				 if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn != null)
                    dblistT_LanguageCertifiedIn = dblistT_LanguageCertifiedIn.Where(a => !t_employee.SelectedT_Langauge_T_LanguageCertifiedIn.Contains(a.T_LangaugeID));
                foreach (var obj in dblistT_LanguageCertifiedIn)
                {
					 db.T_LanguageCertifiedIns.Remove(obj);
					  flagT_LanguageCertifiedIn = true; 
				}
				if (flagT_LanguageCertifiedIn)
					db.SaveChanges();
				flagT_LanguageCertifiedIn = false;
				if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn !=null)
				{
					foreach (var pgs in t_employee.SelectedT_Langauge_T_LanguageCertifiedIn)
					{
						if (db.T_LanguageCertifiedIns.FirstOrDefault(a => a.T_EmployeeID == t_employee.Id && a.T_LangaugeID == pgs) == null)
                        {
							T_LanguageCertifiedIn objT_LanguageCertifiedIn = new T_LanguageCertifiedIn();
							objT_LanguageCertifiedIn.T_EmployeeID = t_employee.Id;
							objT_LanguageCertifiedIn.T_LangaugeID = pgs;
							db.Entry(objT_LanguageCertifiedIn).State = EntityState.Added;
							db.T_LanguageCertifiedIns.Add(objT_LanguageCertifiedIn);
							flagT_LanguageCertifiedIn = true;
						}
					}
					if (flagT_LanguageCertifiedIn)
						db.SaveChanges();
				 }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employee,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_employee.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
		    t_employee.T_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_Langauges.OrderBy(x => x.DisplayValue).ToList();
		    t_employee.T_Langauge_T_LanguageCertifiedIn = db.T_Langauges.OrderBy(x => x.DisplayValue).ToList();
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_employee);
			ViewData["T_EmployeeParentUrl"] = UrlReferrer;
			ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnCreate", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnCreate", true);
			ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnCreate");
            return View(t_employee);
        }
		// GET: /T_Employee/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Employee") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_Employee t_employee = db.T_Employees.Find(id);
            if (t_employee == null)
            {
                return HttpNotFound();
            }
		    t_employee.T_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
		    t_employee.T_Langauge_T_LanguageCertifiedIn = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
		if (UrlReferrer != null)
                ViewData["T_EmployeeParentUrl"] = UrlReferrer;
		if(ViewData["T_EmployeeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Employee")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Employee/Edit/" + t_employee.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Employee/Create"))
			ViewData["T_EmployeeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_employee);
		   ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnEdit", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnEdit", true);
		   ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnEdit");
		    var objT_Employee = new List<T_Employee>();
            ViewBag.T_EmployeeDD = new SelectList(objT_Employee, "ID", "DisplayValue"); 
          return View(t_employee);
        }
		// POST: /T_Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeAtFacilityID,T_PID,T_SSN,T_DateOfBirth,T_EmployeeStatusID,T_SAMAccount,T_LastName,T_FirstName,T_MiddleName,T_Suffix,T_WorkEmail,T_CurrentEmployeeEmploymentProfileID,t_currentemployeeemploymentprofile,T_CurrentEmployeeJobAssignmentID,t_currentemployeejobassignment,T_StateHireDate,T_AdjustedHireDate,T_PriorServiceinmonths,T_CurrentServiceinmonths,T_EmployeeGenderID,T_EmployeeRaceID,T_EmployeeNationalityAssociationID,T_EmployeeVeteranStatusID,T_EmployeeCardEmplGrpAssociationID,T_EmployeeCardLvPlanAssociationID,T_EmployeeAddressID,t_employeeaddress,T_PersonalEmail,T_MobilePhone,T_HomePhone,T_EmployeeUserLoginID,T_EmergencyContactName,T_EmergencyContactRelationship,T_EmergencyMobilePhone,T_EmergencyWorkPhone,T_BadgeNumber,T_EffectiveDateTime,SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage,SelectedT_Langauge_T_LanguageCertifiedIn")] T_Employee t_employee,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_employee, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_employee,out customsave_hasissues,command))
                {
					db.Entry(t_employee).State = EntityState.Modified;
			 if(t_employee.t_currentemployeeemploymentprofile != null && t_employee.t_currentemployeeemploymentprofile.Id == 0)
                   db.Entry(t_employee.t_currentemployeeemploymentprofile).State = EntityState.Added;
             else if(t_employee.t_currentemployeeemploymentprofile != null && t_employee.t_currentemployeeemploymentprofile.Id > 0)
                  db.Entry(t_employee.t_currentemployeeemploymentprofile).State = EntityState.Modified;
			 if(t_employee.t_currentemployeejobassignment != null && t_employee.t_currentemployeejobassignment.Id == 0)
                   db.Entry(t_employee.t_currentemployeejobassignment).State = EntityState.Added;
             else if(t_employee.t_currentemployeejobassignment != null && t_employee.t_currentemployeejobassignment.Id > 0)
                  db.Entry(t_employee.t_currentemployeejobassignment).State = EntityState.Modified;
			 if(t_employee.t_employeeaddress != null && t_employee.t_employeeaddress.Id == 0)
                   db.Entry(t_employee.t_employeeaddress).State = EntityState.Added;
             else if(t_employee.t_employeeaddress != null && t_employee.t_employeeaddress.Id > 0)
                  db.Entry(t_employee.t_employeeaddress).State = EntityState.Modified;
					db.SaveChanges();
                }
               bool flagT_ConversationalEmployeeForeignLanguage = false; 
				var dblistT_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id);
				 if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage != null)
                    dblistT_ConversationalEmployeeForeignLanguage = dblistT_ConversationalEmployeeForeignLanguage.Where(a => !t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage.Contains(a.T_LangaugeID));
                foreach (var obj in dblistT_ConversationalEmployeeForeignLanguage)
                {
					 db.T_ConversationalEmployeeForeignLanguages.Remove(obj);
					  flagT_ConversationalEmployeeForeignLanguage = true; 
				}
				if (flagT_ConversationalEmployeeForeignLanguage)
					db.SaveChanges();
				flagT_ConversationalEmployeeForeignLanguage = false;
				if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage !=null)
				{
					foreach (var pgs in t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage)
					{
						if (db.T_ConversationalEmployeeForeignLanguages.FirstOrDefault(a => a.T_EmployeeID == t_employee.Id && a.T_LangaugeID == pgs) == null)
                        {
							T_ConversationalEmployeeForeignLanguage objT_ConversationalEmployeeForeignLanguage = new T_ConversationalEmployeeForeignLanguage();
							objT_ConversationalEmployeeForeignLanguage.T_EmployeeID = t_employee.Id;
							objT_ConversationalEmployeeForeignLanguage.T_LangaugeID = pgs;
							db.Entry(objT_ConversationalEmployeeForeignLanguage).State = EntityState.Added;
							db.T_ConversationalEmployeeForeignLanguages.Add(objT_ConversationalEmployeeForeignLanguage);
							flagT_ConversationalEmployeeForeignLanguage = true;
						}
					}
					if (flagT_ConversationalEmployeeForeignLanguage)
						db.SaveChanges();
				 }
               bool flagT_LanguageCertifiedIn = false; 
				var dblistT_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id);
				 if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn != null)
                    dblistT_LanguageCertifiedIn = dblistT_LanguageCertifiedIn.Where(a => !t_employee.SelectedT_Langauge_T_LanguageCertifiedIn.Contains(a.T_LangaugeID));
                foreach (var obj in dblistT_LanguageCertifiedIn)
                {
					 db.T_LanguageCertifiedIns.Remove(obj);
					  flagT_LanguageCertifiedIn = true; 
				}
				if (flagT_LanguageCertifiedIn)
					db.SaveChanges();
				flagT_LanguageCertifiedIn = false;
				if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn !=null)
				{
					foreach (var pgs in t_employee.SelectedT_Langauge_T_LanguageCertifiedIn)
					{
						if (db.T_LanguageCertifiedIns.FirstOrDefault(a => a.T_EmployeeID == t_employee.Id && a.T_LangaugeID == pgs) == null)
                        {
							T_LanguageCertifiedIn objT_LanguageCertifiedIn = new T_LanguageCertifiedIn();
							objT_LanguageCertifiedIn.T_EmployeeID = t_employee.Id;
							objT_LanguageCertifiedIn.T_LangaugeID = pgs;
							db.Entry(objT_LanguageCertifiedIn).State = EntityState.Added;
							db.T_LanguageCertifiedIns.Add(objT_LanguageCertifiedIn);
							flagT_LanguageCertifiedIn = true;
						}
					}
					if (flagT_LanguageCertifiedIn)
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
			
			LoadViewDataAfterOnEdit(t_employee);
			ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnEdit", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnEdit", true);
			ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnEdit");
            return View(t_employee);
        }
        // GET: /T_Employee/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_Employee") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Employee t_employee = db.T_Employees.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Employeelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Employees.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_EmployeeDisplayValueEdit = TempData["T_Employeelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Employeelist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_EmployeeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_employee == null)
            {
                return HttpNotFound();
            }
		    t_employee.T_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
		    t_employee.T_Langauge_T_LanguageCertifiedIn = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_Employee/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_employee.DisplayValue, Value = t_employee.Id.ToString() }));
                ViewBag.EntityT_EmployeeDisplayValueEdit = newList;
				TempData["T_Employeelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_employee.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_employee.DisplayValue;
                    newList[0].Value = t_employee.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_employee.DisplayValue, Value = t_employee.Id.ToString() }));
                }
                ViewBag.EntityT_EmployeeDisplayValueEdit = newList;
				TempData["T_Employeelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_EmployeeParentUrl"] = UrlReferrer;
		if(ViewData["T_EmployeeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Employee")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Employee/Edit/" + t_employee.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Employee/Create"))
			ViewData["T_EmployeeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_employee);
		   ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnEdit", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnEdit", true);
		   ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnEdit");
          return View(t_employee);
        }
        // POST: /T_Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_EmployeeAtFacilityID,T_PID,T_SSN,T_DateOfBirth,T_EmployeeStatusID,T_SAMAccount,T_LastName,T_FirstName,T_MiddleName,T_Suffix,T_WorkEmail,T_CurrentEmployeeEmploymentProfileID,t_currentemployeeemploymentprofile,T_CurrentEmployeeJobAssignmentID,t_currentemployeejobassignment,T_StateHireDate,T_AdjustedHireDate,T_PriorServiceinmonths,T_CurrentServiceinmonths,T_EmployeeGenderID,T_EmployeeRaceID,T_EmployeeNationalityAssociationID,T_EmployeeVeteranStatusID,T_EmployeeCardEmplGrpAssociationID,T_EmployeeCardLvPlanAssociationID,T_EmployeeAddressID,t_employeeaddress,T_PersonalEmail,T_MobilePhone,T_HomePhone,T_EmployeeUserLoginID,T_EmergencyContactName,T_EmergencyContactRelationship,T_EmergencyMobilePhone,T_EmergencyWorkPhone,T_BadgeNumber,T_EffectiveDateTime,SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage,SelectedT_Langauge_T_LanguageCertifiedIn")] T_Employee t_employee,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_employee, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_employee,out customsave_hasissues,command))
            {
				db.Entry(t_employee).State = EntityState.Modified;
			 if(t_employee.t_currentemployeeemploymentprofile != null && t_employee.t_currentemployeeemploymentprofile.Id == 0)
                   db.Entry(t_employee.t_currentemployeeemploymentprofile).State = EntityState.Added;
             else if(t_employee.t_currentemployeeemploymentprofile != null && t_employee.t_currentemployeeemploymentprofile.Id > 0)
                  db.Entry(t_employee.t_currentemployeeemploymentprofile).State = EntityState.Modified;
			 if(t_employee.t_currentemployeejobassignment != null && t_employee.t_currentemployeejobassignment.Id == 0)
                   db.Entry(t_employee.t_currentemployeejobassignment).State = EntityState.Added;
             else if(t_employee.t_currentemployeejobassignment != null && t_employee.t_currentemployeejobassignment.Id > 0)
                  db.Entry(t_employee.t_currentemployeejobassignment).State = EntityState.Modified;
			 if(t_employee.t_employeeaddress != null && t_employee.t_employeeaddress.Id == 0)
                   db.Entry(t_employee.t_employeeaddress).State = EntityState.Added;
             else if(t_employee.t_employeeaddress != null && t_employee.t_employeeaddress.Id > 0)
                  db.Entry(t_employee.t_employeeaddress).State = EntityState.Modified;
				db.SaveChanges();
            }
               bool flagT_ConversationalEmployeeForeignLanguage = false; 
				var dblistT_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id);
				 if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage != null)
                    dblistT_ConversationalEmployeeForeignLanguage = dblistT_ConversationalEmployeeForeignLanguage.Where(a => !t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage.Contains(a.T_LangaugeID));
                foreach (var obj in dblistT_ConversationalEmployeeForeignLanguage)
                {
					 db.T_ConversationalEmployeeForeignLanguages.Remove(obj);
					  flagT_ConversationalEmployeeForeignLanguage = true; 
				}
				if (flagT_ConversationalEmployeeForeignLanguage)
					db.SaveChanges();
				flagT_ConversationalEmployeeForeignLanguage = false;
				if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage !=null)
				{
					foreach (var pgs in t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage)
					{
						if (db.T_ConversationalEmployeeForeignLanguages.FirstOrDefault(a => a.T_EmployeeID == t_employee.Id && a.T_LangaugeID == pgs) == null)
                        {
							T_ConversationalEmployeeForeignLanguage objT_ConversationalEmployeeForeignLanguage = new T_ConversationalEmployeeForeignLanguage();
							objT_ConversationalEmployeeForeignLanguage.T_EmployeeID = t_employee.Id;
							objT_ConversationalEmployeeForeignLanguage.T_LangaugeID = pgs;
							db.Entry(objT_ConversationalEmployeeForeignLanguage).State = EntityState.Added;
							db.T_ConversationalEmployeeForeignLanguages.Add(objT_ConversationalEmployeeForeignLanguage);
							flagT_ConversationalEmployeeForeignLanguage = true;
						}
					}
					if (flagT_ConversationalEmployeeForeignLanguage)
						db.SaveChanges();
				 }
               bool flagT_LanguageCertifiedIn = false; 
				var dblistT_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id);
				 if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn != null)
                    dblistT_LanguageCertifiedIn = dblistT_LanguageCertifiedIn.Where(a => !t_employee.SelectedT_Langauge_T_LanguageCertifiedIn.Contains(a.T_LangaugeID));
                foreach (var obj in dblistT_LanguageCertifiedIn)
                {
					 db.T_LanguageCertifiedIns.Remove(obj);
					  flagT_LanguageCertifiedIn = true; 
				}
				if (flagT_LanguageCertifiedIn)
					db.SaveChanges();
				flagT_LanguageCertifiedIn = false;
				if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn !=null)
				{
					foreach (var pgs in t_employee.SelectedT_Langauge_T_LanguageCertifiedIn)
					{
						if (db.T_LanguageCertifiedIns.FirstOrDefault(a => a.T_EmployeeID == t_employee.Id && a.T_LangaugeID == pgs) == null)
                        {
							T_LanguageCertifiedIn objT_LanguageCertifiedIn = new T_LanguageCertifiedIn();
							objT_LanguageCertifiedIn.T_EmployeeID = t_employee.Id;
							objT_LanguageCertifiedIn.T_LangaugeID = pgs;
							db.Entry(objT_LanguageCertifiedIn).State = EntityState.Added;
							db.T_LanguageCertifiedIns.Add(objT_LanguageCertifiedIn);
							flagT_LanguageCertifiedIn = true;
						}
					}
					if (flagT_LanguageCertifiedIn)
						db.SaveChanges();
				 }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employee,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_employee.Id, UrlReferrer = UrlReferrer });
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
		    t_employee.T_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_Langauges.OrderBy(x => x.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
		    t_employee.T_Langauge_T_LanguageCertifiedIn = db.T_Langauges.OrderBy(x => x.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
			
			// NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Employeelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Employees.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_EmployeeDisplayValueEdit = TempData["T_Employeelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Employeelist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_EmployeeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_employee);
			 ViewData["T_EmployeeParentUrl"] = UrlReferrer;
			ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnEdit", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnEdit", true);
			ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnEdit");
            return View(t_employee);
        }
		// GET: /T_Employee/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Employee") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_Employee t_employee = db.T_Employees.Find(id);
            if (t_employee == null)
            {
                return HttpNotFound();
            }
		    t_employee.T_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
		    t_employee.T_Langauge_T_LanguageCertifiedIn = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
	
		 if (UrlReferrer != null)
                ViewData["T_EmployeeParentUrl"] = UrlReferrer;
		if(ViewData["T_EmployeeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Employee"))
			ViewData["T_EmployeeParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_employee);
			 ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnEdit", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnEdit", true);
			 ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnEdit");
          return View(t_employee);
        }
        // POST: /T_Employee/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeAtFacilityID,T_PID,T_SSN,T_DateOfBirth,T_EmployeeStatusID,T_SAMAccount,T_LastName,T_FirstName,T_MiddleName,T_Suffix,T_WorkEmail,T_CurrentEmployeeEmploymentProfileID,t_currentemployeeemploymentprofile,T_CurrentEmployeeJobAssignmentID,t_currentemployeejobassignment,T_StateHireDate,T_AdjustedHireDate,T_PriorServiceinmonths,T_CurrentServiceinmonths,T_EmployeeGenderID,T_EmployeeRaceID,T_EmployeeNationalityAssociationID,T_EmployeeVeteranStatusID,T_EmployeeCardEmplGrpAssociationID,T_EmployeeCardLvPlanAssociationID,T_EmployeeAddressID,t_employeeaddress,T_PersonalEmail,T_MobilePhone,T_HomePhone,T_EmployeeUserLoginID,T_EmergencyContactName,T_EmergencyContactRelationship,T_EmergencyMobilePhone,T_EmergencyWorkPhone,T_BadgeNumber,T_EffectiveDateTime,SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage,SelectedT_Langauge_T_LanguageCertifiedIn")] T_Employee t_employee,string UrlReferrer)
        {
			CheckBeforeSave(t_employee);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_employee,out customsave_hasissues,"Save"))
            {
				db.Entry(t_employee).State = EntityState.Modified;
			 if(t_employee.t_currentemployeeemploymentprofile !=null && t_employee.t_currentemployeeemploymentprofile.Id == 0)
                   db.Entry(t_employee.t_currentemployeeemploymentprofile).State = EntityState.Added;
             else if(t_employee.t_currentemployeeemploymentprofile !=null && t_employee.t_currentemployeeemploymentprofile.Id > 0)
                  db.Entry(t_employee.t_currentemployeeemploymentprofile).State = EntityState.Modified;
			 if(t_employee.t_currentemployeejobassignment !=null && t_employee.t_currentemployeejobassignment.Id == 0)
                   db.Entry(t_employee.t_currentemployeejobassignment).State = EntityState.Added;
             else if(t_employee.t_currentemployeejobassignment !=null && t_employee.t_currentemployeejobassignment.Id > 0)
                  db.Entry(t_employee.t_currentemployeejobassignment).State = EntityState.Modified;
			 if(t_employee.t_employeeaddress !=null && t_employee.t_employeeaddress.Id == 0)
                   db.Entry(t_employee.t_employeeaddress).State = EntityState.Added;
             else if(t_employee.t_employeeaddress !=null && t_employee.t_employeeaddress.Id > 0)
                  db.Entry(t_employee.t_employeeaddress).State = EntityState.Modified;
				db.SaveChanges();
            }
               bool flagT_ConversationalEmployeeForeignLanguage = false; 
				var dblistT_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id);
				 if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage != null)
                    dblistT_ConversationalEmployeeForeignLanguage = dblistT_ConversationalEmployeeForeignLanguage.Where(a => !t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage.Contains(a.T_LangaugeID));
                foreach (var obj in dblistT_ConversationalEmployeeForeignLanguage)
                {
					 db.T_ConversationalEmployeeForeignLanguages.Remove(obj);
					  flagT_ConversationalEmployeeForeignLanguage = true; 
				}
				if (flagT_ConversationalEmployeeForeignLanguage)
					db.SaveChanges();
				flagT_ConversationalEmployeeForeignLanguage = false;
				if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage !=null)
				{
					foreach (var pgs in t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage)
					{
						if (db.T_ConversationalEmployeeForeignLanguages.FirstOrDefault(a => a.T_EmployeeID == t_employee.Id && a.T_LangaugeID == pgs) == null)
                        {
							T_ConversationalEmployeeForeignLanguage objT_ConversationalEmployeeForeignLanguage = new T_ConversationalEmployeeForeignLanguage();
							objT_ConversationalEmployeeForeignLanguage.T_EmployeeID = t_employee.Id;
							objT_ConversationalEmployeeForeignLanguage.T_LangaugeID = pgs;
							db.Entry(objT_ConversationalEmployeeForeignLanguage).State = EntityState.Added;
							db.T_ConversationalEmployeeForeignLanguages.Add(objT_ConversationalEmployeeForeignLanguage);
							flagT_ConversationalEmployeeForeignLanguage = true;
						}
					}
					if (flagT_ConversationalEmployeeForeignLanguage)
						db.SaveChanges();
				 }
               bool flagT_LanguageCertifiedIn = false; 
				var dblistT_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id);
				 if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn != null)
                    dblistT_LanguageCertifiedIn = dblistT_LanguageCertifiedIn.Where(a => !t_employee.SelectedT_Langauge_T_LanguageCertifiedIn.Contains(a.T_LangaugeID));
                foreach (var obj in dblistT_LanguageCertifiedIn)
                {
					 db.T_LanguageCertifiedIns.Remove(obj);
					  flagT_LanguageCertifiedIn = true; 
				}
				if (flagT_LanguageCertifiedIn)
					db.SaveChanges();
				flagT_LanguageCertifiedIn = false;
				if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn !=null)
				{
					foreach (var pgs in t_employee.SelectedT_Langauge_T_LanguageCertifiedIn)
					{
						if (db.T_LanguageCertifiedIns.FirstOrDefault(a => a.T_EmployeeID == t_employee.Id && a.T_LangaugeID == pgs) == null)
                        {
							T_LanguageCertifiedIn objT_LanguageCertifiedIn = new T_LanguageCertifiedIn();
							objT_LanguageCertifiedIn.T_EmployeeID = t_employee.Id;
							objT_LanguageCertifiedIn.T_LangaugeID = pgs;
							db.Entry(objT_LanguageCertifiedIn).State = EntityState.Added;
							db.T_LanguageCertifiedIns.Add(objT_LanguageCertifiedIn);
							flagT_LanguageCertifiedIn = true;
						}
					}
					if (flagT_LanguageCertifiedIn)
						db.SaveChanges();
				 }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employee,"Edit","");
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
		    t_employee.T_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = db.T_ConversationalEmployeeForeignLanguages.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
		    t_employee.T_Langauge_T_LanguageCertifiedIn = db.T_Langauges.OrderBy(c => c.DisplayValue).ToList();
            t_employee.SelectedT_Langauge_T_LanguageCertifiedIn = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_employee.Id).Select(p => p.T_LangaugeID).ToList();
			LoadViewDataAfterOnEdit(t_employee);
			ViewBag.T_EmployeeIsHiddenRule = checkHidden("T_Employee", "OnEdit", false);
			ViewBag.T_EmployeeIsGroupsHiddenRule = checkHidden("T_Employee", "OnEdit", true);
			ViewBag.T_EmployeeIsSetValueUIRule = checkSetValueUIRule("T_Employee", "OnEdit");
            return View(t_employee);
        }
        // GET: /T_Employee/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_Employee") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_Employee t_employee = db.T_Employees.Find(id);
            if (t_employee == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_EmployeeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Employee"))
			 ViewData["T_EmployeeParentUrl"] = Request.UrlReferrer;
            return View(t_employee);
        }
        // POST: /T_Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_Employee t_employee, string UrlReferrer)
        {
			if (!User.CanDelete("T_Employee"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_employee))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_employee, out customdelete_hasissues, "Delete"))
                {
            var listT_LicenseRecords = db.T_Licensess.Where(p => p.T_LicenseRecordsID == t_employee.Id);
            foreach (var lst in listT_LicenseRecords)
               db.T_Licensess.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeEmployeeInjury = db.T_EmployeeInjurys.Where(p => p.T_EmployeeEmployeeInjuryID == t_employee.Id);
            foreach (var lst in listT_EmployeeEmployeeInjury)
               db.T_EmployeeInjurys.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeCriminalBackgroundCheck = db.T_BackgroundChecks.Where(p => p.T_EmployeeCriminalBackgroundCheckID == t_employee.Id);
            foreach (var lst in listT_EmployeeCriminalBackgroundCheck)
               db.T_BackgroundChecks.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeAccomodation = db.T_Accommodations.Where(p => p.T_EmployeeAccomodationID == t_employee.Id);
            foreach (var lst in listT_EmployeeAccomodation)
               db.T_Accommodations.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeEmploymentProfile = db.T_ServiceRecords.Where(p => p.T_EmployeeEmploymentProfileID == t_employee.Id);
            foreach (var lst in listT_EmployeeEmploymentProfile)
               db.T_ServiceRecords.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeJobAssignment = db.T_JobAssignments.Where(p => p.T_EmployeeJobAssignmentID == t_employee.Id);
            foreach (var lst in listT_EmployeeJobAssignment)
               db.T_JobAssignments.Remove(lst);
           db.SaveChanges();
            var listT_EmployeePayDetails = db.T_PayDetailss.Where(p => p.T_EmployeePayDetailsID == t_employee.Id);
            foreach (var lst in listT_EmployeePayDetails)
               db.T_PayDetailss.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeDrugAlcoholTest = db.T_DrugAlcoholTests.Where(p => p.T_EmployeeDrugAlcoholTestID == t_employee.Id);
            foreach (var lst in listT_EmployeeDrugAlcoholTest)
               db.T_DrugAlcoholTests.Remove(lst);
           db.SaveChanges();
			db.Entry(t_employee).State = EntityState.Deleted;
            db.T_Employees.Remove(t_employee);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_EmployeeParentUrl"] != null)
					{
						string parentUrl = ViewData["T_EmployeeParentUrl"].ToString();
						ViewData["T_EmployeeParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_employee);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Facility" && AssociatedType == "T_EmployeeAtFacility")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeAtFacilityID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_EmployeeStatusCode" && AssociatedType == "T_EmployeeStatus")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeStatusID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_ServiceRecord" && AssociatedType == "T_CurrentEmployeeEmploymentProfile")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_CurrentEmployeeEmploymentProfileID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_JobAssignment" && AssociatedType == "T_CurrentEmployeeJobAssignment")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_CurrentEmployeeJobAssignmentID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Gender" && AssociatedType == "T_EmployeeGender")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeGenderID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Race" && AssociatedType == "T_EmployeeRace")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeRaceID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Nationality" && AssociatedType == "T_EmployeeNationalityAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeNationalityAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_VeteranStatus" && AssociatedType == "T_EmployeeVeteranStatus")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeVeteranStatusID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_CardEmplGrp" && AssociatedType == "T_EmployeeCardEmplGrpAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeCardEmplGrpAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_CardLvPlan" && AssociatedType == "T_EmployeeCardLvPlanAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeCardLvPlanAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Address" && AssociatedType == "T_EmployeeAddress")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Employee obj = db.T_Employees.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeAddressID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_Employee", User) || !User.CanDelete("T_Employee")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_Employee t_employee = db.T_Employees.Find(id);
		if (CheckBeforeDelete(t_employee))
        {
            if (!CustomDelete(t_employee, out customdelete_hasissues, "DeleteBulk"))
            {
            var listT_LicenseRecords = db.T_Licensess.Where(p => p.T_LicenseRecordsID == id);
            foreach (var lst in listT_LicenseRecords)
               db.T_Licensess.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeEmployeeInjury = db.T_EmployeeInjurys.Where(p => p.T_EmployeeEmployeeInjuryID == id);
            foreach (var lst in listT_EmployeeEmployeeInjury)
               db.T_EmployeeInjurys.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeCriminalBackgroundCheck = db.T_BackgroundChecks.Where(p => p.T_EmployeeCriminalBackgroundCheckID == id);
            foreach (var lst in listT_EmployeeCriminalBackgroundCheck)
               db.T_BackgroundChecks.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeAccomodation = db.T_Accommodations.Where(p => p.T_EmployeeAccomodationID == id);
            foreach (var lst in listT_EmployeeAccomodation)
               db.T_Accommodations.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeEmploymentProfile = db.T_ServiceRecords.Where(p => p.T_EmployeeEmploymentProfileID == id);
            foreach (var lst in listT_EmployeeEmploymentProfile)
               db.T_ServiceRecords.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeJobAssignment = db.T_JobAssignments.Where(p => p.T_EmployeeJobAssignmentID == id);
            foreach (var lst in listT_EmployeeJobAssignment)
               db.T_JobAssignments.Remove(lst);
           db.SaveChanges();
            var listT_EmployeePayDetails = db.T_PayDetailss.Where(p => p.T_EmployeePayDetailsID == id);
            foreach (var lst in listT_EmployeePayDetails)
               db.T_PayDetailss.Remove(lst);
           db.SaveChanges();
            var listT_EmployeeDrugAlcoholTest = db.T_DrugAlcoholTests.Where(p => p.T_EmployeeDrugAlcoholTestID == id);
            foreach (var lst in listT_EmployeeDrugAlcoholTest)
               db.T_DrugAlcoholTests.Remove(lst);
           db.SaveChanges();
                db.Entry(t_employee).State = EntityState.Deleted;
                db.T_Employees.Remove(t_employee);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_Employee", User) || !User.CanEdit("T_Employee") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_EmployeeParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_EmployeeAtFacilityID,T_PID,T_SSN,T_DateOfBirth,T_EmployeeStatusID,T_SAMAccount,T_LastName,T_FirstName,T_MiddleName,T_Suffix,T_WorkEmail,T_CurrentEmployeeEmploymentProfileID,t_currentemployeeemploymentprofile,T_CurrentEmployeeJobAssignmentID,t_currentemployeejobassignment,T_StateHireDate,T_AdjustedHireDate,T_PriorServiceinmonths,T_CurrentServiceinmonths,T_EmployeeGenderID,T_EmployeeRaceID,T_EmployeeNationalityAssociationID,T_EmployeeVeteranStatusID,T_EmployeeCardEmplGrpAssociationID,T_EmployeeCardLvPlanAssociationID,T_EmployeeAddressID,t_employeeaddress,T_PersonalEmail,T_MobilePhone,T_HomePhone,T_EmployeeUserLoginID,T_EmergencyContactName,T_EmergencyContactRelationship,T_EmergencyMobilePhone,T_EmergencyWorkPhone,T_BadgeNumber,T_EffectiveDateTime,SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage,SelectedT_Langauge_T_LanguageCertifiedIn")] T_Employee t_employee,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_Employee target = db.T_Employees.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_employee, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_employeeatfacility != null)
							  db.Entry(target.t_employeeatfacility).State = EntityState.Unchanged;
							if (target.t_employeestatus != null)
							  db.Entry(target.t_employeestatus).State = EntityState.Unchanged;
							if (target.t_currentemployeeemploymentprofile != null)
							  db.Entry(target.t_currentemployeeemploymentprofile).State = EntityState.Unchanged;
							if (target.t_currentemployeejobassignment != null)
							  db.Entry(target.t_currentemployeejobassignment).State = EntityState.Unchanged;
							if (target.t_employeegender != null)
							  db.Entry(target.t_employeegender).State = EntityState.Unchanged;
							if (target.t_employeerace != null)
							  db.Entry(target.t_employeerace).State = EntityState.Unchanged;
							if (target.t_employeenationalityassociation != null)
							  db.Entry(target.t_employeenationalityassociation).State = EntityState.Unchanged;
							if (target.t_employeeveteranstatus != null)
							  db.Entry(target.t_employeeveteranstatus).State = EntityState.Unchanged;
							if (target.t_employeecardemplgrpassociation != null)
							  db.Entry(target.t_employeecardemplgrpassociation).State = EntityState.Unchanged;
							if (target.t_employeecardlvplanassociation != null)
							  db.Entry(target.t_employeecardlvplanassociation).State = EntityState.Unchanged;
							if (target.t_employeeaddress != null)
							  db.Entry(target.t_employeeaddress).State = EntityState.Unchanged;
							if (target.t_employeeuserlogin != null)
							  db.Entry(target.t_employeeuserlogin).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employee,"BulkUpdate","");
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
