using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
namespace GeneratorBase.MVC.Models
{
    public class MandatoryDropdown
    {
        public static ValidationResult ValidateDropdown(long? id, ValidationContext validationContext)
        {
            //if (!id.HasValue)
            //{
            //    var displayName = "";
            //    var attributes = validationContext.ObjectType.GetProperty(validationContext.MemberName).GetCustomAttributes(typeof(DisplayNameAttribute), true);
            //    if (attributes != null)
            //        displayName = (attributes[0] as DisplayNameAttribute).DisplayName;
            //    else
            //        displayName = validationContext.DisplayName;
            //    return new ValidationResult(
            //        displayName + " Field is required.");
            //}
            //else
                return ValidationResult.Success;
        }
    }
    public abstract class Entity : IEntity
    {
        [Key]
        public long Id { get; set; }
        [Timestamp]
        [ConcurrencyCheck]
        public byte[] ConcurrencyKey { get; set; }
        [NotMapped]
        public string m_DisplayValue = "";
        [DisplayName("DisplayValue")]
        public string DisplayValue
        {
            get { return getDisplayValueModel(); }
            set { value = m_DisplayValue; }
        }
        [NotMapped]
        public TimeZoneInfo m_Timezone
        {
            get
            {
                var result = "";
                if (HttpContext.Current != null)
                {
                    var timeZoneCookie = HttpContext.Current.Request.Cookies["_timezone"];
                    if (timeZoneCookie != null)
                    {
                        result = Convert.ToString(timeZoneCookie.Value);
                    }
                }
               return  TimeZoneInfo.FindSystemTimeZoneById(result);
            }
            set { }
        }
        public virtual string getDisplayValueModel() { return m_DisplayValue; }
    }
}