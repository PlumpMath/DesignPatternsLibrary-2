using System.Collections.Generic;

namespace AdapterPattern
{
    public interface IDataPatternRendererAdapter
    {
        string ListPatterns(IEnumerable<Pattern> patterns);
    }
}
