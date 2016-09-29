using System;
using System.Collections.Generic;

namespace AISModel
{
	public static class Protocol
	{
		private static int mIdRunIteration = 0;

		private static void TransportPacketTo(int pId, Packet pPacket, List<Device> pDevices) {
			foreach(var device in pDevices) {
				if(device.GetId() == pId) {
					device.AddIncomingPacket(pPacket);
				}
			}
		}

		public static void RunIteration(Network pNetwork)
		{

			List<Device> pDevices = pNetwork.GetDevices();

			foreach(var device in pDevices) {
				device.AddRandomPacketForOutgoing();
				device.HandlePackets();
			}

			foreach(var device in pDevices) {
				Queue<Packet> queue = device.GetOutgoingPackets();
				while(queue.Count > 0) {
					Packet p = queue.Dequeue();
					int id = p.GetNextDeviceId();
					TransportPacketTo(id, p, pDevices);
				}
			}

			State.AppendNetworkState(mIdRunIteration++, pDevices);
		}

	}
}

