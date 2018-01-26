using GeneratorBase.MVC.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Reflection;
using System;
namespace GeneratorBase.MVC
{
    public class JournalEntrySecurityFilter : IFilter<JournalEntryContext>
    {
        IUser user;
        public JournalEntryContext DbContext { get; set; }
		ApplicationContext admindb;
        public JournalEntrySecurityFilter(IUser user)
        {
            this.user = user;
			admindb = new ApplicationContext(new SystemUser());
        }
		private Expression<Func<JournalEntry, bool>> FilterPredicate(Expression<Func<JournalEntry, bool>> predicateJournalEntry,List<long> rangeList,string EntityName)
        {
            var list = rangeList.GroupAdjacentBy((x, y) => x + 1 == y).Select(g => new long[] { g.First(), g.Last() }.Distinct());
            foreach (var item in list)
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => ((d.RecordId >= item.Min() && d.RecordId <= item.Max()) || d.Type == "ViewList") && d.EntityName == EntityName);
            }
            return predicateJournalEntry;
        }
        public void ApplyBasicSecurity()
        {
        }
        public void ApplyUserBasedSecurity()
        {
        }
		public void CustomFilter()
		{
		}
        public void ApplyMainSecurity()
        {
            if (string.IsNullOrEmpty(user.Name))
                return;
		   Expression<Func<JournalEntry, bool>> predicateJournalEntry = n => false;
			if (user.CanView("T_Vendor"))
            {
                var T_VendorList = DbContext.T_Vendors.Select(p => p.Id);
				if (admindb.T_Vendors.Count() > T_VendorList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_VendorList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Vendor");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_VendorList, "T_Vendor");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Vendor");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Vendor"));
            }
			if (user.CanView("T_Licenses"))
            {
                var T_LicensesList = DbContext.T_Licensess.Select(p => p.Id);
				if (admindb.T_Licensess.Count() > T_LicensesList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_LicensesList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Licenses");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_LicensesList, "T_Licenses");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Licenses");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Licenses"));
            }
			if (user.CanView("T_Program"))
            {
                var T_ProgramList = DbContext.T_Programs.Select(p => p.Id);
				if (admindb.T_Programs.Count() > T_ProgramList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ProgramList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Program");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ProgramList, "T_Program");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Program");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Program"));
            }
			if (user.CanView("T_CostCenter"))
            {
                var T_CostCenterList = DbContext.T_CostCenters.Select(p => p.Id);
				if (admindb.T_CostCenters.Count() > T_CostCenterList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_CostCenterList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_CostCenter");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_CostCenterList, "T_CostCenter");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_CostCenter");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_CostCenter"));
            }
			if (user.CanView("T_Fund"))
            {
                var T_FundList = DbContext.T_Funds.Select(p => p.Id);
				if (admindb.T_Funds.Count() > T_FundList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_FundList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Fund");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_FundList, "T_Fund");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Fund");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Fund"));
            }
			if (user.CanView("T_OrgCodes"))
            {
                var T_OrgCodesList = DbContext.T_OrgCodess.Select(p => p.Id);
				if (admindb.T_OrgCodess.Count() > T_OrgCodesList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_OrgCodesList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_OrgCodes");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_OrgCodesList, "T_OrgCodes");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_OrgCodes");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_OrgCodes"));
            }
			if (user.CanView("T_Department"))
            {
                var T_DepartmentList = DbContext.T_Departments.Select(p => p.Id);
				if (admindb.T_Departments.Count() > T_DepartmentList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_DepartmentList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Department");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_DepartmentList, "T_Department");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Department");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Department"));
            }
			if (user.CanView("T_PositionType"))
            {
                var T_PositionTypeList = DbContext.T_PositionTypes.Select(p => p.Id);
				if (admindb.T_PositionTypes.Count() > T_PositionTypeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_PositionTypeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_PositionType");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_PositionTypeList, "T_PositionType");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_PositionType");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_PositionType"));
            }
			if (user.CanView("T_SalaryBand"))
            {
                var T_SalaryBandList = DbContext.T_SalaryBands.Select(p => p.Id);
				if (admindb.T_SalaryBands.Count() > T_SalaryBandList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_SalaryBandList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_SalaryBand");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_SalaryBandList, "T_SalaryBand");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_SalaryBand");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_SalaryBand"));
            }
			if (user.CanView("T_Facility"))
            {
                var T_FacilityList = DbContext.T_Facilitys.Select(p => p.Id);
				if (admindb.T_Facilitys.Count() > T_FacilityList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_FacilityList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Facility");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_FacilityList, "T_Facility");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Facility");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Facility"));
            }
			if (user.CanView("T_Position"))
            {
                var T_PositionList = DbContext.T_Positions.Select(p => p.Id);
				if (admindb.T_Positions.Count() > T_PositionList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_PositionList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Position");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_PositionList, "T_Position");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Position");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Position"));
            }
			if (user.CanView("T_TerminationReason"))
            {
                var T_TerminationReasonList = DbContext.T_TerminationReasons.Select(p => p.Id);
				if (admindb.T_TerminationReasons.Count() > T_TerminationReasonList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_TerminationReasonList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_TerminationReason");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_TerminationReasonList, "T_TerminationReason");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_TerminationReason");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_TerminationReason"));
            }
			if (user.CanView("T_ServiceRecord"))
            {
                var T_ServiceRecordList = DbContext.T_ServiceRecords.Select(p => p.Id);
				if (admindb.T_ServiceRecords.Count() > T_ServiceRecordList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ServiceRecordList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ServiceRecord");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ServiceRecordList, "T_ServiceRecord");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ServiceRecord");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ServiceRecord"));
            }
			if (user.CanView("T_Gender"))
            {
                var T_GenderList = DbContext.T_Genders.Select(p => p.Id);
				if (admindb.T_Genders.Count() > T_GenderList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_GenderList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Gender");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_GenderList, "T_Gender");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Gender");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Gender"));
            }
			if (user.CanView("T_VeteranStatus"))
            {
                var T_VeteranStatusList = DbContext.T_VeteranStatuss.Select(p => p.Id);
				if (admindb.T_VeteranStatuss.Count() > T_VeteranStatusList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_VeteranStatusList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_VeteranStatus");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_VeteranStatusList, "T_VeteranStatus");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_VeteranStatus");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_VeteranStatus"));
            }
			if (user.CanView("T_PositionFillReason"))
            {
                var T_PositionFillReasonList = DbContext.T_PositionFillReasons.Select(p => p.Id);
				if (admindb.T_PositionFillReasons.Count() > T_PositionFillReasonList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_PositionFillReasonList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_PositionFillReason");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_PositionFillReasonList, "T_PositionFillReason");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_PositionFillReason");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_PositionFillReason"));
            }
			if (user.CanView("T_EEOCode"))
            {
                var T_EEOCodeList = DbContext.T_EEOCodes.Select(p => p.Id);
				if (admindb.T_EEOCodes.Count() > T_EEOCodeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_EEOCodeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_EEOCode");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_EEOCodeList, "T_EEOCode");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_EEOCode");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_EEOCode"));
            }
			if (user.CanView("T_Credential"))
            {
                var T_CredentialList = DbContext.T_Credentials.Select(p => p.Id);
				if (admindb.T_Credentials.Count() > T_CredentialList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_CredentialList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Credential");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_CredentialList, "T_Credential");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Credential");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Credential"));
            }
			if (user.CanView("T_EducationLevel"))
            {
                var T_EducationLevelList = DbContext.T_EducationLevels.Select(p => p.Id);
				if (admindb.T_EducationLevels.Count() > T_EducationLevelList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_EducationLevelList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_EducationLevel");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_EducationLevelList, "T_EducationLevel");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_EducationLevel");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_EducationLevel"));
            }
			if (user.CanView("T_PositionLevel"))
            {
                var T_PositionLevelList = DbContext.T_PositionLevels.Select(p => p.Id);
				if (admindb.T_PositionLevels.Count() > T_PositionLevelList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_PositionLevelList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_PositionLevel");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_PositionLevelList, "T_PositionLevel");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_PositionLevel");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_PositionLevel"));
            }
			if (user.CanView("T_PositionPostStatus"))
            {
                var T_PositionPostStatusList = DbContext.T_PositionPostStatuss.Select(p => p.Id);
				if (admindb.T_PositionPostStatuss.Count() > T_PositionPostStatusList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_PositionPostStatusList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_PositionPostStatus");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_PositionPostStatusList, "T_PositionPostStatus");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_PositionPostStatus");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_PositionPostStatus"));
            }
			if (user.CanView("T_EmployeeStatusCode"))
            {
                var T_EmployeeStatusCodeList = DbContext.T_EmployeeStatusCodes.Select(p => p.Id);
				if (admindb.T_EmployeeStatusCodes.Count() > T_EmployeeStatusCodeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_EmployeeStatusCodeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_EmployeeStatusCode");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_EmployeeStatusCodeList, "T_EmployeeStatusCode");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_EmployeeStatusCode");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_EmployeeStatusCode"));
            }
			if (user.CanView("T_SocCode"))
            {
                var T_SocCodeList = DbContext.T_SocCodes.Select(p => p.Id);
				if (admindb.T_SocCodes.Count() > T_SocCodeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_SocCodeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_SocCode");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_SocCodeList, "T_SocCode");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_SocCode");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_SocCode"));
            }
			if (user.CanView("T_ClassCode"))
            {
                var T_ClassCodeList = DbContext.T_ClassCodes.Select(p => p.Id);
				if (admindb.T_ClassCodes.Count() > T_ClassCodeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ClassCodeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ClassCode");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ClassCodeList, "T_ClassCode");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ClassCode");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ClassCode"));
            }
			if (user.CanView("T_ShiftMealTime"))
            {
                var T_ShiftMealTimeList = DbContext.T_ShiftMealTimes.Select(p => p.Id);
				if (admindb.T_ShiftMealTimes.Count() > T_ShiftMealTimeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ShiftMealTimeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ShiftMealTime");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ShiftMealTimeList, "T_ShiftMealTime");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ShiftMealTime");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ShiftMealTime"));
            }
			if (user.CanView("T_Employee"))
            {
                var T_EmployeeList = DbContext.T_Employees.Select(p => p.Id);
				if (admindb.T_Employees.Count() > T_EmployeeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_EmployeeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Employee");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_EmployeeList, "T_Employee");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Employee");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Employee"));
            }
			if (user.CanView("T_DepartmentArea"))
            {
                var T_DepartmentAreaList = DbContext.T_DepartmentAreas.Select(p => p.Id);
				if (admindb.T_DepartmentAreas.Count() > T_DepartmentAreaList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_DepartmentAreaList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_DepartmentArea");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_DepartmentAreaList, "T_DepartmentArea");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_DepartmentArea");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_DepartmentArea"));
            }
			if (user.CanView("T_LeaveReason"))
            {
                var T_LeaveReasonList = DbContext.T_LeaveReasons.Select(p => p.Id);
				if (admindb.T_LeaveReasons.Count() > T_LeaveReasonList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_LeaveReasonList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_LeaveReason");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_LeaveReasonList, "T_LeaveReason");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_LeaveReason");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_LeaveReason"));
            }
			if (user.CanView("T_Comment"))
            {
                var T_CommentList = DbContext.T_Comments.Select(p => p.Id);
				if (admindb.T_Comments.Count() > T_CommentList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_CommentList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Comment");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_CommentList, "T_Comment");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Comment");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Comment"));
            }
			if (user.CanView("T_Commenttype"))
            {
                var T_CommenttypeList = DbContext.T_Commenttypes.Select(p => p.Id);
				if (admindb.T_Commenttypes.Count() > T_CommenttypeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_CommenttypeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Commenttype");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_CommenttypeList, "T_Commenttype");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Commenttype");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Commenttype"));
            }
			if (user.CanView("T_ClaimType"))
            {
                var T_ClaimTypeList = DbContext.T_ClaimTypes.Select(p => p.Id);
				if (admindb.T_ClaimTypes.Count() > T_ClaimTypeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ClaimTypeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ClaimType");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ClaimTypeList, "T_ClaimType");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ClaimType");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ClaimType"));
            }
			if (user.CanView("T_Restrictions"))
            {
                var T_RestrictionsList = DbContext.T_Restrictionss.Select(p => p.Id);
				if (admindb.T_Restrictionss.Count() > T_RestrictionsList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_RestrictionsList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Restrictions");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_RestrictionsList, "T_Restrictions");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Restrictions");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Restrictions"));
            }
			if (user.CanView("T_Refusal"))
            {
                var T_RefusalList = DbContext.T_Refusals.Select(p => p.Id);
				if (admindb.T_Refusals.Count() > T_RefusalList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_RefusalList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Refusal");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_RefusalList, "T_Refusal");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Refusal");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Refusal"));
            }
			if (user.CanView("T_InjuryCause"))
            {
                var T_InjuryCauseList = DbContext.T_InjuryCauses.Select(p => p.Id);
				if (admindb.T_InjuryCauses.Count() > T_InjuryCauseList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_InjuryCauseList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_InjuryCause");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_InjuryCauseList, "T_InjuryCause");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_InjuryCause");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_InjuryCause"));
            }
			if (user.CanView("T_CPSResults"))
            {
                var T_CPSResultsList = DbContext.T_CPSResultss.Select(p => p.Id);
				if (admindb.T_CPSResultss.Count() > T_CPSResultsList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_CPSResultsList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_CPSResults");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_CPSResultsList, "T_CPSResults");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_CPSResults");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_CPSResults"));
            }
			if (user.CanView("T_DrugAlcoholTest"))
            {
                var T_DrugAlcoholTestList = DbContext.T_DrugAlcoholTests.Select(p => p.Id);
				if (admindb.T_DrugAlcoholTests.Count() > T_DrugAlcoholTestList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_DrugAlcoholTestList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_DrugAlcoholTest");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_DrugAlcoholTestList, "T_DrugAlcoholTest");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_DrugAlcoholTest");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_DrugAlcoholTest"));
            }
			if (user.CanView("T_ReasonForDrugTest"))
            {
                var T_ReasonForDrugTestList = DbContext.T_ReasonForDrugTests.Select(p => p.Id);
				if (admindb.T_ReasonForDrugTests.Count() > T_ReasonForDrugTestList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ReasonForDrugTestList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ReasonForDrugTest");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ReasonForDrugTestList, "T_ReasonForDrugTest");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ReasonForDrugTest");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ReasonForDrugTest"));
            }
			if (user.CanView("T_ResultsForDrugTest"))
            {
                var T_ResultsForDrugTestList = DbContext.T_ResultsForDrugTests.Select(p => p.Id);
				if (admindb.T_ResultsForDrugTests.Count() > T_ResultsForDrugTestList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ResultsForDrugTestList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ResultsForDrugTest");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ResultsForDrugTestList, "T_ResultsForDrugTest");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ResultsForDrugTest");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ResultsForDrugTest"));
            }
			if (user.CanView("T_Country"))
            {
                var T_CountryList = DbContext.T_Countrys.Select(p => p.Id);
				if (admindb.T_Countrys.Count() > T_CountryList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_CountryList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Country");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_CountryList, "T_Country");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Country");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Country"));
            }
			if (user.CanView("T_State"))
            {
                var T_StateList = DbContext.T_States.Select(p => p.Id);
				if (admindb.T_States.Count() > T_StateList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_StateList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_State");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_StateList, "T_State");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_State");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_State"));
            }
			if (user.CanView("T_Positionstatus"))
            {
                var T_PositionstatusList = DbContext.T_Positionstatuss.Select(p => p.Id);
				if (admindb.T_Positionstatuss.Count() > T_PositionstatusList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_PositionstatusList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Positionstatus");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_PositionstatusList, "T_Positionstatus");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Positionstatus");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Positionstatus"));
            }
			if (user.CanView("T_RoleCode"))
            {
                var T_RoleCodeList = DbContext.T_RoleCodes.Select(p => p.Id);
				if (admindb.T_RoleCodes.Count() > T_RoleCodeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_RoleCodeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_RoleCode");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_RoleCodeList, "T_RoleCode");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_RoleCode");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_RoleCode"));
            }
			if (user.CanView("T_UnitX"))
            {
                var T_UnitXList = DbContext.T_UnitXs.Select(p => p.Id);
				if (admindb.T_UnitXs.Count() > T_UnitXList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_UnitXList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_UnitX");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_UnitXList, "T_UnitX");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_UnitX");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_UnitX"));
            }
			if (user.CanView("T_JobAssignment"))
            {
                var T_JobAssignmentList = DbContext.T_JobAssignments.Select(p => p.Id);
				if (admindb.T_JobAssignments.Count() > T_JobAssignmentList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_JobAssignmentList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_JobAssignment");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_JobAssignmentList, "T_JobAssignment");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_JobAssignment");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_JobAssignment"));
            }
			if (user.CanView("T_Address"))
            {
                var T_AddressList = DbContext.T_Addresss.Select(p => p.Id);
				if (admindb.T_Addresss.Count() > T_AddressList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_AddressList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Address");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_AddressList, "T_Address");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Address");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Address"));
            }
			if (user.CanView("T_City"))
            {
                var T_CityList = DbContext.T_Citys.Select(p => p.Id);
				if (admindb.T_Citys.Count() > T_CityList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_CityList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_City");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_CityList, "T_City");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_City");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_City"));
            }
			if (user.CanView("T_Race"))
            {
                var T_RaceList = DbContext.T_Races.Select(p => p.Id);
				if (admindb.T_Races.Count() > T_RaceList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_RaceList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Race");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_RaceList, "T_Race");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Race");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Race"));
            }
			if (user.CanView("T_LeaveProfile"))
            {
                var T_LeaveProfileList = DbContext.T_LeaveProfiles.Select(p => p.Id);
				if (admindb.T_LeaveProfiles.Count() > T_LeaveProfileList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_LeaveProfileList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_LeaveProfile");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_LeaveProfileList, "T_LeaveProfile");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_LeaveProfile");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_LeaveProfile"));
            }
			if (user.CanView("T_EmployeeInjury"))
            {
                var T_EmployeeInjuryList = DbContext.T_EmployeeInjurys.Select(p => p.Id);
				if (admindb.T_EmployeeInjurys.Count() > T_EmployeeInjuryList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_EmployeeInjuryList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_EmployeeInjury");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_EmployeeInjuryList, "T_EmployeeInjury");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_EmployeeInjury");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_EmployeeInjury"));
            }
			if (user.CanView("T_Patient"))
            {
                var T_PatientList = DbContext.T_Patients.Select(p => p.Id);
				if (admindb.T_Patients.Count() > T_PatientList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_PatientList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Patient");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_PatientList, "T_Patient");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Patient");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Patient"));
            }
			if (user.CanView("T_WCAccident"))
            {
                var T_WCAccidentList = DbContext.T_WCAccidents.Select(p => p.Id);
				if (admindb.T_WCAccidents.Count() > T_WCAccidentList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_WCAccidentList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_WCAccident");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_WCAccidentList, "T_WCAccident");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_WCAccident");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_WCAccident"));
            }
			if (user.CanView("T_BackgroundCheck"))
            {
                var T_BackgroundCheckList = DbContext.T_BackgroundChecks.Select(p => p.Id);
				if (admindb.T_BackgroundChecks.Count() > T_BackgroundCheckList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_BackgroundCheckList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_BackgroundCheck");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_BackgroundCheckList, "T_BackgroundCheck");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_BackgroundCheck");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_BackgroundCheck"));
            }
			if (user.CanView("T_RetainTable"))
            {
                var T_RetainTableList = DbContext.T_RetainTables.Select(p => p.Id);
				if (admindb.T_RetainTables.Count() > T_RetainTableList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_RetainTableList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_RetainTable");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_RetainTableList, "T_RetainTable");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_RetainTable");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_RetainTable"));
            }
			if (user.CanView("T_ResultsTable"))
            {
                var T_ResultsTableList = DbContext.T_ResultsTables.Select(p => p.Id);
				if (admindb.T_ResultsTables.Count() > T_ResultsTableList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ResultsTableList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ResultsTable");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ResultsTableList, "T_ResultsTable");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ResultsTable");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ResultsTable"));
            }
			if (user.CanView("T_EmployeeTerminationFacility"))
            {
                var T_EmployeeTerminationFacilityList = DbContext.T_EmployeeTerminationFacilitys.Select(p => p.Id);
				if (admindb.T_EmployeeTerminationFacilitys.Count() > T_EmployeeTerminationFacilityList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_EmployeeTerminationFacilityList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_EmployeeTerminationFacility");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_EmployeeTerminationFacilityList, "T_EmployeeTerminationFacility");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_EmployeeTerminationFacility");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_EmployeeTerminationFacility"));
            }
			if (user.CanView("T_Licensestype"))
            {
                var T_LicensestypeList = DbContext.T_Licensestypes.Select(p => p.Id);
				if (admindb.T_Licensestypes.Count() > T_LicensestypeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_LicensestypeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Licensestype");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_LicensestypeList, "T_Licensestype");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Licensestype");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Licensestype"));
            }
			if (user.CanView("T_OvertimeEligibility"))
            {
                var T_OvertimeEligibilityList = DbContext.T_OvertimeEligibilitys.Select(p => p.Id);
				if (admindb.T_OvertimeEligibilitys.Count() > T_OvertimeEligibilityList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_OvertimeEligibilityList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_OvertimeEligibility");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_OvertimeEligibilityList, "T_OvertimeEligibility");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_OvertimeEligibility");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_OvertimeEligibility"));
            }
			if (user.CanView("T_Langauge"))
            {
                var T_LangaugeList = DbContext.T_Langauges.Select(p => p.Id);
				if (admindb.T_Langauges.Count() > T_LangaugeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_LangaugeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Langauge");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_LangaugeList, "T_Langauge");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Langauge");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Langauge"));
            }
			if (user.CanView("T_InjuryNature"))
            {
                var T_InjuryNatureList = DbContext.T_InjuryNatures.Select(p => p.Id);
				if (admindb.T_InjuryNatures.Count() > T_InjuryNatureList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_InjuryNatureList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_InjuryNature");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_InjuryNatureList, "T_InjuryNature");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_InjuryNature");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_InjuryNature"));
            }
			if (user.CanView("T_BodyPartsAffected"))
            {
                var T_BodyPartsAffectedList = DbContext.T_BodyPartsAffecteds.Select(p => p.Id);
				if (admindb.T_BodyPartsAffecteds.Count() > T_BodyPartsAffectedList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_BodyPartsAffectedList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_BodyPartsAffected");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_BodyPartsAffectedList, "T_BodyPartsAffected");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_BodyPartsAffected");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_BodyPartsAffected"));
            }
			if (user.CanView("T_InitialTreatment"))
            {
                var T_InitialTreatmentList = DbContext.T_InitialTreatments.Select(p => p.Id);
				if (admindb.T_InitialTreatments.Count() > T_InitialTreatmentList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_InitialTreatmentList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_InitialTreatment");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_InitialTreatmentList, "T_InitialTreatment");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_InitialTreatment");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_InitialTreatment"));
            }
			if (user.CanView("T_ClaimTypeMCI"))
            {
                var T_ClaimTypeMCIList = DbContext.T_ClaimTypeMCIs.Select(p => p.Id);
				if (admindb.T_ClaimTypeMCIs.Count() > T_ClaimTypeMCIList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ClaimTypeMCIList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ClaimTypeMCI");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ClaimTypeMCIList, "T_ClaimTypeMCI");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ClaimTypeMCI");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ClaimTypeMCI"));
            }
			if (user.CanView("T_MachineTool"))
            {
                var T_MachineToolList = DbContext.T_MachineTools.Select(p => p.Id);
				if (admindb.T_MachineTools.Count() > T_MachineToolList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_MachineToolList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_MachineTool");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_MachineToolList, "T_MachineTool");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_MachineTool");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_MachineTool"));
            }
			if (user.CanView("T_Unit"))
            {
                var T_UnitList = DbContext.T_Units.Select(p => p.Id);
				if (admindb.T_Units.Count() > T_UnitList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_UnitList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Unit");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_UnitList, "T_Unit");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Unit");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Unit"));
            }
			if (user.CanView("T_DrugTestResult"))
            {
                var T_DrugTestResultList = DbContext.T_DrugTestResults.Select(p => p.Id);
				if (admindb.T_DrugTestResults.Count() > T_DrugTestResultList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_DrugTestResultList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_DrugTestResult");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_DrugTestResultList, "T_DrugTestResult");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_DrugTestResult");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_DrugTestResult"));
            }
			if (user.CanView("T_Education"))
            {
                var T_EducationList = DbContext.T_Educations.Select(p => p.Id);
				if (admindb.T_Educations.Count() > T_EducationList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_EducationList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Education");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_EducationList, "T_Education");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Education");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Education"));
            }
			if (user.CanView("T_Accommodation"))
            {
                var T_AccommodationList = DbContext.T_Accommodations.Select(p => p.Id);
				if (admindb.T_Accommodations.Count() > T_AccommodationList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_AccommodationList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Accommodation");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_AccommodationList, "T_Accommodation");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Accommodation");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Accommodation"));
            }
			if (user.CanView("T_TestType"))
            {
                var T_TestTypeList = DbContext.T_TestTypes.Select(p => p.Id);
				if (admindb.T_TestTypes.Count() > T_TestTypeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_TestTypeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_TestType");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_TestTypeList, "T_TestType");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_TestType");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_TestType"));
            }
			if (user.CanView("T_Major"))
            {
                var T_MajorList = DbContext.T_Majors.Select(p => p.Id);
				if (admindb.T_Majors.Count() > T_MajorList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_MajorList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Major");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_MajorList, "T_Major");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Major");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Major"));
            }
			if (user.CanView("T_RequiredEducation"))
            {
                var T_RequiredEducationList = DbContext.T_RequiredEducations.Select(p => p.Id);
				if (admindb.T_RequiredEducations.Count() > T_RequiredEducationList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_RequiredEducationList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_RequiredEducation");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_RequiredEducationList, "T_RequiredEducation");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_RequiredEducation");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_RequiredEducation"));
            }
			if (user.CanView("T_ReasonforHire"))
            {
                var T_ReasonforHireList = DbContext.T_ReasonforHires.Select(p => p.Id);
				if (admindb.T_ReasonforHires.Count() > T_ReasonforHireList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ReasonforHireList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ReasonforHire");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ReasonforHireList, "T_ReasonforHire");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ReasonforHire");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ReasonforHire"));
            }
			if (user.CanView("T_WCCode"))
            {
                var T_WCCodeList = DbContext.T_WCCodes.Select(p => p.Id);
				if (admindb.T_WCCodes.Count() > T_WCCodeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_WCCodeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_WCCode");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_WCCodeList, "T_WCCode");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_WCCode");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_WCCode"));
            }
			if (user.CanView("T_MedicalFacilityForTreatment"))
            {
                var T_MedicalFacilityForTreatmentList = DbContext.T_MedicalFacilityForTreatments.Select(p => p.Id);
				if (admindb.T_MedicalFacilityForTreatments.Count() > T_MedicalFacilityForTreatmentList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_MedicalFacilityForTreatmentList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_MedicalFacilityForTreatment");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_MedicalFacilityForTreatmentList, "T_MedicalFacilityForTreatment");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_MedicalFacilityForTreatment");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_MedicalFacilityForTreatment"));
            }
			if (user.CanView("T_ShiftTime"))
            {
                var T_ShiftTimeList = DbContext.T_ShiftTimes.Select(p => p.Id);
				if (admindb.T_ShiftTimes.Count() > T_ShiftTimeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ShiftTimeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ShiftTime");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ShiftTimeList, "T_ShiftTime");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ShiftTime");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ShiftTime"));
            }
			if (user.CanView("T_Floor"))
            {
                var T_FloorList = DbContext.T_Floors.Select(p => p.Id);
				if (admindb.T_Floors.Count() > T_FloorList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_FloorList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Floor");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_FloorList, "T_Floor");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Floor");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Floor"));
            }
			if (user.CanView("T_PayType"))
            {
                var T_PayTypeList = DbContext.T_PayTypes.Select(p => p.Id);
				if (admindb.T_PayTypes.Count() > T_PayTypeList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_PayTypeList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_PayType");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_PayTypeList, "T_PayType");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_PayType");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_PayType"));
            }
			if (user.CanView("T_PayDetails"))
            {
                var T_PayDetailsList = DbContext.T_PayDetailss.Select(p => p.Id);
				if (admindb.T_PayDetailss.Count() > T_PayDetailsList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_PayDetailsList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_PayDetails");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_PayDetailsList, "T_PayDetails");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_PayDetails");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_PayDetails"));
            }
			if (user.CanView("T_ShiftDuration"))
            {
                var T_ShiftDurationList = DbContext.T_ShiftDurations.Select(p => p.Id);
				if (admindb.T_ShiftDurations.Count() > T_ShiftDurationList.Count())
				{
					predicateJournalEntry = predicateJournalEntry.Or(d => (T_ShiftDurationList.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_ShiftDuration");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, T_ShiftDurationList, "T_ShiftDuration");
				}
				else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_ShiftDuration");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_ShiftDuration"));
            }
			if (user.CanView("T_Schedule"))
            {
                var list = DbContext.T_Schedules.Select(p => p.Id);
			   if (admindb.T_Schedules.Count() > list.Count())
			   {
					predicateJournalEntry = predicateJournalEntry.Or(d => (list.Contains(d.RecordId) || d.Type == "ViewList") && d.EntityName == "T_Schedule");
					//predicateJournalEntry = FilterPredicate(predicateJournalEntry, list, "T_Schedule");
				}
			    else predicateJournalEntry = predicateJournalEntry.Or(d => d.EntityName == "T_Schedule");
            }
            else
            {
                predicateJournalEntry = predicateJournalEntry.Or(d => (d.RecordId == -1 && d.EntityName == "T_Schedule"));
            }
			DbContext.JournalEntries = new FilteredDbSet<JournalEntry>(DbContext, predicateJournalEntry);
        }
    }
}

