using Agilent.Ag3352x.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaveformGenerator33500BApi
{
    public interface IWafeForm
    {
        void NotifyError(bool state, string err);
    }
    public enum CHANNLES
    {
        Channel1,
        Channel2,
        Notset
    }
    public struct WFGen33500BInfo
    {
        public string Identifier;
        public string Revision;
        public string Vendor;
        public string Description;
        public string Model;
        public string FirmwareRev;
        public string Serial;
        public bool Simulate;
    }

    public class WaveformGenerator33500B  
    {
        protected bool m_init = false;
        protected Ag3352x driver = null;
        protected Ivi.Fgen.Interop.IIviFgen driver1 = null;
        protected string m_resourceDesc = "TCPIP0::<ip or hostname>::INSTR";
         
        public WaveformGenerator33500B(string visaName)
        {
            m_resourceDesc = visaName;
        }
        protected IWafeForm pWafeForm = null;


        public bool IsInit()
        {
            return m_init;
        }
        public void IsInit(bool e)
        {
            m_init = e;
        }
        public virtual bool Initialize(out string outMessage, out WFGen33500BInfo info , IWafeForm p = null)
        {
            lock (this)
            {
                outMessage = string.Empty;
                info = new WFGen33500BInfo();
                try
                {
                    // Create driver instance
                    driver = new Ag3352x();

                    // Edit resource and options as needed.  Resource is ignored if option Simulate=true


                    string initOptions = "QueryInstrStatus=true, Simulate=false, DriverSetup= Model=, Trace=false";
                    bool idquery = true;
                    bool reset = true;

                    // Initialize the driver.  See driver help topic "Initializing the IVI-COM Driver" for additional information
                    driver.Initialize(m_resourceDesc, idquery, reset, initOptions);

                    info.Identifier = driver.Identity.Identifier;
                    info.Revision = driver.Identity.Revision;
                    info.Vendor = driver.Identity.Vendor;
                    info.Description = driver.Identity.Description;
                    info.Model = driver.Identity.InstrumentModel;
                    info.FirmwareRev = driver.Identity.InstrumentFirmwareRevision;
                    info.Serial = driver.System.SerialNumber;
                    info.Simulate = driver.DriverOperation.Simulate;
                    m_init = true;
                    return true;
                }
                catch (Exception err)
                {
                    outMessage = err.Message;
                    return false;
                }
            }
        }
        
        public virtual void Clear()
        {
            lock (this)
            {
                driver.Status.Clear();
            }
        }
        public virtual void Reset()
        {
            lock (this)
            {
                driver.Utility.Reset();
            }
        }
        
       
        CHANNLES m_channel = CHANNLES.Notset;
        IAg3352xChannel3 pAg3352xChannel = null;

        public virtual void SetChannel(CHANNLES channel)
        {

           
            if (m_channel == channel)
                return;
            if (channel == CHANNLES.Channel1)
            {
                pAg3352xChannel = driver.Channels3.get_Item3("Channel1");
                m_channel = channel;
            }
            if (channel == CHANNLES.Channel2)
            {
                pAg3352xChannel = driver.Channels3.get_Item3("Channel2");
                m_channel = channel;
            }
        }
        public virtual void OutputLoad(CHANNLES channel, double value)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.Output3.Load = value;
            }            
        }

        public virtual void SetOutputFunction(CHANNLES channel, Ag3352xOutputFunctionEnum function)
        {

            lock (this)
            {
                SetChannel(channel);

                pAg3352xChannel.OutputFunction.Function = function;
            }
        }

        public virtual Ag3352xOutputFunctionEnum GetOutputFunction(CHANNLES channel)
        {
            lock (this)
            {
                SetChannel(channel);
                return pAg3352xChannel.OutputFunction.Function;
            }
        }
        public virtual void SetOutputFrequency(CHANNLES channel, double frequencyInHz)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.Output.Frequency = frequencyInHz;
            }
        }
        public virtual void GetOutputFrequency(CHANNLES channel, out double frequencyInHz)
        {
            lock (this)
            {
                SetChannel(channel);
                frequencyInHz = pAg3352xChannel.Output.Frequency;
            }
        }
        public virtual void SetOutputVoltageAmplitude(CHANNLES channel, double value)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.Output.Voltage.Amplitude = value;
            }
        }
        public virtual void SetDCOffset(CHANNLES channel, double value)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.Output.Voltage.Offset.DCOffset = value;
            }
        }

        public virtual void SetPulseWidth(CHANNLES channel, double value)
        {
            lock (this)
            {
                pAg3352xChannel.OutputFunction.Pulse.Width = value;
            }
        }

        public virtual void SetOutput3VoltageAmplitude(CHANNLES channel, double value)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.Output3.Voltage.Amplitude = value;
            }
        }

        public virtual void SetOutput2VoltageAmplitude(CHANNLES channel, double value)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.Output2.Voltage.Amplitude = value;
            }
        }

        public virtual void GetOutputVoltageAmplitude(CHANNLES channel, out double value)
        {
            lock (this)
            {
                SetChannel(channel);
                value = pAg3352xChannel.Output.Voltage.Amplitude;
            }
        }

        public virtual void SetAMMode(CHANNLES channel, Ag3352xAMModeEnum mode)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.AM.Mode = Ag3352xAMModeEnum.Ag3352xAMModeDSSC;
            }
        }
        public virtual void SetAMSource(CHANNLES channel, Ag3352xModulationSourceEnum source)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.AM.Source = source;
            }
        }

        public virtual void SetAMInternalFunction(CHANNLES channel, Ag3352xModulationInternalFunctionEnum function)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.AM.InternalFunction = function;
            }
        }
        public virtual void SetAMInternalFrequency(CHANNLES channel, double value)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.AM.InternalFrequency = 1000;
            }
        }

        public virtual void SetAMDepth(CHANNLES channel, double value)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.AM.Depth = value;
            }
        }
 
        public virtual void AMEnabled(CHANNLES channel, bool en)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.AM.Enabled = en;
            }
        }
        public virtual void OutputEnable(CHANNLES channel, bool enable)
        {
            lock (this)
            {
                SetChannel(channel);
                pAg3352xChannel.Output.Enabled = enable;
            }            
        }
        public virtual void Close()
        {
            if (driver != null & driver.Initialized == true)
            {
                try
                {
                    driver.Close();
                }
                catch (Exception  err)
                {

                }
                driver = null;
            }
        }

        public virtual void SetPulsePeriod(CHANNLES channel , double period)
        {
            lock (this)
            {
                pAg3352xChannel.OutputFunction.Pulse.Period = 1E-3;
            }
        }
        public virtual void SetPulseDutyCycle(CHANNLES channel , double dutyCycle)
        {
            lock (this)
            {
                pAg3352xChannel.OutputFunction.Pulse.DutyCycle = dutyCycle;
            }
        }
        public virtual void SetPulseTransitionEdgeTime(CHANNLES channel, double edgeTime)
        {
            lock (this)
            {
                pAg3352xChannel.OutputFunction.Pulse.Transition.EdgeTime = edgeTime;
            }
        }

        public virtual void RecallState(int state)
        {
            lock (this)
            {
                driver.StateStorage.Recall(state);
            }
        }
        public virtual void SaveState(int state)
        {
            lock (this)
            {
                driver.StateStorage.Save(state);
            }
        }
        public virtual void GetOutputLoadMinMax(CHANNLES channel, out double min, out double max)
        {
            lock (this)
            {
                SetChannel(channel);
                min = pAg3352xChannel.Output3.LoadMin;
                max = pAg3352xChannel.Output3.LoadMax;
            }
        }

        public virtual void LoadStateFromFile(string fileName)
        {
            lock (this)
            {
                driver.Memory.LoadState(fileName);
            }
        }

        public virtual void LoadStateFromFile2(string fileName)
        {
            lock (this)
            {
                driver.Memory.Load(fileName);
            }
        }

    }
}
