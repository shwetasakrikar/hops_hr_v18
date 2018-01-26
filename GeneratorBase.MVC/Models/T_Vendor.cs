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
    [Table("tbl_Vendor"),CustomDisplayName("T_Vendor", "T_Vendor.resx", "Education Verification Vendor")]
	public partial class T_Vendor : Entity
    {	
		public T_Vendor()
        {
            this.t_educationverificationvendor = new HashSet<T_Education>();
        }
				[StringLength(255, ErrorMessage = "Title cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Title","T_Vendor.resx","Title"), Column("Title")]  
		
        public string T_Title { get; set; }
				[StringLength(255, ErrorMessage = "First Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_FirstName","T_Vendor.resx","First Name"), Column("FirstName")] [Required] 
		
        public string T_FirstName { get; set; }
				[StringLength(255, ErrorMessage = "Middle Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_MiddleName","T_Vendor.resx","Middle Name"), Column("MiddleName")]  
		
        public string T_MiddleName { get; set; }
				[StringLength(255, ErrorMessage = "Last Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_LastName","T_Vendor.resx","Last Name"), Column("LastName")]  
		
        public string T_LastName { get; set; }
            
           [EmailAddress]
		


		 
		 
		[CustomDisplayName("T_Email","T_Vendor.resx","Email"), Column("Email")]  
		
        public string T_Email { get; set; }
            
           [RegularExpression(@"^\d{3}\-?\d{3}\-?\d{4}$", ErrorMessage = "Invalid Phone No")]
		


		 
		 
		[CustomDisplayName("T_PhoneNo","T_Vendor.resx","Phone No"), Column("PhoneNo")]  
		
        public string T_PhoneNo { get; set; }
				[StringLength(255, ErrorMessage = "Identification No cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_IdentificationNo","T_Vendor.resx","Identification No"), Column("IdentificationNo")]  
		
        public string T_IdentificationNo { get; set; }
		


		 
		 
		[CustomDisplayName("T_Picture","T_Vendor.resx","Picture"), Column("Picture")]  
		
        public string T_Picture { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Education> t_educationverificationvendor { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_FirstName != null ?Convert.ToString(this.T_FirstName)+" " : Convert.ToString(this.T_FirstName))+(this.T_LastName != null ?Convert.ToString(this.T_LastName)+" " : Convert.ToString(this.T_LastName)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_FirstName != null ?Convert.ToString(this.T_FirstName)+" " : Convert.ToString(this.T_FirstName))+(this.T_LastName != null ?Convert.ToString(this.T_LastName)+" " : Convert.ToString(this.T_LastName)); 
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

