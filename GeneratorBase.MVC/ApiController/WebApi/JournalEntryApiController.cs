using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AttributeRouting.Web.Http;
using GeneratorBase.MVC.Models;
using GeneratorBase.MVC.Controllers;
using Newtonsoft.Json;
using System.Web.Http.Description;
using System;
using System.Web.Http.OData;
using System.Data.Entity.SqlServer;
namespace GeneratorBase.MVC.ApiControllers
{
    [AuthorizationRequired]
    public class JournalEntryController : ApiBaseController
    {
        //private JournalEntryContext JournalEntryDB = new JournalEntryContext();
        [EnableQuery]
        public HttpResponseMessage Get()
        {
            //JournalEntryContext JournalEntryDB = new JournalEntryContext(User);
            var list = db.JournalEntries.ToList();
            var objList = list as List<JournalEntry> ?? list.ToList();
            if (objList.Any())
                return Request.CreateResponse(HttpStatusCode.OK, objList);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "JournalEntry not found");
        }
        public HttpResponseMessage Get(long id)
        {
            //JournalEntryContext JournalEntryDB = new JournalEntryContext(User);
            var obj = db.JournalEntries.Find(id);
            if (obj != null)
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No JournalEntry found for this id");
        }
        public HttpResponseMessage Get(string EntityName)
        {
            //JournalEntryContext JournalEntryDB = new JournalEntryContext(User);
            var objList = db.JournalEntries.Where(p => p.EntityName == EntityName).ToList();
            if (objList.Any())
                return Request.CreateResponse(HttpStatusCode.OK, objList);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No JournalEntry found");
        }
        public HttpResponseMessage GetByRecordId(string EntityName,long recordid)
        {
           // JournalEntryContext JournalEntryDB = new JournalEntryContext(User);
            var objList = db.JournalEntries.Where(p => p.EntityName == EntityName && p.RecordId == recordid).ToList();
            if (objList.Any())
                return Request.CreateResponse(HttpStatusCode.OK, objList);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No JournalEntry found");
        }
        public HttpResponseMessage Get(Int32 skip, Int32 take, string orderKey, string searchKey, string hostingentity, string hostingentityid, string associatedtype)
        {
           // JournalEntryContext JournalEntryDB = new JournalEntryContext(User);
            var list = db.JournalEntries.OrderByDescending(o => o.Id).Skip(skip).Take(take);
            var objList = list.ToList();
            if (!string.IsNullOrEmpty(searchKey))
                objList = searchRecords(db.JournalEntries, searchKey, true).OrderByDescending(o => o.Id).Skip(skip).Take(take).ToList();
            if (objList.Any())
                return Request.CreateResponse(HttpStatusCode.OK, objList);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No City found");
        }
        private IQueryable<JournalEntry> searchRecords(IQueryable<JournalEntry> lst, string searchString, bool? IsDeepSearch)
        {
            if (string.IsNullOrEmpty(searchString)) return lst;
            
            searchString = searchString.Trim();
            if (Convert.ToBoolean(IsDeepSearch))
                lst = lst.Where(s => (!String.IsNullOrEmpty(s.EntityName) && s.EntityName.ToUpper().Contains(searchString)) || (!String.IsNullOrEmpty(s.PropertyName) && s.PropertyName.ToUpper().Contains(searchString)) || (s.UserName != null && (s.UserName.ToUpper().Contains(searchString))));
            else
                lst = lst.Where(s => (!String.IsNullOrEmpty(s.EntityName) && s.EntityName.ToUpper().Contains(searchString)) || (!String.IsNullOrEmpty(s.PropertyName) && s.PropertyName.ToUpper().Contains(searchString)) || (s.UserName != null && (s.UserName.ToUpper().Contains(searchString))));
            return lst;
        }
    }
}

