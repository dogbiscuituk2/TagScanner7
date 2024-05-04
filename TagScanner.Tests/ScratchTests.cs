namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq.Expressions;
    using Terms;

    [TestClass]
    public class ScratchTests : BaseTests
    {
        [TestMethod]
        public void ScratchTest01()
        {
            var X = Expression.Parameter(typeof(int), "X");
            var assignX = Expression.AddAssign(X, Expression.Constant(2));
            var Y = Expression.Parameter(typeof(int), "Y");
            var assignY = Expression.AddAssign(Y, Expression.Add(assignX, Expression.Constant(5)));
            var Z = Expression.Parameter(typeof(int), "Z");
            var assignZ = Expression.AddAssign(Z, Expression.Add(assignY, Expression.Constant(15)));
            
            var lambdaExpression = Expression.Lambda(assignZ, X, Y, Z);
            var lambdaDelegate = lambdaExpression.Compile();

            var result = lambdaDelegate.DynamicInvoke(0, 0, 0);
            return;
        }
    }
}
