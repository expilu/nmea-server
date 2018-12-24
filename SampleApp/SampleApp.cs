using NMEALib;
using System;
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
            numericUpDownRate.Value = 1000M;
            numericUpDownLat.Value = 28.134420M;
            numericUpDownLat.Increment = 0.01M;
            numericUpDownLon.Value = -15.435076M;
            numericUpDownLon.Increment = 0.01M;

            Move();
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

        private void numericUpDownHeading_ValueChanged(object sender, EventArgs e)
        {
            boatData.TrueHeading = decimal.ToDouble(numericUpDownHeading.Value);
        }

        private void numericUpDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            boatData.Speed = decimal.ToDouble(numericUpDownSpeed.Value);
        }

        private void Move()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    if (nmeaServer != null && nmeaServer.Started)
                    {
                        double currentLat = decimal.ToDouble(numericUpDownLat.Value);
                        double currentLon = decimal.ToDouble(numericUpDownLon.Value);
                        double time = (decimal.ToDouble(numericUpDownRate.Value) / 1000) / 3600;
                        double speed = decimal.ToDouble(numericUpDownSpeed.Value);
                        double distance = speed * 0.514444 * time;
                        double heading = decimal.ToDouble(numericUpDownHeading.Value);
                        double radius = 6371e3;
                        double δ = distance / radius;
                        double θ = toRadians(heading);
                        double φ1 = toRadians(currentLat);
                        double λ1 = toRadians(currentLon);
                        double sinφ1 = Math.Sin(φ1);
                        double cosφ1 = Math.Cos(φ1);
                        double sinδ = Math.Sin(δ);
                        double cosδ = Math.Cos(δ);
                        double sinθ = Math.Sin(θ);
                        double cosθ = Math.Cos(θ);
                        double sinφ2 = sinφ1 * cosδ + cosφ1 * sinδ * cosθ;
                        double φ2 = Math.Asin(sinφ2);
                        double y = sinθ * sinδ * cosφ1;
                        double x = cosδ - sinφ1 * sinφ2;
                        double λ2 = λ1 + Math.Atan2(y, x);

                        double newLat = toDegrees(φ2);
                        double newLon = (toDegrees(λ2) + 540) % 360 - 180;

                        numericUpDownLat.Invoke(new Action(() => numericUpDownLat.Value = Convert.ToDecimal(newLat)));
                        numericUpDownLon.Invoke(new Action(() => numericUpDownLon.Value = Convert.ToDecimal(newLon)));
                    }

                    await Task.Delay(Convert.ToInt32(numericUpDownRate.Value));
                }
            });
        }

        private double toRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        private double toDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }
    }
}
