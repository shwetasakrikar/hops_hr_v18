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
    [Table("tbl_Patient"),CustomDisplayName("T_Patient", "T_Patient.resx", "Patient")]
	public partial class T_Patient : Entity
    {	
				[StringLength(255, ErrorMessage = "Register Number cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_RegisterNumber","T_Patient.resx","Register Number"), Column("RegisterNumber")] [Required] 
		
        public string T_RegisterNumber { get; set; }
				[StringLength(255, ErrorMessage = "Patient Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_PatientName","T_Patient.resx","Patient Name"), Column("PatientName")]  
		
        public string T_PatientName { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_RegisterNumber != null ?Convert.ToString(this.T_RegisterNumber)+" " : Convert.ToString(this.T_RegisterNumber)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_RegisterNumber != null ?Convert.ToString(this.T_RegisterNumber)+" " : Convert.ToString(this.T_RegisterNumber)); 
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

