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
    [Table("tbl_ServiceRecord"),CustomDisplayName("T_ServiceRecord", "T_ServiceRecord.resx", "Service Record")]
	public partial class T_ServiceRecord : Entity
    {	
		public T_ServiceRecord()
        {
            this.t_servicerecordcomments = new HashSet<T_Comment>();
        }
		


		 
		 
		[CustomDisplayName("T_IsCurrent","T_ServiceRecord.resx","Current Active Service Record"), Column("IsCurrent")]  
		
        public Boolean? T_IsCurrent { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_HireDate","T_ServiceRecord.resx","Hire Date"), Column("HireDate")] [Required] 
		
        public DateTime T_HireDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_TerminationDate","T_ServiceRecord.resx","Separation Date"), Column("TerminationDate")]  
		
        public Nullable<DateTime> T_TerminationDate { get; set; }
		[NotMapped]
        public Nullable<DateTime> m_T_ThreeMonthDue { get; set; }
				
		[NotMapped]
        public Nullable<DateTime> calc_T_ThreeMonthDue = null;
		


		[DataType(DataType.Time)][DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_ThreeMonthDue","T_ServiceRecord.resx","Three Month Due"), Column("ThreeMonthDue")]  
		
        public Nullable<DateTime> T_ThreeMonthDue {  get { return getT_ThreeMonthDue(); } set { calc_T_ThreeMonthDue = value;} }
		


		 
		 
		[CustomDisplayName("T_ThreeMonthReviewCompleted","T_ServiceRecord.resx","Three Month Review Completed"), Column("ThreeMonthReviewCompleted")]  
		
        public Boolean? T_ThreeMonthReviewCompleted { get; set; }
		[NotMapped]
        public Nullable<DateTime> m_T_SixMonthDue { get; set; }
				
		[NotMapped]
        public Nullable<DateTime> calc_T_SixMonthDue = null;
		


		[DataType(DataType.Time)][DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_SixMonthDue","T_ServiceRecord.resx","Six Month Due "), Column("SixMonthDue")]  
		
        public Nullable<DateTime> T_SixMonthDue {  get { return getT_SixMonthDue(); } set { calc_T_SixMonthDue = value;} }
		


		 
		 
		[CustomDisplayName("T_SixMonthReviewCompleted","T_ServiceRecord.resx","Six Month Review Completed"), Column("SixMonthReviewCompleted")]  
		
        public Boolean? T_SixMonthReviewCompleted { get; set; }
		[NotMapped]
        public Nullable<DateTime> m_T_TwelveMonthDue { get; set; }
				
		[NotMapped]
        public Nullable<DateTime> calc_T_TwelveMonthDue = null;
		


		[DataType(DataType.Time)][DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_TwelveMonthDue","T_ServiceRecord.resx","Twelve Month Due"), Column("TwelveMonthDue")]  
		
        public Nullable<DateTime> T_TwelveMonthDue {  get { return getT_TwelveMonthDue(); } set { calc_T_TwelveMonthDue = value;} }
		


		 
		 
		[CustomDisplayName("T_TwelveMonthReviewCompleted","T_ServiceRecord.resx","Twelve Month Review Completed"), Column("TwelveMonthReviewCompleted")]  
		
        public Boolean? T_TwelveMonthReviewCompleted { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_ProbationaryExtensionDate","T_ServiceRecord.resx","Probationary Extension Date"), Column("ProbationaryExtensionDate")]  
		
        public Nullable<DateTime> T_ProbationaryExtensionDate { get; set; }
		


		 
		 
		[CustomDisplayName("T_ExtensionReviewCompleted","T_ServiceRecord.resx","Extension Review Completed"), Column("ExtensionReviewCompleted")]  
		
        public Boolean? T_ExtensionReviewCompleted { get; set; }
		


		 
		 
		[CustomDisplayName("T_TwoWeekNoticeGiven","T_ServiceRecord.resx","Two Week Notice Given"), Column("TwoWeekNoticeGiven")]  
		
        public Boolean? T_TwoWeekNoticeGiven { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_NoticeGivenDate","T_ServiceRecord.resx","Notice Given Date"), Column("NoticeGivenDate")]  
		
        public Nullable<DateTime> T_NoticeGivenDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_ThirtyDaysSinceTermination","T_ServiceRecord.resx","Thirty Days Since Separation"), Column("ThirtyDaysSinceTermination")]  
		
        public Nullable<DateTime> T_ThirtyDaysSinceTermination { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_ThirteenWeeksSinceTermination","T_ServiceRecord.resx","Thirteen Weeks Since Separation"), Column("ThirteenWeeksSinceTermination")]  
		
        public Nullable<DateTime> T_ThirteenWeeksSinceTermination { get; set; }
		


		 
		 
		[CustomDisplayName("T_EligibleForRehire","T_ServiceRecord.resx","Not Eligible For Rehire"), Column("EligibleForRehire")]  
		
        public Boolean? T_EligibleForRehire { get; set; }
		


		 
		 
		[CustomDisplayName("T_ProbationNotes","T_ServiceRecord.resx","Probation Notes"), Column("ProbationNotes")]  
		
        public string T_ProbationNotes { get; set; }
		


		 
		 
		[CustomDisplayName("T_TerminationNotes","T_ServiceRecord.resx","Separation Notes"), Column("TerminationNotes")]  
		
        public string T_TerminationNotes { get; set; }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmployeeEmploymentProfileID","T_ServiceRecord.resx","Employee"), Column("EmployeeEmploymentProfileID")]
        public Nullable<long> T_EmployeeEmploymentProfileID { get; set; }
		
        public virtual T_Employee t_employeeemploymentprofile { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmploymentRecordEmployeeTypeID","T_ServiceRecord.resx","Employee Type"), Column("EmploymentRecordEmployeeTypeID")]
        public Nullable<long> T_EmploymentRecordEmployeeTypeID { get; set; }
		
        public virtual T_EmployeeType t_employmentrecordemployeetype { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmploymentRecordHiredAtFacilityID","T_ServiceRecord.resx","Hired At Facility"), Column("EmploymentRecordHiredAtFacilityID")]
        public Nullable<long> T_EmploymentRecordHiredAtFacilityID { get; set; }
		
        public virtual T_AllFacilities t_employmentrecordhiredatfacility { get; set;}
		


		[CustomDisplayName("T_EmployeeTerminationReasonID","T_ServiceRecord.resx","Separation Reason"), Column("EmployeeTerminationReasonID")]
        public Nullable<long> T_EmployeeTerminationReasonID { get; set; }
		
        public virtual T_TerminationReason t_employeeterminationreason { get; set;}
		


		[CustomDisplayName("T_EmployeeRecordTerminationFacilityID","T_ServiceRecord.resx","After Termination Joined Facility"), Column("EmployeeRecordTerminationFacilityID")]
        public Nullable<long> T_EmployeeRecordTerminationFacilityID { get; set; }
		
        public virtual T_AllFacilities t_employeerecordterminationfacility { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_servicerecordcomments { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_EmployeeEmploymentProfileID != null ? (new ApplicationContext(new SystemUser())).T_Employees.FirstOrDefault(p=>p.Id == this.T_EmployeeEmploymentProfileID).DisplayValue + "-" : "")+(this.T_EmploymentRecordHiredAtFacilityID != null ? (new ApplicationContext(new SystemUser())).T_AllFacilitiess.FirstOrDefault(p=>p.Id == this.T_EmploymentRecordHiredAtFacilityID).DisplayValue + "-" : "")+(this.T_HireDate!=null ?this.T_HireDate.ToShortDateString()+"-":""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_employeeemploymentprofile != null ?t_employeeemploymentprofile.DisplayValue + "-" : "")+(this.t_employmentrecordhiredatfacility != null ?t_employmentrecordhiredatfacility.DisplayValue + "-" : "")+(this.T_HireDate!=null ?this.T_HireDate.ToShortDateString()+"-":""); 
			return dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			//return m_DisplayValue;
			}catch{ return "";}
					 }
		public void setCalculation(){ try{  this.calc_T_ThreeMonthDue =  this.calc_T_ThreeMonthDue =  this.T_ThreeMonthDue = (T_HireDate.AddMonths(Convert.ToInt32(3)));
 this.calc_T_SixMonthDue =  this.calc_T_SixMonthDue =  this.T_SixMonthDue = (T_HireDate.AddMonths(Convert.ToInt32(6)));
 this.calc_T_TwelveMonthDue =  this.calc_T_TwelveMonthDue =  this.T_TwelveMonthDue = (T_HireDate.AddMonths(Convert.ToInt32(12)));
 }catch{}}
		public void setDateTimeToClientTime() //call this method when you have to update record from code (not from html form). e.g. BulkUpdate
		{
		}
		public void setDateTimeToUTC()
        {
			this.T_HireDate =  this.T_HireDate.Date ;
			this.T_TerminationDate = this.T_TerminationDate.HasValue ?  this.T_TerminationDate.Value.Date : this.T_TerminationDate;
			this.T_ProbationaryExtensionDate = this.T_ProbationaryExtensionDate.HasValue ?  this.T_ProbationaryExtensionDate.Value.Date : this.T_ProbationaryExtensionDate;
			this.T_NoticeGivenDate = this.T_NoticeGivenDate.HasValue ?  this.T_NoticeGivenDate.Value.Date : this.T_NoticeGivenDate;
			this.T_ThirtyDaysSinceTermination = this.T_ThirtyDaysSinceTermination.HasValue ?  this.T_ThirtyDaysSinceTermination.Value.Date : this.T_ThirtyDaysSinceTermination;
			this.T_ThirteenWeeksSinceTermination = this.T_ThirteenWeeksSinceTermination.HasValue ?  this.T_ThirteenWeeksSinceTermination.Value.Date : this.T_ThirteenWeeksSinceTermination;
        }
        public Nullable<DateTime> getT_ThreeMonthDue()
        {
            if (calc_T_ThreeMonthDue == null)
			{
                if (T_HireDate!= null)
 calc_T_ThreeMonthDue = (T_HireDate.AddMonths(Convert.ToInt32(3)));
else
 calc_T_ThreeMonthDue = null;;
			}
            return calc_T_ThreeMonthDue;
        }
        public Nullable<DateTime> getT_SixMonthDue()
        {
            if (calc_T_SixMonthDue == null)
			{
                if (T_HireDate!= null)
 calc_T_SixMonthDue = (T_HireDate.AddMonths(Convert.ToInt32(6)));
else
 calc_T_SixMonthDue = null;;
			}
            return calc_T_SixMonthDue;
        }
        public Nullable<DateTime> getT_TwelveMonthDue()
        {
            if (calc_T_TwelveMonthDue == null)
			{
                if (T_HireDate!= null)
 calc_T_TwelveMonthDue = (T_HireDate.AddMonths(Convert.ToInt32(12)));
else
 calc_T_TwelveMonthDue = null;;
			}
            return calc_T_TwelveMonthDue;
        }
    }
}

