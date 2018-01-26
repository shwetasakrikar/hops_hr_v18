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
    [Table("tbl_FacilityConfiguration"),CustomDisplayName("T_FacilityConfiguration", "T_FacilityConfiguration.resx", "Facility Configuration")]
	public partial class T_FacilityConfiguration : Entity
    {	
				[StringLength(255, ErrorMessage = "Key cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Key","T_FacilityConfiguration.resx","Key"), Column("Key")] [Required] 
		
        public string T_Key { get; set; }
				[StringLength(255, ErrorMessage = "Value cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Value","T_FacilityConfiguration.resx","Value"), Column("Value")] [Required] 
		
        public string T_Value { get; set; }



		[CustomDisplayName("T_TenantConfigurationAssociationID","T_FacilityConfiguration.resx","Tenant"), Column("TenantConfigurationAssociationID")]
        public Nullable<long> T_TenantConfigurationAssociationID { get; set; }
		
        public virtual T_Facility t_tenantconfigurationassociation { get; set;}
				 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Key != null ?Convert.ToString(this.T_Key)+" " : Convert.ToString(this.T_Key))+(this.T_Value != null ?Convert.ToString(this.T_Value)+" " : Convert.ToString(this.T_Value)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Key != null ?Convert.ToString(this.T_Key)+" " : Convert.ToString(this.T_Key))+(this.T_Value != null ?Convert.ToString(this.T_Value)+" " : Convert.ToString(this.T_Value)); 
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

