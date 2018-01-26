using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneratorBase.MVC.Models
{
    public class PaginatedList<T>
    {
        [JsonProperty("results")]
        public IEnumerable<T> Results { get; set; }

        [JsonProperty("currentPage")]
        public long CurrentPage { get; set; }

        [JsonProperty("totalPages")]
        public long TotalPages { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("pagination")]
        public PaginationInformation Pagination { get; set; }
    }

    public class PaginationInformation
    {
        [JsonProperty("more")]
        public bool More { get; set; }
    }
}