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
    public partial class T_PositionController : BaseController
    {
		public bool CheckBeforeDelete(T_Position t_position)
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
		public string CheckBeforeSave(T_Position t_position, string command ="")
        {
			var AlertMsg = "";
            // Write your logic here
 
			   //Make sure to assign AlertMsg with proper message
			   //AlertMsg = "Validation Alert - Before Save !! Information not saved.";
               //ModelState.AddModelError("CustomError", AlertMsg);
			   //ViewBag.ApplicationError = AlertMsg;
            return AlertMsg;
        }
		public void OnDeleting(T_Position t_position)
        {
            // Write your logic here
 
		}
        public void OnSaving(T_Position t_position, ApplicationContext db)
        {
		//it is called before saving changes if 'BeforeSave' validates and return true.
		//use below code to find db value (value before save) to compare it with current object t_position in your business logic.
		//var oldValue = db.T_Position.Find(t_position.Id);
		 if (t_position.T_PositionFill >= 100 || (t_position.T_PositionFill < 100 && t_position.T_QuasiFill == true))
            {
                var positionstatus = db.T_Positionstatuss.FirstOrDefault(ps => ps.T_Name.ToLower() == "active");
                if (positionstatus != null)
                    t_position.T_AssociatedPositionStatusID = positionstatus.Id;
            }
            else if ((t_position.T_PositionFill == null || t_position.T_PositionFill < 100) && t_position.T_QuasiFill == false)
            {
                var positionstatus = db.T_Positionstatuss.FirstOrDefault(ps => ps.T_Name.ToLower() == "vacant");

                if (positionstatus != null)
                    t_position.T_AssociatedPositionStatusID = positionstatus.Id;
            }
            else if (t_position.T_AbolishDate != null && (t_position.T_EstablishedDate == null || t_position.T_AbolishDate > t_position.T_EstablishedDate))
            {
                var positionstatus = db.T_Positionstatuss.FirstOrDefault(ps => ps.T_Name.ToLower() == "abolish");
                if (positionstatus != null)
                    t_position.T_AssociatedPositionStatusID = positionstatus.Id;
            }
            if (t_position.T_DualIncumbent != null && t_position.T_DualIncumbent.Value && t_position.T_PositionFill < 200)
        {
            var positionstatus = db.T_Positionstatuss.FirstOrDefault(ps => ps.T_Name.ToLower() == "vacant");
            if (positionstatus != null)
				t_position.T_AssociatedPositionStatusID = positionstatus.Id;
        }
 
        }
		public void AfterSave(T_Position t_position)
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
private void CustomLoadViewDataListAfterOnCreate(T_Position t_position)
{
}
private void CustomLoadViewDataListBeforeEdit(T_Position t_position)
{
}
private void CustomLoadViewDataListAfterEdit(T_Position t_position)
{
}
private void CustomLoadViewDataListOnIndex(string HostingEntity, int? HostingEntityID, string AssociatedType)
{
}
private bool CustomSaveOnCreate(T_Position t_position, out bool customcreate_hasissues, string command="")
{
            var result = false;
			customcreate_hasissues = false;
            return result;
}
private bool CustomSaveOnEdit(T_Position t_position, out bool customsave_hasissues, string command="")
{
            var result = false;
			customsave_hasissues = false;
            return result;
}
private bool CustomSaveOnImport(T_Position t_position, out string customerror, int i)
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
private bool CustomDelete(T_Position t_position, out bool customdelete_hasissues, string command="")
{
            var result = false;
			customdelete_hasissues = false;
            return result;
}
private IQueryable<T_Position> CustomSorting(IQueryable<T_Position> list)
{
    IQueryable<T_Position> orderedList = list;
	// Do custom sorting here
    return orderedList;
}
private RedirectToRouteResult CustomRedirectUrl(T_Position t_position,string action,string command="")
{
	// Sample Custom implemention below
    // return RedirectToAction("Index", "T_Position");
    return null;
}
	}
}
