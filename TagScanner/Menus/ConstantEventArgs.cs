namespace TagScanner.Menus
{
    using System;

    public class ConstantEventArgs : EventArgs
    {
        public ConstantEventArgs(int value) { Value = value; }

        public int Value { get; private set; }
    }
}