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
    public partial class Notify : UserControl
    {
        public static bool Promping = false;
        public Notify()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
            PilotTab.reset = true;
        }
        public static string TitleText = "";
        public static string DescText = "";
        private void Notify_Load(object sender, EventArgs e)
        {
            Static.Start();
        }

        private void Static_Tick(object sender, EventArgs e)
        {
            Title.Text = TitleText;
            TextArea.Text = DescText;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Promping)
            {
                Timer t = new Timer()
                {
                    Interval = 5,
                };
                t.Tick += (object s, EventArgs a) =>
                {
                    this.Location = new Point(Location.X, Location.Y - 1);
                    if (Location.Y == Parent.Size.Height - 5)
                    {
                        t.Enabled = false;
                    }
                };
            }
        }
    }
}
