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
    [Table("tbl_ShiftMealTime"),CustomDisplayName("T_ShiftMealTime", "T_ShiftMealTime.resx", "Shift Meal Time")]
	public partial class T_ShiftMealTime : Entity
    {	
		public T_ShiftMealTime()
        {
            this.t_positionshiftmealtime = new HashSet<T_Position>();
        }
				[StringLength(255, ErrorMessage = "Meal Time cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_MealTime","T_ShiftMealTime.resx","Meal Time"), Column("MealTime")]  
		
        public string T_MealTime { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Position> t_positionshiftmealtime { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_MealTime != null ?Convert.ToString(this.T_MealTime)+" " : Convert.ToString(this.T_MealTime)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_MealTime != null ?Convert.ToString(this.T_MealTime)+" " : Convert.ToString(this.T_MealTime)); 
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

