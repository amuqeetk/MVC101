using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC001.ViewModels
{
    public class QueryOptions
    {
        public QueryOptions()
        {
            CurrentPage = 1;
            PageSize = 5;


            SortField = "Id";
            SortOrder = SortOrder.ASC;
        }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("sortField")]
        public string SortField { get; set; }

        [JsonProperty("sortOrder")]
        public SortOrder SortOrder { get; set; }

        [JsonProperty("sort")]
        public string Sort
        {
            get
            {
                return string.Format("{0} {1}", SortField, SortOrder);
            }
        }
    }
}