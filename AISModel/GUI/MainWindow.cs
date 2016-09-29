using Gtk;
using System;

namespace AISModel
{

	public delegate void RunFunctionDelegate(Network pNetwork); 

	public class MainWindow : Gtk.Window
	{

		private RunFunctionDelegate RunFunction;

		LogWindow logWindow;

		public MainWindow(Network pNetwork, CPlot pPlot) : base("AIS Model")
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

			Button runIterationButton = new Button("Run");
			runIterationButton.Clicked += (object sender, EventArgs e) => {
				RunFunction(pNetwork);
				this.QueueDraw();
			};


			vbox1.PackStart(runIterationButton, false, false, 0);


			this.Add(vbox1);



			//window.BorderWidth = 10;
		}


		public void SetDelegate(RunFunctionDelegate pFunc) {
			RunFunction = pFunc;
		}

		public Gtk.ListStore GetListStore() {
			return logWindow.GetListStore();
		}

	}
}

