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
        Boid[] flock;

        float alignValue = (float)0.5;
        float cohesionValue = 1;
        float seperationValue = 1;

        public Form1()
        {
            InitializeComponent();

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            int n = 5000;
            flock = new Boid[n];
            for (int i = 0; i < n; i++)
            {
                flock[i] = new Boid(pBx_main.Width, pBx_main.Height, alignValue, cohesionValue, seperationValue);
            }
        }

        private void pBx_main_Paint(object sender, PaintEventArgs e)
        {
            foreach(Boid boid in flock)
            {
                boid.edges();

                //boid.flock(flock);
                boid.update();
                boid.show(e);
            }
        }

        private void tmr_16ms_Tick(object sender, EventArgs e)
        {
            pBx_main.Invalidate();
        }
    }
}