using Degreed.Shared.Contracts;

namespace Degreed.Shared.Highlighters
{
    public class MarkHighlighter: IHighlighter
    {
        public string HighlightFormat { get { return @"<mark>$1</mark>"; } }
    }
}
