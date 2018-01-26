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
    [Table("tbl_DrugAlcoholTest"),CustomDisplayName("T_DrugAlcoholTest", "T_DrugAlcoholTest.resx", "Drug & Alcohol Test")]
	public partial class T_DrugAlcoholTest : Entity
    {	
		public T_DrugAlcoholTest()
        {
            this.t_drugalcoholtestcomments = new HashSet<T_Comment>();
        }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_DateOrdered","T_DrugAlcoholTest.resx","Date Of Test"), Column("DateOrdered")] [Required] 
		
        public DateTime T_DateOrdered { get; set; }
				[StringLength(255, ErrorMessage = "Administered By cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_ReviewersInitials","T_DrugAlcoholTest.resx","Administered By"), Column("ReviewersInitials")]  
		
        public string T_ReviewersInitials { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_ResultsReceivedDate","T_DrugAlcoholTest.resx","Results Received Date"), Column("ResultsReceivedDate")]  
		
        public Nullable<DateTime> T_ResultsReceivedDate { get; set; }
		


		 
		 
		[CustomDisplayName("T_Notes","T_DrugAlcoholTest.resx","Notes"), Column("Notes")]  
		
        public string T_Notes { get; set; }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmployeeDrugAlcoholTestID","T_DrugAlcoholTest.resx","Employee"), Column("EmployeeDrugAlcoholTestID")]
        public Nullable<long> T_EmployeeDrugAlcoholTestID { get; set; }
		
        public virtual T_Employee t_employeedrugalcoholtest { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_TypeOfTestID","T_DrugAlcoholTest.resx","Type Of Test"), Column("TypeOfTestID")]
        public Nullable<long> T_TypeOfTestID { get; set; }
		
        public virtual T_TestType t_typeoftest { get; set;}
		


		[CustomDisplayName("T_TestReasonID","T_DrugAlcoholTest.resx","Test Reason"), Column("TestReasonID")]
        public Nullable<long> T_TestReasonID { get; set; }
		
        public virtual T_ReasonForDrugTest t_testreason { get; set;}
		


		[CustomDisplayName("T_DrugTestResultsID","T_DrugAlcoholTest.resx","Test Results"), Column("DrugTestResultsID")]
        public Nullable<long> T_DrugTestResultsID { get; set; }
		
        public virtual T_DrugTestResult t_drugtestresults { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_drugalcoholtestcomments { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_EmployeeDrugAlcoholTestID != null ? (new ApplicationContext(new SystemUser())).T_Employees.FirstOrDefault(p=>p.Id == this.T_EmployeeDrugAlcoholTestID).DisplayValue + "-" : "")+(this.T_TestReasonID != null ? (new ApplicationContext(new SystemUser())).T_ReasonForDrugTests.FirstOrDefault(p=>p.Id == this.T_TestReasonID).DisplayValue + "-" : "")+(this.T_DateOrdered!=null ?this.T_DateOrdered.ToShortDateString()+"-":""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_employeedrugalcoholtest != null ?t_employeedrugalcoholtest.DisplayValue + "-" : "")+(this.t_testreason != null ?t_testreason.DisplayValue + "-" : "")+(this.T_DateOrdered!=null ?this.T_DateOrdered.ToShortDateString()+"-":""); 
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
			this.T_DateOrdered =  this.T_DateOrdered.Date ;
			this.T_ResultsReceivedDate = this.T_ResultsReceivedDate.HasValue ?  this.T_ResultsReceivedDate.Value.Date : this.T_ResultsReceivedDate;
        }
    }
}

