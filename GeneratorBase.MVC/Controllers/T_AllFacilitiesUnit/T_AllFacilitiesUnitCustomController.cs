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
using GeneratorBase.MVC.DynamicQueryable;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing.Imaging;
using System.Web.Helpers;
namespace GeneratorBase.MVC.Controllers
{	
    public partial class T_AllFacilitiesUnitController : BaseController
    {
		public bool CheckBeforeDelete(T_AllFacilitiesUnit t_allfacilitiesunit)
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
		public string CheckBeforeSave(T_AllFacilitiesUnit t_allfacilitiesunit, string command ="")
        {
			var AlertMsg = "";
            // Write your logic here
 
			   //Make sure to assign AlertMsg with proper message
			   //AlertMsg = "Validation Alert - Before Save !! Information not saved.";
               //ModelState.AddModelError("CustomError", AlertMsg);
			   //ViewBag.ApplicationError = AlertMsg;
            return AlertMsg;
        }
		public void OnDeleting(T_AllFacilitiesUnit t_allfacilitiesunit)
        {
            // Write your logic here
 
		}
        public void OnSaving(T_AllFacilitiesUnit t_allfacilitiesunit, ApplicationContext db)
        {
            // Write your logic here
 
        }
		public void AfterSave(T_AllFacilitiesUnit t_allfacilitiesunit)
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
private void CustomLoadViewDataListAfterOnCreate(T_AllFacilitiesUnit t_allfacilitiesunit)
{
}
private void CustomLoadViewDataListBeforeEdit(T_AllFacilitiesUnit t_allfacilitiesunit)
{
}
private void CustomLoadViewDataListAfterEdit(T_AllFacilitiesUnit t_allfacilitiesunit)
{
}
private void CustomLoadViewDataListOnIndex(string HostingEntity, int? HostingEntityID, string AssociatedType)
{
}
private bool CustomSaveOnCreate(T_AllFacilitiesUnit t_allfacilitiesunit, out bool customcreate_hasissues, string command="")
{
            var result = false;
			customcreate_hasissues = false;
            return result;
}
private bool CustomSaveOnEdit(T_AllFacilitiesUnit t_allfacilitiesunit, out bool customsave_hasissues, string command="")
{
            var result = false;
			customsave_hasissues = false;
            return result;
}
private bool CustomSaveOnImport(T_AllFacilitiesUnit t_allfacilitiesunit, out string customerror, int i)
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
private bool CustomDelete(T_AllFacilitiesUnit t_allfacilitiesunit, out bool customdelete_hasissues, string command="")
{
            var result = false;
			customdelete_hasissues = false;
            return result;
}
private IQueryable<T_AllFacilitiesUnit> CustomSorting(IQueryable<T_AllFacilitiesUnit> list)
{
    IQueryable<T_AllFacilitiesUnit> orderedList = list;
	// Do custom sorting here
    return orderedList;
}
private RedirectToRouteResult CustomRedirectUrl(T_AllFacilitiesUnit t_allfacilitiesunit,string action,string command="")
{
	// Sample Custom implemention below
    // return RedirectToAction("Index", "T_AllFacilitiesUnit");
    return null;
}
	}
}
