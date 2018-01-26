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
    public partial class T_EmployeeInjuryController : BaseController
    {
		private void LoadViewDataForCount(T_EmployeeInjury t_employeeinjury, string AssocType)
        {
        }
		private void LoadViewDataAfterOnEdit(T_EmployeeInjury t_employeeinjury)
        {		
			var T_ClaimType_T_TypeofClaimlist = db.T_ClaimTypes.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim != null)
            {
                var list = T_ClaimType_T_TypeofClaimlist.Union(db.T_ClaimTypes.Where(p => t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim.ToList().Contains(p.Id))).Distinct();
                ViewBag.SelectedT_ClaimType_T_TypeofClaim = new MultiSelectList(list, "ID", "DisplayValue",t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim);
            }
            else
            {
                ViewBag.SelectedT_ClaimType_T_TypeofClaim = new MultiSelectList(T_ClaimType_T_TypeofClaimlist, "ID", "DisplayValue");
            }
			var T_Restrictions_T_TypeOfRestrictionslist = db.T_Restrictionss.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions != null)
            {
                var list = T_Restrictions_T_TypeOfRestrictionslist.Union(db.T_Restrictionss.Where(p => t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions.ToList().Contains(p.Id))).Distinct();
                ViewBag.SelectedT_Restrictions_T_TypeOfRestrictions = new MultiSelectList(list, "ID", "DisplayValue",t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions);
            }
            else
            {
                ViewBag.SelectedT_Restrictions_T_TypeOfRestrictions = new MultiSelectList(T_Restrictions_T_TypeOfRestrictionslist, "ID", "DisplayValue");
            }
			 ViewBag.T_EmployeeEmployeeInjuryID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_employeeinjury.T_EmployeeEmployeeInjuryID);
			 ViewBag.T_TypeofClaimMCIID = new SelectList(db.T_ClaimTypeMCIs, "ID", "DisplayValue", t_employeeinjury.T_TypeofClaimMCIID);
			 ViewBag.T_AccidentShiftID = new SelectList(db.T_ShiftTimes, "ID", "DisplayValue", t_employeeinjury.T_AccidentShiftID);
			 ViewBag.T_FacilityAccidentOccuredID = new SelectList(db.T_AllFacilitiess, "ID", "DisplayValue", t_employeeinjury.T_FacilityAccidentOccuredID);
			 ViewBag.T_UnitWhereAccidentOccuredID = new SelectList(db.T_AllFacilitiesUnits, "ID", "DisplayValue", t_employeeinjury.T_UnitWhereAccidentOccuredID);
			 ViewBag.T_EmployeInjuryFloorID = new SelectList(db.T_AllFacilitiesFloors, "ID", "DisplayValue", t_employeeinjury.T_EmployeInjuryFloorID);
			 ViewBag.T_LocationOfAccidentID = new SelectList(db.T_WCAccidents, "ID", "DisplayValue", t_employeeinjury.T_LocationOfAccidentID);
			 ViewBag.T_EmployeeInjuryCauseID = new SelectList(db.T_InjuryCauses, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryCauseID);
			 ViewBag.T_EmployeeInjuryNatureID = new SelectList(db.T_InjuryNatures, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryNatureID);
			 ViewBag.T_EmployeeInjuryBodyPartsAffectedID = new SelectList(db.T_BodyPartsAffecteds, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryBodyPartsAffectedID);
			 ViewBag.T_EMployeeInjuryMachineToolID = new SelectList(db.T_MachineTools, "ID", "DisplayValue", t_employeeinjury.T_EMployeeInjuryMachineToolID);
			 ViewBag.T_InitialTreatmentListID = new SelectList(db.T_InitialTreatments, "ID", "DisplayValue", t_employeeinjury.T_InitialTreatmentListID);
			 ViewBag.T_EmployeeInjuryMedicalFacilityForTreatmentID = new SelectList(db.T_MedicalFacilityForTreatments, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryMedicalFacilityForTreatmentID);
			 ViewBag.T_EmployeeInjuryRefusalID = new SelectList(db.T_Refusals, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryRefusalID);
			CustomLoadViewDataListAfterEdit(t_employeeinjury);
        }
        private void LoadViewDataBeforeOnEdit(T_EmployeeInjury t_employeeinjury)
        {		
			var T_ClaimType_T_TypeofClaimlist = db.T_ClaimTypes.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            if (t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim != null)
            {
                var list = T_ClaimType_T_TypeofClaimlist.Union(db.T_ClaimTypes.Where(p => t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim.ToList().Contains(p.Id))).Distinct();
                ViewBag.SelectedT_ClaimType_T_TypeofClaim = new MultiSelectList(list, "ID", "DisplayValue",t_employeeinjury.SelectedT_ClaimType_T_TypeofClaim);
            }
            else
            {
                ViewBag.SelectedT_ClaimType_T_TypeofClaim = new MultiSelectList(T_ClaimType_T_TypeofClaimlist, "ID", "DisplayValue");
            }
			var T_Restrictions_T_TypeOfRestrictionslist = db.T_Restrictionss.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            if (t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions != null)
            {
                var list = T_Restrictions_T_TypeOfRestrictionslist.Union(db.T_Restrictionss.Where(p => t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions.ToList().Contains(p.Id))).Distinct();
                ViewBag.SelectedT_Restrictions_T_TypeOfRestrictions = new MultiSelectList(list, "ID", "DisplayValue",t_employeeinjury.SelectedT_Restrictions_T_TypeOfRestrictions);
            }
            else
            {
                ViewBag.SelectedT_Restrictions_T_TypeOfRestrictions = new MultiSelectList(T_Restrictions_T_TypeOfRestrictionslist, "ID", "DisplayValue");
            }
               var _objT_EmployeeEmployeeInjury = new List<T_Employee>();
               _objT_EmployeeEmployeeInjury.Add(t_employeeinjury.t_employeeemployeeinjury);
			   			   ViewBag.T_EmployeeEmployeeInjuryID = new SelectList(_objT_EmployeeEmployeeInjury, "ID", "DisplayValue", t_employeeinjury.T_EmployeeEmployeeInjuryID);
			               var _objT_TypeofClaimMCI = new List<T_ClaimTypeMCI>();
               _objT_TypeofClaimMCI.Add(t_employeeinjury.t_typeofclaimmci);
			   			   ViewBag.T_TypeofClaimMCIID = new SelectList(_objT_TypeofClaimMCI, "ID", "DisplayValue", t_employeeinjury.T_TypeofClaimMCIID);
			               var _objT_AccidentShift = new List<T_ShiftTime>();
               _objT_AccidentShift.Add(t_employeeinjury.t_accidentshift);
			   			   ViewBag.T_AccidentShiftID = new SelectList(_objT_AccidentShift, "ID", "DisplayValue", t_employeeinjury.T_AccidentShiftID);
			               var _objT_FacilityAccidentOccured = new List<T_AllFacilities>();
               _objT_FacilityAccidentOccured.Add(t_employeeinjury.t_facilityaccidentoccured);
			   			   ViewBag.T_FacilityAccidentOccuredID = new SelectList(_objT_FacilityAccidentOccured, "ID", "DisplayValue", t_employeeinjury.T_FacilityAccidentOccuredID);
			               var _objT_UnitWhereAccidentOccured = new List<T_AllFacilitiesUnit>();
               _objT_UnitWhereAccidentOccured.Add(t_employeeinjury.t_unitwhereaccidentoccured);
			   			   ViewBag.T_UnitWhereAccidentOccuredID = new SelectList(_objT_UnitWhereAccidentOccured, "ID", "DisplayValue", t_employeeinjury.T_UnitWhereAccidentOccuredID);
			               var _objT_EmployeInjuryFloor = new List<T_AllFacilitiesFloor>();
               _objT_EmployeInjuryFloor.Add(t_employeeinjury.t_employeinjuryfloor);
			   			   ViewBag.T_EmployeInjuryFloorID = new SelectList(_objT_EmployeInjuryFloor, "ID", "DisplayValue", t_employeeinjury.T_EmployeInjuryFloorID);
			               var _objT_LocationOfAccident = new List<T_WCAccident>();
               _objT_LocationOfAccident.Add(t_employeeinjury.t_locationofaccident);
			   			   ViewBag.T_LocationOfAccidentID = new SelectList(_objT_LocationOfAccident, "ID", "DisplayValue", t_employeeinjury.T_LocationOfAccidentID);
			               var _objT_EmployeeInjuryCause = new List<T_InjuryCause>();
               _objT_EmployeeInjuryCause.Add(t_employeeinjury.t_employeeinjurycause);
			   			   ViewBag.T_EmployeeInjuryCauseID = new SelectList(_objT_EmployeeInjuryCause, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryCauseID);
			               var _objT_EmployeeInjuryNature = new List<T_InjuryNature>();
               _objT_EmployeeInjuryNature.Add(t_employeeinjury.t_employeeinjurynature);
			   			   ViewBag.T_EmployeeInjuryNatureID = new SelectList(_objT_EmployeeInjuryNature, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryNatureID);
			               var _objT_EmployeeInjuryBodyPartsAffected = new List<T_BodyPartsAffected>();
               _objT_EmployeeInjuryBodyPartsAffected.Add(t_employeeinjury.t_employeeinjurybodypartsaffected);
			   			   ViewBag.T_EmployeeInjuryBodyPartsAffectedID = new SelectList(_objT_EmployeeInjuryBodyPartsAffected, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryBodyPartsAffectedID);
			               var _objT_EMployeeInjuryMachineTool = new List<T_MachineTool>();
               _objT_EMployeeInjuryMachineTool.Add(t_employeeinjury.t_employeeinjurymachinetool);
			   			   ViewBag.T_EMployeeInjuryMachineToolID = new SelectList(_objT_EMployeeInjuryMachineTool, "ID", "DisplayValue", t_employeeinjury.T_EMployeeInjuryMachineToolID);
			               var _objT_InitialTreatmentList = new List<T_InitialTreatment>();
               _objT_InitialTreatmentList.Add(t_employeeinjury.t_initialtreatmentlist);
			   			   ViewBag.T_InitialTreatmentListID = new SelectList(_objT_InitialTreatmentList, "ID", "DisplayValue", t_employeeinjury.T_InitialTreatmentListID);
			               var _objT_EmployeeInjuryMedicalFacilityForTreatment = new List<T_MedicalFacilityForTreatment>();
               _objT_EmployeeInjuryMedicalFacilityForTreatment.Add(t_employeeinjury.t_employeeinjurymedicalfacilityfortreatment);
			   			   ViewBag.T_EmployeeInjuryMedicalFacilityForTreatmentID = new SelectList(_objT_EmployeeInjuryMedicalFacilityForTreatment, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryMedicalFacilityForTreatmentID);
			               var _objT_EmployeeInjuryRefusal = new List<T_Refusal>();
               _objT_EmployeeInjuryRefusal.Add(t_employeeinjury.t_employeeinjuryrefusal);
			   			   ViewBag.T_EmployeeInjuryRefusalID = new SelectList(_objT_EmployeeInjuryRefusal, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryRefusalID);
				 ViewBag.T_InjuryRelatedLeaveCount = t_employeeinjury.t_injuryrelatedleave.Count();
	 ViewBag.T_InjuryCommentsCount = t_employeeinjury.t_injurycomments.Count();
	 ViewBag.T_AccommodationInjuryCount = t_employeeinjury.t_accommodationinjury.Count();
		CustomLoadViewDataListBeforeEdit(t_employeeinjury);
        }
        private void LoadViewDataAfterOnCreate(T_EmployeeInjury t_employeeinjury)
        {			
			var T_ClaimType_T_TypeofClaimlist = db.T_ClaimTypes.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            ViewBag.SelectedT_ClaimType_T_TypeofClaim = new MultiSelectList(T_ClaimType_T_TypeofClaimlist, "ID", "DisplayValue");
			var T_Restrictions_T_TypeOfRestrictionslist = db.T_Restrictionss.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            ViewBag.SelectedT_Restrictions_T_TypeOfRestrictions = new MultiSelectList(T_Restrictions_T_TypeOfRestrictionslist, "ID", "DisplayValue");
			 ViewBag.T_EmployeeEmployeeInjuryID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_employeeinjury.T_EmployeeEmployeeInjuryID);
			 ViewBag.T_TypeofClaimMCIID = new SelectList(db.T_ClaimTypeMCIs, "ID", "DisplayValue", t_employeeinjury.T_TypeofClaimMCIID);
			 ViewBag.T_AccidentShiftID = new SelectList(db.T_ShiftTimes, "ID", "DisplayValue", t_employeeinjury.T_AccidentShiftID);
			 ViewBag.T_FacilityAccidentOccuredID = new SelectList(db.T_AllFacilitiess, "ID", "DisplayValue", t_employeeinjury.T_FacilityAccidentOccuredID);
			 ViewBag.T_UnitWhereAccidentOccuredID = new SelectList(db.T_AllFacilitiesUnits, "ID", "DisplayValue", t_employeeinjury.T_UnitWhereAccidentOccuredID);
			 ViewBag.T_EmployeInjuryFloorID = new SelectList(db.T_AllFacilitiesFloors, "ID", "DisplayValue", t_employeeinjury.T_EmployeInjuryFloorID);
			 ViewBag.T_LocationOfAccidentID = new SelectList(db.T_WCAccidents, "ID", "DisplayValue", t_employeeinjury.T_LocationOfAccidentID);
			 ViewBag.T_EmployeeInjuryCauseID = new SelectList(db.T_InjuryCauses, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryCauseID);
			 ViewBag.T_EmployeeInjuryNatureID = new SelectList(db.T_InjuryNatures, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryNatureID);
			 ViewBag.T_EmployeeInjuryBodyPartsAffectedID = new SelectList(db.T_BodyPartsAffecteds, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryBodyPartsAffectedID);
			 ViewBag.T_EMployeeInjuryMachineToolID = new SelectList(db.T_MachineTools, "ID", "DisplayValue", t_employeeinjury.T_EMployeeInjuryMachineToolID);
			 ViewBag.T_InitialTreatmentListID = new SelectList(db.T_InitialTreatments, "ID", "DisplayValue", t_employeeinjury.T_InitialTreatmentListID);
			 ViewBag.T_EmployeeInjuryMedicalFacilityForTreatmentID = new SelectList(db.T_MedicalFacilityForTreatments, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryMedicalFacilityForTreatmentID);
			 ViewBag.T_EmployeeInjuryRefusalID = new SelectList(db.T_Refusals, "ID", "DisplayValue", t_employeeinjury.T_EmployeeInjuryRefusalID);
		CustomLoadViewDataListAfterOnCreate(t_employeeinjury);
        }
        private void LoadViewDataBeforeOnCreate(string HostingEntityName, string HostingEntityID, string AssociatedType)
        {			
			var T_ClaimType_T_TypeofClaimlist = db.T_ClaimTypes.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            ViewBag.SelectedT_ClaimType_T_TypeofClaim = new MultiSelectList(T_ClaimType_T_TypeofClaimlist, "ID", "DisplayValue");
			var T_Restrictions_T_TypeOfRestrictionslist = db.T_Restrictionss.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            ViewBag.SelectedT_Restrictions_T_TypeOfRestrictions = new MultiSelectList(T_Restrictions_T_TypeOfRestrictionslist, "ID", "DisplayValue");
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeEmployeeInjury")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeEmployeeInjuryID = new SelectList(db.T_Employees.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Employees.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeEmployeeInjury = new List<T_Employee>();
			 ViewBag.T_EmployeeEmployeeInjuryID = new SelectList(objT_EmployeeEmployeeInjury , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_ClaimTypeMCI" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_TypeofClaimMCI")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_TypeofClaimMCIID = new SelectList(db.T_ClaimTypeMCIs.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_ClaimTypeMCIs.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_TypeofClaimMCI = new List<T_ClaimTypeMCI>();
			 ViewBag.T_TypeofClaimMCIID = new SelectList(objT_TypeofClaimMCI , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_ShiftTime" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_AccidentShift")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_AccidentShiftID = new SelectList(db.T_ShiftTimes.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_ShiftTimes.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_AccidentShift = new List<T_ShiftTime>();
			 ViewBag.T_AccidentShiftID = new SelectList(objT_AccidentShift , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_AllFacilities" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_FacilityAccidentOccured")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_FacilityAccidentOccuredID = new SelectList(db.T_AllFacilitiess.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_AllFacilitiess.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_FacilityAccidentOccured = new List<T_AllFacilities>();
			 ViewBag.T_FacilityAccidentOccuredID = new SelectList(objT_FacilityAccidentOccured , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_AllFacilitiesUnit" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_UnitWhereAccidentOccured")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_UnitWhereAccidentOccuredID = new SelectList(db.T_AllFacilitiesUnits.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_AllFacilitiesUnits.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_UnitWhereAccidentOccured = new List<T_AllFacilitiesUnit>();
			 ViewBag.T_UnitWhereAccidentOccuredID = new SelectList(objT_UnitWhereAccidentOccured , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_AllFacilitiesFloor" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeInjuryFloor")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeInjuryFloorID = new SelectList(db.T_AllFacilitiesFloors.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_AllFacilitiesFloors.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeInjuryFloor = new List<T_AllFacilitiesFloor>();
			 ViewBag.T_EmployeInjuryFloorID = new SelectList(objT_EmployeInjuryFloor , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_WCAccident" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_LocationOfAccident")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_LocationOfAccidentID = new SelectList(db.T_WCAccidents.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_WCAccidents.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_LocationOfAccident = new List<T_WCAccident>();
			 ViewBag.T_LocationOfAccidentID = new SelectList(objT_LocationOfAccident , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_InjuryCause" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeInjuryCause")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeInjuryCauseID = new SelectList(db.T_InjuryCauses.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_InjuryCauses.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeInjuryCause = new List<T_InjuryCause>();
			 ViewBag.T_EmployeeInjuryCauseID = new SelectList(objT_EmployeeInjuryCause , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_InjuryNature" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeInjuryNature")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeInjuryNatureID = new SelectList(db.T_InjuryNatures.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_InjuryNatures.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeInjuryNature = new List<T_InjuryNature>();
			 ViewBag.T_EmployeeInjuryNatureID = new SelectList(objT_EmployeeInjuryNature , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_BodyPartsAffected" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeInjuryBodyPartsAffected")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeInjuryBodyPartsAffectedID = new SelectList(db.T_BodyPartsAffecteds.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_BodyPartsAffecteds.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeInjuryBodyPartsAffected = new List<T_BodyPartsAffected>();
			 ViewBag.T_EmployeeInjuryBodyPartsAffectedID = new SelectList(objT_EmployeeInjuryBodyPartsAffected , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_MachineTool" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EMployeeInjuryMachineTool")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EMployeeInjuryMachineToolID = new SelectList(db.T_MachineTools.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_MachineTools.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EMployeeInjuryMachineTool = new List<T_MachineTool>();
			 ViewBag.T_EMployeeInjuryMachineToolID = new SelectList(objT_EMployeeInjuryMachineTool , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_InitialTreatment" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_InitialTreatmentList")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_InitialTreatmentListID = new SelectList(db.T_InitialTreatments.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_InitialTreatments.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_InitialTreatmentList = new List<T_InitialTreatment>();
			 ViewBag.T_InitialTreatmentListID = new SelectList(objT_InitialTreatmentList , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_MedicalFacilityForTreatment" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeInjuryMedicalFacilityForTreatment")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeInjuryMedicalFacilityForTreatmentID = new SelectList(db.T_MedicalFacilityForTreatments.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_MedicalFacilityForTreatments.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeInjuryMedicalFacilityForTreatment = new List<T_MedicalFacilityForTreatment>();
			 ViewBag.T_EmployeeInjuryMedicalFacilityForTreatmentID = new SelectList(objT_EmployeeInjuryMedicalFacilityForTreatment , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Refusal" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeInjuryRefusal")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeInjuryRefusalID = new SelectList(db.T_Refusals.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Refusals.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeInjuryRefusal = new List<T_Refusal>();
			 ViewBag.T_EmployeeInjuryRefusalID = new SelectList(objT_EmployeeInjuryRefusal , "ID", "DisplayValue");
		    }
			CustomLoadViewDataListBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
        }
		private IQueryable<T_EmployeeInjury> searchRecords(IQueryable<T_EmployeeInjury> lstT_EmployeeInjury, string searchString, bool? IsDeepSearch)
        {
		   searchString = searchString.Trim();
		if(Convert.ToBoolean(IsDeepSearch))
            lstT_EmployeeInjury = lstT_EmployeeInjury.Where(s => (s.t_employeeemployeeinjury!= null && (s.t_employeeemployeeinjury.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_typeofclaimmci!= null && (s.t_typeofclaimmci.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_ClaimNo) && s.T_ClaimNo.ToUpper().Contains(searchString)) ||(s.t_accidentshift!= null && (s.t_accidentshift.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_Location) && s.T_Location.ToUpper().Contains(searchString)) ||(s.t_facilityaccidentoccured!= null && (s.t_facilityaccidentoccured.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_unitwhereaccidentoccured!= null && (s.t_unitwhereaccidentoccured.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeinjuryfloor!= null && (s.t_employeinjuryfloor.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_locationofaccident!= null && (s.t_locationofaccident.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_DescribeHowInjuryOrIllnessOccurred) && s.T_DescribeHowInjuryOrIllnessOccurred.ToUpper().Contains(searchString)) ||(s.t_employeeinjurycause!= null && (s.t_employeeinjurycause.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeinjurynature!= null && (s.t_employeeinjurynature.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeinjurybodypartsaffected!= null && (s.t_employeeinjurybodypartsaffected.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeinjurymachinetool!= null && (s.t_employeeinjurymachinetool.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_initialtreatmentlist!= null && (s.t_initialtreatmentlist.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_PatientInvolvedRegnoepi) && s.T_PatientInvolvedRegnoepi.ToUpper().Contains(searchString)) ||(s.t_employeeinjurymedicalfacilityfortreatment!= null && (s.t_employeeinjurymedicalfacilityfortreatment.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_ExaminingPhysician) && s.T_ExaminingPhysician.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_ReferringPhysician) && s.T_ReferringPhysician.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_Diagnosis) && s.T_Diagnosis.ToUpper().Contains(searchString)) ||(s.T_DaysOff != null && SqlFunctions.StringConvert((double)s.T_DaysOff).Contains(searchString)) ||(s.T_DaysRestricted != null && SqlFunctions.StringConvert((double)s.T_DaysRestricted).Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_DetailsOfRestriction) && s.T_DetailsOfRestriction.ToUpper().Contains(searchString)) ||(s.t_employeeinjuryrefusal!= null && (s.t_employeeinjuryrefusal.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_AccidentNotes) && s.T_AccidentNotes.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_RestrictionNotes) && s.T_RestrictionNotes.ToUpper().Contains(searchString)) ||s.T_TypeofClaim_t_employeeinjury.Any(c => c.t_claimtype.DisplayValue.ToUpper().Contains(searchString)) ||s.T_TypeOfRestrictions_t_employeeinjury.Any(c => c.t_restrictions.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
		else
			 lstT_EmployeeInjury = lstT_EmployeeInjury.Where(s => (s.t_employeeemployeeinjury!= null && (s.t_employeeemployeeinjury.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_typeofclaimmci!= null && (s.t_typeofclaimmci.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_ClaimNo) && s.T_ClaimNo.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_Location) && s.T_Location.ToUpper().Contains(searchString)) ||(s.t_initialtreatmentlist!= null && (s.t_initialtreatmentlist.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_Diagnosis) && s.T_Diagnosis.ToUpper().Contains(searchString)) ||(s.T_DaysOff != null && SqlFunctions.StringConvert((double)s.T_DaysOff).Contains(searchString)) ||(s.T_DaysRestricted != null && SqlFunctions.StringConvert((double)s.T_DaysRestricted).Contains(searchString)) ||s.T_TypeofClaim_t_employeeinjury.Any(c => c.t_claimtype.DisplayValue.ToUpper().Contains(searchString)) ||s.T_TypeOfRestrictions_t_employeeinjury.Any(c => c.t_restrictions.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
			try
            {
                var boolvalue = Convert.ToBoolean(searchString);
                lstT_EmployeeInjury = lstT_EmployeeInjury.Union(db.T_EmployeeInjurys.Where(s => (s.T_OSHA == boolvalue) ));
            }
            catch { }
			try
            {
                var datevalue = Convert.ToDateTime(searchString);
                lstT_EmployeeInjury = lstT_EmployeeInjury.Union(db.T_EmployeeInjurys.Where(s => (s.T_AccidentDate == datevalue) ||(s.T_RestrictionStartDate == datevalue) ||(s.T_RestrictionEndDate == datevalue) ));
            }
            catch { }
            return lstT_EmployeeInjury;
        }
		private IQueryable<T_EmployeeInjury> sortRecords(IQueryable<T_EmployeeInjury> lstT_EmployeeInjury, string sortBy, string isAsc)
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
	 if(sortBy == "T_EmployeeEmployeeInjuryID")
                return isAsc.ToLower() == "asc" ? lstT_EmployeeInjury.OrderBy(p => p.t_employeeemployeeinjury.DisplayValue) : lstT_EmployeeInjury.OrderByDescending(p => p.t_employeeemployeeinjury.DisplayValue);
	 if(sortBy == "T_TypeofClaimMCIID")
                return isAsc.ToLower() == "asc" ? lstT_EmployeeInjury.OrderBy(p => p.t_typeofclaimmci.DisplayValue) : lstT_EmployeeInjury.OrderByDescending(p => p.t_typeofclaimmci.DisplayValue);
	 if(sortBy == "T_InitialTreatmentListID")
                return isAsc.ToLower() == "asc" ? lstT_EmployeeInjury.OrderBy(p => p.t_initialtreatmentlist.DisplayValue) : lstT_EmployeeInjury.OrderByDescending(p => p.t_initialtreatmentlist.DisplayValue);
		    if (sortBy.Contains("."))
                return isAsc.ToLower() == "asc" ? lstT_EmployeeInjury.Sort(sortBy,true) : lstT_EmployeeInjury.Sort(sortBy,false);
            ParameterExpression paramExpression = Expression.Parameter(typeof(T_EmployeeInjury), "t_employeeinjury");
            MemberExpression memExp = Expression.PropertyOrField(paramExpression, sortBy);
            LambdaExpression lambda = Expression.Lambda(memExp, paramExpression);
            return (IQueryable<T_EmployeeInjury>)lstT_EmployeeInjury.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { lstT_EmployeeInjury.ElementType, lambda.Body.Type },
                    lstT_EmployeeInjury.Expression,
                    lambda));
        }
		public ActionResult FindFSearch(string id, string sourceEntity)
        {
            if (sourceEntity == "FileDocument")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.FileDocuments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeeDocumentsID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Licenses")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Licensess.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_LicenseRecordsID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Position")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Positions.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_AccidentShift  = _Object.T_PositionShiftTimeID;
						url += "&t_accidentshift=" + T_AccidentShift;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_ServiceRecord")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_ServiceRecords.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeeEmploymentProfileID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
						var T_FacilityAccidentOccured  = _Object.T_EmploymentRecordHiredAtFacilityID;
						url += "&t_facilityaccidentoccured=" + T_FacilityAccidentOccured;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Comment")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Comments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeeCommentsID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_DrugAlcoholTest")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_DrugAlcoholTests.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeeDrugAlcoholTestID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_UnitX")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_UnitXs.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeeAdministratorID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_JobAssignment")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_JobAssignments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeeJobAssignmentID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_LeaveProfile")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_LeaveProfiles.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeeLeaveProfileID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_BackgroundCheck")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_BackgroundChecks.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeeCriminalBackgroundCheckID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Education")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Educations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeeEducationID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Accommodation")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Accommodations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeeAccomodationID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_PayDetails")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_PayDetailss.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmployeeInjury  = _Object.T_EmployeePayDetailsID;
						url += "&t_employeeemployeeinjury=" + T_EmployeeEmployeeInjury;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_AllFacilitiesUnit")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_AllFacilitiesUnits.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityAccidentOccured  = _Object.T_UnitsforAllFaciltiesID;
						url += "&t_facilityaccidentoccured=" + T_FacilityAccidentOccured;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_AllFacilitiesFloor")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_AllFacilitiesFloors.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_UnitWhereAccidentOccured  = _Object.T_AllUnitsFloorID;
						url += "&t_unitwhereaccidentoccured=" + T_UnitWhereAccidentOccured;									
                Response.Redirect(url.ToString());
            }
            return null;
        }
        public ActionResult SetFSearch(string searchString, string HostingEntity ,string t_employeeemployeeinjury,string t_typeofclaimmci,string t_accidentshift,string t_facilityaccidentoccured,string t_unitwhereaccidentoccured,string t_employeinjuryfloor,string t_locationofaccident,string t_employeeinjurycause,string t_employeeinjurynature,string t_employeeinjurybodypartsaffected,string t_employeeinjurymachinetool,string t_initialtreatmentlist,string t_employeeinjurymedicalfacilityfortreatment,string t_employeeinjuryrefusal,string t_typeofclaim,string t_typeofrestrictions, bool? RenderPartial)
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
			var T_EmployeeEmployeeInjurylist = db.T_Employees.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeemployeeinjury != null)
            {
                var ids = t_employeeemployeeinjury.Split(",".ToCharArray());
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
					var list = T_EmployeeEmployeeInjurylist.Union(db.T_Employees.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
					ViewBag.t_employeeemployeeinjury = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeEmployeeInjurylist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
				ViewBag.t_employeeemployeeinjury = new SelectList(list, "ID", "DisplayValue");
			}
			var T_TypeofClaimMCIlist = db.T_ClaimTypeMCIs.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_typeofclaimmci != null)
            {
                var ids = t_typeofclaimmci.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Type of Claim MCI= ";
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
							   ViewBag.SearchResult += db.T_ClaimTypeMCIs.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_TypeofClaimMCIlist.Union(db.T_ClaimTypeMCIs.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_ClaimTypeMCI>(User, list, "T_ClaimTypeMCI", null);
					ViewBag.t_typeofclaimmci = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_TypeofClaimMCIlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_ClaimTypeMCI>(User, list, "T_ClaimTypeMCI", null);
				ViewBag.t_typeofclaimmci = new SelectList(list, "ID", "DisplayValue");
			}
			var T_AccidentShiftlist = db.T_ShiftTimes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_accidentshift != null)
            {
                var ids = t_accidentshift.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Shift Working When Accident Occurred= ";
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
							   ViewBag.SearchResult += db.T_ShiftTimes.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_AccidentShiftlist.Union(db.T_ShiftTimes.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_ShiftTime>(User, list, "T_ShiftTime", null);
					ViewBag.t_accidentshift = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_AccidentShiftlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_ShiftTime>(User, list, "T_ShiftTime", null);
				ViewBag.t_accidentshift = new SelectList(list, "ID", "DisplayValue");
			}
			var T_FacilityAccidentOccuredlist = db.T_AllFacilitiess.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_facilityaccidentoccured != null)
            {
                var ids = t_facilityaccidentoccured.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Facility Accident Occurred At= ";
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
							   ViewBag.SearchResult += db.T_AllFacilitiess.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_FacilityAccidentOccuredlist.Union(db.T_AllFacilitiess.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_AllFacilities>(User, list, "T_AllFacilities", null);
					ViewBag.t_facilityaccidentoccured = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_FacilityAccidentOccuredlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_AllFacilities>(User, list, "T_AllFacilities", null);
				ViewBag.t_facilityaccidentoccured = new SelectList(list, "ID", "DisplayValue");
			}
			var T_UnitWhereAccidentOccuredlist = db.T_AllFacilitiesUnits.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_unitwhereaccidentoccured != null)
            {
                var ids = t_unitwhereaccidentoccured.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Unit Where Accident Occured= ";
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
							   ViewBag.SearchResult += db.T_AllFacilitiesUnits.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_UnitWhereAccidentOccuredlist.Union(db.T_AllFacilitiesUnits.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_AllFacilitiesUnit>(User, list, "T_AllFacilitiesUnit", null);
					ViewBag.t_unitwhereaccidentoccured = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_UnitWhereAccidentOccuredlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_AllFacilitiesUnit>(User, list, "T_AllFacilitiesUnit", null);
				ViewBag.t_unitwhereaccidentoccured = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeInjuryFloorlist = db.T_AllFacilitiesFloors.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeinjuryfloor != null)
            {
                var ids = t_employeinjuryfloor.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Floor Accident Occurred on= ";
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
							   ViewBag.SearchResult += db.T_AllFacilitiesFloors.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeInjuryFloorlist.Union(db.T_AllFacilitiesFloors.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_AllFacilitiesFloor>(User, list, "T_AllFacilitiesFloor", null);
					ViewBag.t_employeinjuryfloor = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeInjuryFloorlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_AllFacilitiesFloor>(User, list, "T_AllFacilitiesFloor", null);
				ViewBag.t_employeinjuryfloor = new SelectList(list, "ID", "DisplayValue");
			}
			var T_LocationOfAccidentlist = db.T_WCAccidents.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_locationofaccident != null)
            {
                var ids = t_locationofaccident.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Location Of Accident= ";
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
							   ViewBag.SearchResult += db.T_WCAccidents.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_LocationOfAccidentlist.Union(db.T_WCAccidents.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_WCAccident>(User, list, "T_WCAccident", null);
					ViewBag.t_locationofaccident = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_LocationOfAccidentlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_WCAccident>(User, list, "T_WCAccident", null);
				ViewBag.t_locationofaccident = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeInjuryCauselist = db.T_InjuryCauses.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeinjurycause != null)
            {
                var ids = t_employeeinjurycause.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Cause Of Injury = ";
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
							   ViewBag.SearchResult += db.T_InjuryCauses.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeInjuryCauselist.Union(db.T_InjuryCauses.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_InjuryCause>(User, list, "T_InjuryCause", null);
					ViewBag.t_employeeinjurycause = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeInjuryCauselist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_InjuryCause>(User, list, "T_InjuryCause", null);
				ViewBag.t_employeeinjurycause = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeInjuryNaturelist = db.T_InjuryNatures.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeinjurynature != null)
            {
                var ids = t_employeeinjurynature.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Nature Of Injury Or Illness= ";
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
							   ViewBag.SearchResult += db.T_InjuryNatures.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeInjuryNaturelist.Union(db.T_InjuryNatures.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_InjuryNature>(User, list, "T_InjuryNature", null);
					ViewBag.t_employeeinjurynature = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeInjuryNaturelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_InjuryNature>(User, list, "T_InjuryNature", null);
				ViewBag.t_employeeinjurynature = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeInjuryBodyPartsAffectedlist = db.T_BodyPartsAffecteds.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeinjurybodypartsaffected != null)
            {
                var ids = t_employeeinjurybodypartsaffected.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Parts Of Body Affected= ";
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
							   ViewBag.SearchResult += db.T_BodyPartsAffecteds.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeInjuryBodyPartsAffectedlist.Union(db.T_BodyPartsAffecteds.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_BodyPartsAffected>(User, list, "T_BodyPartsAffected", null);
					ViewBag.t_employeeinjurybodypartsaffected = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeInjuryBodyPartsAffectedlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_BodyPartsAffected>(User, list, "T_BodyPartsAffected", null);
				ViewBag.t_employeeinjurybodypartsaffected = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EMployeeInjuryMachineToollist = db.T_MachineTools.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeinjurymachinetool != null)
            {
                var ids = t_employeeinjurymachinetool.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Machine, Tool Or Object Causing Illness Or Injury = ";
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
							   ViewBag.SearchResult += db.T_MachineTools.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EMployeeInjuryMachineToollist.Union(db.T_MachineTools.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_MachineTool>(User, list, "T_MachineTool", null);
					ViewBag.t_employeeinjurymachinetool = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EMployeeInjuryMachineToollist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_MachineTool>(User, list, "T_MachineTool", null);
				ViewBag.t_employeeinjurymachinetool = new SelectList(list, "ID", "DisplayValue");
			}
			var T_InitialTreatmentListlist = db.T_InitialTreatments.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_initialtreatmentlist != null)
            {
                var ids = t_initialtreatmentlist.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Initial Treatment List= ";
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
							   ViewBag.SearchResult += db.T_InitialTreatments.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_InitialTreatmentListlist.Union(db.T_InitialTreatments.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_InitialTreatment>(User, list, "T_InitialTreatment", null);
					ViewBag.t_initialtreatmentlist = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_InitialTreatmentListlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_InitialTreatment>(User, list, "T_InitialTreatment", null);
				ViewBag.t_initialtreatmentlist = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeInjuryMedicalFacilityForTreatmentlist = db.T_MedicalFacilityForTreatments.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeinjurymedicalfacilityfortreatment != null)
            {
                var ids = t_employeeinjurymedicalfacilityfortreatment.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Medical Facility For Treatment= ";
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
							   ViewBag.SearchResult += db.T_MedicalFacilityForTreatments.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeInjuryMedicalFacilityForTreatmentlist.Union(db.T_MedicalFacilityForTreatments.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_MedicalFacilityForTreatment>(User, list, "T_MedicalFacilityForTreatment", null);
					ViewBag.t_employeeinjurymedicalfacilityfortreatment = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeInjuryMedicalFacilityForTreatmentlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_MedicalFacilityForTreatment>(User, list, "T_MedicalFacilityForTreatment", null);
				ViewBag.t_employeeinjurymedicalfacilityfortreatment = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeInjuryRefusallist = db.T_Refusals.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeinjuryrefusal != null)
            {
                var ids = t_employeeinjuryrefusal.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Restriction Refusal Reason= ";
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
							   ViewBag.SearchResult += db.T_Refusals.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeInjuryRefusallist.Union(db.T_Refusals.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Refusal>(User, list, "T_Refusal", null);
					ViewBag.t_employeeinjuryrefusal = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeInjuryRefusallist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Refusal>(User, list, "T_Refusal", null);
				ViewBag.t_employeeinjuryrefusal = new SelectList(list, "ID", "DisplayValue");
			}
			var T_TypeofClaimlist = db.T_ClaimTypes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_typeofclaim != null)
            {
                var ids = t_typeofclaim.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Type of Claim Facility= ";
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
							   ViewBag.SearchResult += db.T_ClaimTypes.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_TypeofClaimlist.Union(db.T_ClaimTypes.Where(p=>ids1.Contains(p.Id))).Distinct().Select(p=>new { ID=p.Id,DisplayValue=p.DisplayValue }).ToList();
					ViewBag.t_typeofclaim = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				ViewBag.t_typeofclaim = new SelectList(T_TypeofClaimlist.Select(p => new { ID = p.Id, DisplayValue = p.DisplayValue }).ToList(), "ID", "DisplayValue");
			}
			var T_TypeOfRestrictionslist = db.T_Restrictionss.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_typeofrestrictions != null)
            {
                var ids = t_typeofrestrictions.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Type Of Restrictions= ";
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
							   ViewBag.SearchResult += db.T_Restrictionss.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_TypeOfRestrictionslist.Union(db.T_Restrictionss.Where(p=>ids1.Contains(p.Id))).Distinct().Select(p=>new { ID=p.Id,DisplayValue=p.DisplayValue }).ToList();
					ViewBag.t_typeofrestrictions = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				ViewBag.t_typeofrestrictions = new SelectList(T_TypeOfRestrictionslist.Select(p => new { ID = p.Id, DisplayValue = p.DisplayValue }).ToList(), "ID", "DisplayValue");
			}
			}
			else
			{
			var objT_EmployeeEmployeeInjury = new List<T_Employee>();
		    ViewBag.t_employeeemployeeinjury = new SelectList(objT_EmployeeEmployeeInjury, "ID", "DisplayValue");
			var objT_TypeofClaimMCI = new List<T_ClaimTypeMCI>();
		    ViewBag.t_typeofclaimmci = new SelectList(objT_TypeofClaimMCI, "ID", "DisplayValue");
			var objT_AccidentShift = new List<T_ShiftTime>();
		    ViewBag.t_accidentshift = new SelectList(objT_AccidentShift, "ID", "DisplayValue");
			var objT_FacilityAccidentOccured = new List<T_AllFacilities>();
		    ViewBag.t_facilityaccidentoccured = new SelectList(objT_FacilityAccidentOccured, "ID", "DisplayValue");
			var objT_UnitWhereAccidentOccured = new List<T_AllFacilitiesUnit>();
		    ViewBag.t_unitwhereaccidentoccured = new SelectList(objT_UnitWhereAccidentOccured, "ID", "DisplayValue");
			var objT_EmployeInjuryFloor = new List<T_AllFacilitiesFloor>();
		    ViewBag.t_employeinjuryfloor = new SelectList(objT_EmployeInjuryFloor, "ID", "DisplayValue");
			var objT_LocationOfAccident = new List<T_WCAccident>();
		    ViewBag.t_locationofaccident = new SelectList(objT_LocationOfAccident, "ID", "DisplayValue");
			var objT_EmployeeInjuryCause = new List<T_InjuryCause>();
		    ViewBag.t_employeeinjurycause = new SelectList(objT_EmployeeInjuryCause, "ID", "DisplayValue");
			var objT_EmployeeInjuryNature = new List<T_InjuryNature>();
		    ViewBag.t_employeeinjurynature = new SelectList(objT_EmployeeInjuryNature, "ID", "DisplayValue");
			var objT_EmployeeInjuryBodyPartsAffected = new List<T_BodyPartsAffected>();
		    ViewBag.t_employeeinjurybodypartsaffected = new SelectList(objT_EmployeeInjuryBodyPartsAffected, "ID", "DisplayValue");
			var objT_EMployeeInjuryMachineTool = new List<T_MachineTool>();
		    ViewBag.t_employeeinjurymachinetool = new SelectList(objT_EMployeeInjuryMachineTool, "ID", "DisplayValue");
			var objT_InitialTreatmentList = new List<T_InitialTreatment>();
		    ViewBag.t_initialtreatmentlist = new SelectList(objT_InitialTreatmentList, "ID", "DisplayValue");
			var objT_EmployeeInjuryMedicalFacilityForTreatment = new List<T_MedicalFacilityForTreatment>();
		    ViewBag.t_employeeinjurymedicalfacilityfortreatment = new SelectList(objT_EmployeeInjuryMedicalFacilityForTreatment, "ID", "DisplayValue");
			var objT_EmployeeInjuryRefusal = new List<T_Refusal>();
		    ViewBag.t_employeeinjuryrefusal = new SelectList(objT_EmployeeInjuryRefusal, "ID", "DisplayValue");
			var objT_TypeofClaim = new List<T_ClaimType>();
		    ViewBag.t_typeofclaim = new SelectList(objT_TypeofClaim, "ID", "DisplayValue");
			var objT_TypeOfRestrictions = new List<T_Restrictions>();
		    ViewBag.t_typeofrestrictions = new SelectList(objT_TypeOfRestrictions, "ID", "DisplayValue");
			}
				var lstFavoriteItem = db.FavoriteItems.Where(p => p.LastUpdatedByUser == User.Name);
				if (lstFavoriteItem.Count() > 0)
                    ViewBag.FavoriteItem = lstFavoriteItem;
				ViewBag.EntityName = "T_EmployeeInjury";
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
			columns.Add("3", "Type of Claim MCI");
			columns.Add("4", "Claim No.");
			columns.Add("5", "OSHA");
			columns.Add("6", "Location ");
			columns.Add("7", "Accident Date & Time");
			columns.Add("8", "Initial Treatment List");
			columns.Add("9", "Diagnosis ");
			columns.Add("10", "Days Off");
			columns.Add("11", "Days Restricted");
				ViewBag.HideColumns = new MultiSelectList(columns, "Key", "Value");
				return View(new T_EmployeeInjury());
            }
		public string conditionFSearch(string property, string operators, string value)
        {
            string expression = string.Empty;
            var PrpertyType = GetDataTypeOfProperty("T_EmployeeInjury", property);
            var dataType = PrpertyType[0];
            property = PrpertyType[1];
            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                var ValueType = GetDataTypeOfProperty("T_EmployeeInjury", value, true);
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
							expression = string.Format(" DbFunctions.TruncateTime(" + property + ") " + operators + " (\"{0}\")", (TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (new T_EmployeeInjury()).m_Timezone)).Date);
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
		// GET: /T_EmployeeInjury/FSearch/
		[Audit("FacetedSearch")]
		public ActionResult FSearch(string currentFilter, string searchString, string FSFilter, string sortBy, string isAsc, int? page, int? itemsPerPage, string search, bool? IsExport ,string t_employeeemployeeinjury,string t_typeofclaimmci,string t_accidentshift,string t_facilityaccidentoccured,string t_unitwhereaccidentoccured,string t_employeinjuryfloor,string t_locationofaccident,string t_employeeinjurycause,string t_employeeinjurynature,string t_employeeinjurybodypartsaffected,string t_employeeinjurymachinetool,string t_initialtreatmentlist,string t_employeeinjurymedicalfacilityfortreatment,string t_employeeinjuryrefusal,string t_typeofclaim,string t_typeofrestrictions ,string T_OSHA,string T_AccidentDateFrom,string T_AccidentDateTo,string T_DaysOffFrom,string T_DaysOffTo,string T_DaysRestrictedFrom,string T_DaysRestrictedTo,string T_RestrictionStartDateFrom,string T_RestrictionStartDateTo,string T_RestrictionEndDateFrom,string T_RestrictionEndDateTo,string T_AccidentDateFromhdn,string T_AccidentDateTohdn,string FilterCondition, string HostingEntity, string AssociatedType,string HostingEntityID, string viewtype, string SortOrder, string HideColumns, string GroupByColumn,bool? IsReports, bool? IsdrivedTab)
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
				 var lstT_EmployeeInjury  = from s in db.T_EmployeeInjurys
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_EmployeeInjury  = searchRecords(lstT_EmployeeInjury, searchString.ToUpper(),true);
            }
			  if(!string.IsNullOrEmpty(search))
                	search=search.Replace("?IsAddPop=true", "");
			if(!string.IsNullOrEmpty(search)){
				ViewBag.SearchResult += "\r\n General Criterial= "+search;
				lstT_EmployeeInjury = searchRecords(lstT_EmployeeInjury, search,true);
			}
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_EmployeeInjury  = sortRecords(lstT_EmployeeInjury, sortBy, isAsc);
            }
            else   lstT_EmployeeInjury  = lstT_EmployeeInjury.OrderByDescending(c => c.Id);
			lstT_EmployeeInjury = CustomSorting(lstT_EmployeeInjury);
			lstT_EmployeeInjury = lstT_EmployeeInjury.Include(t=>t.t_employeeemployeeinjury).Include(t=>t.t_typeofclaimmci).Include(t=>t.t_accidentshift).Include(t=>t.t_facilityaccidentoccured).Include(t=>t.t_unitwhereaccidentoccured).Include(t=>t.t_employeinjuryfloor).Include(t=>t.t_locationofaccident).Include(t=>t.t_employeeinjurycause).Include(t=>t.t_employeeinjurynature).Include(t=>t.t_employeeinjurybodypartsaffected).Include(t=>t.t_employeeinjurymachinetool).Include(t=>t.t_initialtreatmentlist).Include(t=>t.t_employeeinjurymedicalfacilityfortreatment).Include(t=>t.t_employeeinjuryrefusal);
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
					ViewBag.SearchResult += " " + GetPropertyDP("T_EmployeeInjury", PropertyName) + " " + Operator + " " + Value + " " + LogicalConnector;
                    whereCondition.Append(conditionFSearch(PropertyName, Operator, Value) + LogicalConnector);
                    iCnt++;
                }
                if (!string.IsNullOrEmpty(whereCondition.ToString()))
                    lstT_EmployeeInjury = lstT_EmployeeInjury.Where(whereCondition.ToString());
                ViewBag.FilterCondition = FilterCondition;
            }
			var DataOrdering = string.Empty;
            if (!string.IsNullOrEmpty(GroupByColumn))
            {
                DataOrdering = GroupByColumn;
				                ViewBag.IsGroupBy = true;
            }
            if (!string.IsNullOrEmpty(SortOrder))
                DataOrdering += SortOrder;
            if (!string.IsNullOrEmpty(DataOrdering))
                lstT_EmployeeInjury = Sorting.Sort<T_EmployeeInjury>(lstT_EmployeeInjury, DataOrdering);
            var _T_EmployeeInjury = lstT_EmployeeInjury;
		 if(T_OSHA!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_OSHA);
                    _T_EmployeeInjury =  _T_EmployeeInjury.Where(o => o.T_OSHA == boolvalue);
					ViewBag.SearchResult += "\r\n OSHA= "+T_OSHA;
                }
                catch { }
            }
				if(T_AccidentDateFrom!=null || T_AccidentDateTo !=null)
				{
						try
						{
							DateTime from = T_AccidentDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_AccidentDateFrom);
							DateTime to = T_AccidentDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_AccidentDateTo);
                      _T_EmployeeInjury =  _T_EmployeeInjury.Where(o => o.T_AccidentDate >= from && o.T_AccidentDate <= to);
                   							ViewBag.SearchResult += "\r\n Accident Date & Time= "+T_AccidentDateFromhdn+"-"+T_AccidentDateTohdn;
						}
						catch { }
				}
		 if(T_DaysOffFrom!=null || T_DaysOffTo !=null)
		 {
                try
                {
                    int from = T_DaysOffFrom == null ? 0 : Convert.ToInt32(T_DaysOffFrom);
                    int to =  T_DaysOffTo == null ? int.MaxValue : Convert.ToInt32(T_DaysOffTo);
									     _T_EmployeeInjury =  _T_EmployeeInjury.Where(o => o.T_DaysOff >= from && o.T_DaysOff <= to);
                   					ViewBag.SearchResult += "\r\n Days Off= "+from+"-"+to;
                }
                catch { }
          }
		 if(T_DaysRestrictedFrom!=null || T_DaysRestrictedTo !=null)
		 {
                try
                {
                    int from = T_DaysRestrictedFrom == null ? 0 : Convert.ToInt32(T_DaysRestrictedFrom);
                    int to =  T_DaysRestrictedTo == null ? int.MaxValue : Convert.ToInt32(T_DaysRestrictedTo);
									     _T_EmployeeInjury =  _T_EmployeeInjury.Where(o => o.T_DaysRestricted >= from && o.T_DaysRestricted <= to);
                   					ViewBag.SearchResult += "\r\n Days Restricted= "+from+"-"+to;
                }
                catch { }
          }
				if(T_RestrictionStartDateFrom!=null || T_RestrictionStartDateTo !=null)
				{
						try
						{
							DateTime from = T_RestrictionStartDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_RestrictionStartDateFrom);
							DateTime to = T_RestrictionStartDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_RestrictionStartDateTo).AddTicks(-1).AddDays(1);
							                       _T_EmployeeInjury =  _T_EmployeeInjury.Where(o =>o.T_RestrictionStartDate!=null && o.T_RestrictionStartDate.Value.CompareTo(from) >= 0 && o.T_RestrictionStartDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Restriction Start Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_RestrictionEndDateFrom!=null || T_RestrictionEndDateTo !=null)
				{
						try
						{
							DateTime from = T_RestrictionEndDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_RestrictionEndDateFrom);
							DateTime to = T_RestrictionEndDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_RestrictionEndDateTo).AddTicks(-1).AddDays(1);
							                       _T_EmployeeInjury =  _T_EmployeeInjury.Where(o =>o.T_RestrictionEndDate!=null && o.T_RestrictionEndDate.Value.CompareTo(from) >= 0 && o.T_RestrictionEndDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Restriction End Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
			//if (lstT_EmployeeInjury.Where(p => p.t_employeeemployeeinjury != null).Count() <= 50)
		    //ViewBag.t_employeeemployeeinjury = new SelectList(lstT_EmployeeInjury.Where(p => p.t_employeeemployeeinjury != null).Select(P => P.t_employeeemployeeinjury).Distinct(), "ID", "DisplayValue");
            if (t_employeeemployeeinjury != null)
            {
                var ids = t_employeeemployeeinjury.Split(",".ToCharArray());
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
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_EmployeeEmployeeInjuryID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_typeofclaimmci != null).Count() <= 50)
		    //ViewBag.t_typeofclaimmci = new SelectList(lstT_EmployeeInjury.Where(p => p.t_typeofclaimmci != null).Select(P => P.t_typeofclaimmci).Distinct(), "ID", "DisplayValue");
            if (t_typeofclaimmci != null)
            {
                var ids = t_typeofclaimmci.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Type of Claim MCI= ";
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
                            var obj = db.T_ClaimTypeMCIs.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_TypeofClaimMCIID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_accidentshift != null).Count() <= 50)
		    //ViewBag.t_accidentshift = new SelectList(lstT_EmployeeInjury.Where(p => p.t_accidentshift != null).Select(P => P.t_accidentshift).Distinct(), "ID", "DisplayValue");
            if (t_accidentshift != null)
            {
                var ids = t_accidentshift.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Shift Working When Accident Occurred= ";
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
                            var obj = db.T_ShiftTimes.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_AccidentShiftID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_facilityaccidentoccured != null).Count() <= 50)
		    //ViewBag.t_facilityaccidentoccured = new SelectList(lstT_EmployeeInjury.Where(p => p.t_facilityaccidentoccured != null).Select(P => P.t_facilityaccidentoccured).Distinct(), "ID", "DisplayValue");
            if (t_facilityaccidentoccured != null)
            {
                var ids = t_facilityaccidentoccured.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Facility Accident Occurred At= ";
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
                            var obj = db.T_AllFacilitiess.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_FacilityAccidentOccuredID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_unitwhereaccidentoccured != null).Count() <= 50)
		    //ViewBag.t_unitwhereaccidentoccured = new SelectList(lstT_EmployeeInjury.Where(p => p.t_unitwhereaccidentoccured != null).Select(P => P.t_unitwhereaccidentoccured).Distinct(), "ID", "DisplayValue");
            if (t_unitwhereaccidentoccured != null)
            {
                var ids = t_unitwhereaccidentoccured.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Unit Where Accident Occured= ";
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
                            var obj = db.T_AllFacilitiesUnits.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_UnitWhereAccidentOccuredID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_employeinjuryfloor != null).Count() <= 50)
		    //ViewBag.t_employeinjuryfloor = new SelectList(lstT_EmployeeInjury.Where(p => p.t_employeinjuryfloor != null).Select(P => P.t_employeinjuryfloor).Distinct(), "ID", "DisplayValue");
            if (t_employeinjuryfloor != null)
            {
                var ids = t_employeinjuryfloor.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Floor Accident Occurred on= ";
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
                            var obj = db.T_AllFacilitiesFloors.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_EmployeInjuryFloorID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_locationofaccident != null).Count() <= 50)
		    //ViewBag.t_locationofaccident = new SelectList(lstT_EmployeeInjury.Where(p => p.t_locationofaccident != null).Select(P => P.t_locationofaccident).Distinct(), "ID", "DisplayValue");
            if (t_locationofaccident != null)
            {
                var ids = t_locationofaccident.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Location Of Accident= ";
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
                            var obj = db.T_WCAccidents.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_LocationOfAccidentID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_employeeinjurycause != null).Count() <= 50)
		    //ViewBag.t_employeeinjurycause = new SelectList(lstT_EmployeeInjury.Where(p => p.t_employeeinjurycause != null).Select(P => P.t_employeeinjurycause).Distinct(), "ID", "DisplayValue");
            if (t_employeeinjurycause != null)
            {
                var ids = t_employeeinjurycause.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Cause Of Injury = ";
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
                            var obj = db.T_InjuryCauses.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_EmployeeInjuryCauseID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_employeeinjurynature != null).Count() <= 50)
		    //ViewBag.t_employeeinjurynature = new SelectList(lstT_EmployeeInjury.Where(p => p.t_employeeinjurynature != null).Select(P => P.t_employeeinjurynature).Distinct(), "ID", "DisplayValue");
            if (t_employeeinjurynature != null)
            {
                var ids = t_employeeinjurynature.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Nature Of Injury Or Illness= ";
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
                            var obj = db.T_InjuryNatures.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_EmployeeInjuryNatureID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_employeeinjurybodypartsaffected != null).Count() <= 50)
		    //ViewBag.t_employeeinjurybodypartsaffected = new SelectList(lstT_EmployeeInjury.Where(p => p.t_employeeinjurybodypartsaffected != null).Select(P => P.t_employeeinjurybodypartsaffected).Distinct(), "ID", "DisplayValue");
            if (t_employeeinjurybodypartsaffected != null)
            {
                var ids = t_employeeinjurybodypartsaffected.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Parts Of Body Affected= ";
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
                            var obj = db.T_BodyPartsAffecteds.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_EmployeeInjuryBodyPartsAffectedID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_employeeinjurymachinetool != null).Count() <= 50)
		    //ViewBag.t_employeeinjurymachinetool = new SelectList(lstT_EmployeeInjury.Where(p => p.t_employeeinjurymachinetool != null).Select(P => P.t_employeeinjurymachinetool).Distinct(), "ID", "DisplayValue");
            if (t_employeeinjurymachinetool != null)
            {
                var ids = t_employeeinjurymachinetool.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Machine, Tool Or Object Causing Illness Or Injury = ";
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
                            var obj = db.T_MachineTools.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_EMployeeInjuryMachineToolID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_initialtreatmentlist != null).Count() <= 50)
		    //ViewBag.t_initialtreatmentlist = new SelectList(lstT_EmployeeInjury.Where(p => p.t_initialtreatmentlist != null).Select(P => P.t_initialtreatmentlist).Distinct(), "ID", "DisplayValue");
            if (t_initialtreatmentlist != null)
            {
                var ids = t_initialtreatmentlist.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Initial Treatment List= ";
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
                            var obj = db.T_InitialTreatments.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_InitialTreatmentListID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_employeeinjurymedicalfacilityfortreatment != null).Count() <= 50)
		    //ViewBag.t_employeeinjurymedicalfacilityfortreatment = new SelectList(lstT_EmployeeInjury.Where(p => p.t_employeeinjurymedicalfacilityfortreatment != null).Select(P => P.t_employeeinjurymedicalfacilityfortreatment).Distinct(), "ID", "DisplayValue");
            if (t_employeeinjurymedicalfacilityfortreatment != null)
            {
                var ids = t_employeeinjurymedicalfacilityfortreatment.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Medical Facility For Treatment= ";
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
                            var obj = db.T_MedicalFacilityForTreatments.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_EmployeeInjuryMedicalFacilityForTreatmentID));
            }
				//if (lstT_EmployeeInjury.Where(p => p.t_employeeinjuryrefusal != null).Count() <= 50)
		    //ViewBag.t_employeeinjuryrefusal = new SelectList(lstT_EmployeeInjury.Where(p => p.t_employeeinjuryrefusal != null).Select(P => P.t_employeeinjuryrefusal).Distinct(), "ID", "DisplayValue");
            if (t_employeeinjuryrefusal != null)
            {
                var ids = t_employeeinjuryrefusal.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Restriction Refusal Reason= ";
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
                            var obj = db.T_Refusals.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.T_EmployeeInjuryRefusalID));
            }
				if (t_typeofclaim != null)
            {
                var ids = t_typeofclaim.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
                ViewBag.SearchResult += "\r\n  Type of Claim Facility= ";
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
                        var idvalue= Convert.ToInt64(str);
                        ViewBag.SearchResult += db.T_ClaimTypes.Find(Convert.ToInt64(str)).DisplayValue + ", ";
                        ids1.AddRange(db.T_TypeofClaims.Where(p=>p.T_ClaimTypeID ==idvalue).Select(p=>p.T_EmployeeInjuryID));
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.Id));
            }
			if (t_typeofrestrictions != null)
            {
                var ids = t_typeofrestrictions.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
                ViewBag.SearchResult += "\r\n  Type Of Restrictions= ";
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
                        var idvalue= Convert.ToInt64(str);
                        ViewBag.SearchResult += db.T_Restrictionss.Find(Convert.ToInt64(str)).DisplayValue + ", ";
                        ids1.AddRange(db.T_TypeOfRestrictionss.Where(p=>p.T_RestrictionsID ==idvalue).Select(p=>p.T_EmployeeInjuryID));
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_EmployeeInjury = _T_EmployeeInjury.Where(p => ids1.Contains(p.Id));
            }
			if (!string.IsNullOrEmpty(SortOrder))
            {
                ViewBag.SearchResult += " \r\n Sort Order = ";
                var sortString = "";
                var sortProps = SortOrder.Split(",".ToCharArray());
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeInjury");
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
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeInjury");
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
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_EmployeeInjury"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_EmployeeInjury"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
            //
            if (Convert.ToBoolean(IsExport))
            {
                pageNumber = 1;
                if (_T_EmployeeInjury.Count() > 0)
                    pageSize = _T_EmployeeInjury.Count();
                return View("ExcelExport", _T_EmployeeInjury.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_EmployeeInjury.Count();
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
			  var list = _T_EmployeeInjury.ToPagedList(pageNumber, pageSize);
			  if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_EmployeeInjury", tagsSplit.ToArray());
                    }
			  ViewBag.EntityT_EmployeeInjuryDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
			  TempData["T_EmployeeInjurylist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
              return View("Index",list);
			}
            else
			{
				var list = _T_EmployeeInjury.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_EmployeeInjuryDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_EmployeeInjurylist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_EmployeeInjury", tagsSplit.ToArray());
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
		var entity = "T_EmployeeInjury";
           var chartlist = db.Charts.Where(chrt => chrt.EntityName == entity && chrt.ShowInDashBoard).ToList();
           if (type != "all")
               chartlist = chartlist.Where(chrt => chrt.Id == Convert.ToInt64(type)).ToList();
           var entitylist = db.T_EmployeeInjurys;
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
                var gd = db.T_EmployeeInjurys.GroupBy(p => p.t_employeeemployeeinjury.DisplayValue).ToList();
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
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Employee", "Employee Injury"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "1", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).ToList();
                    if (_yvalT_DaysOff .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysOff  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysOff.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Employee (Top 10)"));
				else
				chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Employee"));
                chartT_DaysOff.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Employee", "T_DaysOff"));
                chartT_DaysOff.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysOff.Series[0].Points.DataBindXY(_xval, _yvalT_DaysOff );
                chartT_DaysOff.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysOff.Width = 800;
                        chartT_DaysOff.Height = 800;
                    }
                byte[] bytesT_DaysOff;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysOff.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysOff = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysOff = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "2", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
                    else
                    {
                        string imgT_DaysOff = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
				}
			if (type == "3" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).ToList();
                    if (_yvalT_DaysRestricted .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysRestricted  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysRestricted.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Employee (Top 10)"));
				else
				chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Employee"));
                chartT_DaysRestricted.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Employee", "T_DaysRestricted"));
                chartT_DaysRestricted.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysRestricted.Series[0].Points.DataBindXY(_xval, _yvalT_DaysRestricted );
                chartT_DaysRestricted.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysRestricted.Width = 800;
                        chartT_DaysRestricted.Height = 800;
                    }
                byte[] bytesT_DaysRestricted;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysRestricted.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysRestricted = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysRestricted = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "3", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
                    else
                    {
                        string imgT_DaysRestricted = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
				}
            }
           {
                var gd = db.T_EmployeeInjurys.GroupBy(p => p.t_typeofclaimmci.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "4" || type == "all")
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
                chart.Titles.Add(CreateTitle("Count by Type of Claim MCI (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Type of Claim MCI"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Type of Claim MCI", "Employee Injury"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "4", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
			if (type == "5" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).ToList();
                    if (_yvalT_DaysOff .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysOff  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysOff.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Type of Claim MCI (Top 10)"));
				else
				chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Type of Claim MCI"));
                chartT_DaysOff.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Type of Claim MCI", "T_DaysOff"));
                chartT_DaysOff.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysOff.Series[0].Points.DataBindXY(_xval, _yvalT_DaysOff );
                chartT_DaysOff.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysOff.Width = 800;
                        chartT_DaysOff.Height = 800;
                    }
                byte[] bytesT_DaysOff;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysOff.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysOff = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysOff = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "5", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
                    else
                    {
                        string imgT_DaysOff = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
				}
			if (type == "6" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).ToList();
                    if (_yvalT_DaysRestricted .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysRestricted  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysRestricted.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Type of Claim MCI (Top 10)"));
				else
				chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Type of Claim MCI"));
                chartT_DaysRestricted.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Type of Claim MCI", "T_DaysRestricted"));
                chartT_DaysRestricted.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysRestricted.Series[0].Points.DataBindXY(_xval, _yvalT_DaysRestricted );
                chartT_DaysRestricted.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysRestricted.Width = 800;
                        chartT_DaysRestricted.Height = 800;
                    }
                byte[] bytesT_DaysRestricted;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysRestricted.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysRestricted = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysRestricted = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "6", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
                    else
                    {
                        string imgT_DaysRestricted = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
				}
            }
           {
                var gd = db.T_EmployeeInjurys.GroupBy(p => p.t_accidentshift.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Shift Working When Accident Occurred (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Shift Working When Accident Occurred"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Shift Working When Accident Occurred", "Employee Injury"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "7", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).ToList();
                    if (_yvalT_DaysOff .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysOff  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysOff.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Shift Working When Accident Occurred (Top 10)"));
				else
				chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Shift Working When Accident Occurred"));
                chartT_DaysOff.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Shift Working When Accident Occurred", "T_DaysOff"));
                chartT_DaysOff.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysOff.Series[0].Points.DataBindXY(_xval, _yvalT_DaysOff );
                chartT_DaysOff.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysOff.Width = 800;
                        chartT_DaysOff.Height = 800;
                    }
                byte[] bytesT_DaysOff;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysOff.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysOff = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysOff = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "8", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
                    else
                    {
                        string imgT_DaysOff = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
				}
			if (type == "9" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).ToList();
                    if (_yvalT_DaysRestricted .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysRestricted  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysRestricted.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Shift Working When Accident Occurred (Top 10)"));
				else
				chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Shift Working When Accident Occurred"));
                chartT_DaysRestricted.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Shift Working When Accident Occurred", "T_DaysRestricted"));
                chartT_DaysRestricted.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysRestricted.Series[0].Points.DataBindXY(_xval, _yvalT_DaysRestricted );
                chartT_DaysRestricted.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysRestricted.Width = 800;
                        chartT_DaysRestricted.Height = 800;
                    }
                byte[] bytesT_DaysRestricted;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysRestricted.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysRestricted = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysRestricted = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "9", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
                    else
                    {
                        string imgT_DaysRestricted = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
				}
            }
           {
                var gd = db.T_EmployeeInjurys.GroupBy(p => p.t_facilityaccidentoccured.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "10" || type == "all")
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
                chart.Titles.Add(CreateTitle("Count by Facility Accident Occurred At (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Facility Accident Occurred At"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Facility Accident Occurred At", "Employee Injury"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "10", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
			if (type == "11" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).ToList();
                    if (_yvalT_DaysOff .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysOff  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysOff.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Facility Accident Occurred At (Top 10)"));
				else
				chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Facility Accident Occurred At"));
                chartT_DaysOff.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Facility Accident Occurred At", "T_DaysOff"));
                chartT_DaysOff.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysOff.Series[0].Points.DataBindXY(_xval, _yvalT_DaysOff );
                chartT_DaysOff.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysOff.Width = 800;
                        chartT_DaysOff.Height = 800;
                    }
                byte[] bytesT_DaysOff;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysOff.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysOff = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysOff = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "11", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
                    else
                    {
                        string imgT_DaysOff = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
				}
			if (type == "12" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).ToList();
                    if (_yvalT_DaysRestricted .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysRestricted  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysRestricted.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Facility Accident Occurred At (Top 10)"));
				else
				chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Facility Accident Occurred At"));
                chartT_DaysRestricted.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Facility Accident Occurred At", "T_DaysRestricted"));
                chartT_DaysRestricted.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysRestricted.Series[0].Points.DataBindXY(_xval, _yvalT_DaysRestricted );
                chartT_DaysRestricted.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysRestricted.Width = 800;
                        chartT_DaysRestricted.Height = 800;
                    }
                byte[] bytesT_DaysRestricted;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysRestricted.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysRestricted = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysRestricted = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "12", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
                    else
                    {
                        string imgT_DaysRestricted = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
				}
            }
           {
                var gd = db.T_EmployeeInjurys.GroupBy(p => p.t_unitwhereaccidentoccured.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Unit Where Accident Occured (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Unit Where Accident Occured"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Unit Where Accident Occured", "Employee Injury"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "13", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).ToList();
                    if (_yvalT_DaysOff .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysOff  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysOff.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Unit Where Accident Occured (Top 10)"));
				else
				chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Unit Where Accident Occured"));
                chartT_DaysOff.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Unit Where Accident Occured", "T_DaysOff"));
                chartT_DaysOff.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysOff.Series[0].Points.DataBindXY(_xval, _yvalT_DaysOff );
                chartT_DaysOff.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysOff.Width = 800;
                        chartT_DaysOff.Height = 800;
                    }
                byte[] bytesT_DaysOff;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysOff.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysOff = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysOff = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "14", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
                    else
                    {
                        string imgT_DaysOff = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
				}
			if (type == "15" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).ToList();
                    if (_yvalT_DaysRestricted .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysRestricted  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysRestricted.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Unit Where Accident Occured (Top 10)"));
				else
				chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Unit Where Accident Occured"));
                chartT_DaysRestricted.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Unit Where Accident Occured", "T_DaysRestricted"));
                chartT_DaysRestricted.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysRestricted.Series[0].Points.DataBindXY(_xval, _yvalT_DaysRestricted );
                chartT_DaysRestricted.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysRestricted.Width = 800;
                        chartT_DaysRestricted.Height = 800;
                    }
                byte[] bytesT_DaysRestricted;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysRestricted.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysRestricted = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysRestricted = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "15", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
                    else
                    {
                        string imgT_DaysRestricted = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
				}
            }
           {
                var gd = db.T_EmployeeInjurys.GroupBy(p => p.t_employeinjuryfloor.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "16" || type == "all")
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
                chart.Titles.Add(CreateTitle("Count by Floor Accident Occurred on (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Floor Accident Occurred on"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Floor Accident Occurred on", "Employee Injury"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "16", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
			if (type == "17" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).ToList();
                    if (_yvalT_DaysOff .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysOff  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysOff.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Floor Accident Occurred on (Top 10)"));
				else
				chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Floor Accident Occurred on"));
                chartT_DaysOff.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Floor Accident Occurred on", "T_DaysOff"));
                chartT_DaysOff.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysOff.Series[0].Points.DataBindXY(_xval, _yvalT_DaysOff );
                chartT_DaysOff.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysOff.Width = 800;
                        chartT_DaysOff.Height = 800;
                    }
                byte[] bytesT_DaysOff;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysOff.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysOff = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysOff = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "17", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
                    else
                    {
                        string imgT_DaysOff = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
				}
			if (type == "18" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).ToList();
                    if (_yvalT_DaysRestricted .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysRestricted  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysRestricted.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Floor Accident Occurred on (Top 10)"));
				else
				chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Floor Accident Occurred on"));
                chartT_DaysRestricted.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Floor Accident Occurred on", "T_DaysRestricted"));
                chartT_DaysRestricted.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysRestricted.Series[0].Points.DataBindXY(_xval, _yvalT_DaysRestricted );
                chartT_DaysRestricted.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysRestricted.Width = 800;
                        chartT_DaysRestricted.Height = 800;
                    }
                byte[] bytesT_DaysRestricted;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysRestricted.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysRestricted = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysRestricted = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "18", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
                    else
                    {
                        string imgT_DaysRestricted = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
				}
            }
           {
                var gd = db.T_EmployeeInjurys.GroupBy(p => p.t_locationofaccident.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "19" || type == "all")
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
                chart.Titles.Add(CreateTitle("Count by Location Of Accident (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Location Of Accident"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Location Of Accident", "Employee Injury"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "19", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
			if (type == "20" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).ToList();
                    if (_yvalT_DaysOff .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysOff  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysOff.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Location Of Accident (Top 10)"));
				else
				chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Location Of Accident"));
                chartT_DaysOff.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Location Of Accident", "T_DaysOff"));
                chartT_DaysOff.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysOff.Series[0].Points.DataBindXY(_xval, _yvalT_DaysOff );
                chartT_DaysOff.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysOff.Width = 800;
                        chartT_DaysOff.Height = 800;
                    }
                byte[] bytesT_DaysOff;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysOff.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysOff = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysOff = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "20", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
                    else
                    {
                        string imgT_DaysOff = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
				}
			if (type == "21" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).ToList();
                    if (_yvalT_DaysRestricted .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysRestricted  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysRestricted.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Location Of Accident (Top 10)"));
				else
				chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Location Of Accident"));
                chartT_DaysRestricted.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Location Of Accident", "T_DaysRestricted"));
                chartT_DaysRestricted.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysRestricted.Series[0].Points.DataBindXY(_xval, _yvalT_DaysRestricted );
                chartT_DaysRestricted.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysRestricted.Width = 800;
                        chartT_DaysRestricted.Height = 800;
                    }
                byte[] bytesT_DaysRestricted;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysRestricted.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysRestricted = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysRestricted = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "21", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
                    else
                    {
                        string imgT_DaysRestricted = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
				}
            }
           {
                var gd = db.T_EmployeeInjurys.GroupBy(p => p.t_employeeinjurycause.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "22" || type == "all")
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
                chart.Titles.Add(CreateTitle("Count by Cause Of Injury  (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Cause Of Injury "));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Cause Of Injury ", "Employee Injury"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "22", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
			if (type == "23" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).ToList();
                    if (_yvalT_DaysOff .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysOff  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysOff.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Cause Of Injury  (Top 10)"));
				else
				chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Cause Of Injury "));
                chartT_DaysOff.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Cause Of Injury ", "T_DaysOff"));
                chartT_DaysOff.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysOff.Series[0].Points.DataBindXY(_xval, _yvalT_DaysOff );
                chartT_DaysOff.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysOff.Width = 800;
                        chartT_DaysOff.Height = 800;
                    }
                byte[] bytesT_DaysOff;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysOff.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysOff = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysOff = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "23", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
                    else
                    {
                        string imgT_DaysOff = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
				}
			if (type == "24" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).ToList();
                    if (_yvalT_DaysRestricted .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysRestricted  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysRestricted.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Cause Of Injury  (Top 10)"));
				else
				chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Cause Of Injury "));
                chartT_DaysRestricted.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Cause Of Injury ", "T_DaysRestricted"));
                chartT_DaysRestricted.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysRestricted.Series[0].Points.DataBindXY(_xval, _yvalT_DaysRestricted );
                chartT_DaysRestricted.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysRestricted.Width = 800;
                        chartT_DaysRestricted.Height = 800;
                    }
                byte[] bytesT_DaysRestricted;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysRestricted.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysRestricted = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysRestricted = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "24", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
                    else
                    {
                        string imgT_DaysRestricted = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
				}
            }
           {
                var gd = db.T_EmployeeInjurys.GroupBy(p => p.t_employeeinjurynature.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Nature Of Injury Or Illness (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Nature Of Injury Or Illness"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Nature Of Injury Or Illness", "Employee Injury"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "25", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).ToList();
                    if (_yvalT_DaysOff .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysOff = gd.Select(k => k.Sum(p=>p.T_DaysOff)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysOff  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysOff.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Nature Of Injury Or Illness (Top 10)"));
				else
				chartT_DaysOff.Titles.Add(CreateTitle("Total of Days Off by Nature Of Injury Or Illness"));
                chartT_DaysOff.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Nature Of Injury Or Illness", "T_DaysOff"));
                chartT_DaysOff.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysOff.Series[0].Points.DataBindXY(_xval, _yvalT_DaysOff );
                chartT_DaysOff.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysOff.Width = 800;
                        chartT_DaysOff.Height = 800;
                    }
                byte[] bytesT_DaysOff;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysOff.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysOff = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysOff = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "26", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
                    else
                    {
                        string imgT_DaysOff = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysOff = Convert.ToBase64String(bytesT_DaysOff.ToArray());
                        result += String.Format(imgT_DaysOff, encodedT_DaysOff);
                    }
				}
			if (type == "27" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).ToList();
                    if (_yvalT_DaysRestricted .Count > 10 && inlarge == null)
                    {
                        _yvalT_DaysRestricted = gd.Select(k => k.Sum(p=>p.T_DaysRestricted)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_DaysRestricted  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_DaysRestricted.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Nature Of Injury Or Illness (Top 10)"));
				else
				chartT_DaysRestricted.Titles.Add(CreateTitle("Total of Days Restricted by Nature Of Injury Or Illness"));
                chartT_DaysRestricted.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Nature Of Injury Or Illness", "T_DaysRestricted"));
                chartT_DaysRestricted.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_DaysRestricted.Series[0].Points.DataBindXY(_xval, _yvalT_DaysRestricted );
                chartT_DaysRestricted.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_DaysRestricted.Width = 800;
                        chartT_DaysRestricted.Height = 800;
                    }
                byte[] bytesT_DaysRestricted;
                using (var chartimage = new MemoryStream())
                {
                    chartT_DaysRestricted.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_DaysRestricted = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_DaysRestricted = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_EmployeeInjury", new { type = "27", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
                    }
                    else
                    {
                        string imgT_DaysRestricted = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_DaysRestricted = Convert.ToBase64String(bytesT_DaysRestricted.ToArray());
                        result += String.Format(imgT_DaysRestricted, encodedT_DaysRestricted);
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
            var _Obj = db1.T_EmployeeInjurys.FirstOrDefault(p => p.Id == idvalue);
            return  _Obj==null?"":_Obj.DisplayValue;
        }
		public IQueryable<JournalEntry> GetExtraJournalEntry(int? id, Models.IUser user, JournalEntryContext jedb)
        {
			var listjournaliquery = jedb.JournalEntries.Where(p => p.Id == 0);
			Expression<Func<JournalEntry, bool>> predicateJournalEntry = n => false;
		var t_employeeinjury = jedb.T_EmployeeInjurys.Find(id);
			var T_InjuryRelatedLeaveIds = jedb.T_LeaveProfiles.Where(p=>p.T_InjuryRelatedLeaveID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_LeaveProfile" && T_InjuryRelatedLeaveIds.Contains(d.RecordId) && d.Type != "View"));
			var T_InjuryCommentsIds = jedb.T_Comments.Where(p=>p.T_InjuryCommentsID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_Comment" && T_InjuryCommentsIds.Contains(d.RecordId) && d.Type != "View"));
			var T_AccommodationInjuryIds = jedb.T_Accommodations.Where(p=>p.T_AccommodationInjuryID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_Accommodation" && T_AccommodationInjuryIds.Contains(d.RecordId) && d.Type != "View"));
			
			listjournaliquery = new FilteredDbSet<JournalEntry>(jedb, predicateJournalEntry); 
			return listjournaliquery;
        }
		public object GetRecordById(string id)
        {
		            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            if (string.IsNullOrEmpty(id)) return "";
            var _Obj = db1.T_EmployeeInjurys.Find(Convert.ToInt64(id));
            return _Obj;
        }
		public string GetRecordById_Reflection(string id)
        {
							ApplicationContext db1 = new ApplicationContext(new SystemUser());
			if (string.IsNullOrEmpty(id)) return "";
			var _Obj = db1.T_EmployeeInjurys.Find(Convert.ToInt64(id));
            return _Obj == null ? "" : EntityComparer.EnumeratePropertyValues<T_EmployeeInjury>(_Obj, "T_EmployeeInjury", new string[] { ""  }); ;
			        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllValueForFilter(string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
		            IQueryable<T_EmployeeInjury> list = db.T_EmployeeInjurys;
            var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                       select new { Id = x.Id, Name = x.DisplayValue };
            return Json(data, JsonRequestBehavior.AllowGet);
			        }
		[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValue(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_EmployeeInjury> list = db.T_EmployeeInjurys;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_EmployeeInjurys;
					string lambda = "";
                    foreach (var asso in AssoNameWithParent.Split("?".ToCharArray()))
                    {
                        lambda += asso + "=" + AssociationID + " OR ";
                    }
                    lambda = lambda.TrimEnd(" OR ".ToCharArray());
                    query = query.Where(lambda);
                   //Type[] exprArgTypes = { query.ElementType };
                   // string propToWhere = AssoNameWithParent;
                   // ParameterExpression p = Expression.Parameter(typeof(T_EmployeeInjury), "p");
                   // MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                   // LambdaExpression lambda = Expression.Lambda<Func<T_EmployeeInjury, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                   // MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                   // IQueryable q = query.Provider.CreateQuery(methodCall);
                   //list = ((IQueryable<T_EmployeeInjury>)q);
				   list = ((IQueryable<T_EmployeeInjury>)query);
                }
				else if (AssoID == 0)
                {
                   IQueryable query = db.T_EmployeeInjurys;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_EmployeeInjury), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_EmployeeInjury, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_EmployeeInjury>)q);
                }
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_EmployeeInjury>(User,list, "T_EmployeeInjury",caller);
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
			IQueryable<T_EmployeeInjury> list = db.T_EmployeeInjurys;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_EmployeeInjurys;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_EmployeeInjury), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_EmployeeInjury, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_EmployeeInjury>)q);
                }
            }
			var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
        }
[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValueMobile(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_EmployeeInjury> list = db.T_EmployeeInjurys;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
				try
                {
					Nullable<long> AssoID = Convert.ToInt64(AssociationID);
					if (AssoID != null && AssoID > 0)
					{
						IQueryable query = db.T_EmployeeInjurys;
						Type[] exprArgTypes = { query.ElementType };
						string propToWhere = AssoNameWithParent;
						ParameterExpression p = Expression.Parameter(typeof(T_EmployeeInjury), "p");
						MemberExpression member = Expression.PropertyOrField(p, propToWhere);
						LambdaExpression lambda = Expression.Lambda<Func<T_EmployeeInjury, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
						MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
						IQueryable q = query.Provider.CreateQuery(methodCall);
						list = ((IQueryable<T_EmployeeInjury>)q).Take(20);
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
           list = _fad.FilterDropdown<T_EmployeeInjury>(User,list, "T_EmployeeInjury",caller);
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
            IQueryable<T_EmployeeInjury> list = db.T_EmployeeInjurys;
            if (!string.IsNullOrEmpty(propNameBR))
            {
				//added new code (Remove old code if everything works)
				var result = list.Select("new(Id," + propNameBR + " as value)");
                return Json(result, JsonRequestBehavior.AllowGet);
				//
                ParameterExpression param = Expression.Parameter(typeof(T_EmployeeInjury), "d");
                //bulid expression tree:data.Field1
                var Property = typeof(T_EmployeeInjury).GetProperty(propNameBR);
                Expression selector = Expression.Property(param, Property);
                Expression pred = Expression.Lambda(selector, param);
                //bulid expression tree:Select(d=>d.Field1)
                var targetType = Property.PropertyType;
                if (targetType.GetGenericArguments().Count() > 0)
                {
                    if (targetType.GetGenericArguments()[0].Name == "DateTime")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select", 
                        new Type[] { typeof(T_EmployeeInjury), typeof(DateTime?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<DateTime?> query = list.Provider.CreateQuery<DateTime?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (targetType.GetGenericArguments()[0].Name == "Decimal")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_EmployeeInjury), typeof(decimal?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<decimal?> query = list.Provider.CreateQuery<decimal?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Boolean")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_EmployeeInjury), typeof(bool?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<bool?> query = list.Provider.CreateQuery<bool?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int32")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_EmployeeInjury), typeof(Int32?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int32?> query = list.Provider.CreateQuery<Int32?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int64")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_EmployeeInjury), typeof(Int64?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int64?> query = list.Provider.CreateQuery<Int64?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Double")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_EmployeeInjury), typeof(double?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<double?> query = list.Provider.CreateQuery<double?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    Expression expr = Expression.Call(typeof(Queryable), "Select",
                            new Type[] { typeof(T_EmployeeInjury), typeof(string) }, Expression.Constant(list.AsQueryable()), pred);
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
			IQueryable<T_EmployeeInjury> list = db.T_EmployeeInjurys;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                IQueryable query = db.T_EmployeeInjurys;
                Type[] exprArgTypes = { query.ElementType };
                string propToWhere = AssoNameWithParent;
                var AssoIDs = AssociationID.Split(',').ToList();
                List<ParameterExpression> paramList = new List<ParameterExpression>();
                paramList.Add(Expression.Parameter(typeof(T_EmployeeInjury), "p"));
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
                list = ((IQueryable<T_EmployeeInjury>)q);
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_EmployeeInjury>(User, list, "T_EmployeeInjury", null);
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

			if (!((CustomPrincipal)User).CanUseVerb("ImportExcel", "T_EmployeeInjury", User) || !User.CanAdd("T_EmployeeInjury"))
            {
                return RedirectToAction("Index", "Error");
            }
            //ViewBag.IsMapping = (db.ImportConfigurations.Where(p => p.Name == "T_EmployeeInjury")).Count() > 0 ? true : false;
            var lstMappings = db.ImportConfigurations.Where(p => p.Name == "T_EmployeeInjury").ToList();
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
                    var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_EmployeeInjury");
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
                        typeName = "T_EmployeeInjury";
                        //var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        //long idMapping = Convert.ToInt64(collection["ListOfMappings"]);
						string idMapping = collection["ListOfMappings"];
                        string ExistsColumnMappingName = string.Empty;
                        string mappingName = idMapping; //db.ImportConfigurations.Where(p => p.Name == typeName && p.Id == idMapping && !(string.IsNullOrEmpty(p.SheetColumn))).FirstOrDefault().MappingName;
                        var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && p.MappingName == mappingName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        if (collection["DefaultMapping"] == "on")
                        {
                            var lstMapping = db.ImportConfigurations.Where(p => p.Name == "T_EmployeeInjury" && p.IsDefaultMapping);
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
                        DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Employee Injurys";
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
                                										 case "T_EmployeeEmployeeInjuryID":
										 var t_employeeemployeeinjuryId = db.T_Employees.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeemployeeinjuryId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_TypeofClaimMCIID":
										 var t_typeofclaimmciId = db.T_ClaimTypeMCIs.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_typeofclaimmciId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_AccidentShiftID":
										 var t_accidentshiftId = db.T_ShiftTimes.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_accidentshiftId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_FacilityAccidentOccuredID":
										 var t_facilityaccidentoccuredId = db.T_AllFacilitiess.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_facilityaccidentoccuredId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_UnitWhereAccidentOccuredID":
										 var t_unitwhereaccidentoccuredId = db.T_AllFacilitiesUnits.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_unitwhereaccidentoccuredId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeInjuryFloorID":
										 var t_employeinjuryfloorId = db.T_AllFacilitiesFloors.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeinjuryfloorId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_LocationOfAccidentID":
										 var t_locationofaccidentId = db.T_WCAccidents.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_locationofaccidentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeInjuryCauseID":
										 var t_employeeinjurycauseId = db.T_InjuryCauses.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeinjurycauseId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeInjuryNatureID":
										 var t_employeeinjurynatureId = db.T_InjuryNatures.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeinjurynatureId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeInjuryBodyPartsAffectedID":
										 var t_employeeinjurybodypartsaffectedId = db.T_BodyPartsAffecteds.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeinjurybodypartsaffectedId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EMployeeInjuryMachineToolID":
										 var t_employeeinjurymachinetoolId = db.T_MachineTools.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeinjurymachinetoolId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_InitialTreatmentListID":
										 var t_initialtreatmentlistId = db.T_InitialTreatments.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_initialtreatmentlistId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeInjuryMedicalFacilityForTreatmentID":
										 var t_employeeinjurymedicalfacilityfortreatmentId = db.T_MedicalFacilityForTreatments.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeinjurymedicalfacilityfortreatmentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeInjuryRefusalID":
										 var t_employeeinjuryrefusalId = db.T_Refusals.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeinjuryrefusalId == null)
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
			string typename = "T_EmployeeInjury";
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
                DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Employee Injurys";
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
                var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_EmployeeInjury");
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
                                										 case "T_EmployeeEmployeeInjuryID":
										 var strPropertyT_EmployeeEmployeeInjury = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeEmployeeInjuryID").Value;
										 ModelReflector.Property propT_EmployeeEmployeeInjury = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeEmployeeInjury);
										 //var elementTypeT_EmployeeEmployeeInjury = db.T_Employees.ElementType;
										 //var propertyInfoT_EmployeeEmployeeInjury = elementTypeT_EmployeeEmployeeInjury.GetProperty(propT_EmployeeEmployeeInjury.Name);
										 // var t_employeeemployeeinjuryId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeEmployeeInjury.GetValue(p, null)) == assovalue);
										 var t_employeeemployeeinjuryId = db.T_Employees.Where(propT_EmployeeEmployeeInjury.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeemployeeinjuryId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_TypeofClaimMCIID":
										 var strPropertyT_TypeofClaimMCI = lstEntityProp.FirstOrDefault(p => p.Key == "T_TypeofClaimMCIID").Value;
										 ModelReflector.Property propT_TypeofClaimMCI = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ClaimTypeMCI").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_TypeofClaimMCI);
										 //var elementTypeT_TypeofClaimMCI = db.T_ClaimTypeMCIs.ElementType;
										 //var propertyInfoT_TypeofClaimMCI = elementTypeT_TypeofClaimMCI.GetProperty(propT_TypeofClaimMCI.Name);
										 // var t_typeofclaimmciId = db.T_ClaimTypeMCIs.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_TypeofClaimMCI.GetValue(p, null)) == assovalue);
										 var t_typeofclaimmciId = db.T_ClaimTypeMCIs.Where(propT_TypeofClaimMCI.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_typeofclaimmciId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_AccidentShiftID":
										 var strPropertyT_AccidentShift = lstEntityProp.FirstOrDefault(p => p.Key == "T_AccidentShiftID").Value;
										 ModelReflector.Property propT_AccidentShift = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ShiftTime").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_AccidentShift);
										 //var elementTypeT_AccidentShift = db.T_ShiftTimes.ElementType;
										 //var propertyInfoT_AccidentShift = elementTypeT_AccidentShift.GetProperty(propT_AccidentShift.Name);
										 // var t_accidentshiftId = db.T_ShiftTimes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_AccidentShift.GetValue(p, null)) == assovalue);
										 var t_accidentshiftId = db.T_ShiftTimes.Where(propT_AccidentShift.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_accidentshiftId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_FacilityAccidentOccuredID":
										 var strPropertyT_FacilityAccidentOccured = lstEntityProp.FirstOrDefault(p => p.Key == "T_FacilityAccidentOccuredID").Value;
										 ModelReflector.Property propT_FacilityAccidentOccured = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_AllFacilities").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_FacilityAccidentOccured);
										 //var elementTypeT_FacilityAccidentOccured = db.T_AllFacilitiess.ElementType;
										 //var propertyInfoT_FacilityAccidentOccured = elementTypeT_FacilityAccidentOccured.GetProperty(propT_FacilityAccidentOccured.Name);
										 // var t_facilityaccidentoccuredId = db.T_AllFacilitiess.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_FacilityAccidentOccured.GetValue(p, null)) == assovalue);
										 var t_facilityaccidentoccuredId = db.T_AllFacilitiess.Where(propT_FacilityAccidentOccured.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_facilityaccidentoccuredId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_UnitWhereAccidentOccuredID":
										 var strPropertyT_UnitWhereAccidentOccured = lstEntityProp.FirstOrDefault(p => p.Key == "T_UnitWhereAccidentOccuredID").Value;
										 ModelReflector.Property propT_UnitWhereAccidentOccured = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_AllFacilitiesUnit").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_UnitWhereAccidentOccured);
										 //var elementTypeT_UnitWhereAccidentOccured = db.T_AllFacilitiesUnits.ElementType;
										 //var propertyInfoT_UnitWhereAccidentOccured = elementTypeT_UnitWhereAccidentOccured.GetProperty(propT_UnitWhereAccidentOccured.Name);
										 // var t_unitwhereaccidentoccuredId = db.T_AllFacilitiesUnits.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_UnitWhereAccidentOccured.GetValue(p, null)) == assovalue);
										 var t_unitwhereaccidentoccuredId = db.T_AllFacilitiesUnits.Where(propT_UnitWhereAccidentOccured.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_unitwhereaccidentoccuredId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeInjuryFloorID":
										 var strPropertyT_EmployeInjuryFloor = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeInjuryFloorID").Value;
										 ModelReflector.Property propT_EmployeInjuryFloor = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_AllFacilitiesFloor").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeInjuryFloor);
										 //var elementTypeT_EmployeInjuryFloor = db.T_AllFacilitiesFloors.ElementType;
										 //var propertyInfoT_EmployeInjuryFloor = elementTypeT_EmployeInjuryFloor.GetProperty(propT_EmployeInjuryFloor.Name);
										 // var t_employeinjuryfloorId = db.T_AllFacilitiesFloors.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeInjuryFloor.GetValue(p, null)) == assovalue);
										 var t_employeinjuryfloorId = db.T_AllFacilitiesFloors.Where(propT_EmployeInjuryFloor.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeinjuryfloorId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_LocationOfAccidentID":
										 var strPropertyT_LocationOfAccident = lstEntityProp.FirstOrDefault(p => p.Key == "T_LocationOfAccidentID").Value;
										 ModelReflector.Property propT_LocationOfAccident = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_WCAccident").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_LocationOfAccident);
										 //var elementTypeT_LocationOfAccident = db.T_WCAccidents.ElementType;
										 //var propertyInfoT_LocationOfAccident = elementTypeT_LocationOfAccident.GetProperty(propT_LocationOfAccident.Name);
										 // var t_locationofaccidentId = db.T_WCAccidents.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_LocationOfAccident.GetValue(p, null)) == assovalue);
										 var t_locationofaccidentId = db.T_WCAccidents.Where(propT_LocationOfAccident.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_locationofaccidentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeInjuryCauseID":
										 var strPropertyT_EmployeeInjuryCause = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeInjuryCauseID").Value;
										 ModelReflector.Property propT_EmployeeInjuryCause = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_InjuryCause").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeInjuryCause);
										 //var elementTypeT_EmployeeInjuryCause = db.T_InjuryCauses.ElementType;
										 //var propertyInfoT_EmployeeInjuryCause = elementTypeT_EmployeeInjuryCause.GetProperty(propT_EmployeeInjuryCause.Name);
										 // var t_employeeinjurycauseId = db.T_InjuryCauses.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeInjuryCause.GetValue(p, null)) == assovalue);
										 var t_employeeinjurycauseId = db.T_InjuryCauses.Where(propT_EmployeeInjuryCause.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeinjurycauseId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeInjuryNatureID":
										 var strPropertyT_EmployeeInjuryNature = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeInjuryNatureID").Value;
										 ModelReflector.Property propT_EmployeeInjuryNature = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_InjuryNature").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeInjuryNature);
										 //var elementTypeT_EmployeeInjuryNature = db.T_InjuryNatures.ElementType;
										 //var propertyInfoT_EmployeeInjuryNature = elementTypeT_EmployeeInjuryNature.GetProperty(propT_EmployeeInjuryNature.Name);
										 // var t_employeeinjurynatureId = db.T_InjuryNatures.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeInjuryNature.GetValue(p, null)) == assovalue);
										 var t_employeeinjurynatureId = db.T_InjuryNatures.Where(propT_EmployeeInjuryNature.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeinjurynatureId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeInjuryBodyPartsAffectedID":
										 var strPropertyT_EmployeeInjuryBodyPartsAffected = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeInjuryBodyPartsAffectedID").Value;
										 ModelReflector.Property propT_EmployeeInjuryBodyPartsAffected = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_BodyPartsAffected").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeInjuryBodyPartsAffected);
										 //var elementTypeT_EmployeeInjuryBodyPartsAffected = db.T_BodyPartsAffecteds.ElementType;
										 //var propertyInfoT_EmployeeInjuryBodyPartsAffected = elementTypeT_EmployeeInjuryBodyPartsAffected.GetProperty(propT_EmployeeInjuryBodyPartsAffected.Name);
										 // var t_employeeinjurybodypartsaffectedId = db.T_BodyPartsAffecteds.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeInjuryBodyPartsAffected.GetValue(p, null)) == assovalue);
										 var t_employeeinjurybodypartsaffectedId = db.T_BodyPartsAffecteds.Where(propT_EmployeeInjuryBodyPartsAffected.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeinjurybodypartsaffectedId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EMployeeInjuryMachineToolID":
										 var strPropertyT_EMployeeInjuryMachineTool = lstEntityProp.FirstOrDefault(p => p.Key == "T_EMployeeInjuryMachineToolID").Value;
										 ModelReflector.Property propT_EMployeeInjuryMachineTool = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_MachineTool").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EMployeeInjuryMachineTool);
										 //var elementTypeT_EMployeeInjuryMachineTool = db.T_MachineTools.ElementType;
										 //var propertyInfoT_EMployeeInjuryMachineTool = elementTypeT_EMployeeInjuryMachineTool.GetProperty(propT_EMployeeInjuryMachineTool.Name);
										 // var t_employeeinjurymachinetoolId = db.T_MachineTools.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EMployeeInjuryMachineTool.GetValue(p, null)) == assovalue);
										 var t_employeeinjurymachinetoolId = db.T_MachineTools.Where(propT_EMployeeInjuryMachineTool.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeinjurymachinetoolId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_InitialTreatmentListID":
										 var strPropertyT_InitialTreatmentList = lstEntityProp.FirstOrDefault(p => p.Key == "T_InitialTreatmentListID").Value;
										 ModelReflector.Property propT_InitialTreatmentList = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_InitialTreatment").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_InitialTreatmentList);
										 //var elementTypeT_InitialTreatmentList = db.T_InitialTreatments.ElementType;
										 //var propertyInfoT_InitialTreatmentList = elementTypeT_InitialTreatmentList.GetProperty(propT_InitialTreatmentList.Name);
										 // var t_initialtreatmentlistId = db.T_InitialTreatments.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_InitialTreatmentList.GetValue(p, null)) == assovalue);
										 var t_initialtreatmentlistId = db.T_InitialTreatments.Where(propT_InitialTreatmentList.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_initialtreatmentlistId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeInjuryMedicalFacilityForTreatmentID":
										 var strPropertyT_EmployeeInjuryMedicalFacilityForTreatment = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeInjuryMedicalFacilityForTreatmentID").Value;
										 ModelReflector.Property propT_EmployeeInjuryMedicalFacilityForTreatment = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_MedicalFacilityForTreatment").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeInjuryMedicalFacilityForTreatment);
										 //var elementTypeT_EmployeeInjuryMedicalFacilityForTreatment = db.T_MedicalFacilityForTreatments.ElementType;
										 //var propertyInfoT_EmployeeInjuryMedicalFacilityForTreatment = elementTypeT_EmployeeInjuryMedicalFacilityForTreatment.GetProperty(propT_EmployeeInjuryMedicalFacilityForTreatment.Name);
										 // var t_employeeinjurymedicalfacilityfortreatmentId = db.T_MedicalFacilityForTreatments.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeInjuryMedicalFacilityForTreatment.GetValue(p, null)) == assovalue);
										 var t_employeeinjurymedicalfacilityfortreatmentId = db.T_MedicalFacilityForTreatments.Where(propT_EmployeeInjuryMedicalFacilityForTreatment.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeinjurymedicalfacilityfortreatmentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeInjuryRefusalID":
										 var strPropertyT_EmployeeInjuryRefusal = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeInjuryRefusalID").Value;
										 ModelReflector.Property propT_EmployeeInjuryRefusal = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Refusal").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeInjuryRefusal);
										 //var elementTypeT_EmployeeInjuryRefusal = db.T_Refusals.ElementType;
										 //var propertyInfoT_EmployeeInjuryRefusal = elementTypeT_EmployeeInjuryRefusal.GetProperty(propT_EmployeeInjuryRefusal.Name);
										 // var t_employeeinjuryrefusalId = db.T_Refusals.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeInjuryRefusal.GetValue(p, null)) == assovalue);
										 var t_employeeinjuryrefusalId = db.T_Refusals.Where(propT_EmployeeInjuryRefusal.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeinjuryrefusalId == null)
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
                        T_EmployeeInjury model = new T_EmployeeInjury();
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
    case "T_ClaimNo":
    model.T_ClaimNo = columnValue;
	break;
    case "T_OSHA":
    model.T_OSHA = Boolean.Parse(columnValue);
	break;
    case "T_Location":
    model.T_Location = columnValue;
	break;
    case "T_AccidentDate":
    model.T_AccidentDate = DateTime.Parse(columnValue);
	break;
    case "T_DescribeHowInjuryOrIllnessOccurred":
    model.T_DescribeHowInjuryOrIllnessOccurred = columnValue;
	break;
    case "T_PatientInvolvedRegnoepi":
    model.T_PatientInvolvedRegnoepi = columnValue;
	break;
    case "T_ExaminingPhysician":
    model.T_ExaminingPhysician = columnValue;
	break;
    case "T_ReferringPhysician":
    model.T_ReferringPhysician = columnValue;
	break;
    case "T_Diagnosis":
    model.T_Diagnosis = columnValue;
	break;
    case "T_DaysOff":
    model.T_DaysOff = Int32.Parse(columnValue);
	break;
    case "T_DaysRestricted":
    model.T_DaysRestricted = Int32.Parse(columnValue);
	break;
    case "T_DetailsOfRestriction":
    model.T_DetailsOfRestriction = columnValue;
	break;
    case "T_RestrictionStartDate":
    model.T_RestrictionStartDate = DateTime.Parse(columnValue);
	break;
    case "T_RestrictionEndDate":
    model.T_RestrictionEndDate = DateTime.Parse(columnValue);
	break;
    case "T_AccidentNotes":
    model.T_AccidentNotes = columnValue;
	break;
    case "T_RestrictionNotes":
    model.T_RestrictionNotes = columnValue;
	break;
					 case "T_EmployeeEmployeeInjuryID":
		 dynamic t_employeeemployeeinjuryId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeEmployeeInjury = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeEmployeeInjuryID").Value;
			 ModelReflector.Property propT_EmployeeEmployeeInjury = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeEmployeeInjury);
			 //var elementTypeT_EmployeeEmployeeInjury = db.T_Employees.ElementType;
			 //var propertyInfoT_EmployeeEmployeeInjury = elementTypeT_EmployeeEmployeeInjury.GetProperty(propT_EmployeeEmployeeInjury.Name);			 
			 //t_employeeemployeeinjuryId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeEmployeeInjury.GetValue(p, null)) == columnValue);
			 t_employeeemployeeinjuryId = db.T_Employees.Where(propT_EmployeeEmployeeInjury.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeemployeeinjuryId = db.T_Employees.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeemployeeinjuryId != null)
			model.T_EmployeeEmployeeInjuryID = t_employeeemployeeinjuryId.Id;
		  else
			{
				if ((collection["T_EmployeeEmployeeInjuryID"].ToString() == "true,false"))
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
						model.T_EmployeeEmployeeInjuryID = objT_Employee.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_TypeofClaimMCIID":
		 dynamic t_typeofclaimmciId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_TypeofClaimMCI = lstEntityProp.FirstOrDefault(p => p.Key == "T_TypeofClaimMCIID").Value;
			 ModelReflector.Property propT_TypeofClaimMCI = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ClaimTypeMCI").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_TypeofClaimMCI);
			 //var elementTypeT_TypeofClaimMCI = db.T_ClaimTypeMCIs.ElementType;
			 //var propertyInfoT_TypeofClaimMCI = elementTypeT_TypeofClaimMCI.GetProperty(propT_TypeofClaimMCI.Name);			 
			 //t_typeofclaimmciId = db.T_ClaimTypeMCIs.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_TypeofClaimMCI.GetValue(p, null)) == columnValue);
			 t_typeofclaimmciId = db.T_ClaimTypeMCIs.Where(propT_TypeofClaimMCI.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_typeofclaimmciId = db.T_ClaimTypeMCIs.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_typeofclaimmciId != null)
			model.T_TypeofClaimMCIID = t_typeofclaimmciId.Id;
		  else
			{
				if ((collection["T_TypeofClaimMCIID"].ToString() == "true,false"))
				{
					try
					{
						T_ClaimTypeMCI objT_ClaimTypeMCI = new T_ClaimTypeMCI();
						objT_ClaimTypeMCI.T_Name  = (columnValue);
						db.T_ClaimTypeMCIs.Add(objT_ClaimTypeMCI);
						db.SaveChanges();
						model.T_TypeofClaimMCIID = objT_ClaimTypeMCI.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_AccidentShiftID":
		 dynamic t_accidentshiftId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_AccidentShift = lstEntityProp.FirstOrDefault(p => p.Key == "T_AccidentShiftID").Value;
			 ModelReflector.Property propT_AccidentShift = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ShiftTime").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_AccidentShift);
			 //var elementTypeT_AccidentShift = db.T_ShiftTimes.ElementType;
			 //var propertyInfoT_AccidentShift = elementTypeT_AccidentShift.GetProperty(propT_AccidentShift.Name);			 
			 //t_accidentshiftId = db.T_ShiftTimes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_AccidentShift.GetValue(p, null)) == columnValue);
			 t_accidentshiftId = db.T_ShiftTimes.Where(propT_AccidentShift.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_accidentshiftId = db.T_ShiftTimes.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_accidentshiftId != null)
			model.T_AccidentShiftID = t_accidentshiftId.Id;
		  else
			{
				if ((collection["T_AccidentShiftID"].ToString() == "true,false"))
				{
					try
					{
						T_ShiftTime objT_ShiftTime = new T_ShiftTime();
						objT_ShiftTime.T_Name  = (columnValue);
						db.T_ShiftTimes.Add(objT_ShiftTime);
						db.SaveChanges();
						model.T_AccidentShiftID = objT_ShiftTime.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_FacilityAccidentOccuredID":
		 dynamic t_facilityaccidentoccuredId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_FacilityAccidentOccured = lstEntityProp.FirstOrDefault(p => p.Key == "T_FacilityAccidentOccuredID").Value;
			 ModelReflector.Property propT_FacilityAccidentOccured = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_AllFacilities").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_FacilityAccidentOccured);
			 //var elementTypeT_FacilityAccidentOccured = db.T_AllFacilitiess.ElementType;
			 //var propertyInfoT_FacilityAccidentOccured = elementTypeT_FacilityAccidentOccured.GetProperty(propT_FacilityAccidentOccured.Name);			 
			 //t_facilityaccidentoccuredId = db.T_AllFacilitiess.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_FacilityAccidentOccured.GetValue(p, null)) == columnValue);
			 t_facilityaccidentoccuredId = db.T_AllFacilitiess.Where(propT_FacilityAccidentOccured.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_facilityaccidentoccuredId = db.T_AllFacilitiess.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_facilityaccidentoccuredId != null)
			model.T_FacilityAccidentOccuredID = t_facilityaccidentoccuredId.Id;
		  else
			{
				if ((collection["T_FacilityAccidentOccuredID"].ToString() == "true,false"))
				{
					try
					{
						T_AllFacilities objT_AllFacilities = new T_AllFacilities();
						objT_AllFacilities.T_Name  = (columnValue);
						db.T_AllFacilitiess.Add(objT_AllFacilities);
						db.SaveChanges();
						model.T_FacilityAccidentOccuredID = objT_AllFacilities.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_UnitWhereAccidentOccuredID":
		 dynamic t_unitwhereaccidentoccuredId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_UnitWhereAccidentOccured = lstEntityProp.FirstOrDefault(p => p.Key == "T_UnitWhereAccidentOccuredID").Value;
			 ModelReflector.Property propT_UnitWhereAccidentOccured = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_AllFacilitiesUnit").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_UnitWhereAccidentOccured);
			 //var elementTypeT_UnitWhereAccidentOccured = db.T_AllFacilitiesUnits.ElementType;
			 //var propertyInfoT_UnitWhereAccidentOccured = elementTypeT_UnitWhereAccidentOccured.GetProperty(propT_UnitWhereAccidentOccured.Name);			 
			 //t_unitwhereaccidentoccuredId = db.T_AllFacilitiesUnits.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_UnitWhereAccidentOccured.GetValue(p, null)) == columnValue);
			 t_unitwhereaccidentoccuredId = db.T_AllFacilitiesUnits.Where(propT_UnitWhereAccidentOccured.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_unitwhereaccidentoccuredId = db.T_AllFacilitiesUnits.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_unitwhereaccidentoccuredId != null)
			model.T_UnitWhereAccidentOccuredID = t_unitwhereaccidentoccuredId.Id;
		  else
			{
				if ((collection["T_UnitWhereAccidentOccuredID"].ToString() == "true,false"))
				{
					try
					{
						T_AllFacilitiesUnit objT_AllFacilitiesUnit = new T_AllFacilitiesUnit();
						objT_AllFacilitiesUnit.T_Name  = (columnValue);
						db.T_AllFacilitiesUnits.Add(objT_AllFacilitiesUnit);
						db.SaveChanges();
						model.T_UnitWhereAccidentOccuredID = objT_AllFacilitiesUnit.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeInjuryFloorID":
		 dynamic t_employeinjuryfloorId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeInjuryFloor = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeInjuryFloorID").Value;
			 ModelReflector.Property propT_EmployeInjuryFloor = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_AllFacilitiesFloor").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeInjuryFloor);
			 //var elementTypeT_EmployeInjuryFloor = db.T_AllFacilitiesFloors.ElementType;
			 //var propertyInfoT_EmployeInjuryFloor = elementTypeT_EmployeInjuryFloor.GetProperty(propT_EmployeInjuryFloor.Name);			 
			 //t_employeinjuryfloorId = db.T_AllFacilitiesFloors.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeInjuryFloor.GetValue(p, null)) == columnValue);
			 t_employeinjuryfloorId = db.T_AllFacilitiesFloors.Where(propT_EmployeInjuryFloor.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeinjuryfloorId = db.T_AllFacilitiesFloors.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeinjuryfloorId != null)
			model.T_EmployeInjuryFloorID = t_employeinjuryfloorId.Id;
		  else
			{
				if ((collection["T_EmployeInjuryFloorID"].ToString() == "true,false"))
				{
					try
					{
						T_AllFacilitiesFloor objT_AllFacilitiesFloor = new T_AllFacilitiesFloor();
						objT_AllFacilitiesFloor.T_Name  = (columnValue);
						db.T_AllFacilitiesFloors.Add(objT_AllFacilitiesFloor);
						db.SaveChanges();
						model.T_EmployeInjuryFloorID = objT_AllFacilitiesFloor.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_LocationOfAccidentID":
		 dynamic t_locationofaccidentId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_LocationOfAccident = lstEntityProp.FirstOrDefault(p => p.Key == "T_LocationOfAccidentID").Value;
			 ModelReflector.Property propT_LocationOfAccident = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_WCAccident").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_LocationOfAccident);
			 //var elementTypeT_LocationOfAccident = db.T_WCAccidents.ElementType;
			 //var propertyInfoT_LocationOfAccident = elementTypeT_LocationOfAccident.GetProperty(propT_LocationOfAccident.Name);			 
			 //t_locationofaccidentId = db.T_WCAccidents.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_LocationOfAccident.GetValue(p, null)) == columnValue);
			 t_locationofaccidentId = db.T_WCAccidents.Where(propT_LocationOfAccident.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_locationofaccidentId = db.T_WCAccidents.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_locationofaccidentId != null)
			model.T_LocationOfAccidentID = t_locationofaccidentId.Id;
		  else
			{
				if ((collection["T_LocationOfAccidentID"].ToString() == "true,false"))
				{
					try
					{
						T_WCAccident objT_WCAccident = new T_WCAccident();
						objT_WCAccident.T_Name  = (columnValue);
						db.T_WCAccidents.Add(objT_WCAccident);
						db.SaveChanges();
						model.T_LocationOfAccidentID = objT_WCAccident.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeInjuryCauseID":
		 dynamic t_employeeinjurycauseId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeInjuryCause = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeInjuryCauseID").Value;
			 ModelReflector.Property propT_EmployeeInjuryCause = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_InjuryCause").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeInjuryCause);
			 //var elementTypeT_EmployeeInjuryCause = db.T_InjuryCauses.ElementType;
			 //var propertyInfoT_EmployeeInjuryCause = elementTypeT_EmployeeInjuryCause.GetProperty(propT_EmployeeInjuryCause.Name);			 
			 //t_employeeinjurycauseId = db.T_InjuryCauses.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeInjuryCause.GetValue(p, null)) == columnValue);
			 t_employeeinjurycauseId = db.T_InjuryCauses.Where(propT_EmployeeInjuryCause.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeinjurycauseId = db.T_InjuryCauses.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeinjurycauseId != null)
			model.T_EmployeeInjuryCauseID = t_employeeinjurycauseId.Id;
		  else
			{
				if ((collection["T_EmployeeInjuryCauseID"].ToString() == "true,false"))
				{
					try
					{
						T_InjuryCause objT_InjuryCause = new T_InjuryCause();
						objT_InjuryCause.T_Name  = (columnValue);
						db.T_InjuryCauses.Add(objT_InjuryCause);
						db.SaveChanges();
						model.T_EmployeeInjuryCauseID = objT_InjuryCause.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeInjuryNatureID":
		 dynamic t_employeeinjurynatureId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeInjuryNature = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeInjuryNatureID").Value;
			 ModelReflector.Property propT_EmployeeInjuryNature = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_InjuryNature").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeInjuryNature);
			 //var elementTypeT_EmployeeInjuryNature = db.T_InjuryNatures.ElementType;
			 //var propertyInfoT_EmployeeInjuryNature = elementTypeT_EmployeeInjuryNature.GetProperty(propT_EmployeeInjuryNature.Name);			 
			 //t_employeeinjurynatureId = db.T_InjuryNatures.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeInjuryNature.GetValue(p, null)) == columnValue);
			 t_employeeinjurynatureId = db.T_InjuryNatures.Where(propT_EmployeeInjuryNature.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeinjurynatureId = db.T_InjuryNatures.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeinjurynatureId != null)
			model.T_EmployeeInjuryNatureID = t_employeeinjurynatureId.Id;
		  else
			{
				if ((collection["T_EmployeeInjuryNatureID"].ToString() == "true,false"))
				{
					try
					{
						T_InjuryNature objT_InjuryNature = new T_InjuryNature();
						objT_InjuryNature.T_Name  = (columnValue);
						db.T_InjuryNatures.Add(objT_InjuryNature);
						db.SaveChanges();
						model.T_EmployeeInjuryNatureID = objT_InjuryNature.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeInjuryBodyPartsAffectedID":
		 dynamic t_employeeinjurybodypartsaffectedId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeInjuryBodyPartsAffected = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeInjuryBodyPartsAffectedID").Value;
			 ModelReflector.Property propT_EmployeeInjuryBodyPartsAffected = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_BodyPartsAffected").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeInjuryBodyPartsAffected);
			 //var elementTypeT_EmployeeInjuryBodyPartsAffected = db.T_BodyPartsAffecteds.ElementType;
			 //var propertyInfoT_EmployeeInjuryBodyPartsAffected = elementTypeT_EmployeeInjuryBodyPartsAffected.GetProperty(propT_EmployeeInjuryBodyPartsAffected.Name);			 
			 //t_employeeinjurybodypartsaffectedId = db.T_BodyPartsAffecteds.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeInjuryBodyPartsAffected.GetValue(p, null)) == columnValue);
			 t_employeeinjurybodypartsaffectedId = db.T_BodyPartsAffecteds.Where(propT_EmployeeInjuryBodyPartsAffected.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeinjurybodypartsaffectedId = db.T_BodyPartsAffecteds.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeinjurybodypartsaffectedId != null)
			model.T_EmployeeInjuryBodyPartsAffectedID = t_employeeinjurybodypartsaffectedId.Id;
		  else
			{
				if ((collection["T_EmployeeInjuryBodyPartsAffectedID"].ToString() == "true,false"))
				{
					try
					{
						T_BodyPartsAffected objT_BodyPartsAffected = new T_BodyPartsAffected();
						objT_BodyPartsAffected.T_Name  = (columnValue);
						db.T_BodyPartsAffecteds.Add(objT_BodyPartsAffected);
						db.SaveChanges();
						model.T_EmployeeInjuryBodyPartsAffectedID = objT_BodyPartsAffected.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EMployeeInjuryMachineToolID":
		 dynamic t_employeeinjurymachinetoolId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EMployeeInjuryMachineTool = lstEntityProp.FirstOrDefault(p => p.Key == "T_EMployeeInjuryMachineToolID").Value;
			 ModelReflector.Property propT_EMployeeInjuryMachineTool = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_MachineTool").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EMployeeInjuryMachineTool);
			 //var elementTypeT_EMployeeInjuryMachineTool = db.T_MachineTools.ElementType;
			 //var propertyInfoT_EMployeeInjuryMachineTool = elementTypeT_EMployeeInjuryMachineTool.GetProperty(propT_EMployeeInjuryMachineTool.Name);			 
			 //t_employeeinjurymachinetoolId = db.T_MachineTools.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EMployeeInjuryMachineTool.GetValue(p, null)) == columnValue);
			 t_employeeinjurymachinetoolId = db.T_MachineTools.Where(propT_EMployeeInjuryMachineTool.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeinjurymachinetoolId = db.T_MachineTools.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeinjurymachinetoolId != null)
			model.T_EMployeeInjuryMachineToolID = t_employeeinjurymachinetoolId.Id;
		  else
			{
				if ((collection["T_EMployeeInjuryMachineToolID"].ToString() == "true,false"))
				{
					try
					{
						T_MachineTool objT_MachineTool = new T_MachineTool();
						objT_MachineTool.T_Name  = (columnValue);
						db.T_MachineTools.Add(objT_MachineTool);
						db.SaveChanges();
						model.T_EMployeeInjuryMachineToolID = objT_MachineTool.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_InitialTreatmentListID":
		 dynamic t_initialtreatmentlistId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_InitialTreatmentList = lstEntityProp.FirstOrDefault(p => p.Key == "T_InitialTreatmentListID").Value;
			 ModelReflector.Property propT_InitialTreatmentList = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_InitialTreatment").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_InitialTreatmentList);
			 //var elementTypeT_InitialTreatmentList = db.T_InitialTreatments.ElementType;
			 //var propertyInfoT_InitialTreatmentList = elementTypeT_InitialTreatmentList.GetProperty(propT_InitialTreatmentList.Name);			 
			 //t_initialtreatmentlistId = db.T_InitialTreatments.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_InitialTreatmentList.GetValue(p, null)) == columnValue);
			 t_initialtreatmentlistId = db.T_InitialTreatments.Where(propT_InitialTreatmentList.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_initialtreatmentlistId = db.T_InitialTreatments.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_initialtreatmentlistId != null)
			model.T_InitialTreatmentListID = t_initialtreatmentlistId.Id;
		  else
			{
				if ((collection["T_InitialTreatmentListID"].ToString() == "true,false"))
				{
					try
					{
						T_InitialTreatment objT_InitialTreatment = new T_InitialTreatment();
						objT_InitialTreatment.T_Name  = (columnValue);
						db.T_InitialTreatments.Add(objT_InitialTreatment);
						db.SaveChanges();
						model.T_InitialTreatmentListID = objT_InitialTreatment.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeInjuryMedicalFacilityForTreatmentID":
		 dynamic t_employeeinjurymedicalfacilityfortreatmentId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeInjuryMedicalFacilityForTreatment = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeInjuryMedicalFacilityForTreatmentID").Value;
			 ModelReflector.Property propT_EmployeeInjuryMedicalFacilityForTreatment = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_MedicalFacilityForTreatment").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeInjuryMedicalFacilityForTreatment);
			 //var elementTypeT_EmployeeInjuryMedicalFacilityForTreatment = db.T_MedicalFacilityForTreatments.ElementType;
			 //var propertyInfoT_EmployeeInjuryMedicalFacilityForTreatment = elementTypeT_EmployeeInjuryMedicalFacilityForTreatment.GetProperty(propT_EmployeeInjuryMedicalFacilityForTreatment.Name);			 
			 //t_employeeinjurymedicalfacilityfortreatmentId = db.T_MedicalFacilityForTreatments.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeInjuryMedicalFacilityForTreatment.GetValue(p, null)) == columnValue);
			 t_employeeinjurymedicalfacilityfortreatmentId = db.T_MedicalFacilityForTreatments.Where(propT_EmployeeInjuryMedicalFacilityForTreatment.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeinjurymedicalfacilityfortreatmentId = db.T_MedicalFacilityForTreatments.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeinjurymedicalfacilityfortreatmentId != null)
			model.T_EmployeeInjuryMedicalFacilityForTreatmentID = t_employeeinjurymedicalfacilityfortreatmentId.Id;
		  else
			{
				if ((collection["T_EmployeeInjuryMedicalFacilityForTreatmentID"].ToString() == "true,false"))
				{
					try
					{
						T_MedicalFacilityForTreatment objT_MedicalFacilityForTreatment = new T_MedicalFacilityForTreatment();
						objT_MedicalFacilityForTreatment.T_Name  = (columnValue);
						db.T_MedicalFacilityForTreatments.Add(objT_MedicalFacilityForTreatment);
						db.SaveChanges();
						model.T_EmployeeInjuryMedicalFacilityForTreatmentID = objT_MedicalFacilityForTreatment.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeInjuryRefusalID":
		 dynamic t_employeeinjuryrefusalId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeInjuryRefusal = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeInjuryRefusalID").Value;
			 ModelReflector.Property propT_EmployeeInjuryRefusal = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Refusal").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeInjuryRefusal);
			 //var elementTypeT_EmployeeInjuryRefusal = db.T_Refusals.ElementType;
			 //var propertyInfoT_EmployeeInjuryRefusal = elementTypeT_EmployeeInjuryRefusal.GetProperty(propT_EmployeeInjuryRefusal.Name);			 
			 //t_employeeinjuryrefusalId = db.T_Refusals.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeInjuryRefusal.GetValue(p, null)) == columnValue);
			 t_employeeinjuryrefusalId = db.T_Refusals.Where(propT_EmployeeInjuryRefusal.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeinjuryrefusalId = db.T_Refusals.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeinjuryrefusalId != null)
			model.T_EmployeeInjuryRefusalID = t_employeeinjuryrefusalId.Id;
		  else
			{
				if ((collection["T_EmployeeInjuryRefusalID"].ToString() == "true,false"))
				{
					try
					{
						T_Refusal objT_Refusal = new T_Refusal();
						objT_Refusal.T_Name  = (columnValue);
						db.T_Refusals.Add(objT_Refusal);
						db.SaveChanges();
						model.T_EmployeeInjuryRefusalID = objT_Refusal.Id;
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
			 if (model.T_AccidentDate == DateTime.MinValue)
                            model.T_AccidentDate =  DateTime.UtcNow;
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
									db.T_EmployeeInjurys.Add(model);
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
		public bool ValidateModel(T_EmployeeInjury validate)
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
                var obj1 = db1.T_EmployeeInjurys.Find(Id);
                System.Reflection.PropertyInfo[] properties = (obj1.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
                var Property = properties.FirstOrDefault(p => p.Name == PropName);
                object PropValue = Property.GetValue(obj1, null);
                return PropValue;
				            }
            catch { return null; }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetReadOnlyProperties(T_EmployeeInjury OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_EmployeeInjury").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.ReadOnlyPropertiesRule(OModel, BR, "T_EmployeeInjury");
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
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeInjury");
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
        public JsonResult GetMandatoryProperties(T_EmployeeInjury OModel, string ruleType)
        {
            Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_EmployeeInjury").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
                    if (ruleType == "OnCreate")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 2).ToList();
                    else if (ruleType == "OnEdit")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 1).ToList();
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_EmployeeInjury");
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
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeInjury");
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
        public JsonResult GetUIAlertBusinessRules(T_EmployeeInjury OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_EmployeeInjury").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.UIAlertRule(OModel, BR, "T_EmployeeInjury");
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
        public JsonResult GetValidateBeforeSaveProperties(T_EmployeeInjury OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_EmployeeInjury").ToList();
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
                    var ResultOfBusinessRules = db.ValidateBeforeSavePropertiesRule(OModel, BR, "T_EmployeeInjury",state);
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
                                    var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeInjury");
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
        public JsonResult GetLockBusinessRules(T_EmployeeInjury OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            //string RulesApplied = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_EmployeeInjury").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.LockEntityRule(OModel, BR, "T_EmployeeInjury");
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
		private List<string> CheckMandatoryProperties(T_EmployeeInjury OModel)
        {
            List<string> result = new List<string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_EmployeeInjury").ToList();
                Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
                if (BR != null && BR.Count > 0)
                {
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_EmployeeInjury");
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
                                var dispName = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeInjury").Properties.FirstOrDefault(p => p.Name == paramName).DisplayName;
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
            var _Obj = db1.T_EmployeeInjurys.FirstOrDefault(p => p.DisplayValue == displayvalue);
            long outValue;
            if (_Obj != null)
                return Int64.TryParse(_Obj.Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				public long? GetIdFromPropertyValue(string PropName, string PropValue)
        {
            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            IQueryable query = db1.T_EmployeeInjurys;
            Type[] exprArgTypes = { query.ElementType };
            string propToWhere = PropName;
            ParameterExpression p = Expression.Parameter(typeof(T_EmployeeInjury), "p");
            MemberExpression member = Expression.PropertyOrField(p, propToWhere);
            LambdaExpression lambda = null;
            if (PropValue.ToLower().Trim() != "null")
            lambda = Expression.Lambda<Func<T_EmployeeInjury, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(PropValue), member.Type)), p);
            else
                lambda = Expression.Lambda<Func<T_EmployeeInjury, bool>>(Expression.Equal(member, Expression.Constant(null, member.Type)), p);
            MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
            IQueryable q = query.Provider.CreateQuery(methodCall);
            long outValue;
            var list1 = ((IQueryable<T_EmployeeInjury>)q);
            if (list1 != null && list1.Count() > 0)
                return Int64.TryParse(list1.FirstOrDefault().Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPropertyValueByEntityId(long Id, string PropName)
        {
								ApplicationContext db1 = new ApplicationContext(new SystemUser());
            var obj1 = db1.T_EmployeeInjurys.Find(Id);
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
        public JsonResult Check1MThresholdValue(T_EmployeeInjury t_employeeinjury)
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
            string[][] groupsarr = new string[][] { new string[] {"48915","T_EmployeeInjury48915"},new string[] {"48903","T_EmployeeInjury48903"},new string[] {"48929","T_EmployeeInjury48929"},new string[] {"48918","Basic Information"},new string[] {"48919","Accident Details"},new string[] {"48920","Restriction"},new string[] {"48921","Notes"} };
            return groupsarr;
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCalculationValues(T_EmployeeInjury t_employeeinjury)
        {
            t_employeeinjury.setCalculation();
            Dictionary<string, string> Calculations = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_employeeinjury.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            return Json(Calculations, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		//get Templates 
		// select templates 
        public void GetTemplatesForList(string defaultview)
        {
            string pageNameList = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_EmployeeInjury"
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
                                       where s.EntityName == "T_EmployeeInjury"
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
                                       where s.EntityName == "T_EmployeeInjury"
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
                                       where s.EntityName == "T_EmployeeInjury"
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
                                       where s.EntityName == "T_EmployeeInjury"
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
                                       where s.EntityName == "T_EmployeeInjury"
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
                                       where s.EntityName == "T_EmployeeInjury"
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
                                       where s.EntityName == "T_EmployeeInjury"
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
                                       where s.EntityName == "T_EmployeeInjury"
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
        public ActionResult GetDerivedDetails(T_EmployeeInjury t_employeeinjury, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_employeeinjury.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            return Json(derivedlist, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDerivedDetailsInline(string host, string value, T_EmployeeInjury t_employeeinjury, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
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

