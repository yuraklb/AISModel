using System;
using System.Collections.Generic;

namespace AISModel
{
	public class PacketGenerator
	{
		private static int mId;

		public static int GetNewId() {

			object lock_object = new object();

			lock(lock_object) {
				mId++;
				return mId;
			}
		}

		public List<Packet> GetListPacketsWithRoute(int pMaxId, int pMaxCountPackets = 1) {
			List<Packet> l = new List<Packet>();

			int cntPackets = RandomGenerator.GetRandomInt(1, pMaxCountPackets);

			for(int i = 0; i < cntPackets; i++) {
				l.Add(GetPacketWithRoute(pMaxId));
			}

			return l;
		}

		private Packet GetPacketWithRoute(int pMaxId) {

			Packet np;

			int pType = RandomGenerator.GetRandomInt(0, 10);



			switch(pType) {
				case 0:
				case 1:
					np = GetPacketError();
					np.SetRoute(RouteGenerator.GenerateRoute(pMaxId));
					Logger.AddLine(np.GetId().ToString(), "Packet ERROR", "ERROR packet generated: " + np.GetRouteString());
					break;
				case 2:
				case 3:
				case 4:
					np = GetPacketWarning();
					np.SetRoute(RouteGenerator.GenerateRoute(pMaxId));
					Logger.AddLine(np.GetId().ToString(), "Packet WARNING", "WARNING packet generated: " + np.GetRouteString());
					break;
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
					default:
					np = GetPacketNormal();
					np.SetRoute(RouteGenerator.GenerateRoute(pMaxId));
					Logger.AddLine(np.GetId().ToString(), "Packet NORMAL", "NORMAL packet generated: " + np.GetRouteString());
					break;
			}

			return np;

		}

		private Packet GetPacketError() {
			return new Packet(GetNewId(), PacketType.Error);				
		}

		private Packet GetPacketWarning() {
			return new Packet(GetNewId(), PacketType.Warning);
		}

		private Packet GetPacketNormal() {
			return new Packet(GetNewId(), PacketType.Normal);
		}


	}
}

