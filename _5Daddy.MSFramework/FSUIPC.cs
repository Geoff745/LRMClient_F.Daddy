using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _5Daddy.MSFramework
{
    class FSUIPCReader
    {
        private static Offset<uint> heading = new Offset<uint>(0x0580);
        private static Offset<long> longitude = new Offset<long>(0x0568);
        private static Offset<long> latitude = new Offset<long>(0x0560);
        private static Offset<uint> airspeed = new Offset<uint>(0x02BC);             // 4-byte offset - Unsigned integer 
        private static Offset<int> verticalSpeed = new Offset<int>(0x02C8);          // 4-byte offset - Signed integer 
        private Offset<ushort> onGround = new Offset<ushort>(0x0366);
        private Offset<ushort> COM1act = new Offset<ushort>(0x034E);  // 2-byte offset - Unsigned short
        private Offset<ushort> COM1sby = new Offset<ushort>(0x311A);
        private Offset<int> windSpeed = new Offset<int>(0x04BA);
        private Offset<int> windDirection = new Offset<int>(0x04DA);  //*360/65536 for heading
        private Offset<int> pitch = new Offset<int>(0x0578);
        private Offset<string> aircraftType = new Offset<string>(0x3D00, 256);
        private Offset<string> aircraftID = new Offset<string>(0x313C, 12);
        private Offset<int> roll = new Offset<int>(0x057C);

        public static int Heading { get; set; }
        public static double Longitude { get; set; }
        public static double Latitude { get; set; }
        public static int Airspeed { get; set; }
        public static int VerticalSpeed { get; set; }
        public static bool OnGround { get; set; }
        public static int WindSpeed { get; set; }
        public static int WindHeading { get; set; }
        public static int Pitch { get; set; }
        public static int Bank { get; set; }
        public static string AircraftType { get; set; }
        public static string AircraftTypeExtra { get; set; }
        public static string AircraftID { get; set; }
        public static string AircraftIDExtra { get; set; }

        public static bool isConnected = false;

        private static bool RptGround = false;
        public static event EventHandler<LandingEventArgs> Landed;
        public static event EventHandler<CustomOffsetData> CustomOffsetRead;

        private List<CustomOffset> CustomOffsetList = new List<CustomOffset>();

        public class CustomOffset
        {
            public int OffestAddress { get; set; }
            public string Name { get; set; }
            public Type Type { get; set; }
        }
        
        public void AddCustomOffset(CustomOffset offset)
        {
            if(offset != null)
            {
                CustomOffsetList.Add(offset);
            }
        }
        public void RemoveCustomOffset(CustomOffset offset)
        {
            if (CustomOffsetList.Contains(offset))
                CustomOffsetList.Remove(offset);
        }

        static Timer t = new Timer()
        {
            Interval = 25,
            AutoReset = true,
            Enabled = false
        };
        FSUIPCReader()
        {
            t.Elapsed += ReadOffsets;
        }

        private void ReadOffsets(object sender, ElapsedEventArgs e)
        {
            if (!isConnected)
                return;
            FSUIPCConnection.Process();
            Longitude = (double)longitude.Value * 360 / (1.8446744e+19);
            Latitude = (double)latitude.Value * 90.0 / (10001750.0 * 65536.0 * 65536.0);
            Heading = (int)Math.Round((double)heading.Value * 360 / 4294967296);
            Airspeed = (int)Math.Round(airspeed.Value / 128d);
            AircraftType = aircraftType.Value;
            AircraftID = aircraftID.Value;
            double verticalSpeedMPS = verticalSpeed.Value / 256d;
            double verticalSpeedFPM = verticalSpeedMPS * 60d * 3.28084d;
            VerticalSpeed = (int)verticalSpeedFPM;
            WeatherServices ws = FSUIPCConnection.WeatherServices;
            FsWeather weather = ws.GetWeatherAtAircraft();
            FsWindLayer windLayer = weather.WindLayers[0];
            WindSpeed = (int)windLayer.SpeedKnots;
            WindHeading = (int)windLayer.Direction;
            Bank = (int)((double)roll.Value * 360 / 4294967296);
            Pitch = (int)((double)pitch.Value * 360 / 4294967296 * -1);
            foreach(var offset in CustomOffsetList)
            {
                Type t = offset.Type;
                var type = typeof(Offset<>).MakeGenericType(t);
                object a_Context = Activator.CreateInstance(type, new object[] { offset.OffestAddress });
                var value = a_Context.GetType().GetProperty("Value");
                CustomOffsetRead.Invoke(this, new CustomOffsetData()
                {
                    Address = offset.OffestAddress,
                    Name = offset.Name,
                    Type = t,
                    Value = value
                });
            }

            if (OnGround && !RptGround)
            {
                //new landing

                Landed.Invoke(this, new LandingEventArgs()
                {
                    Airspeed = Airspeed,
                    VerticalSpeed = VerticalSpeed,
                    WindSpeed = WindSpeed,
                    WindHeading = WindHeading,
                    Bank = Bank,
                    Pitch = Pitch
                });

                RptGround = true;
            }
            if (RptGround && !OnGround)
            {
                Timer tempTimer = new Timer()
                {
                    Interval = 3000,
                    AutoReset = false
                };
                StopReading();
                tempTimer.Elapsed += (object s, ElapsedEventArgs el) =>
                {
                    StartReading();
                    RptGround = false;
                };
            }
        }
        public class LandingEventArgs : EventArgs
        {
            public int VerticalSpeed { get; set; }
            public int Airspeed { get; set; }
            public int WindSpeed { get; set; }
            public int WindHeading { get; set; }
            public int Pitch { get; set; }
            public int Bank { get; set; }
        }
        public class CustomOffsetData : EventArgs
        {
            public object Value { get; set; }
            public Type Type { get; set; }
            public string Name { get; set; }
            public int Address { get; set; }
        }
        static FlightSim ConnectToFlightSim()
        {
            FSUIPCConnection.Open();
            if(FSUIPCConnection.IsOpen)
            {
                isConnected = true;
                return FSUIPCConnection.FlightSimVersionConnected.Simulator;
            }
            else
            {
                isConnected = false;
                throw new Exception("Cannot connect to flight Sim!");
            }
        }
        static void CloseConnection()
        {
            FSUIPCConnection.Close();
            isConnected = false;
        }
        static void StartReading()
        {
            t.Start();
        }
        static void StopReading()
        {
            t.Stop();
        }
    }
}
