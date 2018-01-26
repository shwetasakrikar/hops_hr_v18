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
    [Table("tbl_SalaryBand"),CustomDisplayName("T_SalaryBand", "T_SalaryBand.resx", "Salary Band")]
	public partial class T_SalaryBand : Entity
    {	
		public T_SalaryBand()
        {
            this.t_salarybandsalaryrangeassociation = new HashSet<T_SalaryRange>();
            this.t_rolecodesalaryband = new HashSet<T_RoleCode>();
        }
				[StringLength(255, ErrorMessage = "Band cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_SalaryBand.resx","Band"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_SalaryRange> t_salarybandsalaryrangeassociation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_RoleCode> t_rolecodesalaryband { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+" Range: $" : Convert.ToString(this.T_Name)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" Range: $".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+" Range: $" : Convert.ToString(this.T_Name)); 
			return dispValue!=null?dispValue.TrimEnd(" Range: $".ToCharArray()):"";
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

