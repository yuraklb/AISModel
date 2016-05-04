namespace AISModel
{
    public class NetworkPacket
    {
		private PacketType mType;

		public NetworkPacket(PacketType pType = PacketType.Normal) {
			mType = pType;
		}

		public PacketType GetPacketType() {
			return mType;
		}
	
    }
}