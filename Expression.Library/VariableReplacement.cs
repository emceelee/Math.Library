using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Library
{
    public class VariableReplacement
    {
        public string Token { get; private set; }
        public double Value { get; private set; }

        public VariableReplacement(string token, double value)
        {
            Token = token;
            Value = value;
        }
    }
}
