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
    [Table("tbl_Credential"),CustomDisplayName("T_Credential", "T_Credential.resx", "Credential")]
	public partial class T_Credential : Entity
    {	
				[StringLength(255, ErrorMessage = "Credential Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_CredentialName","T_Credential.resx","Credential Name"), Column("CredentialName")] [Required] 
		
        public string T_CredentialName { get; set; }
		


		 
		 
		[CustomDisplayName("T_Description","T_Credential.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }
				[StringLength(255, ErrorMessage = "Issue Authority cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_IssueAuthority","T_Credential.resx","Issue Authority"), Column("IssueAuthority")]  
		
        public string T_IssueAuthority { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_CredentialName != null ?Convert.ToString(this.T_CredentialName)+" " : Convert.ToString(this.T_CredentialName))+(this.T_Description != null ?Convert.ToString(this.T_Description)+"-" : Convert.ToString(this.T_Description))+(this.T_IssueAuthority != null ?Convert.ToString(this.T_IssueAuthority)+"-" : Convert.ToString(this.T_IssueAuthority)); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_CredentialName != null ?Convert.ToString(this.T_CredentialName)+" " : Convert.ToString(this.T_CredentialName))+(this.T_Description != null ?Convert.ToString(this.T_Description)+"-" : Convert.ToString(this.T_Description))+(this.T_IssueAuthority != null ?Convert.ToString(this.T_IssueAuthority)+"-" : Convert.ToString(this.T_IssueAuthority)); 
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

