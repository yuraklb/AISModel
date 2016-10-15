using System;
using Gtk;

namespace AISAlgo
{
	public class MainWindow : Gtk.Window
	{

		public MainWindow(CPlot pPlot) : base("AIS Model")
		{
			
			this.DeleteEvent += (o, args) => {
				args.RetVal = true;
				Application.Quit();
			};

			this.SetSizeRequest(700, 500);

			VBox vbox1 = new VBox(false, 0);

			vbox1.PackStart(pPlot.GetPlotView(), true, false, 0);

			Button showLogButton = new Button("Log");

			showLogButton.Clicked += (object sender, EventArgs e) => {

				//logWindow.ShowAll();
			};

			vbox1.PackStart(showLogButton, false, false, 0);

			Button startStopButton = new Button("Run");
			startStopButton.Clicked += (object sender, EventArgs e) => {
				if(startStopButton.Label == "Run") {
					startStopButton.Label = "Stop";
				} else {
					startStopButton.Label = "Run";
				}
				//StartStopFunction();
			};
			vbox1.PackStart(startStopButton, false, false, 0);
			this.Add(vbox1);

			pPlot.OnAppendNewValue += () => {
				this.QueueDraw();
			};
		}
	}
}

