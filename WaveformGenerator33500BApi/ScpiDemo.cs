using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Ivi.Visa.Interop;



namespace Intel_unit_Test
{
    public class ScpiDemo
    {
        protected ResourceManager ioMgr = new ResourceManager();
        protected FormattedIO488 instrument = new FormattedIO488();
        protected string m_openString;

        public ScpiDemo(string openString)
        {
            m_openString = openString;
        }
        public virtual bool Initialize(out string outMessage)
        {
            IVisaSession session = null;
            try
            {
                session = ioMgr.Open(m_openString, AccessMode.NO_LOCK, 3000, "");
                instrument.IO = (IMessage)session;
                instrument.IO.SendEndEnabled = false;
                instrument.IO.Timeout = 10000;                       //in milliseconds
                instrument.IO.TerminationCharacterEnabled = true;   //Defaults to false            

                //Determine whether the VSA process is running
                bool isCreated = false;
                instrument.WriteString("*IDN?");
                IdnString = instrument.ReadString();
                outMessage = string.Empty;
                return true;
            }
            catch (COMException ex)
            {
                outMessage = ex.Message;
                return false;
            }
        }

        ~ScpiDemo()
        {
            
        }  
       
        public string IdnString { get; set; }
         

        public virtual void SendScpi(string Command)
        {
            instrument.WriteString(Command);
        }
         
        public virtual string QueryScpi (string Command)
        {
            string res = string.Empty;
            instrument.WriteString(Command);
            res  = instrument.ReadString();
            res = res.Replace("\n", "");
            return res;

        }

        public virtual void OutQueryScpi(string Command, out string Res)
        {
            //string res = string.Empty;
            instrument.WriteString(Command);
            Res = instrument.ReadString();
           
        }

        public virtual void Close()
        {
            try
            {
                instrument.FlushRead();
                instrument.IO.Clear();
                instrument.IO.Close();
            }
            catch (Exception err)
            {

            }
        }

    }
}
