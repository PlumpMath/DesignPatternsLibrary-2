using System;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using AdapterPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterPatternTest
{
    [TestClass]
    public class DataRendererTest
    {
        [TestMethod]
        public void ShouldRenderOneRowGivenStubDataAdapter()
        {
            const int expectedNumberOfLines = 3;
            var myRenderer = new DataRenderer(new StubDbAdapter());

            var writer = new StringWriter();
            myRenderer.Render(writer);

            var result = writer.ToString();
            Console.WriteLine(result);

            var numberOfLines = result.Count(r => r == '\n');
            Assert.AreEqual(expectedNumberOfLines, numberOfLines);
        }

        [TestMethod]
        public void ShouldRenderTwoRowsGivenOleDbDataAdapter()
        {
            const int expectedNumberOfLines = 4;
            
            var adapter = new OleDbDataAdapter
            {
                SelectCommand = new OleDbCommand("SELECT * FROM Pattern")
                {
                    Connection =
                        new OleDbConnection(
                            @"Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5;Data Source=AdapterSampleDb.sdf")
                }
            };

            var myRenderer = new DataRenderer(adapter);

            var writer = new StringWriter();
            myRenderer.Render(writer);

            var result = writer.ToString();
            Console.WriteLine(result);

            var numberOfLines = result.Count(r => r == '\n');
            Assert.AreEqual(expectedNumberOfLines, numberOfLines);
        }
    }
}
