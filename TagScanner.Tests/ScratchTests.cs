namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Models;
    using Terms;
    using System.Diagnostics;

    [TestClass]
    public class ScratchTests : BaseTests
    {
        [TestMethod]
        public void ScratchTest01()
        {
            IEnumerable<Track> collection = new List<Track>();
            Debug.WriteLine(collection);

            var parser = new Parser();
            var text = "Selection";
            var term = parser.Parse(text, caseSensitive: true);
            return;
        }
    }
}
