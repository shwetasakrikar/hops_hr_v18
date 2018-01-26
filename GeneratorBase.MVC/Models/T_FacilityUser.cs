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
    [Table("tbl_FacilityUser"),CustomDisplayName("T_FacilityUser", "T_FacilityUser.resx", "Facility User")]
	public partial class T_FacilityUser : Entity
    {	



		[CustomDisplayName("T_UserID","T_FacilityUser.resx","Facility Users"),  Column("UserID")]
        public string T_UserID { get; set; }
        public virtual IdentityUser t_user { get; set; }//IdentityUser replaced by ApplicationUser



		[CustomDisplayName("T_FacilityID","T_FacilityUser.resx","Facility Users"), Column("FacilityID")]
        public Nullable<long> T_FacilityID { get; set; }
		
        public virtual T_Facility t_facility { get; set;}
				 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_UserID != null ? (new ApplicationDbContext()).Users.Find(this.T_UserID).UserName + "-"  : "")+(this.T_FacilityID != null ? (new ApplicationContext(new SystemUser())).T_Facilitys.FirstOrDefault(p=>p.Id == this.T_FacilityID).DisplayValue + "-" : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_facility != null ?t_facility.DisplayValue + "-" : ""); 
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

