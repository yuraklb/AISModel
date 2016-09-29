using System;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace AISModel
{
	public class CPlot
	{
		LineSeries mCountNormalPackets;
		LineSeries mCountWarningPackets;
		LineSeries mCountErrorPackets;

		PlotModel plotModel;

		public CPlot() {

			plotModel = new PlotModel();

			plotModel.Title = "Trigonometric functions";
			plotModel.Subtitle = "Example using the FunctionSeries";
			plotModel.PlotType = PlotType.XY;// Cartesian
			plotModel.Background = OxyColors.White;

			plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
			plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });

			mCountNormalPackets = new LineSeries {
				MarkerType = MarkerType.Circle,
				MarkerSize = 4,
				MarkerStroke = OxyColors.White,

					
			};
			mCountWarningPackets = new LineSeries();
			mCountErrorPackets = new LineSeries();

			plotModel.Series.Add(mCountNormalPackets);
			plotModel.Series.Add(mCountWarningPackets);
			plotModel.Series.Add(mCountErrorPackets);
		}

		public Gtk.Widget GetPlotView() {

//			plotModel.Series.Add(new FunctionSeries(Math.Sin, -10, 10, 0.1, "sin(x)"));
//			plotModel.Series.Add(new FunctionSeries(Math.Cos, -10, 10, 0.1, "cos(x)"));
//			plotModel.Series.Add(new FunctionSeries(t => 5 * Math.Cos(t), t => 5 * Math.Sin(t), 0, 2 * Math.PI, 0.1,"cos(t),sin(t)"));

			var plotView = new OxyPlot.GtkSharp.PlotView { Model = plotModel, Visible = true };

			plotView.SetSizeRequest(500, 400);

			return plotView;
		}

		public void AddCountPackets(int pIdRunIteration, int pCountNormalPackets, int pCountWarningPackets, int pCountErrorPackets) {

//			var r = new Random(100);
//			var y = r.Next(10, 30);
//			for (int x = 0; x <= 100; x += 10)
//			{
//				mCountNormalPackets.Points.Add(new DataPoint(x, y));
//				y += r.Next(-5, 5);
//			}

			mCountNormalPackets.Points.Add(new DataPoint(pIdRunIteration, pCountNormalPackets));
			mCountWarningPackets.Points.Add(new DataPoint(pIdRunIteration, pCountWarningPackets));
			mCountErrorPackets.Points.Add(new DataPoint(pIdRunIteration, pCountErrorPackets));


		} 
          
	}
}

