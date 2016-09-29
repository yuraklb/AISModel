using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace AISModel
{
	public delegate void TDUpdateDataInPlot(int pIdRunIteration, int pCountNormalPackets, int pCountWarningPackets, int pCountErrorPackets);

    public static class State
    {
		private static List<NetworkState> mListNetworkState = new List<NetworkState>();

		public static int MaxDevices = 5;

		public static TDUpdateDataInPlot UpdateDataInPlot;

		private static void AddNetworkState(int pIdRunIteration, int pCountNormalPackets, int pCountWarningPackets, int pCountErrorPackets) {
			mListNetworkState.Add(new NetworkState(pIdRunIteration, pCountNormalPackets, pCountWarningPackets, pCountErrorPackets));
		}

		public static List<NetworkState> GetNetworkState() {
			return mListNetworkState;
		}

		public static void SetDelegate(TDUpdateDataInPlot deleg) {
			UpdateDataInPlot = deleg;
		}

		public static void AppendNetworkState(int pIdRunIteration, List<Device> pDevices) {
			int countNormalPackets = 0;
			int countWarningPackets = 0;
			int countErrorPackets = 0;

			foreach(var device in pDevices) {
				Queue<Packet> tmpIncoming = device.GetIncomintPackets();
				Queue<Packet> tmpOutgoing = device.GetOutgoingPackets();

				foreach(var packet in tmpIncoming) {
					switch(packet.GetPacketType()) {
						case PacketType.Normal:
							countNormalPackets++;
							break;
						case PacketType.Warning:
							countWarningPackets++;
							break;
						case PacketType.Error:
							countErrorPackets++;
							break;
					}
				}

				foreach(var packet in tmpOutgoing) {
					switch(packet.GetPacketType()) {
						case PacketType.Normal:
							countNormalPackets++;
							break;
						case PacketType.Warning:
							countWarningPackets++;
							break;
						case PacketType.Error:
							countErrorPackets++;
							break;
					}
				}


			}

			//mListNetworkState.Add(new NetworkState(pIdRunIteration, countNormalPackets, countWarningPackets, countErrorPackets));

			UpdateDataInPlot(pIdRunIteration, countNormalPackets, countWarningPackets, countErrorPackets);
						
		}

    }
}