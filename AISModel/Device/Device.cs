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
        }

		public int GetId() {
			return mId;
		}

		public void AddIncomingPacket(Packet pPacket) {
			mIncoming.Enqueue(pPacket);
		}

		public Queue<Packet> GetOutgoingPackets() {
			return mOutgoing;
		}

		public Queue<Packet> GetIncomintPackets() {
			return mIncoming;
		}

		public void HandlePackets() {
			
			Logger.AddLine(mId.ToString(), "Device START HANDLE", "START HANDLE INCOMING PACKETS");

			if(mIncoming.Count > 0) {

				Packet p = mIncoming.Dequeue();

				if(p.GetPacketType() != PacketType.Error) {
					if(p.GetPacketType() == PacketType.Warning) {
						Logger.AddLine(p.GetId().ToString(), "Packet", "WARNING DETECTED!");
					} 
					if(p.GetRouteHops() > 0) {
						Logger.AddLine(p.GetId().ToString(), "Packet", "PUT PACKET TO OUTGOING!");
						mOutgoing.Enqueue(p);
					} else {
						Logger.AddLine(p.GetId().ToString(), "Packet", "Packet delivered!!");
					}
				} else {
					Logger.AddLine(p.GetId().ToString(), "Packet", "Destroy error!");
				}
			}

			Logger.AddLine(mId.ToString(), "Device END HANDLE", "END HANDLE INCOMING PACKETS");
		}

		public void AddRandomPacketForOutgoing() {

			Logger.AddLine(mId.ToString(), "Device START GENERATE", "START GENERATE OUTGOING PACKETS");

			var list = mPacketGenerator.GetListPacketsWithRoute(State.MaxDevices);

			Logger.AddLine(mId.ToString(), "Device END GENERATE", "END GENERATE OUTGOING PACKETS");

			foreach(var l in list) {
				mOutgoing.Enqueue(l);
			}

		}
    }
}