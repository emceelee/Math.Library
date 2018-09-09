using System;
using System.Collections.Generic;
using System.Linq;

using Emceelee.Math.Shared;

namespace Emceelee.Math.Expression
{
    public abstract class ExpressionBase : IFunction
    {
        public abstract double Evaluate(VariableReplacements replacements);

        public double Evaluate(double value)
        {
            var replacements = new List<VariableReplacement>();
            foreach(Variable v in Variables())
            {
                replacements.Add(new VariableReplacement(v.Token, value));
            }

            return Evaluate(new VariableReplacements(replacements));
        }

        public abstract IEnumerable<Variable> Variables();

        public static implicit operator ExpressionBase(double value)
        {
            return new Constant(value);
        }

        public static implicit operator ExpressionBase(string value)
        {
            return new Variable(value);
        }

        public static ExpressionBase operator +(ExpressionBase ex1, ExpressionBase ex2)
        {
            Add add1 = ex1 as Add;
            Add add2 = ex2 as Add;

            var expressions = new List<ExpressionBase>();

            if (add1 != null)
            {
                if (add2 != null)
                {
                    var listAdd = new List<Add>()
                    {
                        add1,
                        add2
                    };

                    expressions.AddRange(listAdd.SelectMany(a => a.Expressions).ToList());
                }
                else
                {
                    expressions.AddRange(add1.Expressions);
                    expressions.Add(ex2);
                }
            }
            else if (add2 != null)
            {
                expressions.AddRange(add2.Expressions);
                expressions.Add(ex1);
            }
            else
            {
                expressions.Add(ex1);
                expressions.Add(ex2);
            }

            return new Add(expressions);
        }

        public static ExpressionBase operator -(ExpressionBase ex1, ExpressionBase ex2)
        {
            Add add1 = ex1 as Add;
            Add add2 = ex2 as Add;

            var expressions = new List<ExpressionBase>();

            if (add1 != null)
            {
                if (add2 != null)
                {
                    expressions.AddRange(add1.Expressions);
                    foreach (ExpressionBase expression in add2.Expressions)
                    {
                        expressions.Add(-expression);
                    }
                }
                else
                {
                    expressions.AddRange(add1.Expressions);
                    expressions.Add(-ex2);
                }
            }
            else if (add2 != null)
            {
                expressions.Add(ex1);
                foreach (ExpressionBase expression in add2.Expressions)
                {
                    expressions.Add(-expression);
                }
            }
            else
            {
                expressions.Add(ex1);
                expressions.Add(-ex2);
            }

            return new Add(expressions);
        }

        public static ExpressionBase operator *(ExpressionBase ex1, ExpressionBase ex2)
        {
            Multiply factor1 = ex1 as Multiply;
            Multiply factor2 = ex2 as Multiply;

            var expressions = new List<ExpressionBase>();

            if (factor1 != null)
            {
                if (factor2 != null)
                {
                    var listAdd = new List<Multiply>()
                    {
                        factor1,
                        factor2
                    };

                    expressions.AddRange(listAdd.SelectMany(a => a.Expressions).ToList());
                }
                else
                {
                    expressions.AddRange(factor1.Expressions);
                    expressions.Add(ex2);
                }
            }
            else if (factor2 != null)
            {
                expressions.AddRange(factor2.Expressions);
                expressions.Add(ex1);
            }
            else
            {
                expressions.Add(ex1);
                expressions.Add(ex2);
            }

            return new Multiply(expressions);
        }

        public static ExpressionBase operator /(ExpressionBase ex1, ExpressionBase ex2)
        {
            Multiply factor1 = ex1 as Multiply;
            Multiply factor2 = ex2 as Multiply;

            var expressions = new List<ExpressionBase>();

            if (factor1 != null)
            {
                if (factor2 != null)
                {
                    expressions.AddRange(factor1.Expressions);
                    foreach (ExpressionBase expression in factor2.Expressions)
                    {
                        expressions.Add(new Inverse(expression));
                    }
                }
                else
                {
                    expressions.AddRange(factor1.Expressions);
                    expressions.Add(new Inverse(ex2));
                }
            }
            else if (factor2 != null)
            {
                expressions.Add(ex1);
                foreach (ExpressionBase expression in factor2.Expressions)
                {
                    expressions.Add(new Inverse(expression));
                }
            }
            else
            {
                expressions.Add(ex1);
                expressions.Add(new Inverse(ex2));
            }

            return new Multiply(expressions);
        }

        public static ExpressionBase operator -(ExpressionBase expression)
        {
            return new Negative(expression);
        }
    }
}
