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

    public partial class T_InitialTreatmentController : BaseController
    {
        // GET: /T_InitialTreatment/
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
			var lstT_InitialTreatment = from s in db.T_InitialTreatments
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_InitialTreatment = searchRecords(lstT_InitialTreatment, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_InitialTreatment = sortRecords(lstT_InitialTreatment, sortBy, isAsc);
            }
            else lstT_InitialTreatment = lstT_InitialTreatment.OrderByDescending(c => c.Id);
			lstT_InitialTreatment = CustomSorting(lstT_InitialTreatment);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_InitialTreatment"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_InitialTreatment"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_InitialTreatment"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_InitialTreatment"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_InitialTreatment = lstT_InitialTreatment;
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_InitialTreatment", User) || !User.CanView("T_InitialTreatment"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_InitialTreatment.Count() > 0)
                    pageSize = _T_InitialTreatment.Count();
                return View("ExcelExport", _T_InitialTreatment.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_InitialTreatment.Count();
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
				var list = _T_InitialTreatment.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_InitialTreatmentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_InitialTreatmentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_InitialTreatment = _fad.FilterDropdown<T_InitialTreatment>(User,  _T_InitialTreatment, "T_InitialTreatment", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_InitialTreatment.Except(_T_InitialTreatment),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_InitialTreatment.Except(_T_InitialTreatment).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_InitialTreatment.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_InitialTreatment.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_InitialTreatment.Count() == 0 ? 1 : _T_InitialTreatment.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_InitialTreatment.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_InitialTreatmentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_InitialTreatmentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_InitialTreatment.Count() == 0 ? 1 : _T_InitialTreatment.Count();
                            }
							var list = _T_InitialTreatment.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_InitialTreatmentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_InitialTreatmentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_InitialTreatment/Details/5
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
            T_InitialTreatment t_initialtreatment = db.T_InitialTreatments.Find(id);
            if (t_initialtreatment == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_initialtreatment);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_initialtreatment, AssociatedType);
            ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnDetails", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnDetails", true);
			ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnDetails");
			return View(ViewBag.TemplatesName,t_initialtreatment);
        }
        // GET: /T_InitialTreatment/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_InitialTreatment") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_InitialTreatmentParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", true);
		  ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnCreate");
          return View();
        }
		// GET: /T_InitialTreatment/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_InitialTreatment") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_InitialTreatmentParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", true);
			 ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnCreate");
            return View();
        }
		// POST: /T_InitialTreatment/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_InitialTreatment t_initialtreatment, string UrlReferrer)
        {
			CheckBeforeSave(t_initialtreatment);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_initialtreatment,out customcreate_hasissues,"Create"))
                {
                    db.T_InitialTreatments.Add(t_initialtreatment);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_initialtreatment,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_initialtreatment);
			ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", true);
			ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnCreate");	
            return View(t_initialtreatment);
        }
		 // GET: /T_InitialTreatment/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_InitialTreatment") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_InitialTreatmentParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", true);
			ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnCreate");
            return View();
        }
		  // POST: /T_InitialTreatment/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_InitialTreatment t_initialtreatment,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_initialtreatment);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_initialtreatment,out customcreate_hasissues,"Create"))
                {
                    db.T_InitialTreatments.Add(t_initialtreatment);
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
			LoadViewDataAfterOnCreate(t_initialtreatment);
			ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", true);
			ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_initialtreatment, AssociatedEntity);
			return View(t_initialtreatment);
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
        // POST: /T_InitialTreatment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_InitialTreatment t_initialtreatment, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_initialtreatment, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_initialtreatment,out customcreate_hasissues,command))
                {
                    db.T_InitialTreatments.Add(t_initialtreatment);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_initialtreatment,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_initialtreatment.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_initialtreatment);
			ViewData["T_InitialTreatmentParentUrl"] = UrlReferrer;
			ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnCreate", true);
			ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnCreate");
            return View(t_initialtreatment);
        }
		// GET: /T_InitialTreatment/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_InitialTreatment") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_InitialTreatment t_initialtreatment = db.T_InitialTreatments.Find(id);
            if (t_initialtreatment == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_InitialTreatmentParentUrl"] = UrlReferrer;
		if(ViewData["T_InitialTreatmentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_InitialTreatment")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_InitialTreatment/Edit/" + t_initialtreatment.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_InitialTreatment/Create"))
			ViewData["T_InitialTreatmentParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_initialtreatment);
		   ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", true);
		   ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnEdit");
		    var objT_InitialTreatment = new List<T_InitialTreatment>();
            ViewBag.T_InitialTreatmentDD = new SelectList(objT_InitialTreatment, "ID", "DisplayValue"); 
          return View(t_initialtreatment);
        }
		// POST: /T_InitialTreatment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_InitialTreatment t_initialtreatment,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_initialtreatment, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_initialtreatment,out customsave_hasissues,command))
                {
					db.Entry(t_initialtreatment).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_initialtreatment);
			ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", true);
			ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnEdit");
            return View(t_initialtreatment);
        }
        // GET: /T_InitialTreatment/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_InitialTreatment") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_InitialTreatment t_initialtreatment = db.T_InitialTreatments.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_InitialTreatmentlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_InitialTreatments.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_InitialTreatmentDisplayValueEdit = TempData["T_InitialTreatmentlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_InitialTreatmentlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_InitialTreatmentDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_initialtreatment == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_InitialTreatment/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_initialtreatment.DisplayValue, Value = t_initialtreatment.Id.ToString() }));
                ViewBag.EntityT_InitialTreatmentDisplayValueEdit = newList;
				TempData["T_InitialTreatmentlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_initialtreatment.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_initialtreatment.DisplayValue;
                    newList[0].Value = t_initialtreatment.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_initialtreatment.DisplayValue, Value = t_initialtreatment.Id.ToString() }));
                }
                ViewBag.EntityT_InitialTreatmentDisplayValueEdit = newList;
				TempData["T_InitialTreatmentlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_InitialTreatmentParentUrl"] = UrlReferrer;
		if(ViewData["T_InitialTreatmentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_InitialTreatment")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_InitialTreatment/Edit/" + t_initialtreatment.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_InitialTreatment/Create"))
			ViewData["T_InitialTreatmentParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_initialtreatment);
		   ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", true);
		   ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnEdit");
          return View(t_initialtreatment);
        }
        // POST: /T_InitialTreatment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_InitialTreatment t_initialtreatment,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_initialtreatment, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_initialtreatment,out customsave_hasissues,command))
            {
				db.Entry(t_initialtreatment).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_initialtreatment,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_initialtreatment.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_InitialTreatmentlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_InitialTreatments.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_InitialTreatmentDisplayValueEdit = TempData["T_InitialTreatmentlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_InitialTreatmentlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_InitialTreatmentDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_initialtreatment);
			 ViewData["T_InitialTreatmentParentUrl"] = UrlReferrer;
			ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", true);
			ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnEdit");
            return View(t_initialtreatment);
        }
		// GET: /T_InitialTreatment/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_InitialTreatment") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_InitialTreatment t_initialtreatment = db.T_InitialTreatments.Find(id);
            if (t_initialtreatment == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_InitialTreatmentParentUrl"] = UrlReferrer;
		if(ViewData["T_InitialTreatmentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_InitialTreatment"))
			ViewData["T_InitialTreatmentParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_initialtreatment);
			 ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", true);
			 ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnEdit");
          return View(t_initialtreatment);
        }
        // POST: /T_InitialTreatment/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_InitialTreatment t_initialtreatment,string UrlReferrer)
        {
			CheckBeforeSave(t_initialtreatment);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_initialtreatment,out customsave_hasissues,"Save"))
            {
				db.Entry(t_initialtreatment).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_initialtreatment,"Edit","");
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
			LoadViewDataAfterOnEdit(t_initialtreatment);
			ViewBag.T_InitialTreatmentIsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", false);
			ViewBag.T_InitialTreatmentIsGroupsHiddenRule = checkHidden("T_InitialTreatment", "OnEdit", true);
			ViewBag.T_InitialTreatmentIsSetValueUIRule = checkSetValueUIRule("T_InitialTreatment", "OnEdit");
            return View(t_initialtreatment);
        }
        // GET: /T_InitialTreatment/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_InitialTreatment") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_InitialTreatment t_initialtreatment = db.T_InitialTreatments.Find(id);
            if (t_initialtreatment == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_InitialTreatmentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_InitialTreatment"))
			 ViewData["T_InitialTreatmentParentUrl"] = Request.UrlReferrer;
            return View(t_initialtreatment);
        }
        // POST: /T_InitialTreatment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_InitialTreatment t_initialtreatment, string UrlReferrer)
        {
			if (!User.CanDelete("T_InitialTreatment"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_initialtreatment))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_initialtreatment, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_initialtreatment).State = EntityState.Deleted;
            db.T_InitialTreatments.Remove(t_initialtreatment);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_InitialTreatmentParentUrl"] != null)
					{
						string parentUrl = ViewData["T_InitialTreatmentParentUrl"].ToString();
						ViewData["T_InitialTreatmentParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_initialtreatment);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_InitialTreatment", User) || !User.CanDelete("T_InitialTreatment")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_InitialTreatment t_initialtreatment = db.T_InitialTreatments.Find(id);
		if (CheckBeforeDelete(t_initialtreatment))
        {
            if (!CustomDelete(t_initialtreatment, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_initialtreatment).State = EntityState.Deleted;
                db.T_InitialTreatments.Remove(t_initialtreatment);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_InitialTreatment", User) || !User.CanEdit("T_InitialTreatment") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_InitialTreatmentParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_InitialTreatment t_initialtreatment,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_InitialTreatment target = db.T_InitialTreatments.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_initialtreatment, target, chkUpdate); 
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
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_initialtreatment,"BulkUpdate","");
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
