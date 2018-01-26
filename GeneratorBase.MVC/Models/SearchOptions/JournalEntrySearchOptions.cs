using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace GeneratorBase.MVC.Models.SearchOptions
{
    public class JournalEntrySearchOptions : SearchOptionsBase
    {

        public long? recordid { get; set; }
        public string entityname { get; set; }
        public string propertyname { get; set; }
    }
}
