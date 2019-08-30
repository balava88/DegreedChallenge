using Data.Contracts.Contracts;
using Degreed.Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Specialized;

namespace Data.Repositories
{
    public class JokeRepository : IJokeRepository
    {

        private readonly RestClient _client;
        private readonly string apiUrl;
        private readonly string jokesLimit;

        public JokeRepository(NameValueCollection appSettings)
        {
            jokesLimit = appSettings["JokesLimit"];
            apiUrl = appSettings["JokesApiBaseUrl"];
            _client = new RestClient(apiUrl);
        }

        public JokesModels GetJokesByTerm(string term)
        {
            var request = new RestRequest($"{apiUrl}/search?term={term}&limit={jokesLimit}",Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = _client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Some Error Occured {response.Content}" +
                    $"{response.StatusDescription}");
            }
            return JsonConvert.DeserializeObject<JokesModels>(response.Content);
        }

        public JokeModel GetRandomJoke()
        {           
            var request = new RestRequest($"{apiUrl}",Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = _client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Some Error Occured {response.Content}" +
                    $"{response.StatusDescription}");
            }
            return JsonConvert.DeserializeObject<JokeModel>(response.Content);
        }
    }
}
