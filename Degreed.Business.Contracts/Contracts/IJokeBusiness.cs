using Degreed.Domain.Models;

namespace Business.Contracts.Contracts
{
    public interface IJokeBusiness : IBaseBusinessFactory
    {
        JokeModel GetRandomJoke();

        JokesModels GetJokesByTerm(string term);
    }
}
