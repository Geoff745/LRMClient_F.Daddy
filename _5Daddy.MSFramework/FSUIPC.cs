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

        public static bool RptGround = false;

        public static event EventHandler<LandingEventArgs> Landed;
        public static event EventHandler<CustomOffsetData[]> CustomOffsetRead;
        public static event EventHandler OffsetDataUpdated;
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
            Interval = Global.OffsetRefreshRate,
            AutoReset = true,
            Enabled = false
        };

        public FSUIPCReader()
        {
            t.Elapsed += ReadOffsets;
        }

        private void ReadOffsets(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (CustomOffsetList.Count == 0)
                    return;
                if (!isConnected)
                    return;
                FSUIPCConnection.Process();
                List<CustomOffsetData> l = new List<CustomOffsetData>();
                foreach (var offset in CustomOffsetList)
                {
                    Type t = offset.Type;
                    var type = typeof(Offset<>).MakeGenericType(t);
                    object a_Context = Activator.CreateInstance(type, new object[] { offset.OffestAddress });
                    var value = a_Context.GetType().GetProperty("Value");
                    var d = new CustomOffsetData()
                    {
                        Address = offset.OffestAddress,
                        Name = offset.Name,
                        Type = t,
                        Value = value
                    };
                    l.Add(d);
                }
                CustomOffsetRead.Invoke(this, l.ToArray());
            }
            catch(Exception ex)
            {
                CloseConnection();
                StopReading();
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
        public static FlightSim ConnectToFlightSim()
        {
            FSUIPCConnection.Open();
            if (FSUIPCConnection.IsOpen)
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
        public static void CloseConnection()
        {
            FSUIPCConnection.Close();
            isConnected = false;
        }
        public static void StartReading()
        {
            t.Start();
        }
        public static void StopReading()
        {
            t.Stop();
        }
    }
}
