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

    public partial class T_CostCenterController : BaseController
    {
        // GET: /T_CostCenter/
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
			var lstT_CostCenter = from s in db.T_CostCenters
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_CostCenter = searchRecords(lstT_CostCenter, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_CostCenter = sortRecords(lstT_CostCenter, sortBy, isAsc);
            }
            else lstT_CostCenter = lstT_CostCenter.OrderByDescending(c => c.Id);
			lstT_CostCenter = CustomSorting(lstT_CostCenter);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_CostCenter"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_CostCenter"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_CostCenter"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_CostCenter"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_CostCenter = lstT_CostCenter.Include(t=>t.t_costprogram).Include(t=>t.t_costfund);
		 if (HostingEntity == "T_Program" && AssociatedType == "T_CostProgram")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_CostCenter = _T_CostCenter.Where(p => p.T_CostProgramID == hostid);
			 }
			 else
			     _T_CostCenter = _T_CostCenter.Where(p => p.T_CostProgramID == null);
         }
		 if (HostingEntity == "T_Fund" && AssociatedType == "T_CostFund")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_CostCenter = _T_CostCenter.Where(p => p.T_CostFundID == hostid);
			 }
			 else
			     _T_CostCenter = _T_CostCenter.Where(p => p.T_CostFundID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_CostCenter", User) || !User.CanView("T_CostCenter"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_CostCenter.Count() > 0)
                    pageSize = _T_CostCenter.Count();
                return View("ExcelExport", _T_CostCenter.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_CostCenter.Count();
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
				var list = _T_CostCenter.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_CostCenterDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_CostCenterlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_CostCenter = _fad.FilterDropdown<T_CostCenter>(User,  _T_CostCenter, "T_CostCenter", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_CostCenter.Except(_T_CostCenter),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_CostCenter.Except(_T_CostCenter).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_CostCenter.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_CostCenter.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_CostCenter.Count() == 0 ? 1 : _T_CostCenter.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_CostCenter.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_CostCenterDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_CostCenterlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_CostCenter.Count() == 0 ? 1 : _T_CostCenter.Count();
                            }
							var list = _T_CostCenter.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_CostCenterDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_CostCenterlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_CostCenter/Details/5
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
            T_CostCenter t_costcenter = db.T_CostCenters.Find(id);
            if (t_costcenter == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_costcenter);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_costcenter, AssociatedType);
            ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnDetails", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnDetails", true);
			ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnDetails");
			return View(ViewBag.TemplatesName,t_costcenter);
        }
        // GET: /T_CostCenter/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_CostCenter") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_CostCenterParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnCreate", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnCreate", true);
		  ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnCreate");
          return View();
        }
		// GET: /T_CostCenter/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_CostCenter") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_CostCenterParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnCreate", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnCreate", true);
			 ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnCreate");
            return View();
        }
		// POST: /T_CostCenter/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_CC,T_CCDescription,T_CostProgramID,T_CostFundID")] T_CostCenter t_costcenter, string UrlReferrer)
        {
			CheckBeforeSave(t_costcenter);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_costcenter,out customcreate_hasissues,"Create"))
                {
                    db.T_CostCenters.Add(t_costcenter);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_costcenter,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_costcenter);
			ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnCreate", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnCreate", true);
			ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnCreate");	
            return View(t_costcenter);
        }
		 // GET: /T_CostCenter/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_CostCenter") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_CostCenterParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnCreate", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnCreate", true);
			ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnCreate");
            return View();
        }
		  // POST: /T_CostCenter/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_CC,T_CCDescription,T_CostProgramID,T_CostFundID")] T_CostCenter t_costcenter,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_costcenter);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_costcenter,out customcreate_hasissues,"Create"))
                {
                    db.T_CostCenters.Add(t_costcenter);
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
			LoadViewDataAfterOnCreate(t_costcenter);
			ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnCreate", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnCreate", true);
			ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_costcenter, AssociatedEntity);
			return View(t_costcenter);
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
        // POST: /T_CostCenter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_CC,T_CCDescription,T_CostProgramID,T_CostFundID")] T_CostCenter t_costcenter, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_costcenter, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_costcenter,out customcreate_hasissues,command))
                {
                    db.T_CostCenters.Add(t_costcenter);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_costcenter,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_costcenter.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_costcenter);
			ViewData["T_CostCenterParentUrl"] = UrlReferrer;
			ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnCreate", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnCreate", true);
			ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnCreate");
            return View(t_costcenter);
        }
		// GET: /T_CostCenter/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_CostCenter") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_CostCenter t_costcenter = db.T_CostCenters.Find(id);
            if (t_costcenter == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_CostCenterParentUrl"] = UrlReferrer;
		if(ViewData["T_CostCenterParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_CostCenter")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_CostCenter/Edit/" + t_costcenter.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_CostCenter/Create"))
			ViewData["T_CostCenterParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_costcenter);
		   ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnEdit", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnEdit", true);
		   ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnEdit");
		    var objT_CostCenter = new List<T_CostCenter>();
            ViewBag.T_CostCenterDD = new SelectList(objT_CostCenter, "ID", "DisplayValue"); 
          return View(t_costcenter);
        }
		// POST: /T_CostCenter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_CC,T_CCDescription,T_CostProgramID,T_CostFundID")] T_CostCenter t_costcenter,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_costcenter, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_costcenter,out customsave_hasissues,command))
                {
					db.Entry(t_costcenter).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_costcenter);
			ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnEdit", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnEdit", true);
			ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnEdit");
            return View(t_costcenter);
        }
        // GET: /T_CostCenter/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_CostCenter") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_CostCenter t_costcenter = db.T_CostCenters.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_CostCenterlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_CostCenters.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_CostCenterDisplayValueEdit = TempData["T_CostCenterlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_CostCenterlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_CostCenterDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_costcenter == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_CostCenter/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_costcenter.DisplayValue, Value = t_costcenter.Id.ToString() }));
                ViewBag.EntityT_CostCenterDisplayValueEdit = newList;
				TempData["T_CostCenterlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_costcenter.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_costcenter.DisplayValue;
                    newList[0].Value = t_costcenter.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_costcenter.DisplayValue, Value = t_costcenter.Id.ToString() }));
                }
                ViewBag.EntityT_CostCenterDisplayValueEdit = newList;
				TempData["T_CostCenterlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_CostCenterParentUrl"] = UrlReferrer;
		if(ViewData["T_CostCenterParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_CostCenter")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_CostCenter/Edit/" + t_costcenter.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_CostCenter/Create"))
			ViewData["T_CostCenterParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_costcenter);
		   ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnEdit", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnEdit", true);
		   ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnEdit");
          return View(t_costcenter);
        }
        // POST: /T_CostCenter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_CC,T_CCDescription,T_CostProgramID,T_CostFundID")] T_CostCenter t_costcenter,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_costcenter, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_costcenter,out customsave_hasissues,command))
            {
				db.Entry(t_costcenter).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_costcenter,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_costcenter.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_CostCenterlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_CostCenters.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_CostCenterDisplayValueEdit = TempData["T_CostCenterlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_CostCenterlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_CostCenterDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_costcenter);
			 ViewData["T_CostCenterParentUrl"] = UrlReferrer;
			ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnEdit", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnEdit", true);
			ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnEdit");
            return View(t_costcenter);
        }
		// GET: /T_CostCenter/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_CostCenter") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_CostCenter t_costcenter = db.T_CostCenters.Find(id);
            if (t_costcenter == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_CostCenterParentUrl"] = UrlReferrer;
		if(ViewData["T_CostCenterParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_CostCenter"))
			ViewData["T_CostCenterParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_costcenter);
			 ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnEdit", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnEdit", true);
			 ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnEdit");
          return View(t_costcenter);
        }
        // POST: /T_CostCenter/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_CC,T_CCDescription,T_CostProgramID,T_CostFundID")] T_CostCenter t_costcenter,string UrlReferrer)
        {
			CheckBeforeSave(t_costcenter);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_costcenter,out customsave_hasissues,"Save"))
            {
				db.Entry(t_costcenter).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_costcenter,"Edit","");
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
			LoadViewDataAfterOnEdit(t_costcenter);
			ViewBag.T_CostCenterIsHiddenRule = checkHidden("T_CostCenter", "OnEdit", false);
			ViewBag.T_CostCenterIsGroupsHiddenRule = checkHidden("T_CostCenter", "OnEdit", true);
			ViewBag.T_CostCenterIsSetValueUIRule = checkSetValueUIRule("T_CostCenter", "OnEdit");
            return View(t_costcenter);
        }
        // GET: /T_CostCenter/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_CostCenter") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_CostCenter t_costcenter = db.T_CostCenters.Find(id);
            if (t_costcenter == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_CostCenterParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_CostCenter"))
			 ViewData["T_CostCenterParentUrl"] = Request.UrlReferrer;
            return View(t_costcenter);
        }
        // POST: /T_CostCenter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_CostCenter t_costcenter, string UrlReferrer)
        {
			if (!User.CanDelete("T_CostCenter"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_costcenter))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_costcenter, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_costcenter).State = EntityState.Deleted;
            db.T_CostCenters.Remove(t_costcenter);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_CostCenterParentUrl"] != null)
					{
						string parentUrl = ViewData["T_CostCenterParentUrl"].ToString();
						ViewData["T_CostCenterParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_costcenter);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Program" && AssociatedType == "T_CostProgram")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_CostCenter obj = db.T_CostCenters.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_CostProgramID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Fund" && AssociatedType == "T_CostFund")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_CostCenter obj = db.T_CostCenters.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_CostFundID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_CostCenter", User) || !User.CanDelete("T_CostCenter")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_CostCenter t_costcenter = db.T_CostCenters.Find(id);
		if (CheckBeforeDelete(t_costcenter))
        {
            if (!CustomDelete(t_costcenter, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_costcenter).State = EntityState.Deleted;
                db.T_CostCenters.Remove(t_costcenter);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_CostCenter", User) || !User.CanEdit("T_CostCenter") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_CostCenterParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_CC,T_CCDescription,T_CostProgramID,T_CostFundID")] T_CostCenter t_costcenter,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_CostCenter target = db.T_CostCenters.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_costcenter, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_costprogram != null)
							  db.Entry(target.t_costprogram).State = EntityState.Unchanged;
							if (target.t_costfund != null)
							  db.Entry(target.t_costfund).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_costcenter,"BulkUpdate","");
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
