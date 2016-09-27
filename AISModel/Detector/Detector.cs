namespace AISModel
{
    public class Detector
    {
		public Detector() {
		}

		public PacketType HandleNetPacket(Packet pPacket) {

			if (Recognize (pPacket) == PacketType.Error) {
				return PacketType.Error;
			}
			if (Recognize (pPacket) == PacketType.Warning) {
				return PacketType.Warning;
			}
			else {
				//if (Recognize (pPacket) == PacketType.Normal) 
				return PacketType.Normal;
			}
		}

		private PacketType Recognize(Packet pPacket) {
			//do magic
			return pPacket.GetPacketType(); 
		}
    }
}