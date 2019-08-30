using Degreed.Shared.Contracts;

namespace Degreed.Shared.Highlighters
{
    public class CustomHighlighter : IHighlighter
    {
        public string HighlightFormat { get { return @"<b><mark>$1</mark></b>"; } }
    }
}
