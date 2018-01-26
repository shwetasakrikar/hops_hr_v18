using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
namespace GeneratorBase.MVC.Models
{
    [Table("tbl_Employee"),CustomDisplayName("T_Employee", "T_Employee.resx", "Employee")]
	public partial class T_Employee : Entity
    {	
		public T_Employee()
        {
            this.T_ConversationalEmployeeForeignLanguage_t_employee = new HashSet<T_ConversationalEmployeeForeignLanguage>();
            this.T_LanguageCertifiedIn_t_employee = new HashSet<T_LanguageCertifiedIn>();
            this.t_employeedocuments = new HashSet<FileDocument>();
            this.t_licenserecords = new HashSet<T_Licenses>();
            this.t_employeeemployeeinjury = new HashSet<T_EmployeeInjury>();
            this.t_employeecriminalbackgroundcheck = new HashSet<T_BackgroundCheck>();
            this.t_employeecomments = new HashSet<T_Comment>();
            this.t_employeeleaveprofile = new HashSet<T_LeaveProfile>();
            this.t_employeeeducation = new HashSet<T_Education>();
            this.t_employeeaccomodation = new HashSet<T_Accommodation>();
            this.t_employeeemploymentprofile = new HashSet<T_ServiceRecord>();
            this.t_employeejobassignment = new HashSet<T_JobAssignment>();
            this.t_employeepaydetails = new HashSet<T_PayDetails>();
            this.t_employeedrugalcoholtest = new HashSet<T_DrugAlcoholTest>();
            this.t_employeeadministrator = new HashSet<T_UnitX>();
            this.t_employeeunitxhead = new HashSet<T_UnitX>();
            this.t_jobassignmentmanageremployee = new HashSet<T_JobAssignment>();
            this.t_employeesupervisor = new HashSet<T_JobAssignment>();
            this.t_reviewer = new HashSet<T_BackgroundCheck>();
        }
				
		[NotMapped]
        public string calc_T_FacilityPID = null;
		


	 [Unique(typeof(ApplicationContext),ErrorMessage="PID already exists. ")]
		 
		 
		[CustomDisplayName("T_FacilityPID","T_Employee.resx","FacilityPID"), Column("FacilityPID")]  
		
        public string T_FacilityPID {  get { return getT_FacilityPID(); } set { calc_T_FacilityPID = value;} }
            
           [StringLength(9 , MinimumLength = 1)]
		


		 
		 
		[CustomDisplayName("T_PID","T_Employee.resx","PID"), Column("PID")] [Required] 
		
        public string T_PID { get; set; }
            
           [RegularExpression(@"^\d{3}\-?\d{2}\-?\d{4}$", ErrorMessage = "Invalid SSN")]
		


		 
		 
		[CustomDisplayName("T_SSN","T_Employee.resx","SSN"), Column("SSN")]  
		
        public string T_SSN { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_DateOfBirth","T_Employee.resx","Date Of Birth"), Column("DateOfBirth")]  
		
        public Nullable<DateTime> T_DateOfBirth { get; set; }
				[StringLength(255, ErrorMessage = "SAM Account cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_SAMAccount","T_Employee.resx","SAM Account"), Column("SAMAccount")]  
		
        public string T_SAMAccount { get; set; }
				[StringLength(255, ErrorMessage = "Last Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_LastName","T_Employee.resx","Last Name"), Column("LastName")] [Required] 
		
        public string T_LastName { get; set; }
				[StringLength(255, ErrorMessage = "First Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_FirstName","T_Employee.resx","First Name"), Column("FirstName")] [Required] 
		
        public string T_FirstName { get; set; }
				[StringLength(255, ErrorMessage = "Middle Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_MiddleName","T_Employee.resx","Middle Name"), Column("MiddleName")]  
		
        public string T_MiddleName { get; set; }
				[StringLength(255, ErrorMessage = "Suffix cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Suffix","T_Employee.resx","Suffix"), Column("Suffix")]  
		
        public string T_Suffix { get; set; }
            
           [EmailAddress]
		


		 
		 
		[CustomDisplayName("T_WorkEmail","T_Employee.resx","Work Email"), Column("WorkEmail")]  
		
        public string T_WorkEmail { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_StateHireDate","T_Employee.resx","State Hire Date "), Column("StateHireDate")]  
		
        public Nullable<DateTime> T_StateHireDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_AdjustedHireDate","T_Employee.resx","Adjusted Hire Date"), Column("AdjustedHireDate")]  
		
        public Nullable<DateTime> T_AdjustedHireDate { get; set; }
		[NotMapped]
        public Nullable<Int32> calc_T_PriorServiceinmonths = null;
		


		 
		 
		[CustomDisplayName("T_PriorServiceinmonths","T_Employee.resx","Prior Service (in months)"), Column("PriorServiceinmonths")]  
		
        public Nullable<Int32> T_PriorServiceinmonths {  get { return getT_PriorServiceinmonths(); } set { calc_T_PriorServiceinmonths = value;} }
		[NotMapped]
        public Nullable<Int32> calc_T_CurrentServiceinmonths = null;
		


		 
		 
		[CustomDisplayName("T_CurrentServiceinmonths","T_Employee.resx","Current Service (in months)"), Column("CurrentServiceinmonths")]  
		
        public Nullable<Int32> T_CurrentServiceinmonths {  get { return getT_CurrentServiceinmonths(); } set { calc_T_CurrentServiceinmonths = value;} }
            
           [EmailAddress]
		


		 
		 
		[CustomDisplayName("T_PersonalEmail","T_Employee.resx","Personal Email"), Column("PersonalEmail")]  
		
        public string T_PersonalEmail { get; set; }
            
           [RegularExpression(@"^\d{3}\-?\d{3}\-?\d{4}$", ErrorMessage = "Invalid Mobile Phone")]
		


		 
		 
		[CustomDisplayName("T_MobilePhone","T_Employee.resx","Mobile Phone"), Column("MobilePhone")]  
		
        public string T_MobilePhone { get; set; }
            
           [RegularExpression(@"^\d{3}\-?\d{3}\-?\d{4}$", ErrorMessage = "Invalid Home Phone")]
		


		 
		 
		[CustomDisplayName("T_HomePhone","T_Employee.resx","Home Phone"), Column("HomePhone")]  
		
        public string T_HomePhone { get; set; }
				[StringLength(255, ErrorMessage = "Emergency Contact Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_EmergencyContactName","T_Employee.resx","Emergency Contact Name"), Column("EmergencyContactName")]  
		
        public string T_EmergencyContactName { get; set; }
				[StringLength(255, ErrorMessage = "Emergency Contact Relationship cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_EmergencyContactRelationship","T_Employee.resx","Emergency Contact Relationship"), Column("EmergencyContactRelationship")]  
		
        public string T_EmergencyContactRelationship { get; set; }
            
           [RegularExpression(@"^\d{3}\-?\d{3}\-?\d{4}$", ErrorMessage = "Invalid Emergency Mobile Phone")]
		


		 
		 
		[CustomDisplayName("T_EmergencyMobilePhone","T_Employee.resx","Emergency Mobile Phone"), Column("EmergencyMobilePhone")]  
		
        public string T_EmergencyMobilePhone { get; set; }
            
           [RegularExpression(@"^\d{3}\-?\d{3}\-?\d{4}$", ErrorMessage = "Invalid Emergency Work Phone")]
		


		 
		 
		[CustomDisplayName("T_EmergencyWorkPhone","T_Employee.resx","Emergency Work Phone"), Column("EmergencyWorkPhone")]  
		
        public string T_EmergencyWorkPhone { get; set; }
		


		 
		 
		[CustomDisplayName("T_BadgeNumber","T_Employee.resx","Badge Number"), Column("BadgeNumber")]  
		
        public Nullable<Int32> T_BadgeNumber { get; set; }
		[NotMapped]
        public Nullable<DateTime> m_T_EffectiveDateTime { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.DateTime)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_EffectiveDateTime","T_Employee.resx","Effective Date & Time"), Column("EffectiveDateTime")]  
		
        public Nullable<DateTime> T_EffectiveDateTime { get; set; }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmployeeAtFacilityID","T_Employee.resx","Facility"), Column("EmployeeAtFacilityID")]
        public Nullable<long> T_EmployeeAtFacilityID { get; set; }
		
        public virtual T_Facility t_employeeatfacility { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmployeeStatusID","T_Employee.resx","Employee Status"), Column("EmployeeStatusID")]
        public Nullable<long> T_EmployeeStatusID { get; set; }
		
        public virtual T_EmployeeStatusCode t_employeestatus { get; set;}
		


		[CustomDisplayName("T_CurrentEmployeeEmploymentProfileID","T_Employee.resx","Service Record"), Column("CurrentEmployeeEmploymentProfileID")]
        public Nullable<long> T_CurrentEmployeeEmploymentProfileID { get; set; }
		
        public virtual T_ServiceRecord t_currentemployeeemploymentprofile { get; set;}
		


		[CustomDisplayName("T_CurrentEmployeeJobAssignmentID","T_Employee.resx","Primary Job Assignment"), Column("CurrentEmployeeJobAssignmentID")]
        public Nullable<long> T_CurrentEmployeeJobAssignmentID { get; set; }
		
        public virtual T_JobAssignment t_currentemployeejobassignment { get; set;}
		


		[CustomDisplayName("T_EmployeeGenderID","T_Employee.resx","Gender"), Column("EmployeeGenderID")]
        public Nullable<long> T_EmployeeGenderID { get; set; }
		
        public virtual T_Gender t_employeegender { get; set;}
		


		[CustomDisplayName("T_EmployeeRaceID","T_Employee.resx","Race"), Column("EmployeeRaceID")]
        public Nullable<long> T_EmployeeRaceID { get; set; }
		
        public virtual T_Race t_employeerace { get; set;}
		


		[CustomDisplayName("T_EmployeeNationalityAssociationID","T_Employee.resx","Nationality"), Column("EmployeeNationalityAssociationID")]
        public Nullable<long> T_EmployeeNationalityAssociationID { get; set; }
		
        public virtual T_Nationality t_employeenationalityassociation { get; set;}
		


		[CustomDisplayName("T_EmployeeVeteranStatusID","T_Employee.resx","Veteran Status"), Column("EmployeeVeteranStatusID")]
        public Nullable<long> T_EmployeeVeteranStatusID { get; set; }
		
        public virtual T_VeteranStatus t_employeeveteranstatus { get; set;}
		


		[CustomDisplayName("T_EmployeeCardEmplGrpAssociationID","T_Employee.resx","CardEmplGrp"), Column("EmployeeCardEmplGrpAssociationID")]
        public Nullable<long> T_EmployeeCardEmplGrpAssociationID { get; set; }
		
        public virtual T_CardEmplGrp t_employeecardemplgrpassociation { get; set;}
		


		[CustomDisplayName("T_EmployeeCardLvPlanAssociationID","T_Employee.resx","CardAltLvPlan"), Column("EmployeeCardLvPlanAssociationID")]
        public Nullable<long> T_EmployeeCardLvPlanAssociationID { get; set; }
		
        public virtual T_CardLvPlan t_employeecardlvplanassociation { get; set;}
		


		[CustomDisplayName("T_EmployeeAddressID","T_Employee.resx","Employee Address"), Column("EmployeeAddressID")]
        public Nullable<long> T_EmployeeAddressID { get; set; }
		
        public virtual T_Address t_employeeaddress { get; set;}
		


		[CustomDisplayName("T_EmployeeUserLoginID","T_Employee.resx","Employee User Login"),  Column("EmployeeUserLoginID")]
        public string T_EmployeeUserLoginID { get; set; }
        public virtual IdentityUser t_employeeuserlogin { get; set; }//IdentityUser replaced by ApplicationUser
		
        public virtual ICollection<T_ConversationalEmployeeForeignLanguage> T_ConversationalEmployeeForeignLanguage_t_employee { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<T_Langauge> T_Langauge_T_ConversationalEmployeeForeignLanguage { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedT_Langauge_T_ConversationalEmployeeForeignLanguage { get; set; }
		
        public virtual ICollection<T_LanguageCertifiedIn> T_LanguageCertifiedIn_t_employee { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<T_Langauge> T_Langauge_T_LanguageCertifiedIn { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedT_Langauge_T_LanguageCertifiedIn { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<FileDocument> t_employeedocuments { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Licenses> t_licenserecords { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_EmployeeInjury> t_employeeemployeeinjury { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_BackgroundCheck> t_employeecriminalbackgroundcheck { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_employeecomments { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_LeaveProfile> t_employeeleaveprofile { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Education> t_employeeeducation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Accommodation> t_employeeaccomodation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_ServiceRecord> t_employeeemploymentprofile { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_JobAssignment> t_employeejobassignment { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_PayDetails> t_employeepaydetails { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_DrugAlcoholTest> t_employeedrugalcoholtest { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_UnitX> t_employeeadministrator { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_UnitX> t_employeeunitxhead { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_JobAssignment> t_jobassignmentmanageremployee { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_JobAssignment> t_employeesupervisor { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_BackgroundCheck> t_reviewer { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_PID != null ?Convert.ToString(this.T_PID)+"-" : Convert.ToString(this.T_PID))+(this.T_FirstName != null ?Convert.ToString(this.T_FirstName)+"  " : Convert.ToString(this.T_FirstName))+(this.T_MiddleName != null ?Convert.ToString(this.T_MiddleName)+" " : Convert.ToString(this.T_MiddleName))+(this.T_LastName != null ?Convert.ToString(this.T_LastName)+" -" : Convert.ToString(this.T_LastName))+(this.T_EmployeeStatusID != null ? (new ApplicationContext(new SystemUser())).T_EmployeeStatusCodes.FirstOrDefault(p=>p.Id == this.T_EmployeeStatusID).DisplayValue + " " : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_PID != null ?Convert.ToString(this.T_PID)+"-" : Convert.ToString(this.T_PID))+(this.T_FirstName != null ?Convert.ToString(this.T_FirstName)+"  " : Convert.ToString(this.T_FirstName))+(this.T_MiddleName != null ?Convert.ToString(this.T_MiddleName)+" " : Convert.ToString(this.T_MiddleName))+(this.T_LastName != null ?Convert.ToString(this.T_LastName)+" -" : Convert.ToString(this.T_LastName))+(this.t_employeestatus != null ?t_employeestatus.DisplayValue + " " : ""); 
			return dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			//return m_DisplayValue;
			}catch{ return "";}
					 }
		public void setCalculation(){ try{  var T_FacilityPID_Value1 = (this.T_EmployeeAtFacilityID != null ? (new ApplicationContext(new SystemUser())).T_Facilitys.Find(this.T_EmployeeAtFacilityID).T_FacilityCode :t_employeeatfacility.T_FacilityCode);
 var T_FacilityPID_Value2 = this.T_PID;
 this.calc_T_FacilityPID =  this.T_FacilityPID =  Convert.ToString(T_FacilityPID_Value1)+ Convert.ToString(T_FacilityPID_Value2);
 this.calc_T_PriorServiceinmonths =  this.T_PriorServiceinmonths = this.T_PriorServiceinmonths = Convert.ToInt32(((new ApplicationContext(new SystemUser())).T_ServiceRecords
.Where(sr => sr.T_EmployeeEmploymentProfileID == this.Id && sr.T_EmploymentRecordEmployeeTypeID == 3 && sr.T_TerminationDate != null)
.Select(p => System.Data.Entity.SqlServer.SqlFunctions.DateDiff("month", p.T_HireDate, p.T_TerminationDate))
.Select(p => (int?)p.Value).Sum()) ?? 0);; this.calc_T_CurrentServiceinmonths =  this.T_CurrentServiceinmonths = this.T_CurrentServiceinmonths = Convert.ToInt32(((new ApplicationContext(new SystemUser())).T_ServiceRecords
.Where(sr => sr.T_EmployeeEmploymentProfileID == this.Id && sr.T_EmploymentRecordEmployeeTypeID == 3 && sr.T_TerminationDate == null)
.Select(p => System.Data.Entity.SqlServer.SqlFunctions.DateDiff("month", p.T_HireDate , DateTime.Now))
.Select(p => (int?)p.Value).Sum()) ?? 0);	; }catch{}}
		public void setDateTimeToClientTime() //call this method when you have to update record from code (not from html form). e.g. BulkUpdate
		{
		this.T_EffectiveDateTime = this.T_EffectiveDateTime.HasValue ?  TimeZoneInfo.ConvertTimeFromUtc(this.T_EffectiveDateTime.Value, this.m_Timezone) : this.T_EffectiveDateTime;
		}
		public void setDateTimeToUTC()
        {
			this.T_DateOfBirth = this.T_DateOfBirth.HasValue ?  this.T_DateOfBirth.Value.Date : this.T_DateOfBirth;
			this.T_StateHireDate = this.T_StateHireDate.HasValue ?  this.T_StateHireDate.Value.Date : this.T_StateHireDate;
			this.T_AdjustedHireDate = this.T_AdjustedHireDate.HasValue ?  this.T_AdjustedHireDate.Value.Date : this.T_AdjustedHireDate;
            this.T_EffectiveDateTime = this.T_EffectiveDateTime.HasValue ?  TimeZoneInfo.ConvertTimeToUtc(this.T_EffectiveDateTime.Value, this.m_Timezone) : this.T_EffectiveDateTime;
        }
        public string getT_FacilityPID()
        {
            if (calc_T_FacilityPID == null)
			{
                var T_FacilityPID_Value1 = (this.T_EmployeeAtFacilityID != null ? (new ApplicationContext(new SystemUser())).T_Facilitys.FirstOrDefault(p=>p.Id == this.T_EmployeeAtFacilityID).T_FacilityCode : new T_Facility().T_FacilityCode);
 var T_FacilityPID_Value2 = this.T_PID;
 calc_T_FacilityPID = Convert.ToString(T_FacilityPID_Value1)+ Convert.ToString(T_FacilityPID_Value2);
;
			}
            return calc_T_FacilityPID;
        }
        public Nullable<Int32> getT_PriorServiceinmonths()
        {
            if (calc_T_PriorServiceinmonths == null)
			{
                calc_T_PriorServiceinmonths = this.T_PriorServiceinmonths = Convert.ToInt32(((new ApplicationContext(new SystemUser())).T_ServiceRecords
.Where(sr => sr.T_EmployeeEmploymentProfileID == this.Id && sr.T_EmploymentRecordEmployeeTypeID == 3 && sr.T_TerminationDate != null)
.Select(p => System.Data.Entity.SqlServer.SqlFunctions.DateDiff("month", p.T_HireDate, p.T_TerminationDate))
.Select(p => (int?)p.Value).Sum()) ?? 0);;
			}
            return calc_T_PriorServiceinmonths;
        }
        public Nullable<Int32> getT_CurrentServiceinmonths()
        {
            if (calc_T_CurrentServiceinmonths == null)
			{
                calc_T_CurrentServiceinmonths = this.T_CurrentServiceinmonths = Convert.ToInt32(((new ApplicationContext(new SystemUser())).T_ServiceRecords
.Where(sr => sr.T_EmployeeEmploymentProfileID == this.Id && sr.T_EmploymentRecordEmployeeTypeID == 3 && sr.T_TerminationDate == null)
.Select(p => System.Data.Entity.SqlServer.SqlFunctions.DateDiff("month", p.T_HireDate , DateTime.Now))
.Select(p => (int?)p.Value).Sum()) ?? 0);	;
			}
            return calc_T_CurrentServiceinmonths;
        }
    }
}

