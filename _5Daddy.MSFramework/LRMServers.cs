using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _5Daddy.MSFramework.MasterServer;

namespace _5Daddy.MSFramework
{
    public partial class LRMServers : UserControl
    {

        LRMServer ClickedServer;
        List<MasterServer.LRMServer> CurrentServers = new List<MasterServer.LRMServer>();

        public LRMServers()
        {
            InitializeComponent();
            //label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            button1.Hide();

        }
        private void updateServerListGUI()
        {
            dataGridView1.Rows.Clear();
            foreach(var item in CurrentServers)
            {
                Image img;
                if (item.PasswordProtected)
                    img = Properties.Resources.Locked;
                else
                    img = Properties.Resources.Unlocked;
                dataGridView1.Rows.Add(item.Name, item.Players + "/" + item.MaxPlayers, img);
            }
        }
        private async void LRMServers_Load(object sender, EventArgs e)
        {
            if (!Global.OfflineMode && Global.AuthToken != null)
            {
                timer1.Tick += UpdateServerList;
                timer1.Enabled = true;
                //ask master server for current lrm servers every 5 seconds
                //display those servers
            }
        }

        private async void UpdateServerList(object sender, EventArgs e)
        {
            try
            {
                if (!Global.OfflineMode)
                {
                    CurrentServers = await MasterServer.GetOnlineServers();
                    updateServerListGUI();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClickedServer = CurrentServers[e.RowIndex];

            string allows = "";
            foreach(var item in ClickedServer.AllowedFlightSims)
                allows += Enum.GetName(typeof(FSUIPC.FlightSim), item) + ", ";
            allows.Remove(allows.Length - 2, 2);
            if (ClickedServer.AllowedFlightSims.Contains(Global.ConnectedFlightsim))
            { label3.ForeColor = Color.Green; button1.Show(); }
            else
            { label3.ForeColor = Color.Red; button1.Hide(); }
           
            label1.Text = ClickedServer.Name;
            label2.Text = ClickedServer.Description;
            label3.Text = "Allows: " + allows;
            label5.Text = "Type: " + ClickedServer.Type;
            label4.Text = $"{ClickedServer.Players}/{ClickedServer.MaxPlayers}";

            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connect to lrm server
        }
    }
}
