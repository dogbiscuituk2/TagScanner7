namespace TagScanner.Menus
{
    using System;
    using System.Collections.Generic;
    using Terms;

    public class OperationEventArgs : EventArgs
    {
        public OperationEventArgs(KeyValuePair<Op, OpInfo> operation)
        {
            Operation = operation;
        }

        public KeyValuePair<Op, OpInfo> Operation { get; set; }
    }
}
