namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using Controllers;
    using Terms;

    public partial class Test
    {
        public void TestTerm(Term term)
        {
            TestTerm(term, StreamFormat.Binary);
            TestTerm(term, StreamFormat.Json);
            TestTerm(term, StreamFormat.Xml);
            if (!(term is TermList termList)) return;
            for (var index = 0; index < termList.Operands.Count; index++)
            {
                var start = termList.Start(index);
                var subTerm = termList.Operands[index];
                var length = subTerm.Length;
                Assert.AreEqual(expected: subTerm.ToString(), actual: termList.ToString().Substring(start, length));
                var range = termList.CharacterRanges[2 * index + 1];
                Assert.AreEqual(expected: start, actual: range.First);
                Assert.AreEqual(expected: length, actual: range.Length);
                TestTerm(subTerm);
            }
        }

        public void TestTerm(Term term, StreamFormat format)
        {
            var filter = new Filter();
            filter.Terms.Add(term);
            var text = filter.ToString();
            using (var stream = new MemoryStream())
            {
                StreamController.SaveToStream(stream, filter, format);
                filter = new Filter();
                Assert.AreNotEqual(notExpected: text, actual: filter?.ToString());
                stream.Seek(0, SeekOrigin.Begin);
                filter = (Filter)StreamController.LoadFromStream(stream, typeof(Filter), format);
                Assert.AreEqual(expected: text, actual: filter?.ToString());
            }
        }
    }
}
