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
    [Table("tbl_Licenses"),CustomDisplayName("T_Licenses", "T_Licenses.resx", "Licenses")]
	public partial class T_Licenses : Entity
    {	
		public T_Licenses()
        {
            this.t_licensescomments = new HashSet<T_Comment>();
        }
		


		 
		 
		[CustomDisplayName("T_NameontheLicense","T_Licenses.resx","Name on the License"), Column("NameontheLicense")]  
		
        public string T_NameontheLicense { get; set; }
				[StringLength(255, ErrorMessage = "License Number cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_LicenseNumber","T_Licenses.resx","License Number"), Column("LicenseNumber")]  
		
        public string T_LicenseNumber { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_InitialLicenseDate","T_Licenses.resx","Initial License Date"), Column("InitialLicenseDate")]  
		
        public Nullable<DateTime> T_InitialLicenseDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_ExpiryDate","T_Licenses.resx","Expiry Date"), Column("ExpiryDate")]  
		
        public Nullable<DateTime> T_ExpiryDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_PrintDate","T_Licenses.resx","License Print Date"), Column("PrintDate")]  
		
        public Nullable<DateTime> T_PrintDate { get; set; }
		


		 
		 
		[CustomDisplayName("T_Notes","T_Licenses.resx","Notes"), Column("Notes")]  
		
        public string T_Notes { get; set; }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_LicenseRecordsID","T_Licenses.resx","Employee"), Column("LicenseRecordsID")]
        public Nullable<long> T_LicenseRecordsID { get; set; }
		
        public virtual T_Employee t_licenserecords { get; set;}
		
[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_AssociatedLicensesTypeID","T_Licenses.resx","Licenses Type"), Column("AssociatedLicensesTypeID")]
        public Nullable<long> T_AssociatedLicensesTypeID { get; set; }
		
        public virtual T_Licensestype t_associatedlicensestype { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_licensescomments { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_AssociatedLicensesTypeID != null ? (new ApplicationContext(new SystemUser())).T_Licensestypes.FirstOrDefault(p=>p.Id == this.T_AssociatedLicensesTypeID).DisplayValue + "-" : "")+(this.T_LicenseRecordsID != null ? (new ApplicationContext(new SystemUser())).T_Employees.FirstOrDefault(p=>p.Id == this.T_LicenseRecordsID).DisplayValue + "-" : "")+(this.T_PrintDate.HasValue ? this.T_PrintDate.Value.ToShortDateString()+"-" : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_associatedlicensestype != null ?t_associatedlicensestype.DisplayValue + "-" : "")+(this.t_licenserecords != null ?t_licenserecords.DisplayValue + "-" : "")+(this.T_PrintDate.HasValue ? this.T_PrintDate.Value.ToShortDateString()+"-" : ""); 
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
			this.T_InitialLicenseDate = this.T_InitialLicenseDate.HasValue ?  this.T_InitialLicenseDate.Value.Date : this.T_InitialLicenseDate;
			this.T_ExpiryDate = this.T_ExpiryDate.HasValue ?  this.T_ExpiryDate.Value.Date : this.T_ExpiryDate;
			this.T_PrintDate = this.T_PrintDate.HasValue ?  this.T_PrintDate.Value.Date : this.T_PrintDate;
        }
    }
}

