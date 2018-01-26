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

    public partial class T_ClassCodeController : BaseController
    {
        // GET: /T_ClassCode/
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
			var lstT_ClassCode = from s in db.T_ClassCodes
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_ClassCode = searchRecords(lstT_ClassCode, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_ClassCode = sortRecords(lstT_ClassCode, sortBy, isAsc);
            }
            else lstT_ClassCode = lstT_ClassCode.OrderBy(c=>c.T_Code);
			lstT_ClassCode = CustomSorting(lstT_ClassCode);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_ClassCode"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_ClassCode"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_ClassCode"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_ClassCode"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_ClassCode = lstT_ClassCode.Include(t=>t.t_classeeocode);
		 if (HostingEntity == "T_EEOCode" && AssociatedType == "T_ClassEEOCode")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_ClassCode = _T_ClassCode.Where(p => p.T_ClassEEOCodeID == hostid);
			 }
			 else
			     _T_ClassCode = _T_ClassCode.Where(p => p.T_ClassEEOCodeID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_ClassCode", User) || !User.CanView("T_ClassCode"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_ClassCode.Count() > 0)
                    pageSize = _T_ClassCode.Count();
                return View("ExcelExport", _T_ClassCode.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_ClassCode.Count();
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
				var list = _T_ClassCode.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_ClassCodeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_ClassCodelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_ClassCode = _fad.FilterDropdown<T_ClassCode>(User,  _T_ClassCode, "T_ClassCode", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_ClassCode.Except(_T_ClassCode),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_ClassCode.Except(_T_ClassCode).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_ClassCode.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_ClassCode.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_ClassCode.Count() == 0 ? 1 : _T_ClassCode.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_ClassCode.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_ClassCodeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_ClassCodelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_ClassCode.Count() == 0 ? 1 : _T_ClassCode.Count();
                            }
							var list = _T_ClassCode.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_ClassCodeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_ClassCodelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_ClassCode/Details/5
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
            T_ClassCode t_classcode = db.T_ClassCodes.Find(id);
            if (t_classcode == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_classcode);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_classcode, AssociatedType);
            ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnDetails", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnDetails", true);
			ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnDetails");
			return View(ViewBag.TemplatesName,t_classcode);
        }
        // GET: /T_ClassCode/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_ClassCode") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_ClassCodeParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnCreate", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnCreate", true);
		  ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnCreate");
          return View();
        }
		// GET: /T_ClassCode/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_ClassCode") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_ClassCodeParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnCreate", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnCreate", true);
			 ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnCreate");
            return View();
        }
		// POST: /T_ClassCode/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_Code,T_Title,T_ClassEEOCodeID")] T_ClassCode t_classcode, string UrlReferrer)
        {
			CheckBeforeSave(t_classcode);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_classcode,out customcreate_hasissues,"Create"))
                {
                    db.T_ClassCodes.Add(t_classcode);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_classcode,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_classcode);
			ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnCreate", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnCreate", true);
			ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnCreate");	
            return View(t_classcode);
        }
		 // GET: /T_ClassCode/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_ClassCode") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_ClassCodeParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnCreate", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnCreate", true);
			ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnCreate");
            return View();
        }
		  // POST: /T_ClassCode/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_Code,T_Title,T_ClassEEOCodeID")] T_ClassCode t_classcode,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_classcode);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_classcode,out customcreate_hasissues,"Create"))
                {
                    db.T_ClassCodes.Add(t_classcode);
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
			LoadViewDataAfterOnCreate(t_classcode);
			ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnCreate", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnCreate", true);
			ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_classcode, AssociatedEntity);
			return View(t_classcode);
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
        // POST: /T_ClassCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_Code,T_Title,T_ClassEEOCodeID")] T_ClassCode t_classcode, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_classcode, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_classcode,out customcreate_hasissues,command))
                {
                    db.T_ClassCodes.Add(t_classcode);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_classcode,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_classcode.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_classcode);
			ViewData["T_ClassCodeParentUrl"] = UrlReferrer;
			ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnCreate", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnCreate", true);
			ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnCreate");
            return View(t_classcode);
        }
		// GET: /T_ClassCode/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_ClassCode") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_ClassCode t_classcode = db.T_ClassCodes.Find(id);
            if (t_classcode == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_ClassCodeParentUrl"] = UrlReferrer;
		if(ViewData["T_ClassCodeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClassCode")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClassCode/Edit/" + t_classcode.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClassCode/Create"))
			ViewData["T_ClassCodeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_classcode);
		   ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnEdit", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnEdit", true);
		   ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnEdit");
		    var objT_ClassCode = new List<T_ClassCode>();
            ViewBag.T_ClassCodeDD = new SelectList(objT_ClassCode, "ID", "DisplayValue"); 
          return View(t_classcode);
        }
		// POST: /T_ClassCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_Code,T_Title,T_ClassEEOCodeID")] T_ClassCode t_classcode,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_classcode, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_classcode,out customsave_hasissues,command))
                {
					db.Entry(t_classcode).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_classcode);
			ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnEdit", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnEdit", true);
			ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnEdit");
            return View(t_classcode);
        }
        // GET: /T_ClassCode/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_ClassCode") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_ClassCode t_classcode = db.T_ClassCodes.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_ClassCodelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_ClassCodes.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_ClassCodeDisplayValueEdit = TempData["T_ClassCodelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_ClassCodelist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_ClassCodeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_classcode == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClassCode/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_classcode.DisplayValue, Value = t_classcode.Id.ToString() }));
                ViewBag.EntityT_ClassCodeDisplayValueEdit = newList;
				TempData["T_ClassCodelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_classcode.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_classcode.DisplayValue;
                    newList[0].Value = t_classcode.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_classcode.DisplayValue, Value = t_classcode.Id.ToString() }));
                }
                ViewBag.EntityT_ClassCodeDisplayValueEdit = newList;
				TempData["T_ClassCodelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_ClassCodeParentUrl"] = UrlReferrer;
		if(ViewData["T_ClassCodeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClassCode")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClassCode/Edit/" + t_classcode.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClassCode/Create"))
			ViewData["T_ClassCodeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_classcode);
		   ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnEdit", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnEdit", true);
		   ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnEdit");
          return View(t_classcode);
        }
        // POST: /T_ClassCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_Code,T_Title,T_ClassEEOCodeID")] T_ClassCode t_classcode,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_classcode, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_classcode,out customsave_hasissues,command))
            {
				db.Entry(t_classcode).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_classcode,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_classcode.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_ClassCodelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_ClassCodes.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_ClassCodeDisplayValueEdit = TempData["T_ClassCodelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_ClassCodelist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_ClassCodeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_classcode);
			 ViewData["T_ClassCodeParentUrl"] = UrlReferrer;
			ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnEdit", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnEdit", true);
			ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnEdit");
            return View(t_classcode);
        }
		// GET: /T_ClassCode/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_ClassCode") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_ClassCode t_classcode = db.T_ClassCodes.Find(id);
            if (t_classcode == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_ClassCodeParentUrl"] = UrlReferrer;
		if(ViewData["T_ClassCodeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClassCode"))
			ViewData["T_ClassCodeParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_classcode);
			 ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnEdit", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnEdit", true);
			 ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnEdit");
          return View(t_classcode);
        }
        // POST: /T_ClassCode/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_Code,T_Title,T_ClassEEOCodeID")] T_ClassCode t_classcode,string UrlReferrer)
        {
			CheckBeforeSave(t_classcode);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_classcode,out customsave_hasissues,"Save"))
            {
				db.Entry(t_classcode).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_classcode,"Edit","");
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
			LoadViewDataAfterOnEdit(t_classcode);
			ViewBag.T_ClassCodeIsHiddenRule = checkHidden("T_ClassCode", "OnEdit", false);
			ViewBag.T_ClassCodeIsGroupsHiddenRule = checkHidden("T_ClassCode", "OnEdit", true);
			ViewBag.T_ClassCodeIsSetValueUIRule = checkSetValueUIRule("T_ClassCode", "OnEdit");
            return View(t_classcode);
        }
        // GET: /T_ClassCode/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_ClassCode") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_ClassCode t_classcode = db.T_ClassCodes.Find(id);
            if (t_classcode == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_ClassCodeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_ClassCode"))
			 ViewData["T_ClassCodeParentUrl"] = Request.UrlReferrer;
            return View(t_classcode);
        }
        // POST: /T_ClassCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_ClassCode t_classcode, string UrlReferrer)
        {
			if (!User.CanDelete("T_ClassCode"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_classcode))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_classcode, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_classcode).State = EntityState.Deleted;
            db.T_ClassCodes.Remove(t_classcode);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_ClassCodeParentUrl"] != null)
					{
						string parentUrl = ViewData["T_ClassCodeParentUrl"].ToString();
						ViewData["T_ClassCodeParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_classcode);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_EEOCode" && AssociatedType == "T_ClassEEOCode")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_ClassCode obj = db.T_ClassCodes.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_ClassEEOCodeID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_ClassCode", User) || !User.CanDelete("T_ClassCode")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_ClassCode t_classcode = db.T_ClassCodes.Find(id);
		if (CheckBeforeDelete(t_classcode))
        {
            if (!CustomDelete(t_classcode, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_classcode).State = EntityState.Deleted;
                db.T_ClassCodes.Remove(t_classcode);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_ClassCode", User) || !User.CanEdit("T_ClassCode") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_ClassCodeParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_Code,T_Title,T_ClassEEOCodeID")] T_ClassCode t_classcode,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_ClassCode target = db.T_ClassCodes.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_classcode, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_classeeocode != null)
							  db.Entry(target.t_classeeocode).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_classcode,"BulkUpdate","");
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
