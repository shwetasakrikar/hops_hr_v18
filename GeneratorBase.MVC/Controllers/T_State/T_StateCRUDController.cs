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

    public partial class T_StateController : BaseController
    {
        // GET: /T_State/
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
			var lstT_State = from s in db.T_States
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_State = searchRecords(lstT_State, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_State = sortRecords(lstT_State, sortBy, isAsc);
            }
            else lstT_State = lstT_State.OrderByDescending(c => c.Id);
			lstT_State = CustomSorting(lstT_State);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_State"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_State"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_State"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_State"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_State = lstT_State.Include(t=>t.t_statecountry);
		 if (HostingEntity == "T_Country" && AssociatedType == "T_StateCountry")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_State = _T_State.Where(p => p.T_StateCountryID == hostid);
			 }
			 else
			     _T_State = _T_State.Where(p => p.T_StateCountryID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_State", User) || !User.CanView("T_State"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_State.Count() > 0)
                    pageSize = _T_State.Count();
                return View("ExcelExport", _T_State.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_State.Count();
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
				var list = _T_State.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_StateDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_Statelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_State = _fad.FilterDropdown<T_State>(User,  _T_State, "T_State", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_State.Except(_T_State),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_State.Except(_T_State).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_State.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_State.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_State.Count() == 0 ? 1 : _T_State.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_State.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_StateDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Statelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_State.Count() == 0 ? 1 : _T_State.Count();
                            }
							var list = _T_State.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_StateDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Statelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_State/Details/5
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
            T_State t_state = db.T_States.Find(id);
            if (t_state == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_state);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_state, AssociatedType);
            ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnDetails", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnDetails", true);
			ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnDetails");
			return View(ViewBag.TemplatesName,t_state);
        }
        // GET: /T_State/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_State") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_StateParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnCreate", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnCreate", true);
		  ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnCreate");
          return View();
        }
		// GET: /T_State/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_State") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_StateParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnCreate", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnCreate", true);
			 ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnCreate");
            return View();
        }
		// POST: /T_State/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_StateCountryID")] T_State t_state, string UrlReferrer)
        {
			CheckBeforeSave(t_state);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_state,out customcreate_hasissues,"Create"))
                {
                    db.T_States.Add(t_state);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_state,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_state);
			ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnCreate", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnCreate", true);
			ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnCreate");	
            return View(t_state);
        }
		 // GET: /T_State/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_State") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_StateParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnCreate", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnCreate", true);
			ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnCreate");
            return View();
        }
		  // POST: /T_State/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_StateCountryID")] T_State t_state,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_state);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_state,out customcreate_hasissues,"Create"))
                {
                    db.T_States.Add(t_state);
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
			LoadViewDataAfterOnCreate(t_state);
			ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnCreate", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnCreate", true);
			ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_state, AssociatedEntity);
			return View(t_state);
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
        // POST: /T_State/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_StateCountryID")] T_State t_state, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_state, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_state,out customcreate_hasissues,command))
                {
                    db.T_States.Add(t_state);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_state,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_state.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_state);
			ViewData["T_StateParentUrl"] = UrlReferrer;
			ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnCreate", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnCreate", true);
			ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnCreate");
            return View(t_state);
        }
		// GET: /T_State/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_State") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_State t_state = db.T_States.Find(id);
            if (t_state == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_StateParentUrl"] = UrlReferrer;
		if(ViewData["T_StateParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_State")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_State/Edit/" + t_state.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_State/Create"))
			ViewData["T_StateParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_state);
		   ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnEdit", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnEdit", true);
		   ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnEdit");
		    var objT_State = new List<T_State>();
            ViewBag.T_StateDD = new SelectList(objT_State, "ID", "DisplayValue"); 
          return View(t_state);
        }
		// POST: /T_State/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_StateCountryID")] T_State t_state,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_state, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_state,out customsave_hasissues,command))
                {
					db.Entry(t_state).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_state);
			ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnEdit", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnEdit", true);
			ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnEdit");
            return View(t_state);
        }
        // GET: /T_State/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_State") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_State t_state = db.T_States.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Statelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_States.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_StateDisplayValueEdit = TempData["T_Statelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Statelist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_StateDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_state == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_State/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_state.DisplayValue, Value = t_state.Id.ToString() }));
                ViewBag.EntityT_StateDisplayValueEdit = newList;
				TempData["T_Statelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_state.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_state.DisplayValue;
                    newList[0].Value = t_state.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_state.DisplayValue, Value = t_state.Id.ToString() }));
                }
                ViewBag.EntityT_StateDisplayValueEdit = newList;
				TempData["T_Statelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_StateParentUrl"] = UrlReferrer;
		if(ViewData["T_StateParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_State")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_State/Edit/" + t_state.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_State/Create"))
			ViewData["T_StateParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_state);
		   ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnEdit", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnEdit", true);
		   ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnEdit");
          return View(t_state);
        }
        // POST: /T_State/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_StateCountryID")] T_State t_state,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_state, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_state,out customsave_hasissues,command))
            {
				db.Entry(t_state).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_state,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_state.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_Statelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_States.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_StateDisplayValueEdit = TempData["T_Statelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Statelist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_StateDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_state);
			 ViewData["T_StateParentUrl"] = UrlReferrer;
			ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnEdit", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnEdit", true);
			ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnEdit");
            return View(t_state);
        }
		// GET: /T_State/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_State") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_State t_state = db.T_States.Find(id);
            if (t_state == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_StateParentUrl"] = UrlReferrer;
		if(ViewData["T_StateParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_State"))
			ViewData["T_StateParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_state);
			 ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnEdit", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnEdit", true);
			 ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnEdit");
          return View(t_state);
        }
        // POST: /T_State/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_StateCountryID")] T_State t_state,string UrlReferrer)
        {
			CheckBeforeSave(t_state);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_state,out customsave_hasissues,"Save"))
            {
				db.Entry(t_state).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_state,"Edit","");
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
			LoadViewDataAfterOnEdit(t_state);
			ViewBag.T_StateIsHiddenRule = checkHidden("T_State", "OnEdit", false);
			ViewBag.T_StateIsGroupsHiddenRule = checkHidden("T_State", "OnEdit", true);
			ViewBag.T_StateIsSetValueUIRule = checkSetValueUIRule("T_State", "OnEdit");
            return View(t_state);
        }
        // GET: /T_State/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_State") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_State t_state = db.T_States.Find(id);
            if (t_state == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_StateParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_State"))
			 ViewData["T_StateParentUrl"] = Request.UrlReferrer;
            return View(t_state);
        }
        // POST: /T_State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_State t_state, string UrlReferrer)
        {
			if (!User.CanDelete("T_State"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_state))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_state, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_state).State = EntityState.Deleted;
            db.T_States.Remove(t_state);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_StateParentUrl"] != null)
					{
						string parentUrl = ViewData["T_StateParentUrl"].ToString();
						ViewData["T_StateParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_state);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Country" && AssociatedType == "T_StateCountry")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_State obj = db.T_States.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_StateCountryID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_State", User) || !User.CanDelete("T_State")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_State t_state = db.T_States.Find(id);
		if (CheckBeforeDelete(t_state))
        {
            if (!CustomDelete(t_state, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_state).State = EntityState.Deleted;
                db.T_States.Remove(t_state);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_State", User) || !User.CanEdit("T_State") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_StateParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description,T_StateCountryID")] T_State t_state,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_State target = db.T_States.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_state, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_statecountry != null)
							  db.Entry(target.t_statecountry).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_state,"BulkUpdate","");
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