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
    [Table("tbl_PayDetails"),CustomDisplayName("T_PayDetails", "T_PayDetails.resx", "Pay Details ")]
	public partial class T_PayDetails : Entity
    {	
		public T_PayDetails()
        {
            this.t_salarycomments = new HashSet<T_Comment>();
        }
		


		[DataType(DataType.Currency)] 
		 
		[CustomDisplayName("T_Amount","T_PayDetails.resx","Amount"), Column("Amount")] [Required] 
		
        public Decimal T_Amount { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_StartDate","T_PayDetails.resx","Start Date"), Column("StartDate")] [Required] 
		
        public DateTime T_StartDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_EndDate","T_PayDetails.resx","End Date"), Column("EndDate")]  
		
        public Nullable<DateTime> T_EndDate { get; set; }
		


		 
		 
		[CustomDisplayName("T_Notes","T_PayDetails.resx","Notes"), Column("Notes")]  
		
        public string T_Notes { get; set; }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmployeePayDetailsID","T_PayDetails.resx","Employee"), Column("EmployeePayDetailsID")]
        public Nullable<long> T_EmployeePayDetailsID { get; set; }
		
        public virtual T_Employee t_employeepaydetails { get; set;}
		


		[CustomDisplayName("T_PayDetailsJobAssignmentID","T_PayDetails.resx","Job Assignment"), Column("PayDetailsJobAssignmentID")]
        public Nullable<long> T_PayDetailsJobAssignmentID { get; set; }
		
        public virtual T_JobAssignment t_paydetailsjobassignment { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_OtherPayDetailsTypeID","T_PayDetails.resx","Pay Type"), Column("OtherPayDetailsTypeID")]
        public Nullable<long> T_OtherPayDetailsTypeID { get; set; }
		
        public virtual T_PayType t_otherpaydetailstype { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_salarycomments { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_EmployeePayDetailsID != null ? (new ApplicationContext(new SystemUser())).T_Employees.FirstOrDefault(p=>p.Id == this.T_EmployeePayDetailsID).DisplayValue + "-" : "")+(this.T_OtherPayDetailsTypeID != null ? (new ApplicationContext(new SystemUser())).T_PayTypes.FirstOrDefault(p=>p.Id == this.T_OtherPayDetailsTypeID).DisplayValue + "-" : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_employeepaydetails != null ?t_employeepaydetails.DisplayValue + "-" : "")+(this.t_otherpaydetailstype != null ?t_otherpaydetailstype.DisplayValue + "-" : ""); 
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
			this.T_StartDate =  this.T_StartDate.Date ;
			this.T_EndDate = this.T_EndDate.HasValue ?  this.T_EndDate.Value.Date : this.T_EndDate;
        }
    }
}

