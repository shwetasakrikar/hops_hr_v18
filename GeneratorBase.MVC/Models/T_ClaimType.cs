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
    [Table("tbl_ClaimType"),CustomDisplayName("T_ClaimType", "T_ClaimType.resx", "Claim Type")]
	public partial class T_ClaimType : Entity
    {	
		public T_ClaimType()
        {
            this.T_TypeofClaim_t_claimtype = new HashSet<T_TypeofClaim>();
        }
				[StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_ClaimType.resx","Name"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }



		[CustomDisplayName("T_ClaimTypeFacilityAssociationID","T_ClaimType.resx","Facility"), Column("ClaimTypeFacilityAssociationID")]
        public Nullable<long> T_ClaimTypeFacilityAssociationID { get; set; }
		
        public virtual T_Facility t_claimtypefacilityassociation { get; set;}
				
        public virtual ICollection<T_TypeofClaim> T_TypeofClaim_t_claimtype { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<T_EmployeeInjury> T_EmployeeInjury_T_TypeofClaim { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedT_EmployeeInjury_T_TypeofClaim { get; set; }
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

