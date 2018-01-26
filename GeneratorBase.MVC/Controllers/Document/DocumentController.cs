using GeneratorBase.MVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
namespace GeneratorBase.MVC.Controllers
{
    public partial class DocumentController : BaseController
    {

        // GET: /Document/Edit/5
        public ActionResult Edit(int? id, string UrlReferrer, string HostingEntityName, string AssociatedType, string defaultview)
        {
            if (!User.CanEdit("Document"))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document Document = db.Documents.Find(id);
            // NEXT-PREVIOUS DROP DOWN CODE
            TempData.Keep();
            string json = "";
            if (TempData["Documentlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.Documents.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityDocumentDisplayValueEdit = TempData["Documentlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["Documentlist"]);
            }

            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json.Replace(@"\", ""));
            ViewBag.EntityDocumentDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");
            //
            if (Document == null)
            {
                return HttpNotFound();
            }
            if (string.IsNullOrEmpty(defaultview))
                defaultview = "Edit";
            // NEXT-PREVIOUS DROP DOWN CODE
            SelectList selitm = new SelectList(lst, "ID", "DisplayValue");
            List<SelectListItem> newList = selitm.ToList();
            if (Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.EndsWith("/Document/Create"))
            {
                newList.Insert(0, (new SelectListItem { Text = Document.DisplayValue, Value = Document.Id.ToString() }));
                ViewBag.EntityDocumentDisplayValueEdit = newList;
                TempData["Documentlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text });
            }
            else if (!newList.Exists(p => p.Value == Convert.ToString(Document.Id)))
            {

                if (newList.Count > 0)
                {
                    newList[0].Text = Document.DisplayValue;
                    newList[0].Value = Document.Id.ToString();
                }
                else
                {
                    newList.Insert(0, (new SelectListItem { Text = Document.DisplayValue, Value = Document.Id.ToString() }));
                }
                ViewBag.EntityDocumentDisplayValueEdit = newList;
                TempData["Documentlist"] = newList.Select(z => new { ID = z.Value, DisplayValue = z.Text });
            }
            //
            if (UrlReferrer != null)
                ViewData["DocumentParentUrl"] = UrlReferrer;
            if (ViewData["DocumentParentUrl"] == null && Request.UrlReferrer != null && !Request.UrlReferrer.AbsolutePath.EndsWith("/Document") && !Request.UrlReferrer.AbsolutePath.EndsWith("/Document/Edit/" + Document.Id + "") && !Request.UrlReferrer.AbsolutePath.EndsWith("/Document/Create"))
                ViewData["DocumentParentUrl"] = Request.UrlReferrer;
            ViewData["HostingEntityName"] = HostingEntityName;
            ViewData["AssociatedType"] = AssociatedType;
            return View(Document);
        }
        // POST: /Document/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ConcurrencyKey,DocumentName,Description,AttachDocument,DateCreated,DateLastUpdated")] Document Document, HttpPostedFileBase File_Byte, String CamerafileUploadAttachDocument, string UrlReferrer)
        {
            if (File_Byte != null || (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"] != ""))
                IsFileTypeAndSizeAllowed(File_Byte);
            if (ModelState.IsValid)
            {
                string command = Request.Form["hdncommand"];
                string path = Server.MapPath("~/Files/");
                string ticks = DateTime.UtcNow.Ticks.ToString();
                if (File_Byte != null)
                {
                    Document.FileName = System.IO.Path.GetFileName(File_Byte.FileName.Trim().Replace(" ", ""));
                    //UpdateDocument(File_Byte, Document.Id);
                    string fileExt = "";
                    string filename = "";
                    long fileSize = 0;
                    //Document document = new Document();
                    Document.DocumentName = File_Byte.FileName;
                    filename = System.IO.Path.GetFileName(File_Byte.FileName);
                    fileExt = System.IO.Path.GetExtension(File_Byte.FileName);
                    fileSize = File_Byte.ContentLength;
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(File_Byte.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(File_Byte.ContentLength);
                    }
                    Document.DocumentName = filename;
                    Document.DateCreated = System.DateTime.UtcNow.Date;
                    Document.DateLastUpdated = System.DateTime.UtcNow.Date;
                    Document.FileExtension = fileExt;
                    Document.DisplayValue = filename;
                    Document.FileName = filename;
                    Document.FileSize = fileSize;
                    Document.MIMEType = File_Byte.ContentType;
                    Document.Byte = fileData;
                }
                if (Request.Form["CamerafileUploadAttachDocument"] != null && Request.Form["CamerafileUploadAttachDocument"] != "")
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(Convert.FromBase64String(Request.Form["CamerafileUploadAttachDocument"])));
                    image.Save(path + ticks + "Camera-" + ticks + "-" + User.Name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    Document.FileName = ticks + "Camera-" + ticks + "-" + User.Name + ".jpg";
                }
                db.Entry(Document).State = EntityState.Modified;
                db.SaveChanges();
                if (command != "Save")
                {
                    if (command == "SaveNextPrev")
                    {
                        long NextPreId = Convert.ToInt64(Request.Form["hdnNextPrevId"]);
                        return RedirectToAction("Edit", new { Id = NextPreId, UrlReferrer = UrlReferrer });
                    }
                    else
                        return RedirectToAction("Edit", new { Id = Document.Id, UrlReferrer = UrlReferrer });
                }
                if (!string.IsNullOrEmpty(UrlReferrer))
                {
                    var uri = new Uri(UrlReferrer);
                    var query = HttpUtility.ParseQueryString(uri.Query);
                    if (Convert.ToBoolean(query.Get("IsFilter")) == true)
                        return RedirectToAction("Index");
                    else
                        return Redirect(UrlReferrer);
                }
                else
                    return RedirectToAction("Index");
            }

            // NEXT-PREVIOUS DROP DOWN CODE
            TempData.Keep();
            string json = "";
            if (TempData["Documentlist"] == null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(db.Documents.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }).ToList());
            }
            else
            {
                ViewBag.EntityDocumentDisplayValueEdit = TempData["Documentlist"];
                json = Newtonsoft.Json.JsonConvert.SerializeObject(TempData["Documentlist"]);
            }
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(json.Replace(@"\", ""));
            ViewBag.EntityDocumentDisplayValueEdit = new SelectList(lst, "ID", "DisplayValue");


            ViewData["DocumentParentUrl"] = UrlReferrer;

            return View(Document);
        }
        // GET: /Document/Delete/5
        public ActionResult Delete(int id)
        {
            if (!User.CanDelete("Document"))
            {
                return RedirectToAction("Index", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document Document = db.Documents.Find(id);
            if (Document == null)
            {
                throw (new Exception("Deleted"));
            }
            if (ViewData["DocumentParentUrl"] == null && Request.UrlReferrer != null && !Request.UrlReferrer.AbsolutePath.EndsWith("/Document"))
                ViewData["DocumentParentUrl"] = Request.UrlReferrer;
            return View(Document);
        }
        // POST: /Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Document Document, string UrlReferrer)
        {
            if (!User.CanDelete("Document"))
            {
                return RedirectToAction("Index", "Error");
            }

            //Delete Document
            db.Entry(Document).State = EntityState.Deleted;
            db.Documents.Remove(Document);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(UrlReferrer))
                return Redirect(UrlReferrer);
            if (ViewData["DocumentParentUrl"] != null)
            {
                string parentUrl = ViewData["DocumentParentUrl"].ToString();
                ViewData["DocumentParentUrl"] = null;
                return Redirect(parentUrl);
            }
            else return RedirectToAction("Index");
            return View(Document);
        }


        private IQueryable<Document> sortRecords(IQueryable<Document> lstFileDocument, string sortBy, string isAsc)
        {
            string methodName = "";
            switch (isAsc.ToLower())
            {
                case "asc":
                    methodName = "OrderBy";
                    break;
                case "desc":
                    methodName = "OrderByDescending";
                    break;
            }

            ParameterExpression paramExpression = Expression.Parameter(typeof(Document), "document");
            MemberExpression memExp = Expression.PropertyOrField(paramExpression, sortBy);
            LambdaExpression lambda = Expression.Lambda(memExp, paramExpression);
            return (IQueryable<Document>)lstFileDocument.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { lstFileDocument.ElementType, lambda.Body.Type },
                    lstFileDocument.Expression,
                    lambda));
        }
        private IQueryable<Document> searchRecords(IQueryable<Document> lstFileDocument, string searchString, bool? IsDeepSearch)
        {
            searchString = searchString.Trim();
            lstFileDocument = lstFileDocument.Where(s => (!String.IsNullOrEmpty(s.FileName) && s.FileName.ToUpper().Contains(searchString)) || (!String.IsNullOrEmpty(s.DocumentName) && s.DocumentName.ToUpper().Contains(searchString)) || (!String.IsNullOrEmpty(s.Description) && s.Description.ToUpper().Contains(searchString)) || (!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
            return lstFileDocument;
        }
        public ActionResult Index(string currentFilter, string searchString, string sortBy, string isAsc, int? page, int? itemsPerPage, string HostingEntity, int? HostingEntityID, string AssociatedType, bool? IsExport, bool? IsDeepSearch, bool? IsFilter, bool? RenderPartial, string BulkOperation, string parent, string Wfsearch, string caller, bool? BulkAssociate, string viewtype, string isMobileHome, bool? IsHomeList)
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
            var lstFileDocument = from s in db.Documents
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
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Pages = page;
            if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "Document"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "Document"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
            //Cookies for pagination 
            if (Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "Document"] != null)
            {
                pageNumber = Convert.ToInt32(Request.Cookies["pagination" + HttpUtility.UrlEncode(User.Name) + "Document"].Value);
                ViewBag.Pages = pageNumber;
            }
            //
            //
            ViewBag.PageSize = pageSize;
            var _FileDocument = lstFileDocument;


            if (Convert.ToBoolean(IsExport))
            {
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
            if (!(RenderPartial == null ? false : RenderPartial.Value) && !Request.IsAjaxRequest())
            {
                if (string.IsNullOrEmpty(viewtype))
                    viewtype = "IndexPartial";
                if ((ViewBag.TemplatesName != null && viewtype != null) && ViewBag.TemplatesName != viewtype)
                    ViewBag.TemplatesName = viewtype;

                var list = _FileDocument.ToPagedList(pageNumber, pageSize);
                ViewBag.EntityFileDocumentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
                TempData["Documentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });

                return View(list);
            }
            else
            {
                if (BulkOperation != null && (BulkOperation == "single" || BulkOperation == "multiple"))
                {
                    ViewData["BulkAssociate"] = BulkAssociate;

                    return View();
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
                        TempData["Documentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });

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
                        TempData["Documentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });

                        return PartialView(ViewBag.TemplatesName, list);
                    }
                }
            }
        }
        public FileResult Download(long id)
        {
            //check download permission;
            return ExportCode(id);
        }
        protected FileContentResult ExportCode(long id)
        {
            var doc = db.Documents.Find(id);
            if (doc == null)
                return null;
            byte[] fileBytes = doc.Byte;
            string fileName = doc.DisplayValue;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDocumentName(long? id)
        {

            var doc = db.Documents.Find(id);
            if (doc == null)
                return Json("NA", JsonRequestBehavior.AllowGet);
            else
                return Json(doc.DocumentName, JsonRequestBehavior.AllowGet);
        }
        public void DisplayImage(long id, int? maxSize, int? maxHeight, int? maxWidth)
        {
            //maxSize = 30;
            int height = Math.Min(maxSize ?? Int32.MaxValue, maxHeight ?? Int32.MaxValue);
            int width = Math.Min(maxSize ?? Int32.MaxValue, maxWidth ?? Int32.MaxValue);
            var doc = db.Documents.Find(id);
            if (doc == null)
                return;
            var wi = new WebImage(doc.Byte);
            wi.Resize(width, height, preventEnlarge: true);
            wi.Write();
        }
        public FileResult DisplayImage_old(long id)
        {
            var doc = db.Documents.Find(id);
            if (doc == null)
                return null;
            byte[] fileBytes = doc.Byte;
            string fileName = doc.DisplayValue;
            return File(fileBytes, doc.MIMEType.ToString());
        }
        public FileResult DisplayImageAfterhover(long id)
        {
            var doc = db.Documents.Find(id);
            if (doc == null)
                return null;
            byte[] fileBytes = doc.Byte;
            string fileName = doc.DisplayValue;
            return File(fileBytes, doc.MIMEType.ToString());
        }
        public FileResult DisplayImageAfterClick(long id)
        {
            var doc = db.Documents.Find(id);
            if (doc == null)
                return null;
            byte[] fileBytes = doc.Byte;
            string fileName = doc.DisplayValue;
            return File(fileBytes, doc.MIMEType.ToString());
        }
        public FileResult DisplayImageMobile(long id)
        {
            var doc = db.Documents.Find(id);
            if (doc == null)
                return null;
            byte[] fileBytes = doc.Byte;
            string fileName = doc.DisplayValue;
            return File(fileBytes, doc.MIMEType.ToString());
        }
        public void DisplayImageMobileList(long id, int? maxSize, int? maxHeight, int? maxWidth)
        {
            maxSize = 85;
            int height = Math.Min(maxSize ?? Int32.MaxValue, maxHeight ?? Int32.MaxValue);
            int width = Math.Min(maxSize ?? Int32.MaxValue, maxWidth ?? Int32.MaxValue);
            var doc = db.Documents.Find(id);
            if (doc == null)
                return;
            var wi = new WebImage(doc.Byte);
            wi.Resize(width, height, preventEnlarge: true);
            wi.Write();
        }
        public string GetDisplayValue(string id)
        {
            if (string.IsNullOrEmpty(id)) return "";
            long idvalue = Convert.ToInt64(id);
            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            var _Obj = db1.Documents.FirstOrDefault(p => p.Id == idvalue);
            return _Obj == null ? "" : _Obj.DisplayValue;
            //return _Obj;
        }
    }
}