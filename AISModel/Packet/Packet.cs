using System.Collections.Generic;

namespace AISModel
{
    public class Packet
    {
		private int mId;

		private Queue<int> mRoute;

		private PacketType mType;

		public Packet(int pId, PacketType pType = PacketType.Normal) {
			mId = pId;
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

		public int GetRouteHops() {
			return mRoute.Count;
		}

		public int GetNextDeviceId() {
			return mRoute.Dequeue();
		}
	
		public int GetId() {
			return mId;
		}

    }
}