using System;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace ClonalAlgoGUI
{

	public class CPlot
	{
		LineSeries mBest;

		PlotModel plotModel;

		public CPlot() {

			plotModel = new PlotModel();

			plotModel.Title = "Best antibody";
			plotModel.Subtitle = "Example using clonal algo";
			plotModel.PlotType = PlotType.XY;// Cartesian
			plotModel.Background = OxyColors.White;

			plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
			plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });

			mBest = new LineSeries {
				MarkerType = MarkerType.Circle,
				MarkerSize = 4,
				MarkerStroke = OxyColors.White,
			};


			plotModel.Series.Add(mBest);
		}

		public Gtk.Widget GetPlotView() {

//			plotModel.Series.Add(new FunctionSeries(Math.Sin, -10, 10, 0.1, "sin(x)"));
//			plotModel.Series.Add(new FunctionSeries(Math.Cos, -10, 10, 0.1, "cos(x)"));
//			plotModel.Series.Add(new FunctionSeries(t => 5 * Math.Cos(t), t => 5 * Math.Sin(t), 0, 2 * Math.PI, 0.1,"cos(t),sin(t)"));

			var plotView = new OxyPlot.GtkSharp.PlotView { Model = plotModel, Visible = true };

			plotView.SetSizeRequest(500, 400);

			return plotView;
		}

		public void AddData(int pGeneration, int pAff) {

			mBest.Points.Add(new DataPoint(pGeneration, pAff));
			plotModel.InvalidatePlot(true);

		}

		public void Clear()
		{
			mBest.Points.Clear();
			plotModel.InvalidatePlot(true);
			//PlotView.InvalidatePlot(true);
			//plotModel.ResetAllAxes();
		}
          
	}
}

