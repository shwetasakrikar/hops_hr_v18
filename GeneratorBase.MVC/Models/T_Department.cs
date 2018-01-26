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
    [Table("tbl_Department"),CustomDisplayName("T_Department", "T_Department.resx", "Department")]
	public partial class T_Department : Entity
    {	
		public T_Department()
        {
            this.t_warddepartment = new HashSet<T_UnitX>();
        }
				[StringLength(255, ErrorMessage = "DEPTshort cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_DEPTshort","T_Department.resx","DEPTshort"), Column("DEPTshort")] [Required] 
		
        public string T_DEPTshort { get; set; }
				[StringLength(255, ErrorMessage = "Department Title cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_DepartmentTitle","T_Department.resx","Department Title"), Column("DepartmentTitle")]  
		
        public string T_DepartmentTitle { get; set; }



		[CustomDisplayName("T_DepartmentFacilityAssociationID","T_Department.resx","Facility"), Column("DepartmentFacilityAssociationID")]
        public Nullable<long> T_DepartmentFacilityAssociationID { get; set; }
		
        public virtual T_Facility t_departmentfacilityassociation { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_UnitX> t_warddepartment { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_DEPTshort != null ?Convert.ToString(this.T_DEPTshort)+" " : Convert.ToString(this.T_DEPTshort)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_DEPTshort != null ?Convert.ToString(this.T_DEPTshort)+" " : Convert.ToString(this.T_DEPTshort)); 
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

