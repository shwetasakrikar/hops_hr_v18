using GeneratorBase.MVC.Controllers;
using GeneratorBase.MVC.Models;
using GeneratorBase.MVC.Models.SearchOptions;
using Microsoft.Web.Http;
using NSwag.Annotations;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
namespace GeneratorBase.MVC.ApiControllers.v1
{
    [AuthorizationRequired]
    [ApiVersion("1.0")]
    public class JournalEntryController : ApiBaseControllerv1
    {
        [HttpGet]
        [Route("api/v{version:apiVersion}/JournalEntry")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(PagedList<JournalEntry>))]
        public async Task<IHttpActionResult> Get([FromUri]JournalEntrySearchOptions options)
        {
            var list = db.JournalEntries.Select(s => s);
            list = SearchInternal(list, options);
            return await Page(db.JournalEntries, options.Page.Value);
        }


        [Route("api/v{version:apiVersion}/JournalEntry/{id:long}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(JournalEntry))]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(void))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var _journalentry = await db.JournalEntries.FirstOrDefaultAsync(s => s.Id == id);
            if (_journalentry != null)
                return Ok(_journalentry);
            return NotFound();
        }

        private IQueryable<JournalEntry> SearchInternal(IQueryable<JournalEntry> list, JournalEntrySearchOptions opt)
        {
            if (!String.IsNullOrEmpty(opt.Search))
            {
                list = Filter(list, opt.Search, opt.DeepSearch);
            }
            if (!String.IsNullOrEmpty(opt.entityname))
            {
                list = list.Where(p=>p.EntityName == opt.entityname);
            }
            if (opt.recordid.HasValue)
            {
                list = list.Where(p => p.RecordId == opt.recordid);
            }
            if (!String.IsNullOrEmpty(opt.propertyname))
            {
                list = list.Where(p => p.PropertyName == opt.propertyname);
            }
            if (!String.IsNullOrEmpty(opt.Order))
            {
                list = Sort(list, opt.Order, opt.Ascending.Value);
            }
            else list = list.OrderByDescending(c => c.Id);
            return list;
        }
        private IQueryable<JournalEntry> Filter(IQueryable<JournalEntry> list, string searchString, bool? deepSearch)
        {
            if (String.IsNullOrEmpty(searchString)) return list;

            searchString = searchString.ToUpper().Trim();
            if (deepSearch ?? false)
                list = list.Where(s => (!String.IsNullOrEmpty(s.EntityName) && s.EntityName.ToUpper().Contains(searchString)) || (!String.IsNullOrEmpty(s.PropertyName) && s.PropertyName.ToUpper().Contains(searchString)) || (s.UserName != null && (s.UserName.ToUpper().Contains(searchString))));
            else
                list = list.Where(s => (!String.IsNullOrEmpty(s.EntityName) && s.EntityName.ToUpper().Contains(searchString)) || (!String.IsNullOrEmpty(s.PropertyName) && s.PropertyName.ToUpper().Contains(searchString)) || (s.UserName != null && (s.UserName.ToUpper().Contains(searchString))));
            return list;
        }

    }
}

