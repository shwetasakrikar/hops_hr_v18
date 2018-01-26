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
    public partial class T_LeaveProfileController : BaseController
    {
		
        // GET: /T_LeaveProfile/
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
			var lstT_LeaveProfile = from s in db.T_LeaveProfiles
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_LeaveProfile = searchRecords(lstT_LeaveProfile, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_LeaveProfile = sortRecords(lstT_LeaveProfile, sortBy, isAsc);
            }
            else lstT_LeaveProfile = lstT_LeaveProfile.OrderByDescending(c => c.Id);
			lstT_LeaveProfile = CustomSorting(lstT_LeaveProfile);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_LeaveProfile"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_LeaveProfile"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_LeaveProfile"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_LeaveProfile"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_LeaveProfile = lstT_LeaveProfile.Include(t=>t.t_employeeleaveprofile).Include(t=>t.t_injuryrelatedleave);
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeLeaveProfile")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_LeaveProfile = _T_LeaveProfile.Where(p => p.T_EmployeeLeaveProfileID == hostid);
			 }
			 else
			     _T_LeaveProfile = _T_LeaveProfile.Where(p => p.T_EmployeeLeaveProfileID == null);
         }
		 if (HostingEntity == "T_EmployeeInjury" && AssociatedType == "T_InjuryRelatedLeave")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_LeaveProfile = _T_LeaveProfile.Where(p => p.T_InjuryRelatedLeaveID == hostid);
			 }
			 else
			     _T_LeaveProfile = _T_LeaveProfile.Where(p => p.T_InjuryRelatedLeaveID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_LeaveProfile", User) || !User.CanView("T_LeaveProfile"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_LeaveProfile.Count() > 0)
                    pageSize = _T_LeaveProfile.Count();
                return View("ExcelExport", _T_LeaveProfile.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_LeaveProfile.Count();
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
					var list = _T_LeaveProfile.ToPagedList(pageNumber, pageSize);
					ViewBag.EntityT_LeaveProfileDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
					TempData["T_LeaveProfilelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
					return View(list);
				}
				 else
				 {
					if (BulkOperation != null && (BulkOperation == "single" || BulkOperation == "multiple"))
					{
						FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
                        _T_LeaveProfile = _fad.FilterDropdown<T_LeaveProfile>(User, _T_LeaveProfile, "T_LeaveProfile", caller);
						return PartialView("BulkOperation", _T_LeaveProfile.OrderBy(p=>p.Id).ToPagedList(pageNumber, pageSize)); 
					}
					else
					{
						if (ViewBag.TemplatesName == null)
						{
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_LeaveProfile.Count() == 0 ? 1 : _T_LeaveProfile.Count();
                            }
							var list = _T_LeaveProfile.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_LeaveProfileDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_LeaveProfilelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
						}
					    else
						{
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_LeaveProfile.Count() == 0 ? 1 : _T_LeaveProfile.Count();
                            }
							var list = _T_LeaveProfile.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_LeaveProfileDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_LeaveProfilelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
						}
					}
				 }
        }
		 // GET: /T_LeaveProfile/Details/5
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
            T_LeaveProfile t_leaveprofile = db.T_LeaveProfiles.Find(id);
            if (t_leaveprofile == null)
            {
                return HttpNotFound();
            }
		    t_leaveprofile.T_LeaveReason_T_LeaveProfileReason = db.T_LeaveReasons.OrderBy(c => c.DisplayValue).ToList();
            t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id).Select(p => p.T_LeaveReasonID).ToList();
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_leaveprofile);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_leaveprofile, AssociatedType);
            ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnDetails", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnDetails", true);
			ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnDetails");
			return View(ViewBag.TemplatesName,t_leaveprofile);
        }
        // GET: /T_LeaveProfile/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_LeaveProfile") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		    ViewBag.T_LeaveReason_T_LeaveProfileReason = db.T_LeaveReasons.OrderBy(c => c.DisplayValue).ToList();
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_LeaveProfileParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", true);
		  ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnCreate");
          return View();
        }
		// GET: /T_LeaveProfile/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_LeaveProfile") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		    ViewBag.T_LeaveReason_T_LeaveProfileReason = db.T_LeaveReasons.OrderBy(x => x.DisplayValue).ToList();
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_LeaveProfileParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", true);
			 ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnCreate");
            return View();
        }
		// POST: /T_LeaveProfile/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeLeaveProfileID,T_From,T_To,T_DaysOff,T_Intermittent,T_FullDays,T_InjuryRelatedLeaveID,T_Notes,SelectedT_LeaveReason_T_LeaveProfileReason")] T_LeaveProfile t_leaveprofile, string UrlReferrer)
        {
			CheckBeforeSave(t_leaveprofile);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_leaveprofile,out customcreate_hasissues,"Create"))
                {
                    db.T_LeaveProfiles.Add(t_leaveprofile);
					db.SaveChanges();
                }
                bool flagT_LeaveProfileReason = false; 
				var dblistT_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id);
				 if (t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason != null)
                    dblistT_LeaveProfileReason = dblistT_LeaveProfileReason.Where(a => !t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason.Contains(a.T_LeaveReasonID));
                foreach (var obj in dblistT_LeaveProfileReason)
                {
					 db.T_LeaveProfileReasons.Remove(obj);
					  flagT_LeaveProfileReason = true; 
				}
				if (flagT_LeaveProfileReason)
					db.SaveChanges();
				flagT_LeaveProfileReason = false;
				if (t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason !=null)
				{
					foreach (var pgs in t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason)
					{
						if (db.T_LeaveProfileReasons.FirstOrDefault(a => a.T_LeaveProfileID == t_leaveprofile.Id && a.T_LeaveReasonID == pgs) == null)
                        {
							T_LeaveProfileReason objT_LeaveProfileReason = new T_LeaveProfileReason();
							objT_LeaveProfileReason.T_LeaveProfileID = t_leaveprofile.Id;
							objT_LeaveProfileReason.T_LeaveReasonID = pgs;
							db.Entry(objT_LeaveProfileReason).State = EntityState.Added;
							db.T_LeaveProfileReasons.Add(objT_LeaveProfileReason);
							flagT_LeaveProfileReason = true;
						}
					}
					if (flagT_LeaveProfileReason)
						db.SaveChanges();
				 }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_leaveprofile,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
		    t_leaveprofile.T_LeaveReason_T_LeaveProfileReason = db.T_LeaveReasons.OrderBy(x => x.DisplayValue).ToList();
	
			LoadViewDataAfterOnCreate(t_leaveprofile);
			ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", true);
			ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnCreate");	
            return View(t_leaveprofile);
        }
		 // GET: /T_LeaveProfile/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_LeaveProfile") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_LeaveProfileParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", true);
			ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnCreate");
            return View();
        }
		  // POST: /T_LeaveProfile/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeLeaveProfileID,T_From,T_To,T_Intermittent,T_FullDays,T_InjuryRelatedLeaveID")] T_LeaveProfile t_leaveprofile,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_leaveprofile);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_leaveprofile,out customcreate_hasissues,"Create"))
                {
                    db.T_LeaveProfiles.Add(t_leaveprofile);
					db.SaveChanges();
                }
				if (HostingEntityName == "T_LeaveReason" && AssociatedEntity == "T_LeaveProfileReason_T_LeaveReason")
                {
                    long hostingentityid;
                    if(Int64.TryParse(HostingEntityID,out hostingentityid) && hostingentityid >0)
                    {
                        db.T_LeaveProfileReasons.Add(new T_LeaveProfileReason { T_LeaveReasonID = hostingentityid, T_LeaveProfileID = t_leaveprofile.Id });
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
			LoadViewDataAfterOnCreate(t_leaveprofile);
			ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", true);
			ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_leaveprofile, AssociatedEntity);
			return View(t_leaveprofile);
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
        // POST: /T_LeaveProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_EmployeeLeaveProfileID,T_From,T_To,T_DaysOff,T_Intermittent,T_FullDays,T_InjuryRelatedLeaveID,T_Notes,SelectedT_LeaveReason_T_LeaveProfileReason")] T_LeaveProfile t_leaveprofile, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_leaveprofile, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_leaveprofile,out customcreate_hasissues,command))
                {
                    db.T_LeaveProfiles.Add(t_leaveprofile);
					db.SaveChanges();
                }
				bool flagT_LeaveProfileReason = false; 
				var dblistT_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id);
				 if (t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason != null)
                    dblistT_LeaveProfileReason = dblistT_LeaveProfileReason.Where(a => !t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason.Contains(a.T_LeaveReasonID));
                foreach (var obj in dblistT_LeaveProfileReason)
                {
					 db.T_LeaveProfileReasons.Remove(obj);
					  flagT_LeaveProfileReason = true; 
				}
				if (flagT_LeaveProfileReason)
					db.SaveChanges();
				flagT_LeaveProfileReason = false;
				if (t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason !=null)
				{
					foreach (var pgs in t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason)
					{
						if (db.T_LeaveProfileReasons.FirstOrDefault(a => a.T_LeaveProfileID == t_leaveprofile.Id && a.T_LeaveReasonID == pgs) == null)
                        {
							T_LeaveProfileReason objT_LeaveProfileReason = new T_LeaveProfileReason();
							objT_LeaveProfileReason.T_LeaveProfileID = t_leaveprofile.Id;
							objT_LeaveProfileReason.T_LeaveReasonID = pgs;
							db.Entry(objT_LeaveProfileReason).State = EntityState.Added;
							db.T_LeaveProfileReasons.Add(objT_LeaveProfileReason);
							flagT_LeaveProfileReason = true;
						}
					}
					if (flagT_LeaveProfileReason)
						db.SaveChanges();
				 }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_leaveprofile,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_leaveprofile.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
		    t_leaveprofile.T_LeaveReason_T_LeaveProfileReason = db.T_LeaveReasons.OrderBy(x => x.DisplayValue).ToList();
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_leaveprofile);
			ViewData["T_LeaveProfileParentUrl"] = UrlReferrer;
			ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnCreate", true);
			ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnCreate");
            return View(t_leaveprofile);
        }
		// GET: /T_LeaveProfile/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_LeaveProfile") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_LeaveProfile t_leaveprofile = db.T_LeaveProfiles.Find(id);
            if (t_leaveprofile == null)
            {
                return HttpNotFound();
            }
		    t_leaveprofile.T_LeaveReason_T_LeaveProfileReason = db.T_LeaveReasons.OrderBy(c => c.DisplayValue).ToList();
            t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id).Select(p => p.T_LeaveReasonID).ToList();
		if (UrlReferrer != null)
                ViewData["T_LeaveProfileParentUrl"] = UrlReferrer;
		if(ViewData["T_LeaveProfileParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfile")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfile/Edit/" + t_leaveprofile.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfile/Create"))
			ViewData["T_LeaveProfileParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_leaveprofile);
		   ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", true);
		   ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnEdit");
		    var objT_LeaveProfile = new List<T_LeaveProfile>();
            ViewBag.T_LeaveProfileDD = new SelectList(objT_LeaveProfile, "ID", "DisplayValue"); 
          return View(t_leaveprofile);
        }
		// POST: /T_LeaveProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeLeaveProfileID,T_From,T_To,T_DaysOff,T_Intermittent,T_FullDays,T_InjuryRelatedLeaveID,T_Notes,SelectedT_LeaveReason_T_LeaveProfileReason")] T_LeaveProfile t_leaveprofile,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_leaveprofile, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_leaveprofile,out customsave_hasissues,command))
                {
					db.Entry(t_leaveprofile).State = EntityState.Modified;
					db.SaveChanges();
                }
               bool flagT_LeaveProfileReason = false; 
				var dblistT_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id);
				 if (t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason != null)
                    dblistT_LeaveProfileReason = dblistT_LeaveProfileReason.Where(a => !t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason.Contains(a.T_LeaveReasonID));
                foreach (var obj in dblistT_LeaveProfileReason)
                {
					 db.T_LeaveProfileReasons.Remove(obj);
					  flagT_LeaveProfileReason = true; 
				}
				if (flagT_LeaveProfileReason)
					db.SaveChanges();
				flagT_LeaveProfileReason = false;
				if (t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason !=null)
				{
					foreach (var pgs in t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason)
					{
						if (db.T_LeaveProfileReasons.FirstOrDefault(a => a.T_LeaveProfileID == t_leaveprofile.Id && a.T_LeaveReasonID == pgs) == null)
                        {
							T_LeaveProfileReason objT_LeaveProfileReason = new T_LeaveProfileReason();
							objT_LeaveProfileReason.T_LeaveProfileID = t_leaveprofile.Id;
							objT_LeaveProfileReason.T_LeaveReasonID = pgs;
							db.Entry(objT_LeaveProfileReason).State = EntityState.Added;
							db.T_LeaveProfileReasons.Add(objT_LeaveProfileReason);
							flagT_LeaveProfileReason = true;
						}
					}
					if (flagT_LeaveProfileReason)
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
			
			LoadViewDataAfterOnEdit(t_leaveprofile);
			ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", true);
			ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnEdit");
            return View(t_leaveprofile);
        }
        // GET: /T_LeaveProfile/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_LeaveProfile") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_LeaveProfile t_leaveprofile = db.T_LeaveProfiles.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_LeaveProfilelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_LeaveProfiles.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_LeaveProfileDisplayValueEdit = TempData["T_LeaveProfilelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_LeaveProfilelist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_LeaveProfileDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_leaveprofile == null)
            {
                return HttpNotFound();
            }
		    t_leaveprofile.T_LeaveReason_T_LeaveProfileReason = db.T_LeaveReasons.OrderBy(c => c.DisplayValue).ToList();
            t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id).Select(p => p.T_LeaveReasonID).ToList();
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfile/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_leaveprofile.DisplayValue, Value = t_leaveprofile.Id.ToString() }));
                ViewBag.EntityT_LeaveProfileDisplayValueEdit = newList;
				TempData["T_LeaveProfilelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_leaveprofile.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_leaveprofile.DisplayValue;
                    newList[0].Value = t_leaveprofile.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_leaveprofile.DisplayValue, Value = t_leaveprofile.Id.ToString() }));
                }
                ViewBag.EntityT_LeaveProfileDisplayValueEdit = newList;
				TempData["T_LeaveProfilelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_LeaveProfileParentUrl"] = UrlReferrer;
		if(ViewData["T_LeaveProfileParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfile")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfile/Edit/" + t_leaveprofile.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfile/Create"))
			ViewData["T_LeaveProfileParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_leaveprofile);
		   ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", true);
		   ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnEdit");
          return View(t_leaveprofile);
        }
        // POST: /T_LeaveProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_EmployeeLeaveProfileID,T_From,T_To,T_DaysOff,T_Intermittent,T_FullDays,T_InjuryRelatedLeaveID,T_Notes,SelectedT_LeaveReason_T_LeaveProfileReason")] T_LeaveProfile t_leaveprofile,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_leaveprofile, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_leaveprofile,out customsave_hasissues,command))
            {
				db.Entry(t_leaveprofile).State = EntityState.Modified;
				db.SaveChanges();
            }
               bool flagT_LeaveProfileReason = false; 
				var dblistT_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id);
				 if (t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason != null)
                    dblistT_LeaveProfileReason = dblistT_LeaveProfileReason.Where(a => !t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason.Contains(a.T_LeaveReasonID));
                foreach (var obj in dblistT_LeaveProfileReason)
                {
					 db.T_LeaveProfileReasons.Remove(obj);
					  flagT_LeaveProfileReason = true; 
				}
				if (flagT_LeaveProfileReason)
					db.SaveChanges();
				flagT_LeaveProfileReason = false;
				if (t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason !=null)
				{
					foreach (var pgs in t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason)
					{
						if (db.T_LeaveProfileReasons.FirstOrDefault(a => a.T_LeaveProfileID == t_leaveprofile.Id && a.T_LeaveReasonID == pgs) == null)
                        {
							T_LeaveProfileReason objT_LeaveProfileReason = new T_LeaveProfileReason();
							objT_LeaveProfileReason.T_LeaveProfileID = t_leaveprofile.Id;
							objT_LeaveProfileReason.T_LeaveReasonID = pgs;
							db.Entry(objT_LeaveProfileReason).State = EntityState.Added;
							db.T_LeaveProfileReasons.Add(objT_LeaveProfileReason);
							flagT_LeaveProfileReason = true;
						}
					}
					if (flagT_LeaveProfileReason)
						db.SaveChanges();
				 }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_leaveprofile,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_leaveprofile.Id, UrlReferrer = UrlReferrer });
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
		    t_leaveprofile.T_LeaveReason_T_LeaveProfileReason = db.T_LeaveReasons.OrderBy(x => x.DisplayValue).ToList();
            t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id).Select(p => p.T_LeaveReasonID).ToList();
			
			// NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_LeaveProfilelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_LeaveProfiles.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_LeaveProfileDisplayValueEdit = TempData["T_LeaveProfilelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_LeaveProfilelist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_LeaveProfileDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_leaveprofile);
			 ViewData["T_LeaveProfileParentUrl"] = UrlReferrer;
			ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", true);
			ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnEdit");
            return View(t_leaveprofile);
        }
		// GET: /T_LeaveProfile/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_LeaveProfile") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_LeaveProfile t_leaveprofile = db.T_LeaveProfiles.Find(id);
            if (t_leaveprofile == null)
            {
                return HttpNotFound();
            }
		    t_leaveprofile.T_LeaveReason_T_LeaveProfileReason = db.T_LeaveReasons.OrderBy(c => c.DisplayValue).ToList();
            t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id).Select(p => p.T_LeaveReasonID).ToList();
	
		 if (UrlReferrer != null)
                ViewData["T_LeaveProfileParentUrl"] = UrlReferrer;
		if(ViewData["T_LeaveProfileParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfile"))
			ViewData["T_LeaveProfileParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_leaveprofile);
			 ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", true);
			 ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnEdit");
          return View(t_leaveprofile);
        }
        // POST: /T_LeaveProfile/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeLeaveProfileID,T_From,T_To,T_DaysOff,T_Intermittent,T_FullDays,T_InjuryRelatedLeaveID,T_Notes,SelectedT_LeaveReason_T_LeaveProfileReason")] T_LeaveProfile t_leaveprofile,string UrlReferrer)
        {
			CheckBeforeSave(t_leaveprofile);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_leaveprofile,out customsave_hasissues,"Save"))
            {
				db.Entry(t_leaveprofile).State = EntityState.Modified;
				db.SaveChanges();
            }
               bool flagT_LeaveProfileReason = false; 
				var dblistT_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id);
				 if (t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason != null)
                    dblistT_LeaveProfileReason = dblistT_LeaveProfileReason.Where(a => !t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason.Contains(a.T_LeaveReasonID));
                foreach (var obj in dblistT_LeaveProfileReason)
                {
					 db.T_LeaveProfileReasons.Remove(obj);
					  flagT_LeaveProfileReason = true; 
				}
				if (flagT_LeaveProfileReason)
					db.SaveChanges();
				flagT_LeaveProfileReason = false;
				if (t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason !=null)
				{
					foreach (var pgs in t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason)
					{
						if (db.T_LeaveProfileReasons.FirstOrDefault(a => a.T_LeaveProfileID == t_leaveprofile.Id && a.T_LeaveReasonID == pgs) == null)
                        {
							T_LeaveProfileReason objT_LeaveProfileReason = new T_LeaveProfileReason();
							objT_LeaveProfileReason.T_LeaveProfileID = t_leaveprofile.Id;
							objT_LeaveProfileReason.T_LeaveReasonID = pgs;
							db.Entry(objT_LeaveProfileReason).State = EntityState.Added;
							db.T_LeaveProfileReasons.Add(objT_LeaveProfileReason);
							flagT_LeaveProfileReason = true;
						}
					}
					if (flagT_LeaveProfileReason)
						db.SaveChanges();
				 }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_leaveprofile,"Edit","");
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
		    t_leaveprofile.T_LeaveReason_T_LeaveProfileReason = db.T_LeaveReasons.OrderBy(c => c.DisplayValue).ToList();
            t_leaveprofile.SelectedT_LeaveReason_T_LeaveProfileReason = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofile.Id).Select(p => p.T_LeaveReasonID).ToList();
			LoadViewDataAfterOnEdit(t_leaveprofile);
			ViewBag.T_LeaveProfileIsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", false);
			ViewBag.T_LeaveProfileIsGroupsHiddenRule = checkHidden("T_LeaveProfile", "OnEdit", true);
			ViewBag.T_LeaveProfileIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfile", "OnEdit");
            return View(t_leaveprofile);
        }
        // GET: /T_LeaveProfile/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_LeaveProfile") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_LeaveProfile t_leaveprofile = db.T_LeaveProfiles.Find(id);
            if (t_leaveprofile == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_LeaveProfileParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfile"))
			 ViewData["T_LeaveProfileParentUrl"] = Request.UrlReferrer;
            return View(t_leaveprofile);
        }
        // POST: /T_LeaveProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_LeaveProfile t_leaveprofile, string UrlReferrer)
        {
			if (!User.CanDelete("T_LeaveProfile"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_leaveprofile))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_leaveprofile, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_leaveprofile).State = EntityState.Deleted;
            db.T_LeaveProfiles.Remove(t_leaveprofile);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_LeaveProfileParentUrl"] != null)
					{
						string parentUrl = ViewData["T_LeaveProfileParentUrl"].ToString();
						ViewData["T_LeaveProfileParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_leaveprofile);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeLeaveProfile")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_LeaveProfile obj = db.T_LeaveProfiles.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeLeaveProfileID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_EmployeeInjury" && AssociatedType == "T_InjuryRelatedLeave")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_LeaveProfile obj = db.T_LeaveProfiles.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_InjuryRelatedLeaveID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_LeaveProfile", User) || !User.CanDelete("T_LeaveProfile")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_LeaveProfile t_leaveprofile = db.T_LeaveProfiles.Find(id);
		if (CheckBeforeDelete(t_leaveprofile))
        {
            if (!CustomDelete(t_leaveprofile, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_leaveprofile).State = EntityState.Deleted;
                db.T_LeaveProfiles.Remove(t_leaveprofile);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_LeaveProfile", User) || !User.CanEdit("T_LeaveProfile") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_LeaveProfileParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_EmployeeLeaveProfileID,T_From,T_To,T_DaysOff,T_Intermittent,T_FullDays,T_InjuryRelatedLeaveID,T_Notes,SelectedT_LeaveReason_T_LeaveProfileReason")] T_LeaveProfile t_leaveprofile,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_LeaveProfile target = db.T_LeaveProfiles.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_leaveprofile, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_employeeleaveprofile != null)
							  db.Entry(target.t_employeeleaveprofile).State = EntityState.Unchanged;
							if (target.t_injuryrelatedleave != null)
							  db.Entry(target.t_injuryrelatedleave).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_leaveprofile,"BulkUpdate","");
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
