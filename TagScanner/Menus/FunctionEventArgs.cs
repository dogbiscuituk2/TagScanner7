namespace TagScanner.Menus
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class FunctionEventArgs : EventArgs
    {
        public FunctionEventArgs(KeyValuePair<string, MethodInfo> method) : base() { Method = method; }

        public KeyValuePair<string, MethodInfo> Method { get; set; }
    }
}
