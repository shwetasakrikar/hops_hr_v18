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

    public partial class T_TestTypeController : BaseController
    {
        // GET: /T_TestType/
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
			var lstT_TestType = from s in db.T_TestTypes
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_TestType = searchRecords(lstT_TestType, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_TestType = sortRecords(lstT_TestType, sortBy, isAsc);
            }
            else lstT_TestType = lstT_TestType.OrderByDescending(c => c.Id);
			lstT_TestType = CustomSorting(lstT_TestType);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_TestType"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_TestType"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_TestType"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_TestType"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_TestType = lstT_TestType;
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_TestType", User) || !User.CanView("T_TestType"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_TestType.Count() > 0)
                    pageSize = _T_TestType.Count();
                return View("ExcelExport", _T_TestType.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_TestType.Count();
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
				var list = _T_TestType.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_TestTypeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_TestTypelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_TestType = _fad.FilterDropdown<T_TestType>(User,  _T_TestType, "T_TestType", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_TestType.Except(_T_TestType),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_TestType.Except(_T_TestType).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_TestType.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_TestType.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_TestType.Count() == 0 ? 1 : _T_TestType.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_TestType.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_TestTypeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_TestTypelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_TestType.Count() == 0 ? 1 : _T_TestType.Count();
                            }
							var list = _T_TestType.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_TestTypeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_TestTypelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_TestType/Details/5
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
            T_TestType t_testtype = db.T_TestTypes.Find(id);
            if (t_testtype == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_testtype);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_testtype, AssociatedType);
            ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnDetails", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnDetails", true);
			ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnDetails");
			return View(ViewBag.TemplatesName,t_testtype);
        }
        // GET: /T_TestType/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_TestType") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_TestTypeParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnCreate", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnCreate", true);
		  ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnCreate");
          return View();
        }
		// GET: /T_TestType/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_TestType") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_TestTypeParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnCreate", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnCreate", true);
			 ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnCreate");
            return View();
        }
		// POST: /T_TestType/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Name")] T_TestType t_testtype, string UrlReferrer)
        {
			CheckBeforeSave(t_testtype);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_testtype,out customcreate_hasissues,"Create"))
                {
                    db.T_TestTypes.Add(t_testtype);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_testtype,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_testtype);
			ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnCreate", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnCreate", true);
			ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnCreate");	
            return View(t_testtype);
        }
		 // GET: /T_TestType/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_TestType") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_TestTypeParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnCreate", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnCreate", true);
			ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnCreate");
            return View();
        }
		  // POST: /T_TestType/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Name")] T_TestType t_testtype,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_testtype);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_testtype,out customcreate_hasissues,"Create"))
                {
                    db.T_TestTypes.Add(t_testtype);
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
			LoadViewDataAfterOnCreate(t_testtype);
			ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnCreate", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnCreate", true);
			ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_testtype, AssociatedEntity);
			return View(t_testtype);
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
        // POST: /T_TestType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Name")] T_TestType t_testtype, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_testtype, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_testtype,out customcreate_hasissues,command))
                {
                    db.T_TestTypes.Add(t_testtype);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_testtype,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_testtype.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_testtype);
			ViewData["T_TestTypeParentUrl"] = UrlReferrer;
			ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnCreate", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnCreate", true);
			ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnCreate");
            return View(t_testtype);
        }
		// GET: /T_TestType/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_TestType") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_TestType t_testtype = db.T_TestTypes.Find(id);
            if (t_testtype == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_TestTypeParentUrl"] = UrlReferrer;
		if(ViewData["T_TestTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TestType")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TestType/Edit/" + t_testtype.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TestType/Create"))
			ViewData["T_TestTypeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_testtype);
		   ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnEdit", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnEdit", true);
		   ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnEdit");
		    var objT_TestType = new List<T_TestType>();
            ViewBag.T_TestTypeDD = new SelectList(objT_TestType, "ID", "DisplayValue"); 
          return View(t_testtype);
        }
		// POST: /T_TestType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Name")] T_TestType t_testtype,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_testtype, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_testtype,out customsave_hasissues,command))
                {
					db.Entry(t_testtype).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_testtype);
			ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnEdit", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnEdit", true);
			ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnEdit");
            return View(t_testtype);
        }
        // GET: /T_TestType/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_TestType") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TestType t_testtype = db.T_TestTypes.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_TestTypelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_TestTypes.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_TestTypeDisplayValueEdit = TempData["T_TestTypelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_TestTypelist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_TestTypeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_testtype == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_TestType/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_testtype.DisplayValue, Value = t_testtype.Id.ToString() }));
                ViewBag.EntityT_TestTypeDisplayValueEdit = newList;
				TempData["T_TestTypelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_testtype.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_testtype.DisplayValue;
                    newList[0].Value = t_testtype.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_testtype.DisplayValue, Value = t_testtype.Id.ToString() }));
                }
                ViewBag.EntityT_TestTypeDisplayValueEdit = newList;
				TempData["T_TestTypelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_TestTypeParentUrl"] = UrlReferrer;
		if(ViewData["T_TestTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TestType")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TestType/Edit/" + t_testtype.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TestType/Create"))
			ViewData["T_TestTypeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_testtype);
		   ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnEdit", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnEdit", true);
		   ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnEdit");
          return View(t_testtype);
        }
        // POST: /T_TestType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Name")] T_TestType t_testtype,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_testtype, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_testtype,out customsave_hasissues,command))
            {
				db.Entry(t_testtype).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_testtype,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_testtype.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_TestTypelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_TestTypes.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_TestTypeDisplayValueEdit = TempData["T_TestTypelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_TestTypelist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_TestTypeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_testtype);
			 ViewData["T_TestTypeParentUrl"] = UrlReferrer;
			ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnEdit", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnEdit", true);
			ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnEdit");
            return View(t_testtype);
        }
		// GET: /T_TestType/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_TestType") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_TestType t_testtype = db.T_TestTypes.Find(id);
            if (t_testtype == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_TestTypeParentUrl"] = UrlReferrer;
		if(ViewData["T_TestTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TestType"))
			ViewData["T_TestTypeParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_testtype);
			 ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnEdit", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnEdit", true);
			 ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnEdit");
          return View(t_testtype);
        }
        // POST: /T_TestType/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Name")] T_TestType t_testtype,string UrlReferrer)
        {
			CheckBeforeSave(t_testtype);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_testtype,out customsave_hasissues,"Save"))
            {
				db.Entry(t_testtype).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_testtype,"Edit","");
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
			LoadViewDataAfterOnEdit(t_testtype);
			ViewBag.T_TestTypeIsHiddenRule = checkHidden("T_TestType", "OnEdit", false);
			ViewBag.T_TestTypeIsGroupsHiddenRule = checkHidden("T_TestType", "OnEdit", true);
			ViewBag.T_TestTypeIsSetValueUIRule = checkSetValueUIRule("T_TestType", "OnEdit");
            return View(t_testtype);
        }
        // GET: /T_TestType/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_TestType") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_TestType t_testtype = db.T_TestTypes.Find(id);
            if (t_testtype == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_TestTypeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TestType"))
			 ViewData["T_TestTypeParentUrl"] = Request.UrlReferrer;
            return View(t_testtype);
        }
        // POST: /T_TestType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_TestType t_testtype, string UrlReferrer)
        {
			if (!User.CanDelete("T_TestType"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_testtype))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_testtype, out customdelete_hasissues, "Delete"))
                {
            var listT_TypeOfTest = db.T_DrugAlcoholTests.Where(p => p.T_TypeOfTestID == t_testtype.Id);
            foreach (var lst in listT_TypeOfTest)
               db.T_DrugAlcoholTests.Remove(lst);
           db.SaveChanges();
			db.Entry(t_testtype).State = EntityState.Deleted;
            db.T_TestTypes.Remove(t_testtype);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_TestTypeParentUrl"] != null)
					{
						string parentUrl = ViewData["T_TestTypeParentUrl"].ToString();
						ViewData["T_TestTypeParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_testtype);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_TestType", User) || !User.CanDelete("T_TestType")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_TestType t_testtype = db.T_TestTypes.Find(id);
		if (CheckBeforeDelete(t_testtype))
        {
            if (!CustomDelete(t_testtype, out customdelete_hasissues, "DeleteBulk"))
            {
            var listT_TypeOfTest = db.T_DrugAlcoholTests.Where(p => p.T_TypeOfTestID == id);
            foreach (var lst in listT_TypeOfTest)
               db.T_DrugAlcoholTests.Remove(lst);
           db.SaveChanges();
                db.Entry(t_testtype).State = EntityState.Deleted;
                db.T_TestTypes.Remove(t_testtype);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_TestType", User) || !User.CanEdit("T_TestType") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_TestTypeParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Name")] T_TestType t_testtype,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_TestType target = db.T_TestTypes.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_testtype, target, chkUpdate); 
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
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_testtype,"BulkUpdate","");
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
