using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Emceelee.Math.Shared;

namespace Emceelee.Math.Interpolation
{
    public abstract class Interpolation
    {
        protected List<Point> _dataSet = new List<Point>();
        protected List<IFunction> _formulas = new List<IFunction>();

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

        public Point Interpolate(double x)
        {
            double y = 0;
            if (!_initialized)
            {
                Initialize();
                //For n points, we should have n-1 interpolation functions
                Debug.Assert(_formulas.Count() == (_dataSet.Count() - 1));
            }

            if(x < DomainMin || x > DomainMax)
            {
                throw new ArgumentOutOfRangeException($"{x} does not fall within the domain of [{DomainMin},{DomainMax}]");
            }

            return new Point(x, y);
        }

        public double DomainMin
        {
            get { return _dataSet.Min(p => p.X); }
        }

        public double DomainMax
        {
            get { return _dataSet.Max(p => p.X); }
        }
    }
}
