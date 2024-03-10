namespace TagScanner.Menus
{
    using System;
    using System.Collections.Generic;
    using TagScanner.Terms;

    public class OperationEventArgs : EventArgs
    {
        public OperationEventArgs(KeyValuePair<Operator, OperatorInfo> operation) : base() { Operation = operation; }

        public KeyValuePair<Operator, OperatorInfo> Operation { get; set; }
    }
}
