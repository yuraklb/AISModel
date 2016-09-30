using Gtk;
using System;

namespace AISModel
{

	public delegate void StartStopFunctionDelegate(); 

	public class MainWindow : Gtk.Window
	{

		private StartStopFunctionDelegate StartStopFunction;

		LogWindow logWindow;

		public MainWindow(CPlot pPlot) : base("AIS Model")
		{
						
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
			startStopButton.Clicked += (object sender, EventArgs e) => {
				if(startStopButton.Label == "Run") {
					startStopButton.Label = "Stop";
				} else {
					startStopButton.Label = "Run";
				}
				StartStopFunction();
			};
			vbox1.PackStart(startStopButton, false, false, 0);
			this.Add(vbox1);

			pPlot.OnAppendNewValue += () => {
				this.QueueDraw();
			};
		}

		public void SetDelegateStartStopFunction(StartStopFunctionDelegate pFunc) {
			StartStopFunction = pFunc;
		}

		public Gtk.ListStore GetListStore() {
			return logWindow.GetListStore();
		}


	}
}

