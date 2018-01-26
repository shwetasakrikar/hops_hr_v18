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

    public partial class T_TypeofClaimController : BaseController
    {
        // GET: /T_TypeofClaim/
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
			var lstT_TypeofClaim = from s in db.T_TypeofClaims
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_TypeofClaim = searchRecords(lstT_TypeofClaim, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_TypeofClaim = sortRecords(lstT_TypeofClaim, sortBy, isAsc);
            }
            else lstT_TypeofClaim = lstT_TypeofClaim.OrderByDescending(c => c.Id);
			lstT_TypeofClaim = CustomSorting(lstT_TypeofClaim);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_TypeofClaim"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_TypeofClaim"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_TypeofClaim"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_TypeofClaim"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_TypeofClaim = lstT_TypeofClaim.Include(t=>t.t_claimtype).Include(t=>t.t_employeeinjury);
		 if (HostingEntity == "T_ClaimType" && AssociatedType == "T_TypeofClaim_T_ClaimType")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_TypeofClaim = _T_TypeofClaim.Where(p => p.T_ClaimTypeID == hostid);
			 }
			 else
			     _T_TypeofClaim = _T_TypeofClaim.Where(p => p.T_ClaimTypeID == null);
         }
		 if (HostingEntity == "T_EmployeeInjury" && AssociatedType == "T_TypeofClaim_T_EmployeeInjury")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_TypeofClaim = _T_TypeofClaim.Where(p => p.T_EmployeeInjuryID == hostid);
			 }
			 else
			     _T_TypeofClaim = _T_TypeofClaim.Where(p => p.T_EmployeeInjuryID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_TypeofClaim", User) || !User.CanView("T_TypeofClaim"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_TypeofClaim.Count() > 0)
                    pageSize = _T_TypeofClaim.Count();
                return View("ExcelExport", _T_TypeofClaim.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_TypeofClaim.Count();
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
				var list = _T_TypeofClaim.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_TypeofClaimDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_TypeofClaimlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_TypeofClaim = _fad.FilterDropdown<T_TypeofClaim>(User,  _T_TypeofClaim, "T_TypeofClaim", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_TypeofClaim.Except(_T_TypeofClaim),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_TypeofClaim.Except(_T_TypeofClaim).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_TypeofClaim.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_TypeofClaim.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_TypeofClaim.Count() == 0 ? 1 : _T_TypeofClaim.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_TypeofClaim.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_TypeofClaimDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_TypeofClaimlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_TypeofClaim.Count() == 0 ? 1 : _T_TypeofClaim.Count();
                            }
							var list = _T_TypeofClaim.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_TypeofClaimDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_TypeofClaimlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_TypeofClaim/Details/5
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
            T_TypeofClaim t_typeofclaim = db.T_TypeofClaims.Find(id);
            if (t_typeofclaim == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_typeofclaim);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_typeofclaim, AssociatedType);
            ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnDetails", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnDetails", true);
			ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnDetails");
			return View(ViewBag.TemplatesName,t_typeofclaim);
        }
        // GET: /T_TypeofClaim/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_TypeofClaim") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_TypeofClaimParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", true);
		  ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnCreate");
          return View();
        }
		// GET: /T_TypeofClaim/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_TypeofClaim") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_TypeofClaimParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", true);
			 ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnCreate");
            return View();
        }
		// POST: /T_TypeofClaim/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeID,T_EmployeeInjuryID")] T_TypeofClaim t_typeofclaim, string UrlReferrer)
        {
			CheckBeforeSave(t_typeofclaim);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_typeofclaim,out customcreate_hasissues,"Create"))
                {
                    db.T_TypeofClaims.Add(t_typeofclaim);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_typeofclaim,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_typeofclaim);
			ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", true);
			ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnCreate");	
            return View(t_typeofclaim);
        }
		 // GET: /T_TypeofClaim/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_TypeofClaim") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_TypeofClaimParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", true);
			ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnCreate");
            return View();
        }
		  // POST: /T_TypeofClaim/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeID,T_EmployeeInjuryID")] T_TypeofClaim t_typeofclaim, List<string> T_ClaimTypeIDSelected, List<string> T_ClaimTypeIDAvailable, List<string> T_EmployeeInjuryIDSelected, List<string> T_EmployeeInjuryIDAvailable,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_typeofclaim);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
					if(T_ClaimTypeIDSelected != null || T_ClaimTypeIDAvailable != null)
				{
				    t_typeofclaim.t_employeeinjury = db.T_EmployeeInjurys.FirstOrDefault(p => p.Id == t_typeofclaim.T_EmployeeInjuryID);
					var T_ClaimTypeIDSelectedlong =T_ClaimTypeIDSelected !=null ? T_ClaimTypeIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_TypeofClaims.Where(p => p.T_EmployeeInjuryID == t_typeofclaim.T_EmployeeInjuryID && !T_ClaimTypeIDSelectedlong.Contains(p.T_ClaimTypeID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_employeeinjury !=null )
					    db.Entry(item.t_employeeinjury).State = EntityState.Unchanged;
						if(item.t_claimtype !=null )
                        db.Entry(item.t_claimtype).State = EntityState.Unchanged;
                        db.T_TypeofClaims.Remove(item);
                        db.SaveChanges();
                    }
					if(T_ClaimTypeIDSelected != null)
					{
					var T_ClaimTypeIDSelectedLong = T_ClaimTypeIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_typeofclaim.T_EmployeeInjuryID && T_ClaimTypeIDSelectedLong.Contains(a.T_ClaimTypeID.Value)).Select(p => p.T_ClaimTypeID.Value).ToList();
                    T_ClaimTypeIDSelectedLong = T_ClaimTypeIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_ClaimTypeIDSelectedLong != null)
                        foreach (var longid in T_ClaimTypeIDSelectedLong)
						{
                            {
								var obj = new T_TypeofClaim(); 
								obj = t_typeofclaim;
								obj.T_ClaimTypeID = longid;//Convert.ToInt64(id);
								db.Entry(obj).State = EntityState.Added;
								//obj.t_claimtype = db.T_ClaimTypes.FirstOrDefault(p => p.Id == t_typeofclaim.T_ClaimTypeID);
								if(obj.t_employeeinjury !=null )
									db.Entry(obj.t_employeeinjury).State = EntityState.Unchanged;
								if(obj.t_claimtype !=null )
									db.Entry(obj.t_claimtype).State = EntityState.Unchanged;
								//
								//
								db.T_TypeofClaims.Add(obj); db.SaveChanges();
							}
						}
					}
				}
				if(T_EmployeeInjuryIDSelected != null || T_EmployeeInjuryIDAvailable != null)
				{
				    t_typeofclaim.t_claimtype = db.T_ClaimTypes.FirstOrDefault(p => p.Id == t_typeofclaim.T_ClaimTypeID);
					var T_EmployeeInjuryIDSelectedlong =T_EmployeeInjuryIDSelected !=null ? T_EmployeeInjuryIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_TypeofClaims.Where(p => p.T_ClaimTypeID == t_typeofclaim.T_ClaimTypeID && !T_EmployeeInjuryIDSelectedlong.Contains(p.T_EmployeeInjuryID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_claimtype !=null )
					    db.Entry(item.t_claimtype).State = EntityState.Unchanged;
						if(item.t_employeeinjury !=null )
                        db.Entry(item.t_employeeinjury).State = EntityState.Unchanged;
                        db.T_TypeofClaims.Remove(item);
                        db.SaveChanges();
                    }
					if(T_EmployeeInjuryIDSelected != null)
					{
					var T_EmployeeInjuryIDSelectedLong = T_EmployeeInjuryIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_typeofclaim.T_ClaimTypeID && T_EmployeeInjuryIDSelectedLong.Contains(a.T_EmployeeInjuryID.Value)).Select(p => p.T_EmployeeInjuryID.Value).ToList();
                    T_EmployeeInjuryIDSelectedLong = T_EmployeeInjuryIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_EmployeeInjuryIDSelectedLong != null)
                        foreach (var longid in T_EmployeeInjuryIDSelectedLong)
						{
                            {
								var obj = new T_TypeofClaim(); 
								obj = t_typeofclaim;
								obj.T_EmployeeInjuryID = longid;//Convert.ToInt64(id);
								db.Entry(obj).State = EntityState.Added;
								//obj.t_employeeinjury = db.T_EmployeeInjurys.FirstOrDefault(p => p.Id == t_typeofclaim.T_EmployeeInjuryID);
								if(obj.t_claimtype !=null )
									db.Entry(obj.t_claimtype).State = EntityState.Unchanged;
								if(obj.t_employeeinjury !=null )
									db.Entry(obj.t_employeeinjury).State = EntityState.Unchanged;
								//
								//
								db.T_TypeofClaims.Add(obj); db.SaveChanges();
							}
						}
					}
				}
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
			LoadViewDataAfterOnCreate(t_typeofclaim);
			ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", true);
			ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_typeofclaim, AssociatedEntity);
			return View(t_typeofclaim);
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
        // POST: /T_TypeofClaim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeID,T_EmployeeInjuryID")] T_TypeofClaim t_typeofclaim, List<string> T_ClaimTypeIDSelected, List<string> T_ClaimTypeIDAvailable, List<string> T_EmployeeInjuryIDSelected, List<string> T_EmployeeInjuryIDAvailable, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_typeofclaim, command);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
				if(T_ClaimTypeIDSelected != null || T_ClaimTypeIDAvailable != null)
				{
					t_typeofclaim.t_employeeinjury = db.T_EmployeeInjurys.FirstOrDefault(p => p.Id == t_typeofclaim.T_EmployeeInjuryID);
					var T_ClaimTypeIDSelectedlong =T_ClaimTypeIDSelected !=null ? T_ClaimTypeIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_TypeofClaims.Where(p => p.T_EmployeeInjuryID == t_typeofclaim.T_EmployeeInjuryID && !T_ClaimTypeIDSelectedlong.Contains(p.T_ClaimTypeID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_employeeinjury !=null )
						db.Entry(item.t_employeeinjury).State = EntityState.Unchanged;
					if(item.t_claimtype !=null )
                        db.Entry(item.t_claimtype).State = EntityState.Unchanged;
						db.Entry(item).State = EntityState.Deleted;
                        db.T_TypeofClaims.Remove(item);
                        db.SaveChanges();
                    }
					if(T_ClaimTypeIDSelected != null)
					{
					var T_ClaimTypeIDSelectedLong = T_ClaimTypeIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_TypeofClaims.Where(a => a.T_EmployeeInjuryID == t_typeofclaim.T_EmployeeInjuryID && T_ClaimTypeIDSelectedLong.Contains(a.T_ClaimTypeID.Value)).Select(p => p.T_ClaimTypeID.Value).ToList();
                    T_ClaimTypeIDSelectedLong = T_ClaimTypeIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_ClaimTypeIDSelectedLong != null)
                        foreach (var longid in T_ClaimTypeIDSelectedLong)
						{
                            {
								var obj = new T_TypeofClaim(); 
								obj = t_typeofclaim;
								obj.T_ClaimTypeID = longid;
								db.Entry(obj).State = EntityState.Added;
								 //obj.t_claimtype = db.T_ClaimTypes.FirstOrDefault(p => p.Id == t_typeofclaim.T_ClaimTypeID);
								 if(obj.t_employeeinjury !=null )
									db.Entry(obj.t_employeeinjury).State = EntityState.Unchanged;
								if(obj.t_claimtype !=null )
									 db.Entry(obj.t_claimtype).State = EntityState.Unchanged;
								//
								//
							 db.T_TypeofClaims.Add(obj); db.SaveChanges();
							}
						}
				}
			}
				if(T_EmployeeInjuryIDSelected != null || T_EmployeeInjuryIDAvailable != null)
				{
					t_typeofclaim.t_claimtype = db.T_ClaimTypes.FirstOrDefault(p => p.Id == t_typeofclaim.T_ClaimTypeID);
					var T_EmployeeInjuryIDSelectedlong =T_EmployeeInjuryIDSelected !=null ? T_EmployeeInjuryIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_TypeofClaims.Where(p => p.T_ClaimTypeID == t_typeofclaim.T_ClaimTypeID && !T_EmployeeInjuryIDSelectedlong.Contains(p.T_EmployeeInjuryID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_claimtype !=null )
						db.Entry(item.t_claimtype).State = EntityState.Unchanged;
					if(item.t_employeeinjury !=null )
                        db.Entry(item.t_employeeinjury).State = EntityState.Unchanged;
						db.Entry(item).State = EntityState.Deleted;
                        db.T_TypeofClaims.Remove(item);
                        db.SaveChanges();
                    }
					if(T_EmployeeInjuryIDSelected != null)
					{
					var T_EmployeeInjuryIDSelectedLong = T_EmployeeInjuryIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_TypeofClaims.Where(a => a.T_ClaimTypeID == t_typeofclaim.T_ClaimTypeID && T_EmployeeInjuryIDSelectedLong.Contains(a.T_EmployeeInjuryID.Value)).Select(p => p.T_EmployeeInjuryID.Value).ToList();
                    T_EmployeeInjuryIDSelectedLong = T_EmployeeInjuryIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_EmployeeInjuryIDSelectedLong != null)
                        foreach (var longid in T_EmployeeInjuryIDSelectedLong)
						{
                            {
								var obj = new T_TypeofClaim(); 
								obj = t_typeofclaim;
								obj.T_EmployeeInjuryID = longid;
								db.Entry(obj).State = EntityState.Added;
								 //obj.t_employeeinjury = db.T_EmployeeInjurys.FirstOrDefault(p => p.Id == t_typeofclaim.T_EmployeeInjuryID);
								 if(obj.t_claimtype !=null )
									db.Entry(obj.t_claimtype).State = EntityState.Unchanged;
								if(obj.t_employeeinjury !=null )
									 db.Entry(obj.t_employeeinjury).State = EntityState.Unchanged;
								//
								//
							 db.T_TypeofClaims.Add(obj); db.SaveChanges();
							}
						}
				}
			}
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_typeofclaim,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_typeofclaim.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_typeofclaim);
			ViewData["T_TypeofClaimParentUrl"] = UrlReferrer;
			ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnCreate", true);
			ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnCreate");
            return View(t_typeofclaim);
        }
		// GET: /T_TypeofClaim/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_TypeofClaim") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_TypeofClaim t_typeofclaim = db.T_TypeofClaims.Find(id);
            if (t_typeofclaim == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_TypeofClaimParentUrl"] = UrlReferrer;
		if(ViewData["T_TypeofClaimParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeofClaim")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeofClaim/Edit/" + t_typeofclaim.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeofClaim/Create"))
			ViewData["T_TypeofClaimParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_typeofclaim);
		   ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", true);
		   ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnEdit");
		    var objT_TypeofClaim = new List<T_TypeofClaim>();
            ViewBag.T_TypeofClaimDD = new SelectList(objT_TypeofClaim, "ID", "DisplayValue"); 
          return View(t_typeofclaim);
        }
		// POST: /T_TypeofClaim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeID,T_EmployeeInjuryID")] T_TypeofClaim t_typeofclaim,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_typeofclaim, command);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_typeofclaim,out customsave_hasissues,command))
                {
					db.Entry(t_typeofclaim).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_typeofclaim);
			ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", true);
			ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnEdit");
            return View(t_typeofclaim);
        }
        // GET: /T_TypeofClaim/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_TypeofClaim") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TypeofClaim t_typeofclaim = db.T_TypeofClaims.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_TypeofClaimlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_TypeofClaims.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_TypeofClaimDisplayValueEdit = TempData["T_TypeofClaimlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_TypeofClaimlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_TypeofClaimDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_typeofclaim == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeofClaim/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_typeofclaim.DisplayValue, Value = t_typeofclaim.Id.ToString() }));
                ViewBag.EntityT_TypeofClaimDisplayValueEdit = newList;
				TempData["T_TypeofClaimlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_typeofclaim.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_typeofclaim.DisplayValue;
                    newList[0].Value = t_typeofclaim.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_typeofclaim.DisplayValue, Value = t_typeofclaim.Id.ToString() }));
                }
                ViewBag.EntityT_TypeofClaimDisplayValueEdit = newList;
				TempData["T_TypeofClaimlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_TypeofClaimParentUrl"] = UrlReferrer;
		if(ViewData["T_TypeofClaimParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeofClaim")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeofClaim/Edit/" + t_typeofclaim.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeofClaim/Create"))
			ViewData["T_TypeofClaimParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_typeofclaim);
		   ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", true);
		   ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnEdit");
          return View(t_typeofclaim);
        }
        // POST: /T_TypeofClaim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeID,T_EmployeeInjuryID")] T_TypeofClaim t_typeofclaim,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_typeofclaim, command);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_typeofclaim,out customsave_hasissues,command))
            {
				db.Entry(t_typeofclaim).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_typeofclaim,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_typeofclaim.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_TypeofClaimlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_TypeofClaims.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_TypeofClaimDisplayValueEdit = TempData["T_TypeofClaimlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_TypeofClaimlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_TypeofClaimDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_typeofclaim);
			 ViewData["T_TypeofClaimParentUrl"] = UrlReferrer;
			ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", true);
			ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnEdit");
            return View(t_typeofclaim);
        }
		// GET: /T_TypeofClaim/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_TypeofClaim") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_TypeofClaim t_typeofclaim = db.T_TypeofClaims.Find(id);
            if (t_typeofclaim == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_TypeofClaimParentUrl"] = UrlReferrer;
		if(ViewData["T_TypeofClaimParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeofClaim"))
			ViewData["T_TypeofClaimParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_typeofclaim);
			 ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", true);
			 ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnEdit");
          return View(t_typeofclaim);
        }
        // POST: /T_TypeofClaim/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeID,T_EmployeeInjuryID")] T_TypeofClaim t_typeofclaim,string UrlReferrer)
        {
			CheckBeforeSave(t_typeofclaim);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_typeofclaim,out customsave_hasissues,"Save"))
            {
				db.Entry(t_typeofclaim).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_typeofclaim,"Edit","");
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
			LoadViewDataAfterOnEdit(t_typeofclaim);
			ViewBag.T_TypeofClaimIsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", false);
			ViewBag.T_TypeofClaimIsGroupsHiddenRule = checkHidden("T_TypeofClaim", "OnEdit", true);
			ViewBag.T_TypeofClaimIsSetValueUIRule = checkSetValueUIRule("T_TypeofClaim", "OnEdit");
            return View(t_typeofclaim);
        }
        // GET: /T_TypeofClaim/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_TypeofClaim") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_TypeofClaim t_typeofclaim = db.T_TypeofClaims.Find(id);
            if (t_typeofclaim == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_TypeofClaimParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeofClaim"))
			 ViewData["T_TypeofClaimParentUrl"] = Request.UrlReferrer;
            return View(t_typeofclaim);
        }
        // POST: /T_TypeofClaim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_TypeofClaim t_typeofclaim, string UrlReferrer)
        {
			if (!User.CanDelete("T_TypeofClaim"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_typeofclaim))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_typeofclaim, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_typeofclaim).State = EntityState.Deleted;
            db.T_TypeofClaims.Remove(t_typeofclaim);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_TypeofClaimParentUrl"] != null)
					{
						string parentUrl = ViewData["T_TypeofClaimParentUrl"].ToString();
						ViewData["T_TypeofClaimParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_typeofclaim);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_TypeofClaim", User) || !User.CanDelete("T_TypeofClaim")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_TypeofClaim t_typeofclaim = db.T_TypeofClaims.Find(id);
		if (CheckBeforeDelete(t_typeofclaim))
        {
            if (!CustomDelete(t_typeofclaim, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_typeofclaim).State = EntityState.Deleted;
                db.T_TypeofClaims.Remove(t_typeofclaim);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_TypeofClaim", User) || !User.CanEdit("T_TypeofClaim") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_TypeofClaimParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_ClaimTypeID,T_EmployeeInjuryID")] T_TypeofClaim t_typeofclaim,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_TypeofClaim target = db.T_TypeofClaims.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_typeofclaim, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_claimtype != null)
							  db.Entry(target.t_claimtype).State = EntityState.Unchanged;
							if (target.t_employeeinjury != null)
							  db.Entry(target.t_employeeinjury).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_typeofclaim,"BulkUpdate","");
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
