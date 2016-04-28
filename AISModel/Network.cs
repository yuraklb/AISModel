using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace AISModel
{
    public class Network
    {
        private List<Device> mDevices;

        private NetProtocol mProtocol;
        
        public Network()
        {
            mDevices = new List<Device>();
            mProtocol = new NetProtocol();
        }

        public void Init()
        {
            
        }

        public void GenerateConnectedLinks(int pIdDevice)
        {
            for(int i = 0; i < mCountDevices; i++) {
                if(rnd.Next(1, 100) < mTmpPerc) {
                    mDevices[pIdDevice].AddLinkToDevice(i);
                   // mDevices[i].AddLinkToDevice(pIdDevice);
                    Console.WriteLine("Connect {0} <==> {1}", pIdDevice, i);
                }
            }
        }

        public void GenerateGraphFile()
        {
            StreamWriter sw = new StreamWriter("graph.dot", false);

            sw.WriteLine("graph graphname");
            sw.WriteLine("{");

            for(int i = 0; i < mDevices.Count; i++) {
                foreach(int linkDevice in mDevices[i].GetLinkDevices()) {
                    sw.WriteLine("{0} -- {1};", i, linkDevice);
                }
            }

        sw.WriteLine("}");
            sw.Close();

        }
        
        public void RunIteration()
        {
            //Destination

            //GetNetPackages
        }
    }
}