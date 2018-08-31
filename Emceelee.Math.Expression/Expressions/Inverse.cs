using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emceelee.Math.Expression
{
    public class Inverse : ExpressionBase
    {
        public ExpressionBase Expression { get; private set; }

        public Inverse(ExpressionBase expression)
        {
            Expression = expression;
        }

        public override double Evaluate(VariableReplacements replacements)
        {
            return 1 / Expression.Evaluate(replacements);
        }

        public override IEnumerable<Variable> Variables()
        {
            return Expression.Variables();
        }

        public override string ToString()
        {
            return "1/" + Expression.ToString();
        }
    }
}
