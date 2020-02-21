using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSUIPC;
using System.Timers;

namespace _5Daddy.MSFramework
{
    public partial class LRM_Page : UserControl
    {
        public LRM_Page()
        {
            InitializeComponent();
        }
        private static Offset<uint> airspeed = new Offset<uint>(0x02BC);             // 4-byte offset - Unsigned integer 
        private static Offset<int> verticalSpeed = new Offset<int>(0x02C8);          // 4-byte offset - Signed integer 
        private Offset<ushort> onGround = new Offset<ushort>(0x0366);
        private Offset<int> windSpeed = new Offset<int>(0x04BA);
        private Offset<int> windDirection = new Offset<int>(0x04DA);                 //*360/65536 for heading
        private Offset<int> pitch = new Offset<int>(0x0578);
        private Offset<string> aircraftType = new Offset<string>(0x3D00, 256);
        private Offset<string> aircraftID = new Offset<string>(0x313C, 12);
        private Offset<int> roll = new Offset<int>(0x057C);


        private void LRM_Page_Load(object sender, EventArgs e)
        {
            OffsetReaderTimer.Interval = Global.OffsetRefreshRate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var flightsim = FSUIPCReader.ConnectToFlightSim();
                FSUIPCReader.StartReading();
                if (FSUIPCReader.isConnected)
                {
                    label2.Text = "Connected To: " + flightsim;
                    label2.ForeColor = Color.Green;
                    OffsetReaderTimer.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot connect to flightsim!\nMake sure you have your flightsim running and have FSUIPC installed!", "Uh Oh!", MessageBoxButtons.OK);
            }
        }
        bool RptGround = false;
        private delegate void SafeCallDelegate();
        private void UpdateForm(object sender, EventArgs e)
        {
            FSUIPCConnection.Process();
            var OnGround = onGround.Value > 0 ? true : false;
            if (!OnGround && !RptGround)
            {
                var Airspeed = (int)Math.Round(airspeed.Value / 128d);
                double verticalSpeedMPS = verticalSpeed.Value / 256d;
                double verticalSpeedFPM = verticalSpeedMPS * 60d * 3.28084d;
                var VerticalSpeed = (int)verticalSpeedFPM;
                WeatherServices ws = FSUIPCConnection.WeatherServices;
                FsWeather weather = ws.GetWeatherAtAircraft();
                FsWindLayer windLayer = weather.WindLayers[0];
                var WindSpeed = (int)windLayer.SpeedKnots;
                var WindHeading = (int)windLayer.Direction;
                var Bank = (int)((double)roll.Value * 360 / 4294967296);
                var Pitch = (int)((double)pitch.Value * 360 / 4294967296 * -1);
                string pitchS = "";
                if (Pitch >= 0)
                    pitchS = Pitch.ToString() + "▲";
                else
                    pitchS = Pitch.ToString() + "▼";
                string bankS = "";
                if (Bank != 0)
                {
                    if (Bank > 0)
                        bankS = Bank + "L";
                    else
                        bankS = (Bank * -1) + "R";
                }

                this.FPMBox.Text = VerticalSpeed.ToString();
                this.PitchBox.Text = pitchS;
                this.BankBox.Text = bankS;
                this.WindSpeedBox.Text = WindSpeed.ToString();
                this.WindHeadingBox.Text = WindHeading.ToString();
                this.SpeedBox.Text = Airspeed.ToString();
            }
            if (OnGround && !RptGround)
            {
                //new landing
                int fpm = Convert.ToInt32(this.FPMBox.Text);
                if (fpm <= -1500)
                {
                    ScoreBox.Text = "DEAD!";
                    return;
                }
                if (fpm <= -700)
                {
                    ScoreBox.Text = "1/10!";
                    return;
                }
                if (fpm <= -500)
                {
                    ScoreBox.Text = "Need repair!";
                    return;
                }
                if (fpm <= -300)
                {
                    ScoreBox.Text = "Ouch!";
                    return;
                }
                if (fpm <= -200)
                {
                    ScoreBox.Text = "Harsh!";
                    return;
                }
                if (fpm <= -175)
                {
                    ScoreBox.Text = "Nice!";
                    return;
                }
                if (fpm <= -100)
                {
                    ScoreBox.Text = "Smooth!";
                    return;
                }
                if (fpm <= -50)
                {
                    ScoreBox.Text = "Butter!";
                    return;
                }
                RptGround = true;
            }
            if (RptGround && !OnGround)
            {
                System.Timers.Timer tempTimer = new System.Timers.Timer()
                {
                    Interval = Global.LandingTimeoutTime,
                    AutoReset = false
                };
                tempTimer.Elapsed += (object s, ElapsedEventArgs el) =>
                {
                    RptGround = false;
                };
                tempTimer.Start();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FSUIPCReader.CloseConnection();
            FSUIPCReader.StopReading();
            if (!FSUIPCReader.isConnected)
            {
                label2.Text = "Connected To: None";
                label2.ForeColor = Color.Red;
                OffsetReaderTimer.Enabled = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
