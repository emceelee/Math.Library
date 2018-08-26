using System;
using System.Collections.Generic;

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
    }
}
