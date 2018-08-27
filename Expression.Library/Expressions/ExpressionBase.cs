using System;
using System.Collections.Generic;
using System.Linq;

namespace Expression.Library
{
    public abstract class ExpressionBase
    {
        public abstract double Evaluate(VariableReplacements replacements);

        public abstract IEnumerable<Variable> Variables();

        public static implicit operator ExpressionBase(double value)
        {
            return new Constant(value);
        }

        public static implicit operator ExpressionBase(char value)
        {
            return new Variable(value);
        }

        public static ExpressionBase operator +(ExpressionBase ex1, ExpressionBase ex2)
        {
            Add add1 = ex1 as Add;
            Add add2 = ex2 as Add;

            var expressions = new List<ExpressionBase>();

            if(add1 != null)
            {
                if(add2 != null)
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
            else if(add2 != null)
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

        public static ExpressionBase operator -(ExpressionBase expression)
        {
            var negative = expression as Negative;

            if(negative != null)
            {
                return negative.Expression;
            }

            return new Negative(expression);
        }
    }
}
