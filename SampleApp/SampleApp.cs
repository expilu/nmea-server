using NMEALib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleApp
{
    public partial class SampleApp : Form
    {
        private NMEAServer nmeaServer;
        private InstrumentsData boatData = new InstrumentsData();

        public SampleApp()
        {
            InitializeComponent();

            numericUpDownPort.Value = 10110M;
            numericUpDownLat.Value = 28.134420M;
            numericUpDownLat.Increment = 0.01M;
            numericUpDownLon.Value = -15.435076M;
            numericUpDownLon.Increment = 0.01M;
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            if(nmeaServer == null || !nmeaServer.Started)
            {
                nmeaServer = new NMEAServer(ref boatData, Convert.ToInt32(numericUpDownPort.Value), Convert.ToInt32(numericUpDownRate.Value));
                nmeaServer.Start();
                buttonStartServer.Text = "Stop server";                
            } else
            {
                nmeaServer.Stop();
                buttonStartServer.Text = "Start server";
            }

            numericUpDownPort.Enabled = !nmeaServer.Started;
            numericUpDownRate.Enabled = !nmeaServer.Started;
        }

        private void SampleApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            nmeaServer.Stop();
        }

        private void numericUpDownLat_ValueChanged(object sender, EventArgs e)
        {
            boatData.Lat = decimal.ToDouble(numericUpDownLat.Value);
        }

        private void numericUpDownLon_ValueChanged(object sender, EventArgs e)
        {
            boatData.Lon = decimal.ToDouble(numericUpDownLon.Value);
        }
    }
}
