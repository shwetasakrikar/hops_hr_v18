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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace GeneratorBase.MVC.Controllers
{	
    public partial class T_FacilityController : BaseController
    {
		public bool CheckBeforeDelete(T_Facility t_facility)
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
		public string CheckBeforeSave(T_Facility t_facility, string command ="")
        {
			var AlertMsg = "";
            // Write your logic here
 
			   //Make sure to assign AlertMsg with proper message
			   //AlertMsg = "Validation Alert - Before Save !! Information not saved.";
               //ModelState.AddModelError("CustomError", AlertMsg);
			   //ViewBag.ApplicationError = AlertMsg;
            return AlertMsg;
        }
		public void OnDeleting(T_Facility t_facility)
        {
            // Write your logic here
 
		}
        public void OnSaving(T_Facility t_facility, ApplicationContext db)
        {
            // Write your logic here
 
        }
		public void AfterSave(T_Facility t_facility)
        {
			var roleContext = new ApplicationDbContext();
			if (roleContext.Roles.FirstOrDefault(p => p.TenantId == t_facility.Id) == null)
            {
                var RoleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new ApplicationDbContext()));
				IdentityResult roleResultCanEdit = RoleManager.Create(new ApplicationRole(t_facility.DisplayValue + "-Admin",t_facility.DisplayValue + " Tenant Admin Role","TenantSpecific",t_facility.Id));
                if (roleResultCanEdit.Succeeded)
                {
                    using (var permissionContextTenantAdmin = new PermissionContext())
                    {
                        var flag = false;
                        foreach (var ent in permissionContextTenantAdmin.Permissions.Where(p => p.RoleName == "Tenant-Admin-Template"))
                        {
                            Permission permission = new Permission();
                            permission.CanAdd = ent.CanAdd;
                            permission.CanDelete = ent.CanDelete;
                            permission.CanView = ent.CanView;
                            permission.CanEdit = ent.CanEdit;
                            permission.IsOwner = ent.IsOwner;
                            permission.SelfRegistration = ent.SelfRegistration;
                            permission.EntityName = ent.EntityName;
                            permission.RoleName = t_facility.DisplayValue + "-Admin";
                            permission.Verbs = ent.Verbs;
                            permission.UserAssociation = ent.UserAssociation;
                            permissionContextTenantAdmin.Permissions.Add(permission);
                            flag = true;
                        }
                        if(flag)
                            permissionContextTenantAdmin.SaveChanges();
                        flag = false;
                        foreach (var ent in permissionContextTenantAdmin.AdminPrivileges.Where(p => p.RoleName == "Tenant-Admin-Template"))
                        {
                            PermissionAdminPrivilege permission = new PermissionAdminPrivilege();
                            permission.AdminFeature = ent.AdminFeature;
                            permission.IsAdd = ent.IsAdd;
                            permission.IsAllow = ent.IsAllow;
                            permission.IsDelete = ent.IsDelete;
                            permission.IsEdit = ent.IsEdit;
                            permission.RoleName = t_facility.DisplayValue + "-Admin";
                            permissionContextTenantAdmin.AdminPrivileges.Add(permission);
                            flag = true;
                        }
                        if (flag)
                            permissionContextTenantAdmin.SaveChanges();
                    }
                }
            }
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
private void CustomLoadViewDataListAfterOnCreate(T_Facility t_facility)
{
}
private void CustomLoadViewDataListBeforeEdit(T_Facility t_facility)
{
}
private void CustomLoadViewDataListAfterEdit(T_Facility t_facility)
{
}
private void CustomLoadViewDataListOnIndex(string HostingEntity, int? HostingEntityID, string AssociatedType)
{
}
private bool CustomSaveOnCreate(T_Facility t_facility, out bool customcreate_hasissues, string command="")
{
            var result = false;
			customcreate_hasissues = false;
            return result;
}
private bool CustomSaveOnEdit(T_Facility t_facility, out bool customsave_hasissues, string command="")
{
            var result = false;
			customsave_hasissues = false;
            return result;
}
private bool CustomSaveOnImport(T_Facility t_facility, out string customerror, int i)
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
private bool CustomDelete(T_Facility t_facility, out bool customdelete_hasissues, string command="")
{
            var result = false;
			customdelete_hasissues = false;
            return result;
}
private IQueryable<T_Facility> CustomSorting(IQueryable<T_Facility> list)
{
    IQueryable<T_Facility> orderedList = list;
	// Do custom sorting here
    return orderedList;
}
private RedirectToRouteResult CustomRedirectUrl(T_Facility t_facility,string action,string command="")
{
	// Sample Custom implemention below
    // return RedirectToAction("Index", "T_Facility");
    return null;
}
	}
}
