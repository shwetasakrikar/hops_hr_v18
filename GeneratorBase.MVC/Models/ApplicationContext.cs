using GeneratorBase.MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;
namespace GeneratorBase.MVC
{
    public partial class ApplicationContext : DbContext
    {
        IUser user;
		int mode = -1; // 1 means bypass everthing and savechanges, 0 means ignore dirty property check, similarly you can create different modes as per requirement
        public ApplicationContext(IUser user)
            : base("DefaultConnection")
        {
            this.user = user;
			//this.Database.Log = MvcApplication.LogToConsole;
			if (this.user != null && !this.user.IsAdmin)
			this.ApplyFilters(new List<IFilter<ApplicationContext>>()
                     {
                         new ApplicationSecurityFilter(user)                                         
                     });
        }	
		public ApplicationContext(IUser user, int mode)
            : base("DefaultConnection")
        {
            this.user = user;
            this.mode = mode;
        }
        public IDbSet<FileDocument> FileDocuments { get; set; }
        public IDbSet<T_Vendor> T_Vendors { get; set; }
        public IDbSet<T_Licenses> T_Licensess { get; set; }
        public IDbSet<T_Program> T_Programs { get; set; }
        public IDbSet<T_CostCenter> T_CostCenters { get; set; }
        public IDbSet<T_Fund> T_Funds { get; set; }
        public IDbSet<T_OrgCodes> T_OrgCodess { get; set; }
        public IDbSet<T_Department> T_Departments { get; set; }
        public IDbSet<T_PositionType> T_PositionTypes { get; set; }
        public IDbSet<T_SalaryBand> T_SalaryBands { get; set; }
        public IDbSet<T_Facility> T_Facilitys { get; set; }
        public IDbSet<T_Position> T_Positions { get; set; }
        public IDbSet<T_TerminationReason> T_TerminationReasons { get; set; }
        public IDbSet<T_ServiceRecord> T_ServiceRecords { get; set; }
        public IDbSet<T_EmployeeType> T_EmployeeTypes { get; set; }
        public IDbSet<T_Gender> T_Genders { get; set; }
        public IDbSet<T_VeteranStatus> T_VeteranStatuss { get; set; }
        public IDbSet<T_PositionFillReason> T_PositionFillReasons { get; set; }
        public IDbSet<T_EEOCode> T_EEOCodes { get; set; }
        public IDbSet<T_Credential> T_Credentials { get; set; }
        public IDbSet<T_EducationLevel> T_EducationLevels { get; set; }
        public IDbSet<T_PositionLevel> T_PositionLevels { get; set; }
        public IDbSet<T_PositionPostStatus> T_PositionPostStatuss { get; set; }
        public IDbSet<T_EmployeeStatusCode> T_EmployeeStatusCodes { get; set; }
        public IDbSet<T_SocCode> T_SocCodes { get; set; }
        public IDbSet<T_ClassCode> T_ClassCodes { get; set; }
        public IDbSet<T_ShiftMealTime> T_ShiftMealTimes { get; set; }
        public IDbSet<T_Employee> T_Employees { get; set; }
        public IDbSet<T_DepartmentArea> T_DepartmentAreas { get; set; }
        public IDbSet<T_LeaveReason> T_LeaveReasons { get; set; }
        public IDbSet<T_Comment> T_Comments { get; set; }
        public IDbSet<T_Commenttype> T_Commenttypes { get; set; }
        public IDbSet<T_ClaimType> T_ClaimTypes { get; set; }
        public IDbSet<T_Restrictions> T_Restrictionss { get; set; }
        public IDbSet<T_Refusal> T_Refusals { get; set; }
        public IDbSet<T_InjuryCause> T_InjuryCauses { get; set; }
        public IDbSet<T_CPSResults> T_CPSResultss { get; set; }
        public IDbSet<T_DrugAlcoholTest> T_DrugAlcoholTests { get; set; }
        public IDbSet<T_ReasonForDrugTest> T_ReasonForDrugTests { get; set; }
        public IDbSet<T_ResultsForDrugTest> T_ResultsForDrugTests { get; set; }
        public IDbSet<T_Country> T_Countrys { get; set; }
        public IDbSet<T_State> T_States { get; set; }
        public IDbSet<T_Positionstatus> T_Positionstatuss { get; set; }
        public IDbSet<T_RoleCode> T_RoleCodes { get; set; }
        public IDbSet<T_UnitX> T_UnitXs { get; set; }
        public IDbSet<T_JobAssignment> T_JobAssignments { get; set; }
        public IDbSet<T_Address> T_Addresss { get; set; }
        public IDbSet<T_City> T_Citys { get; set; }
        public IDbSet<T_Race> T_Races { get; set; }
        public IDbSet<T_LeaveProfile> T_LeaveProfiles { get; set; }
        public IDbSet<T_EmployeeInjury> T_EmployeeInjurys { get; set; }
        public IDbSet<T_Patient> T_Patients { get; set; }
        public IDbSet<T_WCAccident> T_WCAccidents { get; set; }
        public IDbSet<T_BackgroundCheck> T_BackgroundChecks { get; set; }
        public IDbSet<T_RetainTable> T_RetainTables { get; set; }
        public IDbSet<T_ResultsTable> T_ResultsTables { get; set; }
        public IDbSet<T_EmployeeTerminationFacility> T_EmployeeTerminationFacilitys { get; set; }
        public IDbSet<T_Licensestype> T_Licensestypes { get; set; }
        public IDbSet<T_OvertimeEligibility> T_OvertimeEligibilitys { get; set; }
        public IDbSet<T_Langauge> T_Langauges { get; set; }
        public IDbSet<T_InjuryNature> T_InjuryNatures { get; set; }
        public IDbSet<T_BodyPartsAffected> T_BodyPartsAffecteds { get; set; }
        public IDbSet<T_InitialTreatment> T_InitialTreatments { get; set; }
        public IDbSet<T_ClaimTypeMCI> T_ClaimTypeMCIs { get; set; }
        public IDbSet<T_MachineTool> T_MachineTools { get; set; }
        public IDbSet<T_Unit> T_Units { get; set; }
        public IDbSet<T_DrugTestResult> T_DrugTestResults { get; set; }
        public IDbSet<T_Education> T_Educations { get; set; }
        public IDbSet<T_Accommodation> T_Accommodations { get; set; }
        public IDbSet<T_TestType> T_TestTypes { get; set; }
        public IDbSet<T_Major> T_Majors { get; set; }
        public IDbSet<T_RequiredEducation> T_RequiredEducations { get; set; }
        public IDbSet<T_ReasonforHire> T_ReasonforHires { get; set; }
        public IDbSet<T_WCCode> T_WCCodes { get; set; }
        public IDbSet<T_MedicalFacilityForTreatment> T_MedicalFacilityForTreatments { get; set; }
        public IDbSet<T_ShiftTime> T_ShiftTimes { get; set; }
        public IDbSet<T_Floor> T_Floors { get; set; }
        public IDbSet<T_PayType> T_PayTypes { get; set; }
        public IDbSet<T_PayDetails> T_PayDetailss { get; set; }
        public IDbSet<T_ShiftDuration> T_ShiftDurations { get; set; }
        public IDbSet<T_AllFacilities> T_AllFacilitiess { get; set; }
        public IDbSet<T_AllFacilitiesUnit> T_AllFacilitiesUnits { get; set; }
        public IDbSet<T_AllFacilitiesFloor> T_AllFacilitiesFloors { get; set; }
        public IDbSet<T_WorkingTitle> T_WorkingTitles { get; set; }
        public IDbSet<T_SalaryRange> T_SalaryRanges { get; set; }
        public IDbSet<T_Nationality> T_Nationalitys { get; set; }
        public IDbSet<T_CardLvPlan> T_CardLvPlans { get; set; }
        public IDbSet<T_CardEmplGrp> T_CardEmplGrps { get; set; }
        public IDbSet<T_FacilityConfiguration> T_FacilityConfigurations { get; set; }
        public IDbSet<T_FacilityUser> T_FacilityUsers { get; set; }
        public IDbSet<T_ConversationalEmployeeForeignLanguage> T_ConversationalEmployeeForeignLanguages { get; set; }
        public IDbSet<T_LanguageCertifiedIn> T_LanguageCertifiedIns { get; set; }
        public IDbSet<T_LeaveProfileReason> T_LeaveProfileReasons { get; set; }
        public IDbSet<T_TypeofClaim> T_TypeofClaims { get; set; }
        public IDbSet<T_TypeOfRestrictions> T_TypeOfRestrictionss { get; set; }
		//Default DbSet for Application
		public IDbSet<Document> Documents { get; set; }
		public IDbSet<ImportConfiguration> ImportConfigurations { get; set; }     
		public IDbSet<FavoriteItem> FavoriteItems { get; set; }
		public IDbSet<DefaultEntityPage> DefaultEntityPages { get; set; }
		public IDbSet<DynamicRoleMapping> DynamicRoleMappings { get; set; }	 
		public IDbSet<ApplicationFeedback> ApplicationFeedbacks { get; set; }
		public IDbSet<ApplicationFeedbackType> ApplicationFeedbackTypes { get; set; }
		public IDbSet<ApplicationFeedbackStatus> ApplicationFeedbackStatuss { get; set; }
		public IDbSet<FeedbackPriority> FeedbackPrioritys { get; set; }
		public IDbSet<FeedbackSeverity> FeedbackSeveritys { get; set; }
		public IDbSet<FeedbackResource> FeedbackResources { get; set; }
		public IDbSet<AppSettingGroup> AppSettingGroups { get; set; }
		public IDbSet<AppSetting> AppSettings { get; set; }
		public IDbSet<EmailTemplateType> EmailTemplateTypes { get; set; }
		public IDbSet<EmailTemplate> EmailTemplates { get; set; }
		public IDbSet<EntityDataSource> EntityDataSources { get; set; }
        public IDbSet<DataSourceParameters> DataSourceParameterss { get; set; }
        public IDbSet<PropertyMapping> PropertyMappings { get; set; }
		public IDbSet<T_Chart> Charts { get; set; }
		//Scheduler
		public IDbSet<T_Schedule> T_Schedules { get; set; }
        public IDbSet<T_Scheduletype> T_Scheduletypes { get; set; }
        public IDbSet<T_RecurringScheduleDetailstype> T_RecurringScheduleDetailstypes { get; set; }
        public IDbSet<T_RecurringFrequency> T_RecurringFrequencys { get; set; }
        public IDbSet<T_RecurringEndType> T_RecurringEndTypes { get; set; }
        public IDbSet<T_RecurrenceDays> T_RecurrenceDayss { get; set; }
        public IDbSet<T_MonthlyRepeatType> T_MonthlyRepeatTypes { get; set; }
        public IDbSet<T_RepeatOn> T_RepeatOns { get; set; }
		//Web Api
		public IDbSet<ApiToken> ApiTokens { get; set; }//will be used in case of webapi only
        //Custom Reports
        public IDbSet<CustomReports> CustomReportss { get; set; }
		public IDbSet<ReportsInRole> ReportsInRoles { get; set; }
        public IDbSet<ApplicationUser> T_Users { get; set; }
		public IDbSet<JournalEntry> JournalEntries { get; set; }
		 
		//End default DbSet for Application
        public override int SaveChanges()
        {
			if (this.mode == 1)
                return base.SaveChanges();
			var result = 0;
            var entries = this.ChangeTracker.Entries().Where(e => e.State.HasFlag(EntityState.Added) ||
                                                                   e.State.HasFlag(EntityState.Modified) ||
                                                                   e.State.HasFlag(EntityState.Deleted));
            var originalStates = new Dictionary<DbEntityEntry, EntityState>();
            foreach (var entry in entries)
            {
				if(this.mode != 0) //0 to ignore dirty properties check, and force calling save
					if (!CheckIfModified(entry)) { CancelChanges(entry); continue; }
                
				if (ValidateBeforeSave(entry) == false)
                {
                    CancelChanges(entry); continue;
                }
                OnSaving(entry);
                //Add in list for business logic after successfully save.
                if (!originalStates.ContainsKey(entry))
                    originalStates.Add(entry, entry.State);
				if(CheckExternalAPISave(entry))
                {
                    CancelChanges(entry); continue;
                }
            }
            result = base.SaveChanges();//Save Changes
            ApplyBusinessLogicAfterSave(originalStates);
            return result;
        }
		private void OnSaving(DbEntityEntry entry)
        {
            if (entry.State != EntityState.Deleted)
                OnSavingCustom(entry, this);//29March2017 for performance
            else
                OnDeletingCustom(entry);
		    SetDateTimeToUTC(entry);
            SetCalculatedValue(entry);
            SetAutoProperty(entry);
            SetDisplayValue(entry);
            CheckFieldLevelSecurity(entry);
			TimeBasedAlert(entry);
            if (entry.State == EntityState.Modified)
            {
                AssignOneToManyCurrentOnUpdate(entry);
                MakeUpdateJournalEntry(entry);
            }
			OrderedListCheck(entry);
            if (entry.State == EntityState.Deleted)
                MakeDeleteJournalEntry(entry);
        }
        private void ApplyBusinessLogicAfterSave(Dictionary<DbEntityEntry, EntityState> originalStates)
        {
            if (originalStates != null)
            {
                if (originalStates.Any(p => p.Value.HasFlag(EntityState.Added)))
                {
					AssignOneToManyCurrentOnAdd(originalStates);
                    MakeAddJournalEntry(originalStates);
                    SetAutoProperty(originalStates);
                }
            }
            if (originalStates != null && originalStates.Any(p => p.Value.HasFlag(EntityState.Added) || p.Value.HasFlag(EntityState.Modified)))
            {
				InvokeActionRule(originalStates);
                EncryptValue(originalStates);
                TimeBasedAlert(originalStates);
                AfterSave(originalStates);
            }
        }
		private bool CheckExternalAPISave(DbEntityEntry entry)
        {
            var result = false;
            var entity = (IEntity)entry.Entity;
            var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
            var EntityName = entityType.Name;
            var state = entry.State;
            if (IsExternalEntity(entity,EntityName,state))
                result = true;
            return result;
        }
        private bool ValidateBeforeSave(DbEntityEntry entry)
        {
            var result = true;
            var entity = (IEntity)entry.Entity;
            var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
            var EntityName = entityType.Name;
            if (!CheckPermissionOnEntity(EntityName, entry.State))
                return false;
            if (CheckOwnerPermission(entry))
                return false;
            if (ViolatingBusinessRules(entry))
                return false;
			if (CheckLockCondition(entry))
                return false;
            if ((entry.State == EntityState.Added || entry.State == EntityState.Modified))
            {
                if (!Check1MThresholdCondition(entry))
                    return false;
				string strChkBeforeSave = CheckBeforeSave(entity, EntityName);
                if (!string.IsNullOrEmpty(strChkBeforeSave))
                {
                    throw new ArgumentException(strChkBeforeSave);
                    return false;
                }
            }
            if (entry.State == EntityState.Deleted && !CheckBeforeDelete(entity, EntityName))
            {
                throw new ArgumentException("Validation Alert - Before Delete !! Record not deleted.");
                return false;
            }
            return result;
        }
    }
}

