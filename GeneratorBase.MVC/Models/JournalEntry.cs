using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;
namespace GeneratorBase.MVC.Models
{
    [Table("tbl_JournalEntry")]
    public class JournalEntry : Entity
    {
		
		[DisplayName("Entity Name")]
        public string EntityName { get; set; }
        [DisplayName("Entry Type")]
        public string Type { get; set; }
        [NotMapped]
        public DateTime m_DateTimeOfEntry { get; set; }
        [DisplayName("Entry DateTime")]
        public DateTime DateTimeOfEntry { get; set; }
        [DisplayName("Record Info")]
        public string RecordInfo { get; set; }
        [DisplayName("PropertyName")]
        public string PropertyName { get; set; }
        [DisplayName("OldValue")]
        public string OldValue { get; set; }
        [DisplayName("NewValue")]
        public string NewValue { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Record Id")]
        public long RecordId { get; set; }
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
        


        public void setDateTimeToUTC()
        {
            this.DateTimeOfEntry = DateTime.UtcNow; 
        }
        public override string getDisplayValueModel()
        {
            return this.EntityName + "-" + this.PropertyName;
        }
        public string getDisplayValue()
        {
            return this.EntityName + "-" + this.PropertyName;
        }
    }
}
