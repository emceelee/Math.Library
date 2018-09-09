using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emceelee.Math.Expression
{
    public class Sin : ExpressionBase
    {
        public ExpressionBase Expression { get; private set; }

        public Sin(ExpressionBase expression)
        {
            Expression = expression;
        }

        public override double Evaluate(VariableReplacements replacements)
        {
            return System.Math.Sin(Expression.Evaluate(replacements));
        }

        public override IEnumerable<Variable> Variables()
        {
            return Expression.Variables();
        }

        public override string ToString()
        {
            return $"Cos({Expression})";
        }
    }
}
