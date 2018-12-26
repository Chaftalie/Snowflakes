using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Snowflakes
{
    public partial class Form1 : Form
    {
        Flake[] flock;

        public Form1()
        {
            InitializeComponent();

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            int n = 10000;
            flock = new Flake[n];
            for (int i = 0; i < n; i++)
            {
                flock[i] = new Flake(pBx_main.Width, pBx_main.Height);
            }
        }

        private void pBx_main_Paint(object sender, PaintEventArgs e)
        {
            foreach(Flake boid in flock)
            {
                boid.edges();
                boid.Update();
                boid.show(e);
            }
        }

        private void tmr_16ms_Tick(object sender, EventArgs e)
        {
            pBx_main.Invalidate();
        }
    }
}