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

    public partial class T_RestrictionsController : BaseController
    {
        // GET: /T_Restrictions/
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
			var lstT_Restrictions = from s in db.T_Restrictionss
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Restrictions = searchRecords(lstT_Restrictions, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Restrictions = sortRecords(lstT_Restrictions, sortBy, isAsc);
            }
            else lstT_Restrictions = lstT_Restrictions.OrderByDescending(c => c.Id);
			lstT_Restrictions = CustomSorting(lstT_Restrictions);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Restrictions"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Restrictions"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Restrictions"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Restrictions"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_Restrictions = lstT_Restrictions.Include(t=>t.t_restrictionsfacilityassociation);
		 if (HostingEntity == "T_Facility" && AssociatedType == "T_RestrictionsFacilityAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Restrictions = _T_Restrictions.Where(p => p.T_RestrictionsFacilityAssociationID == hostid);
			 }
			 else
			     _T_Restrictions = _T_Restrictions.Where(p => p.T_RestrictionsFacilityAssociationID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_Restrictions", User) || !User.CanView("T_Restrictions"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_Restrictions.Count() > 0)
                    pageSize = _T_Restrictions.Count();
                return View("ExcelExport", _T_Restrictions.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Restrictions.Count();
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
				var list = _T_Restrictions.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_RestrictionsDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_Restrictionslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_Restrictions = _fad.FilterDropdown<T_Restrictions>(User,  _T_Restrictions, "T_Restrictions", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_Restrictions.Except(_T_Restrictions),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_Restrictions.Except(_T_Restrictions).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_Restrictions.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_Restrictions.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_Restrictions.Count() == 0 ? 1 : _T_Restrictions.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_Restrictions.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_RestrictionsDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Restrictionslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_Restrictions.Count() == 0 ? 1 : _T_Restrictions.Count();
                            }
							var list = _T_Restrictions.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_RestrictionsDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Restrictionslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_Restrictions/Details/5
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
            T_Restrictions t_restrictions = db.T_Restrictionss.Find(id);
            if (t_restrictions == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_restrictions);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_restrictions, AssociatedType);
            ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnDetails", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnDetails", true);
			ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnDetails");
			return View(ViewBag.TemplatesName,t_restrictions);
        }
        // GET: /T_Restrictions/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_Restrictions") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_RestrictionsParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnCreate", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnCreate", true);
		  ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnCreate");
          return View();
        }
		// GET: /T_Restrictions/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_Restrictions") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_RestrictionsParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnCreate", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnCreate", true);
			 ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnCreate");
            return View();
        }
		// POST: /T_Restrictions/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_RestrictionsFacilityAssociationID,T_Name,T_Description")] T_Restrictions t_restrictions, string UrlReferrer)
        {
			CheckBeforeSave(t_restrictions);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_restrictions,out customcreate_hasissues,"Create"))
                {
                    db.T_Restrictionss.Add(t_restrictions);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_restrictions,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_restrictions);
			ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnCreate", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnCreate", true);
			ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnCreate");	
            return View(t_restrictions);
        }
		 // GET: /T_Restrictions/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_Restrictions") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_RestrictionsParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnCreate", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnCreate", true);
			ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnCreate");
            return View();
        }
		  // POST: /T_Restrictions/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_RestrictionsFacilityAssociationID,T_Name,T_Description")] T_Restrictions t_restrictions,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_restrictions);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_restrictions,out customcreate_hasissues,"Create"))
                {
                    db.T_Restrictionss.Add(t_restrictions);
					db.SaveChanges();
                }
				if (HostingEntityName == "T_EmployeeInjury" && AssociatedEntity == "T_TypeOfRestrictions_T_EmployeeInjury")
                {
                    long hostingentityid;
                    if(Int64.TryParse(HostingEntityID,out hostingentityid) && hostingentityid >0)
                    {
                        db.T_TypeOfRestrictionss.Add(new T_TypeOfRestrictions { T_EmployeeInjuryID = hostingentityid, T_RestrictionsID = t_restrictions.Id });
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
			LoadViewDataAfterOnCreate(t_restrictions);
			ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnCreate", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnCreate", true);
			ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_restrictions, AssociatedEntity);
			return View(t_restrictions);
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
        // POST: /T_Restrictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_RestrictionsFacilityAssociationID,T_Name,T_Description")] T_Restrictions t_restrictions, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_restrictions, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_restrictions,out customcreate_hasissues,command))
                {
                    db.T_Restrictionss.Add(t_restrictions);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_restrictions,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_restrictions.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_restrictions);
			ViewData["T_RestrictionsParentUrl"] = UrlReferrer;
			ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnCreate", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnCreate", true);
			ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnCreate");
            return View(t_restrictions);
        }
		// GET: /T_Restrictions/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Restrictions") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_Restrictions t_restrictions = db.T_Restrictionss.Find(id);
            if (t_restrictions == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_RestrictionsParentUrl"] = UrlReferrer;
		if(ViewData["T_RestrictionsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Restrictions")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Restrictions/Edit/" + t_restrictions.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Restrictions/Create"))
			ViewData["T_RestrictionsParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_restrictions);
		   ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnEdit", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnEdit", true);
		   ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnEdit");
		    var objT_Restrictions = new List<T_Restrictions>();
            ViewBag.T_RestrictionsDD = new SelectList(objT_Restrictions, "ID", "DisplayValue"); 
          return View(t_restrictions);
        }
		// POST: /T_Restrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_RestrictionsFacilityAssociationID,T_Name,T_Description")] T_Restrictions t_restrictions,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_restrictions, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_restrictions,out customsave_hasissues,command))
                {
					db.Entry(t_restrictions).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_restrictions);
			ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnEdit", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnEdit", true);
			ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnEdit");
            return View(t_restrictions);
        }
        // GET: /T_Restrictions/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_Restrictions") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Restrictions t_restrictions = db.T_Restrictionss.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Restrictionslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Restrictionss.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_RestrictionsDisplayValueEdit = TempData["T_Restrictionslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Restrictionslist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_RestrictionsDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_restrictions == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_Restrictions/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_restrictions.DisplayValue, Value = t_restrictions.Id.ToString() }));
                ViewBag.EntityT_RestrictionsDisplayValueEdit = newList;
				TempData["T_Restrictionslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_restrictions.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_restrictions.DisplayValue;
                    newList[0].Value = t_restrictions.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_restrictions.DisplayValue, Value = t_restrictions.Id.ToString() }));
                }
                ViewBag.EntityT_RestrictionsDisplayValueEdit = newList;
				TempData["T_Restrictionslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_RestrictionsParentUrl"] = UrlReferrer;
		if(ViewData["T_RestrictionsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Restrictions")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Restrictions/Edit/" + t_restrictions.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Restrictions/Create"))
			ViewData["T_RestrictionsParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_restrictions);
		   ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnEdit", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnEdit", true);
		   ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnEdit");
          return View(t_restrictions);
        }
        // POST: /T_Restrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_RestrictionsFacilityAssociationID,T_Name,T_Description")] T_Restrictions t_restrictions,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_restrictions, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_restrictions,out customsave_hasissues,command))
            {
				db.Entry(t_restrictions).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_restrictions,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_restrictions.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_Restrictionslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Restrictionss.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_RestrictionsDisplayValueEdit = TempData["T_Restrictionslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Restrictionslist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_RestrictionsDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_restrictions);
			 ViewData["T_RestrictionsParentUrl"] = UrlReferrer;
			ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnEdit", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnEdit", true);
			ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnEdit");
            return View(t_restrictions);
        }
		// GET: /T_Restrictions/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Restrictions") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_Restrictions t_restrictions = db.T_Restrictionss.Find(id);
            if (t_restrictions == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_RestrictionsParentUrl"] = UrlReferrer;
		if(ViewData["T_RestrictionsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Restrictions"))
			ViewData["T_RestrictionsParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_restrictions);
			 ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnEdit", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnEdit", true);
			 ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnEdit");
          return View(t_restrictions);
        }
        // POST: /T_Restrictions/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_RestrictionsFacilityAssociationID,T_Name,T_Description")] T_Restrictions t_restrictions,string UrlReferrer)
        {
			CheckBeforeSave(t_restrictions);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_restrictions,out customsave_hasissues,"Save"))
            {
				db.Entry(t_restrictions).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_restrictions,"Edit","");
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
			LoadViewDataAfterOnEdit(t_restrictions);
			ViewBag.T_RestrictionsIsHiddenRule = checkHidden("T_Restrictions", "OnEdit", false);
			ViewBag.T_RestrictionsIsGroupsHiddenRule = checkHidden("T_Restrictions", "OnEdit", true);
			ViewBag.T_RestrictionsIsSetValueUIRule = checkSetValueUIRule("T_Restrictions", "OnEdit");
            return View(t_restrictions);
        }
        // GET: /T_Restrictions/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_Restrictions") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_Restrictions t_restrictions = db.T_Restrictionss.Find(id);
            if (t_restrictions == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_RestrictionsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Restrictions"))
			 ViewData["T_RestrictionsParentUrl"] = Request.UrlReferrer;
            return View(t_restrictions);
        }
        // POST: /T_Restrictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_Restrictions t_restrictions, string UrlReferrer)
        {
			if (!User.CanDelete("T_Restrictions"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_restrictions))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_restrictions, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_restrictions).State = EntityState.Deleted;
            db.T_Restrictionss.Remove(t_restrictions);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_RestrictionsParentUrl"] != null)
					{
						string parentUrl = ViewData["T_RestrictionsParentUrl"].ToString();
						ViewData["T_RestrictionsParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_restrictions);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Facility" && AssociatedType == "T_RestrictionsFacilityAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Restrictions obj = db.T_Restrictionss.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_RestrictionsFacilityAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_Restrictions", User) || !User.CanDelete("T_Restrictions")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_Restrictions t_restrictions = db.T_Restrictionss.Find(id);
		if (CheckBeforeDelete(t_restrictions))
        {
            if (!CustomDelete(t_restrictions, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_restrictions).State = EntityState.Deleted;
                db.T_Restrictionss.Remove(t_restrictions);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_Restrictions", User) || !User.CanEdit("T_Restrictions") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_RestrictionsParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_RestrictionsFacilityAssociationID,T_Name,T_Description")] T_Restrictions t_restrictions,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_Restrictions target = db.T_Restrictionss.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_restrictions, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_restrictionsfacilityassociation != null)
							  db.Entry(target.t_restrictionsfacilityassociation).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_restrictions,"BulkUpdate","");
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
