namespace AISModel
{
    public class Detector
    {
		public Detector() {
		}

		public PacketType HandleNetPacket(NetworkPacket pPacket) {

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

		private PacketType Recognize(NetworkPacket pPacket) {
			//do magic
			return pPacket.GetPacketType; 
		}
    }
}