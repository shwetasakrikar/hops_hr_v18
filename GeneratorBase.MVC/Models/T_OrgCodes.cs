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
    [Table("tbl_OrgCodes"),CustomDisplayName("T_OrgCodes", "T_OrgCodes.resx", "Org Codes")]
	public partial class T_OrgCodes : Entity
    {	
		public T_OrgCodes()
        {
            this.t_wardorgcode = new HashSet<T_UnitX>();
        }
				[StringLength(255, ErrorMessage = "Org Code cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_OrgCode","T_OrgCodes.resx","Org Code"), Column("OrgCode")] [Required] 
		
        public string T_OrgCode { get; set; }
		


		 
		 
		[CustomDisplayName("T_CodeDescription","T_OrgCodes.resx","Code Description"), Column("CodeDescription")]  
		
        public string T_CodeDescription { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_UnitX> t_wardorgcode { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_OrgCode != null ?Convert.ToString(this.T_OrgCode)+" " : Convert.ToString(this.T_OrgCode))+(this.T_CodeDescription != null ?Convert.ToString(this.T_CodeDescription)+" " : Convert.ToString(this.T_CodeDescription)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_OrgCode != null ?Convert.ToString(this.T_OrgCode)+" " : Convert.ToString(this.T_OrgCode))+(this.T_CodeDescription != null ?Convert.ToString(this.T_CodeDescription)+" " : Convert.ToString(this.T_CodeDescription)); 
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

