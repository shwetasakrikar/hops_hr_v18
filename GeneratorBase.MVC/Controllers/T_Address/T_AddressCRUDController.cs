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

    public partial class T_AddressController : BaseController
    {
        // GET: /T_Address/
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
			var lstT_Address = from s in db.T_Addresss
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Address = searchRecords(lstT_Address, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Address = sortRecords(lstT_Address, sortBy, isAsc);
            }
            else lstT_Address = lstT_Address.OrderByDescending(c => c.Id);
			lstT_Address = CustomSorting(lstT_Address);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Address"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_Address"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Address"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_Address"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_Address = lstT_Address.Include(t=>t.t_addresscountry).Include(t=>t.t_addressstate).Include(t=>t.t_addresscity);
		 if (HostingEntity == "T_Country" && AssociatedType == "T_AddressCountry")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Address = _T_Address.Where(p => p.T_AddressCountryID == hostid);
			 }
			 else
			     _T_Address = _T_Address.Where(p => p.T_AddressCountryID == null);
         }
		 if (HostingEntity == "T_State" && AssociatedType == "T_AddressState")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Address = _T_Address.Where(p => p.T_AddressStateID == hostid);
			 }
			 else
			     _T_Address = _T_Address.Where(p => p.T_AddressStateID == null);
         }
		 if (HostingEntity == "T_City" && AssociatedType == "T_AddressCity")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_Address = _T_Address.Where(p => p.T_AddressCityID == hostid);
			 }
			 else
			     _T_Address = _T_Address.Where(p => p.T_AddressCityID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_Address", User) || !User.CanView("T_Address"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_Address.Count() > 0)
                    pageSize = _T_Address.Count();
                return View("ExcelExport", _T_Address.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Address.Count();
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
				var list = _T_Address.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_AddressDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_Addresslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_Address = _fad.FilterDropdown<T_Address>(User,  _T_Address, "T_Address", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_Address.Except(_T_Address),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_Address.Except(_T_Address).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_Address.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_Address.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_Address.Count() == 0 ? 1 : _T_Address.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_Address.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_AddressDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Addresslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_Address.Count() == 0 ? 1 : _T_Address.Count();
                            }
							var list = _T_Address.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_AddressDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_Addresslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_Address/Details/5
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
            T_Address t_address = db.T_Addresss.Find(id);
            if (t_address == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_address);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_address, AssociatedType);
            ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnDetails", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnDetails", true);
			ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnDetails");
			return View(ViewBag.TemplatesName,t_address);
        }
        // GET: /T_Address/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_Address") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_AddressParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnCreate", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnCreate", true);
		  ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnCreate");
          return View();
        }
		// GET: /T_Address/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_Address") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_AddressParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnCreate", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnCreate", true);
			 ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnCreate");
            return View();
        }
		// POST: /T_Address/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_AddressLine1,T_AddressLine2,T_ZipCode,T_AddressCountryID,T_AddressStateID,T_AddressCityID")] T_Address t_address, string UrlReferrer)
        {
			CheckBeforeSave(t_address);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_address,out customcreate_hasissues,"Create"))
                {
                    db.T_Addresss.Add(t_address);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_address,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_address);
			ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnCreate", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnCreate", true);
			ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnCreate");	
            return View(t_address);
        }
		 // GET: /T_Address/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_Address") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_AddressParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnCreate", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnCreate", true);
			ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnCreate");
            return View();
        }
		  // POST: /T_Address/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_AddressLine1,T_AddressLine2,T_ZipCode,T_AddressCountryID,T_AddressStateID,T_AddressCityID")] T_Address t_address,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_address);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_address,out customcreate_hasissues,"Create"))
                {
                    db.T_Addresss.Add(t_address);
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
			LoadViewDataAfterOnCreate(t_address);
			ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnCreate", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnCreate", true);
			ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_address, AssociatedEntity);
			return View(t_address);
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
        // POST: /T_Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_AddressLine1,T_AddressLine2,T_ZipCode,T_AddressCountryID,T_AddressStateID,T_AddressCityID")] T_Address t_address, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_address, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_address,out customcreate_hasissues,command))
                {
                    db.T_Addresss.Add(t_address);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_address,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_address.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_address);
			ViewData["T_AddressParentUrl"] = UrlReferrer;
			ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnCreate", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnCreate", true);
			ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnCreate");
            return View(t_address);
        }
		// GET: /T_Address/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Address") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_Address t_address = db.T_Addresss.Find(id);
            if (t_address == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_AddressParentUrl"] = UrlReferrer;
		if(ViewData["T_AddressParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Address")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Address/Edit/" + t_address.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Address/Create"))
			ViewData["T_AddressParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_address);
		   ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnEdit", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnEdit", true);
		   ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnEdit");
		    var objT_Address = new List<T_Address>();
            ViewBag.T_AddressDD = new SelectList(objT_Address, "ID", "DisplayValue"); 
          return View(t_address);
        }
		// POST: /T_Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_AddressLine1,T_AddressLine2,T_ZipCode,T_AddressCountryID,T_AddressStateID,T_AddressCityID")] T_Address t_address,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_address, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_address,out customsave_hasissues,command))
                {
					db.Entry(t_address).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_address);
			ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnEdit", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnEdit", true);
			ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnEdit");
            return View(t_address);
        }
        // GET: /T_Address/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_Address") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Address t_address = db.T_Addresss.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_Addresslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Addresss.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_AddressDisplayValueEdit = TempData["T_Addresslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Addresslist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_AddressDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_address == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_Address/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_address.DisplayValue, Value = t_address.Id.ToString() }));
                ViewBag.EntityT_AddressDisplayValueEdit = newList;
				TempData["T_Addresslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_address.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_address.DisplayValue;
                    newList[0].Value = t_address.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_address.DisplayValue, Value = t_address.Id.ToString() }));
                }
                ViewBag.EntityT_AddressDisplayValueEdit = newList;
				TempData["T_Addresslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_AddressParentUrl"] = UrlReferrer;
		if(ViewData["T_AddressParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Address")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Address/Edit/" + t_address.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_Address/Create"))
			ViewData["T_AddressParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_address);
		   ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnEdit", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnEdit", true);
		   ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnEdit");
          return View(t_address);
        }
        // POST: /T_Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_AddressLine1,T_AddressLine2,T_ZipCode,T_AddressCountryID,T_AddressStateID,T_AddressCityID")] T_Address t_address,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_address, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_address,out customsave_hasissues,command))
            {
				db.Entry(t_address).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_address,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_address.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_Addresslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_Addresss.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_AddressDisplayValueEdit = TempData["T_Addresslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_Addresslist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_AddressDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_address);
			 ViewData["T_AddressParentUrl"] = UrlReferrer;
			ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnEdit", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnEdit", true);
			ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnEdit");
            return View(t_address);
        }
		// GET: /T_Address/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_Address") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_Address t_address = db.T_Addresss.Find(id);
            if (t_address == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_AddressParentUrl"] = UrlReferrer;
		if(ViewData["T_AddressParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Address"))
			ViewData["T_AddressParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_address);
			 ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnEdit", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnEdit", true);
			 ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnEdit");
          return View(t_address);
        }
        // POST: /T_Address/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_AddressLine1,T_AddressLine2,T_ZipCode,T_AddressCountryID,T_AddressStateID,T_AddressCityID")] T_Address t_address,string UrlReferrer)
        {
			CheckBeforeSave(t_address);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_address,out customsave_hasissues,"Save"))
            {
				db.Entry(t_address).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_address,"Edit","");
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
			LoadViewDataAfterOnEdit(t_address);
			ViewBag.T_AddressIsHiddenRule = checkHidden("T_Address", "OnEdit", false);
			ViewBag.T_AddressIsGroupsHiddenRule = checkHidden("T_Address", "OnEdit", true);
			ViewBag.T_AddressIsSetValueUIRule = checkSetValueUIRule("T_Address", "OnEdit");
            return View(t_address);
        }
        // GET: /T_Address/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_Address") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_Address t_address = db.T_Addresss.Find(id);
            if (t_address == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_AddressParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_Address"))
			 ViewData["T_AddressParentUrl"] = Request.UrlReferrer;
            return View(t_address);
        }
        // POST: /T_Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_Address t_address, string UrlReferrer)
        {
			if (!User.CanDelete("T_Address"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_address))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_address, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_address).State = EntityState.Deleted;
            db.T_Addresss.Remove(t_address);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_AddressParentUrl"] != null)
					{
						string parentUrl = ViewData["T_AddressParentUrl"].ToString();
						ViewData["T_AddressParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_address);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Country" && AssociatedType == "T_AddressCountry")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Address obj = db.T_Addresss.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_AddressCountryID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_State" && AssociatedType == "T_AddressState")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Address obj = db.T_Addresss.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_AddressStateID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_City" && AssociatedType == "T_AddressCity")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_Address obj = db.T_Addresss.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_AddressCityID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_Address", User) || !User.CanDelete("T_Address")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_Address t_address = db.T_Addresss.Find(id);
		if (CheckBeforeDelete(t_address))
        {
            if (!CustomDelete(t_address, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_address).State = EntityState.Deleted;
                db.T_Addresss.Remove(t_address);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_Address", User) || !User.CanEdit("T_Address") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_AddressParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_AddressLine1,T_AddressLine2,T_ZipCode,T_AddressCountryID,T_AddressStateID,T_AddressCityID")] T_Address t_address,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_Address target = db.T_Addresss.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_address, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_addresscountry != null)
							  db.Entry(target.t_addresscountry).State = EntityState.Unchanged;
							if (target.t_addressstate != null)
							  db.Entry(target.t_addressstate).State = EntityState.Unchanged;
							if (target.t_addresscity != null)
							  db.Entry(target.t_addresscity).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_address,"BulkUpdate","");
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
