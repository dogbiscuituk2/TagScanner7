namespace TagScanner.Menus
{
    using System;
    using System.Collections.Generic;
    using TagScanner.Terms;

    public class OperationEventArgs : EventArgs
    {
        public OperationEventArgs(KeyValuePair<Op, OpInfo> operation) : base() { Operation = operation; }

        public KeyValuePair<Op, OpInfo> Operation { get; set; }
    }
}
