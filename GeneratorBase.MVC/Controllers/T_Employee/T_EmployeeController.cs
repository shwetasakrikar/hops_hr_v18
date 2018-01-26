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
		private void LoadViewDataForCount(T_Employee t_employee, string AssocType)
        {
        }
		private void LoadViewDataAfterOnEdit(T_Employee t_employee)
        {		
			var T_Langauge_T_ConversationalEmployeeForeignLanguagelist = db.T_Langauges.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage != null)
            {
                var list = T_Langauge_T_ConversationalEmployeeForeignLanguagelist.Union(db.T_Langauges.Where(p => t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage.ToList().Contains(p.Id))).Distinct();
                ViewBag.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = new MultiSelectList(list, "ID", "DisplayValue",t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage);
            }
            else
            {
                ViewBag.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = new MultiSelectList(T_Langauge_T_ConversationalEmployeeForeignLanguagelist, "ID", "DisplayValue");
            }
			var T_Langauge_T_LanguageCertifiedInlist = db.T_Langauges.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn != null)
            {
                var list = T_Langauge_T_LanguageCertifiedInlist.Union(db.T_Langauges.Where(p => t_employee.SelectedT_Langauge_T_LanguageCertifiedIn.ToList().Contains(p.Id))).Distinct();
                ViewBag.SelectedT_Langauge_T_LanguageCertifiedIn = new MultiSelectList(list, "ID", "DisplayValue",t_employee.SelectedT_Langauge_T_LanguageCertifiedIn);
            }
            else
            {
                ViewBag.SelectedT_Langauge_T_LanguageCertifiedIn = new MultiSelectList(T_Langauge_T_LanguageCertifiedInlist, "ID", "DisplayValue");
            }
			 ViewBag.T_EmployeeAtFacilityID = new SelectList(db.T_Facilitys, "ID", "DisplayValue", t_employee.T_EmployeeAtFacilityID);
			 ViewBag.T_EmployeeStatusID = new SelectList(db.T_EmployeeStatusCodes, "ID", "DisplayValue", t_employee.T_EmployeeStatusID);
			 ViewBag.T_CurrentEmployeeEmploymentProfileID = new SelectList(db.T_ServiceRecords, "ID", "DisplayValue", t_employee.T_CurrentEmployeeEmploymentProfileID);
               ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmployeeEmploymentProfileID = new SelectList(db.T_Employees.Take(10).Union(db.T_Employees.Where(p=>p.Id ==t_employee.t_currentemployeeemploymentprofile.T_EmployeeEmploymentProfileID)), "ID", "DisplayValue");
               ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmploymentRecordEmployeeTypeID = new SelectList(db.T_EmployeeTypes.Take(10).Union(db.T_EmployeeTypes.Where(p=>p.Id ==t_employee.t_currentemployeeemploymentprofile.T_EmploymentRecordEmployeeTypeID)), "ID", "DisplayValue");
               ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmploymentRecordHiredAtFacilityID = new SelectList(db.T_AllFacilitiess.Take(10).Union(db.T_AllFacilitiess.Where(p=>p.Id ==t_employee.t_currentemployeeemploymentprofile.T_EmploymentRecordHiredAtFacilityID)), "ID", "DisplayValue");
               ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmployeeTerminationReasonID = new SelectList(db.T_TerminationReasons.Take(10).Union(db.T_TerminationReasons.Where(p=>p.Id ==t_employee.t_currentemployeeemploymentprofile.T_EmployeeTerminationReasonID)), "ID", "DisplayValue");
               ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmployeeRecordTerminationFacilityID = new SelectList(db.T_AllFacilitiess.Take(10).Union(db.T_AllFacilitiess.Where(p=>p.Id ==t_employee.t_currentemployeeemploymentprofile.T_EmployeeRecordTerminationFacilityID)), "ID", "DisplayValue");
			 ViewBag.T_CurrentEmployeeJobAssignmentID = new SelectList(db.T_JobAssignments, "ID", "DisplayValue", t_employee.T_CurrentEmployeeJobAssignmentID);
               ViewBag.T_CurrentEmployeeJobAssignment_T_EmployeeJobAssignmentID = new SelectList(db.T_Employees.Take(10).Union(db.T_Employees.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_EmployeeJobAssignmentID)), "ID", "DisplayValue");
               ViewBag.T_CurrentEmployeeJobAssignment_T_PositionJobAssignmentID = new SelectList(db.T_Positions.Take(10).Union(db.T_Positions.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_PositionJobAssignmentID)), "ID", "DisplayValue");
               ViewBag.T_CurrentEmployeeJobAssignment_T_JobAssignmentReasonID = new SelectList(db.T_ReasonforHires.Take(10).Union(db.T_ReasonforHires.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_JobAssignmentReasonID)), "ID", "DisplayValue");
               ViewBag.T_CurrentEmployeeJobAssignment_T_JobAssignmentUnitXID = new SelectList(db.T_UnitXs.Take(10).Union(db.T_UnitXs.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_JobAssignmentUnitXID)), "ID", "DisplayValue");
               ViewBag.T_CurrentEmployeeJobAssignment_T_JobAssignmentManagerEmployeeID = new SelectList(db.T_Employees.Take(10).Union(db.T_Employees.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_JobAssignmentManagerEmployeeID)), "ID", "DisplayValue");
               ViewBag.T_CurrentEmployeeJobAssignment_T_EmployeeSupervisorID = new SelectList(db.T_Employees.Take(10).Union(db.T_Employees.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_EmployeeSupervisorID)), "ID", "DisplayValue");
			 ViewBag.T_EmployeeGenderID = new SelectList(db.T_Genders, "ID", "DisplayValue", t_employee.T_EmployeeGenderID);
			 ViewBag.T_EmployeeRaceID = new SelectList(db.T_Races, "ID", "DisplayValue", t_employee.T_EmployeeRaceID);
			 ViewBag.T_EmployeeNationalityAssociationID = new SelectList(db.T_Nationalitys, "ID", "DisplayValue", t_employee.T_EmployeeNationalityAssociationID);
			 ViewBag.T_EmployeeVeteranStatusID = new SelectList(db.T_VeteranStatuss, "ID", "DisplayValue", t_employee.T_EmployeeVeteranStatusID);
			 ViewBag.T_EmployeeCardEmplGrpAssociationID = new SelectList(db.T_CardEmplGrps, "ID", "DisplayValue", t_employee.T_EmployeeCardEmplGrpAssociationID);
			 ViewBag.T_EmployeeCardLvPlanAssociationID = new SelectList(db.T_CardLvPlans, "ID", "DisplayValue", t_employee.T_EmployeeCardLvPlanAssociationID);
			 ViewBag.T_EmployeeAddressID = new SelectList(db.T_Addresss, "ID", "DisplayValue", t_employee.T_EmployeeAddressID);
               ViewBag.T_EmployeeAddress_T_AddressCountryID = new SelectList(db.T_Countrys.Take(10).Union(db.T_Countrys.Where(p=>p.Id ==t_employee.t_employeeaddress.T_AddressCountryID)), "ID", "DisplayValue");
               ViewBag.T_EmployeeAddress_T_AddressStateID = new SelectList(db.T_States.Take(10).Union(db.T_States.Where(p=>p.Id ==t_employee.t_employeeaddress.T_AddressStateID)), "ID", "DisplayValue");
               ViewBag.T_EmployeeAddress_T_AddressCityID = new SelectList(db.T_Citys.Take(10).Union(db.T_Citys.Where(p=>p.Id ==t_employee.t_employeeaddress.T_AddressCityID)), "ID", "DisplayValue");
			 ViewBag.T_EmployeeUserLoginID = new SelectList(UserContext.Users, "Id", "UserName", t_employee.T_EmployeeUserLoginID);
			CustomLoadViewDataListAfterEdit(t_employee);
        }
        private void LoadViewDataBeforeOnEdit(T_Employee t_employee)
        {		
			var T_Langauge_T_ConversationalEmployeeForeignLanguagelist = db.T_Langauges.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            if (t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage != null)
            {
                var list = T_Langauge_T_ConversationalEmployeeForeignLanguagelist.Union(db.T_Langauges.Where(p => t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage.ToList().Contains(p.Id))).Distinct();
                ViewBag.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = new MultiSelectList(list, "ID", "DisplayValue",t_employee.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage);
            }
            else
            {
                ViewBag.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = new MultiSelectList(T_Langauge_T_ConversationalEmployeeForeignLanguagelist, "ID", "DisplayValue");
            }
			var T_Langauge_T_LanguageCertifiedInlist = db.T_Langauges.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            if (t_employee.SelectedT_Langauge_T_LanguageCertifiedIn != null)
            {
                var list = T_Langauge_T_LanguageCertifiedInlist.Union(db.T_Langauges.Where(p => t_employee.SelectedT_Langauge_T_LanguageCertifiedIn.ToList().Contains(p.Id))).Distinct();
                ViewBag.SelectedT_Langauge_T_LanguageCertifiedIn = new MultiSelectList(list, "ID", "DisplayValue",t_employee.SelectedT_Langauge_T_LanguageCertifiedIn);
            }
            else
            {
                ViewBag.SelectedT_Langauge_T_LanguageCertifiedIn = new MultiSelectList(T_Langauge_T_LanguageCertifiedInlist, "ID", "DisplayValue");
            }
               var _objT_EmployeeAtFacility = new List<T_Facility>();
               _objT_EmployeeAtFacility.Add(t_employee.t_employeeatfacility);
			   			   ViewBag.T_EmployeeAtFacilityID = new SelectList(_objT_EmployeeAtFacility, "ID", "DisplayValue", t_employee.T_EmployeeAtFacilityID);
			               var _objT_EmployeeStatus = new List<T_EmployeeStatusCode>();
               _objT_EmployeeStatus.Add(t_employee.t_employeestatus);
			   			   ViewBag.T_EmployeeStatusID = new SelectList(_objT_EmployeeStatus, "ID", "DisplayValue", t_employee.T_EmployeeStatusID);
			               var _objT_CurrentEmployeeEmploymentProfile = new List<T_ServiceRecord>();
               _objT_CurrentEmployeeEmploymentProfile.Add(t_employee.t_currentemployeeemploymentprofile);
			   			   ViewBag.T_CurrentEmployeeEmploymentProfileID = new SelectList(_objT_CurrentEmployeeEmploymentProfile, "ID", "DisplayValue", t_employee.T_CurrentEmployeeEmploymentProfileID);
						if(t_employee.t_currentemployeeemploymentprofile != null)
                ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmployeeEmploymentProfileID = new SelectList(db.T_Employees.Take(10).Union(db.T_Employees.Where(p=>p.Id ==t_employee.t_currentemployeeemploymentprofile.T_EmployeeEmploymentProfileID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmployeeEmploymentProfileID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
			if(t_employee.t_currentemployeeemploymentprofile != null)
                ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmploymentRecordEmployeeTypeID = new SelectList(db.T_EmployeeTypes.Take(10).Union(db.T_EmployeeTypes.Where(p=>p.Id ==t_employee.t_currentemployeeemploymentprofile.T_EmploymentRecordEmployeeTypeID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmploymentRecordEmployeeTypeID = new SelectList(db.T_EmployeeTypes.Take(10), "ID", "DisplayValue");
			if(t_employee.t_currentemployeeemploymentprofile != null)
                ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmploymentRecordHiredAtFacilityID = new SelectList(db.T_AllFacilitiess.Take(10).Union(db.T_AllFacilitiess.Where(p=>p.Id ==t_employee.t_currentemployeeemploymentprofile.T_EmploymentRecordHiredAtFacilityID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmploymentRecordHiredAtFacilityID = new SelectList(db.T_AllFacilitiess.Take(10), "ID", "DisplayValue");
			if(t_employee.t_currentemployeeemploymentprofile != null)
                ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmployeeTerminationReasonID = new SelectList(db.T_TerminationReasons.Take(10).Union(db.T_TerminationReasons.Where(p=>p.Id ==t_employee.t_currentemployeeemploymentprofile.T_EmployeeTerminationReasonID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmployeeTerminationReasonID = new SelectList(db.T_TerminationReasons.Take(10), "ID", "DisplayValue");
			if(t_employee.t_currentemployeeemploymentprofile != null)
                ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmployeeRecordTerminationFacilityID = new SelectList(db.T_AllFacilitiess.Take(10).Union(db.T_AllFacilitiess.Where(p=>p.Id ==t_employee.t_currentemployeeemploymentprofile.T_EmployeeRecordTerminationFacilityID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeEmploymentProfile_T_EmployeeRecordTerminationFacilityID = new SelectList(db.T_AllFacilitiess.Take(10), "ID", "DisplayValue");
               var _objT_CurrentEmployeeJobAssignment = new List<T_JobAssignment>();
               _objT_CurrentEmployeeJobAssignment.Add(t_employee.t_currentemployeejobassignment);
			   			   ViewBag.T_CurrentEmployeeJobAssignmentID = new SelectList(_objT_CurrentEmployeeJobAssignment, "ID", "DisplayValue", t_employee.T_CurrentEmployeeJobAssignmentID);
						if(t_employee.t_currentemployeejobassignment != null)
                ViewBag.T_CurrentEmployeeJobAssignment_T_EmployeeJobAssignmentID = new SelectList(db.T_Employees.Take(10).Union(db.T_Employees.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_EmployeeJobAssignmentID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeJobAssignment_T_EmployeeJobAssignmentID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
			if(t_employee.t_currentemployeejobassignment != null)
                ViewBag.T_CurrentEmployeeJobAssignment_T_PositionJobAssignmentID = new SelectList(db.T_Positions.Take(10).Union(db.T_Positions.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_PositionJobAssignmentID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeJobAssignment_T_PositionJobAssignmentID = new SelectList(db.T_Positions.Take(10), "ID", "DisplayValue");
			if(t_employee.t_currentemployeejobassignment != null)
                ViewBag.T_CurrentEmployeeJobAssignment_T_JobAssignmentReasonID = new SelectList(db.T_ReasonforHires.Take(10).Union(db.T_ReasonforHires.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_JobAssignmentReasonID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeJobAssignment_T_JobAssignmentReasonID = new SelectList(db.T_ReasonforHires.Take(10), "ID", "DisplayValue");
			if(t_employee.t_currentemployeejobassignment != null)
                ViewBag.T_CurrentEmployeeJobAssignment_T_JobAssignmentUnitXID = new SelectList(db.T_UnitXs.Take(10).Union(db.T_UnitXs.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_JobAssignmentUnitXID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeJobAssignment_T_JobAssignmentUnitXID = new SelectList(db.T_UnitXs.Take(10), "ID", "DisplayValue");
			if(t_employee.t_currentemployeejobassignment != null)
                ViewBag.T_CurrentEmployeeJobAssignment_T_JobAssignmentManagerEmployeeID = new SelectList(db.T_Employees.Take(10).Union(db.T_Employees.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_JobAssignmentManagerEmployeeID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeJobAssignment_T_JobAssignmentManagerEmployeeID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
			if(t_employee.t_currentemployeejobassignment != null)
                ViewBag.T_CurrentEmployeeJobAssignment_T_EmployeeSupervisorID = new SelectList(db.T_Employees.Take(10).Union(db.T_Employees.Where(p=>p.Id ==t_employee.t_currentemployeejobassignment.T_EmployeeSupervisorID)), "ID", "DisplayValue");
			else
			    ViewBag.T_CurrentEmployeeJobAssignment_T_EmployeeSupervisorID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
               var _objT_EmployeeGender = new List<T_Gender>();
               _objT_EmployeeGender.Add(t_employee.t_employeegender);
			   			   ViewBag.T_EmployeeGenderID = new SelectList(_objT_EmployeeGender, "ID", "DisplayValue", t_employee.T_EmployeeGenderID);
			               var _objT_EmployeeRace = new List<T_Race>();
               _objT_EmployeeRace.Add(t_employee.t_employeerace);
			   			   ViewBag.T_EmployeeRaceID = new SelectList(_objT_EmployeeRace, "ID", "DisplayValue", t_employee.T_EmployeeRaceID);
			               var _objT_EmployeeNationalityAssociation = new List<T_Nationality>();
               _objT_EmployeeNationalityAssociation.Add(t_employee.t_employeenationalityassociation);
			   			   ViewBag.T_EmployeeNationalityAssociationID = new SelectList(_objT_EmployeeNationalityAssociation, "ID", "DisplayValue", t_employee.T_EmployeeNationalityAssociationID);
			               var _objT_EmployeeVeteranStatus = new List<T_VeteranStatus>();
               _objT_EmployeeVeteranStatus.Add(t_employee.t_employeeveteranstatus);
			   			   ViewBag.T_EmployeeVeteranStatusID = new SelectList(_objT_EmployeeVeteranStatus, "ID", "DisplayValue", t_employee.T_EmployeeVeteranStatusID);
			               var _objT_EmployeeCardEmplGrpAssociation = new List<T_CardEmplGrp>();
               _objT_EmployeeCardEmplGrpAssociation.Add(t_employee.t_employeecardemplgrpassociation);
			   			   ViewBag.T_EmployeeCardEmplGrpAssociationID = new SelectList(_objT_EmployeeCardEmplGrpAssociation, "ID", "DisplayValue", t_employee.T_EmployeeCardEmplGrpAssociationID);
			               var _objT_EmployeeCardLvPlanAssociation = new List<T_CardLvPlan>();
               _objT_EmployeeCardLvPlanAssociation.Add(t_employee.t_employeecardlvplanassociation);
			   			   ViewBag.T_EmployeeCardLvPlanAssociationID = new SelectList(_objT_EmployeeCardLvPlanAssociation, "ID", "DisplayValue", t_employee.T_EmployeeCardLvPlanAssociationID);
			               var _objT_EmployeeAddress = new List<T_Address>();
               _objT_EmployeeAddress.Add(t_employee.t_employeeaddress);
			   			   ViewBag.T_EmployeeAddressID = new SelectList(_objT_EmployeeAddress, "ID", "DisplayValue", t_employee.T_EmployeeAddressID);
						if(t_employee.t_employeeaddress != null)
                ViewBag.T_EmployeeAddress_T_AddressCountryID = new SelectList(db.T_Countrys.Take(10).Union(db.T_Countrys.Where(p=>p.Id ==t_employee.t_employeeaddress.T_AddressCountryID)), "ID", "DisplayValue");
			else
			    ViewBag.T_EmployeeAddress_T_AddressCountryID = new SelectList(db.T_Countrys.Take(10), "ID", "DisplayValue");
			if(t_employee.t_employeeaddress != null)
                ViewBag.T_EmployeeAddress_T_AddressStateID = new SelectList(db.T_States.Take(10).Union(db.T_States.Where(p=>p.Id ==t_employee.t_employeeaddress.T_AddressStateID)), "ID", "DisplayValue");
			else
			    ViewBag.T_EmployeeAddress_T_AddressStateID = new SelectList(db.T_States.Take(10), "ID", "DisplayValue");
			if(t_employee.t_employeeaddress != null)
                ViewBag.T_EmployeeAddress_T_AddressCityID = new SelectList(db.T_Citys.Take(10).Union(db.T_Citys.Where(p=>p.Id ==t_employee.t_employeeaddress.T_AddressCityID)), "ID", "DisplayValue");
			else
			    ViewBag.T_EmployeeAddress_T_AddressCityID = new SelectList(db.T_Citys.Take(10), "ID", "DisplayValue");
			 ViewBag.T_EmployeeUserLoginID = new SelectList(UserContext.Users, "Id", "UserName", t_employee.T_EmployeeUserLoginID);
	 ViewBag.T_LicenseRecordsCount = t_employee.t_licenserecords.Count();
	 ViewBag.T_EmployeeEmployeeInjuryCount = t_employee.t_employeeemployeeinjury.Count();
	 ViewBag.T_EmployeeCriminalBackgroundCheckCount = t_employee.t_employeecriminalbackgroundcheck.Count();
	 ViewBag.T_EmployeeCommentsCount = t_employee.t_employeecomments.Count();
	 ViewBag.T_EmployeeLeaveProfileCount = t_employee.t_employeeleaveprofile.Count();
	 ViewBag.T_EmployeeEducationCount = t_employee.t_employeeeducation.Count();
	 ViewBag.T_EmployeeAccomodationCount = t_employee.t_employeeaccomodation.Count();
	 ViewBag.T_EmployeeEmploymentProfileCount = t_employee.t_employeeemploymentprofile.Count();
	 ViewBag.T_EmployeeJobAssignmentCount = t_employee.t_employeejobassignment.Count();
	 ViewBag.T_EmployeePayDetailsCount = t_employee.t_employeepaydetails.Count();
	 ViewBag.T_EmployeeDrugAlcoholTestCount = t_employee.t_employeedrugalcoholtest.Count();
	 ViewBag.T_EmployeeAdministratorCount = t_employee.t_employeeadministrator.Count();
	 ViewBag.T_EmployeeUnitXHeadCount = t_employee.t_employeeunitxhead.Count();
	 ViewBag.T_JobAssignmentManagerEmployeeCount = t_employee.t_jobassignmentmanageremployee.Count();
	 ViewBag.T_EmployeeSupervisorCount = t_employee.t_employeesupervisor.Count();
	 ViewBag.T_ReviewerCount = t_employee.t_reviewer.Count();
	 ViewBag.T_EmployeeDocumentsCount = t_employee.t_employeedocuments.Count();
		CustomLoadViewDataListBeforeEdit(t_employee);
        }
        private void LoadViewDataAfterOnCreate(T_Employee t_employee)
        {			
			var T_Langauge_T_ConversationalEmployeeForeignLanguagelist = db.T_Langauges.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            ViewBag.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = new MultiSelectList(T_Langauge_T_ConversationalEmployeeForeignLanguagelist, "ID", "DisplayValue");
			var T_Langauge_T_LanguageCertifiedInlist = db.T_Langauges.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            ViewBag.SelectedT_Langauge_T_LanguageCertifiedIn = new MultiSelectList(T_Langauge_T_LanguageCertifiedInlist, "ID", "DisplayValue");
			 ViewBag.T_EmployeeAtFacilityID = new SelectList(db.T_Facilitys, "ID", "DisplayValue", t_employee.T_EmployeeAtFacilityID);
			 ViewBag.T_EmployeeStatusID = new SelectList(db.T_EmployeeStatusCodes, "ID", "DisplayValue", t_employee.T_EmployeeStatusID);
			 ViewBag.T_CurrentEmployeeEmploymentProfileID = new SelectList(db.T_ServiceRecords, "ID", "DisplayValue", t_employee.T_CurrentEmployeeEmploymentProfileID);
                ViewBag.T_EmployeeEmploymentProfileID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
                ViewBag.T_EmploymentRecordEmployeeTypeID = new SelectList(db.T_EmployeeTypes.Take(10), "ID", "DisplayValue");
                ViewBag.T_EmploymentRecordHiredAtFacilityID = new SelectList(db.T_AllFacilitiess.Take(10), "ID", "DisplayValue");
                ViewBag.T_EmployeeTerminationReasonID = new SelectList(db.T_TerminationReasons.Take(10), "ID", "DisplayValue");
                ViewBag.T_EmployeeRecordTerminationFacilityID = new SelectList(db.T_AllFacilitiess.Take(10), "ID", "DisplayValue");
			 ViewBag.T_CurrentEmployeeJobAssignmentID = new SelectList(db.T_JobAssignments, "ID", "DisplayValue", t_employee.T_CurrentEmployeeJobAssignmentID);
                ViewBag.T_EmployeeJobAssignmentID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
                ViewBag.T_PositionJobAssignmentID = new SelectList(db.T_Positions.Take(10), "ID", "DisplayValue");
                ViewBag.T_JobAssignmentReasonID = new SelectList(db.T_ReasonforHires.Take(10), "ID", "DisplayValue");
                ViewBag.T_JobAssignmentUnitXID = new SelectList(db.T_UnitXs.Take(10), "ID", "DisplayValue");
                ViewBag.T_JobAssignmentManagerEmployeeID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
                ViewBag.T_EmployeeSupervisorID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
			 ViewBag.T_EmployeeGenderID = new SelectList(db.T_Genders, "ID", "DisplayValue", t_employee.T_EmployeeGenderID);
			 ViewBag.T_EmployeeRaceID = new SelectList(db.T_Races, "ID", "DisplayValue", t_employee.T_EmployeeRaceID);
			 ViewBag.T_EmployeeNationalityAssociationID = new SelectList(db.T_Nationalitys, "ID", "DisplayValue", t_employee.T_EmployeeNationalityAssociationID);
			 ViewBag.T_EmployeeVeteranStatusID = new SelectList(db.T_VeteranStatuss, "ID", "DisplayValue", t_employee.T_EmployeeVeteranStatusID);
			 ViewBag.T_EmployeeCardEmplGrpAssociationID = new SelectList(db.T_CardEmplGrps, "ID", "DisplayValue", t_employee.T_EmployeeCardEmplGrpAssociationID);
			 ViewBag.T_EmployeeCardLvPlanAssociationID = new SelectList(db.T_CardLvPlans, "ID", "DisplayValue", t_employee.T_EmployeeCardLvPlanAssociationID);
			 ViewBag.T_EmployeeAddressID = new SelectList(db.T_Addresss, "ID", "DisplayValue", t_employee.T_EmployeeAddressID);
                ViewBag.T_AddressCountryID = new SelectList(db.T_Countrys.Take(10), "ID", "DisplayValue");
                ViewBag.T_AddressStateID = new SelectList(db.T_States.Take(10), "ID", "DisplayValue");
                ViewBag.T_AddressCityID = new SelectList(db.T_Citys.Take(10), "ID", "DisplayValue");
			 ViewBag.T_EmployeeUserLoginID = new SelectList(UserContext.Users, "Id", "UserName", t_employee.T_EmployeeUserLoginID);
		CustomLoadViewDataListAfterOnCreate(t_employee);
        }
        private void LoadViewDataBeforeOnCreate(string HostingEntityName, string HostingEntityID, string AssociatedType)
        {			
			var T_Langauge_T_ConversationalEmployeeForeignLanguagelist = db.T_Langauges.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            ViewBag.SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage = new MultiSelectList(T_Langauge_T_ConversationalEmployeeForeignLanguagelist, "ID", "DisplayValue");
			var T_Langauge_T_LanguageCertifiedInlist = db.T_Langauges.OrderBy(p => p.DisplayValue).Take(10).Distinct();
            ViewBag.SelectedT_Langauge_T_LanguageCertifiedIn = new MultiSelectList(T_Langauge_T_LanguageCertifiedInlist, "ID", "DisplayValue");
			if(HostingEntityName == "T_Facility" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeAtFacility")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeAtFacilityID = new SelectList(db.T_Facilitys.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Facilitys.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeAtFacility = new List<T_Facility>();
			 ViewBag.T_EmployeeAtFacilityID = new SelectList(objT_EmployeeAtFacility , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_EmployeeStatusCode" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeStatus")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeStatusID = new SelectList(db.T_EmployeeStatusCodes.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_EmployeeStatusCodes.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeStatus = new List<T_EmployeeStatusCode>();
			 ViewBag.T_EmployeeStatusID = new SelectList(objT_EmployeeStatus , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_ServiceRecord" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_CurrentEmployeeEmploymentProfile")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_CurrentEmployeeEmploymentProfileID = new SelectList(db.T_ServiceRecords.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_ServiceRecords.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_CurrentEmployeeEmploymentProfile = new List<T_ServiceRecord>();
			 ViewBag.T_CurrentEmployeeEmploymentProfileID = new SelectList(objT_CurrentEmployeeEmploymentProfile , "ID", "DisplayValue");
                ViewBag.T_EmployeeEmploymentProfileID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
                ViewBag.T_EmploymentRecordEmployeeTypeID = new SelectList(db.T_EmployeeTypes.Take(10), "ID", "DisplayValue");
                ViewBag.T_EmploymentRecordHiredAtFacilityID = new SelectList(db.T_AllFacilitiess.Take(10), "ID", "DisplayValue");
                ViewBag.T_EmployeeTerminationReasonID = new SelectList(db.T_TerminationReasons.Take(10), "ID", "DisplayValue");
                ViewBag.T_EmployeeRecordTerminationFacilityID = new SelectList(db.T_AllFacilitiess.Take(10), "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_JobAssignment" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_CurrentEmployeeJobAssignment")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_CurrentEmployeeJobAssignmentID = new SelectList(db.T_JobAssignments.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_JobAssignments.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_CurrentEmployeeJobAssignment = new List<T_JobAssignment>();
			 ViewBag.T_CurrentEmployeeJobAssignmentID = new SelectList(objT_CurrentEmployeeJobAssignment , "ID", "DisplayValue");
                ViewBag.T_EmployeeJobAssignmentID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
                ViewBag.T_PositionJobAssignmentID = new SelectList(db.T_Positions.Take(10), "ID", "DisplayValue");
                ViewBag.T_JobAssignmentReasonID = new SelectList(db.T_ReasonforHires.Take(10), "ID", "DisplayValue");
                ViewBag.T_JobAssignmentUnitXID = new SelectList(db.T_UnitXs.Take(10), "ID", "DisplayValue");
                ViewBag.T_JobAssignmentManagerEmployeeID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
                ViewBag.T_EmployeeSupervisorID = new SelectList(db.T_Employees.Take(10), "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Gender" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeGender")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeGenderID = new SelectList(db.T_Genders.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Genders.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeGender = new List<T_Gender>();
			 ViewBag.T_EmployeeGenderID = new SelectList(objT_EmployeeGender , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Race" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeRace")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeRaceID = new SelectList(db.T_Races.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Races.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeRace = new List<T_Race>();
			 ViewBag.T_EmployeeRaceID = new SelectList(objT_EmployeeRace , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Nationality" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeNationalityAssociation")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeNationalityAssociationID = new SelectList(db.T_Nationalitys.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Nationalitys.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeNationalityAssociation = new List<T_Nationality>();
			 ViewBag.T_EmployeeNationalityAssociationID = new SelectList(objT_EmployeeNationalityAssociation , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_VeteranStatus" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeVeteranStatus")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeVeteranStatusID = new SelectList(db.T_VeteranStatuss.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_VeteranStatuss.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeVeteranStatus = new List<T_VeteranStatus>();
			 ViewBag.T_EmployeeVeteranStatusID = new SelectList(objT_EmployeeVeteranStatus , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_CardEmplGrp" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeCardEmplGrpAssociation")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeCardEmplGrpAssociationID = new SelectList(db.T_CardEmplGrps.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_CardEmplGrps.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeCardEmplGrpAssociation = new List<T_CardEmplGrp>();
			 ViewBag.T_EmployeeCardEmplGrpAssociationID = new SelectList(objT_EmployeeCardEmplGrpAssociation , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_CardLvPlan" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeCardLvPlanAssociation")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeCardLvPlanAssociationID = new SelectList(db.T_CardLvPlans.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_CardLvPlans.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeCardLvPlanAssociation = new List<T_CardLvPlan>();
			 ViewBag.T_EmployeeCardLvPlanAssociationID = new SelectList(objT_EmployeeCardLvPlanAssociation , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Address" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeAddress")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeAddressID = new SelectList(db.T_Addresss.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Addresss.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeAddress = new List<T_Address>();
			 ViewBag.T_EmployeeAddressID = new SelectList(objT_EmployeeAddress , "ID", "DisplayValue");
                ViewBag.T_AddressCountryID = new SelectList(db.T_Countrys.Take(10), "ID", "DisplayValue");
                ViewBag.T_AddressStateID = new SelectList(db.T_States.Take(10), "ID", "DisplayValue");
                ViewBag.T_AddressCityID = new SelectList(db.T_Citys.Take(10), "ID", "DisplayValue");
		    }
			//Add object for UserDropDown
            Dictionary<string, string> T_EmployeeUserLoginDict = new Dictionary<string, string>();
            ViewBag.T_EmployeeUserLoginID = new SelectList(T_EmployeeUserLoginDict, "Id", "UserName");
            //
			CustomLoadViewDataListBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
        }
		private IQueryable<T_Employee> searchRecords(IQueryable<T_Employee> lstT_Employee, string searchString, bool? IsDeepSearch)
        {
		   searchString = searchString.Trim();
		if(Convert.ToBoolean(IsDeepSearch))
            lstT_Employee = lstT_Employee.Where(s => (s.t_employeeatfacility!= null && (s.t_employeeatfacility.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_PID) && s.T_PID.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_SSN) && s.T_SSN.ToUpper().Contains(searchString)) ||(s.t_employeestatus!= null && (s.t_employeestatus.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_SAMAccount) && s.T_SAMAccount.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_LastName) && s.T_LastName.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_FirstName) && s.T_FirstName.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_MiddleName) && s.T_MiddleName.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_Suffix) && s.T_Suffix.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_WorkEmail) && s.T_WorkEmail.ToUpper().Contains(searchString)) ||(s.t_currentemployeeemploymentprofile!= null && (s.t_currentemployeeemploymentprofile.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment!= null && (s.t_currentemployeejobassignment.DisplayValue.ToUpper().Contains(searchString) )) ||(s.T_PriorServiceinmonths != null && SqlFunctions.StringConvert((double)s.T_PriorServiceinmonths).Contains(searchString)) ||(s.T_CurrentServiceinmonths != null && SqlFunctions.StringConvert((double)s.T_CurrentServiceinmonths).Contains(searchString)) ||(s.t_employeegender!= null && (s.t_employeegender.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeerace!= null && (s.t_employeerace.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeenationalityassociation!= null && (s.t_employeenationalityassociation.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeveteranstatus!= null && (s.t_employeeveteranstatus.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeecardemplgrpassociation!= null && (s.t_employeecardemplgrpassociation.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeecardlvplanassociation!= null && (s.t_employeecardlvplanassociation.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeaddress!= null && (s.t_employeeaddress.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_PersonalEmail) && s.T_PersonalEmail.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_MobilePhone) && s.T_MobilePhone.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_HomePhone) && s.T_HomePhone.ToUpper().Contains(searchString)) ||(s.t_employeeuserlogin!= null && (s.t_employeeuserlogin.UserName.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_EmergencyContactName) && s.T_EmergencyContactName.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_EmergencyContactRelationship) && s.T_EmergencyContactRelationship.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_EmergencyMobilePhone) && s.T_EmergencyMobilePhone.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_EmergencyWorkPhone) && s.T_EmergencyWorkPhone.ToUpper().Contains(searchString)) ||(s.T_BadgeNumber != null && SqlFunctions.StringConvert((double)s.T_BadgeNumber).Contains(searchString)) ||(s.t_currentemployeeemploymentprofile.t_employeeemploymentprofile!= null && (s.t_currentemployeeemploymentprofile.t_employeeemploymentprofile.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeeemploymentprofile.t_employmentrecordemployeetype!= null && (s.t_currentemployeeemploymentprofile.t_employmentrecordemployeetype.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeeemploymentprofile.t_employmentrecordhiredatfacility!= null && (s.t_currentemployeeemploymentprofile.t_employmentrecordhiredatfacility.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeeemploymentprofile.t_employeeterminationreason!= null && (s.t_currentemployeeemploymentprofile.t_employeeterminationreason.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeeemploymentprofile.t_employeerecordterminationfacility!= null && (s.t_currentemployeeemploymentprofile.t_employeerecordterminationfacility.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.t_employeejobassignment!= null && (s.t_currentemployeejobassignment.t_employeejobassignment.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.T_EmployeePercent != null && SqlFunctions.StringConvert((double)s.t_currentemployeejobassignment.T_EmployeePercent).Contains(searchString)) ||(s.t_currentemployeejobassignment.t_positionjobassignment!= null && (s.t_currentemployeejobassignment.t_positionjobassignment.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.t_jobassignmentreason!= null && (s.t_currentemployeejobassignment.t_jobassignmentreason.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.t_jobassignmentunitx!= null && (s.t_currentemployeejobassignment.t_jobassignmentunitx.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.t_jobassignmentmanageremployee!= null && (s.t_currentemployeejobassignment.t_jobassignmentmanageremployee.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.t_employeesupervisor!= null && (s.t_currentemployeejobassignment.t_employeesupervisor.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_employeeaddress.T_AddressLine1) && s.t_employeeaddress.T_AddressLine1.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_employeeaddress.T_AddressLine2) && s.t_employeeaddress.T_AddressLine2.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_employeeaddress.T_ZipCode) && s.t_employeeaddress.T_ZipCode.ToUpper().Contains(searchString)) ||(s.t_employeeaddress.t_addresscountry!= null && (s.t_employeeaddress.t_addresscountry.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeaddress.t_addressstate!= null && (s.t_employeeaddress.t_addressstate.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeaddress.t_addresscity!= null && (s.t_employeeaddress.t_addresscity.DisplayValue.ToUpper().Contains(searchString) )) ||s.T_ConversationalEmployeeForeignLanguage_t_employee.Any(c => c.t_langauge.DisplayValue.ToUpper().Contains(searchString)) ||s.T_LanguageCertifiedIn_t_employee.Any(c => c.t_langauge.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
		else
			 lstT_Employee = lstT_Employee.Where(s => (s.t_employeeatfacility!= null && (s.t_employeeatfacility.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_PID) && s.T_PID.ToUpper().Contains(searchString)) ||(s.t_employeestatus!= null && (s.t_employeestatus.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_LastName) && s.T_LastName.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_FirstName) && s.T_FirstName.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_MiddleName) && s.T_MiddleName.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_WorkEmail) && s.T_WorkEmail.ToUpper().Contains(searchString)) ||(s.t_currentemployeeemploymentprofile!= null && (s.t_currentemployeeemploymentprofile.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment!= null && (s.t_currentemployeejobassignment.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeegender!= null && (s.t_employeegender.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeeemploymentprofile.t_employeeemploymentprofile!= null && (s.t_currentemployeeemploymentprofile.t_employeeemploymentprofile.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeeemploymentprofile.t_employmentrecordemployeetype!= null && (s.t_currentemployeeemploymentprofile.t_employmentrecordemployeetype.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeeemploymentprofile.t_employmentrecordhiredatfacility!= null && (s.t_currentemployeeemploymentprofile.t_employmentrecordhiredatfacility.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeeemploymentprofile.t_employeeterminationreason!= null && (s.t_currentemployeeemploymentprofile.t_employeeterminationreason.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeeemploymentprofile.t_employeerecordterminationfacility!= null && (s.t_currentemployeeemploymentprofile.t_employeerecordterminationfacility.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.t_employeejobassignment!= null && (s.t_currentemployeejobassignment.t_employeejobassignment.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.T_EmployeePercent != null && SqlFunctions.StringConvert((double)s.t_currentemployeejobassignment.T_EmployeePercent).Contains(searchString)) ||(s.t_currentemployeejobassignment.t_positionjobassignment!= null && (s.t_currentemployeejobassignment.t_positionjobassignment.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.t_jobassignmentreason!= null && (s.t_currentemployeejobassignment.t_jobassignmentreason.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.t_jobassignmentunitx!= null && (s.t_currentemployeejobassignment.t_jobassignmentunitx.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.t_jobassignmentmanageremployee!= null && (s.t_currentemployeejobassignment.t_jobassignmentmanageremployee.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_currentemployeejobassignment.t_employeesupervisor!= null && (s.t_currentemployeejobassignment.t_employeesupervisor.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.t_employeeaddress.T_AddressLine1) && s.t_employeeaddress.T_AddressLine1.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_employeeaddress.T_AddressLine2) && s.t_employeeaddress.T_AddressLine2.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.t_employeeaddress.T_ZipCode) && s.t_employeeaddress.T_ZipCode.ToUpper().Contains(searchString)) ||(s.t_employeeaddress.t_addresscountry!= null && (s.t_employeeaddress.t_addresscountry.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeaddress.t_addressstate!= null && (s.t_employeeaddress.t_addressstate.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeaddress.t_addresscity!= null && (s.t_employeeaddress.t_addresscity.DisplayValue.ToUpper().Contains(searchString) )) ||s.T_ConversationalEmployeeForeignLanguage_t_employee.Any(c => c.t_langauge.DisplayValue.ToUpper().Contains(searchString)) ||s.T_LanguageCertifiedIn_t_employee.Any(c => c.t_langauge.DisplayValue.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
			try
            {
                var boolvalue = Convert.ToBoolean(searchString);
                lstT_Employee = lstT_Employee.Union(db.T_Employees.Where(s => (s.t_currentemployeeemploymentprofile.T_IsCurrent == boolvalue) ||(s.t_currentemployeeemploymentprofile.T_ThreeMonthReviewCompleted == boolvalue) ||(s.t_currentemployeeemploymentprofile.T_EligibleForRehire == boolvalue) ||(s.t_currentemployeejobassignment.T_Primary == boolvalue) ||(s.t_currentemployeejobassignment.T_Active == boolvalue) ));
            }
            catch { }
			try
            {
                var datevalue = Convert.ToDateTime(searchString);
                lstT_Employee = lstT_Employee.Union(db.T_Employees.Where(s => (s.T_DateOfBirth == datevalue) ||(s.T_StateHireDate == datevalue) ||(s.T_AdjustedHireDate == datevalue) ||(s.T_EffectiveDateTime == datevalue) ||(s.t_currentemployeeemploymentprofile.T_HireDate == datevalue) ||(s.t_currentemployeeemploymentprofile.T_TerminationDate == datevalue) ||(s.t_currentemployeejobassignment.T_StartDate == datevalue) ||(s.t_currentemployeejobassignment.T_EndDate == datevalue) ));
            }
            catch { }
            return lstT_Employee;
        }
		private IQueryable<T_Employee> sortRecords(IQueryable<T_Employee> lstT_Employee, string sortBy, string isAsc)
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
	 if(sortBy == "T_EmployeeAtFacilityID")
                return isAsc.ToLower() == "asc" ? lstT_Employee.OrderBy(p => p.t_employeeatfacility.DisplayValue) : lstT_Employee.OrderByDescending(p => p.t_employeeatfacility.DisplayValue);
	 if(sortBy == "T_EmployeeStatusID")
                return isAsc.ToLower() == "asc" ? lstT_Employee.OrderBy(p => p.t_employeestatus.DisplayValue) : lstT_Employee.OrderByDescending(p => p.t_employeestatus.DisplayValue);
	 if(sortBy == "T_CurrentEmployeeEmploymentProfileID")
                return isAsc.ToLower() == "asc" ? lstT_Employee.OrderBy(p => p.t_currentemployeeemploymentprofile.DisplayValue) : lstT_Employee.OrderByDescending(p => p.t_currentemployeeemploymentprofile.DisplayValue);
	 if(sortBy == "T_CurrentEmployeeJobAssignmentID")
                return isAsc.ToLower() == "asc" ? lstT_Employee.OrderBy(p => p.t_currentemployeejobassignment.DisplayValue) : lstT_Employee.OrderByDescending(p => p.t_currentemployeejobassignment.DisplayValue);
	 if(sortBy == "T_EmployeeGenderID")
                return isAsc.ToLower() == "asc" ? lstT_Employee.OrderBy(p => p.t_employeegender.DisplayValue) : lstT_Employee.OrderByDescending(p => p.t_employeegender.DisplayValue);
		    if (sortBy.Contains("."))
                return isAsc.ToLower() == "asc" ? lstT_Employee.Sort(sortBy,true) : lstT_Employee.Sort(sortBy,false);
            ParameterExpression paramExpression = Expression.Parameter(typeof(T_Employee), "t_employee");
            MemberExpression memExp = Expression.PropertyOrField(paramExpression, sortBy);
            LambdaExpression lambda = Expression.Lambda(memExp, paramExpression);
            return (IQueryable<T_Employee>)lstT_Employee.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { lstT_Employee.ElementType, lambda.Body.Type },
                    lstT_Employee.Expression,
                    lambda));
        }
		public ActionResult FindFSearch(string id, string sourceEntity)
        {
            if (sourceEntity == "T_Department")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Departments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAtFacility  = _Object.T_DepartmentFacilityAssociationID;
						url += "&t_employeeatfacility=" + T_EmployeeAtFacility;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Position")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Positions.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAtFacility  = _Object.T_FacilityAssignedToID;
						url += "&t_employeeatfacility=" + T_EmployeeAtFacility;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_DepartmentArea")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_DepartmentAreas.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAtFacility  = _Object.T_DepartmentAreaEmployeeTypeAssociationID;
						url += "&t_employeeatfacility=" + T_EmployeeAtFacility;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_ClaimType")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_ClaimTypes.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAtFacility  = _Object.T_ClaimTypeFacilityAssociationID;
						url += "&t_employeeatfacility=" + T_EmployeeAtFacility;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Restrictions")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Restrictionss.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAtFacility  = _Object.T_RestrictionsFacilityAssociationID;
						url += "&t_employeeatfacility=" + T_EmployeeAtFacility;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_UnitX")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_UnitXs.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAtFacility  = _Object.T_FacilityUnitXID;
						url += "&t_employeeatfacility=" + T_EmployeeAtFacility;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Unit")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Units.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAtFacility  = _Object.T_FacilityUnitID;
						url += "&t_employeeatfacility=" + T_EmployeeAtFacility;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_SalaryRange")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_SalaryRanges.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAtFacility  = _Object.T_FacilitySalaryRangeAssociationID;
						url += "&t_employeeatfacility=" + T_EmployeeAtFacility;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_FacilityConfiguration")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_FacilityConfigurations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeAtFacility  = _Object.T_TenantConfigurationAssociationID;
						url += "&t_employeeatfacility=" + T_EmployeeAtFacility;									
                Response.Redirect(url.ToString());
            }
            return null;
        }
        public ActionResult SetFSearch(string searchString, string HostingEntity ,string t_employeeatfacility,string t_employeestatus,string t_currentemployeeemploymentprofile,string t_currentemployeejobassignment,string t_employeegender,string t_employeerace,string t_employeenationalityassociation,string t_employeeveteranstatus,string t_employeecardemplgrpassociation,string t_employeecardlvplanassociation,string t_employeeaddress,string t_employeeuserlogin,string t_conversationalemployeeforeignlanguage,string t_languagecertifiedin, bool? RenderPartial)
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
			var T_EmployeeAtFacilitylist = db.T_Facilitys.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeatfacility != null)
            {
                var ids = t_employeeatfacility.Split(",".ToCharArray());
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
					var list = T_EmployeeAtFacilitylist.Union(db.T_Facilitys.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Facility>(User, list, "T_Facility", null);
					ViewBag.t_employeeatfacility = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeAtFacilitylist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Facility>(User, list, "T_Facility", null);
				ViewBag.t_employeeatfacility = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeStatuslist = db.T_EmployeeStatusCodes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeestatus != null)
            {
                var ids = t_employeestatus.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee Status= ";
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
							   ViewBag.SearchResult += db.T_EmployeeStatusCodes.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeStatuslist.Union(db.T_EmployeeStatusCodes.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_EmployeeStatusCode>(User, list, "T_EmployeeStatusCode", null);
					ViewBag.t_employeestatus = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeStatuslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_EmployeeStatusCode>(User, list, "T_EmployeeStatusCode", null);
				ViewBag.t_employeestatus = new SelectList(list, "ID", "DisplayValue");
			}
			var T_CurrentEmployeeEmploymentProfilelist = db.T_ServiceRecords.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_currentemployeeemploymentprofile != null)
            {
                var ids = t_currentemployeeemploymentprofile.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Service Record= ";
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
							   ViewBag.SearchResult += db.T_ServiceRecords.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_CurrentEmployeeEmploymentProfilelist.Union(db.T_ServiceRecords.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_ServiceRecord>(User, list, "T_ServiceRecord", null);
					ViewBag.t_currentemployeeemploymentprofile = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_CurrentEmployeeEmploymentProfilelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_ServiceRecord>(User, list, "T_ServiceRecord", null);
				ViewBag.t_currentemployeeemploymentprofile = new SelectList(list, "ID", "DisplayValue");
			}
			var T_CurrentEmployeeJobAssignmentlist = db.T_JobAssignments.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_currentemployeejobassignment != null)
            {
                var ids = t_currentemployeejobassignment.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Primary Job Assignment= ";
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
							   ViewBag.SearchResult += db.T_JobAssignments.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_CurrentEmployeeJobAssignmentlist.Union(db.T_JobAssignments.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_JobAssignment>(User, list, "T_JobAssignment", null);
					ViewBag.t_currentemployeejobassignment = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_CurrentEmployeeJobAssignmentlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_JobAssignment>(User, list, "T_JobAssignment", null);
				ViewBag.t_currentemployeejobassignment = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeGenderlist = db.T_Genders.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeegender != null)
            {
                var ids = t_employeegender.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Gender= ";
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
							   ViewBag.SearchResult += db.T_Genders.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeGenderlist.Union(db.T_Genders.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Gender>(User, list, "T_Gender", null);
					ViewBag.t_employeegender = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeGenderlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Gender>(User, list, "T_Gender", null);
				ViewBag.t_employeegender = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeRacelist = db.T_Races.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeerace != null)
            {
                var ids = t_employeerace.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Race= ";
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
							   ViewBag.SearchResult += db.T_Races.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeRacelist.Union(db.T_Races.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Race>(User, list, "T_Race", null);
					ViewBag.t_employeerace = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeRacelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Race>(User, list, "T_Race", null);
				ViewBag.t_employeerace = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeNationalityAssociationlist = db.T_Nationalitys.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeenationalityassociation != null)
            {
                var ids = t_employeenationalityassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Nationality= ";
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
							   ViewBag.SearchResult += db.T_Nationalitys.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeNationalityAssociationlist.Union(db.T_Nationalitys.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Nationality>(User, list, "T_Nationality", null);
					ViewBag.t_employeenationalityassociation = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeNationalityAssociationlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Nationality>(User, list, "T_Nationality", null);
				ViewBag.t_employeenationalityassociation = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeVeteranStatuslist = db.T_VeteranStatuss.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeveteranstatus != null)
            {
                var ids = t_employeeveteranstatus.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Veteran Status= ";
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
							   ViewBag.SearchResult += db.T_VeteranStatuss.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeVeteranStatuslist.Union(db.T_VeteranStatuss.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_VeteranStatus>(User, list, "T_VeteranStatus", null);
					ViewBag.t_employeeveteranstatus = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeVeteranStatuslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_VeteranStatus>(User, list, "T_VeteranStatus", null);
				ViewBag.t_employeeveteranstatus = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeCardEmplGrpAssociationlist = db.T_CardEmplGrps.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeecardemplgrpassociation != null)
            {
                var ids = t_employeecardemplgrpassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n CardEmplGrp= ";
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
							   ViewBag.SearchResult += db.T_CardEmplGrps.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeCardEmplGrpAssociationlist.Union(db.T_CardEmplGrps.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_CardEmplGrp>(User, list, "T_CardEmplGrp", null);
					ViewBag.t_employeecardemplgrpassociation = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeCardEmplGrpAssociationlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_CardEmplGrp>(User, list, "T_CardEmplGrp", null);
				ViewBag.t_employeecardemplgrpassociation = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeCardLvPlanAssociationlist = db.T_CardLvPlans.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeecardlvplanassociation != null)
            {
                var ids = t_employeecardlvplanassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n CardAltLvPlan= ";
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
							   ViewBag.SearchResult += db.T_CardLvPlans.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeCardLvPlanAssociationlist.Union(db.T_CardLvPlans.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_CardLvPlan>(User, list, "T_CardLvPlan", null);
					ViewBag.t_employeecardlvplanassociation = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeCardLvPlanAssociationlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_CardLvPlan>(User, list, "T_CardLvPlan", null);
				ViewBag.t_employeecardlvplanassociation = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeAddresslist = db.T_Addresss.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeaddress != null)
            {
                var ids = t_employeeaddress.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee Address= ";
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
							   ViewBag.SearchResult += db.T_Addresss.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeAddresslist.Union(db.T_Addresss.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Address>(User, list, "T_Address", null);
					ViewBag.t_employeeaddress = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeAddresslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Address>(User, list, "T_Address", null);
				ViewBag.t_employeeaddress = new SelectList(list, "ID", "DisplayValue");
			}
			var T_ConversationalEmployeeForeignLanguagelist = db.T_Langauges.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_conversationalemployeeforeignlanguage != null)
            {
                var ids = t_conversationalemployeeforeignlanguage.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Conversational Foreign Language= ";
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
							   ViewBag.SearchResult += db.T_Langauges.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_ConversationalEmployeeForeignLanguagelist.Union(db.T_Langauges.Where(p=>ids1.Contains(p.Id))).Distinct().Select(p=>new { ID=p.Id,DisplayValue=p.DisplayValue }).ToList();
					ViewBag.t_conversationalemployeeforeignlanguage = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				ViewBag.t_conversationalemployeeforeignlanguage = new SelectList(T_ConversationalEmployeeForeignLanguagelist.Select(p => new { ID = p.Id, DisplayValue = p.DisplayValue }).ToList(), "ID", "DisplayValue");
			}
			var T_LanguageCertifiedInlist = db.T_Langauges.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_languagecertifiedin != null)
            {
                var ids = t_languagecertifiedin.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Languages Certified In= ";
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
							   ViewBag.SearchResult += db.T_Langauges.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_LanguageCertifiedInlist.Union(db.T_Langauges.Where(p=>ids1.Contains(p.Id))).Distinct().Select(p=>new { ID=p.Id,DisplayValue=p.DisplayValue }).ToList();
					ViewBag.t_languagecertifiedin = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				ViewBag.t_languagecertifiedin = new SelectList(T_LanguageCertifiedInlist.Select(p => new { ID = p.Id, DisplayValue = p.DisplayValue }).ToList(), "ID", "DisplayValue");
			}
			}
			else
			{
			var objT_EmployeeAtFacility = new List<T_Facility>();
		    ViewBag.t_employeeatfacility = new SelectList(objT_EmployeeAtFacility, "ID", "DisplayValue");
			var objT_EmployeeStatus = new List<T_EmployeeStatusCode>();
		    ViewBag.t_employeestatus = new SelectList(objT_EmployeeStatus, "ID", "DisplayValue");
			var objT_CurrentEmployeeEmploymentProfile = new List<T_ServiceRecord>();
		    ViewBag.t_currentemployeeemploymentprofile = new SelectList(objT_CurrentEmployeeEmploymentProfile, "ID", "DisplayValue");
			var objT_CurrentEmployeeJobAssignment = new List<T_JobAssignment>();
		    ViewBag.t_currentemployeejobassignment = new SelectList(objT_CurrentEmployeeJobAssignment, "ID", "DisplayValue");
			var objT_EmployeeGender = new List<T_Gender>();
		    ViewBag.t_employeegender = new SelectList(objT_EmployeeGender, "ID", "DisplayValue");
			var objT_EmployeeRace = new List<T_Race>();
		    ViewBag.t_employeerace = new SelectList(objT_EmployeeRace, "ID", "DisplayValue");
			var objT_EmployeeNationalityAssociation = new List<T_Nationality>();
		    ViewBag.t_employeenationalityassociation = new SelectList(objT_EmployeeNationalityAssociation, "ID", "DisplayValue");
			var objT_EmployeeVeteranStatus = new List<T_VeteranStatus>();
		    ViewBag.t_employeeveteranstatus = new SelectList(objT_EmployeeVeteranStatus, "ID", "DisplayValue");
			var objT_EmployeeCardEmplGrpAssociation = new List<T_CardEmplGrp>();
		    ViewBag.t_employeecardemplgrpassociation = new SelectList(objT_EmployeeCardEmplGrpAssociation, "ID", "DisplayValue");
			var objT_EmployeeCardLvPlanAssociation = new List<T_CardLvPlan>();
		    ViewBag.t_employeecardlvplanassociation = new SelectList(objT_EmployeeCardLvPlanAssociation, "ID", "DisplayValue");
			var objT_EmployeeAddress = new List<T_Address>();
		    ViewBag.t_employeeaddress = new SelectList(objT_EmployeeAddress, "ID", "DisplayValue");
			var objT_ConversationalEmployeeForeignLanguage = new List<T_Langauge>();
		    ViewBag.t_conversationalemployeeforeignlanguage = new SelectList(objT_ConversationalEmployeeForeignLanguage, "ID", "DisplayValue");
			var objT_LanguageCertifiedIn = new List<T_Langauge>();
		    ViewBag.t_languagecertifiedin = new SelectList(objT_LanguageCertifiedIn, "ID", "DisplayValue");
			}
				var lstFavoriteItem = db.FavoriteItems.Where(p => p.LastUpdatedByUser == User.Name);
				if (lstFavoriteItem.Count() > 0)
                    ViewBag.FavoriteItem = lstFavoriteItem;
				ViewBag.EntityName = "T_Employee";
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
			columns.Add("3", "PID");
			columns.Add("4", "Date Of Birth");
			columns.Add("5", "Employee Status");
			columns.Add("6", "Last Name");
			columns.Add("7", "First Name");
			columns.Add("8", "Middle Name");
			columns.Add("9", "Work Email");
			columns.Add("10", "Service Record");
			columns.Add("11", "Primary Job Assignment");
			columns.Add("12", "Gender");
				ViewBag.HideColumns = new MultiSelectList(columns, "Key", "Value");
				return View(new T_Employee());
            }
		public string conditionFSearch(string property, string operators, string value)
        {
            string expression = string.Empty;
            var PrpertyType = GetDataTypeOfProperty("T_Employee", property);
            var dataType = PrpertyType[0];
            property = PrpertyType[1];
            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                var ValueType = GetDataTypeOfProperty("T_Employee", value, true);
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
							expression = string.Format(" DbFunctions.TruncateTime(" + property + ") " + operators + " (\"{0}\")", (TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (new T_Employee()).m_Timezone)).Date);
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
		// GET: /T_Employee/FSearch/
		[Audit("FacetedSearch")]
		public ActionResult FSearch(string currentFilter, string searchString, string FSFilter, string sortBy, string isAsc, int? page, int? itemsPerPage, string search, bool? IsExport ,string t_employeeatfacility,string t_employeestatus,string t_currentemployeeemploymentprofile,string t_currentemployeejobassignment,string t_employeegender,string t_employeerace,string t_employeenationalityassociation,string t_employeeveteranstatus,string t_employeecardemplgrpassociation,string t_employeecardlvplanassociation,string t_employeeaddress,string t_employeeuserlogin,string t_conversationalemployeeforeignlanguage,string t_languagecertifiedin ,string T_DateOfBirthFrom,string T_DateOfBirthTo,string T_StateHireDateFrom,string T_StateHireDateTo,string T_AdjustedHireDateFrom,string T_AdjustedHireDateTo,string T_PriorServiceinmonthsFrom,string T_PriorServiceinmonthsTo,string T_CurrentServiceinmonthsFrom,string T_CurrentServiceinmonthsTo,string T_BadgeNumberFrom,string T_BadgeNumberTo,string T_EffectiveDateTimeFrom,string T_EffectiveDateTimeTo,string T_EffectiveDateTimeFromhdn,string T_EffectiveDateTimeTohdn,string FilterCondition, string HostingEntity, string AssociatedType,string HostingEntityID, string viewtype, string SortOrder, string HideColumns, string GroupByColumn,bool? IsReports, bool? IsdrivedTab)
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
				 var lstT_Employee  = from s in db.T_Employees
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Employee  = searchRecords(lstT_Employee, searchString.ToUpper(),true);
            }
			  if(!string.IsNullOrEmpty(search))
                	search=search.Replace("?IsAddPop=true", "");
			if(!string.IsNullOrEmpty(search)){
				ViewBag.SearchResult += "\r\n General Criterial= "+search;
				lstT_Employee = searchRecords(lstT_Employee, search,true);
			}
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Employee  = sortRecords(lstT_Employee, sortBy, isAsc);
            }
            else   lstT_Employee  = lstT_Employee.OrderByDescending(c => c.Id);
			lstT_Employee = CustomSorting(lstT_Employee);
			lstT_Employee = lstT_Employee.Include(t=>t.t_employeeatfacility).Include(t=>t.t_employeestatus).Include(t=>t.t_currentemployeeemploymentprofile).Include(t=>t.t_currentemployeejobassignment).Include(t=>t.t_employeegender).Include(t=>t.t_employeerace).Include(t=>t.t_employeenationalityassociation).Include(t=>t.t_employeeveteranstatus).Include(t=>t.t_employeecardemplgrpassociation).Include(t=>t.t_employeecardlvplanassociation).Include(t=>t.t_employeeaddress).Include(t=>t.t_employeeuserlogin);
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
					ViewBag.SearchResult += " " + GetPropertyDP("T_Employee", PropertyName) + " " + Operator + " " + Value + " " + LogicalConnector;
                    whereCondition.Append(conditionFSearch(PropertyName, Operator, Value) + LogicalConnector);
                    iCnt++;
                }
                if (!string.IsNullOrEmpty(whereCondition.ToString()))
                    lstT_Employee = lstT_Employee.Where(whereCondition.ToString());
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
                lstT_Employee = Sorting.Sort<T_Employee>(lstT_Employee, DataOrdering);
            var _T_Employee = lstT_Employee;
				if(T_DateOfBirthFrom!=null || T_DateOfBirthTo !=null)
				{
						try
						{
							DateTime from = T_DateOfBirthFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_DateOfBirthFrom);
							DateTime to = T_DateOfBirthTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_DateOfBirthTo).AddTicks(-1).AddDays(1);
							                       _T_Employee =  _T_Employee.Where(o =>o.T_DateOfBirth!=null && o.T_DateOfBirth.Value.CompareTo(from) >= 0 && o.T_DateOfBirth.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Date Of Birth= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_StateHireDateFrom!=null || T_StateHireDateTo !=null)
				{
						try
						{
							DateTime from = T_StateHireDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_StateHireDateFrom);
							DateTime to = T_StateHireDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_StateHireDateTo).AddTicks(-1).AddDays(1);
							                       _T_Employee =  _T_Employee.Where(o =>o.T_StateHireDate!=null && o.T_StateHireDate.Value.CompareTo(from) >= 0 && o.T_StateHireDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n State Hire Date = "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_AdjustedHireDateFrom!=null || T_AdjustedHireDateTo !=null)
				{
						try
						{
							DateTime from = T_AdjustedHireDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_AdjustedHireDateFrom);
							DateTime to = T_AdjustedHireDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_AdjustedHireDateTo).AddTicks(-1).AddDays(1);
							                       _T_Employee =  _T_Employee.Where(o =>o.T_AdjustedHireDate!=null && o.T_AdjustedHireDate.Value.CompareTo(from) >= 0 && o.T_AdjustedHireDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Adjusted Hire Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
		 if(T_PriorServiceinmonthsFrom!=null || T_PriorServiceinmonthsTo !=null)
		 {
                try
                {
                    int from = T_PriorServiceinmonthsFrom == null ? 0 : Convert.ToInt32(T_PriorServiceinmonthsFrom);
                    int to =  T_PriorServiceinmonthsTo == null ? int.MaxValue : Convert.ToInt32(T_PriorServiceinmonthsTo);
									     _T_Employee =  _T_Employee.Where(o => o.T_PriorServiceinmonths >= from && o.T_PriorServiceinmonths <= to);
                   					ViewBag.SearchResult += "\r\n Prior Service (in months)= "+from+"-"+to;
                }
                catch { }
          }
		 if(T_CurrentServiceinmonthsFrom!=null || T_CurrentServiceinmonthsTo !=null)
		 {
                try
                {
                    int from = T_CurrentServiceinmonthsFrom == null ? 0 : Convert.ToInt32(T_CurrentServiceinmonthsFrom);
                    int to =  T_CurrentServiceinmonthsTo == null ? int.MaxValue : Convert.ToInt32(T_CurrentServiceinmonthsTo);
									     _T_Employee =  _T_Employee.Where(o => o.T_CurrentServiceinmonths >= from && o.T_CurrentServiceinmonths <= to);
                   					ViewBag.SearchResult += "\r\n Current Service (in months)= "+from+"-"+to;
                }
                catch { }
          }
		 if(T_BadgeNumberFrom!=null || T_BadgeNumberTo !=null)
		 {
                try
                {
                    int from = T_BadgeNumberFrom == null ? 0 : Convert.ToInt32(T_BadgeNumberFrom);
                    int to =  T_BadgeNumberTo == null ? int.MaxValue : Convert.ToInt32(T_BadgeNumberTo);
									     _T_Employee =  _T_Employee.Where(o => o.T_BadgeNumber >= from && o.T_BadgeNumber <= to);
                   					ViewBag.SearchResult += "\r\n Badge Number= "+from+"-"+to;
                }
                catch { }
          }
				if(T_EffectiveDateTimeFrom!=null || T_EffectiveDateTimeTo !=null)
				{
						try
						{
							DateTime from = T_EffectiveDateTimeFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_EffectiveDateTimeFrom);
							DateTime to = T_EffectiveDateTimeTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_EffectiveDateTimeTo);
                      _T_Employee =  _T_Employee.Where(o => o.T_EffectiveDateTime >= from && o.T_EffectiveDateTime <= to);
                   							ViewBag.SearchResult += "\r\n Effective Date & Time= "+T_EffectiveDateTimeFromhdn+"-"+T_EffectiveDateTimeTohdn;
						}
						catch { }
				}
			//if (lstT_Employee.Where(p => p.t_employeeatfacility != null).Count() <= 50)
		    //ViewBag.t_employeeatfacility = new SelectList(lstT_Employee.Where(p => p.t_employeeatfacility != null).Select(P => P.t_employeeatfacility).Distinct(), "ID", "DisplayValue");
            if (t_employeeatfacility != null)
            {
                var ids = t_employeeatfacility.Split(",".ToCharArray());
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
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_EmployeeAtFacilityID));
            }
				//if (lstT_Employee.Where(p => p.t_employeestatus != null).Count() <= 50)
		    //ViewBag.t_employeestatus = new SelectList(lstT_Employee.Where(p => p.t_employeestatus != null).Select(P => P.t_employeestatus).Distinct(), "ID", "DisplayValue");
            if (t_employeestatus != null)
            {
                var ids = t_employeestatus.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee Status= ";
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
                            var obj = db.T_EmployeeStatusCodes.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_EmployeeStatusID));
            }
				//if (lstT_Employee.Where(p => p.t_currentemployeeemploymentprofile != null).Count() <= 50)
		    //ViewBag.t_currentemployeeemploymentprofile = new SelectList(lstT_Employee.Where(p => p.t_currentemployeeemploymentprofile != null).Select(P => P.t_currentemployeeemploymentprofile).Distinct(), "ID", "DisplayValue");
            if (t_currentemployeeemploymentprofile != null)
            {
                var ids = t_currentemployeeemploymentprofile.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Service Record= ";
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
                            var obj = db.T_ServiceRecords.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_CurrentEmployeeEmploymentProfileID));
            }
				//if (lstT_Employee.Where(p => p.t_currentemployeejobassignment != null).Count() <= 50)
		    //ViewBag.t_currentemployeejobassignment = new SelectList(lstT_Employee.Where(p => p.t_currentemployeejobassignment != null).Select(P => P.t_currentemployeejobassignment).Distinct(), "ID", "DisplayValue");
            if (t_currentemployeejobassignment != null)
            {
                var ids = t_currentemployeejobassignment.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Primary Job Assignment= ";
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
                            var obj = db.T_JobAssignments.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_CurrentEmployeeJobAssignmentID));
            }
				//if (lstT_Employee.Where(p => p.t_employeegender != null).Count() <= 50)
		    //ViewBag.t_employeegender = new SelectList(lstT_Employee.Where(p => p.t_employeegender != null).Select(P => P.t_employeegender).Distinct(), "ID", "DisplayValue");
            if (t_employeegender != null)
            {
                var ids = t_employeegender.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Gender= ";
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
                            var obj = db.T_Genders.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_EmployeeGenderID));
            }
				//if (lstT_Employee.Where(p => p.t_employeerace != null).Count() <= 50)
		    //ViewBag.t_employeerace = new SelectList(lstT_Employee.Where(p => p.t_employeerace != null).Select(P => P.t_employeerace).Distinct(), "ID", "DisplayValue");
            if (t_employeerace != null)
            {
                var ids = t_employeerace.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Race= ";
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
                            var obj = db.T_Races.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_EmployeeRaceID));
            }
				//if (lstT_Employee.Where(p => p.t_employeenationalityassociation != null).Count() <= 50)
		    //ViewBag.t_employeenationalityassociation = new SelectList(lstT_Employee.Where(p => p.t_employeenationalityassociation != null).Select(P => P.t_employeenationalityassociation).Distinct(), "ID", "DisplayValue");
            if (t_employeenationalityassociation != null)
            {
                var ids = t_employeenationalityassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Nationality= ";
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
                            var obj = db.T_Nationalitys.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_EmployeeNationalityAssociationID));
            }
				//if (lstT_Employee.Where(p => p.t_employeeveteranstatus != null).Count() <= 50)
		    //ViewBag.t_employeeveteranstatus = new SelectList(lstT_Employee.Where(p => p.t_employeeveteranstatus != null).Select(P => P.t_employeeveteranstatus).Distinct(), "ID", "DisplayValue");
            if (t_employeeveteranstatus != null)
            {
                var ids = t_employeeveteranstatus.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Veteran Status= ";
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
                            var obj = db.T_VeteranStatuss.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_EmployeeVeteranStatusID));
            }
				//if (lstT_Employee.Where(p => p.t_employeecardemplgrpassociation != null).Count() <= 50)
		    //ViewBag.t_employeecardemplgrpassociation = new SelectList(lstT_Employee.Where(p => p.t_employeecardemplgrpassociation != null).Select(P => P.t_employeecardemplgrpassociation).Distinct(), "ID", "DisplayValue");
            if (t_employeecardemplgrpassociation != null)
            {
                var ids = t_employeecardemplgrpassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n CardEmplGrp= ";
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
                            var obj = db.T_CardEmplGrps.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_EmployeeCardEmplGrpAssociationID));
            }
				//if (lstT_Employee.Where(p => p.t_employeecardlvplanassociation != null).Count() <= 50)
		    //ViewBag.t_employeecardlvplanassociation = new SelectList(lstT_Employee.Where(p => p.t_employeecardlvplanassociation != null).Select(P => P.t_employeecardlvplanassociation).Distinct(), "ID", "DisplayValue");
            if (t_employeecardlvplanassociation != null)
            {
                var ids = t_employeecardlvplanassociation.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n CardAltLvPlan= ";
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
                            var obj = db.T_CardLvPlans.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_EmployeeCardLvPlanAssociationID));
            }
				//if (lstT_Employee.Where(p => p.t_employeeaddress != null).Count() <= 50)
		    //ViewBag.t_employeeaddress = new SelectList(lstT_Employee.Where(p => p.t_employeeaddress != null).Select(P => P.t_employeeaddress).Distinct(), "ID", "DisplayValue");
            if (t_employeeaddress != null)
            {
                var ids = t_employeeaddress.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee Address= ";
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
                            var obj = db.T_Addresss.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.T_EmployeeAddressID));
            }
				if (t_conversationalemployeeforeignlanguage != null)
            {
                var ids = t_conversationalemployeeforeignlanguage.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
                ViewBag.SearchResult += "\r\n  Conversational Foreign Language= ";
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
                        ViewBag.SearchResult += db.T_Langauges.Find(Convert.ToInt64(str)).DisplayValue + ", ";
                        ids1.AddRange(db.T_ConversationalEmployeeForeignLanguages.Where(p=>p.T_LangaugeID ==idvalue).Select(p=>p.T_EmployeeID));
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.Id));
            }
			if (t_languagecertifiedin != null)
            {
                var ids = t_languagecertifiedin.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
                ViewBag.SearchResult += "\r\n  Languages Certified In= ";
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
                        ViewBag.SearchResult += db.T_Langauges.Find(Convert.ToInt64(str)).DisplayValue + ", ";
                        ids1.AddRange(db.T_LanguageCertifiedIns.Where(p=>p.T_LangaugeID ==idvalue).Select(p=>p.T_EmployeeID));
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Employee = _T_Employee.Where(p => ids1.Contains(p.Id));
            }
			if (!string.IsNullOrEmpty(SortOrder))
            {
                ViewBag.SearchResult += " \r\n Sort Order = ";
                var sortString = "";
                var sortProps = SortOrder.Split(",".ToCharArray());
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee");
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
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee");
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
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_Employee"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_Employee"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
            //
            if (Convert.ToBoolean(IsExport))
            {
                pageNumber = 1;
                if (_T_Employee.Count() > 0)
                    pageSize = _T_Employee.Count();
                return View("ExcelExport", _T_Employee.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Employee.Count();
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
			  var list = _T_Employee.ToPagedList(pageNumber, pageSize);
			  if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_Employee", tagsSplit.ToArray());
                    }
			  ViewBag.EntityT_EmployeeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
			  TempData["T_Employeelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
              return View("Index",list);
			}
            else
			{
				var list = _T_Employee.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_EmployeeDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_Employeelist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_Employee", tagsSplit.ToArray());
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
		var entity = "T_Employee";
           var chartlist = db.Charts.Where(chrt => chrt.EntityName == entity && chrt.ShowInDashBoard).ToList();
           if (type != "all")
               chartlist = chartlist.Where(chrt => chrt.Id == Convert.ToInt64(type)).ToList();
           var entitylist = db.T_Employees;
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
                var gd = db.T_Employees.GroupBy(p => p.t_employeeatfacility.DisplayValue).ToList();
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
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Facility", "Employee"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "1", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).ToList();
                    if (_yvalT_PriorServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PriorServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PriorServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Facility (Top 10)"));
				else
				chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Facility"));
                chartT_PriorServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Facility", "T_PriorServiceinmonths"));
                chartT_PriorServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PriorServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_PriorServiceinmonths );
                chartT_PriorServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PriorServiceinmonths.Width = 800;
                        chartT_PriorServiceinmonths.Height = 800;
                    }
                byte[] bytesT_PriorServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PriorServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PriorServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PriorServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "2", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
                    else
                    {
                        string imgT_PriorServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
				}
			if (type == "3" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).ToList();
                    if (_yvalT_CurrentServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_CurrentServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_CurrentServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Facility (Top 10)"));
				else
				chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Facility"));
                chartT_CurrentServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Facility", "T_CurrentServiceinmonths"));
                chartT_CurrentServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_CurrentServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_CurrentServiceinmonths );
                chartT_CurrentServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_CurrentServiceinmonths.Width = 800;
                        chartT_CurrentServiceinmonths.Height = 800;
                    }
                byte[] bytesT_CurrentServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_CurrentServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_CurrentServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_CurrentServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "3", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
                    else
                    {
                        string imgT_CurrentServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
				}
			if (type == "4" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).ToList();
                    if (_yvalT_BadgeNumber .Count > 10 && inlarge == null)
                    {
                        _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_BadgeNumber  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_BadgeNumber.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Facility (Top 10)"));
				else
				chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Facility"));
                chartT_BadgeNumber.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Facility", "T_BadgeNumber"));
                chartT_BadgeNumber.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_BadgeNumber.Series[0].Points.DataBindXY(_xval, _yvalT_BadgeNumber );
                chartT_BadgeNumber.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_BadgeNumber.Width = 800;
                        chartT_BadgeNumber.Height = 800;
                    }
                byte[] bytesT_BadgeNumber;
                using (var chartimage = new MemoryStream())
                {
                    chartT_BadgeNumber.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_BadgeNumber = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_BadgeNumber = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "4", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
                    else
                    {
                        string imgT_BadgeNumber = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
				}
            }
           {
                var gd = db.T_Employees.GroupBy(p => p.t_employeestatus.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Employee Status (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Employee Status"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Employee Status", "Employee"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "5", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).ToList();
                    if (_yvalT_PriorServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PriorServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PriorServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Employee Status (Top 10)"));
				else
				chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Employee Status"));
                chartT_PriorServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Employee Status", "T_PriorServiceinmonths"));
                chartT_PriorServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PriorServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_PriorServiceinmonths );
                chartT_PriorServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PriorServiceinmonths.Width = 800;
                        chartT_PriorServiceinmonths.Height = 800;
                    }
                byte[] bytesT_PriorServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PriorServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PriorServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PriorServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "6", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
                    else
                    {
                        string imgT_PriorServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
				}
			if (type == "7" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).ToList();
                    if (_yvalT_CurrentServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_CurrentServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_CurrentServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Employee Status (Top 10)"));
				else
				chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Employee Status"));
                chartT_CurrentServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Employee Status", "T_CurrentServiceinmonths"));
                chartT_CurrentServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_CurrentServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_CurrentServiceinmonths );
                chartT_CurrentServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_CurrentServiceinmonths.Width = 800;
                        chartT_CurrentServiceinmonths.Height = 800;
                    }
                byte[] bytesT_CurrentServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_CurrentServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_CurrentServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_CurrentServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "7", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
                    else
                    {
                        string imgT_CurrentServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
				}
			if (type == "8" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).ToList();
                    if (_yvalT_BadgeNumber .Count > 10 && inlarge == null)
                    {
                        _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_BadgeNumber  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_BadgeNumber.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Employee Status (Top 10)"));
				else
				chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Employee Status"));
                chartT_BadgeNumber.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Employee Status", "T_BadgeNumber"));
                chartT_BadgeNumber.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_BadgeNumber.Series[0].Points.DataBindXY(_xval, _yvalT_BadgeNumber );
                chartT_BadgeNumber.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_BadgeNumber.Width = 800;
                        chartT_BadgeNumber.Height = 800;
                    }
                byte[] bytesT_BadgeNumber;
                using (var chartimage = new MemoryStream())
                {
                    chartT_BadgeNumber.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_BadgeNumber = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_BadgeNumber = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "8", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
                    else
                    {
                        string imgT_BadgeNumber = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
				}
            }
           {
                var gd = db.T_Employees.GroupBy(p => p.t_employeegender.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Gender (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Gender"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Gender", "Employee"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "9", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).ToList();
                    if (_yvalT_PriorServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PriorServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PriorServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Gender (Top 10)"));
				else
				chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Gender"));
                chartT_PriorServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Gender", "T_PriorServiceinmonths"));
                chartT_PriorServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PriorServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_PriorServiceinmonths );
                chartT_PriorServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PriorServiceinmonths.Width = 800;
                        chartT_PriorServiceinmonths.Height = 800;
                    }
                byte[] bytesT_PriorServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PriorServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PriorServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PriorServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "10", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
                    else
                    {
                        string imgT_PriorServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
				}
			if (type == "11" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).ToList();
                    if (_yvalT_CurrentServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_CurrentServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_CurrentServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Gender (Top 10)"));
				else
				chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Gender"));
                chartT_CurrentServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Gender", "T_CurrentServiceinmonths"));
                chartT_CurrentServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_CurrentServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_CurrentServiceinmonths );
                chartT_CurrentServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_CurrentServiceinmonths.Width = 800;
                        chartT_CurrentServiceinmonths.Height = 800;
                    }
                byte[] bytesT_CurrentServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_CurrentServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_CurrentServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_CurrentServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "11", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
                    else
                    {
                        string imgT_CurrentServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
				}
			if (type == "12" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).ToList();
                    if (_yvalT_BadgeNumber .Count > 10 && inlarge == null)
                    {
                        _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_BadgeNumber  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_BadgeNumber.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Gender (Top 10)"));
				else
				chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Gender"));
                chartT_BadgeNumber.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Gender", "T_BadgeNumber"));
                chartT_BadgeNumber.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_BadgeNumber.Series[0].Points.DataBindXY(_xval, _yvalT_BadgeNumber );
                chartT_BadgeNumber.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_BadgeNumber.Width = 800;
                        chartT_BadgeNumber.Height = 800;
                    }
                byte[] bytesT_BadgeNumber;
                using (var chartimage = new MemoryStream())
                {
                    chartT_BadgeNumber.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_BadgeNumber = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_BadgeNumber = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "12", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
                    else
                    {
                        string imgT_BadgeNumber = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
				}
            }
           {
                var gd = db.T_Employees.GroupBy(p => p.t_employeerace.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Race (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Race"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Race", "Employee"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "13", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).ToList();
                    if (_yvalT_PriorServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PriorServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PriorServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Race (Top 10)"));
				else
				chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Race"));
                chartT_PriorServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Race", "T_PriorServiceinmonths"));
                chartT_PriorServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PriorServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_PriorServiceinmonths );
                chartT_PriorServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PriorServiceinmonths.Width = 800;
                        chartT_PriorServiceinmonths.Height = 800;
                    }
                byte[] bytesT_PriorServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PriorServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PriorServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PriorServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "14", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
                    else
                    {
                        string imgT_PriorServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
				}
			if (type == "15" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).ToList();
                    if (_yvalT_CurrentServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_CurrentServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_CurrentServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Race (Top 10)"));
				else
				chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Race"));
                chartT_CurrentServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Race", "T_CurrentServiceinmonths"));
                chartT_CurrentServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_CurrentServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_CurrentServiceinmonths );
                chartT_CurrentServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_CurrentServiceinmonths.Width = 800;
                        chartT_CurrentServiceinmonths.Height = 800;
                    }
                byte[] bytesT_CurrentServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_CurrentServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_CurrentServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_CurrentServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "15", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
                    else
                    {
                        string imgT_CurrentServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
				}
			if (type == "16" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).ToList();
                    if (_yvalT_BadgeNumber .Count > 10 && inlarge == null)
                    {
                        _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_BadgeNumber  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_BadgeNumber.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Race (Top 10)"));
				else
				chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Race"));
                chartT_BadgeNumber.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Race", "T_BadgeNumber"));
                chartT_BadgeNumber.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_BadgeNumber.Series[0].Points.DataBindXY(_xval, _yvalT_BadgeNumber );
                chartT_BadgeNumber.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_BadgeNumber.Width = 800;
                        chartT_BadgeNumber.Height = 800;
                    }
                byte[] bytesT_BadgeNumber;
                using (var chartimage = new MemoryStream())
                {
                    chartT_BadgeNumber.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_BadgeNumber = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_BadgeNumber = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "16", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
                    else
                    {
                        string imgT_BadgeNumber = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
				}
            }
           {
                var gd = db.T_Employees.GroupBy(p => p.t_employeenationalityassociation.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Nationality (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Nationality"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Nationality", "Employee"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "17", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).ToList();
                    if (_yvalT_PriorServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PriorServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PriorServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Nationality (Top 10)"));
				else
				chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Nationality"));
                chartT_PriorServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Nationality", "T_PriorServiceinmonths"));
                chartT_PriorServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PriorServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_PriorServiceinmonths );
                chartT_PriorServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PriorServiceinmonths.Width = 800;
                        chartT_PriorServiceinmonths.Height = 800;
                    }
                byte[] bytesT_PriorServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PriorServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PriorServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PriorServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "18", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
                    else
                    {
                        string imgT_PriorServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
				}
			if (type == "19" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).ToList();
                    if (_yvalT_CurrentServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_CurrentServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_CurrentServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Nationality (Top 10)"));
				else
				chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Nationality"));
                chartT_CurrentServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Nationality", "T_CurrentServiceinmonths"));
                chartT_CurrentServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_CurrentServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_CurrentServiceinmonths );
                chartT_CurrentServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_CurrentServiceinmonths.Width = 800;
                        chartT_CurrentServiceinmonths.Height = 800;
                    }
                byte[] bytesT_CurrentServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_CurrentServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_CurrentServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_CurrentServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "19", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
                    else
                    {
                        string imgT_CurrentServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
				}
			if (type == "20" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).ToList();
                    if (_yvalT_BadgeNumber .Count > 10 && inlarge == null)
                    {
                        _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_BadgeNumber  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_BadgeNumber.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Nationality (Top 10)"));
				else
				chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Nationality"));
                chartT_BadgeNumber.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Nationality", "T_BadgeNumber"));
                chartT_BadgeNumber.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_BadgeNumber.Series[0].Points.DataBindXY(_xval, _yvalT_BadgeNumber );
                chartT_BadgeNumber.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_BadgeNumber.Width = 800;
                        chartT_BadgeNumber.Height = 800;
                    }
                byte[] bytesT_BadgeNumber;
                using (var chartimage = new MemoryStream())
                {
                    chartT_BadgeNumber.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_BadgeNumber = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_BadgeNumber = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "20", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
                    else
                    {
                        string imgT_BadgeNumber = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
				}
            }
           {
                var gd = db.T_Employees.GroupBy(p => p.t_employeeveteranstatus.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by Veteran Status (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Veteran Status"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Veteran Status", "Employee"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "21", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).ToList();
                    if (_yvalT_PriorServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PriorServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PriorServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Veteran Status (Top 10)"));
				else
				chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by Veteran Status"));
                chartT_PriorServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Veteran Status", "T_PriorServiceinmonths"));
                chartT_PriorServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PriorServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_PriorServiceinmonths );
                chartT_PriorServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PriorServiceinmonths.Width = 800;
                        chartT_PriorServiceinmonths.Height = 800;
                    }
                byte[] bytesT_PriorServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PriorServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PriorServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PriorServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "22", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
                    else
                    {
                        string imgT_PriorServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
				}
			if (type == "23" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).ToList();
                    if (_yvalT_CurrentServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_CurrentServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_CurrentServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Veteran Status (Top 10)"));
				else
				chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by Veteran Status"));
                chartT_CurrentServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Veteran Status", "T_CurrentServiceinmonths"));
                chartT_CurrentServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_CurrentServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_CurrentServiceinmonths );
                chartT_CurrentServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_CurrentServiceinmonths.Width = 800;
                        chartT_CurrentServiceinmonths.Height = 800;
                    }
                byte[] bytesT_CurrentServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_CurrentServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_CurrentServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_CurrentServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "23", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
                    else
                    {
                        string imgT_CurrentServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
				}
			if (type == "24" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).ToList();
                    if (_yvalT_BadgeNumber .Count > 10 && inlarge == null)
                    {
                        _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_BadgeNumber  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_BadgeNumber.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Veteran Status (Top 10)"));
				else
				chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by Veteran Status"));
                chartT_BadgeNumber.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "Veteran Status", "T_BadgeNumber"));
                chartT_BadgeNumber.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_BadgeNumber.Series[0].Points.DataBindXY(_xval, _yvalT_BadgeNumber );
                chartT_BadgeNumber.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_BadgeNumber.Width = 800;
                        chartT_BadgeNumber.Height = 800;
                    }
                byte[] bytesT_BadgeNumber;
                using (var chartimage = new MemoryStream())
                {
                    chartT_BadgeNumber.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_BadgeNumber = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_BadgeNumber = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "24", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
                    else
                    {
                        string imgT_BadgeNumber = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
				}
            }
           {
                var gd = db.T_Employees.GroupBy(p => p.t_employeecardemplgrpassociation.DisplayValue).ToList();
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
                chart.Titles.Add(CreateTitle("Count by CardEmplGrp (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by CardEmplGrp"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "CardEmplGrp", "Employee"));
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
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "25", inlarge = 1 }) + "')\"" : "") + "/></div>";
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
                    var _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).ToList();
                    if (_yvalT_PriorServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_PriorServiceinmonths = gd.Select(k => k.Sum(p=>p.T_PriorServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_PriorServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_PriorServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by CardEmplGrp (Top 10)"));
				else
				chartT_PriorServiceinmonths.Titles.Add(CreateTitle("Total of Prior Service (in months) by CardEmplGrp"));
                chartT_PriorServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "CardEmplGrp", "T_PriorServiceinmonths"));
                chartT_PriorServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_PriorServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_PriorServiceinmonths );
                chartT_PriorServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_PriorServiceinmonths.Width = 800;
                        chartT_PriorServiceinmonths.Height = 800;
                    }
                byte[] bytesT_PriorServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_PriorServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_PriorServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_PriorServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "26", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
                    else
                    {
                        string imgT_PriorServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_PriorServiceinmonths = Convert.ToBase64String(bytesT_PriorServiceinmonths.ToArray());
                        result += String.Format(imgT_PriorServiceinmonths, encodedT_PriorServiceinmonths);
                    }
				}
			if (type == "27" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).ToList();
                    if (_yvalT_CurrentServiceinmonths .Count > 10 && inlarge == null)
                    {
                        _yvalT_CurrentServiceinmonths = gd.Select(k => k.Sum(p=>p.T_CurrentServiceinmonths)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_CurrentServiceinmonths  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_CurrentServiceinmonths.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by CardEmplGrp (Top 10)"));
				else
				chartT_CurrentServiceinmonths.Titles.Add(CreateTitle("Total of Current Service (in months) by CardEmplGrp"));
                chartT_CurrentServiceinmonths.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "CardEmplGrp", "T_CurrentServiceinmonths"));
                chartT_CurrentServiceinmonths.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_CurrentServiceinmonths.Series[0].Points.DataBindXY(_xval, _yvalT_CurrentServiceinmonths );
                chartT_CurrentServiceinmonths.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_CurrentServiceinmonths.Width = 800;
                        chartT_CurrentServiceinmonths.Height = 800;
                    }
                byte[] bytesT_CurrentServiceinmonths;
                using (var chartimage = new MemoryStream())
                {
                    chartT_CurrentServiceinmonths.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_CurrentServiceinmonths = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_CurrentServiceinmonths = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "27", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
                    else
                    {
                        string imgT_CurrentServiceinmonths = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_CurrentServiceinmonths = Convert.ToBase64String(bytesT_CurrentServiceinmonths.ToArray());
                        result += String.Format(imgT_CurrentServiceinmonths, encodedT_CurrentServiceinmonths);
                    }
				}
			if (type == "28" || type == "all")
                {
			var cntgrt10 = false;
                    var _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).ToList();
                    if (_yvalT_BadgeNumber .Count > 10 && inlarge == null)
                    {
                        _yvalT_BadgeNumber = gd.Select(k => k.Sum(p=>p.T_BadgeNumber)).Take(10).ToList();
                        cntgrt10 = true;
                    }
			 var chartT_BadgeNumber  = new System.Web.UI.DataVisualization.Charting.Chart
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
                chartT_BadgeNumber.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by CardEmplGrp (Top 10)"));
				else
				chartT_BadgeNumber.Titles.Add(CreateTitle("Total of Badge Number by CardEmplGrp"));
                chartT_BadgeNumber.ChartAreas.Add(CreateChartArea(SeriesChartType.Column,"", "CardEmplGrp", "T_BadgeNumber"));
                chartT_BadgeNumber.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chartT_BadgeNumber.Series[0].Points.DataBindXY(_xval, _yvalT_BadgeNumber );
                chartT_BadgeNumber.Legends.Add(CreateLegend(""));
				if (inlarge != null)
                    {
                        chartT_BadgeNumber.Width = 800;
                        chartT_BadgeNumber.Height = 800;
                    }
                byte[] bytesT_BadgeNumber;
                using (var chartimage = new MemoryStream())
                {
                    chartT_BadgeNumber.SaveImage(chartimage, ChartImageFormat.Png);
                    bytesT_BadgeNumber = chartimage.GetBuffer();
                }
				 if (cntgrt10)
                    {
                        string imgT_BadgeNumber = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_Employee", new { type = "28", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
                    }
                    else
                    {
                        string imgT_BadgeNumber = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                        string encodedT_BadgeNumber = Convert.ToBase64String(bytesT_BadgeNumber.ToArray());
                        result += String.Format(imgT_BadgeNumber, encodedT_BadgeNumber);
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
            var _Obj = db1.T_Employees.FirstOrDefault(p => p.Id == idvalue);
            return  _Obj==null?"":_Obj.DisplayValue;
        }
		public IQueryable<JournalEntry> GetExtraJournalEntry(int? id, Models.IUser user, JournalEntryContext jedb)
        {
			var listjournaliquery = jedb.JournalEntries.Where(p => p.Id == 0);
			Expression<Func<JournalEntry, bool>> predicateJournalEntry = n => false;
		var t_employee = jedb.T_Employees.Find(id);
			var T_LicenseRecordsIds = jedb.T_Licensess.Where(p=>p.T_LicenseRecordsID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_Licenses" && T_LicenseRecordsIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeEmployeeInjuryIds = jedb.T_EmployeeInjurys.Where(p=>p.T_EmployeeEmployeeInjuryID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_EmployeeInjury" && T_EmployeeEmployeeInjuryIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeCriminalBackgroundCheckIds = jedb.T_BackgroundChecks.Where(p=>p.T_EmployeeCriminalBackgroundCheckID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_BackgroundCheck" && T_EmployeeCriminalBackgroundCheckIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeCommentsIds = jedb.T_Comments.Where(p=>p.T_EmployeeCommentsID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_Comment" && T_EmployeeCommentsIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeLeaveProfileIds = jedb.T_LeaveProfiles.Where(p=>p.T_EmployeeLeaveProfileID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_LeaveProfile" && T_EmployeeLeaveProfileIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeEducationIds = jedb.T_Educations.Where(p=>p.T_EmployeeEducationID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_Education" && T_EmployeeEducationIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeAccomodationIds = jedb.T_Accommodations.Where(p=>p.T_EmployeeAccomodationID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_Accommodation" && T_EmployeeAccomodationIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeEmploymentProfileIds = jedb.T_ServiceRecords.Where(p=>p.T_EmployeeEmploymentProfileID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_ServiceRecord" && T_EmployeeEmploymentProfileIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeJobAssignmentIds = jedb.T_JobAssignments.Where(p=>p.T_EmployeeJobAssignmentID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_JobAssignment" && T_EmployeeJobAssignmentIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeePayDetailsIds = jedb.T_PayDetailss.Where(p=>p.T_EmployeePayDetailsID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_PayDetails" && T_EmployeePayDetailsIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeDrugAlcoholTestIds = jedb.T_DrugAlcoholTests.Where(p=>p.T_EmployeeDrugAlcoholTestID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_DrugAlcoholTest" && T_EmployeeDrugAlcoholTestIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeAdministratorIds = jedb.T_UnitXs.Where(p=>p.T_EmployeeAdministratorID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_UnitX" && T_EmployeeAdministratorIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeUnitXHeadIds = jedb.T_UnitXs.Where(p=>p.T_EmployeeUnitXHeadID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_UnitX" && T_EmployeeUnitXHeadIds.Contains(d.RecordId) && d.Type != "View"));
			var T_JobAssignmentManagerEmployeeIds = jedb.T_JobAssignments.Where(p=>p.T_JobAssignmentManagerEmployeeID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_JobAssignment" && T_JobAssignmentManagerEmployeeIds.Contains(d.RecordId) && d.Type != "View"));
			var T_EmployeeSupervisorIds = jedb.T_JobAssignments.Where(p=>p.T_EmployeeSupervisorID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_JobAssignment" && T_EmployeeSupervisorIds.Contains(d.RecordId) && d.Type != "View"));
			var T_ReviewerIds = jedb.T_BackgroundChecks.Where(p=>p.T_ReviewerID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_BackgroundCheck" && T_ReviewerIds.Contains(d.RecordId) && d.Type != "View"));
			
			listjournaliquery = new FilteredDbSet<JournalEntry>(jedb, predicateJournalEntry); 
			return listjournaliquery;
        }
		public object GetRecordById(string id)
        {
		            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            if (string.IsNullOrEmpty(id)) return "";
            var _Obj = db1.T_Employees.Find(Convert.ToInt64(id));
            return _Obj;
        }
		public string GetRecordById_Reflection(string id)
        {
							ApplicationContext db1 = new ApplicationContext(new SystemUser());
			if (string.IsNullOrEmpty(id)) return "";
			var _Obj = db1.T_Employees.Find(Convert.ToInt64(id));
            return _Obj == null ? "" : EntityComparer.EnumeratePropertyValues<T_Employee>(_Obj, "T_Employee", new string[] { ""  }); ;
			        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllValueForFilter(string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
		            IQueryable<T_Employee> list = db.T_Employees;
            var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                       select new { Id = x.Id, Name = x.DisplayValue };
            return Json(data, JsonRequestBehavior.AllowGet);
			        }
		[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValue(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_Employee> list = db.T_Employees;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_Employees;
					string lambda = "";
                    foreach (var asso in AssoNameWithParent.Split("?".ToCharArray()))
                    {
                        lambda += asso + "=" + AssociationID + " OR ";
                    }
                    lambda = lambda.TrimEnd(" OR ".ToCharArray());
                    query = query.Where(lambda);
                   //Type[] exprArgTypes = { query.ElementType };
                   // string propToWhere = AssoNameWithParent;
                   // ParameterExpression p = Expression.Parameter(typeof(T_Employee), "p");
                   // MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                   // LambdaExpression lambda = Expression.Lambda<Func<T_Employee, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                   // MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                   // IQueryable q = query.Provider.CreateQuery(methodCall);
                   //list = ((IQueryable<T_Employee>)q);
				   list = ((IQueryable<T_Employee>)query);
                }
				else if (AssoID == 0)
                {
                   IQueryable query = db.T_Employees;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_Employee), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_Employee, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_Employee>)q);
                }
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_Employee>(User,list, "T_Employee",caller);
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
			IQueryable<T_Employee> list = db.T_Employees;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_Employees;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_Employee), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_Employee, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_Employee>)q);
                }
            }
			var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
        }
[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValueMobile(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_Employee> list = db.T_Employees;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
				try
                {
					Nullable<long> AssoID = Convert.ToInt64(AssociationID);
					if (AssoID != null && AssoID > 0)
					{
						IQueryable query = db.T_Employees;
						Type[] exprArgTypes = { query.ElementType };
						string propToWhere = AssoNameWithParent;
						ParameterExpression p = Expression.Parameter(typeof(T_Employee), "p");
						MemberExpression member = Expression.PropertyOrField(p, propToWhere);
						LambdaExpression lambda = Expression.Lambda<Func<T_Employee, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
						MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
						IQueryable q = query.Provider.CreateQuery(methodCall);
						list = ((IQueryable<T_Employee>)q).Take(20);
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
           list = _fad.FilterDropdown<T_Employee>(User,list, "T_Employee",caller);
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
            IQueryable<T_Employee> list = db.T_Employees;
            if (!string.IsNullOrEmpty(propNameBR))
            {
				//added new code (Remove old code if everything works)
				var result = list.Select("new(Id," + propNameBR + " as value)");
                return Json(result, JsonRequestBehavior.AllowGet);
				//
                ParameterExpression param = Expression.Parameter(typeof(T_Employee), "d");
                //bulid expression tree:data.Field1
                var Property = typeof(T_Employee).GetProperty(propNameBR);
                Expression selector = Expression.Property(param, Property);
                Expression pred = Expression.Lambda(selector, param);
                //bulid expression tree:Select(d=>d.Field1)
                var targetType = Property.PropertyType;
                if (targetType.GetGenericArguments().Count() > 0)
                {
                    if (targetType.GetGenericArguments()[0].Name == "DateTime")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select", 
                        new Type[] { typeof(T_Employee), typeof(DateTime?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<DateTime?> query = list.Provider.CreateQuery<DateTime?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (targetType.GetGenericArguments()[0].Name == "Decimal")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Employee), typeof(decimal?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<decimal?> query = list.Provider.CreateQuery<decimal?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Boolean")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Employee), typeof(bool?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<bool?> query = list.Provider.CreateQuery<bool?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int32")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Employee), typeof(Int32?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int32?> query = list.Provider.CreateQuery<Int32?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int64")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Employee), typeof(Int64?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int64?> query = list.Provider.CreateQuery<Int64?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Double")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Employee), typeof(double?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<double?> query = list.Provider.CreateQuery<double?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    Expression expr = Expression.Call(typeof(Queryable), "Select",
                            new Type[] { typeof(T_Employee), typeof(string) }, Expression.Constant(list.AsQueryable()), pred);
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
			IQueryable<T_Employee> list = db.T_Employees;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                IQueryable query = db.T_Employees;
                Type[] exprArgTypes = { query.ElementType };
                string propToWhere = AssoNameWithParent;
                var AssoIDs = AssociationID.Split(',').ToList();
                List<ParameterExpression> paramList = new List<ParameterExpression>();
                paramList.Add(Expression.Parameter(typeof(T_Employee), "p"));
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
                list = ((IQueryable<T_Employee>)q);
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
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

			if (!((CustomPrincipal)User).CanUseVerb("ImportExcel", "T_Employee", User) || !User.CanAdd("T_Employee"))
            {
                return RedirectToAction("Index", "Error");
            }
            //ViewBag.IsMapping = (db.ImportConfigurations.Where(p => p.Name == "T_Employee")).Count() > 0 ? true : false;
            var lstMappings = db.ImportConfigurations.Where(p => p.Name == "T_Employee").ToList();
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
                    var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_Employee");
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
                        typeName = "T_Employee";
                        //var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        //long idMapping = Convert.ToInt64(collection["ListOfMappings"]);
						string idMapping = collection["ListOfMappings"];
                        string ExistsColumnMappingName = string.Empty;
                        string mappingName = idMapping; //db.ImportConfigurations.Where(p => p.Name == typeName && p.Id == idMapping && !(string.IsNullOrEmpty(p.SheetColumn))).FirstOrDefault().MappingName;
                        var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && p.MappingName == mappingName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        if (collection["DefaultMapping"] == "on")
                        {
                            var lstMapping = db.ImportConfigurations.Where(p => p.Name == "T_Employee" && p.IsDefaultMapping);
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
                        DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Employees";
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
                                										 case "T_EmployeeAtFacilityID":
										 var t_employeeatfacilityId = db.T_Facilitys.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeatfacilityId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeStatusID":
										 var t_employeestatusId = db.T_EmployeeStatusCodes.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeestatusId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_CurrentEmployeeEmploymentProfileID":
										 var t_currentemployeeemploymentprofileId = db.T_ServiceRecords.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_currentemployeeemploymentprofileId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_CurrentEmployeeJobAssignmentID":
										 var t_currentemployeejobassignmentId = db.T_JobAssignments.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_currentemployeejobassignmentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeGenderID":
										 var t_employeegenderId = db.T_Genders.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeegenderId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeRaceID":
										 var t_employeeraceId = db.T_Races.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeraceId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeNationalityAssociationID":
										 var t_employeenationalityassociationId = db.T_Nationalitys.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeenationalityassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeVeteranStatusID":
										 var t_employeeveteranstatusId = db.T_VeteranStatuss.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeveteranstatusId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeCardEmplGrpAssociationID":
										 var t_employeecardemplgrpassociationId = db.T_CardEmplGrps.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeecardemplgrpassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeCardLvPlanAssociationID":
										 var t_employeecardlvplanassociationId = db.T_CardLvPlans.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeecardlvplanassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeAddressID":
										 var t_employeeaddressId = db.T_Addresss.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeaddressId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeUserLoginID":
										 var t_employeeuserloginId = UserContext.Users.FirstOrDefault(p => p.UserName == assovalue);
										 if (t_employeeuserloginId == null)
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
			string typename = "T_Employee";
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
                DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Employees";
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
                var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_Employee");
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
                                										 case "T_EmployeeAtFacilityID":
										 var strPropertyT_EmployeeAtFacility = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeAtFacilityID").Value;
										 ModelReflector.Property propT_EmployeeAtFacility = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Facility").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeAtFacility);
										 //var elementTypeT_EmployeeAtFacility = db.T_Facilitys.ElementType;
										 //var propertyInfoT_EmployeeAtFacility = elementTypeT_EmployeeAtFacility.GetProperty(propT_EmployeeAtFacility.Name);
										 // var t_employeeatfacilityId = db.T_Facilitys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeAtFacility.GetValue(p, null)) == assovalue);
										 var t_employeeatfacilityId = db.T_Facilitys.Where(propT_EmployeeAtFacility.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeatfacilityId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeStatusID":
										 var strPropertyT_EmployeeStatus = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeStatusID").Value;
										 ModelReflector.Property propT_EmployeeStatus = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeStatusCode").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeStatus);
										 //var elementTypeT_EmployeeStatus = db.T_EmployeeStatusCodes.ElementType;
										 //var propertyInfoT_EmployeeStatus = elementTypeT_EmployeeStatus.GetProperty(propT_EmployeeStatus.Name);
										 // var t_employeestatusId = db.T_EmployeeStatusCodes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeStatus.GetValue(p, null)) == assovalue);
										 var t_employeestatusId = db.T_EmployeeStatusCodes.Where(propT_EmployeeStatus.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeestatusId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_CurrentEmployeeEmploymentProfileID":
										 var strPropertyT_CurrentEmployeeEmploymentProfile = lstEntityProp.FirstOrDefault(p => p.Key == "T_CurrentEmployeeEmploymentProfileID").Value;
										 ModelReflector.Property propT_CurrentEmployeeEmploymentProfile = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ServiceRecord").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_CurrentEmployeeEmploymentProfile);
										 //var elementTypeT_CurrentEmployeeEmploymentProfile = db.T_ServiceRecords.ElementType;
										 //var propertyInfoT_CurrentEmployeeEmploymentProfile = elementTypeT_CurrentEmployeeEmploymentProfile.GetProperty(propT_CurrentEmployeeEmploymentProfile.Name);
										 // var t_currentemployeeemploymentprofileId = db.T_ServiceRecords.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_CurrentEmployeeEmploymentProfile.GetValue(p, null)) == assovalue);
										 var t_currentemployeeemploymentprofileId = db.T_ServiceRecords.Where(propT_CurrentEmployeeEmploymentProfile.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_currentemployeeemploymentprofileId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_CurrentEmployeeJobAssignmentID":
										 var strPropertyT_CurrentEmployeeJobAssignment = lstEntityProp.FirstOrDefault(p => p.Key == "T_CurrentEmployeeJobAssignmentID").Value;
										 ModelReflector.Property propT_CurrentEmployeeJobAssignment = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_JobAssignment").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_CurrentEmployeeJobAssignment);
										 //var elementTypeT_CurrentEmployeeJobAssignment = db.T_JobAssignments.ElementType;
										 //var propertyInfoT_CurrentEmployeeJobAssignment = elementTypeT_CurrentEmployeeJobAssignment.GetProperty(propT_CurrentEmployeeJobAssignment.Name);
										 // var t_currentemployeejobassignmentId = db.T_JobAssignments.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_CurrentEmployeeJobAssignment.GetValue(p, null)) == assovalue);
										 var t_currentemployeejobassignmentId = db.T_JobAssignments.Where(propT_CurrentEmployeeJobAssignment.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_currentemployeejobassignmentId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeGenderID":
										 var strPropertyT_EmployeeGender = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeGenderID").Value;
										 ModelReflector.Property propT_EmployeeGender = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Gender").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeGender);
										 //var elementTypeT_EmployeeGender = db.T_Genders.ElementType;
										 //var propertyInfoT_EmployeeGender = elementTypeT_EmployeeGender.GetProperty(propT_EmployeeGender.Name);
										 // var t_employeegenderId = db.T_Genders.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeGender.GetValue(p, null)) == assovalue);
										 var t_employeegenderId = db.T_Genders.Where(propT_EmployeeGender.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeegenderId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeRaceID":
										 var strPropertyT_EmployeeRace = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeRaceID").Value;
										 ModelReflector.Property propT_EmployeeRace = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Race").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeRace);
										 //var elementTypeT_EmployeeRace = db.T_Races.ElementType;
										 //var propertyInfoT_EmployeeRace = elementTypeT_EmployeeRace.GetProperty(propT_EmployeeRace.Name);
										 // var t_employeeraceId = db.T_Races.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeRace.GetValue(p, null)) == assovalue);
										 var t_employeeraceId = db.T_Races.Where(propT_EmployeeRace.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeraceId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeNationalityAssociationID":
										 var strPropertyT_EmployeeNationalityAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeNationalityAssociationID").Value;
										 ModelReflector.Property propT_EmployeeNationalityAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Nationality").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeNationalityAssociation);
										 //var elementTypeT_EmployeeNationalityAssociation = db.T_Nationalitys.ElementType;
										 //var propertyInfoT_EmployeeNationalityAssociation = elementTypeT_EmployeeNationalityAssociation.GetProperty(propT_EmployeeNationalityAssociation.Name);
										 // var t_employeenationalityassociationId = db.T_Nationalitys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeNationalityAssociation.GetValue(p, null)) == assovalue);
										 var t_employeenationalityassociationId = db.T_Nationalitys.Where(propT_EmployeeNationalityAssociation.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeenationalityassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeVeteranStatusID":
										 var strPropertyT_EmployeeVeteranStatus = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeVeteranStatusID").Value;
										 ModelReflector.Property propT_EmployeeVeteranStatus = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_VeteranStatus").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeVeteranStatus);
										 //var elementTypeT_EmployeeVeteranStatus = db.T_VeteranStatuss.ElementType;
										 //var propertyInfoT_EmployeeVeteranStatus = elementTypeT_EmployeeVeteranStatus.GetProperty(propT_EmployeeVeteranStatus.Name);
										 // var t_employeeveteranstatusId = db.T_VeteranStatuss.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeVeteranStatus.GetValue(p, null)) == assovalue);
										 var t_employeeveteranstatusId = db.T_VeteranStatuss.Where(propT_EmployeeVeteranStatus.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeveteranstatusId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeCardEmplGrpAssociationID":
										 var strPropertyT_EmployeeCardEmplGrpAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeCardEmplGrpAssociationID").Value;
										 ModelReflector.Property propT_EmployeeCardEmplGrpAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_CardEmplGrp").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeCardEmplGrpAssociation);
										 //var elementTypeT_EmployeeCardEmplGrpAssociation = db.T_CardEmplGrps.ElementType;
										 //var propertyInfoT_EmployeeCardEmplGrpAssociation = elementTypeT_EmployeeCardEmplGrpAssociation.GetProperty(propT_EmployeeCardEmplGrpAssociation.Name);
										 // var t_employeecardemplgrpassociationId = db.T_CardEmplGrps.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeCardEmplGrpAssociation.GetValue(p, null)) == assovalue);
										 var t_employeecardemplgrpassociationId = db.T_CardEmplGrps.Where(propT_EmployeeCardEmplGrpAssociation.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeecardemplgrpassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeCardLvPlanAssociationID":
										 var strPropertyT_EmployeeCardLvPlanAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeCardLvPlanAssociationID").Value;
										 ModelReflector.Property propT_EmployeeCardLvPlanAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_CardLvPlan").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeCardLvPlanAssociation);
										 //var elementTypeT_EmployeeCardLvPlanAssociation = db.T_CardLvPlans.ElementType;
										 //var propertyInfoT_EmployeeCardLvPlanAssociation = elementTypeT_EmployeeCardLvPlanAssociation.GetProperty(propT_EmployeeCardLvPlanAssociation.Name);
										 // var t_employeecardlvplanassociationId = db.T_CardLvPlans.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeCardLvPlanAssociation.GetValue(p, null)) == assovalue);
										 var t_employeecardlvplanassociationId = db.T_CardLvPlans.Where(propT_EmployeeCardLvPlanAssociation.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeecardlvplanassociationId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeAddressID":
										 var strPropertyT_EmployeeAddress = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeAddressID").Value;
										 ModelReflector.Property propT_EmployeeAddress = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Address").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeAddress);
										 //var elementTypeT_EmployeeAddress = db.T_Addresss.ElementType;
										 //var propertyInfoT_EmployeeAddress = elementTypeT_EmployeeAddress.GetProperty(propT_EmployeeAddress.Name);
										 // var t_employeeaddressId = db.T_Addresss.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeAddress.GetValue(p, null)) == assovalue);
										 var t_employeeaddressId = db.T_Addresss.Where(propT_EmployeeAddress.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeaddressId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeUserLoginID":
										 var t_employeeuserloginId = UserContext.Users.FirstOrDefault(p => p.UserName == assovalue);
										 if (t_employeeuserloginId == null)
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
                        T_Employee model = new T_Employee();
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
    case "T_PID":
    model.T_PID = columnValue;
	break;
    case "T_SSN":
    model.T_SSN = columnValue;
	break;
    case "T_DateOfBirth":
    model.T_DateOfBirth = DateTime.Parse(columnValue);
	break;
    case "T_SAMAccount":
    model.T_SAMAccount = columnValue;
	break;
    case "T_LastName":
    model.T_LastName = columnValue;
	break;
    case "T_FirstName":
    model.T_FirstName = columnValue;
	break;
    case "T_MiddleName":
    model.T_MiddleName = columnValue;
	break;
    case "T_Suffix":
    model.T_Suffix = columnValue;
	break;
    case "T_WorkEmail":
    model.T_WorkEmail = columnValue;
	break;
    case "T_StateHireDate":
    model.T_StateHireDate = DateTime.Parse(columnValue);
	break;
    case "T_AdjustedHireDate":
    model.T_AdjustedHireDate = DateTime.Parse(columnValue);
	break;
    case "T_PriorServiceinmonths":
    model.T_PriorServiceinmonths = Int32.Parse(columnValue);
	break;
    case "T_CurrentServiceinmonths":
    model.T_CurrentServiceinmonths = Int32.Parse(columnValue);
	break;
    case "T_PersonalEmail":
    model.T_PersonalEmail = columnValue;
	break;
    case "T_MobilePhone":
    model.T_MobilePhone = columnValue;
	break;
    case "T_HomePhone":
    model.T_HomePhone = columnValue;
	break;
    case "T_EmergencyContactName":
    model.T_EmergencyContactName = columnValue;
	break;
    case "T_EmergencyContactRelationship":
    model.T_EmergencyContactRelationship = columnValue;
	break;
    case "T_EmergencyMobilePhone":
    model.T_EmergencyMobilePhone = columnValue;
	break;
    case "T_EmergencyWorkPhone":
    model.T_EmergencyWorkPhone = columnValue;
	break;
    case "T_BadgeNumber":
    model.T_BadgeNumber = Int32.Parse(columnValue);
	break;
    case "T_EffectiveDateTime":
    model.T_EffectiveDateTime = DateTime.Parse(columnValue);
	break;
					 case "T_EmployeeAtFacilityID":
		 dynamic t_employeeatfacilityId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeAtFacility = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeAtFacilityID").Value;
			 ModelReflector.Property propT_EmployeeAtFacility = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Facility").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeAtFacility);
			 //var elementTypeT_EmployeeAtFacility = db.T_Facilitys.ElementType;
			 //var propertyInfoT_EmployeeAtFacility = elementTypeT_EmployeeAtFacility.GetProperty(propT_EmployeeAtFacility.Name);			 
			 //t_employeeatfacilityId = db.T_Facilitys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeAtFacility.GetValue(p, null)) == columnValue);
			 t_employeeatfacilityId = db.T_Facilitys.Where(propT_EmployeeAtFacility.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeatfacilityId = db.T_Facilitys.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeatfacilityId != null)
			model.T_EmployeeAtFacilityID = t_employeeatfacilityId.Id;
		  else
			{
				if ((collection["T_EmployeeAtFacilityID"].ToString() == "true,false"))
				{
					try
					{
						T_Facility objT_Facility = new T_Facility();
						objT_Facility.T_FacilityCode  = (columnValue);
						db.T_Facilitys.Add(objT_Facility);
						db.SaveChanges();
						model.T_EmployeeAtFacilityID = objT_Facility.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeStatusID":
		 dynamic t_employeestatusId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeStatus = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeStatusID").Value;
			 ModelReflector.Property propT_EmployeeStatus = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeStatusCode").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeStatus);
			 //var elementTypeT_EmployeeStatus = db.T_EmployeeStatusCodes.ElementType;
			 //var propertyInfoT_EmployeeStatus = elementTypeT_EmployeeStatus.GetProperty(propT_EmployeeStatus.Name);			 
			 //t_employeestatusId = db.T_EmployeeStatusCodes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeStatus.GetValue(p, null)) == columnValue);
			 t_employeestatusId = db.T_EmployeeStatusCodes.Where(propT_EmployeeStatus.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeestatusId = db.T_EmployeeStatusCodes.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeestatusId != null)
			model.T_EmployeeStatusID = t_employeestatusId.Id;
		  else
			{
				if ((collection["T_EmployeeStatusID"].ToString() == "true,false"))
				{
					try
					{
						T_EmployeeStatusCode objT_EmployeeStatusCode = new T_EmployeeStatusCode();
						objT_EmployeeStatusCode.T_Name  = (columnValue);
						db.T_EmployeeStatusCodes.Add(objT_EmployeeStatusCode);
						db.SaveChanges();
						model.T_EmployeeStatusID = objT_EmployeeStatusCode.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_CurrentEmployeeEmploymentProfileID":
		 dynamic t_currentemployeeemploymentprofileId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_CurrentEmployeeEmploymentProfile = lstEntityProp.FirstOrDefault(p => p.Key == "T_CurrentEmployeeEmploymentProfileID").Value;
			 ModelReflector.Property propT_CurrentEmployeeEmploymentProfile = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ServiceRecord").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_CurrentEmployeeEmploymentProfile);
			 //var elementTypeT_CurrentEmployeeEmploymentProfile = db.T_ServiceRecords.ElementType;
			 //var propertyInfoT_CurrentEmployeeEmploymentProfile = elementTypeT_CurrentEmployeeEmploymentProfile.GetProperty(propT_CurrentEmployeeEmploymentProfile.Name);			 
			 //t_currentemployeeemploymentprofileId = db.T_ServiceRecords.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_CurrentEmployeeEmploymentProfile.GetValue(p, null)) == columnValue);
			 t_currentemployeeemploymentprofileId = db.T_ServiceRecords.Where(propT_CurrentEmployeeEmploymentProfile.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_currentemployeeemploymentprofileId = db.T_ServiceRecords.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_currentemployeeemploymentprofileId != null)
			model.T_CurrentEmployeeEmploymentProfileID = t_currentemployeeemploymentprofileId.Id;
         break;
		 case "T_CurrentEmployeeJobAssignmentID":
		 dynamic t_currentemployeejobassignmentId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_CurrentEmployeeJobAssignment = lstEntityProp.FirstOrDefault(p => p.Key == "T_CurrentEmployeeJobAssignmentID").Value;
			 ModelReflector.Property propT_CurrentEmployeeJobAssignment = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_JobAssignment").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_CurrentEmployeeJobAssignment);
			 //var elementTypeT_CurrentEmployeeJobAssignment = db.T_JobAssignments.ElementType;
			 //var propertyInfoT_CurrentEmployeeJobAssignment = elementTypeT_CurrentEmployeeJobAssignment.GetProperty(propT_CurrentEmployeeJobAssignment.Name);			 
			 //t_currentemployeejobassignmentId = db.T_JobAssignments.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_CurrentEmployeeJobAssignment.GetValue(p, null)) == columnValue);
			 t_currentemployeejobassignmentId = db.T_JobAssignments.Where(propT_CurrentEmployeeJobAssignment.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_currentemployeejobassignmentId = db.T_JobAssignments.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_currentemployeejobassignmentId != null)
			model.T_CurrentEmployeeJobAssignmentID = t_currentemployeejobassignmentId.Id;
         break;
		 case "T_EmployeeGenderID":
		 dynamic t_employeegenderId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeGender = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeGenderID").Value;
			 ModelReflector.Property propT_EmployeeGender = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Gender").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeGender);
			 //var elementTypeT_EmployeeGender = db.T_Genders.ElementType;
			 //var propertyInfoT_EmployeeGender = elementTypeT_EmployeeGender.GetProperty(propT_EmployeeGender.Name);			 
			 //t_employeegenderId = db.T_Genders.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeGender.GetValue(p, null)) == columnValue);
			 t_employeegenderId = db.T_Genders.Where(propT_EmployeeGender.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeegenderId = db.T_Genders.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeegenderId != null)
			model.T_EmployeeGenderID = t_employeegenderId.Id;
		  else
			{
				if ((collection["T_EmployeeGenderID"].ToString() == "true,false"))
				{
					try
					{
						T_Gender objT_Gender = new T_Gender();
						objT_Gender.T_Name  = (columnValue);
						db.T_Genders.Add(objT_Gender);
						db.SaveChanges();
						model.T_EmployeeGenderID = objT_Gender.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeRaceID":
		 dynamic t_employeeraceId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeRace = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeRaceID").Value;
			 ModelReflector.Property propT_EmployeeRace = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Race").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeRace);
			 //var elementTypeT_EmployeeRace = db.T_Races.ElementType;
			 //var propertyInfoT_EmployeeRace = elementTypeT_EmployeeRace.GetProperty(propT_EmployeeRace.Name);			 
			 //t_employeeraceId = db.T_Races.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeRace.GetValue(p, null)) == columnValue);
			 t_employeeraceId = db.T_Races.Where(propT_EmployeeRace.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeraceId = db.T_Races.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeraceId != null)
			model.T_EmployeeRaceID = t_employeeraceId.Id;
		  else
			{
				if ((collection["T_EmployeeRaceID"].ToString() == "true,false"))
				{
					try
					{
						T_Race objT_Race = new T_Race();
						objT_Race.T_Name  = (columnValue);
						db.T_Races.Add(objT_Race);
						db.SaveChanges();
						model.T_EmployeeRaceID = objT_Race.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeNationalityAssociationID":
		 dynamic t_employeenationalityassociationId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeNationalityAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeNationalityAssociationID").Value;
			 ModelReflector.Property propT_EmployeeNationalityAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Nationality").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeNationalityAssociation);
			 //var elementTypeT_EmployeeNationalityAssociation = db.T_Nationalitys.ElementType;
			 //var propertyInfoT_EmployeeNationalityAssociation = elementTypeT_EmployeeNationalityAssociation.GetProperty(propT_EmployeeNationalityAssociation.Name);			 
			 //t_employeenationalityassociationId = db.T_Nationalitys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeNationalityAssociation.GetValue(p, null)) == columnValue);
			 t_employeenationalityassociationId = db.T_Nationalitys.Where(propT_EmployeeNationalityAssociation.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeenationalityassociationId = db.T_Nationalitys.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeenationalityassociationId != null)
			model.T_EmployeeNationalityAssociationID = t_employeenationalityassociationId.Id;
		  else
			{
				if ((collection["T_EmployeeNationalityAssociationID"].ToString() == "true,false"))
				{
					try
					{
						T_Nationality objT_Nationality = new T_Nationality();
						objT_Nationality.T_Name  = (columnValue);
						db.T_Nationalitys.Add(objT_Nationality);
						db.SaveChanges();
						model.T_EmployeeNationalityAssociationID = objT_Nationality.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeVeteranStatusID":
		 dynamic t_employeeveteranstatusId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeVeteranStatus = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeVeteranStatusID").Value;
			 ModelReflector.Property propT_EmployeeVeteranStatus = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_VeteranStatus").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeVeteranStatus);
			 //var elementTypeT_EmployeeVeteranStatus = db.T_VeteranStatuss.ElementType;
			 //var propertyInfoT_EmployeeVeteranStatus = elementTypeT_EmployeeVeteranStatus.GetProperty(propT_EmployeeVeteranStatus.Name);			 
			 //t_employeeveteranstatusId = db.T_VeteranStatuss.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeVeteranStatus.GetValue(p, null)) == columnValue);
			 t_employeeveteranstatusId = db.T_VeteranStatuss.Where(propT_EmployeeVeteranStatus.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeveteranstatusId = db.T_VeteranStatuss.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeveteranstatusId != null)
			model.T_EmployeeVeteranStatusID = t_employeeveteranstatusId.Id;
		  else
			{
				if ((collection["T_EmployeeVeteranStatusID"].ToString() == "true,false"))
				{
					try
					{
						T_VeteranStatus objT_VeteranStatus = new T_VeteranStatus();
						objT_VeteranStatus.T_Name  = (columnValue);
						db.T_VeteranStatuss.Add(objT_VeteranStatus);
						db.SaveChanges();
						model.T_EmployeeVeteranStatusID = objT_VeteranStatus.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeCardEmplGrpAssociationID":
		 dynamic t_employeecardemplgrpassociationId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeCardEmplGrpAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeCardEmplGrpAssociationID").Value;
			 ModelReflector.Property propT_EmployeeCardEmplGrpAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_CardEmplGrp").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeCardEmplGrpAssociation);
			 //var elementTypeT_EmployeeCardEmplGrpAssociation = db.T_CardEmplGrps.ElementType;
			 //var propertyInfoT_EmployeeCardEmplGrpAssociation = elementTypeT_EmployeeCardEmplGrpAssociation.GetProperty(propT_EmployeeCardEmplGrpAssociation.Name);			 
			 //t_employeecardemplgrpassociationId = db.T_CardEmplGrps.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeCardEmplGrpAssociation.GetValue(p, null)) == columnValue);
			 t_employeecardemplgrpassociationId = db.T_CardEmplGrps.Where(propT_EmployeeCardEmplGrpAssociation.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeecardemplgrpassociationId = db.T_CardEmplGrps.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeecardemplgrpassociationId != null)
			model.T_EmployeeCardEmplGrpAssociationID = t_employeecardemplgrpassociationId.Id;
		  else
			{
				if ((collection["T_EmployeeCardEmplGrpAssociationID"].ToString() == "true,false"))
				{
					try
					{
						T_CardEmplGrp objT_CardEmplGrp = new T_CardEmplGrp();
						objT_CardEmplGrp.T_Name  = (columnValue);
						db.T_CardEmplGrps.Add(objT_CardEmplGrp);
						db.SaveChanges();
						model.T_EmployeeCardEmplGrpAssociationID = objT_CardEmplGrp.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeCardLvPlanAssociationID":
		 dynamic t_employeecardlvplanassociationId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeCardLvPlanAssociation = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeCardLvPlanAssociationID").Value;
			 ModelReflector.Property propT_EmployeeCardLvPlanAssociation = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_CardLvPlan").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeCardLvPlanAssociation);
			 //var elementTypeT_EmployeeCardLvPlanAssociation = db.T_CardLvPlans.ElementType;
			 //var propertyInfoT_EmployeeCardLvPlanAssociation = elementTypeT_EmployeeCardLvPlanAssociation.GetProperty(propT_EmployeeCardLvPlanAssociation.Name);			 
			 //t_employeecardlvplanassociationId = db.T_CardLvPlans.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeCardLvPlanAssociation.GetValue(p, null)) == columnValue);
			 t_employeecardlvplanassociationId = db.T_CardLvPlans.Where(propT_EmployeeCardLvPlanAssociation.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeecardlvplanassociationId = db.T_CardLvPlans.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeecardlvplanassociationId != null)
			model.T_EmployeeCardLvPlanAssociationID = t_employeecardlvplanassociationId.Id;
		  else
			{
				if ((collection["T_EmployeeCardLvPlanAssociationID"].ToString() == "true,false"))
				{
					try
					{
						T_CardLvPlan objT_CardLvPlan = new T_CardLvPlan();
						objT_CardLvPlan.T_Name  = (columnValue);
						db.T_CardLvPlans.Add(objT_CardLvPlan);
						db.SaveChanges();
						model.T_EmployeeCardLvPlanAssociationID = objT_CardLvPlan.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeAddressID":
		 dynamic t_employeeaddressId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeAddress = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeAddressID").Value;
			 ModelReflector.Property propT_EmployeeAddress = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Address").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeAddress);
			 //var elementTypeT_EmployeeAddress = db.T_Addresss.ElementType;
			 //var propertyInfoT_EmployeeAddress = elementTypeT_EmployeeAddress.GetProperty(propT_EmployeeAddress.Name);			 
			 //t_employeeaddressId = db.T_Addresss.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeAddress.GetValue(p, null)) == columnValue);
			 t_employeeaddressId = db.T_Addresss.Where(propT_EmployeeAddress.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeaddressId = db.T_Addresss.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeaddressId != null)
			model.T_EmployeeAddressID = t_employeeaddressId.Id;
		  else
			{
				if ((collection["T_EmployeeAddressID"].ToString() == "true,false"))
				{
					try
					{
						T_Address objT_Address = new T_Address();
						objT_Address.T_AddressLine1  = (columnValue);
						db.T_Addresss.Add(objT_Address);
						db.SaveChanges();
						model.T_EmployeeAddressID = objT_Address.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeUserLoginID":
         var t_employeeuserloginId = UserContext.Users.FirstOrDefault(p => p.UserName == columnValue);
         if (t_employeeuserloginId != null)
			model.T_EmployeeUserLoginID = t_employeeuserloginId.Id;
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
									db.T_Employees.Add(model);
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
		public bool ValidateModel(T_Employee validate)
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
                var obj1 = db1.T_Employees.Find(Id);
                System.Reflection.PropertyInfo[] properties = (obj1.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
                var Property = properties.FirstOrDefault(p => p.Name == PropName);
                object PropValue = Property.GetValue(obj1, null);
                return PropValue;
				            }
            catch { return null; }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetReadOnlyProperties(T_Employee OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Employee").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.ReadOnlyPropertiesRule(OModel, BR, "T_Employee");
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
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee");
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
        public JsonResult GetMandatoryProperties(T_Employee OModel, string ruleType)
        {
            Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Employee").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
                    if (ruleType == "OnCreate")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 2).ToList();
                    else if (ruleType == "OnEdit")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 1).ToList();
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_Employee");
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
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee");
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
        public JsonResult GetUIAlertBusinessRules(T_Employee OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Employee").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.UIAlertRule(OModel, BR, "T_Employee");
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
        public JsonResult GetValidateBeforeSaveProperties(T_Employee OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Employee").ToList();
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
                    var ResultOfBusinessRules = db.ValidateBeforeSavePropertiesRule(OModel, BR, "T_Employee",state);
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
                                    var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee");
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
        public JsonResult GetLockBusinessRules(T_Employee OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            //string RulesApplied = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Employee").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.LockEntityRule(OModel, BR, "T_Employee");
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
		private List<string> CheckMandatoryProperties(T_Employee OModel)
        {
            List<string> result = new List<string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Employee").ToList();
                Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
                if (BR != null && BR.Count > 0)
                {
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_Employee");
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
                                var dispName = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.Name == paramName).DisplayName;
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
            var _Obj = db1.T_Employees.FirstOrDefault(p => p.DisplayValue == displayvalue);
            long outValue;
            if (_Obj != null)
                return Int64.TryParse(_Obj.Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				public long? GetIdFromPropertyValue(string PropName, string PropValue)
        {
            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            IQueryable query = db1.T_Employees;
            Type[] exprArgTypes = { query.ElementType };
            string propToWhere = PropName;
            ParameterExpression p = Expression.Parameter(typeof(T_Employee), "p");
            MemberExpression member = Expression.PropertyOrField(p, propToWhere);
            LambdaExpression lambda = null;
            if (PropValue.ToLower().Trim() != "null")
            lambda = Expression.Lambda<Func<T_Employee, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(PropValue), member.Type)), p);
            else
                lambda = Expression.Lambda<Func<T_Employee, bool>>(Expression.Equal(member, Expression.Constant(null, member.Type)), p);
            MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
            IQueryable q = query.Provider.CreateQuery(methodCall);
            long outValue;
            var list1 = ((IQueryable<T_Employee>)q);
            if (list1 != null && list1.Count() > 0)
                return Int64.TryParse(list1.FirstOrDefault().Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPropertyValueByEntityId(long Id, string PropName)
        {
								ApplicationContext db1 = new ApplicationContext(new SystemUser());
            var obj1 = db1.T_Employees.Find(Id);
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
                                            string[] inlineAssoList = { "T_CurrentEmployeeEmploymentProfileID","T_CurrentEmployeeJobAssignmentID","T_EmployeeAddressID" };
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
                                                        string[] inlineAssoList = { "T_CurrentEmployeeEmploymentProfileID","T_CurrentEmployeeJobAssignmentID","T_EmployeeAddressID" };
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
                                                        string[] inlineAssoList = { "T_CurrentEmployeeEmploymentProfileID","T_CurrentEmployeeJobAssignmentID","T_EmployeeAddressID" };
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
        public JsonResult Check1MThresholdValue(T_Employee t_employee)
        {
            Dictionary<string, string> msgThreshold = new Dictionary<string, string>();
            return Json(msgThreshold, JsonRequestBehavior.AllowGet);
        }
		//code for verb action security
        public string[] getVerbsName()
        {
            string[] Verbsarr = new string[] { "BulkUpdate","BulkDelete","ImportExcel","ExportExcel"  ,"SendEmailtoIT" };
            return Verbsarr;
        }
        //
		//code for list of groups
        public string[][] getGroupsName()
        {
            string[][] groupsarr = new string[][] { new string[] {"48885","T_Employee48885"},new string[] {"48918","T_Employee48918"},new string[] {"48923","T_Employee48923"},new string[] {"48901","T_Employee48901"},new string[] {"48916","T_Employee48916"},new string[] {"48926","T_Employee48926"},new string[] {"48929","T_Employee48929"},new string[] {"48893","T_Employee48893"},new string[] {"48911","T_Employee48911"},new string[] {"48932","T_Employee48932"},new string[] {"48904","T_Employee48904"},new string[] {"48907","T_Employee48907"},new string[] {"48907","T_Employee48907"},new string[] {"48910","T_Employee48910"},new string[] {"48910","T_Employee48910"},new string[] {"48922","T_Employee48922"},new string[] {"48895","Initial Information"},new string[] {"48900","Current Service Record"},new string[] {"48899","Other Employee Details"},new string[] {"48897","Contact"},new string[] {"48898","Emergency Contact"},new string[] {"48896","Badge Information"} };
            return groupsarr;
        }
public bool IsAlreadyRegistred(string UserId, ApplicationContext db)
{
    var result = false;
    var obj = db.T_Employees.FirstOrDefault(p => p.T_EmployeeUserLoginID==UserId );
    if (obj != null)
        result = true;
    return result;
}
[AllowAnonymous]
public ActionResult AutoRegistration(string userid)
{
    T_Employee newregistration = new T_Employee();
			 newregistration.T_EmployeeUserLoginID = userid;
    ApplicationContext dbregistration = new ApplicationContext(new SystemUser());
    //set required properties
    var properties = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties;
    foreach (var prop in properties)
    {
        if (!prop.IsRequired) continue;
        var targetProp = newregistration.GetType().GetProperty(prop.Name);
        if (prop.DataType.ToUpper() == "STRING")
        {
            if (targetProp != null)
                targetProp.SetValue(newregistration, User.Name);
        }
        else
            targetProp.SetValue(newregistration, 0);
    }
    dbregistration.T_Employees.Add(newregistration);
    dbregistration.SaveChanges();
    return RedirectToAction("Edit", new { id = newregistration.Id });
}
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCalculationValues(T_Employee t_employee)
        {
            t_employee.setCalculation();
            Dictionary<string, string> Calculations = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_employee.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
		    var T_PriorServiceinmonthsProperty = properties.FirstOrDefault(p => p.Name == "T_PriorServiceinmonths");
            if (T_PriorServiceinmonthsProperty != null)
            {
			  object PropValue = T_PriorServiceinmonthsProperty.GetValue(t_employee, null);
				       Calculations.Add("T_PriorServiceinmonths", Convert.ToString(PropValue));
		            }
		    var T_CurrentServiceinmonthsProperty = properties.FirstOrDefault(p => p.Name == "T_CurrentServiceinmonths");
            if (T_CurrentServiceinmonthsProperty != null)
            {
			  object PropValue = T_CurrentServiceinmonthsProperty.GetValue(t_employee, null);
				       Calculations.Add("T_CurrentServiceinmonths", Convert.ToString(PropValue));
		            }
				var T_CurrentEmployeeEmploymentProfile = properties.FirstOrDefault(p => p.Name == "T_CurrentEmployeeEmploymentProfileID");
                
                if (T_CurrentEmployeeEmploymentProfile != null)
                {
                    Calculations.Add("t_currentemployeeemploymentprofile_T_ThreeMonthDue", Convert.ToString(t_employee.t_currentemployeeemploymentprofile.T_ThreeMonthDue));
                }
                
                if (T_CurrentEmployeeEmploymentProfile != null)
                {
                    Calculations.Add("t_currentemployeeemploymentprofile_T_SixMonthDue", Convert.ToString(t_employee.t_currentemployeeemploymentprofile.T_SixMonthDue));
                }
                
                if (T_CurrentEmployeeEmploymentProfile != null)
                {
                    Calculations.Add("t_currentemployeeemploymentprofile_T_TwelveMonthDue", Convert.ToString(t_employee.t_currentemployeeemploymentprofile.T_TwelveMonthDue));
                }
				var T_CurrentEmployeeJobAssignment = properties.FirstOrDefault(p => p.Name == "T_CurrentEmployeeJobAssignmentID");
				var T_EmployeeAddress = properties.FirstOrDefault(p => p.Name == "T_EmployeeAddressID");
            return Json(Calculations, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		//get Templates 
		// select templates 
        public void GetTemplatesForList(string defaultview)
        {
            string pageNameList = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_Employee"
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
                                       where s.EntityName == "T_Employee"
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
                                       where s.EntityName == "T_Employee"
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
                                       where s.EntityName == "T_Employee"
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
                                       where s.EntityName == "T_Employee"
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
                                       where s.EntityName == "T_Employee"
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
                                       where s.EntityName == "T_Employee"
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
                                       where s.EntityName == "T_Employee"
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
                                       where s.EntityName == "T_Employee"
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
		//UserLogin Dropown
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllValueUserLogin(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
            var list = UserContext.Users;
            var data = from x in list.OrderBy(q => q.UserName).ToList()
                       select new { Id = x.Id, Name = x.UserName };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //
		//
	[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDerivedDetails(T_Employee t_employee, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_employee.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            return Json(derivedlist, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDerivedDetailsInline(string host, string value, T_Employee t_employee, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
            return Json(derivedlist, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
	   [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDisplayValueByUserName()
        {
            ApplicationDbContext usercontext = new ApplicationDbContext();
            var userid = usercontext.Users.FirstOrDefault(p => p.UserName == User.Name).Id;
			 IQueryable<T_Employee> list = db.T_Employees;
            var data = (from x in list.Where(p => p.T_EmployeeUserLoginID == userid).ToList()
                        select new { Id = x.Id, Name = x.DisplayValue }).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
			[AcceptVerbs(HttpVerbs.Get)]
        public ActionResult getInlineAssociationsOfEntity()
        {
            List<string> list = new List<string> { "T_CurrentEmployeeEmploymentProfileID","T_CurrentEmployeeJobAssignmentID","T_EmployeeAddressID" };
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

