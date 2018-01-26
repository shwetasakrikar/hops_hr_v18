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

    public partial class T_TerminationReasonController : BaseController
    {
        // GET: /T_TerminationReason/
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
			var lstT_TerminationReason = from s in db.T_TerminationReasons
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_TerminationReason = searchRecords(lstT_TerminationReason, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_TerminationReason = sortRecords(lstT_TerminationReason, sortBy, isAsc);
            }
            else lstT_TerminationReason = lstT_TerminationReason.OrderByDescending(c => c.Id);
			lstT_TerminationReason = CustomSorting(lstT_TerminationReason);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_TerminationReason"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_TerminationReason"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_TerminationReason"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_TerminationReason"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_TerminationReason = lstT_TerminationReason;
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_TerminationReason", User) || !User.CanView("T_TerminationReason"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_TerminationReason.Count() > 0)
                    pageSize = _T_TerminationReason.Count();
                return View("ExcelExport", _T_TerminationReason.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_TerminationReason.Count();
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
				var list = _T_TerminationReason.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_TerminationReasonDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_TerminationReasonlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_TerminationReason = _fad.FilterDropdown<T_TerminationReason>(User,  _T_TerminationReason, "T_TerminationReason", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_TerminationReason.Except(_T_TerminationReason),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_TerminationReason.Except(_T_TerminationReason).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_TerminationReason.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_TerminationReason.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_TerminationReason.Count() == 0 ? 1 : _T_TerminationReason.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_TerminationReason.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_TerminationReasonDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_TerminationReasonlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_TerminationReason.Count() == 0 ? 1 : _T_TerminationReason.Count();
                            }
							var list = _T_TerminationReason.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_TerminationReasonDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_TerminationReasonlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_TerminationReason/Details/5
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
            T_TerminationReason t_terminationreason = db.T_TerminationReasons.Find(id);
            if (t_terminationreason == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_terminationreason);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_terminationreason, AssociatedType);
            ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnDetails", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnDetails", true);
			ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnDetails");
			return View(ViewBag.TemplatesName,t_terminationreason);
        }
        // GET: /T_TerminationReason/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_TerminationReason") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_TerminationReasonParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", true);
		  ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnCreate");
          return View();
        }
		// GET: /T_TerminationReason/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_TerminationReason") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_TerminationReasonParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", true);
			 ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnCreate");
            return View();
        }
		// POST: /T_TerminationReason/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_TerminationReason t_terminationreason, string UrlReferrer)
        {
			CheckBeforeSave(t_terminationreason);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_terminationreason,out customcreate_hasissues,"Create"))
                {
                    db.T_TerminationReasons.Add(t_terminationreason);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_terminationreason,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_terminationreason);
			ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", true);
			ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnCreate");	
            return View(t_terminationreason);
        }
		 // GET: /T_TerminationReason/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_TerminationReason") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_TerminationReasonParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", true);
			ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnCreate");
            return View();
        }
		  // POST: /T_TerminationReason/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_TerminationReason t_terminationreason,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_terminationreason);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_terminationreason,out customcreate_hasissues,"Create"))
                {
                    db.T_TerminationReasons.Add(t_terminationreason);
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
			LoadViewDataAfterOnCreate(t_terminationreason);
			ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", true);
			ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_terminationreason, AssociatedEntity);
			return View(t_terminationreason);
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
        // POST: /T_TerminationReason/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_TerminationReason t_terminationreason, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_terminationreason, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_terminationreason,out customcreate_hasissues,command))
                {
                    db.T_TerminationReasons.Add(t_terminationreason);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_terminationreason,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_terminationreason.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_terminationreason);
			ViewData["T_TerminationReasonParentUrl"] = UrlReferrer;
			ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnCreate", true);
			ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnCreate");
            return View(t_terminationreason);
        }
		// GET: /T_TerminationReason/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_TerminationReason") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_TerminationReason t_terminationreason = db.T_TerminationReasons.Find(id);
            if (t_terminationreason == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_TerminationReasonParentUrl"] = UrlReferrer;
		if(ViewData["T_TerminationReasonParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TerminationReason")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TerminationReason/Edit/" + t_terminationreason.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TerminationReason/Create"))
			ViewData["T_TerminationReasonParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_terminationreason);
		   ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", true);
		   ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnEdit");
		    var objT_TerminationReason = new List<T_TerminationReason>();
            ViewBag.T_TerminationReasonDD = new SelectList(objT_TerminationReason, "ID", "DisplayValue"); 
          return View(t_terminationreason);
        }
		// POST: /T_TerminationReason/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_TerminationReason t_terminationreason,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_terminationreason, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_terminationreason,out customsave_hasissues,command))
                {
					db.Entry(t_terminationreason).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_terminationreason);
			ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", true);
			ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnEdit");
            return View(t_terminationreason);
        }
        // GET: /T_TerminationReason/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_TerminationReason") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TerminationReason t_terminationreason = db.T_TerminationReasons.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_TerminationReasonlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_TerminationReasons.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_TerminationReasonDisplayValueEdit = TempData["T_TerminationReasonlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_TerminationReasonlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_TerminationReasonDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_terminationreason == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_TerminationReason/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_terminationreason.DisplayValue, Value = t_terminationreason.Id.ToString() }));
                ViewBag.EntityT_TerminationReasonDisplayValueEdit = newList;
				TempData["T_TerminationReasonlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_terminationreason.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_terminationreason.DisplayValue;
                    newList[0].Value = t_terminationreason.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_terminationreason.DisplayValue, Value = t_terminationreason.Id.ToString() }));
                }
                ViewBag.EntityT_TerminationReasonDisplayValueEdit = newList;
				TempData["T_TerminationReasonlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_TerminationReasonParentUrl"] = UrlReferrer;
		if(ViewData["T_TerminationReasonParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TerminationReason")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TerminationReason/Edit/" + t_terminationreason.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TerminationReason/Create"))
			ViewData["T_TerminationReasonParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_terminationreason);
		   ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", true);
		   ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnEdit");
          return View(t_terminationreason);
        }
        // POST: /T_TerminationReason/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_TerminationReason t_terminationreason,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_terminationreason, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_terminationreason,out customsave_hasissues,command))
            {
				db.Entry(t_terminationreason).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_terminationreason,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_terminationreason.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_TerminationReasonlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_TerminationReasons.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_TerminationReasonDisplayValueEdit = TempData["T_TerminationReasonlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_TerminationReasonlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_TerminationReasonDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_terminationreason);
			 ViewData["T_TerminationReasonParentUrl"] = UrlReferrer;
			ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", true);
			ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnEdit");
            return View(t_terminationreason);
        }
		// GET: /T_TerminationReason/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_TerminationReason") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_TerminationReason t_terminationreason = db.T_TerminationReasons.Find(id);
            if (t_terminationreason == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_TerminationReasonParentUrl"] = UrlReferrer;
		if(ViewData["T_TerminationReasonParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TerminationReason"))
			ViewData["T_TerminationReasonParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_terminationreason);
			 ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", true);
			 ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnEdit");
          return View(t_terminationreason);
        }
        // POST: /T_TerminationReason/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_TerminationReason t_terminationreason,string UrlReferrer)
        {
			CheckBeforeSave(t_terminationreason);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_terminationreason,out customsave_hasissues,"Save"))
            {
				db.Entry(t_terminationreason).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_terminationreason,"Edit","");
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
			LoadViewDataAfterOnEdit(t_terminationreason);
			ViewBag.T_TerminationReasonIsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", false);
			ViewBag.T_TerminationReasonIsGroupsHiddenRule = checkHidden("T_TerminationReason", "OnEdit", true);
			ViewBag.T_TerminationReasonIsSetValueUIRule = checkSetValueUIRule("T_TerminationReason", "OnEdit");
            return View(t_terminationreason);
        }
        // GET: /T_TerminationReason/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_TerminationReason") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_TerminationReason t_terminationreason = db.T_TerminationReasons.Find(id);
            if (t_terminationreason == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_TerminationReasonParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TerminationReason"))
			 ViewData["T_TerminationReasonParentUrl"] = Request.UrlReferrer;
            return View(t_terminationreason);
        }
        // POST: /T_TerminationReason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_TerminationReason t_terminationreason, string UrlReferrer)
        {
			if (!User.CanDelete("T_TerminationReason"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_terminationreason))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_terminationreason, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_terminationreason).State = EntityState.Deleted;
            db.T_TerminationReasons.Remove(t_terminationreason);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_TerminationReasonParentUrl"] != null)
					{
						string parentUrl = ViewData["T_TerminationReasonParentUrl"].ToString();
						ViewData["T_TerminationReasonParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_terminationreason);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_TerminationReason", User) || !User.CanDelete("T_TerminationReason")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_TerminationReason t_terminationreason = db.T_TerminationReasons.Find(id);
		if (CheckBeforeDelete(t_terminationreason))
        {
            if (!CustomDelete(t_terminationreason, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_terminationreason).State = EntityState.Deleted;
                db.T_TerminationReasons.Remove(t_terminationreason);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_TerminationReason", User) || !User.CanEdit("T_TerminationReason") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_TerminationReasonParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_TerminationReason t_terminationreason,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_TerminationReason target = db.T_TerminationReasons.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_terminationreason, target, chkUpdate); 
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
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_terminationreason,"BulkUpdate","");
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
