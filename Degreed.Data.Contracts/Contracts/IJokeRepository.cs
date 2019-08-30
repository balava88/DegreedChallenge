using Degreed.Domain.Models;

namespace Data.Contracts.Contracts
{
    public interface IJokeRepository : IBaseRepositoryFactory
    {
        JokeModel GetRandomJoke();
        JokesModels GetJokesByTerm(string term);
    }
}
