using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Library
{
    public class Variable : ExpressionBase
    {
        public char Token { get; private set; }

        public Variable(char token)
        {
            Token = token;
        }

        public override double Evaluate(VariableReplacements replacements)
        {
            return replacements.GetReplacement(Token);
        }

        public override IEnumerable<Variable> Variables()
        {
            yield return this;
        }
    }
}
