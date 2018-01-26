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
    [Table("tbl_FileDocument"),CustomDisplayName("FileDocument", "FileDocument.resx", "Document")]
	public partial class FileDocument : Entity
    {	
				[StringLength(255, ErrorMessage = "Document Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("DocumentName","FileDocument.resx","Document Name"), Column("DocumentName")] [Required] 
		
        public string DocumentName { get; set; }
				[StringLength(255, ErrorMessage = "Description cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("Description","FileDocument.resx","Description"), Column("Description")]  
		
        public string Description { get; set; }
		


		 
		 
		[CustomDisplayName("AttachDocument","FileDocument.resx","Attach Document"), Column("AttachDocument")]  
		
        public string AttachDocument { get; set; }
		[NotMapped]
        public DateTime m_DateCreated { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.DateTime)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("DateCreated","FileDocument.resx","Created"), Column("DateCreated")] [Required] 
		
        public DateTime DateCreated { get; set; }
		[NotMapped]
        public DateTime m_DateLastUpdated { get; set; }
				[CustomDate("01/01/1900", "12/31/9999")]
		


		[DataType(DataType.DateTime)][DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)] 
		 
		[CustomDisplayName("DateLastUpdated","FileDocument.resx","Last Updated"), Column("DateLastUpdated")] [Required] 
		
        public DateTime DateLastUpdated { get; set; }



		[CustomDisplayName("T_EmployeeDocumentsID","FileDocument.resx","Employee"), Column("EmployeeDocumentsID")]
        public Nullable<long> T_EmployeeDocumentsID { get; set; }
		
        public virtual T_Employee t_employeedocuments { get; set;}
				 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.DocumentName != null ?Convert.ToString(this.DocumentName)+" " : Convert.ToString(this.DocumentName)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.DocumentName != null ?Convert.ToString(this.DocumentName)+" " : Convert.ToString(this.DocumentName)); 
			return dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			//return m_DisplayValue;
			}catch{ return "";}
					 }
		public void setCalculation(){ try{  }catch{}}
		public void setDateTimeToClientTime() //call this method when you have to update record from code (not from html form). e.g. BulkUpdate
		{
		this.DateCreated =  TimeZoneInfo.ConvertTimeFromUtc(this.DateCreated, this.m_Timezone) ;
		this.DateLastUpdated =  TimeZoneInfo.ConvertTimeFromUtc(this.DateLastUpdated, this.m_Timezone) ;
		}
		public void setDateTimeToUTC()
        {
            this.DateCreated =  TimeZoneInfo.ConvertTimeToUtc(this.DateCreated, this.m_Timezone) ;
            this.DateLastUpdated =  TimeZoneInfo.ConvertTimeToUtc(this.DateLastUpdated, this.m_Timezone) ;
        }
    }
}

