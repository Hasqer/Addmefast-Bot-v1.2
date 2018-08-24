using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace addmefast
{
    public partial class Form2 : Form
    {
        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public static void SesAyarla(int volume)
        {
            int NewVolume = ((ushort.MaxValue / 10) * volume);
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }
        
        public Form2()
        {
            InitializeComponent();
        }
        public WebBrowser Browser
        {
            get { return webBrowser1; }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            timer1.Interval = Form1.abone_ol_hizi;
            timer1.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            SesAyarla(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            foreach (HtmlElement btn in webBrowser1.Document.GetElementsByTagName("button"))
            {
                if (btn.GetAttribute("className") == "yt-uix-button yt-uix-button-size-default yt-uix-button-subscribe-branded yt-uix-button-has-icon no-icon-markup yt-uix-subscription-button yt-can-buffer")
                {
                    btn.InvokeMember("Click");
                    break;
                }
            }
            this.Hide();
            timer1.Stop();
            timer2.Interval = Form1.popup_kapatma_hizi;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            timer2.Stop();
        }
    }
}
