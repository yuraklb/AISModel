using Gtk;

namespace AISModel
{
	
    class Program
    {

        static void Main(string[] args) {

			Application.Init();

            Network myNetwork = new Network();

			myNetwork.AddDevices(NetworkGenerator.GenerateDevices(State.MaxDevices));

			var plot = new CPlot();

			State.SetDelegate(plot.AddCountPackets);

			MainWindow window = new MainWindow(plot);

			Logger.SetLogger(window.GetListStore());

			window.SetDelegateStartStopFunction(Protocol.StartStopGenerateOutgoingTraffic);

			GLib.Timeout.Add(100, delegate {
				Protocol.RunIteration(myNetwork);	
				return true;
			});


			window.ShowAll();
		
			Application.Run();


			//NetworkGenerator.GenerateConnectedLinks(myNetwork.GetDevices());
            //myNetwork.GenerateGraphFile();

        }
    }
}
