using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static _5Daddy.MSFramework.Connection;

namespace _5Daddy.MSFramework
{
    class MasterServer
    {
        internal static Uri MasterServerAddress = new Uri("http://82.0.172.129:56798/");


        public async static Task<string> SendToMasterServer(IPacket data, int Timeout = 5000)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data);
                var RequestMessage = new HttpRequestMessage()
                {
                    Content = new ByteArrayContent(Encoding.ASCII.GetBytes(json)),
                    Method = new HttpMethod("POST"),
                    RequestUri = MasterServer.MasterServerAddress,
                };
                var ResponseMessage = Global.Communcation.SendAsync(RequestMessage).Result;
                Console.WriteLine("POST > " + MasterServer.MasterServerAddress.ToString().Replace("/", "").Remove(0, 5) + "\n    TX > " + json);
                Stream ReadSteam = await ResponseMessage.Content.ReadAsStreamAsync();
                byte[] MaxBuffer = new byte[1024];
                int ByteBuffer = ReadSteam.Read(MaxBuffer, 0, Convert.ToInt32(ReadSteam.Length));
                byte[] DataBuffer = new byte[ByteBuffer];
                Array.Copy(MaxBuffer, DataBuffer, ByteBuffer);
                Console.WriteLine("POST > " + MasterServer.MasterServerAddress.ToString().Replace("/", "").Remove(0, 5) + "\n    RX > " + Encoding.ASCII.GetString(DataBuffer));
                return Encoding.ASCII.GetString(DataBuffer);
            }
            catch (SocketException ex)
            {
                throw new Exception("Could Not Send Data to Master Server!", ex);
            }
        }
    }
}
