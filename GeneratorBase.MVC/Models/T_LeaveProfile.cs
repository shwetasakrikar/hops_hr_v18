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
    [Table("tbl_LeaveProfile"),CustomDisplayName("T_LeaveProfile", "T_LeaveProfile.resx", "Leave")]
	public partial class T_LeaveProfile : Entity
    {	
		public T_LeaveProfile()
        {
            this.T_LeaveProfileReason_t_leaveprofile = new HashSet<T_LeaveProfileReason>();
            this.t_leavecomments = new HashSet<T_Comment>();
        }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_From","T_LeaveProfile.resx","From Date"), Column("From")]  
		
        public Nullable<DateTime> T_From { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_To","T_LeaveProfile.resx","To Date"), Column("To")]  
		
        public Nullable<DateTime> T_To { get; set; }
		[NotMapped]
        public Nullable<Decimal> calc_T_DaysOff = null;
		


		 
		 
		[CustomDisplayName("T_DaysOff","T_LeaveProfile.resx","Days Off"), Column("DaysOff")]  
		
        public Nullable<Decimal> T_DaysOff {  get { return getT_DaysOff(); } set { calc_T_DaysOff = value;} }
		


		 
		 
		[CustomDisplayName("T_Intermittent","T_LeaveProfile.resx","Intermittent"), Column("Intermittent")]  
		
        public Boolean? T_Intermittent { get; set; }
		


		 
		 
		[CustomDisplayName("T_FullDays","T_LeaveProfile.resx","Full Days"), Column("FullDays")]  
		
        public Boolean? T_FullDays { get; set; }
		


		 
		 
		[CustomDisplayName("T_Notes","T_LeaveProfile.resx","Notes"), Column("Notes")]  
		
        public string T_Notes { get; set; }



		[CustomDisplayName("T_EmployeeLeaveProfileID","T_LeaveProfile.resx","Employee"), Column("EmployeeLeaveProfileID")]
        public Nullable<long> T_EmployeeLeaveProfileID { get; set; }
		
        public virtual T_Employee t_employeeleaveprofile { get; set;}
		


		[CustomDisplayName("T_InjuryRelatedLeaveID","T_LeaveProfile.resx","Related Injury If Any"), Column("InjuryRelatedLeaveID")]
        public Nullable<long> T_InjuryRelatedLeaveID { get; set; }
		
        public virtual T_EmployeeInjury t_injuryrelatedleave { get; set;}
				
        public virtual ICollection<T_LeaveProfileReason> T_LeaveProfileReason_t_leaveprofile { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<T_LeaveReason> T_LeaveReason_T_LeaveProfileReason { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedT_LeaveReason_T_LeaveProfileReason { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_leavecomments { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_From.HasValue ? this.T_From.Value.ToShortDateString()+" " : ""); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_From.HasValue ? this.T_From.Value.ToShortDateString()+" " : ""); 
			return dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			//return m_DisplayValue;
			}catch{ return "";}
					 }
		public void setCalculation(){ try{  var T_DaysOff_Value1 = this.T_To;
 var T_DaysOff_Value2 = this.T_From;
 this.calc_T_DaysOff =  this.T_DaysOff = (T_DaysOff_Value1.Value-T_DaysOff_Value2.Value).Days;
 }catch{}}
		public void setDateTimeToClientTime() //call this method when you have to update record from code (not from html form). e.g. BulkUpdate
		{
		}
		public void setDateTimeToUTC()
        {
			this.T_From = this.T_From.HasValue ?  this.T_From.Value.Date : this.T_From;
			this.T_To = this.T_To.HasValue ?  this.T_To.Value.Date : this.T_To;
        }
        public Nullable<Decimal> getT_DaysOff()
        {
            if (calc_T_DaysOff == null)
			{
                var T_DaysOff_Value1 = this.T_To;
 var T_DaysOff_Value2 = this.T_From;
 if (T_DaysOff_Value1 != null && T_DaysOff_Value2 != null)
 calc_T_DaysOff = (T_DaysOff_Value1.Value-T_DaysOff_Value2.Value).Days;
 else 
 calc_T_DaysOff = null;;
			}
            return calc_T_DaysOff;
        }
    }
}

