using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.Runtime.InteropServices;
namespace Loginform1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int cButtons, int dwExtrainfo);
        private const int MOUSEEVENT_LEFTDOWN = 0x02;
        private const int MOUSEEVENT_LEFTUP = 0x04;

        int counter=0;
        int b1=0;
        int num=1;
        int j=0;
        int k=260;
        int deadcount=0;
        int shotmode=0;
        int soundcount=0;
        int speedcount=0;
        int maxbullit = 0;
        int bullit = 40;
        int deadnum = 0;
        
        
        Control[] BTN = new Control[4];
        Control[] BTNstop = new Control[4];


        WindowsMediaPlayer player = new WindowsMediaPlayer();
        WindowsMediaPlayer player2 = new WindowsMediaPlayer();
        WindowsMediaPlayer player3 = new WindowsMediaPlayer();
        WindowsMediaPlayer player4 = new WindowsMediaPlayer();
        WindowsMediaPlayer player5 = new WindowsMediaPlayer();
        WindowsMediaPlayer player6 = new WindowsMediaPlayer();
        WindowsMediaPlayer player7 = new WindowsMediaPlayer();
        WindowsMediaPlayer player8 = new WindowsMediaPlayer();
        WindowsMediaPlayer player9 = new WindowsMediaPlayer();
        WindowsMediaPlayer player10 = new WindowsMediaPlayer();
        WindowsMediaPlayer player11 = new WindowsMediaPlayer();
        WindowsMediaPlayer player1 = new WindowsMediaPlayer();
        WindowsMediaPlayer player12 = new WindowsMediaPlayer();
        WindowsMediaPlayer player13 = new WindowsMediaPlayer();
        WindowsMediaPlayer player14 = new WindowsMediaPlayer();
        WindowsMediaPlayer player15 = new WindowsMediaPlayer();
       
        public Form1()
        {
            InitializeComponent();    
        }

        private void btt_Down(object sender, MouseEventArgs e)
        {
            Control ctl = sender as Control;
            Random r = new Random();


            b1++;
            if (0 == b1%4)
            {
                ctl.Dispose();
                if (r.Next(1, 3) == 1) 
                    k = 260;
                else
                    k=700;
                start_Click(sender, e);
                deadcount = deadcount +15;
                deadnum++;
                label2.Text = deadcount.ToString();

            }
        }
        private void btt_Down1(object sender, MouseEventArgs e)
        {
            Control ctl = sender as Control;
            Random r = new Random();


            b1++;
            if (0 == b1 % 4)
            {
                ctl.Dispose();
                deadcount = deadcount +9;
                deadnum++;
                label2.Text = deadcount.ToString();

                start_Click1(sender, e);
            }
        }

        private void start_Click2(object sender, EventArgs e)
        {
            start.Hide();

            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();

            modebtt.Show();
            exutbtt.Show();

        }
        private void start_Click(object sender,EventArgs e)
        {
            int i;
            Random a = new Random();
            Random r = new Random();
            Random si = new Random();
           // Img.Load("snake.jpg");
            //Img.SizeMode = PictureBoxSizeMode.StretchImage;
            
            i=a.Next(1,4);
            while (num == i)
            {

                i = a.Next(1, 4);
            }
            num = i;
            j=r.Next(1, 5);

            BTN[i] = new Button();
            BTN[i].Name = i.ToString();
            BTN[i].Parent = this;
            BTN[i].Size = new Size(si.Next(2,3)*10, si.Next(2,5)*10);
            BTN[i].Tag = i.ToString();
            BTN[i].MouseDown += new MouseEventHandler(Form1_MouseDown1);
            BTN[i].MouseDown += new MouseEventHandler(btt_Down);
            BTN[i].MouseUp += new MouseEventHandler(Form1_MouseUp);
            BTN[i].BackgroundImage = Image.FromFile(@"aim.png");
            BTN[i].BackgroundImageLayout = ImageLayout.Stretch;
           
                if (i == 1)
                {
                    timer1.Start();
                    timer1.Interval = 55;
                }
                else if (i == 2)
                {
                    timer2.Start();
                    timer2.Interval = 60;

                }
                else if (i == 3)
                {
                    timer3.Start();
                    timer3.Interval = 50;
                }
           }
        private void start_Click1(object sender, EventArgs e)
        {
            int i;
            Random a = new Random();
            Random si = new Random();

            i = a.Next(1, 4);
            while (num == i)
            {

                i = a.Next(1, 4);
            }

            BTNstop[i] = new Button();
            BTNstop[i].Name = i.ToString();
            BTNstop[i].Parent = this;
            BTNstop[i].Size = new Size(si.Next(2, 3) * 10, si.Next(2, 5) * 10);
            BTNstop[i].Tag = i.ToString();
            BTNstop[i].MouseDown += new MouseEventHandler(Form1_MouseDown1);
            BTNstop[i].MouseDown += new MouseEventHandler(btt_Down1);
            BTNstop[i].MouseUp += new MouseEventHandler(Form1_MouseUp);
            BTNstop[i].BackgroundImage = Image.FromFile(@"aim.png");
            BTNstop[i].BackgroundImageLayout = ImageLayout.Stretch;
            BTNstop[i].Location = new Point(50+200*i,350);
        }


        private void Form1_Load1(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            modebtt.Hide();
            exutbtt.Hide();
            label10.Hide();
            label8.Hide();
            restatrbtt.Hide();
            button2.Hide();
            label6.Hide();
            deadcountlb.Hide();
            deadnumlb.Hide();

        }     

        private void Form1_Load(object sender, EventArgs e)
        {
        
            player.URL = "m4.wav";
            player2.URL = "m4.wav";
            player3.URL = "m4.wav";
            player4.URL = "m4.wav";
            player5.URL = "m4.wav";
            player6.URL = "m4.wav";
            player1.URL = "battle.wav";
            player7.URL = "m4.wav";
            player8.URL = "m4.wav";
            player9.URL = "m4.wav";
            player10.URL = "m4.wav";
            player11.URL = "relaod.wav";
            player12.URL = "m4.wav";
            player13.URL = "m4.wav";
            player14.URL = "m4.wav";
            player15.URL = "m4.wav";
            
            player.controls.stop();
            player2.controls.stop();
            player3.controls.stop();
            player4.controls.stop();
            player5.controls.stop();
            player6.controls.stop();
            player7.controls.stop();
            player8.controls.stop();
            player9.controls.stop();
            player10.controls.stop();
            player11.controls.stop();
            player12.controls.stop();
            player13.controls.stop();
            player14.controls.stop();
            player15.controls.stop();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            BTN[1].Location = new Point(k, j * 50 + 350);

            if (k == 700)
                counter = 1;
            else if (k == 260)
                counter = 0;
            if (counter == 0)
                k = k + 2;
            else if (counter == 1)
                k = k - 2;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            BTN[2].Location = new Point(k, j * 50 + 350);

            if (k == 700)
                counter = 1;
            else if (k == 260)
                counter = 0;
            if (counter == 0)
                k = k + 2;
            else if (counter == 1)
                k = k - 2;
            }

        private void timer3_Tick(object sender, EventArgs e)
        {
            BTN[3].Location = new Point(k, j*50+350);

            if (k == 700)
                counter = 1;
            else if (k == 260)
                counter = 0;
            if (counter == 0)
                k = k + 2;
            else if (counter == 1)
                k = k - 2;
        }

        private void Form1_MouseDown1(object sender, MouseEventArgs e1)
        {
           
            Random a = new Random();
            Random b = new Random();
            
            bullit = bullit - 1;
            maxbullit++;
            label4.Text = maxbullit.ToString();
            if (bullit == 0)
            {
                player11.controls.play();
                bullit = 40;
            }
            label3.Text = bullit.ToString();


                if (soundcount % 14 == 0)
                    player.controls.play();
                else if (soundcount % 14 == 1)
                    player2.controls.play();
                else if (soundcount % 14 == 2)
                    player3.controls.play();
                else if (soundcount % 14 == 3)
                    player4.controls.play();
                else if (soundcount % 14 == 4)
                    player5.controls.play();
                else if (soundcount % 14 == 5)
                    player6.controls.play();
                else if (soundcount % 14 == 6)
                    player7.controls.play();
                else if (soundcount % 14 == 7)
                    player8.controls.play();
                else if (soundcount % 14 == 8)
                    player12.controls.play();
                else if (soundcount % 14 == 9)
                    player13.controls.play();
                else if (soundcount % 14 == 10)
                    player14.controls.play();
                else if (soundcount % 14 == 11)
                    player15.controls.play();
                else if (soundcount % 14 == 12)
                    player9.controls.play();
                else if (soundcount % 14 == 13)
                {
                    player10.controls.play();
                    soundcount = 0;
                }

            soundcount++;                 

            Cursor.Position = new Point(Cursor.Position.X + a.Next(-5, 5), Cursor.Position.Y - 60 + a.Next(-5, 5));
            System.Threading.Thread.Sleep(30);
            Cursor.Position = new Point(Cursor.Position.X + b.Next(-5, 5), Cursor.Position.Y + 30 + b.Next(-5, 5));
            
                if (shotmode == 1 && speedcount == 0)
                {
                    timer4.Interval = 35;
                    timer4.Start();
                }    
        }

        private void timer4_Tick(object sender,EventArgs e)
        {
            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);
            mouse_event(MOUSEEVENT_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            mouse_event(MOUSEEVENT_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);

            label3.Text = bullit.ToString();
            speedcount = 1;
            

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e1)
        {
            if (shotmode == 1)
            {
                speedcount = 0;
                timer4.Stop();
            }
        }


        private void modebtt_Click(object sender, EventArgs e)
        {
            if (shotmode == 1)
            {
                shotmode = 0;
                modebtt.Text = "단발";
            }
            else if (shotmode == 0)
            {
                shotmode = 1;
                modebtt.Text = "연사";
            }
        }

        private void exutbtt_Click(object sender, EventArgs e)
        {
            player1.controls.stop();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            exutbtt.Hide();
            modebtt.Hide();

            deadcountlb.Text = deadcount.ToString();
            deadnumlb.Text = (deadcount * 4 * deadnum / maxbullit).ToString();
            label8.Show();
            label10.Show();
            deadcountlb.Show();
            deadnumlb.Show();
            label6.Show();
            restatrbtt.Show();
            button2.Show();
        }

        private void restatrbtt_Click(object sender, EventArgs e)
        {
            deadcount = 0;
            deadnum = 0;
            bullit = 40;
            maxbullit = 0;

            for (int i = 0; i < 4; i++)
            {
                if (BTN[i] != null)
                {
                    BTN[i].Dispose();
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (BTNstop[i] != null)
                {
                    BTNstop[i].Dispose();
                }
            }

            Form1_Load1(sender, e);
            label2.Text = deadcount.ToString();
            label3.Text = bullit.ToString();
            label4.Text = maxbullit.ToString();
            start_Click(sender, e);
            start_Click1(sender, e);
            start_Click2(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
