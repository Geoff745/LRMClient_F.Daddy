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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.page = new _5Daddy.MSFramework.LRM_Page();
            this.landingDatabase1 = new _5Daddy.MSFramework.LandingDatabase();
            this.airTraffic1 = new _5Daddy.MSFramework.AirTraffic();
            this.settings1 = new _5Daddy.MSFramework.Settings();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(130, 308);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(107, 58);
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
            this.metroTile2.Location = new System.Drawing.Point(242, 308);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(107, 58);
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
            this.metroTile3.Location = new System.Drawing.Point(354, 308);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(107, 58);
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
            this.metroTile4.Location = new System.Drawing.Point(466, 308);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(107, 58);
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
            this.pictureBox1.Location = new System.Drawing.Point(1, -6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 17);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(130, 301);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 2);
            this.panel1.TabIndex = 12;
            // 
            // page
            // 
            this.page.BackColor = System.Drawing.Color.White;
            this.page.Location = new System.Drawing.Point(0, 21);
            this.page.Margin = new System.Windows.Forms.Padding(1);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(708, 271);
            this.page.TabIndex = 11;
            // 
            // landingDatabase1
            // 
            this.landingDatabase1.BackColor = System.Drawing.Color.White;
            this.landingDatabase1.Location = new System.Drawing.Point(-1, 21);
            this.landingDatabase1.Margin = new System.Windows.Forms.Padding(1);
            this.landingDatabase1.Name = "landingDatabase1";
            this.landingDatabase1.Size = new System.Drawing.Size(708, 271);
            this.landingDatabase1.TabIndex = 6;
            this.landingDatabase1.Load += new System.EventHandler(this.landingDatabase1_Load);
            // 
            // airTraffic1
            // 
            this.airTraffic1.Location = new System.Drawing.Point(-1, 21);
            this.airTraffic1.Margin = new System.Windows.Forms.Padding(1);
            this.airTraffic1.Name = "airTraffic1";
            this.airTraffic1.Size = new System.Drawing.Size(708, 271);
            this.airTraffic1.TabIndex = 10;
            // 
            // settings1
            // 
            this.settings1.Location = new System.Drawing.Point(-1, 21);
            this.settings1.Margin = new System.Windows.Forms.Padding(1);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(708, 271);
            this.settings1.TabIndex = 9;
            // 
            // PilotTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 368);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.page);
            this.Controls.Add(this.metroTile4);
            this.Controls.Add(this.metroTile3);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.landingDatabase1);
            this.Controls.Add(this.airTraffic1);
            this.Controls.Add(this.settings1);
            this.Name = "PilotTab";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Green;
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
        private System.Windows.Forms.Timer timer1;
        private LRM_Page page;
        private System.Windows.Forms.Panel panel1;
    }
}