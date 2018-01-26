using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneratorBase.MVC.Models.SearchOptions
{
    public class SearchOptionsBase
    {
        public string Search { get; set; }
        private bool? _DeepSearch;
        public bool? DeepSearch
        {
            get { return _DeepSearch ?? false; }
            set { _DeepSearch = value; }
        }
        // public bool? DeepSearch { get; set; } = false;
        public string Order { get; set; }
        private bool? _Ascending;
        public bool? Ascending
        {
            get { return _Ascending ?? false; }
            set { _Ascending = value; }
        }
        // public bool? Ascending { get; set; } = true;
        private int? _Page;
        public int? Page
        {
            get { return _Page ?? 1; }
            set { _Page = value; }
        }
        // public int? Page { get; set; } = 1;
        public string HostingEntity { get; set; }
        public long? HostingEntityID { get; set; }
        public string AssociatedType { get; set; }

        public string FilterCondition { get; set; }
        public string SortOrder { get; set; }
    }
}