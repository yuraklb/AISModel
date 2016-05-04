using System;

namespace AISModel
{
	public static class NetworkPacketGenerator
	{
		public static NetworkPacket GetPacketError() {
			return new NetworkPacket(PacketType.Error);				
		}

		public static NetworkPacket GetPacketWarning() {
			return new NetworkPacket(PacketType.Warning);
		}

		public static NetworkPacket GetPacketNormal() {
			return new NetworkPacket(PacketType.Normal);
		}
	}
}

