using System;

namespace AISModel
{
	public static class ShowDeviceInfo
	{
		public static void Print(Device pDevice) {
			
			//Console.WriteLine("Device ID {0} has incoming {1} outgoing {2}", pDevice.GetId());
			Console.WriteLine("Device ID {0}", pDevice.GetId());

		}
	}
}

