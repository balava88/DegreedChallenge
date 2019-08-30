using Degreed.Domain.Enums;
using Degreed.Shared.Contracts;
using System.Text.RegularExpressions;

namespace Degreed.Shared.Utilities
{
    public class JokesHelper : IJokesHelper
    {
        /// <summary>
        /// Highlights the specified text 
        /// </summary>
        /// <param name="text">Text that is going to be checked</param>
        /// <param name="textToBeHighlighted">Word to be highlighted</param>
        /// <param name="highLighter">HighLigter to be used</param>
        /// <returns>Text with the word  enclosed by the highlight</returns>
        public string HighLight(string text, string textToBeHighlighted, IHighlighter highLighter)
        {
            if (string.IsNullOrEmpty(textToBeHighlighted) || string.IsNullOrEmpty(text))
                return text;

            var regex = @"(" + textToBeHighlighted + @")";
            var result = Regex.Replace(text, regex, highLighter.HighlightFormat, RegexOptions.IgnoreCase);
            return result;
        }

        /// <summary>
        /// Gets the length of the joke by words
        /// </summary>
        /// <param name="jokeText">Joke text</param>
        /// <returns>Classification of how many words the joke contains (short for less or 10 words, medium for more than 10 and less than 21, long for more than 20 words)</returns>
        public JokeLengthClassification GetJokeLength(string jokeText)
        {
            int wordCount = GetWordCount(jokeText);

            if (wordCount <= 10 && wordCount >= 0)
                return JokeLengthClassification.Short;
            else if (wordCount <= 20 && wordCount > 10)
                return JokeLengthClassification.Medium;
            else
                return JokeLengthClassification.Long;

        }

        /// <summary>
        /// Counts words of a text
        /// </summary>
        /// <param name="text">Text that is going to be used to count words</param>
        /// <returns>Number of words in the text</returns>
        public int GetWordCount(string text)
        {
            int wordCount = 0, index = 0;

            if (!string.IsNullOrEmpty(text))
            {
                while (index < text.Length && char.IsWhiteSpace(text[index]))
                    index++;
                while (index < text.Length)
                {
                    while (index < text.Length && !char.IsWhiteSpace(text[index]))
                        index++;
                    wordCount++;
                    while (index < text.Length && char.IsWhiteSpace(text[index]))
                        index++;
                }
            }

            return wordCount;
        }
    }
}
