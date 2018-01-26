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
namespace GeneratorBase.MVC.Controllers
{	
    public partial class T_MajorController : BaseController
    {
		public bool CheckBeforeDelete(T_Major t_major)
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
		public string CheckBeforeSave(T_Major t_major, string command ="")
        {
			var AlertMsg = "";
            // Write your logic here
 
			   //Make sure to assign AlertMsg with proper message
			   //AlertMsg = "Validation Alert - Before Save !! Information not saved.";
               //ModelState.AddModelError("CustomError", AlertMsg);
			   //ViewBag.ApplicationError = AlertMsg;
            return AlertMsg;
        }
		public void OnDeleting(T_Major t_major)
        {
            // Write your logic here
 
		}
        public void OnSaving(T_Major t_major, ApplicationContext db)
        {
            // Write your logic here
 
        }
		public void AfterSave(T_Major t_major)
        {
            // Write your logic here
 
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
private void CustomLoadViewDataListAfterOnCreate(T_Major t_major)
{
}
private void CustomLoadViewDataListBeforeEdit(T_Major t_major)
{
}
private void CustomLoadViewDataListAfterEdit(T_Major t_major)
{
}
private void CustomLoadViewDataListOnIndex(string HostingEntity, int? HostingEntityID, string AssociatedType)
{
}
private bool CustomSaveOnCreate(T_Major t_major, out bool customcreate_hasissues, string command="")
{
            var result = false;
			customcreate_hasissues = false;
            return result;
}
private bool CustomSaveOnEdit(T_Major t_major, out bool customsave_hasissues, string command="")
{
            var result = false;
			customsave_hasissues = false;
            return result;
}
private bool CustomSaveOnImport(T_Major t_major, out string customerror, int i)
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
private bool CustomDelete(T_Major t_major, out bool customdelete_hasissues, string command="")
{
            var result = false;
			customdelete_hasissues = false;
            return result;
}
private IQueryable<T_Major> CustomSorting(IQueryable<T_Major> list)
{
    IQueryable<T_Major> orderedList = list;
	// Do custom sorting here
    return orderedList;
}
private RedirectToRouteResult CustomRedirectUrl(T_Major t_major,string action,string command="")
{
	// Sample Custom implemention below
    // return RedirectToAction("Index", "T_Major");
    return null;
}
	}
}
