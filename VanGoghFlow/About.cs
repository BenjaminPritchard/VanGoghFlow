using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanGoghFlow
{
    public partial class About : Form
    {

        int DelayCount = 0;

        public About()
        {
            InitializeComponent();

            // just setup a timer to fade out this form
            timer1.Interval = 100;
            timer1.Enabled = true;
        
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            string VersionString = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            e.Graphics.DrawString("Van Gogh Flow / Kundalini Software", new Font("Arial", 20), Brushes.White, new Point(15, 115));
            e.Graphics.DrawString("Version " + VersionString, new Font("Arial", 10), Brushes.White, new Point(15, 155));
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // hang out for 3 seconds
            if (DelayCount < 10 * 3)
            {
                DelayCount++;
                return;
            }
            // otherwise start fading out this form
            this.Opacity = this.Opacity +- .20;

            // and when we are done fading, just close the form
            if (this.Opacity == 0)
            {
                timer1.Enabled = false;
                this.Close();
            }
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }

        private void About_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
