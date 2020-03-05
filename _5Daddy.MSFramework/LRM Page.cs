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
        private Offset<long> Alt = new Offset<long>(0x0574);
        private Offset<string> messageWrite = new Offset<string>("message", 0x3380, 128, true);
        private Offset<short> messageDuration = new Offset<short>("message", 0x32FA, true);

        private void LRM_Page_Load(object sender, EventArgs e)
        {
            OffsetReaderTimer.Interval = Global.OffsetRefreshRate;
            ConnectionTimer.Enabled = true;
            button1.BackColor = Color.FromArgb(255, 157, 0);
            button1.Text = "Searching... ";
        }
        bool RptGround = true;
        private delegate void SafeCallDelegate();
        private void NextLR_Tick(object sender, EventArgs e)
        {
            NextLR.Stop();
            OffsetReaderTimer.Start();
        }
        private void UpdateForm(object sender, EventArgs e)
        {
            try
            {
                FSUIPCConnection.Process();
                var OnGround = onGround.Value > 0 ? true : false;
                if (!OnGround && !RptGround)
                {
                    var Airspeed = (int)Math.Round(airspeed.Value / 128d);
                    double verticalSpeedMPS = verticalSpeed.Value / 256d;
                    double verticalSpeedFPM = verticalSpeedMPS * 60d * 3.28084d;
                    var VerticalSpeed = (int)verticalSpeedFPM;
                    var Bank = (int)((double)roll.Value * 360 / 4294967296);
                    var Pitch = (int)((double)pitch.Value * 360 / 4294967296 * -1);
                    string pitchS = "";
                    if (Pitch >= 0)
                        pitchS = Pitch.ToString();
                    else
                        pitchS = Pitch.ToString();
                    string bankS = "";
                    if (Bank != 0)
                    {
                        if (Bank > 0)
                            bankS = Bank.ToString();
                        else
                            bankS = (Bank * -1).ToString();
                    }
                    else
                        bankS = "0";

                    this.FPMBox.Text = VerticalSpeed.ToString();
                    this.PitchBox.Text = pitchS + " °";
                    this.BankBox.Text = bankS + " °";
                    this.SpeedBox.Text = Airspeed.ToString() + " Knots";
                }
                if (OnGround && !RptGround)
                {
                    WeatherServices ws = FSUIPCConnection.WeatherServices;
                    FsWeather weather = ws.GetWeatherAtAircraft();
                    FsWindLayer windLayer = weather.WindLayers[0];
                    var WindSpeed = (int)windLayer.SpeedKnots;
                    var WindHeading = (int)windLayer.Direction;
                    this.WindSpeedBox.Text = WindSpeed.ToString() + " Knots";
                    this.WindHeadingBox.Text = WindHeading.ToString() + " °";


                    //new landing
                    int fpm = Convert.ToInt32(this.FPMBox.Text);
                    if (fpm <= -1500)
                    {
                        ScoreBox.Text = "DEAD!";
                    }
                    else if (fpm <= -700)
                    {
                        ScoreBox.Text = "1/10!";
                    }
                    else if(fpm <= -500)
                    {
                        ScoreBox.Text = "Need repair!";
                    }
                    else if(fpm <= -300)
                    {
                        ScoreBox.Text = "Ouch!";
                    }
                    else if(fpm <= -200)
                    {
                        ScoreBox.Text = "Harsh!";
                    }
                    else if(fpm <= -175)
                    {
                        ScoreBox.Text = "Nice!";
                    }
                    else if(fpm <= -100)
                    {
                        ScoreBox.Text = "Smooth!";
                    }
                    else if(fpm <= 0)
                    {
                        ScoreBox.Text = "Butter!";
                    }
                    RptGround = true;
                    string Message = "5Daddy LRM: " +ScoreBox.Text+" "+ FPMBox.Text+ " Landed at " + SpeedBox.Text + " " + PitchBox.Text.Replace("°", "degrees") + " Winds " + WindSpeedBox.Text + " at " + WindHeadingBox.Text.Replace("°", "degrees");
                    this.messageWrite.Value = Message;
                    this.messageDuration.Value = 10;
                    FSUIPCConnection.Process("message");
                    var par = this.Parent as PilotTab;
                    par.PromptNotify();
                    Notify.TitleText = ScoreBox.Text;
                    Notify.DescText = "Landed at " + SpeedBox.Text + " " + PitchBox.Text.Replace("°", "degrees") + "\nWinds " + WindSpeedBox.Text + " at " + WindHeadingBox.Text.Replace("°", "degrees")+"\nFPM "+ FPMBox.Text;
                    NextLR.Start();
                    OffsetReaderTimer.Stop();
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
            } catch {
                
            }
            GC.Collect();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        bool ConnectionError = true;
        bool CountUP = true;
        private void ConnectionTimer_Tick(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(255, 157, 0);
            button1.Text = "Searching... ";
            try
            {
                Global.ConnectedFlightsim = FSUIPCReader.ConnectToFlightSim();
                //FSUIPCReader.StartReading();
                if (FSUIPCReader.isConnected)
                {
                    panel2.Visible = false;
                    panel1.Visible = true;
                    OffsetReaderTimer.Enabled = true;
                }
            }
            catch (FSUIPCException ex)
            {
                
                Console.WriteLine(ex);
                if (ex.FSUIPCErrorCode == FSUIPCError.FSUIPC_ERR_OPEN)
                {
                    OffsetReaderTimer.Enabled = true;
                    button1.BackColor = Color.FromArgb(235, 14, 14);
                    button1.Text = "Disconnect";
                    panel2.Visible = false;
                    panel1.Visible = true;
                    ConnectionTimer.Stop();
                }
                else if (ConnectionError)
                {
                    ConnectionError = false;
                    MetroFramework.MetroMessageBox.Show(this, "Cannot connect to flightsim!\nMake sure you have your flightsim running and have FSUIPC installed!", "Uh Oh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Disconnect")
            {
                button1.BackColor = Color.FromArgb(0, 177, 89);
                button1.Text = "Connect";
                OffsetReaderTimer.Stop();
            }
            else if (button1.Text == "Connect")
            {
                button1.BackColor = Color.FromArgb(255, 157, 0);
                button1.Text = "Searching... ";
                ConnectionTimer.Start();
            }
        }

    }
}
