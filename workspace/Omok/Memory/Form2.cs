using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Memory
{
    public partial class Form2 : Form
    {
        int stonesize = 18;
        int psize = 20;
        Pen pen;
        
        SoundPlayer sp = new SoundPlayer();
 
        bool turn = false;
        enum STONE { none, black, white };
        STONE[,] ground = new STONE[19, 19];
        

        public Form2()
        {
            InitializeComponent();
            pen = new Pen(Color.Black);
            sp.SoundLocation = "../../bgm.wav";
            sp.PlayLooping();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            drawground();
        }

        public void drawground()
        {
            Graphics g = panel1.CreateGraphics();
            for (int x = 0; x < 19; x++)
                g.DrawLine(pen, 10, 10 + x * psize, 370, 10 + x * psize);
            for (int x = 0; x < 19; x++)
                g.DrawLine(pen, 10 + x * psize, 10, 10 + x * psize, 10 + 18 * psize);
        }

        public void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            int x, y;
            x = e.X / psize;
            y = e.Y / psize;
            if (x < 0 || x >= 19 || y < 0 || y >= 19)
                return;
            drawstone(x, y);
        }

        public void drawstone(int x, int y)
        {
            Graphics g = panel1.CreateGraphics();

            if (ground[x, y] == STONE.black || ground[x, y] == STONE.white)
                return;

            Rectangle r = new Rectangle(10 + psize * x - stonesize / 2, 10 + psize * y - stonesize / 2, stonesize, stonesize);
            
            if (turn == false)
            {
                Bitmap bmp = new Bitmap("../../7-1_burned.png");
                g.DrawImage(bmp, r);
                ground[x, y] = STONE.black;
            }
            else
            {
                Bitmap bmp = new Bitmap("../../5-1_burned.png");
                g.DrawImage(bmp, r);
                ground[x, y] = STONE.white;
            }
            turn = !turn;
            checkOmok(x, y);
        }

        public void checkOmok(int x, int y)
        {
            if (checkLR(x, y) >= 5)
                MessageBox.Show("finish");
            if (checkUD(x, y) >= 5)
                MessageBox.Show("finish");
            if (checkSLASH(x, y) >= 5)
                MessageBox.Show("finish");
            if (checkBACKSLASH(x, y) >= 5)
                MessageBox.Show("finish");
        }

        public int checkLR(int x, int y)
        {
            int cnt = 1;
            for (int i = 1; i < 5; i++)
                if (x + i <= 18 && ground[x + i, y] == ground[x, y])
                    cnt++;
                else
                    break;
            for (int i = 1; i < 5; i++)
                if (x - i >= 0 && ground[x - i, y] == ground[x, y])
                    cnt++;
                else
                    break;
            return cnt;
        }

        private int checkUD(int x, int y)
        {
            int cnt = 1;
            for (int i = 1; i < 5; i++)
                if (i + y <= 18 && ground[x, y + i] == ground[x, y])
                    cnt++;
                else
                    break;
            for (int i = 1; i < 5; i++)
                if (y - i >= 0 && ground[x, y - i] == ground[x, y])
                    cnt++;
                else
                    break;
            return cnt;
        }

        private int checkBACKSLASH(int x, int y)
        {
            int cnt = 1;
            for (int i = 1; i < 5; i++)
                if (x - i >= 0 && y - i >= 0 && ground[x - i, y - i] == ground[x, y])
                    cnt++;
                else
                    break;
            for (int i = 1; i < 5; i++)
                if (x + i <= 18 && y + i <= 18 && ground[x + i, y + i] == ground[x, y])
                    cnt++;
                else
                    break;
            return cnt;
        }

        private int checkSLASH(int x, int y)
        {
            int cnt = 1;
            for (int i = 1; i < 5; i++)
                if (x + i <= 18 && y - i >= 0 && ground[x + i, y - i] == ground[x, y])
                    cnt++;
                else
                    break;
            for (int i = 1; i < 5; i++)
                if (x - i >= 0 && y + i <= 18 && ground[x - i, y + i] == ground[x, y])
                    cnt++;
                else
                    break;
            return cnt;
        }
    }
}
