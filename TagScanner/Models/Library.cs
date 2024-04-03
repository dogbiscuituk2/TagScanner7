namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using Terms;

    [Serializable]
    public class Library
    {

        private Filter _filter = new Filter();
        public Filter Filter
        {
            get => _filter;
            set => _filter = value;
        }
        private List<string> _folders = new List<string>();
        public List<string> Folders
        {
            get => _folders;
            set => _folders = value;
        }

        private List<Work> _works = new List<Work>();
        public List<Work> Works
        {
            get => _works;
            set => _works = value;
        }

        public void Clear()
        {
            Filter.Clear();
            Folders.Clear();
            Works.Clear();
        }
    }
}
