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
namespace GeneratorBase.MVC.Controllers
{

    public partial class T_EmployeeTypeController : BaseController
    {
        // GET: /T_EmployeeType/
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
			var lstT_EmployeeType = from s in db.T_EmployeeTypes
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_EmployeeType = searchRecords(lstT_EmployeeType, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_EmployeeType = sortRecords(lstT_EmployeeType, sortBy, isAsc);
            }
            else lstT_EmployeeType = lstT_EmployeeType.OrderByDescending(c => c.Id);
			lstT_EmployeeType = CustomSorting(lstT_EmployeeType);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_EmployeeType"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_EmployeeType"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_EmployeeType"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_EmployeeType"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_EmployeeType = lstT_EmployeeType;
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_EmployeeType", User) || !User.CanView("T_EmployeeType"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_EmployeeType.Count() > 0)
                    pageSize = _T_EmployeeType.Count();
                return View("ExcelExport", _T_EmployeeType.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_EmployeeType.Count();
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
				var list = _T_EmployeeType.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_EmployeeTypeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_EmployeeTypelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_EmployeeType = _fad.FilterDropdown<T_EmployeeType>(User,  _T_EmployeeType, "T_EmployeeType", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_EmployeeType.Except(_T_EmployeeType),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_EmployeeType.Except(_T_EmployeeType).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_EmployeeType.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_EmployeeType.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_EmployeeType.Count() == 0 ? 1 : _T_EmployeeType.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_EmployeeType.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_EmployeeTypeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_EmployeeTypelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_EmployeeType.Count() == 0 ? 1 : _T_EmployeeType.Count();
                            }
							var list = _T_EmployeeType.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_EmployeeTypeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_EmployeeTypelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_EmployeeType/Details/5
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
            T_EmployeeType t_employeetype = db.T_EmployeeTypes.Find(id);
            if (t_employeetype == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_employeetype);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_employeetype, AssociatedType);
            ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnDetails", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnDetails", true);
			ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnDetails");
			return View(ViewBag.TemplatesName,t_employeetype);
        }
        // GET: /T_EmployeeType/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_EmployeeType") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_EmployeeTypeParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", true);
		  ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnCreate");
          return View();
        }
		// GET: /T_EmployeeType/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_EmployeeType") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_EmployeeTypeParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", true);
			 ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnCreate");
            return View();
        }
		// POST: /T_EmployeeType/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_EmployeeType t_employeetype, string UrlReferrer)
        {
			CheckBeforeSave(t_employeetype);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_employeetype,out customcreate_hasissues,"Create"))
                {
                    db.T_EmployeeTypes.Add(t_employeetype);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employeetype,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_employeetype);
			ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", true);
			ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnCreate");	
            return View(t_employeetype);
        }
		 // GET: /T_EmployeeType/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_EmployeeType") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_EmployeeTypeParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", true);
			ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnCreate");
            return View();
        }
		  // POST: /T_EmployeeType/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_EmployeeType t_employeetype,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_employeetype);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_employeetype,out customcreate_hasissues,"Create"))
                {
                    db.T_EmployeeTypes.Add(t_employeetype);
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
			LoadViewDataAfterOnCreate(t_employeetype);
			ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", true);
			ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_employeetype, AssociatedEntity);
			return View(t_employeetype);
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
        // POST: /T_EmployeeType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_EmployeeType t_employeetype, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_employeetype, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_employeetype,out customcreate_hasissues,command))
                {
                    db.T_EmployeeTypes.Add(t_employeetype);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employeetype,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_employeetype.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_employeetype);
			ViewData["T_EmployeeTypeParentUrl"] = UrlReferrer;
			ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnCreate", true);
			ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnCreate");
            return View(t_employeetype);
        }
		// GET: /T_EmployeeType/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_EmployeeType") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_EmployeeType t_employeetype = db.T_EmployeeTypes.Find(id);
            if (t_employeetype == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_EmployeeTypeParentUrl"] = UrlReferrer;
		if(ViewData["T_EmployeeTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeType")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeType/Edit/" + t_employeetype.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeType/Create"))
			ViewData["T_EmployeeTypeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_employeetype);
		   ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", true);
		   ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnEdit");
		    var objT_EmployeeType = new List<T_EmployeeType>();
            ViewBag.T_EmployeeTypeDD = new SelectList(objT_EmployeeType, "ID", "DisplayValue"); 
          return View(t_employeetype);
        }
		// POST: /T_EmployeeType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_EmployeeType t_employeetype,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_employeetype, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_employeetype,out customsave_hasissues,command))
                {
					db.Entry(t_employeetype).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_employeetype);
			ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", true);
			ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnEdit");
            return View(t_employeetype);
        }
        // GET: /T_EmployeeType/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_EmployeeType") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_EmployeeType t_employeetype = db.T_EmployeeTypes.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_EmployeeTypelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_EmployeeTypes.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_EmployeeTypeDisplayValueEdit = TempData["T_EmployeeTypelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_EmployeeTypelist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_EmployeeTypeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_employeetype == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeType/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_employeetype.DisplayValue, Value = t_employeetype.Id.ToString() }));
                ViewBag.EntityT_EmployeeTypeDisplayValueEdit = newList;
				TempData["T_EmployeeTypelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_employeetype.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_employeetype.DisplayValue;
                    newList[0].Value = t_employeetype.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_employeetype.DisplayValue, Value = t_employeetype.Id.ToString() }));
                }
                ViewBag.EntityT_EmployeeTypeDisplayValueEdit = newList;
				TempData["T_EmployeeTypelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_EmployeeTypeParentUrl"] = UrlReferrer;
		if(ViewData["T_EmployeeTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeType")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeType/Edit/" + t_employeetype.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeType/Create"))
			ViewData["T_EmployeeTypeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_employeetype);
		   ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", true);
		   ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnEdit");
          return View(t_employeetype);
        }
        // POST: /T_EmployeeType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_EmployeeType t_employeetype,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_employeetype, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_employeetype,out customsave_hasissues,command))
            {
				db.Entry(t_employeetype).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employeetype,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_employeetype.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_EmployeeTypelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_EmployeeTypes.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_EmployeeTypeDisplayValueEdit = TempData["T_EmployeeTypelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_EmployeeTypelist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_EmployeeTypeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_employeetype);
			 ViewData["T_EmployeeTypeParentUrl"] = UrlReferrer;
			ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", true);
			ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnEdit");
            return View(t_employeetype);
        }
		// GET: /T_EmployeeType/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_EmployeeType") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_EmployeeType t_employeetype = db.T_EmployeeTypes.Find(id);
            if (t_employeetype == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_EmployeeTypeParentUrl"] = UrlReferrer;
		if(ViewData["T_EmployeeTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeType"))
			ViewData["T_EmployeeTypeParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_employeetype);
			 ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", true);
			 ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnEdit");
          return View(t_employeetype);
        }
        // POST: /T_EmployeeType/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_EmployeeType t_employeetype,string UrlReferrer)
        {
			CheckBeforeSave(t_employeetype);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_employeetype,out customsave_hasissues,"Save"))
            {
				db.Entry(t_employeetype).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employeetype,"Edit","");
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
			LoadViewDataAfterOnEdit(t_employeetype);
			ViewBag.T_EmployeeTypeIsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", false);
			ViewBag.T_EmployeeTypeIsGroupsHiddenRule = checkHidden("T_EmployeeType", "OnEdit", true);
			ViewBag.T_EmployeeTypeIsSetValueUIRule = checkSetValueUIRule("T_EmployeeType", "OnEdit");
            return View(t_employeetype);
        }
        // GET: /T_EmployeeType/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_EmployeeType") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_EmployeeType t_employeetype = db.T_EmployeeTypes.Find(id);
            if (t_employeetype == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_EmployeeTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_EmployeeType"))
			 ViewData["T_EmployeeTypeParentUrl"] = Request.UrlReferrer;
            return View(t_employeetype);
        }
        // POST: /T_EmployeeType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_EmployeeType t_employeetype, string UrlReferrer)
        {
			if (!User.CanDelete("T_EmployeeType"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_employeetype))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_employeetype, out customdelete_hasissues, "Delete"))
                {
            var listT_EmploymentRecordEmployeeType = db.T_ServiceRecords.Where(p => p.T_EmploymentRecordEmployeeTypeID == t_employeetype.Id);
            foreach (var lst in listT_EmploymentRecordEmployeeType)
               db.T_ServiceRecords.Remove(lst);
           db.SaveChanges();
			db.Entry(t_employeetype).State = EntityState.Deleted;
            db.T_EmployeeTypes.Remove(t_employeetype);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_EmployeeTypeParentUrl"] != null)
					{
						string parentUrl = ViewData["T_EmployeeTypeParentUrl"].ToString();
						ViewData["T_EmployeeTypeParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_employeetype);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_EmployeeType", User) || !User.CanDelete("T_EmployeeType")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_EmployeeType t_employeetype = db.T_EmployeeTypes.Find(id);
		if (CheckBeforeDelete(t_employeetype))
        {
            if (!CustomDelete(t_employeetype, out customdelete_hasissues, "DeleteBulk"))
            {
            var listT_EmploymentRecordEmployeeType = db.T_ServiceRecords.Where(p => p.T_EmploymentRecordEmployeeTypeID == id);
            foreach (var lst in listT_EmploymentRecordEmployeeType)
               db.T_ServiceRecords.Remove(lst);
           db.SaveChanges();
                db.Entry(t_employeetype).State = EntityState.Deleted;
                db.T_EmployeeTypes.Remove(t_employeetype);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_EmployeeType", User) || !User.CanEdit("T_EmployeeType") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_EmployeeTypeParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_EmployeeType t_employeetype,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_EmployeeType target = db.T_EmployeeTypes.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_employeetype, target, chkUpdate); 
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
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_employeetype,"BulkUpdate","");
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
