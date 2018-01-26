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
    [Table("tbl_SalaryRange"),CustomDisplayName("T_SalaryRange", "T_SalaryRange.resx", "Salary Range")]
	public partial class T_SalaryRange : Entity
    {	
		


		[DataType(DataType.Currency)] 
		 
		[CustomDisplayName("T_Minimum","T_SalaryRange.resx","Minimum"), Column("Minimum")]  
		
        public Nullable<Decimal> T_Minimum { get; set; }
		


		[DataType(DataType.Currency)] 
		 
		[CustomDisplayName("T_Maximum","T_SalaryRange.resx","Maximum"), Column("Maximum")]  
		
        public Nullable<Decimal> T_Maximum { get; set; }



		[CustomDisplayName("T_SalaryBandSalaryRangeAssociationID","T_SalaryRange.resx","Salary Band"), Column("SalaryBandSalaryRangeAssociationID")]
        public Nullable<long> T_SalaryBandSalaryRangeAssociationID { get; set; }
		
        public virtual T_SalaryBand t_salarybandsalaryrangeassociation { get; set;}
		


		[CustomDisplayName("T_FacilitySalaryRangeAssociationID","T_SalaryRange.resx","Facility"), Column("FacilitySalaryRangeAssociationID")]
        public Nullable<long> T_FacilitySalaryRangeAssociationID { get; set; }
		
        public virtual T_Facility t_facilitysalaryrangeassociation { get; set;}
				 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Minimum != null ?this.T_Minimum.Value.ToString("0.00")+"-" : this.T_Minimum.Value.ToString("0.00"))+(this.T_Maximum != null ?this.T_Maximum.Value.ToString("0.00")+"-" : this.T_Maximum.Value.ToString("0.00")); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Minimum != null ?this.T_Minimum.Value.ToString("0.00")+"-" : this.T_Minimum.Value.ToString("0.00"))+(this.T_Maximum != null ?this.T_Maximum.Value.ToString("0.00")+"-" : this.T_Maximum.Value.ToString("0.00")); 
			return dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
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

