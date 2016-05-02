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
            List<Device> mDevices;

            Random rnd = new Random();

            //Generate network devices
            for(int i = 0; i < mCountDevices; i++) {
                mDevices.Add(new Device(i));
            }

            for(int i = 0; i < mCountDevices; i++) {
                GenerateConnectedLinks(i);
            }

        }
    }
}
