using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYNCOMLib;
using SYNCTRLLib;
using SynConnType = SYNCTRLLib.SynConnectionType;
using SynDeviceType = SYNCTRLLib.SynDeviceType;
using SynOnPacketEventHandler = SYNCTRLLib._ISynDeviceCtrlEvents_OnPacketEventHandler;
using System.Collections;

namespace TP_Test1
{
    class Syn
    {
        #region Private fields

        SynAPICtrl synApiCtrl = new SynAPICtrl();
        SynDeviceCtrl synDeviceCtrl = new SynDeviceCtrl();
        SynPacketCtrl synPacketCtrl = new SynPacketCtrl();

        private readonly double xBLCornerCtr, yBLCornerCtr;
        readonly Hashtable regionUnicode = new Hashtable();
        #endregion

        SynAPICtrl SynTP_API = new SynAPICtrl();
        SynDeviceCtrl SynTP_Dev = new SynDeviceCtrl();
        SynPacketCtrl SynTP_Pack = new SynPacketCtrl();
        int DeviceHandle;
        double currFingerX, currFingerY;
        TP_Region currRegion;
        char currUnicode;

        //Constructor
        public Syn ()
        {

            SynTP_API.Initialize();
            SynTP_API.Activate();

            //Readonly instance field can only be initialized
            //in constructor or in variable declaration.
            xBLCornerCtr = 2;
            yBLCornerCtr = 4;  

            //Initialize Region to Unicode char in hashtable
            regionUnicode.Add(TP_Region.topleft, "hello");
            regionUnicode.Add(TP_Region.topright, "hello");
            regionUnicode.Add(TP_Region.center, "hello");
            regionUnicode.Add(TP_Region.bottomleft, "hello");
            regionUnicode.Add(TP_Region.bottomright, "hello");
            //ERR:
            //Resolved:
            //DeviceHandle == -1: Can't find device?
            //DeviceHandle = SynTP_API.FindDevice(new SynConnectionType(), new SynDeviceType(), 0);

            DeviceHandle = SynTP_API.FindDevice(SynConnType.SE_ConnectionAny, SynDeviceType.SE_DeviceTouchPad, -1);
            Console.WriteLine("Device Handle: {0} ", DeviceHandle);
            SynTP_Dev.Select(DeviceHandle);
            SynTP_Dev.Activate();
                
            SynTP_Dev.OnPacket += new SynOnPacketEventHandler(SynTP_Dev_OnPacket);
          

        }

        //Event handler 
        public void SynTP_Dev_OnPacket()
        {

            //SynTP_Dev.LoadPacket(SynTP_Pack);
            int loadPck = SynTP_Dev.LoadPacket(SynTP_Pack);
            if (loadPck == 1)
            {
                //ERR (12/3): Outputing 0s for FingerState, X, Y 
                //ERR (2/11): Not detecting X,Y from touch
                Console.WriteLine(DateTime.Now + "Finger State: {0}", SynTP_Pack.FingerState);
                currFingerX = SynTP_Pack.X;
                Console.WriteLine(DateTime.Now + "Finger X:{0} Y:{1}", SynTP_Pack.X, SynTP_Pack.Y);
                currFingerY = SynTP_Pack.Y;

                //Interpret absolute (x, y) into 1 of 5 regions on touchpad
                //currRegion = getRegion(currFingerX, currFingerY);

                //currUnicode = getUnicode(currRegion);
            }

           

        }

        //Interprets absolute coords as 1 of 5 regions

        //public TP_Region getRegion(double absX, double absY)
        //{

        //}

        //Interprets each region as a Unicode char
        //public string getUnicode(TP_Region myRegion)
        //{
        //    return regionUnicode[myRegion];
        //}
    }
}
