using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Ivi.Visa.Interop;



namespace Intel_unit_Test
{
    public class ScpiDemoSim : ScpiDemo
    {
        
        public ScpiDemoSim(string openString): base(openString)
        {
            
        }
        public override bool Initialize(out string outMessage)
        {
            outMessage = string.Empty;
            return true;            
        }
        
        public override void SendScpi(string Command)
        {
            
        }
         
        public override string QueryScpi (string Command)
        {             
            return "ok";
        }

        public override void OutQueryScpi(string Command, out string Res)
        {
            Res = "ok";           
        }

        public override void Close()
        {
             
        }

    }
}
