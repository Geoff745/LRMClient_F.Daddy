using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
namespace _5Daddy.MSFramework
{
    public partial class PilotTab : MetroFramework.Forms.MetroForm
    {
        bool Down = false;
        public PilotTab()
        {
            InitializeComponent();
            this.Controls.Add(this.landingDatabase1);
            this.Controls.Add(this.airTraffic1);
            this.Controls.Add(this.settings1);
            this.Controls.Add(this.page);
            this.Controls.Add(this.lrmServers1);
            notify1.Hide();
            //pl_lb.Text = "Hello, " + Global.Username;

        }
        Dictionary<string, int> ControlPoints = new Dictionary<string, int>();
        bool MovingControl = false;
        Rectangle r;
        Rectangle Base;
        int offsetx = 0;
       
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MovingControl)
            {
                if (offsetx == 0)
                    offsetx = e.X;
               
                page.Location = new Point(page.Location.X + ((offsetx - e.X) * 5), page.Location.Y);
                airTraffic1.Location = new Point(airTraffic1.Location.X + ((offsetx - e.X) * 5), airTraffic1.Location.Y);
                landingDatabase1.Location = new Point(landingDatabase1.Location.X + ((offsetx - e.X) * 5), landingDatabase1.Location.Y);
                settings1.Location = new Point(settings1.Location.X + ((offsetx - e.X) * 5), settings1.Location.Y);
                offsetx = e.X;
            }

        }
        

       
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            Down = false;
            offsetx = 0;
            MovingControl = false;
            Point p1 = new Point();
            Point p2;
            Point p3;
            Point p4;
            Point p5;
            //move to closest box 
            if (pictureBox1.Location.X > 0 || pictureBox1.Location.X > 336)
                pictureBox1.Location = new Point(0, 0);
            if (r.IntersectsWith(new Rectangle(page.Location, page.Size)))
            {
                p1 = new Point(Base.Location.X, Base.Location.Y);
                p2 = new Point(Base.Location.X + Base.Width + 6, Base.Location.Y);
                p3 = new Point(Base.Location.X + (Base.Width * 2) + 12, Base.Location.Y);
                p4 = new Point(Base.Location.X + (Base.Width * 3) + 18, Base.Location.Y);
                p5 = new Point(Base.Location.X + (Base.Width * 4) + 24, Base.Location.Y);
                pictureBox1.Location = new Point(0, 0);
            }
            else if (r.IntersectsWith(new Rectangle(airTraffic1.Location, airTraffic1.Size)))
            {
                p1 = new Point((Base.Location.X - Base.Width) - 6, Base.Location.Y);
                p2 = new Point(Base.Location.X, Base.Location.Y);
                p3 = new Point(Base.Location.X + (Base.Width) + 6, Base.Location.Y);
                p4 = new Point(Base.Location.X + (Base.Width * 2) + 12, Base.Location.Y);
                p5 = new Point(Base.Location.X + (Base.Width * 3) + 18, Base.Location.Y);
                pictureBox1.Location = new Point(112, 0);
            }
            else if (r.IntersectsWith(new Rectangle(landingDatabase1.Location, landingDatabase1.Size)))
            {
                p1 = new Point(Base.Location.X - (Base.Width * 2) - 12, Base.Location.Y);
                p2 = new Point((Base.Location.X - Base.Width) - 6, Base.Location.Y);
                p3 = new Point(Base.Location.X, Base.Location.Y);
                p4 = new Point(Base.Location.X + (Base.Width) + 6, Base.Location.Y);
                p5 = new Point(Base.Location.X + (Base.Width * 2) + 12, Base.Location.Y);
                pictureBox1.Location = new Point(224, 0);
            }
            else if (r.IntersectsWith(new Rectangle(lrmServers1.Location, lrmServers1.Size)))
            {
                p1 = new Point(Base.Location.X - (Base.Width * 3) - 18, Base.Location.Y);
                p2 = new Point(Base.Location.X - (Base.Width * 2) - 12, Base.Location.Y);
                p3 = new Point(Base.Location.X - Base.Width, Base.Location.Y);
                p4 = new Point(Base.Location.X, Base.Location.Y);
                p5 = new Point(Base.Location.X + (Base.Width) + 6, Base.Location.Y);
                pictureBox1.Location = new Point(224, 0);
            }
            else if (r.IntersectsWith(new Rectangle(settings1.Location, settings1.Size)))
            {
                p1 = new Point(Base.Location.X - (Base.Width * 4) - 24, Base.Location.Y);
                p2 = new Point(Base.Location.X - (Base.Width * 3) - 18, Base.Location.Y);
                p3 = new Point(Base.Location.X - (Base.Width * 2) - 12, Base.Location.Y);
                p4 = new Point(Base.Location.X - Base.Width - 6, Base.Location.Y);
                p5 = new Point(Base.Location.X, Base.Location.Y);
                pictureBox1.Location = new Point(336, 0);
            }
            else
                return;
            EventHandler h = null;
            h = (object s, EventArgs ev) =>
            {
                if (!Down)
                {
                    if (p1.X != page.Location.X && p2.X != airTraffic1.Location.X && p3.X != landingDatabase1.Location.X && p4.X != lrmServers1.Location.X && p5.X != settings1.Location.X)
                    {
                        page.Location = new Point((p1.X + page.Location.X) / 2, p1.Y);
                        airTraffic1.Location = new Point((p2.X + airTraffic1.Location.X) / 2, p2.Y);
                        landingDatabase1.Location = new Point((p3.X + landingDatabase1.Location.X) / 2, p3.Y);
                        lrmServers1.Location = new Point((p4.X + lrmServers1.Location.X) / 2, p4.Y);
                        settings1.Location = new Point((p5.X + settings1.Location.X) / 2, p5.Y);
                    }
                    else
                    {
                        timer1.Enabled = false;
                        timer1.Tick -= h;
                    }
                }
                else
                {
                    timer1.Enabled = false;
                    timer1.Tick -= h;
                }
            };
            timer1.Tick += h;
            timer1.Enabled = true;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Down = true;
            offsetx = 0;
            MovingControl = true;
        }

        private void PilotTab_Load(object sender, EventArgs e)
        {
            
            landingDatabase1.Hide();
            r = new Rectangle((this.Width / 2) - 5, this.Height / 2, 10, 3);
            Base = new Rectangle(page.Location, page.Size);
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            airTraffic1.Location = new Point(page.Location.X + page.Width + 6, page.Location.Y);
            landingDatabase1.Location = new Point(page.Location.X + (page.Width * 2) + 12, page.Location.Y);
            lrmServers1.Location = new Point(page.Location.X + (page.Width * 3) + 18, page.Location.Y);
            settings1.Location = new Point(page.Location.X + (page.Width * 4) + 24, page.Location.Y);
            page.Show();
            lrmServers1.Show();
            airTraffic1.Show();
            settings1.Show();
            landingDatabase1.Show();
        }
        enum Pages
        {
            LRM,
            AirTraffic,
            Settings,
            LandingDatabase
        }
        private void MoveToPage(Point p1, Point p2, Point p3, Point p4, Point p5)
        {
            Down = false;
            EventHandler h = null;
            h = (object s, EventArgs ev) =>
            {
                if (!Down)
                {
                    if (p1.X != page.Location.X && p2.X != airTraffic1.Location.X && p3.X != landingDatabase1.Location.X && p4.X != lrmServers1.Location.X && p5.X != settings1.Location.X)
                    {
                        page.Location = new Point((p1.X + page.Location.X) / 2, p1.Y);
                        airTraffic1.Location = new Point((p2.X + airTraffic1.Location.X) / 2, p2.Y);
                        landingDatabase1.Location = new Point((p3.X + landingDatabase1.Location.X) / 2, p3.Y);
                        lrmServers1.Location = new Point((p4.X + lrmServers1.Location.X) / 2, p4.Y);
                        settings1.Location = new Point((p5.X + settings1.Location.X) / 2, p5.Y);
                    }
                    else
                    {
                        timer1.Enabled = false;
                        timer1.Tick -= h;
                    }
                }
                else
                {
                    timer1.Enabled = false;
                    timer1.Tick -= h;
                }
            };
            timer1.Tick += h;
            timer1.Enabled = true;
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            Down = true;
            Point p1;
            Point p2;
            Point p3;
            Point p4;
            Point p5;
            CurrentControl = "Settings";
            p1 = new Point(Base.Location.X - (Base.Width * 4) - 24, Base.Location.Y);
            p2 = new Point(Base.Location.X - (Base.Width * 3) - 18, Base.Location.Y);
            p3 = new Point(Base.Location.X - (Base.Width * 2) - 12, Base.Location.Y);
            p4 = new Point(Base.Location.X - Base.Width - 6, Base.Location.Y);
            p5 = new Point(Base.Location.X, Base.Location.Y);
            pictureBox1.Location = new Point(336, 0);
            MoveToPage(p1, p2, p3, p4, p5);
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            Down = true;
            Point p1;
            Point p2;
            Point p3;
            Point p4;
            Point p5;
            CurrentControl = "Log Book";
            p1 = new Point(Base.Location.X - (Base.Width * 2) - 12, Base.Location.Y);
            p2 = new Point((Base.Location.X - Base.Width) - 6, Base.Location.Y);
            p3 = new Point(Base.Location.X, Base.Location.Y);
            p4 = new Point(Base.Location.X + (Base.Width) + 6, Base.Location.Y);
            p5 = new Point(Base.Location.X + (Base.Width * 2) + 12, Base.Location.Y);
            pictureBox1.Location = new Point(224, 0);
            MoveToPage(p1, p2, p3, p4, p5);
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Down = true;
            Point p1;
            Point p2;
            Point p3;
            Point p4;
            Point p5;
            CurrentControl = "Air Traffic";
            p1 = new Point((Base.Location.X - Base.Width) - 6, Base.Location.Y);
            p2 = new Point(Base.Location.X, Base.Location.Y);
            p3 = new Point(Base.Location.X + (Base.Width) + 6, Base.Location.Y);
            p4 = new Point(Base.Location.X + (Base.Width * 2) + 12, Base.Location.Y);
            p5 = new Point(Base.Location.X + (Base.Width * 3) + 18, Base.Location.Y);
            pictureBox1.Location = new Point(112, 0);
            MoveToPage(p1, p2, p3, p4, p5);
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {//
            Down = true;
            Point p1;
            Point p2;
            Point p3;
            Point p4;
            Point p5;
            CurrentControl = "LRMPage";
            p1 = new Point(Base.Location.X, Base.Location.Y);
            p2 = new Point(Base.Location.X + Base.Width + 6, Base.Location.Y);
            p3 = new Point(Base.Location.X + (Base.Width * 2) + 12, Base.Location.Y);
            p4 = new Point(Base.Location.X + (Base.Width * 3) + 18, Base.Location.Y);
            p5 = new Point(Base.Location.X + (Base.Width * 4) + 24, Base.Location.Y);
            pictureBox1.Location = new Point(336, 0);
            MoveToPage(p1, p2, p3, p4, p5);
        }

        string CurrentControl = "";

        private void landingDatabase1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            Down = true;
            Point p1;
            Point p2;
            Point p3;
            Point p4;
            Point p5;
            CurrentControl = "Servers";
            p1 = new Point(Base.Location.X - (Base.Width * 3) - 18, Base.Location.Y);
            p2 = new Point(Base.Location.X - (Base.Width * 2) - 12, Base.Location.Y);
            p3 = new Point(Base.Location.X - Base.Width, Base.Location.Y);
            p4 = new Point(Base.Location.X, Base.Location.Y);
            p5 = new Point(Base.Location.X + (Base.Width) + 6, Base.Location.Y);
            pictureBox1.Location = new Point(336, 0);
            MoveToPage(p1, p2, p3, p4, p5);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
        public static bool show = false;
        public static bool reset = false;
        public void PromptNotify()
        {
            notify1.Location = new Point(358, notify1.Size.Height * -1);
            notify1.Show();
            if (Global.UserSettings.Sounds)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Notification);
                player.Play();
            }
            NextLR.Start();
            //notify : 358, -217
            Timer t = new Timer();
            t.Interval = 20;
            int des = (notify1.Size.Height * -1) + 20;
            t.Tick += (object s, EventArgs e) =>
            {
                notify1.Location = new Point(358, notify1.Location.Y + +1);
                if (notify1.Location.Y == des)
                {
                    t.Enabled = false;
                    Notify.Promping = true;
                }
            };
            t.Enabled = true;
        }
        private void NextLR_Tick(object sender, EventArgs e)
        {
            NextLR.Stop();
            reset = true;
        }

        private void Closed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}