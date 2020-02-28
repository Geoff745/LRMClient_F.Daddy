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
            //pl_lb.Text = "Hello, " + Global.Username;
            
        }
        Dictionary<string, int> ControlPoints = new Dictionary<string, int>();
        bool MovingControl = false;
        Rectangle r;
        Rectangle Base;
        int offsetx = 0;
        int prev = 0;
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
            //move to closest box 
            if (r.IntersectsWith(new Rectangle(page.Location, page.Size)))
            {
                p1 = new Point(Base.Location.X, Base.Location.Y);
                p2 = new Point(Base.Location.X + Base.Width + 6, Base.Location.Y);
                p3 = new Point(Base.Location.X + (Base.Width * 2) + 12, Base.Location.Y);
                p4 = new Point(Base.Location.X + (Base.Width * 3) + 18, Base.Location.Y);
            }
            else if (r.IntersectsWith(new Rectangle(airTraffic1.Location, airTraffic1.Size)))
            {
                p1 = new Point((Base.Location.X - Base.Width) - 6, Base.Location.Y);
                p2 = new Point(Base.Location.X, Base.Location.Y);
                p3 = new Point(Base.Location.X + (Base.Width) + 6, Base.Location.Y);
                p4 = new Point(Base.Location.X + (Base.Width * 2) + 12, Base.Location.Y);
            }
            else if (r.IntersectsWith(new Rectangle(landingDatabase1.Location, landingDatabase1.Size)))
            {
                p1 = new Point(Base.Location.X - (Base.Width * 2) - 12, Base.Location.Y);
                p2 = new Point((Base.Location.X - Base.Width) - 6, Base.Location.Y);
                p3 = new Point(Base.Location.X, Base.Location.Y);
                p4 = new Point(Base.Location.X + (Base.Width) + 6, Base.Location.Y);
            }
            else if (r.IntersectsWith(new Rectangle(settings1.Location, settings1.Size)))
            {
                p1 = new Point(Base.Location.X - (Base.Width * 3) - 18, Base.Location.Y);
                p2 = new Point(Base.Location.X - (Base.Width * 2) - 12, Base.Location.Y);
                p3 = new Point(Base.Location.X - Base.Width, Base.Location.Y);
                p4 = new Point(Base.Location.X, Base.Location.Y);
            }
            else
                return;
            EventHandler h = null;
            h = (object s, EventArgs ev) =>
            {
                if (!Down)
                {
                    if (p1.X != page.Location.X && p2.X != airTraffic1.Location.X && p3.X != landingDatabase1.Location.X && p4.X != settings1.Location.X)
                    {
                        page.Location = new Point((p1.X + page.Location.X) / 2, p1.Y);
                        airTraffic1.Location = new Point((p2.X + airTraffic1.Location.X) / 2, p2.Y);
                        landingDatabase1.Location = new Point((p3.X + landingDatabase1.Location.X) / 2, p3.Y);
                        settings1.Location = new Point((p4.X + settings1.Location.X) / 2, p4.Y);
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
        bool Down = false;
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
            settings1.Location = new Point(page.Location.X + (page.Width * 3) + 18, page.Location.Y);
            page.Show();
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
        private void MoveToPage(Pages Page)
        {
            //Down = false;
            //offsetx = 0;
            //MovingControl = false;
            //Pages currpage;
            ////move to closest box 
            //if (r.IntersectsWith(new Rectangle(page.Location, page.Size)))
            //{
            //    currpage = Pages.LRM;
            //}
            //else if (r.IntersectsWith(new Rectangle(airTraffic1.Location, airTraffic1.Size)))
            //{
            //    currpage = Pages.AirTraffic;
            //}
            //else if (r.IntersectsWith(new Rectangle(landingDatabase1.Location, landingDatabase1.Size)))
            //{
            //    currpage = Pages.LandingDatabase;
            //}
            //else if (r.IntersectsWith(new Rectangle(settings1.Location, settings1.Size)))
            //{
            //    currpage = Pages.Settings;
            //}
            //else
            //    return;
            //if (currpage == Page)
            //    return;

            //Control destControl = null;
            //Control currControl = null;
            //switch (Page)
            //{
            //    case Pages.AirTraffic:
            //        destControl = airTraffic1;
            //        break;
            //    case Pages.LandingDatabase:
            //        destControl = landingDatabase1;
            //        break;
            //    case Pages.LRM:
            //        destControl = page;
            //        break;
            //    case Pages.Settings:
            //        destControl = settings1;
            //        break;
            //}

            //switch (currpage)
            //{
            //    case Pages.AirTraffic:
            //        currControl = airTraffic1;
            //        break;
            //    case Pages.LandingDatabase:
            //        currControl = landingDatabase1;
            //        break;
            //    case Pages.LRM:
            //        currControl = page;
            //        break;
            //    case Pages.Settings:
            //        currControl = settings1;
            //        break;
            //}

            //if (destControl == null)
            //    return;

            //int destx = destControl.Location.X;
            //int currx = currControl.Location.X;
            //bool left = false;
            //if (destx < currx)
            //    left = true;

            //EventHandler h = null;
            //h = (object s, EventArgs ev) =>
            //{
            //    if (!Down)
            //    {
            //        if (destx != currx)
            //        {
            //            page.Location = new Point((destx + page.Location.X) / 2, p1.Y);
            //            airTraffic1.Location = new Point((p2.X + airTraffic1.Location.X) / 2, p2.Y);
            //            landingDatabase1.Location = new Point((p3.X + landingDatabase1.Location.X) / 2, p3.Y);
            //            settings1.Location = new Point((p4.X + settings1.Location.X) / 2, p4.Y);
            //        }
            //        else
            //        {
            //            timer1.Enabled = false;
            //            timer1.Tick -= h;
            //        }
            //    }
            //    else
            //    {
            //        timer1.Enabled = false;
            //        timer1.Tick -= h;
            //    }
            //};
            //timer1.Tick += h;
            //timer1.Enabled = true;
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            CurrentControl = "Settings";
            //page.Hide();
            //airTraffic1.Hide();
            //settings1.Show();
            //landingDatabase1.Hide();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            CurrentControl = "Log Book";
            //page.Hide();
            //airTraffic1.Hide();
            //settings1.Hide();
            //landingDatabase1.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            CurrentControl = "Air Traffic";
            //page.Hide();
            //airTraffic1.Show();
            //settings1.Hide();
            //landingDatabase1.Hide();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            CurrentControl = "Pilot Menu";
            //page.Show();
            //landingDatabase1.Hide();
        }
        
        string CurrentControl = "";

        private void landingDatabase1_Load(object sender, EventArgs e)
        {

        }
    }
}