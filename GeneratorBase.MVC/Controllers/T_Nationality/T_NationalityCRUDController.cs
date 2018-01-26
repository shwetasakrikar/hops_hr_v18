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

    public partial class T_NationalityController : BaseController
    {
        // GET: /T_Nationality/
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
			var lstT_Nationality = from s in db.T_Nationalitys
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Nationality = searchRecords(lstT_Nationality, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Nationality = sortRecords(lstT_Nationality, sortBy, isAsc);
            }
            else lstT_Nationality = lstT_Nationality.OrderByDescending(c => c.Id);
			lstT_Nationality = CustomSorting(lstT_Nationality);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Nationality"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Nationality"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Nationality"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Nationality"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_Nationality = lstT_Nationality;
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_Nationality", User) || !User.CanView("T_Nationality"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_Nationality.Count() > 0)
                    pageSize = _T_Nationality.Count();
                return View("ExcelExport", _T_Nationality.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Nationality.Count();
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
				var list = _T_Nationality.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_NationalityDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_Nationalitylist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_Nationality = _fad.FilterDropdown<T_Nationality>(User,  _T_Nationality, "T_Nationality", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_Nationality.Except(_T_Nationality),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_Nationality.Except(_T_Nationality).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_Nationality.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_Nationality.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_Nationality.Count() == 0 ? 1 : _T_Nationality.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_Nationality.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_NationalityDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Nationalitylist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_Nationality.Count() == 0 ? 1 : _T_Nationality.Count();
                            }
							var list = _T_Nationality.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_NationalityDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Nationalitylist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_Nationality/Details/5
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
            T_Nationality t_nationality = db.T_Nationalitys.Find(id);
            if (t_nationality == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_nationality);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_nationality, AssociatedType);
            ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnDetails", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnDetails", true);
			ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnDetails");
			return View(ViewBag.TemplatesName,t_nationality);
        }
        // GET: /T_Nationality/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_Nationality") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_NationalityParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnCreate", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnCreate", true);
		  ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnCreate");
          return View();
        }
		// GET: /T_Nationality/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_Nationality") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_NationalityParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnCreate", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnCreate", true);
			 ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnCreate");
            return View();
        }
		// POST: /T_Nationality/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Nationality t_nationality, string UrlReferrer)
        {
			CheckBeforeSave(t_nationality);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_nationality,out customcreate_hasissues,"Create"))
                {
                    db.T_Nationalitys.Add(t_nationality);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_nationality,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_nationality);
			ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnCreate", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnCreate", true);
			ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnCreate");	
            return View(t_nationality);
        }
		 // GET: /T_Nationality/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_Nationality") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_NationalityParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnCreate", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnCreate", true);
			ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnCreate");
            return View();
        }
		  // POST: /T_Nationality/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Nationality t_nationality,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_nationality);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_nationality,out customcreate_hasissues,"Create"))
                {
                    db.T_Nationalitys.Add(t_nationality);
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
			LoadViewDataAfterOnCreate(t_nationality);
			ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnCreate", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnCreate", true);
			ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_nationality, AssociatedEntity);
			return View(t_nationality);
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
        // POST: /T_Nationality/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Nationality t_nationality, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_nationality, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_nationality,out customcreate_hasissues,command))
                {
                    db.T_Nationalitys.Add(t_nationality);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_nationality,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_nationality.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_nationality);
			ViewData["T_NationalityParentUrl"] = UrlReferrer;
			ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnCreate", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnCreate", true);
			ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnCreate");
            return View(t_nationality);
        }
		// GET: /T_Nationality/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Nationality") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_Nationality t_nationality = db.T_Nationalitys.Find(id);
            if (t_nationality == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_NationalityParentUrl"] = UrlReferrer;
		if(ViewData["T_NationalityParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Nationality")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Nationality/Edit/" + t_nationality.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Nationality/Create"))
			ViewData["T_NationalityParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_nationality);
		   ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnEdit", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnEdit", true);
		   ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnEdit");
		    var objT_Nationality = new List<T_Nationality>();
            ViewBag.T_NationalityDD = new SelectList(objT_Nationality, "ID", "DisplayValue"); 
          return View(t_nationality);
        }
		// POST: /T_Nationality/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Nationality t_nationality,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_nationality, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_nationality,out customsave_hasissues,command))
                {
					db.Entry(t_nationality).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_nationality);
			ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnEdit", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnEdit", true);
			ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnEdit");
            return View(t_nationality);
        }
        // GET: /T_Nationality/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_Nationality") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Nationality t_nationality = db.T_Nationalitys.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Nationalitylist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Nationalitys.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_NationalityDisplayValueEdit = TempData["T_Nationalitylist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Nationalitylist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_NationalityDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_nationality == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_Nationality/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_nationality.DisplayValue, Value = t_nationality.Id.ToString() }));
                ViewBag.EntityT_NationalityDisplayValueEdit = newList;
				TempData["T_Nationalitylist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_nationality.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_nationality.DisplayValue;
                    newList[0].Value = t_nationality.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_nationality.DisplayValue, Value = t_nationality.Id.ToString() }));
                }
                ViewBag.EntityT_NationalityDisplayValueEdit = newList;
				TempData["T_Nationalitylist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_NationalityParentUrl"] = UrlReferrer;
		if(ViewData["T_NationalityParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Nationality")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Nationality/Edit/" + t_nationality.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Nationality/Create"))
			ViewData["T_NationalityParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_nationality);
		   ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnEdit", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnEdit", true);
		   ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnEdit");
          return View(t_nationality);
        }
        // POST: /T_Nationality/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Nationality t_nationality,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_nationality, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_nationality,out customsave_hasissues,command))
            {
				db.Entry(t_nationality).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_nationality,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_nationality.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_Nationalitylist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Nationalitys.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_NationalityDisplayValueEdit = TempData["T_Nationalitylist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Nationalitylist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_NationalityDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_nationality);
			 ViewData["T_NationalityParentUrl"] = UrlReferrer;
			ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnEdit", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnEdit", true);
			ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnEdit");
            return View(t_nationality);
        }
		// GET: /T_Nationality/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Nationality") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_Nationality t_nationality = db.T_Nationalitys.Find(id);
            if (t_nationality == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_NationalityParentUrl"] = UrlReferrer;
		if(ViewData["T_NationalityParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Nationality"))
			ViewData["T_NationalityParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_nationality);
			 ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnEdit", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnEdit", true);
			 ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnEdit");
          return View(t_nationality);
        }
        // POST: /T_Nationality/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Nationality t_nationality,string UrlReferrer)
        {
			CheckBeforeSave(t_nationality);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_nationality,out customsave_hasissues,"Save"))
            {
				db.Entry(t_nationality).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_nationality,"Edit","");
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
			LoadViewDataAfterOnEdit(t_nationality);
			ViewBag.T_NationalityIsHiddenRule = checkHidden("T_Nationality", "OnEdit", false);
			ViewBag.T_NationalityIsGroupsHiddenRule = checkHidden("T_Nationality", "OnEdit", true);
			ViewBag.T_NationalityIsSetValueUIRule = checkSetValueUIRule("T_Nationality", "OnEdit");
            return View(t_nationality);
        }
        // GET: /T_Nationality/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_Nationality") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_Nationality t_nationality = db.T_Nationalitys.Find(id);
            if (t_nationality == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_NationalityParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Nationality"))
			 ViewData["T_NationalityParentUrl"] = Request.UrlReferrer;
            return View(t_nationality);
        }
        // POST: /T_Nationality/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_Nationality t_nationality, string UrlReferrer)
        {
			if (!User.CanDelete("T_Nationality"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_nationality))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_nationality, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_nationality).State = EntityState.Deleted;
            db.T_Nationalitys.Remove(t_nationality);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_NationalityParentUrl"] != null)
					{
						string parentUrl = ViewData["T_NationalityParentUrl"].ToString();
						ViewData["T_NationalityParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_nationality);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_Nationality", User) || !User.CanDelete("T_Nationality")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_Nationality t_nationality = db.T_Nationalitys.Find(id);
		if (CheckBeforeDelete(t_nationality))
        {
            if (!CustomDelete(t_nationality, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_nationality).State = EntityState.Deleted;
                db.T_Nationalitys.Remove(t_nationality);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_Nationality", User) || !User.CanEdit("T_Nationality") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_NationalityParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name,T_Description")] T_Nationality t_nationality,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_Nationality target = db.T_Nationalitys.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_nationality, target, chkUpdate); 
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
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_nationality,"BulkUpdate","");
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
