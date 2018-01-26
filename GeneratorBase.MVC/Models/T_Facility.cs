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
    [Table("tbl_Facility"),CustomDisplayName("T_Facility", "T_Facility.resx", "Facility")]
	public partial class T_Facility : Entity
    {	
		public T_Facility()
        {
            this.t_facilityunit = new HashSet<T_Unit>();
            this.T_FacilityUser_t_facility = new HashSet<T_FacilityUser>();
            this.t_facilitysalaryrangeassociation = new HashSet<T_SalaryRange>();
            this.t_departmentfacilityassociation = new HashSet<T_Department>();
            this.t_departmentareaemployeetypeassociation = new HashSet<T_DepartmentArea>();
            this.t_claimtypefacilityassociation = new HashSet<T_ClaimType>();
            this.t_restrictionsfacilityassociation = new HashSet<T_Restrictions>();
            this.t_tenantconfigurationassociation = new HashSet<T_FacilityConfiguration>();
            this.t_facilityunitx = new HashSet<T_UnitX>();
            this.t_facilityassignedto = new HashSet<T_Position>();
            this.t_employeeatfacility = new HashSet<T_Employee>();
        }
				[StringLength(255, ErrorMessage = "Facility Code cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_FacilityCode","T_Facility.resx","Facility Code"), Column("FacilityCode")] [Required] 
		
        public string T_FacilityCode { get; set; }
		


		 
		 
		[CustomDisplayName("T_WorkingHours","T_Facility.resx","Working Hours"), Column("WorkingHours")]  
		
        public string T_WorkingHours { get; set; }
		


		 
		 
		[CustomDisplayName("T_FacilityName","T_Facility.resx","Facility Name"), Column("FacilityName")]  
		
        public string T_FacilityName { get; set; }



		[CustomDisplayName("T_FacilityAddressID","T_Facility.resx","Address"), Column("FacilityAddressID")]
        public Nullable<long> T_FacilityAddressID { get; set; }
		
        public virtual T_Address t_facilityaddress { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Unit> t_facilityunit { get; set; }
		
        public virtual ICollection<T_FacilityUser> T_FacilityUser_t_facility { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<ApplicationUser> ApplicationUser_T_FacilityUser { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedApplicationUser_T_FacilityUser { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_SalaryRange> t_facilitysalaryrangeassociation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Department> t_departmentfacilityassociation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_DepartmentArea> t_departmentareaemployeetypeassociation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_ClaimType> t_claimtypefacilityassociation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Restrictions> t_restrictionsfacilityassociation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_FacilityConfiguration> t_tenantconfigurationassociation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_UnitX> t_facilityunitx { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Position> t_facilityassignedto { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Employee> t_employeeatfacility { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_FacilityCode != null ?Convert.ToString(this.T_FacilityCode)+" " : Convert.ToString(this.T_FacilityCode))+(this.T_FacilityName != null ?Convert.ToString(this.T_FacilityName)+"-" : Convert.ToString(this.T_FacilityName)); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_FacilityCode != null ?Convert.ToString(this.T_FacilityCode)+" " : Convert.ToString(this.T_FacilityCode))+(this.T_FacilityName != null ?Convert.ToString(this.T_FacilityName)+"-" : Convert.ToString(this.T_FacilityName)); 
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
        }
    }
}

