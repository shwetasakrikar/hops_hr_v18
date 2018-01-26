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
    public partial class T_EmployeeController : BaseController
    {
		public bool CheckBeforeDelete(T_Employee t_employee)
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
		public string CheckBeforeSave(T_Employee t_employee, string command ="")
        {
			var AlertMsg = "";
            // Write your logic here
 
			   //Make sure to assign AlertMsg with proper message
			   //AlertMsg = "Validation Alert - Before Save !! Information not saved.";
               //ModelState.AddModelError("CustomError", AlertMsg);
			   //ViewBag.ApplicationError = AlertMsg;
            return AlertMsg;
        }
		public void OnDeleting(T_Employee t_employee)
        {
            // Write your logic here
 
		}
        public void OnSaving(T_Employee t_employee, ApplicationContext db)
        {
            // Write your logic here
 
        }
		public void AfterSave(T_Employee t_employee)
        {
		//Do not call db.SaveChanges() for T_Employee otherwise it will be a recursive call.
		//e.g. send email notification after saving changes.
		var db1 = new ApplicationContext(new SystemUser());
            var status = db1.T_EmployeeStatusCodes.FirstOrDefault(p => p.T_Name == "T");
            long statusid = 0;
            if (status != null)
                statusid = status.Id;
            if (t_employee.T_EmployeeStatusID == statusid)
            {
                bool saveFlagSupervisor = false;
                var lstJobUnderSupervisor = db1.T_JobAssignments.Where(p => p.T_EmployeeSupervisorID == t_employee.Id).ToList();
                foreach (var job in lstJobUnderSupervisor)
                {
                    if (job.T_EmployeeSupervisorID == t_employee.Id)
                    {
                        var unitXID = job.T_JobAssignmentUnitXID;
                        var unitX = db1.T_UnitXs.Find(unitXID);
                        if (unitX != null && unitX.T_EmployeeUnitXHeadID != null) 
                        {
                            job.T_EmployeeSupervisorID = unitX.T_EmployeeUnitXHeadID; 
                            db1.Entry(job).State = EntityState.Modified;
                            saveFlagSupervisor = true;
                        }
                    }
                }
                if (saveFlagSupervisor)
                    db1.SaveChanges();
                bool saveFlagManager = false;
                var lstJobUnderManager = db1.T_JobAssignments.Where(p => p.T_JobAssignmentManagerEmployeeID == t_employee.Id).ToList();
                foreach (var job in lstJobUnderManager)
                {
                    if (job.T_JobAssignmentManagerEmployeeID == t_employee.Id)
                    {
                        var unitXID = job.T_JobAssignmentUnitXID;
                        var unitX = db1.T_UnitXs.Find(unitXID);
                        if (unitX != null && unitX.T_EmployeeAdministratorID != null)
                        {
                            job.T_JobAssignmentManagerEmployeeID = unitX.T_EmployeeAdministratorID; 
                            db1.Entry(job).State = EntityState.Modified;
                            saveFlagManager = true;
                        }
                    }
                }
                if (saveFlagManager)
                    db1.SaveChanges();
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
private void CustomLoadViewDataListAfterOnCreate(T_Employee t_employee)
{
}
private void CustomLoadViewDataListBeforeEdit(T_Employee t_employee)
{
}
private void CustomLoadViewDataListAfterEdit(T_Employee t_employee)
{
}
private void CustomLoadViewDataListOnIndex(string HostingEntity, int? HostingEntityID, string AssociatedType)
{
}
private bool CustomSaveOnCreate(T_Employee t_employee, out bool customcreate_hasissues, string command="")
{
            var result = false;
			customcreate_hasissues = false;
            return result;
}
private bool CustomSaveOnEdit(T_Employee t_employee, out bool customsave_hasissues, string command="")
{
            var result = false;
			customsave_hasissues = false;
            return result;
}
private bool CustomSaveOnImport(T_Employee t_employee, out string customerror, int i)
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
private bool CustomDelete(T_Employee t_employee, out bool customdelete_hasissues, string command="")
{
            var result = false;
			customdelete_hasissues = false;
            return result;
}
private IQueryable<T_Employee> CustomSorting(IQueryable<T_Employee> list)
{
    IQueryable<T_Employee> orderedList = list;
	// Do custom sorting here
    return orderedList;
}
private RedirectToRouteResult CustomRedirectUrl(T_Employee t_employee,string action,string command="")
{
	// Sample Custom implemention below
    // return RedirectToAction("Index", "T_Employee");
    return null;
}
	}
}
