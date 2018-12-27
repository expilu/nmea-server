using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using NMEAServerLib;

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
            boatData.Lat = 28.134420;
            numericUpDownLat.Value = (decimal) boatData.Lat;
            numericUpDownLat.Increment = 0.01M;
            boatData.Lon = -15.435076;
            numericUpDownLon.Value = (decimal) boatData.Lon;
            numericUpDownLon.Increment = 0.01M;
            boatData.Heading = 0;
            boatData.CourseOverGround = 0; // use the same, is just an example after all
            numericUpDownHeading.Value = (decimal) boatData.Heading;
            boatData.WaterSpeed = 5;
            boatData.SpeedOverGround = boatData.WaterSpeed; // use the same, is just an example after all
            numericUpDownSpeed.Value = (decimal) boatData.WaterSpeed;
            boatData.TrueWindAngle = 90;
            numericUpDownTWA.Value = (decimal) boatData.TrueWindAngle;
            boatData.TrueWindSpeed = 15;
            numericUpDownTWS.Value = (decimal)boatData.TrueWindSpeed;

            // TODO remove this
            boatData.Depth = 1000.4;
            boatData.TransducerDepth = 1;

            CalcMovement();
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
            boatData.Heading = Convert.ToInt32(numericUpDownHeading.Value);
            boatData.CourseOverGround = boatData.Heading; // use the same, is just an example after all
        }

        private void numericUpDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            boatData.WaterSpeed = decimal.ToDouble(numericUpDownSpeed.Value);
            boatData.SpeedOverGround = boatData.WaterSpeed; // use the same, is just an example after all
        }

        private void CalcMovement()
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

                        //numericUpDownLat.Invoke(new Action(() => numericUpDownLat.Value = Convert.ToDecimal(newLat)));
                        //numericUpDownLon.Invoke(new Action(() => numericUpDownLon.Value = Convert.ToDecimal(newLon)));
                        this.numericUpDownLat.Value = Convert.ToDecimal(newLat);
                        this.numericUpDownLon.Value = Convert.ToDecimal(newLon);

                        boatData.ApparentWindSpeed = Math.Sqrt(Math.Pow(boatData.TrueWindSpeed ?? 0, 2) + Math.Pow(boatData.SpeedOverGround ?? 0, 2) + (2 * boatData.TrueWindSpeed ?? 0 * boatData.SpeedOverGround ?? 0 * Math.Cos(boatData.CourseOverGround ?? 0)));
                        boatData.ApparentWindAngle = Convert.ToInt32(Math.Acos((boatData.TrueWindSpeed ?? 0 * Math.Cos(boatData.CourseOverGround ?? 0) + boatData.SpeedOverGround ?? 0) / boatData.ApparentWindSpeed ?? 0));
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

        private void numericUpDownTWA_ValueChanged(object sender, EventArgs e)
        {
            boatData.TrueWindAngle = Convert.ToInt32(numericUpDownTWA.Value);
        }

        private void numericUpDownTWS_ValueChanged(object sender, EventArgs e)
        {
            boatData.TrueWindSpeed = decimal.ToDouble(numericUpDownTWS.Value);
        }
    }
}
