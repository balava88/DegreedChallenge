using Degreed.Domain.Enums;
using Newtonsoft.Json;

namespace Degreed.Domain.Models
{
    public class JokeModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("joke")]
        public string Joke { get; set; }

        public JokeLengthClassification JokeLength { get; set; }
    }
}
