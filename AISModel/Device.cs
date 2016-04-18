using System;
using System.Collections.Generic;

namespace AISModel
{
    public class Device
    {
        private int mId;

        private List<int> mConnectedTo;
        
        public Device(int pId)
        {
        
            mId = pId;
            mConnectedTo = new List<int>();
        }
        
        public bool IsLinkExist(int pIdDevice)
        {
            return mConnectedTo.Exists(x => x == pIdDevice);
            //for(int i = 0; i < mConnectedTo.Count; i++) {
            //    if(mConnectedTo[i] == pIdDevice) {
            //        return true;
            //    }
            //}

            //return false;
        }

        public void AddLinkToDevice(int pIdDevice)
        {
            if(mId != pIdDevice) {
                if(!IsLinkExist(pIdDevice)) {
                    mConnectedTo.Add(pIdDevice);
                }
            }
        }

        public List<int> GetLinkDevices()
        {
            return mConnectedTo;
        }

    }
}