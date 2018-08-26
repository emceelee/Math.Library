using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Library
{
    public class KeyedExpression : ExpressionBase
    {
        public char Token { get; private set; }
        public ExpressionBase Expression { get; private set; }

        public override double Evaluate(VariableReplacements replacements)
        {
            double result = Expression.Evaluate(replacements);
            replacements.Add(new VariableReplacement(Token, result));

            return result;
        }

        public override IEnumerable<Variable> Variables()
        {
            return Expression.Variables();
        }
    }
}
