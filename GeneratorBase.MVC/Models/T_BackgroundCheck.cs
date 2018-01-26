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
    [Table("tbl_BackgroundCheck"),CustomDisplayName("T_BackgroundCheck", "T_BackgroundCheck.resx", "Background Check")]
	public partial class T_BackgroundCheck : Entity
    {	
		public T_BackgroundCheck()
        {
            this.t_preemploymentcomments = new HashSet<T_Comment>();
        }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_DateFingerPrintTaken","T_BackgroundCheck.resx","Date Finger Print Taken"), Column("DateFingerPrintTaken")] [Required] 
		
        public DateTime T_DateFingerPrintTaken { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_DateInformationReceivedFromCBC","T_BackgroundCheck.resx","VSP Response Rcvd Date"), Column("DateInformationReceivedFromCBC")]  
		
        public Nullable<DateTime> T_DateInformationReceivedFromCBC { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_BackgroundDispositionDate","T_BackgroundCheck.resx","FBI Record Received Date "), Column("BackgroundDispositionDate")]  
		
        public Nullable<DateTime> T_BackgroundDispositionDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_ReviewDate","T_BackgroundCheck.resx","Review Date"), Column("ReviewDate")]  
		
        public Nullable<DateTime> T_ReviewDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_DateCheckInitiated","T_BackgroundCheck.resx","Date Check Initiated"), Column("DateCheckInitiated")]  
		
        public Nullable<DateTime> T_DateCheckInitiated { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_DateCPSResultReceived","T_BackgroundCheck.resx","Date CPS Result Received"), Column("DateCPSResultReceived")]  
		
        public Nullable<DateTime> T_DateCPSResultReceived { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_CPSReviewDate","T_BackgroundCheck.resx","CPS Review Date"), Column("CPSReviewDate")]  
		
        public Nullable<DateTime> T_CPSReviewDate { get; set; }
		


		 
		 
		[CustomDisplayName("T_Notes","T_BackgroundCheck.resx","Notes"), Column("Notes")]  
		
        public string T_Notes { get; set; }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmployeeCriminalBackgroundCheckID","T_BackgroundCheck.resx","Employee"), Column("EmployeeCriminalBackgroundCheckID")]
        public Nullable<long> T_EmployeeCriminalBackgroundCheckID { get; set; }
		
        public virtual T_Employee t_employeecriminalbackgroundcheck { get; set;}
		


		[CustomDisplayName("T_RetainTablePreEmploymentCheckID","T_BackgroundCheck.resx","Employment Decision"), Column("RetainTablePreEmploymentCheckID")]
        public Nullable<long> T_RetainTablePreEmploymentCheckID { get; set; }
		
        public virtual T_RetainTable t_retaintablepreemploymentcheck { get; set;}
		


		[CustomDisplayName("T_PreEmploymentCheckResultsVAStateID","T_BackgroundCheck.resx","VSP Initial Results"), Column("PreEmploymentCheckResultsVAStateID")]
        public Nullable<long> T_PreEmploymentCheckResultsVAStateID { get; set; }
		
        public virtual T_ResultsTable t_preemploymentcheckresultsvastate { get; set;}
		


		[CustomDisplayName("T_ReviewerID","T_BackgroundCheck.resx","Reviewer "), Column("ReviewerID")]
        public Nullable<long> T_ReviewerID { get; set; }
		
        public virtual T_Employee t_reviewer { get; set;}
		


		[CustomDisplayName("T_CPSResultID","T_BackgroundCheck.resx","CPS Result "), Column("CPSResultID")]
        public Nullable<long> T_CPSResultID { get; set; }
		
        public virtual T_CPSResults t_cpsresult { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_preemploymentcomments { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_EmployeeCriminalBackgroundCheckID != null ? (new ApplicationContext(new SystemUser())).T_Employees.FirstOrDefault(p=>p.Id == this.T_EmployeeCriminalBackgroundCheckID).DisplayValue + "-" : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_employeecriminalbackgroundcheck != null ?t_employeecriminalbackgroundcheck.DisplayValue + "-" : ""); 
			return dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			//return m_DisplayValue;
			}catch{ return "";}
					 }
		public void setCalculation(){ try{  }catch{}}
		public void setDateTimeToClientTime() //call this method when you have to update record from code (not from html form). e.g. BulkUpdate
		{
		}
		public void setDateTimeToUTC()
        {
			this.T_DateFingerPrintTaken =  this.T_DateFingerPrintTaken.Date ;
			this.T_DateInformationReceivedFromCBC = this.T_DateInformationReceivedFromCBC.HasValue ?  this.T_DateInformationReceivedFromCBC.Value.Date : this.T_DateInformationReceivedFromCBC;
			this.T_BackgroundDispositionDate = this.T_BackgroundDispositionDate.HasValue ?  this.T_BackgroundDispositionDate.Value.Date : this.T_BackgroundDispositionDate;
			this.T_ReviewDate = this.T_ReviewDate.HasValue ?  this.T_ReviewDate.Value.Date : this.T_ReviewDate;
			this.T_DateCheckInitiated = this.T_DateCheckInitiated.HasValue ?  this.T_DateCheckInitiated.Value.Date : this.T_DateCheckInitiated;
			this.T_DateCPSResultReceived = this.T_DateCPSResultReceived.HasValue ?  this.T_DateCPSResultReceived.Value.Date : this.T_DateCPSResultReceived;
			this.T_CPSReviewDate = this.T_CPSReviewDate.HasValue ?  this.T_CPSReviewDate.Value.Date : this.T_CPSReviewDate;
        }
    }
}

