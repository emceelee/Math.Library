using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Library
{
    public class VariableReplacements
    {
        private Dictionary<char, VariableReplacement> _replacements;

        public VariableReplacements()
        {
            _replacements = new Dictionary<char, VariableReplacement>();
        }
        public VariableReplacements(List<VariableReplacement> replacements)
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

        public double GetReplacement(char token)
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
