﻿namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Core;
    using Models;
    using Terms;

    public class AutoCompleter : Controller
    {
        #region Constructor

        public AutoCompleter(Controller parent, params ToolStripComboBox[] controls) : base(parent) =>
            Array.ForEach(controls, p =>
            {
                p.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                p.AutoCompleteSource = AutoCompleteSource.CustomSource;
            });

        #endregion

        #region Public Methods

        public AutoCompleteStringCollection GetFilterAutoCompleteItems() => GetFieldList(0, Tag.JoinedPerformers, Tag.Album, Tag.Title);

        public AutoCompleteStringCollection GetFieldList(params Tag[] tags) => FieldLists[ValidateFieldList(tags)];

        /// <summary>
        /// Discard all field lists except that with key 0 (which is essentially a keyword list, unrelated to any tag).
        /// </summary>
        public void InvalidateFieldLists()
        {
            var tokens = FieldLists.ContainsKey("\0") ? FieldLists["\0"] : null;
            FieldLists.Clear();
            if (tokens != null)
                FieldLists.Add("\0", tokens);
        }

        #endregion

        #region Private Fields

        private readonly Dictionary<string, AutoCompleteStringCollection> FieldLists = new Dictionary<string, AutoCompleteStringCollection>();

        #endregion

        #region Private Methods

        private static string MakeKey(params Tag[] tags) => new string(tags.Select(p => (char)p).OrderBy(p => p).ToArray());

        private string ValidateFieldList(params Tag[] tags)
        {
            var key = MakeKey(tags);
            if (!FieldLists.ContainsKey(key))
            {
                Array.ForEach(tags, tag =>
                {
                    var subKey = MakeKey(tag);
                    if (!FieldLists.ContainsKey(subKey))
                    {
                        Type type;
                        IEnumerable<object> values;
                        if (tag == 0)
                        {
                            type = typeof(string);
                            values = Term.Booleans
                                .Union(Tags.FieldNames)
                                .Union(Functors.FunctionNames)
                                .Union(Types.Names)
                                .Union(Keywords.All);
                        }
                        else
                        {
                            type = tag.TagToTagInfo().Type;
                            values = MainModel.Tracks.Select(p => p.GetPropertyValue(tag));
                        }
                        var list = new AutoCompleteStringCollection();
                        list.AddRange((
                            type == typeof(string) ? values.Cast<string>() :
                            type == typeof(string[]) ? values.Cast<string[]>().SelectMany(p => p) :
                            type == typeof(Picture[]) ? values.Cast<Picture[]>().SelectMany(p => p).Select(q => q.ToString()) :
                            values.Select(p => p.ToString())
                            ).ToArray());
                        FieldLists.Add(subKey, list);
                    }
                });
                if (!FieldLists.ContainsKey(key))
                {
                    var result = new AutoCompleteStringCollection();
                    Array.ForEach(tags, tag =>
                    {
                        var list = FieldLists[MakeKey(tag)];
                        var items = new string[list.Count];
                        list.CopyTo(items, 0);
                        result.AddRange(items);
                    });
                    FieldLists.Add(key, result);
                }
            }
            return key;
        }

        #endregion
    }
}
