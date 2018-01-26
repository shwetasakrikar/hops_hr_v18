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

    public partial class T_SalaryRangeController : BaseController
    {
        // GET: /T_SalaryRange/
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
			var lstT_SalaryRange = from s in db.T_SalaryRanges
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_SalaryRange = searchRecords(lstT_SalaryRange, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_SalaryRange = sortRecords(lstT_SalaryRange, sortBy, isAsc);
            }
            else lstT_SalaryRange = lstT_SalaryRange.OrderByDescending(c => c.Id);
			lstT_SalaryRange = CustomSorting(lstT_SalaryRange);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_SalaryRange"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_SalaryRange"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_SalaryRange"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_SalaryRange"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_SalaryRange = lstT_SalaryRange.Include(t=>t.t_salarybandsalaryrangeassociation).Include(t=>t.t_facilitysalaryrangeassociation);
		 if (HostingEntity == "T_SalaryBand" && AssociatedType == "T_SalaryBandSalaryRangeAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_SalaryRange = _T_SalaryRange.Where(p => p.T_SalaryBandSalaryRangeAssociationID == hostid);
			 }
			 else
			     _T_SalaryRange = _T_SalaryRange.Where(p => p.T_SalaryBandSalaryRangeAssociationID == null);
         }
		 if (HostingEntity == "T_Facility" && AssociatedType == "T_FacilitySalaryRangeAssociation")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_SalaryRange = _T_SalaryRange.Where(p => p.T_FacilitySalaryRangeAssociationID == hostid);
			 }
			 else
			     _T_SalaryRange = _T_SalaryRange.Where(p => p.T_FacilitySalaryRangeAssociationID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_SalaryRange", User) || !User.CanView("T_SalaryRange"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_SalaryRange.Count() > 0)
                    pageSize = _T_SalaryRange.Count();
                return View("ExcelExport", _T_SalaryRange.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_SalaryRange.Count();
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
				var list = _T_SalaryRange.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_SalaryRangeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_SalaryRangelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_SalaryRange = _fad.FilterDropdown<T_SalaryRange>(User,  _T_SalaryRange, "T_SalaryRange", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_SalaryRange.Except(_T_SalaryRange),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_SalaryRange.Except(_T_SalaryRange).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_SalaryRange.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_SalaryRange.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_SalaryRange.Count() == 0 ? 1 : _T_SalaryRange.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_SalaryRange.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_SalaryRangeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_SalaryRangelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_SalaryRange.Count() == 0 ? 1 : _T_SalaryRange.Count();
                            }
							var list = _T_SalaryRange.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_SalaryRangeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_SalaryRangelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_SalaryRange/Details/5
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
            T_SalaryRange t_salaryrange = db.T_SalaryRanges.Find(id);
            if (t_salaryrange == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_salaryrange);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_salaryrange, AssociatedType);
            ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnDetails", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnDetails", true);
			ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnDetails");
			return View(ViewBag.TemplatesName,t_salaryrange);
        }
        // GET: /T_SalaryRange/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_SalaryRange") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_SalaryRangeParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", true);
		  ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnCreate");
          return View();
        }
		// GET: /T_SalaryRange/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_SalaryRange") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_SalaryRangeParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", true);
			 ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnCreate");
            return View();
        }
		// POST: /T_SalaryRange/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_SalaryBandSalaryRangeAssociationID,T_FacilitySalaryRangeAssociationID,T_Minimum,T_Maximum")] T_SalaryRange t_salaryrange, string UrlReferrer)
        {
			CheckBeforeSave(t_salaryrange);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_salaryrange,out customcreate_hasissues,"Create"))
                {
                    db.T_SalaryRanges.Add(t_salaryrange);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_salaryrange,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_salaryrange);
			ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", true);
			ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnCreate");	
            return View(t_salaryrange);
        }
		 // GET: /T_SalaryRange/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_SalaryRange") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_SalaryRangeParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", true);
			ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnCreate");
            return View();
        }
		  // POST: /T_SalaryRange/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_SalaryBandSalaryRangeAssociationID,T_FacilitySalaryRangeAssociationID,T_Minimum,T_Maximum")] T_SalaryRange t_salaryrange,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_salaryrange);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_salaryrange,out customcreate_hasissues,"Create"))
                {
                    db.T_SalaryRanges.Add(t_salaryrange);
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
			LoadViewDataAfterOnCreate(t_salaryrange);
			ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", true);
			ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_salaryrange, AssociatedEntity);
			return View(t_salaryrange);
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
        // POST: /T_SalaryRange/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_SalaryBandSalaryRangeAssociationID,T_FacilitySalaryRangeAssociationID,T_Minimum,T_Maximum")] T_SalaryRange t_salaryrange, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_salaryrange, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_salaryrange,out customcreate_hasissues,command))
                {
                    db.T_SalaryRanges.Add(t_salaryrange);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_salaryrange,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_salaryrange.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_salaryrange);
			ViewData["T_SalaryRangeParentUrl"] = UrlReferrer;
			ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnCreate", true);
			ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnCreate");
            return View(t_salaryrange);
        }
		// GET: /T_SalaryRange/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_SalaryRange") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_SalaryRange t_salaryrange = db.T_SalaryRanges.Find(id);
            if (t_salaryrange == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_SalaryRangeParentUrl"] = UrlReferrer;
		if(ViewData["T_SalaryRangeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_SalaryRange")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_SalaryRange/Edit/" + t_salaryrange.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_SalaryRange/Create"))
			ViewData["T_SalaryRangeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_salaryrange);
		   ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", true);
		   ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnEdit");
		    var objT_SalaryRange = new List<T_SalaryRange>();
            ViewBag.T_SalaryRangeDD = new SelectList(objT_SalaryRange, "ID", "DisplayValue"); 
          return View(t_salaryrange);
        }
		// POST: /T_SalaryRange/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_SalaryBandSalaryRangeAssociationID,T_FacilitySalaryRangeAssociationID,T_Minimum,T_Maximum")] T_SalaryRange t_salaryrange,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_salaryrange, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_salaryrange,out customsave_hasissues,command))
                {
					db.Entry(t_salaryrange).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_salaryrange);
			ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", true);
			ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnEdit");
            return View(t_salaryrange);
        }
        // GET: /T_SalaryRange/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_SalaryRange") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SalaryRange t_salaryrange = db.T_SalaryRanges.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_SalaryRangelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_SalaryRanges.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_SalaryRangeDisplayValueEdit = TempData["T_SalaryRangelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_SalaryRangelist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_SalaryRangeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_salaryrange == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_SalaryRange/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_salaryrange.DisplayValue, Value = t_salaryrange.Id.ToString() }));
                ViewBag.EntityT_SalaryRangeDisplayValueEdit = newList;
				TempData["T_SalaryRangelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_salaryrange.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_salaryrange.DisplayValue;
                    newList[0].Value = t_salaryrange.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_salaryrange.DisplayValue, Value = t_salaryrange.Id.ToString() }));
                }
                ViewBag.EntityT_SalaryRangeDisplayValueEdit = newList;
				TempData["T_SalaryRangelist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_SalaryRangeParentUrl"] = UrlReferrer;
		if(ViewData["T_SalaryRangeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_SalaryRange")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_SalaryRange/Edit/" + t_salaryrange.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_SalaryRange/Create"))
			ViewData["T_SalaryRangeParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_salaryrange);
		   ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", true);
		   ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnEdit");
          return View(t_salaryrange);
        }
        // POST: /T_SalaryRange/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_SalaryBandSalaryRangeAssociationID,T_FacilitySalaryRangeAssociationID,T_Minimum,T_Maximum")] T_SalaryRange t_salaryrange,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_salaryrange, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_salaryrange,out customsave_hasissues,command))
            {
				db.Entry(t_salaryrange).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_salaryrange,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_salaryrange.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_SalaryRangelist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_SalaryRanges.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_SalaryRangeDisplayValueEdit = TempData["T_SalaryRangelist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_SalaryRangelist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_SalaryRangeDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_salaryrange);
			 ViewData["T_SalaryRangeParentUrl"] = UrlReferrer;
			ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", true);
			ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnEdit");
            return View(t_salaryrange);
        }
		// GET: /T_SalaryRange/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_SalaryRange") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_SalaryRange t_salaryrange = db.T_SalaryRanges.Find(id);
            if (t_salaryrange == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_SalaryRangeParentUrl"] = UrlReferrer;
		if(ViewData["T_SalaryRangeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_SalaryRange"))
			ViewData["T_SalaryRangeParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_salaryrange);
			 ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", true);
			 ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnEdit");
          return View(t_salaryrange);
        }
        // POST: /T_SalaryRange/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_SalaryBandSalaryRangeAssociationID,T_FacilitySalaryRangeAssociationID,T_Minimum,T_Maximum")] T_SalaryRange t_salaryrange,string UrlReferrer)
        {
			CheckBeforeSave(t_salaryrange);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_salaryrange,out customsave_hasissues,"Save"))
            {
				db.Entry(t_salaryrange).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_salaryrange,"Edit","");
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
			LoadViewDataAfterOnEdit(t_salaryrange);
			ViewBag.T_SalaryRangeIsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", false);
			ViewBag.T_SalaryRangeIsGroupsHiddenRule = checkHidden("T_SalaryRange", "OnEdit", true);
			ViewBag.T_SalaryRangeIsSetValueUIRule = checkSetValueUIRule("T_SalaryRange", "OnEdit");
            return View(t_salaryrange);
        }
        // GET: /T_SalaryRange/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_SalaryRange") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_SalaryRange t_salaryrange = db.T_SalaryRanges.Find(id);
            if (t_salaryrange == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_SalaryRangeParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_SalaryRange"))
			 ViewData["T_SalaryRangeParentUrl"] = Request.UrlReferrer;
            return View(t_salaryrange);
        }
        // POST: /T_SalaryRange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_SalaryRange t_salaryrange, string UrlReferrer)
        {
			if (!User.CanDelete("T_SalaryRange"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_salaryrange))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_salaryrange, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_salaryrange).State = EntityState.Deleted;
            db.T_SalaryRanges.Remove(t_salaryrange);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_SalaryRangeParentUrl"] != null)
					{
						string parentUrl = ViewData["T_SalaryRangeParentUrl"].ToString();
						ViewData["T_SalaryRangeParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_salaryrange);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_SalaryBand" && AssociatedType == "T_SalaryBandSalaryRangeAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_SalaryRange obj = db.T_SalaryRanges.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_SalaryBandSalaryRangeAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_Facility" && AssociatedType == "T_FacilitySalaryRangeAssociation")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_SalaryRange obj = db.T_SalaryRanges.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_FacilitySalaryRangeAssociationID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_SalaryRange", User) || !User.CanDelete("T_SalaryRange")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_SalaryRange t_salaryrange = db.T_SalaryRanges.Find(id);
		if (CheckBeforeDelete(t_salaryrange))
        {
            if (!CustomDelete(t_salaryrange, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_salaryrange).State = EntityState.Deleted;
                db.T_SalaryRanges.Remove(t_salaryrange);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_SalaryRange", User) || !User.CanEdit("T_SalaryRange") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_SalaryRangeParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_SalaryBandSalaryRangeAssociationID,T_FacilitySalaryRangeAssociationID,T_Minimum,T_Maximum")] T_SalaryRange t_salaryrange,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_SalaryRange target = db.T_SalaryRanges.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_salaryrange, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_salarybandsalaryrangeassociation != null)
							  db.Entry(target.t_salarybandsalaryrangeassociation).State = EntityState.Unchanged;
							if (target.t_facilitysalaryrangeassociation != null)
							  db.Entry(target.t_facilitysalaryrangeassociation).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_salaryrange,"BulkUpdate","");
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
