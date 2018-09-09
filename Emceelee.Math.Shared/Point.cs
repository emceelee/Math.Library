﻿using System;

namespace Emceelee.Math.Shared
{
    public struct Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X {get; private set;}
        public double Y {get; private set;}
    }
}
