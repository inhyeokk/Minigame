using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Snake
{
    public partial class frmMain : Form
    {
        private int direction = 0;
        private int score = 1;
        private int stage = 1;
        private int timeCnt = 0;
        private Timer gameLoop = new Timer();
        private Timer musicSeeker = new Timer();
        private Random rand = new Random();
        private Graphics graphics;
        private Snake snake;
        private Food food;
        private SpecialFood sFood;
        private int keyOn;

        WindowsMediaPlayer player = new WindowsMediaPlayer();
        WindowsMediaPlayer player1 = new WindowsMediaPlayer();
        // 3개이상일때 키 두개 같이 입력되면 죽음 키 중복입력 막아야함
        // 해결했지만 게임 재미가 없어져서 취소
        public frmMain()
        {
            InitializeComponent();
            Init();

            snake = new Snake();
            food = new Food(rand);
            sFood = new SpecialFood();
            gameLoop.Interval = 75;
            gameLoop.Tick += Update;
            musicSeeker.Interval = 1000;
            musicSeeker.Tick += CntTime;
            player.URL = "snake.mp3";
            player.controls.stop();
            player1.URL = "Eat.mp3";
            player1.controls.stop();
            keyOn = 0;
        }

        private void Init()
        {
            Img.Load("snake.jpg");
            Img.SizeMode = PictureBoxSizeMode.StretchImage;
            deadImg.Load("deadsnake.jpg");
            deadImg.SizeMode = PictureBoxSizeMode.StretchImage;
            orPanel.Visible = false;
            backBtn.Enabled = false;
            replayBtn.Enabled = false;
            stopBtn.Enabled = false;
            normal_Btn.Enabled = true;
            helpBtn.Enabled = true;
            mainPanel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            normal_Btn.Enabled = false;
            helpBtn.Enabled = false;
            mainPanel.Visible = false;
            gameLoop.Start();
            musicSeeker.Start();
            player.controls.play();
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" 방향키를 이용해서 조작합니다.\n\n 게임설명: 빨간먹이를 1개먹으면 뱀이 성장하고 5개를 먹으면 노란먹이가 나타납니다. 노란먹이를 먹으면 단계가 올라갑니다.");
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyOn == 0)
            {
                switch (e.KeyData)
                {
                    case Keys.Right:
                        if (direction != 2)
                            direction = 0;
                        //keyOn = 1;
                        break;
                    case Keys.Down:
                        if (direction != 3)
                            direction = 1;
                        //keyOn = 1;
                        break;
                    case Keys.Left:
                        if (direction != 0)
                            direction = 2;
                        //keyOn = 1;
                        break;
                    case Keys.Up:
                        if (direction != 1)
                            direction = 3;
                        //keyOn = 1;
                        break;
                }
            }
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            snake.Draw(graphics);
            food.Draw(graphics);
            sFood.Draw(graphics);
        }

        private void CntTime(object sender, EventArgs e)
        {
            timeCnt += 1;
        }

        private void Update(object sender, EventArgs e)
        {
            this.Text = string.Format("Snake - 점수: {0} {1}단계", score, stage);
            snake.Move(direction);
            if (timeCnt == 83)
            {
                player.controls.stop();
                player.controls.play();
                timeCnt = 0;
            }
            for (int i = 1; i < snake.Body.Length; i++)
            {
                if (snake.Body[0].IntersectsWith(snake.Body[i]))
                    Restart();
            }
            //if (snake.Body[0].X < 0 || snake.Body[0].X > 290)
            //Restart();
            if (snake.Body[0].X <= 0)
                snake.Body[0].X += 300;
            if (snake.Body[0].X >= 300)
                snake.Body[0].X -= 300;
            //if (snake.Body[0].Y < 0 || snake.Body[0].Y > 190)
            //Restart();
            if (snake.Body[0].Y <= 0)
                snake.Body[0].Y += 200;
            if (snake.Body[0].Y >= 200)
                snake.Body[0].Y -= 200;
            if (snake.Body[0].IntersectsWith(food.Piece))
            {
                player1.controls.stop();
                score += 1;
                snake.Grow();
                player1.controls.play();
                if (score % 5 != 0)
                {
                    food.Generate(rand);
                    sFood.Fix();
                }
                else
                {
                    food.Fix();
                    sFood.Generate(rand);
                }
            }
            if (snake.Body[0].IntersectsWith(sFood.Piece))
            {
                player1.controls.stop();
                score += 1;
                player1.controls.play();
                if (stage < 6)
                {
                    gameLoop.Interval -= 10;
                    stage += 1;
                }
                else
                {
                    gameLoop.Interval -= 1;
                    stage += 1;
                }
                snake.Grow();
                food.Generate(rand);
                sFood.Fix();
            }

            this.Invalidate();
        }

        private void Restart()
        {
            lbScore.Text = "점수: " + score + "\n단계: " + stage + "\n분발하세요~";
            gameLoop.Stop();
            musicSeeker.Stop();
            graphics.Clear(SystemColors.Control);
            snake = new Snake();
            food = new Food(rand);
            sFood = new SpecialFood();
            gameLoop.Interval = 75;
            timeCnt = 0;
            direction = 0;
            score = 1;
            stage = 1;
            player.controls.stop();
            player1.controls.stop();
            orPanel.Visible = true;
            backBtn.Enabled = true;
            replayBtn.Enabled = true;
            stopBtn.Enabled = true;
        }


        private void frmNormal_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Right:
                    keyOn = 0;
                    break;
                case Keys.Down:
                    keyOn = 0;
                    break;
                case Keys.Left:
                    keyOn = 0;
                    break;
                case Keys.Up:
                    keyOn = 0;
                    break;
            }
        }

        private void replayBtn_Click(object sender, EventArgs e)
        {
            orPanel.Visible = false;
            backBtn.Enabled = false;
            replayBtn.Enabled = false;
            stopBtn.Enabled = false;
            gameLoop.Start();
            musicSeeker.Start();
            player.controls.play();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            orPanel.Visible = false;
            backBtn.Enabled = false;
            replayBtn.Enabled = false;
            stopBtn.Enabled = false;
            normal_Btn.Enabled = true;
            helpBtn.Enabled = true;
            mainPanel.Visible = true;
            this.Text = "Snake";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            orPanel.Visible = false;
            backBtn.Enabled = false;
            replayBtn.Enabled = false;
            stopBtn.Enabled = false;
            this.Hide();
            frmSelect fN = new frmSelect();
            fN.ShowDialog();
            this.Close();
        }
    }
}
