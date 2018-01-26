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

    public partial class T_FacilityUserController : BaseController
    {
			//private ApplicationDbContext UserContext = new ApplicationDbContext();
			 public ApplicationDbContext UserContext { get { return new ApplicationDbContext(User); } private set{} } 
        // GET: /T_FacilityUser/
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
			var lstT_FacilityUser = from s in db.T_FacilityUsers
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_FacilityUser = searchRecords(lstT_FacilityUser, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_FacilityUser = sortRecords(lstT_FacilityUser, sortBy, isAsc);
            }
            else lstT_FacilityUser = lstT_FacilityUser.OrderByDescending(c => c.Id);
			lstT_FacilityUser = CustomSorting(lstT_FacilityUser);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_FacilityUser"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_FacilityUser"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_FacilityUser"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_FacilityUser"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_FacilityUser = lstT_FacilityUser.Include(t=>t.t_user).Include(t=>t.t_facility);
		 if (HostingEntity == "T_Facility" && AssociatedType == "T_FacilityUser_T_Facility")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_FacilityUser = _T_FacilityUser.Where(p => p.T_FacilityID == hostid);
			 }
			 else
			     _T_FacilityUser = _T_FacilityUser.Where(p => p.T_FacilityID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_FacilityUser", User) || !User.CanView("T_FacilityUser"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_FacilityUser.Count() > 0)
                    pageSize = _T_FacilityUser.Count();
                return View("ExcelExport", _T_FacilityUser.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_FacilityUser.Count();
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
				var list = _T_FacilityUser.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_FacilityUserDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_FacilityUserlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_FacilityUser = _fad.FilterDropdown<T_FacilityUser>(User,  _T_FacilityUser, "T_FacilityUser", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_FacilityUser.Except(_T_FacilityUser),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_FacilityUser.Except(_T_FacilityUser).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_FacilityUser.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_FacilityUser.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_FacilityUser.Count() == 0 ? 1 : _T_FacilityUser.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_FacilityUser.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_FacilityUserDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_FacilityUserlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_FacilityUser.Count() == 0 ? 1 : _T_FacilityUser.Count();
                            }
							var list = _T_FacilityUser.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_FacilityUserDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_FacilityUserlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_FacilityUser/Details/5
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
            T_FacilityUser t_facilityuser = db.T_FacilityUsers.Find(id);
            if (t_facilityuser == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_facilityuser);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_facilityuser, AssociatedType);
            ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnDetails", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnDetails", true);
			ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnDetails");
			return View(ViewBag.TemplatesName,t_facilityuser);
        }
        // GET: /T_FacilityUser/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_FacilityUser") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_FacilityUserParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", true);
		  ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnCreate");
          return View();
        }
		// GET: /T_FacilityUser/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_FacilityUser") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_FacilityUserParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", true);
			 ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnCreate");
            return View();
        }
		// POST: /T_FacilityUser/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_UserID,T_FacilityID")] T_FacilityUser t_facilityuser, string UrlReferrer)
        {
			CheckBeforeSave(t_facilityuser);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_facilityuser,out customcreate_hasissues,"Create"))
                {
                    db.T_FacilityUsers.Add(t_facilityuser);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_facilityuser,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_facilityuser);
			ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", true);
			ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnCreate");	
            return View(t_facilityuser);
        }
		 // GET: /T_FacilityUser/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_FacilityUser") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_FacilityUserParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", true);
			ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnCreate");
            return View();
        }
		  // POST: /T_FacilityUser/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_UserID,T_FacilityID")] T_FacilityUser t_facilityuser, List<string> T_UserIDSelected, List<string> T_UserIDAvailable, List<string> T_FacilityIDSelected, List<string> T_FacilityIDAvailable,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_facilityuser);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
					if(T_UserIDSelected != null || T_UserIDAvailable != null)
				{
				    t_facilityuser.t_facility = db.T_Facilitys.FirstOrDefault(p => p.Id == t_facilityuser.T_FacilityID);
					var deletedItems = db.T_FacilityUsers.Where(p => p.T_FacilityID == t_facilityuser.T_FacilityID && !T_UserIDSelected.Contains(p.T_UserID)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_facility !=null )
					    db.Entry(item.t_facility).State = EntityState.Unchanged;
						if(item.t_user !=null )
                        db.Entry(item.t_user).State = EntityState.Unchanged;
                        db.T_FacilityUsers.Remove(item);
                        db.SaveChanges();
                    }
					if(T_UserIDSelected != null)
					{
					var T_UserIDSelectedLong = T_UserIDSelected.ToList();
					var alreadyregistered = db.T_FacilityUsers.Where(a => a.T_FacilityID == t_facilityuser.T_FacilityID && T_UserIDSelectedLong.Contains(a.T_UserID)).Select(p => p.T_UserID).ToList();
                    T_UserIDSelectedLong = T_UserIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_UserIDSelectedLong != null)
                        foreach (var longid in T_UserIDSelectedLong)
						{
                            {
								var obj = new T_FacilityUser(); 
								obj = t_facilityuser;
								obj.T_UserID = longid;//Convert.ToString(id);
								db.Entry(obj).State = EntityState.Added;
								//obj.t_user = db.T_Users.FirstOrDefault(p => p.Id == t_facilityuser.T_UserID);
								if(obj.t_facility !=null )
									db.Entry(obj.t_facility).State = EntityState.Unchanged;
								if(obj.t_user !=null )
									db.Entry(obj.t_user).State = EntityState.Unchanged;
								//
								//
								db.T_FacilityUsers.Add(obj); db.SaveChanges();
							}
						}
					}
				}
				if(T_FacilityIDSelected != null || T_FacilityIDAvailable != null)
				{
				    t_facilityuser.t_user = db.T_Users.FirstOrDefault(p => p.Id == t_facilityuser.T_UserID);
					var T_FacilityIDSelectedlong =T_FacilityIDSelected !=null ? T_FacilityIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_FacilityUsers.Where(p => p.T_UserID == t_facilityuser.T_UserID && !T_FacilityIDSelectedlong.Contains(p.T_FacilityID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_user !=null )
					    db.Entry(item.t_user).State = EntityState.Unchanged;
						if(item.t_facility !=null )
                        db.Entry(item.t_facility).State = EntityState.Unchanged;
                        db.T_FacilityUsers.Remove(item);
                        db.SaveChanges();
                    }
					if(T_FacilityIDSelected != null)
					{
					var T_FacilityIDSelectedLong = T_FacilityIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_FacilityUsers.Where(a => a.T_UserID == t_facilityuser.T_UserID && T_FacilityIDSelectedLong.Contains(a.T_FacilityID.Value)).Select(p => p.T_FacilityID.Value).ToList();
                    T_FacilityIDSelectedLong = T_FacilityIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_FacilityIDSelectedLong != null)
                        foreach (var longid in T_FacilityIDSelectedLong)
						{
                            {
								var obj = new T_FacilityUser(); 
								obj = t_facilityuser;
								obj.T_FacilityID = longid;//Convert.ToInt64(id);
								db.Entry(obj).State = EntityState.Added;
								//obj.t_facility = db.T_Facilitys.FirstOrDefault(p => p.Id == t_facilityuser.T_FacilityID);
								if(obj.t_user !=null )
									db.Entry(obj.t_user).State = EntityState.Unchanged;
								if(obj.t_facility !=null )
									db.Entry(obj.t_facility).State = EntityState.Unchanged;
								//
								//
								db.T_FacilityUsers.Add(obj); db.SaveChanges();
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
			LoadViewDataAfterOnCreate(t_facilityuser);
			ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", true);
			ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_facilityuser, AssociatedEntity);
			return View(t_facilityuser);
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
        // POST: /T_FacilityUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_UserID,T_FacilityID")] T_FacilityUser t_facilityuser, List<string> T_UserIDSelected, List<string> T_UserIDAvailable, List<string> T_FacilityIDSelected, List<string> T_FacilityIDAvailable, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_facilityuser, command);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
				if(T_UserIDSelected != null || T_UserIDAvailable != null)
				{
					t_facilityuser.t_facility = db.T_Facilitys.FirstOrDefault(p => p.Id == t_facilityuser.T_FacilityID);
					var deletedItems = db.T_FacilityUsers.Where(p => p.T_FacilityID == t_facilityuser.T_FacilityID && !T_UserIDSelected.Contains(p.T_UserID)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_facility !=null )
						db.Entry(item.t_facility).State = EntityState.Unchanged;
					if(item.t_user !=null )
                        db.Entry(item.t_user).State = EntityState.Unchanged;
						db.Entry(item).State = EntityState.Deleted;
                        db.T_FacilityUsers.Remove(item);
                        db.SaveChanges();
                    }
					if(T_UserIDSelected != null)
					{
					var T_UserIDSelectedLong = T_UserIDSelected.ToList();
					var alreadyregistered = db.T_FacilityUsers.Where(a => a.T_FacilityID == t_facilityuser.T_FacilityID && T_UserIDSelectedLong.Contains(a.T_UserID)).Select(p => p.T_UserID).ToList();
                    T_UserIDSelectedLong = T_UserIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_UserIDSelectedLong != null)
                        foreach (var longid in T_UserIDSelectedLong)
						{
                            {
								var obj = new T_FacilityUser(); 
								obj = t_facilityuser;
								obj.T_UserID = longid;
								db.Entry(obj).State = EntityState.Added;
								 //obj.t_user = db.T_Users.FirstOrDefault(p => p.Id == t_facilityuser.T_UserID);
								 if(obj.t_facility !=null )
									db.Entry(obj.t_facility).State = EntityState.Unchanged;
								if(obj.t_user !=null )
									 db.Entry(obj.t_user).State = EntityState.Unchanged;
								//
								//
							 db.T_FacilityUsers.Add(obj); db.SaveChanges();
							}
						}
				}
			}
				if(T_FacilityIDSelected != null || T_FacilityIDAvailable != null)
				{
					t_facilityuser.t_user = db.T_Users.FirstOrDefault(p => p.Id == t_facilityuser.T_UserID);
					var T_FacilityIDSelectedlong =T_FacilityIDSelected !=null ? T_FacilityIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_FacilityUsers.Where(p => p.T_UserID == t_facilityuser.T_UserID && !T_FacilityIDSelectedlong.Contains(p.T_FacilityID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_user !=null )
						db.Entry(item.t_user).State = EntityState.Unchanged;
					if(item.t_facility !=null )
                        db.Entry(item.t_facility).State = EntityState.Unchanged;
						db.Entry(item).State = EntityState.Deleted;
                        db.T_FacilityUsers.Remove(item);
                        db.SaveChanges();
                    }
					if(T_FacilityIDSelected != null)
					{
					var T_FacilityIDSelectedLong = T_FacilityIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_FacilityUsers.Where(a => a.T_UserID == t_facilityuser.T_UserID && T_FacilityIDSelectedLong.Contains(a.T_FacilityID.Value)).Select(p => p.T_FacilityID.Value).ToList();
                    T_FacilityIDSelectedLong = T_FacilityIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_FacilityIDSelectedLong != null)
                        foreach (var longid in T_FacilityIDSelectedLong)
						{
                            {
								var obj = new T_FacilityUser(); 
								obj = t_facilityuser;
								obj.T_FacilityID = longid;
								db.Entry(obj).State = EntityState.Added;
								 //obj.t_facility = db.T_Facilitys.FirstOrDefault(p => p.Id == t_facilityuser.T_FacilityID);
								 if(obj.t_user !=null )
									db.Entry(obj.t_user).State = EntityState.Unchanged;
								if(obj.t_facility !=null )
									 db.Entry(obj.t_facility).State = EntityState.Unchanged;
								//
								//
							 db.T_FacilityUsers.Add(obj); db.SaveChanges();
							}
						}
				}
			}
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_facilityuser,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_facilityuser.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_facilityuser);
			ViewData["T_FacilityUserParentUrl"] = UrlReferrer;
			ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnCreate", true);
			ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnCreate");
            return View(t_facilityuser);
        }
		// GET: /T_FacilityUser/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_FacilityUser") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_FacilityUser t_facilityuser = db.T_FacilityUsers.Find(id);
            if (t_facilityuser == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_FacilityUserParentUrl"] = UrlReferrer;
		if(ViewData["T_FacilityUserParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityUser")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityUser/Edit/" + t_facilityuser.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityUser/Create"))
			ViewData["T_FacilityUserParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_facilityuser);
		   ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", true);
		   ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnEdit");
		    var objT_FacilityUser = new List<T_FacilityUser>();
            ViewBag.T_FacilityUserDD = new SelectList(objT_FacilityUser, "ID", "DisplayValue"); 
          return View(t_facilityuser);
        }
		// POST: /T_FacilityUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_UserID,T_FacilityID")] T_FacilityUser t_facilityuser,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_facilityuser, command);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_facilityuser,out customsave_hasissues,command))
                {
					db.Entry(t_facilityuser).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_facilityuser);
			ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", true);
			ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnEdit");
            return View(t_facilityuser);
        }
        // GET: /T_FacilityUser/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_FacilityUser") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_FacilityUser t_facilityuser = db.T_FacilityUsers.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_FacilityUserlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_FacilityUsers.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_FacilityUserDisplayValueEdit = TempData["T_FacilityUserlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_FacilityUserlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_FacilityUserDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_facilityuser == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityUser/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_facilityuser.DisplayValue, Value = t_facilityuser.Id.ToString() }));
                ViewBag.EntityT_FacilityUserDisplayValueEdit = newList;
				TempData["T_FacilityUserlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_facilityuser.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_facilityuser.DisplayValue;
                    newList[0].Value = t_facilityuser.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_facilityuser.DisplayValue, Value = t_facilityuser.Id.ToString() }));
                }
                ViewBag.EntityT_FacilityUserDisplayValueEdit = newList;
				TempData["T_FacilityUserlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_FacilityUserParentUrl"] = UrlReferrer;
		if(ViewData["T_FacilityUserParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityUser")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityUser/Edit/" + t_facilityuser.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityUser/Create"))
			ViewData["T_FacilityUserParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_facilityuser);
		   ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", true);
		   ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnEdit");
          return View(t_facilityuser);
        }
        // POST: /T_FacilityUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_UserID,T_FacilityID")] T_FacilityUser t_facilityuser,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_facilityuser, command);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_facilityuser,out customsave_hasissues,command))
            {
				db.Entry(t_facilityuser).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_facilityuser,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_facilityuser.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_FacilityUserlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_FacilityUsers.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_FacilityUserDisplayValueEdit = TempData["T_FacilityUserlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_FacilityUserlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_FacilityUserDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_facilityuser);
			 ViewData["T_FacilityUserParentUrl"] = UrlReferrer;
			ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", true);
			ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnEdit");
            return View(t_facilityuser);
        }
		// GET: /T_FacilityUser/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_FacilityUser") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_FacilityUser t_facilityuser = db.T_FacilityUsers.Find(id);
            if (t_facilityuser == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_FacilityUserParentUrl"] = UrlReferrer;
		if(ViewData["T_FacilityUserParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityUser"))
			ViewData["T_FacilityUserParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_facilityuser);
			 ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", true);
			 ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnEdit");
          return View(t_facilityuser);
        }
        // POST: /T_FacilityUser/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_UserID,T_FacilityID")] T_FacilityUser t_facilityuser,string UrlReferrer)
        {
			CheckBeforeSave(t_facilityuser);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_facilityuser,out customsave_hasissues,"Save"))
            {
				db.Entry(t_facilityuser).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_facilityuser,"Edit","");
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
			LoadViewDataAfterOnEdit(t_facilityuser);
			ViewBag.T_FacilityUserIsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", false);
			ViewBag.T_FacilityUserIsGroupsHiddenRule = checkHidden("T_FacilityUser", "OnEdit", true);
			ViewBag.T_FacilityUserIsSetValueUIRule = checkSetValueUIRule("T_FacilityUser", "OnEdit");
            return View(t_facilityuser);
        }
        // GET: /T_FacilityUser/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_FacilityUser") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_FacilityUser t_facilityuser = db.T_FacilityUsers.Find(id);
            if (t_facilityuser == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_FacilityUserParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_FacilityUser"))
			 ViewData["T_FacilityUserParentUrl"] = Request.UrlReferrer;
            return View(t_facilityuser);
        }
        // POST: /T_FacilityUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_FacilityUser t_facilityuser, string UrlReferrer)
        {
			if (!User.CanDelete("T_FacilityUser"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_facilityuser))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_facilityuser, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_facilityuser).State = EntityState.Deleted;
            db.T_FacilityUsers.Remove(t_facilityuser);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_FacilityUserParentUrl"] != null)
					{
						string parentUrl = ViewData["T_FacilityUserParentUrl"].ToString();
						ViewData["T_FacilityUserParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_facilityuser);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_FacilityUser", User) || !User.CanDelete("T_FacilityUser")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_FacilityUser t_facilityuser = db.T_FacilityUsers.Find(id);
		if (CheckBeforeDelete(t_facilityuser))
        {
            if (!CustomDelete(t_facilityuser, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_facilityuser).State = EntityState.Deleted;
                db.T_FacilityUsers.Remove(t_facilityuser);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_FacilityUser", User) || !User.CanEdit("T_FacilityUser") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_FacilityUserParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_UserID,T_FacilityID")] T_FacilityUser t_facilityuser,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_FacilityUser target = db.T_FacilityUsers.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_facilityuser, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_user != null)
							  db.Entry(target.t_user).State = EntityState.Unchanged;
							if (target.t_facility != null)
							  db.Entry(target.t_facility).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_facilityuser,"BulkUpdate","");
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
