using Degreed.Shared.Contracts;

namespace Degreed.Shared.Highlighters
{
    public class BoldHighlighter : IHighlighter
    {
        public string HighlightFormat { get { return @"<b>$1</b>"; } }
    }
}
