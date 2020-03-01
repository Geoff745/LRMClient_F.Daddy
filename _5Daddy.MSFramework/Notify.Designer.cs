namespace _5Daddy.MSFramework
{
    partial class Notify
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
            this.Title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Close = new System.Windows.Forms.Button();
            this.TextArea = new System.Windows.Forms.RichTextBox();
            this.Static = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 15.25F);
            this.Title.Location = new System.Drawing.Point(7, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(52, 28);
            this.Title.TabIndex = 16;
            this.Title.Text = "Title";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(8, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 1);
            this.panel1.TabIndex = 17;
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Gainsboro;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10F);
            this.Close.Location = new System.Drawing.Point(214, -1);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(32, 26);
            this.Close.TabIndex = 18;
            this.Close.Text = "X";
            this.Close.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // TextArea
            // 
            this.TextArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextArea.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextArea.Location = new System.Drawing.Point(10, 38);
            this.TextArea.Name = "TextArea";
            this.TextArea.Size = new System.Drawing.Size(219, 119);
            this.TextArea.TabIndex = 19;
            this.TextArea.Text = "";
            // 
            // Static
            // 
            this.Static.Enabled = true;
            this.Static.Tick += new System.EventHandler(this.Static_Tick);
            // 
            // Notify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.TextArea);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Close);
            this.Name = "Notify";
            this.Size = new System.Drawing.Size(245, 162);
            this.Load += new System.EventHandler(this.Notify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.RichTextBox TextArea;
        private System.Windows.Forms.Timer Static;
    }
}
