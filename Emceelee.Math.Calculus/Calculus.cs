using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emceelee.Math.Interpolation;
using Emceelee.Math.Shared;

namespace Emceelee.Math.Calculus
{
    public static class Calculus
    {
        public static IFunction Differentiate(IFunction func, double xMin, double xMax, int granularity)
        {
            var points = new List<Point>();
            double xDiff = xMax - xMin;
            double delta = xDiff / granularity;

            double x = xMin;
            for (int i = 0; i < granularity; ++i)
            {
                double xa = x - delta / 2;
                double xb = x + delta / 2;

                double ya = func.Evaluate(xa);
                double yb = func.Evaluate(xb);

                double slope = (yb - ya) / (xb - xa);
                points.Add(new Point(x, slope));

                x += delta;
            }

            return new LinearInterpolation(points);
        }

        public static IFunction Integrate(IFunction func, double xMin, double xMax, int granularity)
        {
            var points = new List<Point>();
            double xDiff = xMax - xMin;
            double delta = xDiff / granularity;

            double x = xMin;
            double yPrev = 0;
            for (int i = 0; i < granularity; ++i)
            {
                double xa = x;
                double xb = x + delta;
                
                double ya = func.Evaluate(xa);
                double yb = func.Evaluate(xb);

                double area = delta * (ya + yb)/2;
                double y = yPrev + area;
                points.Add(new Point(x, y));

                x += delta;
                yPrev = y;
            }

            return new LinearInterpolation(points);
        }
    }
}
