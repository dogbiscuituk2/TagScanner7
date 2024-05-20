namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class AutoCompleteController : Controller
    {
        public AutoCompleteController(Controller parent) : base(parent) { }

        public string[] GetList(params Tag[] tags)
        {
            IEnumerable<string> result = new List<string>();
            foreach (var tag in tags)
            {
                if (!Lists.ContainsKey(tag))
                    Lists.Add(tag, MainModel.Tracks.Select(p => p.GetPropertyValue(tag).ToString()).Distinct().ToArray());
                result = result.Union(Lists[tag]);
            }
            return result.ToArray();
        }

        public void Invalidate() => Lists.Clear();

        private Dictionary<Tag, string[]> Lists = new Dictionary<Tag, string[]>();
    }
}
