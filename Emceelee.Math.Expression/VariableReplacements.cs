using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emceelee.Math.Expression
{
    public class VariableReplacements
    {
        private Dictionary<string, VariableReplacement> _replacements;

        public VariableReplacements()
        {
            _replacements = new Dictionary<string, VariableReplacement>();
        }
        public VariableReplacements(IEnumerable<VariableReplacement> replacements)
        {
            _replacements = replacements.ToDictionary(vr => vr.Token, vr => vr);
        }

        public void Add(VariableReplacement replacement)
        {
            try
            {
                _replacements.Add(replacement.Token, replacement);
            }
            catch(ArgumentException ex)
            {
                throw new ArgumentException($"Token '{replacement.Token}' already exists in the collection.", ex);
            }
        }

        public double GetReplacement(string token)
        {
            VariableReplacement replacement = null;
            if(_replacements.TryGetValue(token, out replacement))
            {
                return replacement.Value;
            }

            throw new KeyNotFoundException($"Token '{token}' not provided.");
        }

        public void Clear()
        {
            _replacements.Clear();
        }
    }
}
