using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expression.Library
{
    public class Divide : ExpressionBase
    {
        public ExpressionBase Dividend { get; private set; }
        public ExpressionBase Divisor { get; private set; }

        public Divide(ExpressionBase dividend, ExpressionBase divisor)
        {
            Dividend = dividend;
            Divisor = divisor;
        }

        public override double Evaluate(VariableReplacements replacements)
        {
            return Dividend.Evaluate(replacements) / Divisor.Evaluate(replacements);
        }

        public override IEnumerable<Variable> Variables()
        {
            List<string> tokens = new List<string>();
            List<ExpressionBase> expressions = new List<ExpressionBase>()
            {
                Dividend,
                Divisor
            };

            foreach (Variable v in expressions.SelectMany(ex => ex.Variables()))
            {
                if (!tokens.Contains(v.Token))
                {
                    tokens.Add(v.Token);
                    yield return v;
                }
            }
        }

        public override string ToString()
        {
            return "(" + Dividend.ToString() + " / " + Divisor.ToString() + ")";
        }
    }
}
