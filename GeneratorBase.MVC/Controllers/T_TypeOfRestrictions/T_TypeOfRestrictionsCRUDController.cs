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

    public partial class T_TypeOfRestrictionsController : BaseController
    {
        // GET: /T_TypeOfRestrictions/
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
			var lstT_TypeOfRestrictions = from s in db.T_TypeOfRestrictionss
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_TypeOfRestrictions = searchRecords(lstT_TypeOfRestrictions, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_TypeOfRestrictions = sortRecords(lstT_TypeOfRestrictions, sortBy, isAsc);
            }
            else lstT_TypeOfRestrictions = lstT_TypeOfRestrictions.OrderByDescending(c => c.Id);
			lstT_TypeOfRestrictions = CustomSorting(lstT_TypeOfRestrictions);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_TypeOfRestrictions"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_TypeOfRestrictions"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_TypeOfRestrictions"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_TypeOfRestrictions"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_TypeOfRestrictions = lstT_TypeOfRestrictions.Include(t=>t.t_restrictions).Include(t=>t.t_employeeinjury);
		 if (HostingEntity == "T_Restrictions" && AssociatedType == "T_TypeOfRestrictions_T_Restrictions")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_TypeOfRestrictions = _T_TypeOfRestrictions.Where(p => p.T_RestrictionsID == hostid);
			 }
			 else
			     _T_TypeOfRestrictions = _T_TypeOfRestrictions.Where(p => p.T_RestrictionsID == null);
         }
		 if (HostingEntity == "T_EmployeeInjury" && AssociatedType == "T_TypeOfRestrictions_T_EmployeeInjury")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_TypeOfRestrictions = _T_TypeOfRestrictions.Where(p => p.T_EmployeeInjuryID == hostid);
			 }
			 else
			     _T_TypeOfRestrictions = _T_TypeOfRestrictions.Where(p => p.T_EmployeeInjuryID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_TypeOfRestrictions", User) || !User.CanView("T_TypeOfRestrictions"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_TypeOfRestrictions.Count() > 0)
                    pageSize = _T_TypeOfRestrictions.Count();
                return View("ExcelExport", _T_TypeOfRestrictions.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_TypeOfRestrictions.Count();
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
				var list = _T_TypeOfRestrictions.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_TypeOfRestrictionsDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_TypeOfRestrictionslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_TypeOfRestrictions = _fad.FilterDropdown<T_TypeOfRestrictions>(User,  _T_TypeOfRestrictions, "T_TypeOfRestrictions", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_TypeOfRestrictions.Except(_T_TypeOfRestrictions),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_TypeOfRestrictions.Except(_T_TypeOfRestrictions).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_TypeOfRestrictions.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_TypeOfRestrictions.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_TypeOfRestrictions.Count() == 0 ? 1 : _T_TypeOfRestrictions.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_TypeOfRestrictions.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_TypeOfRestrictionsDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_TypeOfRestrictionslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_TypeOfRestrictions.Count() == 0 ? 1 : _T_TypeOfRestrictions.Count();
                            }
							var list = _T_TypeOfRestrictions.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_TypeOfRestrictionsDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_TypeOfRestrictionslist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_TypeOfRestrictions/Details/5
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
            T_TypeOfRestrictions t_typeofrestrictions = db.T_TypeOfRestrictionss.Find(id);
            if (t_typeofrestrictions == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_typeofrestrictions);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_typeofrestrictions, AssociatedType);
            ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnDetails", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnDetails", true);
			ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnDetails");
			return View(ViewBag.TemplatesName,t_typeofrestrictions);
        }
        // GET: /T_TypeOfRestrictions/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_TypeOfRestrictions") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_TypeOfRestrictionsParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", true);
		  ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnCreate");
          return View();
        }
		// GET: /T_TypeOfRestrictions/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_TypeOfRestrictions") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_TypeOfRestrictionsParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", true);
			 ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnCreate");
            return View();
        }
		// POST: /T_TypeOfRestrictions/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_RestrictionsID,T_EmployeeInjuryID")] T_TypeOfRestrictions t_typeofrestrictions, string UrlReferrer)
        {
			CheckBeforeSave(t_typeofrestrictions);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_typeofrestrictions,out customcreate_hasissues,"Create"))
                {
                    db.T_TypeOfRestrictionss.Add(t_typeofrestrictions);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_typeofrestrictions,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_typeofrestrictions);
			ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", true);
			ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnCreate");	
            return View(t_typeofrestrictions);
        }
		 // GET: /T_TypeOfRestrictions/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_TypeOfRestrictions") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_TypeOfRestrictionsParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", true);
			ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnCreate");
            return View();
        }
		  // POST: /T_TypeOfRestrictions/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_RestrictionsID,T_EmployeeInjuryID")] T_TypeOfRestrictions t_typeofrestrictions, List<string> T_RestrictionsIDSelected, List<string> T_RestrictionsIDAvailable, List<string> T_EmployeeInjuryIDSelected, List<string> T_EmployeeInjuryIDAvailable,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_typeofrestrictions);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
					if(T_RestrictionsIDSelected != null || T_RestrictionsIDAvailable != null)
				{
				    t_typeofrestrictions.t_employeeinjury = db.T_EmployeeInjurys.FirstOrDefault(p => p.Id == t_typeofrestrictions.T_EmployeeInjuryID);
					var T_RestrictionsIDSelectedlong =T_RestrictionsIDSelected !=null ? T_RestrictionsIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_TypeOfRestrictionss.Where(p => p.T_EmployeeInjuryID == t_typeofrestrictions.T_EmployeeInjuryID && !T_RestrictionsIDSelectedlong.Contains(p.T_RestrictionsID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_employeeinjury !=null )
					    db.Entry(item.t_employeeinjury).State = EntityState.Unchanged;
						if(item.t_restrictions !=null )
                        db.Entry(item.t_restrictions).State = EntityState.Unchanged;
                        db.T_TypeOfRestrictionss.Remove(item);
                        db.SaveChanges();
                    }
					if(T_RestrictionsIDSelected != null)
					{
					var T_RestrictionsIDSelectedLong = T_RestrictionsIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_typeofrestrictions.T_EmployeeInjuryID && T_RestrictionsIDSelectedLong.Contains(a.T_RestrictionsID.Value)).Select(p => p.T_RestrictionsID.Value).ToList();
                    T_RestrictionsIDSelectedLong = T_RestrictionsIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_RestrictionsIDSelectedLong != null)
                        foreach (var longid in T_RestrictionsIDSelectedLong)
						{
                            {
								var obj = new T_TypeOfRestrictions(); 
								obj = t_typeofrestrictions;
								obj.T_RestrictionsID = longid;//Convert.ToInt64(id);
								db.Entry(obj).State = EntityState.Added;
								//obj.t_restrictions = db.T_Restrictionss.FirstOrDefault(p => p.Id == t_typeofrestrictions.T_RestrictionsID);
								if(obj.t_employeeinjury !=null )
									db.Entry(obj.t_employeeinjury).State = EntityState.Unchanged;
								if(obj.t_restrictions !=null )
									db.Entry(obj.t_restrictions).State = EntityState.Unchanged;
								//
								//
								db.T_TypeOfRestrictionss.Add(obj); db.SaveChanges();
							}
						}
					}
				}
				if(T_EmployeeInjuryIDSelected != null || T_EmployeeInjuryIDAvailable != null)
				{
				    t_typeofrestrictions.t_restrictions = db.T_Restrictionss.FirstOrDefault(p => p.Id == t_typeofrestrictions.T_RestrictionsID);
					var T_EmployeeInjuryIDSelectedlong =T_EmployeeInjuryIDSelected !=null ? T_EmployeeInjuryIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_TypeOfRestrictionss.Where(p => p.T_RestrictionsID == t_typeofrestrictions.T_RestrictionsID && !T_EmployeeInjuryIDSelectedlong.Contains(p.T_EmployeeInjuryID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_restrictions !=null )
					    db.Entry(item.t_restrictions).State = EntityState.Unchanged;
						if(item.t_employeeinjury !=null )
                        db.Entry(item.t_employeeinjury).State = EntityState.Unchanged;
                        db.T_TypeOfRestrictionss.Remove(item);
                        db.SaveChanges();
                    }
					if(T_EmployeeInjuryIDSelected != null)
					{
					var T_EmployeeInjuryIDSelectedLong = T_EmployeeInjuryIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_TypeOfRestrictionss.Where(a => a.T_RestrictionsID == t_typeofrestrictions.T_RestrictionsID && T_EmployeeInjuryIDSelectedLong.Contains(a.T_EmployeeInjuryID.Value)).Select(p => p.T_EmployeeInjuryID.Value).ToList();
                    T_EmployeeInjuryIDSelectedLong = T_EmployeeInjuryIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_EmployeeInjuryIDSelectedLong != null)
                        foreach (var longid in T_EmployeeInjuryIDSelectedLong)
						{
                            {
								var obj = new T_TypeOfRestrictions(); 
								obj = t_typeofrestrictions;
								obj.T_EmployeeInjuryID = longid;//Convert.ToInt64(id);
								db.Entry(obj).State = EntityState.Added;
								//obj.t_employeeinjury = db.T_EmployeeInjurys.FirstOrDefault(p => p.Id == t_typeofrestrictions.T_EmployeeInjuryID);
								if(obj.t_restrictions !=null )
									db.Entry(obj.t_restrictions).State = EntityState.Unchanged;
								if(obj.t_employeeinjury !=null )
									db.Entry(obj.t_employeeinjury).State = EntityState.Unchanged;
								//
								//
								db.T_TypeOfRestrictionss.Add(obj); db.SaveChanges();
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
			LoadViewDataAfterOnCreate(t_typeofrestrictions);
			ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", true);
			ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_typeofrestrictions, AssociatedEntity);
			return View(t_typeofrestrictions);
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
        // POST: /T_TypeOfRestrictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_RestrictionsID,T_EmployeeInjuryID")] T_TypeOfRestrictions t_typeofrestrictions, List<string> T_RestrictionsIDSelected, List<string> T_RestrictionsIDAvailable, List<string> T_EmployeeInjuryIDSelected, List<string> T_EmployeeInjuryIDAvailable, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_typeofrestrictions, command);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
				if(T_RestrictionsIDSelected != null || T_RestrictionsIDAvailable != null)
				{
					t_typeofrestrictions.t_employeeinjury = db.T_EmployeeInjurys.FirstOrDefault(p => p.Id == t_typeofrestrictions.T_EmployeeInjuryID);
					var T_RestrictionsIDSelectedlong =T_RestrictionsIDSelected !=null ? T_RestrictionsIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_TypeOfRestrictionss.Where(p => p.T_EmployeeInjuryID == t_typeofrestrictions.T_EmployeeInjuryID && !T_RestrictionsIDSelectedlong.Contains(p.T_RestrictionsID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_employeeinjury !=null )
						db.Entry(item.t_employeeinjury).State = EntityState.Unchanged;
					if(item.t_restrictions !=null )
                        db.Entry(item.t_restrictions).State = EntityState.Unchanged;
						db.Entry(item).State = EntityState.Deleted;
                        db.T_TypeOfRestrictionss.Remove(item);
                        db.SaveChanges();
                    }
					if(T_RestrictionsIDSelected != null)
					{
					var T_RestrictionsIDSelectedLong = T_RestrictionsIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_TypeOfRestrictionss.Where(a => a.T_EmployeeInjuryID == t_typeofrestrictions.T_EmployeeInjuryID && T_RestrictionsIDSelectedLong.Contains(a.T_RestrictionsID.Value)).Select(p => p.T_RestrictionsID.Value).ToList();
                    T_RestrictionsIDSelectedLong = T_RestrictionsIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_RestrictionsIDSelectedLong != null)
                        foreach (var longid in T_RestrictionsIDSelectedLong)
						{
                            {
								var obj = new T_TypeOfRestrictions(); 
								obj = t_typeofrestrictions;
								obj.T_RestrictionsID = longid;
								db.Entry(obj).State = EntityState.Added;
								 //obj.t_restrictions = db.T_Restrictionss.FirstOrDefault(p => p.Id == t_typeofrestrictions.T_RestrictionsID);
								 if(obj.t_employeeinjury !=null )
									db.Entry(obj.t_employeeinjury).State = EntityState.Unchanged;
								if(obj.t_restrictions !=null )
									 db.Entry(obj.t_restrictions).State = EntityState.Unchanged;
								//
								//
							 db.T_TypeOfRestrictionss.Add(obj); db.SaveChanges();
							}
						}
				}
			}
				if(T_EmployeeInjuryIDSelected != null || T_EmployeeInjuryIDAvailable != null)
				{
					t_typeofrestrictions.t_restrictions = db.T_Restrictionss.FirstOrDefault(p => p.Id == t_typeofrestrictions.T_RestrictionsID);
					var T_EmployeeInjuryIDSelectedlong =T_EmployeeInjuryIDSelected !=null ? T_EmployeeInjuryIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_TypeOfRestrictionss.Where(p => p.T_RestrictionsID == t_typeofrestrictions.T_RestrictionsID && !T_EmployeeInjuryIDSelectedlong.Contains(p.T_EmployeeInjuryID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_restrictions !=null )
						db.Entry(item.t_restrictions).State = EntityState.Unchanged;
					if(item.t_employeeinjury !=null )
                        db.Entry(item.t_employeeinjury).State = EntityState.Unchanged;
						db.Entry(item).State = EntityState.Deleted;
                        db.T_TypeOfRestrictionss.Remove(item);
                        db.SaveChanges();
                    }
					if(T_EmployeeInjuryIDSelected != null)
					{
					var T_EmployeeInjuryIDSelectedLong = T_EmployeeInjuryIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_TypeOfRestrictionss.Where(a => a.T_RestrictionsID == t_typeofrestrictions.T_RestrictionsID && T_EmployeeInjuryIDSelectedLong.Contains(a.T_EmployeeInjuryID.Value)).Select(p => p.T_EmployeeInjuryID.Value).ToList();
                    T_EmployeeInjuryIDSelectedLong = T_EmployeeInjuryIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_EmployeeInjuryIDSelectedLong != null)
                        foreach (var longid in T_EmployeeInjuryIDSelectedLong)
						{
                            {
								var obj = new T_TypeOfRestrictions(); 
								obj = t_typeofrestrictions;
								obj.T_EmployeeInjuryID = longid;
								db.Entry(obj).State = EntityState.Added;
								 //obj.t_employeeinjury = db.T_EmployeeInjurys.FirstOrDefault(p => p.Id == t_typeofrestrictions.T_EmployeeInjuryID);
								 if(obj.t_restrictions !=null )
									db.Entry(obj.t_restrictions).State = EntityState.Unchanged;
								if(obj.t_employeeinjury !=null )
									 db.Entry(obj.t_employeeinjury).State = EntityState.Unchanged;
								//
								//
							 db.T_TypeOfRestrictionss.Add(obj); db.SaveChanges();
							}
						}
				}
			}
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_typeofrestrictions,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_typeofrestrictions.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_typeofrestrictions);
			ViewData["T_TypeOfRestrictionsParentUrl"] = UrlReferrer;
			ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnCreate", true);
			ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnCreate");
            return View(t_typeofrestrictions);
        }
		// GET: /T_TypeOfRestrictions/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_TypeOfRestrictions") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_TypeOfRestrictions t_typeofrestrictions = db.T_TypeOfRestrictionss.Find(id);
            if (t_typeofrestrictions == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_TypeOfRestrictionsParentUrl"] = UrlReferrer;
		if(ViewData["T_TypeOfRestrictionsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeOfRestrictions")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeOfRestrictions/Edit/" + t_typeofrestrictions.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeOfRestrictions/Create"))
			ViewData["T_TypeOfRestrictionsParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_typeofrestrictions);
		   ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", true);
		   ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnEdit");
		    var objT_TypeOfRestrictions = new List<T_TypeOfRestrictions>();
            ViewBag.T_TypeOfRestrictionsDD = new SelectList(objT_TypeOfRestrictions, "ID", "DisplayValue"); 
          return View(t_typeofrestrictions);
        }
		// POST: /T_TypeOfRestrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_RestrictionsID,T_EmployeeInjuryID")] T_TypeOfRestrictions t_typeofrestrictions,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_typeofrestrictions, command);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_typeofrestrictions,out customsave_hasissues,command))
                {
					db.Entry(t_typeofrestrictions).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_typeofrestrictions);
			ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", true);
			ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnEdit");
            return View(t_typeofrestrictions);
        }
        // GET: /T_TypeOfRestrictions/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_TypeOfRestrictions") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TypeOfRestrictions t_typeofrestrictions = db.T_TypeOfRestrictionss.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_TypeOfRestrictionslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_TypeOfRestrictionss.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_TypeOfRestrictionsDisplayValueEdit = TempData["T_TypeOfRestrictionslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_TypeOfRestrictionslist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_TypeOfRestrictionsDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_typeofrestrictions == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeOfRestrictions/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_typeofrestrictions.DisplayValue, Value = t_typeofrestrictions.Id.ToString() }));
                ViewBag.EntityT_TypeOfRestrictionsDisplayValueEdit = newList;
				TempData["T_TypeOfRestrictionslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_typeofrestrictions.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_typeofrestrictions.DisplayValue;
                    newList[0].Value = t_typeofrestrictions.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_typeofrestrictions.DisplayValue, Value = t_typeofrestrictions.Id.ToString() }));
                }
                ViewBag.EntityT_TypeOfRestrictionsDisplayValueEdit = newList;
				TempData["T_TypeOfRestrictionslist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_TypeOfRestrictionsParentUrl"] = UrlReferrer;
		if(ViewData["T_TypeOfRestrictionsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeOfRestrictions")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeOfRestrictions/Edit/" + t_typeofrestrictions.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeOfRestrictions/Create"))
			ViewData["T_TypeOfRestrictionsParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_typeofrestrictions);
		   ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", true);
		   ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnEdit");
          return View(t_typeofrestrictions);
        }
        // POST: /T_TypeOfRestrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_RestrictionsID,T_EmployeeInjuryID")] T_TypeOfRestrictions t_typeofrestrictions,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_typeofrestrictions, command);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_typeofrestrictions,out customsave_hasissues,command))
            {
				db.Entry(t_typeofrestrictions).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_typeofrestrictions,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_typeofrestrictions.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_TypeOfRestrictionslist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_TypeOfRestrictionss.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_TypeOfRestrictionsDisplayValueEdit = TempData["T_TypeOfRestrictionslist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_TypeOfRestrictionslist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_TypeOfRestrictionsDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_typeofrestrictions);
			 ViewData["T_TypeOfRestrictionsParentUrl"] = UrlReferrer;
			ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", true);
			ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnEdit");
            return View(t_typeofrestrictions);
        }
		// GET: /T_TypeOfRestrictions/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_TypeOfRestrictions") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_TypeOfRestrictions t_typeofrestrictions = db.T_TypeOfRestrictionss.Find(id);
            if (t_typeofrestrictions == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_TypeOfRestrictionsParentUrl"] = UrlReferrer;
		if(ViewData["T_TypeOfRestrictionsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeOfRestrictions"))
			ViewData["T_TypeOfRestrictionsParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_typeofrestrictions);
			 ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", true);
			 ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnEdit");
          return View(t_typeofrestrictions);
        }
        // POST: /T_TypeOfRestrictions/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_RestrictionsID,T_EmployeeInjuryID")] T_TypeOfRestrictions t_typeofrestrictions,string UrlReferrer)
        {
			CheckBeforeSave(t_typeofrestrictions);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_typeofrestrictions,out customsave_hasissues,"Save"))
            {
				db.Entry(t_typeofrestrictions).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_typeofrestrictions,"Edit","");
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
			LoadViewDataAfterOnEdit(t_typeofrestrictions);
			ViewBag.T_TypeOfRestrictionsIsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", false);
			ViewBag.T_TypeOfRestrictionsIsGroupsHiddenRule = checkHidden("T_TypeOfRestrictions", "OnEdit", true);
			ViewBag.T_TypeOfRestrictionsIsSetValueUIRule = checkSetValueUIRule("T_TypeOfRestrictions", "OnEdit");
            return View(t_typeofrestrictions);
        }
        // GET: /T_TypeOfRestrictions/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_TypeOfRestrictions") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_TypeOfRestrictions t_typeofrestrictions = db.T_TypeOfRestrictionss.Find(id);
            if (t_typeofrestrictions == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_TypeOfRestrictionsParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_TypeOfRestrictions"))
			 ViewData["T_TypeOfRestrictionsParentUrl"] = Request.UrlReferrer;
            return View(t_typeofrestrictions);
        }
        // POST: /T_TypeOfRestrictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_TypeOfRestrictions t_typeofrestrictions, string UrlReferrer)
        {
			if (!User.CanDelete("T_TypeOfRestrictions"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_typeofrestrictions))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_typeofrestrictions, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_typeofrestrictions).State = EntityState.Deleted;
            db.T_TypeOfRestrictionss.Remove(t_typeofrestrictions);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_TypeOfRestrictionsParentUrl"] != null)
					{
						string parentUrl = ViewData["T_TypeOfRestrictionsParentUrl"].ToString();
						ViewData["T_TypeOfRestrictionsParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_typeofrestrictions);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_TypeOfRestrictions", User) || !User.CanDelete("T_TypeOfRestrictions")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_TypeOfRestrictions t_typeofrestrictions = db.T_TypeOfRestrictionss.Find(id);
		if (CheckBeforeDelete(t_typeofrestrictions))
        {
            if (!CustomDelete(t_typeofrestrictions, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_typeofrestrictions).State = EntityState.Deleted;
                db.T_TypeOfRestrictionss.Remove(t_typeofrestrictions);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_TypeOfRestrictions", User) || !User.CanEdit("T_TypeOfRestrictions") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_TypeOfRestrictionsParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_RestrictionsID,T_EmployeeInjuryID")] T_TypeOfRestrictions t_typeofrestrictions,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_TypeOfRestrictions target = db.T_TypeOfRestrictionss.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_typeofrestrictions, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_restrictions != null)
							  db.Entry(target.t_restrictions).State = EntityState.Unchanged;
							if (target.t_employeeinjury != null)
							  db.Entry(target.t_employeeinjury).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_typeofrestrictions,"BulkUpdate","");
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
