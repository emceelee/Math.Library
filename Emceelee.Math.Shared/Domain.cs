using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emceelee.Math.Shared
{
    public struct Domain
    {
        public double Min {get; private set;}
        public double Max { get; private set; }
        public bool MinInclusive { get; private set; }
        public bool MaxInclusive { get; private set; }

        public Domain(double min, double max, bool minInclusive = true, bool maxInclusive = false)
        {
            Min = min;
            Max = max;
            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
        }

        public bool IsValid(double x)
        {
            if (MinInclusive)
            {
                if (x < Min)
                {
                    return false;
                }
            }
            else
            {
                if (x <= Min)
                {
                    return false;
                }
            }

            if (MaxInclusive)
            {
                if (x > Max)
                {
                    return false;
                }
            }
            else
            {
                if (x >= Max)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string lowerBound = "(";
            string upperBound = ")";

            if (MinInclusive)
            {
                lowerBound = "[";
            }
            if (MaxInclusive)
            {
                upperBound = "]";
            }

            return $"{lowerBound}{Min},{Max}{upperBound}";
        }
    }
}
