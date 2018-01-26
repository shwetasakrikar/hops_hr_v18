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
    [Table("tbl_Langauge"),CustomDisplayName("T_Langauge", "T_Langauge.resx", "Language")]
	public partial class T_Langauge : Entity
    {	
		public T_Langauge()
        {
            this.T_ConversationalEmployeeForeignLanguage_t_langauge = new HashSet<T_ConversationalEmployeeForeignLanguage>();
            this.T_LanguageCertifiedIn_t_langauge = new HashSet<T_LanguageCertifiedIn>();
        }
				[StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_Langauge.resx","Name"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }
		
        public virtual ICollection<T_ConversationalEmployeeForeignLanguage> T_ConversationalEmployeeForeignLanguage_t_langauge { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<T_Employee> T_Employee_T_ConversationalEmployeeForeignLanguage { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedT_Employee_T_ConversationalEmployeeForeignLanguage { get; set; }
		
        public virtual ICollection<T_LanguageCertifiedIn> T_LanguageCertifiedIn_t_langauge { get; set; }
		[NotMapped]
		 [JsonIgnore]
        public virtual ICollection<T_Employee> T_Employee_T_LanguageCertifiedIn { get; set; }
        [NotMapped]
        public virtual ICollection<long?> SelectedT_Employee_T_LanguageCertifiedIn { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+"-" : Convert.ToString(this.T_Name)); 
			dispValue = dispValue!=null?dispValue.TrimEnd("-".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+"-" : Convert.ToString(this.T_Name)); 
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

