using Newtonsoft.Json;
using System.Collections.Generic;

namespace Degreed.Domain.Models
{
    public class JokesModels
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("next_page")]
        public int NextPage { get; set; }

        [JsonProperty("previous_page")]
        public int PreviousPage { get; set; }

        [JsonProperty("results")]
        public List<JokeModel> Results { get; set; }

        [JsonProperty("search_term")]
        public string SearchTerm { get; set; }

        [JsonProperty("total_jokes")]
        public int TotalJokes { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }


    }
}
