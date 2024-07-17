namespace TagScanner.Parsing
{
    using System;
    using System.Linq;
    using Models;
    using Terms;
    using Utils;

    public static class Fixer
    {
        public static Term Fix(this Term term, bool caseSensitive = false)
        {
            if (!(term is Compound compound))
                return term;
            var operands = compound.Operands;
            var count = operands.Count;
            foreach (var operand in operands.OfType<Compound>())
                Fix(operand, caseSensitive);
            if (compound is Function function)
                FixFunction(function);
            else if (compound is Operation operation)
                FixOperation(operation);
            return compound;

            void FixFunction(Function f)
            {
                var fn = f.Fn;
                var operandTypes = fn.OperandTypes();
                for (var index = count; index < operandTypes.Count(); index++)
                    operands.Add(new Default(operandTypes[index]));
                var fix = fn.IndexOfParams();
                if (fix >= 0)
                    CastAll(fix, typeof(object));
                switch (fn)
                {
                    case Fn.Compare:
                    case Fn.Contains:
                    case Fn.ContainsX:
                    case Fn.Count:
                    case Fn.CountX:
                    case Fn.EndsWith:
                    case Fn.EndsWithX:
                    case Fn.Equals:
                    case Fn.EqualsX:
                    case Fn.IndexOf:
                    case Fn.IndexOfX:
                    case Fn.LastIndexOf:
                    case Fn.LastIndexOfX:
                    case Fn.StartsWith:
                    case Fn.StartsWithX:
                        CheckCase(2);
                        break;

                    case Fn.Replace:
                    case Fn.ReplaceX:
                        CheckCase(3);
                        break;

                    case Fn.Max:
                    case Fn.Min:
                    case Fn.Pow:
                        Cast(1, typeof(double));
                        goto case Fn.Round;
                    case Fn.Round:
                    case Fn.Sign:
                        Cast(0, typeof(double));
                        break;

                    case Fn.ToString:
                        Cast(0, typeof(object));
                        break;
                }
            }

            void FixOperation(Operation operation)
            {
                var op = operation.Op;
                if (op.IsAssignment())
                {
                    if (count < 2)
                        throw new ArgumentException("Missing argument(s)");
                    var type = operands[count - 1].ResultType;
                    foreach (var arg in operands.Take(count - 1))
                    {
                        if (!(arg is Variable variable))
                            throw new ArgumentException("LValue required");
                        variable.ResultType = type;
                    }
                    return;
                }
                var first = op == Op.Else ? 1 : 0;
                var commonType = Utility.GetCompatibleType(operands.Skip(first).Select(p => p.ResultType).ToArray());
                if (commonType == typeof(Logical))
                    commonType = typeof(bool);
                var adjustCase = !caseSensitive && op.CanChain();
                for (var index = first; index < count; index++)
                {
                    var operand = operands[index];
                    if (operand.ResultType != commonType)
                        operand = new Cast(commonType, operand);
                    if (adjustCase)
                    {
                        if (operand.ResultType == typeof(string) && !(operand is Function f && f.Fn == Fn.Upper))
                            operand = operand is Constant<string> constantString
                                ? new Constant<string>(constantString.Value.ToUpperInvariant())
                                : (Term)new Function(Fn.Upper, operand);
                    }
                    operands[index] = operand;
                }
            }

            void Cast(int index, Type type)
            {
                var operand = operands[index];
                if (operand.ResultType != type)
                    operands[index] = new Cast(type, operand);
            }

            void CastAll(int first, Type type)
            {
                for (var index = first; index < operands.Count; index++)
                    Cast(index, type);
            }

            void CheckCase(int index)
            {
                if (operands[index] is Default)
                    operands[index] = caseSensitive;
            }
        }
    }
}
