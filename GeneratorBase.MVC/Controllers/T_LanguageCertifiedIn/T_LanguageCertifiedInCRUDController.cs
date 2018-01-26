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

    public partial class T_LanguageCertifiedInController : BaseController
    {
        // GET: /T_LanguageCertifiedIn/
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
			var lstT_LanguageCertifiedIn = from s in db.T_LanguageCertifiedIns
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_LanguageCertifiedIn = searchRecords(lstT_LanguageCertifiedIn, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_LanguageCertifiedIn = sortRecords(lstT_LanguageCertifiedIn, sortBy, isAsc);
            }
            else lstT_LanguageCertifiedIn = lstT_LanguageCertifiedIn.OrderByDescending(c => c.Id);
			lstT_LanguageCertifiedIn = CustomSorting(lstT_LanguageCertifiedIn);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_LanguageCertifiedIn"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "T_LanguageCertifiedIn"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_LanguageCertifiedIn"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "T_LanguageCertifiedIn"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _T_LanguageCertifiedIn = lstT_LanguageCertifiedIn.Include(t=>t.t_employee).Include(t=>t.t_langauge);
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_LanguageCertifiedIn_T_Employee")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_LanguageCertifiedIn = _T_LanguageCertifiedIn.Where(p => p.T_EmployeeID == hostid);
			 }
			 else
			     _T_LanguageCertifiedIn = _T_LanguageCertifiedIn.Where(p => p.T_EmployeeID == null);
         }
		 if (HostingEntity == "T_Langauge" && AssociatedType == "T_LanguageCertifiedIn_T_Langauge")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _T_LanguageCertifiedIn = _T_LanguageCertifiedIn.Where(p => p.T_LangaugeID == hostid);
			 }
			 else
			     _T_LanguageCertifiedIn = _T_LanguageCertifiedIn.Where(p => p.T_LangaugeID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "T_LanguageCertifiedIn", User) || !User.CanView("T_LanguageCertifiedIn"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_T_LanguageCertifiedIn.Count() > 0)
                    pageSize = _T_LanguageCertifiedIn.Count();
                return View("ExcelExport", _T_LanguageCertifiedIn.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_LanguageCertifiedIn.Count();
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
				var list = _T_LanguageCertifiedIn.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityT_LanguageCertifiedInDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["T_LanguageCertifiedInlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_T_LanguageCertifiedIn = _fad.FilterDropdown<T_LanguageCertifiedIn>(User,  _T_LanguageCertifiedIn, "T_LanguageCertifiedIn", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstT_LanguageCertifiedIn.Except(_T_LanguageCertifiedIn),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstT_LanguageCertifiedIn.Except(_T_LanguageCertifiedIn).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _T_LanguageCertifiedIn.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _T_LanguageCertifiedIn.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _T_LanguageCertifiedIn.Count() == 0 ? 1 : _T_LanguageCertifiedIn.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _T_LanguageCertifiedIn.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityT_LanguageCertifiedInDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_LanguageCertifiedInlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _T_LanguageCertifiedIn.Count() == 0 ? 1 : _T_LanguageCertifiedIn.Count();
                            }
							var list = _T_LanguageCertifiedIn.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityT_LanguageCertifiedInDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["T_LanguageCertifiedInlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /T_LanguageCertifiedIn/Details/5
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
            T_LanguageCertifiedIn t_languagecertifiedin = db.T_LanguageCertifiedIns.Find(id);
            if (t_languagecertifiedin == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(t_languagecertifiedin);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(t_languagecertifiedin, AssociatedType);
            ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnDetails", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnDetails", true);
			ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnDetails");
			return View(ViewBag.TemplatesName,t_languagecertifiedin);
        }
        // GET: /T_LanguageCertifiedIn/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("T_LanguageCertifiedIn") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["T_LanguageCertifiedInParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", true);
		  ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnCreate");
          return View();
        }
		// GET: /T_LanguageCertifiedIn/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("T_LanguageCertifiedIn") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["T_LanguageCertifiedInParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", true);
			 ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnCreate");
            return View();
        }
		// POST: /T_LanguageCertifiedIn/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeID,T_LangaugeID")] T_LanguageCertifiedIn t_languagecertifiedin, string UrlReferrer)
        {
			CheckBeforeSave(t_languagecertifiedin);
            if (ModelState.IsValid)
            {
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(t_languagecertifiedin,out customcreate_hasissues,"Create"))
                {
                    db.T_LanguageCertifiedIns.Add(t_languagecertifiedin);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_languagecertifiedin,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(t_languagecertifiedin);
			ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", true);
			ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnCreate");	
            return View(t_languagecertifiedin);
        }
		 // GET: /T_LanguageCertifiedIn/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("T_LanguageCertifiedIn") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["T_LanguageCertifiedInParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", true);
			ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnCreate");
            return View();
        }
		  // POST: /T_LanguageCertifiedIn/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeID,T_LangaugeID")] T_LanguageCertifiedIn t_languagecertifiedin, List<string> T_EmployeeIDSelected, List<string> T_EmployeeIDAvailable, List<string> T_LangaugeIDSelected, List<string> T_LangaugeIDAvailable,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(t_languagecertifiedin);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
					if(T_EmployeeIDSelected != null || T_EmployeeIDAvailable != null)
				{
				    t_languagecertifiedin.t_langauge = db.T_Langauges.FirstOrDefault(p => p.Id == t_languagecertifiedin.T_LangaugeID);
					var T_EmployeeIDSelectedlong =T_EmployeeIDSelected !=null ? T_EmployeeIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_LanguageCertifiedIns.Where(p => p.T_LangaugeID == t_languagecertifiedin.T_LangaugeID && !T_EmployeeIDSelectedlong.Contains(p.T_EmployeeID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_langauge !=null )
					    db.Entry(item.t_langauge).State = EntityState.Unchanged;
						if(item.t_employee !=null )
                        db.Entry(item.t_employee).State = EntityState.Unchanged;
                        db.T_LanguageCertifiedIns.Remove(item);
                        db.SaveChanges();
                    }
					if(T_EmployeeIDSelected != null)
					{
					var T_EmployeeIDSelectedLong = T_EmployeeIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_LanguageCertifiedIns.Where(a => a.T_LangaugeID == t_languagecertifiedin.T_LangaugeID && T_EmployeeIDSelectedLong.Contains(a.T_EmployeeID.Value)).Select(p => p.T_EmployeeID.Value).ToList();
                    T_EmployeeIDSelectedLong = T_EmployeeIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_EmployeeIDSelectedLong != null)
                        foreach (var longid in T_EmployeeIDSelectedLong)
						{
                            {
								var obj = new T_LanguageCertifiedIn(); 
								obj = t_languagecertifiedin;
								obj.T_EmployeeID = longid;//Convert.ToInt64(id);
								db.Entry(obj).State = EntityState.Added;
								//obj.t_employee = db.T_Employees.FirstOrDefault(p => p.Id == t_languagecertifiedin.T_EmployeeID);
								if(obj.t_langauge !=null )
									db.Entry(obj.t_langauge).State = EntityState.Unchanged;
								if(obj.t_employee !=null )
									db.Entry(obj.t_employee).State = EntityState.Unchanged;
								//
								//
								db.T_LanguageCertifiedIns.Add(obj); db.SaveChanges();
							}
						}
					}
				}
				if(T_LangaugeIDSelected != null || T_LangaugeIDAvailable != null)
				{
				    t_languagecertifiedin.t_employee = db.T_Employees.FirstOrDefault(p => p.Id == t_languagecertifiedin.T_EmployeeID);
					var T_LangaugeIDSelectedlong =T_LangaugeIDSelected !=null ? T_LangaugeIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_LanguageCertifiedIns.Where(p => p.T_EmployeeID == t_languagecertifiedin.T_EmployeeID && !T_LangaugeIDSelectedlong.Contains(p.T_LangaugeID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_employee !=null )
					    db.Entry(item.t_employee).State = EntityState.Unchanged;
						if(item.t_langauge !=null )
                        db.Entry(item.t_langauge).State = EntityState.Unchanged;
                        db.T_LanguageCertifiedIns.Remove(item);
                        db.SaveChanges();
                    }
					if(T_LangaugeIDSelected != null)
					{
					var T_LangaugeIDSelectedLong = T_LangaugeIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_languagecertifiedin.T_EmployeeID && T_LangaugeIDSelectedLong.Contains(a.T_LangaugeID.Value)).Select(p => p.T_LangaugeID.Value).ToList();
                    T_LangaugeIDSelectedLong = T_LangaugeIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_LangaugeIDSelectedLong != null)
                        foreach (var longid in T_LangaugeIDSelectedLong)
						{
                            {
								var obj = new T_LanguageCertifiedIn(); 
								obj = t_languagecertifiedin;
								obj.T_LangaugeID = longid;//Convert.ToInt64(id);
								db.Entry(obj).State = EntityState.Added;
								//obj.t_langauge = db.T_Langauges.FirstOrDefault(p => p.Id == t_languagecertifiedin.T_LangaugeID);
								if(obj.t_employee !=null )
									db.Entry(obj.t_employee).State = EntityState.Unchanged;
								if(obj.t_langauge !=null )
									db.Entry(obj.t_langauge).State = EntityState.Unchanged;
								//
								//
								db.T_LanguageCertifiedIns.Add(obj); db.SaveChanges();
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
			LoadViewDataAfterOnCreate(t_languagecertifiedin);
			ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", true);
			ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(t_languagecertifiedin, AssociatedEntity);
			return View(t_languagecertifiedin);
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
        // POST: /T_LanguageCertifiedIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,T_EmployeeID,T_LangaugeID")] T_LanguageCertifiedIn t_languagecertifiedin, List<string> T_EmployeeIDSelected, List<string> T_EmployeeIDAvailable, List<string> T_LangaugeIDSelected, List<string> T_LangaugeIDAvailable, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_languagecertifiedin, command);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
				if(T_EmployeeIDSelected != null || T_EmployeeIDAvailable != null)
				{
					t_languagecertifiedin.t_langauge = db.T_Langauges.FirstOrDefault(p => p.Id == t_languagecertifiedin.T_LangaugeID);
					var T_EmployeeIDSelectedlong =T_EmployeeIDSelected !=null ? T_EmployeeIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_LanguageCertifiedIns.Where(p => p.T_LangaugeID == t_languagecertifiedin.T_LangaugeID && !T_EmployeeIDSelectedlong.Contains(p.T_EmployeeID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_langauge !=null )
						db.Entry(item.t_langauge).State = EntityState.Unchanged;
					if(item.t_employee !=null )
                        db.Entry(item.t_employee).State = EntityState.Unchanged;
						db.Entry(item).State = EntityState.Deleted;
                        db.T_LanguageCertifiedIns.Remove(item);
                        db.SaveChanges();
                    }
					if(T_EmployeeIDSelected != null)
					{
					var T_EmployeeIDSelectedLong = T_EmployeeIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_LanguageCertifiedIns.Where(a => a.T_LangaugeID == t_languagecertifiedin.T_LangaugeID && T_EmployeeIDSelectedLong.Contains(a.T_EmployeeID.Value)).Select(p => p.T_EmployeeID.Value).ToList();
                    T_EmployeeIDSelectedLong = T_EmployeeIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_EmployeeIDSelectedLong != null)
                        foreach (var longid in T_EmployeeIDSelectedLong)
						{
                            {
								var obj = new T_LanguageCertifiedIn(); 
								obj = t_languagecertifiedin;
								obj.T_EmployeeID = longid;
								db.Entry(obj).State = EntityState.Added;
								 //obj.t_employee = db.T_Employees.FirstOrDefault(p => p.Id == t_languagecertifiedin.T_EmployeeID);
								 if(obj.t_langauge !=null )
									db.Entry(obj.t_langauge).State = EntityState.Unchanged;
								if(obj.t_employee !=null )
									 db.Entry(obj.t_employee).State = EntityState.Unchanged;
								//
								//
							 db.T_LanguageCertifiedIns.Add(obj); db.SaveChanges();
							}
						}
				}
			}
				if(T_LangaugeIDSelected != null || T_LangaugeIDAvailable != null)
				{
					t_languagecertifiedin.t_employee = db.T_Employees.FirstOrDefault(p => p.Id == t_languagecertifiedin.T_EmployeeID);
					var T_LangaugeIDSelectedlong =T_LangaugeIDSelected !=null ? T_LangaugeIDSelected.Select(long.Parse).ToList():new List<long>();
					var deletedItems = db.T_LanguageCertifiedIns.Where(p => p.T_EmployeeID == t_languagecertifiedin.T_EmployeeID && !T_LangaugeIDSelectedlong.Contains(p.T_LangaugeID.Value)).ToList();
                    foreach (var item in deletedItems)
                    {
					if(item.t_employee !=null )
						db.Entry(item.t_employee).State = EntityState.Unchanged;
					if(item.t_langauge !=null )
                        db.Entry(item.t_langauge).State = EntityState.Unchanged;
						db.Entry(item).State = EntityState.Deleted;
                        db.T_LanguageCertifiedIns.Remove(item);
                        db.SaveChanges();
                    }
					if(T_LangaugeIDSelected != null)
					{
					var T_LangaugeIDSelectedLong = T_LangaugeIDSelected.Select(Int64.Parse).ToList();
					var alreadyregistered = db.T_LanguageCertifiedIns.Where(a => a.T_EmployeeID == t_languagecertifiedin.T_EmployeeID && T_LangaugeIDSelectedLong.Contains(a.T_LangaugeID.Value)).Select(p => p.T_LangaugeID.Value).ToList();
                    T_LangaugeIDSelectedLong = T_LangaugeIDSelectedLong.Except(alreadyregistered).ToList();
					if (T_LangaugeIDSelectedLong != null)
                        foreach (var longid in T_LangaugeIDSelectedLong)
						{
                            {
								var obj = new T_LanguageCertifiedIn(); 
								obj = t_languagecertifiedin;
								obj.T_LangaugeID = longid;
								db.Entry(obj).State = EntityState.Added;
								 //obj.t_langauge = db.T_Langauges.FirstOrDefault(p => p.Id == t_languagecertifiedin.T_LangaugeID);
								 if(obj.t_employee !=null )
									db.Entry(obj.t_employee).State = EntityState.Unchanged;
								if(obj.t_langauge !=null )
									 db.Entry(obj.t_langauge).State = EntityState.Unchanged;
								//
								//
							 db.T_LanguageCertifiedIns.Add(obj); db.SaveChanges();
							}
						}
				}
			}
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_languagecertifiedin,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = t_languagecertifiedin.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(t_languagecertifiedin);
			ViewData["T_LanguageCertifiedInParentUrl"] = UrlReferrer;
			ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnCreate", true);
			ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnCreate");
            return View(t_languagecertifiedin);
        }
		// GET: /T_LanguageCertifiedIn/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_LanguageCertifiedIn") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            T_LanguageCertifiedIn t_languagecertifiedin = db.T_LanguageCertifiedIns.Find(id);
            if (t_languagecertifiedin == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["T_LanguageCertifiedInParentUrl"] = UrlReferrer;
		if(ViewData["T_LanguageCertifiedInParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LanguageCertifiedIn")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LanguageCertifiedIn/Edit/" + t_languagecertifiedin.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LanguageCertifiedIn/Create"))
			ViewData["T_LanguageCertifiedInParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_languagecertifiedin);
		   ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", true);
		   ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnEdit");
		    var objT_LanguageCertifiedIn = new List<T_LanguageCertifiedIn>();
            ViewBag.T_LanguageCertifiedInDD = new SelectList(objT_LanguageCertifiedIn, "ID", "DisplayValue"); 
          return View(t_languagecertifiedin);
        }
		// POST: /T_LanguageCertifiedIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,T_EmployeeID,T_LangaugeID")] T_LanguageCertifiedIn t_languagecertifiedin,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_languagecertifiedin, command);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(t_languagecertifiedin,out customsave_hasissues,command))
                {
					db.Entry(t_languagecertifiedin).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(t_languagecertifiedin);
			ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", true);
			ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnEdit");
            return View(t_languagecertifiedin);
        }
        // GET: /T_LanguageCertifiedIn/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("T_LanguageCertifiedIn") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_LanguageCertifiedIn t_languagecertifiedin = db.T_LanguageCertifiedIns.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["T_LanguageCertifiedInlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_LanguageCertifiedIns.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_LanguageCertifiedInDisplayValueEdit = TempData["T_LanguageCertifiedInlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_LanguageCertifiedInlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityT_LanguageCertifiedInDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (t_languagecertifiedin == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/T_LanguageCertifiedIn/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = t_languagecertifiedin.DisplayValue, Value = t_languagecertifiedin.Id.ToString() }));
                ViewBag.EntityT_LanguageCertifiedInDisplayValueEdit = newList;
				TempData["T_LanguageCertifiedInlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(t_languagecertifiedin.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = t_languagecertifiedin.DisplayValue;
                    newList[0].Value = t_languagecertifiedin.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = t_languagecertifiedin.DisplayValue, Value = t_languagecertifiedin.Id.ToString() }));
                }
                ViewBag.EntityT_LanguageCertifiedInDisplayValueEdit = newList;
				TempData["T_LanguageCertifiedInlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["T_LanguageCertifiedInParentUrl"] = UrlReferrer;
		if(ViewData["T_LanguageCertifiedInParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LanguageCertifiedIn")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LanguageCertifiedIn/Edit/" + t_languagecertifiedin.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/T_LanguageCertifiedIn/Create"))
			ViewData["T_LanguageCertifiedInParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(t_languagecertifiedin);
		   ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", true);
		   ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnEdit");
          return View(t_languagecertifiedin);
        }
        // POST: /T_LanguageCertifiedIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,T_EmployeeID,T_LangaugeID")] T_LanguageCertifiedIn t_languagecertifiedin,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(t_languagecertifiedin, command);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_languagecertifiedin,out customsave_hasissues,command))
            {
				db.Entry(t_languagecertifiedin).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_languagecertifiedin,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = t_languagecertifiedin.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["T_LanguageCertifiedInlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.T_LanguageCertifiedIns.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityT_LanguageCertifiedInDisplayValueEdit = TempData["T_LanguageCertifiedInlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["T_LanguageCertifiedInlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityT_LanguageCertifiedInDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(t_languagecertifiedin);
			 ViewData["T_LanguageCertifiedInParentUrl"] = UrlReferrer;
			ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", true);
			ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnEdit");
            return View(t_languagecertifiedin);
        }
		// GET: /T_LanguageCertifiedIn/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("T_LanguageCertifiedIn") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            T_LanguageCertifiedIn t_languagecertifiedin = db.T_LanguageCertifiedIns.Find(id);
            if (t_languagecertifiedin == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["T_LanguageCertifiedInParentUrl"] = UrlReferrer;
		if(ViewData["T_LanguageCertifiedInParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LanguageCertifiedIn"))
			ViewData["T_LanguageCertifiedInParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(t_languagecertifiedin);
			 ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", true);
			 ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnEdit");
          return View(t_languagecertifiedin);
        }
        // POST: /T_LanguageCertifiedIn/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,T_EmployeeID,T_LangaugeID")] T_LanguageCertifiedIn t_languagecertifiedin,string UrlReferrer)
        {
			CheckBeforeSave(t_languagecertifiedin);
            if (ModelState.IsValid)
            {
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(t_languagecertifiedin,out customsave_hasissues,"Save"))
            {
				db.Entry(t_languagecertifiedin).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_languagecertifiedin,"Edit","");
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
			LoadViewDataAfterOnEdit(t_languagecertifiedin);
			ViewBag.T_LanguageCertifiedInIsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", false);
			ViewBag.T_LanguageCertifiedInIsGroupsHiddenRule = checkHidden("T_LanguageCertifiedIn", "OnEdit", true);
			ViewBag.T_LanguageCertifiedInIsSetValueUIRule = checkSetValueUIRule("T_LanguageCertifiedIn", "OnEdit");
            return View(t_languagecertifiedin);
        }
        // GET: /T_LanguageCertifiedIn/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("T_LanguageCertifiedIn") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            T_LanguageCertifiedIn t_languagecertifiedin = db.T_LanguageCertifiedIns.Find(id);
            if (t_languagecertifiedin == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["T_LanguageCertifiedInParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/T_LanguageCertifiedIn"))
			 ViewData["T_LanguageCertifiedInParentUrl"] = Request.UrlReferrer;
            return View(t_languagecertifiedin);
        }
        // POST: /T_LanguageCertifiedIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(T_LanguageCertifiedIn t_languagecertifiedin, string UrlReferrer)
        {
			if (!User.CanDelete("T_LanguageCertifiedIn"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(t_languagecertifiedin))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(t_languagecertifiedin, out customdelete_hasissues, "Delete"))
                {
			db.Entry(t_languagecertifiedin).State = EntityState.Deleted;
            db.T_LanguageCertifiedIns.Remove(t_languagecertifiedin);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["T_LanguageCertifiedInParentUrl"] != null)
					{
						string parentUrl = ViewData["T_LanguageCertifiedInParentUrl"].ToString();
						ViewData["T_LanguageCertifiedInParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(t_languagecertifiedin);
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
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "T_LanguageCertifiedIn", User) || !User.CanDelete("T_LanguageCertifiedIn")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            T_LanguageCertifiedIn t_languagecertifiedin = db.T_LanguageCertifiedIns.Find(id);
		if (CheckBeforeDelete(t_languagecertifiedin))
        {
            if (!CustomDelete(t_languagecertifiedin, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(t_languagecertifiedin).State = EntityState.Deleted;
                db.T_LanguageCertifiedIns.Remove(t_languagecertifiedin);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "T_LanguageCertifiedIn", User) || !User.CanEdit("T_LanguageCertifiedIn") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["T_LanguageCertifiedInParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,T_EmployeeID,T_LangaugeID")] T_LanguageCertifiedIn t_languagecertifiedin,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                T_LanguageCertifiedIn target = db.T_LanguageCertifiedIns.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(t_languagecertifiedin, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_employee != null)
							  db.Entry(target.t_employee).State = EntityState.Unchanged;
							if (target.t_langauge != null)
							  db.Entry(target.t_langauge).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(t_languagecertifiedin,"BulkUpdate","");
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
