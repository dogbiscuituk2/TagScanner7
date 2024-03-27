namespace TagScanner.Terms
{
    using Microsoft.CodeAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Utils;

    public class Parser
    {
        #region Constructor

        public Parser(string text)
        {
        }

        #endregion

        #region Private Fields

        private readonly Stack<Term> OperandStack = new Stack<Term>();
        private readonly Stack<string> OperatorStack = new Stack<string>();

        #endregion

        #region Private Methods

        private void ParseExpression()
        {
            do
            {
                ParseTerm();
            } while (true);
        }

        private void ParseTerm()
        {

        }

        #endregion
    }
}
