﻿using System;
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

    public partial class T_UnitController : BaseController
    {
        // GET: /T_Unit/
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
			var lstT_Unit = from s in db.T_Units
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Unit = searchRecords(lstT_Unit, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Unit = sortRecords(lstT_Unit, sortBy, isAsc);
            }
            else lstT_Unit = lstT_Unit.OrderByDescending(c => c.Id);
			lstT_Unit = CustomSorting(lstT_Unit);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Unit"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Unit"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Unit"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Unit"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_Unit = lstT_Unit.Include(t=>t.t_facilityunit);
		 if (HostingEntity == "T_Facility" && AssociatedType == "T_FacilityUnit")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Unit = _T_Unit.Where(p => p.T_FacilityUnitID == hostid);
			 }
			 else
			     _T_Unit = _T_Unit.Where(p => p.T_FacilityUnitID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_Unit", User) || !User.CanView("T_Unit"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_Unit.Count() > 0)
                    pageSize = _T_Unit.Count();
                return View("ExcelExport", _T_Unit.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Unit.Count();
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
				var list = _T_Unit.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_UnitDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_Unitlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_Unit = _fad.FilterDropdown<T_Unit>(User,  _T_Unit, "T_Unit", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_Unit.Except(_T_Unit),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_Unit.Except(_T_Unit).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_Unit.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_Unit.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_Unit.Count() == 0 ? 1 : _T_Unit.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_Unit.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_UnitDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Unitlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_Unit.Count() == 0 ? 1 : _T_Unit.Count();
                            }
							var list = _T_Unit.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_UnitDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Unitlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_Unit/Details/5
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
            T_Unit t_unit = db.T_Units.Find(id);
            if (t_unit == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_unit);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_unit, AssociatedType);
            ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnDetails", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnDetails", true);
			ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnDetails");
			return View(ViewBag.TemplatesName,t_unit);
        }
        // GET: /T_Unit/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_Unit") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_UnitParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnCreate", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnCreate", true);
		  ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnCreate");
          return View();
        }
		// GET: /T_Unit/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_Unit") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_UnitParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnCreate", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnCreate", true);
			 ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnCreate");
            return View();
        }
		// POST: /T_Unit/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_FacilityUnitID,T_Name,T_Description")] T_Unit t_unit, string UrlReferrer)
        {
			CheckBeforeSave(t_unit);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_unit,out customcreate_hasissues,"Create"))
                {
                    db.T_Units.Add(t_unit);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_unit,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_unit);
			ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnCreate", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnCreate", true);
			ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnCreate");	
            return View(t_unit);
        }
		 // GET: /T_Unit/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_Unit") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_UnitParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnCreate", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnCreate", true);
			ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnCreate");
            return View();
        }
		  // POST: /T_Unit/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_FacilityUnitID,T_Name,T_Description")] T_Unit t_unit,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_unit);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_unit,out customcreate_hasissues,"Create"))
                {
                    db.T_Units.Add(t_unit);
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
			LoadViewDataAfterOnCreate(t_unit);
			ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnCreate", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnCreate", true);
			ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_unit, AssociatedEntity);
			return View(t_unit);
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
        // POST: /T_Unit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_FacilityUnitID,T_Name,T_Description")] T_Unit t_unit, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_unit, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_unit,out customcreate_hasissues,command))
                {
                    db.T_Units.Add(t_unit);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_unit,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_unit.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_unit);
			ViewData["T_UnitParentUrl"] = UrlReferrer;
			ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnCreate", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnCreate", true);
			ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnCreate");
            return View(t_unit);
        }
		// GET: /T_Unit/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Unit") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_Unit t_unit = db.T_Units.Find(id);
            if (t_unit == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_UnitParentUrl"] = UrlReferrer;
		if(ViewData["T_UnitParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Unit")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Unit/Edit/" + t_unit.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Unit/Create"))
			ViewData["T_UnitParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_unit);
		   ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnEdit", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnEdit", true);
		   ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnEdit");
		    var objT_Unit = new List<T_Unit>();
            ViewBag.T_UnitDD = new SelectList(objT_Unit, "ID", "DisplayValue"); 
          return View(t_unit);
        }
		// POST: /T_Unit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_FacilityUnitID,T_Name,T_Description")] T_Unit t_unit,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_unit, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_unit,out customsave_hasissues,command))
                {
					db.Entry(t_unit).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_unit);
			ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnEdit", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnEdit", true);
			ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnEdit");
            return View(t_unit);
        }
        // GET: /T_Unit/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_Unit") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Unit t_unit = db.T_Units.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Unitlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Units.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_UnitDisplayValueEdit = TempData["T_Unitlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Unitlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_UnitDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_unit == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_Unit/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_unit.DisplayValue, Value = t_unit.Id.ToString() }));
                ViewBag.EntityT_UnitDisplayValueEdit = newList;
				TempData["T_Unitlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_unit.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_unit.DisplayValue;
                    newList[0].Value = t_unit.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_unit.DisplayValue, Value = t_unit.Id.ToString() }));
                }
                ViewBag.EntityT_UnitDisplayValueEdit = newList;
				TempData["T_Unitlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_UnitParentUrl"] = UrlReferrer;
		if(ViewData["T_UnitParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Unit")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Unit/Edit/" + t_unit.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Unit/Create"))
			ViewData["T_UnitParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_unit);
		   ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnEdit", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnEdit", true);
		   ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnEdit");
          return View(t_unit);
        }
        // POST: /T_Unit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_FacilityUnitID,T_Name,T_Description")] T_Unit t_unit,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_unit, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_unit,out customsave_hasissues,command))
            {
				db.Entry(t_unit).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_unit,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_unit.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_Unitlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Units.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_UnitDisplayValueEdit = TempData["T_Unitlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Unitlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_UnitDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_unit);
			 ViewData["T_UnitParentUrl"] = UrlReferrer;
			ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnEdit", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnEdit", true);
			ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnEdit");
            return View(t_unit);
        }
		// GET: /T_Unit/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Unit") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_Unit t_unit = db.T_Units.Find(id);
            if (t_unit == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_UnitParentUrl"] = UrlReferrer;
		if(ViewData["T_UnitParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Unit"))
			ViewData["T_UnitParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_unit);
			 ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnEdit", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnEdit", true);
			 ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnEdit");
          return View(t_unit);
        }
        // POST: /T_Unit/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_FacilityUnitID,T_Name,T_Description")] T_Unit t_unit,string UrlReferrer)
        {
			CheckBeforeSave(t_unit);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_unit,out customsave_hasissues,"Save"))
            {
				db.Entry(t_unit).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_unit,"Edit","");
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
			LoadViewDataAfterOnEdit(t_unit);
			ViewBag.T_UnitIsHiddenRule = checkHidden("T_Unit", "OnEdit", false);
			ViewBag.T_UnitIsGroupsHiddenRule = checkHidden("T_Unit", "OnEdit", true);
			ViewBag.T_UnitIsSetValueUIRule = checkSetValueUIRule("T_Unit", "OnEdit");
            return View(t_unit);
        }
        // GET: /T_Unit/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_Unit") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_Unit t_unit = db.T_Units.Find(id);
            if (t_unit == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_UnitParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Unit"))
			 ViewData["T_UnitParentUrl"] = Request.UrlReferrer;
            return View(t_unit);
        }
        // POST: /T_Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_Unit t_unit, string UrlReferrer)
        {
			if (!User.CanDelete("T_Unit"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_unit))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_unit, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_unit).State = EntityState.Deleted;
            db.T_Units.Remove(t_unit);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_UnitParentUrl"] != null)
					{
						string parentUrl = ViewData["T_UnitParentUrl"].ToString();
						ViewData["T_UnitParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_unit);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Facility" && AssociatedType == "T_FacilityUnit")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Unit obj = db.T_Units.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_FacilityUnitID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_Unit", User) || !User.CanDelete("T_Unit")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_Unit t_unit = db.T_Units.Find(id);
		if (CheckBeforeDelete(t_unit))
        {
            if (!CustomDelete(t_unit, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_unit).State = EntityState.Deleted;
                db.T_Units.Remove(t_unit);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_Unit", User) || !User.CanEdit("T_Unit") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_UnitParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_FacilityUnitID,T_Name,T_Description")] T_Unit t_unit,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_Unit target = db.T_Units.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_unit, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_facilityunit != null)
							  db.Entry(target.t_facilityunit).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_unit,"BulkUpdate","");
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