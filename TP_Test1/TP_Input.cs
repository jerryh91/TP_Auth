using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Test1
{
    //Predefined Regions Inputs
  
    class TP_Input
    {
        public int IntRegion { get;}
        
        //Constructor
        public TP_Input (TP_Region newRegion)
        {
            IntRegion = (int) newRegion;
        } 
    }
}
