﻿namespace TagScanner.Controllers.Mru
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Win32 = Microsoft.Win32;
    using Utils;

    public class MruStringsController : MruController
    {
        public MruStringsController(Controller parent, string subKeyName) : base(parent, subKeyName) { }

        public void AddValue(string value) => RegistryWrite(new[] { value });

        public void RegistryRead(ComboBox.ObjectCollection items)
        {
            items.Clear();
            items.AddRange(ReadValues().ToArray());
        }

        private void RegistryWrite(ComboBox.ObjectCollection items) => RegistryWrite(items.Cast<string>());

        private void RegistryWrite(IEnumerable<string> values) =>
            WriteValues(values.Union(ReadValues()).Where(p => !string.IsNullOrWhiteSpace(p)));

        public void UpdateItems(ComboBox.ObjectCollection items, string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                if (items.Contains(item))
                    items.Remove(item);
                items.Insert(0, item);
            }
            RegistryWrite(items);
        }

        private IEnumerable<string> ReadValues()
        {
            string[] values = Array.Empty<string>();
            if (TryReadKey(out Win32.RegistryKey key))
            {
                values = key?.GetValue("Filter")?.ToString()?.TextToStrings() ?? Array.Empty<string>(); ;
                key?.Close();
            }
            return values;
        }

        private void WriteValues(IEnumerable<string> values) => AddItem("Filter", values.StringsToText());
    }
}
