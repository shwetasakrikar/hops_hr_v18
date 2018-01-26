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

    public partial class T_ClaimTypeController : BaseController
    {
		
        // GET: /T_ClaimType/
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
			var lstT_ClaimType = from s in db.T_ClaimTypes
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_ClaimType = searchRecords(lstT_ClaimType, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_ClaimType = sortRecords(lstT_ClaimType, sortBy, isAsc);
            }
            else lstT_ClaimType = lstT_ClaimType.OrderByDescending(c => c.Id);
			lstT_ClaimType = CustomSorting(lstT_ClaimType);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_ClaimType"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_ClaimType"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_ClaimType"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_ClaimType"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_ClaimType = lstT_ClaimType.Include(t=>t.t_claimtypefacilityassociation);
		 if (HostingEntity == "T_Facility" && AssociatedType == "T_ClaimTypeFacilityAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_ClaimType = _T_ClaimType.Where(p => p.T_ClaimTypeFacilityAssociationID == hostid);
			 }
			 else
			     _T_ClaimType = _T_ClaimType.Where(p => p.T_ClaimTypeFacilityAssociationID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_ClaimType", User) || !User.CanView("T_ClaimType"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_ClaimType.Count() > 0)
                    pageSize = _T_ClaimType.Count();
                return View("ExcelExport", _T_ClaimType.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_ClaimType.Count();
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
					var list = _T_ClaimType.ToPagedList(pageNumber, pageSize);
					ViewBag.EntityT_ClaimTypeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
					TempData["T_ClaimTypelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
					return View(list);
				}
				 else
				 {
					if (BulkOperation != null && (BulkOperation == "single" || BulkOperation == "multiple"))
					{
						FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
                        _T_ClaimType = _fad.FilterDropdown<T_ClaimType>(User, _T_ClaimType, "T_ClaimType", caller);
						return PartialView("BulkOperation", _T_ClaimType.OrderBy(p=>p.Id).ToPagedList(pageNumber, pageSize)); 
					}
					else
					{
						if (ViewBag.TemplatesName == null)
						{
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_ClaimType.Count() == 0 ? 1 : _T_ClaimType.Count();
                            }
							var list = _T_ClaimType.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_ClaimTypeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_ClaimTypelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
						}
					    else
						{
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_ClaimType.Count() == 0 ? 1 : _T_ClaimType.Count();
                            }
							var list = _T_ClaimType.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_ClaimTypeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_ClaimTypelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
						}
					}
				 }
        }
		 // GET: /T_ClaimType/Details/5
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
            T_ClaimType t_claimtype = db.T_ClaimTypes.Find(id);
            if (t_claimtype == null)
            {
                return HttpNotFound();
            }
		    t_claimtype.T_EmployeeInjury_T_TypeofClaim = db.T_EmployeeInjurys.OrderBy(c => c.DisplayValue).ToList();
            t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id).Select(p => p.T_EmployeeInjuryID).ToList();
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_claimtype);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_claimtype, AssociatedType);
            ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnDetails", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnDetails", true);
			ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnDetails");
			return View(ViewBag.TemplatesName,t_claimtype);
        }
        // GET: /T_ClaimType/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_ClaimType") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		    ViewBag.T_EmployeeInjury_T_TypeofClaim = db.T_EmployeeInjurys.OrderBy(c => c.DisplayValue).ToList();
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_ClaimTypeParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnCreate", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnCreate", true);
		  ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnCreate");
          return View();
        }
		// GET: /T_ClaimType/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_ClaimType") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		    ViewBag.T_EmployeeInjury_T_TypeofClaim = db.T_EmployeeInjurys.OrderBy(x => x.DisplayValue).ToList();
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_ClaimTypeParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnCreate", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnCreate", true);
			 ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnCreate");
            return View();
        }
		// POST: /T_ClaimType/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeFacilityAssociationID,T_Name,SelectedT_EmployeeInjury_T_TypeofClaim")] T_ClaimType t_claimtype, string UrlReferrer)
        {
			CheckBeforeSave(t_claimtype);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_claimtype,out customcreate_hasissues,"Create"))
                {
                    db.T_ClaimTypes.Add(t_claimtype);
					db.SaveChanges();
                }
                bool flagT_TypeofClaim = false; 
				var dblistT_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id);
				 if (t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim != null)
                    dblistT_TypeofClaim = dblistT_TypeofClaim.Where(a => !t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim.Contains(a.T_EmployeeInjuryID));
                foreach (var obj in dblistT_TypeofClaim)
                {
					 db.T_TypeofClaims.Remove(obj);
					  flagT_TypeofClaim = true; 
				}
				if (flagT_TypeofClaim)
					db.SaveChanges();
				flagT_TypeofClaim = false;
				if (t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim !=null)
				{
					foreach (var pgs in t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim)
					{
						if (db.T_TypeofClaims.FirstOrDefault(a => a.T_ClaimTypeID == t_claimtype.Id && a.T_EmployeeInjuryID == pgs) == null)
                        {
							T_TypeofClaim objT_TypeofClaim = new T_TypeofClaim();
							objT_TypeofClaim.T_ClaimTypeID = t_claimtype.Id;
							objT_TypeofClaim.T_EmployeeInjuryID = pgs;
							db.Entry(objT_TypeofClaim).State = EntityState.Added;
							db.T_TypeofClaims.Add(objT_TypeofClaim);
							flagT_TypeofClaim = true;
						}
					}
					if (flagT_TypeofClaim)
						db.SaveChanges();
				 }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_claimtype,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
		    t_claimtype.T_EmployeeInjury_T_TypeofClaim = db.T_EmployeeInjurys.OrderBy(x => x.DisplayValue).ToList();
	
			LoadViewDataAfterOnCreate(t_claimtype);
			ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnCreate", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnCreate", true);
			ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnCreate");	
            return View(t_claimtype);
        }
		 // GET: /T_ClaimType/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_ClaimType") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_ClaimTypeParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnCreate", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnCreate", true);
			ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnCreate");
            return View();
        }
		  // POST: /T_ClaimType/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeFacilityAssociationID,T_Name")] T_ClaimType t_claimtype,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_claimtype);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_claimtype,out customcreate_hasissues,"Create"))
                {
                    db.T_ClaimTypes.Add(t_claimtype);
					db.SaveChanges();
                }
				if (HostingEntityName == "T_EmployeeInjury" && AssociatedEntity == "T_TypeofClaim_T_EmployeeInjury")
                {
                    long hostingentityid;
                    if(Int64.TryParse(HostingEntityID,out hostingentityid) && hostingentityid >0)
                    {
                        db.T_TypeofClaims.Add(new T_TypeofClaim { T_EmployeeInjuryID = hostingentityid, T_ClaimTypeID = t_claimtype.Id });
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
			LoadViewDataAfterOnCreate(t_claimtype);
			ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnCreate", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnCreate", true);
			ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_claimtype, AssociatedEntity);
			return View(t_claimtype);
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
        // POST: /T_ClaimType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeFacilityAssociationID,T_Name,SelectedT_EmployeeInjury_T_TypeofClaim")] T_ClaimType t_claimtype, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_claimtype, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_claimtype,out customcreate_hasissues,command))
                {
                    db.T_ClaimTypes.Add(t_claimtype);
					db.SaveChanges();
                }
				bool flagT_TypeofClaim = false; 
				var dblistT_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id);
				 if (t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim != null)
                    dblistT_TypeofClaim = dblistT_TypeofClaim.Where(a => !t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim.Contains(a.T_EmployeeInjuryID));
                foreach (var obj in dblistT_TypeofClaim)
                {
					 db.T_TypeofClaims.Remove(obj);
					  flagT_TypeofClaim = true; 
				}
				if (flagT_TypeofClaim)
					db.SaveChanges();
				flagT_TypeofClaim = false;
				if (t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim !=null)
				{
					foreach (var pgs in t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim)
					{
						if (db.T_TypeofClaims.FirstOrDefault(a => a.T_ClaimTypeID == t_claimtype.Id && a.T_EmployeeInjuryID == pgs) == null)
                        {
							T_TypeofClaim objT_TypeofClaim = new T_TypeofClaim();
							objT_TypeofClaim.T_ClaimTypeID = t_claimtype.Id;
							objT_TypeofClaim.T_EmployeeInjuryID = pgs;
							db.Entry(objT_TypeofClaim).State = EntityState.Added;
							db.T_TypeofClaims.Add(objT_TypeofClaim);
							flagT_TypeofClaim = true;
						}
					}
					if (flagT_TypeofClaim)
						db.SaveChanges();
				 }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_claimtype,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_claimtype.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
		    t_claimtype.T_EmployeeInjury_T_TypeofClaim = db.T_EmployeeInjurys.OrderBy(x => x.DisplayValue).ToList();
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_claimtype);
			ViewData["T_ClaimTypeParentUrl"] = UrlReferrer;
			ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnCreate", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnCreate", true);
			ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnCreate");
            return View(t_claimtype);
        }
		// GET: /T_ClaimType/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_ClaimType") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_ClaimType t_claimtype = db.T_ClaimTypes.Find(id);
            if (t_claimtype == null)
            {
                return HttpNotFound();
            }
		    t_claimtype.T_EmployeeInjury_T_TypeofClaim = db.T_EmployeeInjurys.OrderBy(c => c.DisplayValue).ToList();
            t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id).Select(p => p.T_EmployeeInjuryID).ToList();
		if (UrlReferrer != null)
                ViewData["T_ClaimTypeParentUrl"] = UrlReferrer;
		if(ViewData["T_ClaimTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClaimType")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClaimType/Edit/" + t_claimtype.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClaimType/Create"))
			ViewData["T_ClaimTypeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_claimtype);
		   ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnEdit", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnEdit", true);
		   ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnEdit");
		    var objT_ClaimType = new List<T_ClaimType>();
            ViewBag.T_ClaimTypeDD = new SelectList(objT_ClaimType, "ID", "DisplayValue"); 
          return View(t_claimtype);
        }
		// POST: /T_ClaimType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeFacilityAssociationID,T_Name,SelectedT_EmployeeInjury_T_TypeofClaim")] T_ClaimType t_claimtype,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_claimtype, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_claimtype,out customsave_hasissues,command))
                {
					db.Entry(t_claimtype).State = EntityState.Modified;
					db.SaveChanges();
                }
               bool flagT_TypeofClaim = false; 
				var dblistT_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id);
				 if (t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim != null)
                    dblistT_TypeofClaim = dblistT_TypeofClaim.Where(a => !t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim.Contains(a.T_EmployeeInjuryID));
                foreach (var obj in dblistT_TypeofClaim)
                {
					 db.T_TypeofClaims.Remove(obj);
					  flagT_TypeofClaim = true; 
				}
				if (flagT_TypeofClaim)
					db.SaveChanges();
				flagT_TypeofClaim = false;
				if (t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim !=null)
				{
					foreach (var pgs in t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim)
					{
						if (db.T_TypeofClaims.FirstOrDefault(a => a.T_ClaimTypeID == t_claimtype.Id && a.T_EmployeeInjuryID == pgs) == null)
                        {
							T_TypeofClaim objT_TypeofClaim = new T_TypeofClaim();
							objT_TypeofClaim.T_ClaimTypeID = t_claimtype.Id;
							objT_TypeofClaim.T_EmployeeInjuryID = pgs;
							db.Entry(objT_TypeofClaim).State = EntityState.Added;
							db.T_TypeofClaims.Add(objT_TypeofClaim);
							flagT_TypeofClaim = true;
						}
					}
					if (flagT_TypeofClaim)
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
			
			LoadViewDataAfterOnEdit(t_claimtype);
			ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnEdit", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnEdit", true);
			ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnEdit");
            return View(t_claimtype);
        }
        // GET: /T_ClaimType/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_ClaimType") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_ClaimType t_claimtype = db.T_ClaimTypes.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_ClaimTypelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_ClaimTypes.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_ClaimTypeDisplayValueEdit = TempData["T_ClaimTypelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_ClaimTypelist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_ClaimTypeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_claimtype == null)
            {
                return HttpNotFound();
            }
		    t_claimtype.T_EmployeeInjury_T_TypeofClaim = db.T_EmployeeInjurys.OrderBy(c => c.DisplayValue).ToList();
            t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id).Select(p => p.T_EmployeeInjuryID).ToList();
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClaimType/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_claimtype.DisplayValue, Value = t_claimtype.Id.ToString() }));
                ViewBag.EntityT_ClaimTypeDisplayValueEdit = newList;
				TempData["T_ClaimTypelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_claimtype.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_claimtype.DisplayValue;
                    newList[0].Value = t_claimtype.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_claimtype.DisplayValue, Value = t_claimtype.Id.ToString() }));
                }
                ViewBag.EntityT_ClaimTypeDisplayValueEdit = newList;
				TempData["T_ClaimTypelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_ClaimTypeParentUrl"] = UrlReferrer;
		if(ViewData["T_ClaimTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClaimType")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClaimType/Edit/" + t_claimtype.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClaimType/Create"))
			ViewData["T_ClaimTypeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_claimtype);
		   ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnEdit", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnEdit", true);
		   ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnEdit");
          return View(t_claimtype);
        }
        // POST: /T_ClaimType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeFacilityAssociationID,T_Name,SelectedT_EmployeeInjury_T_TypeofClaim")] T_ClaimType t_claimtype,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_claimtype, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_claimtype,out customsave_hasissues,command))
            {
				db.Entry(t_claimtype).State = EntityState.Modified;
				db.SaveChanges();
            }
               bool flagT_TypeofClaim = false; 
				var dblistT_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id);
				 if (t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim != null)
                    dblistT_TypeofClaim = dblistT_TypeofClaim.Where(a => !t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim.Contains(a.T_EmployeeInjuryID));
                foreach (var obj in dblistT_TypeofClaim)
                {
					 db.T_TypeofClaims.Remove(obj);
					  flagT_TypeofClaim = true; 
				}
				if (flagT_TypeofClaim)
					db.SaveChanges();
				flagT_TypeofClaim = false;
				if (t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim !=null)
				{
					foreach (var pgs in t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim)
					{
						if (db.T_TypeofClaims.FirstOrDefault(a => a.T_ClaimTypeID == t_claimtype.Id && a.T_EmployeeInjuryID == pgs) == null)
                        {
							T_TypeofClaim objT_TypeofClaim = new T_TypeofClaim();
							objT_TypeofClaim.T_ClaimTypeID = t_claimtype.Id;
							objT_TypeofClaim.T_EmployeeInjuryID = pgs;
							db.Entry(objT_TypeofClaim).State = EntityState.Added;
							db.T_TypeofClaims.Add(objT_TypeofClaim);
							flagT_TypeofClaim = true;
						}
					}
					if (flagT_TypeofClaim)
						db.SaveChanges();
				 }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_claimtype,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_claimtype.Id, UrlReferrer = UrlReferrer });
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
		    t_claimtype.T_EmployeeInjury_T_TypeofClaim = db.T_EmployeeInjurys.OrderBy(x => x.DisplayValue).ToList();
            t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id).Select(p => p.T_EmployeeInjuryID).ToList();
			
			// NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_ClaimTypelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_ClaimTypes.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_ClaimTypeDisplayValueEdit = TempData["T_ClaimTypelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_ClaimTypelist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_ClaimTypeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_claimtype);
			 ViewData["T_ClaimTypeParentUrl"] = UrlReferrer;
			ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnEdit", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnEdit", true);
			ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnEdit");
            return View(t_claimtype);
        }
		// GET: /T_ClaimType/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_ClaimType") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_ClaimType t_claimtype = db.T_ClaimTypes.Find(id);
            if (t_claimtype == null)
            {
                return HttpNotFound();
            }
		    t_claimtype.T_EmployeeInjury_T_TypeofClaim = db.T_EmployeeInjurys.OrderBy(c => c.DisplayValue).ToList();
            t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id).Select(p => p.T_EmployeeInjuryID).ToList();
	
		 if (UrlReferrer != null)
                ViewData["T_ClaimTypeParentUrl"] = UrlReferrer;
		if(ViewData["T_ClaimTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClaimType"))
			ViewData["T_ClaimTypeParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_claimtype);
			 ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnEdit", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnEdit", true);
			 ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnEdit");
          return View(t_claimtype);
        }
        // POST: /T_ClaimType/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeFacilityAssociationID,T_Name,SelectedT_EmployeeInjury_T_TypeofClaim")] T_ClaimType t_claimtype,string UrlReferrer)
        {
			CheckBeforeSave(t_claimtype);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_claimtype,out customsave_hasissues,"Save"))
            {
				db.Entry(t_claimtype).State = EntityState.Modified;
				db.SaveChanges();
            }
               bool flagT_TypeofClaim = false; 
				var dblistT_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id);
				 if (t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim != null)
                    dblistT_TypeofClaim = dblistT_TypeofClaim.Where(a => !t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim.Contains(a.T_EmployeeInjuryID));
                foreach (var obj in dblistT_TypeofClaim)
                {
					 db.T_TypeofClaims.Remove(obj);
					  flagT_TypeofClaim = true; 
				}
				if (flagT_TypeofClaim)
					db.SaveChanges();
				flagT_TypeofClaim = false;
				if (t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim !=null)
				{
					foreach (var pgs in t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim)
					{
						if (db.T_TypeofClaims.FirstOrDefault(a => a.T_ClaimTypeID == t_claimtype.Id && a.T_EmployeeInjuryID == pgs) == null)
                        {
							T_TypeofClaim objT_TypeofClaim = new T_TypeofClaim();
							objT_TypeofClaim.T_ClaimTypeID = t_claimtype.Id;
							objT_TypeofClaim.T_EmployeeInjuryID = pgs;
							db.Entry(objT_TypeofClaim).State = EntityState.Added;
							db.T_TypeofClaims.Add(objT_TypeofClaim);
							flagT_TypeofClaim = true;
						}
					}
					if (flagT_TypeofClaim)
						db.SaveChanges();
				 }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_claimtype,"Edit","");
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
		    t_claimtype.T_EmployeeInjury_T_TypeofClaim = db.T_EmployeeInjurys.OrderBy(c => c.DisplayValue).ToList();
            t_claimtype.SelectedT_EmployeeInjury_T_TypeofClaim = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_claimtype.Id).Select(p => p.T_EmployeeInjuryID).ToList();
			LoadViewDataAfterOnEdit(t_claimtype);
			ViewBag.T_ClaimTypeIsHiddenRule = checkHidden("T_ClaimType", "OnEdit", false);
			ViewBag.T_ClaimTypeIsGroupsHiddenRule = checkHidden("T_ClaimType", "OnEdit", true);
			ViewBag.T_ClaimTypeIsSetValueUIRule = checkSetValueUIRule("T_ClaimType", "OnEdit");
            return View(t_claimtype);
        }
        // GET: /T_ClaimType/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_ClaimType") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_ClaimType t_claimtype = db.T_ClaimTypes.Find(id);
            if (t_claimtype == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_ClaimTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClaimType"))
			 ViewData["T_ClaimTypeParentUrl"] = Request.UrlReferrer;
            return View(t_claimtype);
        }
        // POST: /T_ClaimType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_ClaimType t_claimtype, string UrlReferrer)
        {
			if (!User.CanDelete("T_ClaimType"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_claimtype))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_claimtype, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_claimtype).State = EntityState.Deleted;
            db.T_ClaimTypes.Remove(t_claimtype);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_ClaimTypeParentUrl"] != null)
					{
						string parentUrl = ViewData["T_ClaimTypeParentUrl"].ToString();
						ViewData["T_ClaimTypeParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_claimtype);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Facility" && AssociatedType == "T_ClaimTypeFacilityAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_ClaimType obj = db.T_ClaimTypes.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_ClaimTypeFacilityAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_ClaimType", User) || !User.CanDelete("T_ClaimType")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_ClaimType t_claimtype = db.T_ClaimTypes.Find(id);
		if (CheckBeforeDelete(t_claimtype))
        {
            if (!CustomDelete(t_claimtype, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_claimtype).State = EntityState.Deleted;
                db.T_ClaimTypes.Remove(t_claimtype);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_ClaimType", User) || !User.CanEdit("T_ClaimType") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_ClaimTypeParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeFacilityAssociationID,T_Name,SelectedT_EmployeeInjury_T_TypeofClaim")] T_ClaimType t_claimtype,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_ClaimType target = db.T_ClaimTypes.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_claimtype, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_claimtypefacilityassociation != null)
							  db.Entry(target.t_claimtypefacilityassociation).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_claimtype,"BulkUpdate","");
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
