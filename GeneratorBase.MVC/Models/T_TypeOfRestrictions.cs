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
    [Table("tbl_TypeOfRestrictions"),CustomDisplayName("T_TypeOfRestrictions", "T_TypeOfRestrictions.resx", "Type Of Restrictions")]
	public partial class T_TypeOfRestrictions : Entity
    {	



		[CustomDisplayName("T_RestrictionsID","T_TypeOfRestrictions.resx","Type Of Restrictions"), Column("RestrictionsID")]
        public Nullable<long> T_RestrictionsID { get; set; }
		
        public virtual T_Restrictions t_restrictions { get; set;}
		


		[CustomDisplayName("T_EmployeeInjuryID","T_TypeOfRestrictions.resx","Employees Injuries"), Column("EmployeeInjuryID")]
        public Nullable<long> T_EmployeeInjuryID { get; set; }
		
        public virtual T_EmployeeInjury t_employeeinjury { get; set;}
				 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_RestrictionsID != null ? (new ApplicationContext(new SystemUser())).T_Restrictionss.FirstOrDefault(p=>p.Id == this.T_RestrictionsID).DisplayValue + "-" : "")+(this.T_EmployeeInjuryID != null ? (new ApplicationContext(new SystemUser())).T_EmployeeInjurys.FirstOrDefault(p=>p.Id == this.T_EmployeeInjuryID).DisplayValue + "-" : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_restrictions != null ?t_restrictions.DisplayValue + "-" : "")+(this.t_employeeinjury != null ?t_employeeinjury.DisplayValue + "-" : ""); 
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

