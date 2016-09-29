using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

using Gtk;



//			foreach(var item in myNetwork.GetDevices()) {
//				List<Packet> l = PacketGenerator.GetListPacketsWithRoute(State.MaxDevices);
//				foreach(var packet in l) {
//					item.AddIncomingPacket(packet);
//				}
//			}

//myNetwork.RunIteration();

//			foreach(var item in myNetwork.GetDevices()) {
//				item.PrintInfo();
//			}

//NetworkGenerator.GenerateConnectedLinks(myNetwork.GetDevices());

namespace AISModel
{
	
    class Program
    {

        static void Main(string[] args) {

			Application.Init();

            Network myNetwork = new Network();

			myNetwork.AddDevices(NetworkGenerator.GenerateDevices(State.MaxDevices));

			CPlot plot = new CPlot();

			State.SetDelegate(plot.AddCountPackets);

			MainWindow window = new MainWindow(myNetwork, plot);

			Logger.SetLogger(window.GetListStore());

			window.SetDelegate(Protocol.RunIteration);

			window.ShowAll();
		
			Application.Run();

            //myNetwork.GenerateGraphFile();

        }
    }
}
