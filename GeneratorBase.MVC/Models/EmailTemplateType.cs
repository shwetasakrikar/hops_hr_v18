﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.AspNet.Identity.EntityFramework;
namespace GeneratorBase.MVC.Models
{
    [Table("tbl_EmailTemplateType")]
    public class EmailTemplateType : Entity
    {
        public EmailTemplateType()
        {
            this.associatedemailtemplate = new HashSet<EmailTemplate>();
        }
        [Unique(typeof(ApplicationContext), ErrorMessage = "Must be unique")]
        [DisplayName("Template Name")]
        [Required]
        public string Name { get; set; }
        [DisplayName("IsDefault")]
        public bool IsDefault { get; set; }
        DateTime? m_LastUpdatedBy = DateTime.UtcNow;
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> LastUpdatedBy
        {
            get
            {
                return m_LastUpdatedBy;
            }
            set
            {
                m_LastUpdatedBy = value;
            }
        }
        string m_LastUpdatedByUser = HttpContext.Current != null && HttpContext.Current.User != null ? HttpContext.Current.User.Identity.Name : "System";
        [DisplayName("LastUpdatedByUser")]
        public string LastUpdatedByUser
        {
            get
            {
                return m_LastUpdatedByUser;
            }
            set
            {
                m_LastUpdatedByUser = value;
            }
        }
        public virtual ICollection<EmailTemplate> associatedemailtemplate { get; set; }
        public  string getDisplayValue() {
            var dispValue = Convert.ToString(this.Name);
            dispValue = dispValue.TrimEnd(" - ".ToCharArray());
            this.m_DisplayValue = dispValue;
            return dispValue;
        }
        public override string getDisplayValueModel() {
            if (!string.IsNullOrEmpty(m_DisplayValue))
                return m_DisplayValue;
            return Convert.ToString(this.Name); 
        }
    }
}