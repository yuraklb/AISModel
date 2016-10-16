using System;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace AISAlgo
{

	public delegate void TDOnAppendNewValueHandler();

	public class CPlot
	{
		public event TDOnAppendNewValueHandler OnAppendNewValue;

		LineSeries mCountAntigenes;
		LineSeries mCountDetectors;
		LineSeries mCountAntibodies;

		PlotModel plotModel;

		public CPlot() {

			plotModel = new PlotModel();

			plotModel.Title = "AIS Model";
			plotModel.PlotType = PlotType.XY;// Cartesian
			plotModel.Background = OxyColors.White;

			plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
			plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });


			mCountAntigenes = new LineSeries {
//				MarkerType = MarkerType.Circle,
//				MarkerSize = 4,
//				MarkerStroke = OxyColors.Red,
				Title = "Antigenes"
			};

			mCountDetectors = new LineSeries {
//				MarkerType = MarkerType.Cross,
//				MarkerSize = 4,
//				MarkerStroke = OxyColors.Blue,
				Title = "Detectors"
			};

			mCountAntibodies = new LineSeries {
//				MarkerType = MarkerType.Cross,
//				MarkerSize = 4,
//				MarkerStroke = OxyColors.Green,
				Title = "Antibodies"
			};

			plotModel.Series.Add(mCountAntigenes);
			plotModel.Series.Add(mCountDetectors);
			plotModel.Series.Add(mCountAntibodies);
		}

		public Gtk.Widget GetPlotView() {

			var plotView = new OxyPlot.GtkSharp.PlotView { Model = plotModel, Visible = true };

			plotView.SetSizeRequest(500, 400);

			return plotView;
		}

		public void AddPoints(int pIdRunIteration, double pCountNormalPackets, double pCountWarningPackets, double pCountErrorPackets) {

			mCountAntigenes.Points.Add(new DataPoint(pIdRunIteration, pCountNormalPackets));
			mCountDetectors.Points.Add(new DataPoint(pIdRunIteration, pCountWarningPackets));
			mCountAntibodies.Points.Add(new DataPoint(pIdRunIteration, pCountErrorPackets));

			plotModel.InvalidatePlot (true);

			//OnAppendNewValue();
		} 
          

		public void Clear() {

			foreach (var axis in plotModel.Axes) {
				axis.Reset ();
			}

			mCountAntigenes.Points.Clear ();
			mCountDetectors.Points.Clear ();
			mCountAntibodies.Points.Clear ();


		}

	}
}

