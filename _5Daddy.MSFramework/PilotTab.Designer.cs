namespace _5Daddy.MSFramework
{
    partial class PilotTab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroTile5 = new MetroFramework.Controls.MetroTile();
            this.NextLR = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.page = new _5Daddy.MSFramework.LRM_Page();
            this.landingDatabase1 = new _5Daddy.MSFramework.LandingDatabase();
            this.airTraffic1 = new _5Daddy.MSFramework.AirTraffic();
            this.settings1 = new _5Daddy.MSFramework.Settings();
            this.lrmServers1 = new _5Daddy.MSFramework.LRMServers();
            this.notify1 = new _5Daddy.MSFramework.Notify();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(116, 475);
            this.metroTile1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(160, 89);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile1.TabIndex = 2;
            this.metroTile1.TabStop = false;
            this.metroTile1.Text = "LRM";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(284, 475);
            this.metroTile2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(160, 89);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile2.TabIndex = 3;
            this.metroTile2.TabStop = false;
            this.metroTile2.Text = "Air Traffic";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Location = new System.Drawing.Point(452, 475);
            this.metroTile3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(160, 89);
            this.metroTile3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile3.TabIndex = 4;
            this.metroTile3.TabStop = false;
            this.metroTile3.Text = "Log Book";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.Click += new System.EventHandler(this.metroTile3_Click);
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Location = new System.Drawing.Point(789, 475);
            this.metroTile4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(160, 89);
            this.metroTile4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile4.TabIndex = 5;
            this.metroTile4.TabStop = false;
            this.metroTile4.Text = "Settings";
            this.metroTile4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile4.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile4.UseSelectable = true;
            this.metroTile4.Click += new System.EventHandler(this.metroTile4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 26);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(116, 446);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 18);
            this.panel1.TabIndex = 12;
            // 
            // metroTile5
            // 
            this.metroTile5.ActiveControl = null;
            this.metroTile5.Location = new System.Drawing.Point(620, 475);
            this.metroTile5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroTile5.Name = "metroTile5";
            this.metroTile5.Size = new System.Drawing.Size(160, 89);
            this.metroTile5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile5.TabIndex = 13;
            this.metroTile5.TabStop = false;
            this.metroTile5.Text = "Servers";
            this.metroTile5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile5.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile5.UseSelectable = true;
            this.metroTile5.Click += new System.EventHandler(this.metroTile5_Click);
            // 
            // NextLR
            // 
            this.NextLR.Interval = 60000;
            this.NextLR.Tick += new System.EventHandler(this.NextLR_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            // 
            // page
            // 
            this.page.BackColor = System.Drawing.Color.White;
            this.page.Location = new System.Drawing.Point(0, 32);
            this.page.Margin = new System.Windows.Forms.Padding(2);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(1062, 417);
            this.page.TabIndex = 11;
            // 
            // landingDatabase1
            // 
            this.landingDatabase1.BackColor = System.Drawing.Color.White;
            this.landingDatabase1.Location = new System.Drawing.Point(-2, 32);
            this.landingDatabase1.Margin = new System.Windows.Forms.Padding(2);
            this.landingDatabase1.Name = "landingDatabase1";
            this.landingDatabase1.Size = new System.Drawing.Size(1062, 417);
            this.landingDatabase1.TabIndex = 6;
            this.landingDatabase1.Load += new System.EventHandler(this.landingDatabase1_Load);
            // 
            // airTraffic1
            // 
            this.airTraffic1.Location = new System.Drawing.Point(-2, 32);
            this.airTraffic1.Margin = new System.Windows.Forms.Padding(2);
            this.airTraffic1.Name = "airTraffic1";
            this.airTraffic1.Size = new System.Drawing.Size(1062, 417);
            this.airTraffic1.TabIndex = 10;
            // 
            // settings1
            // 
            this.settings1.BackColor = System.Drawing.Color.White;
            this.settings1.Location = new System.Drawing.Point(-2, 32);
            this.settings1.Margin = new System.Windows.Forms.Padding(2);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(1062, 417);
            this.settings1.TabIndex = 9;
            // 
            // lrmServers1
            // 
            this.lrmServers1.Location = new System.Drawing.Point(-2, 32);
            this.lrmServers1.Name = "lrmServers1";
            this.lrmServers1.Size = new System.Drawing.Size(1062, 417);
            this.lrmServers1.TabIndex = 17;
            // 
            // notify1
            // 
            this.notify1.BackColor = System.Drawing.Color.White;
            this.notify1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notify1.Location = new System.Drawing.Point(349, -213);
            this.notify1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.notify1.Name = "notify1";
            this.notify1.Size = new System.Drawing.Size(368, 249);
            this.notify1.TabIndex = 14;
            // 
            // PilotTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 566);
            this.Controls.Add(this.notify1);
            this.Controls.Add(this.metroTile5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroTile4);
            this.Controls.Add(this.metroTile3);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroTile1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PilotTab";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Closed);
            this.Load += new System.EventHandler(this.PilotTab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroTile metroTile4;
        private LandingDatabase landingDatabase1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Settings settings1;
        private AirTraffic airTraffic1;
        private LRM_Page page;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTile metroTile5;
        private System.Windows.Forms.Timer NextLR;
        private System.Windows.Forms.Timer timer1;
        private LRMServers lrmServers1;
        private Notify notify1;
    }
}