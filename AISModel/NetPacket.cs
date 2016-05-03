namespace AISModel
{
    public class NetPacket
    {
		private PacketType mType;

		public NetPacket(PacketType pType = PacketType.Normal) {
			mType = pType;
		}

		public PacketType GetPacketType() {
			return mType;
		}
	
    }
}