using System;
using System.Collections.Generic;
using System.Linq;
using AdapterPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterPatternTest
{
    [TestClass]
    public class PatternRendererTest
    {
        [TestMethod]
        public void ShouldRenderTwoPatterns()
        {
            var myRenderer = new PatternRenderer();

            var myList = new List<Pattern>
            {
                new Pattern {Id = 1, Name = "Pattern One", Description = "Pattern One Description"},
                new Pattern {Id = 2, Name = "Pattern Two", Description = "Pattern Two Description"}
            };

            var result = myRenderer.ListPatterns(myList);

            Console.Write(result);

            const int headerLines = 2;
            var expectedNumberOfLines = myList.Count + headerLines;

            var numberOfLines = result.Count(c => c == '\n');
            Assert.AreEqual(expectedNumberOfLines, numberOfLines);
        }
    }
}
