namespace TagScanner.Controllers.Mru
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

        public void RegistryRead(ComboBox comboBox)
        {
            var items = comboBox.Items;
            items.Clear();
            items.AddRange(ReadValues().ToArray());
        }

        public void RegistryWrite(ComboBox comboBox) => WriteValues(comboBox.Items.Cast<string>());

        public void UpdateItems(ComboBox comboBox)
        {
            var filter = comboBox.Text;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                var filters = comboBox.Items;
                if (filters.Contains(filter))
                    filters.Remove(filter);
                filters.Insert(0, filter);
            }
            RegistryWrite(comboBox);
        }

        private IEnumerable<string> ReadValues()
        {
            string[] strings = Array.Empty<string>();
            if (TryReadKey(out Win32.RegistryKey key))
            {
                strings = key?.GetValue("Filter")?.ToString()?.TextToStrings() ?? Array.Empty<string>(); ;
                key?.Close();
            }
            return strings;
        }

        private void WriteValues(IEnumerable<string> values) => AddItem("Filter", values.StringsToText());
    }
}
