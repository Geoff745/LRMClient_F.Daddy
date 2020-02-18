﻿using Newtonsoft.Json.Linq;
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
        internal static Uri URI = new Uri("http://localhost:8081/");
        public static Type PacketType { get; set; }
        public static string AuthToken { get; set; }

        public static List<Connection.RawPacket> RawPacket_History = new List<Connection.RawPacket>();

        public static bool ServerAcesss = false;

        public const string Version = "1.0.0";

        public static string Username;
    }
}
