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
    [Table("tbl_CostCenter"),CustomDisplayName("T_CostCenter", "T_CostCenter.resx", "Cost Center")]
	public partial class T_CostCenter : Entity
    {	
		public T_CostCenter()
        {
            this.t_positioncostcenterassociation = new HashSet<T_Position>();
            this.t_wardcostcenter = new HashSet<T_UnitX>();
        }
				[StringLength(255, ErrorMessage = "CC cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_CC","T_CostCenter.resx","CC"), Column("CC")] [Required] 
		
        public string T_CC { get; set; }
		


		 
		 
		[CustomDisplayName("T_CCDescription","T_CostCenter.resx","CC Description"), Column("CCDescription")]  
		
        public string T_CCDescription { get; set; }



		[CustomDisplayName("T_CostProgramID","T_CostCenter.resx","Program"), Column("CostProgramID")]
        public Nullable<long> T_CostProgramID { get; set; }
		
        public virtual T_Program t_costprogram { get; set;}
		


		[CustomDisplayName("T_CostFundID","T_CostCenter.resx","Fund"), Column("CostFundID")]
        public Nullable<long> T_CostFundID { get; set; }
		
        public virtual T_Fund t_costfund { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Position> t_positioncostcenterassociation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_UnitX> t_wardcostcenter { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_CC != null ?Convert.ToString(this.T_CC)+" " : Convert.ToString(this.T_CC))+(this.T_CCDescription != null ?Convert.ToString(this.T_CCDescription)+" " : Convert.ToString(this.T_CCDescription)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_CC != null ?Convert.ToString(this.T_CC)+" " : Convert.ToString(this.T_CC))+(this.T_CCDescription != null ?Convert.ToString(this.T_CCDescription)+" " : Convert.ToString(this.T_CCDescription)); 
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

