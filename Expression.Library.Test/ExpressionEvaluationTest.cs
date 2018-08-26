using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expression.Library;
using System.Collections.Generic;

namespace Expression.Library.Test
{
    [TestClass]
    public class ExpressionEvaluationTest
    {
        private static VariableReplacements _replacements;

        [TestInitialize]
        public void TestInitialize()
        {
            var replacements = new List<VariableReplacement>()
            {
                new VariableReplacement('x', 0.5)
            };

            _replacements = new VariableReplacements(replacements);
        }

        [TestMethod]
        public void IExpression_Evaluation_Constant()
        {
            ExpressionBase expression = new Constant(2.0);

            Assert.AreEqual(expression.Evaluate(_replacements), 2.0);
        }

        [TestMethod]
        public void IExpression_Evaluation_Variable()
        {
            ExpressionBase expression = new Variable('x');

            Assert.AreEqual(expression.Evaluate(_replacements), 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void IExpression_Evaluation_Variable_KeyNotFoundException()
        {
            ExpressionBase expression = new Variable('t');

            expression.Evaluate(_replacements);
        }

        [TestMethod]
        public void IExpression_Evaluation_Add()
        {
            var expressions = new List<ExpressionBase>()
            {
                new Variable('x'),
                1.0
            };

            var expression = new Add(expressions);

            Assert.AreEqual(expression.Evaluate(_replacements), 1.5);
        }

        [TestMethod]
        public void IExpression_Evaluation_Add_AddExpression()
        {
            var expression = new Add();
            expression.AddExpression(new Variable('x'));
            expression.AddExpression(1.0);

            Assert.AreEqual(expression.Evaluate(_replacements), 1.5);
        }
    }
}
