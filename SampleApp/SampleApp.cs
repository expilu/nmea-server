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

        public SampleApp()
        {
            InitializeComponent();

            nmeaServer = new NMEAServer(55555, 1000);
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            if(nmeaServer.Started)
            {
                nmeaServer.Stop();
                buttonStartServer.Text = "Start server";
            } else
            {
                nmeaServer.Start();
                buttonStartServer.Text = "Stop server";
            }
            
        }

        private void SampleApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            nmeaServer.Stop();
        }
    }
}
