using Degreed.Shared.Contracts;

namespace Degreed.Shared.Highlighters
{
    public class EmphasizeHighlighter : IHighlighter
    {
        public string HighlightFormat { get => @"<em>$1</em>"; }
    }
}
