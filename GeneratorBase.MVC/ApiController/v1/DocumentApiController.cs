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
    public partial class DocumentController : ApiBaseControllerv1
    {
        [HttpGet]
        [Route("api/v{version:apiVersion}/Document")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(PagedList<Document>))]
        public async Task<IHttpActionResult> Get([FromUri]DocumentSearchOptions options)
        {
            var list = db.Documents.Select(s => s);
            list = SearchInternal(list, options);
            return await Page(db.Documents, options.Page.Value);
        }
       
        [Route("api/v{version:apiVersion}/Document/{id:long}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Document))]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(void))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var _document = await db.Documents.FirstOrDefaultAsync(s => s.Id == id);
            if (_document != null)
                return Ok(_document);
            return NotFound();
        }

        // GET api/Document/display
        [HttpGet]
        [Route("api/v{version:apiVersion}/Document/display")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(PagedList<DisplayItem>))]
        [Description("A light-weight, paged list of entities whose DisplayValue starts with the given search term.")]
        public async Task<IHttpActionResult> Display(string q = null, int? page = 1)
        {
            var list = db.Documents.Where(f => String.IsNullOrEmpty(q) || f.FileName.StartsWith(q))
                                .OrderBy(f => f.DisplayValue)
                                .Select(s => new DisplayItem() { Id = s.Id, Text = s.DisplayValue });

            return await Page(list, page.Value);
        }
        [HttpGet]
        [Route("api/v{version:apiVersion}/Document/count")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int))]
        public async Task<IHttpActionResult> Count([FromUri]DocumentSearchOptions options)
        {
            var list = db.Documents.Select(s => s);
            list = SearchInternal(list, options);
            var count = await list.CountAsync();
            return Ok(count);
        }
        private IQueryable<Document> SearchInternal(IQueryable<Document> list, DocumentSearchOptions opt)
        {
            if (!String.IsNullOrEmpty(opt.Search))
            {
                list = Filter(list, opt.Search, opt.DeepSearch);
            }

            if (!String.IsNullOrEmpty(opt.Order))
            {
                list = Sort(list, opt.Order, opt.Ascending.Value);
            }
            else list = list.OrderByDescending(c => c.Id);
            return list;
        }
        private IQueryable<Document> Filter(IQueryable<Document> list, string searchString, bool? deepSearch)
        {
            if (String.IsNullOrEmpty(searchString)) return list;

            searchString = searchString.ToUpper().Trim();
            if (deepSearch ?? false)
                list = list.Where(s => (s.FileName != null && (s.FileName.ToUpper().Contains(searchString))));
            else
                list = list.Where(s => (s.FileName != null && (s.FileName.ToUpper().Contains(searchString))));
            return list;
        }
        // POST api/DocumentApi
        [Route("api/v{version:apiVersion}/Document")]
        [SwaggerResponse(HttpStatusCode.Created, typeof(Document))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void))]
        [SwaggerResponse(HttpStatusCode.Conflict, typeof(void))]
        public async Task<IHttpActionResult> Post(Document _document)
        {
            if (_document == null) return BadRequest();
            if (_document.Id > 0) return Conflict();
            _document.DateCreated = _document.DateLastUpdated = DateTime.UtcNow;
            db.Documents.Add(_document);
            await db.SaveChangesAsync();//SaveChangesAsync will not call base.SaveChanges of context, it has lots of validations 
            return CreatedAtRoute("DefaultApi", new { id = _document.Id }, _document);
        }
       

        // PUT api/DocumentApi/5
        [Route("api/v{version:apiVersion}/Document/{id:long}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Document))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void))]
        public async Task<IHttpActionResult> Put(int id, Document _document)
        {
            if (_document == null) return BadRequest();
            if (_document.Id == 0) return BadRequest();
            _document.DateLastUpdated = DateTime.UtcNow;
            db.Entry(_document).State = EntityState.Modified;
            await db.SaveChangesAsync();//SaveChangesAsync will not call base.SaveChanges of context, it has lots of validations
            return Ok(_document);
        }
        

        // DELETE api/DocumentApi/5
        [Route("api/v{version:apiVersion}/Document/{id:long}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(void))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();

            var _document = await db.Documents.FirstOrDefaultAsync(s => s.Id == id); // should be FindAsync

            if (_document == null) return StatusCode(HttpStatusCode.NoContent);
            db.Entry(_document).State = EntityState.Deleted;
            db.Documents.Remove(_document);
            await db.SaveChangesAsync();//SaveChangesAsync will not call base.SaveChanges of context, it has lots of validations

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
