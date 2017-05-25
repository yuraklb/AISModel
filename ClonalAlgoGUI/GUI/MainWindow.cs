using Gtk;
using System;

using ClonalAlgo;

namespace ClonalAlgoGUI
{

	public delegate void StartStopFunctionDelegate(); 

	public class MainWindow : Gtk.Window
	{
		void StartStopButton_Clicked(object sender, EventArgs e)
		{
			pPlot.Clear();
			Logger.Clear();

			var dv = ClonalAlgo.Algorithm.Compute();

			int i = 0;

			foreach (var item in dv.mPopulations) {
				pPlot.AddData(i, item.BestAffinity);
				i++;
			}

			Logger.AddDataView(dv);

		}

		LogWindow logWindow;

		CPlot pPlot;

		public MainWindow() : base("Clonal Algorithm")
		{
					
			pPlot = new CPlot();

			logWindow = new LogWindow();
			logWindow.ShowAll();

			this.DeleteEvent += (o, args) => {
				args.RetVal = true;
				Application.Quit();
			};

			this.SetSizeRequest(700, 500);

			VBox vbox1 = new VBox(false, 0);

			vbox1.PackStart(pPlot.GetPlotView(), true, false, 0);

			Button showLogButton = new Button("Log");

			showLogButton.Clicked += (object sender, EventArgs e) => {
				
				logWindow.ShowAll();
			};

			vbox1.PackStart(showLogButton, false, false, 0);

			Button startStopButton = new Button("Run");
			startStopButton.Clicked += StartStopButton_Clicked; 

			vbox1.PackStart(startStopButton, false, false, 0);
			this.Add(vbox1);


			Logger.SetLogger(logWindow.GetListStore());

		}
	}
}

