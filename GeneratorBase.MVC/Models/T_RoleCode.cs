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
    [Table("tbl_RoleCode"),CustomDisplayName("T_RoleCode", "T_RoleCode.resx", "Role Code")]
	public partial class T_RoleCode : Entity
    {	
		public T_RoleCode()
        {
            this.t_rolecoderequirededucation = new HashSet<T_RequiredEducation>();
            this.t_positionrolecode = new HashSet<T_Position>();
        }
				[StringLength(255, ErrorMessage = "Code cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Code","T_RoleCode.resx","Code"), Column("Code")] [Required] 
		
        public string T_Code { get; set; }
				[StringLength(255, ErrorMessage = "Title cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Title","T_RoleCode.resx","Title"), Column("Title")] [Required] 
		
        public string T_Title { get; set; }
				[StringLength(255, ErrorMessage = "Role_TitleA cannot be longer than 255 characters.")]
		


		 
		 
		[CustomDisplayName("T_Role_TitleA","T_RoleCode.resx","Role_TitleA"), Column("Role_TitleA")]  
		
        public string T_Role_TitleA { get; set; }



		[CustomDisplayName("T_RoleCodeSalaryBandID","T_RoleCode.resx","Salary Band"), Column("RoleCodeSalaryBandID")]
        public Nullable<long> T_RoleCodeSalaryBandID { get; set; }
		
        public virtual T_SalaryBand t_rolecodesalaryband { get; set;}
				
		[JsonIgnore]
        public virtual ICollection<T_RequiredEducation> t_rolecoderequirededucation { get; set; }
		
		[JsonIgnore]
        public virtual ICollection<T_Position> t_positionrolecode { get; set; }
		 public  string getDisplayValue() {
 
		 try{
			var dispValue = (this.T_Code != null ?Convert.ToString(this.T_Code)+" " : Convert.ToString(this.T_Code))+(this.T_Title != null ?Convert.ToString(this.T_Title)+" -" : Convert.ToString(this.T_Title)); 
			dispValue = dispValue!=null?dispValue.TrimEnd(" -".ToCharArray()):"";
			this.m_DisplayValue = dispValue;
			return dispValue;
			}catch{ return "";}
					 }
public override string getDisplayValueModel() {
			try{
			 if (!string.IsNullOrEmpty(m_DisplayValue))
                 return m_DisplayValue;
				 
			var dispValue = (this.T_Code != null ?Convert.ToString(this.T_Code)+" " : Convert.ToString(this.T_Code))+(this.T_Title != null ?Convert.ToString(this.T_Title)+" -" : Convert.ToString(this.T_Title)); 
			return dispValue!=null?dispValue.TrimEnd(" -".ToCharArray()):"";
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

