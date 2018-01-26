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
    [Table("tbl_Accommodation"),CustomDisplayName("T_Accommodation", "T_Accommodation.resx", "Accommodation")]
	public partial class T_Accommodation : Entity
    {	
		public T_Accommodation()
        {
            this.t_accommodationcomments = new HashSet<T_Comment>();
        }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_AccommodationStartDate","T_Accommodation.resx","Accommodation Start Date"), Column("AccommodationStartDate")] [Required] 
		
        public DateTime T_AccommodationStartDate { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_AccommodationEndDate","T_Accommodation.resx","Accommodation End Date"), Column("AccommodationEndDate")]  
		
        public Nullable<DateTime> T_AccommodationEndDate { get; set; }
		[NotMapped]
        public Nullable<DateTime> m_T_NinetyDaysSinceAccommodation { get; set; }
				
		[NotMapped]
        public Nullable<DateTime> calc_T_NinetyDaysSinceAccommodation = null;
		


		[DataType(DataType.Time)][DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_NinetyDaysSinceAccommodation","T_Accommodation.resx","Ninety Days Since Accommodation"), Column("NinetyDaysSinceAccommodation")]  
		
        public Nullable<DateTime> T_NinetyDaysSinceAccommodation {  get { return getT_NinetyDaysSinceAccommodation(); } set { calc_T_NinetyDaysSinceAccommodation = value;} }
		


		 
		 
		[CustomDisplayName("T_TemporaryAccommodation","T_Accommodation.resx","Temporary Accommodation"), Column("TemporaryAccommodation")]  
		
        public Boolean? T_TemporaryAccommodation { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.Date)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("T_DateLetterGivenToEmployee","T_Accommodation.resx","Date Letter Given To Employee"), Column("DateLetterGivenToEmployee")]  
		
        public Nullable<DateTime> T_DateLetterGivenToEmployee { get; set; }
		

[NotMapped]
		 
		 
		[CustomDisplayName("T_Restriction","T_Accommodation.resx","Restriction"), Column("Restriction")]  
		
        public string T_Restriction { get {return t_accommodationinjury!=null ?t_accommodationinjury.T_DetailsOfRestriction:null;} set { } }
		


		 
		 
		[CustomDisplayName("T_AccommodationNotes","T_Accommodation.resx","Accommodation Notes"), Column("AccommodationNotes")]  
		
        public string T_AccommodationNotes { get; set; }

[CustomValidation(typeof(MandatoryDropdown), "ValidateDropdown")]

		[CustomDisplayName("T_EmployeeAccomodationID","T_Accommodation.resx","Employee"), Column("EmployeeAccomodationID")]
        public Nullable<long> T_EmployeeAccomodationID { get; set; }
		
        public virtual T_Employee t_employeeaccomodation { get; set;}
		


		[CustomDisplayName("T_AccommodationInjuryID","T_Accommodation.resx","Employee Injury"), Column("AccommodationInjuryID")]
        public Nullable<long> T_AccommodationInjuryID { get; set; }
		
        public virtual T_EmployeeInjury t_accommodationinjury { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Comment> t_accommodationcomments { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_EmployeeAccomodationID != null ? (new ApplicationContext(new SystemUser())).T_Employees.FirstOrDefault(p=>p.Id == this.T_EmployeeAccomodationID).DisplayValue + "-" : "")+(this.T_AccommodationStartDate!=null ?this.T_AccommodationStartDate.ToShortDateString()+"-":""); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.t_employeeaccomodation != null ?t_employeeaccomodation.DisplayValue + "-" : "")+(this.T_AccommodationStartDate!=null ?this.T_AccommodationStartDate.ToShortDateString()+"-":""); 
			return dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			//return m_DisplayValue;
			}catch{ return "";}
					 }
		public void setCalculation(){ try{  this.calc_T_NinetyDaysSinceAccommodation =  this.calc_T_NinetyDaysSinceAccommodation =  this.T_NinetyDaysSinceAccommodation = (T_AccommodationStartDate.AddDays(Convert.ToDouble(90)));
 }catch{}}
		public void setDateTimeToClientTime() //call this method when you have to update record from code (not from html form). e.g. BulkUpdate
		{
		}
		public void setDateTimeToUTC()
        {
			this.T_AccommodationStartDate =  this.T_AccommodationStartDate.Date ;
			this.T_AccommodationEndDate = this.T_AccommodationEndDate.HasValue ?  this.T_AccommodationEndDate.Value.Date : this.T_AccommodationEndDate;
			this.T_DateLetterGivenToEmployee = this.T_DateLetterGivenToEmployee.HasValue ?  this.T_DateLetterGivenToEmployee.Value.Date : this.T_DateLetterGivenToEmployee;
        }
        public Nullable<DateTime> getT_NinetyDaysSinceAccommodation()
        {
            if (calc_T_NinetyDaysSinceAccommodation == null)
			{
                if (T_AccommodationStartDate!= null)
 calc_T_NinetyDaysSinceAccommodation = (T_AccommodationStartDate.AddDays(Convert.ToDouble(90)));
else
 calc_T_NinetyDaysSinceAccommodation = null;;
			}
            return calc_T_NinetyDaysSinceAccommodation;
        }
    }
}

