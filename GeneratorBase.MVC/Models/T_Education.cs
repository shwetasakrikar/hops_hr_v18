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
    [Table("tbl_Education"),CustomDisplayName("T_Education", "T_Education.resx", "Education")]
	public partial class T_Education : Entity
    {	
		public T_Education()
        {
            this.t_educationcomments = new HashSet<T_Comment>();
        }
		


		 
		 
		[CustomDisplayName("T_DetailsofEducation","T_Education.resx","Details of Education"), Column("DetailsofEducation")]  
		
        public string T_DetailsofEducation { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_DateVerified","T_Education.resx","Date Verified"), Column("DateVerified")]  
		
        public Nullable<DateTime> T_DateVerified { get; set; }
		


		 
		 
		[CustomDisplayName("T_EducationNotes","T_Education.resx","Education Notes"), Column("EducationNotes")]  
		
        public string T_EducationNotes { get; set; }



		[CustomDisplayName("T_EmployeeEducationID","T_Education.resx","Employee"), Column("EmployeeEducationID")]
        public Nullable<long> T_EmployeeEducationID { get; set; }
		
        public virtual T_Employee t_employeeeducation { get; set;}
		


		[CustomDisplayName("T_LevelOfEducationID","T_Education.resx","Level Of Education"), Column("LevelOfEducationID")]
        public Nullable<long> T_LevelOfEducationID { get; set; }
		
        public virtual T_EducationLevel t_levelofeducation { get; set;}
		


		[CustomDisplayName("T_MajorInMultiCheckBoxID","T_Education.resx","Major In"), Column("MajorInMultiCheckBoxID")]
        public Nullable<long> T_MajorInMultiCheckBoxID { get; set; }
		
        public virtual T_Major t_majorinmulticheckbox { get; set;}
		


		[CustomDisplayName("T_EducationVerificationVendorID","T_Education.resx","Education Verification Vendor"), Column("EducationVerificationVendorID")]
        public Nullable<long> T_EducationVerificationVendorID { get; set; }
		
        public virtual T_Vendor t_educationverificationvendor { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_educationcomments { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_EmployeeEducationID != null ? (new ApplicationContext(new SystemUser())).T_Employees.FirstOrDefault(p=>p.Id == this.T_EmployeeEducationID).DisplayValue + "-" : "")+(this.T_LevelOfEducationID != null ? (new ApplicationContext(new SystemUser())).T_EducationLevels.FirstOrDefault(p=>p.Id == this.T_LevelOfEducationID).DisplayValue + " " : "")+(this.T_MajorInMultiCheckBoxID != null ? (new ApplicationContext(new SystemUser())).T_Majors.FirstOrDefault(p=>p.Id == this.T_MajorInMultiCheckBoxID).DisplayValue + " " : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_employeeeducation != null ?t_employeeeducation.DisplayValue + "-" : "")+(this.t_levelofeducation != null ?t_levelofeducation.DisplayValue + " " : "")+(this.t_majorinmulticheckbox != null ?t_majorinmulticheckbox.DisplayValue + " " : ""); 
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
			this.T_DateVerified = this.T_DateVerified.HasValue ?  this.T_DateVerified.Value.Date : this.T_DateVerified;
        }
    }
}

