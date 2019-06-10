/*---------------------------------------------------------------------------------
 *  Van Gogh Flow
 *  Benjamin Pritchard / Kundalini Software
 *  6-June-2019
 * 
 *  Van Gogh Flow is a small program written for Windows 10-based computers 
 *  which overlays the display with semi-transparent visualizations.
 *  
 *  The overlays are pulled from YouTube and rendered using the awesome 
 *  cefSharp browser component.
 *  
 *  Writing programs like this is like standing on the shoulders of giants.
 *  
 *  https://www.kundalinisoftware.com/van-gogh-flow/
 * 
 *-------------------------------------------------------------------------------*/


using System;
using System.Drawing;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;


namespace VanGoghFlow
{
    public partial class OverlayForm : Form
    {

        public ChromiumWebBrowser chromeBrowser;

        // read in our config file, and create the popup menu
        public void ReadConfig()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "VanGoghFlow.ini";
            string[] lines = System.IO.File.ReadAllLines(directory + FileName);
            foreach (string line in lines)
            {
                string URL = line.Split('|')[0];
                string Name = line.Split('|')[1];
            }
        }

        // create some global hotkeys, so the user can adjust the opacity
        // opacity UP
        // opactiy DOWN
        // show video
        // hide video
        public void RegisterHotKeys()
        {

        }

        public OverlayForm()
        {

            Form f = new About();
            f.Show();

            //

            InitializeComponent();
            InitializeChromium();

            // create a semi-transparent always-on-top style window
            // (CreateParams() below sets the extended window styles we need)

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = .10;                 // default to 25% opacity; can be changed at runtime with hotkeys
            this.TopMost = true;                // create an always-on-top window, over top of everything else
            this.ShowInTaskbar = false;

            // give the user some hotkeys to adjust the opacity
            RegisterHotKeys();

            // parse our config file
            ReadConfig();

            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;

            DoVideo1();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
         
        }

        // just create an instance of ChromiumWebBrowser and set it to fill up the whole screen
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            chromeBrowser = new ChromiumWebBrowser("");
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        public void DoNoVideo()
        {
            chromeBrowser.LoadHtml("<html><body>Hello world</body></html>");
        }

        public void DoVideo1()
        {

            String YouTubeURL = "https://www.youtube.com/embed/QFZBTYFTeto"     ; //vr-jtDjTaIc";
            String Params = "?rel=0;&autoplay=1&mute=1";
            chromeBrowser.Load(YouTubeURL + Params);
        }

        public void DoVideo2()
        {
            String YouTubeURL = "https://www.youtube.com/embed/EeqF6m3MqqY";
            String Params = "?rel=0;&autoplay=1&mute=1";
            chromeBrowser.Load(YouTubeURL + Params);
        }

        

        // create our window with the layered, transparent flags, and toolwindow flags
        // (WS_EX_TOOLWINDOW prevents us from showing up with ALT-TAB)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80000;  /* WS_EX_LAYERED        */
                cp.ExStyle |= 0x20;     /* WS_EX_TRANSPARENT    */
                cp.ExStyle |= 0x80;     /* WS_EX_TOOLWINDOW     */
                return cp;
            }
        }

       
        private void notifyIcon1_DoubleClick(object sender,
                                     System.EventArgs e)
        {
            Form f = new About();
            f.Show();
        }

    

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            this.Opacity = 0;
            Form f = new About();
            f.ShowDialog();
            */
        }

        private void NoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoNoVideo();
        }

        private void Video1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoVideo1();
        }

        private void Video2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoVideo2();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OverlayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Icon = null;
        }

        private void OverlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Icon = null;
        }
    }
}
