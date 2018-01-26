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
    [Table("tbl_LanguageCertifiedIn"),CustomDisplayName("T_LanguageCertifiedIn", "T_LanguageCertifiedIn.resx", "Language Certified In")]
	public partial class T_LanguageCertifiedIn : Entity
    {	



		[CustomDisplayName("T_EmployeeID","T_LanguageCertifiedIn.resx","Employee Certified in the Language"), Column("EmployeeID")]
        public Nullable<long> T_EmployeeID { get; set; }
		
        public virtual T_Employee t_employee { get; set;}
		


		[CustomDisplayName("T_LangaugeID","T_LanguageCertifiedIn.resx","Languages Certified In"), Column("LangaugeID")]
        public Nullable<long> T_LangaugeID { get; set; }
		
        public virtual T_Langauge t_langauge { get; set;}
				 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_EmployeeID != null ? (new ApplicationContext(new SystemUser())).T_Employees.FirstOrDefault(p=>p.Id == this.T_EmployeeID).DisplayValue + "-" : "")+(this.T_LangaugeID != null ? (new ApplicationContext(new SystemUser())).T_Langauges.FirstOrDefault(p=>p.Id == this.T_LangaugeID).DisplayValue + "-" : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_employee != null ?t_employee.DisplayValue + "-" : "")+(this.t_langauge != null ?t_langauge.DisplayValue + "-" : ""); 
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

