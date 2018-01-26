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
    [Table("tbl_EmployeeInjury"),CustomDisplayName("T_EmployeeInjury", "T_EmployeeInjury.resx", "Employee Injury")]
	public partial class T_EmployeeInjury : Entity
    {	
		public T_EmployeeInjury()
        {
            this.T_TypeofClaim_t_employeeinjury = new HashSet<T_TypeofClaim>();
            this.T_TypeOfRestrictions_t_employeeinjury = new HashSet<T_TypeOfRestrictions>();
            this.t_injuryrelatedleave = new HashSet<T_LeaveProfile>();
            this.t_injurycomments = new HashSet<T_Comment>();
            this.t_accommodationinjury = new HashSet<T_Accommodation>();
        }
				[StringLength(255, ErrorMessage = "Claim No. cannot be longer than 255 characters.")]
		


	 [Unique(typeof(ApplicationContext),ErrorMessage="Claim No. is Unique.")]
		 
		 
		[CustomDisplayName("T_ClaimNo","T_EmployeeInjury.resx","Claim No."), Column("ClaimNo")]  
		
        public string T_ClaimNo { get; set; }
		


		 
		 
		[CustomDisplayName("T_OSHA","T_EmployeeInjury.resx","OSHA"), Column("OSHA")]  
		
        public Boolean? T_OSHA { get; set; }
				[StringLength(255, ErrorMessage = "Location  cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Location","T_EmployeeInjury.resx","Location "), Column("Location")]  
		
        public string T_Location { get; set; }
		[NotMapped]
        public DateTime m_T_AccidentDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.DateTime)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_AccidentDate","T_EmployeeInjury.resx","Accident Date & Time"), Column("AccidentDate")] [Required] 
		
        public DateTime T_AccidentDate { get; set; }
		


		 
		 
		[CustomDisplayName("T_DescribeHowInjuryOrIllnessOccurred","T_EmployeeInjury.resx","Describe How Injury Or Illness Occurred"), Column("DescribeHowInjuryOrIllnessOccurred")]  
		
        public string T_DescribeHowInjuryOrIllnessOccurred { get; set; }
				[StringLength(255, ErrorMessage = "Patient Involved (Regnoepi) cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_PatientInvolvedRegnoepi","T_EmployeeInjury.resx","Patient Involved (Regnoepi)"), Column("PatientInvolvedRegnoepi")]  
		
        public string T_PatientInvolvedRegnoepi { get; set; }
		


		 
		 
		[CustomDisplayName("T_ExaminingPhysician","T_EmployeeInjury.resx","Examining Physician"), Column("ExaminingPhysician")]  
		
        public string T_ExaminingPhysician { get; set; }
		


		 
		 
		[CustomDisplayName("T_ReferringPhysician","T_EmployeeInjury.resx","Referring Physician"), Column("ReferringPhysician")]  
		
        public string T_ReferringPhysician { get; set; }
		


		 
		 
		[CustomDisplayName("T_Diagnosis","T_EmployeeInjury.resx","Diagnosis "), Column("Diagnosis")]  
		
        public string T_Diagnosis { get; set; }
		


		 
		 
		[CustomDisplayName("T_DaysOff","T_EmployeeInjury.resx","Days Off"), Column("DaysOff")]  
		
        public Nullable<Int32> T_DaysOff { get; set; }
		


		 
		 
		[CustomDisplayName("T_DaysRestricted","T_EmployeeInjury.resx","Days Restricted"), Column("DaysRestricted")]  
		
        public Nullable<Int32> T_DaysRestricted { get; set; }
		


		 
		 
		[CustomDisplayName("T_DetailsOfRestriction","T_EmployeeInjury.resx","Details Of Restriction"), Column("DetailsOfRestriction")]  
		
        public string T_DetailsOfRestriction { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_RestrictionStartDate","T_EmployeeInjury.resx","Restriction Start Date"), Column("RestrictionStartDate")]  
		
        public Nullable<DateTime> T_RestrictionStartDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_RestrictionEndDate","T_EmployeeInjury.resx","Restriction End Date"), Column("RestrictionEndDate")]  
		
        public Nullable<DateTime> T_RestrictionEndDate { get; set; }
		


		 
		 
		[CustomDisplayName("T_AccidentNotes","T_EmployeeInjury.resx","Accident Notes"), Column("AccidentNotes")]  
		
        public string T_AccidentNotes { get; set; }
		


		 
		 
		[CustomDisplayName("T_RestrictionNotes","T_EmployeeInjury.resx","Restriction Notes"), Column("RestrictionNotes")]  
		
        public string T_RestrictionNotes { get; set; }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmployeeEmployeeInjuryID","T_EmployeeInjury.resx","Employee"), Column("EmployeeEmployeeInjuryID")]
        public Nullable<long> T_EmployeeEmployeeInjuryID { get; set; }
		
        public virtual T_Employee t_employeeemployeeinjury { get; set;}
		


		[CustomDisplayName("T_TypeofClaimMCIID","T_EmployeeInjury.resx","Type of Claim MCI"), Column("TypeofClaimMCIID")]
        public Nullable<long> T_TypeofClaimMCIID { get; set; }
		
        public virtual T_ClaimTypeMCI t_typeofclaimmci { get; set;}
		


		[CustomDisplayName("T_AccidentShiftID","T_EmployeeInjury.resx","Shift Working When Accident Occurred"), Column("AccidentShiftID")]
        public Nullable<long> T_AccidentShiftID { get; set; }
		
        public virtual T_ShiftTime t_accidentshift { get; set;}
		


		[CustomDisplayName("T_FacilityAccidentOccuredID","T_EmployeeInjury.resx","Facility Accident Occurred At"), Column("FacilityAccidentOccuredID")]
        public Nullable<long> T_FacilityAccidentOccuredID { get; set; }
		
        public virtual T_AllFacilities t_facilityaccidentoccured { get; set;}
		


		[CustomDisplayName("T_UnitWhereAccidentOccuredID","T_EmployeeInjury.resx","Unit Where Accident Occured"), Column("UnitWhereAccidentOccuredID")]
        public Nullable<long> T_UnitWhereAccidentOccuredID { get; set; }
		
        public virtual T_AllFacilitiesUnit t_unitwhereaccidentoccured { get; set;}
		


		[CustomDisplayName("T_EmployeInjuryFloorID","T_EmployeeInjury.resx","Floor Accident Occurred on"), Column("EmployeInjuryFloorID")]
        public Nullable<long> T_EmployeInjuryFloorID { get; set; }
		
        public virtual T_AllFacilitiesFloor t_employeinjuryfloor { get; set;}
		


		[CustomDisplayName("T_LocationOfAccidentID","T_EmployeeInjury.resx","Location Of Accident"), Column("LocationOfAccidentID")]
        public Nullable<long> T_LocationOfAccidentID { get; set; }
		
        public virtual T_WCAccident t_locationofaccident { get; set;}
		


		[CustomDisplayName("T_EmployeeInjuryCauseID","T_EmployeeInjury.resx","Cause Of Injury "), Column("EmployeeInjuryCauseID")]
        public Nullable<long> T_EmployeeInjuryCauseID { get; set; }
		
        public virtual T_InjuryCause t_employeeinjurycause { get; set;}
		


		[CustomDisplayName("T_EmployeeInjuryNatureID","T_EmployeeInjury.resx","Nature Of Injury Or Illness"), Column("EmployeeInjuryNatureID")]
        public Nullable<long> T_EmployeeInjuryNatureID { get; set; }
		
        public virtual T_InjuryNature t_employeeinjurynature { get; set;}
		


		[CustomDisplayName("T_EmployeeInjuryBodyPartsAffectedID","T_EmployeeInjury.resx","Parts Of Body Affected"), Column("EmployeeInjuryBodyPartsAffectedID")]
        public Nullable<long> T_EmployeeInjuryBodyPartsAffectedID { get; set; }
		
        public virtual T_BodyPartsAffected t_employeeinjurybodypartsaffected { get; set;}
		


		[CustomDisplayName("T_EMployeeInjuryMachineToolID","T_EmployeeInjury.resx","Machine, Tool Or Object Causing Illness Or Injury "), Column("EMployeeInjuryMachineToolID")]
        public Nullable<long> T_EMployeeInjuryMachineToolID { get; set; }
		
        public virtual T_MachineTool t_employeeinjurymachinetool { get; set;}
		


		[CustomDisplayName("T_InitialTreatmentListID","T_EmployeeInjury.resx","Initial Treatment List"), Column("InitialTreatmentListID")]
        public Nullable<long> T_InitialTreatmentListID { get; set; }
		
        public virtual T_InitialTreatment t_initialtreatmentlist { get; set;}
		


		[CustomDisplayName("T_EmployeeInjuryMedicalFacilityForTreatmentID","T_EmployeeInjury.resx","Medical Facility For Treatment"), Column("EmployeeInjuryMedicalFacilityForTreatmentID")]
        public Nullable<long> T_EmployeeInjuryMedicalFacilityForTreatmentID { get; set; }
		
        public virtual T_MedicalFacilityForTreatment t_employeeinjurymedicalfacilityfortreatment { get; set;}
		


		[CustomDisplayName("T_EmployeeInjuryRefusalID","T_EmployeeInjury.resx","Restriction Refusal Reason"), Column("EmployeeInjuryRefusalID")]
        public Nullable<long> T_EmployeeInjuryRefusalID { get; set; }
		
        public virtual T_Refusal t_employeeinjuryrefusal { get; set;}
				
        public virtual ICollection<T_TypeofClaim> T_TypeofClaim_t_employeeinjury { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<T_ClaimType> T_ClaimType_T_TypeofClaim { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedT_ClaimType_T_TypeofClaim { get; set; }
		
        public virtual ICollection<T_TypeOfRestrictions> T_TypeOfRestrictions_t_employeeinjury { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<T_Restrictions> T_Restrictions_T_TypeOfRestrictions { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedT_Restrictions_T_TypeOfRestrictions { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_LeaveProfile> t_injuryrelatedleave { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_injurycomments { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Accommodation> t_accommodationinjury { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_EmployeeEmployeeInjuryID != null ? (new ApplicationContext(new SystemUser())).T_Employees.FirstOrDefault(p=>p.Id == this.T_EmployeeEmployeeInjuryID).DisplayValue + "-" : "")+(this.T_ClaimNo != null ?Convert.ToString(this.T_ClaimNo)+"-" : Convert.ToString(this.T_ClaimNo))+(this.T_AccidentDate != null ?Convert.ToString(this.T_AccidentDate)+"-" : Convert.ToString(this.T_AccidentDate)); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				  var dbT_AccidentDate =this.T_AccidentDate; if (this.m_T_AccidentDate != this.T_AccidentDate) dbT_AccidentDate = TimeZoneInfo.ConvertTimeFromUtc(dbT_AccidentDate, this.m_Timezone);

			var dispValue = (this.t_employeeemployeeinjury != null ?t_employeeemployeeinjury.DisplayValue + "-" : "")+(this.T_ClaimNo != null ?Convert.ToString(this.T_ClaimNo)+"-" : Convert.ToString(this.T_ClaimNo))+(this.T_AccidentDate != null ?Convert.ToString(dbT_AccidentDate)+"-" : ""); 
			return dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			//return m_DisplayValue;
			}catch{ return "";}
					 }
		public void setCalculation(){ try{  }catch{}}
		public void setDateTimeToClientTime() //call this method when you have to update record from code (not from html form). e.g. BulkUpdate
		{
		this.T_AccidentDate =  TimeZoneInfo.ConvertTimeFromUtc(this.T_AccidentDate, this.m_Timezone) ;
		}
		public void setDateTimeToUTC()
        {
            this.T_AccidentDate =  TimeZoneInfo.ConvertTimeToUtc(this.T_AccidentDate, this.m_Timezone) ;
			this.T_RestrictionStartDate = this.T_RestrictionStartDate.HasValue ?  this.T_RestrictionStartDate.Value.Date : this.T_RestrictionStartDate;
			this.T_RestrictionEndDate = this.T_RestrictionEndDate.HasValue ?  this.T_RestrictionEndDate.Value.Date : this.T_RestrictionEndDate;
        }
    }
}

