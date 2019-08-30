using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Highlighters
{
    public class EmphasizerHighlighter : IHighlighter
    {
        public string HighlightFormat { get => @"<em>$1<em>"; set { this.HighlightFormat = @"<em>$1<em>"; } }
    }
}
