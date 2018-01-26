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
    public partial class T_UnitXController : BaseController
    {
		private void LoadViewDataForCount(T_UnitX t_unitx, string AssocType)
        {
        }
		private void LoadViewDataAfterOnEdit(T_UnitX t_unitx)
        {		
			 ViewBag.T_FacilityUnitXID = new SelectList(db.T_Facilitys, "ID", "DisplayValue", t_unitx.T_FacilityUnitXID);
			 ViewBag.T_UnitXUnitAssociationID = new SelectList(db.T_Units, "ID", "DisplayValue", t_unitx.T_UnitXUnitAssociationID);
			 ViewBag.T_WardDepartmentID = new SelectList(db.T_Departments, "ID", "DisplayValue", t_unitx.T_WardDepartmentID);
			 ViewBag.T_UnitXDepartmentAreaID = new SelectList(db.T_DepartmentAreas, "ID", "DisplayValue", t_unitx.T_UnitXDepartmentAreaID);
			 ViewBag.T_WardOrgCodeID = new SelectList(db.T_OrgCodess, "ID", "DisplayValue", t_unitx.T_WardOrgCodeID);
			 ViewBag.T_UnitXFloorID = new SelectList(db.T_Floors, "ID", "DisplayValue", t_unitx.T_UnitXFloorID);
			 ViewBag.T_EmployeeAdministratorID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_unitx.T_EmployeeAdministratorID);
			 ViewBag.T_EmployeeUnitXHeadID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_unitx.T_EmployeeUnitXHeadID);
			 ViewBag.T_WardCostCenterID = new SelectList(db.T_CostCenters, "ID", "DisplayValue", t_unitx.T_WardCostCenterID);
			CustomLoadViewDataListAfterEdit(t_unitx);
        }
        private void LoadViewDataBeforeOnEdit(T_UnitX t_unitx)
        {		
               var _objT_FacilityUnitX = new List<T_Facility>();
               _objT_FacilityUnitX.Add(t_unitx.t_facilityunitx);
			   			   ViewBag.T_FacilityUnitXID = new SelectList(_objT_FacilityUnitX, "ID", "DisplayValue", t_unitx.T_FacilityUnitXID);
			               var _objT_UnitXUnitAssociation = new List<T_Unit>();
               _objT_UnitXUnitAssociation.Add(t_unitx.t_unitxunitassociation);
			   			   ViewBag.T_UnitXUnitAssociationID = new SelectList(_objT_UnitXUnitAssociation, "ID", "DisplayValue", t_unitx.T_UnitXUnitAssociationID);
			               var _objT_WardDepartment = new List<T_Department>();
               _objT_WardDepartment.Add(t_unitx.t_warddepartment);
			   			   ViewBag.T_WardDepartmentID = new SelectList(_objT_WardDepartment, "ID", "DisplayValue", t_unitx.T_WardDepartmentID);
			               var _objT_UnitXDepartmentArea = new List<T_DepartmentArea>();
               _objT_UnitXDepartmentArea.Add(t_unitx.t_unitxdepartmentarea);
			   			   ViewBag.T_UnitXDepartmentAreaID = new SelectList(_objT_UnitXDepartmentArea, "ID", "DisplayValue", t_unitx.T_UnitXDepartmentAreaID);
			               var _objT_WardOrgCode = new List<T_OrgCodes>();
               _objT_WardOrgCode.Add(t_unitx.t_wardorgcode);
			   			   ViewBag.T_WardOrgCodeID = new SelectList(_objT_WardOrgCode, "ID", "DisplayValue", t_unitx.T_WardOrgCodeID);
			               var _objT_UnitXFloor = new List<T_Floor>();
               _objT_UnitXFloor.Add(t_unitx.t_unitxfloor);
			   			   ViewBag.T_UnitXFloorID = new SelectList(_objT_UnitXFloor, "ID", "DisplayValue", t_unitx.T_UnitXFloorID);
			               var _objT_EmployeeAdministrator = new List<T_Employee>();
               _objT_EmployeeAdministrator.Add(t_unitx.t_employeeadministrator);
			   			   ViewBag.T_EmployeeAdministratorID = new SelectList(_objT_EmployeeAdministrator, "ID", "DisplayValue", t_unitx.T_EmployeeAdministratorID);
			               var _objT_EmployeeUnitXHead = new List<T_Employee>();
               _objT_EmployeeUnitXHead.Add(t_unitx.t_employeeunitxhead);
			   			   ViewBag.T_EmployeeUnitXHeadID = new SelectList(_objT_EmployeeUnitXHead, "ID", "DisplayValue", t_unitx.T_EmployeeUnitXHeadID);
			               var _objT_WardCostCenter = new List<T_CostCenter>();
               _objT_WardCostCenter.Add(t_unitx.t_wardcostcenter);
			   			   ViewBag.T_WardCostCenterID = new SelectList(_objT_WardCostCenter, "ID", "DisplayValue", t_unitx.T_WardCostCenterID);
				 ViewBag.T_JobAssignmentUnitXCount = t_unitx.t_jobassignmentunitx.Count();
		CustomLoadViewDataListBeforeEdit(t_unitx);
        }
        private void LoadViewDataAfterOnCreate(T_UnitX t_unitx)
        {			
			 ViewBag.T_FacilityUnitXID = new SelectList(db.T_Facilitys, "ID", "DisplayValue", t_unitx.T_FacilityUnitXID);
			 ViewBag.T_UnitXUnitAssociationID = new SelectList(db.T_Units, "ID", "DisplayValue", t_unitx.T_UnitXUnitAssociationID);
			 ViewBag.T_WardDepartmentID = new SelectList(db.T_Departments, "ID", "DisplayValue", t_unitx.T_WardDepartmentID);
			 ViewBag.T_UnitXDepartmentAreaID = new SelectList(db.T_DepartmentAreas, "ID", "DisplayValue", t_unitx.T_UnitXDepartmentAreaID);
			 ViewBag.T_WardOrgCodeID = new SelectList(db.T_OrgCodess, "ID", "DisplayValue", t_unitx.T_WardOrgCodeID);
			 ViewBag.T_UnitXFloorID = new SelectList(db.T_Floors, "ID", "DisplayValue", t_unitx.T_UnitXFloorID);
			 ViewBag.T_EmployeeAdministratorID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_unitx.T_EmployeeAdministratorID);
			 ViewBag.T_EmployeeUnitXHeadID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_unitx.T_EmployeeUnitXHeadID);
			 ViewBag.T_WardCostCenterID = new SelectList(db.T_CostCenters, "ID", "DisplayValue", t_unitx.T_WardCostCenterID);
		CustomLoadViewDataListAfterOnCreate(t_unitx);
        }
        private void LoadViewDataBeforeOnCreate(string HostingEntityName, string HostingEntityID, string AssociatedType)
        {			
			if(HostingEntityName == "T_Facility" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_FacilityUnitX")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_FacilityUnitXID = new SelectList(db.T_Facilitys.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Facilitys.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_FacilityUnitX = new List<T_Facility>();
			 ViewBag.T_FacilityUnitXID = new SelectList(objT_FacilityUnitX , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Unit" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_UnitXUnitAssociation")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_UnitXUnitAssociationID = new SelectList(db.T_Units.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Units.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_UnitXUnitAssociation = new List<T_Unit>();
			 ViewBag.T_UnitXUnitAssociationID = new SelectList(objT_UnitXUnitAssociation , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Department" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_WardDepartment")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_WardDepartmentID = new SelectList(db.T_Departments.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Departments.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_WardDepartment = new List<T_Department>();
			 ViewBag.T_WardDepartmentID = new SelectList(objT_WardDepartment , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_DepartmentArea" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_UnitXDepartmentArea")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_UnitXDepartmentAreaID = new SelectList(db.T_DepartmentAreas.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_DepartmentAreas.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_UnitXDepartmentArea = new List<T_DepartmentArea>();
			 ViewBag.T_UnitXDepartmentAreaID = new SelectList(objT_UnitXDepartmentArea , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_OrgCodes" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_WardOrgCode")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_WardOrgCodeID = new SelectList(db.T_OrgCodess.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_OrgCodess.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_WardOrgCode = new List<T_OrgCodes>();
			 ViewBag.T_WardOrgCodeID = new SelectList(objT_WardOrgCode , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Floor" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_UnitXFloor")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_UnitXFloorID = new SelectList(db.T_Floors.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Floors.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_UnitXFloor = new List<T_Floor>();
			 ViewBag.T_UnitXFloorID = new SelectList(objT_UnitXFloor , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeAdministrator")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeAdministratorID = new SelectList(db.T_Employees.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Employees.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeAdministrator = new List<T_Employee>();
			 ViewBag.T_EmployeeAdministratorID = new SelectList(objT_EmployeeAdministrator , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeUnitXHead")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeUnitXHeadID = new SelectList(db.T_Employees.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Employees.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeUnitXHead = new List<T_Employee>();
			 ViewBag.T_EmployeeUnitXHeadID = new SelectList(objT_EmployeeUnitXHead , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_CostCenter" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_WardCostCenter")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_WardCostCenterID = new SelectList(db.T_CostCenters.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_CostCenters.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_WardCostCenter = new List<T_CostCenter>();
			 ViewBag.T_WardCostCenterID = new SelectList(objT_WardCostCenter , "ID", "DisplayValue");
		    }
			CustomLoadViewDataListBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
        }
		private IQueryable<T_UnitX> searchRecords(IQueryable<T_UnitX> lstT_UnitX, string searchString, bool? IsDeepSearch)
        {
		   searchString = searchString.Trim();
		if(Convert.ToBoolean(IsDeepSearch))
            lstT_UnitX = lstT_UnitX.Where(s => (s.t_facilityunitx!= null && (s.t_facilityunitx.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_unitxunitassociation!= null && (s.t_unitxunitassociation.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_warddepartment!= null && (s.t_warddepartment.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_unitxdepartmentarea!= null && (s.t_unitxdepartmentarea.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_wardorgcode!= null && (s.t_wardorgcode.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_Unit) && s.T_Unit.ToUpper().Contains(searchString)) ||(s.t_unitxfloor!= null && (s.t_unitxfloor.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_UnitPhoneNumber) && s.T_UnitPhoneNumber.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_MailDistributor) && s.T_MailDistributor.ToUpper().Contains(searchString)) ||(s.t_employeeadministrator!= null && (s.t_employeeadministrator.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeunitxhead!= null && (s.t_employeeunitxhead.DisplayValue.ToUpper().Contains(searchString) )) ||(s.T_MaleBeds != null && SqlFunctions.StringConvert((double)s.T_MaleBeds).Contains(searchString)) ||(s.T_FemaleBeds != null && SqlFunctions.StringConvert((double)s.T_FemaleBeds).Contains(searchString)) ||(s.T_TotalBeds != null && SqlFunctions.StringConvert((double)s.T_TotalBeds).Contains(searchString)) ||(s.t_wardcostcenter!= null && (s.t_wardcostcenter.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_wardcostcenter.t_costprogram.DisplayValue) && s.t_wardcostcenter.t_costprogram.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_wardcostcenter.t_costfund.DisplayValue) && s.t_wardcostcenter.t_costfund.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
		else
			 lstT_UnitX = lstT_UnitX.Where(s => (s.t_facilityunitx!= null && (s.t_facilityunitx.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_warddepartment!= null && (s.t_warddepartment.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_unitxdepartmentarea!= null && (s.t_unitxdepartmentarea.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_wardorgcode!= null && (s.t_wardorgcode.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_Unit) && s.T_Unit.ToUpper().Contains(searchString)) ||(s.t_unitxfloor!= null && (s.t_unitxfloor.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_UnitPhoneNumber) && s.T_UnitPhoneNumber.ToUpper().Contains(searchString)) ||(s.t_employeeadministrator!= null && (s.t_employeeadministrator.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeunitxhead!= null && (s.t_employeeunitxhead.DisplayValue.ToUpper().Contains(searchString) )) ||(s.T_TotalBeds != null && SqlFunctions.StringConvert((double)s.T_TotalBeds).Contains(searchString)) ||(s.t_wardcostcenter!= null && (s.t_wardcostcenter.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_wardcostcenter.t_costprogram.DisplayValue) && s.t_wardcostcenter.t_costprogram.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_wardcostcenter.t_costfund.DisplayValue) && s.t_wardcostcenter.t_costfund.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
            return lstT_UnitX;
        }
		private IQueryable<T_UnitX> sortRecords(IQueryable<T_UnitX> lstT_UnitX, string sortBy, string isAsc)
        {
            string methodName = "";
            switch (isAsc.ToLower())
            {
                case "asc":
                    methodName = "OrderBy";
                    break;
                case "desc":
                    methodName = "OrderByDescending";
                    break;
            }
	 if(sortBy == "T_ProgramID")
                return isAsc.ToLower() == "asc" ? lstT_UnitX.OrderBy(p => p.t_wardcostcenter.t_costprogram.DisplayValue) : lstT_UnitX.OrderByDescending(p => p.t_wardcostcenter.t_costprogram.DisplayValue);
	 if(sortBy == "T_FundID")
                return isAsc.ToLower() == "asc" ? lstT_UnitX.OrderBy(p => p.t_wardcostcenter.t_costfund.DisplayValue) : lstT_UnitX.OrderByDescending(p => p.t_wardcostcenter.t_costfund.DisplayValue);
	 if(sortBy == "T_FacilityUnitXID")
                return isAsc.ToLower() == "asc" ? lstT_UnitX.OrderBy(p => p.t_facilityunitx.DisplayValue) : lstT_UnitX.OrderByDescending(p => p.t_facilityunitx.DisplayValue);
	 if(sortBy == "T_WardDepartmentID")
                return isAsc.ToLower() == "asc" ? lstT_UnitX.OrderBy(p => p.t_warddepartment.DisplayValue) : lstT_UnitX.OrderByDescending(p => p.t_warddepartment.DisplayValue);
	 if(sortBy == "T_UnitXDepartmentAreaID")
                return isAsc.ToLower() == "asc" ? lstT_UnitX.OrderBy(p => p.t_unitxdepartmentarea.DisplayValue) : lstT_UnitX.OrderByDescending(p => p.t_unitxdepartmentarea.DisplayValue);
	 if(sortBy == "T_WardOrgCodeID")
                return isAsc.ToLower() == "asc" ? lstT_UnitX.OrderBy(p => p.t_wardorgcode.DisplayValue) : lstT_UnitX.OrderByDescending(p => p.t_wardorgcode.DisplayValue);
	 if(sortBy == "T_UnitXFloorID")
                return isAsc.ToLower() == "asc" ? lstT_UnitX.OrderBy(p => p.t_unitxfloor.DisplayValue) : lstT_UnitX.OrderByDescending(p => p.t_unitxfloor.DisplayValue);
	 if(sortBy == "T_EmployeeAdministratorID")
                return isAsc.ToLower() == "asc" ? lstT_UnitX.OrderBy(p => p.t_employeeadministrator.DisplayValue) : lstT_UnitX.OrderByDescending(p => p.t_employeeadministrator.DisplayValue);
	 if(sortBy == "T_EmployeeUnitXHeadID")
                return isAsc.ToLower() == "asc" ? lstT_UnitX.OrderBy(p => p.t_employeeunitxhead.DisplayValue) : lstT_UnitX.OrderByDescending(p => p.t_employeeunitxhead.DisplayValue);
	 if(sortBy == "T_WardCostCenterID")
                return isAsc.ToLower() == "asc" ? lstT_UnitX.OrderBy(p => p.t_wardcostcenter.DisplayValue) : lstT_UnitX.OrderByDescending(p => p.t_wardcostcenter.DisplayValue);
		    if (sortBy.Contains("."))
                return isAsc.ToLower() == "asc" ? lstT_UnitX.Sort(sortBy,true) : lstT_UnitX.Sort(sortBy,false);
            ParameterExpression paramExpression = Expression.Parameter(typeof(T_UnitX), "t_unitx");
            MemberExpression memExp = Expression.PropertyOrField(paramExpression, sortBy);
            LambdaExpression lambda = Expression.Lambda(memExp, paramExpression);
            return (IQueryable<T_UnitX>)lstT_UnitX.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { lstT_UnitX.ElementType, lambda.Body.Type },
                    lstT_UnitX.Expression,
                    lambda));
        }
		public ActionResult FindFSearch(string id, string sourceEntity)
        {
            if (sourceEntity == "FileDocument")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.FileDocuments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeeDocumentsID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Licenses")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Licensess.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_LicenseRecordsID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Department")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Departments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityUnitX  = _Object.T_DepartmentFacilityAssociationID;
						url += "&t_facilityunitx=" + T_FacilityUnitX;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Position")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Positions.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityUnitX  = _Object.T_FacilityAssignedToID;
						url += "&t_facilityunitx=" + T_FacilityUnitX;									
						var T_WardCostCenter  = _Object.T_PositionCostCenterAssociationID;
						url += "&t_wardcostcenter=" + T_WardCostCenter;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_ServiceRecord")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_ServiceRecords.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeeEmploymentProfileID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Employee")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Employees.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityUnitX  = _Object.T_EmployeeAtFacilityID;
						url += "&t_facilityunitx=" + T_FacilityUnitX;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_DepartmentArea")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_DepartmentAreas.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityUnitX  = _Object.T_DepartmentAreaEmployeeTypeAssociationID;
						url += "&t_facilityunitx=" + T_FacilityUnitX;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Comment")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Comments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeeCommentsID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_ClaimType")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_ClaimTypes.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityUnitX  = _Object.T_ClaimTypeFacilityAssociationID;
						url += "&t_facilityunitx=" + T_FacilityUnitX;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Restrictions")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Restrictionss.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityUnitX  = _Object.T_RestrictionsFacilityAssociationID;
						url += "&t_facilityunitx=" + T_FacilityUnitX;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_DrugAlcoholTest")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_DrugAlcoholTests.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeeDrugAlcoholTestID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_JobAssignment")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_JobAssignments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeeJobAssignmentID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_LeaveProfile")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_LeaveProfiles.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeeLeaveProfileID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_EmployeeInjury")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_EmployeeInjurys.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeeEmployeeInjuryID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_BackgroundCheck")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_BackgroundChecks.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeeCriminalBackgroundCheckID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Unit")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Units.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityUnitX  = _Object.T_FacilityUnitID;
						url += "&t_facilityunitx=" + T_FacilityUnitX;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Education")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Educations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeeEducationID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Accommodation")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Accommodations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeeAccomodationID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_PayDetails")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_PayDetailss.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAdministrator  = _Object.T_EmployeePayDetailsID;
						url += "&t_employeeadministrator=" + T_EmployeeAdministrator;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_SalaryRange")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_SalaryRanges.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityUnitX  = _Object.T_FacilitySalaryRangeAssociationID;
						url += "&t_facilityunitx=" + T_FacilityUnitX;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_FacilityConfiguration")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_FacilityConfigurations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityUnitX  = _Object.T_TenantConfigurationAssociationID;
						url += "&t_facilityunitx=" + T_FacilityUnitX;									
                Response.Redirect(url.ToString());
            }
            return null;
        }
        public ActionResult SetFSearch(string searchString, string HostingEntity ,string t_facilityunitx,string t_unitxunitassociation,string t_warddepartment,string t_unitxdepartmentarea,string t_wardorgcode,string t_unitxfloor,string t_employeeadministrator,string t_employeeunitxhead,string t_wardcostcenter, bool? RenderPartial)
        {
			int Qcount = 0;
            if (Request.UrlReferrer != null)
                Qcount = Request.UrlReferrer.Query.Count();
			//For Reports
			 if ((RenderPartial == null ? false : RenderPartial.Value))
                Qcount = Request.QueryString.AllKeys.Count();
			ViewBag.CurrentFilter = searchString;
			if(Qcount > 0)
			{
			var T_FacilityUnitXlist = db.T_Facilitys.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_facilityunitx != null)
            {
                var ids = t_facilityunitx.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Facility= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_Facilitys.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_FacilityUnitXlist.Union(db.T_Facilitys.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Facility>(User, list, "T_Facility", null);
					ViewBag.t_facilityunitx = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_FacilityUnitXlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Facility>(User, list, "T_Facility", null);
				ViewBag.t_facilityunitx = new SelectList(list, "ID", "DisplayValue");
			}
			var T_UnitXUnitAssociationlist = db.T_Units.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_unitxunitassociation != null)
            {
                var ids = t_unitxunitassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Unit Name= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_Units.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_UnitXUnitAssociationlist.Union(db.T_Units.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Unit>(User, list, "T_Unit", null);
					ViewBag.t_unitxunitassociation = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_UnitXUnitAssociationlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Unit>(User, list, "T_Unit", null);
				ViewBag.t_unitxunitassociation = new SelectList(list, "ID", "DisplayValue");
			}
			var T_WardDepartmentlist = db.T_Departments.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_warddepartment != null)
            {
                var ids = t_warddepartment.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Department= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_Departments.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_WardDepartmentlist.Union(db.T_Departments.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Department>(User, list, "T_Department", null);
					ViewBag.t_warddepartment = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_WardDepartmentlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Department>(User, list, "T_Department", null);
				ViewBag.t_warddepartment = new SelectList(list, "ID", "DisplayValue");
			}
			var T_UnitXDepartmentArealist = db.T_DepartmentAreas.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_unitxdepartmentarea != null)
            {
                var ids = t_unitxdepartmentarea.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Department Area= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_DepartmentAreas.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_UnitXDepartmentArealist.Union(db.T_DepartmentAreas.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_DepartmentArea>(User, list, "T_DepartmentArea", null);
					ViewBag.t_unitxdepartmentarea = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_UnitXDepartmentArealist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_DepartmentArea>(User, list, "T_DepartmentArea", null);
				ViewBag.t_unitxdepartmentarea = new SelectList(list, "ID", "DisplayValue");
			}
			var T_WardOrgCodelist = db.T_OrgCodess.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_wardorgcode != null)
            {
                var ids = t_wardorgcode.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Org Code= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_OrgCodess.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_WardOrgCodelist.Union(db.T_OrgCodess.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_OrgCodes>(User, list, "T_OrgCodes", null);
					ViewBag.t_wardorgcode = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_WardOrgCodelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_OrgCodes>(User, list, "T_OrgCodes", null);
				ViewBag.t_wardorgcode = new SelectList(list, "ID", "DisplayValue");
			}
			var T_UnitXFloorlist = db.T_Floors.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_unitxfloor != null)
            {
                var ids = t_unitxfloor.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Floor= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_Floors.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_UnitXFloorlist.Union(db.T_Floors.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Floor>(User, list, "T_Floor", null);
					ViewBag.t_unitxfloor = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_UnitXFloorlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Floor>(User, list, "T_Floor", null);
				ViewBag.t_unitxfloor = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeAdministratorlist = db.T_Employees.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeadministrator != null)
            {
                var ids = t_employeeadministrator.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Administrator= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_Employees.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeAdministratorlist.Union(db.T_Employees.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
					ViewBag.t_employeeadministrator = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeAdministratorlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
				ViewBag.t_employeeadministrator = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeUnitXHeadlist = db.T_Employees.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeunitxhead != null)
            {
                var ids = t_employeeunitxhead.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Head= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_Employees.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeUnitXHeadlist.Union(db.T_Employees.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
					ViewBag.t_employeeunitxhead = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeUnitXHeadlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
				ViewBag.t_employeeunitxhead = new SelectList(list, "ID", "DisplayValue");
			}
			var T_WardCostCenterlist = db.T_CostCenters.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_wardcostcenter != null)
            {
                var ids = t_wardcostcenter.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Cost Center= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_CostCenters.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_WardCostCenterlist.Union(db.T_CostCenters.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_CostCenter>(User, list, "T_CostCenter", null);
					ViewBag.t_wardcostcenter = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_WardCostCenterlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_CostCenter>(User, list, "T_CostCenter", null);
				ViewBag.t_wardcostcenter = new SelectList(list, "ID", "DisplayValue");
			}
			}
			else
			{
			var objT_FacilityUnitX = new List<T_Facility>();
		    ViewBag.t_facilityunitx = new SelectList(objT_FacilityUnitX, "ID", "DisplayValue");
			var objT_UnitXUnitAssociation = new List<T_Unit>();
		    ViewBag.t_unitxunitassociation = new SelectList(objT_UnitXUnitAssociation, "ID", "DisplayValue");
			var objT_WardDepartment = new List<T_Department>();
		    ViewBag.t_warddepartment = new SelectList(objT_WardDepartment, "ID", "DisplayValue");
			var objT_UnitXDepartmentArea = new List<T_DepartmentArea>();
		    ViewBag.t_unitxdepartmentarea = new SelectList(objT_UnitXDepartmentArea, "ID", "DisplayValue");
			var objT_WardOrgCode = new List<T_OrgCodes>();
		    ViewBag.t_wardorgcode = new SelectList(objT_WardOrgCode, "ID", "DisplayValue");
			var objT_UnitXFloor = new List<T_Floor>();
		    ViewBag.t_unitxfloor = new SelectList(objT_UnitXFloor, "ID", "DisplayValue");
			var objT_EmployeeAdministrator = new List<T_Employee>();
		    ViewBag.t_employeeadministrator = new SelectList(objT_EmployeeAdministrator, "ID", "DisplayValue");
			var objT_EmployeeUnitXHead = new List<T_Employee>();
		    ViewBag.t_employeeunitxhead = new SelectList(objT_EmployeeUnitXHead, "ID", "DisplayValue");
			var objT_WardCostCenter = new List<T_CostCenter>();
		    ViewBag.t_wardcostcenter = new SelectList(objT_WardCostCenter, "ID", "DisplayValue");
			}
				var lstFavoriteItem = db.FavoriteItems.Where(p => p.LastUpdatedByUser == User.Name);
				if (lstFavoriteItem.Count() > 0)
                    ViewBag.FavoriteItem = lstFavoriteItem;
				ViewBag.EntityName = "T_UnitX";
				var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == ViewBag.EntityName);
				var Prop = Entity.Properties.Select(z => new { z.DisplayName, z.Name });
				var sortlist = Prop;
				ViewBag.PropertyList = new SelectList(Prop, "Name", "DisplayName");
				ViewBag.SuggestedDynamicValueInCondition7 = new SelectList(Prop, "Name", "DisplayName");
				Dictionary<string, string> Dumplist = new Dictionary<string, string>();
				ViewBag.SuggestedDynamicValue71 = ViewBag.SuggestedDynamicValue7 = ViewBag.SuggestedPropertyValue7
               = ViewBag.SuggestedPropertyValue = ViewBag.AssociationPropertyList = ViewBag.SuggestedDynamicValueInCondition71 = new SelectList(Dumplist, "key", "value");
				ViewBag.SortOrder1 = new SelectList(sortlist, "Name", "DisplayName");
				ViewBag.GroupByColumn = new SelectList(sortlist, "Name", "DisplayName");
				Dictionary<string, string> columns = new Dictionary<string, string>();
			columns.Add("2", "Facility");
			columns.Add("3", "Department");
			columns.Add("4", "Department Area");
			columns.Add("5", "Org Code");
			columns.Add("6", "Unit");
			columns.Add("7", "Floor");
			columns.Add("8", "Unit Phone Number");
			columns.Add("9", "Administrator");
			columns.Add("10", "Head");
			columns.Add("11", "Total Beds");
			columns.Add("12", "Cost Center");
			columns.Add("13", "Program");
			columns.Add("14", "Fund ");
				ViewBag.HideColumns = new MultiSelectList(columns, "Key", "Value");
				return View(new T_UnitX());
            }
		public string conditionFSearch(string property, string operators, string value)
        {
            string expression = string.Empty;
            var PrpertyType = GetDataTypeOfProperty("T_UnitX", property);
            var dataType = PrpertyType[0];
            property = PrpertyType[1];
            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                var ValueType = GetDataTypeOfProperty("T_UnitX", value, true);
                if (ValueType != null && ValueType[0] == "dynamic")
                {
                    dataType = ValueType[0];
                    value = ValueType[1];
                }
            }
	    if (value.ToLower().Trim() == "null")
            {
                expression = string.Format(" " + property + " " + operators + " {0}", "null");
                return expression;
            }
            switch (dataType)
            {
                case "Int32":
                case "Int64":
                case "Double":
                case "Boolean":
                case "Decimal":
                    {
                        expression = string.Format(" " + property + " " + operators + " {0}", value);
                        break;
                    }
                case "DateTime":
                    {
 					   if (value.Trim().ToLower() == "today")
					   {
							expression = string.Format(" DbFunctions.TruncateTime(" + property + ") " + operators + " (\"{0}\")", (TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (new T_UnitX()).m_Timezone)).Date);
						}
						else
						{
							DateTime val = Convert.ToDateTime(value);
							expression = string.Format(" " + property + " " + operators + " (\"{0}\")", val);
						}
                        break;
                    }
                case "Text":
                case "String":
                    {
                        if (operators.ToLower() == "contains")
                            expression = string.Format(" " + property + "." + operators + "(\"{0}\")", value);
                        else
                            expression = string.Format(" " + property + " " + operators + " \"{0}\"", value);
                        break;
                    }
                default:
                    {
                        expression = string.Format(" " + property + " " + operators + " {0}", value);
                        break;
                    }
            }
            return expression;
        }
        public List<string> GetDataTypeOfProperty(string entityName, string propertyName, bool valueType = false)
        {
            var listString = new List<string>();
            System.Reflection.PropertyInfo[] properties = (propertyName.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            var Property = properties.FirstOrDefault(p => p.Name == propertyName);
            var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == entityName);
            var PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == propertyName);
            var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == propertyName);
            ModelReflector.Property targetPropInfo = null;
            var associatedprop = string.Empty;
            if (propertyName.StartsWith("[") && propertyName.EndsWith("]"))
            {
                propertyName = propertyName.TrimStart("[".ToArray()).TrimEnd("]".ToArray());
                if (propertyName.Contains("."))
                {
                    var targetProperties = propertyName.Split(".".ToCharArray());
                    if (targetProperties.Length > 1)
                    {
                        AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                        if (AssociationInfo != null)
                        {
                            var EntityInfo1 = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                            PropInfo = EntityInfo1.Properties.FirstOrDefault(p => p.Name == targetProperties[1]);
                            associatedprop = AssociationInfo.Name.ToLower() + "." + PropInfo.Name;
                        }
                    }
                }
            }
            string DataType = string.Empty;
            if (valueType)
                DataType = "dynamic";
            else
                DataType = PropInfo.DataType;
            listString.Add(DataType);
            if (AssociationInfo != null)
                listString.Add(associatedprop);
            else
                listString.Add(propertyName);
            return listString;
        }
        public string GetPropertyDP(string entityName, string propertyName)
        {
            System.Reflection.PropertyInfo[] properties = (propertyName.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            var Property = properties.FirstOrDefault(p => p.Name == propertyName);
            var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == entityName);
            var PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == propertyName);
            var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == propertyName);
            ModelReflector.Property targetPropInfo = null;
            var associatedprop = string.Empty;
            if (propertyName.StartsWith("[") && propertyName.EndsWith("]"))
            {
                propertyName = propertyName.TrimStart("[".ToArray()).TrimEnd("]".ToArray());
                if (propertyName.Contains("."))
                {
                    var targetProperties = propertyName.Split(".".ToCharArray());
                    if (targetProperties.Length > 1)
                    {
                        AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                        if (AssociationInfo != null)
                        {
                            var EntityInfo1 = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                            PropInfo = EntityInfo1.Properties.FirstOrDefault(p => p.Name == targetProperties[1]);
                            associatedprop = "[" + AssociationInfo.DisplayName + "." + PropInfo.DisplayName + "]";
                        }
                    }
                }
            }
            string PropertyName = string.Empty;
            if (AssociationInfo != null)
                PropertyName = associatedprop;
            else
                PropertyName = PropInfo.DisplayName;
            return PropertyName;
        }
		// GET: /T_UnitX/FSearch/
		[Audit("FacetedSearch")]
		public ActionResult FSearch(string currentFilter, string searchString, string FSFilter, string sortBy, string isAsc, int? page, int? itemsPerPage, string search, bool? IsExport ,string t_facilityunitx,string t_unitxunitassociation,string t_warddepartment,string t_unitxdepartmentarea,string t_wardorgcode,string t_unitxfloor,string t_employeeadministrator,string t_employeeunitxhead,string t_wardcostcenter ,string T_MaleBedsFrom,string T_MaleBedsTo,string T_FemaleBedsFrom,string T_FemaleBedsTo,string T_TotalBedsFrom,string T_TotalBedsTo,string FilterCondition, string HostingEntity, string AssociatedType,string HostingEntityID, string viewtype, string SortOrder, string HideColumns, string GroupByColumn,bool? IsReports, bool? IsdrivedTab)
        {
			ViewData["HostingEntity"] = HostingEntity;
            ViewData["AssociatedType"] = AssociatedType;
			ViewData["HostingEntityID"] = HostingEntityID;
			ViewBag.SearchResult = "";
			ViewData["HideColumns"] = HideColumns;
			ViewBag.GroupByColumn = GroupByColumn;
			ViewBag.IsdrivedTab = IsdrivedTab;
			if (!string.IsNullOrEmpty(viewtype))
                ViewBag.TemplatesName = viewtype.Replace("?IsAddPop=true", "");
			if (string.IsNullOrEmpty(isAsc) && !string.IsNullOrEmpty(sortBy))
            {
                isAsc = "ASC";
            }
            ViewBag.isAsc = isAsc;
            ViewBag.CurrentSort = sortBy;
			if (searchString != null)
                page = null;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
			CustomLoadViewDataListOnIndex(HostingEntity, Convert.ToInt32(HostingEntityID), AssociatedType);
            if (!string.IsNullOrEmpty(searchString) && FSFilter == null)
                ViewBag.FSFilter = "Fsearch";
				 var lstT_UnitX  = from s in db.T_UnitXs
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_UnitX  = searchRecords(lstT_UnitX, searchString.ToUpper(),true);
            }
			  if(!string.IsNullOrEmpty(search))
                	search=search.Replace("?IsAddPop=true", "");
			if(!string.IsNullOrEmpty(search)){
				ViewBag.SearchResult += "\r\n General Criterial= "+search;
				lstT_UnitX = searchRecords(lstT_UnitX, search,true);
			}
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_UnitX  = sortRecords(lstT_UnitX, sortBy, isAsc);
            }
            else   lstT_UnitX  = lstT_UnitX.OrderByDescending(c => c.Id);
			lstT_UnitX = CustomSorting(lstT_UnitX);
			lstT_UnitX = lstT_UnitX.Include(t=>t.t_facilityunitx).Include(t=>t.t_unitxunitassociation).Include(t=>t.t_warddepartment).Include(t=>t.t_unitxdepartmentarea).Include(t=>t.t_wardorgcode).Include(t=>t.t_unitxfloor).Include(t=>t.t_employeeadministrator).Include(t=>t.t_employeeunitxhead).Include(t=>t.t_wardcostcenter);
					if (!string.IsNullOrEmpty(SortOrder) && SortOrder.Contains("T_Program"))
                    {
                      SortOrder = SortOrder.Replace("T_Program", "t_wardcostcenter.t_costprogram.DisplayValue");  
                    }
					if (!string.IsNullOrEmpty(SortOrder) && SortOrder.Contains("T_Fund"))
                    {
                      SortOrder = SortOrder.Replace("T_Fund", "t_wardcostcenter.t_costfund.DisplayValue");  
                    }
			if (!string.IsNullOrEmpty(FilterCondition))
            {
                StringBuilder whereCondition = new StringBuilder();
                var conditions = FilterCondition.Split("?".ToCharArray()).Where(lrc => lrc != "");
                int iCnt = 1;
                foreach (var cond in conditions)
                {
                    if (string.IsNullOrEmpty(cond)) continue;
                    var param = cond.Split(",".ToCharArray());
                    var PropertyName = param[0];
                    var Operator = param[1];
                    var Value = string.Empty;
                    var LogicalConnector = string.Empty;
                    Value = param[2];
                    LogicalConnector = (param[3] == "AND" ? " And" : " Or");
                    if (iCnt == conditions.Count())
                        LogicalConnector = "";
					ViewBag.SearchResult += " " + GetPropertyDP("T_UnitX", PropertyName) + " " + Operator + " " + Value + " " + LogicalConnector;
                    whereCondition.Append(conditionFSearch(PropertyName, Operator, Value) + LogicalConnector);
                    iCnt++;
                }
                if (!string.IsNullOrEmpty(whereCondition.ToString()))
                    lstT_UnitX = lstT_UnitX.Where(whereCondition.ToString());
                ViewBag.FilterCondition = FilterCondition;
            }
			var DataOrdering = string.Empty;
            if (!string.IsNullOrEmpty(GroupByColumn))
            {
                DataOrdering = GroupByColumn;
									if (DataOrdering.Contains("T_Program"))
                    {
                      DataOrdering = DataOrdering.Replace("T_Program", "t_wardcostcenter.t_costprogram.DisplayValue");  
                    }
					if (DataOrdering.Contains("T_Fund"))
                    {
                      DataOrdering = DataOrdering.Replace("T_Fund", "t_wardcostcenter.t_costfund.DisplayValue");  
                    }
                ViewBag.IsGroupBy = true;
            }
            if (!string.IsNullOrEmpty(SortOrder))
                DataOrdering += SortOrder;
            if (!string.IsNullOrEmpty(DataOrdering))
                lstT_UnitX = Sorting.Sort<T_UnitX>(lstT_UnitX, DataOrdering);
            var _T_UnitX = lstT_UnitX;
		 if(T_MaleBedsFrom!=null || T_MaleBedsTo !=null)
		 {
                try
                {
                    int from = T_MaleBedsFrom == null ? 0 : Convert.ToInt32(T_MaleBedsFrom);
                    int to =  T_MaleBedsTo == null ? int.MaxValue : Convert.ToInt32(T_MaleBedsTo);
									     _T_UnitX =  _T_UnitX.Where(o => o.T_MaleBeds >= from && o.T_MaleBeds <= to);
                   					ViewBag.SearchResult += "\r\n Male Beds= "+from+"-"+to;
                }
                catch { }
          }
		 if(T_FemaleBedsFrom!=null || T_FemaleBedsTo !=null)
		 {
                try
                {
                    int from = T_FemaleBedsFrom == null ? 0 : Convert.ToInt32(T_FemaleBedsFrom);
                    int to =  T_FemaleBedsTo == null ? int.MaxValue : Convert.ToInt32(T_FemaleBedsTo);
									     _T_UnitX =  _T_UnitX.Where(o => o.T_FemaleBeds >= from && o.T_FemaleBeds <= to);
                   					ViewBag.SearchResult += "\r\n Female Beds= "+from+"-"+to;
                }
                catch { }
          }
		 if(T_TotalBedsFrom!=null || T_TotalBedsTo !=null)
		 {
                try
                {
                    int from = T_TotalBedsFrom == null ? 0 : Convert.ToInt32(T_TotalBedsFrom);
                    int to =  T_TotalBedsTo == null ? int.MaxValue : Convert.ToInt32(T_TotalBedsTo);
									     _T_UnitX =  _T_UnitX.Where(o => o.T_TotalBeds >= from && o.T_TotalBeds <= to);
                   					ViewBag.SearchResult += "\r\n Total Beds= "+from+"-"+to;
                }
                catch { }
          }
			//if (lstT_UnitX.Where(p => p.t_facilityunitx != null).Count() <= 50)
		    //ViewBag.t_facilityunitx = new SelectList(lstT_UnitX.Where(p => p.t_facilityunitx != null).Select(P => P.t_facilityunitx).Distinct(), "ID", "DisplayValue");
            if (t_facilityunitx != null)
            {
                var ids = t_facilityunitx.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Facility= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_Facilitys.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_UnitX = _T_UnitX.Where(p => ids1.Contains(p.T_FacilityUnitXID));
            }
				//if (lstT_UnitX.Where(p => p.t_unitxunitassociation != null).Count() <= 50)
		    //ViewBag.t_unitxunitassociation = new SelectList(lstT_UnitX.Where(p => p.t_unitxunitassociation != null).Select(P => P.t_unitxunitassociation).Distinct(), "ID", "DisplayValue");
            if (t_unitxunitassociation != null)
            {
                var ids = t_unitxunitassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Unit Name= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_Units.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_UnitX = _T_UnitX.Where(p => ids1.Contains(p.T_UnitXUnitAssociationID));
            }
				//if (lstT_UnitX.Where(p => p.t_warddepartment != null).Count() <= 50)
		    //ViewBag.t_warddepartment = new SelectList(lstT_UnitX.Where(p => p.t_warddepartment != null).Select(P => P.t_warddepartment).Distinct(), "ID", "DisplayValue");
            if (t_warddepartment != null)
            {
                var ids = t_warddepartment.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Department= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_Departments.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_UnitX = _T_UnitX.Where(p => ids1.Contains(p.T_WardDepartmentID));
            }
				//if (lstT_UnitX.Where(p => p.t_unitxdepartmentarea != null).Count() <= 50)
		    //ViewBag.t_unitxdepartmentarea = new SelectList(lstT_UnitX.Where(p => p.t_unitxdepartmentarea != null).Select(P => P.t_unitxdepartmentarea).Distinct(), "ID", "DisplayValue");
            if (t_unitxdepartmentarea != null)
            {
                var ids = t_unitxdepartmentarea.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Department Area= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_DepartmentAreas.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_UnitX = _T_UnitX.Where(p => ids1.Contains(p.T_UnitXDepartmentAreaID));
            }
				//if (lstT_UnitX.Where(p => p.t_wardorgcode != null).Count() <= 50)
		    //ViewBag.t_wardorgcode = new SelectList(lstT_UnitX.Where(p => p.t_wardorgcode != null).Select(P => P.t_wardorgcode).Distinct(), "ID", "DisplayValue");
            if (t_wardorgcode != null)
            {
                var ids = t_wardorgcode.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Org Code= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_OrgCodess.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_UnitX = _T_UnitX.Where(p => ids1.Contains(p.T_WardOrgCodeID));
            }
				//if (lstT_UnitX.Where(p => p.t_unitxfloor != null).Count() <= 50)
		    //ViewBag.t_unitxfloor = new SelectList(lstT_UnitX.Where(p => p.t_unitxfloor != null).Select(P => P.t_unitxfloor).Distinct(), "ID", "DisplayValue");
            if (t_unitxfloor != null)
            {
                var ids = t_unitxfloor.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Floor= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_Floors.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_UnitX = _T_UnitX.Where(p => ids1.Contains(p.T_UnitXFloorID));
            }
				//if (lstT_UnitX.Where(p => p.t_employeeadministrator != null).Count() <= 50)
		    //ViewBag.t_employeeadministrator = new SelectList(lstT_UnitX.Where(p => p.t_employeeadministrator != null).Select(P => P.t_employeeadministrator).Distinct(), "ID", "DisplayValue");
            if (t_employeeadministrator != null)
            {
                var ids = t_employeeadministrator.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Administrator= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_Employees.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_UnitX = _T_UnitX.Where(p => ids1.Contains(p.T_EmployeeAdministratorID));
            }
				//if (lstT_UnitX.Where(p => p.t_employeeunitxhead != null).Count() <= 50)
		    //ViewBag.t_employeeunitxhead = new SelectList(lstT_UnitX.Where(p => p.t_employeeunitxhead != null).Select(P => P.t_employeeunitxhead).Distinct(), "ID", "DisplayValue");
            if (t_employeeunitxhead != null)
            {
                var ids = t_employeeunitxhead.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Head= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_Employees.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_UnitX = _T_UnitX.Where(p => ids1.Contains(p.T_EmployeeUnitXHeadID));
            }
				//if (lstT_UnitX.Where(p => p.t_wardcostcenter != null).Count() <= 50)
		    //ViewBag.t_wardcostcenter = new SelectList(lstT_UnitX.Where(p => p.t_wardcostcenter != null).Select(P => P.t_wardcostcenter).Distinct(), "ID", "DisplayValue");
            if (t_wardcostcenter != null)
            {
                var ids = t_wardcostcenter.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Cost Center= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_CostCenters.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_UnitX = _T_UnitX.Where(p => ids1.Contains(p.T_WardCostCenterID));
            }
				if (!string.IsNullOrEmpty(SortOrder))
            {
                ViewBag.SearchResult += " \r\n Sort Order = ";
                var sortString = "";
                var sortProps = SortOrder.Split(",".ToCharArray());
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_UnitX");
                foreach(var prop in sortProps)
                {
                    if (string.IsNullOrEmpty(prop)) continue;
					if (prop.Contains("."))
                    {
                        sortString += prop + ",";
                        continue;
                    }
                    var asso = Entity.Associations.FirstOrDefault(p => p.AssociationProperty == prop);
                    if (asso != null)
                    {
                        sortString += asso.DisplayName + ">";
                    }
                    else
                    {
                        var propInfo = Entity.Properties.FirstOrDefault(p=>p.Name == prop);
                        sortString += propInfo.DisplayName + ">";
                    }
                }
                ViewBag.SearchResult += sortString.TrimEnd(">".ToCharArray());
            }
			if (!string.IsNullOrEmpty(GroupByColumn))
            {
                ViewBag.SearchResult += " \r\n Group By = ";
                var groupbyString = "";
                var GroupProps = GroupByColumn.Split(",".ToCharArray());
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_UnitX");
                foreach (var prop in GroupProps)
                {
                    if (string.IsNullOrEmpty(prop)) continue;
                    var asso = Entity.Associations.FirstOrDefault(p => p.AssociationProperty == prop);
                    if (asso != null)
                    {
                        groupbyString += asso.DisplayName + " > ";
                    }
                    else
                    {
                        var propInfo = Entity.Properties.FirstOrDefault(p => p.Name == prop);
                        groupbyString += propInfo.DisplayName + " > ";
                    }
                }
                ViewBag.SearchResult += groupbyString.TrimEnd(" > ".ToCharArray());
            }
			ViewBag.SearchResult = ((string)ViewBag.SearchResult).TrimStart("\r\n".ToCharArray());
	        int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Pages = page;
		   if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
		    //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_UnitX"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_UnitX"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
            //
            if (Convert.ToBoolean(IsExport))
            {
                pageNumber = 1;
                if (_T_UnitX.Count() > 0)
                    pageSize = _T_UnitX.Count();
                return View("ExcelExport", _T_UnitX.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_UnitX.Count();
                int quotient = totalListCount / pageSize;
                var remainder = totalListCount % pageSize;
                var maxpagenumber = quotient + (remainder > 0 ? 1 : 0);
                if (pageNumber > maxpagenumber)
                {
                    pageNumber = 1;
                }
			 }
            }			
			if (!Request.IsAjaxRequest())
			{
				if (string.IsNullOrEmpty(viewtype))
                    viewtype = "IndexPartial";
				GetTemplatesForList(viewtype); 
                if ((ViewBag.TemplatesName != null && viewtype != null) && ViewBag.TemplatesName != viewtype)
                    ViewBag.TemplatesName = viewtype;
				var list = _T_UnitX.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_UnitXDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_UnitXlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_UnitX", tagsSplit.ToArray());
                    }
                return View("Index",list);
			}
            else
			{
				var list = _T_UnitX.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_UnitXDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_UnitXlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_UnitX", tagsSplit.ToArray());
                    }
				if (ViewBag.TemplatesName == null)
                    return PartialView("IndexPartial", list);
                else
                 return PartialView(ViewBag.TemplatesName, list);
			}
        }
		public string ShowGraph(string type, int? inlarge)
        {
		string result = "";
		var entity = "T_UnitX";
           var chartlist = db.Charts.Where(chrt => chrt.EntityName == entity && chrt.ShowInDashBoard).ToList();
           if (type != "all")
               chartlist = chartlist.Where(chrt => chrt.Id == Convert.ToInt64(type)).ToList();
           var entitylist = db.T_UnitXs;
		    if (chartlist.Count > 0)
            {
           foreach (var charts in chartlist)
           {
		    try
               {
                   var xaxis = charts.XAxis;
                   var yaxis = charts.YAxis;
                   var xaxisTitle = charts.XAxis;
                   var yaxisTitle = charts.YAxis;
                   var charttitle = charts.ChartTitle;
                   var entInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == charts.EntityName);
                   if (yaxis == null || yaxis == "0" || yaxis.ToLower() == "displayvalue")
                       yaxis = "id";
                   if (yaxis.ToLower() == "id")
                       yaxisTitle = entInfo.DisplayName;
                   var asso = entInfo.Associations.FirstOrDefault(p => p.AssociationProperty == xaxis);
                   if (asso != null)
                   {
                       xaxis = asso.Name.ToLower() + "." + "DisplayValue";
                       xaxisTitle = asso.DisplayName;
                   }
                   var gd = entitylist.AsQueryable().GroupBy(xaxis, "it");
                   var cntgrt10 = false;
                   if (gd.Count() > 10 && inlarge == null)
                   {
                       gd = gd.Take(10);
                       cntgrt10 = true;
                   }
                   if (yaxis.ToLower() == "id")
                       gd = gd.Select("new (it.Key as " + xaxisTitle.Replace(" ", "") + ", it.Count() as " + yaxis + ")");
                   else
                       gd = gd.Select("new (it.Key as " + xaxisTitle.Replace(" ", "") + ", it.Sum(" + yaxis + ") as " + yaxis + ")");
                   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                   {
                       BorderlineDashStyle = ChartDashStyle.Solid,
                       BackSecondaryColor = System.Drawing.Color.White,
                       BackGradientStyle = GradientStyle.TopBottom,
                       BorderlineWidth = 1,
                       BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105),
                       RenderType = RenderType.ImageTag,
                       AntiAliasing = AntiAliasingStyles.All,
                       TextAntiAliasingQuality = TextAntiAliasingQuality.High
                   };
                   chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                   if (cntgrt10)
                       chart.Titles.Add(CreateTitle(charttitle + " (Top 10)"));
                   else
                       chart.Titles.Add(CreateTitle(charttitle));
                   chart.ChartAreas.Add(CreateChartArea((SeriesChartType)Enum.Parse(typeof(SeriesChartType), charts.ChartType), "", xaxisTitle, yaxisTitle));
                   chart.Series.Add(CreateSeries((SeriesChartType)Enum.Parse(typeof(SeriesChartType), charts.ChartType), ""));
                   chart.Series[0].Points.DataBindXY(gd, xaxisTitle.Replace(" ", ""), gd, yaxis);
                   chart.Legends.Add(CreateLegend(""));
                   if (charts.ChartType.ToLower() == "pie")
                   {
                       chart.Series[0].LegendText = "#VALX";
                       chart.Series[0].Label = "#PERCENT{P2}";
                   }
                   if (inlarge != null)
                   {
                       chart.Width = 800;
                       chart.Height = 800;
                   }
                   byte[] bytes;
                   using (var chartimage = new MemoryStream())
                   {
                       chart.SaveImage(chartimage, ChartImageFormat.Png);
                       bytes = chartimage.GetBuffer();
                   }
                   if (cntgrt10)
                   {
                       string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", entity, new { type = charts.Id, inlarge = 1 }) + "')\"" : "") + "/></div>";
                       string encoded = Convert.ToBase64String(bytes.ToArray());
                       result += String.Format(img, encoded);
                   }
                   else
                   {
                       string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                       string encoded = Convert.ToBase64String(bytes.ToArray());
                       result += String.Format(img, encoded);
                   }
               }
			    catch
                { continue; }
           }
		   }
		    else
            {
                result = "No chart available to display.";
            }
		    return result;
	    }
		public string ShowGraph1(string type, int? inlarge)
        {
            string result = "";
           {
                var gd = db.T_UnitXs.GroupBy(p => p.t_facilityunitx.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "1" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Facility (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Facility"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Facility", "UnitX"));
                chart.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "1", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
			if (type == "2" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).ToList();
                    if (_yvalT_MaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_MaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_MaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Facility (Top 10)"));
				else
				chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Facility"));
                chartT_MaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Facility", "T_MaleBeds"));
                chartT_MaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_MaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_MaleBeds );
                chartT_MaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_MaleBeds.Width = 800;
                        chartT_MaleBeds.Height = 800;
                    }
                byte[] bytesT_MaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_MaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_MaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_MaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "2", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
                    else
                    {
                        string imgT_MaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
				}
			if (type == "3" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).ToList();
                    if (_yvalT_FemaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_FemaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_FemaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Facility (Top 10)"));
				else
				chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Facility"));
                chartT_FemaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Facility", "T_FemaleBeds"));
                chartT_FemaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_FemaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_FemaleBeds );
                chartT_FemaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_FemaleBeds.Width = 800;
                        chartT_FemaleBeds.Height = 800;
                    }
                byte[] bytesT_FemaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_FemaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_FemaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_FemaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "3", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
                    else
                    {
                        string imgT_FemaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
				}
			if (type == "4" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).ToList();
                    if (_yvalT_TotalBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_TotalBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_TotalBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Facility (Top 10)"));
				else
				chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Facility"));
                chartT_TotalBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Facility", "T_TotalBeds"));
                chartT_TotalBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_TotalBeds.Series[0].Points.DataBindXY(_xval, _yvalT_TotalBeds );
                chartT_TotalBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_TotalBeds.Width = 800;
                        chartT_TotalBeds.Height = 800;
                    }
                byte[] bytesT_TotalBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_TotalBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_TotalBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_TotalBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "4", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
                    else
                    {
                        string imgT_TotalBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
				}
            }
           {
                var gd = db.T_UnitXs.GroupBy(p => p.t_unitxunitassociation.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "5" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Unit Name (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Unit Name"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Unit Name", "UnitX"));
                chart.Series.Add(CreateSeries(SeriesChartType.Pie, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
								chart.Series[0].LegendText = "#VALX";
				chart.Series[0].Label = "#PERCENT{P2}";
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "5", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
			if (type == "6" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).ToList();
                    if (_yvalT_MaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_MaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_MaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Unit Name (Top 10)"));
				else
				chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Unit Name"));
                chartT_MaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Unit Name", "T_MaleBeds"));
                chartT_MaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_MaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_MaleBeds );
                chartT_MaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_MaleBeds.Width = 800;
                        chartT_MaleBeds.Height = 800;
                    }
                byte[] bytesT_MaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_MaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_MaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_MaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "6", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
                    else
                    {
                        string imgT_MaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
				}
			if (type == "7" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).ToList();
                    if (_yvalT_FemaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_FemaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_FemaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Unit Name (Top 10)"));
				else
				chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Unit Name"));
                chartT_FemaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Unit Name", "T_FemaleBeds"));
                chartT_FemaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_FemaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_FemaleBeds );
                chartT_FemaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_FemaleBeds.Width = 800;
                        chartT_FemaleBeds.Height = 800;
                    }
                byte[] bytesT_FemaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_FemaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_FemaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_FemaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "7", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
                    else
                    {
                        string imgT_FemaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
				}
			if (type == "8" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).ToList();
                    if (_yvalT_TotalBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_TotalBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_TotalBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Unit Name (Top 10)"));
				else
				chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Unit Name"));
                chartT_TotalBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Unit Name", "T_TotalBeds"));
                chartT_TotalBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_TotalBeds.Series[0].Points.DataBindXY(_xval, _yvalT_TotalBeds );
                chartT_TotalBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_TotalBeds.Width = 800;
                        chartT_TotalBeds.Height = 800;
                    }
                byte[] bytesT_TotalBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_TotalBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_TotalBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_TotalBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "8", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
                    else
                    {
                        string imgT_TotalBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
				}
            }
           {
                var gd = db.T_UnitXs.GroupBy(p => p.t_warddepartment.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "9" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Department (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Department"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Department", "UnitX"));
                chart.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "9", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
			if (type == "10" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).ToList();
                    if (_yvalT_MaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_MaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_MaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Department (Top 10)"));
				else
				chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Department"));
                chartT_MaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Department", "T_MaleBeds"));
                chartT_MaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_MaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_MaleBeds );
                chartT_MaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_MaleBeds.Width = 800;
                        chartT_MaleBeds.Height = 800;
                    }
                byte[] bytesT_MaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_MaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_MaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_MaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "10", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
                    else
                    {
                        string imgT_MaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
				}
			if (type == "11" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).ToList();
                    if (_yvalT_FemaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_FemaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_FemaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Department (Top 10)"));
				else
				chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Department"));
                chartT_FemaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Department", "T_FemaleBeds"));
                chartT_FemaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_FemaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_FemaleBeds );
                chartT_FemaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_FemaleBeds.Width = 800;
                        chartT_FemaleBeds.Height = 800;
                    }
                byte[] bytesT_FemaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_FemaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_FemaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_FemaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "11", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
                    else
                    {
                        string imgT_FemaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
				}
			if (type == "12" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).ToList();
                    if (_yvalT_TotalBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_TotalBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_TotalBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Department (Top 10)"));
				else
				chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Department"));
                chartT_TotalBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Department", "T_TotalBeds"));
                chartT_TotalBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_TotalBeds.Series[0].Points.DataBindXY(_xval, _yvalT_TotalBeds );
                chartT_TotalBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_TotalBeds.Width = 800;
                        chartT_TotalBeds.Height = 800;
                    }
                byte[] bytesT_TotalBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_TotalBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_TotalBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_TotalBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "12", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
                    else
                    {
                        string imgT_TotalBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
				}
            }
           {
                var gd = db.T_UnitXs.GroupBy(p => p.t_unitxdepartmentarea.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "13" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Department Area (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Department Area"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Department Area", "UnitX"));
                chart.Series.Add(CreateSeries(SeriesChartType.Pie, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
								chart.Series[0].LegendText = "#VALX";
				chart.Series[0].Label = "#PERCENT{P2}";
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "13", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
			if (type == "14" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).ToList();
                    if (_yvalT_MaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_MaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_MaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Department Area (Top 10)"));
				else
				chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Department Area"));
                chartT_MaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Department Area", "T_MaleBeds"));
                chartT_MaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_MaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_MaleBeds );
                chartT_MaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_MaleBeds.Width = 800;
                        chartT_MaleBeds.Height = 800;
                    }
                byte[] bytesT_MaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_MaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_MaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_MaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "14", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
                    else
                    {
                        string imgT_MaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
				}
			if (type == "15" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).ToList();
                    if (_yvalT_FemaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_FemaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_FemaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Department Area (Top 10)"));
				else
				chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Department Area"));
                chartT_FemaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Department Area", "T_FemaleBeds"));
                chartT_FemaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_FemaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_FemaleBeds );
                chartT_FemaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_FemaleBeds.Width = 800;
                        chartT_FemaleBeds.Height = 800;
                    }
                byte[] bytesT_FemaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_FemaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_FemaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_FemaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "15", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
                    else
                    {
                        string imgT_FemaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
				}
			if (type == "16" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).ToList();
                    if (_yvalT_TotalBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_TotalBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_TotalBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Department Area (Top 10)"));
				else
				chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Department Area"));
                chartT_TotalBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Department Area", "T_TotalBeds"));
                chartT_TotalBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_TotalBeds.Series[0].Points.DataBindXY(_xval, _yvalT_TotalBeds );
                chartT_TotalBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_TotalBeds.Width = 800;
                        chartT_TotalBeds.Height = 800;
                    }
                byte[] bytesT_TotalBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_TotalBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_TotalBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_TotalBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "16", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
                    else
                    {
                        string imgT_TotalBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
				}
            }
           {
                var gd = db.T_UnitXs.GroupBy(p => p.t_wardorgcode.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "17" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Org Code (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Org Code"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Org Code", "UnitX"));
                chart.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "17", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
			if (type == "18" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).ToList();
                    if (_yvalT_MaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_MaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_MaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Org Code (Top 10)"));
				else
				chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Org Code"));
                chartT_MaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Org Code", "T_MaleBeds"));
                chartT_MaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_MaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_MaleBeds );
                chartT_MaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_MaleBeds.Width = 800;
                        chartT_MaleBeds.Height = 800;
                    }
                byte[] bytesT_MaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_MaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_MaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_MaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "18", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
                    else
                    {
                        string imgT_MaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
				}
			if (type == "19" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).ToList();
                    if (_yvalT_FemaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_FemaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_FemaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Org Code (Top 10)"));
				else
				chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Org Code"));
                chartT_FemaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Org Code", "T_FemaleBeds"));
                chartT_FemaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_FemaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_FemaleBeds );
                chartT_FemaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_FemaleBeds.Width = 800;
                        chartT_FemaleBeds.Height = 800;
                    }
                byte[] bytesT_FemaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_FemaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_FemaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_FemaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "19", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
                    else
                    {
                        string imgT_FemaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
				}
			if (type == "20" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).ToList();
                    if (_yvalT_TotalBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_TotalBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_TotalBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Org Code (Top 10)"));
				else
				chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Org Code"));
                chartT_TotalBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Org Code", "T_TotalBeds"));
                chartT_TotalBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_TotalBeds.Series[0].Points.DataBindXY(_xval, _yvalT_TotalBeds );
                chartT_TotalBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_TotalBeds.Width = 800;
                        chartT_TotalBeds.Height = 800;
                    }
                byte[] bytesT_TotalBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_TotalBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_TotalBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_TotalBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "20", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
                    else
                    {
                        string imgT_TotalBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
				}
            }
           {
                var gd = db.T_UnitXs.GroupBy(p => p.t_unitxfloor.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "21" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Floor (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Floor"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Floor", "UnitX"));
                chart.Series.Add(CreateSeries(SeriesChartType.Pie, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
								chart.Series[0].LegendText = "#VALX";
				chart.Series[0].Label = "#PERCENT{P2}";
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "21", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
			if (type == "22" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).ToList();
                    if (_yvalT_MaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_MaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_MaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Floor (Top 10)"));
				else
				chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Floor"));
                chartT_MaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Floor", "T_MaleBeds"));
                chartT_MaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_MaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_MaleBeds );
                chartT_MaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_MaleBeds.Width = 800;
                        chartT_MaleBeds.Height = 800;
                    }
                byte[] bytesT_MaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_MaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_MaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_MaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "22", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
                    else
                    {
                        string imgT_MaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
				}
			if (type == "23" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).ToList();
                    if (_yvalT_FemaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_FemaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_FemaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Floor (Top 10)"));
				else
				chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Floor"));
                chartT_FemaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Floor", "T_FemaleBeds"));
                chartT_FemaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_FemaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_FemaleBeds );
                chartT_FemaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_FemaleBeds.Width = 800;
                        chartT_FemaleBeds.Height = 800;
                    }
                byte[] bytesT_FemaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_FemaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_FemaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_FemaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "23", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
                    else
                    {
                        string imgT_FemaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
				}
			if (type == "24" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).ToList();
                    if (_yvalT_TotalBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_TotalBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_TotalBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Floor (Top 10)"));
				else
				chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Floor"));
                chartT_TotalBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Floor", "T_TotalBeds"));
                chartT_TotalBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_TotalBeds.Series[0].Points.DataBindXY(_xval, _yvalT_TotalBeds );
                chartT_TotalBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_TotalBeds.Width = 800;
                        chartT_TotalBeds.Height = 800;
                    }
                byte[] bytesT_TotalBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_TotalBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_TotalBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_TotalBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "24", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
                    else
                    {
                        string imgT_TotalBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
				}
            }
           {
                var gd = db.T_UnitXs.GroupBy(p => p.t_employeeadministrator.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "25" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Administrator (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Administrator"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Administrator", "UnitX"));
                chart.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "25", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
			if (type == "26" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).ToList();
                    if (_yvalT_MaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_MaleBeds = gd.Select(k => k.Sum(p=>p.T_MaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_MaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_MaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Administrator (Top 10)"));
				else
				chartT_MaleBeds.Titles.Add(CreateTitle("Total of Male Beds by Administrator"));
                chartT_MaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Administrator", "T_MaleBeds"));
                chartT_MaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_MaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_MaleBeds );
                chartT_MaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_MaleBeds.Width = 800;
                        chartT_MaleBeds.Height = 800;
                    }
                byte[] bytesT_MaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_MaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_MaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_MaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "26", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
                    else
                    {
                        string imgT_MaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_MaleBeds = Convert.ToBase64String(bytesT_MaleBeds.ToArray());
                        result += String.Format(imgT_MaleBeds, encodedT_MaleBeds);
                    }
				}
			if (type == "27" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).ToList();
                    if (_yvalT_FemaleBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_FemaleBeds = gd.Select(k => k.Sum(p=>p.T_FemaleBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_FemaleBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_FemaleBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Administrator (Top 10)"));
				else
				chartT_FemaleBeds.Titles.Add(CreateTitle("Total of Female Beds by Administrator"));
                chartT_FemaleBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Administrator", "T_FemaleBeds"));
                chartT_FemaleBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_FemaleBeds.Series[0].Points.DataBindXY(_xval, _yvalT_FemaleBeds );
                chartT_FemaleBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_FemaleBeds.Width = 800;
                        chartT_FemaleBeds.Height = 800;
                    }
                byte[] bytesT_FemaleBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_FemaleBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_FemaleBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_FemaleBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "27", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
                    else
                    {
                        string imgT_FemaleBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_FemaleBeds = Convert.ToBase64String(bytesT_FemaleBeds.ToArray());
                        result += String.Format(imgT_FemaleBeds, encodedT_FemaleBeds);
                    }
				}
			if (type == "28" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).ToList();
                    if (_yvalT_TotalBeds .Count > 10 && inlarge == null)
                    {
                        _yvalT_TotalBeds = gd.Select(k => k.Sum(p=>p.T_TotalBeds)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_TotalBeds  = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chartT_TotalBeds.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Administrator (Top 10)"));
				else
				chartT_TotalBeds.Titles.Add(CreateTitle("Total of Total Beds by Administrator"));
                chartT_TotalBeds.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Administrator", "T_TotalBeds"));
                chartT_TotalBeds.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_TotalBeds.Series[0].Points.DataBindXY(_xval, _yvalT_TotalBeds );
                chartT_TotalBeds.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_TotalBeds.Width = 800;
                        chartT_TotalBeds.Height = 800;
                    }
                byte[] bytesT_TotalBeds;
                using (var chartimage = new MemoryStream())
                {
                    chartT_TotalBeds.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_TotalBeds = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_TotalBeds = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_UnitX", new { type = "28", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
                    else
                    {
                        string imgT_TotalBeds = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_TotalBeds = Convert.ToBase64String(bytesT_TotalBeds.ToArray());
                        result += String.Format(imgT_TotalBeds, encodedT_TotalBeds);
                    }
				}
            }
			 return result;
	    }
		#region Chart Methods
        public Title CreateTitle(string charttitle)
        {
            Title title = new Title();
            title.Text = charttitle;
            title.Font = new System.Drawing.Font("Helvetica", 10F, System.Drawing.FontStyle.Regular);
            title.ForeColor = System.Drawing.Color.FromArgb(26, 59, 105);
            return title;
        }
        public Legend CreateLegend(string chartlegend)
        {
            Legend legend = new Legend();
            legend.Title = chartlegend;
            legend.Font = new System.Drawing.Font("Helvetica", 8F, System.Drawing.FontStyle.Regular);
            legend.ForeColor = System.Drawing.Color.FromArgb(26, 59, 105);
            legend.Docking = Docking.Bottom;
            legend.Alignment = System.Drawing.StringAlignment.Center;
            return legend;
        }
        public Series CreateSeries(SeriesChartType chartType, string chartseries)
        {
            Series seriesDetail = new Series();
            seriesDetail.Name = chartseries;
            seriesDetail.IsValueShownAsLabel = false;
            if (chartType == SeriesChartType.Column)
                seriesDetail.IsVisibleInLegend = false;
            seriesDetail.ChartType = chartType;
            seriesDetail.BorderWidth = 2;
            seriesDetail.ChartArea = chartseries;
            return seriesDetail;
        }
        public ChartArea CreateChartArea(SeriesChartType chartType, string chartarea, string xtitle, string ytitle)
        {
            ChartArea chartArea = new ChartArea();
            chartArea.Name = chartarea;
            chartArea.BackColor = System.Drawing.Color.Transparent;
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisY.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Helvetica", 8F, System.Drawing.FontStyle.Regular);
            chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Helvetica", 8F, System.Drawing.FontStyle.Regular);
            chartArea.AxisY.LineColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.LineColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.Interval = 1;
            if (chartType == SeriesChartType.Column)
                chartArea.AxisX.LabelStyle.Angle = -90;
            chartArea.AxisX.Title = xtitle;
            chartArea.AxisY.Title = ytitle;
            return chartArea;
        }
        #endregion
        public string GetDisplayValue(string id)
        {
			if (string.IsNullOrEmpty(id)) return "";
			long idvalue = Convert.ToInt64(id);
			ApplicationContext db1 = new ApplicationContext(new SystemUser());
            var _Obj = db1.T_UnitXs.FirstOrDefault(p => p.Id == idvalue);
            return  _Obj==null?"":_Obj.DisplayValue;
        }
		public IQueryable<JournalEntry> GetExtraJournalEntry(int? id, Models.IUser user, JournalEntryContext jedb)
        {
			var listjournaliquery = jedb.JournalEntries.Where(p => p.Id == 0);
			Expression<Func<JournalEntry, bool>> predicateJournalEntry = n => false;
		var t_unitx = jedb.T_UnitXs.Find(id);
			var T_JobAssignmentUnitXIds = jedb.T_JobAssignments.Where(p=>p.T_JobAssignmentUnitXID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_JobAssignment" && T_JobAssignmentUnitXIds.Contains(d.RecordId) && d.Type != "View"));
			
			listjournaliquery = new FilteredDbSet<JournalEntry>(jedb, predicateJournalEntry); 
			return listjournaliquery;
        }
		public object GetRecordById(string id)
        {
		            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            if (string.IsNullOrEmpty(id)) return "";
            var _Obj = db1.T_UnitXs.Find(Convert.ToInt64(id));
            return _Obj;
        }
		public string GetRecordById_Reflection(string id)
        {
							ApplicationContext db1 = new ApplicationContext(new SystemUser());
			if (string.IsNullOrEmpty(id)) return "";
			var _Obj = db1.T_UnitXs.Find(Convert.ToInt64(id));
            return _Obj == null ? "" : EntityComparer.EnumeratePropertyValues<T_UnitX>(_Obj, "T_UnitX", new string[] { ""  }); ;
			        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllValueForFilter(string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
		            IQueryable<T_UnitX> list = db.T_UnitXs;
            var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                       select new { Id = x.Id, Name = x.DisplayValue };
            return Json(data, JsonRequestBehavior.AllowGet);
			        }
		[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValue(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_UnitX> list = db.T_UnitXs;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_UnitXs;
					string lambda = "";
                    foreach (var asso in AssoNameWithParent.Split("?".ToCharArray()))
                    {
                        lambda += asso + "=" + AssociationID + " OR ";
                    }
                    lambda = lambda.TrimEnd(" OR ".ToCharArray());
                    query = query.Where(lambda);
                   //Type[] exprArgTypes = { query.ElementType };
                   // string propToWhere = AssoNameWithParent;
                   // ParameterExpression p = Expression.Parameter(typeof(T_UnitX), "p");
                   // MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                   // LambdaExpression lambda = Expression.Lambda<Func<T_UnitX, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                   // MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                   // IQueryable q = query.Provider.CreateQuery(methodCall);
                   //list = ((IQueryable<T_UnitX>)q);
				   list = ((IQueryable<T_UnitX>)query);
                }
				else if (AssoID == 0)
                {
                   IQueryable query = db.T_UnitXs;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_UnitX), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_UnitX, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_UnitX>)q);
                }
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_UnitX>(User,list, "T_UnitX",caller);
		   if (key != null && key.Length > 0)
            {
			    if (ExtraVal != null && ExtraVal.Length > 0)
                {
                    long? val = Convert.ToInt64(ExtraVal);
                    var data = from x in list.Where(p => p.DisplayValue.Contains(key) && p.Id != val).Take(9).Union(list.Where(p=>p.Id == val)).OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var data = from x in list.Where(p => p.DisplayValue.Contains(key)).OrderBy(q => q.DisplayValue).Take(10).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
               if (ExtraVal != null && ExtraVal.Length > 0)
                {
                    long? val = Convert.ToInt64(ExtraVal);
                     var data = from x in list.Where(p=>p.Id != val).Take(9).Union(list.Where(p=>p.Id == val)).Distinct().OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }                
                else
                {
                    var data = from x in list.OrderBy(q => q.DisplayValue).Take(10).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
        }
		[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValueForRB(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_UnitX> list = db.T_UnitXs;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_UnitXs;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_UnitX), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_UnitX, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_UnitX>)q);
                }
            }
			var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
        }
[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValueMobile(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_UnitX> list = db.T_UnitXs;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
				try
                {
					Nullable<long> AssoID = Convert.ToInt64(AssociationID);
					if (AssoID != null && AssoID > 0)
					{
						IQueryable query = db.T_UnitXs;
						Type[] exprArgTypes = { query.ElementType };
						string propToWhere = AssoNameWithParent;
						ParameterExpression p = Expression.Parameter(typeof(T_UnitX), "p");
						MemberExpression member = Expression.PropertyOrField(p, propToWhere);
						LambdaExpression lambda = Expression.Lambda<Func<T_UnitX, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
						MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
						IQueryable q = query.Provider.CreateQuery(methodCall);
						list = ((IQueryable<T_UnitX>)q).Take(20);
					}
				}
				catch
                {
                    var data = from x in list.OrderBy(q => q.DisplayValue).Take(20).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
		   FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
           list = _fad.FilterDropdown<T_UnitX>(User,list, "T_UnitX",caller);
		   if (key != null && key.Length > 0)
            {
			    if (ExtraVal != null && ExtraVal.Length > 0)
                {
                    long? val = Convert.ToInt64(ExtraVal);
                    var data = from x in list.Where(p => p.DisplayValue.Contains(key) && p.Id != val).Take(20).Union(list.Where(p=>p.Id == val)).OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var data = from x in list.Where(p => p.DisplayValue.Contains(key)).OrderBy(q => q.DisplayValue).Take(20).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
               if (ExtraVal != null && ExtraVal.Length > 0)
                {
                    long? val = Convert.ToInt64(ExtraVal);
                     var data = from x in list.Where(p=>p.Id != val).Take(20).Union(list.Where(p=>p.Id == val)).Distinct().OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }                
                else
                {
                    var data = from x in list.OrderBy(q => q.DisplayValue).Take(20).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllMultiSelectValueForBR(string propNameBR)
        {
            IQueryable<T_UnitX> list = db.T_UnitXs;
            if (!string.IsNullOrEmpty(propNameBR))
            {
				//added new code (Remove old code if everything works)
				var result = list.Select("new(Id," + propNameBR + " as value)");
                return Json(result, JsonRequestBehavior.AllowGet);
				//
                ParameterExpression param = Expression.Parameter(typeof(T_UnitX), "d");
                //bulid expression tree:data.Field1
                var Property = typeof(T_UnitX).GetProperty(propNameBR);
                Expression selector = Expression.Property(param, Property);
                Expression pred = Expression.Lambda(selector, param);
                //bulid expression tree:Select(d=>d.Field1)
                var targetType = Property.PropertyType;
                if (targetType.GetGenericArguments().Count() > 0)
                {
                    if (targetType.GetGenericArguments()[0].Name == "DateTime")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select", 
                        new Type[] { typeof(T_UnitX), typeof(DateTime?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<DateTime?> query = list.Provider.CreateQuery<DateTime?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (targetType.GetGenericArguments()[0].Name == "Decimal")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_UnitX), typeof(decimal?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<decimal?> query = list.Provider.CreateQuery<decimal?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Boolean")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_UnitX), typeof(bool?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<bool?> query = list.Provider.CreateQuery<bool?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int32")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_UnitX), typeof(Int32?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int32?> query = list.Provider.CreateQuery<Int32?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int64")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_UnitX), typeof(Int64?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int64?> query = list.Provider.CreateQuery<Int64?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Double")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_UnitX), typeof(double?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<double?> query = list.Provider.CreateQuery<double?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    Expression expr = Expression.Call(typeof(Queryable), "Select",
                            new Type[] { typeof(T_UnitX), typeof(string) }, Expression.Constant(list.AsQueryable()), pred);
                    //var result = query.AsEnumerable().Take(10);
                    IQueryable<string> query = list.Provider.CreateQuery<string>(expr).Distinct();
                    return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                }
                return Json(list.AsEnumerable(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = from x in list.OrderBy(q => q.DisplayValue).Take(10).ToList()
                           select new { Id = x.Id, Name = x.DisplayValue };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllMultiSelectValue(string key, string AssoNameWithParent, string AssociationID)
        {
			IQueryable<T_UnitX> list = db.T_UnitXs;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                IQueryable query = db.T_UnitXs;
                Type[] exprArgTypes = { query.ElementType };
                string propToWhere = AssoNameWithParent;
                var AssoIDs = AssociationID.Split(',').ToList();
                List<ParameterExpression> paramList = new List<ParameterExpression>();
                paramList.Add(Expression.Parameter(typeof(T_UnitX), "p"));
                MemberExpression member = Expression.PropertyOrField(paramList[0], propToWhere);
                List<LambdaExpression> lexList = new List<LambdaExpression>();
                Expression ex = null;
                for (int i = 0; i < AssoIDs.Count; i++)
                {
                    if (string.IsNullOrEmpty(AssoIDs[i].ToString()))
                        continue;
                    Nullable<long> AssoID = Convert.ToInt64(AssoIDs[i].ToString());
                    if (i == 0)
                    {
                        Expression bodyInner = Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type));
                        lexList.Add(Expression.Lambda(bodyInner, paramList[0]));
                    }
                    else
                    {
                        ex = Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type));
                        Expression bodyOuter = Expression.Or(lexList[lexList.Count - 1].Body, ex);
                        lexList.Add(Expression.Lambda(bodyOuter, paramList[0]));
                        ex = null;
                    }
                }
                LambdaExpression lambda = (lexList[lexList.Count - 1]);
                MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                IQueryable q = query.Provider.CreateQuery(methodCall);
                list = ((IQueryable<T_UnitX>)q);
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_UnitX>(User, list, "T_UnitX", null);
			if (key != null && key.Length > 0)
            {
			   var data = from x in list.Where(p=>p.DisplayValue.Contains(key)).OrderBy(q=>q.DisplayValue).Take(10).ToList()
                           select new { Id = x.Id, Name = x.DisplayValue };
               return Json(data, JsonRequestBehavior.AllowGet);
            }
			else
			{
				var data = from x in list.OrderBy(q=>q.DisplayValue).Take(10).ToList()
						   select new { Id = x.Id, Name = x.DisplayValue };
				return Json(data, JsonRequestBehavior.AllowGet);
			}
        }
		private DataSet DataImport(string fileExtension, string fileLocation)
        {
            string excelConnectionString = string.Empty;
            if (fileExtension == ".xls")
            {
                excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }
            else if (fileExtension == ".csv")
            {
                excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.IO.Path.GetDirectoryName(fileLocation) + ";Extended Properties=\"Text;HDR=YES;FMT=Delimited\"";
            }
            else if (fileExtension == ".xlsx")
            {
                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            }
            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
            OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);
            excelConnection.Open();
            DataSet objDataSet = new DataSet();
            DataTable dt = null;
            string query = string.Empty;
            String[] excelSheets = null;
            if (fileExtension == ".csv")
            {
                query = "SELECT * FROM [" + System.IO.Path.GetFileName(fileLocation) + "]";
            }
            else
            {
                dt = new DataTable();
                dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                excelSheets = new String[dt.Rows.Count];
                int t = 0;
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[t] = row["TABLE_NAME"].ToString();
                    t++;
                }
                query = string.Format("Select * from [{0}]", excelSheets[0]);
            }
            excelConnection.Close();
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
            {
                dataAdapter.Fill(objDataSet);
            }
            excelConnection1.Close();
            return WithoutBlankRow(objDataSet);
        }
        private DataSet WithoutBlankRow(DataSet ds)
        {
            DataSet dsnew = new DataSet();
            DataTable dt = ds.Tables[0].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field).ToString().Trim(), string.Empty) == 0)).CopyToDataTable();
            dsnew.Tables.Add(dt);
            return dsnew;
        }
		[HttpGet]
        public ActionResult Upload()
        {

			if (!((CustomPrincipal)User).CanUseVerb("ImportExcel", "T_UnitX", User) || !User.CanAdd("T_UnitX"))
            {
                return RedirectToAction("Index", "Error");
            }
            //ViewBag.IsMapping = (db.ImportConfigurations.Where(p => p.Name == "T_UnitX")).Count() > 0 ? true : false;
            var lstMappings = db.ImportConfigurations.Where(p => p.Name == "T_UnitX").ToList();
            var distinctMapping = lstMappings.GroupBy(p => p.MappingName).Distinct();
            List<ImportConfiguration> ddlMappingList = new List<ImportConfiguration>();
            foreach (var elem in distinctMapping)
            {
                ddlMappingList.Add(elem.FirstOrDefault());
            }
            var DefaultMapping = lstMappings.Where(p => p.IsDefaultMapping).FirstOrDefault();
            var mappingID = DefaultMapping == null ? "" : DefaultMapping.MappingName;
            ViewBag.IsDefaultMapping = DefaultMapping != null ? true : false;
            //ViewBag.ListOfMappings = new SelectList(ddlMappingList, "ID", "MappingName", mappingID);
			ViewBag.ListOfMappings = new SelectList(ddlMappingList, "MappingName", "MappingName", mappingID);
			ViewBag.Title = "Upload File";
            return View();
        }
		[AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
         public ActionResult Upload([Bind(Include = "FileUpload")] HttpPostedFileBase FileUpload, FormCollection collection)
        {
            if (FileUpload != null)
            {
                 string fileExtension = System.IO.Path.GetExtension(FileUpload.FileName).ToLower();
                if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv" || fileExtension == ".all")
                {
					string rename = string.Empty;
                    if (fileExtension == ".all")
                    {
                        rename = System.IO.Path.GetFileName(FileUpload.FileName.ToLower().Replace(fileExtension, ".csv"));
                        fileExtension = ".csv";
                    }
                    else
                        rename = System.IO.Path.GetFileName(FileUpload.FileName);
                    string fileLocation = string.Format("{0}\\{1}", Server.MapPath("~/ExcelFiles"), rename);
                    if (System.IO.File.Exists(fileLocation))
                        System.IO.File.Delete(fileLocation);
                    FileUpload.SaveAs(fileLocation);
                    DataSet objDataSet = DataImport(fileExtension, fileLocation);
                    var col = new List<SelectListItem>();
                    if (objDataSet.Tables.Count > 0)
                    {
                        int iCols = objDataSet.Tables[0].Columns.Count;
                        if (iCols > 0)
                        {
                            for (int i = 0; i < iCols; i++)
                            {
                                col.Add(new SelectListItem { Value = (i + 1).ToString(), Text = objDataSet.Tables[0].Columns[i].Caption });
                            }
                        }
                    }
                    col.Insert(0, new SelectListItem { Value = "", Text = "Select Column" });
					Dictionary<GeneratorBase.MVC.ModelReflector.Association, SelectList> objColMapAssocProperties = new Dictionary<GeneratorBase.MVC.ModelReflector.Association, SelectList>();
                    Dictionary<GeneratorBase.MVC.ModelReflector.Property, SelectList> objColMap = new Dictionary<GeneratorBase.MVC.ModelReflector.Property, SelectList>();
                    var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_UnitX");
                    if (entList != null)
                    {
                        foreach (var prop in entList.Properties.Where(p => p.Name != "DisplayValue"))
                        {
                            long selectedVal = 0;
                            var colSelected = col.FirstOrDefault(p=> p.Text.Trim().ToLower() == prop.DisplayName.Trim().ToLower());
                            if (colSelected != null)
                                selectedVal = long.Parse(colSelected.Value);
                            objColMap.Add(prop, new SelectList(col,"Value", "Text", selectedVal));
                        }
						List<GeneratorBase.MVC.ModelReflector.Association> assocList = entList.Associations;
                        if (assocList != null)
                        {
                            foreach (var assoc in assocList)
                            {
								if(assoc.Target == "IdentityUser")
									continue;
                                Dictionary<string, string> lstProperty = new Dictionary<string, string>();
                                var assocEntity = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(p => p.Name == assoc.Target);
                                var assocProperties = assocEntity.Properties.Where(p => p.Name != "DisplayValue");
                                lstProperty.Add("DisplayValue", "DisplayValue-" + assoc.AssociationProperty);
                                foreach (var prop in assocProperties)
                                {
                                    lstProperty.Add(prop.DisplayName, prop.DisplayName + "-" + assoc.AssociationProperty);
                                }
                                var dispValue = lstProperty.Keys.FirstOrDefault();
                                objColMapAssocProperties.Add(assoc, new SelectList(lstProperty.AsEnumerable(), "Value", "Key", "Key"));
                            }
                        }
                    }
					 ViewBag.AssociatedProperties = objColMapAssocProperties;
                    ViewBag.ColumnMapping = objColMap;
                    ViewBag.FilePath = fileLocation;
					if (!string.IsNullOrEmpty(collection["ListOfMappings"]))
                    {
                        string typeName = "";
                        string colKey = "";
                        string colDisKey = "";
                        string colListInx = "";
                        typeName = "T_UnitX";
                        //var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        //long idMapping = Convert.ToInt64(collection["ListOfMappings"]);
						string idMapping = collection["ListOfMappings"];
                        string ExistsColumnMappingName = string.Empty;
                        string mappingName = idMapping; //db.ImportConfigurations.Where(p => p.Name == typeName && p.Id == idMapping && !(string.IsNullOrEmpty(p.SheetColumn))).FirstOrDefault().MappingName;
                        var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && p.MappingName == mappingName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        if (collection["DefaultMapping"] == "on")
                        {
                            var lstMapping = db.ImportConfigurations.Where(p => p.Name == "T_UnitX" && p.IsDefaultMapping);
                            if (lstMapping.Count() > 0)
                            {
                                foreach (var mapping in lstMapping)
                                {
                                    mapping.IsDefaultMapping = false;
                                    db.Entry(mapping).State = EntityState.Modified;
                                }
                            }
                            foreach (var defaultMapping in DefaultMapping)
                            {
                                defaultMapping.IsDefaultMapping = true;
                                db.Entry(defaultMapping).State = EntityState.Modified;
                            }
                        }
                        db.SaveChanges();
                        foreach (var defcol in ViewBag.ColumnMapping as Dictionary<GeneratorBase.MVC.ModelReflector.Property, SelectList>)
                        {
                            colDisKey = colDisKey + defcol.Key.DisplayName + ",";
                            colKey = colKey + defcol.Key.Name + ",";
                            string colSelected = (DefaultMapping.ToList().Where(p => p.TableColumn == defcol.Key.DisplayName).Count() > 0 ? DefaultMapping.ToList().Where(p => p.TableColumn == defcol.Key.DisplayName).FirstOrDefault().SheetColumn : null);
                            int colExist = 0;
                            if (!string.IsNullOrEmpty(colSelected))
                            {
                                colExist = defcol.Value.Where(s => s.Text.Trim() == colSelected.Trim()).Count();
                                if (colExist == 0)
                                    ExistsColumnMappingName += defcol.Key.DisplayName + " - " + colSelected + ", ";
                                colListInx = colListInx + (colExist > 0 ? defcol.Value.Where(s => s.Text.Trim() == colSelected.Trim()).First().Value.ToString() : "") + ",";
                            }
                            else
                                colListInx = colListInx + "" + ",";
                        }
                        if (colKey != "")
                            colKey = colKey.Substring(0, colKey.Length - 1);
                        if (colDisKey != "")
                            colDisKey = colDisKey.Substring(0, colDisKey.Length - 1);
                        if (colListInx != "")
                            colListInx = colListInx.Substring(0, colListInx.Length - 1);
                        if (!string.IsNullOrEmpty(ExistsColumnMappingName))
                            ExistsColumnMappingName = ExistsColumnMappingName.Trim().Substring(0, ExistsColumnMappingName.Trim().Length - 1);
                        string FilePath = ViewBag.FilePath;
                        var columnlist = colKey;
                        var columndisplaynamelist = colDisKey;
                        var selectedlist = colListInx;
                        string DefaultColumnMappingName = string.Empty;
                        if (DefaultMapping.Count > 0)
                            DefaultColumnMappingName = String.Join(", ", DefaultMapping.OrderByDescending(p => p.Id).Select(p => p.TableColumn));
                        ViewBag.DefaultMappingMsg = null;
                        if (DefaultMapping.Count() != colListInx.Split(',').Where(p => p.Trim() != string.Empty).Count())
                        {
                            ViewBag.DefaultMappingMsg += "There was an ERROR in file being uploaded: It does not contain all the required columns.";
                            ViewBag.DefaultMappingMsg += "<br /><br /> Error Details: <br /> The following columns are missing : " + ExistsColumnMappingName;
                            ViewBag.DefaultMappingMsg += "<br /><br /> Please verify the file and upload again. No data has currently been imported and NO change has been made.";
                        }
                        string DetailMessage = "";
                        string excelConnectionString = string.Empty;
                        DataTable tempdt = new DataTable();
                        if (selectedlist != null && columnlist != null)
                        {
                            var dtsheetColumns = selectedlist.Split(',').ToList();
                            var dttblColumns = columndisplaynamelist.Split(',').ToList();
                            for (int j = 0; j < dtsheetColumns.Count; j++)
                            {
                                string columntable = dttblColumns[j];
                                int columnSheet = 0;
                                if (string.IsNullOrEmpty(dtsheetColumns[j]))
                                    continue;
                                else
                                    columnSheet = Convert.ToInt32(dtsheetColumns[j]) - 1;
                                tempdt.Columns.Add(columntable);
                            }
                            for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                            {
                                var sheetColumns = selectedlist.Split(',').ToList();
                                if (AreAllColumnsEmpty(objDataSet.Tables[0].Rows[i], sheetColumns))
                                    continue;
                                var tblColumns = columndisplaynamelist.Split(',').ToList();
                                DataRow objdr = tempdt.NewRow();
                                for (int j = 0; j < sheetColumns.Count; j++)
                                {
                                    string columntable = tblColumns[j];
                                    int columnSheet = 0;
                                    if (string.IsNullOrEmpty(sheetColumns[j]))
                                        continue;
                                    else
                                        columnSheet = Convert.ToInt32(sheetColumns[j]) - 1;
                                    string columnValue = objDataSet.Tables[0].Rows[i][columnSheet].ToString().Trim();
                                    if (string.IsNullOrEmpty(columnValue))
                                        continue;
                                    objdr[columntable] = columnValue;
                                }
                                tempdt.Rows.Add(objdr);
                            }
                        }
                        DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new UnitXs";
                        Dictionary<GeneratorBase.MVC.ModelReflector.Association, List<String>> objAssoUnique = new Dictionary<GeneratorBase.MVC.ModelReflector.Association, List<String>>();
                        if (entList != null)
                        {
                            DataTable uniqueCols = new DataTable();
                            foreach (var association in entList.Associations)
                            {
                                if (!tempdt.Columns.Contains(association.DisplayName))
                                    continue;
                                uniqueCols = tempdt.DefaultView.ToTable(true, association.DisplayName);
                                List<String> uniqueassoValues = new List<String>();
                                for (int i = 0; i < uniqueCols.Rows.Count; i++)
                                {
                                    string assovalue = "";
                                    if (string.IsNullOrEmpty(uniqueCols.Rows[i][0].ToString().Trim()))
                                        continue;
                                    else
                                        assovalue = uniqueCols.Rows[i][0].ToString();
                                    #region Association Values
                                    switch (association.AssociationProperty)
                                    {
                                										 case "T_FacilityUnitXID":
										 var t_facilityunitxId = db.T_Facilitys.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_facilityunitxId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_UnitXUnitAssociationID":
										 var t_unitxunitassociationId = db.T_Units.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_unitxunitassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_WardDepartmentID":
										 var t_warddepartmentId = db.T_Departments.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_warddepartmentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_UnitXDepartmentAreaID":
										 var t_unitxdepartmentareaId = db.T_DepartmentAreas.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_unitxdepartmentareaId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_WardOrgCodeID":
										 var t_wardorgcodeId = db.T_OrgCodess.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_wardorgcodeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_UnitXFloorID":
										 var t_unitxfloorId = db.T_Floors.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_unitxfloorId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeAdministratorID":
										 var t_employeeadministratorId = db.T_Employees.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeadministratorId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeUnitXHeadID":
										 var t_employeeunitxheadId = db.T_Employees.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeunitxheadId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_WardCostCenterID":
										 var t_wardcostcenterId = db.T_CostCenters.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_wardcostcenterId == null)
											uniqueassoValues.Add(assovalue);
										 break;
								                                        default:
                                            break;
                                    }
                                    #endregion
                                }
                                if (uniqueassoValues.Count > 0)
                                {
                                    DetailMessage += ", " + uniqueassoValues.Count() + " <b>new " + (association.DisplayName.EndsWith("s") ? association.DisplayName + "</b>" : association.DisplayName + "s</b>");
                                    objAssoUnique.Add(association, uniqueassoValues.ToList());
                                    if (!User.CanAdd(association.Target) && ViewBag.Confirm == null)
                                        ViewBag.Confirm = true;
                                }
                            }
                            if (objAssoUnique.Count > 0)
                                ViewBag.AssoUnique = objAssoUnique;
                            if (!string.IsNullOrEmpty(DetailMessage))
                                ViewBag.DetailMessage = DetailMessage + " in the Excel file. Please review the data below, before we import it into the system.";
                            ViewBag.ColumnMapping = null;
                            ViewBag.FilePath = FilePath;
                            ViewBag.ColumnList = columnlist;
                            ViewBag.SelectedList = selectedlist;
                            ViewBag.ConfirmImportData = tempdt;
                            if (ViewBag.ConfirmImportData != null)
                            {
                                ViewBag.Title = "Data Preview";
                                return View("Upload");
                            }
                            else
                                return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Plese select Excel File.");
                }
            }
			ViewBag.Title = "Column Mapping";
            return View("Upload");
        }
		  [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult ConfirmImportData(FormCollection collection)
        {
            string FilePath = collection["hdnFilePath"];
            var columnlist = collection["lblColumn"];
            var columndisplaynamelist = collection["lblColumnDisplayName"];
            var selectedlist = collection["colList"];
			var selectedAssocPropList = collection["colAssocPropList"];
			bool SaveMapping = collection["SaveMapping"] == "on" ? true : false;
			string mappingName = collection["MappingName"];
            string DetailMessage = "";
            string fileLocation = FilePath;
            string excelConnectionString = string.Empty;
			string typename = "T_UnitX";
            string fileExtension = System.IO.Path.GetExtension(fileLocation).ToLower();
            if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv")
            {
                DataSet objDataSet = DataImport(fileExtension, fileLocation);
				if (!String.IsNullOrEmpty(mappingName))
                {
					if (SaveMapping)
					{
						var lstMapping = db.ImportConfigurations.Where(p => p.Name == typename && p.IsDefaultMapping);
						if (lstMapping.Count() > 0)
						{
							foreach (var mapping in lstMapping)
							{
								mapping.IsDefaultMapping = false;
								db.Entry(mapping).State = EntityState.Modified;
							}
						}
					}
					var tblcols = columndisplaynamelist.Split(',').ToList();
					var shtcols = selectedlist.Split(',').ToList();
					var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typename).ToList();
					for (int i = 0; i < tblcols.Count(); i++)
					{
						ImportConfiguration objImtConfig = null;
						string shtcolName = string.IsNullOrEmpty(shtcols[i]) ? "" : objDataSet.Tables[0].Columns[int.Parse(shtcols[i]) - 1].Caption;
						objImtConfig = new ImportConfiguration();
						objImtConfig.Name = typename;
						objImtConfig.MappingName = mappingName;
						objImtConfig.IsDefaultMapping = SaveMapping;
						objImtConfig.TableColumn = tblcols[i];
						objImtConfig.SheetColumn = shtcolName;                          
						db.ImportConfigurations.Add(objImtConfig);
					}
					db.SaveChanges();
				}
                DataTable tempdt = new DataTable();
                if (selectedlist != null && columnlist != null)
                {
                    var dtsheetColumns = selectedlist.Split(',').ToList();
                    var dttblColumns = columndisplaynamelist.Split(',').ToList();
                    for (int j = 0; j < dtsheetColumns.Count; j++)
                    {
                        string columntable = dttblColumns[j];
                        int columnSheet = 0;
                        if (string.IsNullOrEmpty(dtsheetColumns[j]))
                            continue;
                        else
                            columnSheet = Convert.ToInt32(dtsheetColumns[j]) - 1;
                        tempdt.Columns.Add(columntable);
                    }
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        var sheetColumns = selectedlist.Split(',').ToList();
                        if (AreAllColumnsEmpty(objDataSet.Tables[0].Rows[i], sheetColumns))
                            continue;
                        var tblColumns = columndisplaynamelist.Split(',').ToList();
                        DataRow objdr = tempdt.NewRow();
                        for (int j = 0; j < sheetColumns.Count; j++)
                        {
                            string columntable = tblColumns[j];
                            int columnSheet = 0;
                            if (string.IsNullOrEmpty(sheetColumns[j]))
                                continue;
                            else
                                columnSheet = Convert.ToInt32(sheetColumns[j]) - 1;
                            string columnValue = objDataSet.Tables[0].Rows[i][columnSheet].ToString().Trim();
                            if (string.IsNullOrEmpty(columnValue))
                                continue;
							if (CustomImportDataValidate(objDataSet, objDataSet.Tables[0].Columns[columnSheet].ColumnName, columnValue))
								objdr[columntable] = columnValue;   
                        }
                        tempdt.Rows.Add(objdr);
                    }
                }
                DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new UnitXs";
				Dictionary<string, string> lstEntityProp = new Dictionary<string, string>();
				if (!string.IsNullOrEmpty(selectedAssocPropList))
				{
					var entitypropList = selectedAssocPropList.Split(',');
					foreach (var prop in entitypropList)
					{
						var lst = prop.Split('-');
						lstEntityProp.Add(lst[1], lst[0]);
					}
				}
                Dictionary<GeneratorBase.MVC.ModelReflector.Association, List<String>> objAssoUnique = new Dictionary<GeneratorBase.MVC.ModelReflector.Association, List<String>>();
                var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_UnitX");
                if (entList != null)
                {
                    DataTable uniqueCols = new DataTable();
                    foreach (var association in entList.Associations)
                    {
                        if (!tempdt.Columns.Contains(association.DisplayName))
                            continue;
                        uniqueCols = tempdt.DefaultView.ToTable(true, association.DisplayName);
                        List<String> uniqueassoValues = new List<String>();
                        for (int i = 0; i < uniqueCols.Rows.Count; i++)
                        {
                            string assovalue = "";
                            if (string.IsNullOrEmpty(uniqueCols.Rows[i][0].ToString().Trim()))
                                continue;
                            else
                                assovalue = uniqueCols.Rows[i][0].ToString();
                            #region Association Values
                            switch (association.AssociationProperty)
                            {
                                										 case "T_FacilityUnitXID":
										 var strPropertyT_FacilityUnitX = lstEntityProp.FirstOrDefault(p => p.Key == "T_FacilityUnitXID").Value;
										 ModelReflector.Property propT_FacilityUnitX = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Facility").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_FacilityUnitX);
										 //var elementTypeT_FacilityUnitX = db.T_Facilitys.ElementType;
										 //var propertyInfoT_FacilityUnitX = elementTypeT_FacilityUnitX.GetProperty(propT_FacilityUnitX.Name);
										 // var t_facilityunitxId = db.T_Facilitys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_FacilityUnitX.GetValue(p, null)) == assovalue);
										 var t_facilityunitxId = db.T_Facilitys.Where(propT_FacilityUnitX.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_facilityunitxId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_UnitXUnitAssociationID":
										 var strPropertyT_UnitXUnitAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_UnitXUnitAssociationID").Value;
										 ModelReflector.Property propT_UnitXUnitAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Unit").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_UnitXUnitAssociation);
										 //var elementTypeT_UnitXUnitAssociation = db.T_Units.ElementType;
										 //var propertyInfoT_UnitXUnitAssociation = elementTypeT_UnitXUnitAssociation.GetProperty(propT_UnitXUnitAssociation.Name);
										 // var t_unitxunitassociationId = db.T_Units.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_UnitXUnitAssociation.GetValue(p, null)) == assovalue);
										 var t_unitxunitassociationId = db.T_Units.Where(propT_UnitXUnitAssociation.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_unitxunitassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_WardDepartmentID":
										 var strPropertyT_WardDepartment = lstEntityProp.FirstOrDefault(p => p.Key == "T_WardDepartmentID").Value;
										 ModelReflector.Property propT_WardDepartment = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Department").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_WardDepartment);
										 //var elementTypeT_WardDepartment = db.T_Departments.ElementType;
										 //var propertyInfoT_WardDepartment = elementTypeT_WardDepartment.GetProperty(propT_WardDepartment.Name);
										 // var t_warddepartmentId = db.T_Departments.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_WardDepartment.GetValue(p, null)) == assovalue);
										 var t_warddepartmentId = db.T_Departments.Where(propT_WardDepartment.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_warddepartmentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_UnitXDepartmentAreaID":
										 var strPropertyT_UnitXDepartmentArea = lstEntityProp.FirstOrDefault(p => p.Key == "T_UnitXDepartmentAreaID").Value;
										 ModelReflector.Property propT_UnitXDepartmentArea = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_DepartmentArea").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_UnitXDepartmentArea);
										 //var elementTypeT_UnitXDepartmentArea = db.T_DepartmentAreas.ElementType;
										 //var propertyInfoT_UnitXDepartmentArea = elementTypeT_UnitXDepartmentArea.GetProperty(propT_UnitXDepartmentArea.Name);
										 // var t_unitxdepartmentareaId = db.T_DepartmentAreas.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_UnitXDepartmentArea.GetValue(p, null)) == assovalue);
										 var t_unitxdepartmentareaId = db.T_DepartmentAreas.Where(propT_UnitXDepartmentArea.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_unitxdepartmentareaId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_WardOrgCodeID":
										 var strPropertyT_WardOrgCode = lstEntityProp.FirstOrDefault(p => p.Key == "T_WardOrgCodeID").Value;
										 ModelReflector.Property propT_WardOrgCode = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_OrgCodes").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_WardOrgCode);
										 //var elementTypeT_WardOrgCode = db.T_OrgCodess.ElementType;
										 //var propertyInfoT_WardOrgCode = elementTypeT_WardOrgCode.GetProperty(propT_WardOrgCode.Name);
										 // var t_wardorgcodeId = db.T_OrgCodess.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_WardOrgCode.GetValue(p, null)) == assovalue);
										 var t_wardorgcodeId = db.T_OrgCodess.Where(propT_WardOrgCode.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_wardorgcodeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_UnitXFloorID":
										 var strPropertyT_UnitXFloor = lstEntityProp.FirstOrDefault(p => p.Key == "T_UnitXFloorID").Value;
										 ModelReflector.Property propT_UnitXFloor = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Floor").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_UnitXFloor);
										 //var elementTypeT_UnitXFloor = db.T_Floors.ElementType;
										 //var propertyInfoT_UnitXFloor = elementTypeT_UnitXFloor.GetProperty(propT_UnitXFloor.Name);
										 // var t_unitxfloorId = db.T_Floors.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_UnitXFloor.GetValue(p, null)) == assovalue);
										 var t_unitxfloorId = db.T_Floors.Where(propT_UnitXFloor.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_unitxfloorId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeAdministratorID":
										 var strPropertyT_EmployeeAdministrator = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeAdministratorID").Value;
										 ModelReflector.Property propT_EmployeeAdministrator = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeAdministrator);
										 //var elementTypeT_EmployeeAdministrator = db.T_Employees.ElementType;
										 //var propertyInfoT_EmployeeAdministrator = elementTypeT_EmployeeAdministrator.GetProperty(propT_EmployeeAdministrator.Name);
										 // var t_employeeadministratorId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeAdministrator.GetValue(p, null)) == assovalue);
										 var t_employeeadministratorId = db.T_Employees.Where(propT_EmployeeAdministrator.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeadministratorId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeUnitXHeadID":
										 var strPropertyT_EmployeeUnitXHead = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeUnitXHeadID").Value;
										 ModelReflector.Property propT_EmployeeUnitXHead = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeUnitXHead);
										 //var elementTypeT_EmployeeUnitXHead = db.T_Employees.ElementType;
										 //var propertyInfoT_EmployeeUnitXHead = elementTypeT_EmployeeUnitXHead.GetProperty(propT_EmployeeUnitXHead.Name);
										 // var t_employeeunitxheadId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeUnitXHead.GetValue(p, null)) == assovalue);
										 var t_employeeunitxheadId = db.T_Employees.Where(propT_EmployeeUnitXHead.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeunitxheadId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_WardCostCenterID":
										 var strPropertyT_WardCostCenter = lstEntityProp.FirstOrDefault(p => p.Key == "T_WardCostCenterID").Value;
										 ModelReflector.Property propT_WardCostCenter = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_CostCenter").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_WardCostCenter);
										 //var elementTypeT_WardCostCenter = db.T_CostCenters.ElementType;
										 //var propertyInfoT_WardCostCenter = elementTypeT_WardCostCenter.GetProperty(propT_WardCostCenter.Name);
										 // var t_wardcostcenterId = db.T_CostCenters.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_WardCostCenter.GetValue(p, null)) == assovalue);
										 var t_wardcostcenterId = db.T_CostCenters.Where(propT_WardCostCenter.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_wardcostcenterId == null)
											uniqueassoValues.Add(assovalue);
										 break;
								                                default:
                                    break;
                            }
                            #endregion
                        }
                        if (uniqueassoValues.Count > 0)
                        {
							 DetailMessage += ", " + uniqueassoValues.Count() + " <b>new " + (association.DisplayName.EndsWith("s") ? association.DisplayName + "</b>" : association.DisplayName + "s</b>");
                            objAssoUnique.Add(association, uniqueassoValues.ToList());
                            if (!User.CanAdd(association.Target) && ViewBag.Confirm == null)
                                ViewBag.Confirm = true;
                        }
                    }
                }
                if (objAssoUnique.Count > 0)
                    ViewBag.AssoUnique = objAssoUnique;
                if (!string.IsNullOrEmpty(DetailMessage))
                    ViewBag.DetailMessage = DetailMessage + " in the Excel file. Please review the data below, before we import it into the system.";
                ViewBag.FilePath = FilePath;
                ViewBag.ColumnList = columnlist;
                ViewBag.SelectedList = selectedlist;
                ViewBag.ConfirmImportData = tempdt;
				ViewBag.colAssocPropList = selectedAssocPropList;
                if (ViewBag.ConfirmImportData != null){
                    ViewBag.Title = "Data Preview";
                    return View("Upload");
				}
                else
                    return RedirectToAction("Index");
            }
            return View();
        }
		[AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult ImportData(FormCollection collection)
        {
            string FilePath = collection["hdnFilePath"];
            var columnlist = collection["hdnColumnList"];
            var selectedlist = collection["hdnSelectedList"];
            string fileLocation = FilePath;
            string excelConnectionString = string.Empty;
            string fileExtension = System.IO.Path.GetExtension(fileLocation).ToLower();
			var selectedAssocPropList = collection["hdnSelectedAssocPropList"];
            Dictionary<string, string> lstEntityProp = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(selectedAssocPropList))
			{
				var entitypropList = selectedAssocPropList.Split(',');
				foreach (var prop in entitypropList)
				{
					var lst = prop.Split('-');
					lstEntityProp.Add(lst[1], lst[0]);
				}
			}
            if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv")
            {
                DataSet objDataSet = DataImport(fileExtension, fileLocation);
				string error = string.Empty;
                if (selectedlist != null && columnlist != null)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
						  var sheetColumns = selectedlist.Split(',').ToList();
                        if (AreAllColumnsEmpty(objDataSet.Tables[0].Rows[i], sheetColumns))
                            continue;
                        T_UnitX model = new T_UnitX();
                        var tblColumns = columnlist.Split(',').ToList();
                        for (int j = 0; j < sheetColumns.Count; j++)
                        {
                            string columntable = tblColumns[j];
                            int columnSheet = 0;
                            if (string.IsNullOrEmpty(sheetColumns[j]))
                                continue;
                            else
                                columnSheet = Convert.ToInt32(sheetColumns[j]) - 1;
                            string columnValue = objDataSet.Tables[0].Rows[i][columnSheet].ToString().Trim();
                            if (string.IsNullOrEmpty(columnValue))
                                continue;
                            switch (columntable)
                            {
    case "T_Unit":
    model.T_Unit = columnValue;
	break;
    case "T_UnitPhoneNumber":
    model.T_UnitPhoneNumber = columnValue;
	break;
    case "T_MailDistributor":
    model.T_MailDistributor = columnValue;
	break;
    case "T_MaleBeds":
    model.T_MaleBeds = Int32.Parse(columnValue);
	break;
    case "T_FemaleBeds":
    model.T_FemaleBeds = Int32.Parse(columnValue);
	break;
    case "T_TotalBeds":
    model.T_TotalBeds = Int32.Parse(columnValue);
	break;
    case "T_Program":
    model.T_Program = columnValue;
	break;
    case "T_Fund":
    model.T_Fund = columnValue;
	break;
					 case "T_FacilityUnitXID":
		 dynamic t_facilityunitxId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_FacilityUnitX = lstEntityProp.FirstOrDefault(p => p.Key == "T_FacilityUnitXID").Value;
			 ModelReflector.Property propT_FacilityUnitX = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Facility").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_FacilityUnitX);
			 //var elementTypeT_FacilityUnitX = db.T_Facilitys.ElementType;
			 //var propertyInfoT_FacilityUnitX = elementTypeT_FacilityUnitX.GetProperty(propT_FacilityUnitX.Name);			 
			 //t_facilityunitxId = db.T_Facilitys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_FacilityUnitX.GetValue(p, null)) == columnValue);
			 t_facilityunitxId = db.T_Facilitys.Where(propT_FacilityUnitX.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_facilityunitxId = db.T_Facilitys.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_facilityunitxId != null)
			model.T_FacilityUnitXID = t_facilityunitxId.Id;
		  else
			{
				if ((collection["T_FacilityUnitXID"].ToString() == "true,false"))
				{
					try
					{
						T_Facility objT_Facility = new T_Facility();
						objT_Facility.T_FacilityCode  = (columnValue);
						db.T_Facilitys.Add(objT_Facility);
						db.SaveChanges();
						model.T_FacilityUnitXID = objT_Facility.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_UnitXUnitAssociationID":
		 dynamic t_unitxunitassociationId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_UnitXUnitAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_UnitXUnitAssociationID").Value;
			 ModelReflector.Property propT_UnitXUnitAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Unit").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_UnitXUnitAssociation);
			 //var elementTypeT_UnitXUnitAssociation = db.T_Units.ElementType;
			 //var propertyInfoT_UnitXUnitAssociation = elementTypeT_UnitXUnitAssociation.GetProperty(propT_UnitXUnitAssociation.Name);			 
			 //t_unitxunitassociationId = db.T_Units.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_UnitXUnitAssociation.GetValue(p, null)) == columnValue);
			 t_unitxunitassociationId = db.T_Units.Where(propT_UnitXUnitAssociation.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_unitxunitassociationId = db.T_Units.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_unitxunitassociationId != null)
			model.T_UnitXUnitAssociationID = t_unitxunitassociationId.Id;
		  else
			{
				if ((collection["T_UnitXUnitAssociationID"].ToString() == "true,false"))
				{
					try
					{
						T_Unit objT_Unit = new T_Unit();
						objT_Unit.T_Name  = (columnValue);
						db.T_Units.Add(objT_Unit);
						db.SaveChanges();
						model.T_UnitXUnitAssociationID = objT_Unit.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_WardDepartmentID":
		 dynamic t_warddepartmentId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_WardDepartment = lstEntityProp.FirstOrDefault(p => p.Key == "T_WardDepartmentID").Value;
			 ModelReflector.Property propT_WardDepartment = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Department").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_WardDepartment);
			 //var elementTypeT_WardDepartment = db.T_Departments.ElementType;
			 //var propertyInfoT_WardDepartment = elementTypeT_WardDepartment.GetProperty(propT_WardDepartment.Name);			 
			 //t_warddepartmentId = db.T_Departments.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_WardDepartment.GetValue(p, null)) == columnValue);
			 t_warddepartmentId = db.T_Departments.Where(propT_WardDepartment.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_warddepartmentId = db.T_Departments.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_warddepartmentId != null)
			model.T_WardDepartmentID = t_warddepartmentId.Id;
		  else
			{
				if ((collection["T_WardDepartmentID"].ToString() == "true,false"))
				{
					try
					{
						T_Department objT_Department = new T_Department();
						objT_Department.T_DEPTshort  = (columnValue);
						db.T_Departments.Add(objT_Department);
						db.SaveChanges();
						model.T_WardDepartmentID = objT_Department.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_UnitXDepartmentAreaID":
		 dynamic t_unitxdepartmentareaId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_UnitXDepartmentArea = lstEntityProp.FirstOrDefault(p => p.Key == "T_UnitXDepartmentAreaID").Value;
			 ModelReflector.Property propT_UnitXDepartmentArea = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_DepartmentArea").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_UnitXDepartmentArea);
			 //var elementTypeT_UnitXDepartmentArea = db.T_DepartmentAreas.ElementType;
			 //var propertyInfoT_UnitXDepartmentArea = elementTypeT_UnitXDepartmentArea.GetProperty(propT_UnitXDepartmentArea.Name);			 
			 //t_unitxdepartmentareaId = db.T_DepartmentAreas.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_UnitXDepartmentArea.GetValue(p, null)) == columnValue);
			 t_unitxdepartmentareaId = db.T_DepartmentAreas.Where(propT_UnitXDepartmentArea.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_unitxdepartmentareaId = db.T_DepartmentAreas.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_unitxdepartmentareaId != null)
			model.T_UnitXDepartmentAreaID = t_unitxdepartmentareaId.Id;
		  else
			{
				if ((collection["T_UnitXDepartmentAreaID"].ToString() == "true,false"))
				{
					try
					{
						T_DepartmentArea objT_DepartmentArea = new T_DepartmentArea();
						objT_DepartmentArea.T_Name  = (columnValue);
						db.T_DepartmentAreas.Add(objT_DepartmentArea);
						db.SaveChanges();
						model.T_UnitXDepartmentAreaID = objT_DepartmentArea.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_WardOrgCodeID":
		 dynamic t_wardorgcodeId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_WardOrgCode = lstEntityProp.FirstOrDefault(p => p.Key == "T_WardOrgCodeID").Value;
			 ModelReflector.Property propT_WardOrgCode = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_OrgCodes").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_WardOrgCode);
			 //var elementTypeT_WardOrgCode = db.T_OrgCodess.ElementType;
			 //var propertyInfoT_WardOrgCode = elementTypeT_WardOrgCode.GetProperty(propT_WardOrgCode.Name);			 
			 //t_wardorgcodeId = db.T_OrgCodess.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_WardOrgCode.GetValue(p, null)) == columnValue);
			 t_wardorgcodeId = db.T_OrgCodess.Where(propT_WardOrgCode.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_wardorgcodeId = db.T_OrgCodess.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_wardorgcodeId != null)
			model.T_WardOrgCodeID = t_wardorgcodeId.Id;
		  else
			{
				if ((collection["T_WardOrgCodeID"].ToString() == "true,false"))
				{
					try
					{
						T_OrgCodes objT_OrgCodes = new T_OrgCodes();
						objT_OrgCodes.T_OrgCode  = (columnValue);
						db.T_OrgCodess.Add(objT_OrgCodes);
						db.SaveChanges();
						model.T_WardOrgCodeID = objT_OrgCodes.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_UnitXFloorID":
		 dynamic t_unitxfloorId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_UnitXFloor = lstEntityProp.FirstOrDefault(p => p.Key == "T_UnitXFloorID").Value;
			 ModelReflector.Property propT_UnitXFloor = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Floor").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_UnitXFloor);
			 //var elementTypeT_UnitXFloor = db.T_Floors.ElementType;
			 //var propertyInfoT_UnitXFloor = elementTypeT_UnitXFloor.GetProperty(propT_UnitXFloor.Name);			 
			 //t_unitxfloorId = db.T_Floors.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_UnitXFloor.GetValue(p, null)) == columnValue);
			 t_unitxfloorId = db.T_Floors.Where(propT_UnitXFloor.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_unitxfloorId = db.T_Floors.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_unitxfloorId != null)
			model.T_UnitXFloorID = t_unitxfloorId.Id;
		  else
			{
				if ((collection["T_UnitXFloorID"].ToString() == "true,false"))
				{
					try
					{
						T_Floor objT_Floor = new T_Floor();
						objT_Floor.T_Name  = (columnValue);
						db.T_Floors.Add(objT_Floor);
						db.SaveChanges();
						model.T_UnitXFloorID = objT_Floor.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeAdministratorID":
		 dynamic t_employeeadministratorId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeAdministrator = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeAdministratorID").Value;
			 ModelReflector.Property propT_EmployeeAdministrator = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeAdministrator);
			 //var elementTypeT_EmployeeAdministrator = db.T_Employees.ElementType;
			 //var propertyInfoT_EmployeeAdministrator = elementTypeT_EmployeeAdministrator.GetProperty(propT_EmployeeAdministrator.Name);			 
			 //t_employeeadministratorId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeAdministrator.GetValue(p, null)) == columnValue);
			 t_employeeadministratorId = db.T_Employees.Where(propT_EmployeeAdministrator.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeadministratorId = db.T_Employees.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeadministratorId != null)
			model.T_EmployeeAdministratorID = t_employeeadministratorId.Id;
		  else
			{
				if ((collection["T_EmployeeAdministratorID"].ToString() == "true,false"))
				{
					try
					{
						T_Employee objT_Employee = new T_Employee();
						objT_Employee.T_PID  = (columnValue);
				 try { objT_Employee.T_LastName =(columnValue); }
                 catch { objT_Employee.T_LastName = default(string); }
				 try { objT_Employee.T_FirstName =(columnValue); }
                 catch { objT_Employee.T_FirstName = default(string); }
						db.T_Employees.Add(objT_Employee);
						db.SaveChanges();
						model.T_EmployeeAdministratorID = objT_Employee.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeUnitXHeadID":
		 dynamic t_employeeunitxheadId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeUnitXHead = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeUnitXHeadID").Value;
			 ModelReflector.Property propT_EmployeeUnitXHead = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeUnitXHead);
			 //var elementTypeT_EmployeeUnitXHead = db.T_Employees.ElementType;
			 //var propertyInfoT_EmployeeUnitXHead = elementTypeT_EmployeeUnitXHead.GetProperty(propT_EmployeeUnitXHead.Name);			 
			 //t_employeeunitxheadId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeUnitXHead.GetValue(p, null)) == columnValue);
			 t_employeeunitxheadId = db.T_Employees.Where(propT_EmployeeUnitXHead.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeunitxheadId = db.T_Employees.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeunitxheadId != null)
			model.T_EmployeeUnitXHeadID = t_employeeunitxheadId.Id;
		  else
			{
				if ((collection["T_EmployeeUnitXHeadID"].ToString() == "true,false"))
				{
					try
					{
						T_Employee objT_Employee = new T_Employee();
						objT_Employee.T_PID  = (columnValue);
				 try { objT_Employee.T_LastName =(columnValue); }
                 catch { objT_Employee.T_LastName = default(string); }
				 try { objT_Employee.T_FirstName =(columnValue); }
                 catch { objT_Employee.T_FirstName = default(string); }
						db.T_Employees.Add(objT_Employee);
						db.SaveChanges();
						model.T_EmployeeUnitXHeadID = objT_Employee.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_WardCostCenterID":
		 dynamic t_wardcostcenterId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_WardCostCenter = lstEntityProp.FirstOrDefault(p => p.Key == "T_WardCostCenterID").Value;
			 ModelReflector.Property propT_WardCostCenter = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_CostCenter").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_WardCostCenter);
			 //var elementTypeT_WardCostCenter = db.T_CostCenters.ElementType;
			 //var propertyInfoT_WardCostCenter = elementTypeT_WardCostCenter.GetProperty(propT_WardCostCenter.Name);			 
			 //t_wardcostcenterId = db.T_CostCenters.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_WardCostCenter.GetValue(p, null)) == columnValue);
			 t_wardcostcenterId = db.T_CostCenters.Where(propT_WardCostCenter.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_wardcostcenterId = db.T_CostCenters.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_wardcostcenterId != null)
			model.T_WardCostCenterID = t_wardcostcenterId.Id;
		  else
			{
				if ((collection["T_WardCostCenterID"].ToString() == "true,false"))
				{
					try
					{
						T_CostCenter objT_CostCenter = new T_CostCenter();
						objT_CostCenter.T_CC  = (columnValue);
						db.T_CostCenters.Add(objT_CostCenter);
						db.SaveChanges();
						model.T_WardCostCenterID = objT_CostCenter.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
            default:
                break;
        }
    }
						CheckBeforeSave(model, "ImportData");
						var customimport_hasissues = false;
					    if (ValidateModel(model))
                        {
							var result = CheckMandatoryProperties(model);
                            if (result == null || result.Count == 0)
                            {
								var customerror = "";
								if(!CustomSaveOnImport(model, out customerror,i))
								{
									db.T_UnitXs.Add(model);
									db.SaveChanges();
								}
								error += customerror;
							}
							else
                            {
                                if (ViewBag.ImportError == null)
                                    ViewBag.ImportError = "Row No : " + (i + 1) + " " + string.Join(", ", result.ToArray()) + " Required Value Missing";
                                else
                                    ViewBag.ImportError += "<br/> Row No : " + (i + 1) + " " + string.Join(", ", result.ToArray()) + " Required Value Missing";
                                error += ((i + 1).ToString()) + ",";
                            }
                        }
                        else
                        {
							if (ViewBag.ImportError == null)
                                ViewBag.ImportError = "Row No : " + (i + 1) + " Value is Blank or Duplicate or Validation failed.";
                            else
                                ViewBag.ImportError += "<br/> Row No : " + (i + 1) + " Value is Blank or Duplicate or Validation failed.";
								error += ((i + 1).ToString()) + ",";
                        }
                    }
                }
                if (ViewBag.ImportError != null)
                {
                    ViewBag.FilePath = FilePath;
                    ViewBag.ErrorList = error.Substring(0, error.Length - 1);
                    ViewBag.Title = "Error List";
                    return View("Upload");
                }
                else
                {
                    if (System.IO.File.Exists(fileLocation))
                        System.IO.File.Delete(fileLocation);
                    if (ViewBag.ImportError == null)
                    {
                        ViewBag.ImportError = "success";
                        ViewBag.Title = "Upload List";
                        return View("Upload");
                    }
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
		public ActionResult DownloadSheet(FormCollection collection)
        {
            string FilePath = collection["hdnFilePath"];
            var columnlist = collection["hdnErrorList"];
            string fileLocation = FilePath;
            string excelConnectionString = string.Empty;
            string fileExtension = System.IO.Path.GetExtension(fileLocation).ToLower();
            if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv")
            {
                DataSet objDataSet = DataImport(fileExtension, fileLocation);
                if (System.IO.File.Exists(fileLocation))
                    System.IO.File.Delete(fileLocation);
                (new DataToExcel()).ExportDetails(objDataSet.Tables[0], fileExtension == ".csv" ? "CSV" : "Excel", "DownloadError" + (fileExtension == ".csv" ? ".csv" : ".xls"), columnlist.Split(',').ToList());
            }
            return View();
        }
		public bool ValidateModel(T_UnitX validate)
        {
            return Validator.TryValidateObject(validate, new ValidationContext(validate, null, null), null,true);
        }
		 bool AreAllColumnsEmpty(DataRow dr, List<string> sheetColumns)
        {
            if (dr == null)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < sheetColumns.Count(); i++ )
                {
                    if (string.IsNullOrEmpty(sheetColumns[i]))
                        continue;
                    if (dr[ Convert.ToInt32(sheetColumns[i]) - 1] != null && dr[ Convert.ToInt32(sheetColumns[i]) - 1].ToString() != "")
                    {
                        return false;
                    }
                }
                return true;
            }
        }
				[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetMapping(string typename)
        {
            bool isMapping = (db.ImportConfigurations.Where(p => p.LastUpdateUser == User.Name && p.Name == typename)).Count() > 0 ? true : false;
            return Json(isMapping, JsonRequestBehavior.AllowGet);
        }
		public object GetFieldValueByEntityId(long Id, string PropName)
        {
            try
            {
			                ApplicationContext db1 = new ApplicationContext(new SystemUser());
                var obj1 = db1.T_UnitXs.Find(Id);
                System.Reflection.PropertyInfo[] properties = (obj1.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
                var Property = properties.FirstOrDefault(p => p.Name == PropName);
                object PropValue = Property.GetValue(obj1, null);
                return PropValue;
				            }
            catch { return null; }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetReadOnlyProperties(T_UnitX OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_UnitX").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.ReadOnlyPropertiesRule(OModel, BR, "T_UnitX");
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    var BRFail = BRAll.Except(BR).Where(p => p.AssociatedBusinessRuleTypeID == 4);
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(4))
                    {
                        var Args = GeneratorBase.MVC.Models.BusinessRuleContext.GetActionArguments(ResultOfBusinessRules.Where(p => p.Key.TypeNo == 4).Select(v => v.Value.ActionID).ToList());
                        var listArgs = Args;
                        foreach (var parametersArgs in Args)
                        {
                            var dispName = "";
                            var paramName = parametersArgs.ParameterName;
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_UnitX");
                            var property = entity.Properties.FirstOrDefault(p => p.Name == paramName);
                            if (property != null)
                                dispName = property.DisplayName;
                            else
                            {
                                if (paramName.Contains("."))
                                {
                                    var arrparamName = paramName.Split('.');
                                    var assocName = entity.Associations.FirstOrDefault(p => p.AssociationProperty == arrparamName[0]);
                                    var targetPropName = ModelReflector.Entities.FirstOrDefault(p => p.Name == assocName.Target).Properties.FirstOrDefault(q => q.Name == arrparamName[1]);
                                    paramName = arrparamName[0].Replace("ID", "").ToLower().Trim() + "_" + arrparamName[1];
                                    dispName = assocName.DisplayName + "." + targetPropName.DisplayName;
                                }
                            }
                            if (!RulesApplied.ContainsKey(paramName))
                            {
                                RulesApplied.Add(paramName, dispName);
                                var objBR = BR.Find(p => p.Id == parametersArgs.actionarguments.RuleActionID);
								if (!RulesApplied.ContainsKey("FailureMessage-" + objBR.Id))
									RulesApplied.Add("FailureMessage-" + objBR.Id, objBR.FailureMessage);
                            }
                        }
                    }
                    if (BRFail != null && BRFail.Count() > 0)
                    {
                        foreach (var objBR in BRFail)
                        {
							if (!RulesApplied.ContainsKey("InformationMessage-" + objBR.Id))
								RulesApplied.Add("InformationMessage-" + objBR.Id, objBR.InformationMessage);
                        }
                    }
                }
            }
            return Json(RulesApplied, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetMandatoryProperties(T_UnitX OModel, string ruleType)
        {
            Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_UnitX").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
                    if (ruleType == "OnCreate")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 2).ToList();
                    else if (ruleType == "OnEdit")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 1).ToList();
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_UnitX");
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    var ruleActions = new RuleActionContext().RuleActions.Where(p => p.AssociatedActionTypeID == 2).Select(p => p.RuleActionID).ToList();
                    var BRFail = BRAll.Except(BR);
                    BRFail = BRFail.Where(p => ruleActions.Contains(p.Id)).ToList();
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(2))
                    {
                        var Args = GeneratorBase.MVC.Models.BusinessRuleContext.GetActionArguments(ResultOfBusinessRules.Where(p => p.Key.TypeNo == 2).Select(v => v.Value.ActionID).ToList());
                        var listArgs = Args;
                        foreach (var parametersArgs in Args)
                        {
							var dispName = "";
                            var paramName = parametersArgs.ParameterName;
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_UnitX");
                            var property = entity.Properties.FirstOrDefault(p => p.Name == paramName);
                            if (property != null)
                                dispName = property.DisplayName;
                            else
                            {
                                if (paramName.Contains("."))
                                {
                                    var arrparamName = paramName.Split('.');
                                    var assocName = entity.Associations.FirstOrDefault(p => p.AssociationProperty == arrparamName[0]);
                                    var targetPropName = ModelReflector.Entities.FirstOrDefault(p => p.Name == assocName.Target).Properties.FirstOrDefault(q => q.Name == arrparamName[1]);
                                    paramName = arrparamName[0].Replace("ID", "").ToLower().Trim() + "_" + arrparamName[1];
                                    dispName = assocName.DisplayName + "." + targetPropName.DisplayName;
                                }
                            }
							if (!RequiredProperties.ContainsKey(paramName))
                            {
                                RequiredProperties.Add(paramName, dispName);
                                var objBR = BR.Find(p => p.Id == parametersArgs.actionarguments.RuleActionID);
								if (!RequiredProperties.ContainsKey("FailureMessage-" + objBR.Id))
									RequiredProperties.Add("FailureMessage-" + objBR.Id, objBR.FailureMessage);
                            }
                        }
                    }
                    if (BRFail != null && BRFail.Count() > 0)
                    {
                        foreach (var objBR in BRFail)
                        {
							if (!RequiredProperties.ContainsKey("InformationMessage-" + objBR.Id))
								RequiredProperties.Add("InformationMessage-" + objBR.Id, objBR.InformationMessage);
                        }
                    }
                }
            }
            return Json(RequiredProperties, JsonRequestBehavior.AllowGet);
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetUIAlertBusinessRules(T_UnitX OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_UnitX").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.UIAlertRule(OModel, BR, "T_UnitX");
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    var BRFail = BRAll.Except(BR).Where(p => p.AssociatedBusinessRuleTypeID == 13);
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(13))
                    {
                        foreach (var rules in ResultOfBusinessRules)
                        {
                            //RulesApplied.Add("Business Rule #" + rules.Value.BRID + " applied : ", conditions.Trim().TrimEnd(",".ToCharArray()));
							 RulesApplied.Add("<span style=\"color:grey;font-size:11px;\">Warning(#" + rules.Value.BRID + ") :</span> ", conditions.Trim().TrimEnd(",".ToCharArray()));
                            var BRList = BR.Where(q => ResultOfBusinessRules.Values.Select(p => p.BRID).Contains(q.Id));
                            foreach (var objBR in BRList)
                            {
                                if (!RulesApplied.ContainsKey("FailureMessage-" + objBR.Id))
                                    RulesApplied.Add("FailureMessage-" + objBR.Id, objBR.FailureMessage);
                            }
                        }
                    }
                    if (BRFail != null && BRFail.Count() > 0)
                    {
                        foreach (var objBR in BRFail)
                        {
                            if (!RulesApplied.ContainsKey("InformationMessage-" + objBR.Id))
                                RulesApplied.Add("InformationMessage-" + objBR.Id, objBR.InformationMessage);
                        }
                    }
                }
            }
            return Json(RulesApplied, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetValidateBeforeSaveProperties(T_UnitX OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_UnitX").ToList();
				EntityState state = EntityState.Added;
                if(ruleType == "OnEdit")
                {
                    BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 1).ToList();
                    state = EntityState.Modified;
                }
                if (ruleType == "OnCreate")
                {
                    BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 2).ToList();
                    state = EntityState.Added;
                }
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.ValidateBeforeSavePropertiesRule(OModel, BR, "T_UnitX",state);
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    var BRFail = BRAll.Except(BR).Where(p => p.AssociatedBusinessRuleTypeID == 10);
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(10))
                    {
                        foreach (var rules in ResultOfBusinessRules)
                        {
                            if (rules.Key.TypeNo == 10)
                            {
                                var ruleconditionsdb = new ConditionContext().Conditions.Where(p => p.RuleConditionsID == rules.Value.BRID);
                                foreach (var condition in ruleconditionsdb)
                                {
                                    string conditionPropertyName = condition.PropertyName;
                                    var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_UnitX");
                                    var PropInfo = Entity.Properties.FirstOrDefault(p => p.Name == conditionPropertyName);
                                    var AssociationInfo = Entity.Associations.FirstOrDefault(p => p.AssociationProperty == conditionPropertyName);
                                    var propDispName = "";
                                    if (conditionPropertyName.StartsWith("[") && conditionPropertyName.EndsWith("]"))
                                    {
                                        conditionPropertyName = conditionPropertyName.TrimStart('[').TrimEnd(']').Trim();
                                        if (conditionPropertyName.Contains("."))
                                        {
                                            var targetProperties = conditionPropertyName.Split(".".ToCharArray());
                                            if (targetProperties.Length > 1)
                                            {
                                                AssociationInfo = Entity.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                                                if (AssociationInfo != null)
                                                {
                                                    var EntityInfo1 = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                                                    conditionPropertyName = EntityInfo1.Properties.FirstOrDefault(p => p.Name == targetProperties[1]).DisplayName;
                                                }
                                            }
                                            propDispName = AssociationInfo.DisplayName + "." + conditionPropertyName;
                                        }
                                    }
                                    else
                                    {
                                        propDispName = Entity.Properties.FirstOrDefault(p => p.Name == conditionPropertyName).DisplayName;
                                    }
                                    conditions += propDispName + " " + condition.Operator + " " + condition.Value + ", ";
                                }   
                            }
                            //RulesApplied.Add("Business Rule #" + rules.Value.BRID + " applied : ", conditions.Trim().TrimEnd(','));
							//RulesApplied.Add("<span style=\"color:grey;font-size:11px;\">Warning(#" + rules.Value.BRID + ") :</span> ", conditions.Trim().TrimEnd(",".ToCharArray()));
                            var BRList = BR.Where(q => ResultOfBusinessRules.Values.Select(p => p.BRID).Contains(q.Id));
                            foreach (var objBR in BRList)
                            {
								if (!RulesApplied.ContainsKey("<span style=\"color:grey;font-size:11px;\">Warning(#" + objBR.Id + ") :</span> "))
                                {
                                    if(!string.IsNullOrEmpty(objBR.FailureMessage))
                                        RulesApplied.Add("<span style=\"color:grey;font-size:11px;\">Warning(#" + objBR.Id + ") :</span> ", objBR.FailureMessage);
                                    else
                                        RulesApplied.Add("<span style=\"color:grey;font-size:11px;\">Warning(#" + objBR.Id + ") :</span> ", conditions.Trim().TrimEnd(",".ToCharArray()));
                                }
                            }
                        }
                    }
                    if (BRFail != null && BRFail.Count() > 0)
                    {
                        foreach (var objBR in BRFail)
                        {
							if (!RulesApplied.ContainsKey("InformationMessage-" + objBR.Id))
								RulesApplied.Add("InformationMessage-" + objBR.Id, objBR.InformationMessage);
                        }
                    }
                }
            }
            return Json(RulesApplied, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetLockBusinessRules(T_UnitX OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            //string RulesApplied = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_UnitX").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.LockEntityRule(OModel, BR, "T_UnitX");
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    var BRFail = BRAll.Except(BR).Where(p=>p.AssociatedBusinessRuleTypeID==2);
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(1)||ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(11))
                    {
                        var BRList = BR.Where(q => ResultOfBusinessRules.Values.Select(p => p.BRID).Contains(q.Id));
                        foreach(var objBR in BRList)
                        {
                            RulesApplied.Add("Rule #" + objBR.Id + " is Applied", objBR.RuleName);
							if (!RulesApplied.ContainsKey("FailureMessage-" + objBR.Id))
								RulesApplied.Add("FailureMessage-" + objBR.Id, objBR.FailureMessage);
                        }
                    }
                    if (BRFail != null && BRFail.Count() > 0)
                    {
                        foreach (var objBR in BRFail)
                        {
							if (!RulesApplied.ContainsKey("InformationMessage-" + objBR.Id))
								RulesApplied.Add("InformationMessage-" + objBR.Id, objBR.InformationMessage);
                        }
                    }
                }
            }
            return Json(RulesApplied, JsonRequestBehavior.AllowGet);
        }
		private List<string> CheckMandatoryProperties(T_UnitX OModel)
        {
            List<string> result = new List<string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_UnitX").ToList();
                Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
                if (BR != null && BR.Count > 0)
                {
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_UnitX");
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    if (ResultOfBusinessRules.Keys.Select(p=>p.TypeNo).Contains(2))
                    {
                        var Args = GeneratorBase.MVC.Models.BusinessRuleContext.GetActionArguments(ResultOfBusinessRules.Where(p => p.Key.TypeNo == 2).Select(v => v.Value.ActionID).ToList());
                        foreach (string paramName in Args.Select(p => p.ParameterName))
                        {
                            var type = OModel.GetType();
                            if (type.GetProperty(paramName) == null) continue;
                            var propertyvalue = type.GetProperty(paramName).GetValue(OModel, null);
                            if (propertyvalue == null)
                            {
                                var dispName = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_UnitX").Properties.FirstOrDefault(p => p.Name == paramName).DisplayName;
                                result.Add(dispName);
                            }
                        }
                    }
                }
            }
            return result;
        }
		public long? GetIdFromDisplayValue(string displayvalue)
        {
            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            if (string.IsNullOrEmpty(displayvalue)) return 0;
            var _Obj = db1.T_UnitXs.FirstOrDefault(p => p.DisplayValue == displayvalue);
            long outValue;
            if (_Obj != null)
                return Int64.TryParse(_Obj.Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				public long? GetIdFromPropertyValue(string PropName, string PropValue)
        {
            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            IQueryable query = db1.T_UnitXs;
            Type[] exprArgTypes = { query.ElementType };
            string propToWhere = PropName;
            ParameterExpression p = Expression.Parameter(typeof(T_UnitX), "p");
            MemberExpression member = Expression.PropertyOrField(p, propToWhere);
            LambdaExpression lambda = null;
            if (PropValue.ToLower().Trim() != "null")
            lambda = Expression.Lambda<Func<T_UnitX, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(PropValue), member.Type)), p);
            else
                lambda = Expression.Lambda<Func<T_UnitX, bool>>(Expression.Equal(member, Expression.Constant(null, member.Type)), p);
            MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
            IQueryable q = query.Provider.CreateQuery(methodCall);
            long outValue;
            var list1 = ((IQueryable<T_UnitX>)q);
            if (list1 != null && list1.Count() > 0)
                return Int64.TryParse(list1.FirstOrDefault().Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPropertyValueByEntityId(long Id, string PropName)
        {
								ApplicationContext db1 = new ApplicationContext(new SystemUser());
            var obj1 = db1.T_UnitXs.Find(Id);
			 if (obj1 == null)
                return Json("0", JsonRequestBehavior.AllowGet);
            System.Reflection.PropertyInfo[] properties = (obj1.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            var Property = properties.FirstOrDefault(p => p.Name == PropName);
            object PropValue = Property.GetValue(obj1, null);
            PropValue = PropValue == null ? 0 : PropValue;
			return Json(Convert.ToString(PropValue), JsonRequestBehavior.AllowGet);
			        }
		public string checkHidden(string entityName, string brType, bool isHiddenGroup)
        {
            System.Text.StringBuilder hiddenBRString = new System.Text.StringBuilder();
            System.Text.StringBuilder chkHiddenGroup = new System.Text.StringBuilder();
            RuleActionContext objRuleAction = new RuleActionContext();
            ConditionContext objCondition = new ConditionContext();
            ActionArgsContext objActionArgs = new ActionArgsContext();
            var businessRules = User.businessrules.Where(p => p.EntityName == entityName).ToList();
            string selectCondition = "";
            string selectval = "";
            string propChangeEvnetdd = "";
            string AssociationName = "";
           			string[] rbList = null;
            {
                foreach (BusinessRule objBR in businessRules)
                {
                    long ActionTypeId = 6;
                    if (isHiddenGroup)
                        ActionTypeId = 12;
                    var objRuleActionList = objRuleAction.RuleActions.Where(ra => ra.AssociatedActionTypeID.Value == ActionTypeId && ra.RuleActionID.Value == objBR.Id);
                    if (objRuleActionList.Count() > 0)
                    {
                        System.Text.StringBuilder chkHidden = new System.Text.StringBuilder();
                        System.Text.StringBuilder chkFnHidden = new System.Text.StringBuilder();
                        if (objBR.AssociatedBusinessRuleTypeID == 1 && brType != "OnCreate")
                            continue;
                        else if (objBR.AssociatedBusinessRuleTypeID == 2 && (brType != "OnEdit" && brType != "OnDetails"))
                            continue;
                        foreach (RuleAction objRA in objRuleActionList)
                        {
                            var objConditionList = objCondition.Conditions.Where(con => con.RuleConditionsID == objRA.RuleActionID);
                            if (objConditionList.Count() > 0)
                            {
                                string fnCondition = string.Empty;
                                string fnConditionValue = string.Empty;
                                foreach (Condition objCon in objConditionList)
                                {
                                    if (string.IsNullOrEmpty(chkHidden.ToString()))
                                    {
                                        chkHidden.Append("<script type='text/javascript'>$(document).ready(function () {");
                                        fnCondition = "hiddenCondition" + objCon.Id.ToString() + "()";
                                        chkHidden.Append(fnCondition + ";");
                                    }
                                    string datatype = checkPropType(entityName, objCon.PropertyName);
                                    string operand = checkOperator(objCon.Operator);
                                    string propertyAttribute = getPropertyAttribute(entityName, objCon.PropertyName);
                                    string logicalconnector = objCon.LogicalConnector.ToLower() == "and" ? "&&" : "||";
                                    //check if today is used for datetime property
                                    string condValue = "";
                                    if (datatype == "DateTime" && objCon.Value.ToLower() == "today")
                                        condValue = DateTime.UtcNow.Date.ToString("MM/dd/yyyy");
                                    else
                                        condValue = objCon.Value;
                                    var rbcheck = false;
                                    if (rbList != null && rbList.Contains(objCon.PropertyName))
                                        rbcheck = true;
                                    if (datatype == "Association")
                                    {
                                        var propertyName = objCon.PropertyName.Replace('[', ' ').Remove(objCon.PropertyName.IndexOf('.')).Trim();
                                        var strText = ".text()";
                                        var strOptionSelected = "$('option:selected', '#" + propertyName + "')";
                                        if (brType != "OnDetails")
                                            chkHidden.Append((rbcheck ? " $('input:radio[name=" + propertyName + "]')" : " $('#" + propertyName + "')") + ".change(function() { " + fnCondition + "; });");
                                        else
                                        {
                                            propertyName = "lbl" + propertyName;
                                            strText = "[0].innerText";
                                            strOptionSelected = "$('#" + propertyName + "')";
                                        }
                                        if (operand.Length > 2)
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "(" + strOptionSelected) + strText + ".toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                            else
                                            {
                                                fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " " + logicalconnector + " (" + strOptionSelected) + strText + ".toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "(" + strOptionSelected) + strText + ".toLowerCase() " + operand + " '" + condValue + "'.toLowerCase())";
                                            }
                                            else
                                            {
                                                fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " " + logicalconnector + " (" + strOptionSelected) + strText + ".toLowerCase() " + operand + " '" + condValue + "'.toLowerCase())";
                                            }
                                        }
                                        if (!rbcheck)
                                        {
                                            if (isHiddenGroup)
                                            {
                                                if (AssociationName != propertyName)
                                                {
                                                    propChangeEvnetdd += " $('#" + propertyName + "').change(function() { CONDITION ";
                                                    selectval += " var selected" + propertyName + " =  $('option:selected', '#" + propertyName + "') " + ".text().toLowerCase(); ";
                                                    AssociationName = propertyName;
                                                }
                                                selectCondition += " selected" + propertyName + operand + " '" + condValue + "'.toLowerCase() ||";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string propertyName = objCon.PropertyName;
                                        string strVal = ".val()";
                                        string eventName = ".change";
                                        if (propertyAttribute.ToLower() == "currency")
                                            eventName = ".blur";
                                        if (brType != "OnDetails")
                                            chkHidden.Append((rbcheck ? " $('input:radio[name=" + propertyName + "]')" : " $('#" + propertyName + "')") + eventName + "(function() { " + fnCondition + "; });");
                                        else
                                        {
                                            if (propertyName != "Id")
                                            {
                                                propertyName = "lbl" + propertyName;
                                                strVal = "[0].innerText";
                                            }
                                        }
                                        if (operand.Length > 2)
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                fnConditionValue = "($('#" + propertyName + "')" + strVal + ".toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                            else
                                            {
                                                fnConditionValue += " " + logicalconnector + " ($('#" + propertyName + "')" + strVal + ".toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                        }
                                        else
                                        {
                                            string strLowerCase = ".toLowerCase() ";
                                            string strCondValue = " '" + condValue + "'";
                                            if (datatype.ToLower() == "decimal" || datatype.ToLower() == "double" || datatype.ToLower() == "int32")
                                            {
                                                strLowerCase = "";
                                                strCondValue = condValue;
                                            }
											 if (datatype.ToLower() == "boolean")
                                            {
                                                strVal = ".prop('checked')";
                                                strCondValue = condValue.ToLower();
                                                strLowerCase = "";
                                            }
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                if (propertyName == "Id" && objCon.Operator == ">" && objCon.Value == "0" && (brType == "OnEdit" || brType == "OnDetails"))
                                                    fnConditionValue = "($('#" + propertyName + "')" + strVal + " " + operand + " '" + objCon.Value + "')";
                                                else if (propertyName == "Id" && objCon.Operator == ">" && objCon.Value == "0" && brType == "OnCreate")
                                                    fnConditionValue = "('true')";
                                                else
                                                {
                                                    if (strCondValue.ToLower().Trim() == "'null'")
                                                        fnConditionValue = "($('#" + propertyName + "')" + strVal + strLowerCase + operand + "''" + strLowerCase + ")";
                                                    else
                                                        fnConditionValue = "($('#" + propertyName + "')" + strVal + strLowerCase + operand + strCondValue + strLowerCase + ")";
                                                }
                                            }
                                            else
                                            {
                                                fnConditionValue += " " + logicalconnector + " ($('#" + propertyName + "')" + strVal + strLowerCase + operand + strCondValue + strLowerCase + ")";
                                            }
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(chkHidden.ToString()))
                                {
                                    chkHidden.Append(" });");
                                    var objActionArgsList = objActionArgs.ActionArgss.Where(aa => aa.ActionArgumentsID == objRA.Id);
                                    if (objActionArgsList.Count() > 0)
                                    {
                                        string fnName = string.Empty;
                                        string fnProp = string.Empty;
                                        string fn = string.Empty;
                                        foreach (ActionArgs objaa in objActionArgsList)
                                        {
                                            fn += objaa.Id.ToString();
                                            //change for inline association
                                            if (isHiddenGroup)
                                                fnProp += "$('#dvGroup" + objaa.ParameterName.Remove(objaa.ParameterName.IndexOf('|')) + "').css('display', type);";
                                            else
                                                fnProp += "$('#dv" + objaa.ParameterName.Replace('.', '_') + "').css('display', type);";
                                        }
                                        if (!string.IsNullOrEmpty(fn))
                                            fnName = "hiddenProp" + fn;
                                        if (!string.IsNullOrEmpty(fnName))
                                        {
                                            string hdnElse = "";
                                            string showHideAllGroup = "";
                                            //if (!isHiddenGroup)
                                            {
                                                hdnElse = "else { " + fnName + "('block'); }";
                                            }
                                            if (isHiddenGroup)
                                            {
                                                showHideAllGroup = "showalldivs();";
                                            }
                                            chkHidden.Append("function " + fnCondition + " { if ( " + fnConditionValue + " ) { " + showHideAllGroup + " " + fnName + "('none'); } " + hdnElse + " }");
                                            chkFnHidden.Append("function " + fnName + "(type) { " + fnProp + " }");
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(chkFnHidden.ToString()))
                                {
                                    chkHidden.Append(chkFnHidden.ToString());
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(chkHidden.ToString()))
                        {
                            chkHidden.Append("</script> ");
                            hiddenBRString.Append(chkHidden);
                        }
                    }
                }
            }
            //
            if (selectCondition != "" && selectval != "")
            {
                chkHiddenGroup.Append("<script type='text/javascript'> $(document).ready(function () {");
                selectCondition = selectCondition.Remove(selectCondition.Length - 2);
                string finalStr = selectval + "if (!(" + selectCondition + ")){showalldivs();}});";
                chkHiddenGroup.Append(propChangeEvnetdd.Replace("CONDITION", finalStr));
                chkHiddenGroup.Append("}); ");
                chkHiddenGroup.Append("</script> ");
                //chkHiddenGroup = "";
                selectval = "";
                propChangeEvnetdd = "";
                selectCondition = "";
                AssociationName = "";
                hiddenBRString.Append(chkHiddenGroup);
            }
            //
            return hiddenBRString.ToString();
        }
	     public string checkSetValueUIRule(string entityName, string brType)
        {
            System.Text.StringBuilder SetValueBRString = new System.Text.StringBuilder();
            ConditionContext objCondition = new ConditionContext();
            RuleActionContext objRuleAction = new RuleActionContext();
            ActionArgsContext objActionArgs = new ActionArgsContext();
            var businessRules = User.businessrules.Where(p => p.EntityName == entityName).ToList();
            string[] rbList = null;
            if (businessRules != null && businessRules.Count > 0)
            {
                foreach (BusinessRule objBR in businessRules)
                {
                    var ActionCount = 1;
                    long ActionTypeId = 7;
                    var objRuleActionList = objRuleAction.RuleActions.Where(ra => ra.AssociatedActionTypeID.Value == ActionTypeId && ra.RuleActionID.Value == objBR.Id).ToList();
                    if (objRuleActionList.Count() > 0)
                    {
                        System.Text.StringBuilder chkSetValue = new System.Text.StringBuilder();
                        System.Text.StringBuilder chkFnSetValue = new System.Text.StringBuilder();
                        if (objBR.AssociatedBusinessRuleTypeID != 6)
                            continue;
                        foreach (RuleAction objRA in objRuleActionList)
                        {
                            if (ActionCount > 1)
                                continue;
                            var objConditionList = objCondition.Conditions.Where(con => con.RuleConditionsID == objRA.RuleActionID);
                            if (objConditionList.Count() > 0)
                            {
                                string fnCondition = string.Empty;
                                string fnConditionValue = string.Empty;
                                foreach (Condition objCon in objConditionList)
                                {
                                    ActionCount++;
                                    if (string.IsNullOrEmpty(chkSetValue.ToString()))
                                    {
                                        chkSetValue.Append("<script type='text/javascript'>$(document).ready(function () {");
                                        fnCondition = "setvalueUIRule" + objCon.Id.ToString() + "()";
                                        chkSetValue.Append(fnCondition + ";");
                                    }
                                    string datatype = checkPropType(entityName, objCon.PropertyName);
                                    string operand = checkOperator(objCon.Operator);
                                    string propertyAttribute = getPropertyAttribute(entityName, objCon.PropertyName);
                                    string logicalconnector = objCon.LogicalConnector.ToLower() == "and" ? "&&" : "||";
                                    //check if today is used for datetime property
                                    string condValue = "";
                                    if (datatype == "DateTime" && objCon.Value.ToLower() == "today")
                                        condValue = DateTime.UtcNow.Date.ToString("MM/dd/yyyy");
                                    else
                                        condValue = objCon.Value;
                                    var rbcheck = false;
                                    if (rbList != null && rbList.Contains(objCon.PropertyName))
                                        rbcheck = true;
                                    if (datatype == "Association")
                                    {
                                       //var propertyName = objCon.PropertyName.Replace('[', ' ').Remove(objCon.PropertyName.IndexOf('.')).Trim();
										 var propertyName = objCon.PropertyName;
                                        if (propertyName.StartsWith("[") && propertyName.EndsWith("]"))
                                        {
                                            var parameterSplit = propertyName.Substring(1, propertyName.Length - 2).Split('.');
                                            string[] inlineAssoList = {  };
                                            if (inlineAssoList.Length > 0 && inlineAssoList.Contains(parameterSplit[0].Trim()))
                                                propertyName = parameterSplit[0].Replace("ID", "").ToLower().Trim() + "_" + parameterSplit[1].ToString().Trim();
                                            else
                                                propertyName = parameterSplit[0];
                                        }
                                        if (fnCondition == null)
                                            continue;
                                        chkSetValue.Append((rbcheck ? " $('input:radio[name=" + propertyName + "]')" : " $('#" + propertyName + "')") + ".change(function() { " + fnCondition + "; });");
                                        if (operand.Length > 2)
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                if (condValue.ToLower().Trim() == "null")
                                                    fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "($('option:selected', '#" + propertyName + "')") + ".val().toLowerCase() " + operand + " ''.toLowerCase())";
                                                else
                                                    fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "($('option:selected', '#" + propertyName + "')") + ".text().toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                            else
                                            {
                                                if (condValue.ToLower().Trim() == "null")
                                                    fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " && ($('option:selected', '#" + propertyName + "')") + ".val().toLowerCase()" + operand + " ''.toLowerCase())";
                                                else
                                                    fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " && ($('option:selected', '#" + propertyName + "')") + ".text().toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                if (condValue.ToLower().Trim() == "null")
                                                    fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "($('option:selected', '#" + propertyName + "') ") + ".val().toLowerCase() " + operand + "''.toLowerCase())";
                                                else
                                                    fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "($('option:selected', '#" + propertyName + "') ") + ".text().toLowerCase() " + operand + " '" + condValue + "'.toLowerCase())";
                                            }
                                            else
                                            {
                                                if (condValue.ToLower().Trim() == "null")
                                                    fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " && ($('option:selected', '#" + propertyName + "')") + ".val().toLowerCase() " + operand + " ''.toLowerCase())";
                                                else
                                                    fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " && ($('option:selected', '#" + propertyName + "')") + ".text().toLowerCase() " + operand + " '" + condValue + "'.toLowerCase())";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string eventName = ".on('keyup keypress blur change',";
                                        chkSetValue.Append((rbcheck ? " $('input:radio[name=" + objCon.PropertyName + "]')" : " $('#" + objCon.PropertyName + "')") + eventName + " function(event) { " + fnCondition + "; });");
                                        if (operand.Length > 2)
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                if (condValue.ToLower().Trim() == "'null'")
                                                    fnConditionValue = "($('#" + objCon.PropertyName + "').val().length == 0)";
                                                else
                                                    fnConditionValue = "($('#" + objCon.PropertyName + "').val().toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                            else
                                            {
                                                if (condValue.ToLower().Trim() == "'null'")
                                                    fnConditionValue += " " + logicalconnector + " ($('#" + objCon.PropertyName + "').val().length == 0)";
                                                else
                                                    fnConditionValue += " " + logicalconnector + " ($('#" + objCon.PropertyName + "').val().toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                        }
                                        else
                                        {
                                            string strLowerCase = ".toLowerCase() ";
                                            string strCondValue = " '" + condValue + "'";
                                            if (datatype.ToLower() == "decimal" || datatype.ToLower() == "double" || datatype.ToLower() == "int32")
                                            {
                                                strLowerCase = "";
                                                strCondValue = condValue;
                                            }
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                if (objCon.PropertyName == "Id" && objCon.Operator == ">" && objCon.Value == "0" && brType == "OnEdit")
                                                    fnConditionValue = "($('#" + objCon.PropertyName + "').val() " + operand + " '" + objCon.Value + "')";
                                                else if (objCon.PropertyName == "Id" && objCon.Operator == ">" && objCon.Value == "0" && brType == "OnCreate")
                                                    fnConditionValue = "('true')";
                                                else
                                                {
                                                    if (strCondValue.ToLower().Trim() == "'null'")
                                                        fnConditionValue = "($('#" + objCon.PropertyName + "').val()" + strLowerCase + operand + "''" + strLowerCase + ")";
                                                    else
                                                        fnConditionValue = "($('#" + objCon.PropertyName + "').val()" + strLowerCase + operand + strCondValue + strLowerCase + ")";
                                                }
                                            }
                                            else
                                            {
                                                fnConditionValue += " " + logicalconnector + " ($('#" + objCon.PropertyName + "').val()" + strLowerCase + operand + strCondValue + strLowerCase + ")";
                                            }
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(chkSetValue.ToString()))
                                {
                                    chkSetValue.Append(" });");
                                    long[] ids = objRuleActionList.Select(item => item.Id).ToArray();
                                    var objActionArgsList= objActionArgs.ActionArgss.Where(aa => ids.Any(x => x == aa.ActionArgumentsID));
                                    //var objActionArgsList = objActionArgs.ActionArgss.Where(aa => aa.ActionArgumentsID == objRA.Id);
                                    if (objActionArgsList.Count() > 0)
                                    {
                                        string fnName = string.Empty;
                                        string fnProp = string.Empty;
                                        string fn = string.Empty;
                                        bool IsNotElseAssoc = true;
										bool IsNotElseValue = true;
                                        foreach (ActionArgs objaa in objActionArgsList)
                                        {
                                            string paramValue = objaa.ParameterValue;
											string paramType = checkPropType(entityName, objaa.ParameterName);
                                            if (paramValue.ToLower().Trim().Contains("today"))
                                            {
                                                paramValue = ApplyRule.EvaluateDateForActionInTarget(paramValue);
                                                fnProp += "$('#" + objaa.ParameterName + "').change();$('#" + objaa.ParameterName + "').val('" + paramValue + "');";
                                            }
                                            else if (paramValue.StartsWith("[") && paramValue.EndsWith("]"))
                                            {
                                                paramValue = paramValue.TrimStart('[').TrimEnd(']').Trim();
                                                paramValue = "$('#" + paramValue + "').val()";
                                                fnProp += "$('#" + objaa.ParameterName + "').change();$('#" + objaa.ParameterName + "').val(" + paramValue + ");";
                                            }
                                                if (paramType == "Association")
                                            {
                                                if (IsNotElseAssoc)
                                                {
                                                    string parameterName = objaa.ParameterName;
                                                    if (parameterName.StartsWith("[") && parameterName.EndsWith("]"))
                                                    {
                                                         var parameterSplit = parameterName.Substring(1, parameterName.Length - 2).Split('.');
                                                        string[] inlineAssoList = {  };
                                                    if (inlineAssoList.Length > 0 && inlineAssoList.Contains(parameterSplit[0].Trim()))
                                                            parameterName = parameterSplit[0].Replace("ID", "").ToLower().Trim() + "_" + parameterSplit[1].ToString().Trim();
                                                        else
                                                            parameterName = parameterSplit[0];
                                                    }
                                                      if (paramValue.ToLower().Trim() == "null")
                                                    {
                                                        fnProp += "$('#" + parameterName + "').trigger('chosen:open');";
                                                        fnProp += "$('#" + parameterName + " option').map(function () { if ($(this).val() == '') return this; }).attr('selected', 'selected');";
                                                    }
                                                    else
                                                    {
                                                        fnProp += "$('#" + parameterName + "_chosen').find('input').val('" + paramValue + "');";
                                                        fnProp += "$('#" + parameterName + "').trigger('chosen:open');";
                                                        fnProp += "$('#" + parameterName + " option').map(function () { if ($(this).text() == '" + paramValue + "') return this; }).attr('selected', 'selected');";
                                                    }
                                                    fnProp += "$('#" + parameterName + "').trigger('click.chosen');";
                                                    fnProp += "$('#" + parameterName + "').trigger('chosen:updated');";
                                                    fnProp += "$('#" + parameterName + "').trigger('change');";
                                                    IsNotElseAssoc = false;
                                                }
                                                else
                                                {
                                                    string parameterName = objaa.ParameterName;
                                                    if (parameterName.StartsWith("[") && parameterName.EndsWith("]"))
                                                    {
                                                         var parameterSplit = parameterName.Substring(1, parameterName.Length - 2).Split('.');
                                                        string[] inlineAssoList = {  };
                                                    if (inlineAssoList.Length > 0 && inlineAssoList.Contains(parameterSplit[0].Trim()))
                                                            parameterName = parameterSplit[0].Replace("ID", "").ToLower().Trim() + "_" + parameterSplit[1].ToString().Trim();
                                                        else
                                                            parameterName = parameterSplit[0];
                                                    }
                                                    fnProp += "}else {";
                                                     if (paramValue.ToLower().Trim() == "null")
                                                    {
                                                        fnProp += "$('#" + parameterName + "').trigger('chosen:open');";
                                                        fnProp += "$('#" + parameterName + " option').map(function () { if ($(this).val() == '') return this; }).attr('selected', 'selected');";
                                                    }
                                                    else
                                                    {
                                                        fnProp += "$('#" + parameterName + "_chosen').find('input').val('" + paramValue + "');";
                                                        fnProp += "$('#" + parameterName + "').trigger('chosen:open');";
                                                        fnProp += "$('#" + parameterName + " option').map(function () { if ($(this).text() == '" + paramValue + "') return this; }).attr('selected', 'selected');";
                                                    }
                                                    fnProp += "$('#" + parameterName + "').trigger('click.chosen');";
                                                    fnProp += "$('#" + parameterName + "').trigger('chosen:updated');";
                                                    fnProp += "$('#" + parameterName + "').trigger('change');";
                                                }
                                            }
                                            else
											{
                                               if (IsNotElseValue)
                                                {
												if (paramValue.ToLower().Trim() == "null")
													paramValue = "";
                                                    fnProp += "$('#" + objaa.ParameterName + "').change();  $('#" + objaa.ParameterName + "').val('" + paramValue + "');";
                                                    IsNotElseValue = false;
                                                }
                                                else
                                                {
												if (paramValue.ToLower().Trim() == "null")
													paramValue = "";
                                                    fnProp += "}else {";
                                                    fnProp += " $('#" + objaa.ParameterName + "').change(); $('#" + objaa.ParameterName + "').val('" + paramValue + "');";
                                                }
											}
                                            fn += objaa.Id.ToString();
                                        }
                                        //if (fnCondition == "")
                                        //    continue;
                                        if (!string.IsNullOrEmpty(fn))
                                            fnName = "setvalueUIRuleProp" + fn;
                                        if (!string.IsNullOrEmpty(fnName))
                                        {
                                            chkSetValue.Append("function " + fnCondition + " { if ( " + fnConditionValue + " ) { " + fnProp + " } }");
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(chkFnSetValue.ToString()))
                                {
                                    chkSetValue.Append(chkFnSetValue.ToString());
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(chkSetValue.ToString()))
                        {
                            chkSetValue.Append("</script> ");
                            SetValueBRString.Append(chkSetValue);
                        }
                    }
                }
            }
            return SetValueBRString.ToString();
        }
        public string checkOperator(string condition)
        {
            string opr = string.Empty;
            switch (condition)
            {
                case "=":
                    opr = "==";
                    break;
                case "Contains":
                    opr = "Contains";
                    break;
                default:
                    opr = condition;
                    break;
            }
            return opr;
        }
		public string getPropertyAttribute(string EntityName, string PropName)
        {
            if (PropName == "Id")
                return "long";
            var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == EntityName);
            var PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == PropName);
            var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == PropName);
            if (PropName.StartsWith("[") && PropName.EndsWith("]"))
            {
                PropName = PropName.TrimStart("[".ToArray()).TrimEnd("]".ToArray());
                if (PropName.Contains("."))
                {
                    var targetProperties = PropName.Split(".".ToCharArray());
                    if (targetProperties.Length > 1)
                    {
                        AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                        if (AssociationInfo != null)
                        {
                            EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                            PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == targetProperties[1]);
                        }
                    }
                }
            }
            string DataTypeAttribute = PropInfo.DataTypeAttribute;
            if (AssociationInfo != null)
            {
                DataTypeAttribute = "Association";
            }
            return DataTypeAttribute;
        }
        public string checkPropType(string EntityName, string PropName)
        {
			if (PropName == "Id")
                return "long";
            var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == EntityName);
            var PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == PropName);
            var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == PropName);
            if (PropName.StartsWith("[") && PropName.EndsWith("]"))
            {
                PropName = PropName.TrimStart("[".ToArray()).TrimEnd("]".ToArray());
                if (PropName.Contains("."))
                {
                    var targetProperties = PropName.Split(".".ToCharArray());
                    if (targetProperties.Length > 1)
                    {
                        AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                        if (AssociationInfo != null)
                        {
                            EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                            PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == targetProperties[1]);
                        }
                    }
                }
            }
            string DataType = PropInfo.DataType;
            if (AssociationInfo != null)
            {
                DataType = "Association";
            }
            return DataType;
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Check1MThresholdValue(T_UnitX t_unitx)
        {
            Dictionary<string, string> msgThreshold = new Dictionary<string, string>();
            return Json(msgThreshold, JsonRequestBehavior.AllowGet);
        }
		//code for verb action security
        public string[] getVerbsName()
        {
            string[] Verbsarr = new string[] { "BulkUpdate","BulkDelete","ImportExcel","ExportExcel"   };
            return Verbsarr;
        }
        //
		//code for list of groups
        public string[][] getGroupsName()
        {
            string[][] groupsarr = new string[][] { new string[] {"48910","T_UnitX48910"},new string[] {"48907","Basic Details"},new string[] {"48909","Beds"},new string[] {"48908","Accounting Codes"} };
            return groupsarr;
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCalculationValues(T_UnitX t_unitx)
        {
            t_unitx.setCalculation();
            Dictionary<string, string> Calculations = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_unitx.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
		    var T_TotalBedsProperty = properties.FirstOrDefault(p => p.Name == "T_TotalBeds");
            if (T_TotalBedsProperty != null)
            {
			  object PropValue = T_TotalBedsProperty.GetValue(t_unitx, null);
				       Calculations.Add("T_TotalBeds", Convert.ToString(PropValue));
		            }
            return Json(Calculations, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		//get Templates 
		// select templates 
        public void GetTemplatesForList(string defaultview)
        {
            string pageNameList = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_UnitX"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.ListEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageNameList = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageNameList) && IsInRoles)
                ViewBag.TemplatesName = pageNameList;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForDetails(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_UnitX"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.ViewEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForEdit(string defaultview)
        {
            string pageEdit = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_UnitX"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.EditEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageEdit = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageEdit) && IsInRoles)
                ViewBag.TemplatesName = pageEdit;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForCreateQuick(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_UnitX"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.CreateEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForCreate(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_UnitX"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.CreateEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForEditQuick(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_UnitX"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.EditEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForCreateWizard(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_UnitX"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.CreateWizardEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForEditWizard(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_UnitX"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.EditWizardEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForSearch()
        {
            string pageSearch = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_UnitX"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.SearchEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageSearch = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageSearch) && IsInRoles)
                ViewBag.TemplatesName = pageSearch;
            else
                ViewBag.TemplatesName = "SetFSearch";
        }
				//
	[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDerivedDetails(T_UnitX t_unitx, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_unitx.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
 
			var T_ProgramsourceProp = properties.FirstOrDefault(p => p.Name == "T_WardCostCenterID");
            if (T_ProgramsourceProp != null)
            {
                object sourcePropValue = T_ProgramsourceProp.GetValue(t_unitx, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_Program");
                if (Property != null && sourcePropValue != null)
                {
					T_CostCenterController objController = new T_CostCenterController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_CostProgramID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_ProgramController InnerController = new T_ProgramController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_Program"))
                            derivedlist.Add("T_Program", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_Program"))
                   derivedlist.Add("T_Program", "");
            }
 
			var T_FundsourceProp = properties.FirstOrDefault(p => p.Name == "T_WardCostCenterID");
            if (T_FundsourceProp != null)
            {
                object sourcePropValue = T_FundsourceProp.GetValue(t_unitx, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_Fund");
                if (Property != null && sourcePropValue != null)
                {
					T_CostCenterController objController = new T_CostCenterController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_CostFundID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_FundController InnerController = new T_FundController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_Fund"))
                            derivedlist.Add("T_Fund", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_Fund"))
                   derivedlist.Add("T_Fund", "");
            }
            return Json(derivedlist, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDerivedDetailsInline(string host, string value, T_UnitX t_unitx, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
 
		if (host == "T_WardCostCenterID")
			{
			var T_ProgramsourceProp = host;
            if (T_ProgramsourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_CostCenterController objController = new T_CostCenterController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_CostProgramID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_ProgramController InnerController = new T_ProgramController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_Program"))
                            derivedlist.Add("T_Program", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_Program"))
                   derivedlist.Add("T_Program", "");
            }
			}
 
		if (host == "T_WardCostCenterID")
			{
			var T_FundsourceProp = host;
            if (T_FundsourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_CostCenterController objController = new T_CostCenterController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_CostFundID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_FundController InnerController = new T_FundController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_Fund"))
                            derivedlist.Add("T_Fund", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_Fund"))
                   derivedlist.Add("T_Fund", "");
            }
			}
            return Json(derivedlist, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public ActionResult getInlineAssociationsOfEntity()
        {
            List<string> list = new List<string> {  };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
	public ActionResult Download(string FileName)
        {
            string filename = FileName;
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "Files\\" + filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };
            return File(filedata, "application/force-download", Path.GetFileName(FileName));
        }
    }
}

