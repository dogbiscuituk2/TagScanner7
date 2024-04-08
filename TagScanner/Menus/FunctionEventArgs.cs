namespace TagScanner.Menus
{
    using System;
    using TagScanner.Terms;

    public class FunctionEventArgs : EventArgs
    {
        public FunctionEventArgs(Fn fn) { Fn = fn; }

        public Fn Fn { get; private set; }
    }
}
