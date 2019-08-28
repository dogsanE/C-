using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace household_seojun
{
    public partial class Lobby : Form
    {

        public Lobby()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Image lobbypng = Image.FromFile("C:\\lobbyimage.png");

            //g.DrawImage(lobbypng, 0, 0);
        }

        private void LoginBt_Click(object sender, EventArgs e)
        {
            Login gn = new Login();
            DialogResult result = gn.ShowDialog();
            this.Visible = false;
        }

        private void Lobby_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
