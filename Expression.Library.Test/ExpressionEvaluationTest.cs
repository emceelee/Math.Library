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
        public void ExpressionBase_Evaluation_Constant()
        {
            ExpressionBase expression = new Constant(2.0);

            Assert.AreEqual(expression.Evaluate(_replacements), 2.0);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Variable()
        {
            ExpressionBase expression = new Variable('x');

            Assert.AreEqual(expression.Evaluate(_replacements), 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExpressionBase_Evaluation_Variable_KeyNotFoundException()
        {
            ExpressionBase expression = new Variable('t');

            expression.Evaluate(_replacements);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add()
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
        public void ExpressionBase_Evaluation_Add_AddExpression()
        {
            var expression = new Add();
            expression.AddExpression('x');
            expression.AddExpression(1.0);

            Assert.AreEqual(expression.Evaluate(_replacements), 1.5);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_AddOverload()
        {
            var expression = new Variable('x') + 1.0;

            Assert.AreEqual(expression.Evaluate(_replacements), 1.5);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_PlusOverload_Add1()
        {
            var expression1 = new Add('x', 1.0);
            var expression2 = (ExpressionBase)1.5;
            var expression = expression1 + expression2;

            Assert.AreEqual(expression.Evaluate(_replacements), 3.0);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_PlusOverload_Add2()
        {
            var expression1 = (ExpressionBase)1.5;
            var expression2 = new Add('x', 1.0);
            var expression = expression1 + expression2;

            Assert.AreEqual(expression.Evaluate(_replacements), 3.0);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_PlusOverload_AddBoth()
        {
            var expression1 = new Add('x', 1.0, 1.5);
            var expression2 = new Add('x', 1.0);
            var expression = expression1 + expression2;

            Assert.AreEqual(expression.Evaluate(_replacements), 4.5);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Negative()
        {
            var expression = new Negative('x');

            Assert.AreEqual(expression.Evaluate(_replacements), -0.5);
        }
    }
}
