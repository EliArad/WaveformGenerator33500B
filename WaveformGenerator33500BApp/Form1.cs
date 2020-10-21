using Agilent.Ag3352x.Interop;
using Intel_unit_Test;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaveformGenerator33500BApi;
using static WaveformGenerator33500BApi.WaveformGenerator33500B;

namespace WaveformGenerator33500BApp
{
    public partial class Form1 : Form
    {
        WaveformGenerator33500B m_pgen;
        bool m_init = false;
        public Form1()
        {
            InitializeComponent();

            var values = Enum.GetValues(typeof(Ag3352xOutputFunctionEnum)).Cast<Ag3352xOutputFunctionEnum>();
            cmbOperationMode1.DataSource = values.ToList();
            cmbOperationMode2.DataSource = values.ToList();
            cmbOperationMode1.SelectedIndex = (int)Ag3352xOutputFunctionEnum.Ag3352xOutputFunctionPulse;
            cmbOperationMode2.SelectedIndex = (int)Ag3352xOutputFunctionEnum.Ag3352xOutputFunctionPulse;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtVisaName.Text == string.Empty)
            {
                MessageBox.Show("Please specify visa address");
                return;
            }
            m_pgen = new WaveformGenerator33500B(txtVisaName.Text);
            if (m_pgen.Initialize(out string outMessage, out WFGen33500BInfo info) == false)
            {
                MessageBox.Show(outMessage);
            }
            else
            {
                m_init = true;
                groupBox1.Text = info.Serial;
                button5.ForeColor = Color.Green;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;

                m_pgen.GetOutputLoadMinMax(CHANNLES.Channel1, out double min, out double max);
                lblOutputLoad1MinMax.Text = min.ToString() + " , " + max.ToString();
                m_pgen.GetOutputLoadMinMax(CHANNLES.Channel2, out min, out max);
                lblOutputLoad2MinMax.Text = min.ToString() + " , " + max.ToString();
            }
        }

        private void btnSetFrequency_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtFreq1.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetOutputFrequency(CHANNLES.Channel1, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                m_pgen.OutputEnable(CHANNLES.Channel1, chkEnable1.Checked);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtAmp1.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetOutputVoltageAmplitude(CHANNLES.Channel1, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtDutyCycle1.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetPulseDutyCycle(CHANNLES.Channel1, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtPulsePeriod1.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetPulsePeriod(CHANNLES.Channel1, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtTransionTime1.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetPulseTransitionEdgeTime(CHANNLES.Channel1, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void cmbOperationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_init == false)
                return;


            try
            {
                m_pgen.SetOutputFunction(CHANNLES.Channel1, (Ag3352xOutputFunctionEnum)cmbOperationMode1.SelectedIndex);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtFreq2.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetOutputFrequency(CHANNLES.Channel2, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtAmp2.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetOutputVoltageAmplitude(CHANNLES.Channel2, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtDutyCycle2.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetPulseDutyCycle(CHANNLES.Channel2, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtPulsePeriod2.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetPulsePeriod(CHANNLES.Channel2, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void cmbOperationMode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_init == false)
                return;
            try
            {
                m_pgen.SetOutputFunction(CHANNLES.Channel2, (Ag3352xOutputFunctionEnum)cmbOperationMode2.SelectedIndex);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtTransionTime2.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetPulseTransitionEdgeTime(CHANNLES.Channel2, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void chkEnable2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                m_pgen.OutputEnable(CHANNLES.Channel2, chkEnable2.Checked);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnRecallState_Click(object sender, EventArgs e)
        {
            try
            {
                m_pgen.RecallState(int.Parse(txtStateRecall.Text));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSaveState_Click(object sender, EventArgs e)
        {
            try
            {
                m_pgen.SaveState(int.Parse(txtStateRecall.Text));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnChannel1OutputLoadInOhams_Click(object sender, EventArgs e)
        {
            try
            {
                m_pgen.OutputLoad(CHANNLES.Channel1, double.Parse(txtOutput1Load.Text));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnChannel2OutputLoadInOhams_Click(object sender, EventArgs e)
        {
            try
            {
                m_pgen.OutputLoad(CHANNLES.Channel2, double.Parse(txtOutput2Load.Text));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                m_pgen.LoadStateFromFile(txtStateFileName.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                m_pgen.LoadStateFromFile2(txtStateFileName2.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            
            bool b;
            b = double.TryParse(txtChannel1Output2.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetOutput2VoltageAmplitude(CHANNLES.Channel1, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtChannel1Output3.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetOutput3VoltageAmplitude(CHANNLES.Channel1, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnDcOffset_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtChannel1DcOffset.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetDCOffset(CHANNLES.Channel1, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnDcOffset2_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtChannel2DcOffset.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetDCOffset(CHANNLES.Channel2, value);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnPulseWidth_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtChannel1PulseWidth.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetPulseWidth(CHANNLES.Channel1, value / 1e6);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnPulseWidth2_Click(object sender, EventArgs e)
        {
            bool b;
            b = double.TryParse(txtChannel2PulseWidth.Text, out double value);
            if (b == false)
                return;
            try
            {
                m_pgen.SetPulseWidth(CHANNLES.Channel2, value / 1e6);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        ScpiDemo m_scpi;
        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                m_scpi = new ScpiDemo(txtVisaName.Text);                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_scpi != null)
                m_scpi.Close();

            if (m_pgen != null)
                m_pgen.Close();
        }

        private void btnHighZ_Click(object sender, EventArgs e)
        {
            m_scpi.SendScpi("OUTPut1:LOAD INFinity");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            m_scpi.SendScpi("OUTPut2:LOAD INFinity");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
