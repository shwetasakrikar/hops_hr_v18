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
    [Table("tbl_AllFacilitiesFloor"),CustomDisplayName("T_AllFacilitiesFloor", "T_AllFacilitiesFloor.resx", "All Facilities Floor")]
	public partial class T_AllFacilitiesFloor : Entity
    {	
		public T_AllFacilitiesFloor()
        {
            this.t_employeinjuryfloor = new HashSet<T_EmployeeInjury>();
        }
				[StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_AllFacilitiesFloor.resx","Name"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }
		


		 
		 
		[CustomDisplayName("T_Description","T_AllFacilitiesFloor.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }



		[CustomDisplayName("T_AllUnitsFloorID","T_AllFacilitiesFloor.resx","Unit"), Column("AllUnitsFloorID")]
        public Nullable<long> T_AllUnitsFloorID { get; set; }
		
        public virtual T_AllFacilitiesUnit t_allunitsfloor { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_EmployeeInjury> t_employeinjuryfloor { get; set; }
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

