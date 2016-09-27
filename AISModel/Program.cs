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
			
            State.Init();

            Network myNetwork = new Network();

			myNetwork.AddDevices(NetworkGenerator.GenerateDevices(State.MaxDevices));

//			foreach(var item in myNetwork.GetDevices()) {
//				List<Packet> l = PacketGenerator.GetListPacketsWithRoute(State.MaxDevices);
//				foreach(var packet in l) {
//					item.AddIncomingPacket(packet);
//				}
//			}

			myNetwork.RunIteration();

//			foreach(var item in myNetwork.GetDevices()) {
//				item.PrintInfo();
//			}

			//NetworkGenerator.GenerateConnectedLinks(myNetwork.GetDevices());





//            for(int i = 0; i < 100; i++) {
//                myNetwork.RunIteration();
//            }

            //myNetwork.GenerateGraphFile();


        }
    }
}
