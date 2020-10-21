using Agilent.Ag3352x.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaveformGenerator33500BApi
{
  
    public class WaveformGenerator33500BSim : WaveformGenerator33500B
    {
       

         
        public WaveformGenerator33500BSim(string visaName) : base(visaName)
        {
            m_resourceDesc = visaName;
        }


        int m_initcount = 0;
        public override bool Initialize(out string outMessage, out WFGen33500BInfo info , IWafeForm p = null)
        {
            
            outMessage = string.Empty;
            info = new WFGen33500BInfo();
            m_initcount++;
            if (m_initcount >= 1)
            {
                m_init = true;
                return true;
            }
            else
            {
                m_init = false;
                return false;
            }

        }

        public override void Clear()
        {
            lock (this)
            {
                
            }
        }
        public override void Reset()
        {
            lock (this)
            {
                
            }
        }
        
        
        CHANNLES m_channel = CHANNLES.Notset;
        IAg3352xChannel3 pAg3352xChannel = null;

        public override void SetChannel(CHANNLES channel)
        {

            
        }
        public override void OutputLoad(CHANNLES channel, double value)
        {
            lock (this)
            {
                
            }            
        }

        public override void SetOutputFunction(CHANNLES channel, Ag3352xOutputFunctionEnum function)
        {

            lock (this)
            {
               
            }
        }

        public override Ag3352xOutputFunctionEnum GetOutputFunction(CHANNLES channel)
        {
            lock (this)
            {

                return Ag3352xOutputFunctionEnum.Ag3352xOutputFunctionArbitrary;
            }
        }
        public override void SetOutputFrequency(CHANNLES channel, double frequencyInHz)
        {
            lock (this)
            {
                
            }
        }
        public override void GetOutputFrequency(CHANNLES channel, out double frequencyInHz)
        {
            lock (this)
            {
                frequencyInHz = 1000;
            }
        }
        public override void SetOutputVoltageAmplitude(CHANNLES channel, double value)
        {
            lock (this)
            {
                
            }
        }
        public override void SetDCOffset(CHANNLES channel, double value)
        {
            lock (this)
            {
                
            }
        }

        public override void SetPulseWidth(CHANNLES channel, double value)
        {
            lock (this)
            {
                 
            }
        }

        public override void SetOutput3VoltageAmplitude(CHANNLES channel, double value)
        {
            lock (this)
            {
                
            }
        }

        public override void SetOutput2VoltageAmplitude(CHANNLES channel, double value)
        {
            lock (this)
            {
                
            }
        }

        public override void GetOutputVoltageAmplitude(CHANNLES channel, out double value)
        {
            lock (this)
            {
                value = 10;
            }
        }

        public override void SetAMMode(CHANNLES channel, Ag3352xAMModeEnum mode)
        {
            lock (this)
            {
                
            }
        }
        public override void SetAMSource(CHANNLES channel, Ag3352xModulationSourceEnum source)
        {
            lock (this)
            {
                
            }
        }

        public override void SetAMInternalFunction(CHANNLES channel, Ag3352xModulationInternalFunctionEnum function)
        {
            lock (this)
            {
                
            }
        }
        public override void SetAMInternalFrequency(CHANNLES channel, double value)
        {
            lock (this)
            {
                
            }
        }

        public override void SetAMDepth(CHANNLES channel, double value)
        {
            lock (this)
            {
                
            }
        }
 
        public override void AMEnabled(CHANNLES channel, bool en)
        {
            lock (this)
            {
                
            }
        }
        public override void OutputEnable(CHANNLES channel, bool enable)
        {
            lock (this)
            {
                 
            }            
        }
        public override void Close()
        {
            
        }

        public override void SetPulsePeriod(CHANNLES channel , double period)
        {
            lock (this)
            {
                
            }
        }
        public override void SetPulseDutyCycle(CHANNLES channel , double dutyCycle)
        {
            lock (this)
            {
                
            }
        }
        public override void SetPulseTransitionEdgeTime(CHANNLES channel, double edgeTime)
        {
            lock (this)
            {
                
            }
        }

        public override void RecallState(int state)
        {
            lock (this)
            {
                
            }
        }
        public override void SaveState(int state)
        {
            lock (this)
            {
                 
            }
        }
        public override void GetOutputLoadMinMax(CHANNLES channel, out double min, out double max)
        {
            lock (this)
            {
                min = 1;
                max = 2;
            }
        }

        public override void LoadStateFromFile(string fileName)
        {
            lock (this)
            {
                 
            }
        }

        public override void LoadStateFromFile2(string fileName)
        {
            lock (this)
            {
                
            }
        }

    }
}
