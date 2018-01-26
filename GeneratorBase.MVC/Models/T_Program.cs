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
    [Table("tbl_Program"),CustomDisplayName("T_Program", "T_Program.resx", "Program")]
	public partial class T_Program : Entity
    {	
		public T_Program()
        {
            this.t_costprogram = new HashSet<T_CostCenter>();
        }
		


		 
		 
		[CustomDisplayName("T_ProgramNumber","T_Program.resx","Program"), Column("ProgramNumber")]  
		
        public Nullable<Int32> T_ProgramNumber { get; set; }
		


		 
		 
		[CustomDisplayName("T_Description","T_Program.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_CostCenter> t_costprogram { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_ProgramNumber != null ?Convert.ToString(this.T_ProgramNumber)+" " : Convert.ToString(this.T_ProgramNumber))+(this.T_Description != null ?Convert.ToString(this.T_Description)+" " : Convert.ToString(this.T_Description)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_ProgramNumber != null ?Convert.ToString(this.T_ProgramNumber)+" " : Convert.ToString(this.T_ProgramNumber))+(this.T_Description != null ?Convert.ToString(this.T_Description)+" " : Convert.ToString(this.T_Description)); 
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

