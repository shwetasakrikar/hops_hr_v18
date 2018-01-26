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
    [Table("tbl_TypeofClaim"),CustomDisplayName("T_TypeofClaim", "T_TypeofClaim.resx", "Type of Claim")]
	public partial class T_TypeofClaim : Entity
    {	



		[CustomDisplayName("T_ClaimTypeID","T_TypeofClaim.resx","Type of Claim Facility"), Column("ClaimTypeID")]
        public Nullable<long> T_ClaimTypeID { get; set; }
		
        public virtual T_ClaimType t_claimtype { get; set;}
		


		[CustomDisplayName("T_EmployeeInjuryID","T_TypeofClaim.resx","Employee Injury"), Column("EmployeeInjuryID")]
        public Nullable<long> T_EmployeeInjuryID { get; set; }
		
        public virtual T_EmployeeInjury t_employeeinjury { get; set;}
				 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_ClaimTypeID != null ? (new ApplicationContext(new SystemUser())).T_ClaimTypes.FirstOrDefault(p=>p.Id == this.T_ClaimTypeID).DisplayValue + "-" : "")+(this.T_EmployeeInjuryID != null ? (new ApplicationContext(new SystemUser())).T_EmployeeInjurys.FirstOrDefault(p=>p.Id == this.T_EmployeeInjuryID).DisplayValue + "-" : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_claimtype != null ?t_claimtype.DisplayValue + "-" : "")+(this.t_employeeinjury != null ?t_employeeinjury.DisplayValue + "-" : ""); 
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

