using System.Collections.Generic;

namespace AdapterPattern
{
    public class PatternRenderer
    {
        private readonly IDataPatternRendererAdapter _dataPatternRenderer;

        public PatternRenderer() : this(new DataPatternRendererAdapter()) { }

        public PatternRenderer(IDataPatternRendererAdapter dataPatternRenderer)
        {
            _dataPatternRenderer = dataPatternRenderer;
        }

        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            return _dataPatternRenderer.ListPatterns(patterns);
        }
    }
}
