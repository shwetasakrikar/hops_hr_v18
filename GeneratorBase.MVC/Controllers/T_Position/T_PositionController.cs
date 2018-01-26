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
		private void LoadViewDataForCount(T_Position t_position, string AssocType)
        {
        }
		private void LoadViewDataAfterOnEdit(T_Position t_position)
        {		
			 ViewBag.T_FacilityAssignedToID = new SelectList(db.T_Facilitys, "ID", "DisplayValue", t_position.T_FacilityAssignedToID);
			 ViewBag.T_TypeOfPositionID = new SelectList(db.T_PositionTypes, "ID", "DisplayValue", t_position.T_TypeOfPositionID);
			 ViewBag.T_AssociatedPositionStatusID = new SelectList(db.T_Positionstatuss, "ID", "DisplayValue", t_position.T_AssociatedPositionStatusID);
			 ViewBag.T_PositionIdentifierID = new SelectList(db.T_PositionLevels, "ID", "DisplayValue", t_position.T_PositionIdentifierID);
			 ViewBag.T_PositionWorkingTitleAssociationID = new SelectList(db.T_WorkingTitles, "ID", "DisplayValue", t_position.T_PositionWorkingTitleAssociationID);
			 ViewBag.T_PositionRoleCodeID = new SelectList(db.T_RoleCodes, "ID", "DisplayValue", t_position.T_PositionRoleCodeID);
			 ViewBag.T_PositionSOCCodeID = new SelectList(db.T_SocCodes, "ID", "DisplayValue", t_position.T_PositionSOCCodeID);
			 ViewBag.T_PositionClassCodeID = new SelectList(db.T_ClassCodes, "ID", "DisplayValue", t_position.T_PositionClassCodeID);
			 ViewBag.T_WorkersCompCodePositionID = new SelectList(db.T_WCCodes, "ID", "DisplayValue", t_position.T_WorkersCompCodePositionID);
			 ViewBag.T_PositionCostCenterAssociationID = new SelectList(db.T_CostCenters, "ID", "DisplayValue", t_position.T_PositionCostCenterAssociationID);
			 ViewBag.T_PositionShiftMealTimeID = new SelectList(db.T_ShiftMealTimes, "ID", "DisplayValue", t_position.T_PositionShiftMealTimeID);
			 ViewBag.T_PositionShiftTimeID = new SelectList(db.T_ShiftTimes, "ID", "DisplayValue", t_position.T_PositionShiftTimeID);
			 ViewBag.T_PositionShiftDurationID = new SelectList(db.T_ShiftDurations, "ID", "DisplayValue", t_position.T_PositionShiftDurationID);
			 ViewBag.T_PositionOvertimeEligibilityID = new SelectList(db.T_OvertimeEligibilitys, "ID", "DisplayValue", t_position.T_PositionOvertimeEligibilityID);
			 ViewBag.T_PositionStatusforPostingID = new SelectList(db.T_PositionPostStatuss, "ID", "DisplayValue", t_position.T_PositionStatusforPostingID);
			CustomLoadViewDataListAfterEdit(t_position);
        }
        private void LoadViewDataBeforeOnEdit(T_Position t_position)
        {		
               var _objT_FacilityAssignedTo = new List<T_Facility>();
               _objT_FacilityAssignedTo.Add(t_position.t_facilityassignedto);
			   			   ViewBag.T_FacilityAssignedToID = new SelectList(_objT_FacilityAssignedTo, "ID", "DisplayValue", t_position.T_FacilityAssignedToID);
			               var _objT_TypeOfPosition = new List<T_PositionType>();
               _objT_TypeOfPosition.Add(t_position.t_typeofposition);
			   			   ViewBag.T_TypeOfPositionID = new SelectList(_objT_TypeOfPosition, "ID", "DisplayValue", t_position.T_TypeOfPositionID);
			               var _objT_AssociatedPositionStatus = new List<T_Positionstatus>();
               _objT_AssociatedPositionStatus.Add(t_position.t_associatedpositionstatus);
			   			   ViewBag.T_AssociatedPositionStatusID = new SelectList(_objT_AssociatedPositionStatus, "ID", "DisplayValue", t_position.T_AssociatedPositionStatusID);
			               var _objT_PositionIdentifier = new List<T_PositionLevel>();
               _objT_PositionIdentifier.Add(t_position.t_positionidentifier);
			   			   ViewBag.T_PositionIdentifierID = new SelectList(_objT_PositionIdentifier, "ID", "DisplayValue", t_position.T_PositionIdentifierID);
			               var _objT_PositionWorkingTitleAssociation = new List<T_WorkingTitle>();
               _objT_PositionWorkingTitleAssociation.Add(t_position.t_positionworkingtitleassociation);
			   			   ViewBag.T_PositionWorkingTitleAssociationID = new SelectList(_objT_PositionWorkingTitleAssociation, "ID", "DisplayValue", t_position.T_PositionWorkingTitleAssociationID);
			               var _objT_PositionRoleCode = new List<T_RoleCode>();
               _objT_PositionRoleCode.Add(t_position.t_positionrolecode);
			   			   ViewBag.T_PositionRoleCodeID = new SelectList(_objT_PositionRoleCode, "ID", "DisplayValue", t_position.T_PositionRoleCodeID);
			               var _objT_PositionSOCCode = new List<T_SocCode>();
               _objT_PositionSOCCode.Add(t_position.t_positionsoccode);
			   			   ViewBag.T_PositionSOCCodeID = new SelectList(_objT_PositionSOCCode, "ID", "DisplayValue", t_position.T_PositionSOCCodeID);
			               var _objT_PositionClassCode = new List<T_ClassCode>();
               _objT_PositionClassCode.Add(t_position.t_positionclasscode);
			   			   ViewBag.T_PositionClassCodeID = new SelectList(_objT_PositionClassCode, "ID", "DisplayValue", t_position.T_PositionClassCodeID);
			               var _objT_WorkersCompCodePosition = new List<T_WCCode>();
               _objT_WorkersCompCodePosition.Add(t_position.t_workerscompcodeposition);
			   			   ViewBag.T_WorkersCompCodePositionID = new SelectList(_objT_WorkersCompCodePosition, "ID", "DisplayValue", t_position.T_WorkersCompCodePositionID);
			               var _objT_PositionCostCenterAssociation = new List<T_CostCenter>();
               _objT_PositionCostCenterAssociation.Add(t_position.t_positioncostcenterassociation);
			   			   ViewBag.T_PositionCostCenterAssociationID = new SelectList(_objT_PositionCostCenterAssociation, "ID", "DisplayValue", t_position.T_PositionCostCenterAssociationID);
			               var _objT_PositionShiftMealTime = new List<T_ShiftMealTime>();
               _objT_PositionShiftMealTime.Add(t_position.t_positionshiftmealtime);
			   			   ViewBag.T_PositionShiftMealTimeID = new SelectList(_objT_PositionShiftMealTime, "ID", "DisplayValue", t_position.T_PositionShiftMealTimeID);
			               var _objT_PositionShiftTime = new List<T_ShiftTime>();
               _objT_PositionShiftTime.Add(t_position.t_positionshifttime);
			   			   ViewBag.T_PositionShiftTimeID = new SelectList(_objT_PositionShiftTime, "ID", "DisplayValue", t_position.T_PositionShiftTimeID);
			               var _objT_PositionShiftDuration = new List<T_ShiftDuration>();
               _objT_PositionShiftDuration.Add(t_position.t_positionshiftduration);
			   			   ViewBag.T_PositionShiftDurationID = new SelectList(_objT_PositionShiftDuration, "ID", "DisplayValue", t_position.T_PositionShiftDurationID);
			               var _objT_PositionOvertimeEligibility = new List<T_OvertimeEligibility>();
               _objT_PositionOvertimeEligibility.Add(t_position.t_positionovertimeeligibility);
			   			   ViewBag.T_PositionOvertimeEligibilityID = new SelectList(_objT_PositionOvertimeEligibility, "ID", "DisplayValue", t_position.T_PositionOvertimeEligibilityID);
			               var _objT_PositionStatusforPosting = new List<T_PositionPostStatus>();
               _objT_PositionStatusforPosting.Add(t_position.t_positionstatusforposting);
			   			   ViewBag.T_PositionStatusforPostingID = new SelectList(_objT_PositionStatusforPosting, "ID", "DisplayValue", t_position.T_PositionStatusforPostingID);
				 ViewBag.T_PositionJobAssignmentCount = t_position.t_positionjobassignment.Count();
		CustomLoadViewDataListBeforeEdit(t_position);
        }
        private void LoadViewDataAfterOnCreate(T_Position t_position)
        {			
			 ViewBag.T_FacilityAssignedToID = new SelectList(db.T_Facilitys, "ID", "DisplayValue", t_position.T_FacilityAssignedToID);
			 ViewBag.T_TypeOfPositionID = new SelectList(db.T_PositionTypes, "ID", "DisplayValue", t_position.T_TypeOfPositionID);
			 ViewBag.T_AssociatedPositionStatusID = new SelectList(db.T_Positionstatuss, "ID", "DisplayValue", t_position.T_AssociatedPositionStatusID);
			 ViewBag.T_PositionIdentifierID = new SelectList(db.T_PositionLevels, "ID", "DisplayValue", t_position.T_PositionIdentifierID);
			 ViewBag.T_PositionWorkingTitleAssociationID = new SelectList(db.T_WorkingTitles, "ID", "DisplayValue", t_position.T_PositionWorkingTitleAssociationID);
			 ViewBag.T_PositionRoleCodeID = new SelectList(db.T_RoleCodes, "ID", "DisplayValue", t_position.T_PositionRoleCodeID);
			 ViewBag.T_PositionSOCCodeID = new SelectList(db.T_SocCodes, "ID", "DisplayValue", t_position.T_PositionSOCCodeID);
			 ViewBag.T_PositionClassCodeID = new SelectList(db.T_ClassCodes, "ID", "DisplayValue", t_position.T_PositionClassCodeID);
			 ViewBag.T_WorkersCompCodePositionID = new SelectList(db.T_WCCodes, "ID", "DisplayValue", t_position.T_WorkersCompCodePositionID);
			 ViewBag.T_PositionCostCenterAssociationID = new SelectList(db.T_CostCenters, "ID", "DisplayValue", t_position.T_PositionCostCenterAssociationID);
			 ViewBag.T_PositionShiftMealTimeID = new SelectList(db.T_ShiftMealTimes, "ID", "DisplayValue", t_position.T_PositionShiftMealTimeID);
			 ViewBag.T_PositionShiftTimeID = new SelectList(db.T_ShiftTimes, "ID", "DisplayValue", t_position.T_PositionShiftTimeID);
			 ViewBag.T_PositionShiftDurationID = new SelectList(db.T_ShiftDurations, "ID", "DisplayValue", t_position.T_PositionShiftDurationID);
			 ViewBag.T_PositionOvertimeEligibilityID = new SelectList(db.T_OvertimeEligibilitys, "ID", "DisplayValue", t_position.T_PositionOvertimeEligibilityID);
			 ViewBag.T_PositionStatusforPostingID = new SelectList(db.T_PositionPostStatuss, "ID", "DisplayValue", t_position.T_PositionStatusforPostingID);
		CustomLoadViewDataListAfterOnCreate(t_position);
        }
        private void LoadViewDataBeforeOnCreate(string HostingEntityName, string HostingEntityID, string AssociatedType)
        {			
			if(HostingEntityName == "T_Facility" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_FacilityAssignedTo")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_FacilityAssignedToID = new SelectList(db.T_Facilitys.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Facilitys.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_FacilityAssignedTo = new List<T_Facility>();
			 ViewBag.T_FacilityAssignedToID = new SelectList(objT_FacilityAssignedTo , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_PositionType" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_TypeOfPosition")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_TypeOfPositionID = new SelectList(db.T_PositionTypes.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_PositionTypes.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_TypeOfPosition = new List<T_PositionType>();
			 ViewBag.T_TypeOfPositionID = new SelectList(objT_TypeOfPosition , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Positionstatus" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_AssociatedPositionStatus")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_AssociatedPositionStatusID = new SelectList(db.T_Positionstatuss.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Positionstatuss.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_AssociatedPositionStatus = new List<T_Positionstatus>();
			 ViewBag.T_AssociatedPositionStatusID = new SelectList(objT_AssociatedPositionStatus , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_PositionLevel" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionIdentifier")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionIdentifierID = new SelectList(db.T_PositionLevels.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_PositionLevels.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionIdentifier = new List<T_PositionLevel>();
			 ViewBag.T_PositionIdentifierID = new SelectList(objT_PositionIdentifier , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_WorkingTitle" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionWorkingTitleAssociation")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionWorkingTitleAssociationID = new SelectList(db.T_WorkingTitles.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_WorkingTitles.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionWorkingTitleAssociation = new List<T_WorkingTitle>();
			 ViewBag.T_PositionWorkingTitleAssociationID = new SelectList(objT_PositionWorkingTitleAssociation , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_RoleCode" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionRoleCode")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionRoleCodeID = new SelectList(db.T_RoleCodes.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_RoleCodes.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionRoleCode = new List<T_RoleCode>();
			 ViewBag.T_PositionRoleCodeID = new SelectList(objT_PositionRoleCode , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_SocCode" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionSOCCode")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionSOCCodeID = new SelectList(db.T_SocCodes.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_SocCodes.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionSOCCode = new List<T_SocCode>();
			 ViewBag.T_PositionSOCCodeID = new SelectList(objT_PositionSOCCode , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_ClassCode" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionClassCode")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionClassCodeID = new SelectList(db.T_ClassCodes.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_ClassCodes.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionClassCode = new List<T_ClassCode>();
			 ViewBag.T_PositionClassCodeID = new SelectList(objT_PositionClassCode , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_WCCode" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_WorkersCompCodePosition")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_WorkersCompCodePositionID = new SelectList(db.T_WCCodes.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_WCCodes.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_WorkersCompCodePosition = new List<T_WCCode>();
			 ViewBag.T_WorkersCompCodePositionID = new SelectList(objT_WorkersCompCodePosition , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_CostCenter" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionCostCenterAssociation")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionCostCenterAssociationID = new SelectList(db.T_CostCenters.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_CostCenters.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionCostCenterAssociation = new List<T_CostCenter>();
			 ViewBag.T_PositionCostCenterAssociationID = new SelectList(objT_PositionCostCenterAssociation , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_ShiftMealTime" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionShiftMealTime")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionShiftMealTimeID = new SelectList(db.T_ShiftMealTimes.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_ShiftMealTimes.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionShiftMealTime = new List<T_ShiftMealTime>();
			 ViewBag.T_PositionShiftMealTimeID = new SelectList(objT_PositionShiftMealTime , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_ShiftTime" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionShiftTime")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionShiftTimeID = new SelectList(db.T_ShiftTimes.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_ShiftTimes.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionShiftTime = new List<T_ShiftTime>();
			 ViewBag.T_PositionShiftTimeID = new SelectList(objT_PositionShiftTime , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_ShiftDuration" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionShiftDuration")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionShiftDurationID = new SelectList(db.T_ShiftDurations.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_ShiftDurations.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionShiftDuration = new List<T_ShiftDuration>();
			 ViewBag.T_PositionShiftDurationID = new SelectList(objT_PositionShiftDuration , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_OvertimeEligibility" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionOvertimeEligibility")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionOvertimeEligibilityID = new SelectList(db.T_OvertimeEligibilitys.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_OvertimeEligibilitys.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionOvertimeEligibility = new List<T_OvertimeEligibility>();
			 ViewBag.T_PositionOvertimeEligibilityID = new SelectList(objT_PositionOvertimeEligibility , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_PositionPostStatus" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PositionStatusforPosting")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PositionStatusforPostingID = new SelectList(db.T_PositionPostStatuss.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_PositionPostStatuss.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PositionStatusforPosting = new List<T_PositionPostStatus>();
			 ViewBag.T_PositionStatusforPostingID = new SelectList(objT_PositionStatusforPosting , "ID", "DisplayValue");
		    }
			CustomLoadViewDataListBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
        }
		private IQueryable<T_Position> searchRecords(IQueryable<T_Position> lstT_Position, string searchString, bool? IsDeepSearch)
        {
		   searchString = searchString.Trim();
		if(Convert.ToBoolean(IsDeepSearch))
            lstT_Position = lstT_Position.Where(s => (s.t_facilityassignedto!= null && (s.t_facilityassignedto.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_PositionNumber) && s.T_PositionNumber.ToUpper().Contains(searchString)) ||(s.t_typeofposition!= null && (s.t_typeofposition.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_associatedpositionstatus!= null && (s.t_associatedpositionstatus.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_positionidentifier!= null && (s.t_positionidentifier.DisplayValue.ToUpper().Contains(searchString) )) ||(s.T_PositionFill != null && SqlFunctions.StringConvert((double)s.T_PositionFill).Contains(searchString)) ||(s.t_positionworkingtitleassociation!= null && (s.t_positionworkingtitleassociation.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_positionrolecode!= null && (s.t_positionrolecode.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_positionrolecode.t_rolecodesalaryband.T_Name) && s.t_positionrolecode.t_rolecodesalaryband.T_Name.ToUpper().Contains(searchString)) ||(s.t_positionsoccode!= null && (s.t_positionsoccode.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_positionclasscode!= null && (s.t_positionclasscode.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_workerscompcodeposition!= null && (s.t_workerscompcodeposition.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_CardApprvr) && s.T_CardApprvr.ToUpper().Contains(searchString)) ||(s.t_positioncostcenterassociation!= null && (s.t_positioncostcenterassociation.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_positionshiftmealtime!= null && (s.t_positionshiftmealtime.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_positionshifttime!= null && (s.t_positionshifttime.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_positionshiftduration!= null && (s.t_positionshiftduration.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_positionovertimeeligibility!= null && (s.t_positionovertimeeligibility.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_positionstatusforposting!= null && (s.t_positionstatusforposting.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
		else
			 lstT_Position = lstT_Position.Where(s => (s.t_facilityassignedto!= null && (s.t_facilityassignedto.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_PositionNumber) && s.T_PositionNumber.ToUpper().Contains(searchString)) ||(s.t_typeofposition!= null && (s.t_typeofposition.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_associatedpositionstatus!= null && (s.t_associatedpositionstatus.DisplayValue.ToUpper().Contains(searchString) )) ||(s.T_PositionFill != null && SqlFunctions.StringConvert((double)s.T_PositionFill).Contains(searchString)) ||(s.t_positionworkingtitleassociation!= null && (s.t_positionworkingtitleassociation.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_positionrolecode!= null && (s.t_positionrolecode.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_positionrolecode.t_rolecodesalaryband.T_Name) && s.t_positionrolecode.t_rolecodesalaryband.T_Name.ToUpper().Contains(searchString)) ||(s.t_positionclasscode!= null && (s.t_positionclasscode.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_positionshifttime!= null && (s.t_positionshifttime.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
			try
            {
                var boolvalue = Convert.ToBoolean(searchString);
                lstT_Position = lstT_Position.Union(db.T_Positions.Where(s => (s.T_QuasiFill == boolvalue) ||(s.T_DualIncumbent == boolvalue) ||(s.T_Funded == boolvalue) ));
            }
            catch { }
			try
            {
                var datevalue = Convert.ToDateTime(searchString);
                lstT_Position = lstT_Position.Union(db.T_Positions.Where(s => (s.T_EffectiveDate == datevalue) ||(s.T_ShiftStart == datevalue) ||(s.T_ShiftEnd == datevalue) ||(s.T_DualIncumbentStartDate == datevalue) ||(s.T_DualIncumbentEndDate == datevalue) ||(s.T_EstablishedDate == datevalue) ||(s.T_AbolishDate == datevalue) ));
            }
            catch { }
            return lstT_Position;
        }
		private IQueryable<T_Position> sortRecords(IQueryable<T_Position> lstT_Position, string sortBy, string isAsc)
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
	 if(sortBy == "T_SalaryBandID")
                return isAsc.ToLower() == "asc" ? lstT_Position.OrderBy(p => p.t_positionrolecode.t_rolecodesalaryband.T_Name) : lstT_Position.OrderByDescending(p => p.t_positionrolecode.t_rolecodesalaryband.T_Name);
	 if(sortBy == "T_FacilityAssignedToID")
                return isAsc.ToLower() == "asc" ? lstT_Position.OrderBy(p => p.t_facilityassignedto.DisplayValue) : lstT_Position.OrderByDescending(p => p.t_facilityassignedto.DisplayValue);
	 if(sortBy == "T_TypeOfPositionID")
                return isAsc.ToLower() == "asc" ? lstT_Position.OrderBy(p => p.t_typeofposition.DisplayValue) : lstT_Position.OrderByDescending(p => p.t_typeofposition.DisplayValue);
	 if(sortBy == "T_AssociatedPositionStatusID")
                return isAsc.ToLower() == "asc" ? lstT_Position.OrderBy(p => p.t_associatedpositionstatus.DisplayValue) : lstT_Position.OrderByDescending(p => p.t_associatedpositionstatus.DisplayValue);
	 if(sortBy == "T_PositionWorkingTitleAssociationID")
                return isAsc.ToLower() == "asc" ? lstT_Position.OrderBy(p => p.t_positionworkingtitleassociation.DisplayValue) : lstT_Position.OrderByDescending(p => p.t_positionworkingtitleassociation.DisplayValue);
	 if(sortBy == "T_PositionRoleCodeID")
                return isAsc.ToLower() == "asc" ? lstT_Position.OrderBy(p => p.t_positionrolecode.DisplayValue) : lstT_Position.OrderByDescending(p => p.t_positionrolecode.DisplayValue);
	 if(sortBy == "T_PositionClassCodeID")
                return isAsc.ToLower() == "asc" ? lstT_Position.OrderBy(p => p.t_positionclasscode.DisplayValue) : lstT_Position.OrderByDescending(p => p.t_positionclasscode.DisplayValue);
	 if(sortBy == "T_PositionShiftTimeID")
                return isAsc.ToLower() == "asc" ? lstT_Position.OrderBy(p => p.t_positionshifttime.DisplayValue) : lstT_Position.OrderByDescending(p => p.t_positionshifttime.DisplayValue);
		    if (sortBy.Contains("."))
                return isAsc.ToLower() == "asc" ? lstT_Position.Sort(sortBy,true) : lstT_Position.Sort(sortBy,false);
            ParameterExpression paramExpression = Expression.Parameter(typeof(T_Position), "t_position");
            MemberExpression memExp = Expression.PropertyOrField(paramExpression, sortBy);
            LambdaExpression lambda = Expression.Lambda(memExp, paramExpression);
            return (IQueryable<T_Position>)lstT_Position.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { lstT_Position.ElementType, lambda.Body.Type },
                    lstT_Position.Expression,
                    lambda));
        }
		public ActionResult FindFSearch(string id, string sourceEntity)
        {
            if (sourceEntity == "T_Department")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Departments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityAssignedTo  = _Object.T_DepartmentFacilityAssociationID;
						url += "&t_facilityassignedto=" + T_FacilityAssignedTo;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Employee")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Employees.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityAssignedTo  = _Object.T_EmployeeAtFacilityID;
						url += "&t_facilityassignedto=" + T_FacilityAssignedTo;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_DepartmentArea")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_DepartmentAreas.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityAssignedTo  = _Object.T_DepartmentAreaEmployeeTypeAssociationID;
						url += "&t_facilityassignedto=" + T_FacilityAssignedTo;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_ClaimType")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_ClaimTypes.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityAssignedTo  = _Object.T_ClaimTypeFacilityAssociationID;
						url += "&t_facilityassignedto=" + T_FacilityAssignedTo;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Restrictions")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Restrictionss.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityAssignedTo  = _Object.T_RestrictionsFacilityAssociationID;
						url += "&t_facilityassignedto=" + T_FacilityAssignedTo;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_UnitX")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_UnitXs.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityAssignedTo  = _Object.T_FacilityUnitXID;
						url += "&t_facilityassignedto=" + T_FacilityAssignedTo;									
						var T_PositionCostCenterAssociation  = _Object.T_WardCostCenterID;
						url += "&t_positioncostcenterassociation=" + T_PositionCostCenterAssociation;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_EmployeeInjury")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_EmployeeInjurys.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_PositionShiftTime  = _Object.T_AccidentShiftID;
						url += "&t_positionshifttime=" + T_PositionShiftTime;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Unit")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Units.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityAssignedTo  = _Object.T_FacilityUnitID;
						url += "&t_facilityassignedto=" + T_FacilityAssignedTo;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_RequiredEducation")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_RequiredEducations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_PositionRoleCode  = _Object.T_RoleCodeRequiredEducationID;
						url += "&t_positionrolecode=" + T_PositionRoleCode;									
						var T_PositionSOCCode  = _Object.T_RequiredEducationSOCCodeID;
						url += "&t_positionsoccode=" + T_PositionSOCCode;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_SalaryRange")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_SalaryRanges.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityAssignedTo  = _Object.T_FacilitySalaryRangeAssociationID;
						url += "&t_facilityassignedto=" + T_FacilityAssignedTo;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_FacilityConfiguration")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_FacilityConfigurations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_FacilityAssignedTo  = _Object.T_TenantConfigurationAssociationID;
						url += "&t_facilityassignedto=" + T_FacilityAssignedTo;									
                Response.Redirect(url.ToString());
            }
            return null;
        }
        public ActionResult SetFSearch(string searchString, string HostingEntity ,string t_facilityassignedto,string t_typeofposition,string t_associatedpositionstatus,string t_positionidentifier,string t_positionworkingtitleassociation,string t_positionrolecode,string t_positionsoccode,string t_positionclasscode,string t_workerscompcodeposition,string t_positioncostcenterassociation,string t_positionshiftmealtime,string t_positionshifttime,string t_positionshiftduration,string t_positionovertimeeligibility,string t_positionstatusforposting, bool? RenderPartial)
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
			var T_FacilityAssignedTolist = db.T_Facilitys.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_facilityassignedto != null)
            {
                var ids = t_facilityassignedto.Split(",".ToCharArray());
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
					var list = T_FacilityAssignedTolist.Union(db.T_Facilitys.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Facility>(User, list, "T_Facility", null);
					ViewBag.t_facilityassignedto = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_FacilityAssignedTolist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Facility>(User, list, "T_Facility", null);
				ViewBag.t_facilityassignedto = new SelectList(list, "ID", "DisplayValue");
			}
			var T_TypeOfPositionlist = db.T_PositionTypes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_typeofposition != null)
            {
                var ids = t_typeofposition.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Position Type= ";
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
							   ViewBag.SearchResult += db.T_PositionTypes.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_TypeOfPositionlist.Union(db.T_PositionTypes.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_PositionType>(User, list, "T_PositionType", null);
					ViewBag.t_typeofposition = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_TypeOfPositionlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_PositionType>(User, list, "T_PositionType", null);
				ViewBag.t_typeofposition = new SelectList(list, "ID", "DisplayValue");
			}
			var T_AssociatedPositionStatuslist = db.T_Positionstatuss.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_associatedpositionstatus != null)
            {
                var ids = t_associatedpositionstatus.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Position Status= ";
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
							   ViewBag.SearchResult += db.T_Positionstatuss.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_AssociatedPositionStatuslist.Union(db.T_Positionstatuss.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Positionstatus>(User, list, "T_Positionstatus", null);
					ViewBag.t_associatedpositionstatus = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_AssociatedPositionStatuslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Positionstatus>(User, list, "T_Positionstatus", null);
				ViewBag.t_associatedpositionstatus = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionIdentifierlist = db.T_PositionLevels.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionidentifier != null)
            {
                var ids = t_positionidentifier.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Position Level= ";
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
							   ViewBag.SearchResult += db.T_PositionLevels.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PositionIdentifierlist.Union(db.T_PositionLevels.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_PositionLevel>(User, list, "T_PositionLevel", null);
					ViewBag.t_positionidentifier = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionIdentifierlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_PositionLevel>(User, list, "T_PositionLevel", null);
				ViewBag.t_positionidentifier = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionWorkingTitleAssociationlist = db.T_WorkingTitles.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionworkingtitleassociation != null)
            {
                var ids = t_positionworkingtitleassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Working Title = ";
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
							   ViewBag.SearchResult += db.T_WorkingTitles.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PositionWorkingTitleAssociationlist.Union(db.T_WorkingTitles.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_WorkingTitle>(User, list, "T_WorkingTitle", null);
					ViewBag.t_positionworkingtitleassociation = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionWorkingTitleAssociationlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_WorkingTitle>(User, list, "T_WorkingTitle", null);
				ViewBag.t_positionworkingtitleassociation = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionRoleCodelist = db.T_RoleCodes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionrolecode != null)
            {
                var ids = t_positionrolecode.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Role Code= ";
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
							   ViewBag.SearchResult += db.T_RoleCodes.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PositionRoleCodelist.Union(db.T_RoleCodes.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_RoleCode>(User, list, "T_RoleCode", null);
					ViewBag.t_positionrolecode = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionRoleCodelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_RoleCode>(User, list, "T_RoleCode", null);
				ViewBag.t_positionrolecode = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionSOCCodelist = db.T_SocCodes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionsoccode != null)
            {
                var ids = t_positionsoccode.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n SOC Code= ";
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
							   ViewBag.SearchResult += db.T_SocCodes.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PositionSOCCodelist.Union(db.T_SocCodes.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_SocCode>(User, list, "T_SocCode", null);
					ViewBag.t_positionsoccode = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionSOCCodelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_SocCode>(User, list, "T_SocCode", null);
				ViewBag.t_positionsoccode = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionClassCodelist = db.T_ClassCodes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionclasscode != null)
            {
                var ids = t_positionclasscode.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Class Code= ";
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
							   ViewBag.SearchResult += db.T_ClassCodes.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PositionClassCodelist.Union(db.T_ClassCodes.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_ClassCode>(User, list, "T_ClassCode", null);
					ViewBag.t_positionclasscode = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionClassCodelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_ClassCode>(User, list, "T_ClassCode", null);
				ViewBag.t_positionclasscode = new SelectList(list, "ID", "DisplayValue");
			}
			var T_WorkersCompCodePositionlist = db.T_WCCodes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_workerscompcodeposition != null)
            {
                var ids = t_workerscompcodeposition.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n WC Code= ";
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
							   ViewBag.SearchResult += db.T_WCCodes.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_WorkersCompCodePositionlist.Union(db.T_WCCodes.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_WCCode>(User, list, "T_WCCode", null);
					ViewBag.t_workerscompcodeposition = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_WorkersCompCodePositionlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_WCCode>(User, list, "T_WCCode", null);
				ViewBag.t_workerscompcodeposition = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionCostCenterAssociationlist = db.T_CostCenters.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positioncostcenterassociation != null)
            {
                var ids = t_positioncostcenterassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n CardDept= ";
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
					var list = T_PositionCostCenterAssociationlist.Union(db.T_CostCenters.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_CostCenter>(User, list, "T_CostCenter", null);
					ViewBag.t_positioncostcenterassociation = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionCostCenterAssociationlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_CostCenter>(User, list, "T_CostCenter", null);
				ViewBag.t_positioncostcenterassociation = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionShiftMealTimelist = db.T_ShiftMealTimes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionshiftmealtime != null)
            {
                var ids = t_positionshiftmealtime.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Shift Meal Time= ";
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
							   ViewBag.SearchResult += db.T_ShiftMealTimes.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PositionShiftMealTimelist.Union(db.T_ShiftMealTimes.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_ShiftMealTime>(User, list, "T_ShiftMealTime", null);
					ViewBag.t_positionshiftmealtime = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionShiftMealTimelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_ShiftMealTime>(User, list, "T_ShiftMealTime", null);
				ViewBag.t_positionshiftmealtime = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionShiftTimelist = db.T_ShiftTimes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionshifttime != null)
            {
                var ids = t_positionshifttime.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Shift Time= ";
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
					var list = T_PositionShiftTimelist.Union(db.T_ShiftTimes.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_ShiftTime>(User, list, "T_ShiftTime", null);
					ViewBag.t_positionshifttime = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionShiftTimelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_ShiftTime>(User, list, "T_ShiftTime", null);
				ViewBag.t_positionshifttime = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionShiftDurationlist = db.T_ShiftDurations.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionshiftduration != null)
            {
                var ids = t_positionshiftduration.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Shift Duration= ";
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
							   ViewBag.SearchResult += db.T_ShiftDurations.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PositionShiftDurationlist.Union(db.T_ShiftDurations.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_ShiftDuration>(User, list, "T_ShiftDuration", null);
					ViewBag.t_positionshiftduration = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionShiftDurationlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_ShiftDuration>(User, list, "T_ShiftDuration", null);
				ViewBag.t_positionshiftduration = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionOvertimeEligibilitylist = db.T_OvertimeEligibilitys.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionovertimeeligibility != null)
            {
                var ids = t_positionovertimeeligibility.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Overtime Eligibility= ";
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
							   ViewBag.SearchResult += db.T_OvertimeEligibilitys.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PositionOvertimeEligibilitylist.Union(db.T_OvertimeEligibilitys.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_OvertimeEligibility>(User, list, "T_OvertimeEligibility", null);
					ViewBag.t_positionovertimeeligibility = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionOvertimeEligibilitylist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_OvertimeEligibility>(User, list, "T_OvertimeEligibility", null);
				ViewBag.t_positionovertimeeligibility = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PositionStatusforPostinglist = db.T_PositionPostStatuss.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_positionstatusforposting != null)
            {
                var ids = t_positionstatusforposting.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Position Post Status= ";
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
							   ViewBag.SearchResult += db.T_PositionPostStatuss.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PositionStatusforPostinglist.Union(db.T_PositionPostStatuss.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_PositionPostStatus>(User, list, "T_PositionPostStatus", null);
					ViewBag.t_positionstatusforposting = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PositionStatusforPostinglist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_PositionPostStatus>(User, list, "T_PositionPostStatus", null);
				ViewBag.t_positionstatusforposting = new SelectList(list, "ID", "DisplayValue");
			}
			}
			else
			{
			var objT_FacilityAssignedTo = new List<T_Facility>();
		    ViewBag.t_facilityassignedto = new SelectList(objT_FacilityAssignedTo, "ID", "DisplayValue");
			var objT_TypeOfPosition = new List<T_PositionType>();
		    ViewBag.t_typeofposition = new SelectList(objT_TypeOfPosition, "ID", "DisplayValue");
			var objT_AssociatedPositionStatus = new List<T_Positionstatus>();
		    ViewBag.t_associatedpositionstatus = new SelectList(objT_AssociatedPositionStatus, "ID", "DisplayValue");
			var objT_PositionIdentifier = new List<T_PositionLevel>();
		    ViewBag.t_positionidentifier = new SelectList(objT_PositionIdentifier, "ID", "DisplayValue");
			var objT_PositionWorkingTitleAssociation = new List<T_WorkingTitle>();
		    ViewBag.t_positionworkingtitleassociation = new SelectList(objT_PositionWorkingTitleAssociation, "ID", "DisplayValue");
			var objT_PositionRoleCode = new List<T_RoleCode>();
		    ViewBag.t_positionrolecode = new SelectList(objT_PositionRoleCode, "ID", "DisplayValue");
			var objT_PositionSOCCode = new List<T_SocCode>();
		    ViewBag.t_positionsoccode = new SelectList(objT_PositionSOCCode, "ID", "DisplayValue");
			var objT_PositionClassCode = new List<T_ClassCode>();
		    ViewBag.t_positionclasscode = new SelectList(objT_PositionClassCode, "ID", "DisplayValue");
			var objT_WorkersCompCodePosition = new List<T_WCCode>();
		    ViewBag.t_workerscompcodeposition = new SelectList(objT_WorkersCompCodePosition, "ID", "DisplayValue");
			var objT_PositionCostCenterAssociation = new List<T_CostCenter>();
		    ViewBag.t_positioncostcenterassociation = new SelectList(objT_PositionCostCenterAssociation, "ID", "DisplayValue");
			var objT_PositionShiftMealTime = new List<T_ShiftMealTime>();
		    ViewBag.t_positionshiftmealtime = new SelectList(objT_PositionShiftMealTime, "ID", "DisplayValue");
			var objT_PositionShiftTime = new List<T_ShiftTime>();
		    ViewBag.t_positionshifttime = new SelectList(objT_PositionShiftTime, "ID", "DisplayValue");
			var objT_PositionShiftDuration = new List<T_ShiftDuration>();
		    ViewBag.t_positionshiftduration = new SelectList(objT_PositionShiftDuration, "ID", "DisplayValue");
			var objT_PositionOvertimeEligibility = new List<T_OvertimeEligibility>();
		    ViewBag.t_positionovertimeeligibility = new SelectList(objT_PositionOvertimeEligibility, "ID", "DisplayValue");
			var objT_PositionStatusforPosting = new List<T_PositionPostStatus>();
		    ViewBag.t_positionstatusforposting = new SelectList(objT_PositionStatusforPosting, "ID", "DisplayValue");
			}
				var lstFavoriteItem = db.FavoriteItems.Where(p => p.LastUpdatedByUser == User.Name);
				if (lstFavoriteItem.Count() > 0)
                    ViewBag.FavoriteItem = lstFavoriteItem;
				ViewBag.EntityName = "T_Position";
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
			columns.Add("3", "Position Number");
			columns.Add("4", "Position Type");
			columns.Add("5", "Position Status");
			columns.Add("6", "Position Fill %");
			columns.Add("7", "Working Title ");
			columns.Add("8", "Effective Date");
			columns.Add("9", "Role Code");
			columns.Add("10", "Salary Band");
			columns.Add("11", "Class Code");
			columns.Add("12", "Shift Start");
			columns.Add("13", "Shift End");
			columns.Add("14", "Shift Time");
			columns.Add("15", "Established Date");
				ViewBag.HideColumns = new MultiSelectList(columns, "Key", "Value");
				return View(new T_Position());
            }
		public string conditionFSearch(string property, string operators, string value)
        {
            string expression = string.Empty;
            var PrpertyType = GetDataTypeOfProperty("T_Position", property);
            var dataType = PrpertyType[0];
            property = PrpertyType[1];
            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                var ValueType = GetDataTypeOfProperty("T_Position", value, true);
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
							expression = string.Format(" DbFunctions.TruncateTime(" + property + ") " + operators + " (\"{0}\")", (TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (new T_Position()).m_Timezone)).Date);
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
		// GET: /T_Position/FSearch/
		[Audit("FacetedSearch")]
		public ActionResult FSearch(string currentFilter, string searchString, string FSFilter, string sortBy, string isAsc, int? page, int? itemsPerPage, string search, bool? IsExport ,string t_facilityassignedto,string t_typeofposition,string t_associatedpositionstatus,string t_positionidentifier,string t_positionworkingtitleassociation,string t_positionrolecode,string t_positionsoccode,string t_positionclasscode,string t_workerscompcodeposition,string t_positioncostcenterassociation,string t_positionshiftmealtime,string t_positionshifttime,string t_positionshiftduration,string t_positionovertimeeligibility,string t_positionstatusforposting ,string T_PositionFillFrom,string T_PositionFillTo,string T_QuasiFill,string T_EffectiveDateFrom,string T_EffectiveDateTo,string T_ShiftStartFrom,string T_ShiftStartTo,string T_ShiftEndFrom,string T_ShiftEndTo,string T_DualIncumbent,string T_DualIncumbentStartDateFrom,string T_DualIncumbentStartDateTo,string T_DualIncumbentEndDateFrom,string T_DualIncumbentEndDateTo,string T_Funded,string T_EstablishedDateFrom,string T_EstablishedDateTo,string T_AbolishDateFrom,string T_AbolishDateTo,string T_ShiftStartFromhdn,string T_ShiftStartTohdn,string T_ShiftEndFromhdn,string T_ShiftEndTohdn,string FilterCondition, string HostingEntity, string AssociatedType,string HostingEntityID, string viewtype, string SortOrder, string HideColumns, string GroupByColumn,bool? IsReports, bool? IsdrivedTab)
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
				 var lstT_Position  = from s in db.T_Positions
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Position  = searchRecords(lstT_Position, searchString.ToUpper(),true);
            }
			  if(!string.IsNullOrEmpty(search))
                	search=search.Replace("?IsAddPop=true", "");
			if(!string.IsNullOrEmpty(search)){
				ViewBag.SearchResult += "\r\n General Criterial= "+search;
				lstT_Position = searchRecords(lstT_Position, search,true);
			}
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Position  = sortRecords(lstT_Position, sortBy, isAsc);
            }
            else   lstT_Position  = lstT_Position.OrderBy(c=>c.T_PositionFill);
			lstT_Position = CustomSorting(lstT_Position);
			lstT_Position = lstT_Position.Include(t=>t.t_facilityassignedto).Include(t=>t.t_typeofposition).Include(t=>t.t_associatedpositionstatus).Include(t=>t.t_positionidentifier).Include(t=>t.t_positionworkingtitleassociation).Include(t=>t.t_positionrolecode).Include(t=>t.t_positionsoccode).Include(t=>t.t_positionclasscode).Include(t=>t.t_workerscompcodeposition).Include(t=>t.t_positioncostcenterassociation).Include(t=>t.t_positionshiftmealtime).Include(t=>t.t_positionshifttime).Include(t=>t.t_positionshiftduration).Include(t=>t.t_positionovertimeeligibility).Include(t=>t.t_positionstatusforposting);
					if (!string.IsNullOrEmpty(SortOrder) && SortOrder.Contains("T_SalaryBand"))
                    {
                      SortOrder = SortOrder.Replace("T_SalaryBand", "t_positionrolecode.t_rolecodesalaryband.T_Name");  
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
					ViewBag.SearchResult += " " + GetPropertyDP("T_Position", PropertyName) + " " + Operator + " " + Value + " " + LogicalConnector;
                    whereCondition.Append(conditionFSearch(PropertyName, Operator, Value) + LogicalConnector);
                    iCnt++;
                }
                if (!string.IsNullOrEmpty(whereCondition.ToString()))
                    lstT_Position = lstT_Position.Where(whereCondition.ToString());
                ViewBag.FilterCondition = FilterCondition;
            }
			var DataOrdering = string.Empty;
            if (!string.IsNullOrEmpty(GroupByColumn))
            {
                DataOrdering = GroupByColumn;
									if (DataOrdering.Contains("T_SalaryBand"))
                    {
                      DataOrdering = DataOrdering.Replace("T_SalaryBand", "t_positionrolecode.t_rolecodesalaryband.T_Name");  
                    }
                ViewBag.IsGroupBy = true;
            }
            if (!string.IsNullOrEmpty(SortOrder))
                DataOrdering += SortOrder;
            if (!string.IsNullOrEmpty(DataOrdering))
                lstT_Position = Sorting.Sort<T_Position>(lstT_Position, DataOrdering);
            var _T_Position = lstT_Position;
		 if(T_PositionFillFrom!=null || T_PositionFillTo !=null)
		 {
                try
                {
                    int from = T_PositionFillFrom == null ? 0 : Convert.ToInt32(T_PositionFillFrom);
                    int to =  T_PositionFillTo == null ? int.MaxValue : Convert.ToInt32(T_PositionFillTo);
									     _T_Position =  _T_Position.Where(o => o.T_PositionFill >= from && o.T_PositionFill <= to);
                   					ViewBag.SearchResult += "\r\n Position Fill %= "+from+"-"+to;
                }
                catch { }
          }
		 if(T_QuasiFill!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_QuasiFill);
                    _T_Position =  _T_Position.Where(o => o.T_QuasiFill == boolvalue);
					ViewBag.SearchResult += "\r\n Quasi Fill= "+T_QuasiFill;
                }
                catch { }
            }
				if(T_EffectiveDateFrom!=null || T_EffectiveDateTo !=null)
				{
						try
						{
							DateTime from = T_EffectiveDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_EffectiveDateFrom);
							DateTime to = T_EffectiveDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_EffectiveDateTo).AddTicks(-1).AddDays(1);
							                       _T_Position =  _T_Position.Where(o =>o.T_EffectiveDate!=null && o.T_EffectiveDate.Value.CompareTo(from) >= 0 && o.T_EffectiveDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Effective Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_ShiftStartFrom!=null || T_ShiftStartTo !=null)
				{
						try
						{
							TimeSpan from = T_ShiftStartFrom == null ? Convert.ToDateTime("01/01/1900").TimeOfDay : Convert.ToDateTime(T_ShiftStartFrom).TimeOfDay;
							TimeSpan to = T_ShiftStartTo == null ? DateTime.MaxValue.TimeOfDay : Convert.ToDateTime(T_ShiftStartTo).TimeOfDay;
												   _T_Position =  _T_Position.Where(o => o.T_ShiftStart.Value.Hour * 60 + o.T_ShiftStart.Value.Minute >= from.TotalMinutes && o.T_ShiftStart.Value.Hour * 60 + o.T_ShiftStart.Value.Minute <= to.TotalMinutes);
                   							ViewBag.SearchResult += "\r\n Shift Start= " + T_ShiftStartFromhdn + "-" + T_ShiftStartTohdn;
						}
						catch { }
				}
				if(T_ShiftEndFrom!=null || T_ShiftEndTo !=null)
				{
						try
						{
							TimeSpan from = T_ShiftEndFrom == null ? Convert.ToDateTime("01/01/1900").TimeOfDay : Convert.ToDateTime(T_ShiftEndFrom).TimeOfDay;
							TimeSpan to = T_ShiftEndTo == null ? DateTime.MaxValue.TimeOfDay : Convert.ToDateTime(T_ShiftEndTo).TimeOfDay;
												   _T_Position =  _T_Position.Where(o => o.T_ShiftEnd.Value.Hour * 60 + o.T_ShiftEnd.Value.Minute >= from.TotalMinutes && o.T_ShiftEnd.Value.Hour * 60 + o.T_ShiftEnd.Value.Minute <= to.TotalMinutes);
                   							ViewBag.SearchResult += "\r\n Shift End= " + T_ShiftEndFromhdn + "-" + T_ShiftEndTohdn;
						}
						catch { }
				}
		 if(T_DualIncumbent!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_DualIncumbent);
                    _T_Position =  _T_Position.Where(o => o.T_DualIncumbent == boolvalue);
					ViewBag.SearchResult += "\r\n Dual Incumbent= "+T_DualIncumbent;
                }
                catch { }
            }
				if(T_DualIncumbentStartDateFrom!=null || T_DualIncumbentStartDateTo !=null)
				{
						try
						{
							DateTime from = T_DualIncumbentStartDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_DualIncumbentStartDateFrom);
							DateTime to = T_DualIncumbentStartDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_DualIncumbentStartDateTo).AddTicks(-1).AddDays(1);
							                       _T_Position =  _T_Position.Where(o =>o.T_DualIncumbentStartDate!=null && o.T_DualIncumbentStartDate.Value.CompareTo(from) >= 0 && o.T_DualIncumbentStartDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Dual Incumbent Start Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_DualIncumbentEndDateFrom!=null || T_DualIncumbentEndDateTo !=null)
				{
						try
						{
							DateTime from = T_DualIncumbentEndDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_DualIncumbentEndDateFrom);
							DateTime to = T_DualIncumbentEndDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_DualIncumbentEndDateTo).AddTicks(-1).AddDays(1);
							                       _T_Position =  _T_Position.Where(o =>o.T_DualIncumbentEndDate!=null && o.T_DualIncumbentEndDate.Value.CompareTo(from) >= 0 && o.T_DualIncumbentEndDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Dual Incumbent End Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
		 if(T_Funded!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_Funded);
                    _T_Position =  _T_Position.Where(o => o.T_Funded == boolvalue);
					ViewBag.SearchResult += "\r\n Funded= "+T_Funded;
                }
                catch { }
            }
				if(T_EstablishedDateFrom!=null || T_EstablishedDateTo !=null)
				{
						try
						{
							DateTime from = T_EstablishedDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_EstablishedDateFrom);
							DateTime to = T_EstablishedDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_EstablishedDateTo).AddTicks(-1).AddDays(1);
							                       _T_Position =  _T_Position.Where(o =>o.T_EstablishedDate!=null && o.T_EstablishedDate.CompareTo(from) >= 0 && o.T_EstablishedDate.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Established Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_AbolishDateFrom!=null || T_AbolishDateTo !=null)
				{
						try
						{
							DateTime from = T_AbolishDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_AbolishDateFrom);
							DateTime to = T_AbolishDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_AbolishDateTo).AddTicks(-1).AddDays(1);
							                       _T_Position =  _T_Position.Where(o =>o.T_AbolishDate!=null && o.T_AbolishDate.Value.CompareTo(from) >= 0 && o.T_AbolishDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Abolish Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
			//if (lstT_Position.Where(p => p.t_facilityassignedto != null).Count() <= 50)
		    //ViewBag.t_facilityassignedto = new SelectList(lstT_Position.Where(p => p.t_facilityassignedto != null).Select(P => P.t_facilityassignedto).Distinct(), "ID", "DisplayValue");
            if (t_facilityassignedto != null)
            {
                var ids = t_facilityassignedto.Split(",".ToCharArray());
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
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_FacilityAssignedToID));
            }
				//if (lstT_Position.Where(p => p.t_typeofposition != null).Count() <= 50)
		    //ViewBag.t_typeofposition = new SelectList(lstT_Position.Where(p => p.t_typeofposition != null).Select(P => P.t_typeofposition).Distinct(), "ID", "DisplayValue");
            if (t_typeofposition != null)
            {
                var ids = t_typeofposition.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Position Type= ";
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
                            var obj = db.T_PositionTypes.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_TypeOfPositionID));
            }
				//if (lstT_Position.Where(p => p.t_associatedpositionstatus != null).Count() <= 50)
		    //ViewBag.t_associatedpositionstatus = new SelectList(lstT_Position.Where(p => p.t_associatedpositionstatus != null).Select(P => P.t_associatedpositionstatus).Distinct(), "ID", "DisplayValue");
            if (t_associatedpositionstatus != null)
            {
                var ids = t_associatedpositionstatus.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Position Status= ";
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
                            var obj = db.T_Positionstatuss.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_AssociatedPositionStatusID));
            }
				//if (lstT_Position.Where(p => p.t_positionidentifier != null).Count() <= 50)
		    //ViewBag.t_positionidentifier = new SelectList(lstT_Position.Where(p => p.t_positionidentifier != null).Select(P => P.t_positionidentifier).Distinct(), "ID", "DisplayValue");
            if (t_positionidentifier != null)
            {
                var ids = t_positionidentifier.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Position Level= ";
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
                            var obj = db.T_PositionLevels.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionIdentifierID));
            }
				//if (lstT_Position.Where(p => p.t_positionworkingtitleassociation != null).Count() <= 50)
		    //ViewBag.t_positionworkingtitleassociation = new SelectList(lstT_Position.Where(p => p.t_positionworkingtitleassociation != null).Select(P => P.t_positionworkingtitleassociation).Distinct(), "ID", "DisplayValue");
            if (t_positionworkingtitleassociation != null)
            {
                var ids = t_positionworkingtitleassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Working Title = ";
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
                            var obj = db.T_WorkingTitles.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionWorkingTitleAssociationID));
            }
				//if (lstT_Position.Where(p => p.t_positionrolecode != null).Count() <= 50)
		    //ViewBag.t_positionrolecode = new SelectList(lstT_Position.Where(p => p.t_positionrolecode != null).Select(P => P.t_positionrolecode).Distinct(), "ID", "DisplayValue");
            if (t_positionrolecode != null)
            {
                var ids = t_positionrolecode.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Role Code= ";
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
                            var obj = db.T_RoleCodes.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionRoleCodeID));
            }
				//if (lstT_Position.Where(p => p.t_positionsoccode != null).Count() <= 50)
		    //ViewBag.t_positionsoccode = new SelectList(lstT_Position.Where(p => p.t_positionsoccode != null).Select(P => P.t_positionsoccode).Distinct(), "ID", "DisplayValue");
            if (t_positionsoccode != null)
            {
                var ids = t_positionsoccode.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n SOC Code= ";
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
                            var obj = db.T_SocCodes.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionSOCCodeID));
            }
				//if (lstT_Position.Where(p => p.t_positionclasscode != null).Count() <= 50)
		    //ViewBag.t_positionclasscode = new SelectList(lstT_Position.Where(p => p.t_positionclasscode != null).Select(P => P.t_positionclasscode).Distinct(), "ID", "DisplayValue");
            if (t_positionclasscode != null)
            {
                var ids = t_positionclasscode.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Class Code= ";
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
                            var obj = db.T_ClassCodes.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionClassCodeID));
            }
				//if (lstT_Position.Where(p => p.t_workerscompcodeposition != null).Count() <= 50)
		    //ViewBag.t_workerscompcodeposition = new SelectList(lstT_Position.Where(p => p.t_workerscompcodeposition != null).Select(P => P.t_workerscompcodeposition).Distinct(), "ID", "DisplayValue");
            if (t_workerscompcodeposition != null)
            {
                var ids = t_workerscompcodeposition.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n WC Code= ";
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
                            var obj = db.T_WCCodes.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_WorkersCompCodePositionID));
            }
				//if (lstT_Position.Where(p => p.t_positioncostcenterassociation != null).Count() <= 50)
		    //ViewBag.t_positioncostcenterassociation = new SelectList(lstT_Position.Where(p => p.t_positioncostcenterassociation != null).Select(P => P.t_positioncostcenterassociation).Distinct(), "ID", "DisplayValue");
            if (t_positioncostcenterassociation != null)
            {
                var ids = t_positioncostcenterassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n CardDept= ";
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
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionCostCenterAssociationID));
            }
				//if (lstT_Position.Where(p => p.t_positionshiftmealtime != null).Count() <= 50)
		    //ViewBag.t_positionshiftmealtime = new SelectList(lstT_Position.Where(p => p.t_positionshiftmealtime != null).Select(P => P.t_positionshiftmealtime).Distinct(), "ID", "DisplayValue");
            if (t_positionshiftmealtime != null)
            {
                var ids = t_positionshiftmealtime.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Shift Meal Time= ";
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
                            var obj = db.T_ShiftMealTimes.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionShiftMealTimeID));
            }
				//if (lstT_Position.Where(p => p.t_positionshifttime != null).Count() <= 50)
		    //ViewBag.t_positionshifttime = new SelectList(lstT_Position.Where(p => p.t_positionshifttime != null).Select(P => P.t_positionshifttime).Distinct(), "ID", "DisplayValue");
            if (t_positionshifttime != null)
            {
                var ids = t_positionshifttime.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Shift Time= ";
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
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionShiftTimeID));
            }
				//if (lstT_Position.Where(p => p.t_positionshiftduration != null).Count() <= 50)
		    //ViewBag.t_positionshiftduration = new SelectList(lstT_Position.Where(p => p.t_positionshiftduration != null).Select(P => P.t_positionshiftduration).Distinct(), "ID", "DisplayValue");
            if (t_positionshiftduration != null)
            {
                var ids = t_positionshiftduration.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Shift Duration= ";
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
                            var obj = db.T_ShiftDurations.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionShiftDurationID));
            }
				//if (lstT_Position.Where(p => p.t_positionovertimeeligibility != null).Count() <= 50)
		    //ViewBag.t_positionovertimeeligibility = new SelectList(lstT_Position.Where(p => p.t_positionovertimeeligibility != null).Select(P => P.t_positionovertimeeligibility).Distinct(), "ID", "DisplayValue");
            if (t_positionovertimeeligibility != null)
            {
                var ids = t_positionovertimeeligibility.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Overtime Eligibility= ";
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
                            var obj = db.T_OvertimeEligibilitys.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionOvertimeEligibilityID));
            }
				//if (lstT_Position.Where(p => p.t_positionstatusforposting != null).Count() <= 50)
		    //ViewBag.t_positionstatusforposting = new SelectList(lstT_Position.Where(p => p.t_positionstatusforposting != null).Select(P => P.t_positionstatusforposting).Distinct(), "ID", "DisplayValue");
            if (t_positionstatusforposting != null)
            {
                var ids = t_positionstatusforposting.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Position Post Status= ";
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
                            var obj = db.T_PositionPostStatuss.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Position = _T_Position.Where(p => ids1.Contains(p.T_PositionStatusforPostingID));
            }
				if (!string.IsNullOrEmpty(SortOrder))
            {
                ViewBag.SearchResult += " \r\n Sort Order = ";
                var sortString = "";
                var sortProps = SortOrder.Split(",".ToCharArray());
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Position");
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
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Position");
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
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_Position"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_Position"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
            //
            if (Convert.ToBoolean(IsExport))
            {
                pageNumber = 1;
                if (_T_Position.Count() > 0)
                    pageSize = _T_Position.Count();
                return View("ExcelExport", _T_Position.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Position.Count();
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
				var list = _T_Position.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_PositionDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_Positionlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_Position", tagsSplit.ToArray());
                    }
                return View("Index",list);
			}
            else
			{
				var list = _T_Position.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_PositionDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_Positionlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_Position", tagsSplit.ToArray());
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
		var entity = "T_Position";
           var chartlist = db.Charts.Where(chrt => chrt.EntityName == entity && chrt.ShowInDashBoard).ToList();
           if (type != "all")
               chartlist = chartlist.Where(chrt => chrt.Id == Convert.ToInt64(type)).ToList();
           var entitylist = db.T_Positions;
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
                var gd = db.T_Positions.GroupBy(p => p.t_facilityassignedto.DisplayValue).ToList();
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
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Facility", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "1", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Facility (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Facility"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Facility", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "2", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_typeofposition.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Position Type (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Position Type"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Position Type", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "3", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Position Type (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Position Type"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Position Type", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "4", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_associatedpositionstatus.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Position Status (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Position Status"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Position Status", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "5", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Position Status (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Position Status"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Position Status", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "6", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_positionidentifier.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Position Level (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Position Level"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Position Level", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "7", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Position Level (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Position Level"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Position Level", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "8", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_positionworkingtitleassociation.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Working Title  (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Working Title "));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Working Title ", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "9", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Working Title  (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Working Title "));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Working Title ", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "10", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_positionrolecode.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Role Code (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Role Code"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Role Code", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "11", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Role Code (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Role Code"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Role Code", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "12", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_positionsoccode.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by SOC Code (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by SOC Code"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "SOC Code", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "13", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by SOC Code (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by SOC Code"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "SOC Code", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "14", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_positionclasscode.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "15" || type == "all")
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
                chart.Titles.Add(CreateTitle("Count by Class Code (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Class Code"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Class Code", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "15", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
			if (type == "16" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Class Code (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Class Code"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Class Code", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "16", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_workerscompcodeposition.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by WC Code (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by WC Code"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "WC Code", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "17", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by WC Code (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by WC Code"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "WC Code", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "18", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_positioncostcenterassociation.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by CardDept (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by CardDept"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "CardDept", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "19", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by CardDept (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by CardDept"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "CardDept", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "20", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_positionshiftmealtime.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Shift Meal Time (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Shift Meal Time"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Shift Meal Time", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "21", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Shift Meal Time (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Shift Meal Time"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Shift Meal Time", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "22", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_positionshifttime.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "23" || type == "all")
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
                chart.Titles.Add(CreateTitle("Count by Shift Time (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Shift Time"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Shift Time", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "23", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
			if (type == "24" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Shift Time (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Shift Time"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Shift Time", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "24", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
				}
            }
           {
                var gd = db.T_Positions.GroupBy(p => p.t_positionshiftduration.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Shift Duration (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Shift Duration"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Shift Duration", "Position"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "25", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).ToList();
                    if (_yvalT_PositionFill .Count > 10 && inlarge == null)
                    {
                        _yvalT_PositionFill = gd.Select(k => k.Sum(p=>p.T_PositionFill)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PositionFill  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PositionFill.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Shift Duration (Top 10)"));
				else
				chartT_PositionFill.Titles.Add(CreateTitle("Total of Position Fill % by Shift Duration"));
                chartT_PositionFill.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Shift Duration", "T_PositionFill"));
                chartT_PositionFill.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PositionFill.Series[0].Points.DataBindXY(_xval, _yvalT_PositionFill );
                chartT_PositionFill.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PositionFill.Width = 800;
                        chartT_PositionFill.Height = 800;
                    }
                byte[] bytesT_PositionFill;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PositionFill.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PositionFill = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PositionFill = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Position", new { type = "26", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
                    }
                    else
                    {
                        string imgT_PositionFill = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PositionFill = Convert.ToBase64String(bytesT_PositionFill.ToArray());
                        result += String.Format(imgT_PositionFill, encodedT_PositionFill);
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
            var _Obj = db1.T_Positions.FirstOrDefault(p => p.Id == idvalue);
            return  _Obj==null?"":_Obj.DisplayValue;
        }
		public IQueryable<JournalEntry> GetExtraJournalEntry(int? id, Models.IUser user, JournalEntryContext jedb)
        {
			var listjournaliquery = jedb.JournalEntries.Where(p => p.Id == 0);
			Expression<Func<JournalEntry, bool>> predicateJournalEntry = n => false;
		var t_position = jedb.T_Positions.Find(id);
			var T_PositionJobAssignmentIds = jedb.T_JobAssignments.Where(p=>p.T_PositionJobAssignmentID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_JobAssignment" && T_PositionJobAssignmentIds.Contains(d.RecordId) && d.Type != "View"));
			
			listjournaliquery = new FilteredDbSet<JournalEntry>(jedb, predicateJournalEntry); 
			return listjournaliquery;
        }
		public object GetRecordById(string id)
        {
		            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            if (string.IsNullOrEmpty(id)) return "";
            var _Obj = db1.T_Positions.Find(Convert.ToInt64(id));
            return _Obj;
        }
		public string GetRecordById_Reflection(string id)
        {
							ApplicationContext db1 = new ApplicationContext(new SystemUser());
			if (string.IsNullOrEmpty(id)) return "";
			var _Obj = db1.T_Positions.Find(Convert.ToInt64(id));
            return _Obj == null ? "" : EntityComparer.EnumeratePropertyValues<T_Position>(_Obj, "T_Position", new string[] { ""  }); ;
			        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllValueForFilter(string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
		            IQueryable<T_Position> list = db.T_Positions;
            var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                       select new { Id = x.Id, Name = x.DisplayValue };
            return Json(data, JsonRequestBehavior.AllowGet);
			        }
		[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValue(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_Position> list = db.T_Positions;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_Positions;
					string lambda = "";
                    foreach (var asso in AssoNameWithParent.Split("?".ToCharArray()))
                    {
                        lambda += asso + "=" + AssociationID + " OR ";
                    }
                    lambda = lambda.TrimEnd(" OR ".ToCharArray());
                    query = query.Where(lambda);
                   //Type[] exprArgTypes = { query.ElementType };
                   // string propToWhere = AssoNameWithParent;
                   // ParameterExpression p = Expression.Parameter(typeof(T_Position), "p");
                   // MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                   // LambdaExpression lambda = Expression.Lambda<Func<T_Position, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                   // MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                   // IQueryable q = query.Provider.CreateQuery(methodCall);
                   //list = ((IQueryable<T_Position>)q);
				   list = ((IQueryable<T_Position>)query);
                }
				else if (AssoID == 0)
                {
                   IQueryable query = db.T_Positions;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_Position), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_Position, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_Position>)q);
                }
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_Position>(User,list, "T_Position",caller);
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
			IQueryable<T_Position> list = db.T_Positions;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_Positions;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_Position), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_Position, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_Position>)q);
                }
            }
			var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
        }
[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValueMobile(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_Position> list = db.T_Positions;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
				try
                {
					Nullable<long> AssoID = Convert.ToInt64(AssociationID);
					if (AssoID != null && AssoID > 0)
					{
						IQueryable query = db.T_Positions;
						Type[] exprArgTypes = { query.ElementType };
						string propToWhere = AssoNameWithParent;
						ParameterExpression p = Expression.Parameter(typeof(T_Position), "p");
						MemberExpression member = Expression.PropertyOrField(p, propToWhere);
						LambdaExpression lambda = Expression.Lambda<Func<T_Position, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
						MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
						IQueryable q = query.Provider.CreateQuery(methodCall);
						list = ((IQueryable<T_Position>)q).Take(20);
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
           list = _fad.FilterDropdown<T_Position>(User,list, "T_Position",caller);
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
            IQueryable<T_Position> list = db.T_Positions;
            if (!string.IsNullOrEmpty(propNameBR))
            {
				//added new code (Remove old code if everything works)
				var result = list.Select("new(Id," + propNameBR + " as value)");
                return Json(result, JsonRequestBehavior.AllowGet);
				//
                ParameterExpression param = Expression.Parameter(typeof(T_Position), "d");
                //bulid expression tree:data.Field1
                var Property = typeof(T_Position).GetProperty(propNameBR);
                Expression selector = Expression.Property(param, Property);
                Expression pred = Expression.Lambda(selector, param);
                //bulid expression tree:Select(d=>d.Field1)
                var targetType = Property.PropertyType;
                if (targetType.GetGenericArguments().Count() > 0)
                {
                    if (targetType.GetGenericArguments()[0].Name == "DateTime")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select", 
                        new Type[] { typeof(T_Position), typeof(DateTime?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<DateTime?> query = list.Provider.CreateQuery<DateTime?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (targetType.GetGenericArguments()[0].Name == "Decimal")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Position), typeof(decimal?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<decimal?> query = list.Provider.CreateQuery<decimal?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Boolean")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Position), typeof(bool?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<bool?> query = list.Provider.CreateQuery<bool?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int32")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Position), typeof(Int32?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int32?> query = list.Provider.CreateQuery<Int32?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int64")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Position), typeof(Int64?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int64?> query = list.Provider.CreateQuery<Int64?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Double")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Position), typeof(double?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<double?> query = list.Provider.CreateQuery<double?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    Expression expr = Expression.Call(typeof(Queryable), "Select",
                            new Type[] { typeof(T_Position), typeof(string) }, Expression.Constant(list.AsQueryable()), pred);
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
			IQueryable<T_Position> list = db.T_Positions;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                IQueryable query = db.T_Positions;
                Type[] exprArgTypes = { query.ElementType };
                string propToWhere = AssoNameWithParent;
                var AssoIDs = AssociationID.Split(',').ToList();
                List<ParameterExpression> paramList = new List<ParameterExpression>();
                paramList.Add(Expression.Parameter(typeof(T_Position), "p"));
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
                list = ((IQueryable<T_Position>)q);
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_Position>(User, list, "T_Position", null);
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

			if (!((CustomPrincipal)User).CanUseVerb("ImportExcel", "T_Position", User) || !User.CanAdd("T_Position"))
            {
                return RedirectToAction("Index", "Error");
            }
            //ViewBag.IsMapping = (db.ImportConfigurations.Where(p => p.Name == "T_Position")).Count() > 0 ? true : false;
            var lstMappings = db.ImportConfigurations.Where(p => p.Name == "T_Position").ToList();
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
                    var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_Position");
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
                        typeName = "T_Position";
                        //var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        //long idMapping = Convert.ToInt64(collection["ListOfMappings"]);
						string idMapping = collection["ListOfMappings"];
                        string ExistsColumnMappingName = string.Empty;
                        string mappingName = idMapping; //db.ImportConfigurations.Where(p => p.Name == typeName && p.Id == idMapping && !(string.IsNullOrEmpty(p.SheetColumn))).FirstOrDefault().MappingName;
                        var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && p.MappingName == mappingName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        if (collection["DefaultMapping"] == "on")
                        {
                            var lstMapping = db.ImportConfigurations.Where(p => p.Name == "T_Position" && p.IsDefaultMapping);
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
                        DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Positions";
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
                                										 case "T_FacilityAssignedToID":
										 var t_facilityassignedtoId = db.T_Facilitys.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_facilityassignedtoId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_TypeOfPositionID":
										 var t_typeofpositionId = db.T_PositionTypes.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_typeofpositionId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_AssociatedPositionStatusID":
										 var t_associatedpositionstatusId = db.T_Positionstatuss.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_associatedpositionstatusId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionIdentifierID":
										 var t_positionidentifierId = db.T_PositionLevels.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionidentifierId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionWorkingTitleAssociationID":
										 var t_positionworkingtitleassociationId = db.T_WorkingTitles.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionworkingtitleassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionRoleCodeID":
										 var t_positionrolecodeId = db.T_RoleCodes.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionrolecodeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionSOCCodeID":
										 var t_positionsoccodeId = db.T_SocCodes.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionsoccodeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionClassCodeID":
										 var t_positionclasscodeId = db.T_ClassCodes.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionclasscodeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_WorkersCompCodePositionID":
										 var t_workerscompcodepositionId = db.T_WCCodes.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_workerscompcodepositionId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionCostCenterAssociationID":
										 var t_positioncostcenterassociationId = db.T_CostCenters.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positioncostcenterassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionShiftMealTimeID":
										 var t_positionshiftmealtimeId = db.T_ShiftMealTimes.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionshiftmealtimeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionShiftTimeID":
										 var t_positionshifttimeId = db.T_ShiftTimes.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionshifttimeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionShiftDurationID":
										 var t_positionshiftdurationId = db.T_ShiftDurations.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionshiftdurationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionOvertimeEligibilityID":
										 var t_positionovertimeeligibilityId = db.T_OvertimeEligibilitys.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionovertimeeligibilityId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionStatusforPostingID":
										 var t_positionstatusforpostingId = db.T_PositionPostStatuss.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_positionstatusforpostingId == null)
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
			string typename = "T_Position";
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
                DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Positions";
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
                var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_Position");
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
                                										 case "T_FacilityAssignedToID":
										 var strPropertyT_FacilityAssignedTo = lstEntityProp.FirstOrDefault(p => p.Key == "T_FacilityAssignedToID").Value;
										 ModelReflector.Property propT_FacilityAssignedTo = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Facility").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_FacilityAssignedTo);
										 //var elementTypeT_FacilityAssignedTo = db.T_Facilitys.ElementType;
										 //var propertyInfoT_FacilityAssignedTo = elementTypeT_FacilityAssignedTo.GetProperty(propT_FacilityAssignedTo.Name);
										 // var t_facilityassignedtoId = db.T_Facilitys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_FacilityAssignedTo.GetValue(p, null)) == assovalue);
										 var t_facilityassignedtoId = db.T_Facilitys.Where(propT_FacilityAssignedTo.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_facilityassignedtoId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_TypeOfPositionID":
										 var strPropertyT_TypeOfPosition = lstEntityProp.FirstOrDefault(p => p.Key == "T_TypeOfPositionID").Value;
										 ModelReflector.Property propT_TypeOfPosition = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_PositionType").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_TypeOfPosition);
										 //var elementTypeT_TypeOfPosition = db.T_PositionTypes.ElementType;
										 //var propertyInfoT_TypeOfPosition = elementTypeT_TypeOfPosition.GetProperty(propT_TypeOfPosition.Name);
										 // var t_typeofpositionId = db.T_PositionTypes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_TypeOfPosition.GetValue(p, null)) == assovalue);
										 var t_typeofpositionId = db.T_PositionTypes.Where(propT_TypeOfPosition.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_typeofpositionId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_AssociatedPositionStatusID":
										 var strPropertyT_AssociatedPositionStatus = lstEntityProp.FirstOrDefault(p => p.Key == "T_AssociatedPositionStatusID").Value;
										 ModelReflector.Property propT_AssociatedPositionStatus = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Positionstatus").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_AssociatedPositionStatus);
										 //var elementTypeT_AssociatedPositionStatus = db.T_Positionstatuss.ElementType;
										 //var propertyInfoT_AssociatedPositionStatus = elementTypeT_AssociatedPositionStatus.GetProperty(propT_AssociatedPositionStatus.Name);
										 // var t_associatedpositionstatusId = db.T_Positionstatuss.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_AssociatedPositionStatus.GetValue(p, null)) == assovalue);
										 var t_associatedpositionstatusId = db.T_Positionstatuss.Where(propT_AssociatedPositionStatus.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_associatedpositionstatusId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionIdentifierID":
										 var strPropertyT_PositionIdentifier = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionIdentifierID").Value;
										 ModelReflector.Property propT_PositionIdentifier = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_PositionLevel").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionIdentifier);
										 //var elementTypeT_PositionIdentifier = db.T_PositionLevels.ElementType;
										 //var propertyInfoT_PositionIdentifier = elementTypeT_PositionIdentifier.GetProperty(propT_PositionIdentifier.Name);
										 // var t_positionidentifierId = db.T_PositionLevels.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionIdentifier.GetValue(p, null)) == assovalue);
										 var t_positionidentifierId = db.T_PositionLevels.Where(propT_PositionIdentifier.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionidentifierId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionWorkingTitleAssociationID":
										 var strPropertyT_PositionWorkingTitleAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionWorkingTitleAssociationID").Value;
										 ModelReflector.Property propT_PositionWorkingTitleAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_WorkingTitle").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionWorkingTitleAssociation);
										 //var elementTypeT_PositionWorkingTitleAssociation = db.T_WorkingTitles.ElementType;
										 //var propertyInfoT_PositionWorkingTitleAssociation = elementTypeT_PositionWorkingTitleAssociation.GetProperty(propT_PositionWorkingTitleAssociation.Name);
										 // var t_positionworkingtitleassociationId = db.T_WorkingTitles.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionWorkingTitleAssociation.GetValue(p, null)) == assovalue);
										 var t_positionworkingtitleassociationId = db.T_WorkingTitles.Where(propT_PositionWorkingTitleAssociation.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionworkingtitleassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionRoleCodeID":
										 var strPropertyT_PositionRoleCode = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionRoleCodeID").Value;
										 ModelReflector.Property propT_PositionRoleCode = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_RoleCode").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionRoleCode);
										 //var elementTypeT_PositionRoleCode = db.T_RoleCodes.ElementType;
										 //var propertyInfoT_PositionRoleCode = elementTypeT_PositionRoleCode.GetProperty(propT_PositionRoleCode.Name);
										 // var t_positionrolecodeId = db.T_RoleCodes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionRoleCode.GetValue(p, null)) == assovalue);
										 var t_positionrolecodeId = db.T_RoleCodes.Where(propT_PositionRoleCode.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionrolecodeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionSOCCodeID":
										 var strPropertyT_PositionSOCCode = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionSOCCodeID").Value;
										 ModelReflector.Property propT_PositionSOCCode = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_SocCode").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionSOCCode);
										 //var elementTypeT_PositionSOCCode = db.T_SocCodes.ElementType;
										 //var propertyInfoT_PositionSOCCode = elementTypeT_PositionSOCCode.GetProperty(propT_PositionSOCCode.Name);
										 // var t_positionsoccodeId = db.T_SocCodes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionSOCCode.GetValue(p, null)) == assovalue);
										 var t_positionsoccodeId = db.T_SocCodes.Where(propT_PositionSOCCode.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionsoccodeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionClassCodeID":
										 var strPropertyT_PositionClassCode = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionClassCodeID").Value;
										 ModelReflector.Property propT_PositionClassCode = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ClassCode").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionClassCode);
										 //var elementTypeT_PositionClassCode = db.T_ClassCodes.ElementType;
										 //var propertyInfoT_PositionClassCode = elementTypeT_PositionClassCode.GetProperty(propT_PositionClassCode.Name);
										 // var t_positionclasscodeId = db.T_ClassCodes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionClassCode.GetValue(p, null)) == assovalue);
										 var t_positionclasscodeId = db.T_ClassCodes.Where(propT_PositionClassCode.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionclasscodeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_WorkersCompCodePositionID":
										 var strPropertyT_WorkersCompCodePosition = lstEntityProp.FirstOrDefault(p => p.Key == "T_WorkersCompCodePositionID").Value;
										 ModelReflector.Property propT_WorkersCompCodePosition = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_WCCode").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_WorkersCompCodePosition);
										 //var elementTypeT_WorkersCompCodePosition = db.T_WCCodes.ElementType;
										 //var propertyInfoT_WorkersCompCodePosition = elementTypeT_WorkersCompCodePosition.GetProperty(propT_WorkersCompCodePosition.Name);
										 // var t_workerscompcodepositionId = db.T_WCCodes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_WorkersCompCodePosition.GetValue(p, null)) == assovalue);
										 var t_workerscompcodepositionId = db.T_WCCodes.Where(propT_WorkersCompCodePosition.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_workerscompcodepositionId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionCostCenterAssociationID":
										 var strPropertyT_PositionCostCenterAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionCostCenterAssociationID").Value;
										 ModelReflector.Property propT_PositionCostCenterAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_CostCenter").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionCostCenterAssociation);
										 //var elementTypeT_PositionCostCenterAssociation = db.T_CostCenters.ElementType;
										 //var propertyInfoT_PositionCostCenterAssociation = elementTypeT_PositionCostCenterAssociation.GetProperty(propT_PositionCostCenterAssociation.Name);
										 // var t_positioncostcenterassociationId = db.T_CostCenters.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionCostCenterAssociation.GetValue(p, null)) == assovalue);
										 var t_positioncostcenterassociationId = db.T_CostCenters.Where(propT_PositionCostCenterAssociation.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positioncostcenterassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionShiftMealTimeID":
										 var strPropertyT_PositionShiftMealTime = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionShiftMealTimeID").Value;
										 ModelReflector.Property propT_PositionShiftMealTime = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ShiftMealTime").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionShiftMealTime);
										 //var elementTypeT_PositionShiftMealTime = db.T_ShiftMealTimes.ElementType;
										 //var propertyInfoT_PositionShiftMealTime = elementTypeT_PositionShiftMealTime.GetProperty(propT_PositionShiftMealTime.Name);
										 // var t_positionshiftmealtimeId = db.T_ShiftMealTimes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionShiftMealTime.GetValue(p, null)) == assovalue);
										 var t_positionshiftmealtimeId = db.T_ShiftMealTimes.Where(propT_PositionShiftMealTime.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionshiftmealtimeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionShiftTimeID":
										 var strPropertyT_PositionShiftTime = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionShiftTimeID").Value;
										 ModelReflector.Property propT_PositionShiftTime = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ShiftTime").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionShiftTime);
										 //var elementTypeT_PositionShiftTime = db.T_ShiftTimes.ElementType;
										 //var propertyInfoT_PositionShiftTime = elementTypeT_PositionShiftTime.GetProperty(propT_PositionShiftTime.Name);
										 // var t_positionshifttimeId = db.T_ShiftTimes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionShiftTime.GetValue(p, null)) == assovalue);
										 var t_positionshifttimeId = db.T_ShiftTimes.Where(propT_PositionShiftTime.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionshifttimeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionShiftDurationID":
										 var strPropertyT_PositionShiftDuration = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionShiftDurationID").Value;
										 ModelReflector.Property propT_PositionShiftDuration = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ShiftDuration").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionShiftDuration);
										 //var elementTypeT_PositionShiftDuration = db.T_ShiftDurations.ElementType;
										 //var propertyInfoT_PositionShiftDuration = elementTypeT_PositionShiftDuration.GetProperty(propT_PositionShiftDuration.Name);
										 // var t_positionshiftdurationId = db.T_ShiftDurations.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionShiftDuration.GetValue(p, null)) == assovalue);
										 var t_positionshiftdurationId = db.T_ShiftDurations.Where(propT_PositionShiftDuration.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionshiftdurationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionOvertimeEligibilityID":
										 var strPropertyT_PositionOvertimeEligibility = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionOvertimeEligibilityID").Value;
										 ModelReflector.Property propT_PositionOvertimeEligibility = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_OvertimeEligibility").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionOvertimeEligibility);
										 //var elementTypeT_PositionOvertimeEligibility = db.T_OvertimeEligibilitys.ElementType;
										 //var propertyInfoT_PositionOvertimeEligibility = elementTypeT_PositionOvertimeEligibility.GetProperty(propT_PositionOvertimeEligibility.Name);
										 // var t_positionovertimeeligibilityId = db.T_OvertimeEligibilitys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionOvertimeEligibility.GetValue(p, null)) == assovalue);
										 var t_positionovertimeeligibilityId = db.T_OvertimeEligibilitys.Where(propT_PositionOvertimeEligibility.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionovertimeeligibilityId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PositionStatusforPostingID":
										 var strPropertyT_PositionStatusforPosting = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionStatusforPostingID").Value;
										 ModelReflector.Property propT_PositionStatusforPosting = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_PositionPostStatus").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionStatusforPosting);
										 //var elementTypeT_PositionStatusforPosting = db.T_PositionPostStatuss.ElementType;
										 //var propertyInfoT_PositionStatusforPosting = elementTypeT_PositionStatusforPosting.GetProperty(propT_PositionStatusforPosting.Name);
										 // var t_positionstatusforpostingId = db.T_PositionPostStatuss.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionStatusforPosting.GetValue(p, null)) == assovalue);
										 var t_positionstatusforpostingId = db.T_PositionPostStatuss.Where(propT_PositionStatusforPosting.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_positionstatusforpostingId == null)
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
                        T_Position model = new T_Position();
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
    case "T_PositionNumber":
    model.T_PositionNumber = columnValue;
	break;
    case "T_PositionFill":
    model.T_PositionFill = Int32.Parse(columnValue);
	break;
    case "T_QuasiFill":
    model.T_QuasiFill = Boolean.Parse(columnValue);
	break;
    case "T_EffectiveDate":
    model.T_EffectiveDate = DateTime.Parse(columnValue);
	break;
    case "T_SalaryBand":
    model.T_SalaryBand = columnValue;
	break;
    case "T_CardApprvr":
    model.T_CardApprvr = columnValue;
	break;
    case "T_ShiftStart":
    model.T_ShiftStart = DateTime.Parse(columnValue);
	break;
    case "T_ShiftEnd":
    model.T_ShiftEnd = DateTime.Parse(columnValue);
	break;
    case "T_DualIncumbent":
    model.T_DualIncumbent = Boolean.Parse(columnValue);
	break;
    case "T_DualIncumbentStartDate":
    model.T_DualIncumbentStartDate = DateTime.Parse(columnValue);
	break;
    case "T_DualIncumbentEndDate":
    model.T_DualIncumbentEndDate = DateTime.Parse(columnValue);
	break;
    case "T_Funded":
    model.T_Funded = Boolean.Parse(columnValue);
	break;
    case "T_EstablishedDate":
    model.T_EstablishedDate = DateTime.Parse(columnValue);
	break;
    case "T_AbolishDate":
    model.T_AbolishDate = DateTime.Parse(columnValue);
	break;
					 case "T_FacilityAssignedToID":
		 dynamic t_facilityassignedtoId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_FacilityAssignedTo = lstEntityProp.FirstOrDefault(p => p.Key == "T_FacilityAssignedToID").Value;
			 ModelReflector.Property propT_FacilityAssignedTo = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Facility").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_FacilityAssignedTo);
			 //var elementTypeT_FacilityAssignedTo = db.T_Facilitys.ElementType;
			 //var propertyInfoT_FacilityAssignedTo = elementTypeT_FacilityAssignedTo.GetProperty(propT_FacilityAssignedTo.Name);			 
			 //t_facilityassignedtoId = db.T_Facilitys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_FacilityAssignedTo.GetValue(p, null)) == columnValue);
			 t_facilityassignedtoId = db.T_Facilitys.Where(propT_FacilityAssignedTo.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_facilityassignedtoId = db.T_Facilitys.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_facilityassignedtoId != null)
			model.T_FacilityAssignedToID = t_facilityassignedtoId.Id;
		  else
			{
				if ((collection["T_FacilityAssignedToID"].ToString() == "true,false"))
				{
					try
					{
						T_Facility objT_Facility = new T_Facility();
						objT_Facility.T_FacilityCode  = (columnValue);
						db.T_Facilitys.Add(objT_Facility);
						db.SaveChanges();
						model.T_FacilityAssignedToID = objT_Facility.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_TypeOfPositionID":
		 dynamic t_typeofpositionId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_TypeOfPosition = lstEntityProp.FirstOrDefault(p => p.Key == "T_TypeOfPositionID").Value;
			 ModelReflector.Property propT_TypeOfPosition = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_PositionType").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_TypeOfPosition);
			 //var elementTypeT_TypeOfPosition = db.T_PositionTypes.ElementType;
			 //var propertyInfoT_TypeOfPosition = elementTypeT_TypeOfPosition.GetProperty(propT_TypeOfPosition.Name);			 
			 //t_typeofpositionId = db.T_PositionTypes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_TypeOfPosition.GetValue(p, null)) == columnValue);
			 t_typeofpositionId = db.T_PositionTypes.Where(propT_TypeOfPosition.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_typeofpositionId = db.T_PositionTypes.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_typeofpositionId != null)
			model.T_TypeOfPositionID = t_typeofpositionId.Id;
		  else
			{
				if ((collection["T_TypeOfPositionID"].ToString() == "true,false"))
				{
					try
					{
						T_PositionType objT_PositionType = new T_PositionType();
						objT_PositionType.T_Name  = (columnValue);
						db.T_PositionTypes.Add(objT_PositionType);
						db.SaveChanges();
						model.T_TypeOfPositionID = objT_PositionType.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_AssociatedPositionStatusID":
		 dynamic t_associatedpositionstatusId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_AssociatedPositionStatus = lstEntityProp.FirstOrDefault(p => p.Key == "T_AssociatedPositionStatusID").Value;
			 ModelReflector.Property propT_AssociatedPositionStatus = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Positionstatus").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_AssociatedPositionStatus);
			 //var elementTypeT_AssociatedPositionStatus = db.T_Positionstatuss.ElementType;
			 //var propertyInfoT_AssociatedPositionStatus = elementTypeT_AssociatedPositionStatus.GetProperty(propT_AssociatedPositionStatus.Name);			 
			 //t_associatedpositionstatusId = db.T_Positionstatuss.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_AssociatedPositionStatus.GetValue(p, null)) == columnValue);
			 t_associatedpositionstatusId = db.T_Positionstatuss.Where(propT_AssociatedPositionStatus.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_associatedpositionstatusId = db.T_Positionstatuss.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_associatedpositionstatusId != null)
			model.T_AssociatedPositionStatusID = t_associatedpositionstatusId.Id;
		  else
			{
				if ((collection["T_AssociatedPositionStatusID"].ToString() == "true,false"))
				{
					try
					{
						T_Positionstatus objT_Positionstatus = new T_Positionstatus();
						objT_Positionstatus.T_Name  = (columnValue);
						db.T_Positionstatuss.Add(objT_Positionstatus);
						db.SaveChanges();
						model.T_AssociatedPositionStatusID = objT_Positionstatus.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionIdentifierID":
		 dynamic t_positionidentifierId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionIdentifier = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionIdentifierID").Value;
			 ModelReflector.Property propT_PositionIdentifier = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_PositionLevel").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionIdentifier);
			 //var elementTypeT_PositionIdentifier = db.T_PositionLevels.ElementType;
			 //var propertyInfoT_PositionIdentifier = elementTypeT_PositionIdentifier.GetProperty(propT_PositionIdentifier.Name);			 
			 //t_positionidentifierId = db.T_PositionLevels.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionIdentifier.GetValue(p, null)) == columnValue);
			 t_positionidentifierId = db.T_PositionLevels.Where(propT_PositionIdentifier.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionidentifierId = db.T_PositionLevels.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionidentifierId != null)
			model.T_PositionIdentifierID = t_positionidentifierId.Id;
		  else
			{
				if ((collection["T_PositionIdentifierID"].ToString() == "true,false"))
				{
					try
					{
						T_PositionLevel objT_PositionLevel = new T_PositionLevel();
						objT_PositionLevel.T_Name  = (columnValue);
						db.T_PositionLevels.Add(objT_PositionLevel);
						db.SaveChanges();
						model.T_PositionIdentifierID = objT_PositionLevel.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionWorkingTitleAssociationID":
		 dynamic t_positionworkingtitleassociationId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionWorkingTitleAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionWorkingTitleAssociationID").Value;
			 ModelReflector.Property propT_PositionWorkingTitleAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_WorkingTitle").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionWorkingTitleAssociation);
			 //var elementTypeT_PositionWorkingTitleAssociation = db.T_WorkingTitles.ElementType;
			 //var propertyInfoT_PositionWorkingTitleAssociation = elementTypeT_PositionWorkingTitleAssociation.GetProperty(propT_PositionWorkingTitleAssociation.Name);			 
			 //t_positionworkingtitleassociationId = db.T_WorkingTitles.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionWorkingTitleAssociation.GetValue(p, null)) == columnValue);
			 t_positionworkingtitleassociationId = db.T_WorkingTitles.Where(propT_PositionWorkingTitleAssociation.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionworkingtitleassociationId = db.T_WorkingTitles.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionworkingtitleassociationId != null)
			model.T_PositionWorkingTitleAssociationID = t_positionworkingtitleassociationId.Id;
		  else
			{
				if ((collection["T_PositionWorkingTitleAssociationID"].ToString() == "true,false"))
				{
					try
					{
						T_WorkingTitle objT_WorkingTitle = new T_WorkingTitle();
						objT_WorkingTitle.T_Name  = (columnValue);
						db.T_WorkingTitles.Add(objT_WorkingTitle);
						db.SaveChanges();
						model.T_PositionWorkingTitleAssociationID = objT_WorkingTitle.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionRoleCodeID":
		 dynamic t_positionrolecodeId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionRoleCode = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionRoleCodeID").Value;
			 ModelReflector.Property propT_PositionRoleCode = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_RoleCode").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionRoleCode);
			 //var elementTypeT_PositionRoleCode = db.T_RoleCodes.ElementType;
			 //var propertyInfoT_PositionRoleCode = elementTypeT_PositionRoleCode.GetProperty(propT_PositionRoleCode.Name);			 
			 //t_positionrolecodeId = db.T_RoleCodes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionRoleCode.GetValue(p, null)) == columnValue);
			 t_positionrolecodeId = db.T_RoleCodes.Where(propT_PositionRoleCode.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionrolecodeId = db.T_RoleCodes.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionrolecodeId != null)
			model.T_PositionRoleCodeID = t_positionrolecodeId.Id;
		  else
			{
				if ((collection["T_PositionRoleCodeID"].ToString() == "true,false"))
				{
					try
					{
						T_RoleCode objT_RoleCode = new T_RoleCode();
						objT_RoleCode.T_Code  = (columnValue);
				 try { objT_RoleCode.T_Title =(columnValue); }
                 catch { objT_RoleCode.T_Title = default(string); }
						db.T_RoleCodes.Add(objT_RoleCode);
						db.SaveChanges();
						model.T_PositionRoleCodeID = objT_RoleCode.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionSOCCodeID":
		 dynamic t_positionsoccodeId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionSOCCode = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionSOCCodeID").Value;
			 ModelReflector.Property propT_PositionSOCCode = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_SocCode").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionSOCCode);
			 //var elementTypeT_PositionSOCCode = db.T_SocCodes.ElementType;
			 //var propertyInfoT_PositionSOCCode = elementTypeT_PositionSOCCode.GetProperty(propT_PositionSOCCode.Name);			 
			 //t_positionsoccodeId = db.T_SocCodes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionSOCCode.GetValue(p, null)) == columnValue);
			 t_positionsoccodeId = db.T_SocCodes.Where(propT_PositionSOCCode.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionsoccodeId = db.T_SocCodes.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionsoccodeId != null)
			model.T_PositionSOCCodeID = t_positionsoccodeId.Id;
		  else
			{
				if ((collection["T_PositionSOCCodeID"].ToString() == "true,false"))
				{
					try
					{
						T_SocCode objT_SocCode = new T_SocCode();
						objT_SocCode.T_Code  = (columnValue);
						db.T_SocCodes.Add(objT_SocCode);
						db.SaveChanges();
						model.T_PositionSOCCodeID = objT_SocCode.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionClassCodeID":
		 dynamic t_positionclasscodeId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionClassCode = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionClassCodeID").Value;
			 ModelReflector.Property propT_PositionClassCode = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ClassCode").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionClassCode);
			 //var elementTypeT_PositionClassCode = db.T_ClassCodes.ElementType;
			 //var propertyInfoT_PositionClassCode = elementTypeT_PositionClassCode.GetProperty(propT_PositionClassCode.Name);			 
			 //t_positionclasscodeId = db.T_ClassCodes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionClassCode.GetValue(p, null)) == columnValue);
			 t_positionclasscodeId = db.T_ClassCodes.Where(propT_PositionClassCode.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionclasscodeId = db.T_ClassCodes.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionclasscodeId != null)
			model.T_PositionClassCodeID = t_positionclasscodeId.Id;
		  else
			{
				if ((collection["T_PositionClassCodeID"].ToString() == "true,false"))
				{
					try
					{
						T_ClassCode objT_ClassCode = new T_ClassCode();
						objT_ClassCode.T_Code  = (columnValue);
						db.T_ClassCodes.Add(objT_ClassCode);
						db.SaveChanges();
						model.T_PositionClassCodeID = objT_ClassCode.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_WorkersCompCodePositionID":
		 dynamic t_workerscompcodepositionId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_WorkersCompCodePosition = lstEntityProp.FirstOrDefault(p => p.Key == "T_WorkersCompCodePositionID").Value;
			 ModelReflector.Property propT_WorkersCompCodePosition = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_WCCode").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_WorkersCompCodePosition);
			 //var elementTypeT_WorkersCompCodePosition = db.T_WCCodes.ElementType;
			 //var propertyInfoT_WorkersCompCodePosition = elementTypeT_WorkersCompCodePosition.GetProperty(propT_WorkersCompCodePosition.Name);			 
			 //t_workerscompcodepositionId = db.T_WCCodes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_WorkersCompCodePosition.GetValue(p, null)) == columnValue);
			 t_workerscompcodepositionId = db.T_WCCodes.Where(propT_WorkersCompCodePosition.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_workerscompcodepositionId = db.T_WCCodes.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_workerscompcodepositionId != null)
			model.T_WorkersCompCodePositionID = t_workerscompcodepositionId.Id;
		  else
			{
				if ((collection["T_WorkersCompCodePositionID"].ToString() == "true,false"))
				{
					try
					{
						T_WCCode objT_WCCode = new T_WCCode();
						objT_WCCode.T_Name  = (columnValue);
						db.T_WCCodes.Add(objT_WCCode);
						db.SaveChanges();
						model.T_WorkersCompCodePositionID = objT_WCCode.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionCostCenterAssociationID":
		 dynamic t_positioncostcenterassociationId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionCostCenterAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionCostCenterAssociationID").Value;
			 ModelReflector.Property propT_PositionCostCenterAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_CostCenter").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionCostCenterAssociation);
			 //var elementTypeT_PositionCostCenterAssociation = db.T_CostCenters.ElementType;
			 //var propertyInfoT_PositionCostCenterAssociation = elementTypeT_PositionCostCenterAssociation.GetProperty(propT_PositionCostCenterAssociation.Name);			 
			 //t_positioncostcenterassociationId = db.T_CostCenters.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionCostCenterAssociation.GetValue(p, null)) == columnValue);
			 t_positioncostcenterassociationId = db.T_CostCenters.Where(propT_PositionCostCenterAssociation.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positioncostcenterassociationId = db.T_CostCenters.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positioncostcenterassociationId != null)
			model.T_PositionCostCenterAssociationID = t_positioncostcenterassociationId.Id;
		  else
			{
				if ((collection["T_PositionCostCenterAssociationID"].ToString() == "true,false"))
				{
					try
					{
						T_CostCenter objT_CostCenter = new T_CostCenter();
						objT_CostCenter.T_CC  = (columnValue);
						db.T_CostCenters.Add(objT_CostCenter);
						db.SaveChanges();
						model.T_PositionCostCenterAssociationID = objT_CostCenter.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionShiftMealTimeID":
		 dynamic t_positionshiftmealtimeId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionShiftMealTime = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionShiftMealTimeID").Value;
			 ModelReflector.Property propT_PositionShiftMealTime = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ShiftMealTime").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionShiftMealTime);
			 //var elementTypeT_PositionShiftMealTime = db.T_ShiftMealTimes.ElementType;
			 //var propertyInfoT_PositionShiftMealTime = elementTypeT_PositionShiftMealTime.GetProperty(propT_PositionShiftMealTime.Name);			 
			 //t_positionshiftmealtimeId = db.T_ShiftMealTimes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionShiftMealTime.GetValue(p, null)) == columnValue);
			 t_positionshiftmealtimeId = db.T_ShiftMealTimes.Where(propT_PositionShiftMealTime.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionshiftmealtimeId = db.T_ShiftMealTimes.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionshiftmealtimeId != null)
			model.T_PositionShiftMealTimeID = t_positionshiftmealtimeId.Id;
		  else
			{
				if ((collection["T_PositionShiftMealTimeID"].ToString() == "true,false"))
				{
					try
					{
						T_ShiftMealTime objT_ShiftMealTime = new T_ShiftMealTime();
						objT_ShiftMealTime.T_MealTime  = (columnValue);
						db.T_ShiftMealTimes.Add(objT_ShiftMealTime);
						db.SaveChanges();
						model.T_PositionShiftMealTimeID = objT_ShiftMealTime.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionShiftTimeID":
		 dynamic t_positionshifttimeId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionShiftTime = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionShiftTimeID").Value;
			 ModelReflector.Property propT_PositionShiftTime = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ShiftTime").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionShiftTime);
			 //var elementTypeT_PositionShiftTime = db.T_ShiftTimes.ElementType;
			 //var propertyInfoT_PositionShiftTime = elementTypeT_PositionShiftTime.GetProperty(propT_PositionShiftTime.Name);			 
			 //t_positionshifttimeId = db.T_ShiftTimes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionShiftTime.GetValue(p, null)) == columnValue);
			 t_positionshifttimeId = db.T_ShiftTimes.Where(propT_PositionShiftTime.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionshifttimeId = db.T_ShiftTimes.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionshifttimeId != null)
			model.T_PositionShiftTimeID = t_positionshifttimeId.Id;
		  else
			{
				if ((collection["T_PositionShiftTimeID"].ToString() == "true,false"))
				{
					try
					{
						T_ShiftTime objT_ShiftTime = new T_ShiftTime();
						objT_ShiftTime.T_Name  = (columnValue);
						db.T_ShiftTimes.Add(objT_ShiftTime);
						db.SaveChanges();
						model.T_PositionShiftTimeID = objT_ShiftTime.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionShiftDurationID":
		 dynamic t_positionshiftdurationId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionShiftDuration = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionShiftDurationID").Value;
			 ModelReflector.Property propT_PositionShiftDuration = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ShiftDuration").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionShiftDuration);
			 //var elementTypeT_PositionShiftDuration = db.T_ShiftDurations.ElementType;
			 //var propertyInfoT_PositionShiftDuration = elementTypeT_PositionShiftDuration.GetProperty(propT_PositionShiftDuration.Name);			 
			 //t_positionshiftdurationId = db.T_ShiftDurations.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionShiftDuration.GetValue(p, null)) == columnValue);
			 t_positionshiftdurationId = db.T_ShiftDurations.Where(propT_PositionShiftDuration.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionshiftdurationId = db.T_ShiftDurations.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionshiftdurationId != null)
			model.T_PositionShiftDurationID = t_positionshiftdurationId.Id;
		  else
			{
				if ((collection["T_PositionShiftDurationID"].ToString() == "true,false"))
				{
					try
					{
						T_ShiftDuration objT_ShiftDuration = new T_ShiftDuration();
						objT_ShiftDuration.T_Name  = (columnValue);
						db.T_ShiftDurations.Add(objT_ShiftDuration);
						db.SaveChanges();
						model.T_PositionShiftDurationID = objT_ShiftDuration.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionOvertimeEligibilityID":
		 dynamic t_positionovertimeeligibilityId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionOvertimeEligibility = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionOvertimeEligibilityID").Value;
			 ModelReflector.Property propT_PositionOvertimeEligibility = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_OvertimeEligibility").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionOvertimeEligibility);
			 //var elementTypeT_PositionOvertimeEligibility = db.T_OvertimeEligibilitys.ElementType;
			 //var propertyInfoT_PositionOvertimeEligibility = elementTypeT_PositionOvertimeEligibility.GetProperty(propT_PositionOvertimeEligibility.Name);			 
			 //t_positionovertimeeligibilityId = db.T_OvertimeEligibilitys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionOvertimeEligibility.GetValue(p, null)) == columnValue);
			 t_positionovertimeeligibilityId = db.T_OvertimeEligibilitys.Where(propT_PositionOvertimeEligibility.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionovertimeeligibilityId = db.T_OvertimeEligibilitys.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionovertimeeligibilityId != null)
			model.T_PositionOvertimeEligibilityID = t_positionovertimeeligibilityId.Id;
		  else
			{
				if ((collection["T_PositionOvertimeEligibilityID"].ToString() == "true,false"))
				{
					try
					{
						T_OvertimeEligibility objT_OvertimeEligibility = new T_OvertimeEligibility();
						objT_OvertimeEligibility.T_Name  = (columnValue);
						db.T_OvertimeEligibilitys.Add(objT_OvertimeEligibility);
						db.SaveChanges();
						model.T_PositionOvertimeEligibilityID = objT_OvertimeEligibility.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_PositionStatusforPostingID":
		 dynamic t_positionstatusforpostingId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PositionStatusforPosting = lstEntityProp.FirstOrDefault(p => p.Key == "T_PositionStatusforPostingID").Value;
			 ModelReflector.Property propT_PositionStatusforPosting = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_PositionPostStatus").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PositionStatusforPosting);
			 //var elementTypeT_PositionStatusforPosting = db.T_PositionPostStatuss.ElementType;
			 //var propertyInfoT_PositionStatusforPosting = elementTypeT_PositionStatusforPosting.GetProperty(propT_PositionStatusforPosting.Name);			 
			 //t_positionstatusforpostingId = db.T_PositionPostStatuss.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PositionStatusforPosting.GetValue(p, null)) == columnValue);
			 t_positionstatusforpostingId = db.T_PositionPostStatuss.Where(propT_PositionStatusforPosting.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_positionstatusforpostingId = db.T_PositionPostStatuss.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_positionstatusforpostingId != null)
			model.T_PositionStatusforPostingID = t_positionstatusforpostingId.Id;
		  else
			{
				if ((collection["T_PositionStatusforPostingID"].ToString() == "true,false"))
				{
					try
					{
						T_PositionPostStatus objT_PositionPostStatus = new T_PositionPostStatus();
						objT_PositionPostStatus.T_Name  = (columnValue);
						db.T_PositionPostStatuss.Add(objT_PositionPostStatus);
						db.SaveChanges();
						model.T_PositionStatusforPostingID = objT_PositionPostStatus.Id;
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
			 if (model.T_EstablishedDate == DateTime.MinValue)
                            model.T_EstablishedDate =  DateTime.UtcNow;
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
									db.T_Positions.Add(model);
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
		public bool ValidateModel(T_Position validate)
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
                var obj1 = db1.T_Positions.Find(Id);
                System.Reflection.PropertyInfo[] properties = (obj1.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
                var Property = properties.FirstOrDefault(p => p.Name == PropName);
                object PropValue = Property.GetValue(obj1, null);
                return PropValue;
				            }
            catch { return null; }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetReadOnlyProperties(T_Position OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Position").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.ReadOnlyPropertiesRule(OModel, BR, "T_Position");
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
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Position");
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
        public JsonResult GetMandatoryProperties(T_Position OModel, string ruleType)
        {
            Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Position").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
                    if (ruleType == "OnCreate")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 2).ToList();
                    else if (ruleType == "OnEdit")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 1).ToList();
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_Position");
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
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Position");
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
        public JsonResult GetUIAlertBusinessRules(T_Position OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Position").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.UIAlertRule(OModel, BR, "T_Position");
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
        public JsonResult GetValidateBeforeSaveProperties(T_Position OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Position").ToList();
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
                    var ResultOfBusinessRules = db.ValidateBeforeSavePropertiesRule(OModel, BR, "T_Position",state);
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
                                    var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Position");
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
        public JsonResult GetLockBusinessRules(T_Position OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            //string RulesApplied = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Position").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.LockEntityRule(OModel, BR, "T_Position");
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
		private List<string> CheckMandatoryProperties(T_Position OModel)
        {
            List<string> result = new List<string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Position").ToList();
                Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
                if (BR != null && BR.Count > 0)
                {
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_Position");
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
                                var dispName = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Position").Properties.FirstOrDefault(p => p.Name == paramName).DisplayName;
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
            var _Obj = db1.T_Positions.FirstOrDefault(p => p.DisplayValue == displayvalue);
            long outValue;
            if (_Obj != null)
                return Int64.TryParse(_Obj.Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				public long? GetIdFromPropertyValue(string PropName, string PropValue)
        {
            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            IQueryable query = db1.T_Positions;
            Type[] exprArgTypes = { query.ElementType };
            string propToWhere = PropName;
            ParameterExpression p = Expression.Parameter(typeof(T_Position), "p");
            MemberExpression member = Expression.PropertyOrField(p, propToWhere);
            LambdaExpression lambda = null;
            if (PropValue.ToLower().Trim() != "null")
            lambda = Expression.Lambda<Func<T_Position, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(PropValue), member.Type)), p);
            else
                lambda = Expression.Lambda<Func<T_Position, bool>>(Expression.Equal(member, Expression.Constant(null, member.Type)), p);
            MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
            IQueryable q = query.Provider.CreateQuery(methodCall);
            long outValue;
            var list1 = ((IQueryable<T_Position>)q);
            if (list1 != null && list1.Count() > 0)
                return Int64.TryParse(list1.FirstOrDefault().Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPropertyValueByEntityId(long Id, string PropName)
        {
								ApplicationContext db1 = new ApplicationContext(new SystemUser());
            var obj1 = db1.T_Positions.Find(Id);
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
        public JsonResult Check1MThresholdValue(T_Position t_position)
        {
            Dictionary<string, string> msgThreshold = new Dictionary<string, string>();
            return Json(msgThreshold, JsonRequestBehavior.AllowGet);
        }
		//code for verb action security
        public string[] getVerbsName()
        {
            string[] Verbsarr = new string[] { "BulkUpdate","BulkDelete","ImportExcel","ExportExcel"  ,"VacantCalculation" };
            return Verbsarr;
        }
        //
		//code for list of groups
        public string[][] getGroupsName()
        {
            string[][] groupsarr = new string[][] { new string[] {"48913","T_Position48913"},new string[] {"48888","Basic Details"},new string[] {"48890","Position Codes"},new string[] {"48889","Time and Other Details"},new string[] {"48887","Position Status"} };
            return groupsarr;
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCalculationValues(T_Position t_position)
        {
            t_position.setCalculation();
            Dictionary<string, string> Calculations = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_position.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
		    var T_PositionFillProperty = properties.FirstOrDefault(p => p.Name == "T_PositionFill");
            if (T_PositionFillProperty != null)
            {
			  object PropValue = T_PositionFillProperty.GetValue(t_position, null);
				       Calculations.Add("T_PositionFill", Convert.ToString(PropValue));
		            }
            return Json(Calculations, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		//get Templates 
		// select templates 
        public void GetTemplatesForList(string defaultview)
        {
            string pageNameList = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_Position"
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
                                       where s.EntityName == "T_Position"
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
                                       where s.EntityName == "T_Position"
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
                                       where s.EntityName == "T_Position"
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
                                       where s.EntityName == "T_Position"
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
                                       where s.EntityName == "T_Position"
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
                                       where s.EntityName == "T_Position"
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
                                       where s.EntityName == "T_Position"
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
                                       where s.EntityName == "T_Position"
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
        public ActionResult GetDerivedDetails(T_Position t_position, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_position.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
 
			var T_SalaryBandsourceProp = properties.FirstOrDefault(p => p.Name == "T_PositionRoleCodeID");
            if (T_SalaryBandsourceProp != null)
            {
                object sourcePropValue = T_SalaryBandsourceProp.GetValue(t_position, null);
                var Property = properties.FirstOrDefault(p => p.Name == "T_SalaryBand");
                if (Property != null && sourcePropValue != null)
                {
					T_RoleCodeController objController = new T_RoleCodeController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_RoleCodeSalaryBandID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_SalaryBandController InnerController = new T_SalaryBandController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "T_Name");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_SalaryBand"))
                            derivedlist.Add("T_SalaryBand", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_SalaryBand"))
                   derivedlist.Add("T_SalaryBand", "");
            }
            return Json(derivedlist, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDerivedDetailsInline(string host, string value, T_Position t_position, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
 
		if (host == "T_PositionRoleCodeID")
			{
			var T_SalaryBandsourceProp = host;
            if (T_SalaryBandsourceProp != null)
            {
                object sourcePropValue = value;
                if (sourcePropValue != null)
                {
					T_RoleCodeController objController = new T_RoleCodeController();
                    object PropValue = objController.GetPropertyValueByEntityId(Convert.ToInt64(sourcePropValue), "T_RoleCodeSalaryBandID");
                     if (PropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(PropValue)).Data) != "0")
                    {
                       T_SalaryBandController InnerController = new T_SalaryBandController();
					   object InnerPropValue = InnerController.GetPropertyValueByEntityId(Convert.ToInt64(((System.Web.Mvc.JsonResult)(PropValue)).Data), "T_Name");
                        if (InnerPropValue != null && Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data) != "0" && !derivedlist.ContainsKey("T_SalaryBand"))
                            derivedlist.Add("T_SalaryBand", Convert.ToString(((System.Web.Mvc.JsonResult)(InnerPropValue)).Data));
                    }
                }
				if (!derivedlist.ContainsKey("T_SalaryBand"))
                   derivedlist.Add("T_SalaryBand", "");
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

