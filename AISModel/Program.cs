using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISModel
{
    class Program
    {
        static void Main(string[] args) {

			const int CountDevices = 10;

            State.Init();

            Network myNetwork = new Network();

			myNetwork.AddDevices(NetworkGenerator.GenerateDevices(CountDevices));

			foreach(var item in myNetwork.GetDevices()) {
				List<Packet> l = PacketGenerator.GetListPacketsWithRoute(CountDevices);
				foreach(var packet in l) {
					item.AddIncomingPacket(packet);
				}
			}

			foreach(var item in myNetwork.GetDevices()) {
				item.PrintInfo();
			}

			//NetworkGenerator.GenerateConnectedLinks(myNetwork.GetDevices());





//            for(int i = 0; i < 100; i++) {
//                myNetwork.RunIteration();
//            }

            //myNetwork.GenerateGraphFile();


        }
    }
}
