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

        private int mCountDevices;

        private int mTmpPerc;

        private Random rnd;// = new Random();

        public Network(int pDefaultCountDevices = 10)
        {
            mTmpPerc = 5;

            rnd = new Random();

            mCountDevices = pDefaultCountDevices;
            mDevices = new List<Device>();
            mProtocol = new NetProtocol();
        }

        public void Init()
        {
            //Generate network devices
            for(int i = 0; i < mCountDevices; i++) {
                mDevices.Add(new Device(i));
            }

            for(int i = 0; i < mCountDevices; i++) {
                GenerateConnectedLinks(i);
            }
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