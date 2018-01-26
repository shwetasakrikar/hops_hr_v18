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
    [Table("tbl_LeaveProfileReason"),CustomDisplayName("T_LeaveProfileReason", "T_LeaveProfileReason.resx", "Leave Profile Reason")]
	public partial class T_LeaveProfileReason : Entity
    {	



		[CustomDisplayName("T_LeaveReasonID","T_LeaveProfileReason.resx","Leave Reason"), Column("LeaveReasonID")]
        public Nullable<long> T_LeaveReasonID { get; set; }
		
        public virtual T_LeaveReason t_leavereason { get; set;}
		


		[CustomDisplayName("T_LeaveProfileID","T_LeaveProfileReason.resx","Leave"), Column("LeaveProfileID")]
        public Nullable<long> T_LeaveProfileID { get; set; }
		
        public virtual T_LeaveProfile t_leaveprofile { get; set;}
				 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_LeaveReasonID != null ? (new ApplicationContext(new SystemUser())).T_LeaveReasons.FirstOrDefault(p=>p.Id == this.T_LeaveReasonID).DisplayValue + "-" : "")+(this.T_LeaveProfileID != null ? (new ApplicationContext(new SystemUser())).T_LeaveProfiles.FirstOrDefault(p=>p.Id == this.T_LeaveProfileID).DisplayValue + "-" : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_leavereason != null ?t_leavereason.DisplayValue + "-" : "")+(this.t_leaveprofile != null ?t_leaveprofile.DisplayValue + "-" : ""); 
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

