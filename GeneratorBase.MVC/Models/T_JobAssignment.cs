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
    [Table("tbl_JobAssignment"),CustomDisplayName("T_JobAssignment", "T_JobAssignment.resx", "Job Assignment")]
	public partial class T_JobAssignment : Entity
    {	
		public T_JobAssignment()
        {
            this.t_jobassignmentcomments = new HashSet<T_Comment>();
            this.t_paydetailsjobassignment = new HashSet<T_PayDetails>();
        }
		


		 
		 
		[CustomDisplayName("T_EmployeePercent","T_JobAssignment.resx","Employee Percent (%)"), Column("EmployeePercent")]  
		
        public Nullable<Int32> T_EmployeePercent { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_StartDate","T_JobAssignment.resx","Start Date"), Column("StartDate")] [Required] 
		
        public DateTime T_StartDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_EndDate","T_JobAssignment.resx","End Date"), Column("EndDate")]  
		
        public Nullable<DateTime> T_EndDate { get; set; }
		


		 
		 
		[CustomDisplayName("T_Primary","T_JobAssignment.resx","Primary"), Column("Primary")]  
		
        public Boolean? T_Primary { get; set; }
		


		 
		 
		[CustomDisplayName("T_Active","T_JobAssignment.resx","Active"), Column("Active")]  
		
        public Boolean? T_Active { get; set; }
				
		


		 
		 
		[CustomDisplayName("T_PositionLevel","T_JobAssignment.resx","Position Level"), Column("PositionLevel")]  
		
        public string T_PositionLevel { get; set; }
				
		


		 
		 
		[CustomDisplayName("T_RoleCode","T_JobAssignment.resx","Role Code "), Column("RoleCode")]  
		
        public string T_RoleCode { get; set; }
				
		


		 
		 
		[CustomDisplayName("T_ClassCode","T_JobAssignment.resx","Class Code "), Column("ClassCode")]  
		
        public string T_ClassCode { get; set; }
				
		


		 
		 
		[CustomDisplayName("T_WorkersCompCode","T_JobAssignment.resx","Workers Comp Code"), Column("WorkersCompCode")]  
		
        public string T_WorkersCompCode { get; set; }
				
		


		 
		 
		[CustomDisplayName("T_SOCCode","T_JobAssignment.resx","SOC Code"), Column("SOCCode")]  
		
        public string T_SOCCode { get; set; }
				
		

[NotMapped]
		 
		 
		[CustomDisplayName("T_OvertimeEligibility","T_JobAssignment.resx","Overtime Eligibility"), Column("OvertimeEligibility")]  
		
        public string T_OvertimeEligibility { get {return t_positionjobassignment!=null && t_positionjobassignment.t_positionovertimeeligibility!=null ?t_positionjobassignment.t_positionovertimeeligibility.DisplayValue:"";} set { } }
				
		

[NotMapped]
		 
		 
		[CustomDisplayName("T_CostCenter","T_JobAssignment.resx","Cost Center"), Column("CostCenter")]  
		
        public string T_CostCenter { get {return t_jobassignmentunitx!=null && t_jobassignmentunitx.t_wardcostcenter!=null ?t_jobassignmentunitx.t_wardcostcenter.DisplayValue:"";} set { } }
				
		

[NotMapped]
		 
		 
		[CustomDisplayName("T_Program","T_JobAssignment.resx","Program"), Column("Program")]  
		
        public string T_Program { get {return t_jobassignmentunitx!=null ?t_jobassignmentunitx.T_Program:"";} set { } }
				
		

[NotMapped]
		 
		 
		[CustomDisplayName("T_DepartmentArea","T_JobAssignment.resx","Department Area"), Column("DepartmentArea")]  
		
        public string T_DepartmentArea { get {return t_jobassignmentunitx!=null && t_jobassignmentunitx.t_unitxdepartmentarea!=null ?t_jobassignmentunitx.t_unitxdepartmentarea.DisplayValue:"";} set { } }
				
		


		 
		 
		[CustomDisplayName("T_Department","T_JobAssignment.resx","Department"), Column("Department")]  
		
        public string T_Department { get; set; }
				
		

[NotMapped]
		 
		 
		[CustomDisplayName("T_SupervisorEmail","T_JobAssignment.resx","Supervisor Email"), Column("SupervisorEmail")]  
		
        public string T_SupervisorEmail { get {return t_employeesupervisor!=null ?t_employeesupervisor.T_WorkEmail:"";} set { } }
		


		 
		 
		[CustomDisplayName("T_Notes","T_JobAssignment.resx","Notes"), Column("Notes")]  
		
        public string T_Notes { get; set; }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmployeeJobAssignmentID","T_JobAssignment.resx","Employee"), Column("EmployeeJobAssignmentID")]
        public Nullable<long> T_EmployeeJobAssignmentID { get; set; }
		
        public virtual T_Employee t_employeejobassignment { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_PositionJobAssignmentID","T_JobAssignment.resx","Position Number"), Column("PositionJobAssignmentID")]
        public Nullable<long> T_PositionJobAssignmentID { get; set; }
		
        public virtual T_Position t_positionjobassignment { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_JobAssignmentReasonID","T_JobAssignment.resx","Job Assignment Reason"), Column("JobAssignmentReasonID")]
        public Nullable<long> T_JobAssignmentReasonID { get; set; }
		
        public virtual T_ReasonforHire t_jobassignmentreason { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_JobAssignmentUnitXID","T_JobAssignment.resx","UnitX"), Column("JobAssignmentUnitXID")]
        public Nullable<long> T_JobAssignmentUnitXID { get; set; }
		
        public virtual T_UnitX t_jobassignmentunitx { get; set;}
		


		[CustomDisplayName("T_JobAssignmentManagerEmployeeID","T_JobAssignment.resx","Manager"), Column("JobAssignmentManagerEmployeeID")]
        public Nullable<long> T_JobAssignmentManagerEmployeeID { get; set; }
		
        public virtual T_Employee t_jobassignmentmanageremployee { get; set;}
		


		[CustomDisplayName("T_EmployeeSupervisorID","T_JobAssignment.resx","Supervisor"), Column("EmployeeSupervisorID")]
        public Nullable<long> T_EmployeeSupervisorID { get; set; }
		
        public virtual T_Employee t_employeesupervisor { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_jobassignmentcomments { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_PayDetails> t_paydetailsjobassignment { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_EmployeeJobAssignmentID != null ? (new ApplicationContext(new SystemUser())).T_Employees.FirstOrDefault(p=>p.Id == this.T_EmployeeJobAssignmentID).DisplayValue + "-" : "")+(this.T_PositionJobAssignmentID != null ? (new ApplicationContext(new SystemUser())).T_Positions.FirstOrDefault(p=>p.Id == this.T_PositionJobAssignmentID).DisplayValue + "-" : "")+(this.T_JobAssignmentUnitXID != null ? (new ApplicationContext(new SystemUser())).T_UnitXs.FirstOrDefault(p=>p.Id == this.T_JobAssignmentUnitXID).DisplayValue + " " : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_employeejobassignment != null ?t_employeejobassignment.DisplayValue + "-" : "")+(this.t_positionjobassignment != null ?t_positionjobassignment.DisplayValue + "-" : "")+(this.t_jobassignmentunitx != null ?t_jobassignmentunitx.DisplayValue + " " : ""); 
			return dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
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

