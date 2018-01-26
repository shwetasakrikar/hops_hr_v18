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
    [Table("tbl_UnitX"),CustomDisplayName("T_UnitX", "T_UnitX.resx", "UnitX")]
	public partial class T_UnitX : Entity
    {	
		public T_UnitX()
        {
            this.t_jobassignmentunitx = new HashSet<T_JobAssignment>();
        }
				[StringLength(255, ErrorMessage = "Unit cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Unit","T_UnitX.resx","Unit"), Column("Unit")] [Required] 
		
        public string T_Unit { get; set; }
            
           [RegularExpression(@"^\d{3}\-?\d{3}\-?\d{4}$", ErrorMessage = "Invalid Unit Phone Number")]
		


		 
		 
		[CustomDisplayName("T_UnitPhoneNumber","T_UnitX.resx","Unit Phone Number"), Column("UnitPhoneNumber")]  
		
        public string T_UnitPhoneNumber { get; set; }
				[StringLength(255, ErrorMessage = "Mail Distributor cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_MailDistributor","T_UnitX.resx","Mail Distributor"), Column("MailDistributor")]  
		
        public string T_MailDistributor { get; set; }
		


		 
		 
		[CustomDisplayName("T_MaleBeds","T_UnitX.resx","Male Beds"), Column("MaleBeds")]  
		
        public Nullable<Int32> T_MaleBeds { get; set; }
		


		 
		 
		[CustomDisplayName("T_FemaleBeds","T_UnitX.resx","Female Beds"), Column("FemaleBeds")]  
		
        public Nullable<Int32> T_FemaleBeds { get; set; }
		[NotMapped]
        public Nullable<Int32> calc_T_TotalBeds = null;
		


		 
		 
		[CustomDisplayName("T_TotalBeds","T_UnitX.resx","Total Beds"), Column("TotalBeds")]  
		
        public Nullable<Int32> T_TotalBeds {  get { return getT_TotalBeds(); } set { calc_T_TotalBeds = value;} }
				
		

[NotMapped]
		 
		 
		[CustomDisplayName("T_Program","T_UnitX.resx","Program"), Column("Program")]  
		
        public string T_Program { get {return t_wardcostcenter!=null && t_wardcostcenter.t_costprogram!=null ?t_wardcostcenter.t_costprogram.DisplayValue:"";} set { } }
				
		

[NotMapped]
		 
		 
		[CustomDisplayName("T_Fund","T_UnitX.resx","Fund "), Column("Fund")]  
		
        public string T_Fund { get {return t_wardcostcenter!=null && t_wardcostcenter.t_costfund!=null ?t_wardcostcenter.t_costfund.DisplayValue:"";} set { } }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_FacilityUnitXID","T_UnitX.resx","Facility"), Column("FacilityUnitXID")]
        public Nullable<long> T_FacilityUnitXID { get; set; }
		
        public virtual T_Facility t_facilityunitx { get; set;}
		


		[CustomDisplayName("T_UnitXUnitAssociationID","T_UnitX.resx","Unit Name"), Column("UnitXUnitAssociationID")]
        public Nullable<long> T_UnitXUnitAssociationID { get; set; }
		
        public virtual T_Unit t_unitxunitassociation { get; set;}
		


		[CustomDisplayName("T_WardDepartmentID","T_UnitX.resx","Department"), Column("WardDepartmentID")]
        public Nullable<long> T_WardDepartmentID { get; set; }
		
        public virtual T_Department t_warddepartment { get; set;}
		


		[CustomDisplayName("T_UnitXDepartmentAreaID","T_UnitX.resx","Department Area"), Column("UnitXDepartmentAreaID")]
        public Nullable<long> T_UnitXDepartmentAreaID { get; set; }
		
        public virtual T_DepartmentArea t_unitxdepartmentarea { get; set;}
		


		[CustomDisplayName("T_WardOrgCodeID","T_UnitX.resx","Org Code"), Column("WardOrgCodeID")]
        public Nullable<long> T_WardOrgCodeID { get; set; }
		
        public virtual T_OrgCodes t_wardorgcode { get; set;}
		


		[CustomDisplayName("T_UnitXFloorID","T_UnitX.resx","Floor"), Column("UnitXFloorID")]
        public Nullable<long> T_UnitXFloorID { get; set; }
		
        public virtual T_Floor t_unitxfloor { get; set;}
		


		[CustomDisplayName("T_EmployeeAdministratorID","T_UnitX.resx","Administrator"), Column("EmployeeAdministratorID")]
        public Nullable<long> T_EmployeeAdministratorID { get; set; }
		
        public virtual T_Employee t_employeeadministrator { get; set;}
		


		[CustomDisplayName("T_EmployeeUnitXHeadID","T_UnitX.resx","Head"), Column("EmployeeUnitXHeadID")]
        public Nullable<long> T_EmployeeUnitXHeadID { get; set; }
		
        public virtual T_Employee t_employeeunitxhead { get; set;}
		


		[CustomDisplayName("T_WardCostCenterID","T_UnitX.resx","Cost Center"), Column("WardCostCenterID")]
        public Nullable<long> T_WardCostCenterID { get; set; }
		
        public virtual T_CostCenter t_wardcostcenter { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_JobAssignment> t_jobassignmentunitx { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Unit != null ?Convert.ToString(this.T_Unit)+" " : Convert.ToString(this.T_Unit)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Unit != null ?Convert.ToString(this.T_Unit)+" " : Convert.ToString(this.T_Unit)); 
			return dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			//return m_DisplayValue;
			}catch{ return "";}
					 }
		public void setCalculation(){ try{  var T_TotalBeds_Value1 = this.T_MaleBeds;
 var T_TotalBeds_Value2 = this.T_FemaleBeds;
 this.calc_T_TotalBeds =  this.T_TotalBeds = T_TotalBeds_Value1+T_TotalBeds_Value2 ;
 }catch{}}
		public void setDateTimeToClientTime() //call this method when you have to update record from code (not from html form). e.g. BulkUpdate
		{
		}
		public void setDateTimeToUTC()
        {
        }
        public Nullable<Int32> getT_TotalBeds()
        {
            if (calc_T_TotalBeds == null)
			{
                var T_TotalBeds_Value1 = this.T_MaleBeds;
 var T_TotalBeds_Value2 = this.T_FemaleBeds;
 calc_T_TotalBeds = T_TotalBeds_Value1+T_TotalBeds_Value2 ;
;
			}
            return calc_T_TotalBeds;
        }
    }
}

