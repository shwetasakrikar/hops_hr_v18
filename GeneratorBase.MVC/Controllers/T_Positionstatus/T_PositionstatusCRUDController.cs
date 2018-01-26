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

    public partial class T_PositionstatusController : BaseController
    {
        // GET: /T_Positionstatus/
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
			var lstT_Positionstatus = from s in db.T_Positionstatuss
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Positionstatus = searchRecords(lstT_Positionstatus, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Positionstatus = sortRecords(lstT_Positionstatus, sortBy, isAsc);
            }
            else lstT_Positionstatus = lstT_Positionstatus.OrderBy(c=>c.T_SortOrder);
			lstT_Positionstatus = CustomSorting(lstT_Positionstatus);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Positionstatus"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Positionstatus"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Positionstatus"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Positionstatus"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_Positionstatus = lstT_Positionstatus;
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_Positionstatus", User) || !User.CanView("T_Positionstatus"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_Positionstatus.Count() > 0)
                    pageSize = _T_Positionstatus.Count();
                return View("ExcelExport", _T_Positionstatus.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Positionstatus.Count();
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
				var list = _T_Positionstatus.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_PositionstatusDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_Positionstatuslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_Positionstatus = _fad.FilterDropdown<T_Positionstatus>(User,  _T_Positionstatus, "T_Positionstatus", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_Positionstatus.Except(_T_Positionstatus),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_Positionstatus.Except(_T_Positionstatus).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_Positionstatus.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_Positionstatus.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_Positionstatus.Count() == 0 ? 1 : _T_Positionstatus.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_Positionstatus.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_PositionstatusDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Positionstatuslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_Positionstatus.Count() == 0 ? 1 : _T_Positionstatus.Count();
                            }
							var list = _T_Positionstatus.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_PositionstatusDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Positionstatuslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_Positionstatus/Details/5
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
            T_Positionstatus t_positionstatus = db.T_Positionstatuss.Find(id);
            if (t_positionstatus == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_positionstatus);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_positionstatus, AssociatedType);
            ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnDetails", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnDetails", true);
			ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnDetails");
			return View(ViewBag.TemplatesName,t_positionstatus);
        }
        // GET: /T_Positionstatus/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_Positionstatus") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_PositionstatusParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", true);
		  ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnCreate");
          return View();
        }
		// GET: /T_Positionstatus/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_Positionstatus") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_PositionstatusParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", true);
			 ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnCreate");
            return View();
        }
		// POST: /T_Positionstatus/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_SortOrder,T_Description")] T_Positionstatus t_positionstatus, string UrlReferrer)
        {
			CheckBeforeSave(t_positionstatus);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_positionstatus,out customcreate_hasissues,"Create"))
                {
                    db.T_Positionstatuss.Add(t_positionstatus);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_positionstatus,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_positionstatus);
			ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", true);
			ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnCreate");	
            return View(t_positionstatus);
        }
		 // GET: /T_Positionstatus/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_Positionstatus") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_PositionstatusParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", true);
			ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnCreate");
            return View();
        }
		  // POST: /T_Positionstatus/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_SortOrder,T_Description")] T_Positionstatus t_positionstatus,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_positionstatus);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_positionstatus,out customcreate_hasissues,"Create"))
                {
                    db.T_Positionstatuss.Add(t_positionstatus);
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
			LoadViewDataAfterOnCreate(t_positionstatus);
			ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", true);
			ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_positionstatus, AssociatedEntity);
			return View(t_positionstatus);
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
        // POST: /T_Positionstatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name,T_SortOrder,T_Description")] T_Positionstatus t_positionstatus, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_positionstatus, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_positionstatus,out customcreate_hasissues,command))
                {
                    db.T_Positionstatuss.Add(t_positionstatus);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_positionstatus,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_positionstatus.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_positionstatus);
			ViewData["T_PositionstatusParentUrl"] = UrlReferrer;
			ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnCreate", true);
			ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnCreate");
            return View(t_positionstatus);
        }
		// GET: /T_Positionstatus/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Positionstatus") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_Positionstatus t_positionstatus = db.T_Positionstatuss.Find(id);
            if (t_positionstatus == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_PositionstatusParentUrl"] = UrlReferrer;
		if(ViewData["T_PositionstatusParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Positionstatus")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Positionstatus/Edit/" + t_positionstatus.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Positionstatus/Create"))
			ViewData["T_PositionstatusParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_positionstatus);
		   ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", true);
		   ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnEdit");
		    var objT_Positionstatus = new List<T_Positionstatus>();
            ViewBag.T_PositionstatusDD = new SelectList(objT_Positionstatus, "ID", "DisplayValue"); 
          return View(t_positionstatus);
        }
		// POST: /T_Positionstatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_SortOrder,T_Description")] T_Positionstatus t_positionstatus,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_positionstatus, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_positionstatus,out customsave_hasissues,command))
                {
					db.Entry(t_positionstatus).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_positionstatus);
			ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", true);
			ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnEdit");
            return View(t_positionstatus);
        }
        // GET: /T_Positionstatus/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_Positionstatus") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Positionstatus t_positionstatus = db.T_Positionstatuss.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Positionstatuslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Positionstatuss.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_PositionstatusDisplayValueEdit = TempData["T_Positionstatuslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Positionstatuslist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_PositionstatusDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_positionstatus == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_Positionstatus/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_positionstatus.DisplayValue, Value = t_positionstatus.Id.ToString() }));
                ViewBag.EntityT_PositionstatusDisplayValueEdit = newList;
				TempData["T_Positionstatuslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_positionstatus.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_positionstatus.DisplayValue;
                    newList[0].Value = t_positionstatus.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_positionstatus.DisplayValue, Value = t_positionstatus.Id.ToString() }));
                }
                ViewBag.EntityT_PositionstatusDisplayValueEdit = newList;
				TempData["T_Positionstatuslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_PositionstatusParentUrl"] = UrlReferrer;
		if(ViewData["T_PositionstatusParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Positionstatus")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Positionstatus/Edit/" + t_positionstatus.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Positionstatus/Create"))
			ViewData["T_PositionstatusParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_positionstatus);
		   ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", true);
		   ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnEdit");
          return View(t_positionstatus);
        }
        // POST: /T_Positionstatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name,T_SortOrder,T_Description")] T_Positionstatus t_positionstatus,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_positionstatus, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_positionstatus,out customsave_hasissues,command))
            {
				db.Entry(t_positionstatus).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_positionstatus,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_positionstatus.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_Positionstatuslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Positionstatuss.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_PositionstatusDisplayValueEdit = TempData["T_Positionstatuslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Positionstatuslist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_PositionstatusDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_positionstatus);
			 ViewData["T_PositionstatusParentUrl"] = UrlReferrer;
			ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", true);
			ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnEdit");
            return View(t_positionstatus);
        }
		// GET: /T_Positionstatus/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Positionstatus") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_Positionstatus t_positionstatus = db.T_Positionstatuss.Find(id);
            if (t_positionstatus == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_PositionstatusParentUrl"] = UrlReferrer;
		if(ViewData["T_PositionstatusParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Positionstatus"))
			ViewData["T_PositionstatusParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_positionstatus);
			 ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", true);
			 ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnEdit");
          return View(t_positionstatus);
        }
        // POST: /T_Positionstatus/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_SortOrder,T_Description")] T_Positionstatus t_positionstatus,string UrlReferrer)
        {
			CheckBeforeSave(t_positionstatus);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_positionstatus,out customsave_hasissues,"Save"))
            {
				db.Entry(t_positionstatus).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_positionstatus,"Edit","");
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
			LoadViewDataAfterOnEdit(t_positionstatus);
			ViewBag.T_PositionstatusIsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", false);
			ViewBag.T_PositionstatusIsGroupsHiddenRule = checkHidden("T_Positionstatus", "OnEdit", true);
			ViewBag.T_PositionstatusIsSetValueUIRule = checkSetValueUIRule("T_Positionstatus", "OnEdit");
            return View(t_positionstatus);
        }
        // GET: /T_Positionstatus/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_Positionstatus") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_Positionstatus t_positionstatus = db.T_Positionstatuss.Find(id);
            if (t_positionstatus == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_PositionstatusParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Positionstatus"))
			 ViewData["T_PositionstatusParentUrl"] = Request.UrlReferrer;
            return View(t_positionstatus);
        }
        // POST: /T_Positionstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_Positionstatus t_positionstatus, string UrlReferrer)
        {
			if (!User.CanDelete("T_Positionstatus"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_positionstatus))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_positionstatus, out customdelete_hasissues, "Delete"))
                {
            var listT_AssociatedPositionStatus = db.T_Positions.Where(p => p.T_AssociatedPositionStatusID == t_positionstatus.Id);
            foreach (var lst in listT_AssociatedPositionStatus)
               db.T_Positions.Remove(lst);
           db.SaveChanges();
			db.Entry(t_positionstatus).State = EntityState.Deleted;
            db.T_Positionstatuss.Remove(t_positionstatus);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_PositionstatusParentUrl"] != null)
					{
						string parentUrl = ViewData["T_PositionstatusParentUrl"].ToString();
						ViewData["T_PositionstatusParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_positionstatus);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_Positionstatus", User) || !User.CanDelete("T_Positionstatus")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_Positionstatus t_positionstatus = db.T_Positionstatuss.Find(id);
		if (CheckBeforeDelete(t_positionstatus))
        {
            if (!CustomDelete(t_positionstatus, out customdelete_hasissues, "DeleteBulk"))
            {
            var listT_AssociatedPositionStatus = db.T_Positions.Where(p => p.T_AssociatedPositionStatusID == id);
            foreach (var lst in listT_AssociatedPositionStatus)
               db.T_Positions.Remove(lst);
           db.SaveChanges();
                db.Entry(t_positionstatus).State = EntityState.Deleted;
                db.T_Positionstatuss.Remove(t_positionstatus);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_Positionstatus", User) || !User.CanEdit("T_Positionstatus") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_PositionstatusParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name,T_SortOrder,T_Description")] T_Positionstatus t_positionstatus,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_Positionstatus target = db.T_Positionstatuss.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_positionstatus, target, chkUpdate); 
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
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_positionstatus,"BulkUpdate","");
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