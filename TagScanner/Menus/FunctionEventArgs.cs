namespace TagScanner.Menus
{
    using System;
    using Terms;

    public class FunctionEventArgs : EventArgs
    {
        public FunctionEventArgs(Fn fn) { Fn = fn; }

        public Fn Fn { get; private set; }
    }
}
