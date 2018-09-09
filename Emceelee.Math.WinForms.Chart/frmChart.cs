using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emceelee.Math.Calculus;
using Emceelee.Math.Expression;
using Emceelee.Math.Shared;

using System.Windows.Forms.DataVisualization.Charting;

namespace Emceelee.Math.WinForms.Chart
{
    public partial class frmChart : Form
    {
        int _granularity = 1000;
        double _xMin = 0;
        double _xMax = 100;

        private IFunction _function;

        public frmChart()
        {
            InitializeComponent();
        }

        private void frmChart_Load(object sender, EventArgs e)
        {
            _function = InitializeFunction();
            ResetSeries();
        }

        private IFunction InitializeFunction()
        {
            return new Cos("X") * new Sin((ExpressionBase)"X" / 10) * "X";
            //return (ExpressionBase) "X";
        }

        private double Evaluate(double x)
        {
            return _function.Evaluate(x);
        }

        private IEnumerable<Emceelee.Math.Shared.Point> ExtractPoints(DataPointCollection dpc)
        {
            return dpc.Select(dp => new Emceelee.Math.Shared.Point(dp.XValue, dp.YValues.FirstOrDefault()));
        }

        private IFunction GetDerivative()
        {
            return Emceelee.Math.Calculus.Calculus.Differentiate(_function, _xMin, _xMax, _granularity);
        }

        private IFunction GetIntegral()
        {
            return Emceelee.Math.Calculus.Calculus.Integrate(_function, _xMin, _xMax, _granularity);
        }

        private void ResetSeries()
        {
            chart1.Series.Clear();
            var series = new Series()
            {
                Name = "Series1",
                Color = System.Drawing.Color.Blue,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };

            chart1.Series.Add(series);
            
            double xDiff = _xMax - _xMin;
            double delta = xDiff / _granularity;

            double x = _xMin;
            for (int i = 0; i < _granularity; ++i)
            {
                series.Points.AddXY(System.Math.Round(x, 5), Evaluate(x));
                x += delta;
            }

            chart1.Invalidate();
        }

        private void btnDifferentiate_Click(object sender, EventArgs e)
        {
            _function = GetDerivative();
            ResetSeries();
        }

        private void btnIntegrate_Click(object sender, EventArgs e)
        {
            _function = GetIntegral();
            ResetSeries();
        }
    }
}
