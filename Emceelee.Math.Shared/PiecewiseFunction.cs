using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emceelee.Math.Shared
{
    public class PiecewiseFunction : IFunction
    {
        private Domain _domain;
        private IFunction _function;
        private bool _validateDomain;

        public PiecewiseFunction(Domain domain, IFunction function, bool validateDomain = false)
        {
            _domain = domain;
            _function = function;
            _validateDomain = validateDomain;
        }

        public Domain Domain
        {
            get
            {
                return _domain;
            }
        }

        public double Evaluate(double x)
        {
            if(_validateDomain)
            {
                if(!_domain.IsValid(x))
                {
                    throw new ArgumentOutOfRangeException($"{x} does not fall within domain {_domain}.");
                }
            }

            return _function.Evaluate(x);
        }
    }
}
