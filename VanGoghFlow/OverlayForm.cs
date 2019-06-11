﻿/*---------------------------------------------------------------------------------
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
 *  https://github.com/BenjaminPritchard/VanGoghFlow
 *  
 *  Release History
 *  ---------------
 *  10-June-2019    Version 1.1     First released version
 * 
 *-------------------------------------------------------------------------------*/


using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;


namespace VanGoghFlow
{

   

    public partial class OverlayForm : Form
    {

        Collection<Video> Videos = new Collection<Video>();

        private ChromiumWebBrowser chromeBrowser;
        private KeyboardHook hook = new KeyboardHook();
        private int CurVideoIndex = 0;

        // read in our config file, and create the popup menu
        private Boolean ReadConfig()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "VanGoghFlow.ini123";
            Boolean retval = false;

            try
            {
                string[] lines = System.IO.File.ReadAllLines(directory + FileName);
                foreach (string line in lines)
                {
                    string tmp = line.Trim();

                    // ignore lines that start with a # indicating a comment
                    if (tmp.Contains("|") && !tmp.StartsWith("#")) {

                        string ID = tmp.Split('|')[0].Trim();
                        string Description = tmp.Split('|')[1].Trim();

                        // save each video and description we find
                        Videos.Add(new Video(Description, ID));

                    }
                    // make sure we successfully read in at least one line...
                    retval = (Videos.Count > 0);
                }
            }  catch (Exception e)
            {
                // do nothing, we'll just return false
            }

            return retval;
        }

        private void IncreaseOpacity()
        {
            if (this.Opacity == 1) return;
            this.Opacity  += .1;
        }

        private void DecreaseOpacity()
        {
            if (this.Opacity == 0) return;
            this.Opacity -= .1;
        }


        public OverlayForm()
        {

            // popup our about box; it will stay on the screen for a few seconds
            // and then fade itself out
            Form f = new About();
            f.Show();

            InitializeComponent();
            InitializeChromium();

            // create a semi-transparent always-on-top style window
            // (CreateParams() below sets the extended window styles we need)

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = .10;                 // default to 25% opacity; can be changed at runtime with hotkeys
            this.TopMost = true;                // create an always-on-top window, over top of everything else
            this.ShowInTaskbar = false;

            // parse our config file
            if (!ReadConfig())
            {
                Videos.Add(new Video("Particle Tests", "fpViZkhpPHk"));
                Videos.Add(new Video("Dive Deep Psychedelic Psytrance", "LNeEqv2B_Is"));
                Videos.Add(new Video("Milkdrop  1", "SMxa21MfaFE"));
                Videos.Add(new Video("Geiss v2", "4kd6ES-TaoU"));
                Videos.Add(new Video("Psychedelic Psychill 3D", "8t3XYNxnUBs"));
                Videos.Add(new Video("The Edge of Infinity", "u1pwtSBTnPU"));
                Videos.Add(new Video("The Splendor of Color Kaleidoscope", "gxxqdrrpgZc"));
                Videos.Add(new Video("Cosmic Relaxation", "Y_plhk1FUQA"));                
            }

            // just put an entry in there to not play a video
            Videos.Add(new Video("None", ""));


            // put the videos into the tray icon
            ContextMenu m_menu = new ContextMenu();
            
            foreach (Video v in Videos) {
                m_menu.MenuItems.Add(m_menu.MenuItems.Count,
                    new MenuItem(v.Description, new System.EventHandler(Video_Click)));
            }

            m_menu.MenuItems.Add("-");

            m_menu.MenuItems.Add(m_menu.MenuItems.Count,
               new MenuItem("About", new System.EventHandler(About_Click)));

            m_menu.MenuItems.Add(m_menu.MenuItems.Count,
                new MenuItem("Help", new System.EventHandler(Help_Click)));

            m_menu.MenuItems.Add(m_menu.MenuItems.Count,
                new MenuItem("Config", new System.EventHandler(Config_Click)));

            m_menu.MenuItems.Add("-");

            m_menu.MenuItems.Add(m_menu.MenuItems.Count,
               new MenuItem("Exit", new System.EventHandler(Exit_Click)));


            notifyIcon1.ContextMenu = m_menu;
            notifyIcon1.Visible = true;

            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            try
            {
                // register the control + alt + left & control + alt + right as global hot keys
                hook.RegisterHotKey(VanGoghFlow.ModifierKeys.Control | VanGoghFlow.ModifierKeys.Alt, Keys.D);    // decrease opacity
                hook.RegisterHotKey(VanGoghFlow.ModifierKeys.Control | VanGoghFlow.ModifierKeys.Alt, Keys.I);   // increase opacity

                hook.RegisterHotKey(VanGoghFlow.ModifierKeys.Control | VanGoghFlow.ModifierKeys.Alt, Keys.N);       // next video
                hook.RegisterHotKey(VanGoghFlow.ModifierKeys.Control | VanGoghFlow.ModifierKeys.Alt, Keys.P);       // prev video
            }
            catch (Exception e)
            {
                // if this happens, there is nothing we can do
                // just keep going i guess (without hot key support)
            }

            // default to playing the first video...
            PlayVideo(Videos[0].VideoID);
        }

        private void PlayVideo(String ID)
        {
            
            String YouTubeURL = "https://www.youtube.com/embed/" + ID;
            String Params = "?rel=0;&autoplay=1&mute=1";

            chromeBrowser.Load(YouTubeURL + Params);
        }

        private void DoPrevVideo()
        {
            if (CurVideoIndex != 0)
            {
                CurVideoIndex--;
                PlayVideo(Videos[CurVideoIndex].VideoID);
            }
        }

        private void DoNextVideo()
        {
            if (CurVideoIndex < (Videos.Count - 2) )                // don't forget we have "none" in this list!!
            {
                CurVideoIndex++;
                PlayVideo(Videos[CurVideoIndex].VideoID);
            }
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Modifier == (VanGoghFlow.ModifierKeys.Control | VanGoghFlow.ModifierKeys.Alt))
                switch (e.Key)
                {
                    case System.Windows.Forms.Keys.D: DecreaseOpacity(); break;
                    case System.Windows.Forms.Keys.I: IncreaseOpacity(); break;
                    case System.Windows.Forms.Keys.N: DoNextVideo(); break;
                    case System.Windows.Forms.Keys.P: DoPrevVideo(); break;
                }
        }
            

        protected void Video_Click(Object sender, System.EventArgs e)
        {
            System.Windows.Forms.MenuItem menu = (System.Windows.Forms.MenuItem)sender;
            

            if (menu.Text == "None")
            {
                chromeBrowser.LoadHtml("<html><body>Hello world</body></html>");
            }
            else
            {
                // try to find the video they clicked on 
                foreach (Video v in Videos)
                {
                   if (v.Description == menu.Text)
                    {
                        String YouTubeURL = "https://www.youtube.com/embed/" + v.VideoID;
                        String Params = "?rel=0;&autoplay=1&mute=1";
                        chromeBrowser.Load(YouTubeURL + Params);
                        break;
                    }
                }

                // execution should never reach here!!
               
            }
        }

        protected void About_Click(Object sender, System.EventArgs e)
        {
            Form f = new About();
            f.Show();
        }

        protected void Help_Click(Object sender, System.EventArgs e)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "help.txt";
            Process.Start("notepad.exe", directory + FileName);
        }

        protected void Config_Click(Object sender, System.EventArgs e)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "VanGoghFlow.ini";
            Process.Start("notepad.exe", directory + FileName);
        }

        protected void Exit_Click(Object sender, System.EventArgs e)
        {
            Close();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
         
        }

        // just create an instance of ChromiumWebBrowser and set it to fill up the whole screen
        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            chromeBrowser = new ChromiumWebBrowser("");
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
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

        private void OverlayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Icon = null;
        }

        private void OverlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Icon = null;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Cleanup so that the icon will be removed when the application is closed
            notifyIcon1.Visible = false;
        }
    }
}