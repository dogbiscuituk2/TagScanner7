namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using TagScanner.Terms;

    public partial class Test
    {
        #region Static functions of no parameters.

        [TestMethod]
        [DataRow("Regex.get_CacheSize()", typeof(int))]
        public void StaticFunctions0(string signature, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                name = method.Name;
            Assert.AreEqual(expected: 0, actual: function.Arity);
            Assert.IsTrue(method.IsStatic);
            Assert.AreEqual(expected: 0, actual: operands.Count);
            Assert.AreEqual(expected: 0, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"{name}()", actual: function.ToCode());
            Assert.AreEqual(expected: $"{name}()", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"{name}()", actual: function.Expression.ToString());
        }

        #endregion
        #region Static functions of one parameter.

        [TestMethod]
        [DataRow("Math.Abs(Decimal)", typeof(decimal), typeof(decimal))]
        [DataRow("Math.Abs(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Abs(Int16)", typeof(short), typeof(short))]
        [DataRow("Math.Abs(Int32)", typeof(int), typeof(int))]
        [DataRow("Math.Abs(Int64)", typeof(long), typeof(long))]
        [DataRow("Math.Abs(SByte)", typeof(sbyte), typeof(sbyte))]
        [DataRow("Math.Abs(Single)", typeof(float), typeof(float))]
        [DataRow("Math.Acos(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Asin(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Atan(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Ceiling(Decimal)", typeof(decimal), typeof(decimal))]
        [DataRow("Math.Ceiling(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Cos(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Cosh(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Exp(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Floor(Decimal)", typeof(decimal), typeof(decimal))]
        [DataRow("Math.Floor(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Ceiling(Decimal)", typeof(decimal), typeof(decimal))]
        [DataRow("Math.Log(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Log10(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Round(Decimal)", typeof(decimal), typeof(decimal))]
        [DataRow("Math.Round(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Sign(Decimal)", typeof(decimal), typeof(int))]
        [DataRow("Math.Sign(Double)", typeof(double), typeof(int))]
        [DataRow("Math.Sign(Int16)", typeof(short), typeof(int))]
        [DataRow("Math.Sign(Int32)", typeof(int), typeof(int))]
        [DataRow("Math.Sign(Int64)", typeof(long), typeof(int))]
        [DataRow("Math.Sign(SByte)", typeof(sbyte), typeof(int))]
        [DataRow("Math.Sign(Single)", typeof(float), typeof(int))]
        [DataRow("Math.Sin(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Sinh(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Sqrt(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Tan(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Tanh(Double)", typeof(double), typeof(double))]
        [DataRow("Math.Truncate(Decimal)", typeof(decimal), typeof(decimal))]
        [DataRow("Math.Truncate(Double)", typeof(double), typeof(double))]
        [DataRow("Regex.Escape(String)", typeof(string), typeof(string))]
        [DataRow("Regex.set_CacheSize(Int32)", typeof(int), typeof(void))]
        [DataRow("Regex.Unescape(String)", typeof(string), typeof(string))]
        [DataRow("String.Concat(Object)", typeof(object), typeof(string))]
        [DataRow("String.Concat(Object[])", typeof(object[]), typeof(string))]
        [DataRow("String.Concat(String[])", typeof(string[]), typeof(string))]
        [DataRow("String.Copy(String)", typeof(string), typeof(string))]
        [DataRow("String.Intern(String)", typeof(string), typeof(string))]
        [DataRow("String.IsInterned(String)", typeof(string), typeof(string))]
        [DataRow("String.IsNullOrEmpty(String)", typeof(string), typeof(bool))]
        [DataRow("String.IsNullOrWhiteSpace(String)", typeof(string), typeof(bool))]
        public void StaticFunctions1(string signature, Type p1Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                name = method.Name,
                p1 = operands[0].ResultType.Name;
            Assert.AreEqual(expected: 1, actual: function.Arity);
            Assert.IsTrue(method.IsStatic);
            Assert.AreEqual(expected: 1, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[0].ResultType);
            Assert.AreEqual(expected: 1, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"{name}(({p1}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"{name}(({p1}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"{name}(default({p1}))", actual: function.Expression.ToString());
        }

        #endregion
        #region Static functions of two parameters.

        [TestMethod]
        [DataRow("Math.Atan2(Double, Double)", typeof(double), typeof(double), typeof(double))]
        [DataRow("Math.BigMul(Int32, Int32)", typeof(int), typeof(int), typeof(long))]
        [DataRow("Math.IEEERemainder(Double, Double)", typeof(double), typeof(double), typeof(double))]
        [DataRow("Math.Log(Double, Double)", typeof(double), typeof(double), typeof(double))]
        [DataRow("Math.Max(Byte, Byte)", typeof(byte), typeof(byte), typeof(byte))]
        [DataRow("Math.Max(Decimal, Decimal)", typeof(decimal), typeof(decimal), typeof(decimal))]
        [DataRow("Math.Max(Double, Double)", typeof(double), typeof(double), typeof(double))]
        [DataRow("Math.Max(Int16, Int16)", typeof(short), typeof(short), typeof(short))]
        [DataRow("Math.Max(Int32, Int32)", typeof(int), typeof(int), typeof(int))]
        [DataRow("Math.Max(Int64, Int64)", typeof(long), typeof(long), typeof(long))]
        [DataRow("Math.Max(SByte, SByte)", typeof(sbyte), typeof(sbyte), typeof(sbyte))]
        [DataRow("Math.Max(Single, Single)", typeof(float), typeof(float), typeof(float))]
        [DataRow("Math.Max(UInt16, UInt16)", typeof(ushort), typeof(ushort), typeof(ushort))]
        [DataRow("Math.Max(UInt32, UInt32)", typeof(uint), typeof(uint), typeof(uint))]
        [DataRow("Math.Max(UInt64, UInt64)", typeof(ulong), typeof(ulong), typeof(ulong))]
        [DataRow("Math.Min(Byte, Byte)", typeof(byte), typeof(byte), typeof(byte))]
        [DataRow("Math.Min(Decimal, Decimal)", typeof(decimal), typeof(decimal), typeof(decimal))]
        [DataRow("Math.Min(Double, Double)", typeof(double), typeof(double), typeof(double))]
        [DataRow("Math.Min(Int16, Int16)", typeof(short), typeof(short), typeof(short))]
        [DataRow("Math.Min(Int32, Int32)", typeof(int), typeof(int), typeof(int))]
        [DataRow("Math.Min(Int64, Int64)", typeof(long), typeof(long), typeof(long))]
        [DataRow("Math.Min(SByte, SByte)", typeof(sbyte), typeof(sbyte), typeof(sbyte))]
        [DataRow("Math.Min(Single, Single)", typeof(float), typeof(float), typeof(float))]
        [DataRow("Math.Min(UInt16, UInt16)", typeof(ushort), typeof(ushort), typeof(ushort))]
        [DataRow("Math.Min(UInt32, UInt32)", typeof(uint), typeof(uint), typeof(uint))]
        [DataRow("Math.Min(UInt64, UInt64)", typeof(ulong), typeof(ulong), typeof(ulong))]
        [DataRow("Math.Pow(Double, Double)", typeof(double), typeof(double), typeof(double))]
        [DataRow("Math.Round(Decimal, Int32)", typeof(decimal), typeof(int), typeof(decimal))]
        [DataRow("Math.Round(Decimal, MidpointRounding)", typeof(decimal), typeof(MidpointRounding), typeof(decimal))]
        [DataRow("Math.Round(Double, Int32)", typeof(double), typeof(int), typeof(double))]
        [DataRow("Math.Round(Double, MidpointRounding)", typeof(double), typeof(MidpointRounding), typeof(double))]
        [DataRow("Regex.IsMatch(String, String)", typeof(string), typeof(string), typeof(bool))]
        [DataRow("Regex.Match(String, String)", typeof(string), typeof(string), typeof(Match))]
        [DataRow("Regex.Matches(String, String)", typeof(string), typeof(string), typeof(MatchCollection))]
        [DataRow("Regex.Split(String, String)", typeof(string), typeof(string), typeof(string[]))]
        [DataRow("String.Compare(String, String)", typeof(string), typeof(string), typeof(int))]
        [DataRow("String.CompareOrdinal(String, String)", typeof(string), typeof(string), typeof(int))]
        [DataRow("String.Concat(Object, Object)", typeof(object), typeof(object), typeof(string))]
        [DataRow("String.Concat(String, String)", typeof(string), typeof(string), typeof(string))]
        [DataRow("String.Equals(String, String)", typeof(string), typeof(string), typeof(bool))]
        [DataRow("String.Format(String, Object)", typeof(string), typeof(object), typeof(string))]
        [DataRow("String.Format(String, Object[])", typeof(string), typeof(object[]), typeof(string))]
        [DataRow("String.Join(String, Object[])", typeof(string), typeof(object[]), typeof(string))]
        [DataRow("String.Join(String, String[])", typeof(string), typeof(string[]), typeof(string))]
        [DataRow("String.op_Equality(String, String)", typeof(string), typeof(string), typeof(bool))]
        [DataRow("String.op_Inequality(String, String)", typeof(string), typeof(string), typeof(bool))]
        public void StaticFunctions2(string signature, Type p1Type, Type p2Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                name = method.Name,
                p1 = operands[0].ResultType.Name,
                p2 = operands[1].ResultType.Name;
            Assert.AreEqual(expected: 2, actual: function.Arity);
            Assert.IsTrue(method.IsStatic);
            Assert.AreEqual(expected: 2, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[0].ResultType);
            Assert.AreEqual(expected: p2Type, actual: operands[1].ResultType);
            Assert.AreEqual(expected: 2, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"{name}(default({p1}), default({p2}))", actual: function.Expression.ToString());
        }

        #endregion
        #region Static functions of three parameters.

        [TestMethod]

        [DataRow("Math.Round(Decimal, Int32, MidpointRounding)", typeof(decimal), typeof(int), typeof(MidpointRounding), typeof(decimal))]
        [DataRow("Math.Round(Double, Int32, MidpointRounding)", typeof(double), typeof(int), typeof(MidpointRounding), typeof(double))]
        [DataRow("Regex.IsMatch(String, String, RegexOptions)", typeof(string), typeof(string), typeof(RegexOptions), typeof(bool))]
        [DataRow("Regex.Match(String, String, RegexOptions)", typeof(string), typeof(string), typeof(RegexOptions), typeof(Match))]
        [DataRow("Regex.Matches(String, String, RegexOptions)", typeof(string), typeof(string), typeof(RegexOptions), typeof(MatchCollection))]
        [DataRow("Regex.Replace(String, String, MatchEvaluator)", typeof(string), typeof(string), typeof(MatchEvaluator), typeof(string))]
        [DataRow("Regex.Replace(String, String, String)", typeof(string), typeof(string), typeof(string), typeof(string))]
        [DataRow("Regex.Split(String, String, RegexOptions)", typeof(string), typeof(string), typeof(RegexOptions), typeof(string[]))]
        [DataRow("String.Compare(String, String, Boolean)", typeof(string), typeof(string), typeof(bool), typeof(int))]
        [DataRow("String.Compare(String, String, StringComparison)", typeof(string), typeof(string), typeof(StringComparison), typeof(int))]
        [DataRow("String.Concat(Object, Object, Object)", typeof(object), typeof(object), typeof(object), typeof(string))]
        [DataRow("String.Concat(String, String, String)", typeof(string), typeof(string), typeof(string), typeof(string))]
        [DataRow("String.Equals(String, String, StringComparison)", typeof(string), typeof(string), typeof(StringComparison), typeof(bool))]
        [DataRow("String.Format(IFormatProvider, String, Object)", typeof(IFormatProvider), typeof(string), typeof(object), typeof(string))]
        [DataRow("String.Format(IFormatProvider, String, Object[])", typeof(IFormatProvider), typeof(string), typeof(object[]), typeof(string))]
        [DataRow("String.Format(String, Object, Object)", typeof(string), typeof(object), typeof(object), typeof(string))]
        public void StaticFunctions3(string signature, Type p1Type, Type p2Type, Type p3Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                name = method.Name,
                p1 = operands[0].ResultType.Name,
                p2 = operands[1].ResultType.Name,
                p3 = operands[2].ResultType.Name;
            Assert.AreEqual(expected: 3, actual: function.Arity);
            Assert.IsTrue(method.IsStatic);
            Assert.AreEqual(expected: 3, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[0].ResultType);
            Assert.AreEqual(expected: p2Type, actual: operands[1].ResultType);
            Assert.AreEqual(expected: p3Type, actual: operands[2].ResultType);
            Assert.AreEqual(expected: 3, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}), ({p3}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}), ({p3}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"{name}(default({p1}), default({p2}), default({p3}))", actual: function.Expression.ToString());
        }

        #endregion
        #region Static functions of four parameters.

        [TestMethod]
        [DataRow("Regex.IsMatch(String, String, RegexOptions, TimeSpan)", typeof(string), typeof(string), typeof(RegexOptions), typeof(TimeSpan), typeof(bool))]
        [DataRow("Regex.Match(String, String, RegexOptions, TimeSpan)", typeof(string), typeof(string), typeof(RegexOptions), typeof(TimeSpan), typeof(Match))]
        [DataRow("Regex.Matches(String, String, RegexOptions, TimeSpan)", typeof(string), typeof(string), typeof(RegexOptions), typeof(TimeSpan), typeof(MatchCollection))]
        [DataRow("Regex.Replace(String, String, MatchEvaluator, RegexOptions)", typeof(string), typeof(string), typeof(MatchEvaluator), typeof(RegexOptions), typeof(string))]
        [DataRow("Regex.Replace(String, String, String, RegexOptions)", typeof(string), typeof(string), typeof(string), typeof(RegexOptions), typeof(string))]
        [DataRow("Regex.Split(String, String, RegexOptions, TimeSpan)", typeof(string), typeof(string), typeof(RegexOptions), typeof(TimeSpan), typeof(string[]))]
        [DataRow("String.Compare(String, String, Boolean, CultureInfo)", typeof(string), typeof(string), typeof(bool), typeof(CultureInfo), typeof(int))]
        [DataRow("String.Compare(String, String, CultureInfo, CompareOptions)", typeof(string), typeof(string), typeof(CultureInfo), typeof(CompareOptions), typeof(int))]
        [DataRow("String.Concat(Object, Object, Object, Object)", typeof(object), typeof(object), typeof(object), typeof(object), typeof(string))]
        [DataRow("String.Concat(String, String, String, String)", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string))]
        [DataRow("String.Format(IFormatProvider, String, Object, Object)", typeof(IFormatProvider), typeof(string), typeof(object), typeof(object), typeof(string))]
        [DataRow("String.Format(String, Object, Object, Object)", typeof(string), typeof(object), typeof(object), typeof(object), typeof(string))]
        [DataRow("String.Join(String, String[], Int32, Int32)", typeof(string), typeof(string[]), typeof(int), typeof(int), typeof(string))]
        public void StaticFunctions4(string signature, Type p1Type, Type p2Type, Type p3Type, Type p4Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                name = method.Name,
                p1 = operands[0].ResultType.Name,
                p2 = operands[1].ResultType.Name,
                p3 = operands[2].ResultType.Name,
                p4 = operands[3].ResultType.Name;
            Assert.AreEqual(expected: 4, actual: function.Arity);
            Assert.IsTrue(method.IsStatic);
            Assert.AreEqual(expected: 4, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[0].ResultType);
            Assert.AreEqual(expected: p2Type, actual: operands[1].ResultType);
            Assert.AreEqual(expected: p3Type, actual: operands[2].ResultType);
            Assert.AreEqual(expected: p4Type, actual: operands[3].ResultType);
            Assert.AreEqual(expected: 4, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}), ({p3}), ({p4}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}), ({p3}), ({p4}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"{name}(default({p1}), default({p2}), default({p3}), default({p4}))", actual: function.Expression.ToString());
        }

        #endregion
        #region Static functions of five parameters.

        [TestMethod]
        [DataRow("Regex.Replace(String, String, MatchEvaluator, RegexOptions, TimeSpan)", typeof(string), typeof(string), typeof(MatchEvaluator), typeof(RegexOptions), typeof(TimeSpan), typeof(string))]
        [DataRow("Regex.Replace(String, String, String, RegexOptions, TimeSpan)", typeof(string), typeof(string), typeof(string), typeof(RegexOptions), typeof(TimeSpan), typeof(string))]
        [DataRow("String.Compare(String, Int32, String, Int32, Int32)", typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(int))]
        [DataRow("String.CompareOrdinal(String, Int32, String, Int32, Int32)", typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(int))]
        [DataRow("String.Format(IFormatProvider, String, Object, Object, Object)", typeof(IFormatProvider), typeof(string), typeof(object), typeof(object), typeof(object), typeof(string))]
        public void StaticFunctions5(string signature, Type p1Type, Type p2Type, Type p3Type, Type p4Type, Type p5Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                name = method.Name,
                p1 = operands[0].ResultType.Name,
                p2 = operands[1].ResultType.Name,
                p3 = operands[2].ResultType.Name,
                p4 = operands[3].ResultType.Name,
                p5 = operands[4].ResultType.Name;
            Assert.AreEqual(expected: 5, actual: function.Arity);
            Assert.IsTrue(method.IsStatic);
            Assert.AreEqual(expected: 5, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[0].ResultType);
            Assert.AreEqual(expected: p2Type, actual: operands[1].ResultType);
            Assert.AreEqual(expected: p3Type, actual: operands[2].ResultType);
            Assert.AreEqual(expected: p4Type, actual: operands[3].ResultType);
            Assert.AreEqual(expected: p5Type, actual: operands[4].ResultType);
            Assert.AreEqual(expected: 5, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}), ({p3}), ({p4}), ({p5}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}), ({p3}), ({p4}), ({p5}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"{name}(default({p1}), default({p2}), default({p3}), default({p4}), default({p5}))", actual: function.Expression.ToString());
        }

        #endregion
        #region Static functions of six parameters.

        [TestMethod]
        [DataRow("String.Compare(String, Int32, String, Int32, Int32, Boolean)", typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(bool), typeof(int))]
        [DataRow("String.Compare(String, Int32, String, Int32, Int32, StringComparison)", typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(StringComparison), typeof(int))]
        public void StaticFunctions6(string signature, Type p1Type, Type p2Type, Type p3Type, Type p4Type, Type p5Type, Type p6Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                name = method.Name,
                p1 = operands[0].ResultType.Name,
                p2 = operands[1].ResultType.Name,
                p3 = operands[2].ResultType.Name,
                p4 = operands[3].ResultType.Name,
                p5 = operands[4].ResultType.Name,
                p6 = operands[5].ResultType.Name;
            Assert.AreEqual(expected: 6, actual: function.Arity);
            Assert.IsTrue(method.IsStatic);
            Assert.AreEqual(expected: 6, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[0].ResultType);
            Assert.AreEqual(expected: p2Type, actual: operands[1].ResultType);
            Assert.AreEqual(expected: p3Type, actual: operands[2].ResultType);
            Assert.AreEqual(expected: p4Type, actual: operands[3].ResultType);
            Assert.AreEqual(expected: p5Type, actual: operands[4].ResultType);
            Assert.AreEqual(expected: p6Type, actual: operands[5].ResultType);
            Assert.AreEqual(expected: 6, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}), ({p3}), ({p4}), ({p5}), ({p6}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}), ({p3}), ({p4}), ({p5}), ({p6}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"{name}(default({p1}), default({p2}), default({p3}), default({p4}), default({p5}), default({p6}))", actual: function.Expression.ToString());
        }

        #endregion
        #region Static functions of seven parameters.

        [TestMethod]
        [DataRow("String.Compare(String, Int32, String, Int32, Int32, Boolean, CultureInfo)", typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(bool), typeof(CultureInfo), typeof(int))]
        [DataRow("String.Compare(String, Int32, String, Int32, Int32, CultureInfo, CompareOptions)", typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(CultureInfo), typeof(CompareOptions), typeof(int))]
        public void StaticFunctions7(string signature, Type p1Type, Type p2Type, Type p3Type, Type p4Type, Type p5Type, Type p6Type, Type p7Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                name = method.Name,
                p1 = operands[0].ResultType.Name,
                p2 = operands[1].ResultType.Name,
                p3 = operands[2].ResultType.Name,
                p4 = operands[3].ResultType.Name,
                p5 = operands[4].ResultType.Name,
                p6 = operands[5].ResultType.Name,
                p7 = operands[6].ResultType.Name;
            Assert.AreEqual(expected: 7, actual: function.Arity);
            Assert.IsTrue(method.IsStatic);
            Assert.AreEqual(expected: 7, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[0].ResultType);
            Assert.AreEqual(expected: p2Type, actual: operands[1].ResultType);
            Assert.AreEqual(expected: p3Type, actual: operands[2].ResultType);
            Assert.AreEqual(expected: p4Type, actual: operands[3].ResultType);
            Assert.AreEqual(expected: p5Type, actual: operands[4].ResultType);
            Assert.AreEqual(expected: p6Type, actual: operands[5].ResultType);
            Assert.AreEqual(expected: p7Type, actual: operands[6].ResultType);
            Assert.AreEqual(expected: 7, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}), ({p3}), ({p4}), ({p5}), ({p6}), ({p7}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"{name}(({p1}), ({p2}), ({p3}), ({p4}), ({p5}), ({p6}), ({p7}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"{name}(default({p1}), default({p2}), default({p3}), default({p4}), default({p5}), default({p6}), default({p7}))", actual: function.Expression.ToString());
        }

        #endregion

        #region String member functions with no additional parameters.

        [TestMethod]
        [DataRow("Clone()", typeof(object))]
        [DataRow("get_Length()", typeof(int))]
        [DataRow("GetEnumerator()", typeof(CharEnumerator))]
        [DataRow("GetHashCode()", typeof(int))]
        [DataRow("GetType()", typeof(Type))]
        [DataRow("GetTypeCode()", typeof(TypeCode))]
        [DataRow("IsNormalized()", typeof(bool))]
        [DataRow("Normalize()", typeof(string))]
        [DataRow("ToCharArray()", typeof(char[]))]
        [DataRow("ToLower()", typeof(string))]
        [DataRow("ToLowerInvariant()", typeof(string))]
        [DataRow("ToString()", typeof(string))]
        [DataRow("ToUpper()", typeof(string))]
        [DataRow("ToUpperInvariant()", typeof(string))]
        [DataRow("Trim()", typeof(string))]
        public void StringMembers0(string signature, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                self = method.DeclaringType.Name,
                name = method.Name;
            Assert.AreEqual(expected: 1, actual: function.Arity);
            Assert.IsFalse(method.IsStatic);
            Assert.AreEqual(expected: 1, actual: operands.Count);
            Assert.AreEqual(expected: 1, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"({self}).{name}()", actual: function.ToCode());
            Assert.AreEqual(expected: $"({self}).{name}()", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"default({self}).{name}()", actual: function.Expression.ToString());
        }

        #endregion
        #region String member functions with one additional parameter.

        [TestMethod]
        [DataRow("CompareTo(Object)", typeof(object), typeof(int))]
        [DataRow("CompareTo(String)", typeof(string), typeof(int))]
        [DataRow("Contains(String)", typeof(string), typeof(bool))]
        [DataRow("EndsWith(String)", typeof(string), typeof(bool))]
        [DataRow("Equals(Object)", typeof(object), typeof(bool))]
        [DataRow("Equals(String)", typeof(string), typeof(bool))]
        [DataRow("get_Chars(Int32)", typeof(int), typeof(char))]
        [DataRow("IndexOf(Char)", typeof(char), typeof(int))]
        [DataRow("IndexOf(String)", typeof(string), typeof(int))]
        [DataRow("IndexOfAny(Char[])", typeof(char[]), typeof(int))]
        [DataRow("IsNormalized(NormalizationForm)", typeof(NormalizationForm), typeof(bool))]
        [DataRow("LastIndexOf(Char)", typeof(char), typeof(int))]
        [DataRow("LastIndexOf(String)", typeof(string), typeof(int))]
        [DataRow("LastIndexOfAny(Char[])", typeof(char[]), typeof(int))]
        [DataRow("Normalize(NormalizationForm)", typeof(NormalizationForm), typeof(string))]
        [DataRow("PadLeft(Int32)", typeof(int), typeof(string))]
        [DataRow("PadRight(Int32)", typeof(int), typeof(string))]
        [DataRow("Remove(Int32)", typeof(int), typeof(string))]
        [DataRow("Split(Char[])", typeof(char[]), typeof(string[]))]
        [DataRow("StartsWith(String)", typeof(string), typeof(bool))]
        [DataRow("Substring(Int32)", typeof(int), typeof(string))]
        [DataRow("ToLower(CultureInfo)", typeof(CultureInfo), typeof(string))]
        [DataRow("ToString(IFormatProvider)", typeof(IFormatProvider), typeof(string))]
        [DataRow("ToUpper(CultureInfo)", typeof(CultureInfo), typeof(string))]
        [DataRow("Trim(Char[])", typeof(char[]), typeof(string))]
        [DataRow("TrimEnd(Char[])", typeof(char[]), typeof(string))]
        [DataRow("TrimStart(Char[])", typeof(char[]), typeof(string))]
        public void StringMembers1(string signature, Type p1Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                self = method.DeclaringType.Name,
                name = method.Name,
                p1 = operands[1].ResultType.Name;
            Assert.AreEqual(expected: 2, actual: function.Arity);
            Assert.IsFalse(method.IsStatic);
            Assert.AreEqual(expected: 2, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[1].ResultType);
            Assert.AreEqual(expected: 2, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"({self}).{name}(({p1}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"({self}).{name}(({p1}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"default({self}).{name}(default({p1}))", actual: function.Expression.ToString());
        }

        #endregion
        #region String member functions with two additional parameters.

        [TestMethod]
        [DataRow("EndsWith(String, StringComparison)", typeof(string), typeof(StringComparison), typeof(bool))]
        [DataRow("Equals(String, StringComparison)", typeof(string), typeof(StringComparison), typeof(bool))]
        [DataRow("IndexOf(Char, Int32)", typeof(char), typeof(int), typeof(int))]
        [DataRow("IndexOf(String, Int32)", typeof(string), typeof(int), typeof(int))]
        [DataRow("IndexOf(String, StringComparison)", typeof(string), typeof(StringComparison), typeof(int))]
        [DataRow("IndexOfAny(Char[], Int32)", typeof(char[]), typeof(int), typeof(int))]
        [DataRow("Insert(Int32, String)", typeof(int), typeof(string), typeof(string))]
        [DataRow("LastIndexOf(Char, Int32)", typeof(char), typeof(int), typeof(int))]
        [DataRow("LastIndexOf(String, Int32)", typeof(string), typeof(int), typeof(int))]
        [DataRow("LastIndexOf(String, StringComparison)", typeof(string), typeof(StringComparison), typeof(int))]
        [DataRow("LastIndexOfAny(Char[], Int32)", typeof(char[]), typeof(int), typeof(int))]
        [DataRow("PadLeft(Int32, Char)", typeof(int), typeof(char), typeof(string))]
        [DataRow("PadRight(Int32, Char)", typeof(int), typeof(char), typeof(string))]
        [DataRow("Remove(Int32, Int32)", typeof(int), typeof(int), typeof(string))]
        [DataRow("Replace(Char, Char)", typeof(char), typeof(char), typeof(string))]
        [DataRow("Replace(String, String)", typeof(string), typeof(string), typeof(string))]
        [DataRow("Split(Char[], Int32)", typeof(char[]), typeof(int), typeof(string[]))]
        [DataRow("Split(Char[], StringSplitOptions)", typeof(char[]), typeof(StringSplitOptions), typeof(string[]))]
        [DataRow("Split(String[], StringSplitOptions)", typeof(string[]), typeof(StringSplitOptions), typeof(string[]))]
        [DataRow("StartsWith(String, StringComparison)", typeof(string), typeof(StringComparison), typeof(bool))]
        [DataRow("Substring(Int32, Int32)", typeof(int), typeof(int), typeof(string))]
        [DataRow("ToCharArray(Int32, Int32)", typeof(int), typeof(int), typeof(char[]))]
        public void StringMembers2(string signature, Type p1Type, Type p2Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                self = method.DeclaringType.Name,
                name = method.Name,
                p1 = operands[1].ResultType.Name,
                p2 = operands[2].ResultType.Name;
            Assert.AreEqual(expected: 3, actual: function.Arity);
            Assert.IsFalse(method.IsStatic);
            Assert.AreEqual(expected: 3, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[1].ResultType);
            Assert.AreEqual(expected: p2Type, actual: operands[2].ResultType);
            Assert.AreEqual(expected: 3, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"({self}).{name}(({p1}), ({p2}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"({self}).{name}(({p1}), ({p2}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"default({self}).{name}(default({p1}), default({p2}))", actual: function.Expression.ToString());
        }

        #endregion
        #region String member functions with three additional parameters.

        [TestMethod]
        [DataRow("EndsWith(String, Boolean, CultureInfo)", typeof(string), typeof(bool), typeof(CultureInfo), typeof(bool))]
        [DataRow("IndexOf(Char, Int32, Int32)", typeof(char), typeof(int), typeof(int), typeof(int))]
        [DataRow("IndexOf(String, Int32, Int32)", typeof(string), typeof(int), typeof(int), typeof(int))]
        [DataRow("IndexOf(String, Int32, StringComparison)", typeof(string), typeof(int), typeof(StringComparison), typeof(int))]
        [DataRow("IndexOfAny(Char[], Int32, Int32)", typeof(char[]), typeof(int), typeof(int), typeof(int))]
        [DataRow("LastIndexOf(Char, Int32, Int32)", typeof(char), typeof(int), typeof(int), typeof(int))]
        [DataRow("LastIndexOf(String, Int32, Int32)", typeof(string), typeof(int), typeof(int), typeof(int))]
        [DataRow("LastIndexOf(String, Int32, StringComparison)", typeof(string), typeof(int), typeof(StringComparison), typeof(int))]
        [DataRow("LastIndexOfAny(Char[], Int32, Int32)", typeof(char[]), typeof(int), typeof(int), typeof(int))]
        [DataRow("Split(Char[], Int32, StringSplitOptions)", typeof(char[]), typeof(int), typeof(StringSplitOptions), typeof(string[]))]
        [DataRow("Split(String[], Int32, StringSplitOptions)", typeof(string[]), typeof(int), typeof(StringSplitOptions), typeof(string[]))]
        [DataRow("StartsWith(String, Boolean, CultureInfo)", typeof(string), typeof(bool), typeof(CultureInfo), typeof(bool))]
        public void StringMembers3(string signature, Type p1Type, Type p2Type, Type p3Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                self = method.DeclaringType.Name,
                name = method.Name,
                p1 = operands[1].ResultType.Name,
                p2 = operands[2].ResultType.Name,
                p3 = operands[3].ResultType.Name;
            Assert.AreEqual(expected: 4, actual: function.Arity);
            Assert.IsFalse(method.IsStatic);
            Assert.AreEqual(expected: 4, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[1].ResultType);
            Assert.AreEqual(expected: p2Type, actual: operands[2].ResultType);
            Assert.AreEqual(expected: p3Type, actual: operands[3].ResultType);
            Assert.AreEqual(expected: 4, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"({self}).{name}(({p1}), ({p2}), ({p3}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"({self}).{name}(({p1}), ({p2}), ({p3}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"default({self}).{name}(default({p1}), default({p2}), default({p3}))", actual: function.Expression.ToString());
        }

        #endregion
        #region String member functions with four additional parameters.

        [TestMethod]
        [DataRow("CopyTo(Int32, Char[], Int32, Int32)", typeof(int), typeof(char[]), typeof(int), typeof(int), typeof(void))]
        [DataRow("IndexOf(String, Int32, Int32, StringComparison)", typeof(string), typeof(int), typeof(int), typeof(StringComparison), typeof(int))]
        [DataRow("LastIndexOf(String, Int32, Int32, StringComparison)", typeof(string), typeof(int), typeof(int), typeof(StringComparison), typeof(int))]
        public void StringMembers4(string signature, Type p1Type, Type p2Type, Type p3Type, Type p4Type, Type resultType)
        {
            var function = new Function(signature);
            var method = function.Method;
            var operands = function.Operands;
            string
                self = method.DeclaringType.Name,
                name = method.Name,
                p1 = operands[1].ResultType.Name,
                p2 = operands[2].ResultType.Name,
                p3 = operands[3].ResultType.Name,
                p4 = operands[4].ResultType.Name;
            Assert.AreEqual(expected: 5, actual: function.Arity);
            Assert.IsFalse(method.IsStatic);
            Assert.AreEqual(expected: 5, actual: operands.Count);
            Assert.AreEqual(expected: p1Type, actual: operands[1].ResultType);
            Assert.AreEqual(expected: p2Type, actual: operands[2].ResultType);
            Assert.AreEqual(expected: p3Type, actual: operands[3].ResultType);
            Assert.AreEqual(expected: p4Type, actual: operands[4].ResultType);
            Assert.AreEqual(expected: 5, actual: function.ParameterTypes.Count());
            Assert.AreEqual(expected: Precedence.Unary, actual: function.Precedence);
            Assert.AreEqual(expected: resultType, actual: function.ResultType);
            Assert.AreEqual(expected: signature, actual: function.Signature);
            Assert.AreEqual(expected: $"({self}).{name}(({p1}), ({p2}), ({p3}), ({p4}))", actual: function.ToCode());
            Assert.AreEqual(expected: $"({self}).{name}(({p1}), ({p2}), ({p3}), ({p4}))", actual: function.ToFriendlyText());
            Assert.AreEqual(expected: $"default({self}).{name}(default({p1}), default({p2}), default({p3}), default({p4}))", actual: function.Expression.ToString());
        }

        #endregion
    }
}
