using GeneratorBase.MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;
namespace GeneratorBase.MVC.Controllers
{
    public class AuditAttribute : ActionFilterAttribute
    {
        private string name { get; set; }
        public AuditAttribute(string name)
        {
            this.name = name;
        }
        public AuditAttribute()
        {
            this.name = "";
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;
            string entity = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var RecdId = 0;
            if (filterContext.ActionParameters.First().Key.ToUpper() == "ID")
                RecdId = Convert.ToInt32(filterContext.ActionParameters.First().Value);
            //Generate an audit
            JournalEntry audit = new JournalEntry()
            {
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                RoleName = (request.IsAuthenticated) ?string.Join(",",((CustomPrincipal)filterContext.HttpContext.User).userroles) : "Anonymous",
                EntityName = entity,
                RecordInfo = "<a href=\"" + request.RawUrl.Replace("RenderPartial=True&","").Replace("EditQuick","Edit") + "\">" + (RecdId > 0 ? EntityComparer.GetDisplayValueForAssociation(entity, Convert.ToString(RecdId)) : "Click to view") + "</a>",
                DateTimeOfEntry = DateTime.UtcNow,
                RecordId = RecdId,
                Type = string.IsNullOrEmpty(name) ? filterContext.ActionDescriptor.ActionName : name
            };
            //Stores the Audit in the Database
            JournalEntryContext context = new JournalEntryContext();
            context.JournalEntries.Add(audit);
            context.SaveChanges();
            //Finishes executing the Action as normal 
            base.OnActionExecuting(filterContext);
        }
    }
}