namespace TagScanner.Controllers.Mru
{
    using System;
    using System.Collections.Generic;
    using Utils;
    using Win32 = Microsoft.Win32;

    public class MruFilterController : MruController
    {
        public MruFilterController(Controller parent) : base(parent, "FilterMRU") { }

        public IEnumerable<string> ReadValues()
        {
            string[] strings = Array.Empty<string>();
            if (TryReadKey(out Win32.RegistryKey key))
            {
                strings = key.GetValue("Filter")?.ToString()?.TextToStrings() ?? Array.Empty<string>(); ;
                key.Close();
            }
            return strings;
        }

        public void WriteValues(IEnumerable<string> values) => AddItem("Filter", values.StringsToText());
    }
}
