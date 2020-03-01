using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5Daddy.MSFramework
{
    public partial class LRMServers : UserControl
    {
        class LRMServer
        {
            string Name { get; set; }
            string Players { get; set; }
            string MaxPlayers { get; set; }
            string Description { get; set; }
            string Type { get; set; }
            string AllowedFlightSims { get; set; }
            string IP { get; set; }
        }

        List<LRMServer> CurrentServers = new List<LRMServer>();

        public LRMServers()
        {
            InitializeComponent();
            
        }

        private void LRMServers_Load(object sender, EventArgs e)
        {
            if (!Global.OfflineMode)
            {
                //setup timer
                //ask master server for current lrm servers every 5 seconds
                //display those servers
            }
        }
    }
}
