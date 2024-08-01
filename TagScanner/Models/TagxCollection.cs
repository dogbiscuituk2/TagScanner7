namespace TagScanner.Models
{
    using System.Collections.Generic;

    public class TagxCollection
    {
        #region Constructors

        public TagxCollection() => _tags = new List<Tagx>();
        public TagxCollection(IEnumerable<Tagx> tags) : this() => _tags.AddRange(tags);

        #endregion

        #region Public Properties

        public IEnumerable<Tagx> Tags => GetTags();

        #endregion

        #region Private Fields

        private List<Tagx> _tags;

        #endregion

        #region Private Methods

        private IEnumerable<Tagx> GetTags()
        {
            foreach (var tag in _tags)
                yield return tag;
        }

        #endregion
    }
}
