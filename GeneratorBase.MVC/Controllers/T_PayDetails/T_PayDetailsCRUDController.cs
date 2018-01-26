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
[LocalDateTimeConverter]
    public partial class T_PayDetailsController : BaseController
    {
        // GET: /T_PayDetails/
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
			var lstT_PayDetails = from s in db.T_PayDetailss
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_PayDetails = searchRecords(lstT_PayDetails, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_PayDetails = sortRecords(lstT_PayDetails, sortBy, isAsc);
            }
            else lstT_PayDetails = lstT_PayDetails.OrderByDescending(c => c.Id);
			lstT_PayDetails = CustomSorting(lstT_PayDetails);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_PayDetails"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_PayDetails"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_PayDetails"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_PayDetails"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_PayDetails = lstT_PayDetails.Include(t=>t.t_employeepaydetails).Include(t=>t.t_paydetailsjobassignment).Include(t=>t.t_otherpaydetailstype);
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeePayDetails")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_PayDetails = _T_PayDetails.Where(p => p.T_EmployeePayDetailsID == hostid);
			 }
			 else
			     _T_PayDetails = _T_PayDetails.Where(p => p.T_EmployeePayDetailsID == null);
         }
		 if (HostingEntity == "T_JobAssignment" && AssociatedType == "T_PayDetailsJobAssignment")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_PayDetails = _T_PayDetails.Where(p => p.T_PayDetailsJobAssignmentID == hostid);
			 }
			 else
			     _T_PayDetails = _T_PayDetails.Where(p => p.T_PayDetailsJobAssignmentID == null);
         }
		 if (HostingEntity == "T_PayType" && AssociatedType == "T_OtherPayDetailsType")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_PayDetails = _T_PayDetails.Where(p => p.T_OtherPayDetailsTypeID == hostid);
			 }
			 else
			     _T_PayDetails = _T_PayDetails.Where(p => p.T_OtherPayDetailsTypeID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_PayDetails", User) || !User.CanView("T_PayDetails"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_PayDetails.Count() > 0)
                    pageSize = _T_PayDetails.Count();
                return View("ExcelExport", _T_PayDetails.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_PayDetails.Count();
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
				var list = _T_PayDetails.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_PayDetailsDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_PayDetailslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_PayDetails = _fad.FilterDropdown<T_PayDetails>(User,  _T_PayDetails, "T_PayDetails", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_PayDetails.Except(_T_PayDetails),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_PayDetails.Except(_T_PayDetails).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_PayDetails.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_PayDetails.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_PayDetails.Count() == 0 ? 1 : _T_PayDetails.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_PayDetails.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_PayDetailsDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_PayDetailslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_PayDetails.Count() == 0 ? 1 : _T_PayDetails.Count();
                            }
							var list = _T_PayDetails.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_PayDetailsDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_PayDetailslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_PayDetails/Details/5
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
            T_PayDetails t_paydetails = db.T_PayDetailss.Find(id);
            if (t_paydetails == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_paydetails);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_paydetails, AssociatedType);
            ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnDetails", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnDetails", true);
			ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnDetails");
			return View(ViewBag.TemplatesName,t_paydetails);
        }
        // GET: /T_PayDetails/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_PayDetails") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_PayDetailsParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnCreate", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnCreate", true);
		  ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnCreate");
          return View();
        }
		// GET: /T_PayDetails/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_PayDetails") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_PayDetailsParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnCreate", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnCreate", true);
			 ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnCreate");
            return View();
        }
		// POST: /T_PayDetails/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeePayDetailsID,T_PayDetailsJobAssignmentID,T_OtherPayDetailsTypeID,T_Amount,T_StartDate,T_EndDate,T_Notes")] T_PayDetails t_paydetails, string UrlReferrer)
        {
			CheckBeforeSave(t_paydetails);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_paydetails,out customcreate_hasissues,"Create"))
                {
                    db.T_PayDetailss.Add(t_paydetails);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_paydetails,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_paydetails);
			ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnCreate", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnCreate", true);
			ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnCreate");	
            return View(t_paydetails);
        }
		 // GET: /T_PayDetails/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_PayDetails") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_PayDetailsParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnCreate", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnCreate", true);
			ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnCreate");
            return View();
        }
		  // POST: /T_PayDetails/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeePayDetailsID,T_PayDetailsJobAssignmentID,T_OtherPayDetailsTypeID,T_Amount,T_StartDate,T_EndDate")] T_PayDetails t_paydetails,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_paydetails);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_paydetails,out customcreate_hasissues,"Create"))
                {
                    db.T_PayDetailss.Add(t_paydetails);
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
			LoadViewDataAfterOnCreate(t_paydetails);
			ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnCreate", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnCreate", true);
			ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_paydetails, AssociatedEntity);
			return View(t_paydetails);
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
        // POST: /T_PayDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_EmployeePayDetailsID,T_PayDetailsJobAssignmentID,T_OtherPayDetailsTypeID,T_Amount,T_StartDate,T_EndDate,T_Notes")] T_PayDetails t_paydetails, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_paydetails, command);
			
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(t_paydetails,out customcreate_hasissues,command))
                {
                    db.T_PayDetailss.Add(t_paydetails);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_paydetails,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_paydetails.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_paydetails);
			ViewData["T_PayDetailsParentUrl"] = UrlReferrer;
			ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnCreate", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnCreate", true);
			ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnCreate");
            return View(t_paydetails);
        }
		// GET: /T_PayDetails/Edit/5
		[Audit("View")]
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_PayDetails") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_PayDetails t_paydetails = db.T_PayDetailss.Find(id);
            if (t_paydetails == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_PayDetailsParentUrl"] = UrlReferrer;
		if(ViewData["T_PayDetailsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_PayDetails")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_PayDetails/Edit/" + t_paydetails.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_PayDetails/Create"))
			ViewData["T_PayDetailsParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_paydetails);
		   ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnEdit", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnEdit", true);
		   ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnEdit");
		    var objT_PayDetails = new List<T_PayDetails>();
            ViewBag.T_PayDetailsDD = new SelectList(objT_PayDetails, "ID", "DisplayValue"); 
          return View(t_paydetails);
        }
		// POST: /T_PayDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeePayDetailsID,T_PayDetailsJobAssignmentID,T_OtherPayDetailsTypeID,T_Amount,T_StartDate,T_EndDate,T_Notes")] T_PayDetails t_paydetails,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_paydetails, command);
			
            if (ModelState.IsValid)
            {
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_paydetails,out customsave_hasissues,command))
                {
					db.Entry(t_paydetails).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_paydetails);
			ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnEdit", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnEdit", true);
			ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnEdit");
            return View(t_paydetails);
        }
        // GET: /T_PayDetails/Edit/5
		[Audit("View")]
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_PayDetails") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PayDetails t_paydetails = db.T_PayDetailss.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_PayDetailslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_PayDetailss.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_PayDetailsDisplayValueEdit = TempData["T_PayDetailslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_PayDetailslist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_PayDetailsDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_paydetails == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_PayDetails/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_paydetails.DisplayValue, Value = t_paydetails.Id.ToString() }));
                ViewBag.EntityT_PayDetailsDisplayValueEdit = newList;
				TempData["T_PayDetailslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_paydetails.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_paydetails.DisplayValue;
                    newList[0].Value = t_paydetails.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_paydetails.DisplayValue, Value = t_paydetails.Id.ToString() }));
                }
                ViewBag.EntityT_PayDetailsDisplayValueEdit = newList;
				TempData["T_PayDetailslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_PayDetailsParentUrl"] = UrlReferrer;
		if(ViewData["T_PayDetailsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_PayDetails")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_PayDetails/Edit/" + t_paydetails.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_PayDetails/Create"))
			ViewData["T_PayDetailsParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_paydetails);
		   ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnEdit", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnEdit", true);
		   ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnEdit");
          return View(t_paydetails);
        }
        // POST: /T_PayDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_EmployeePayDetailsID,T_PayDetailsJobAssignmentID,T_OtherPayDetailsTypeID,T_Amount,T_StartDate,T_EndDate,T_Notes")] T_PayDetails t_paydetails,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_paydetails, command);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_paydetails,out customsave_hasissues,command))
            {
				db.Entry(t_paydetails).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_paydetails,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_paydetails.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_PayDetailslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_PayDetailss.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_PayDetailsDisplayValueEdit = TempData["T_PayDetailslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_PayDetailslist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_PayDetailsDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_paydetails);
			 ViewData["T_PayDetailsParentUrl"] = UrlReferrer;
			ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnEdit", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnEdit", true);
			ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnEdit");
            return View(t_paydetails);
        }
		// GET: /T_PayDetails/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_PayDetails") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_PayDetails t_paydetails = db.T_PayDetailss.Find(id);
            if (t_paydetails == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_PayDetailsParentUrl"] = UrlReferrer;
		if(ViewData["T_PayDetailsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_PayDetails"))
			ViewData["T_PayDetailsParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_paydetails);
			 ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnEdit", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnEdit", true);
			 ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnEdit");
          return View(t_paydetails);
        }
        // POST: /T_PayDetails/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeePayDetailsID,T_PayDetailsJobAssignmentID,T_OtherPayDetailsTypeID,T_Amount,T_StartDate,T_EndDate,T_Notes")] T_PayDetails t_paydetails,string UrlReferrer)
        {
			CheckBeforeSave(t_paydetails);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_paydetails,out customsave_hasissues,"Save"))
            {
				db.Entry(t_paydetails).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_paydetails,"Edit","");
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
			LoadViewDataAfterOnEdit(t_paydetails);
			ViewBag.T_PayDetailsIsHiddenRule = checkHidden("T_PayDetails", "OnEdit", false);
			ViewBag.T_PayDetailsIsGroupsHiddenRule = checkHidden("T_PayDetails", "OnEdit", true);
			ViewBag.T_PayDetailsIsSetValueUIRule = checkSetValueUIRule("T_PayDetails", "OnEdit");
            return View(t_paydetails);
        }
        // GET: /T_PayDetails/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_PayDetails") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_PayDetails t_paydetails = db.T_PayDetailss.Find(id);
            if (t_paydetails == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_PayDetailsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_PayDetails"))
			 ViewData["T_PayDetailsParentUrl"] = Request.UrlReferrer;
            return View(t_paydetails);
        }
        // POST: /T_PayDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_PayDetails t_paydetails, string UrlReferrer)
        {
			if (!User.CanDelete("T_PayDetails"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_paydetails))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_paydetails, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_paydetails).State = EntityState.Deleted;
            db.T_PayDetailss.Remove(t_paydetails);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_PayDetailsParentUrl"] != null)
					{
						string parentUrl = ViewData["T_PayDetailsParentUrl"].ToString();
						ViewData["T_PayDetailsParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_paydetails);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeePayDetails")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_PayDetails obj = db.T_PayDetailss.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeePayDetailsID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_JobAssignment" && AssociatedType == "T_PayDetailsJobAssignment")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_PayDetails obj = db.T_PayDetailss.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_PayDetailsJobAssignmentID = HostingID;
                    db.SaveChanges();
                }
            }
            if (HostingEntity == "T_PayType" && AssociatedType == "T_OtherPayDetailsType")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    T_PayDetails obj = db.T_PayDetailss.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_OtherPayDetailsTypeID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_PayDetails", User) || !User.CanDelete("T_PayDetails")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_PayDetails t_paydetails = db.T_PayDetailss.Find(id);
		if (CheckBeforeDelete(t_paydetails))
        {
            if (!CustomDelete(t_paydetails, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_paydetails).State = EntityState.Deleted;
                db.T_PayDetailss.Remove(t_paydetails);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_PayDetails", User) || !User.CanEdit("T_PayDetails") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_PayDetailsParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_EmployeePayDetailsID,T_PayDetailsJobAssignmentID,T_OtherPayDetailsTypeID,T_Amount,T_StartDate,T_EndDate,T_Notes")] T_PayDetails t_paydetails,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_PayDetails target = db.T_PayDetailss.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_paydetails, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_employeepaydetails != null)
							  db.Entry(target.t_employeepaydetails).State = EntityState.Unchanged;
							if (target.t_paydetailsjobassignment != null)
							  db.Entry(target.t_paydetailsjobassignment).State = EntityState.Unchanged;
							if (target.t_otherpaydetailstype != null)
							  db.Entry(target.t_otherpaydetailstype).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_paydetails,"BulkUpdate","");
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
