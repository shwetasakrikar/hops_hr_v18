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

    public partial class T_FacilityConfigurationController : BaseController
    {
        // GET: /T_FacilityConfiguration/
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
			var lstT_FacilityConfiguration = from s in db.T_FacilityConfigurations
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_FacilityConfiguration = searchRecords(lstT_FacilityConfiguration, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_FacilityConfiguration = sortRecords(lstT_FacilityConfiguration, sortBy, isAsc);
            }
            else lstT_FacilityConfiguration = lstT_FacilityConfiguration.OrderByDescending(c => c.Id);
			lstT_FacilityConfiguration = CustomSorting(lstT_FacilityConfiguration);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_FacilityConfiguration"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_FacilityConfiguration"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_FacilityConfiguration"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_FacilityConfiguration"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_FacilityConfiguration = lstT_FacilityConfiguration.Include(t=>t.t_tenantconfigurationassociation);
		 if (HostingEntity == "T_Facility" && AssociatedType == "T_TenantConfigurationAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_FacilityConfiguration = _T_FacilityConfiguration.Where(p => p.T_TenantConfigurationAssociationID == hostid);
			 }
			 else
			     _T_FacilityConfiguration = _T_FacilityConfiguration.Where(p => p.T_TenantConfigurationAssociationID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_FacilityConfiguration", User) || !User.CanView("T_FacilityConfiguration"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_FacilityConfiguration.Count() > 0)
                    pageSize = _T_FacilityConfiguration.Count();
                return View("ExcelExport", _T_FacilityConfiguration.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_FacilityConfiguration.Count();
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
				var list = _T_FacilityConfiguration.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_FacilityConfigurationDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_FacilityConfigurationlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_FacilityConfiguration = _fad.FilterDropdown<T_FacilityConfiguration>(User,  _T_FacilityConfiguration, "T_FacilityConfiguration", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_FacilityConfiguration.Except(_T_FacilityConfiguration),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_FacilityConfiguration.Except(_T_FacilityConfiguration).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_FacilityConfiguration.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_FacilityConfiguration.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_FacilityConfiguration.Count() == 0 ? 1 : _T_FacilityConfiguration.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_FacilityConfiguration.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_FacilityConfigurationDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_FacilityConfigurationlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_FacilityConfiguration.Count() == 0 ? 1 : _T_FacilityConfiguration.Count();
                            }
							var list = _T_FacilityConfiguration.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_FacilityConfigurationDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_FacilityConfigurationlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_FacilityConfiguration/Details/5
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
            T_FacilityConfiguration t_facilityconfiguration = db.T_FacilityConfigurations.Find(id);
            if (t_facilityconfiguration == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_facilityconfiguration);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_facilityconfiguration, AssociatedType);
            ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnDetails", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnDetails", true);
			ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnDetails");
			return View(ViewBag.TemplatesName,t_facilityconfiguration);
        }
        // GET: /T_FacilityConfiguration/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_FacilityConfiguration") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_FacilityConfigurationParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", true);
		  ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnCreate");
          return View();
        }
		// GET: /T_FacilityConfiguration/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_FacilityConfiguration") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_FacilityConfigurationParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", true);
			 ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnCreate");
            return View();
        }
		// POST: /T_FacilityConfiguration/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Key,T_Value,T_TenantConfigurationAssociationID")] T_FacilityConfiguration t_facilityconfiguration, string UrlReferrer)
        {
			CheckBeforeSave(t_facilityconfiguration);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_facilityconfiguration,out customcreate_hasissues,"Create"))
                {
                    db.T_FacilityConfigurations.Add(t_facilityconfiguration);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_facilityconfiguration,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_facilityconfiguration);
			ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", true);
			ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnCreate");	
            return View(t_facilityconfiguration);
        }
		 // GET: /T_FacilityConfiguration/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_FacilityConfiguration") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_FacilityConfigurationParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", true);
			ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnCreate");
            return View();
        }
		  // POST: /T_FacilityConfiguration/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Key,T_Value,T_TenantConfigurationAssociationID")] T_FacilityConfiguration t_facilityconfiguration,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_facilityconfiguration);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_facilityconfiguration,out customcreate_hasissues,"Create"))
                {
                    db.T_FacilityConfigurations.Add(t_facilityconfiguration);
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
			LoadViewDataAfterOnCreate(t_facilityconfiguration);
			ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", true);
			ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_facilityconfiguration, AssociatedEntity);
			return View(t_facilityconfiguration);
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
        // POST: /T_FacilityConfiguration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Key,T_Value,T_TenantConfigurationAssociationID")] T_FacilityConfiguration t_facilityconfiguration, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_facilityconfiguration, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_facilityconfiguration,out customcreate_hasissues,command))
                {
                    db.T_FacilityConfigurations.Add(t_facilityconfiguration);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_facilityconfiguration,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_facilityconfiguration.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_facilityconfiguration);
			ViewData["T_FacilityConfigurationParentUrl"] = UrlReferrer;
			ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnCreate", true);
			ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnCreate");
            return View(t_facilityconfiguration);
        }
		// GET: /T_FacilityConfiguration/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_FacilityConfiguration") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_FacilityConfiguration t_facilityconfiguration = db.T_FacilityConfigurations.Find(id);
            if (t_facilityconfiguration == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_FacilityConfigurationParentUrl"] = UrlReferrer;
		if(ViewData["T_FacilityConfigurationParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityConfiguration")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityConfiguration/Edit/" + t_facilityconfiguration.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityConfiguration/Create"))
			ViewData["T_FacilityConfigurationParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_facilityconfiguration);
		   ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", true);
		   ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnEdit");
		    var objT_FacilityConfiguration = new List<T_FacilityConfiguration>();
            ViewBag.T_FacilityConfigurationDD = new SelectList(objT_FacilityConfiguration, "ID", "DisplayValue"); 
          return View(t_facilityconfiguration);
        }
		// POST: /T_FacilityConfiguration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Key,T_Value,T_TenantConfigurationAssociationID")] T_FacilityConfiguration t_facilityconfiguration,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_facilityconfiguration, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_facilityconfiguration,out customsave_hasissues,command))
                {
					db.Entry(t_facilityconfiguration).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_facilityconfiguration);
			ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", true);
			ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnEdit");
            return View(t_facilityconfiguration);
        }
        // GET: /T_FacilityConfiguration/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_FacilityConfiguration") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_FacilityConfiguration t_facilityconfiguration = db.T_FacilityConfigurations.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_FacilityConfigurationlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_FacilityConfigurations.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_FacilityConfigurationDisplayValueEdit = TempData["T_FacilityConfigurationlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_FacilityConfigurationlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_FacilityConfigurationDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_facilityconfiguration == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityConfiguration/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_facilityconfiguration.DisplayValue, Value = t_facilityconfiguration.Id.ToString() }));
                ViewBag.EntityT_FacilityConfigurationDisplayValueEdit = newList;
				TempData["T_FacilityConfigurationlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_facilityconfiguration.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_facilityconfiguration.DisplayValue;
                    newList[0].Value = t_facilityconfiguration.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_facilityconfiguration.DisplayValue, Value = t_facilityconfiguration.Id.ToString() }));
                }
                ViewBag.EntityT_FacilityConfigurationDisplayValueEdit = newList;
				TempData["T_FacilityConfigurationlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_FacilityConfigurationParentUrl"] = UrlReferrer;
		if(ViewData["T_FacilityConfigurationParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityConfiguration")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityConfiguration/Edit/" + t_facilityconfiguration.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityConfiguration/Create"))
			ViewData["T_FacilityConfigurationParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_facilityconfiguration);
		   ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", true);
		   ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnEdit");
          return View(t_facilityconfiguration);
        }
        // POST: /T_FacilityConfiguration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Key,T_Value,T_TenantConfigurationAssociationID")] T_FacilityConfiguration t_facilityconfiguration,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_facilityconfiguration, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_facilityconfiguration,out customsave_hasissues,command))
            {
				db.Entry(t_facilityconfiguration).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_facilityconfiguration,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_facilityconfiguration.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_FacilityConfigurationlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_FacilityConfigurations.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_FacilityConfigurationDisplayValueEdit = TempData["T_FacilityConfigurationlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_FacilityConfigurationlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_FacilityConfigurationDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_facilityconfiguration);
			 ViewData["T_FacilityConfigurationParentUrl"] = UrlReferrer;
			ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", true);
			ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnEdit");
            return View(t_facilityconfiguration);
        }
		// GET: /T_FacilityConfiguration/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_FacilityConfiguration") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_FacilityConfiguration t_facilityconfiguration = db.T_FacilityConfigurations.Find(id);
            if (t_facilityconfiguration == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_FacilityConfigurationParentUrl"] = UrlReferrer;
		if(ViewData["T_FacilityConfigurationParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityConfiguration"))
			ViewData["T_FacilityConfigurationParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_facilityconfiguration);
			 ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", true);
			 ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnEdit");
          return View(t_facilityconfiguration);
        }
        // POST: /T_FacilityConfiguration/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Key,T_Value,T_TenantConfigurationAssociationID")] T_FacilityConfiguration t_facilityconfiguration,string UrlReferrer)
        {
			CheckBeforeSave(t_facilityconfiguration);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_facilityconfiguration,out customsave_hasissues,"Save"))
            {
				db.Entry(t_facilityconfiguration).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_facilityconfiguration,"Edit","");
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
			LoadViewDataAfterOnEdit(t_facilityconfiguration);
			ViewBag.T_FacilityConfigurationIsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", false);
			ViewBag.T_FacilityConfigurationIsGroupsHiddenRule = checkHidden("T_FacilityConfiguration", "OnEdit", true);
			ViewBag.T_FacilityConfigurationIsSetValueUIRule = checkSetValueUIRule("T_FacilityConfiguration", "OnEdit");
            return View(t_facilityconfiguration);
        }
        // GET: /T_FacilityConfiguration/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_FacilityConfiguration") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_FacilityConfiguration t_facilityconfiguration = db.T_FacilityConfigurations.Find(id);
            if (t_facilityconfiguration == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_FacilityConfigurationParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityConfiguration"))
			 ViewData["T_FacilityConfigurationParentUrl"] = Request.UrlReferrer;
            return View(t_facilityconfiguration);
        }
        // POST: /T_FacilityConfiguration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_FacilityConfiguration t_facilityconfiguration, string UrlReferrer)
        {
			if (!User.CanDelete("T_FacilityConfiguration"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_facilityconfiguration))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_facilityconfiguration, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_facilityconfiguration).State = EntityState.Deleted;
            db.T_FacilityConfigurations.Remove(t_facilityconfiguration);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_FacilityConfigurationParentUrl"] != null)
					{
						string parentUrl = ViewData["T_FacilityConfigurationParentUrl"].ToString();
						ViewData["T_FacilityConfigurationParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_facilityconfiguration);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Facility" && AssociatedType == "T_TenantConfigurationAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_FacilityConfiguration obj = db.T_FacilityConfigurations.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_TenantConfigurationAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_FacilityConfiguration", User) || !User.CanDelete("T_FacilityConfiguration")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_FacilityConfiguration t_facilityconfiguration = db.T_FacilityConfigurations.Find(id);
		if (CheckBeforeDelete(t_facilityconfiguration))
        {
            if (!CustomDelete(t_facilityconfiguration, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_facilityconfiguration).State = EntityState.Deleted;
                db.T_FacilityConfigurations.Remove(t_facilityconfiguration);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_FacilityConfiguration", User) || !User.CanEdit("T_FacilityConfiguration") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_FacilityConfigurationParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Key,T_Value,T_TenantConfigurationAssociationID")] T_FacilityConfiguration t_facilityconfiguration,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_FacilityConfiguration target = db.T_FacilityConfigurations.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_facilityconfiguration, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_tenantconfigurationassociation != null)
							  db.Entry(target.t_tenantconfigurationassociation).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_facilityconfiguration,"BulkUpdate","");
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
