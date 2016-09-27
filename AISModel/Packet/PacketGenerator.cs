using System;
using System.Collections.Generic;

namespace AISModel
{
	public class PacketGenerator
	{
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
					Console.WriteLine("ERROR GENERATE");
					break;
				case 2:
				case 3:
				case 4:
					np = GetPacketWarning();
					Console.WriteLine("WARNING GENERATE");
					break;
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
					default:
					np = GetPacketNormal();
					break;
			}

			np.SetRoute(GenerateRoute(pMaxId));

			return np;

		}

		private Packet GetPacketError() {
			return new Packet(PacketType.Error);				
		}

		private Packet GetPacketWarning() {
			return new Packet(PacketType.Warning);
		}

		private Packet GetPacketNormal() {
			return new Packet(PacketType.Normal);
		}

		private Queue<int> GenerateRoute(int pMaxId) {

			Queue<int> route = new Queue<int>();

			int maxhop = 0;

			maxhop = RandomGenerator.GetRandomInt(1, pMaxId);

			for(int i = 0; i < maxhop; i++) {

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

