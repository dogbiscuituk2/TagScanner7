namespace TagScanner.Menus
{
    using System;
    using Terms;

    public class OperationEventArgs : EventArgs
    {
        public OperationEventArgs(Op op) { Op = op; }

        public Op Op { get; set; }
    }
}
