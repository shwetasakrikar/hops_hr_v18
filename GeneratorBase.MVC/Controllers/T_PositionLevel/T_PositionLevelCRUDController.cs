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
namespace GeneratorBase.MVC.Controllers
{

    public partial class T_PositionLevelController : BaseController
    {
        // GET: /T_PositionLevel/
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
			var lstT_PositionLevel = from s in db.T_PositionLevels
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_PositionLevel = searchRecords(lstT_PositionLevel, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_PositionLevel = sortRecords(lstT_PositionLevel, sortBy, isAsc);
            }
            else lstT_PositionLevel = lstT_PositionLevel.OrderByDescending(c => c.Id);
			lstT_PositionLevel = CustomSorting(lstT_PositionLevel);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_PositionLevel"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_PositionLevel"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_PositionLevel"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_PositionLevel"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_PositionLevel = lstT_PositionLevel;
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_PositionLevel", User) || !User.CanView("T_PositionLevel"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_PositionLevel.Count() > 0)
                    pageSize = _T_PositionLevel.Count();
                return View("ExcelExport", _T_PositionLevel.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_PositionLevel.Count();
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
				var list = _T_PositionLevel.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_PositionLevelDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_PositionLevellist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_PositionLevel = _fad.FilterDropdown<T_PositionLevel>(User,  _T_PositionLevel, "T_PositionLevel", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_PositionLevel.Except(_T_PositionLevel),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_PositionLevel.Except(_T_PositionLevel).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_PositionLevel.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_PositionLevel.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_PositionLevel.Count() == 0 ? 1 : _T_PositionLevel.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_PositionLevel.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_PositionLevelDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_PositionLevellist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_PositionLevel.Count() == 0 ? 1 : _T_PositionLevel.Count();
                            }
							var list = _T_PositionLevel.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_PositionLevelDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_PositionLevellist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_PositionLevel/Details/5
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
            T_PositionLevel t_positionlevel = db.T_PositionLevels.Find(id);
            if (t_positionlevel == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_positionlevel);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_positionlevel, AssociatedType);
            ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnDetails", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnDetails", true);
			ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnDetails");
			return View(ViewBag.TemplatesName,t_positionlevel);
        }
        // GET: /T_PositionLevel/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_PositionLevel") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_PositionLevelParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", true);
		  ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnCreate");
          return View();
        }
		// GET: /T_PositionLevel/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_PositionLevel") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_PositionLevelParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", true);
			 ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnCreate");
            return View();
        }
		// POST: /T_PositionLevel/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_PositionLevel t_positionlevel, string UrlReferrer)
        {
			CheckBeforeSave(t_positionlevel);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_positionlevel,out customcreate_hasissues,"Create"))
                {
                    db.T_PositionLevels.Add(t_positionlevel);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_positionlevel,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_positionlevel);
			ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", true);
			ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnCreate");	
            return View(t_positionlevel);
        }
		 // GET: /T_PositionLevel/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_PositionLevel") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_PositionLevelParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", true);
			ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnCreate");
            return View();
        }
		  // POST: /T_PositionLevel/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_PositionLevel t_positionlevel,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_positionlevel);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_positionlevel,out customcreate_hasissues,"Create"))
                {
                    db.T_PositionLevels.Add(t_positionlevel);
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
			LoadViewDataAfterOnCreate(t_positionlevel);
			ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", true);
			ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_positionlevel, AssociatedEntity);
			return View(t_positionlevel);
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
        // POST: /T_PositionLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_PositionLevel t_positionlevel, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_positionlevel, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_positionlevel,out customcreate_hasissues,command))
                {
                    db.T_PositionLevels.Add(t_positionlevel);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_positionlevel,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_positionlevel.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_positionlevel);
			ViewData["T_PositionLevelParentUrl"] = UrlReferrer;
			ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnCreate", true);
			ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnCreate");
            return View(t_positionlevel);
        }
		// GET: /T_PositionLevel/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_PositionLevel") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_PositionLevel t_positionlevel = db.T_PositionLevels.Find(id);
            if (t_positionlevel == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_PositionLevelParentUrl"] = UrlReferrer;
		if(ViewData["T_PositionLevelParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_PositionLevel")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_PositionLevel/Edit/" + t_positionlevel.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_PositionLevel/Create"))
			ViewData["T_PositionLevelParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_positionlevel);
		   ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", true);
		   ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnEdit");
		    var objT_PositionLevel = new List<T_PositionLevel>();
            ViewBag.T_PositionLevelDD = new SelectList(objT_PositionLevel, "ID", "DisplayValue"); 
          return View(t_positionlevel);
        }
		// POST: /T_PositionLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_PositionLevel t_positionlevel,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_positionlevel, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_positionlevel,out customsave_hasissues,command))
                {
					db.Entry(t_positionlevel).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_positionlevel);
			ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", true);
			ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnEdit");
            return View(t_positionlevel);
        }
        // GET: /T_PositionLevel/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_PositionLevel") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PositionLevel t_positionlevel = db.T_PositionLevels.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_PositionLevellist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_PositionLevels.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_PositionLevelDisplayValueEdit = TempData["T_PositionLevellist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_PositionLevellist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_PositionLevelDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_positionlevel == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_PositionLevel/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_positionlevel.DisplayValue, Value = t_positionlevel.Id.ToString() }));
                ViewBag.EntityT_PositionLevelDisplayValueEdit = newList;
				TempData["T_PositionLevellist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_positionlevel.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_positionlevel.DisplayValue;
                    newList[0].Value = t_positionlevel.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_positionlevel.DisplayValue, Value = t_positionlevel.Id.ToString() }));
                }
                ViewBag.EntityT_PositionLevelDisplayValueEdit = newList;
				TempData["T_PositionLevellist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_PositionLevelParentUrl"] = UrlReferrer;
		if(ViewData["T_PositionLevelParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_PositionLevel")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_PositionLevel/Edit/" + t_positionlevel.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_PositionLevel/Create"))
			ViewData["T_PositionLevelParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_positionlevel);
		   ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", true);
		   ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnEdit");
          return View(t_positionlevel);
        }
        // POST: /T_PositionLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_PositionLevel t_positionlevel,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_positionlevel, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_positionlevel,out customsave_hasissues,command))
            {
				db.Entry(t_positionlevel).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_positionlevel,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_positionlevel.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_PositionLevellist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_PositionLevels.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_PositionLevelDisplayValueEdit = TempData["T_PositionLevellist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_PositionLevellist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_PositionLevelDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_positionlevel);
			 ViewData["T_PositionLevelParentUrl"] = UrlReferrer;
			ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", true);
			ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnEdit");
            return View(t_positionlevel);
        }
		// GET: /T_PositionLevel/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_PositionLevel") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_PositionLevel t_positionlevel = db.T_PositionLevels.Find(id);
            if (t_positionlevel == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_PositionLevelParentUrl"] = UrlReferrer;
		if(ViewData["T_PositionLevelParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_PositionLevel"))
			ViewData["T_PositionLevelParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_positionlevel);
			 ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", true);
			 ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnEdit");
          return View(t_positionlevel);
        }
        // POST: /T_PositionLevel/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_PositionLevel t_positionlevel,string UrlReferrer)
        {
			CheckBeforeSave(t_positionlevel);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_positionlevel,out customsave_hasissues,"Save"))
            {
				db.Entry(t_positionlevel).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_positionlevel,"Edit","");
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
			LoadViewDataAfterOnEdit(t_positionlevel);
			ViewBag.T_PositionLevelIsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", false);
			ViewBag.T_PositionLevelIsGroupsHiddenRule = checkHidden("T_PositionLevel", "OnEdit", true);
			ViewBag.T_PositionLevelIsSetValueUIRule = checkSetValueUIRule("T_PositionLevel", "OnEdit");
            return View(t_positionlevel);
        }
        // GET: /T_PositionLevel/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_PositionLevel") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_PositionLevel t_positionlevel = db.T_PositionLevels.Find(id);
            if (t_positionlevel == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_PositionLevelParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_PositionLevel"))
			 ViewData["T_PositionLevelParentUrl"] = Request.UrlReferrer;
            return View(t_positionlevel);
        }
        // POST: /T_PositionLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_PositionLevel t_positionlevel, string UrlReferrer)
        {
			if (!User.CanDelete("T_PositionLevel"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_positionlevel))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_positionlevel, out customdelete_hasissues, "Delete"))
                {
            var listT_PositionIdentifier = db.T_Positions.Where(p => p.T_PositionIdentifierID == t_positionlevel.Id);
            foreach (var lst in listT_PositionIdentifier)
               db.T_Positions.Remove(lst);
           db.SaveChanges();
			db.Entry(t_positionlevel).State = EntityState.Deleted;
            db.T_PositionLevels.Remove(t_positionlevel);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_PositionLevelParentUrl"] != null)
					{
						string parentUrl = ViewData["T_PositionLevelParentUrl"].ToString();
						ViewData["T_PositionLevelParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_positionlevel);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_PositionLevel", User) || !User.CanDelete("T_PositionLevel")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_PositionLevel t_positionlevel = db.T_PositionLevels.Find(id);
		if (CheckBeforeDelete(t_positionlevel))
        {
            if (!CustomDelete(t_positionlevel, out customdelete_hasissues, "DeleteBulk"))
            {
            var listT_PositionIdentifier = db.T_Positions.Where(p => p.T_PositionIdentifierID == id);
            foreach (var lst in listT_PositionIdentifier)
               db.T_Positions.Remove(lst);
           db.SaveChanges();
                db.Entry(t_positionlevel).State = EntityState.Deleted;
                db.T_PositionLevels.Remove(t_positionlevel);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_PositionLevel", User) || !User.CanEdit("T_PositionLevel") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_PositionLevelParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_PositionLevel t_positionlevel,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_PositionLevel target = db.T_PositionLevels.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_positionlevel, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_positionlevel,"BulkUpdate","");
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
