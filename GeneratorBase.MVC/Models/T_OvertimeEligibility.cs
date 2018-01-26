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
    [Table("tbl_OvertimeEligibility"),CustomDisplayName("T_OvertimeEligibility", "T_OvertimeEligibility.resx", "Overtime Eligibility")]
	public partial class T_OvertimeEligibility : Entity
    {	
		public T_OvertimeEligibility()
        {
            this.t_positionovertimeeligibility = new HashSet<T_Position>();
        }
				[StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_OvertimeEligibility.resx","Name"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }
				[StringLength(255, ErrorMessage = "Description cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Description","T_OvertimeEligibility.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Position> t_positionovertimeeligibility { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+" " : Convert.ToString(this.T_Name)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+" " : Convert.ToString(this.T_Name)); 
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

