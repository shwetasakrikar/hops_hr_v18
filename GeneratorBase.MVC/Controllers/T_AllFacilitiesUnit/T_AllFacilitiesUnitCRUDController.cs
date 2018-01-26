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

    public partial class T_AllFacilitiesUnitController : BaseController
    {
        // GET: /T_AllFacilitiesUnit/
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
			var lstT_AllFacilitiesUnit = from s in db.T_AllFacilitiesUnits
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_AllFacilitiesUnit = searchRecords(lstT_AllFacilitiesUnit, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_AllFacilitiesUnit = sortRecords(lstT_AllFacilitiesUnit, sortBy, isAsc);
            }
            else lstT_AllFacilitiesUnit = lstT_AllFacilitiesUnit.OrderByDescending(c => c.Id);
			lstT_AllFacilitiesUnit = CustomSorting(lstT_AllFacilitiesUnit);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_AllFacilitiesUnit"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_AllFacilitiesUnit"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_AllFacilitiesUnit"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_AllFacilitiesUnit"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_AllFacilitiesUnit = lstT_AllFacilitiesUnit.Include(t=>t.t_unitsforallfacilties);
		 if (HostingEntity == "T_AllFacilities" && AssociatedType == "T_UnitsforAllFacilties")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_AllFacilitiesUnit = _T_AllFacilitiesUnit.Where(p => p.T_UnitsforAllFaciltiesID == hostid);
			 }
			 else
			     _T_AllFacilitiesUnit = _T_AllFacilitiesUnit.Where(p => p.T_UnitsforAllFaciltiesID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_AllFacilitiesUnit", User) || !User.CanView("T_AllFacilitiesUnit"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_AllFacilitiesUnit.Count() > 0)
                    pageSize = _T_AllFacilitiesUnit.Count();
                return View("ExcelExport", _T_AllFacilitiesUnit.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_AllFacilitiesUnit.Count();
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
				var list = _T_AllFacilitiesUnit.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_AllFacilitiesUnitDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_AllFacilitiesUnitlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_AllFacilitiesUnit = _fad.FilterDropdown<T_AllFacilitiesUnit>(User,  _T_AllFacilitiesUnit, "T_AllFacilitiesUnit", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_AllFacilitiesUnit.Except(_T_AllFacilitiesUnit),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_AllFacilitiesUnit.Except(_T_AllFacilitiesUnit).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_AllFacilitiesUnit.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_AllFacilitiesUnit.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_AllFacilitiesUnit.Count() == 0 ? 1 : _T_AllFacilitiesUnit.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_AllFacilitiesUnit.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_AllFacilitiesUnitDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_AllFacilitiesUnitlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_AllFacilitiesUnit.Count() == 0 ? 1 : _T_AllFacilitiesUnit.Count();
                            }
							var list = _T_AllFacilitiesUnit.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_AllFacilitiesUnitDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_AllFacilitiesUnitlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_AllFacilitiesUnit/Details/5
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
            T_AllFacilitiesUnit t_allfacilitiesunit = db.T_AllFacilitiesUnits.Find(id);
            if (t_allfacilitiesunit == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_allfacilitiesunit);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_allfacilitiesunit, AssociatedType);
            ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnDetails", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnDetails", true);
			ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnDetails");
			return View(ViewBag.TemplatesName,t_allfacilitiesunit);
        }
        // GET: /T_AllFacilitiesUnit/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_AllFacilitiesUnit") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_AllFacilitiesUnitParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", true);
		  ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnCreate");
          return View();
        }
		// GET: /T_AllFacilitiesUnit/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_AllFacilitiesUnit") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_AllFacilitiesUnitParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", true);
			 ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnCreate");
            return View();
        }
		// POST: /T_AllFacilitiesUnit/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_UnitsforAllFaciltiesID")] T_AllFacilitiesUnit t_allfacilitiesunit, string UrlReferrer)
        {
			CheckBeforeSave(t_allfacilitiesunit);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_allfacilitiesunit,out customcreate_hasissues,"Create"))
                {
                    db.T_AllFacilitiesUnits.Add(t_allfacilitiesunit);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_allfacilitiesunit,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_allfacilitiesunit);
			ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", true);
			ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnCreate");	
            return View(t_allfacilitiesunit);
        }
		 // GET: /T_AllFacilitiesUnit/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_AllFacilitiesUnit") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_AllFacilitiesUnitParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", true);
			ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnCreate");
            return View();
        }
		  // POST: /T_AllFacilitiesUnit/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_UnitsforAllFaciltiesID")] T_AllFacilitiesUnit t_allfacilitiesunit,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_allfacilitiesunit);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_allfacilitiesunit,out customcreate_hasissues,"Create"))
                {
                    db.T_AllFacilitiesUnits.Add(t_allfacilitiesunit);
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
			LoadViewDataAfterOnCreate(t_allfacilitiesunit);
			ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", true);
			ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_allfacilitiesunit, AssociatedEntity);
			return View(t_allfacilitiesunit);
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
        // POST: /T_AllFacilitiesUnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_UnitsforAllFaciltiesID")] T_AllFacilitiesUnit t_allfacilitiesunit, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_allfacilitiesunit, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_allfacilitiesunit,out customcreate_hasissues,command))
                {
                    db.T_AllFacilitiesUnits.Add(t_allfacilitiesunit);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_allfacilitiesunit,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_allfacilitiesunit.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_allfacilitiesunit);
			ViewData["T_AllFacilitiesUnitParentUrl"] = UrlReferrer;
			ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnCreate", true);
			ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnCreate");
            return View(t_allfacilitiesunit);
        }
		// GET: /T_AllFacilitiesUnit/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_AllFacilitiesUnit") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_AllFacilitiesUnit t_allfacilitiesunit = db.T_AllFacilitiesUnits.Find(id);
            if (t_allfacilitiesunit == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_AllFacilitiesUnitParentUrl"] = UrlReferrer;
		if(ViewData["T_AllFacilitiesUnitParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_AllFacilitiesUnit")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_AllFacilitiesUnit/Edit/" + t_allfacilitiesunit.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_AllFacilitiesUnit/Create"))
			ViewData["T_AllFacilitiesUnitParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_allfacilitiesunit);
		   ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", true);
		   ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnEdit");
		    var objT_AllFacilitiesUnit = new List<T_AllFacilitiesUnit>();
            ViewBag.T_AllFacilitiesUnitDD = new SelectList(objT_AllFacilitiesUnit, "ID", "DisplayValue"); 
          return View(t_allfacilitiesunit);
        }
		// POST: /T_AllFacilitiesUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_UnitsforAllFaciltiesID")] T_AllFacilitiesUnit t_allfacilitiesunit,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_allfacilitiesunit, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_allfacilitiesunit,out customsave_hasissues,command))
                {
					db.Entry(t_allfacilitiesunit).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_allfacilitiesunit);
			ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", true);
			ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnEdit");
            return View(t_allfacilitiesunit);
        }
        // GET: /T_AllFacilitiesUnit/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_AllFacilitiesUnit") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_AllFacilitiesUnit t_allfacilitiesunit = db.T_AllFacilitiesUnits.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_AllFacilitiesUnitlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_AllFacilitiesUnits.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_AllFacilitiesUnitDisplayValueEdit = TempData["T_AllFacilitiesUnitlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_AllFacilitiesUnitlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_AllFacilitiesUnitDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_allfacilitiesunit == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_AllFacilitiesUnit/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_allfacilitiesunit.DisplayValue, Value = t_allfacilitiesunit.Id.ToString() }));
                ViewBag.EntityT_AllFacilitiesUnitDisplayValueEdit = newList;
				TempData["T_AllFacilitiesUnitlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_allfacilitiesunit.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_allfacilitiesunit.DisplayValue;
                    newList[0].Value = t_allfacilitiesunit.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_allfacilitiesunit.DisplayValue, Value = t_allfacilitiesunit.Id.ToString() }));
                }
                ViewBag.EntityT_AllFacilitiesUnitDisplayValueEdit = newList;
				TempData["T_AllFacilitiesUnitlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_AllFacilitiesUnitParentUrl"] = UrlReferrer;
		if(ViewData["T_AllFacilitiesUnitParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_AllFacilitiesUnit")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_AllFacilitiesUnit/Edit/" + t_allfacilitiesunit.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_AllFacilitiesUnit/Create"))
			ViewData["T_AllFacilitiesUnitParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_allfacilitiesunit);
		   ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", true);
		   ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnEdit");
          return View(t_allfacilitiesunit);
        }
        // POST: /T_AllFacilitiesUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_UnitsforAllFaciltiesID")] T_AllFacilitiesUnit t_allfacilitiesunit,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_allfacilitiesunit, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_allfacilitiesunit,out customsave_hasissues,command))
            {
				db.Entry(t_allfacilitiesunit).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_allfacilitiesunit,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_allfacilitiesunit.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_AllFacilitiesUnitlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_AllFacilitiesUnits.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_AllFacilitiesUnitDisplayValueEdit = TempData["T_AllFacilitiesUnitlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_AllFacilitiesUnitlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_AllFacilitiesUnitDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_allfacilitiesunit);
			 ViewData["T_AllFacilitiesUnitParentUrl"] = UrlReferrer;
			ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", true);
			ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnEdit");
            return View(t_allfacilitiesunit);
        }
		// GET: /T_AllFacilitiesUnit/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_AllFacilitiesUnit") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_AllFacilitiesUnit t_allfacilitiesunit = db.T_AllFacilitiesUnits.Find(id);
            if (t_allfacilitiesunit == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_AllFacilitiesUnitParentUrl"] = UrlReferrer;
		if(ViewData["T_AllFacilitiesUnitParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_AllFacilitiesUnit"))
			ViewData["T_AllFacilitiesUnitParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_allfacilitiesunit);
			 ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", true);
			 ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnEdit");
          return View(t_allfacilitiesunit);
        }
        // POST: /T_AllFacilitiesUnit/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_UnitsforAllFaciltiesID")] T_AllFacilitiesUnit t_allfacilitiesunit,string UrlReferrer)
        {
			CheckBeforeSave(t_allfacilitiesunit);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_allfacilitiesunit,out customsave_hasissues,"Save"))
            {
				db.Entry(t_allfacilitiesunit).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_allfacilitiesunit,"Edit","");
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
			LoadViewDataAfterOnEdit(t_allfacilitiesunit);
			ViewBag.T_AllFacilitiesUnitIsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", false);
			ViewBag.T_AllFacilitiesUnitIsGroupsHiddenRule = checkHidden("T_AllFacilitiesUnit", "OnEdit", true);
			ViewBag.T_AllFacilitiesUnitIsSetValueUIRule = checkSetValueUIRule("T_AllFacilitiesUnit", "OnEdit");
            return View(t_allfacilitiesunit);
        }
        // GET: /T_AllFacilitiesUnit/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_AllFacilitiesUnit") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_AllFacilitiesUnit t_allfacilitiesunit = db.T_AllFacilitiesUnits.Find(id);
            if (t_allfacilitiesunit == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_AllFacilitiesUnitParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_AllFacilitiesUnit"))
			 ViewData["T_AllFacilitiesUnitParentUrl"] = Request.UrlReferrer;
            return View(t_allfacilitiesunit);
        }
        // POST: /T_AllFacilitiesUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_AllFacilitiesUnit t_allfacilitiesunit, string UrlReferrer)
        {
			if (!User.CanDelete("T_AllFacilitiesUnit"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_allfacilitiesunit))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_allfacilitiesunit, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_allfacilitiesunit).State = EntityState.Deleted;
            db.T_AllFacilitiesUnits.Remove(t_allfacilitiesunit);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_AllFacilitiesUnitParentUrl"] != null)
					{
						string parentUrl = ViewData["T_AllFacilitiesUnitParentUrl"].ToString();
						ViewData["T_AllFacilitiesUnitParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_allfacilitiesunit);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_AllFacilities" && AssociatedType == "T_UnitsforAllFacilties")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_AllFacilitiesUnit obj = db.T_AllFacilitiesUnits.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_UnitsforAllFaciltiesID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_AllFacilitiesUnit", User) || !User.CanDelete("T_AllFacilitiesUnit")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_AllFacilitiesUnit t_allfacilitiesunit = db.T_AllFacilitiesUnits.Find(id);
		if (CheckBeforeDelete(t_allfacilitiesunit))
        {
            if (!CustomDelete(t_allfacilitiesunit, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_allfacilitiesunit).State = EntityState.Deleted;
                db.T_AllFacilitiesUnits.Remove(t_allfacilitiesunit);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_AllFacilitiesUnit", User) || !User.CanEdit("T_AllFacilitiesUnit") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_AllFacilitiesUnitParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_UnitsforAllFaciltiesID")] T_AllFacilitiesUnit t_allfacilitiesunit,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_AllFacilitiesUnit target = db.T_AllFacilitiesUnits.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_allfacilitiesunit, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_unitsforallfacilties != null)
							  db.Entry(target.t_unitsforallfacilties).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_allfacilitiesunit,"BulkUpdate","");
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
