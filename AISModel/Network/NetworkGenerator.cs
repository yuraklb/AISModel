using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISModel
{
    internal class NetworkGenerator
    {
        public static List<Device> GenerateDevices(int mCountDevices, int mTmpPerc = 5)
        {
			List<Device> mListDevices = new List<Device>(mCountDevices);

            for(int i = 0; i < mCountDevices; i++) {
				mListDevices.Add(new Device(i));
            }

			return mListDevices;
        }

//		public static void GenerateConnectedLinks(List<Device> pListDevices, int pTmpPerc = 5)
//		{
//			foreach (Device device in pListDevices) {
//				for(int i = 0; i < pListDevices.Count; i++) {
//					if(RandomGenerator.GetRandomInt(1, 100) < pTmpPerc) {
//						device.AddLinkToDevice(i);
//						Console.WriteLine("Connect {0} <==> {1}", device.GetId(), i);
//					}
//				}	
//			}
//		}
    }
}
