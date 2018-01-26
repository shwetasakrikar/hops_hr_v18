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
    [Table("tbl_City"),CustomDisplayName("T_City", "T_City.resx", "City")]
	public partial class T_City : Entity
    {	
		public T_City()
        {
            this.t_addresscity = new HashSet<T_Address>();
        }
				[StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Name","T_City.resx","Name"), Column("Name")] [Required] 
		
        public string T_Name { get; set; }
		


		 
		 
		[CustomDisplayName("T_Description","T_City.resx","Description"), Column("Description")]  
		
        public string T_Description { get; set; }



		[CustomDisplayName("T_CityCountryID","T_City.resx","City Country"), Column("CityCountryID")]
        public Nullable<long> T_CityCountryID { get; set; }
		
        public virtual T_Country t_citycountry { get; set;}
		


		[CustomDisplayName("T_CityStateID","T_City.resx","City State"), Column("CityStateID")]
        public Nullable<long> T_CityStateID { get; set; }
		
        public virtual T_State t_citystate { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_Address> t_addresscity { get; set; }
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

