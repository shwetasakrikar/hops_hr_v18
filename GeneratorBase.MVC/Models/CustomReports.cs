using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.AspNet.Identity.EntityFramework;
namespace GeneratorBase.MVC.Models
{
    [Table("tbl_CustomReports"), CustomDisplayName("CustomReports", "CustomReports.resx", "CustomReports")]
    public class CustomReports : Entity
    {
        [CustomDisplayName("EntityValues", "CustomReports.resx", "EntityValues"), Column("EntityValues")]
        public string EntityValues { get; set; }
        [CustomDisplayName("CrossTabPropertyValues", "CustomReports.resx", "CrossTabPropertyValues"), Column("CrossTabPropertyValues")]
        public string CrossTabPropertyValues { get; set; }
        [CustomDisplayName("QueryConditionValues", "CustomReports.resx", "QueryConditionValues"), Column("QueryConditionValues")]
        public string QueryConditionValues { get; set; }

        [CustomDisplayName("RelationsValues", "CustomReports.resx", "RelationsValues"), Column("RelationsValues")]
        public string RelationsValues { get; set; }



        [CustomDisplayName("OtherValues", "CustomReports.resx", "OtherValues"), Column("OtherValues")]

        public string OtherValues { get; set; }



        [CustomDisplayName("ReportName", "CustomReports.resx", "Report Name"), Column("ReportName")]
        [Required]

        public string ReportName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]

        [CustomDisplayName("CreatedOn", "CustomReports.resx", "Created On"), Column("CreatedOn")]
        [Required]

        public DateTime CreatedOn { get; set; }



        [CustomDisplayName("ReportType", "CustomReports.resx", "Report Type"), Column("ReportType")]
        [Required]

        public string ReportType { get; set; }



        [CustomDisplayName("Description", "CustomReports.resx", "Description"), Column("Description")]

        public string Description { get; set; }



        [CustomDisplayName("EntityName", "CustomReports.resx", "Entity Name"), Column("EntityName")]

        public string EntityName { get; set; }



        [CustomDisplayName("ResultProperty", "CustomReports.resx", "Result Property"), Column("ResultProperty")]

        public string ResultProperty { get; set; }



        [CustomDisplayName("ColumnOrder", "CustomReports.resx", "Column Order"), Column("ColumnOrder")]

        public Nullable<Int32> ColumnOrder { get; set; }



        [CustomDisplayName("OrderBy", "CustomReports.resx", "Order By"), Column("OrderBy")]

        public string OrderBy { get; set; }



        [CustomDisplayName("GroupBy", "CustomReports.resx", "Group By"), Column("GroupBy")]

        public Boolean? GroupBy { get; set; }



        [CustomDisplayName("CrossTabRow", "CustomReports.resx", "Cross Tab Row"), Column("CrossTabRow")]

        public string CrossTabRow { get; set; }



        [CustomDisplayName("CrossTabColumn", "CustomReports.resx", "Cross Tab Column"), Column("CrossTabColumn")]

        public string CrossTabColumn { get; set; }



        [CustomDisplayName("AggregateEntity", "CustomReports.resx", "Aggregate Entity"), Column("AggregateEntity")]

        public string AggregateEntity { get; set; }



        [CustomDisplayName("AggregateProperty", "CustomReports.resx", "Aggregate Property"), Column("AggregateProperty")]

        public string AggregateProperty { get; set; }



        [CustomDisplayName("AggregateFunction", "CustomReports.resx", "Aggregate Function"), Column("AggregateFunction")]

        public string AggregateFunction { get; set; }



        [CustomDisplayName("FilterProperty", "CustomReports.resx", "Filter Property"), Column("FilterProperty")]

        public string FilterProperty { get; set; }



        [CustomDisplayName("FilterCondition", "CustomReports.resx", "Filter Condition"), Column("FilterCondition")]

        public string FilterCondition { get; set; }



        [CustomDisplayName("FilterType", "CustomReports.resx", "Filter Type"), Column("FilterType")]

        public string FilterType { get; set; }



        [CustomDisplayName("FilterValue", "CustomReports.resx", "Filter Value"), Column("FilterValue")]

        public string FilterValue { get; set; }



        [CustomDisplayName("SelectValueFromList", "CustomReports.resx", "Select Value From List"), Column("SelectValueFromList")]

        public string SelectValueFromList { get; set; }



        [CustomDisplayName("SelectProperty", "CustomReports.resx", "Select Property"), Column("SelectProperty")]

        public string SelectProperty { get; set; }



        [CustomDisplayName("RelatedEntity", "CustomReports.resx", "Related Entity"), Column("RelatedEntity")]

        public string RelatedEntity { get; set; }



        [CustomDisplayName("ForeignKeyEntity", "CustomReports.resx", "ForeignKey Entity"), Column("ForeignKeyEntity")]

        public string ForeignKeyEntity { get; set; }



        [CustomDisplayName("RelationName", "CustomReports.resx", "Relation Name"), Column("RelationName")]

        public string RelationName { get; set; }

        [CustomDisplayName("CreatedByUserID", "CustomReports.resx", "Created By"), Column("CreatedByUserID")]
        public string CreatedByUserID { get; set; }
        public virtual IdentityUser createdbyuser { get; set; }
        public string getDisplayValue()
        {
            try
            {
                var dispValue = (this.ReportName != null ? Convert.ToString(this.ReportName) + "-" : Convert.ToString(this.ReportName)) + (this.ReportType != null ? Convert.ToString(this.ReportType) + "-" : Convert.ToString(this.ReportType));
                dispValue = dispValue != null ? dispValue.TrimEnd("-".ToCharArray()) : "";
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
                var dispValue = (this.ReportName != null ? Convert.ToString(this.ReportName) + "-" : Convert.ToString(this.ReportName)) + (this.ReportType != null ? Convert.ToString(this.ReportType) + "-" : Convert.ToString(this.ReportType));
                return dispValue != null ? dispValue.TrimEnd("-".ToCharArray()) : "";
            }
            catch { return ""; }
        }
        public void setCalculation() { try { } catch { } }
    }
}

