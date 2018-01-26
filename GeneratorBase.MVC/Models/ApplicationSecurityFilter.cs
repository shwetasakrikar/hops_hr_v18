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
	public class ParameterRebinder : System.Linq.Expressions.ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
    public static class Utility
    {
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }
	public class ApplicationSecurityFilter : IFilter<ApplicationContext>
    {
		IUser user;
        public ApplicationContext DbContext { get; set; }
        public ApplicationSecurityFilter(IUser user)
        {
            this.user = user;
        }
		public void ApplyBasicSecurity()
		{
			if (string.IsNullOrEmpty(user.Name))
                return;
            List<long?> doclist = new List<long?>();
						
            if (!user.CanView("FileDocument"))
            {
                DbContext.FileDocuments = new FilteredDbSet<FileDocument>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Vendor"))
            {
                DbContext.T_Vendors = new FilteredDbSet<T_Vendor>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Licenses"))
            {
                DbContext.T_Licensess = new FilteredDbSet<T_Licenses>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Program"))
            {
                DbContext.T_Programs = new FilteredDbSet<T_Program>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_CostCenter"))
            {
                DbContext.T_CostCenters = new FilteredDbSet<T_CostCenter>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Fund"))
            {
                DbContext.T_Funds = new FilteredDbSet<T_Fund>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_OrgCodes"))
            {
                DbContext.T_OrgCodess = new FilteredDbSet<T_OrgCodes>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Department"))
            {
                DbContext.T_Departments = new FilteredDbSet<T_Department>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_PositionType"))
            {
                DbContext.T_PositionTypes = new FilteredDbSet<T_PositionType>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_SalaryBand"))
            {
                DbContext.T_SalaryBands = new FilteredDbSet<T_SalaryBand>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Facility"))
            {
                DbContext.T_Facilitys = new FilteredDbSet<T_Facility>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Position"))
            {
                DbContext.T_Positions = new FilteredDbSet<T_Position>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_TerminationReason"))
            {
                DbContext.T_TerminationReasons = new FilteredDbSet<T_TerminationReason>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ServiceRecord"))
            {
                DbContext.T_ServiceRecords = new FilteredDbSet<T_ServiceRecord>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_EmployeeType"))
            {
                DbContext.T_EmployeeTypes = new FilteredDbSet<T_EmployeeType>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Gender"))
            {
                DbContext.T_Genders = new FilteredDbSet<T_Gender>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_VeteranStatus"))
            {
                DbContext.T_VeteranStatuss = new FilteredDbSet<T_VeteranStatus>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_PositionFillReason"))
            {
                DbContext.T_PositionFillReasons = new FilteredDbSet<T_PositionFillReason>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_EEOCode"))
            {
                DbContext.T_EEOCodes = new FilteredDbSet<T_EEOCode>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Credential"))
            {
                DbContext.T_Credentials = new FilteredDbSet<T_Credential>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_EducationLevel"))
            {
                DbContext.T_EducationLevels = new FilteredDbSet<T_EducationLevel>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_PositionLevel"))
            {
                DbContext.T_PositionLevels = new FilteredDbSet<T_PositionLevel>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_PositionPostStatus"))
            {
                DbContext.T_PositionPostStatuss = new FilteredDbSet<T_PositionPostStatus>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_EmployeeStatusCode"))
            {
                DbContext.T_EmployeeStatusCodes = new FilteredDbSet<T_EmployeeStatusCode>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_SocCode"))
            {
                DbContext.T_SocCodes = new FilteredDbSet<T_SocCode>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ClassCode"))
            {
                DbContext.T_ClassCodes = new FilteredDbSet<T_ClassCode>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ShiftMealTime"))
            {
                DbContext.T_ShiftMealTimes = new FilteredDbSet<T_ShiftMealTime>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Employee"))
            {
                DbContext.T_Employees = new FilteredDbSet<T_Employee>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_DepartmentArea"))
            {
                DbContext.T_DepartmentAreas = new FilteredDbSet<T_DepartmentArea>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_LeaveReason"))
            {
                DbContext.T_LeaveReasons = new FilteredDbSet<T_LeaveReason>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Comment"))
            {
                DbContext.T_Comments = new FilteredDbSet<T_Comment>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Commenttype"))
            {
                DbContext.T_Commenttypes = new FilteredDbSet<T_Commenttype>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ClaimType"))
            {
                DbContext.T_ClaimTypes = new FilteredDbSet<T_ClaimType>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Restrictions"))
            {
                DbContext.T_Restrictionss = new FilteredDbSet<T_Restrictions>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Refusal"))
            {
                DbContext.T_Refusals = new FilteredDbSet<T_Refusal>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_InjuryCause"))
            {
                DbContext.T_InjuryCauses = new FilteredDbSet<T_InjuryCause>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_CPSResults"))
            {
                DbContext.T_CPSResultss = new FilteredDbSet<T_CPSResults>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_DrugAlcoholTest"))
            {
                DbContext.T_DrugAlcoholTests = new FilteredDbSet<T_DrugAlcoholTest>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ReasonForDrugTest"))
            {
                DbContext.T_ReasonForDrugTests = new FilteredDbSet<T_ReasonForDrugTest>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ResultsForDrugTest"))
            {
                DbContext.T_ResultsForDrugTests = new FilteredDbSet<T_ResultsForDrugTest>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Country"))
            {
                DbContext.T_Countrys = new FilteredDbSet<T_Country>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_State"))
            {
                DbContext.T_States = new FilteredDbSet<T_State>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Positionstatus"))
            {
                DbContext.T_Positionstatuss = new FilteredDbSet<T_Positionstatus>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_RoleCode"))
            {
                DbContext.T_RoleCodes = new FilteredDbSet<T_RoleCode>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_UnitX"))
            {
                DbContext.T_UnitXs = new FilteredDbSet<T_UnitX>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_JobAssignment"))
            {
                DbContext.T_JobAssignments = new FilteredDbSet<T_JobAssignment>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Address"))
            {
                DbContext.T_Addresss = new FilteredDbSet<T_Address>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_City"))
            {
                DbContext.T_Citys = new FilteredDbSet<T_City>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Race"))
            {
                DbContext.T_Races = new FilteredDbSet<T_Race>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_LeaveProfile"))
            {
                DbContext.T_LeaveProfiles = new FilteredDbSet<T_LeaveProfile>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_EmployeeInjury"))
            {
                DbContext.T_EmployeeInjurys = new FilteredDbSet<T_EmployeeInjury>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Patient"))
            {
                DbContext.T_Patients = new FilteredDbSet<T_Patient>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_WCAccident"))
            {
                DbContext.T_WCAccidents = new FilteredDbSet<T_WCAccident>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_BackgroundCheck"))
            {
                DbContext.T_BackgroundChecks = new FilteredDbSet<T_BackgroundCheck>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_RetainTable"))
            {
                DbContext.T_RetainTables = new FilteredDbSet<T_RetainTable>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ResultsTable"))
            {
                DbContext.T_ResultsTables = new FilteredDbSet<T_ResultsTable>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_EmployeeTerminationFacility"))
            {
                DbContext.T_EmployeeTerminationFacilitys = new FilteredDbSet<T_EmployeeTerminationFacility>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Licensestype"))
            {
                DbContext.T_Licensestypes = new FilteredDbSet<T_Licensestype>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_OvertimeEligibility"))
            {
                DbContext.T_OvertimeEligibilitys = new FilteredDbSet<T_OvertimeEligibility>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Langauge"))
            {
                DbContext.T_Langauges = new FilteredDbSet<T_Langauge>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_InjuryNature"))
            {
                DbContext.T_InjuryNatures = new FilteredDbSet<T_InjuryNature>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_BodyPartsAffected"))
            {
                DbContext.T_BodyPartsAffecteds = new FilteredDbSet<T_BodyPartsAffected>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_InitialTreatment"))
            {
                DbContext.T_InitialTreatments = new FilteredDbSet<T_InitialTreatment>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ClaimTypeMCI"))
            {
                DbContext.T_ClaimTypeMCIs = new FilteredDbSet<T_ClaimTypeMCI>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_MachineTool"))
            {
                DbContext.T_MachineTools = new FilteredDbSet<T_MachineTool>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Unit"))
            {
                DbContext.T_Units = new FilteredDbSet<T_Unit>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_DrugTestResult"))
            {
                DbContext.T_DrugTestResults = new FilteredDbSet<T_DrugTestResult>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Education"))
            {
                DbContext.T_Educations = new FilteredDbSet<T_Education>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Accommodation"))
            {
                DbContext.T_Accommodations = new FilteredDbSet<T_Accommodation>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_TestType"))
            {
                DbContext.T_TestTypes = new FilteredDbSet<T_TestType>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Major"))
            {
                DbContext.T_Majors = new FilteredDbSet<T_Major>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_RequiredEducation"))
            {
                DbContext.T_RequiredEducations = new FilteredDbSet<T_RequiredEducation>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ReasonforHire"))
            {
                DbContext.T_ReasonforHires = new FilteredDbSet<T_ReasonforHire>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_WCCode"))
            {
                DbContext.T_WCCodes = new FilteredDbSet<T_WCCode>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_MedicalFacilityForTreatment"))
            {
                DbContext.T_MedicalFacilityForTreatments = new FilteredDbSet<T_MedicalFacilityForTreatment>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ShiftTime"))
            {
                DbContext.T_ShiftTimes = new FilteredDbSet<T_ShiftTime>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Floor"))
            {
                DbContext.T_Floors = new FilteredDbSet<T_Floor>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_PayType"))
            {
                DbContext.T_PayTypes = new FilteredDbSet<T_PayType>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_PayDetails"))
            {
                DbContext.T_PayDetailss = new FilteredDbSet<T_PayDetails>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ShiftDuration"))
            {
                DbContext.T_ShiftDurations = new FilteredDbSet<T_ShiftDuration>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_AllFacilities"))
            {
                DbContext.T_AllFacilitiess = new FilteredDbSet<T_AllFacilities>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_AllFacilitiesUnit"))
            {
                DbContext.T_AllFacilitiesUnits = new FilteredDbSet<T_AllFacilitiesUnit>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_AllFacilitiesFloor"))
            {
                DbContext.T_AllFacilitiesFloors = new FilteredDbSet<T_AllFacilitiesFloor>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_WorkingTitle"))
            {
                DbContext.T_WorkingTitles = new FilteredDbSet<T_WorkingTitle>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_SalaryRange"))
            {
                DbContext.T_SalaryRanges = new FilteredDbSet<T_SalaryRange>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_Nationality"))
            {
                DbContext.T_Nationalitys = new FilteredDbSet<T_Nationality>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_CardLvPlan"))
            {
                DbContext.T_CardLvPlans = new FilteredDbSet<T_CardLvPlan>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_CardEmplGrp"))
            {
                DbContext.T_CardEmplGrps = new FilteredDbSet<T_CardEmplGrp>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_FacilityConfiguration"))
            {
                DbContext.T_FacilityConfigurations = new FilteredDbSet<T_FacilityConfiguration>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_ConversationalEmployeeForeignLanguage"))
            {
                DbContext.T_ConversationalEmployeeForeignLanguages = new FilteredDbSet<T_ConversationalEmployeeForeignLanguage>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_LanguageCertifiedIn"))
            {
                DbContext.T_LanguageCertifiedIns = new FilteredDbSet<T_LanguageCertifiedIn>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_LeaveProfileReason"))
            {
                DbContext.T_LeaveProfileReasons = new FilteredDbSet<T_LeaveProfileReason>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_TypeofClaim"))
            {
                DbContext.T_TypeofClaims = new FilteredDbSet<T_TypeofClaim>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			
            if (!user.CanView("T_TypeOfRestrictions"))
            {
                DbContext.T_TypeOfRestrictionss = new FilteredDbSet<T_TypeOfRestrictions>(DbContext, d => d.Id == 0);
            }
            else
            {
            }
			if (user.CanView("Document"))
                DbContext.Documents = new FilteredDbSet<Document>(DbContext, d => doclist.Contains(d.Id));
            else
                DbContext.Documents = new FilteredDbSet<Document>(DbContext, d => d.Id == 0);
		}
        public void ApplyMainSecurity()
        {
				if (string.IsNullOrEmpty(user.Name))
                    return;	
				List<long?> doclist = new List<long?>();
            var T_Facility_T_FacilityUserlist = DbContext.T_FacilityUsers.Where(t => t.t_user.UserName == user.Name ).Select(p=>p.T_FacilityID).ToList();
			if(T_Facility_T_FacilityUserlist.Count() > 0)
            {
                var selectedlist = user.MultiTenantLoginSelected.Where(p=>p.T_MainEntity != -1).Select(p=>p.T_MainEntity).ToList();
                if (selectedlist.Count() > 0 && selectedlist[0] != -1)
					T_Facility_T_FacilityUserlist = T_Facility_T_FacilityUserlist.Intersect(selectedlist).ToList();
				var userlist = DbContext.T_FacilityUsers.Where(p => T_Facility_T_FacilityUserlist.Contains(p.T_FacilityID)).Select(p => p.T_UserID).ToList();
                DbContext.T_Users = new FilteredDbSet<ApplicationUser>(DbContext, d => userlist.Contains(d.Id));
            }
			if (user.CanView("T_Facility"))
            {
				DbContext.T_Facilitys = new FilteredDbSet<T_Facility>(DbContext, d => T_Facility_T_FacilityUserlist.Contains(d.Id));
			}
			var T_FacilityList = DbContext.T_Facilitys.Select(p => p.Id);
			if (user.CanView("T_FacilityUser"))
			{
				var T_FacilityUser_T_FacilityUser_T_Facilitylist = T_FacilityList;
				var T_FacilityUser_T_FacilityUserlist = DbContext.T_FacilityUsers.Where(d => T_FacilityUser_T_FacilityUser_T_Facilitylist.Contains(d.t_facility.Id)).Select(p => p.Id).ToList();
				DbContext.T_FacilityUsers = new FilteredDbSet<T_FacilityUser>(DbContext, d => T_FacilityUser_T_FacilityUserlist.Contains(d.Id));
			}
			if (user.CanView("T_Department"))
			{
                var T_Department_T_DepartmentFacilityAssociationlist = T_FacilityList;
                DbContext.T_Departments = new FilteredDbSet<T_Department>(DbContext, d => T_Department_T_DepartmentFacilityAssociationlist.Contains(d.t_departmentfacilityassociation.Id));
			}
			if (user.CanView("T_Position"))
			{
                var T_Position_T_FacilityAssignedTolist = T_FacilityList;
                DbContext.T_Positions = new FilteredDbSet<T_Position>(DbContext, d => T_Position_T_FacilityAssignedTolist.Contains(d.t_facilityassignedto.Id));
			}
			if (user.CanView("T_Employee"))
			{
                var T_Employee_T_EmployeeAtFacilitylist = T_FacilityList;
                DbContext.T_Employees = new FilteredDbSet<T_Employee>(DbContext, d => T_Employee_T_EmployeeAtFacilitylist.Contains(d.t_employeeatfacility.Id));
			}
			if (user.CanView("T_DepartmentArea"))
			{
                var T_DepartmentArea_T_DepartmentAreaEmployeeTypeAssociationlist = T_FacilityList;
                DbContext.T_DepartmentAreas = new FilteredDbSet<T_DepartmentArea>(DbContext, d => T_DepartmentArea_T_DepartmentAreaEmployeeTypeAssociationlist.Contains(d.t_departmentareaemployeetypeassociation.Id));
			}
			if (user.CanView("T_ClaimType"))
			{
                var T_ClaimType_T_ClaimTypeFacilityAssociationlist = T_FacilityList;
                DbContext.T_ClaimTypes = new FilteredDbSet<T_ClaimType>(DbContext, d => T_ClaimType_T_ClaimTypeFacilityAssociationlist.Contains(d.t_claimtypefacilityassociation.Id));
			}
			if (user.CanView("T_Restrictions"))
			{
                var T_Restrictions_T_RestrictionsFacilityAssociationlist = T_FacilityList;
                DbContext.T_Restrictionss = new FilteredDbSet<T_Restrictions>(DbContext, d => T_Restrictions_T_RestrictionsFacilityAssociationlist.Contains(d.t_restrictionsfacilityassociation.Id));
			}
			if (user.CanView("T_UnitX"))
			{
                var T_UnitX_T_FacilityUnitXlist = T_FacilityList;
                DbContext.T_UnitXs = new FilteredDbSet<T_UnitX>(DbContext, d => T_UnitX_T_FacilityUnitXlist.Contains(d.t_facilityunitx.Id));
			}
			if (user.CanView("T_Unit"))
			{
                var T_Unit_T_FacilityUnitlist = T_FacilityList;
                DbContext.T_Units = new FilteredDbSet<T_Unit>(DbContext, d => T_Unit_T_FacilityUnitlist.Contains(d.t_facilityunit.Id));
			}
			if (user.CanView("T_SalaryRange"))
			{
                var T_SalaryRange_T_FacilitySalaryRangeAssociationlist = T_FacilityList;
                DbContext.T_SalaryRanges = new FilteredDbSet<T_SalaryRange>(DbContext, d => T_SalaryRange_T_FacilitySalaryRangeAssociationlist.Contains(d.t_facilitysalaryrangeassociation.Id));
			}
			if (user.CanView("T_FacilityConfiguration"))
			{
                var T_FacilityConfiguration_T_TenantConfigurationAssociationlist = T_FacilityList;
                DbContext.T_FacilityConfigurations = new FilteredDbSet<T_FacilityConfiguration>(DbContext, d => T_FacilityConfiguration_T_TenantConfigurationAssociationlist.Contains(d.t_tenantconfigurationassociation.Id));
			}
						var T_EmployeeList = DbContext.T_Employees.Select(p => p.Id);
			if (user.CanView("T_Licenses"))
			{
                var T_Licenses_T_LicenseRecordslist = T_EmployeeList;
                DbContext.T_Licensess = new FilteredDbSet<T_Licenses>(DbContext, d => T_Licenses_T_LicenseRecordslist.Contains(d.t_licenserecords.Id));
			}
			if (user.CanView("T_ServiceRecord"))
			{
                var T_ServiceRecord_T_EmployeeEmploymentProfilelist = T_EmployeeList;
                DbContext.T_ServiceRecords = new FilteredDbSet<T_ServiceRecord>(DbContext, d => T_ServiceRecord_T_EmployeeEmploymentProfilelist.Contains(d.t_employeeemploymentprofile.Id));
			}
			if (user.CanView("T_Comment"))
			{
                var T_Comment_T_EmployeeCommentslist = T_EmployeeList;
                DbContext.T_Comments = new FilteredDbSet<T_Comment>(DbContext, d => T_Comment_T_EmployeeCommentslist.Contains(d.t_employeecomments.Id));
			}
			if (user.CanView("T_DrugAlcoholTest"))
			{
                var T_DrugAlcoholTest_T_EmployeeDrugAlcoholTestlist = T_EmployeeList;
                DbContext.T_DrugAlcoholTests = new FilteredDbSet<T_DrugAlcoholTest>(DbContext, d => T_DrugAlcoholTest_T_EmployeeDrugAlcoholTestlist.Contains(d.t_employeedrugalcoholtest.Id));
			}
						var T_PositionList = DbContext.T_Positions.Select(p => p.Id);
			if (user.CanView("T_JobAssignment"))
			{
                var T_JobAssignment_T_PositionJobAssignmentlist = T_PositionList;
                DbContext.T_JobAssignments = new FilteredDbSet<T_JobAssignment>(DbContext, d => T_JobAssignment_T_PositionJobAssignmentlist.Contains(d.t_positionjobassignment.Id));
			}
						var T_UnitXList = DbContext.T_UnitXs.Select(p => p.Id);
			if (user.CanView("T_JobAssignment"))
			{
                var T_JobAssignment_T_JobAssignmentUnitXlist = T_UnitXList;
                DbContext.T_JobAssignments = new FilteredDbSet<T_JobAssignment>(DbContext, d => T_JobAssignment_T_JobAssignmentUnitXlist.Contains(d.t_jobassignmentunitx.Id));
			}
			if (user.CanView("T_JobAssignment"))
			{
                var T_JobAssignment_T_JobAssignmentManagerEmployeelist = T_EmployeeList;
                DbContext.T_JobAssignments = new FilteredDbSet<T_JobAssignment>(DbContext, d => T_JobAssignment_T_JobAssignmentManagerEmployeelist.Contains(d.t_jobassignmentmanageremployee.Id));
			}
			if (user.CanView("T_JobAssignment"))
			{
                var T_JobAssignment_T_EmployeeSupervisorlist = T_EmployeeList;
                DbContext.T_JobAssignments = new FilteredDbSet<T_JobAssignment>(DbContext, d => T_JobAssignment_T_EmployeeSupervisorlist.Contains(d.t_employeesupervisor.Id));
			}
			if (user.CanView("T_JobAssignment"))
			{
                var T_JobAssignment_T_EmployeeJobAssignmentlist = T_EmployeeList;
                DbContext.T_JobAssignments = new FilteredDbSet<T_JobAssignment>(DbContext, d => T_JobAssignment_T_EmployeeJobAssignmentlist.Contains(d.t_employeejobassignment.Id));
			}
			if (user.CanView("T_LeaveProfile"))
			{
                var T_LeaveProfile_T_EmployeeLeaveProfilelist = T_EmployeeList;
                DbContext.T_LeaveProfiles = new FilteredDbSet<T_LeaveProfile>(DbContext, d => T_LeaveProfile_T_EmployeeLeaveProfilelist.Contains(d.t_employeeleaveprofile.Id));
			}
			if (user.CanView("T_EmployeeInjury"))
			{
                var T_EmployeeInjury_T_EmployeeEmployeeInjurylist = T_EmployeeList;
                DbContext.T_EmployeeInjurys = new FilteredDbSet<T_EmployeeInjury>(DbContext, d => T_EmployeeInjury_T_EmployeeEmployeeInjurylist.Contains(d.t_employeeemployeeinjury.Id));
			}
			if (user.CanView("T_BackgroundCheck"))
			{
                var T_BackgroundCheck_T_Reviewerlist = T_EmployeeList;
                DbContext.T_BackgroundChecks = new FilteredDbSet<T_BackgroundCheck>(DbContext, d => T_BackgroundCheck_T_Reviewerlist.Contains(d.t_reviewer.Id));
			}
			if (user.CanView("T_BackgroundCheck"))
			{
                var T_BackgroundCheck_T_EmployeeCriminalBackgroundChecklist = T_EmployeeList;
                DbContext.T_BackgroundChecks = new FilteredDbSet<T_BackgroundCheck>(DbContext, d => T_BackgroundCheck_T_EmployeeCriminalBackgroundChecklist.Contains(d.t_employeecriminalbackgroundcheck.Id));
			}
			if (user.CanView("T_Education"))
			{
                var T_Education_T_EmployeeEducationlist = T_EmployeeList;
                DbContext.T_Educations = new FilteredDbSet<T_Education>(DbContext, d => T_Education_T_EmployeeEducationlist.Contains(d.t_employeeeducation.Id));
			}
			if (user.CanView("T_Accommodation"))
			{
                var T_Accommodation_T_EmployeeAccomodationlist = T_EmployeeList;
                DbContext.T_Accommodations = new FilteredDbSet<T_Accommodation>(DbContext, d => T_Accommodation_T_EmployeeAccomodationlist.Contains(d.t_employeeaccomodation.Id));
			}
			if (user.CanView("T_PayDetails"))
			{
                var T_PayDetails_T_EmployeePayDetailslist = T_EmployeeList;
                DbContext.T_PayDetailss = new FilteredDbSet<T_PayDetails>(DbContext, d => T_PayDetails_T_EmployeePayDetailslist.Contains(d.t_employeepaydetails.Id));
			}
			if (user.CanView("T_ConversationalEmployeeForeignLanguage"))
			{
                var T_ConversationalEmployeeForeignLanguage_T_Employeelist = T_EmployeeList;
                DbContext.T_ConversationalEmployeeForeignLanguages = new FilteredDbSet<T_ConversationalEmployeeForeignLanguage>(DbContext, d => T_ConversationalEmployeeForeignLanguage_T_Employeelist.Contains(d.t_employee.Id));
			}
			if (user.CanView("T_LanguageCertifiedIn"))
			{
                var T_LanguageCertifiedIn_T_Employeelist = T_EmployeeList;
                DbContext.T_LanguageCertifiedIns = new FilteredDbSet<T_LanguageCertifiedIn>(DbContext, d => T_LanguageCertifiedIn_T_Employeelist.Contains(d.t_employee.Id));
			}
						var T_ClaimTypeList = DbContext.T_ClaimTypes.Select(p => p.Id);
			if (user.CanView("T_TypeofClaim"))
			{
                var T_TypeofClaim_T_ClaimTypelist = T_ClaimTypeList;
                DbContext.T_TypeofClaims = new FilteredDbSet<T_TypeofClaim>(DbContext, d => T_TypeofClaim_T_ClaimTypelist.Contains(d.t_claimtype.Id));
			}
						var T_RestrictionsList = DbContext.T_Restrictionss.Select(p => p.Id);
			if (user.CanView("T_TypeOfRestrictions"))
			{
                var T_TypeOfRestrictions_T_Restrictionslist = T_RestrictionsList;
                DbContext.T_TypeOfRestrictionss = new FilteredDbSet<T_TypeOfRestrictions>(DbContext, d => T_TypeOfRestrictions_T_Restrictionslist.Contains(d.t_restrictions.Id));
			}
		//document security
		
		DbContext.Documents = new FilteredDbSet<Document>(DbContext, d => doclist.Contains(d.Id));
			
		 List<long?> T_AddressInlineList = new List<long?>();
		 T_AddressInlineList.AddRange(DbContext.T_Facilitys.Select(p => p.T_FacilityAddressID).ToList());
T_AddressInlineList.AddRange(DbContext.T_Employees.Select(p => p.T_EmployeeAddressID).ToList());

		 DbContext.T_Addresss = new FilteredDbSet<T_Address>(DbContext, d => T_AddressInlineList.Contains(d.Id));
						var T_ServiceRecordList = DbContext.T_ServiceRecords.Select(p => p.Id).ToList();
						var T_JobAssignmentList = DbContext.T_JobAssignments.Select(p => p.Id).ToList();
        }
        public void ApplyUserBasedSecurity()
        {
            if (string.IsNullOrEmpty(user.Name))
                return;
			if (user.userbasedsecurity.Count() == 0) return;
			string mainEntity = user.userbasedsecurity.FirstOrDefault(p => p.IsMainEntity).EntityName;
			List<long?> doclist = new List<long?>();
 #region T_Employee
            {
		Expression<Func<T_Employee, bool>> predicateT_Employee = n => false;
		bool flagT_Employee = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_Employee").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_Employee"))
					break;
		if (_ubs.IsMainEntity)
        {
			predicateT_Employee = predicateT_Employee.Or(d =>  (d.t_employeeuserlogin!=null && d.t_employeeuserlogin.UserName == user.Name ) );
			flagT_Employee = true;
		}
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_ServiceRecord" && mainEntity != "T_Employee")
        {
				var list = DbContext.T_ServiceRecords.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Employee = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Employee = predicateT_Employee.Or(d =>  (d.t_currentemployeeemploymentprofile!=null && list.Contains(d.t_currentemployeeemploymentprofile.Id)) );
					 else
					 {
						predicateT_Employee = (d =>  (d.t_currentemployeeemploymentprofile!=null && list.Contains(d.t_currentemployeeemploymentprofile.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_JobAssignment" && mainEntity != "T_Employee")
        {
				var list = DbContext.T_JobAssignments.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Employee = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Employee = predicateT_Employee.Or(d =>  (d.t_currentemployeejobassignment!=null && list.Contains(d.t_currentemployeejobassignment.Id)) );
					 else
					 {
						predicateT_Employee = (d =>  (d.t_currentemployeejobassignment!=null && list.Contains(d.t_currentemployeejobassignment.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_Employee)
		DbContext.T_Employees = new FilteredDbSet<T_Employee>(DbContext, predicateT_Employee);
 }
 #endregion
 #region T_FacilityUser
            {
		Expression<Func<T_FacilityUser, bool>> predicateT_FacilityUser = n => false;
		bool flagT_FacilityUser = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_FacilityUser").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_FacilityUser"))
					break;
		if (_ubs.IsMainEntity)
        {
			predicateT_FacilityUser = predicateT_FacilityUser.Or(d =>  (d.t_user!=null && d.t_user.UserName == user.Name ) );
			flagT_FacilityUser = true;
		}
	}
	if(flagT_FacilityUser)
		DbContext.T_FacilityUsers = new FilteredDbSet<T_FacilityUser>(DbContext, predicateT_FacilityUser);
 }
 #endregion
 #region FileDocument
            {
		Expression<Func<FileDocument, bool>> predicateFileDocument = n => false;
		bool flagFileDocument = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "FileDocument").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("FileDocument"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "FileDocument")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagFileDocument = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateFileDocument = predicateFileDocument.Or(d =>  (d.t_employeedocuments!=null && list.Contains(d.t_employeedocuments.Id)) );
					 else
					 {
						predicateFileDocument = (d =>  (d.t_employeedocuments!=null && list.Contains(d.t_employeedocuments.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagFileDocument)
		DbContext.FileDocuments = new FilteredDbSet<FileDocument>(DbContext, predicateFileDocument);
 }
 #endregion
 #region T_Licenses
            {
		Expression<Func<T_Licenses, bool>> predicateT_Licenses = n => false;
		bool flagT_Licenses = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_Licenses").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_Licenses"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_Licenses")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Licenses = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Licenses = predicateT_Licenses.Or(d =>  (d.t_licenserecords!=null && list.Contains(d.t_licenserecords.Id)) );
					 else
					 {
						predicateT_Licenses = (d =>  (d.t_licenserecords!=null && list.Contains(d.t_licenserecords.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_Licenses)
		DbContext.T_Licensess = new FilteredDbSet<T_Licenses>(DbContext, predicateT_Licenses);
 }
 #endregion
 #region T_ServiceRecord
            {
		Expression<Func<T_ServiceRecord, bool>> predicateT_ServiceRecord = n => false;
		bool flagT_ServiceRecord = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_ServiceRecord").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_ServiceRecord"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_ServiceRecord")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_ServiceRecord = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_ServiceRecord = predicateT_ServiceRecord.Or(d =>  (d.t_employeeemploymentprofile!=null && list.Contains(d.t_employeeemploymentprofile.Id)) );
					 else
					 {
						predicateT_ServiceRecord = (d =>  (d.t_employeeemploymentprofile!=null && list.Contains(d.t_employeeemploymentprofile.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_ServiceRecord)
		DbContext.T_ServiceRecords = new FilteredDbSet<T_ServiceRecord>(DbContext, predicateT_ServiceRecord);
 }
 #endregion
 #region T_Comment
            {
		Expression<Func<T_Comment, bool>> predicateT_Comment = n => false;
		bool flagT_Comment = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_Comment").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_Comment"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_employeecomments!=null && list.Contains(d.t_employeecomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_employeecomments!=null && list.Contains(d.t_employeecomments.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Accommodation" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_Accommodations.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_accommodationcomments!=null && list.Contains(d.t_accommodationcomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_accommodationcomments!=null && list.Contains(d.t_accommodationcomments.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_DrugAlcoholTest" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_DrugAlcoholTests.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_drugalcoholtestcomments!=null && list.Contains(d.t_drugalcoholtestcomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_drugalcoholtestcomments!=null && list.Contains(d.t_drugalcoholtestcomments.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Education" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_Educations.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_educationcomments!=null && list.Contains(d.t_educationcomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_educationcomments!=null && list.Contains(d.t_educationcomments.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_EmployeeInjury" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_EmployeeInjurys.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_injurycomments!=null && list.Contains(d.t_injurycomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_injurycomments!=null && list.Contains(d.t_injurycomments.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_JobAssignment" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_JobAssignments.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_jobassignmentcomments!=null && list.Contains(d.t_jobassignmentcomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_jobassignmentcomments!=null && list.Contains(d.t_jobassignmentcomments.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_LeaveProfile" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_LeaveProfiles.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_leavecomments!=null && list.Contains(d.t_leavecomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_leavecomments!=null && list.Contains(d.t_leavecomments.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Licenses" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_Licensess.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_licensescomments!=null && list.Contains(d.t_licensescomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_licensescomments!=null && list.Contains(d.t_licensescomments.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_PayDetails" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_PayDetailss.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_salarycomments!=null && list.Contains(d.t_salarycomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_salarycomments!=null && list.Contains(d.t_salarycomments.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_BackgroundCheck" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_BackgroundChecks.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_preemploymentcomments!=null && list.Contains(d.t_preemploymentcomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_preemploymentcomments!=null && list.Contains(d.t_preemploymentcomments.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_ServiceRecord" && mainEntity != "T_Comment")
        {
				var list = DbContext.T_ServiceRecords.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Comment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Comment = predicateT_Comment.Or(d =>  (d.t_servicerecordcomments!=null && list.Contains(d.t_servicerecordcomments.Id)) );
					 else
					 {
						predicateT_Comment = (d =>  (d.t_servicerecordcomments!=null && list.Contains(d.t_servicerecordcomments.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_Comment)
		DbContext.T_Comments = new FilteredDbSet<T_Comment>(DbContext, predicateT_Comment);
 }
 #endregion
 #region T_DrugAlcoholTest
            {
		Expression<Func<T_DrugAlcoholTest, bool>> predicateT_DrugAlcoholTest = n => false;
		bool flagT_DrugAlcoholTest = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_DrugAlcoholTest").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_DrugAlcoholTest"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_DrugAlcoholTest")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_DrugAlcoholTest = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_DrugAlcoholTest = predicateT_DrugAlcoholTest.Or(d =>  (d.t_employeedrugalcoholtest!=null && list.Contains(d.t_employeedrugalcoholtest.Id)) );
					 else
					 {
						predicateT_DrugAlcoholTest = (d =>  (d.t_employeedrugalcoholtest!=null && list.Contains(d.t_employeedrugalcoholtest.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_DrugAlcoholTest)
		DbContext.T_DrugAlcoholTests = new FilteredDbSet<T_DrugAlcoholTest>(DbContext, predicateT_DrugAlcoholTest);
 }
 #endregion
 #region T_UnitX
            {
		Expression<Func<T_UnitX, bool>> predicateT_UnitX = n => false;
		bool flagT_UnitX = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_UnitX").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_UnitX"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_UnitX")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_UnitX = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_UnitX = predicateT_UnitX.Or(d =>  (d.t_employeeadministrator!=null && list.Contains(d.t_employeeadministrator.Id)) || (d.t_employeeunitxhead!=null && list.Contains(d.t_employeeunitxhead.Id)) );
					 else
					 {
						predicateT_UnitX = (d =>  (d.t_employeeadministrator!=null && list.Contains(d.t_employeeadministrator.Id)) || (d.t_employeeunitxhead!=null && list.Contains(d.t_employeeunitxhead.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_UnitX)
		DbContext.T_UnitXs = new FilteredDbSet<T_UnitX>(DbContext, predicateT_UnitX);
 }
 #endregion
 #region T_JobAssignment
            {
		Expression<Func<T_JobAssignment, bool>> predicateT_JobAssignment = n => false;
		bool flagT_JobAssignment = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_JobAssignment").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_JobAssignment"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_JobAssignment")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_JobAssignment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_JobAssignment = predicateT_JobAssignment.Or(d =>  (d.t_employeejobassignment!=null && list.Contains(d.t_employeejobassignment.Id)) || (d.t_jobassignmentmanageremployee!=null && list.Contains(d.t_jobassignmentmanageremployee.Id)) || (d.t_employeesupervisor!=null && list.Contains(d.t_employeesupervisor.Id)) );
					 else
					 {
						predicateT_JobAssignment = (d =>  (d.t_employeejobassignment!=null && list.Contains(d.t_employeejobassignment.Id)) || (d.t_jobassignmentmanageremployee!=null && list.Contains(d.t_jobassignmentmanageremployee.Id)) || (d.t_employeesupervisor!=null && list.Contains(d.t_employeesupervisor.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_UnitX" && mainEntity != "T_JobAssignment")
        {
				var list = DbContext.T_UnitXs.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_JobAssignment = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_JobAssignment = predicateT_JobAssignment.Or(d =>  (d.t_jobassignmentunitx!=null && list.Contains(d.t_jobassignmentunitx.Id)) );
					 else
					 {
						predicateT_JobAssignment = (d =>  (d.t_jobassignmentunitx!=null && list.Contains(d.t_jobassignmentunitx.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_JobAssignment)
		DbContext.T_JobAssignments = new FilteredDbSet<T_JobAssignment>(DbContext, predicateT_JobAssignment);
 }
 #endregion
 #region T_LeaveProfile
            {
		Expression<Func<T_LeaveProfile, bool>> predicateT_LeaveProfile = n => false;
		bool flagT_LeaveProfile = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_LeaveProfile").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_LeaveProfile"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_LeaveProfile")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_LeaveProfile = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_LeaveProfile = predicateT_LeaveProfile.Or(d =>  (d.t_employeeleaveprofile!=null && list.Contains(d.t_employeeleaveprofile.Id)) );
					 else
					 {
						predicateT_LeaveProfile = (d =>  (d.t_employeeleaveprofile!=null && list.Contains(d.t_employeeleaveprofile.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_EmployeeInjury" && mainEntity != "T_LeaveProfile")
        {
				var list = DbContext.T_EmployeeInjurys.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_LeaveProfile = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_LeaveProfile = predicateT_LeaveProfile.Or(d =>  (d.t_injuryrelatedleave!=null && list.Contains(d.t_injuryrelatedleave.Id)) );
					 else
					 {
						predicateT_LeaveProfile = (d =>  (d.t_injuryrelatedleave!=null && list.Contains(d.t_injuryrelatedleave.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_LeaveProfile)
		DbContext.T_LeaveProfiles = new FilteredDbSet<T_LeaveProfile>(DbContext, predicateT_LeaveProfile);
 }
 #endregion
 #region T_EmployeeInjury
            {
		Expression<Func<T_EmployeeInjury, bool>> predicateT_EmployeeInjury = n => false;
		bool flagT_EmployeeInjury = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_EmployeeInjury").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_EmployeeInjury"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_EmployeeInjury")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_EmployeeInjury = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_EmployeeInjury = predicateT_EmployeeInjury.Or(d =>  (d.t_employeeemployeeinjury!=null && list.Contains(d.t_employeeemployeeinjury.Id)) );
					 else
					 {
						predicateT_EmployeeInjury = (d =>  (d.t_employeeemployeeinjury!=null && list.Contains(d.t_employeeemployeeinjury.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_EmployeeInjury)
		DbContext.T_EmployeeInjurys = new FilteredDbSet<T_EmployeeInjury>(DbContext, predicateT_EmployeeInjury);
 }
 #endregion
 #region T_BackgroundCheck
            {
		Expression<Func<T_BackgroundCheck, bool>> predicateT_BackgroundCheck = n => false;
		bool flagT_BackgroundCheck = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_BackgroundCheck").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_BackgroundCheck"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_BackgroundCheck")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_BackgroundCheck = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_BackgroundCheck = predicateT_BackgroundCheck.Or(d =>  (d.t_employeecriminalbackgroundcheck!=null && list.Contains(d.t_employeecriminalbackgroundcheck.Id)) || (d.t_reviewer!=null && list.Contains(d.t_reviewer.Id)) );
					 else
					 {
						predicateT_BackgroundCheck = (d =>  (d.t_employeecriminalbackgroundcheck!=null && list.Contains(d.t_employeecriminalbackgroundcheck.Id)) || (d.t_reviewer!=null && list.Contains(d.t_reviewer.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_BackgroundCheck)
		DbContext.T_BackgroundChecks = new FilteredDbSet<T_BackgroundCheck>(DbContext, predicateT_BackgroundCheck);
 }
 #endregion
 #region T_Education
            {
		Expression<Func<T_Education, bool>> predicateT_Education = n => false;
		bool flagT_Education = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_Education").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_Education"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_Education")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Education = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Education = predicateT_Education.Or(d =>  (d.t_employeeeducation!=null && list.Contains(d.t_employeeeducation.Id)) );
					 else
					 {
						predicateT_Education = (d =>  (d.t_employeeeducation!=null && list.Contains(d.t_employeeeducation.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_Education)
		DbContext.T_Educations = new FilteredDbSet<T_Education>(DbContext, predicateT_Education);
 }
 #endregion
 #region T_Accommodation
            {
		Expression<Func<T_Accommodation, bool>> predicateT_Accommodation = n => false;
		bool flagT_Accommodation = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_Accommodation").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_Accommodation"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_Accommodation")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Accommodation = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Accommodation = predicateT_Accommodation.Or(d =>  (d.t_employeeaccomodation!=null && list.Contains(d.t_employeeaccomodation.Id)) );
					 else
					 {
						predicateT_Accommodation = (d =>  (d.t_employeeaccomodation!=null && list.Contains(d.t_employeeaccomodation.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_EmployeeInjury" && mainEntity != "T_Accommodation")
        {
				var list = DbContext.T_EmployeeInjurys.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_Accommodation = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_Accommodation = predicateT_Accommodation.Or(d =>  (d.t_accommodationinjury!=null && list.Contains(d.t_accommodationinjury.Id)) );
					 else
					 {
						predicateT_Accommodation = (d =>  (d.t_accommodationinjury!=null && list.Contains(d.t_accommodationinjury.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_Accommodation)
		DbContext.T_Accommodations = new FilteredDbSet<T_Accommodation>(DbContext, predicateT_Accommodation);
 }
 #endregion
 #region T_PayDetails
            {
		Expression<Func<T_PayDetails, bool>> predicateT_PayDetails = n => false;
		bool flagT_PayDetails = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_PayDetails").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_PayDetails"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_PayDetails")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_PayDetails = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_PayDetails = predicateT_PayDetails.Or(d =>  (d.t_employeepaydetails!=null && list.Contains(d.t_employeepaydetails.Id)) );
					 else
					 {
						predicateT_PayDetails = (d =>  (d.t_employeepaydetails!=null && list.Contains(d.t_employeepaydetails.Id)) );
						break;
					 }
				 }
        }
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_JobAssignment" && mainEntity != "T_PayDetails")
        {
				var list = DbContext.T_JobAssignments.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_PayDetails = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_PayDetails = predicateT_PayDetails.Or(d =>  (d.t_paydetailsjobassignment!=null && list.Contains(d.t_paydetailsjobassignment.Id)) );
					 else
					 {
						predicateT_PayDetails = (d =>  (d.t_paydetailsjobassignment!=null && list.Contains(d.t_paydetailsjobassignment.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_PayDetails)
		DbContext.T_PayDetailss = new FilteredDbSet<T_PayDetails>(DbContext, predicateT_PayDetails);
 }
 #endregion
 #region T_ConversationalEmployeeForeignLanguage
            {
		Expression<Func<T_ConversationalEmployeeForeignLanguage, bool>> predicateT_ConversationalEmployeeForeignLanguage = n => false;
		bool flagT_ConversationalEmployeeForeignLanguage = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_ConversationalEmployeeForeignLanguage").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_ConversationalEmployeeForeignLanguage"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_ConversationalEmployeeForeignLanguage")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_ConversationalEmployeeForeignLanguage = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_ConversationalEmployeeForeignLanguage = predicateT_ConversationalEmployeeForeignLanguage.Or(d =>  (d.t_employee!=null && list.Contains(d.t_employee.Id)) );
					 else
					 {
						predicateT_ConversationalEmployeeForeignLanguage = (d =>  (d.t_employee!=null && list.Contains(d.t_employee.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_ConversationalEmployeeForeignLanguage)
		DbContext.T_ConversationalEmployeeForeignLanguages = new FilteredDbSet<T_ConversationalEmployeeForeignLanguage>(DbContext, predicateT_ConversationalEmployeeForeignLanguage);
 }
 #endregion
 #region T_LanguageCertifiedIn
            {
		Expression<Func<T_LanguageCertifiedIn, bool>> predicateT_LanguageCertifiedIn = n => false;
		bool flagT_LanguageCertifiedIn = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_LanguageCertifiedIn").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_LanguageCertifiedIn"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_Employee" && mainEntity != "T_LanguageCertifiedIn")
        {
				var list = DbContext.T_Employees.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_LanguageCertifiedIn = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_LanguageCertifiedIn = predicateT_LanguageCertifiedIn.Or(d =>  (d.t_employee!=null && list.Contains(d.t_employee.Id)) );
					 else
					 {
						predicateT_LanguageCertifiedIn = (d =>  (d.t_employee!=null && list.Contains(d.t_employee.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_LanguageCertifiedIn)
		DbContext.T_LanguageCertifiedIns = new FilteredDbSet<T_LanguageCertifiedIn>(DbContext, predicateT_LanguageCertifiedIn);
 }
 #endregion
 #region T_LeaveProfileReason
            {
		Expression<Func<T_LeaveProfileReason, bool>> predicateT_LeaveProfileReason = n => false;
		bool flagT_LeaveProfileReason = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_LeaveProfileReason").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_LeaveProfileReason"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_LeaveProfile" && mainEntity != "T_LeaveProfileReason")
        {
				var list = DbContext.T_LeaveProfiles.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_LeaveProfileReason = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_LeaveProfileReason = predicateT_LeaveProfileReason.Or(d =>  (d.t_leaveprofile!=null && list.Contains(d.t_leaveprofile.Id)) );
					 else
					 {
						predicateT_LeaveProfileReason = (d =>  (d.t_leaveprofile!=null && list.Contains(d.t_leaveprofile.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_LeaveProfileReason)
		DbContext.T_LeaveProfileReasons = new FilteredDbSet<T_LeaveProfileReason>(DbContext, predicateT_LeaveProfileReason);
 }
 #endregion
 #region T_TypeofClaim
            {
		Expression<Func<T_TypeofClaim, bool>> predicateT_TypeofClaim = n => false;
		bool flagT_TypeofClaim = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_TypeofClaim").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_TypeofClaim"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_EmployeeInjury" && mainEntity != "T_TypeofClaim")
        {
				var list = DbContext.T_EmployeeInjurys.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_TypeofClaim = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_TypeofClaim = predicateT_TypeofClaim.Or(d =>  (d.t_employeeinjury!=null && list.Contains(d.t_employeeinjury.Id)) );
					 else
					 {
						predicateT_TypeofClaim = (d =>  (d.t_employeeinjury!=null && list.Contains(d.t_employeeinjury.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_TypeofClaim)
		DbContext.T_TypeofClaims = new FilteredDbSet<T_TypeofClaim>(DbContext, predicateT_TypeofClaim);
 }
 #endregion
 #region T_TypeOfRestrictions
            {
		Expression<Func<T_TypeOfRestrictions, bool>> predicateT_TypeOfRestrictions = n => false;
		bool flagT_TypeOfRestrictions = false;
		foreach (var _ubs in user.userbasedsecurity.Where(p => p.EntityName == "T_TypeOfRestrictions").OrderByDescending(p => p.IsMainEntity).ThenByDescending(p=>p.Id))
		{
				if (_ubs.RolesToIgnore != null && user.IsInRole(user.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        continue;
				if(!user.CanView("T_TypeOfRestrictions"))
					break;
		if (!_ubs.IsMainEntity && _ubs.TargetEntityName == "T_EmployeeInjury" && mainEntity != "T_TypeOfRestrictions")
        {
				var list = DbContext.T_EmployeeInjurys.Select(p => p.Id);
				// if(list.Count()>0) //commented 10/16/17
				 {
					 flagT_TypeOfRestrictions = true;
					 if (_ubs.TargetEntityName != mainEntity)
						predicateT_TypeOfRestrictions = predicateT_TypeOfRestrictions.Or(d =>  (d.t_employeeinjury!=null && list.Contains(d.t_employeeinjury.Id)) );
					 else
					 {
						predicateT_TypeOfRestrictions = (d =>  (d.t_employeeinjury!=null && list.Contains(d.t_employeeinjury.Id)) );
						break;
					 }
				 }
        }
	}
	if(flagT_TypeOfRestrictions)
		DbContext.T_TypeOfRestrictionss = new FilteredDbSet<T_TypeOfRestrictions>(DbContext, predicateT_TypeOfRestrictions);
 }
 #endregion
			//document security
			if(user.userbasedsecurity.Count()>0)
			{
				
				DbContext.Documents = new FilteredDbSet<Document>(DbContext, d => doclist.Contains(d.Id));
			}
        }
		
		public void CustomFilter()
		{
		}
    }
	//Add Dynamic Role
	public class AddDynamicRoles
    {
        private static string GetDisplayValueForAssociation(string EntityName, string id)
        {
            try
            {
                Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + EntityName + "Controller");
                object objController = Activator.CreateInstance(controller, null);
                MethodInfo mc = controller.GetMethod("GetDisplayValue");
                object[] MethodParams = new object[] { id };
                var obj = mc.Invoke(objController, MethodParams);
                return Convert.ToString(obj == null ? "" : obj);
            }
            catch { return id; }
        }
        private bool CheckCondition(object obj1, string EntityName, string PropName, string value)
        {
			if (ModelReflector.Entities == null) return false;
            var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == EntityName);
            if (EntityInfo != null)
            {
                var PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == PropName);
                if (PropInfo != null)
                {
                    var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == PropName);
                    string DataType = PropInfo.DataType;
                    PropertyInfo[] properties = (obj1.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
                    var Property = properties.FirstOrDefault(p => p.Name == PropName);
                    object PropValue = Property.GetValue(obj1, null);
                    if (AssociationInfo != null)
                    {
                        if (PropValue != null)
                            PropValue = GetDisplayValueForAssociation(AssociationInfo.Target, Convert.ToString(PropValue));
                        DataType = "Association";
                    }
                    return ValidateValueAgainstRule(PropValue, DataType, "=", value, Property);
                }
            }
            return false;
        }
        private static bool ValidateValueAgainstRule(object PropValue, string DataType, string condition, string value, PropertyInfo property)
        {
            if (PropValue == null) return false;
            bool result = false;
            Type targetType = property.PropertyType;
            if (property.PropertyType.IsGenericType)
                targetType = property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(property.PropertyType) : property.PropertyType;
            if (DataType == "Association")
            {
                targetType = typeof(System.String);
                PropValue = Convert.ToString(PropValue).Trim();
            }
            dynamic value1 = Convert.ChangeType(PropValue, targetType);
            dynamic value2 = Convert.ChangeType(value.Trim(), targetType);
            switch (condition)
            {
                case "=": if (value1 == value2) return true; break;
                case ">": if (value1 > value2) return true; break;
                case "<": if (value1 < value2) return true; break;
                case "<=": if (value1 <= value2) return true; break;
                case ">=": if (value1 >= value2) return true; break;
                case "!=": if (value1 != value2) return true; break;
                case "Contains": if ((Convert.ToString(value1)).Contains(value2.ToString())) return true; break;
            }
            return result;
        }
        public string[] AddRolesDynamic(string[] roles, string userid)
        {
            ApplicationContext db = new ApplicationContext(new SystemUser());
            var dynamicRoles = db.DynamicRoleMappings.ToList();
            foreach (var adr in dynamicRoles)
            {
                if (roles.Contains(adr.RoleId)) continue;
				if (adr.EntityName == "T_Employee")
                {
                    if (adr.UserRelation == "T_EmployeeUserLoginID")
                    {
                        var _Object = db.T_Employees.FirstOrDefault(p => p.T_EmployeeUserLoginID == userid);
                        if (_Object != null)
                        {
                           if(CheckCondition(_Object,"T_Employee",adr.Condition,adr.Value))
                                roles = (roles ?? Enumerable.Empty<string>()).Concat(Enumerable.Repeat(adr.RoleId, 1)).ToArray();
                        }
                    }
                }
				if (adr.EntityName == "T_FacilityUser")
                {
                    if (adr.UserRelation == "T_UserID")
                    {
                        var _Object = db.T_FacilityUsers.FirstOrDefault(p => p.T_UserID == userid);
                        if (_Object != null)
                        {
                           if(CheckCondition(_Object,"T_FacilityUser",adr.Condition,adr.Value))
                                roles = (roles ?? Enumerable.Empty<string>()).Concat(Enumerable.Repeat(adr.RoleId, 1)).ToArray();
                        }
                    }
                }
            }
            return roles;
        }
    }
	//End Dynamic Role
	 //Check Owner level permission
    public class CheckPermissionForOwner
    {
        private bool CheckUserCondition(IUser user, Object original)
        {
            ApplicationDbContext userdb = new ApplicationDbContext(true);
            var userObj = userdb.Users.FirstOrDefault(p => p.UserName == user.Name);
            if (userObj != null && original.ToString() == userObj.Id)
                return false;
            return true;
        }
        private object getObject(IUser user, string EntityName, Object obj, bool FromContext, string propName)
        {
            Object original;
            propName = propName.Trim();
			try{
				if (FromContext)
				{
					obj = (System.Data.Entity.Infrastructure.DbPropertyValues)obj;
					original = ((System.Data.Entity.Infrastructure.DbPropertyValues)obj)[propName + "ID"];
				}
				else
				{
					PropertyInfo[] properties = (obj.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
					var Property = properties.FirstOrDefault(p => p.Name == propName + "ID");
					original = Property.GetValue(obj, null);
				}
				return original;
			}
			catch{return null;}
        }
		public bool CheckLockCondition(string EntityName, Object obj, IUser user, bool FromContext)
        {	
	    try{	
			bool result = false;
			ApplicationContext db = new ApplicationContext(new SystemUser());
			var BRMain = user.businessrules.Where(p => p.EntityName == EntityName).ToList();
            if (BRMain.Count() > 0)
            {
                var ResultOfBusinessRules = db.LockEntityRule(obj, BRMain, EntityName);
                if (ResultOfBusinessRules != null && ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(11))
                {
                    return true;
                }
            }
            var type = obj.GetType();
            var assolist = ModelReflector.Entities.Where(p => p.Name == EntityName).ToList()[0].Associations.ToList();
            PropertyInfo[] properties = type.GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            foreach(var asso in assolist)
            {
				if (asso.Target == null || asso.Target == "IdentityUser") continue;
                var BR = user.businessrules.Where(p => p.EntityName == asso.Target).ToList();
                if (BR.Count() == 0) continue;
				object value = null;
				if (!FromContext)
                    value = type.GetProperty(asso.Name.ToLower()).GetValue(obj, null);
                else
                {
                    obj = (System.Data.Entity.Infrastructure.DbPropertyValues)obj;
                    var original = ((System.Data.Entity.Infrastructure.DbPropertyValues)obj)[asso.Name + "ID"];
                    Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + asso.Target + "Controller");
                    object objController = Activator.CreateInstance(controller, null);
                    MethodInfo mc = controller.GetMethod("GetRecordById");
                    object[] MethodParams = new object[] { Convert.ToString(original) };
                    value = mc.Invoke(objController, MethodParams);
                }
 				if (value != null)
                {
					var ResultOfBusinessRules = db.LockEntityRule(value, BR, asso.Target);
					if (ResultOfBusinessRules != null && ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(11))
					{
					    return true;
					}
				}
            }
			 return result;
			}catch{return false;}
        }
        public bool CheckOwnerPermission(string EntityName, Object obj, IUser user, bool FromContext)
        {
            var result = true;
            ApplicationContext db = new ApplicationContext(new SystemUser());
            var OwnerAssociationName = user.OwnerAssociation(EntityName);
if (EntityName == "T_Employee")
{
			 var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeAtFacility"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeAtFacility");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_EmployeeStatus"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeStatus");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_CurrentEmployeeEmploymentProfile"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_CurrentEmployeeEmploymentProfile");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_CurrentEmployeeJobAssignment"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_CurrentEmployeeJobAssignment");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_EmployeeGender"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeGender");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_EmployeeRace"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeRace");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_EmployeeNationalityAssociation"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeNationalityAssociation");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_EmployeeVeteranStatus"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeVeteranStatus");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_EmployeeCardEmplGrpAssociation"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeCardEmplGrpAssociation");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_EmployeeCardLvPlanAssociation"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeCardLvPlanAssociation");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_EmployeeAddress"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeAddress");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_EmployeeUserLogin"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeUserLogin");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
 return entresult;
}
if (EntityName == "T_FacilityUser")
{
			 var entresult = true;
                if (OwnerAssociationName.Contains("T_User"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_User");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
                if (OwnerAssociationName.Contains("T_Facility"))
                {
                    Object original = getObject(user, EntityName, obj, FromContext, "T_Facility");
					if (original != null)
						entresult = entresult && (CheckUserCondition(user, original));
                }
 return entresult;
}
 if (EntityName == "FileDocument")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeDocuments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeDocuments");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_Licenses")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_LicenseRecords"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_LicenseRecords");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_AssociatedLicensesType"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_AssociatedLicensesType");
                    var relationobj = db.T_Licensestypes.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Licensestype").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Licensestype", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_ServiceRecord")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeEmploymentProfile"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeEmploymentProfile");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmploymentRecordEmployeeType"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmploymentRecordEmployeeType");
                    var relationobj = db.T_EmployeeTypes.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_EmployeeType").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_EmployeeType", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmploymentRecordHiredAtFacility"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmploymentRecordHiredAtFacility");
                    var relationobj = db.T_AllFacilitiess.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_AllFacilities").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_AllFacilities", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeeTerminationReason"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeTerminationReason");
                    var relationobj = db.T_TerminationReasons.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_TerminationReason").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_TerminationReason", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeeRecordTerminationFacility"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeRecordTerminationFacility");
                    var relationobj = db.T_AllFacilitiess.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_AllFacilities").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_AllFacilities", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_Comment")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeComments");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_AccommodationComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_AccommodationComments");
                    var relationobj = db.T_Accommodations.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Accommodation").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Accommodation", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_DrugAlcoholTestComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_DrugAlcoholTestComments");
                    var relationobj = db.T_DrugAlcoholTests.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_DrugAlcoholTest").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_DrugAlcoholTest", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EducationComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EducationComments");
                    var relationobj = db.T_Educations.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Education").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Education", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_InjuryComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_InjuryComments");
                    var relationobj = db.T_EmployeeInjurys.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_EmployeeInjury").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_EmployeeInjury", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_JobAssignmentComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_JobAssignmentComments");
                    var relationobj = db.T_JobAssignments.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_JobAssignment").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_JobAssignment", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_LeaveComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_LeaveComments");
                    var relationobj = db.T_LeaveProfiles.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_LeaveProfile").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_LeaveProfile", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_LicensesComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_LicensesComments");
                    var relationobj = db.T_Licensess.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Licenses").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Licenses", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_SalaryComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_SalaryComments");
                    var relationobj = db.T_PayDetailss.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_PayDetails").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_PayDetails", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_PreemploymentComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_PreemploymentComments");
                    var relationobj = db.T_BackgroundChecks.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_BackgroundCheck").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_BackgroundCheck", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_ServiceRecordComments"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_ServiceRecordComments");
                    var relationobj = db.T_ServiceRecords.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_ServiceRecord").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_ServiceRecord", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_DrugAlcoholTest")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeDrugAlcoholTest"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeDrugAlcoholTest");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_TypeOfTest"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_TypeOfTest");
                    var relationobj = db.T_TestTypes.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_TestType").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_TestType", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_TestReason"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_TestReason");
                    var relationobj = db.T_ReasonForDrugTests.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_ReasonForDrugTest").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_ReasonForDrugTest", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_DrugTestResults"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_DrugTestResults");
                    var relationobj = db.T_DrugTestResults.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_DrugTestResult").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_DrugTestResult", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_UnitX")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_FacilityUnitX"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_FacilityUnitX");
                    var relationobj = db.T_Facilitys.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Facility").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Facility", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_UnitXUnitAssociation"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_UnitXUnitAssociation");
                    var relationobj = db.T_Units.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Unit").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Unit", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_WardDepartment"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_WardDepartment");
                    var relationobj = db.T_Departments.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Department").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Department", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_UnitXDepartmentArea"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_UnitXDepartmentArea");
                    var relationobj = db.T_DepartmentAreas.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_DepartmentArea").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_DepartmentArea", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_WardOrgCode"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_WardOrgCode");
                    var relationobj = db.T_OrgCodess.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_OrgCodes").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_OrgCodes", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_UnitXFloor"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_UnitXFloor");
                    var relationobj = db.T_Floors.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Floor").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Floor", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeeAdministrator"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeAdministrator");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeeUnitXHead"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeUnitXHead");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_WardCostCenter"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_WardCostCenter");
                    var relationobj = db.T_CostCenters.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_CostCenter").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_CostCenter", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_JobAssignment")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeJobAssignment"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeJobAssignment");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_PositionJobAssignment"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_PositionJobAssignment");
                    var relationobj = db.T_Positions.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Position").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Position", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_JobAssignmentReason"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_JobAssignmentReason");
                    var relationobj = db.T_ReasonforHires.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_ReasonforHire").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_ReasonforHire", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_JobAssignmentUnitX"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_JobAssignmentUnitX");
                    var relationobj = db.T_UnitXs.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_UnitX").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_UnitX", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_JobAssignmentManagerEmployee"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_JobAssignmentManagerEmployee");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeeSupervisor"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeSupervisor");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_LeaveProfile")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeLeaveProfile"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeLeaveProfile");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_InjuryRelatedLeave"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_InjuryRelatedLeave");
                    var relationobj = db.T_EmployeeInjurys.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_EmployeeInjury").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_EmployeeInjury", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_EmployeeInjury")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeEmployeeInjury"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeEmployeeInjury");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_TypeofClaimMCI"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_TypeofClaimMCI");
                    var relationobj = db.T_ClaimTypeMCIs.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_ClaimTypeMCI").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_ClaimTypeMCI", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_AccidentShift"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_AccidentShift");
                    var relationobj = db.T_ShiftTimes.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_ShiftTime").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_ShiftTime", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_FacilityAccidentOccured"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_FacilityAccidentOccured");
                    var relationobj = db.T_AllFacilitiess.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_AllFacilities").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_AllFacilities", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_UnitWhereAccidentOccured"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_UnitWhereAccidentOccured");
                    var relationobj = db.T_AllFacilitiesUnits.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_AllFacilitiesUnit").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_AllFacilitiesUnit", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeInjuryFloor"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeInjuryFloor");
                    var relationobj = db.T_AllFacilitiesFloors.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_AllFacilitiesFloor").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_AllFacilitiesFloor", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_LocationOfAccident"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_LocationOfAccident");
                    var relationobj = db.T_WCAccidents.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_WCAccident").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_WCAccident", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeeInjuryCause"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeInjuryCause");
                    var relationobj = db.T_InjuryCauses.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_InjuryCause").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_InjuryCause", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeeInjuryNature"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeInjuryNature");
                    var relationobj = db.T_InjuryNatures.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_InjuryNature").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_InjuryNature", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeeInjuryBodyPartsAffected"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeInjuryBodyPartsAffected");
                    var relationobj = db.T_BodyPartsAffecteds.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_BodyPartsAffected").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_BodyPartsAffected", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EMployeeInjuryMachineTool"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EMployeeInjuryMachineTool");
                    var relationobj = db.T_MachineTools.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_MachineTool").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_MachineTool", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_InitialTreatmentList"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_InitialTreatmentList");
                    var relationobj = db.T_InitialTreatments.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_InitialTreatment").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_InitialTreatment", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeeInjuryMedicalFacilityForTreatment"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeInjuryMedicalFacilityForTreatment");
                    var relationobj = db.T_MedicalFacilityForTreatments.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_MedicalFacilityForTreatment").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_MedicalFacilityForTreatment", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EmployeeInjuryRefusal"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeInjuryRefusal");
                    var relationobj = db.T_Refusals.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Refusal").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Refusal", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_BackgroundCheck")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeCriminalBackgroundCheck"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeCriminalBackgroundCheck");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_RetainTablePreEmploymentCheck"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_RetainTablePreEmploymentCheck");
                    var relationobj = db.T_RetainTables.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_RetainTable").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_RetainTable", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_PreEmploymentCheckResultsVAState"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_PreEmploymentCheckResultsVAState");
                    var relationobj = db.T_ResultsTables.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_ResultsTable").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_ResultsTable", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_Reviewer"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_Reviewer");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_CPSResult"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_CPSResult");
                    var relationobj = db.T_CPSResultss.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_CPSResults").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_CPSResults", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_Education")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeEducation"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeEducation");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_LevelOfEducation"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_LevelOfEducation");
                    var relationobj = db.T_EducationLevels.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_EducationLevel").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_EducationLevel", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_MajorInMultiCheckBox"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_MajorInMultiCheckBox");
                    var relationobj = db.T_Majors.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Major").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Major", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_EducationVerificationVendor"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EducationVerificationVendor");
                    var relationobj = db.T_Vendors.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Vendor").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Vendor", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_Accommodation")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeeAccomodation"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeeAccomodation");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_AccommodationInjury"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_AccommodationInjury");
                    var relationobj = db.T_EmployeeInjurys.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_EmployeeInjury").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_EmployeeInjury", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_PayDetails")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_EmployeePayDetails"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_EmployeePayDetails");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_PayDetailsJobAssignment"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_PayDetailsJobAssignment");
                    var relationobj = db.T_JobAssignments.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_JobAssignment").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_JobAssignment", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_OtherPayDetailsType"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_OtherPayDetailsType");
                    var relationobj = db.T_PayTypes.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_PayType").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_PayType", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_ConversationalEmployeeForeignLanguage")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_Employee"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_Employee");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_Langauge"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_Langauge");
                    var relationobj = db.T_Langauges.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Langauge").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Langauge", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
 if (EntityName == "T_LanguageCertifiedIn")
{
			var entresult = true;
                if (OwnerAssociationName.Contains("T_Employee"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_Employee");
                    var relationobj = db.T_Employees.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Employee").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Employee", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else (CheckUserCondition(user, relationobj.T_EmployeeUserLoginID) );
										}
				  }
                }
                if (OwnerAssociationName.Contains("T_Langauge"))
                {
					Object original = getObject(user, EntityName, obj, FromContext, "T_Langauge");
                    var relationobj = db.T_Langauges.Find(original);
                    if (original != null)
                    {
				     if (relationobj != null)
					 {
												foreach (var str in user.OwnerAssociation("T_Langauge").Split(",".ToArray()))
                            {
                                var UserName = getObject(user, "T_Langauge", relationobj, false, str);
                                if (UserName != null)
                                    entresult = entresult && (CheckUserCondition(user, UserName));
                            }
							//else ();
										}
				  }
                }
	return entresult;
}
            return result;
        }
    }
    //End Owner level permission
}
