using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC001.ViewModels
{
    public class ResultList<T>
    {
        [JsonProperty("queryOptions")]
        public QueryOptions QueryOptions { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }

    }
}