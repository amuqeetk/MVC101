using Newtonsoft.Json;

namespace MVC001.ViewModels
{
    public class AuthorViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }
    }
}