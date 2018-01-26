using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneratorBase.MVC.Models
{
    [Table("tbl_ReportsInRole")]
    public class ReportsInRole : Entity
    {
        [DisplayName("Report")]
        public string ReportId { get; set; }

        [DisplayName("Roles")]
        public string RoleId { get; set; }

        [DisplayName("Entity Name")]
        public string EntityName { get; set; }

        [DisplayName("Flag")]
        public Nullable<bool> Flag { get; set; }

        [DisplayName("Argument")]
        public string Argument { get; set; }

        public string getDisplayValue()
        {
            try
            {
                var dispValue = (this.ReportId != null ? Convert.ToString(this.ReportId) + " " : Convert.ToString(this.ReportId));
                dispValue = dispValue != null ? dispValue.TrimEnd(" ".ToCharArray()) : "";
                this.m_DisplayValue = dispValue;
                return dispValue;
            }
            catch { return ""; }
        }
        public override string getDisplayValueModel()
        {
            try
            {
                if (!string.IsNullOrEmpty(m_DisplayValue))
                    return m_DisplayValue;
                var dispValue = (this.ReportId != null ? Convert.ToString(this.ReportId) + " " : Convert.ToString(this.ReportId));
                return dispValue != null ? dispValue.TrimEnd(" ".ToCharArray()) : "";
            }
            catch { return ""; }
        }

        [NotMapped]
        public string[] SelectedRoleId { get; set; }
    }
}