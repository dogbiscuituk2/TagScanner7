namespace TagScanner.Models
{
    using System;
    using Terms;

    public class Filter : IModel
    {
        public Filter() => Clear();

        public bool Modified { get; set; }

        private Conjunction _root;
        public Conjunction Root
        {
            get => _root;
            set
            {
                _root = value;
                _predicate = null;
            }
        }

        private Func<Work, bool> _predicate = null;
        public Func<Work, bool> Predicate => _predicate ?? (_predicate = Root?.Predicate);

        public void Add(Term term) => Root.Add(term);

        public void Clear()
        {
            _root = new Conjunction();
            _root.Operands.Clear();
        }
    }
}
