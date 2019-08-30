using Business.Contracts.Contracts;
using Degreed.Domain.Models;
using Degreed.WebApi.Core;
using System.Web.Http;
using System.Web.Http.Description;

namespace Degreed.WebApi.Controllers
{
    /// <summary>
    /// Jokes API
    /// </summary>
    [RoutePrefix("api/Jokes")]
    public class JokesController : ApiControllerBase
    {
        private readonly IBusinessFactory _businessFactory;

        /// <summary>
        /// Constructor of the controller
        /// </summary>
        /// <param name="businessFactory"></param>
        public JokesController(IBusinessFactory businessFactory)
        {
            _businessFactory = businessFactory;
        }

        /// <summary>
        /// Gets a random joke
        /// </summary>
        /// <returns>Single random joke</returns>
        [HttpGet]
        [Route("RandomJoke")]
        [ResponseType(typeof(JokeModel))]
        public IHttpActionResult RandomJoke()
        {
            return GetHttpResponse(() =>
            {
                var jokeService = _businessFactory.GetBusinessClass<IJokeBusiness>();
                var joke = jokeService.GetRandomJoke();
                if (joke.Joke != null)
                {
                    return Ok(joke);
                }
                return NotFound();
            });
        }

        
        /// <summary>
        /// Gets a list of jokes filtered by the search term
        /// </summary>
        /// <param name="term">Search term</param>
        /// <returns>Jokes that match the search term with the search term hihglighted and a joke length that specifies the length of the joke</returns>
        [HttpGet]
        [Route("JokesByTerm")]
        [ResponseType(typeof(JokesModels))]
        [HighlightSearch]
        public IHttpActionResult JokesByTerm(string term)
        {
            return GetHttpResponse(() =>
            {
                var jokeService = _businessFactory.GetBusinessClass<IJokeBusiness>();
                var jokeList = jokeService.GetJokesByTerm(term);
                if (jokeList.Results.Count > 0)
                {
                    return Ok(jokeList);
                }
                return NotFound();
            });
        }

    }
}
