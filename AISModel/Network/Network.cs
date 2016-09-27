using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace AISModel
{
    public class Network
    {
        private List<Device> mDevices;

        
        public Network()
        {
            mDevices = new List<Device>();
        }

		public void AddDevices(List<Device> pDevices) {
			mDevices = pDevices;
		}

		public List<Device> GetDevices() {
			return mDevices;
		}

		public void TransportPacketTo(int pId, Packet pPacket) {
			foreach(var device in mDevices) {
				if(device.GetId() == pId) {
					device.AddIncomingPacket(pPacket);
				}
			}
		}

//        public void GenerateGraphFile()
//        {
//            StreamWriter sw = new StreamWriter("graph.dot", false);
//
//            sw.WriteLine("graph graphname");
//            sw.WriteLine("{");
//
//            for(int i = 0; i < mDevices.Count; i++) {
//                foreach(int linkDevice in mDevices[i].GetLinkDevices()) {
//                    sw.WriteLine("{0} -- {1};", i, linkDevice);
//                }
//            }
//
//     		sw.WriteLine("}");
//            sw.Close();
//
//        }
        
        public void RunIteration()
        {
			for(int i = 0; i < 10; i++) {


				foreach(var device in mDevices) {
					device.RunIteration();
				}

				foreach(var device in mDevices) {
					Queue<Packet> queue = device.GetOutgoingPacket();
					while(queue.Count > 0) {
						Packet p = queue.Dequeue();
						int id = p.GetNextId();
						TransportPacketTo(id, p);
					}
				}
			}

            //Destination

            //GetNetPackages
        }
    }
}