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
namespace GeneratorBase.MVC.Controllers
{	
    public partial class T_JobAssignmentController : BaseController
    {
[Audit]
		public ActionResult Active(long[] ids, string UrlReferrer)
		{
		
            foreach (var id in ids.Where(p => p > 0))
            {
				 //T_JobAssignment t_jobassignment = db.T_JobAssignments.Find(id);
				 // do your operation with each object here
				 // db.SaveChanges();
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
		}
	}
}
