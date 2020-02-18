using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _5Daddy.MSFramework.Connection;
using static _5Daddy.MSFramework.Global;
namespace _5Daddy.MSFramework
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
        public Main()
        {
            InitializeComponent();
            Login_btn.Text = "Login as " + Username;
        }

        private void Main_Load(object sender, EventArgs e)
        {

 
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            PilotTab pl = new PilotTab();
            pl.Show();
            Hide();
        }
    }
}
