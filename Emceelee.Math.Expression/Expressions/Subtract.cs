using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Math.Expression
{
    public class Subtract : ExpressionBase
    {
        public ExpressionBase Minuend { get; private set; }
        public ExpressionBase Subtrahend { get; private set; }

        public Subtract(ExpressionBase minuend, ExpressionBase subtrahend)
        {
            Minuend = minuend;
            Subtrahend = subtrahend;
        }

        public override double Evaluate(VariableReplacements replacements)
        {
            return Minuend.Evaluate(replacements) - Subtrahend.Evaluate(replacements); 
        }

        public override IEnumerable<Variable> Variables()
        {
            List<string> tokens = new List<string>();
            List<ExpressionBase> expressions = new List<ExpressionBase>()
            {
                Minuend,
                Subtrahend
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
            return "(" + Minuend.ToString() + " - " + Subtrahend.ToString() + ")";
        }
    }
}
