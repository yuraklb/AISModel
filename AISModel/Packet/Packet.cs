using System.Collections.Generic;

namespace AISModel
{
    public class Packet
    {

		private Queue<int> mRoute;

		private PacketType mType;

		public Packet(PacketType pType = PacketType.Normal) {
			mType = pType;
		}

		public PacketType GetPacketType() {
			return mType;
		}

		public void SetRoute(Queue<int> pRoute) {
			mRoute = pRoute;
		}

		public string GetRouteString() {
			string str = "";

			foreach(var item in mRoute) {
				str += ("=>" + item);
			}

			return str;
		}
	
    }
}