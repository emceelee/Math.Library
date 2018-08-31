using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Emceelee.Math.Expression;
using System.Collections.Generic;

namespace Emceelee.Math.Expression.Test
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
                new VariableReplacement("x", 0.5),
                new VariableReplacement("t", 1.3)
            };

            _replacements = new VariableReplacements(replacements);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Constant()
        {
            ExpressionBase expression = new Constant(2.0);

            Assert.AreEqual(2.0, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Variable()
        {
            ExpressionBase expression = new Variable("x");

            Assert.AreEqual(0.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExpressionBase_Evaluation_Variable_KeyNotFoundException()
        {
            ExpressionBase expression = new Variable("s");

            expression.Evaluate(_replacements);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add()
        {
            var expressions = new List<ExpressionBase>()
            {
                new Variable("x"),
                1.0
            };

            var expression = new Add(expressions);

            Assert.AreEqual(1.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_AddExpression()
        {
            var expression = new Add();
            expression.AddExpression("x");
            expression.AddExpression(1.0);

            Assert.AreEqual(1.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_PlusOverload()
        {
            var expression = new Variable("x") + 1.0;

            Assert.AreEqual(1.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_PlusOverload_Add1()
        {
            var expression1 = new Add("x", 1.0);
            var expression2 = (ExpressionBase)1.5;
            var expression = expression1 + expression2;

            Assert.AreEqual(3.0, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_PlusOverload_Add2()
        {
            var expression1 = (ExpressionBase)1.5;
            var expression2 = new Add("x", 1.0);
            var expression = expression1 + expression2;

            Assert.AreEqual(3.0, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_PlusOverload_AddBoth()
        {
            var expression1 = new Add("x", 1.0, 1.5);
            var expression2 = new Add("x", 1.0);
            var expression = expression1 + expression2;

            Assert.AreEqual(4.5, expression.Evaluate(_replacements));

            var display = expression.ToString();
            Console.WriteLine(display);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_MinusOverload()
        {
            var expression = new Variable("x") - 1.0;

            Assert.AreEqual(-0.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_MinusOverload_Add1()
        {
            var expression1 = new Add("x", 1.0);
            var expression2 = (ExpressionBase)1.5;
            var expression = expression1 - expression2;

            Assert.AreEqual(0, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_MinusOverload_Add2()
        {
            var expression1 = (ExpressionBase)1.5;
            var expression2 = new Add("x", 1.0);
            var expression = expression1 - expression2;

            Assert.AreEqual(0, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Add_MinusOverload_AddBoth()
        {
            var expression1 = new Add("x", 1.0, 1.5);
            var expression2 = new Add("x", 1.0);
            var expression = expression1 - expression2;

            Assert.AreEqual(1.5, expression.Evaluate(_replacements));

            var display = expression.ToString();
            Console.WriteLine(display);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Negative()
        {
            var expression = new Negative("x");

            Assert.AreEqual(-0.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Negative_Overload()
        {
            var expression = -new Variable("x");

            Assert.AreEqual(-0.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Multiply()
        {
            var expressions = new List<ExpressionBase>()
            {
                new Variable("x"),
                1.0
            };

            var expression = new Multiply(expressions);

            Assert.AreEqual(0.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Multiply_AddExpression()
        {
            var expression = new Multiply();
            expression.AddExpression("x");
            expression.AddExpression(1.0);

            Assert.AreEqual(0.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Multiply_MultiplyOverload()
        {
            var expression = new Variable("x") * 1.0;

            Assert.AreEqual(0.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Multiply_MultiplyOverload_Factor1()
        {
            var expression1 = new Multiply("x", 1.0);
            var expression2 = (ExpressionBase)1.5;
            var expression = expression1 * expression2;

            Assert.AreEqual(0.75, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Multiply_MultiplyOverload_Factor2()
        {
            var expression1 = (ExpressionBase)1.5;
            var expression2 = new Multiply("x", 1.0);
            var expression = expression1 * expression2;

            Assert.AreEqual(0.75, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Multiply_MultiplyOverload_FactorBoth()
        {
            var expression1 = new Multiply("x", 1.0, 1.5);
            var expression2 = new Multiply("x", 1.0);
            var expression = expression1 * expression2;

            Assert.AreEqual(0.375, expression.Evaluate(_replacements));

            var display = expression.ToString();
            Console.WriteLine(display);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Multiply_DivideOverload()
        {
            var expression = new Variable("x") / 1.0;

            Assert.AreEqual(0.5, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Multiply_DivideOverload_Factor1()
        {
            var expression1 = new Multiply("x", 1);
            var expression2 = (ExpressionBase)1.5;
            var expression = expression1 / expression2;

            var result = expression.Evaluate(_replacements);

            Assert.AreEqual(1.0/3, result, 0.000000000001);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Multiply_DivideOverload_Factor2()
        {
            var expression1 = (ExpressionBase)1.5;
            var expression2 = new Multiply("x", 1.0);
            var expression = expression1 / expression2;

            Assert.AreEqual(3.0, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Multiply_DivideOverload_FactorBoth()
        {
            var expression1 = new Multiply("x", 1.0, 1.5);
            var expression2 = new Multiply("x", 1.0);
            var expression = expression1 / expression2;

            Assert.AreEqual(1.5, expression.Evaluate(_replacements));

            var display = expression.ToString();
            Console.WriteLine(display);
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_Inverse()
        {
            var expression = new Inverse("x");

            Assert.AreEqual(2, expression.Evaluate(_replacements));
        }

        [TestMethod]
        public void ExpressionBase_Evaluation_AdvancedCalc1()
        {
            var expression = -(ExpressionBase)2.0 * "x" * 5 / new Multiply(3, new Inverse((Variable)"x" + 4.2),"t") + new Variable("t")/4.3 - System.Math.PI;
            // = -2*0.5*5/ (3 * 1/4.7 * 1.3)+1.3/4.3-3.141592653589
            // = -5 / (3.9/4.7) + 1.3/4.3 - 3.141592653589
            // = -23.5/3.9 + 1.3/4.3 - 3.141592653589
            // = -8.864908098

            Assert.AreEqual(-8.864908098, expression.Evaluate(_replacements), 0.000000001);
        }
    }
}