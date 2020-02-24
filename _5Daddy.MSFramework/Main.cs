using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _5Daddy.MSFramework.Connection;
using static _5Daddy.MSFramework.Global;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace _5Daddy.MSFramework
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
        public Main()
        {
            InitializeComponent();
            Login_btn.Text = "Fetching..";
            FSUIPCReader e = new FSUIPCReader();
            if (!File.Exists(Global.landinglistsJsonPath))
                 File.Create(Global.landinglistsJsonPath).Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            New_Client UI_Client = new New_Client()
            {
                Version = "1.0.0",
            };
            try
            {
                RawPacket ParseJson = JsonConvert.DeserializeObject<RawPacket>(MasterServer.SendToMasterServer(GetRawPacket(UI_Client)).GetAwaiter().GetResult());
                if (ParseJson.Header == "Good_Version")
                {
                    Login_btn.Text = "Login With Discord";
                }
                else
                {
                    Login_btn.Text = "Unavailable";
                    MessageBox.Show("The version " + UI_Client.Version + " Is out of date!\nPlease update to " + ParseJson.Body["Expected"], "Offline Mode", MessageBoxButtons.OK);
                }
            }
            catch
            {
                Login_btn.Text = "Unavailable";
                //MessageBox.Show("The core online functions are not available", "Offline Mode", MessageBoxButtons.OK);
            }
        }

        

        private void Login_btn_Click(object sender, EventArgs e)
        {
            //login with discord
            try
            {
                HttpListener l = new HttpListener();
                l.Prefixes.Add("http://localhost:8080/oauth/");
                l.Start();
                Process.Start("https://discordapp.com/api/oauth2/authorize?client_id=602365472905756691&redirect_uri=http%3A%2F%2Flocalhost%3A8080%2Foauth%2F&response_type=code&scope=identify");

                HttpListenerContext context = l.GetContext();
                HttpListenerRequest request = context.Request;
                string id = request.QueryString["code"];
                Validate_User data = new Validate_User()
                {
                    code = id
                };
                string res = MasterServer.SendToMasterServer(GetRawPacket(data)).Result;

                ValidateResponcePacket Responce = new ValidateResponcePacket(JsonConvert.DeserializeObject<RawPacket>(res));

                string Discordusername = "";
                string Auth = "";
                if (Responce.Header == "Authenticated")
                {
                    Discordusername = Responce.DiscordUsername;
                    Auth = Responce.AuthToken;

                    Global.Username = Discordusername;
                    Global.AuthToken = Auth;
                    Global.LoggedIn = true;
                }
                HttpListenerResponse _1response = context.Response;
                OfflineMode = false;
                PilotTab pl = new PilotTab();
                pl.Show();
                Hide();
                Stream dummyS = _1response.OutputStream;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes($"<h1 style=\"color: #5e9ca0;\"><span style=\"color: #000000;\">Thank you, {Global.Username} you have been Authenticated! you can close this window</span></h1><p><span style=\"color: #000000;\" > ps.Thanks for using the LRM :D </span></p><p> &nbsp;</p>");
                _1response.ContentLength64 = buffer.Length;
                dummyS.Write(buffer, 0, buffer.Length);
                l.Stop();
                l.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message, "Uh Oh!");
            }
        }
        private void LoginWithDiscord()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.OfflineMode = true;
            PilotTab pl = new PilotTab();
            pl.Show();
            this.Hide();
        }

        private void OffsetReaderTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
