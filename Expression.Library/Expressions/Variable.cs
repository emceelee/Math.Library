using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Library
{
    public class Variable : ExpressionBase
    {
        public string Token { get; private set; }

        public Variable(string token)
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

        public override string ToString()
        {
            return Token.ToString();
        }
    }
}
