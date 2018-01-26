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
    [Table("tbl_Comment"),CustomDisplayName("T_Comment", "T_Comment.resx", "Comment")]
	public partial class T_Comment : Entity
    {	
				
		


		[NotMapped]
 public DateTime? m_T_WhoandWhen { get; set; }[DataType(DataType.DateTime)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)] 
		[CustomDisplayName("T_WhoandWhen","T_Comment.resx","Update Who and When"), Column("WhoandWhen")]
		public Nullable<DateTime> T_WhoandWhen { get; set; }
		string m_T_WhoandWhenUser = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "System";
		[CustomDisplayName("T_WhoandWhenUser","T_Comment.resx","Update Who and When"), Column("WhoandWhenUser")]
		public string T_WhoandWhenUser
        {
            get
            {
                return m_T_WhoandWhenUser;
            }
            set
            {
                m_T_WhoandWhenUser = value;
            }
        }
		[NotMapped]
		public Nullable<DateTime> m_T_WhoandWhenInsertDate {get; set;}
		[DataType(DataType.DateTime)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)] 
		[CustomDisplayName("T_WhoandWhenInsertDate","T_Comment.resx","Insert Who and When"), Column("WhoandWhenInsertDate")]
		public Nullable<DateTime> T_WhoandWhenInsertDate {get; set;}
		[CustomDisplayName("T_WhoandWhenInsertBy","T_Comment.resx","Insert Who and When"), Column("WhoandWhenInsertBy")]
		public string T_WhoandWhenInsertBy { get; set; }
		


		 
		 
		[CustomDisplayName("T_Summary","T_Comment.resx","Notes"), Column("Summary")]  
		
        public string T_Summary { get; set; }



		[CustomDisplayName("T_EmployeeCommentsID","T_Comment.resx","Employee "), Column("EmployeeCommentsID")]
        public Nullable<long> T_EmployeeCommentsID { get; set; }
		
        public virtual T_Employee t_employeecomments { get; set;}
		


		[CustomDisplayName("T_AccommodationCommentsID","T_Comment.resx","Accommodation"), Column("AccommodationCommentsID")]
        public Nullable<long> T_AccommodationCommentsID { get; set; }
		
        public virtual T_Accommodation t_accommodationcomments { get; set;}
		


		[CustomDisplayName("T_DrugAlcoholTestCommentsID","T_Comment.resx","Drug & Alcohol Test"), Column("DrugAlcoholTestCommentsID")]
        public Nullable<long> T_DrugAlcoholTestCommentsID { get; set; }
		
        public virtual T_DrugAlcoholTest t_drugalcoholtestcomments { get; set;}
		


		[CustomDisplayName("T_EducationCommentsID","T_Comment.resx","Education"), Column("EducationCommentsID")]
        public Nullable<long> T_EducationCommentsID { get; set; }
		
        public virtual T_Education t_educationcomments { get; set;}
		


		[CustomDisplayName("T_InjuryCommentsID","T_Comment.resx","Employee Injury"), Column("InjuryCommentsID")]
        public Nullable<long> T_InjuryCommentsID { get; set; }
		
        public virtual T_EmployeeInjury t_injurycomments { get; set;}
		


		[CustomDisplayName("T_JobAssignmentCommentsID","T_Comment.resx","Job Assignment"), Column("JobAssignmentCommentsID")]
        public Nullable<long> T_JobAssignmentCommentsID { get; set; }
		
        public virtual T_JobAssignment t_jobassignmentcomments { get; set;}
		


		[CustomDisplayName("T_LeaveCommentsID","T_Comment.resx","Leave"), Column("LeaveCommentsID")]
        public Nullable<long> T_LeaveCommentsID { get; set; }
		
        public virtual T_LeaveProfile t_leavecomments { get; set;}
		


		[CustomDisplayName("T_LicensesCommentsID","T_Comment.resx","Licenses"), Column("LicensesCommentsID")]
        public Nullable<long> T_LicensesCommentsID { get; set; }
		
        public virtual T_Licenses t_licensescomments { get; set;}
		


		[CustomDisplayName("T_SalaryCommentsID","T_Comment.resx","Pay Details "), Column("SalaryCommentsID")]
        public Nullable<long> T_SalaryCommentsID { get; set; }
		
        public virtual T_PayDetails t_salarycomments { get; set;}
		


		[CustomDisplayName("T_PreemploymentCommentsID","T_Comment.resx","Pre Employment Checks"), Column("PreemploymentCommentsID")]
        public Nullable<long> T_PreemploymentCommentsID { get; set; }
		
        public virtual T_BackgroundCheck t_preemploymentcomments { get; set;}
		


		[CustomDisplayName("T_ServiceRecordCommentsID","T_Comment.resx","Service Record"), Column("ServiceRecordCommentsID")]
        public Nullable<long> T_ServiceRecordCommentsID { get; set; }
		
        public virtual T_ServiceRecord t_servicerecordcomments { get; set;}
				 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_WhoandWhenUser != null ?Convert.ToString(this.T_WhoandWhenUser)+" " : Convert.ToString(this.T_WhoandWhenUser))+(this.T_WhoandWhen != null ?Convert.ToString(this.T_WhoandWhen)+"-" : Convert.ToString(this.T_WhoandWhen)); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				  var dbT_WhoandWhen =this.T_WhoandWhen; if (this.m_T_WhoandWhen != this.T_WhoandWhen) dbT_WhoandWhen = TimeZoneInfo.ConvertTimeFromUtc(dbT_WhoandWhen.Value, this.m_Timezone);

			var dispValue = (this.T_WhoandWhenUser != null ?Convert.ToString(this.T_WhoandWhenUser)+" " : Convert.ToString(this.T_WhoandWhenUser))+(this.T_WhoandWhen.HasValue ?Convert.ToString(dbT_WhoandWhen.Value)+"-" : ""); 
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
            //this.T_WhoandWhen =  TimeZoneInfo.ConvertTimeToUtc(this.T_WhoandWhen, this.m_Timezone) ;
			this.T_WhoandWhen =  this.T_WhoandWhen.HasValue ? TimeZoneInfo.ConvertTimeToUtc(this.T_WhoandWhen.Value, this.m_Timezone) :  this.T_WhoandWhen;
        }
    }
}

