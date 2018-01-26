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

    public partial class T_RefusalController : BaseController
    {
        // GET: /T_Refusal/
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
			var lstT_Refusal = from s in db.T_Refusals
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Refusal = searchRecords(lstT_Refusal, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Refusal = sortRecords(lstT_Refusal, sortBy, isAsc);
            }
            else lstT_Refusal = lstT_Refusal.OrderByDescending(c => c.Id);
			lstT_Refusal = CustomSorting(lstT_Refusal);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Refusal"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Refusal"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Refusal"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Refusal"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_Refusal = lstT_Refusal;
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_Refusal", User) || !User.CanView("T_Refusal"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_Refusal.Count() > 0)
                    pageSize = _T_Refusal.Count();
                return View("ExcelExport", _T_Refusal.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Refusal.Count();
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
				var list = _T_Refusal.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_RefusalDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_Refusallist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_Refusal = _fad.FilterDropdown<T_Refusal>(User,  _T_Refusal, "T_Refusal", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_Refusal.Except(_T_Refusal),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_Refusal.Except(_T_Refusal).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_Refusal.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_Refusal.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_Refusal.Count() == 0 ? 1 : _T_Refusal.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_Refusal.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_RefusalDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Refusallist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_Refusal.Count() == 0 ? 1 : _T_Refusal.Count();
                            }
							var list = _T_Refusal.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_RefusalDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Refusallist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_Refusal/Details/5
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
            T_Refusal t_refusal = db.T_Refusals.Find(id);
            if (t_refusal == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_refusal);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_refusal, AssociatedType);
            ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnDetails", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnDetails", true);
			ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnDetails");
			return View(ViewBag.TemplatesName,t_refusal);
        }
        // GET: /T_Refusal/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_Refusal") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_RefusalParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnCreate", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnCreate", true);
		  ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnCreate");
          return View();
        }
		// GET: /T_Refusal/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_Refusal") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_RefusalParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnCreate", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnCreate", true);
			 ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnCreate");
            return View();
        }
		// POST: /T_Refusal/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Refusal t_refusal, string UrlReferrer)
        {
			CheckBeforeSave(t_refusal);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_refusal,out customcreate_hasissues,"Create"))
                {
                    db.T_Refusals.Add(t_refusal);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_refusal,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_refusal);
			ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnCreate", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnCreate", true);
			ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnCreate");	
            return View(t_refusal);
        }
		 // GET: /T_Refusal/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_Refusal") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_RefusalParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnCreate", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnCreate", true);
			ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnCreate");
            return View();
        }
		  // POST: /T_Refusal/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Refusal t_refusal,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_refusal);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_refusal,out customcreate_hasissues,"Create"))
                {
                    db.T_Refusals.Add(t_refusal);
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
			LoadViewDataAfterOnCreate(t_refusal);
			ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnCreate", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnCreate", true);
			ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_refusal, AssociatedEntity);
			return View(t_refusal);
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
        // POST: /T_Refusal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Refusal t_refusal, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_refusal, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_refusal,out customcreate_hasissues,command))
                {
                    db.T_Refusals.Add(t_refusal);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_refusal,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_refusal.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_refusal);
			ViewData["T_RefusalParentUrl"] = UrlReferrer;
			ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnCreate", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnCreate", true);
			ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnCreate");
            return View(t_refusal);
        }
		// GET: /T_Refusal/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Refusal") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_Refusal t_refusal = db.T_Refusals.Find(id);
            if (t_refusal == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_RefusalParentUrl"] = UrlReferrer;
		if(ViewData["T_RefusalParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Refusal")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Refusal/Edit/" + t_refusal.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Refusal/Create"))
			ViewData["T_RefusalParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_refusal);
		   ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnEdit", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnEdit", true);
		   ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnEdit");
		    var objT_Refusal = new List<T_Refusal>();
            ViewBag.T_RefusalDD = new SelectList(objT_Refusal, "ID", "DisplayValue"); 
          return View(t_refusal);
        }
		// POST: /T_Refusal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Refusal t_refusal,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_refusal, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_refusal,out customsave_hasissues,command))
                {
					db.Entry(t_refusal).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_refusal);
			ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnEdit", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnEdit", true);
			ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnEdit");
            return View(t_refusal);
        }
        // GET: /T_Refusal/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_Refusal") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Refusal t_refusal = db.T_Refusals.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Refusallist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Refusals.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_RefusalDisplayValueEdit = TempData["T_Refusallist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Refusallist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_RefusalDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_refusal == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_Refusal/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_refusal.DisplayValue, Value = t_refusal.Id.ToString() }));
                ViewBag.EntityT_RefusalDisplayValueEdit = newList;
				TempData["T_Refusallist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_refusal.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_refusal.DisplayValue;
                    newList[0].Value = t_refusal.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_refusal.DisplayValue, Value = t_refusal.Id.ToString() }));
                }
                ViewBag.EntityT_RefusalDisplayValueEdit = newList;
				TempData["T_Refusallist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_RefusalParentUrl"] = UrlReferrer;
		if(ViewData["T_RefusalParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Refusal")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Refusal/Edit/" + t_refusal.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Refusal/Create"))
			ViewData["T_RefusalParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_refusal);
		   ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnEdit", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnEdit", true);
		   ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnEdit");
          return View(t_refusal);
        }
        // POST: /T_Refusal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Refusal t_refusal,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_refusal, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_refusal,out customsave_hasissues,command))
            {
				db.Entry(t_refusal).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_refusal,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_refusal.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_Refusallist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Refusals.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_RefusalDisplayValueEdit = TempData["T_Refusallist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Refusallist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_RefusalDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_refusal);
			 ViewData["T_RefusalParentUrl"] = UrlReferrer;
			ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnEdit", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnEdit", true);
			ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnEdit");
            return View(t_refusal);
        }
		// GET: /T_Refusal/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Refusal") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_Refusal t_refusal = db.T_Refusals.Find(id);
            if (t_refusal == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_RefusalParentUrl"] = UrlReferrer;
		if(ViewData["T_RefusalParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Refusal"))
			ViewData["T_RefusalParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_refusal);
			 ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnEdit", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnEdit", true);
			 ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnEdit");
          return View(t_refusal);
        }
        // POST: /T_Refusal/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Refusal t_refusal,string UrlReferrer)
        {
			CheckBeforeSave(t_refusal);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_refusal,out customsave_hasissues,"Save"))
            {
				db.Entry(t_refusal).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_refusal,"Edit","");
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
			LoadViewDataAfterOnEdit(t_refusal);
			ViewBag.T_RefusalIsHiddenRule = checkHidden("T_Refusal", "OnEdit", false);
			ViewBag.T_RefusalIsGroupsHiddenRule = checkHidden("T_Refusal", "OnEdit", true);
			ViewBag.T_RefusalIsSetValueUIRule = checkSetValueUIRule("T_Refusal", "OnEdit");
            return View(t_refusal);
        }
        // GET: /T_Refusal/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_Refusal") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_Refusal t_refusal = db.T_Refusals.Find(id);
            if (t_refusal == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_RefusalParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Refusal"))
			 ViewData["T_RefusalParentUrl"] = Request.UrlReferrer;
            return View(t_refusal);
        }
        // POST: /T_Refusal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_Refusal t_refusal, string UrlReferrer)
        {
			if (!User.CanDelete("T_Refusal"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_refusal))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_refusal, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_refusal).State = EntityState.Deleted;
            db.T_Refusals.Remove(t_refusal);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_RefusalParentUrl"] != null)
					{
						string parentUrl = ViewData["T_RefusalParentUrl"].ToString();
						ViewData["T_RefusalParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_refusal);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_Refusal", User) || !User.CanDelete("T_Refusal")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_Refusal t_refusal = db.T_Refusals.Find(id);
		if (CheckBeforeDelete(t_refusal))
        {
            if (!CustomDelete(t_refusal, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_refusal).State = EntityState.Deleted;
                db.T_Refusals.Remove(t_refusal);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_Refusal", User) || !User.CanEdit("T_Refusal") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_RefusalParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Refusal t_refusal,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_Refusal target = db.T_Refusals.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_refusal, target, chkUpdate); 
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
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_refusal,"BulkUpdate","");
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
