using Degreed.Domain.Enums;
using Degreed.Shared.Contracts;

namespace Degreed.Shared.Utilities
{
    public interface IJokesHelper
    {
        JokeLengthClassification GetJokeLength(string jokeText);
        int GetWordCount(string text);
        string HighLight(string text, string textToBeHighlighted, IHighlighter highLighter);
    }
}