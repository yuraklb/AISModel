namespace AISModel
{
    public class Detector
    {
		public Detector() {
		}

		public PacketType HandleNetPacket(NetPacket pPacket) {

			if (Recognize (pPacket) == PacketType.Error) {
				return PacketType.Error;
			}
			if (Recognize (pPacket) == PacketType.Warning) {
				return PacketType.Warning;
			}
			if (Recognize (pPacket) == PacketType.Normal) {
				return PacketType.Normal;
			}
		}

		private PacketType Recognize(NetPacket pPacket) {
			//do magic
			return pPacket.GetPacketType; 
		}
    }
}