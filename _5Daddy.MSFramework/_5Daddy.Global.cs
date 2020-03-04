using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static _5Daddy.MSFramework.Connection;
namespace _5Daddy.MSFramework
{
    static class Global
    {

        public static HttpClient Communcation = new HttpClient();

        internal static Uri URI = new Uri("http://82.0.172.129:3033");

        public static Type PacketType { get; set; }

        public static string AuthToken { get; set; }

        public static bool OfflineMode = false;

        public static bool LoggedIn = false;

        //The time after you take off to start reading offsets again
        public static int LandingTimeoutTime = 4000;

        public static int OffsetRefreshRate = 10;

        public static List<Connection.RawPacket> RawPacket_History = new List<Connection.RawPacket>();

        public static bool ServerAcesss = false;

        public const string Version = "1.0.0";

        public static string Username;
        public static string landinglistsJsonPath = $"{Environment.CurrentDirectory}\\Landing.lrm";

        public class UserSettings
        {
            public static bool CacheDiscord = true;

            public static bool AutoLogin = false;

            public static bool VASupport = false;

            public static bool MobileAlerts = false;

            public static bool RemoteFlight = false;

            public static bool Multiplayer = true;

            public static bool Sounds = true;
        }
    }
}
