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
    [Table("tbl_Fund"),CustomDisplayName("T_Fund", "T_Fund.resx", "Fund")]
	public partial class T_Fund : Entity
    {	
		public T_Fund()
        {
            this.t_costfund = new HashSet<T_CostCenter>();
        }
				[StringLength(255, ErrorMessage = "Code cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Code","T_Fund.resx","Code"), Column("Code")] [Required] 
		
        public string T_Code { get; set; }
		


		 
		 
		[CustomDisplayName("T_Description","T_Fund.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_CostCenter> t_costfund { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Code != null ?Convert.ToString(this.T_Code)+" " : Convert.ToString(this.T_Code))+(this.T_Description != null ?Convert.ToString(this.T_Description)+" " : Convert.ToString(this.T_Description)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Code != null ?Convert.ToString(this.T_Code)+" " : Convert.ToString(this.T_Code))+(this.T_Description != null ?Convert.ToString(this.T_Description)+" " : Convert.ToString(this.T_Description)); 
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

