using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5Daddy.MSFramework
{
    public partial class PilotTab : MetroFramework.Forms.MetroForm
    {
        
        public PilotTab()
        {
            InitializeComponent();
            pl_lb.Text = "Hello, " + Global.Username;

            page = new LRM_Page();
            page.Hide();
            page.Location = new Point(-1, 95);
        }

        private void PilotTab_Load(object sender, EventArgs e)
        {
            page.Hide();
            landingDatabase1.Hide();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            page.Hide();
            landingDatabase1.Hide();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            page.Hide();
            landingDatabase1.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            page.Hide();
            landingDatabase1.Hide();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            page.Show();
            landingDatabase1.Hide();
        }
    }
}
