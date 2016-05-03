using System;

namespace AISModel
{
	public static class NetPacketGenerator
	{
		public static NetPacket GetPacketError() {
			return new NetPacket(PacketType.Error);				
		}

		public static NetPacket GetPacketWarning() {
			return new NetPacket(PacketType.Warning);
		}

		public static NetPacket GetPacketNormal() {
			return new NetPacket(PacketType.Normal);
		}
	}
}

