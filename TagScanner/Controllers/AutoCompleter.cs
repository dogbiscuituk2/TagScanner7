namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    public class AutoCompleter : Controller
    {
        #region Constructor

        public AutoCompleter(Controller parent, params Control[] controls) : base(parent)
        {
            foreach (var control in controls)
                if (control is ComboBox comboBox)
                    Init(comboBox);
                else if (control is TextBox textBox)
                    Init(textBox);
        }

        #endregion

        #region Public Methods

        public AutoCompleteStringCollection GetFieldList(params Tag[] tags) => FieldLists[ValidateFieldList(tags)];

        public void Init(ComboBox comboBox)
        {
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void Init(TextBox textBox)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void InvalidateFieldLists() => FieldLists.Clear();
        public void SetList(ComboBox comboBox, IEnumerable<string> items) => comboBox.AutoCompleteCustomSource = MakeList(items);
        public void SetList(TextBox textBox, IEnumerable<string> items) => textBox.AutoCompleteCustomSource = MakeList(items);

        #endregion

        #region Private Fields

        private readonly Dictionary<string, AutoCompleteStringCollection> FieldLists = new Dictionary<string, AutoCompleteStringCollection>();

        #endregion

        #region Private Methods

        private string MakeKey(params Tag[] tags) =>
            new string(
                tags.Select(p => (char)p)
                .OrderBy(p => p)
                .ToArray());

        private AutoCompleteStringCollection MakeList(IEnumerable<string> items)
        {
            var list = new AutoCompleteStringCollection();
            list.AddRange(items.ToArray());
            return list;
        }

        private string ValidateFieldList(params Tag[] tags)
        {
            var key = MakeKey(tags);
            if (!FieldLists.ContainsKey(key))
            {
                foreach (var tag in tags)
                {
                    var subKey = MakeKey(tag);
                    if (!FieldLists.ContainsKey(subKey))
                    {
                        var type = tag.TagToTagInfo().Type;
                        var values = MainModel.Tracks.Select(p => p.GetPropertyValue(tag));
                        var list = new AutoCompleteStringCollection();
                        list.AddRange((
                            type == typeof(string) ? values.Cast<string>() :
                            type == typeof(string[]) ? values.Cast<string[]>().SelectMany(p => p) :
                            type == typeof(Picture[]) ? values.Cast<Picture[]>().SelectMany(p => p).Select(q => q.ToString()) :
                            values.Select(p => p.ToString())
                            ).ToArray());
                        FieldLists.Add(subKey, list);
                    }
                }
                if (!FieldLists.ContainsKey(key))
                {
                    var result = new AutoCompleteStringCollection();
                    foreach (var tag in tags)
                    {
                        var list = FieldLists[MakeKey(tag)];
                        var items = new string[list.Count];
                        list.CopyTo(items, 0);
                        result.AddRange(items);
                    }
                    FieldLists.Add(key, result);
                }
            }
            return key;
        }

        #endregion
    }
}
