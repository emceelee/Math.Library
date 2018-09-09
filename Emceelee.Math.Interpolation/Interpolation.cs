using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Emceelee.Math.Shared;

namespace Emceelee.Math.Interpolation
{
    public abstract class Interpolation : IFunction
    {
        private List<Point> _dataSet = new List<Point>();
        protected List<PiecewiseFunction> _functions = new List<PiecewiseFunction>();

        private bool _initialized = false;

        public Interpolation(IEnumerable<Point> dataSet)
        {
            _dataSet.AddRange(dataSet.OrderBy(p => p.X));

            if(dataSet.Count() < 2)
            {
                throw new ArgumentOutOfRangeException("More than 2 points must be supplied for interpolation.");
            }
        }

        protected abstract void Initialize();

        public double Evaluate(double x)
        {
            if (!_initialized)
            {
                Initialize();
                _initialized = true;
                //For n points, we should have n-1 interpolation functions
                Debug.Assert(_functions.Count() == (_dataSet.Count() - 1));
            }

            /*
            double domainLength = DomainMax - DomainMin;
            if (x < DomainMin - domainLength * 0.01 || x > DomainMax + domainLength * 0.01)
            {
                throw new ArgumentOutOfRangeException($"{x} does not fall within the domain of [{DomainMin},{DomainMax}]");
            }
            */

            var function = _functions.FirstOrDefault();

            if (x <= function.Domain.Min)
            {
                return function.Evaluate(x);
            }

            function = _functions.OrderByDescending(f => f.Domain.Max).FirstOrDefault();
            if(x >= function.Domain.Max)
            {
                return function.Evaluate(x);
            }
            
            function = _functions.FirstOrDefault(f => f.Domain.IsValid(x));
            if(function != null)
            {
                return function.Evaluate(x);
            }

            Debug.Assert(false);
            return 0;
        }

        public double DomainMin
        {
            get { return _dataSet.Min(p => p.X); }
        }

        public double DomainMax
        {
            get { return _dataSet.Max(p => p.X); }
        }

        protected List<Point> DataSet
        {
            get
            {
                return _dataSet;
            }
        }
    }
}
