using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYNCOMLib;
using SYNCTRLLib;
using System;
using System.Collections;

namespace TP_Test1
{
    public enum TP_Region
    {
        topright,
        topleft,
        center,
        bottomright,
        bottomleft
    };
     
    class Program
    {
        
   
      
               

        static void Main(string[] args)
        {
            
            Syn mySyn = new Syn();
            //mySyn.SynTP_Dev_OnPacket();
            //System("pause");
            System.Threading.Thread.Sleep(50000);
        }
    }
}
