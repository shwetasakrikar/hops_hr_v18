﻿using System;
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
    public partial class FileDocumentController : BaseController
    {
        // GET: /FileDocument/
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
			var lstFileDocument = from s in db.FileDocuments
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstFileDocument = searchRecords(lstFileDocument, searchString.ToUpper(), IsDeepSearch);
            }
	   if (parent != null && parent == "Home")
            {
                ViewBag.Homeval = searchString;
            }
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstFileDocument = sortRecords(lstFileDocument, sortBy, isAsc);
            }
            else lstFileDocument = lstFileDocument.OrderByDescending(c => c.Id);
			lstFileDocument = CustomSorting(lstFileDocument);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
			ViewBag.Pages = page;
			if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
			 //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "FileDocument"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name)  + "FileDocument"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
			//Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "FileDocument"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "FileDocument"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
			 ViewBag.PageSize = pageSize;
			var _FileDocument = lstFileDocument.Include(t=>t.t_employeedocuments);
		 if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeDocuments")
         {
			 if (HostingEntityID != null)
             {
                long hostid = Convert.ToInt64(HostingEntityID);
                _FileDocument = _FileDocument.Where(p => p.T_EmployeeDocumentsID == hostid);
			 }
			 else
			     _FileDocument = _FileDocument.Where(p => p.T_EmployeeDocumentsID == null);
         }
	
			if (Convert.ToBoolean(IsExport))
            {
				if (!((CustomPrincipal)User).CanUseVerb("ExportExcel", "FileDocument", User) || !User.CanView("FileDocument"))
                {
                    return RedirectToAction("Index", "Error");
                }
                pageNumber = 1;
                if (_FileDocument.Count() > 0)
                    pageSize = _FileDocument.Count();
                return View("ExcelExport", _FileDocument.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _FileDocument.Count();
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
				var list = _FileDocument.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityFileDocumentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["FileDocumentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
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
							_FileDocument = _fad.FilterDropdown<FileDocument>(User,  _FileDocument, "FileDocument", caller);
						}
						if (Convert.ToBoolean(BulkAssociate))
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation",sortRecords(lstFileDocument.Except(_FileDocument),sortBy,isAsc).ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", lstFileDocument.Except(_FileDocument).OrderBy(q => q.DisplayValue).ToPagedList(pageNumber, pageSize));
						}
						else
						{
							if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
								return PartialView("BulkOperation", _FileDocument.ToPagedList(pageNumber, pageSize));
							else
								return PartialView("BulkOperation", _FileDocument.OrderBy(q=>q.DisplayValue).ToPagedList(pageNumber, pageSize)); 
						}
					}
					else
					{
					  if (ViewBag.TemplatesName == null)
					  {
						    if (!string.IsNullOrEmpty(isMobileHome))
                            {
								 pageSize = _FileDocument.Count() == 0 ? 1 : _FileDocument.Count();
                            }
							ViewData["HomePartialList"] = IsHomeList;
							var list = _FileDocument.ToPagedList(pageNumber, Convert.ToBoolean(IsHomeList) ? 5 : pageSize);
							ViewBag.EntityFileDocumentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["FileDocumentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(Convert.ToBoolean(IsHomeList) ? "HomePartialList" : "IndexPartial", list);
					  }
					  else
					  {
							if (!string.IsNullOrEmpty(isMobileHome))
                            {
                                pageSize = _FileDocument.Count() == 0 ? 1 : _FileDocument.Count();
                            }
							var list = _FileDocument.ToPagedList(pageNumber, pageSize);
							ViewBag.EntityFileDocumentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
							TempData["FileDocumentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
							return PartialView(ViewBag.TemplatesName, list);
					  }
					}
				}
        }
		 // GET: /FileDocument/Details/5
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
            FileDocument filedocument = db.FileDocuments.Find(id);
            if (filedocument == null)
            {
                return HttpNotFound();
            }
			if (string.IsNullOrEmpty(defaultview))
                defaultview = "Details";
            GetTemplatesForDetails(defaultview);
			ViewData["AssociatedType"] = AssociatedType;
		    ViewData["HostingEntityName"] = HostingEntityName;
			LoadViewDataBeforeOnEdit(filedocument);	
			if (!string.IsNullOrEmpty(AssociatedType))
                    LoadViewDataForCount(filedocument, AssociatedType);
            ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnDetails", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnDetails", true);
			ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnDetails");
			return View(ViewBag.TemplatesName,filedocument);
        }
        // GET: /FileDocument/Create
        public ActionResult Create(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd, string viewtype )
        {
            if (!User.CanAdd("FileDocument") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
		  if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		   if (string.IsNullOrEmpty(viewtype))
                viewtype = "Create";
            GetTemplatesForCreate(viewtype);
		  ViewData["FileDocumentParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		  ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnCreate", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnCreate", true);
		  ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnCreate");
          return View();
        }
		// GET: /FileDocument/CreateWizard
        public ActionResult CreateWizard(string UrlReferrer,string HostingEntityName, string HostingEntityID,string AssociatedType, string viewtype)
        {
            if (!User.CanAdd("FileDocument") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
	
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateWizard";
            GetTemplatesForCreateWizard(viewtype);
		    ViewData["FileDocumentParentUrl"] = UrlReferrer;
			LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
			 ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnCreate", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnCreate", true);
			 ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnCreate");
            return View();
        }
		// POST: /FileDocument/CreateWizard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include="Id,ConcurrencyKey,DocumentName,Description,AttachDocument,DateCreated,DateLastUpdated,T_EmployeeDocumentsID")] FileDocument filedocument, HttpPostedFileBase AttachDocument, string UrlReferrer)
        {
			CheckBeforeSave(filedocument);
		if (AttachDocument != null || (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"] != ""))
                IsFileTypeAndSizeAllowed(AttachDocument);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
	                if (AttachDocument != null)
                { 
									AttachDocument.SaveAs(path + ticks + System.IO.Path.GetFileName(AttachDocument.FileName.Trim().Replace(" ", "")));
                    filedocument.AttachDocument = ticks + System.IO.Path.GetFileName(AttachDocument.FileName.Trim().Replace(" ", ""));
                }
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(filedocument,out customcreate_hasissues,"Create"))
                {
                    db.FileDocuments.Add(filedocument);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
                {
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(filedocument,"Create","");
					if (customRedirectAction != null) return customRedirectAction;
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
			LoadViewDataAfterOnCreate(filedocument);
			ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnCreate", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnCreate", true);
			ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnCreate");	
            return View(filedocument);
        }
		 // GET: /FileDocument/CreateQuick
        public ActionResult CreateQuick(string UrlReferrer, string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsAddPop, string viewtype)
        {
            if (!User.CanAdd("FileDocument") || !CustomAuthorizationBeforeCreate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
			if (string.IsNullOrEmpty(viewtype))
                viewtype = "CreateQuick";
            GetTemplatesForCreateQuick(viewtype);
			 ViewBag.IsAddPop = IsAddPop;
		   ViewData["FileDocumentParentUrl"] = UrlReferrer;
		   ViewData["AssociatedType"] = AssociatedType;
           ViewData["HostingEntityName"] = HostingEntityName;
		   ViewData["HostingEntityID"] = HostingEntityID;
		   LoadViewDataBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
		    ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnCreate", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnCreate", true);
			ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnCreate");
            return View();
        }
		  // POST: /FileDocument/CreateQuick
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		        public ActionResult CreateQuick([Bind(Include="Id,ConcurrencyKey,DocumentName,Description,AttachDocument,DateCreated,DateLastUpdated,T_EmployeeDocumentsID")] FileDocument filedocument, HttpPostedFileBase AttachDocument , String CamerafileUploadAttachDocument,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity, string HostingEntityName, string HostingEntityID)
        {
			CheckBeforeSave(filedocument);
		if (AttachDocument != null || (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"] != ""))
                IsFileTypeAndSizeAllowed(AttachDocument);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
	                if (AttachDocument != null)
                { 
									AttachDocument.SaveAs(path  + System.IO.Path.GetFileName(AttachDocument.FileName.Trim().Replace(" ", "")));
                    filedocument.AttachDocument = System.IO.Path.GetFileName(AttachDocument.FileName.Trim().Replace(" ", ""));
			                }
				if (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"]  != "")
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(Convert.FromBase64String(Request.Form["CamerafileUploadAttachDocument"])));
                    image.Save(path + ticks + "Camera-" + ticks + "-" + User.Name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    filedocument.AttachDocument = ticks + "Camera-" + ticks + "-" + User.Name + ".jpg";
                }
				bool customcreate_hasissues = false;
				if (!CustomSaveOnCreate(filedocument,out customcreate_hasissues,"Create"))
                {
                    db.FileDocuments.Add(filedocument);
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
			LoadViewDataAfterOnCreate(filedocument);
			ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnCreate", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnCreate", true);
			ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnCreate");
            if (!string.IsNullOrEmpty(AssociatedEntity))
                    LoadViewDataForCount(filedocument, AssociatedEntity);
			return View(filedocument);
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
        // POST: /FileDocument/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ConcurrencyKey,DocumentName,Description,AttachDocument,DateCreated,DateLastUpdated,T_EmployeeDocumentsID")] FileDocument filedocument, HttpPostedFileBase AttachDocument , String CamerafileUploadAttachDocument, string UrlReferrer, bool? IsDDAdd)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(filedocument, command);
		if (AttachDocument != null || (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"] != ""))
                IsFileTypeAndSizeAllowed(AttachDocument);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
                if (AttachDocument != null)
                { 
					AttachDocument.SaveAs(path + ticks + System.IO.Path.GetFileName(AttachDocument.FileName.Trim().Replace(" ", "")));
                    filedocument.AttachDocument = ticks + System.IO.Path.GetFileName(AttachDocument.FileName.Trim().Replace(" ", ""));
                }
			    if (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"]  != "")
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(Convert.FromBase64String(Request.Form["CamerafileUploadAttachDocument"])));
                    image.Save(path + ticks + "Camera-" + ticks + "-" + User.Name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    filedocument.AttachDocument = ticks + "Camera-" + ticks + "-" + User.Name + ".jpg";
                }
				bool customcreate_hasissues = false;
                if (!CustomSaveOnCreate(filedocument,out customcreate_hasissues,command))
                {
                    db.FileDocuments.Add(filedocument);
					db.SaveChanges();
                }
				if (!customcreate_hasissues)
				{
					RedirectToRouteResult customRedirectAction = CustomRedirectUrl(filedocument,"Create",command);
					if (customRedirectAction != null) return customRedirectAction;
					 if (command == "Create & Continue")
						return RedirectToAction("Edit", new { Id = filedocument.Id, UrlReferrer = UrlReferrer });
					if(!string.IsNullOrEmpty(UrlReferrer))
					   return Redirect(UrlReferrer);
					else return RedirectToAction("Index");
				}
            }
	
		 if (IsDDAdd != null)
              ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		LoadViewDataAfterOnCreate(filedocument);
			ViewData["FileDocumentParentUrl"] = UrlReferrer;
			ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnCreate", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnCreate", true);
			ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnCreate");
            return View(filedocument);
        }
		// GET: /FileDocument/Edit/5
        public ActionResult EditQuick(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("FileDocument") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
            FileDocument filedocument = db.FileDocuments.Find(id);
            if (filedocument == null)
            {
                return HttpNotFound();
            }
		if (UrlReferrer != null)
                ViewData["FileDocumentParentUrl"] = UrlReferrer;
		if(ViewData["FileDocumentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/FileDocument")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/FileDocument/Edit/" + filedocument.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/FileDocument/Create"))
			ViewData["FileDocumentParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(filedocument);
		   ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnEdit", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnEdit", true);
		   ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnEdit");
		    var objFileDocument = new List<FileDocument>();
            ViewBag.FileDocumentDD = new SelectList(objFileDocument, "ID", "DisplayValue"); 
          return View(filedocument);
        }
		// POST: /FileDocument/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuick([Bind(Include="Id,ConcurrencyKey,DocumentName,Description,AttachDocument,DateCreated,DateLastUpdated,T_EmployeeDocumentsID")] FileDocument filedocument, HttpPostedFileBase File_AttachDocument , String CamerafileUploadAttachDocument,  string UrlReferrer, bool? IsAddPop, string AssociatedEntity)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(filedocument, command);
		if (File_AttachDocument != null || (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"] != ""))
                IsFileTypeAndSizeAllowed(File_AttachDocument);
			
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
                if (File_AttachDocument != null)
                { 
									File_AttachDocument.SaveAs(path  + System.IO.Path.GetFileName(File_AttachDocument.FileName.Trim().Replace(" ", "")));
                    filedocument.AttachDocument = System.IO.Path.GetFileName(File_AttachDocument.FileName.Trim().Replace(" ", ""));
			                }
				if (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"] != "")
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(Convert.FromBase64String(Request.Form["CamerafileUploadAttachDocument"] )));
                    image.Save(path + ticks + "Camera-" + ticks + "-" + User.Name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    filedocument.AttachDocument = ticks + "Camera-" + ticks + "-" + User.Name + ".jpg";
                }
				bool customsave_hasissues = false;
				if (!CustomSaveOnEdit(filedocument,out customsave_hasissues,command))
                {
					db.Entry(filedocument).State = EntityState.Modified;
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
			
			LoadViewDataAfterOnEdit(filedocument);
			ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnEdit", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnEdit", true);
			ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnEdit");
            return View(filedocument);
        }
        // GET: /FileDocument/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("FileDocument") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileDocument filedocument = db.FileDocuments.Find(id);
			 // NEXT-PREVIOUS DROP DOWN CODE
			TempData.Keep();
            string json = "";
            if (TempData["FileDocumentlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.FileDocuments.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityFileDocumentDisplayValueEdit = TempData["FileDocumentlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["FileDocumentlist"]);
            }

			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            ViewBag.EntityFileDocumentDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
            if (filedocument == null)
            {
                return HttpNotFound();
            }
		if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            GetTemplatesForEdit(defaultview);
			  // NEXT-PREVIOUS DROP DOWN CODE
			SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
             List<SelectListItem> newList = selitm.ToList();
			 if(Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/FileDocument/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = filedocument.DisplayValue, Value = filedocument.Id.ToString() }));
                ViewBag.EntityFileDocumentDisplayValueEdit = newList;
				TempData["FileDocumentlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			else if(!newList.Exists(p => p.Value == Convert.ToString(filedocument.Id)))
            {
                if (newList.Count > 0)
                {
                    newList[0].Text = filedocument.DisplayValue;
                    newList[0].Value = filedocument.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = filedocument.DisplayValue, Value = filedocument.Id.ToString() }));
                }
                ViewBag.EntityFileDocumentDisplayValueEdit = newList;
				TempData["FileDocumentlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text});
            }
			//
		if (UrlReferrer != null)
                ViewData["FileDocumentParentUrl"] = UrlReferrer;
		if(ViewData["FileDocumentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/FileDocument")  && !Request.UrlReferrer.AbsolutePath.EndsWith("/FileDocument/Edit/" + filedocument.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/FileDocument/Create"))
			ViewData["FileDocumentParentUrl"] = Request.UrlReferrer;
		 ViewData["HostingEntityName"] = HostingEntityName;
         ViewData["AssociatedType"] = AssociatedType;
		  LoadViewDataBeforeOnEdit(filedocument);
		   ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnEdit", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnEdit", true);
		   ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnEdit");
          return View(filedocument);
        }
        // POST: /FileDocument/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ConcurrencyKey,DocumentName,Description,AttachDocument,DateCreated,DateLastUpdated,T_EmployeeDocumentsID")] FileDocument filedocument, HttpPostedFileBase File_AttachDocument , String CamerafileUploadAttachDocument,  string UrlReferrer)
        {
			string command = Request.Form["hdncommand"];
			CheckBeforeSave(filedocument, command);
		if (File_AttachDocument != null || (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"] != ""))
                IsFileTypeAndSizeAllowed(File_AttachDocument);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
                if (File_AttachDocument != null)
                { 
									File_AttachDocument.SaveAs(path  + System.IO.Path.GetFileName(File_AttachDocument.FileName.Trim().Replace(" ", "")));
                    filedocument.AttachDocument =  System.IO.Path.GetFileName(File_AttachDocument.FileName.Trim().Replace(" ", ""));
			                }
				if (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"] != "")
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(Convert.FromBase64String(Request.Form["CamerafileUploadAttachDocument"] )));
                    image.Save(path + ticks + "Camera-" + ticks + "-" + User.Name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    filedocument.AttachDocument = ticks + "Camera-" + ticks + "-" + User.Name + ".jpg";
                }
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(filedocument,out customsave_hasissues,command))
            {
				db.Entry(filedocument).State = EntityState.Modified;
				db.SaveChanges();
            }
		 if (!customsave_hasissues)
		 {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(filedocument,"Edit",command);
				 if (customRedirectAction != null) return customRedirectAction;
				 if (command != "Save")
				 {
				   if (command == "SaveNextPrev")
                     {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                     }
                    else
                       return RedirectToAction("Edit", new { Id = filedocument.Id, UrlReferrer = UrlReferrer });
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
            if (TempData["FileDocumentlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.FileDocuments.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityFileDocumentDisplayValueEdit = TempData["FileDocumentlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["FileDocumentlist"]);
            }
            
			Newtonsoft.Json.JsonSerializerSettings serSettings = new    Newtonsoft.Json.JsonSerializerSettings();
            serSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json, serSettings);
            
            ViewBag.EntityFileDocumentDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
			//
			LoadViewDataAfterOnEdit(filedocument);
			 ViewData["FileDocumentParentUrl"] = UrlReferrer;
			ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnEdit", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnEdit", true);
			ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnEdit");
            return View(filedocument);
        }
		// GET: /FileDocument/EditWizard/5
         public ActionResult EditWizard(int? id, string UrlReferrer,string HostingEntityName, string AssociatedType, string viewtype)
        {
            if (!User.CanEdit("FileDocument") || !CustomAuthorizationBeforeEdit(id, HostingEntityName, AssociatedType))
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
			            FileDocument filedocument = db.FileDocuments.Find(id);
            if (filedocument == null)
            {
                return HttpNotFound();
            }
	
		 if (UrlReferrer != null)
                ViewData["FileDocumentParentUrl"] = UrlReferrer;
		if(ViewData["FileDocumentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/FileDocument"))
			ViewData["FileDocumentParentUrl"] = Request.UrlReferrer;
			 LoadViewDataBeforeOnEdit(filedocument);
			 ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnEdit", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnEdit", true);
			 ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnEdit");
          return View(filedocument);
        }
        // POST: /FileDocument/EditWizard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include="Id,ConcurrencyKey,DocumentName,Description,AttachDocument,DateCreated,DateLastUpdated,T_EmployeeDocumentsID")] FileDocument filedocument, HttpPostedFileBase File_AttachDocument , String CamerafileUploadAttachDocument,string UrlReferrer)
        {
			CheckBeforeSave(filedocument);
		if (File_AttachDocument != null || (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"] != ""))
                IsFileTypeAndSizeAllowed(File_AttachDocument);
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("~/Files/");
				string ticks =  DateTime.UtcNow.Ticks.ToString();
	                if (File_AttachDocument != null)
                { 
					File_AttachDocument.SaveAs(path  + ticks + System.IO.Path.GetFileName(File_AttachDocument.FileName.Trim().Replace(" ", "")));
                    filedocument.AttachDocument = ticks + System.IO.Path.GetFileName(File_AttachDocument.FileName.Trim().Replace(" ", ""));
                }
			bool customsave_hasissues = false;
			if (!CustomSaveOnEdit(filedocument,out customsave_hasissues,"Save"))
            {
				db.Entry(filedocument).State = EntityState.Modified;
				db.SaveChanges();
            }
           if (!customsave_hasissues)
		   {
				 RedirectToRouteResult customRedirectAction = CustomRedirectUrl(filedocument,"Edit","");
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
			LoadViewDataAfterOnEdit(filedocument);
			ViewBag.FileDocumentIsHiddenRule = checkHidden("FileDocument", "OnEdit", false);
			ViewBag.FileDocumentIsGroupsHiddenRule = checkHidden("FileDocument", "OnEdit", true);
			ViewBag.FileDocumentIsSetValueUIRule = checkSetValueUIRule("FileDocument", "OnEdit");
            return View(filedocument);
        }
        // GET: /FileDocument/Delete/5
        public ActionResult Delete(int id)
        {
			if (!User.CanDelete("FileDocument") || !CustomAuthorizationBeforeDelete(id))
            {
                return RedirectToAction("Index", "Error");
            }			
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			            FileDocument filedocument = db.FileDocuments.Find(id);
            if (filedocument == null)
            {
                throw(new Exception("Deleted"));
            }
			if(ViewData["FileDocumentParentUrl"] == null  && Request.UrlReferrer !=null && ! Request.UrlReferrer.AbsolutePath.EndsWith("/FileDocument"))
			 ViewData["FileDocumentParentUrl"] = Request.UrlReferrer;
            return View(filedocument);
        }
        // POST: /FileDocument/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(FileDocument filedocument, string UrlReferrer)
        {
			if (!User.CanDelete("FileDocument"))
            {
                return RedirectToAction("Index", "Error");
            }
			 if (CheckBeforeDelete(filedocument))
            {
				bool customdelete_hasissues = false;
                if (!CustomDelete(filedocument, out customdelete_hasissues, "Delete"))
                {
			db.Entry(filedocument).State = EntityState.Deleted;
            db.FileDocuments.Remove(filedocument);
            db.SaveChanges();
		}
				if (!customdelete_hasissues)
                {
					if (!string.IsNullOrEmpty(UrlReferrer))
						return Redirect(UrlReferrer);
					if (ViewData["FileDocumentParentUrl"] != null)
					{
						string parentUrl = ViewData["FileDocumentParentUrl"].ToString();
						ViewData["FileDocumentParentUrl"] = null;
						return Redirect(parentUrl);
					}
					else return RedirectToAction("Index");
				}
			 }
            return View(filedocument);
        }
		public ActionResult BulkAssociate(long[] ids, string AssociatedType, string HostingEntity, string HostingEntityID)
        {
            var HostingID = Convert.ToInt64(HostingEntityID);
            if (HostingID == 0)
                return Json("Error", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            if (HostingEntity == "T_Employee" && AssociatedType == "T_EmployeeDocuments")
            {
                foreach (var id in ids.Where(p => p > 0))
                {
                    FileDocument obj = db.FileDocuments.Find(id);
                    db.Entry(obj).State = EntityState.Modified;
                    obj.T_EmployeeDocumentsID = HostingID;
                    db.SaveChanges();
                }
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		public ActionResult DeleteBulk(long[] ids, string UrlReferrer)
		{
			if (User != null && (!((CustomPrincipal)User).CanUseVerb("BulkDelete", "FileDocument", User) || !User.CanDelete("FileDocument")))
            {
                return RedirectToAction("Index", "Error");
            }
			bool customdelete_hasissues = false;
            foreach (var id in ids.Where(p => p > 0))
            {
			customdelete_hasissues = false;
            FileDocument filedocument = db.FileDocuments.Find(id);
		if (CheckBeforeDelete(filedocument))
        {
            if (!CustomDelete(filedocument, out customdelete_hasissues, "DeleteBulk"))
            {
                db.Entry(filedocument).State = EntityState.Deleted;
                db.FileDocuments.Remove(filedocument);
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
            if (!((CustomPrincipal)User).CanUseVerb("BulkUpdate", "FileDocument", User) || !User.CanEdit("FileDocument") || !CustomAuthorizationBeforeBulkUpdate(HostingEntityName, HostingEntityID, AssociatedType))
            {
                return RedirectToAction("Index", "Error");
            }
            if (IsDDUpdate != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDUpdate);
            ViewData["FileDocumentParentUrl"] = UrlReferrer;
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
		public ActionResult BulkUpdate([Bind(Include="Id,ConcurrencyKey,DocumentName,Description,AttachDocument,DateCreated,DateLastUpdated,T_EmployeeDocumentsID")] FileDocument filedocument, HttpPostedFileBase File_AttachDocument , String CamerafileUploadAttachDocument,FormCollection collection, string UrlReferrer)
        {
            var bulkIds = collection["BulkUpdate"].Split(',').ToList();
            var chkUpdate = collection["chkUpdate"];
			if (!string.IsNullOrEmpty(chkUpdate))
            {
			bool customsave_hasissues = false;
            foreach (var id in bulkIds.Where(p => p != string.Empty))
            {
                long objId = long.Parse(id);
                FileDocument target = db.FileDocuments.Find(objId);
				target.setDateTimeToClientTime();
                EntityCopy.CopyValuesForSameObjectType(filedocument, target, chkUpdate); 
				customsave_hasissues = false;
				CheckBeforeSave(target,"BulkUpdate");
				if (ValidateModel(target) && !CustomSaveOnEdit(target, out customsave_hasissues, "BulkUpdate"))
                {
						db.Entry(target).State = EntityState.Modified;
						try
						{
							if (target.t_employeedocuments != null)
							  db.Entry(target.t_employeedocuments).State = EntityState.Unchanged;
							db.SaveChanges();
						}
						catch { }
				}
            }
			}
			RedirectToRouteResult customRedirectAction = CustomRedirectUrl(filedocument,"BulkUpdate","");
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
