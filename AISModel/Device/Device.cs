using System;
using System.Collections.Generic;

namespace AISModel
{
    public class Device
    {
        private int mId;

		private PacketGenerator mPacketGenerator = new PacketGenerator();

//        private List<int> mConnectedTo;
//		public bool IsLinkExist(int pIdDevice)
//		{
//			return mConnectedTo.Exists(x => x == pIdDevice);
//		}
//
//		public void AddLinkToDevice(int pIdDevice)
//		{
//			if(mId != pIdDevice) {
//				if(!IsLinkExist(pIdDevice)) {
//					mConnectedTo.Add(pIdDevice);
//				}
//			}
//		}
//
//		public List<int> GetLinkDevices()
//		{
//			return mConnectedTo;
//		}


		private Queue<Packet> mIncoming = new Queue<Packet>();
		private Queue<Packet> mOutgoing = new Queue<Packet>();

		private List<Detector> mDetectors = new List<Detector>();
        
        public Device(int pId)
        {
            mId = pId;
            //mConnectedTo = new List<int>();
        }

		public int GetId() {
			return mId;
		}

		public void AddIncomingPacket(Packet pPacket) {
			mIncoming.Enqueue(pPacket);
		}

		public Queue<Packet> GetOutgoingPacket() {
			return mOutgoing;
		}

		public void RunIteration() {

			SendRandomPackets();

			if(mIncoming.Count > 0) {

				Packet p = mIncoming.Dequeue();

				if(p.GetPacketType() != PacketType.Error) {
					if(p.GetPacketType() == PacketType.Warning) {
						Console.WriteLine("Warning!");
					} 

					if(p.GetRouteHop() > 0) {
						mOutgoing.Enqueue(p);
					} else {
						Console.WriteLine("Packet delivered!");
					}
				} else {
					Console.WriteLine("Destroy error!");
				}
			}
		}

		private void SendRandomPackets() {
			var list = mPacketGenerator.GetListPacketsWithRoute(State.MaxDevices);

			foreach(var l in list) {
				mOutgoing.Enqueue(l);
			}

		}
    }
}