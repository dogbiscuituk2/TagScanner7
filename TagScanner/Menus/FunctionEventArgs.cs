namespace TagScanner.Menus
{
    using System;

    public class FunctionEventArgs : EventArgs
    {
        public FunctionEventArgs(string key) { Key = key; }

        public string Key { get; private set; }
    }
}
