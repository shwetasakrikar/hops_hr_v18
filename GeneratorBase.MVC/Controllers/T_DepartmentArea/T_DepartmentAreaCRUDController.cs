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

    public partial class T_DepartmentAreaController : BaseController
    {
        // GET: /T_DepartmentArea/
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
			var lstT_DepartmentArea = from s in db.T_DepartmentAreas
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_DepartmentArea = searchRecords(lstT_DepartmentArea, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_DepartmentArea = sortRecords(lstT_DepartmentArea, sortBy, isAsc);
            }
            else lstT_DepartmentArea = lstT_DepartmentArea.OrderByDescending(c => c.Id);
			lstT_DepartmentArea = CustomSorting(lstT_DepartmentArea);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_DepartmentArea"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_DepartmentArea"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_DepartmentArea"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_DepartmentArea"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_DepartmentArea = lstT_DepartmentArea.Include(t=>t.t_departmentareaemployeetypeassociation);
		 if (HostingEntity == "T_Facility" && AssociatedType == "T_DepartmentAreaEmployeeTypeAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_DepartmentArea = _T_DepartmentArea.Where(p => p.T_DepartmentAreaEmployeeTypeAssociationID == hostid);
			 }
			 else
			     _T_DepartmentArea = _T_DepartmentArea.Where(p => p.T_DepartmentAreaEmployeeTypeAssociationID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_DepartmentArea", User) || !User.CanView("T_DepartmentArea"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_DepartmentArea.Count() > 0)
                    pageSize = _T_DepartmentArea.Count();
                return View("ExcelExport", _T_DepartmentArea.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_DepartmentArea.Count();
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
				var list = _T_DepartmentArea.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_DepartmentAreaDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_DepartmentArealist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_DepartmentArea = _fad.FilterDropdown<T_DepartmentArea>(User,  _T_DepartmentArea, "T_DepartmentArea", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_DepartmentArea.Except(_T_DepartmentArea),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_DepartmentArea.Except(_T_DepartmentArea).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_DepartmentArea.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_DepartmentArea.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_DepartmentArea.Count() == 0 ? 1 : _T_DepartmentArea.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_DepartmentArea.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_DepartmentAreaDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_DepartmentArealist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_DepartmentArea.Count() == 0 ? 1 : _T_DepartmentArea.Count();
                            }
							var list = _T_DepartmentArea.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_DepartmentAreaDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_DepartmentArealist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_DepartmentArea/Details/5
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
            T_DepartmentArea t_departmentarea = db.T_DepartmentAreas.Find(id);
            if (t_departmentarea == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_departmentarea);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_departmentarea, AssociatedType);
            ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnDetails", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnDetails", true);
			ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnDetails");
			return View(ViewBag.TemplatesName,t_departmentarea);
        }
        // GET: /T_DepartmentArea/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_DepartmentArea") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_DepartmentAreaParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", true);
		  ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnCreate");
          return View();
        }
		// GET: /T_DepartmentArea/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_DepartmentArea") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_DepartmentAreaParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", true);
			 ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnCreate");
            return View();
        }
		// POST: /T_DepartmentArea/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_DepartmentAreaEmployeeTypeAssociationID,T_Name,T_Description")] T_DepartmentArea t_departmentarea, string UrlReferrer)
        {
			CheckBeforeSave(t_departmentarea);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_departmentarea,out customcreate_hasissues,"Create"))
                {
                    db.T_DepartmentAreas.Add(t_departmentarea);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_departmentarea,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_departmentarea);
			ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", true);
			ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnCreate");	
            return View(t_departmentarea);
        }
		 // GET: /T_DepartmentArea/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_DepartmentArea") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_DepartmentAreaParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", true);
			ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnCreate");
            return View();
        }
		  // POST: /T_DepartmentArea/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_DepartmentAreaEmployeeTypeAssociationID,T_Name,T_Description")] T_DepartmentArea t_departmentarea,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_departmentarea);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_departmentarea,out customcreate_hasissues,"Create"))
                {
                    db.T_DepartmentAreas.Add(t_departmentarea);
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
			LoadViewDataAfterOnCreate(t_departmentarea);
			ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", true);
			ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_departmentarea, AssociatedEntity);
			return View(t_departmentarea);
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
        // POST: /T_DepartmentArea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_DepartmentAreaEmployeeTypeAssociationID,T_Name,T_Description")] T_DepartmentArea t_departmentarea, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_departmentarea, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_departmentarea,out customcreate_hasissues,command))
                {
                    db.T_DepartmentAreas.Add(t_departmentarea);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_departmentarea,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_departmentarea.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_departmentarea);
			ViewData["T_DepartmentAreaParentUrl"] = UrlReferrer;
			ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnCreate", true);
			ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnCreate");
            return View(t_departmentarea);
        }
		// GET: /T_DepartmentArea/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_DepartmentArea") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_DepartmentArea t_departmentarea = db.T_DepartmentAreas.Find(id);
            if (t_departmentarea == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_DepartmentAreaParentUrl"] = UrlReferrer;
		if(ViewData["T_DepartmentAreaParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_DepartmentArea")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_DepartmentArea/Edit/" + t_departmentarea.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_DepartmentArea/Create"))
			ViewData["T_DepartmentAreaParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_departmentarea);
		   ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", true);
		   ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnEdit");
		    var objT_DepartmentArea = new List<T_DepartmentArea>();
            ViewBag.T_DepartmentAreaDD = new SelectList(objT_DepartmentArea, "ID", "DisplayValue"); 
          return View(t_departmentarea);
        }
		// POST: /T_DepartmentArea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_DepartmentAreaEmployeeTypeAssociationID,T_Name,T_Description")] T_DepartmentArea t_departmentarea,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_departmentarea, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_departmentarea,out customsave_hasissues,command))
                {
					db.Entry(t_departmentarea).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_departmentarea);
			ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", true);
			ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnEdit");
            return View(t_departmentarea);
        }
        // GET: /T_DepartmentArea/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_DepartmentArea") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_DepartmentArea t_departmentarea = db.T_DepartmentAreas.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_DepartmentArealist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_DepartmentAreas.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_DepartmentAreaDisplayValueEdit = TempData["T_DepartmentArealist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_DepartmentArealist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_DepartmentAreaDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_departmentarea == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_DepartmentArea/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_departmentarea.DisplayValue, Value = t_departmentarea.Id.ToString() }));
                ViewBag.EntityT_DepartmentAreaDisplayValueEdit = newList;
				TempData["T_DepartmentArealist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_departmentarea.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_departmentarea.DisplayValue;
                    newList[0].Value = t_departmentarea.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_departmentarea.DisplayValue, Value = t_departmentarea.Id.ToString() }));
                }
                ViewBag.EntityT_DepartmentAreaDisplayValueEdit = newList;
				TempData["T_DepartmentArealist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_DepartmentAreaParentUrl"] = UrlReferrer;
		if(ViewData["T_DepartmentAreaParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_DepartmentArea")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_DepartmentArea/Edit/" + t_departmentarea.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_DepartmentArea/Create"))
			ViewData["T_DepartmentAreaParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_departmentarea);
		   ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", true);
		   ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnEdit");
          return View(t_departmentarea);
        }
        // POST: /T_DepartmentArea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_DepartmentAreaEmployeeTypeAssociationID,T_Name,T_Description")] T_DepartmentArea t_departmentarea,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_departmentarea, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_departmentarea,out customsave_hasissues,command))
            {
				db.Entry(t_departmentarea).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_departmentarea,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_departmentarea.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_DepartmentArealist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_DepartmentAreas.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_DepartmentAreaDisplayValueEdit = TempData["T_DepartmentArealist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_DepartmentArealist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_DepartmentAreaDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_departmentarea);
			 ViewData["T_DepartmentAreaParentUrl"] = UrlReferrer;
			ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", true);
			ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnEdit");
            return View(t_departmentarea);
        }
		// GET: /T_DepartmentArea/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_DepartmentArea") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_DepartmentArea t_departmentarea = db.T_DepartmentAreas.Find(id);
            if (t_departmentarea == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_DepartmentAreaParentUrl"] = UrlReferrer;
		if(ViewData["T_DepartmentAreaParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_DepartmentArea"))
			ViewData["T_DepartmentAreaParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_departmentarea);
			 ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", true);
			 ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnEdit");
          return View(t_departmentarea);
        }
        // POST: /T_DepartmentArea/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_DepartmentAreaEmployeeTypeAssociationID,T_Name,T_Description")] T_DepartmentArea t_departmentarea,string UrlReferrer)
        {
			CheckBeforeSave(t_departmentarea);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_departmentarea,out customsave_hasissues,"Save"))
            {
				db.Entry(t_departmentarea).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_departmentarea,"Edit","");
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
			LoadViewDataAfterOnEdit(t_departmentarea);
			ViewBag.T_DepartmentAreaIsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", false);
			ViewBag.T_DepartmentAreaIsGroupsHiddenRule = checkHidden("T_DepartmentArea", "OnEdit", true);
			ViewBag.T_DepartmentAreaIsSetValueUIRule = checkSetValueUIRule("T_DepartmentArea", "OnEdit");
            return View(t_departmentarea);
        }
        // GET: /T_DepartmentArea/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_DepartmentArea") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_DepartmentArea t_departmentarea = db.T_DepartmentAreas.Find(id);
            if (t_departmentarea == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_DepartmentAreaParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_DepartmentArea"))
			 ViewData["T_DepartmentAreaParentUrl"] = Request.UrlReferrer;
            return View(t_departmentarea);
        }
        // POST: /T_DepartmentArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_DepartmentArea t_departmentarea, string UrlReferrer)
        {
			if (!User.CanDelete("T_DepartmentArea"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_departmentarea))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_departmentarea, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_departmentarea).State = EntityState.Deleted;
            db.T_DepartmentAreas.Remove(t_departmentarea);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_DepartmentAreaParentUrl"] != null)
					{
						string parentUrl = ViewData["T_DepartmentAreaParentUrl"].ToString();
						ViewData["T_DepartmentAreaParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_departmentarea);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Facility" && AssociatedType == "T_DepartmentAreaEmployeeTypeAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_DepartmentArea obj = db.T_DepartmentAreas.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_DepartmentAreaEmployeeTypeAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_DepartmentArea", User) || !User.CanDelete("T_DepartmentArea")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_DepartmentArea t_departmentarea = db.T_DepartmentAreas.Find(id);
		if (CheckBeforeDelete(t_departmentarea))
        {
            if (!CustomDelete(t_departmentarea, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_departmentarea).State = EntityState.Deleted;
                db.T_DepartmentAreas.Remove(t_departmentarea);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_DepartmentArea", User) || !User.CanEdit("T_DepartmentArea") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_DepartmentAreaParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_DepartmentAreaEmployeeTypeAssociationID,T_Name,T_Description")] T_DepartmentArea t_departmentarea,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_DepartmentArea target = db.T_DepartmentAreas.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_departmentarea, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_departmentareaemployeetypeassociation != null)
							  db.Entry(target.t_departmentareaemployeetypeassociation).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_departmentarea,"BulkUpdate","");
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
