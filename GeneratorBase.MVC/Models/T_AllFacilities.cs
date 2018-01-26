﻿using System;
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
    [Table("tbl_AllFacilities"),CustomDisplayName("T_AllFacilities", "T_AllFacilities.resx", "All Facilities")]
	public partial class T_AllFacilities : Entity
    {	
		public T_AllFacilities()
        {
            this.t_unitsforallfacilties = new HashSet<T_AllFacilitiesUnit>();
            this.t_employmentrecordhiredatfacility = new HashSet<T_ServiceRecord>();
            this.t_employeerecordterminationfacility = new HashSet<T_ServiceRecord>();
            this.t_facilityaccidentoccured = new HashSet<T_EmployeeInjury>();
        }
				[StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_AllFacilities.resx","Name"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }
		


		 
		 
		[CustomDisplayName("T_Description","T_AllFacilities.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_AllFacilitiesUnit> t_unitsforallfacilties { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_ServiceRecord> t_employmentrecordhiredatfacility { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_ServiceRecord> t_employeerecordterminationfacility { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_EmployeeInjury> t_facilityaccidentoccured { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+" " : Convert.ToString(this.T_Name))+(this.T_Description != null ?Convert.ToString(this.T_Description)+"-" : Convert.ToString(this.T_Description)); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+" " : Convert.ToString(this.T_Name))+(this.T_Description != null ?Convert.ToString(this.T_Description)+"-" : Convert.ToString(this.T_Description)); 
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

