using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Library
{
    public class VariableReplacement
    {
        public char Token { get; private set; }
        public double Value { get; private set; }

        public VariableReplacement(char token, double value)
        {
            Token = token;
            Value = value;
        }
    }
}
