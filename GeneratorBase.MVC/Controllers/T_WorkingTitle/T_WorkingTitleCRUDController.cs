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

    public partial class T_WorkingTitleController : BaseController
    {
        // GET: /T_WorkingTitle/
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
			var lstT_WorkingTitle = from s in db.T_WorkingTitles
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_WorkingTitle = searchRecords(lstT_WorkingTitle, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_WorkingTitle = sortRecords(lstT_WorkingTitle, sortBy, isAsc);
            }
            else lstT_WorkingTitle = lstT_WorkingTitle.OrderByDescending(c => c.Id);
			lstT_WorkingTitle = CustomSorting(lstT_WorkingTitle);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_WorkingTitle"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_WorkingTitle"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_WorkingTitle"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_WorkingTitle"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_WorkingTitle = lstT_WorkingTitle;
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_WorkingTitle", User) || !User.CanView("T_WorkingTitle"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_WorkingTitle.Count() > 0)
                    pageSize = _T_WorkingTitle.Count();
                return View("ExcelExport", _T_WorkingTitle.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_WorkingTitle.Count();
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
				var list = _T_WorkingTitle.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_WorkingTitleDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_WorkingTitlelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_WorkingTitle = _fad.FilterDropdown<T_WorkingTitle>(User,  _T_WorkingTitle, "T_WorkingTitle", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_WorkingTitle.Except(_T_WorkingTitle),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_WorkingTitle.Except(_T_WorkingTitle).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_WorkingTitle.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_WorkingTitle.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_WorkingTitle.Count() == 0 ? 1 : _T_WorkingTitle.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_WorkingTitle.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_WorkingTitleDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_WorkingTitlelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_WorkingTitle.Count() == 0 ? 1 : _T_WorkingTitle.Count();
                            }
							var list = _T_WorkingTitle.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_WorkingTitleDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_WorkingTitlelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_WorkingTitle/Details/5
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
            T_WorkingTitle t_workingtitle = db.T_WorkingTitles.Find(id);
            if (t_workingtitle == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_workingtitle);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_workingtitle, AssociatedType);
            ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnDetails", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnDetails", true);
			ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnDetails");
			return View(ViewBag.TemplatesName,t_workingtitle);
        }
        // GET: /T_WorkingTitle/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_WorkingTitle") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_WorkingTitleParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", true);
		  ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnCreate");
          return View();
        }
		// GET: /T_WorkingTitle/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_WorkingTitle") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_WorkingTitleParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", true);
			 ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnCreate");
            return View();
        }
		// POST: /T_WorkingTitle/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_WorkingTitle t_workingtitle, string UrlReferrer)
        {
			CheckBeforeSave(t_workingtitle);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_workingtitle,out customcreate_hasissues,"Create"))
                {
                    db.T_WorkingTitles.Add(t_workingtitle);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_workingtitle,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_workingtitle);
			ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", true);
			ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnCreate");	
            return View(t_workingtitle);
        }
		 // GET: /T_WorkingTitle/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_WorkingTitle") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_WorkingTitleParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", true);
			ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnCreate");
            return View();
        }
		  // POST: /T_WorkingTitle/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_WorkingTitle t_workingtitle,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_workingtitle);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_workingtitle,out customcreate_hasissues,"Create"))
                {
                    db.T_WorkingTitles.Add(t_workingtitle);
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
			LoadViewDataAfterOnCreate(t_workingtitle);
			ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", true);
			ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_workingtitle, AssociatedEntity);
			return View(t_workingtitle);
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
        // POST: /T_WorkingTitle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_WorkingTitle t_workingtitle, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_workingtitle, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_workingtitle,out customcreate_hasissues,command))
                {
                    db.T_WorkingTitles.Add(t_workingtitle);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_workingtitle,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_workingtitle.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_workingtitle);
			ViewData["T_WorkingTitleParentUrl"] = UrlReferrer;
			ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnCreate", true);
			ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnCreate");
            return View(t_workingtitle);
        }
		// GET: /T_WorkingTitle/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_WorkingTitle") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_WorkingTitle t_workingtitle = db.T_WorkingTitles.Find(id);
            if (t_workingtitle == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_WorkingTitleParentUrl"] = UrlReferrer;
		if(ViewData["T_WorkingTitleParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_WorkingTitle")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_WorkingTitle/Edit/" + t_workingtitle.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_WorkingTitle/Create"))
			ViewData["T_WorkingTitleParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_workingtitle);
		   ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", true);
		   ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnEdit");
		    var objT_WorkingTitle = new List<T_WorkingTitle>();
            ViewBag.T_WorkingTitleDD = new SelectList(objT_WorkingTitle, "ID", "DisplayValue"); 
          return View(t_workingtitle);
        }
		// POST: /T_WorkingTitle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_WorkingTitle t_workingtitle,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_workingtitle, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_workingtitle,out customsave_hasissues,command))
                {
					db.Entry(t_workingtitle).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_workingtitle);
			ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", true);
			ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnEdit");
            return View(t_workingtitle);
        }
        // GET: /T_WorkingTitle/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_WorkingTitle") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_WorkingTitle t_workingtitle = db.T_WorkingTitles.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_WorkingTitlelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_WorkingTitles.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_WorkingTitleDisplayValueEdit = TempData["T_WorkingTitlelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_WorkingTitlelist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_WorkingTitleDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_workingtitle == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_WorkingTitle/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_workingtitle.DisplayValue, Value = t_workingtitle.Id.ToString() }));
                ViewBag.EntityT_WorkingTitleDisplayValueEdit = newList;
				TempData["T_WorkingTitlelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_workingtitle.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_workingtitle.DisplayValue;
                    newList[0].Value = t_workingtitle.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_workingtitle.DisplayValue, Value = t_workingtitle.Id.ToString() }));
                }
                ViewBag.EntityT_WorkingTitleDisplayValueEdit = newList;
				TempData["T_WorkingTitlelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_WorkingTitleParentUrl"] = UrlReferrer;
		if(ViewData["T_WorkingTitleParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_WorkingTitle")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_WorkingTitle/Edit/" + t_workingtitle.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_WorkingTitle/Create"))
			ViewData["T_WorkingTitleParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_workingtitle);
		   ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", true);
		   ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnEdit");
          return View(t_workingtitle);
        }
        // POST: /T_WorkingTitle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_WorkingTitle t_workingtitle,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_workingtitle, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_workingtitle,out customsave_hasissues,command))
            {
				db.Entry(t_workingtitle).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_workingtitle,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_workingtitle.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_WorkingTitlelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_WorkingTitles.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_WorkingTitleDisplayValueEdit = TempData["T_WorkingTitlelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_WorkingTitlelist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_WorkingTitleDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_workingtitle);
			 ViewData["T_WorkingTitleParentUrl"] = UrlReferrer;
			ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", true);
			ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnEdit");
            return View(t_workingtitle);
        }
		// GET: /T_WorkingTitle/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_WorkingTitle") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_WorkingTitle t_workingtitle = db.T_WorkingTitles.Find(id);
            if (t_workingtitle == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_WorkingTitleParentUrl"] = UrlReferrer;
		if(ViewData["T_WorkingTitleParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_WorkingTitle"))
			ViewData["T_WorkingTitleParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_workingtitle);
			 ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", true);
			 ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnEdit");
          return View(t_workingtitle);
        }
        // POST: /T_WorkingTitle/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_WorkingTitle t_workingtitle,string UrlReferrer)
        {
			CheckBeforeSave(t_workingtitle);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_workingtitle,out customsave_hasissues,"Save"))
            {
				db.Entry(t_workingtitle).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_workingtitle,"Edit","");
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
			LoadViewDataAfterOnEdit(t_workingtitle);
			ViewBag.T_WorkingTitleIsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", false);
			ViewBag.T_WorkingTitleIsGroupsHiddenRule = checkHidden("T_WorkingTitle", "OnEdit", true);
			ViewBag.T_WorkingTitleIsSetValueUIRule = checkSetValueUIRule("T_WorkingTitle", "OnEdit");
            return View(t_workingtitle);
        }
        // GET: /T_WorkingTitle/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_WorkingTitle") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_WorkingTitle t_workingtitle = db.T_WorkingTitles.Find(id);
            if (t_workingtitle == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_WorkingTitleParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_WorkingTitle"))
			 ViewData["T_WorkingTitleParentUrl"] = Request.UrlReferrer;
            return View(t_workingtitle);
        }
        // POST: /T_WorkingTitle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_WorkingTitle t_workingtitle, string UrlReferrer)
        {
			if (!User.CanDelete("T_WorkingTitle"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_workingtitle))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_workingtitle, out customdelete_hasissues, "Delete"))
                {
            var listT_PositionWorkingTitleAssociation = db.T_Positions.Where(p => p.T_PositionWorkingTitleAssociationID == t_workingtitle.Id);
            foreach (var lst in listT_PositionWorkingTitleAssociation)
               db.T_Positions.Remove(lst);
           db.SaveChanges();
			db.Entry(t_workingtitle).State = EntityState.Deleted;
            db.T_WorkingTitles.Remove(t_workingtitle);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_WorkingTitleParentUrl"] != null)
					{
						string parentUrl = ViewData["T_WorkingTitleParentUrl"].ToString();
						ViewData["T_WorkingTitleParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_workingtitle);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_WorkingTitle", User) || !User.CanDelete("T_WorkingTitle")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_WorkingTitle t_workingtitle = db.T_WorkingTitles.Find(id);
		if (CheckBeforeDelete(t_workingtitle))
        {
            if (!CustomDelete(t_workingtitle, out customdelete_hasissues, "DeleteBulk"))
            {
            var listT_PositionWorkingTitleAssociation = db.T_Positions.Where(p => p.T_PositionWorkingTitleAssociationID == id);
            foreach (var lst in listT_PositionWorkingTitleAssociation)
               db.T_Positions.Remove(lst);
           db.SaveChanges();
                db.Entry(t_workingtitle).State = EntityState.Deleted;
                db.T_WorkingTitles.Remove(t_workingtitle);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_WorkingTitle", User) || !User.CanEdit("T_WorkingTitle") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_WorkingTitleParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_WorkingTitle t_workingtitle,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_WorkingTitle target = db.T_WorkingTitles.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_workingtitle, target, chkUpdate); 
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
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_workingtitle,"BulkUpdate","");
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
