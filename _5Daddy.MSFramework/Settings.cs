using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _5Daddy.MSFramework
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle1.Checked == false)
            {
                metroToggle3.Enabled = false;
                metroToggle3.Checked = false;
            } 
            else
                metroToggle3.Enabled = true;

        }

        private void metroToggle6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle6.Checked == false)
            {
                metroToggle4.Enabled = false;
                metroToggle4.Checked = false;
                metroToggle5.Enabled = false;
                metroToggle5.Checked = false;
            }
            else
            {
                metroToggle4.Enabled = true;
                metroToggle5.Enabled = true;
            }
                
        }
        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Environment.CurrentDirectory + @"\Settings.json", "{ " + $"'CacheDiscord': { metroToggle1.Checked.ToString().ToLower() }, 'AutoLogin': { metroToggle3.Checked.ToString().ToLower() }, 'VASupport': { metroToggle6.Checked.ToString().ToLower() }, 'MobileAlerts': { metroToggle4.Checked.ToString().ToLower() }, 'RemoteFlight': { metroToggle5.Checked.ToString().ToLower() }, 'Multiplayer': { metroToggle7.Checked.ToString().ToLower() }, 'Sounds': { metroToggle2.Checked.ToString().ToLower() } " + " }");
            
        }


    }
}
