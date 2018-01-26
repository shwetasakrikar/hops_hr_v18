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
    [Table("tbl_AllFacilitiesUnit"),CustomDisplayName("T_AllFacilitiesUnit", "T_AllFacilitiesUnit.resx", "All Facilities Unit")]
	public partial class T_AllFacilitiesUnit : Entity
    {	
		public T_AllFacilitiesUnit()
        {
            this.t_allunitsfloor = new HashSet<T_AllFacilitiesFloor>();
            this.t_unitwhereaccidentoccured = new HashSet<T_EmployeeInjury>();
        }
				[StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_AllFacilitiesUnit.resx","Name"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }
		


		 
		 
		[CustomDisplayName("T_Description","T_AllFacilitiesUnit.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }



		[CustomDisplayName("T_UnitsforAllFaciltiesID","T_AllFacilitiesUnit.resx","Facility"), Column("UnitsforAllFaciltiesID")]
        public Nullable<long> T_UnitsforAllFaciltiesID { get; set; }
		
        public virtual T_AllFacilities t_unitsforallfacilties { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_AllFacilitiesFloor> t_allunitsfloor { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_EmployeeInjury> t_unitwhereaccidentoccured { get; set; }
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

