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
    public partial class T_LicensesController : BaseController
    {
        // GET: /T_Licenses/
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
			var lstT_Licenses = from s in db.T_Licensess
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Licenses = searchRecords(lstT_Licenses, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Licenses = sortRecords(lstT_Licenses, sortBy, isAsc);
            }
            else lstT_Licenses = lstT_Licenses.OrderByDescending(c => c.Id);
			lstT_Licenses = CustomSorting(lstT_Licenses);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Licenses"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Licenses"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Licenses"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Licenses"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_Licenses = lstT_Licenses.Include(t=>t.t_licenserecords).Include(t=>t.t_associatedlicensestype);
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_LicenseRecords")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Licenses = _T_Licenses.Where(p => p.T_LicenseRecordsID == hostid);
			 }
			 else
			     _T_Licenses = _T_Licenses.Where(p => p.T_LicenseRecordsID == null);
         }
		 if (HostingEntity == "T_Licensestype" && AssociatedType == "T_AssociatedLicensesType")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Licenses = _T_Licenses.Where(p => p.T_AssociatedLicensesTypeID == hostid);
			 }
			 else
			     _T_Licenses = _T_Licenses.Where(p => p.T_AssociatedLicensesTypeID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_Licenses", User) || !User.CanView("T_Licenses"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_Licenses.Count() > 0)
                    pageSize = _T_Licenses.Count();
                return View("ExcelExport", _T_Licenses.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Licenses.Count();
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
				var list = _T_Licenses.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_LicensesDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_Licenseslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_Licenses = _fad.FilterDropdown<T_Licenses>(User,  _T_Licenses, "T_Licenses", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_Licenses.Except(_T_Licenses),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_Licenses.Except(_T_Licenses).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_Licenses.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_Licenses.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_Licenses.Count() == 0 ? 1 : _T_Licenses.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_Licenses.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_LicensesDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Licenseslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_Licenses.Count() == 0 ? 1 : _T_Licenses.Count();
                            }
							var list = _T_Licenses.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_LicensesDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Licenseslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_Licenses/Details/5
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
            T_Licenses t_licenses = db.T_Licensess.Find(id);
            if (t_licenses == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_licenses);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_licenses, AssociatedType);
            ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnDetails", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnDetails", true);
			ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnDetails");
			return View(ViewBag.TemplatesName,t_licenses);
        }
        // GET: /T_Licenses/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_Licenses") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_LicensesParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnCreate", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnCreate", true);
		  ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnCreate");
          return View();
        }
		// GET: /T_Licenses/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_Licenses") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_LicensesParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnCreate", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnCreate", true);
			 ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnCreate");
            return View();
        }
		// POST: /T_Licenses/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_LicenseRecordsID,T_NameontheLicense,T_AssociatedLicensesTypeID,T_LicenseNumber,T_InitialLicenseDate,T_ExpiryDate,T_PrintDate,T_Notes")] T_Licenses t_licenses, string UrlReferrer)
        {
			CheckBeforeSave(t_licenses);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_licenses,out customcreate_hasissues,"Create"))
                {
                    db.T_Licensess.Add(t_licenses);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_licenses,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_licenses);
			ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnCreate", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnCreate", true);
			ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnCreate");	
            return View(t_licenses);
        }
		 // GET: /T_Licenses/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_Licenses") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_LicensesParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnCreate", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnCreate", true);
			ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnCreate");
            return View();
        }
		  // POST: /T_Licenses/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_LicenseRecordsID,T_NameontheLicense,T_AssociatedLicensesTypeID,T_LicenseNumber,T_InitialLicenseDate,T_ExpiryDate,T_PrintDate")] T_Licenses t_licenses,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_licenses);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_licenses,out customcreate_hasissues,"Create"))
                {
                    db.T_Licensess.Add(t_licenses);
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
			LoadViewDataAfterOnCreate(t_licenses);
			ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnCreate", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnCreate", true);
			ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_licenses, AssociatedEntity);
			return View(t_licenses);
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
        // POST: /T_Licenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_LicenseRecordsID,T_NameontheLicense,T_AssociatedLicensesTypeID,T_LicenseNumber,T_InitialLicenseDate,T_ExpiryDate,T_PrintDate,T_Notes")] T_Licenses t_licenses, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_licenses, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_licenses,out customcreate_hasissues,command))
                {
                    db.T_Licensess.Add(t_licenses);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_licenses,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_licenses.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_licenses);
			ViewData["T_LicensesParentUrl"] = UrlReferrer;
			ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnCreate", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnCreate", true);
			ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnCreate");
            return View(t_licenses);
        }
		// GET: /T_Licenses/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Licenses") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_Licenses t_licenses = db.T_Licensess.Find(id);
            if (t_licenses == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_LicensesParentUrl"] = UrlReferrer;
		if(ViewData["T_LicensesParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Licenses")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Licenses/Edit/" + t_licenses.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Licenses/Create"))
			ViewData["T_LicensesParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_licenses);
		   ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnEdit", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnEdit", true);
		   ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnEdit");
		    var objT_Licenses = new List<T_Licenses>();
            ViewBag.T_LicensesDD = new SelectList(objT_Licenses, "ID", "DisplayValue"); 
          return View(t_licenses);
        }
		// POST: /T_Licenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_LicenseRecordsID,T_NameontheLicense,T_AssociatedLicensesTypeID,T_LicenseNumber,T_InitialLicenseDate,T_ExpiryDate,T_PrintDate,T_Notes")] T_Licenses t_licenses,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_licenses, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_licenses,out customsave_hasissues,command))
                {
					db.Entry(t_licenses).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_licenses);
			ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnEdit", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnEdit", true);
			ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnEdit");
            return View(t_licenses);
        }
        // GET: /T_Licenses/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_Licenses") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Licenses t_licenses = db.T_Licensess.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Licenseslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Licensess.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_LicensesDisplayValueEdit = TempData["T_Licenseslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Licenseslist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_LicensesDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_licenses == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_Licenses/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_licenses.DisplayValue, Value = t_licenses.Id.ToString() }));
                ViewBag.EntityT_LicensesDisplayValueEdit = newList;
				TempData["T_Licenseslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_licenses.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_licenses.DisplayValue;
                    newList[0].Value = t_licenses.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_licenses.DisplayValue, Value = t_licenses.Id.ToString() }));
                }
                ViewBag.EntityT_LicensesDisplayValueEdit = newList;
				TempData["T_Licenseslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_LicensesParentUrl"] = UrlReferrer;
		if(ViewData["T_LicensesParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Licenses")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Licenses/Edit/" + t_licenses.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Licenses/Create"))
			ViewData["T_LicensesParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_licenses);
		   ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnEdit", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnEdit", true);
		   ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnEdit");
          return View(t_licenses);
        }
        // POST: /T_Licenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_LicenseRecordsID,T_NameontheLicense,T_AssociatedLicensesTypeID,T_LicenseNumber,T_InitialLicenseDate,T_ExpiryDate,T_PrintDate,T_Notes")] T_Licenses t_licenses,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_licenses, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_licenses,out customsave_hasissues,command))
            {
				db.Entry(t_licenses).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_licenses,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_licenses.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_Licenseslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Licensess.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_LicensesDisplayValueEdit = TempData["T_Licenseslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Licenseslist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_LicensesDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_licenses);
			 ViewData["T_LicensesParentUrl"] = UrlReferrer;
			ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnEdit", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnEdit", true);
			ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnEdit");
            return View(t_licenses);
        }
		// GET: /T_Licenses/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Licenses") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_Licenses t_licenses = db.T_Licensess.Find(id);
            if (t_licenses == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_LicensesParentUrl"] = UrlReferrer;
		if(ViewData["T_LicensesParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Licenses"))
			ViewData["T_LicensesParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_licenses);
			 ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnEdit", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnEdit", true);
			 ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnEdit");
          return View(t_licenses);
        }
        // POST: /T_Licenses/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_LicenseRecordsID,T_NameontheLicense,T_AssociatedLicensesTypeID,T_LicenseNumber,T_InitialLicenseDate,T_ExpiryDate,T_PrintDate,T_Notes")] T_Licenses t_licenses,string UrlReferrer)
        {
			CheckBeforeSave(t_licenses);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_licenses,out customsave_hasissues,"Save"))
            {
				db.Entry(t_licenses).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_licenses,"Edit","");
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
			LoadViewDataAfterOnEdit(t_licenses);
			ViewBag.T_LicensesIsHiddenRule = checkHidden("T_Licenses", "OnEdit", false);
			ViewBag.T_LicensesIsGroupsHiddenRule = checkHidden("T_Licenses", "OnEdit", true);
			ViewBag.T_LicensesIsSetValueUIRule = checkSetValueUIRule("T_Licenses", "OnEdit");
            return View(t_licenses);
        }
        // GET: /T_Licenses/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_Licenses") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_Licenses t_licenses = db.T_Licensess.Find(id);
            if (t_licenses == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_LicensesParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Licenses"))
			 ViewData["T_LicensesParentUrl"] = Request.UrlReferrer;
            return View(t_licenses);
        }
        // POST: /T_Licenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_Licenses t_licenses, string UrlReferrer)
        {
			if (!User.CanDelete("T_Licenses"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_licenses))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_licenses, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_licenses).State = EntityState.Deleted;
            db.T_Licensess.Remove(t_licenses);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_LicensesParentUrl"] != null)
					{
						string parentUrl = ViewData["T_LicensesParentUrl"].ToString();
						ViewData["T_LicensesParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_licenses);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Employee" && AssociatedType == "T_LicenseRecords")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Licenses obj = db.T_Licensess.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_LicenseRecordsID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Licensestype" && AssociatedType == "T_AssociatedLicensesType")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Licenses obj = db.T_Licensess.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_AssociatedLicensesTypeID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_Licenses", User) || !User.CanDelete("T_Licenses")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_Licenses t_licenses = db.T_Licensess.Find(id);
		if (CheckBeforeDelete(t_licenses))
        {
            if (!CustomDelete(t_licenses, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_licenses).State = EntityState.Deleted;
                db.T_Licensess.Remove(t_licenses);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_Licenses", User) || !User.CanEdit("T_Licenses") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_LicensesParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_LicenseRecordsID,T_NameontheLicense,T_AssociatedLicensesTypeID,T_LicenseNumber,T_InitialLicenseDate,T_ExpiryDate,T_PrintDate,T_Notes")] T_Licenses t_licenses,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_Licenses target = db.T_Licensess.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_licenses, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_licenserecords != null)
							  db.Entry(target.t_licenserecords).State = EntityState.Unchanged;
							if (target.t_associatedlicensestype != null)
							  db.Entry(target.t_associatedlicensestype).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_licenses,"BulkUpdate","");
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
