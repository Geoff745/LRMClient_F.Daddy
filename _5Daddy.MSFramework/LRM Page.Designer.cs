namespace _5Daddy.MSFramework
{
    partial class LRM_Page
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PitchLabel = new System.Windows.Forms.Label();
            this.BankLabel = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.WindHeadingLabel = new System.Windows.Forms.Label();
            this.WindSpeedLabel = new System.Windows.Forms.Label();
            this.FPMBox = new System.Windows.Forms.TextBox();
            this.FPMLabel = new System.Windows.Forms.Label();
            this.ScoreBox = new System.Windows.Forms.TextBox();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.OffsetReaderTimer = new System.Windows.Forms.Timer(this.components);
            this.PitchBox = new System.Windows.Forms.Label();
            this.BankBox = new System.Windows.Forms.Label();
            this.SpeedBox = new System.Windows.Forms.Label();
            this.WindSpeedBox = new System.Windows.Forms.Label();
            this.WindHeadingBox = new System.Windows.Forms.Label();
            this.ConnectionTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PitchLabel
            // 
            this.PitchLabel.AutoSize = true;
            this.PitchLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.PitchLabel.Location = new System.Drawing.Point(18, 17);
            this.PitchLabel.Name = "PitchLabel";
            this.PitchLabel.Size = new System.Drawing.Size(99, 46);
            this.PitchLabel.TabIndex = 0;
            this.PitchLabel.Text = "Pitch";
            // 
            // BankLabel
            // 
            this.BankLabel.AutoSize = true;
            this.BankLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.BankLabel.Location = new System.Drawing.Point(18, 75);
            this.BankLabel.Name = "BankLabel";
            this.BankLabel.Size = new System.Drawing.Size(98, 46);
            this.BankLabel.TabIndex = 6;
            this.BankLabel.Text = "Bank";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.SpeedLabel.Location = new System.Drawing.Point(18, 134);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(123, 46);
            this.SpeedLabel.TabIndex = 7;
            this.SpeedLabel.Text = "Speed";
            // 
            // WindHeadingLabel
            // 
            this.WindHeadingLabel.AutoSize = true;
            this.WindHeadingLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.WindHeadingLabel.Location = new System.Drawing.Point(18, 251);
            this.WindHeadingLabel.Name = "WindHeadingLabel";
            this.WindHeadingLabel.Size = new System.Drawing.Size(255, 46);
            this.WindHeadingLabel.TabIndex = 11;
            this.WindHeadingLabel.Text = "Wind Heading";
            // 
            // WindSpeedLabel
            // 
            this.WindSpeedLabel.AutoSize = true;
            this.WindSpeedLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.WindSpeedLabel.Location = new System.Drawing.Point(18, 192);
            this.WindSpeedLabel.Name = "WindSpeedLabel";
            this.WindSpeedLabel.Size = new System.Drawing.Size(220, 46);
            this.WindSpeedLabel.TabIndex = 10;
            this.WindSpeedLabel.Text = "Wind Speed";
            // 
            // FPMBox
            // 
            this.FPMBox.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.FPMBox.Location = new System.Drawing.Point(826, 22);
            this.FPMBox.Name = "FPMBox";
            this.FPMBox.ReadOnly = true;
            this.FPMBox.Size = new System.Drawing.Size(188, 54);
            this.FPMBox.TabIndex = 12;
            // 
            // FPMLabel
            // 
            this.FPMLabel.AutoSize = true;
            this.FPMLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.FPMLabel.Location = new System.Drawing.Point(684, 26);
            this.FPMLabel.Name = "FPMLabel";
            this.FPMLabel.Size = new System.Drawing.Size(91, 46);
            this.FPMLabel.TabIndex = 13;
            this.FPMLabel.Text = "FPM";
            // 
            // ScoreBox
            // 
            this.ScoreBox.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.ScoreBox.Location = new System.Drawing.Point(826, 94);
            this.ScoreBox.Name = "ScoreBox";
            this.ScoreBox.ReadOnly = true;
            this.ScoreBox.Size = new System.Drawing.Size(162, 54);
            this.ScoreBox.TabIndex = 14;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.ScoreLabel.Location = new System.Drawing.Point(684, 98);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(111, 46);
            this.ScoreLabel.TabIndex = 15;
            this.ScoreLabel.Text = "Score";
            // 
            // OffsetReaderTimer
            // 
            this.OffsetReaderTimer.Tick += new System.EventHandler(this.UpdateForm);
            // 
            // PitchBox
            // 
            this.PitchBox.AutoSize = true;
            this.PitchBox.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.PitchBox.Location = new System.Drawing.Point(369, 17);
            this.PitchBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PitchBox.Name = "PitchBox";
            this.PitchBox.Size = new System.Drawing.Size(35, 46);
            this.PitchBox.TabIndex = 26;
            this.PitchBox.Text = "°";
            // 
            // BankBox
            // 
            this.BankBox.AutoSize = true;
            this.BankBox.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.BankBox.Location = new System.Drawing.Point(369, 75);
            this.BankBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BankBox.Name = "BankBox";
            this.BankBox.Size = new System.Drawing.Size(35, 46);
            this.BankBox.TabIndex = 27;
            this.BankBox.Text = "°";
            // 
            // SpeedBox
            // 
            this.SpeedBox.AutoSize = true;
            this.SpeedBox.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.SpeedBox.Location = new System.Drawing.Point(369, 134);
            this.SpeedBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SpeedBox.Name = "SpeedBox";
            this.SpeedBox.Size = new System.Drawing.Size(107, 46);
            this.SpeedBox.TabIndex = 28;
            this.SpeedBox.Text = "knots";
            // 
            // WindSpeedBox
            // 
            this.WindSpeedBox.AutoSize = true;
            this.WindSpeedBox.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.WindSpeedBox.Location = new System.Drawing.Point(369, 192);
            this.WindSpeedBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WindSpeedBox.Name = "WindSpeedBox";
            this.WindSpeedBox.Size = new System.Drawing.Size(107, 46);
            this.WindSpeedBox.TabIndex = 29;
            this.WindSpeedBox.Text = "knots";
            // 
            // WindHeadingBox
            // 
            this.WindHeadingBox.AutoSize = true;
            this.WindHeadingBox.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17.75F);
            this.WindHeadingBox.Location = new System.Drawing.Point(369, 251);
            this.WindHeadingBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WindHeadingBox.Name = "WindHeadingBox";
            this.WindHeadingBox.Size = new System.Drawing.Size(35, 46);
            this.WindHeadingBox.TabIndex = 30;
            this.WindHeadingBox.Text = "°";
            // 
            // ConnectionTimer
            // 
            this.ConnectionTimer.Tick += new System.EventHandler(this.ConnectionTimer_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 15F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(4, 349);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 63);
            this.button1.TabIndex = 31;
            this.button1.Text = "Searching... ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LRM_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WindHeadingBox);
            this.Controls.Add(this.WindSpeedBox);
            this.Controls.Add(this.SpeedBox);
            this.Controls.Add(this.BankBox);
            this.Controls.Add(this.PitchBox);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.ScoreBox);
            this.Controls.Add(this.FPMLabel);
            this.Controls.Add(this.FPMBox);
            this.Controls.Add(this.WindHeadingLabel);
            this.Controls.Add(this.WindSpeedLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.BankLabel);
            this.Controls.Add(this.PitchLabel);
            this.Name = "LRM_Page";
            this.Size = new System.Drawing.Size(1062, 417);
            this.Load += new System.EventHandler(this.LRM_Page_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PitchLabel;
        private System.Windows.Forms.Label BankLabel;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label WindHeadingLabel;
        private System.Windows.Forms.Label WindSpeedLabel;
        private System.Windows.Forms.TextBox FPMBox;
        private System.Windows.Forms.Label FPMLabel;
        private System.Windows.Forms.TextBox ScoreBox;
        private System.Windows.Forms.Label ScoreLabel;
        public System.Windows.Forms.Timer OffsetReaderTimer;
        private System.Windows.Forms.Label PitchBox;
        private System.Windows.Forms.Label BankBox;
        private System.Windows.Forms.Label SpeedBox;
        private System.Windows.Forms.Label WindSpeedBox;
        private System.Windows.Forms.Label WindHeadingBox;
        private System.Windows.Forms.Timer ConnectionTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}
