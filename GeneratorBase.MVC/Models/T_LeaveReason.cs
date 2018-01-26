﻿using System;
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
    [Table("tbl_LeaveReason"),CustomDisplayName("T_LeaveReason", "T_LeaveReason.resx", "Leave Reason")]
	public partial class T_LeaveReason : Entity
    {	
		public T_LeaveReason()
        {
            this.T_LeaveProfileReason_t_leavereason = new HashSet<T_LeaveProfileReason>();
        }
				[StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_LeaveReason.resx","Name"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }
		


		 
		 
		[CustomDisplayName("T_Description","T_LeaveReason.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }
		
        public virtual ICollection<T_LeaveProfileReason> T_LeaveProfileReason_t_leavereason { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<T_LeaveProfile> T_LeaveProfile_T_LeaveProfileReason { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedT_LeaveProfile_T_LeaveProfileReason { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+" " : Convert.ToString(this.T_Name)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+" " : Convert.ToString(this.T_Name)); 
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

