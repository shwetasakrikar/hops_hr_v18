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
    public partial class T_JobAssignmentController : BaseController
    {
		private void LoadViewDataForCount(T_JobAssignment t_jobassignment, string AssocType)
        {
        }
		private void LoadViewDataAfterOnEdit(T_JobAssignment t_jobassignment)
        {		
			 ViewBag.T_EmployeeJobAssignmentID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_jobassignment.T_EmployeeJobAssignmentID);
			 ViewBag.T_PositionJobAssignmentID = new SelectList(db.T_Positions, "ID", "DisplayValue", t_jobassignment.T_PositionJobAssignmentID);
			 ViewBag.T_JobAssignmentReasonID = new SelectList(db.T_ReasonforHires, "ID", "DisplayValue", t_jobassignment.T_JobAssignmentReasonID);
			 ViewBag.T_JobAssignmentUnitXID = new SelectList(db.T_UnitXs, "ID", "DisplayValue", t_jobassignment.T_JobAssignmentUnitXID);
			 ViewBag.T_JobAssignmentManagerEmployeeID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_jobassignment.T_JobAssignmentManagerEmployeeID);
			 ViewBag.T_EmployeeSupervisorID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_jobassignment.T_EmployeeSupervisorID);
			CustomLoadViewDataListAfterEdit(t_jobassignment);
        }
        private void LoadViewDataBeforeOnEdit(T_JobAssignment t_jobassignment)
        {		
               var _objT_EmployeeJobAssignment = new List<T_Employee>();
               _objT_EmployeeJobAssignment.Add(t_jobassignment.t_employeejobassignment);
			   			   ViewBag.T_EmployeeJobAssignmentID = new SelectList(_objT_EmployeeJobAssignment, "ID", "DisplayValue", t_jobassignment.T_EmployeeJobAssignmentID);
			               var _objT_PositionJobAssignment = new List<T_Position>();
               _objT_PositionJobAssignment.Add(t_jobassignment.t_positionjobassignment);
			   			   ViewBag.T_PositionJobAssignmentID = new SelectList(_objT_PositionJobAssignment, "ID", "DisplayValue", t_jobassignment.T_PositionJobAssignmentID);
			               var _objT_JobAssignmentReason = new List<T_ReasonforHire>();
               _objT_JobAssignmentReason.Add(t_jobassignment.t_jobassignmentreason);
			   			   ViewBag.T_JobAssignmentReasonID = new SelectList(_objT_JobAssignmentReason, "ID", "DisplayValue", t_jobassignment.T_JobAssignmentReasonID);
			               var _objT_JobAssignmentUnitX = new List<T_UnitX>();
               _objT_JobAssignmentUnitX.Add(t_jobassignment.t_jobassignmentunitx);
			   			   ViewBag.T_JobAssignmentUnitXID = new SelectList(_objT_JobAssignmentUnitX, "ID", "DisplayValue", t_jobassignment.T_JobAssignmentUnitXID);
			               var _objT_JobAssignmentManagerEmployee = new List<T_Employee>();
               _objT_JobAssignmentManagerEmployee.Add(t_jobassignment.t_jobassignmentmanageremployee);
			   			   ViewBag.T_JobAssignmentManagerEmployeeID = new SelectList(_objT_JobAssignmentManagerEmployee, "ID", "DisplayValue", t_jobassignment.T_JobAssignmentManagerEmployeeID);
			               var _objT_EmployeeSupervisor = new List<T_Employee>();
               _objT_EmployeeSupervisor.Add(t_jobassignment.t_employeesupervisor);
			   			   ViewBag.T_EmployeeSupervisorID = new SelectList(_objT_EmployeeSupervisor, "ID", "DisplayValue", t_jobassignment.T_EmployeeSupervisorID);
				 ViewBag.T_JobAssignmentCommentsCount = t_jobassignment.t_jobassignmentcomments.Count();
	 ViewBag.T_PayDetailsJobAssignmentCount = t_jobassignment.t_paydetailsjobassignment.Count();
		CustomLoadViewDataListBeforeEdit(t_jobassignment);
        }
        private void LoadViewDataAfterOnCreate(T_JobAssignment t_jobassignment)
        {			
			 ViewBag.T_EmployeeJobAssignmentID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_jobassignment.T_EmployeeJobAssignmentID);
			 ViewBag.T_PositionJobAssignmentID = new SelectList(db.T_Positions, "ID", "DisplayValue", t_jobassignment.T_PositionJobAssignmentID);
			 ViewBag.T_JobAssignmentReasonID = new SelectList(db.T_ReasonforHires, "ID", "DisplayValue", t_jobassignment.T_JobAssignmentReasonID);
			 ViewBag.T_JobAssignmentUnitXID = new SelectList(db.T_UnitXs, "ID", "DisplayValue", t_jobassignment.T_JobAssignmentUnitXID);
			 ViewBag.T_JobAssignmentManagerEmployeeID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_jobassignment.T_JobAssignmentManagerEmployeeID);
			 ViewBag.T_EmployeeSupervisorID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_jobassignment.T_EmployeeSupervisorID);
		CustomLoadViewDataListAfterOnCreate(t_jobassignment);
        }
        private void LoadViewDataBeforeOnCreate(string HostingEntityName, string HostingEntityID, string AssociatedType)
        {			
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeJobAssignment")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeJobAssignmentID = new SelectList(db.T_Employees.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Employees.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeJobAssignment = new List<T_Employee>();
			 ViewBag.T_EmployeeJobAssignmentID = new SelectList(objT_EmployeeJobAssignment , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Position" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionJobAssignment")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionJobAssignmentID = new SelectList(db.T_Positions.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Positions.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionJobAssignment = new List<T_Position>();
			 ViewBag.T_PositionJobAssignmentID = new SelectList(objT_PositionJobAssignment , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_ReasonforHire" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_JobAssignmentReason")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_JobAssignmentReasonID = new SelectList(db.T_ReasonforHires.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_ReasonforHires.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_JobAssignmentReason = new List<T_ReasonforHire>();
			 ViewBag.T_JobAssignmentReasonID = new SelectList(objT_JobAssignmentReason , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_UnitX" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_JobAssignmentUnitX")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_JobAssignmentUnitXID = new SelectList(db.T_UnitXs.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_UnitXs.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_JobAssignmentUnitX = new List<T_UnitX>();
			 ViewBag.T_JobAssignmentUnitXID = new SelectList(objT_JobAssignmentUnitX , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_JobAssignmentManagerEmployee")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_JobAssignmentManagerEmployeeID = new SelectList(db.T_Employees.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Employees.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_JobAssignmentManagerEmployee = new List<T_Employee>();
			 ViewBag.T_JobAssignmentManagerEmployeeID = new SelectList(objT_JobAssignmentManagerEmployee , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeSupervisor")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeSupervisorID = new SelectList(db.T_Employees.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Employees.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeSupervisor = new List<T_Employee>();
			 ViewBag.T_EmployeeSupervisorID = new SelectList(objT_EmployeeSupervisor , "ID", "DisplayValue");
		    }
			CustomLoadViewDataListBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
        }
        public ActionResult CopyFromT_JobAssignment(string UrlReferrer,string HostingEntityName, string HostingEntityID, string AssociatedType, bool? IsDDAdd)
        {
            if (!User.CanAdd("T_JobAssignment"))
            {
                return RedirectToAction("Index", "Error");
            }
		 if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
		  ViewData["T_JobAssignmentParentUrl"] = UrlReferrer;
		  ViewData["AssociatedType"] = AssociatedType;
		  ViewData["HostingEntityName"] = HostingEntityName;
		  ViewData["HostingEntityID"] = HostingEntityID;
		  var objT_JobAssignment = new List<T_JobAssignment>();
          ViewBag.T_JobAssignmentID = new SelectList(objT_JobAssignment, "ID", "DisplayValue");
          return View();
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CopyFromT_JobAssignment(string T_JobAssignmentID, string UrlReferrer, bool? IsDDAdd, string HostingEntityName, string HostingEntityID, string AssociatedType)
        {
            T_JobAssignment Source_t_jobassignment = null;
			T_JobAssignment t_jobassignment = new T_JobAssignment();
            int T_JobAssignmentId = 0;
            if (Int32.TryParse(T_JobAssignmentID, out T_JobAssignmentId))
            {
                if (T_JobAssignmentId == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Source_t_jobassignment = db.T_JobAssignments.Find(T_JobAssignmentId);
                if (Source_t_jobassignment == null)
                {
                    return HttpNotFound();
                }
                EntityCopy.CopyValues(Source_t_jobassignment, t_jobassignment, "StartDate-StartDate,EndDate-EndDate,Active-Active,Primary-Primary,PositionLevel-PositionLevel,RestrictionTypeandRelatedNotes-RestrictionTypeandRelatedNotes,WorkersCompRelated-WorkersCompRelated,ShortTermDisabilityRelated-ShortTermDisabilityRelated,TypeofRestriction-TypeofRestriction,Notes-Notes,EmployeePercent-EmployeePercent,CostCenter-CostCenter,JobAssignmentWard-JobAssignmentWard,JobAssignmentDepartmentArea-JobAssignmentDepartmentArea,EmployeeSupervisor-EmployeeSupervisor,JobAssignmentManagerEmployee-JobAssignmentManagerEmployee,JobAssignmentDepartment-JobAssignmentDepartment,RelatedInjury-RelatedInjury,EmployeeJobAssignment-EmployeeJobAssignment,PositionJobAssignment-PositionJobAssignment","T_");
            }
			else
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeJobAssignment")
			{
				t_jobassignment.T_EmployeeJobAssignmentID = Convert.ToInt64(HostingEntityID);
			}
			if(HostingEntityName == "T_Position" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionJobAssignment")
			{
				t_jobassignment.T_PositionJobAssignmentID = Convert.ToInt64(HostingEntityID);
			}
			if(HostingEntityName == "T_ReasonforHire" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_JobAssignmentReason")
			{
				t_jobassignment.T_JobAssignmentReasonID = Convert.ToInt64(HostingEntityID);
			}
			if(HostingEntityName == "T_UnitX" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_JobAssignmentUnitX")
			{
				t_jobassignment.T_JobAssignmentUnitXID = Convert.ToInt64(HostingEntityID);
			}
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_JobAssignmentManagerEmployee")
			{
				t_jobassignment.T_JobAssignmentManagerEmployeeID = Convert.ToInt64(HostingEntityID);
			}
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeSupervisor")
			{
				t_jobassignment.T_EmployeeSupervisorID = Convert.ToInt64(HostingEntityID);
			}
            if (ValidateModel(t_jobassignment))
            {
                string command = Request.Form["hdncommand"];
 
				db.T_JobAssignments.Add(t_jobassignment);
                db.SaveChanges();
				//if (command == "Create & Continue")
                    return RedirectToAction("Edit", new { Id = t_jobassignment.Id, UrlReferrer = UrlReferrer });
                if (!string.IsNullOrEmpty(UrlReferrer))
                    return Redirect(UrlReferrer);
                else return RedirectToAction("Index");
            }
            if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
            LoadViewDataAfterOnCreate(t_jobassignment);
            return View(t_jobassignment);
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CopyFromT_JobAssignmentAsAction(string T_JobAssignmentID, string UrlReferrer, bool? IsDDAdd, string HostingEntityName, string HostingEntityID, string AssociatedType, ApplicationContext db)
        {
            T_JobAssignment Source_t_jobassignment = null;
			T_JobAssignment t_jobassignment = new T_JobAssignment();
            int T_JobAssignmentId = 0;
            if (Int32.TryParse(T_JobAssignmentID, out T_JobAssignmentId))
            {
                if (T_JobAssignmentId == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Source_t_jobassignment = db.T_JobAssignments.Find(T_JobAssignmentId);
                if (Source_t_jobassignment == null)
                {
                    return HttpNotFound();
                }
                EntityCopy.CopyValues(Source_t_jobassignment, t_jobassignment, "StartDate-StartDate,EndDate-EndDate,Active-Active,Primary-Primary,PositionLevel-PositionLevel,RestrictionTypeandRelatedNotes-RestrictionTypeandRelatedNotes,WorkersCompRelated-WorkersCompRelated,ShortTermDisabilityRelated-ShortTermDisabilityRelated,TypeofRestriction-TypeofRestriction,Notes-Notes,EmployeePercent-EmployeePercent,CostCenter-CostCenter,JobAssignmentWard-JobAssignmentWard,JobAssignmentDepartmentArea-JobAssignmentDepartmentArea,EmployeeSupervisor-EmployeeSupervisor,JobAssignmentManagerEmployee-JobAssignmentManagerEmployee,JobAssignmentDepartment-JobAssignmentDepartment,RelatedInjury-RelatedInjury,EmployeeJobAssignment-EmployeeJobAssignment,PositionJobAssignment-PositionJobAssignment","T_");
            }
			else
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeJobAssignment")
			{
				t_jobassignment.T_EmployeeJobAssignmentID = Convert.ToInt64(HostingEntityID);
			}
			if(HostingEntityName == "T_Position" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionJobAssignment")
			{
				t_jobassignment.T_PositionJobAssignmentID = Convert.ToInt64(HostingEntityID);
			}
			if(HostingEntityName == "T_ReasonforHire" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_JobAssignmentReason")
			{
				t_jobassignment.T_JobAssignmentReasonID = Convert.ToInt64(HostingEntityID);
			}
			if(HostingEntityName == "T_UnitX" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_JobAssignmentUnitX")
			{
				t_jobassignment.T_JobAssignmentUnitXID = Convert.ToInt64(HostingEntityID);
			}
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_JobAssignmentManagerEmployee")
			{
				t_jobassignment.T_JobAssignmentManagerEmployeeID = Convert.ToInt64(HostingEntityID);
			}
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeSupervisor")
			{
				t_jobassignment.T_EmployeeSupervisorID = Convert.ToInt64(HostingEntityID);
			}
            if (ValidateModel(t_jobassignment))
            {
 
				db.T_JobAssignments.Add(t_jobassignment);
                db.SaveChanges();
                    return RedirectToAction("Edit", new { Id = t_jobassignment.Id, UrlReferrer = UrlReferrer });
                if (!string.IsNullOrEmpty(UrlReferrer))
                    return Redirect(UrlReferrer);
                else return RedirectToAction("Index");
            }
            if (IsDDAdd != null)
                ViewBag.IsDDAdd = Convert.ToBoolean(IsDDAdd);
            LoadViewDataAfterOnCreate(t_jobassignment);
            return View(t_jobassignment);
        }
		private IQueryable<T_JobAssignment> searchRecords(IQueryable<T_JobAssignment> lstT_JobAssignment, string searchString, bool? IsDeepSearch)
        {
		   searchString = searchString.Trim();
		if(Convert.ToBoolean(IsDeepSearch))
            lstT_JobAssignment = lstT_JobAssignment.Where(s => (s.t_employeejobassignment!= null && (s.t_employeejobassignment.DisplayValue.ToUpper().Contains(searchString) )) ||(s.T_EmployeePercent != null && SqlFunctions.StringConvert((double)s.T_EmployeePercent).Contains(searchString)) ||(s.t_positionjobassignment!= null && (s.t_positionjobassignment.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_positionjobassignment.t_positionidentifier.DisplayValue) && s.t_positionjobassignment.t_positionidentifier.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_positionjobassignment.t_positionrolecode.DisplayValue) && s.t_positionjobassignment.t_positionrolecode.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_positionjobassignment.t_positionclasscode.DisplayValue) && s.t_positionjobassignment.t_positionclasscode.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_positionjobassignment.t_workerscompcodeposition.DisplayValue) && s.t_positionjobassignment.t_workerscompcodeposition.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_positionjobassignment.t_positionsoccode.DisplayValue) && s.t_positionjobassignment.t_positionsoccode.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_positionjobassignment.t_positionovertimeeligibility.DisplayValue) && s.t_positionjobassignment.t_positionovertimeeligibility.DisplayValue.ToUpper().Contains(searchString)) ||(s.t_jobassignmentreason!= null && (s.t_jobassignmentreason.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_jobassignmentunitx!= null && (s.t_jobassignmentunitx.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_jobassignmentunitx.t_wardcostcenter.DisplayValue) && s.t_jobassignmentunitx.t_wardcostcenter.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_jobassignmentunitx.T_Program) && s.t_jobassignmentunitx.T_Program.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_jobassignmentunitx.t_unitxdepartmentarea.DisplayValue) && s.t_jobassignmentunitx.t_unitxdepartmentarea.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_jobassignmentunitx.t_warddepartment.T_DepartmentTitle) && s.t_jobassignmentunitx.t_warddepartment.T_DepartmentTitle.ToUpper().Contains(searchString)) ||(s.t_jobassignmentmanageremployee!= null && (s.t_jobassignmentmanageremployee.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeesupervisor!= null && (s.t_employeesupervisor.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_employeesupervisor.T_WorkEmail) && s.t_employeesupervisor.T_WorkEmail.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_Notes) && s.T_Notes.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
		else
			 lstT_JobAssignment = lstT_JobAssignment.Where(s => (s.t_employeejobassignment!= null && (s.t_employeejobassignment.DisplayValue.ToUpper().Contains(searchString) )) ||(s.T_EmployeePercent != null && SqlFunctions.StringConvert((double)s.T_EmployeePercent).Contains(searchString)) ||(s.t_positionjobassignment!= null && (s.t_positionjobassignment.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_positionjobassignment.t_positionidentifier.DisplayValue) && s.t_positionjobassignment.t_positionidentifier.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_positionjobassignment.t_positionrolecode.DisplayValue) && s.t_positionjobassignment.t_positionrolecode.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_positionjobassignment.t_positionclasscode.DisplayValue) && s.t_positionjobassignment.t_positionclasscode.DisplayValue.ToUpper().Contains(searchString)) ||(s.t_jobassignmentreason!= null && (s.t_jobassignmentreason.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_jobassignmentunitx!= null && (s.t_jobassignmentunitx.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_jobassignmentunitx.t_wardcostcenter.DisplayValue) && s.t_jobassignmentunitx.t_wardcostcenter.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_jobassignmentunitx.T_Program) && s.t_jobassignmentunitx.T_Program.ToUpper().Contains(searchString)) ||(s.t_jobassignmentmanageremployee!= null && (s.t_jobassignmentmanageremployee.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeesupervisor!= null && (s.t_employeesupervisor.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
			try
            {
                var boolvalue = Convert.ToBoolean(searchString);
                lstT_JobAssignment = lstT_JobAssignment.Union(db.T_JobAssignments.Where(s => (s.T_Primary == boolvalue) ||(s.T_Active == boolvalue) ));
            }
            catch { }
			try
            {
                var datevalue = Convert.ToDateTime(searchString);
                lstT_JobAssignment = lstT_JobAssignment.Union(db.T_JobAssignments.Where(s => (s.T_StartDate == datevalue) ||(s.T_EndDate == datevalue) ));
            }
            catch { }
            return lstT_JobAssignment;
        }
		private IQueryable<T_JobAssignment> sortRecords(IQueryable<T_JobAssignment> lstT_JobAssignment, string sortBy, string isAsc)
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
	 if(sortBy == "T_PositionLevelID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_positionjobassignment.t_positionidentifier.DisplayValue) : lstT_JobAssignment.OrderByDescending(p => p.t_positionjobassignment.t_positionidentifier.DisplayValue);
	 if(sortBy == "T_RoleCodeID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_positionjobassignment.t_positionrolecode.DisplayValue) : lstT_JobAssignment.OrderByDescending(p => p.t_positionjobassignment.t_positionrolecode.DisplayValue);
	 if(sortBy == "T_ClassCodeID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_positionjobassignment.t_positionclasscode.DisplayValue) : lstT_JobAssignment.OrderByDescending(p => p.t_positionjobassignment.t_positionclasscode.DisplayValue);
	 if(sortBy == "T_CostCenterID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_jobassignmentunitx.t_wardcostcenter.DisplayValue) : lstT_JobAssignment.OrderByDescending(p => p.t_jobassignmentunitx.t_wardcostcenter.DisplayValue);
	 if(sortBy == "T_ProgramID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_jobassignmentunitx.T_Program) : lstT_JobAssignment.OrderByDescending(p => p.t_jobassignmentunitx.T_Program);
	 if(sortBy == "T_EmployeeJobAssignmentID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_employeejobassignment.DisplayValue) : lstT_JobAssignment.OrderByDescending(p => p.t_employeejobassignment.DisplayValue);
	 if(sortBy == "T_PositionJobAssignmentID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_positionjobassignment.DisplayValue) : lstT_JobAssignment.OrderByDescending(p => p.t_positionjobassignment.DisplayValue);
	 if(sortBy == "T_JobAssignmentReasonID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_jobassignmentreason.DisplayValue) : lstT_JobAssignment.OrderByDescending(p => p.t_jobassignmentreason.DisplayValue);
	 if(sortBy == "T_JobAssignmentUnitXID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_jobassignmentunitx.DisplayValue) : lstT_JobAssignment.OrderByDescending(p => p.t_jobassignmentunitx.DisplayValue);
	 if(sortBy == "T_JobAssignmentManagerEmployeeID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_jobassignmentmanageremployee.DisplayValue) : lstT_JobAssignment.OrderByDescending(p => p.t_jobassignmentmanageremployee.DisplayValue);
	 if(sortBy == "T_EmployeeSupervisorID")
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.OrderBy(p => p.t_employeesupervisor.DisplayValue) : lstT_JobAssignment.OrderByDescending(p => p.t_employeesupervisor.DisplayValue);
		    if (sortBy.Contains("."))
                return isAsc.ToLower() == "asc" ? lstT_JobAssignment.Sort(sortBy,true) : lstT_JobAssignment.Sort(sortBy,false);
            ParameterExpression paramExpression = Expression.Parameter(typeof(T_JobAssignment), "t_jobassignment");
            MemberExpression memExp = Expression.PropertyOrField(paramExpression, sortBy);
            LambdaExpression lambda = Expression.Lambda(memExp, paramExpression);
            return (IQueryable<T_JobAssignment>)lstT_JobAssignment.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { lstT_JobAssignment.ElementType, lambda.Body.Type },
                    lstT_JobAssignment.Expression,
                    lambda));
        }
		public ActionResult FindFSearch(string id, string sourceEntity)
        {
            if (sourceEntity == "FileDocument")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.FileDocuments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeeDocumentsID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Licenses")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Licensess.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_LicenseRecordsID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_ServiceRecord")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_ServiceRecords.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeeEmploymentProfileID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Comment")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Comments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeeCommentsID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_DrugAlcoholTest")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_DrugAlcoholTests.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeeDrugAlcoholTestID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_UnitX")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_UnitXs.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeeAdministratorID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_LeaveProfile")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_LeaveProfiles.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeeLeaveProfileID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_EmployeeInjury")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_EmployeeInjurys.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeeEmployeeInjuryID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_BackgroundCheck")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_BackgroundChecks.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeeCriminalBackgroundCheckID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Education")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Educations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeeEducationID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Accommodation")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Accommodations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeeAccomodationID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_PayDetails")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_PayDetailss.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeJobAssignment  = _Object.T_EmployeePayDetailsID;
						url += "&t_employeejobassignment=" + T_EmployeeJobAssignment;									
                Response.Redirect(url.ToString());
            }
            return null;
        }
        public ActionResult SetFSearch(string searchString, string HostingEntity ,string t_employeejobassignment,string t_positionjobassignment,string t_jobassignmentreason,string t_jobassignmentunitx,string t_jobassignmentmanageremployee,string t_employeesupervisor, bool? RenderPartial)
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
			var T_EmployeeJobAssignmentlist = db.T_Employees.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeejobassignment != null)
            {
                var ids = t_employeejobassignment.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee= ";
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
					var list = T_EmployeeJobAssignmentlist.Union(db.T_Employees.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
					ViewBag.t_employeejobassignment = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeJobAssignmentlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
				ViewBag.t_employeejobassignment = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionJobAssignmentlist = db.T_Positions.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionjobassignment != null)
            {
                var ids = t_positionjobassignment.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Position Number= ";
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
							   ViewBag.SearchResult += db.T_Positions.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PositionJobAssignmentlist.Union(db.T_Positions.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Position>(User, list, "T_Position", null);
					ViewBag.t_positionjobassignment = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionJobAssignmentlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Position>(User, list, "T_Position", null);
				ViewBag.t_positionjobassignment = new SelectList(list, "ID", "DisplayValue");
			}
			var T_JobAssignmentReasonlist = db.T_ReasonforHires.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_jobassignmentreason != null)
            {
                var ids = t_jobassignmentreason.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Job Assignment Reason= ";
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
							   ViewBag.SearchResult += db.T_ReasonforHires.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_JobAssignmentReasonlist.Union(db.T_ReasonforHires.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_ReasonforHire>(User, list, "T_ReasonforHire", null);
					ViewBag.t_jobassignmentreason = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_JobAssignmentReasonlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_ReasonforHire>(User, list, "T_ReasonforHire", null);
				ViewBag.t_jobassignmentreason = new SelectList(list, "ID", "DisplayValue");
			}
			var T_JobAssignmentUnitXlist = db.T_UnitXs.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_jobassignmentunitx != null)
            {
                var ids = t_jobassignmentunitx.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n UnitX= ";
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
							   ViewBag.SearchResult += db.T_UnitXs.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_JobAssignmentUnitXlist.Union(db.T_UnitXs.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_UnitX>(User, list, "T_UnitX", null);
					ViewBag.t_jobassignmentunitx = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_JobAssignmentUnitXlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_UnitX>(User, list, "T_UnitX", null);
				ViewBag.t_jobassignmentunitx = new SelectList(list, "ID", "DisplayValue");
			}
			var T_JobAssignmentManagerEmployeelist = db.T_Employees.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_jobassignmentmanageremployee != null)
            {
                var ids = t_jobassignmentmanageremployee.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Manager= ";
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
					var list = T_JobAssignmentManagerEmployeelist.Union(db.T_Employees.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
					ViewBag.t_jobassignmentmanageremployee = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_JobAssignmentManagerEmployeelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
				ViewBag.t_jobassignmentmanageremployee = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeSupervisorlist = db.T_Employees.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeesupervisor != null)
            {
                var ids = t_employeesupervisor.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Supervisor= ";
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
					var list = T_EmployeeSupervisorlist.Union(db.T_Employees.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
					ViewBag.t_employeesupervisor = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeSupervisorlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
				ViewBag.t_employeesupervisor = new SelectList(list, "ID", "DisplayValue");
			}
			}
			else
			{
			var objT_EmployeeJobAssignment = new List<T_Employee>();
		    ViewBag.t_employeejobassignment = new SelectList(objT_EmployeeJobAssignment, "ID", "DisplayValue");
			var objT_PositionJobAssignment = new List<T_Position>();
		    ViewBag.t_positionjobassignment = new SelectList(objT_PositionJobAssignment, "ID", "DisplayValue");
			var objT_JobAssignmentReason = new List<T_ReasonforHire>();
		    ViewBag.t_jobassignmentreason = new SelectList(objT_JobAssignmentReason, "ID", "DisplayValue");
			var objT_JobAssignmentUnitX = new List<T_UnitX>();
		    ViewBag.t_jobassignmentunitx = new SelectList(objT_JobAssignmentUnitX, "ID", "DisplayValue");
			var objT_JobAssignmentManagerEmployee = new List<T_Employee>();
		    ViewBag.t_jobassignmentmanageremployee = new SelectList(objT_JobAssignmentManagerEmployee, "ID", "DisplayValue");
			var objT_EmployeeSupervisor = new List<T_Employee>();
		    ViewBag.t_employeesupervisor = new SelectList(objT_EmployeeSupervisor, "ID", "DisplayValue");
			}
				var lstFavoriteItem = db.FavoriteItems.Where(p => p.LastUpdatedByUser == User.Name);
				if (lstFavoriteItem.Count() > 0)
                    ViewBag.FavoriteItem = lstFavoriteItem;
				ViewBag.EntityName = "T_JobAssignment";
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
			columns.Add("2", "Employee");
			columns.Add("3", "Employee Percent (%)");
			columns.Add("4", "Start Date");
			columns.Add("5", "End Date");
			columns.Add("6", "Primary");
			columns.Add("7", "Active");
			columns.Add("8", "Position Number");
			columns.Add("9", "Position Level");
			columns.Add("10", "Role Code ");
			columns.Add("11", "Class Code ");
			columns.Add("12", "Job Assignment Reason");
			columns.Add("13", "UnitX");
			columns.Add("14", "Cost Center");
			columns.Add("15", "Program");
			columns.Add("16", "Manager");
			columns.Add("17", "Supervisor");
				ViewBag.HideColumns = new MultiSelectList(columns, "Key", "Value");
				return View(new T_JobAssignment());
            }
		public string conditionFSearch(string property, string operators, string value)
        {
            string expression = string.Empty;
            var PrpertyType = GetDataTypeOfProperty("T_JobAssignment", property);
            var dataType = PrpertyType[0];
            property = PrpertyType[1];
            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                var ValueType = GetDataTypeOfProperty("T_JobAssignment", value, true);
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
							expression = string.Format(" DbFunctions.TruncateTime(" + property + ") " + operators + " (\"{0}\")", (TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (new T_JobAssignment()).m_Timezone)).Date);
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
		// GET: /T_JobAssignment/FSearch/
		[Audit("FacetedSearch")]
		public ActionResult FSearch(string currentFilter, string searchString, string FSFilter, string sortBy, string isAsc, int? page, int? itemsPerPage, string search, bool? IsExport ,string t_employeejobassignment,string t_positionjobassignment,string t_jobassignmentreason,string t_jobassignmentunitx,string t_jobassignmentmanageremployee,string t_employeesupervisor ,string T_EmployeePercentFrom,string T_EmployeePercentTo,string T_StartDateFrom,string T_StartDateTo,string T_EndDateFrom,string T_EndDateTo,string T_Primary,string T_Active,string FilterCondition, string HostingEntity, string AssociatedType,string HostingEntityID, string viewtype, string SortOrder, string HideColumns, string GroupByColumn,bool? IsReports, bool? IsdrivedTab)
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
				 var lstT_JobAssignment  = from s in db.T_JobAssignments
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_JobAssignment  = searchRecords(lstT_JobAssignment, searchString.ToUpper(),true);
            }
			  if(!string.IsNullOrEmpty(search))
                	search=search.Replace("?IsAddPop=true", "");
			if(!string.IsNullOrEmpty(search)){
				ViewBag.SearchResult += "\r\n General Criterial= "+search;
				lstT_JobAssignment = searchRecords(lstT_JobAssignment, search,true);
			}
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_JobAssignment  = sortRecords(lstT_JobAssignment, sortBy, isAsc);
            }
            else   lstT_JobAssignment  = lstT_JobAssignment.OrderByDescending(c => c.Id);
			lstT_JobAssignment = CustomSorting(lstT_JobAssignment);
			lstT_JobAssignment = lstT_JobAssignment.Include(t=>t.t_employeejobassignment).Include(t=>t.t_positionjobassignment).Include(t=>t.t_jobassignmentreason).Include(t=>t.t_jobassignmentunitx).Include(t=>t.t_jobassignmentmanageremployee).Include(t=>t.t_employeesupervisor);
					if (!string.IsNullOrEmpty(SortOrder) && SortOrder.Contains("T_OvertimeEligibility"))
                    {
                      SortOrder = SortOrder.Replace("T_OvertimeEligibility", "t_positionjobassignment.t_positionovertimeeligibility.DisplayValue");  
                    }
					if (!string.IsNullOrEmpty(SortOrder) && SortOrder.Contains("T_CostCenter"))
                    {
                      SortOrder = SortOrder.Replace("T_CostCenter", "t_jobassignmentunitx.t_wardcostcenter.DisplayValue");  
                    }
					if (!string.IsNullOrEmpty(SortOrder) && SortOrder.Contains("T_Program"))
                    {
                      SortOrder = SortOrder.Replace("T_Program", "t_jobassignmentunitx.T_Program");  
                    }
					if (!string.IsNullOrEmpty(SortOrder) && SortOrder.Contains("T_DepartmentArea"))
                    {
                      SortOrder = SortOrder.Replace("T_DepartmentArea", "t_jobassignmentunitx.t_unitxdepartmentarea.DisplayValue");  
                    }
					if (!string.IsNullOrEmpty(SortOrder) && SortOrder.Contains("T_SupervisorEmail"))
                    {
                      SortOrder = SortOrder.Replace("T_SupervisorEmail", "t_employeesupervisor.T_WorkEmail");  
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
					ViewBag.SearchResult += " " + GetPropertyDP("T_JobAssignment", PropertyName) + " " + Operator + " " + Value + " " + LogicalConnector;
					if (PropertyName == "T_Program")
                    {
                        PropertyName = "[T_JobAssignmentUnitXID.T_Program]";
                    }
					if (PropertyName == "T_SupervisorEmail")
                    {
                        PropertyName = "[T_EmployeeSupervisorID.T_WorkEmail]";
                    }
                    whereCondition.Append(conditionFSearch(PropertyName, Operator, Value) + LogicalConnector);
                    iCnt++;
                }
                if (!string.IsNullOrEmpty(whereCondition.ToString()))
                    lstT_JobAssignment = lstT_JobAssignment.Where(whereCondition.ToString());
                ViewBag.FilterCondition = FilterCondition;
            }
			var DataOrdering = string.Empty;
            if (!string.IsNullOrEmpty(GroupByColumn))
            {
                DataOrdering = GroupByColumn;
									if (DataOrdering.Contains("T_OvertimeEligibility"))
                    {
                      DataOrdering = DataOrdering.Replace("T_OvertimeEligibility", "t_positionjobassignment.t_positionovertimeeligibility.DisplayValue");  
                    }
					if (DataOrdering.Contains("T_CostCenter"))
                    {
                      DataOrdering = DataOrdering.Replace("T_CostCenter", "t_jobassignmentunitx.t_wardcostcenter.DisplayValue");  
                    }
					if (DataOrdering.Contains("T_Program"))
                    {
                      DataOrdering = DataOrdering.Replace("T_Program", "t_jobassignmentunitx.T_Program");  
                    }
					if (DataOrdering.Contains("T_DepartmentArea"))
                    {
                      DataOrdering = DataOrdering.Replace("T_DepartmentArea", "t_jobassignmentunitx.t_unitxdepartmentarea.DisplayValue");  
                    }
					if (DataOrdering.Contains("T_SupervisorEmail"))
                    {
                      DataOrdering = DataOrdering.Replace("T_SupervisorEmail", "t_employeesupervisor.T_WorkEmail");  
                    }
                ViewBag.IsGroupBy = true;
            }
            if (!string.IsNullOrEmpty(SortOrder))
                DataOrdering += SortOrder;
            if (!string.IsNullOrEmpty(DataOrdering))
                lstT_JobAssignment = Sorting.Sort<T_JobAssignment>(lstT_JobAssignment, DataOrdering);
            var _T_JobAssignment = lstT_JobAssignment;
		 if(T_EmployeePercentFrom!=null || T_EmployeePercentTo !=null)
		 {
                try
                {
                    int from = T_EmployeePercentFrom == null ? 0 : Convert.ToInt32(T_EmployeePercentFrom);
                    int to =  T_EmployeePercentTo == null ? int.MaxValue : Convert.ToInt32(T_EmployeePercentTo);
									     _T_JobAssignment =  _T_JobAssignment.Where(o => o.T_EmployeePercent >= from && o.T_EmployeePercent <= to);
                   					ViewBag.SearchResult += "\r\n Employee Percent (%)= "+from+"-"+to;
                }
                catch { }
          }
				if(T_StartDateFrom!=null || T_StartDateTo !=null)
				{
						try
						{
							DateTime from = T_StartDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_StartDateFrom);
							DateTime to = T_StartDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_StartDateTo).AddTicks(-1).AddDays(1);
							                       _T_JobAssignment =  _T_JobAssignment.Where(o =>o.T_StartDate!=null && o.T_StartDate.CompareTo(from) >= 0 && o.T_StartDate.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Start Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_EndDateFrom!=null || T_EndDateTo !=null)
				{
						try
						{
							DateTime from = T_EndDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_EndDateFrom);
							DateTime to = T_EndDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_EndDateTo).AddTicks(-1).AddDays(1);
							                       _T_JobAssignment =  _T_JobAssignment.Where(o =>o.T_EndDate!=null && o.T_EndDate.Value.CompareTo(from) >= 0 && o.T_EndDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n End Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
		 if(T_Primary!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_Primary);
                    _T_JobAssignment =  _T_JobAssignment.Where(o => o.T_Primary == boolvalue);
					ViewBag.SearchResult += "\r\n Primary= "+T_Primary;
                }
                catch { }
            }
		 if(T_Active!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_Active);
                    _T_JobAssignment =  _T_JobAssignment.Where(o => o.T_Active == boolvalue);
					ViewBag.SearchResult += "\r\n Active= "+T_Active;
                }
                catch { }
            }
			//if (lstT_JobAssignment.Where(p => p.t_employeejobassignment != null).Count() <= 50)
		    //ViewBag.t_employeejobassignment = new SelectList(lstT_JobAssignment.Where(p => p.t_employeejobassignment != null).Select(P => P.t_employeejobassignment).Distinct(), "ID", "DisplayValue");
            if (t_employeejobassignment != null)
            {
                var ids = t_employeejobassignment.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee= ";
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
                _T_JobAssignment = _T_JobAssignment.Where(p => ids1.Contains(p.T_EmployeeJobAssignmentID));
            }
				//if (lstT_JobAssignment.Where(p => p.t_positionjobassignment != null).Count() <= 50)
		    //ViewBag.t_positionjobassignment = new SelectList(lstT_JobAssignment.Where(p => p.t_positionjobassignment != null).Select(P => P.t_positionjobassignment).Distinct(), "ID", "DisplayValue");
            if (t_positionjobassignment != null)
            {
                var ids = t_positionjobassignment.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Position Number= ";
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
                            var obj = db.T_Positions.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_JobAssignment = _T_JobAssignment.Where(p => ids1.Contains(p.T_PositionJobAssignmentID));
            }
				//if (lstT_JobAssignment.Where(p => p.t_jobassignmentreason != null).Count() <= 50)
		    //ViewBag.t_jobassignmentreason = new SelectList(lstT_JobAssignment.Where(p => p.t_jobassignmentreason != null).Select(P => P.t_jobassignmentreason).Distinct(), "ID", "DisplayValue");
            if (t_jobassignmentreason != null)
            {
                var ids = t_jobassignmentreason.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Job Assignment Reason= ";
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
                            var obj = db.T_ReasonforHires.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_JobAssignment = _T_JobAssignment.Where(p => ids1.Contains(p.T_JobAssignmentReasonID));
            }
				//if (lstT_JobAssignment.Where(p => p.t_jobassignmentunitx != null).Count() <= 50)
		    //ViewBag.t_jobassignmentunitx = new SelectList(lstT_JobAssignment.Where(p => p.t_jobassignmentunitx != null).Select(P => P.t_jobassignmentunitx).Distinct(), "ID", "DisplayValue");
            if (t_jobassignmentunitx != null)
            {
                var ids = t_jobassignmentunitx.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n UnitX= ";
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
                            var obj = db.T_UnitXs.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_JobAssignment = _T_JobAssignment.Where(p => ids1.Contains(p.T_JobAssignmentUnitXID));
            }
				//if (lstT_JobAssignment.Where(p => p.t_jobassignmentmanageremployee != null).Count() <= 50)
		    //ViewBag.t_jobassignmentmanageremployee = new SelectList(lstT_JobAssignment.Where(p => p.t_jobassignmentmanageremployee != null).Select(P => P.t_jobassignmentmanageremployee).Distinct(), "ID", "DisplayValue");
            if (t_jobassignmentmanageremployee != null)
            {
                var ids = t_jobassignmentmanageremployee.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Manager= ";
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
                _T_JobAssignment = _T_JobAssignment.Where(p => ids1.Contains(p.T_JobAssignmentManagerEmployeeID));
            }
				//if (lstT_JobAssignment.Where(p => p.t_employeesupervisor != null).Count() <= 50)
		    //ViewBag.t_employeesupervisor = new SelectList(lstT_JobAssignment.Where(p => p.t_employeesupervisor != null).Select(P => P.t_employeesupervisor).Distinct(), "ID", "DisplayValue");
            if (t_employeesupervisor != null)
            {
                var ids = t_employeesupervisor.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Supervisor= ";
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
                _T_JobAssignment = _T_JobAssignment.Where(p => ids1.Contains(p.T_EmployeeSupervisorID));
            }
				if (!string.IsNullOrEmpty(SortOrder))
            {
                ViewBag.SearchResult += " \r\n Sort Order = ";
                var sortString = "";
                var sortProps = SortOrder.Split(",".ToCharArray());
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_JobAssignment");
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
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_JobAssignment");
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
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_JobAssignment"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_JobAssignment"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
            //
            if (Convert.ToBoolean(IsExport))
            {
                pageNumber = 1;
                if (_T_JobAssignment.Count() > 0)
                    pageSize = _T_JobAssignment.Count();
                return View("ExcelExport", _T_JobAssignment.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_JobAssignment.Count();
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
				var list = _T_JobAssignment.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_JobAssignmentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_JobAssignmentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_JobAssignment", tagsSplit.ToArray());
                    }
                return View("Index",list);
			}
            else
			{
				var list = _T_JobAssignment.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_JobAssignmentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_JobAssignmentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_JobAssignment", tagsSplit.ToArray());
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
		var entity = "T_JobAssignment";
           var chartlist = db.Charts.Where(chrt => chrt.EntityName == entity && chrt.ShowInDashBoard).ToList();
           if (type != "all")
               chartlist = chartlist.Where(chrt => chrt.Id == Convert.ToInt64(type)).ToList();
           var entitylist = db.T_JobAssignments;
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
                var gd = db.T_JobAssignments.GroupBy(p => p.t_employeejobassignment.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Employee (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Employee"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Employee", "Job Assignment"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "1", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).ToList();
                    if (_yvalT_EmployeePercent .Count > 10 && inlarge == null)
                    {
                        _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_EmployeePercent  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_EmployeePercent.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by Employee (Top 10)"));
				else
				chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by Employee"));
                chartT_EmployeePercent.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Employee", "T_EmployeePercent"));
                chartT_EmployeePercent.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_EmployeePercent.Series[0].Points.DataBindXY(_xval, _yvalT_EmployeePercent );
                chartT_EmployeePercent.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_EmployeePercent.Width = 800;
                        chartT_EmployeePercent.Height = 800;
                    }
                byte[] bytesT_EmployeePercent;
                using (var chartimage = new MemoryStream())
                {
                    chartT_EmployeePercent.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_EmployeePercent = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_EmployeePercent = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "2", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
                    else
                    {
                        string imgT_EmployeePercent = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
				}
            }
           {
                var gd = db.T_JobAssignments.GroupBy(p => p.t_positionjobassignment.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "3" || type == "all")
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
                chart.Titles.Add(CreateTitle("Count by Position Number (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Position Number"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Position Number", "Job Assignment"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "3", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
			if (type == "4" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).ToList();
                    if (_yvalT_EmployeePercent .Count > 10 && inlarge == null)
                    {
                        _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_EmployeePercent  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_EmployeePercent.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by Position Number (Top 10)"));
				else
				chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by Position Number"));
                chartT_EmployeePercent.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Position Number", "T_EmployeePercent"));
                chartT_EmployeePercent.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_EmployeePercent.Series[0].Points.DataBindXY(_xval, _yvalT_EmployeePercent );
                chartT_EmployeePercent.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_EmployeePercent.Width = 800;
                        chartT_EmployeePercent.Height = 800;
                    }
                byte[] bytesT_EmployeePercent;
                using (var chartimage = new MemoryStream())
                {
                    chartT_EmployeePercent.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_EmployeePercent = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_EmployeePercent = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "4", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
                    else
                    {
                        string imgT_EmployeePercent = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
				}
            }
           {
                var gd = db.T_JobAssignments.GroupBy(p => p.t_jobassignmentreason.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Job Assignment Reason (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Job Assignment Reason"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Job Assignment Reason", "Job Assignment"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "5", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).ToList();
                    if (_yvalT_EmployeePercent .Count > 10 && inlarge == null)
                    {
                        _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_EmployeePercent  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_EmployeePercent.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by Job Assignment Reason (Top 10)"));
				else
				chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by Job Assignment Reason"));
                chartT_EmployeePercent.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Job Assignment Reason", "T_EmployeePercent"));
                chartT_EmployeePercent.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_EmployeePercent.Series[0].Points.DataBindXY(_xval, _yvalT_EmployeePercent );
                chartT_EmployeePercent.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_EmployeePercent.Width = 800;
                        chartT_EmployeePercent.Height = 800;
                    }
                byte[] bytesT_EmployeePercent;
                using (var chartimage = new MemoryStream())
                {
                    chartT_EmployeePercent.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_EmployeePercent = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_EmployeePercent = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "6", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
                    else
                    {
                        string imgT_EmployeePercent = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
				}
            }
           {
                var gd = db.T_JobAssignments.GroupBy(p => p.t_jobassignmentunitx.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "7" || type == "all")
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
                chart.Titles.Add(CreateTitle("Count by UnitX (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by UnitX"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "UnitX", "Job Assignment"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "7", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
			if (type == "8" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).ToList();
                    if (_yvalT_EmployeePercent .Count > 10 && inlarge == null)
                    {
                        _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_EmployeePercent  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_EmployeePercent.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by UnitX (Top 10)"));
				else
				chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by UnitX"));
                chartT_EmployeePercent.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "UnitX", "T_EmployeePercent"));
                chartT_EmployeePercent.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_EmployeePercent.Series[0].Points.DataBindXY(_xval, _yvalT_EmployeePercent );
                chartT_EmployeePercent.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_EmployeePercent.Width = 800;
                        chartT_EmployeePercent.Height = 800;
                    }
                byte[] bytesT_EmployeePercent;
                using (var chartimage = new MemoryStream())
                {
                    chartT_EmployeePercent.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_EmployeePercent = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_EmployeePercent = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "8", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
                    else
                    {
                        string imgT_EmployeePercent = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
				}
            }
           {
                var gd = db.T_JobAssignments.GroupBy(p => p.t_jobassignmentmanageremployee.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Manager (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Manager"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Manager", "Job Assignment"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "9", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).ToList();
                    if (_yvalT_EmployeePercent .Count > 10 && inlarge == null)
                    {
                        _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_EmployeePercent  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_EmployeePercent.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by Manager (Top 10)"));
				else
				chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by Manager"));
                chartT_EmployeePercent.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Manager", "T_EmployeePercent"));
                chartT_EmployeePercent.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_EmployeePercent.Series[0].Points.DataBindXY(_xval, _yvalT_EmployeePercent );
                chartT_EmployeePercent.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_EmployeePercent.Width = 800;
                        chartT_EmployeePercent.Height = 800;
                    }
                byte[] bytesT_EmployeePercent;
                using (var chartimage = new MemoryStream())
                {
                    chartT_EmployeePercent.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_EmployeePercent = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_EmployeePercent = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "10", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
                    else
                    {
                        string imgT_EmployeePercent = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
				}
            }
           {
                var gd = db.T_JobAssignments.GroupBy(p => p.t_employeesupervisor.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "11" || type == "all")
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
                chart.Titles.Add(CreateTitle("Count by Supervisor (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Supervisor"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Supervisor", "Job Assignment"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "11", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
			if (type == "12" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).ToList();
                    if (_yvalT_EmployeePercent .Count > 10 && inlarge == null)
                    {
                        _yvalT_EmployeePercent = gd.Select(k => k.Sum(p=>p.T_EmployeePercent)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_EmployeePercent  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_EmployeePercent.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by Supervisor (Top 10)"));
				else
				chartT_EmployeePercent.Titles.Add(CreateTitle("Total of Employee Percent (%) by Supervisor"));
                chartT_EmployeePercent.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Supervisor", "T_EmployeePercent"));
                chartT_EmployeePercent.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_EmployeePercent.Series[0].Points.DataBindXY(_xval, _yvalT_EmployeePercent );
                chartT_EmployeePercent.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_EmployeePercent.Width = 800;
                        chartT_EmployeePercent.Height = 800;
                    }
                byte[] bytesT_EmployeePercent;
                using (var chartimage = new MemoryStream())
                {
                    chartT_EmployeePercent.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_EmployeePercent = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_EmployeePercent = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_JobAssignment", new { type = "12", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
                    }
                    else
                    {
                        string imgT_EmployeePercent = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_EmployeePercent = Convert.ToBase64String(bytesT_EmployeePercent.ToArray());
                        result += String.Format(imgT_EmployeePercent, encodedT_EmployeePercent);
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
            var _Obj = db1.T_JobAssignments.FirstOrDefault(p => p.Id == idvalue);
            return  _Obj==null?"":_Obj.DisplayValue;
        }
		public IQueryable<JournalEntry> GetExtraJournalEntry(int? id, Models.IUser user, JournalEntryContext jedb)
        {
			var listjournaliquery = jedb.JournalEntries.Where(p => p.Id == 0);
			Expression<Func<JournalEntry, bool>> predicateJournalEntry = n => false;
		var t_jobassignment = jedb.T_JobAssignments.Find(id);
			var T_JobAssignmentCommentsIds = jedb.T_Comments.Where(p=>p.T_JobAssignmentCommentsID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_Comment" && T_JobAssignmentCommentsIds.Contains(d.RecordId) && d.Type != "View"));
			var T_PayDetailsJobAssignmentIds = jedb.T_PayDetailss.Where(p=>p.T_PayDetailsJobAssignmentID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_PayDetails" && T_PayDetailsJobAssignmentIds.Contains(d.RecordId) && d.Type != "View"));
			
			listjournaliquery = new FilteredDbSet<JournalEntry>(jedb, predicateJournalEntry); 
			return listjournaliquery;
        }
		public object GetRecordById(string id)
        {
		            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            if (string.IsNullOrEmpty(id)) return "";
            var _Obj = db1.T_JobAssignments.Find(Convert.ToInt64(id));
            return _Obj;
        }
		public string GetRecordById_Reflection(string id)
        {
							ApplicationContext db1 = new ApplicationContext(new SystemUser());
			if (string.IsNullOrEmpty(id)) return "";
			var _Obj = db1.T_JobAssignments.Find(Convert.ToInt64(id));
            return _Obj == null ? "" : EntityComparer.EnumeratePropertyValues<T_JobAssignment>(_Obj, "T_JobAssignment", new string[] { ""  }); ;
			        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllValueForFilter(string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
		            IQueryable<T_JobAssignment> list = db.T_JobAssignments;
            var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                       select new { Id = x.Id, Name = x.DisplayValue };
            return Json(data, JsonRequestBehavior.AllowGet);
			        }
		[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValue(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_JobAssignment> list = db.T_JobAssignments;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_JobAssignments;
					string lambda = "";
                    foreach (var asso in AssoNameWithParent.Split("?".ToCharArray()))
                    {
                        lambda += asso + "=" + AssociationID + " OR ";
                    }
                    lambda = lambda.TrimEnd(" OR ".ToCharArray());
                    query = query.Where(lambda);
                   //Type[] exprArgTypes = { query.ElementType };
                   // string propToWhere = AssoNameWithParent;
                   // ParameterExpression p = Expression.Parameter(typeof(T_JobAssignment), "p");
                   // MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                   // LambdaExpression lambda = Expression.Lambda<Func<T_JobAssignment, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                   // MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                   // IQueryable q = query.Provider.CreateQuery(methodCall);
                   //list = ((IQueryable<T_JobAssignment>)q);
				   list = ((IQueryable<T_JobAssignment>)query);
                }
				else if (AssoID == 0)
                {
                   IQueryable query = db.T_JobAssignments;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_JobAssignment), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_JobAssignment, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_JobAssignment>)q);
                }
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_JobAssignment>(User,list, "T_JobAssignment",caller);
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
			IQueryable<T_JobAssignment> list = db.T_JobAssignments;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_JobAssignments;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_JobAssignment), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_JobAssignment, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_JobAssignment>)q);
                }
            }
			var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
        }
[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValueMobile(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_JobAssignment> list = db.T_JobAssignments;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
				try
                {
					Nullable<long> AssoID = Convert.ToInt64(AssociationID);
					if (AssoID != null && AssoID > 0)
					{
						IQueryable query = db.T_JobAssignments;
						Type[] exprArgTypes = { query.ElementType };
						string propToWhere = AssoNameWithParent;
						ParameterExpression p = Expression.Parameter(typeof(T_JobAssignment), "p");
						MemberExpression member = Expression.PropertyOrField(p, propToWhere);
						LambdaExpression lambda = Expression.Lambda<Func<T_JobAssignment, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
						MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
						IQueryable q = query.Provider.CreateQuery(methodCall);
						list = ((IQueryable<T_JobAssignment>)q).Take(20);
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
           list = _fad.FilterDropdown<T_JobAssignment>(User,list, "T_JobAssignment",caller);
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
            IQueryable<T_JobAssignment> list = db.T_JobAssignments;
            if (!string.IsNullOrEmpty(propNameBR))
            {
				//added new code (Remove old code if everything works)
				var result = list.Select("new(Id," + propNameBR + " as value)");
                return Json(result, JsonRequestBehavior.AllowGet);
				//
                ParameterExpression param = Expression.Parameter(typeof(T_JobAssignment), "d");
                //bulid expression tree:data.Field1
                var Property = typeof(T_JobAssignment).GetProperty(propNameBR);
                Expression selector = Expression.Property(param, Property);
                Expression pred = Expression.Lambda(selector, param);
                //bulid expression tree:Select(d=>d.Field1)
                var targetType = Property.PropertyType;
                if (targetType.GetGenericArguments().Count() > 0)
                {
                    if (targetType.GetGenericArguments()[0].Name == "DateTime")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select", 
                        new Type[] { typeof(T_JobAssignment), typeof(DateTime?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<DateTime?> query = list.Provider.CreateQuery<DateTime?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (targetType.GetGenericArguments()[0].Name == "Decimal")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_JobAssignment), typeof(decimal?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<decimal?> query = list.Provider.CreateQuery<decimal?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Boolean")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_JobAssignment), typeof(bool?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<bool?> query = list.Provider.CreateQuery<bool?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int32")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_JobAssignment), typeof(Int32?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int32?> query = list.Provider.CreateQuery<Int32?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int64")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_JobAssignment), typeof(Int64?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int64?> query = list.Provider.CreateQuery<Int64?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Double")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_JobAssignment), typeof(double?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<double?> query = list.Provider.CreateQuery<double?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    Expression expr = Expression.Call(typeof(Queryable), "Select",
                            new Type[] { typeof(T_JobAssignment), typeof(string) }, Expression.Constant(list.AsQueryable()), pred);
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
			IQueryable<T_JobAssignment> list = db.T_JobAssignments;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                IQueryable query = db.T_JobAssignments;
                Type[] exprArgTypes = { query.ElementType };
                string propToWhere = AssoNameWithParent;
                var AssoIDs = AssociationID.Split(',').ToList();
                List<ParameterExpression> paramList = new List<ParameterExpression>();
                paramList.Add(Expression.Parameter(typeof(T_JobAssignment), "p"));
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
                list = ((IQueryable<T_JobAssignment>)q);
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_JobAssignment>(User, list, "T_JobAssignment", null);
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

			if (!((CustomPrincipal)User).CanUseVerb("ImportExcel", "T_JobAssignment", User) || !User.CanAdd("T_JobAssignment"))
            {
                return RedirectToAction("Index", "Error");
            }
            //ViewBag.IsMapping = (db.ImportConfigurations.Where(p => p.Name == "T_JobAssignment")).Count() > 0 ? true : false;
            var lstMappings = db.ImportConfigurations.Where(p => p.Name == "T_JobAssignment").ToList();
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
                    var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_JobAssignment");
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
                        typeName = "T_JobAssignment";
                        //var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        //long idMapping = Convert.ToInt64(collection["ListOfMappings"]);
						string idMapping = collection["ListOfMappings"];
                        string ExistsColumnMappingName = string.Empty;
                        string mappingName = idMapping; //db.ImportConfigurations.Where(p => p.Name == typeName && p.Id == idMapping && !(string.IsNullOrEmpty(p.SheetColumn))).FirstOrDefault().MappingName;
                        var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && p.MappingName == mappingName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        if (collection["DefaultMapping"] == "on")
                        {
                            var lstMapping = db.ImportConfigurations.Where(p => p.Name == "T_JobAssignment" && p.IsDefaultMapping);
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
                        DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Job Assignments";
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
                                										 case "T_EmployeeJobAssignmentID":
										 var t_employeejobassignmentId = db.T_Employees.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeejobassignmentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionJobAssignmentID":
										 var t_positionjobassignmentId = db.T_Positions.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionjobassignmentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_JobAssignmentReasonID":
										 var t_jobassignmentreasonId = db.T_ReasonforHires.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_jobassignmentreasonId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_JobAssignmentUnitXID":
										 var t_jobassignmentunitxId = db.T_UnitXs.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_jobassignmentunitxId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_JobAssignmentManagerEmployeeID":
										 var t_jobassignmentmanageremployeeId = db.T_Employees.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_jobassignmentmanageremployeeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeSupervisorID":
										 var t_employeesupervisorId = db.T_Employees.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeesupervisorId == null)
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
			string typename = "T_JobAssignment";
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
                DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Job Assignments";
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
                var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_JobAssignment");
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
                                										 case "T_EmployeeJobAssignmentID":
										 var strPropertyT_EmployeeJobAssignment = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeJobAssignmentID").Value;
										 ModelReflector.Property propT_EmployeeJobAssignment = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeJobAssignment);
										 //var elementTypeT_EmployeeJobAssignment = db.T_Employees.ElementType;
										 //var propertyInfoT_EmployeeJobAssignment = elementTypeT_EmployeeJobAssignment.GetProperty(propT_EmployeeJobAssignment.Name);
										 // var t_employeejobassignmentId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeJobAssignment.GetValue(p, null)) == assovalue);
										 var t_employeejobassignmentId = db.T_Employees.Where(propT_EmployeeJobAssignment.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeejobassignmentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionJobAssignmentID":
										 var strPropertyT_PositionJobAssignment = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionJobAssignmentID").Value;
										 ModelReflector.Property propT_PositionJobAssignment = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Position").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionJobAssignment);
										 //var elementTypeT_PositionJobAssignment = db.T_Positions.ElementType;
										 //var propertyInfoT_PositionJobAssignment = elementTypeT_PositionJobAssignment.GetProperty(propT_PositionJobAssignment.Name);
										 // var t_positionjobassignmentId = db.T_Positions.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionJobAssignment.GetValue(p, null)) == assovalue);
										 var t_positionjobassignmentId = db.T_Positions.Where(propT_PositionJobAssignment.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionjobassignmentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_JobAssignmentReasonID":
										 var strPropertyT_JobAssignmentReason = lstEntityProp.FirstOrDefault(p => p.Key == "T_JobAssignmentReasonID").Value;
										 ModelReflector.Property propT_JobAssignmentReason = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ReasonforHire").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_JobAssignmentReason);
										 //var elementTypeT_JobAssignmentReason = db.T_ReasonforHires.ElementType;
										 //var propertyInfoT_JobAssignmentReason = elementTypeT_JobAssignmentReason.GetProperty(propT_JobAssignmentReason.Name);
										 // var t_jobassignmentreasonId = db.T_ReasonforHires.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_JobAssignmentReason.GetValue(p, null)) == assovalue);
										 var t_jobassignmentreasonId = db.T_ReasonforHires.Where(propT_JobAssignmentReason.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_jobassignmentreasonId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_JobAssignmentUnitXID":
										 var strPropertyT_JobAssignmentUnitX = lstEntityProp.FirstOrDefault(p => p.Key == "T_JobAssignmentUnitXID").Value;
										 ModelReflector.Property propT_JobAssignmentUnitX = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_UnitX").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_JobAssignmentUnitX);
										 //var elementTypeT_JobAssignmentUnitX = db.T_UnitXs.ElementType;
										 //var propertyInfoT_JobAssignmentUnitX = elementTypeT_JobAssignmentUnitX.GetProperty(propT_JobAssignmentUnitX.Name);
										 // var t_jobassignmentunitxId = db.T_UnitXs.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_JobAssignmentUnitX.GetValue(p, null)) == assovalue);
										 var t_jobassignmentunitxId = db.T_UnitXs.Where(propT_JobAssignmentUnitX.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_jobassignmentunitxId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_JobAssignmentManagerEmployeeID":
										 var strPropertyT_JobAssignmentManagerEmployee = lstEntityProp.FirstOrDefault(p => p.Key == "T_JobAssignmentManagerEmployeeID").Value;
										 ModelReflector.Property propT_JobAssignmentManagerEmployee = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_JobAssignmentManagerEmployee);
										 //var elementTypeT_JobAssignmentManagerEmployee = db.T_Employees.ElementType;
										 //var propertyInfoT_JobAssignmentManagerEmployee = elementTypeT_JobAssignmentManagerEmployee.GetProperty(propT_JobAssignmentManagerEmployee.Name);
										 // var t_jobassignmentmanageremployeeId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_JobAssignmentManagerEmployee.GetValue(p, null)) == assovalue);
										 var t_jobassignmentmanageremployeeId = db.T_Employees.Where(propT_JobAssignmentManagerEmployee.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_jobassignmentmanageremployeeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeSupervisorID":
										 var strPropertyT_EmployeeSupervisor = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeSupervisorID").Value;
										 ModelReflector.Property propT_EmployeeSupervisor = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeSupervisor);
										 //var elementTypeT_EmployeeSupervisor = db.T_Employees.ElementType;
										 //var propertyInfoT_EmployeeSupervisor = elementTypeT_EmployeeSupervisor.GetProperty(propT_EmployeeSupervisor.Name);
										 // var t_employeesupervisorId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeSupervisor.GetValue(p, null)) == assovalue);
										 var t_employeesupervisorId = db.T_Employees.Where(propT_EmployeeSupervisor.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeesupervisorId == null)
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
                        T_JobAssignment model = new T_JobAssignment();
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
    case "T_EmployeePercent":
    model.T_EmployeePercent = Int32.Parse(columnValue);
	break;
    case "T_StartDate":
    model.T_StartDate = DateTime.Parse(columnValue);
	break;
    case "T_EndDate":
    model.T_EndDate = DateTime.Parse(columnValue);
	break;
    case "T_Primary":
    model.T_Primary = Boolean.Parse(columnValue);
	break;
    case "T_Active":
    model.T_Active = Boolean.Parse(columnValue);
	break;
    case "T_PositionLevel":
    model.T_PositionLevel = columnValue;
	break;
    case "T_RoleCode":
    model.T_RoleCode = columnValue;
	break;
    case "T_ClassCode":
    model.T_ClassCode = columnValue;
	break;
    case "T_WorkersCompCode":
    model.T_WorkersCompCode = columnValue;
	break;
    case "T_SOCCode":
    model.T_SOCCode = columnValue;
	break;
    case "T_OvertimeEligibility":
    model.T_OvertimeEligibility = columnValue;
	break;
    case "T_CostCenter":
    model.T_CostCenter = columnValue;
	break;
    case "T_Program":
    model.T_Program = columnValue;
	break;
    case "T_DepartmentArea":
    model.T_DepartmentArea = columnValue;
	break;
    case "T_Department":
    model.T_Department = columnValue;
	break;
    case "T_SupervisorEmail":
    model.T_SupervisorEmail = columnValue;
	break;
    case "T_Notes":
    model.T_Notes = columnValue;
	break;
					 case "T_EmployeeJobAssignmentID":
		 dynamic t_employeejobassignmentId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeJobAssignment = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeJobAssignmentID").Value;
			 ModelReflector.Property propT_EmployeeJobAssignment = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeJobAssignment);
			 //var elementTypeT_EmployeeJobAssignment = db.T_Employees.ElementType;
			 //var propertyInfoT_EmployeeJobAssignment = elementTypeT_EmployeeJobAssignment.GetProperty(propT_EmployeeJobAssignment.Name);			 
			 //t_employeejobassignmentId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeJobAssignment.GetValue(p, null)) == columnValue);
			 t_employeejobassignmentId = db.T_Employees.Where(propT_EmployeeJobAssignment.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeejobassignmentId = db.T_Employees.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeejobassignmentId != null)
			model.T_EmployeeJobAssignmentID = t_employeejobassignmentId.Id;
		  else
			{
				if ((collection["T_EmployeeJobAssignmentID"].ToString() == "true,false"))
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
						model.T_EmployeeJobAssignmentID = objT_Employee.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionJobAssignmentID":
		 dynamic t_positionjobassignmentId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionJobAssignment = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionJobAssignmentID").Value;
			 ModelReflector.Property propT_PositionJobAssignment = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Position").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionJobAssignment);
			 //var elementTypeT_PositionJobAssignment = db.T_Positions.ElementType;
			 //var propertyInfoT_PositionJobAssignment = elementTypeT_PositionJobAssignment.GetProperty(propT_PositionJobAssignment.Name);			 
			 //t_positionjobassignmentId = db.T_Positions.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionJobAssignment.GetValue(p, null)) == columnValue);
			 t_positionjobassignmentId = db.T_Positions.Where(propT_PositionJobAssignment.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionjobassignmentId = db.T_Positions.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionjobassignmentId != null)
			model.T_PositionJobAssignmentID = t_positionjobassignmentId.Id;
		  else
			{
				if ((collection["T_PositionJobAssignmentID"].ToString() == "true,false"))
				{
					try
					{
						T_Position objT_Position = new T_Position();
						objT_Position.T_PositionNumber  = (columnValue);
				 try { objT_Position.T_EstablishedDate =Convert.ToDateTime(columnValue); }
                 catch { objT_Position.T_EstablishedDate = DateTime.MaxValue; }
						db.T_Positions.Add(objT_Position);
						db.SaveChanges();
						model.T_PositionJobAssignmentID = objT_Position.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_JobAssignmentReasonID":
		 dynamic t_jobassignmentreasonId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_JobAssignmentReason = lstEntityProp.FirstOrDefault(p => p.Key == "T_JobAssignmentReasonID").Value;
			 ModelReflector.Property propT_JobAssignmentReason = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ReasonforHire").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_JobAssignmentReason);
			 //var elementTypeT_JobAssignmentReason = db.T_ReasonforHires.ElementType;
			 //var propertyInfoT_JobAssignmentReason = elementTypeT_JobAssignmentReason.GetProperty(propT_JobAssignmentReason.Name);			 
			 //t_jobassignmentreasonId = db.T_ReasonforHires.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_JobAssignmentReason.GetValue(p, null)) == columnValue);
			 t_jobassignmentreasonId = db.T_ReasonforHires.Where(propT_JobAssignmentReason.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_jobassignmentreasonId = db.T_ReasonforHires.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_jobassignmentreasonId != null)
			model.T_JobAssignmentReasonID = t_jobassignmentreasonId.Id;
		  else
			{
				if ((collection["T_JobAssignmentReasonID"].ToString() == "true,false"))
				{
					try
					{
						T_ReasonforHire objT_ReasonforHire = new T_ReasonforHire();
						objT_ReasonforHire.T_Name  = (columnValue);
						db.T_ReasonforHires.Add(objT_ReasonforHire);
						db.SaveChanges();
						model.T_JobAssignmentReasonID = objT_ReasonforHire.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_JobAssignmentUnitXID":
		 dynamic t_jobassignmentunitxId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_JobAssignmentUnitX = lstEntityProp.FirstOrDefault(p => p.Key == "T_JobAssignmentUnitXID").Value;
			 ModelReflector.Property propT_JobAssignmentUnitX = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_UnitX").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_JobAssignmentUnitX);
			 //var elementTypeT_JobAssignmentUnitX = db.T_UnitXs.ElementType;
			 //var propertyInfoT_JobAssignmentUnitX = elementTypeT_JobAssignmentUnitX.GetProperty(propT_JobAssignmentUnitX.Name);			 
			 //t_jobassignmentunitxId = db.T_UnitXs.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_JobAssignmentUnitX.GetValue(p, null)) == columnValue);
			 t_jobassignmentunitxId = db.T_UnitXs.Where(propT_JobAssignmentUnitX.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_jobassignmentunitxId = db.T_UnitXs.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_jobassignmentunitxId != null)
			model.T_JobAssignmentUnitXID = t_jobassignmentunitxId.Id;
		  else
			{
				if ((collection["T_JobAssignmentUnitXID"].ToString() == "true,false"))
				{
					try
					{
						T_UnitX objT_UnitX = new T_UnitX();
						objT_UnitX.T_Unit  = (columnValue);
						db.T_UnitXs.Add(objT_UnitX);
						db.SaveChanges();
						model.T_JobAssignmentUnitXID = objT_UnitX.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_JobAssignmentManagerEmployeeID":
		 dynamic t_jobassignmentmanageremployeeId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_JobAssignmentManagerEmployee = lstEntityProp.FirstOrDefault(p => p.Key == "T_JobAssignmentManagerEmployeeID").Value;
			 ModelReflector.Property propT_JobAssignmentManagerEmployee = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_JobAssignmentManagerEmployee);
			 //var elementTypeT_JobAssignmentManagerEmployee = db.T_Employees.ElementType;
			 //var propertyInfoT_JobAssignmentManagerEmployee = elementTypeT_JobAssignmentManagerEmployee.GetProperty(propT_JobAssignmentManagerEmployee.Name);			 
			 //t_jobassignmentmanageremployeeId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_JobAssignmentManagerEmployee.GetValue(p, null)) == columnValue);
			 t_jobassignmentmanageremployeeId = db.T_Employees.Where(propT_JobAssignmentManagerEmployee.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_jobassignmentmanageremployeeId = db.T_Employees.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_jobassignmentmanageremployeeId != null)
			model.T_JobAssignmentManagerEmployeeID = t_jobassignmentmanageremployeeId.Id;
		  else
			{
				if ((collection["T_JobAssignmentManagerEmployeeID"].ToString() == "true,false"))
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
						model.T_JobAssignmentManagerEmployeeID = objT_Employee.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeSupervisorID":
		 dynamic t_employeesupervisorId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeSupervisor = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeSupervisorID").Value;
			 ModelReflector.Property propT_EmployeeSupervisor = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeSupervisor);
			 //var elementTypeT_EmployeeSupervisor = db.T_Employees.ElementType;
			 //var propertyInfoT_EmployeeSupervisor = elementTypeT_EmployeeSupervisor.GetProperty(propT_EmployeeSupervisor.Name);			 
			 //t_employeesupervisorId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeSupervisor.GetValue(p, null)) == columnValue);
			 t_employeesupervisorId = db.T_Employees.Where(propT_EmployeeSupervisor.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeesupervisorId = db.T_Employees.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeesupervisorId != null)
			model.T_EmployeeSupervisorID = t_employeesupervisorId.Id;
		  else
			{
				if ((collection["T_EmployeeSupervisorID"].ToString() == "true,false"))
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
						model.T_EmployeeSupervisorID = objT_Employee.Id;
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
			 if (model.T_StartDate == DateTime.MinValue)
                            model.T_StartDate =  DateTime.UtcNow;
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
									db.T_JobAssignments.Add(model);
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
		public bool ValidateModel(T_JobAssignment validate)
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
                var obj1 = db1.T_JobAssignments.Find(Id);
                System.Reflection.PropertyInfo[] properties = (obj1.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
                var Property = properties.FirstOrDefault(p => p.Name == PropName);
                object PropValue = Property.GetValue(obj1, null);
                return PropValue;
				            }
            catch { return null; }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetReadOnlyProperties(T_JobAssignment OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_JobAssignment").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.ReadOnlyPropertiesRule(OModel, BR, "T_JobAssignment");
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
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_JobAssignment");
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
        public JsonResult GetMandatoryProperties(T_JobAssignment OModel, string ruleType)
        {
            Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_JobAssignment").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
                    if (ruleType == "OnCreate")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 2).ToList();
                    else if (ruleType == "OnEdit")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 1).ToList();
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_JobAssignment");
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
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_JobAssignment");
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
        public JsonResult GetUIAlertBusinessRules(T_JobAssignment OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_JobAssignment").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.UIAlertRule(OModel, BR, "T_JobAssignment");
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
        public JsonResult GetValidateBeforeSaveProperties(T_JobAssignment OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_JobAssignment").ToList();
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
                    var ResultOfBusinessRules = db.ValidateBeforeSavePropertiesRule(OModel, BR, "T_JobAssignment",state);
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
                                    var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_JobAssignment");
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
        public JsonResult GetLockBusinessRules(T_JobAssignment OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            //string RulesApplied = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_JobAssignment").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.LockEntityRule(OModel, BR, "T_JobAssignment");
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
		private List<string> CheckMandatoryProperties(T_JobAssignment OModel)
        {
            List<string> result = new List<string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_JobAssignment").ToList();
                Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
                if (BR != null && BR.Count > 0)
                {
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_JobAssignment");
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
                                var dispName = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_JobAssignment").Properties.FirstOrDefault(p => p.Name == paramName).DisplayName;
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
            var _Obj = db1.T_JobAssignments.FirstOrDefault(p => p.DisplayValue == displayvalue);
            long outValue;
            if (_Obj != null)
                return Int64.TryParse(_Obj.Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				public long? GetIdFromPropertyValue(string PropName, string PropValue)
        {
            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            IQueryable query = db1.T_JobAssignments;
            Type[] exprArgTypes = { query.ElementType };
            string propToWhere = PropName;
            ParameterExpression p = Expression.Parameter(typeof(T_JobAssignment), "p");
            MemberExpression member = Expression.PropertyOrField(p, propToWhere);
            LambdaExpression lambda = null;
            if (PropValue.ToLower().Trim() != "null")
            lambda = Expression.Lambda<Func<T_JobAssignment, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(PropValue), member.Type)), p);
            else
                lambda = Expression.Lambda<Func<T_JobAssignment, bool>>(Expression.Equal(member, Expression.Constant(null, member.Type)), p);
            MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
            IQueryable q = query.Provider.CreateQuery(methodCall);
            long outValue;
            var list1 = ((IQueryable<T_JobAssignment>)q);
            if (list1 != null && list1.Count() > 0)
                return Int64.TryParse(list1.FirstOrDefault().Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPropertyValueByEntityId(long Id, string PropName)
        {
								ApplicationContext db1 = new ApplicationContext(new SystemUser());
            var obj1 = db1.T_JobAssignments.Find(Id);
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
        public JsonResult Check1MThresholdValue(T_JobAssignment t_jobassignment)
        {
            Dictionary<string, string> msgThreshold = new Dictionary<string, string>();
            return Json(msgThreshold, JsonRequestBehavior.AllowGet);
        }
		//code for verb action security
        public string[] getVerbsName()
        {
            string[] Verbsarr = new string[] { "BulkUpdate","BulkDelete","ImportExcel","ExportExcel"  ,"Active" };
            return Verbsarr;
        }
        //
		//code for list of groups
        public string[][] getGroupsName()
        {
            string[][] groupsarr = new string[][] { new string[] {"48903","T_JobAssignment48903"},new string[] {"48932","T_JobAssignment48932"},new string[] {"48911","Employee Assigned"},new string[] {"48913","Position Details"},new string[] {"48910","Assignment Details"},new string[] {"48912","Notes"} };
            return groupsarr;
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCalculationValues(T_JobAssignment t_jobassignment)
        {
            t_jobassignment.setCalculation();
            Dictionary<string, string> Calculations = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_jobassignment.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            return Json(Calculations, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		//get Templates 
		// select templates 
        public void GetTemplatesForList(string defaultview)
        {
            string pageNameList = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_JobAssignment"
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
                                       where s.EntityName == "T_JobAssignment"
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
                                       where s.EntityName == "T_JobAssignment"
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
                                       where s.EntityName == "T_JobAssignment"
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
                                       where s.EntityName == "T_JobAssignment"
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
                                       where s.EntityName == "T_JobAssignment"
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
                                       where s.EntityName == "T_JobAssignment"
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
                                       where s.EntityName == "T_JobAssignment"
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
                                       where s.EntityName == "T_JobAssignment"
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
        public ActionResult GetDerivedDetails(T_JobAssignment t_jobassignment, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_jobassignment.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
			if (IgnoreEditable != "T_PositionJobAssignment" )
            {
 
			var T_PositionLevelsourceProp = properties.FirstOrDefault(p => p.Name == "T_PositionJobAssignmentID");
            if (T_PositionLevelsourceProp != null)
            {
                object sourcePropValue = T_PositionLevelsourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_PositionLevel");
                if (Property != null && sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_PositionIdentifierID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_PositionLevelController InnerController = new T_PositionLevelController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_PositionLevel"))
                            derivedlist.Add("T_PositionLevel", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_PositionLevel"))
                   derivedlist.Add("T_PositionLevel", "");
            }
}
			if (IgnoreEditable != "T_PositionJobAssignment" )
            {
 
			var T_RoleCodesourceProp = properties.FirstOrDefault(p => p.Name == "T_PositionJobAssignmentID");
            if (T_RoleCodesourceProp != null)
            {
                object sourcePropValue = T_RoleCodesourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_RoleCode");
                if (Property != null && sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_PositionRoleCodeID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_RoleCodeController InnerController = new T_RoleCodeController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_RoleCode"))
                            derivedlist.Add("T_RoleCode", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_RoleCode"))
                   derivedlist.Add("T_RoleCode", "");
            }
}
			if (IgnoreEditable != "T_PositionJobAssignment" )
            {
 
			var T_ClassCodesourceProp = properties.FirstOrDefault(p => p.Name == "T_PositionJobAssignmentID");
            if (T_ClassCodesourceProp != null)
            {
                object sourcePropValue = T_ClassCodesourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_ClassCode");
                if (Property != null && sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_PositionClassCodeID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_ClassCodeController InnerController = new T_ClassCodeController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_ClassCode"))
                            derivedlist.Add("T_ClassCode", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_ClassCode"))
                   derivedlist.Add("T_ClassCode", "");
            }
}
			if (IgnoreEditable != "T_PositionJobAssignment" )
            {
 
			var T_WorkersCompCodesourceProp = properties.FirstOrDefault(p => p.Name == "T_PositionJobAssignmentID");
            if (T_WorkersCompCodesourceProp != null)
            {
                object sourcePropValue = T_WorkersCompCodesourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_WorkersCompCode");
                if (Property != null && sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_WorkersCompCodePositionID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_WCCodeController InnerController = new T_WCCodeController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_WorkersCompCode"))
                            derivedlist.Add("T_WorkersCompCode", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_WorkersCompCode"))
                   derivedlist.Add("T_WorkersCompCode", "");
            }
}
			if (IgnoreEditable != "T_PositionJobAssignment" )
            {
 
			var T_SOCCodesourceProp = properties.FirstOrDefault(p => p.Name == "T_PositionJobAssignmentID");
            if (T_SOCCodesourceProp != null)
            {
                object sourcePropValue = T_SOCCodesourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_SOCCode");
                if (Property != null && sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_PositionSOCCodeID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_SocCodeController InnerController = new T_SocCodeController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_SOCCode"))
                            derivedlist.Add("T_SOCCode", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_SOCCode"))
                   derivedlist.Add("T_SOCCode", "");
            }
}
 
			var T_OvertimeEligibilitysourceProp = properties.FirstOrDefault(p => p.Name == "T_PositionJobAssignmentID");
            if (T_OvertimeEligibilitysourceProp != null)
            {
                object sourcePropValue = T_OvertimeEligibilitysourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_OvertimeEligibility");
                if (Property != null && sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_PositionOvertimeEligibilityID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_OvertimeEligibilityController InnerController = new T_OvertimeEligibilityController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_OvertimeEligibility"))
                            derivedlist.Add("T_OvertimeEligibility", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_OvertimeEligibility"))
                   derivedlist.Add("T_OvertimeEligibility", "");
            }
 
			var T_CostCentersourceProp = properties.FirstOrDefault(p => p.Name == "T_JobAssignmentUnitXID");
            if (T_CostCentersourceProp != null)
            {
                object sourcePropValue = T_CostCentersourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_CostCenter");
                if (Property != null && sourcePropValue != null)
                {
					T_UnitXController objController = new T_UnitXController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_WardCostCenterID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_CostCenterController InnerController = new T_CostCenterController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_CostCenter"))
                            derivedlist.Add("T_CostCenter", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_CostCenter"))
                   derivedlist.Add("T_CostCenter", "");
            }
 
			var T_ProgramsourceProp = properties.FirstOrDefault(p => p.Name == "T_JobAssignmentUnitXID");
            if (T_ProgramsourceProp != null)
            {
                object sourcePropValue = T_ProgramsourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_Program");
                if (Property != null && sourcePropValue != null)
                {
                   T_UnitXController objController = new T_UnitXController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_Program");
                    if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0" && !derivedlist.ContainsKey("T_Program"))
                        derivedlist.Add("T_Program", Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data));
                }
				if (!derivedlist.ContainsKey("T_Program"))
                   derivedlist.Add("T_Program", "");
            }
 
			var T_DepartmentAreasourceProp = properties.FirstOrDefault(p => p.Name == "T_JobAssignmentUnitXID");
            if (T_DepartmentAreasourceProp != null)
            {
                object sourcePropValue = T_DepartmentAreasourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_DepartmentArea");
                if (Property != null && sourcePropValue != null)
                {
					T_UnitXController objController = new T_UnitXController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_UnitXDepartmentAreaID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_DepartmentAreaController InnerController = new T_DepartmentAreaController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_DepartmentArea"))
                            derivedlist.Add("T_DepartmentArea", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_DepartmentArea"))
                   derivedlist.Add("T_DepartmentArea", "");
            }
			if (IgnoreEditable != "T_JobAssignmentUnitX" )
            {
 
			var T_DepartmentsourceProp = properties.FirstOrDefault(p => p.Name == "T_JobAssignmentUnitXID");
            if (T_DepartmentsourceProp != null)
            {
                object sourcePropValue = T_DepartmentsourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_Department");
                if (Property != null && sourcePropValue != null)
                {
					T_UnitXController objController = new T_UnitXController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_WardDepartmentID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_DepartmentController InnerController = new T_DepartmentController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "T_DepartmentTitle");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_Department"))
                            derivedlist.Add("T_Department", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_Department"))
                   derivedlist.Add("T_Department", "");
            }
}
 
			var T_SupervisorEmailsourceProp = properties.FirstOrDefault(p => p.Name == "T_EmployeeSupervisorID");
            if (T_SupervisorEmailsourceProp != null)
            {
                object sourcePropValue = T_SupervisorEmailsourceProp.GetValue(t_jobassignment, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_SupervisorEmail");
                if (Property != null && sourcePropValue != null)
                {
                   T_EmployeeController objController = new T_EmployeeController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_WorkEmail");
                    if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0" && !derivedlist.ContainsKey("T_SupervisorEmail"))
                        derivedlist.Add("T_SupervisorEmail", Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data));
                }
				if (!derivedlist.ContainsKey("T_SupervisorEmail"))
                   derivedlist.Add("T_SupervisorEmail", "");
            }
            return Json(derivedlist, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDerivedDetailsInline(string host, string value, T_JobAssignment t_jobassignment, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
 
		if (host == "T_PositionJobAssignmentID")
			{
			var T_PositionLevelsourceProp = host;
            if (T_PositionLevelsourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_PositionIdentifierID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_PositionLevelController InnerController = new T_PositionLevelController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_PositionLevel"))
                            derivedlist.Add("T_PositionLevel", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_PositionLevel"))
                   derivedlist.Add("T_PositionLevel", "");
            }
			}
 
		if (host == "T_PositionJobAssignmentID")
			{
			var T_RoleCodesourceProp = host;
            if (T_RoleCodesourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_PositionRoleCodeID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_RoleCodeController InnerController = new T_RoleCodeController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_RoleCode"))
                            derivedlist.Add("T_RoleCode", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_RoleCode"))
                   derivedlist.Add("T_RoleCode", "");
            }
			}
 
		if (host == "T_PositionJobAssignmentID")
			{
			var T_ClassCodesourceProp = host;
            if (T_ClassCodesourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_PositionClassCodeID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_ClassCodeController InnerController = new T_ClassCodeController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_ClassCode"))
                            derivedlist.Add("T_ClassCode", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_ClassCode"))
                   derivedlist.Add("T_ClassCode", "");
            }
			}
 
		if (host == "T_PositionJobAssignmentID")
			{
			var T_WorkersCompCodesourceProp = host;
            if (T_WorkersCompCodesourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_WorkersCompCodePositionID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_WCCodeController InnerController = new T_WCCodeController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_WorkersCompCode"))
                            derivedlist.Add("T_WorkersCompCode", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_WorkersCompCode"))
                   derivedlist.Add("T_WorkersCompCode", "");
            }
			}
 
		if (host == "T_PositionJobAssignmentID")
			{
			var T_SOCCodesourceProp = host;
            if (T_SOCCodesourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_PositionSOCCodeID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_SocCodeController InnerController = new T_SocCodeController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_SOCCode"))
                            derivedlist.Add("T_SOCCode", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_SOCCode"))
                   derivedlist.Add("T_SOCCode", "");
            }
			}
 
		if (host == "T_PositionJobAssignmentID")
			{
			var T_OvertimeEligibilitysourceProp = host;
            if (T_OvertimeEligibilitysourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_PositionController objController = new T_PositionController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_PositionOvertimeEligibilityID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_OvertimeEligibilityController InnerController = new T_OvertimeEligibilityController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_OvertimeEligibility"))
                            derivedlist.Add("T_OvertimeEligibility", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_OvertimeEligibility"))
                   derivedlist.Add("T_OvertimeEligibility", "");
            }
			}
 
		if (host == "T_JobAssignmentUnitXID")
			{
			var T_CostCentersourceProp = host;
            if (T_CostCentersourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_UnitXController objController = new T_UnitXController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_WardCostCenterID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_CostCenterController InnerController = new T_CostCenterController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_CostCenter"))
                            derivedlist.Add("T_CostCenter", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_CostCenter"))
                   derivedlist.Add("T_CostCenter", "");
            }
			}
		if (host == "T_JobAssignmentUnitXID")
			{
			var T_ProgramsourceProp = host;
            if (T_ProgramsourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
                   T_UnitXController objController = new T_UnitXController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_Program");
                    if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0" && !derivedlist.ContainsKey("T_Program"))
                        derivedlist.Add("T_Program", Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data));
                }
				if (!derivedlist.ContainsKey("T_Program"))
                   derivedlist.Add("T_Program", "");
            }
		}
 
		if (host == "T_JobAssignmentUnitXID")
			{
			var T_DepartmentAreasourceProp = host;
            if (T_DepartmentAreasourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_UnitXController objController = new T_UnitXController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_UnitXDepartmentAreaID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_DepartmentAreaController InnerController = new T_DepartmentAreaController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "DisplayValue");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_DepartmentArea"))
                            derivedlist.Add("T_DepartmentArea", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_DepartmentArea"))
                   derivedlist.Add("T_DepartmentArea", "");
            }
			}
 
		if (host == "T_JobAssignmentUnitXID")
			{
			var T_DepartmentsourceProp = host;
            if (T_DepartmentsourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_UnitXController objController = new T_UnitXController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_WardDepartmentID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_DepartmentController InnerController = new T_DepartmentController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "T_DepartmentTitle");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_Department"))
                            derivedlist.Add("T_Department", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_Department"))
                   derivedlist.Add("T_Department", "");
            }
			}
		if (host == "T_EmployeeSupervisorID")
			{
			var T_SupervisorEmailsourceProp = host;
            if (T_SupervisorEmailsourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
                   T_EmployeeController objController = new T_EmployeeController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_WorkEmail");
                    if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0" && !derivedlist.ContainsKey("T_SupervisorEmail"))
                        derivedlist.Add("T_SupervisorEmail", Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data));
                }
				if (!derivedlist.ContainsKey("T_SupervisorEmail"))
                   derivedlist.Add("T_SupervisorEmail", "");
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
			public void CopyToT_JobAssignment(string T_JobAssignmentID, string UrlReferrer, bool? IsDDAdd, string HostingEntityName, string HostingEntityID, string AssociatedType, ApplicationContext db)
			{
				T_JobAssignmentController t_jobassignmentcontroller = new T_JobAssignmentController();
				t_jobassignmentcontroller.CopyFromT_JobAssignmentAsAction(T_JobAssignmentID, UrlReferrer, IsDDAdd, HostingEntityName, HostingEntityID, AssociatedType, db);
			}
    }
}
