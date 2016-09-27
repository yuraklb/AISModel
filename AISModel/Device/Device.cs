using System;
using System.Collections.Generic;

namespace AISModel
{
    public class Device
    {
        private int mId;

        private List<int> mConnectedTo;

		private Queue<Packet> mIncoming;
		private Queue<Packet> mOutgoing;

        private List<Detector> mDetectors; 
        
        public Device(int pId)
        {
        
            mId = pId;
            mConnectedTo = new List<int>();
            mDetectors = new List<Detector>();

			mIncoming = new Queue<Packet>();
			mOutgoing = new Queue<Packet>();

        }
        
        public bool IsLinkExist(int pIdDevice)
        {
            return mConnectedTo.Exists(x => x == pIdDevice);
        }

        public void AddLinkToDevice(int pIdDevice)
        {
            if(mId != pIdDevice) {
                if(!IsLinkExist(pIdDevice)) {
                    mConnectedTo.Add(pIdDevice);
                }
            }
        }

        public List<int> GetLinkDevices()
        {
            return mConnectedTo;
        }

		public int GetId() {
			return mId;
		}

		public void AddIncomingPacket(Packet pPacket) {
			mIncoming.Enqueue(pPacket);
		}

		public Packet GetOutgoingPacket() {
			return mOutgoing.Dequeue();
		}

		public void PrintInfo() {

			Console.WriteLine("Device ID {0} has incoming {1} outgoing {2}", mId, mIncoming.Count, mOutgoing.Count);
			foreach(var item in mIncoming) {
				Console.WriteLine(item.GetRouteString());
			}


		}
    }
}