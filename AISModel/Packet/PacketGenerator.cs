using System;
using System.Collections.Generic;

namespace AISModel
{
	public static class PacketGenerator
	{
		public static List<Packet> GetListPacketsWithRoute(int pMaxId, int pMaxCountPackets = 10) {
			List<Packet> l = new List<Packet>();

			int cntPackets = RandomGenerator.GetRandomInt(1, pMaxCountPackets);

			for(int i = 0; i < cntPackets; i++) {
				l.Add(GetPacketWithRoute(pMaxId));
			}

			return l;


		}

		public static Packet GetPacketWithRoute(int pMaxId) {
			Packet np;

			np = GetPacketNormal();

			np.SetRoute(GenerateRoute(pMaxId));

			return np;

		}

		public static Packet GetPacketError() {
			return new Packet(PacketType.Error);				
		}

		public static Packet GetPacketWarning() {
			return new Packet(PacketType.Warning);
		}

		public static Packet GetPacketNormal() {
			return new Packet(PacketType.Normal);
		}

		public static Queue<int> GenerateRoute(int pMaxId) {

			Queue<int> route = new Queue<int>();

			int cnt = 0;

			cnt = RandomGenerator.GetRandomInt(1, 10);

			for(int i = 0; i < cnt; i++) {

				do {

					int tmpId = RandomGenerator.GetRandomInt(1, pMaxId);
					if(route.Contains(tmpId)) {
						continue;
					} else {
						route.Enqueue(tmpId);
						break;
					}
				} while(true);
			}

			return route;
		}
	}
}

