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
using GeneratorBase.MVC.DynamicQueryable;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing.Imaging;
using System.Web.Helpers;
namespace GeneratorBase.MVC.Controllers
{	
    public partial class T_JobAssignmentController : BaseController
    {
		public bool CheckBeforeDelete(T_JobAssignment t_jobassignment)
        {
            var result = true;
            // Write your logic here
 
			if (!result)
            {
                var AlertMsg = "Validation Alert - Before Delete !! Information not deleted.";
                ModelState.AddModelError("CustomError", AlertMsg);
                ViewBag.ApplicationError = AlertMsg;
            }
			return result;
		}
		public string CheckBeforeSave(T_JobAssignment t_jobassignment, string command ="")
        {
			var AlertMsg = "";
		//Before Save Validation, if returns true then changes will be saved else it cancels the save changes.
		if (t_jobassignment.Id > 0 && t_jobassignment.T_Primary != null && t_jobassignment.T_Primary.Value)
            {
                if (t_jobassignment.T_Active == null || !t_jobassignment.T_Active.Value)
                {
                    AlertMsg = "Only Active Job Assignment can be set as Primary.";
                    ModelState.AddModelError("CustomError", AlertMsg);
                    ViewBag.ApplicationError = AlertMsg;
                    return AlertMsg;
                }
            }
            var db1 = new ApplicationContext(new SystemUser());
            var position = db1.T_Positions.FirstOrDefault(p => p.Id == t_jobassignment.T_PositionJobAssignmentID);
            var positionfill = position.T_PositionFill == null ? 0 : position.T_PositionFill;
            var employeepercent = t_jobassignment.T_EmployeePercent == null ? 0 : t_jobassignment.T_EmployeePercent;
            int fillpercent = 0;
            if (t_jobassignment.Id == 0)
                fillpercent = Convert.ToInt32(positionfill + employeepercent);
            else
            {
                var oldjobassignment = db1.T_JobAssignments.FirstOrDefault(p => p.Id == t_jobassignment.Id);
                var oldemployeepercent = oldjobassignment.T_EmployeePercent == null ? 0 : oldjobassignment.T_EmployeePercent;
                fillpercent = Convert.ToInt32((positionfill - oldemployeepercent) + employeepercent);
            }
            if (position.T_DualIncumbent != null && position.T_DualIncumbent.Value)
            {
                if (fillpercent > 200)
                {
                    AlertMsg = "As Position is Dual Incumbent, either Position Fill% or Employee Percent exceeding limit of 200.";
                    ModelState.AddModelError("CustomError", AlertMsg);
                    ViewBag.ApplicationError = AlertMsg;
                    return AlertMsg;
                }
            }
            else
            {
                if (fillpercent > 100)
                {
                    AlertMsg = "Either Position Fill% or Employee Percent exceeding limit of 100.";
                    ModelState.AddModelError("CustomError", AlertMsg);
                    ViewBag.ApplicationError = AlertMsg;
                    return AlertMsg;
                }
            }
 
			   //Make sure to assign AlertMsg with proper message
			   //AlertMsg = "alert";
               //ModelState.AddModelError("CustomError", AlertMsg);
			   //ViewBag.ApplicationError = AlertMsg;
            return AlertMsg;
        }
		public void OnDeleting(T_JobAssignment t_jobassignment)
        {
            // Write your logic here
 
		}
        public void OnSaving(T_JobAssignment t_jobassignment, ApplicationContext db)
        {
		//it is called before saving changes if 'BeforeSave' validates and return true.
		//use below code to find db value (value before save) to compare it with current object t_jobassignment in your business logic.
		//var oldValue = db.T_JobAssignment.Find(t_jobassignment.Id);
		 if (t_jobassignment.T_StartDate < DateTime.Now && (string.IsNullOrEmpty(t_jobassignment.T_EndDate.ToString()) || t_jobassignment.T_EndDate >= DateTime.Now))
            {
                t_jobassignment.T_Active = true;
            }
            else
            {
                t_jobassignment.T_Active = false;
            }
 
        }
		public void AfterSave(T_JobAssignment t_jobassignment)
        {
		//Do not call db.SaveChanges() for T_JobAssignment otherwise it will be a recursive call.
		//e.g. send email notification after saving changes.
		var db = new ApplicationContext(new SystemUser());

            var jobposition = db.T_Positions.FirstOrDefault(ps => ps.Id == t_jobassignment.T_PositionJobAssignmentID);
            if (jobposition != null)
            {
                if (jobposition.T_PositionFill >= 100 || (jobposition.T_PositionFill < 100 && jobposition.T_QuasiFill == true))
                {
                    var positionstatus = db.T_Positionstatuss.FirstOrDefault(ps => ps.T_Name.ToLower() == "active");
                    if (positionstatus != null)
                        jobposition.T_AssociatedPositionStatusID = positionstatus.Id;
                }
                else if ((jobposition.T_PositionFill == null || jobposition.T_PositionFill < 100) && jobposition.T_QuasiFill == false)
                {
                    var positionstatus = db.T_Positionstatuss.FirstOrDefault(ps => ps.T_Name.ToLower() == "vacant");
                    
                    if (positionstatus != null)
                        jobposition.T_AssociatedPositionStatusID = positionstatus.Id;
                }
                else if (jobposition.T_AbolishDate != null && (jobposition.T_EstablishedDate == null || jobposition.T_AbolishDate > jobposition.T_EstablishedDate))
                {
                    var positionstatus = db.T_Positionstatuss.FirstOrDefault(ps => ps.T_Name.ToLower() == "abolish");
                    if (positionstatus != null)
                        jobposition.T_AssociatedPositionStatusID = positionstatus.Id;
                }
				 if (jobposition.T_DualIncumbent != null && jobposition.T_DualIncumbent.Value && jobposition.T_PositionFill < 200)
                {
                    var positionstatus = db.T_Positionstatuss.FirstOrDefault(ps => ps.T_Name.ToLower() == "vacant");
                    if (positionstatus != null)
                        jobposition.T_AssociatedPositionStatusID = positionstatus.Id;
                }
                db.Entry(jobposition).State = EntityState.Modified;
                db.SaveChanges();
            }
 
}
private bool CustomAuthorizationBeforeCreate(string HostingEntityName, string HostingEntityID, string AssociatedType)
{
		var result = true;
			return result;
}
private bool CustomAuthorizationBeforeEdit(int? id, string HostingEntityName, string AssociatedType)
{
		var result = true;
			return result;
}
private bool CustomAuthorizationBeforeDetails(int? id, string HostingEntityName, string AssociatedType)
{
		var result = true;
			return result;
}
private bool CustomAuthorizationBeforeDelete(int? id)
{
		var result = true;
			return result;
}
private bool CustomAuthorizationBeforeBulkUpdate(string HostingEntityName, string HostingEntityID, string AssociatedType)
{
		var result = true;
			return result;
}
private void CustomLoadViewDataListBeforeOnCreate(string HostingEntityName, string HostingEntityID, string AssociatedType)
{
}
private void CustomLoadViewDataListAfterOnCreate(T_JobAssignment t_jobassignment)
{
}
private void CustomLoadViewDataListBeforeEdit(T_JobAssignment t_jobassignment)
{
}
private void CustomLoadViewDataListAfterEdit(T_JobAssignment t_jobassignment)
{
}
private void CustomLoadViewDataListOnIndex(string HostingEntity, int? HostingEntityID, string AssociatedType)
{
}
private bool CustomSaveOnCreate(T_JobAssignment t_jobassignment, out bool customcreate_hasissues, string command="")
{
            var result = false;
			customcreate_hasissues = false;
            return result;
}
private bool CustomSaveOnEdit(T_JobAssignment t_jobassignment, out bool customsave_hasissues, string command="")
{
            var result = false;
			customsave_hasissues = false;
            return result;
}
private bool CustomSaveOnImport(T_JobAssignment t_jobassignment, out string customerror, int i)
{
            var result = false;
			customerror = "";
            return result;
}
private bool CustomImportDataValidate(DataSet objDataSet, string columnName, string columnValue)
{
            var result = true;
			//create ViewBag.CustomErrorsConfirmImportData for extra validation msg here
            return result;
}
private bool CustomDelete(T_JobAssignment t_jobassignment, out bool customdelete_hasissues, string command="")
{
            var result = false;
			customdelete_hasissues = false;
            return result;
}
private IQueryable<T_JobAssignment> CustomSorting(IQueryable<T_JobAssignment> list)
{
    IQueryable<T_JobAssignment> orderedList = list;
	// Do custom sorting here
    return orderedList;
}
private RedirectToRouteResult CustomRedirectUrl(T_JobAssignment t_jobassignment,string action,string command="")
{
	// Sample Custom implemention below
    // return RedirectToAction("Index", "T_JobAssignment");
    return null;
}
	}
}
