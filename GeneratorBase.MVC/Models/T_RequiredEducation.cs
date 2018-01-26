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
    [Table("tbl_RequiredEducation"),CustomDisplayName("T_RequiredEducation", "T_RequiredEducation.resx", "Required Education")]
	public partial class T_RequiredEducation : Entity
    {	
		


		 
		 
		[CustomDisplayName("T_Description","T_RequiredEducation.resx","Education Details"), Column("Description")]  
		
        public string T_Description { get; set; }



		[CustomDisplayName("T_RoleCodeRequiredEducationID","T_RequiredEducation.resx","Role Code"), Column("RoleCodeRequiredEducationID")]
        public Nullable<long> T_RoleCodeRequiredEducationID { get; set; }
		
        public virtual T_RoleCode t_rolecoderequirededucation { get; set;}
		


		[CustomDisplayName("T_RequiredEducationSOCCodeID","T_RequiredEducation.resx","SOC Code"), Column("RequiredEducationSOCCodeID")]
        public Nullable<long> T_RequiredEducationSOCCodeID { get; set; }
		
        public virtual T_SocCode t_requirededucationsoccode { get; set;}
		


		[CustomDisplayName("T_RequiredEducationEducationLevelID","T_RequiredEducation.resx","Education Level"), Column("RequiredEducationEducationLevelID")]
        public Nullable<long> T_RequiredEducationEducationLevelID { get; set; }
		
        public virtual T_EducationLevel t_requirededucationeducationlevel { get; set;}
				 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Description != null ?Convert.ToString(this.T_Description)+" " : Convert.ToString(this.T_Description)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Description != null ?Convert.ToString(this.T_Description)+" " : Convert.ToString(this.T_Description)); 
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
        }
    }
}

