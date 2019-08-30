using Business.Contracts.Contracts;
using Data.Contracts.Contracts;
using Degreed.Domain.Models;
using Degreed.Shared.Contracts;
using Degreed.Shared.Utilities;

namespace Degreed.Business
{
    public class JokeBusiness : IJokeBusiness
    {
        private readonly IRepositoryFactory _repFactory;
        private readonly IJokesHelper _helper;


        public JokeBusiness(IRepositoryFactory repFactory, JokesHelper helper)
        {
            _repFactory = repFactory;            
            _helper = helper;
        }

        /// <summary>
        /// Gets a random joke
        /// </summary>
        /// <returns>Single random joke</returns>
        public JokeModel GetRandomJoke()
        {
            var jokeRep = _repFactory.GetDataRepository<IJokeRepository>();
            return jokeRep.GetRandomJoke();
        }

        /// <summary>
        /// Get jokes by specified search term
        /// </summary>
        /// <param name="term">Search term</param>
        /// <returns>Jokes that match the search term with the search term hihglighted and a joke length that specifies the length of the joke</returns>
        public JokesModels GetJokesByTerm(string term)
        {
            var jokeRep = _repFactory.GetDataRepository<IJokeRepository>();

            JokesModels toReturn = jokeRep.GetJokesByTerm(term);

            if (toReturn.Results != null )
            {
                foreach (var item in toReturn.Results)
                {
                    item.JokeLength = _helper.GetJokeLength(item.Joke);
                }
            }          

            return toReturn;
        }


    }
}
