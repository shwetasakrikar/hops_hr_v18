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
    [Table("tbl_Restrictions"),CustomDisplayName("T_Restrictions", "T_Restrictions.resx", "Restrictions")]
	public partial class T_Restrictions : Entity
    {	
		public T_Restrictions()
        {
            this.T_TypeOfRestrictions_t_restrictions = new HashSet<T_TypeOfRestrictions>();
        }
				[StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_Restrictions.resx","Name"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }
		


		 
		 
		[CustomDisplayName("T_Description","T_Restrictions.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }



		[CustomDisplayName("T_RestrictionsFacilityAssociationID","T_Restrictions.resx","Facility"), Column("RestrictionsFacilityAssociationID")]
        public Nullable<long> T_RestrictionsFacilityAssociationID { get; set; }
		
        public virtual T_Facility t_restrictionsfacilityassociation { get; set;}
				
        public virtual ICollection<T_TypeOfRestrictions> T_TypeOfRestrictions_t_restrictions { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<T_EmployeeInjury> T_EmployeeInjury_T_TypeOfRestrictions { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedT_EmployeeInjury_T_TypeOfRestrictions { get; set; }
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

