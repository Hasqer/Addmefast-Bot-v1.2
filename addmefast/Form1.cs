using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
namespace addmefast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        SHDocVw.WebBrowser nativeBrowser;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            nativeBrowser = (SHDocVw.WebBrowser)webBrowser1.ActiveXInstance;
            nativeBrowser.NewWindow2 += nativeBrowser_NewWindow2;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            nativeBrowser.NewWindow2 -= nativeBrowser_NewWindow2;
            base.OnFormClosing(e);
        }

        void nativeBrowser_NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            Form2 popup = new Form2();
            popup.Show(this);
            ppDisp = popup.Browser.ActiveXInstance;
        }

      


        private void button1_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://addmefast.com");
            try
            {
                

            
                giris = true;
                timer3.Start();

            }
            catch (Exception)
            {

                giris = false;
                webBrowser1.Navigate("http://addmefast.com/?lang=tr");
                MessageBox.Show("Bir Sorun Oluştu");
                timer5.Start();
               
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://addmefast.com/free_points/youtube_subscribe");
        }
        //-----------
        public static int abone_ol_hizi;
        public static int popup_kapatma_hizi;


        static double bar_hizi;
        static int tekrar_hizi;

        //--------------------

        private void button3_Click(object sender, EventArgs e)
        {
            
            pictureBox1.Visible = true;

            if (radioButton1.Checked == true)
            {
                tekrar_hizi = 5000;
                bar_hizi = ((tekrar_hizi / 1000) / 100);
                abone_ol_hizi = 700;
                popup_kapatma_hizi = 100;
               
              
            }
            else if (radioButton2.Checked == true)
            {
                tekrar_hizi = 8000;
                bar_hizi = ((tekrar_hizi / 1000) / 100);
                abone_ol_hizi = 1000;
                popup_kapatma_hizi = 100;
             
            }
            else if(radioButton3.Checked == true)
            {
                tekrar_hizi = 10000;
                bar_hizi = ((tekrar_hizi / 1000) / 100);
                abone_ol_hizi = 1500;
                popup_kapatma_hizi = 500;
               

            }
            else if(radioButton4.Checked == true)
            {
                tekrar_hizi = 15000;
                bar_hizi = ((tekrar_hizi / 1000) / 100);
                abone_ol_hizi = 3000;
                popup_kapatma_hizi = 1000;
              

            }
            else if (radioButton5.Checked == true)
            {
                tekrar_hizi = 20000;
                bar_hizi = ((tekrar_hizi / 1000) / 100);
                abone_ol_hizi = 5000;
                popup_kapatma_hizi = 3000;
            }


            timer2.Interval = tekrar_hizi;
    



            timer2.Start();
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        
          
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 asa = new Form2();
            asa.Close();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Visible = false;
           



        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://addmefast.com/login/incorrect");
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            
        }
        bool giris = false;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            if (giris == true)
            {
                webBrowser1.Navigate("http://addmefast.com/free_points/youtube_subscribe");
                giris = false;
                foreach (HtmlElement btn in webBrowser1.Document.GetElementsByTagName("span"))
                {
                    if (btn.GetAttribute("className") == "points_count")
                    {
                        label1.Text = btn.OuterText;
                        break;
                    }
                }
            }
           
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (HtmlElement btn in webBrowser1.Document.GetElementsByTagName("a"))
            {
                if (btn.GetAttribute("className") == "single_like_button btn3-wrap")
                {
                    btn.InvokeMember("Click");
                    break;
                }
            }
         
          
            if (tekrar < 1)
            {
                tekrar++;
            }
            else
            {
                webBrowser1.Navigate("http://addmefast.com/free_points/youtube_subscribe");
                timer2.Stop();
                timer4.Start();
            }
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            timer2.Stop();
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
         

            if (int.Parse(webBrowser1.DocumentText.IndexOf("Welcome!").ToString()) > 0)
            {

                button5.Enabled = true;
                button6.Visible = false;
                button5.Visible = true;
                timer3.Stop();

            }
           

           

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;

         
        }
        int tekrar=0;
        private void timer4_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            tekrar = 0;
            timer4.Stop();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void webBrowser6_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                foreach (HtmlElement btn in webBrowser1.Document.GetElementsByTagName("span"))
                {
                    if (btn.GetAttribute("className") == "points_count")
                    {
                        label1.Text = btn.OuterText;
                        break;
                    }
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void webBrowser8_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                foreach (HtmlElement btn in webBrowser1.Document.GetElementsByTagName("span"))
                {
                    if (btn.GetAttribute("className") == "points_count")
                    {
                        label1.Text = btn.OuterText;
                        break;
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                foreach (HtmlElement btn in webBrowser1.Document.GetElementsByTagName("span"))
                {
                    if (btn.GetAttribute("className") == "points_count")
                    {
                        label1.Text = btn.OuterText;
                        break;
                    }
                }
            }
            catch (Exception)
            {


            }
        }
        int engel = 0;
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (engel==5)
            {
                timer5.Stop();
                button3.Enabled = true;
            }
            else
            {
                engel++;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://addmefast.com/?lang=tr");
          
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            foreach (HtmlElement btn in webBrowser1.Document.GetElementsByTagName("span"))
            {
                if (btn.GetAttribute("className") == "points_count")
                {
                    label1.Text = btn.OuterText;
                    break;
                }
            }
        }
    }
}
