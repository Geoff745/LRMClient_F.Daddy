using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _5Daddy.MSFramework.Connection;
using static _5Daddy.MSFramework.Global;
namespace _5Daddy.MSFramework
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [STAThread]
        static void Main()
        {
            if (!Environment.GetCommandLineArgs().ToArray().Contains("-Console"))
            { ShowWindow(GetConsoleWindow(), SW_HIDE);}else{Bitmap bmpSrc = new Bitmap(@"FiveDaddy-1.png", true);ConsoleDebug.ConsoleWriteImage(bmpSrc);}

            
            New_Client UI_Client = new New_Client()
            {
                Version = "1.0.0",
            };
            
            


            dynamic ParseJson = JObject.Parse(RWHTTP(GetRawPacket(UI_Client)).GetAwaiter().GetResult());
            if (ParseJson.Header == "Good_Version")
            {
                Global.ServerAcesss = true;
                Validate_User User_Client = new Validate_User()
                {
                    code = DiscordValidation().GetAwaiter().GetResult(),
                };
                ParseJson = JObject.Parse(RWHTTP(GetRawPacket(User_Client)).GetAwaiter().GetResult());
                
                Global.AuthToken = ParseJson.Auth;
                Global.Username = ParseJson.Body.Discord_Username;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());


            }
            else
            {

                Console.WriteLine("This current version (" + UI_Client.Version + ") is below the required version ("+ UI_Client.Version+")");
                Console.ReadKey();
            }

            
        }
    }
}
