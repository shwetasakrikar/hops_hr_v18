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
    [Table("tbl_Position"),CustomDisplayName("T_Position", "T_Position.resx", "Position")]
	public partial class T_Position : Entity
    {	
		public T_Position()
        {
            this.t_positionjobassignment = new HashSet<T_JobAssignment>();
        }
				
		[NotMapped]
        public string calc_T_FacilityPositionNumber = null;
		


	 [Unique(typeof(ApplicationContext),ErrorMessage="This position already exists.")]
		 
		 
		[CustomDisplayName("T_FacilityPositionNumber","T_Position.resx","FacilityPositionNumber"), Column("FacilityPositionNumber")]  
		
        public string T_FacilityPositionNumber {  get { return getT_FacilityPositionNumber(); } set { calc_T_FacilityPositionNumber = value;} }
				[StringLength(255, ErrorMessage = "Position Number cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_PositionNumber","T_Position.resx","Position Number"), Column("PositionNumber")] [Required] 
		
        public string T_PositionNumber { get; set; }
		[NotMapped]
        public Nullable<Int32> calc_T_PositionFill = null;
		


		 
		 
		[CustomDisplayName("T_PositionFill","T_Position.resx","Position Fill %"), Column("PositionFill")]  
		
        public Nullable<Int32> T_PositionFill {  get { return getT_PositionFill(); } set { calc_T_PositionFill = value;} }
		


		 
		 
		[CustomDisplayName("T_QuasiFill","T_Position.resx","Quasi Fill"), Column("QuasiFill")]  
		
        public Boolean? T_QuasiFill { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_EffectiveDate","T_Position.resx","Effective Date"), Column("EffectiveDate")]  
		
        public Nullable<DateTime> T_EffectiveDate { get; set; }
				
		

[NotMapped]
		 
		 
		[CustomDisplayName("T_SalaryBand","T_Position.resx","Salary Band"), Column("SalaryBand")]  
		
        public string T_SalaryBand { get {return t_positionrolecode!=null && t_positionrolecode.t_rolecodesalaryband!=null ?t_positionrolecode.t_rolecodesalaryband.T_Name:"";} set { } }
				[StringLength(255, ErrorMessage = "CardApprvr cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_CardApprvr","T_Position.resx","CardApprvr"), Column("CardApprvr")]  
		
        public string T_CardApprvr { get; set; }
		[NotMapped]
        public Nullable<DateTime> m_T_ShiftStart { get; set; }
				
		


		[DataType(DataType.Time)][DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_ShiftStart","T_Position.resx","Shift Start"), Column("ShiftStart")]  
		
        public Nullable<DateTime> T_ShiftStart { get; set; }
		[NotMapped]
        public Nullable<DateTime> m_T_ShiftEnd { get; set; }
				
		


		[DataType(DataType.Time)][DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_ShiftEnd","T_Position.resx","Shift End"), Column("ShiftEnd")]  
		
        public Nullable<DateTime> T_ShiftEnd { get; set; }
		


		 
		 
		[CustomDisplayName("T_DualIncumbent","T_Position.resx","Dual Incumbent"), Column("DualIncumbent")]  
		
        public Boolean? T_DualIncumbent { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_DualIncumbentStartDate","T_Position.resx","Dual Incumbent Start Date"), Column("DualIncumbentStartDate")]  
		
        public Nullable<DateTime> T_DualIncumbentStartDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_DualIncumbentEndDate","T_Position.resx","Dual Incumbent End Date"), Column("DualIncumbentEndDate")]  
		
        public Nullable<DateTime> T_DualIncumbentEndDate { get; set; }
		


		 
		 
		[CustomDisplayName("T_Funded","T_Position.resx","Funded"), Column("Funded")]  
		
        public Boolean? T_Funded { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_EstablishedDate","T_Position.resx","Established Date"), Column("EstablishedDate")] [Required] 
		
        public DateTime T_EstablishedDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_AbolishDate","T_Position.resx","Abolish Date"), Column("AbolishDate")]  
		
        public Nullable<DateTime> T_AbolishDate { get; set; }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_FacilityAssignedToID","T_Position.resx","Facility"), Column("FacilityAssignedToID")]
        public Nullable<long> T_FacilityAssignedToID { get; set; }
		
        public virtual T_Facility t_facilityassignedto { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_TypeOfPositionID","T_Position.resx","Position Type"), Column("TypeOfPositionID")]
        public Nullable<long> T_TypeOfPositionID { get; set; }
		
        public virtual T_PositionType t_typeofposition { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_AssociatedPositionStatusID","T_Position.resx","Position Status"), Column("AssociatedPositionStatusID")]
        public Nullable<long> T_AssociatedPositionStatusID { get; set; }
		
        public virtual T_Positionstatus t_associatedpositionstatus { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_PositionIdentifierID","T_Position.resx","Position Level"), Column("PositionIdentifierID")]
        public Nullable<long> T_PositionIdentifierID { get; set; }
		
        public virtual T_PositionLevel t_positionidentifier { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_PositionWorkingTitleAssociationID","T_Position.resx","Working Title "), Column("PositionWorkingTitleAssociationID")]
        public Nullable<long> T_PositionWorkingTitleAssociationID { get; set; }
		
        public virtual T_WorkingTitle t_positionworkingtitleassociation { get; set;}
		


		[CustomDisplayName("T_PositionRoleCodeID","T_Position.resx","Role Code"), Column("PositionRoleCodeID")]
        public Nullable<long> T_PositionRoleCodeID { get; set; }
		
        public virtual T_RoleCode t_positionrolecode { get; set;}
		


		[CustomDisplayName("T_PositionSOCCodeID","T_Position.resx","SOC Code"), Column("PositionSOCCodeID")]
        public Nullable<long> T_PositionSOCCodeID { get; set; }
		
        public virtual T_SocCode t_positionsoccode { get; set;}
		


		[CustomDisplayName("T_PositionClassCodeID","T_Position.resx","Class Code"), Column("PositionClassCodeID")]
        public Nullable<long> T_PositionClassCodeID { get; set; }
		
        public virtual T_ClassCode t_positionclasscode { get; set;}
		


		[CustomDisplayName("T_WorkersCompCodePositionID","T_Position.resx","WC Code"), Column("WorkersCompCodePositionID")]
        public Nullable<long> T_WorkersCompCodePositionID { get; set; }
		
        public virtual T_WCCode t_workerscompcodeposition { get; set;}
		


		[CustomDisplayName("T_PositionCostCenterAssociationID","T_Position.resx","CardDept"), Column("PositionCostCenterAssociationID")]
        public Nullable<long> T_PositionCostCenterAssociationID { get; set; }
		
        public virtual T_CostCenter t_positioncostcenterassociation { get; set;}
		


		[CustomDisplayName("T_PositionShiftMealTimeID","T_Position.resx","Shift Meal Time"), Column("PositionShiftMealTimeID")]
        public Nullable<long> T_PositionShiftMealTimeID { get; set; }
		
        public virtual T_ShiftMealTime t_positionshiftmealtime { get; set;}
		


		[CustomDisplayName("T_PositionShiftTimeID","T_Position.resx","Shift Time"), Column("PositionShiftTimeID")]
        public Nullable<long> T_PositionShiftTimeID { get; set; }
		
        public virtual T_ShiftTime t_positionshifttime { get; set;}
		


		[CustomDisplayName("T_PositionShiftDurationID","T_Position.resx","Shift Duration"), Column("PositionShiftDurationID")]
        public Nullable<long> T_PositionShiftDurationID { get; set; }
		
        public virtual T_ShiftDuration t_positionshiftduration { get; set;}
		


		[CustomDisplayName("T_PositionOvertimeEligibilityID","T_Position.resx","Overtime Eligibility"), Column("PositionOvertimeEligibilityID")]
        public Nullable<long> T_PositionOvertimeEligibilityID { get; set; }
		
        public virtual T_OvertimeEligibility t_positionovertimeeligibility { get; set;}
		


		[CustomDisplayName("T_PositionStatusforPostingID","T_Position.resx","Position Post Status"), Column("PositionStatusforPostingID")]
        public Nullable<long> T_PositionStatusforPostingID { get; set; }
		
        public virtual T_PositionPostStatus t_positionstatusforposting { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_JobAssignment> t_positionjobassignment { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_PositionNumber != null ?Convert.ToString(this.T_PositionNumber)+"-" : Convert.ToString(this.T_PositionNumber))+(this.T_PositionWorkingTitleAssociationID != null ? (new ApplicationContext(new SystemUser())).T_WorkingTitles.FirstOrDefault(p=>p.Id == this.T_PositionWorkingTitleAssociationID).DisplayValue + "-" : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_PositionNumber != null ?Convert.ToString(this.T_PositionNumber)+"-" : Convert.ToString(this.T_PositionNumber))+(this.t_positionworkingtitleassociation != null ?t_positionworkingtitleassociation.DisplayValue + "-" : ""); 
			return dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			//return m_DisplayValue;
			}catch{ return "";}
					 }
		public void setCalculation(){ try{  var T_FacilityPositionNumber_Value1 = (this.T_FacilityAssignedToID != null ? (new ApplicationContext(new SystemUser())).T_Facilitys.Find(this.T_FacilityAssignedToID).T_FacilityCode :t_facilityassignedto.T_FacilityCode);
 var T_FacilityPositionNumber_Value2 = this.T_PositionNumber;
 this.calc_T_FacilityPositionNumber =  this.T_FacilityPositionNumber =  Convert.ToString(T_FacilityPositionNumber_Value1)+ Convert.ToString(T_FacilityPositionNumber_Value2);
 this.calc_T_PositionFill =  this.T_PositionFill = (new ApplicationContext(new SystemUser())).T_JobAssignments.Where(p => p.T_PositionJobAssignmentID == this.Id && p.T_Active == true).Sum(p => p.T_EmployeePercent);; }catch{}}
		public void setDateTimeToClientTime() //call this method when you have to update record from code (not from html form). e.g. BulkUpdate
		{
		this.T_ShiftStart = this.T_ShiftStart.HasValue ?  TimeZoneInfo.ConvertTimeFromUtc(this.T_ShiftStart.Value, this.m_Timezone) : this.T_ShiftStart;
		this.T_ShiftEnd = this.T_ShiftEnd.HasValue ?  TimeZoneInfo.ConvertTimeFromUtc(this.T_ShiftEnd.Value, this.m_Timezone) : this.T_ShiftEnd;
		}
		public void setDateTimeToUTC()
        {
			this.T_EffectiveDate = this.T_EffectiveDate.HasValue ?  this.T_EffectiveDate.Value.Date : this.T_EffectiveDate;
				this.T_ShiftStart = this.T_ShiftStart.HasValue ?  Convert.ToDateTime("01/01/2000").Date + this.T_ShiftStart.Value.TimeOfDay : this.T_ShiftStart;
            this.T_ShiftStart = this.T_ShiftStart.HasValue ?  TimeZoneInfo.ConvertTimeToUtc(this.T_ShiftStart.Value, this.m_Timezone) : this.T_ShiftStart;
				this.T_ShiftEnd = this.T_ShiftEnd.HasValue ?  Convert.ToDateTime("01/01/2000").Date + this.T_ShiftEnd.Value.TimeOfDay : this.T_ShiftEnd;
            this.T_ShiftEnd = this.T_ShiftEnd.HasValue ?  TimeZoneInfo.ConvertTimeToUtc(this.T_ShiftEnd.Value, this.m_Timezone) : this.T_ShiftEnd;
			this.T_DualIncumbentStartDate = this.T_DualIncumbentStartDate.HasValue ?  this.T_DualIncumbentStartDate.Value.Date : this.T_DualIncumbentStartDate;
			this.T_DualIncumbentEndDate = this.T_DualIncumbentEndDate.HasValue ?  this.T_DualIncumbentEndDate.Value.Date : this.T_DualIncumbentEndDate;
			this.T_EstablishedDate =  this.T_EstablishedDate.Date ;
			this.T_AbolishDate = this.T_AbolishDate.HasValue ?  this.T_AbolishDate.Value.Date : this.T_AbolishDate;
        }
        public string getT_FacilityPositionNumber()
        {
            if (calc_T_FacilityPositionNumber == null)
			{
                var T_FacilityPositionNumber_Value1 = (this.T_FacilityAssignedToID != null ? (new ApplicationContext(new SystemUser())).T_Facilitys.FirstOrDefault(p=>p.Id == this.T_FacilityAssignedToID).T_FacilityCode : new T_Facility().T_FacilityCode);
 var T_FacilityPositionNumber_Value2 = this.T_PositionNumber;
 calc_T_FacilityPositionNumber = Convert.ToString(T_FacilityPositionNumber_Value1)+ Convert.ToString(T_FacilityPositionNumber_Value2);
;
			}
            return calc_T_FacilityPositionNumber;
        }
        public Nullable<Int32> getT_PositionFill()
        {
            if (calc_T_PositionFill == null)
			{
                calc_T_PositionFill = (new ApplicationContext(new SystemUser())).T_JobAssignments.Where(p => p.T_PositionJobAssignmentID == this.Id && p.T_Active == true).Sum(p => p.T_EmployeePercent);;
			}
            return calc_T_PositionFill;
        }
    }
}

