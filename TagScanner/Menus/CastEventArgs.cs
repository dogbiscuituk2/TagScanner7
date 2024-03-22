namespace TagScanner.Menus
{
    using System;

    public class CastEventArgs : EventArgs
    {
        public CastEventArgs(Type type) { Type = type; }

        public Type Type { get; private set; }
    }
}
