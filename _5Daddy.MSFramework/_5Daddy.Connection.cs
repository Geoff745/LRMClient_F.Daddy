using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _5Daddy.MSFramework
{
    static class Connection
    {

        internal class New_Client : IPacket
        {
            public string Header { get; set; }
            public Dictionary<object, object> Body { get; set; }
            public string Auth { get; set; }
            public string Version { get; set; }
        }
        internal class Validate_User : IPacket
        {
            public string Header { get; set; }
            public Dictionary<object, object> Body { get; set; }
            public string Auth { get; set; }
            public string code { get; set; }
        }

        internal class RawPacket : IPacket
        {
            public string Header { get; set; }
            public Dictionary<object, object> Body { get; set; }
            public string Auth { get; set; }
        }
        public interface IPacket
        {
            string Header { get; set; }
            Dictionary<object, object> Body { get; set; }
            string Auth { get; set; }
        }
        public static RawPacket GetRawPacket(IPacket DataPacket)
        {
            if (DataPacket == null) return null;
            Global.PacketType = DataPacket.GetType();
            RawPacket RawPacket = new RawPacket();
            RawPacket.Body = new Dictionary<object, object>();
            RawPacket.Header = Global.PacketType.Name;
            RawPacket.Auth = Global.AuthToken;
            var Properties = Global.PacketType.GetProperties();
            foreach (var Properte in Properties)
            {
                if (Properte.Name != "Header" && Properte.Name != "Body" && Properte.Name != "Auth")
                {
                    object val = Properte.GetValue(DataPacket);
                    RawPacket.Body.Add(Properte.Name, val);
                }
            }
            Global.RawPacket_History.Add(RawPacket);
            return RawPacket;
        }
        public async static Task<string> RWHTTP(IPacket data, int Timeout = 5000)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data);
                var RequestMessage = new HttpRequestMessage()
                {
                    Content = new ByteArrayContent(Encoding.ASCII.GetBytes(json)),
                    Method = new HttpMethod("POST"),
                    RequestUri = Global.URI,
                };
                var ResponseMessage = Global.Communcation.SendAsync(RequestMessage).Result;
                Console.WriteLine("POST > " + Global.URI.ToString().Replace("/", "").Remove(0, 5) + "\n    TX > "+ json);
                Stream ReadSteam = await ResponseMessage.Content.ReadAsStreamAsync();
                byte[] MaxBuffer = new byte[1024];
                int ByteBuffer = ReadSteam.Read(MaxBuffer, 0, Convert.ToInt32(ReadSteam.Length));
                byte[] DataBuffer = new byte[ByteBuffer];
                Array.Copy(MaxBuffer, DataBuffer, ByteBuffer);
                Console.WriteLine("POST > " + Global.URI.ToString().Replace("/", "").Remove(0, 5) + "\n    RX > " + Encoding.ASCII.GetString(DataBuffer));
                return Encoding.ASCII.GetString(DataBuffer);
            }
            catch (SocketException ex)
            {
                throw new Exception("Could Not Send Data to Master Server!", ex);
            }
        }

        public async static Task<string> DiscordValidation()
        {
            HttpListenerContext URL_Response;
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/oauth/");
            listener.Start();
            Process.Start("https://discordapp.com/api/oauth2/authorize?client_id=602365472905756691&redirect_uri=http%3A%2F%2Flocalhost%3A8080%2Foauth%2F&response_type=code&scope=identify");
            URL_Response = await listener.GetContextAsync();
            HttpListenerRequest request = URL_Response.Request;
            return request.QueryString["code"];
        }
    }
}
