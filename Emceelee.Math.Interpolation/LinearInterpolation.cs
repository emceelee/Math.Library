using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emceelee.Math.Expression;
using Emceelee.Math.Shared;

namespace Emceelee.Math.Interpolation
{
    public class LinearInterpolation : Interpolation
    {
        public LinearInterpolation(IEnumerable<Point> dataSet) : base(dataSet) { }

        protected override void Initialize()
        {
            for(int i = 0; i < DataSet.Count() - 1; ++i)
            {
                Point point1 = DataSet[i];
                Point point2 = DataSet[i+1];

                double slope = (point2.Y - point1.Y) / (point2.X - point1.X);

                var function = new PiecewiseFunction(new Domain(point1.X, point2.X), (ExpressionBase)slope * new Subtract("X", point1.X) + point1.Y);

                _functions.Add(function);
            }
        }
    }
}
