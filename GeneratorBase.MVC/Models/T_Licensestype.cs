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
    [Table("tbl_Licensestype"),CustomDisplayName("T_Licensestype", "T_Licensestype.resx", "Licenses Type")]
	public partial class T_Licensestype : Entity
    {	
		public T_Licensestype()
        {
            this.t_associatedlicensestype = new HashSet<T_Licenses>();
        }
				[StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_Licensestype.resx","Name"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }
		


		 
		 
		[CustomDisplayName("T_Description","T_Licensestype.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Licenses> t_associatedlicensestype { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+" " : Convert.ToString(this.T_Name))+(this.T_Description != null ?Convert.ToString(this.T_Description)+" " : Convert.ToString(this.T_Description)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" ".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Name != null ?Convert.ToString(this.T_Name)+" " : Convert.ToString(this.T_Name))+(this.T_Description != null ?Convert.ToString(this.T_Description)+" " : Convert.ToString(this.T_Description)); 
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
