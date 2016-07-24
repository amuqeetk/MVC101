using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC001.Models
{
    public class Author
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        [Required]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        [Required]
        public string LastName { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("books")]
        public ICollection<Book> Books { get; set; }

    }
}