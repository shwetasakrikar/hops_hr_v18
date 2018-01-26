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

    public partial class T_LeaveProfileReasonController : BaseController
    {
        // GET: /T_LeaveProfileReason/
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
			var lstT_LeaveProfileReason = from s in db.T_LeaveProfileReasons
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_LeaveProfileReason = searchRecords(lstT_LeaveProfileReason, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_LeaveProfileReason = sortRecords(lstT_LeaveProfileReason, sortBy, isAsc);
            }
            else lstT_LeaveProfileReason = lstT_LeaveProfileReason.OrderByDescending(c => c.Id);
			lstT_LeaveProfileReason = CustomSorting(lstT_LeaveProfileReason);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_LeaveProfileReason"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_LeaveProfileReason"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_LeaveProfileReason"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_LeaveProfileReason"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_LeaveProfileReason = lstT_LeaveProfileReason.Include(t=>t.t_leavereason).Include(t=>t.t_leaveprofile);
		 if (HostingEntity == "T_LeaveReason" && AssociatedType == "T_LeaveProfileReason_T_LeaveReason")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_LeaveProfileReason = _T_LeaveProfileReason.Where(p => p.T_LeaveReasonID == hostid);
			 }
			 else
			     _T_LeaveProfileReason = _T_LeaveProfileReason.Where(p => p.T_LeaveReasonID == null);
         }
		 if (HostingEntity == "T_LeaveProfile" && AssociatedType == "T_LeaveProfileReason_T_LeaveProfile")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_LeaveProfileReason = _T_LeaveProfileReason.Where(p => p.T_LeaveProfileID == hostid);
			 }
			 else
			     _T_LeaveProfileReason = _T_LeaveProfileReason.Where(p => p.T_LeaveProfileID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_LeaveProfileReason", User) || !User.CanView("T_LeaveProfileReason"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_LeaveProfileReason.Count() > 0)
                    pageSize = _T_LeaveProfileReason.Count();
                return View("ExcelExport", _T_LeaveProfileReason.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_LeaveProfileReason.Count();
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
				var list = _T_LeaveProfileReason.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_LeaveProfileReasonDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_LeaveProfileReasonlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_LeaveProfileReason = _fad.FilterDropdown<T_LeaveProfileReason>(User,  _T_LeaveProfileReason, "T_LeaveProfileReason", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_LeaveProfileReason.Except(_T_LeaveProfileReason),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_LeaveProfileReason.Except(_T_LeaveProfileReason).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_LeaveProfileReason.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_LeaveProfileReason.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_LeaveProfileReason.Count() == 0 ? 1 : _T_LeaveProfileReason.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_LeaveProfileReason.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_LeaveProfileReasonDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_LeaveProfileReasonlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_LeaveProfileReason.Count() == 0 ? 1 : _T_LeaveProfileReason.Count();
                            }
							var list = _T_LeaveProfileReason.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_LeaveProfileReasonDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_LeaveProfileReasonlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_LeaveProfileReason/Details/5
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
            T_LeaveProfileReason t_leaveprofilereason = db.T_LeaveProfileReasons.Find(id);
            if (t_leaveprofilereason == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_leaveprofilereason);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_leaveprofilereason, AssociatedType);
            ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnDetails", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnDetails", true);
			ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnDetails");
			return View(ViewBag.TemplatesName,t_leaveprofilereason);
        }
        // GET: /T_LeaveProfileReason/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_LeaveProfileReason") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_LeaveProfileReasonParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", true);
		  ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnCreate");
          return View();
        }
		// GET: /T_LeaveProfileReason/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_LeaveProfileReason") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_LeaveProfileReasonParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", true);
			 ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnCreate");
            return View();
        }
		// POST: /T_LeaveProfileReason/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_LeaveReasonID,T_LeaveProfileID")] T_LeaveProfileReason t_leaveprofilereason, string UrlReferrer)
        {
			CheckBeforeSave(t_leaveprofilereason);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_leaveprofilereason,out customcreate_hasissues,"Create"))
                {
                    db.T_LeaveProfileReasons.Add(t_leaveprofilereason);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_leaveprofilereason,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_leaveprofilereason);
			ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", true);
			ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnCreate");	
            return View(t_leaveprofilereason);
        }
		 // GET: /T_LeaveProfileReason/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_LeaveProfileReason") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_LeaveProfileReasonParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", true);
			ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnCreate");
            return View();
        }
		  // POST: /T_LeaveProfileReason/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_LeaveReasonID,T_LeaveProfileID")] T_LeaveProfileReason t_leaveprofilereason, List<string> T_LeaveReasonIDSelected, List<string> T_LeaveReasonIDAvailable, List<string> T_LeaveProfileIDSelected, List<string> T_LeaveProfileIDAvailable,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_leaveprofilereason);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
					if(T_LeaveReasonIDSelected != null || T_LeaveReasonIDAvailable != null)
				{
				    t_leaveprofilereason.t_leaveprofile = db.T_LeaveProfiles.FirstOrDefault(p => p.Id == t_leaveprofilereason.T_LeaveProfileID);
					var T_LeaveReasonIDSelectedlong =T_LeaveReasonIDSelected !=null ? T_LeaveReasonIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_LeaveProfileReasons.Where(p => p.T_LeaveProfileID == t_leaveprofilereason.T_LeaveProfileID && !T_LeaveReasonIDSelectedlong.Contains(p.T_LeaveReasonID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_leaveprofile !=null )
					    db.Entry(item.t_leaveprofile).State = EntityState.Unchanged;
						if(item.t_leavereason !=null )
                        db.Entry(item.t_leavereason).State = EntityState.Unchanged;
                        db.T_LeaveProfileReasons.Remove(item);
                        db.SaveChanges();
                    }
					if(T_LeaveReasonIDSelected != null)
					{
					var T_LeaveReasonIDSelectedLong = T_LeaveReasonIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofilereason.T_LeaveProfileID && T_LeaveReasonIDSelectedLong.Contains(a.T_LeaveReasonID.Value)).Select(p => p.T_LeaveReasonID.Value).ToList();
                    T_LeaveReasonIDSelectedLong = T_LeaveReasonIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_LeaveReasonIDSelectedLong != null)
                        foreach (var longid in T_LeaveReasonIDSelectedLong)
						{
                            {
								var obj = new T_LeaveProfileReason(); 
								obj = t_leaveprofilereason;
								obj.T_LeaveReasonID = longid;//Convert.ToInt64(id);
								db.Entry(obj).State = EntityState.Added;
								//obj.t_leavereason = db.T_LeaveReasons.FirstOrDefault(p => p.Id == t_leaveprofilereason.T_LeaveReasonID);
								if(obj.t_leaveprofile !=null )
									db.Entry(obj.t_leaveprofile).State = EntityState.Unchanged;
								if(obj.t_leavereason !=null )
									db.Entry(obj.t_leavereason).State = EntityState.Unchanged;
								//
								//
								db.T_LeaveProfileReasons.Add(obj); db.SaveChanges();
							}
						}
					}
				}
				if(T_LeaveProfileIDSelected != null || T_LeaveProfileIDAvailable != null)
				{
				    t_leaveprofilereason.t_leavereason = db.T_LeaveReasons.FirstOrDefault(p => p.Id == t_leaveprofilereason.T_LeaveReasonID);
					var T_LeaveProfileIDSelectedlong =T_LeaveProfileIDSelected !=null ? T_LeaveProfileIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_LeaveProfileReasons.Where(p => p.T_LeaveReasonID == t_leaveprofilereason.T_LeaveReasonID && !T_LeaveProfileIDSelectedlong.Contains(p.T_LeaveProfileID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_leavereason !=null )
					    db.Entry(item.t_leavereason).State = EntityState.Unchanged;
						if(item.t_leaveprofile !=null )
                        db.Entry(item.t_leaveprofile).State = EntityState.Unchanged;
                        db.T_LeaveProfileReasons.Remove(item);
                        db.SaveChanges();
                    }
					if(T_LeaveProfileIDSelected != null)
					{
					var T_LeaveProfileIDSelectedLong = T_LeaveProfileIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_LeaveProfileReasons.Where(a => a.T_LeaveReasonID == t_leaveprofilereason.T_LeaveReasonID && T_LeaveProfileIDSelectedLong.Contains(a.T_LeaveProfileID.Value)).Select(p => p.T_LeaveProfileID.Value).ToList();
                    T_LeaveProfileIDSelectedLong = T_LeaveProfileIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_LeaveProfileIDSelectedLong != null)
                        foreach (var longid in T_LeaveProfileIDSelectedLong)
						{
                            {
								var obj = new T_LeaveProfileReason(); 
								obj = t_leaveprofilereason;
								obj.T_LeaveProfileID = longid;//Convert.ToInt64(id);
								db.Entry(obj).State = EntityState.Added;
								//obj.t_leaveprofile = db.T_LeaveProfiles.FirstOrDefault(p => p.Id == t_leaveprofilereason.T_LeaveProfileID);
								if(obj.t_leavereason !=null )
									db.Entry(obj.t_leavereason).State = EntityState.Unchanged;
								if(obj.t_leaveprofile !=null )
									db.Entry(obj.t_leaveprofile).State = EntityState.Unchanged;
								//
								//
								db.T_LeaveProfileReasons.Add(obj); db.SaveChanges();
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
			LoadViewDataAfterOnCreate(t_leaveprofilereason);
			ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", true);
			ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_leaveprofilereason, AssociatedEntity);
			return View(t_leaveprofilereason);
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
        // POST: /T_LeaveProfileReason/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_LeaveReasonID,T_LeaveProfileID")] T_LeaveProfileReason t_leaveprofilereason, List<string> T_LeaveReasonIDSelected, List<string> T_LeaveReasonIDAvailable, List<string> T_LeaveProfileIDSelected, List<string> T_LeaveProfileIDAvailable, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_leaveprofilereason, command);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
				if(T_LeaveReasonIDSelected != null || T_LeaveReasonIDAvailable != null)
				{
					t_leaveprofilereason.t_leaveprofile = db.T_LeaveProfiles.FirstOrDefault(p => p.Id == t_leaveprofilereason.T_LeaveProfileID);
					var T_LeaveReasonIDSelectedlong =T_LeaveReasonIDSelected !=null ? T_LeaveReasonIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_LeaveProfileReasons.Where(p => p.T_LeaveProfileID == t_leaveprofilereason.T_LeaveProfileID && !T_LeaveReasonIDSelectedlong.Contains(p.T_LeaveReasonID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_leaveprofile !=null )
						db.Entry(item.t_leaveprofile).State = EntityState.Unchanged;
					if(item.t_leavereason !=null )
                        db.Entry(item.t_leavereason).State = EntityState.Unchanged;
						db.Entry(item).State = EntityState.Deleted;
                        db.T_LeaveProfileReasons.Remove(item);
                        db.SaveChanges();
                    }
					if(T_LeaveReasonIDSelected != null)
					{
					var T_LeaveReasonIDSelectedLong = T_LeaveReasonIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_LeaveProfileReasons.Where(a => a.T_LeaveProfileID == t_leaveprofilereason.T_LeaveProfileID && T_LeaveReasonIDSelectedLong.Contains(a.T_LeaveReasonID.Value)).Select(p => p.T_LeaveReasonID.Value).ToList();
                    T_LeaveReasonIDSelectedLong = T_LeaveReasonIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_LeaveReasonIDSelectedLong != null)
                        foreach (var longid in T_LeaveReasonIDSelectedLong)
						{
                            {
								var obj = new T_LeaveProfileReason(); 
								obj = t_leaveprofilereason;
								obj.T_LeaveReasonID = longid;
								db.Entry(obj).State = EntityState.Added;
								 //obj.t_leavereason = db.T_LeaveReasons.FirstOrDefault(p => p.Id == t_leaveprofilereason.T_LeaveReasonID);
								 if(obj.t_leaveprofile !=null )
									db.Entry(obj.t_leaveprofile).State = EntityState.Unchanged;
								if(obj.t_leavereason !=null )
									 db.Entry(obj.t_leavereason).State = EntityState.Unchanged;
								//
								//
							 db.T_LeaveProfileReasons.Add(obj); db.SaveChanges();
							}
						}
				}
			}
				if(T_LeaveProfileIDSelected != null || T_LeaveProfileIDAvailable != null)
				{
					t_leaveprofilereason.t_leavereason = db.T_LeaveReasons.FirstOrDefault(p => p.Id == t_leaveprofilereason.T_LeaveReasonID);
					var T_LeaveProfileIDSelectedlong =T_LeaveProfileIDSelected !=null ? T_LeaveProfileIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_LeaveProfileReasons.Where(p => p.T_LeaveReasonID == t_leaveprofilereason.T_LeaveReasonID && !T_LeaveProfileIDSelectedlong.Contains(p.T_LeaveProfileID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_leavereason !=null )
						db.Entry(item.t_leavereason).State = EntityState.Unchanged;
					if(item.t_leaveprofile !=null )
                        db.Entry(item.t_leaveprofile).State = EntityState.Unchanged;
						db.Entry(item).State = EntityState.Deleted;
                        db.T_LeaveProfileReasons.Remove(item);
                        db.SaveChanges();
                    }
					if(T_LeaveProfileIDSelected != null)
					{
					var T_LeaveProfileIDSelectedLong = T_LeaveProfileIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_LeaveProfileReasons.Where(a => a.T_LeaveReasonID == t_leaveprofilereason.T_LeaveReasonID && T_LeaveProfileIDSelectedLong.Contains(a.T_LeaveProfileID.Value)).Select(p => p.T_LeaveProfileID.Value).ToList();
                    T_LeaveProfileIDSelectedLong = T_LeaveProfileIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_LeaveProfileIDSelectedLong != null)
                        foreach (var longid in T_LeaveProfileIDSelectedLong)
						{
                            {
								var obj = new T_LeaveProfileReason(); 
								obj = t_leaveprofilereason;
								obj.T_LeaveProfileID = longid;
								db.Entry(obj).State = EntityState.Added;
								 //obj.t_leaveprofile = db.T_LeaveProfiles.FirstOrDefault(p => p.Id == t_leaveprofilereason.T_LeaveProfileID);
								 if(obj.t_leavereason !=null )
									db.Entry(obj.t_leavereason).State = EntityState.Unchanged;
								if(obj.t_leaveprofile !=null )
									 db.Entry(obj.t_leaveprofile).State = EntityState.Unchanged;
								//
								//
							 db.T_LeaveProfileReasons.Add(obj); db.SaveChanges();
							}
						}
				}
			}
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_leaveprofilereason,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_leaveprofilereason.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_leaveprofilereason);
			ViewData["T_LeaveProfileReasonParentUrl"] = UrlReferrer;
			ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnCreate", true);
			ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnCreate");
            return View(t_leaveprofilereason);
        }
		// GET: /T_LeaveProfileReason/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_LeaveProfileReason") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_LeaveProfileReason t_leaveprofilereason = db.T_LeaveProfileReasons.Find(id);
            if (t_leaveprofilereason == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_LeaveProfileReasonParentUrl"] = UrlReferrer;
		if(ViewData["T_LeaveProfileReasonParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfileReason")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfileReason/Edit/" + t_leaveprofilereason.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfileReason/Create"))
			ViewData["T_LeaveProfileReasonParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_leaveprofilereason);
		   ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", true);
		   ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnEdit");
		    var objT_LeaveProfileReason = new List<T_LeaveProfileReason>();
            ViewBag.T_LeaveProfileReasonDD = new SelectList(objT_LeaveProfileReason, "ID", "DisplayValue"); 
          return View(t_leaveprofilereason);
        }
		// POST: /T_LeaveProfileReason/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_LeaveReasonID,T_LeaveProfileID")] T_LeaveProfileReason t_leaveprofilereason,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_leaveprofilereason, command);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_leaveprofilereason,out customsave_hasissues,command))
                {
					db.Entry(t_leaveprofilereason).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_leaveprofilereason);
			ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", true);
			ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnEdit");
            return View(t_leaveprofilereason);
        }
        // GET: /T_LeaveProfileReason/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_LeaveProfileReason") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_LeaveProfileReason t_leaveprofilereason = db.T_LeaveProfileReasons.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_LeaveProfileReasonlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_LeaveProfileReasons.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_LeaveProfileReasonDisplayValueEdit = TempData["T_LeaveProfileReasonlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_LeaveProfileReasonlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_LeaveProfileReasonDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_leaveprofilereason == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfileReason/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_leaveprofilereason.DisplayValue, Value = t_leaveprofilereason.Id.ToString() }));
                ViewBag.EntityT_LeaveProfileReasonDisplayValueEdit = newList;
				TempData["T_LeaveProfileReasonlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_leaveprofilereason.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_leaveprofilereason.DisplayValue;
                    newList[0].Value = t_leaveprofilereason.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_leaveprofilereason.DisplayValue, Value = t_leaveprofilereason.Id.ToString() }));
                }
                ViewBag.EntityT_LeaveProfileReasonDisplayValueEdit = newList;
				TempData["T_LeaveProfileReasonlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_LeaveProfileReasonParentUrl"] = UrlReferrer;
		if(ViewData["T_LeaveProfileReasonParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfileReason")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfileReason/Edit/" + t_leaveprofilereason.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfileReason/Create"))
			ViewData["T_LeaveProfileReasonParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_leaveprofilereason);
		   ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", true);
		   ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnEdit");
          return View(t_leaveprofilereason);
        }
        // POST: /T_LeaveProfileReason/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_LeaveReasonID,T_LeaveProfileID")] T_LeaveProfileReason t_leaveprofilereason,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_leaveprofilereason, command);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_leaveprofilereason,out customsave_hasissues,command))
            {
				db.Entry(t_leaveprofilereason).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_leaveprofilereason,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_leaveprofilereason.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_LeaveProfileReasonlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_LeaveProfileReasons.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_LeaveProfileReasonDisplayValueEdit = TempData["T_LeaveProfileReasonlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_LeaveProfileReasonlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_LeaveProfileReasonDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_leaveprofilereason);
			 ViewData["T_LeaveProfileReasonParentUrl"] = UrlReferrer;
			ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", true);
			ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnEdit");
            return View(t_leaveprofilereason);
        }
		// GET: /T_LeaveProfileReason/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_LeaveProfileReason") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_LeaveProfileReason t_leaveprofilereason = db.T_LeaveProfileReasons.Find(id);
            if (t_leaveprofilereason == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_LeaveProfileReasonParentUrl"] = UrlReferrer;
		if(ViewData["T_LeaveProfileReasonParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfileReason"))
			ViewData["T_LeaveProfileReasonParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_leaveprofilereason);
			 ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", true);
			 ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnEdit");
          return View(t_leaveprofilereason);
        }
        // POST: /T_LeaveProfileReason/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_LeaveReasonID,T_LeaveProfileID")] T_LeaveProfileReason t_leaveprofilereason,string UrlReferrer)
        {
			CheckBeforeSave(t_leaveprofilereason);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_leaveprofilereason,out customsave_hasissues,"Save"))
            {
				db.Entry(t_leaveprofilereason).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_leaveprofilereason,"Edit","");
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
			LoadViewDataAfterOnEdit(t_leaveprofilereason);
			ViewBag.T_LeaveProfileReasonIsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", false);
			ViewBag.T_LeaveProfileReasonIsGroupsHiddenRule = checkHidden("T_LeaveProfileReason", "OnEdit", true);
			ViewBag.T_LeaveProfileReasonIsSetValueUIRule = checkSetValueUIRule("T_LeaveProfileReason", "OnEdit");
            return View(t_leaveprofilereason);
        }
        // GET: /T_LeaveProfileReason/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_LeaveProfileReason") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_LeaveProfileReason t_leaveprofilereason = db.T_LeaveProfileReasons.Find(id);
            if (t_leaveprofilereason == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_LeaveProfileReasonParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LeaveProfileReason"))
			 ViewData["T_LeaveProfileReasonParentUrl"] = Request.UrlReferrer;
            return View(t_leaveprofilereason);
        }
        // POST: /T_LeaveProfileReason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_LeaveProfileReason t_leaveprofilereason, string UrlReferrer)
        {
			if (!User.CanDelete("T_LeaveProfileReason"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_leaveprofilereason))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_leaveprofilereason, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_leaveprofilereason).State = EntityState.Deleted;
            db.T_LeaveProfileReasons.Remove(t_leaveprofilereason);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_LeaveProfileReasonParentUrl"] != null)
					{
						string parentUrl = ViewData["T_LeaveProfileReasonParentUrl"].ToString();
						ViewData["T_LeaveProfileReasonParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_leaveprofilereason);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_LeaveProfileReason", User) || !User.CanDelete("T_LeaveProfileReason")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_LeaveProfileReason t_leaveprofilereason = db.T_LeaveProfileReasons.Find(id);
		if (CheckBeforeDelete(t_leaveprofilereason))
        {
            if (!CustomDelete(t_leaveprofilereason, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_leaveprofilereason).State = EntityState.Deleted;
                db.T_LeaveProfileReasons.Remove(t_leaveprofilereason);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_LeaveProfileReason", User) || !User.CanEdit("T_LeaveProfileReason") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_LeaveProfileReasonParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_LeaveReasonID,T_LeaveProfileID")] T_LeaveProfileReason t_leaveprofilereason,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_LeaveProfileReason target = db.T_LeaveProfileReasons.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_leaveprofilereason, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_leavereason != null)
							  db.Entry(target.t_leavereason).State = EntityState.Unchanged;
							if (target.t_leaveprofile != null)
							  db.Entry(target.t_leaveprofile).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_leaveprofilereason,"BulkUpdate","");
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
