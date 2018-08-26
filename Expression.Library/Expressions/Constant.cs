using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Library
{
    public class Constant : ExpressionBase
    {
        public double Value { get; private set; }

        public Constant(double value)
        {
            Value = value;
        }

        public override double Evaluate(VariableReplacements replacements)
        {
            return Value;
        }

        public override IEnumerable<Variable> Variables()
        {
            yield break;
        }

        public static implicit operator Constant(double value)
        {
            return new Constant(value);
        }
    }
}
