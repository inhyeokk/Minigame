using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;


// 나중에 쓸지도 모르는 아이디어
// 1. 갈라지는 총알. 3등분(대각선), 5등분(좌좌상 좌좌하 이런식)
// 2. 보스 : 블락 다 사라지고 보스 튀어나와서 이동하면서 쏴대고 그런거
// 3. 스킬들 각각에 스프라이트 효과 넣기. 
// 4. 레벨에 따른 난이도 상승
// 5. 적 총알 변경

namespace _Game
{
    public partial class MyForm : Form
    {
        PanInfo pan = new PanInfo();
        Random random = new Random();
        static int randNum;
        int idleCounter;
        bool over;
        int tmpNumber;

        Me me;
        int borderSize;
        int borderSizePlus;
        static int meHp;
        static int meHpStep;
        static int meMp;
        static int meMpStep;
        static int mpCounter;

        static bool bSuperBody;
        static int superBodyCounter;
        static bool bKnifeField;
        static int knifeFieldCounter;
        static bool bKeyDownNow;
        static int keyDownCounter;
        static int knifeSizeX;
        static int knifeSizeY;
        static int knifeSpeed;
        static int ultimate;
        static int bulletTypeSave;
        static int bulletSpeedSave;
        static bool bUltState;
        static bool bADown;
        static int bACounter;
        static int bACoolDown;

        static int perMoveDistance;
        static int perJumpDistanceDef;
        static int perJumpDistance;
        static bool bUpDisabled;
        static int bDown;

        static int blockSize;

        static int itemSize;
        static int itemPercent;
        static int score;

        static int bulletSize;
        static int bulletSpeed;
        static int bulletType;

        static int monSize;
        static int monPercent;
        static int monType;

        static Block sendToMapTimer;
        static int blockMakeTimerCnt;
        static int floorDeadCnt;

        static int timeEllapse;

        static int percentTwo;
        static int percentEight;


        List<Block> blockList;
        List<Item> itemList;
        List<Bullet> bulletList;
        List<Bullet> enemyBulletList;
        List<Bullet> knifeList;
        List<Mon> monList;

        PictureBox floor = new PictureBox();
        PictureBox background = new PictureBox();
        PictureBox tmpBackGround = new PictureBox();



        static MapInfo map;
        static MapHeight mapHeight;


        TextBox IdBox;
        TextBox LvBox;
        TextBox ScoreBox;


        delegate int Del(int a, int b);


        public MyForm()
        {
            // 기본
            InitializeComponent();
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
            idleCounter = 0;

            percentTwo = 2;
            percentEight = 8;
            tmpNumber = 0;

            textBox1.Text = "0";
            textBox2.Text = "0";

            // 판
            pan.panLocPt = new Point(Pan.Location.X, Pan.Location.Y);
            pan.panSizePt = new Point(Pan.Width, Pan.Height);

            // 나
            me = new Me(pan);
            borderSize = 5;    // 기본 보더
            borderSizePlus = borderSize + 3;  // 확장 보더(끝부분 잔상 제거용)
            meHp = 100;  // 기본 hp
            meHpStep = 10;  // 깎이는 스텝
            _hpBar.Value = 100;
            meMp = 100;
            meMpStep = 10;
            _mpBar.Value = 0;
            mpCounter = 0;
            over = false;  // 게임 끝

            // 각종 스킬
            bSuperBody = false;
            superBodyCounter = 0;
            bKnifeField = false;
            knifeFieldCounter = 0;
            bKeyDownNow = false;
            keyDownCounter = 0;
            knifeSizeX = 15;
            knifeSizeY = 40;
            knifeSpeed = 30;
            ultimate = 0;
            bulletTypeSave = 0;
            bulletSpeedSave = 0;
            bUltState = false;
            bADown = false;
            bACounter = 0;
            bACoolDown = 0;

            // 점프 관련
            perJumpDistanceDef = 5;  // 5 or 8 이 적당. 웬만하면 조정 x .  최소단위 이동거리
                                     // 점프용인데 좌우랑 공유해놨음. 굳이 필요하면 따로 변수만들어 설정가능
            perJumpDistance = perJumpDistanceDef;
            perMoveDistance = 5;
            bUpDisabled = false;  // 점프 중 추가 up 입력 불가
            bDown = 0;
            jumpTimer.Stop();  // 처음엔 스탑.

            
            // 오브젝트
            blockSize = 30;  // 기본 블럭 사이즈. 조정 ㄴ

            itemSize = 20;  // 아이템 사이즈
            score = 0;  // 아이템먹었을때랑 몹한테 맞았을때랑 공유. 설정은 각 모듈에서
            itemPercent = 50;  // 생성 확률
            //itemNumber = 0;

            bulletSize = 10;   // 총알 크기
            bulletSpeed = 20;   // 총알 속도

            monSize = 30;   // 몹 크기
            monPercent = 30;  // 몹 출현 확률
            monType = 0;


            // 타이머
            sendToMapTimer = null;
            blockMakeTimerCnt = -1;  // 맵 제작용 카운터
            floorDeadCnt = 0; //바닥 사망 활성화 카운터

            
            // 리스트
            blockList = new List<Block>();
            itemList = new List<Item>();
            bulletList = new List<Bullet>();
            enemyBulletList = new List<Bullet>();
            knifeList = new List<Bullet>();
            monList = new List<Mon>();

            // 픽쳐 박스
            floor = new PictureBox();
            floor.Image = Properties.Resources.magma;
            floor.Width = blockSize;
            floor.Height = blockSize;
            Pan.Invalidate();

            background = new PictureBox();
            background.Image = Properties.Resources.jungle;
            background.Width = pan.panSizePt.X;
            background.Height = pan.panSizePt.Y;
            Pan.BackgroundImage = background.Image;

            tmpBackGround = new PictureBox();


            // 맵
            map = new MapInfo();
            mapHeight = new MapHeight();

            timeEllapse = 0;


            // 바닥에 깔린 블락
            for (int x = 0; x < 26; x++)
            {
                blockList.Add(new Block(new Rectangle(x * blockSize, pan.panSizePt.Y - blockSize, blockSize, blockSize), 1));
            }
        }

        // 플리커 방지
        internal static class NativeWinAPI
        {
            internal static readonly int GWL_EXSTYLE = -20;
            internal static readonly int WS_EX_COMPOSITED = 0x02000000;

            [DllImport("user32")]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }


        public static int MovePlus(int a, int b)
        {
            return a += b;
        }
        public static int MoveMinus(int a, int b)
        {
            return a -= b;
        }




        class PanInfo   // 판 기본 정보
        {
            public Point panLocPt;
            public Point panSizePt;
        }


        interface iMove
        {
            void Move(String dir);
        }



        class GameObject  // 모든 오브젝트 공유
        {
            public Point pt;  // 위치 (나빼곤 좌측상단)
            public PictureBox image;  
            public Point size;
            public int type;  // 타입
            public int dir;  // 보는 방향


            public GameObject()
            {
                image = new PictureBox();
            }
            public virtual Rectangle Rect() // 왼쪽위 X, 왼쪽위 Y, width, height
            {
                return new Rectangle(pt.X, pt.Y, size.X, size.Y);
            }
            public virtual Rectangle Rect(int borderSizePlus) // 왼쪽위 X, 왼쪽위 Y, width, height
            {                                     // borderSizePlus = 여유분    
                return new Rectangle(pt.X - borderSizePlus, pt.Y - borderSizePlus, size.X + borderSizePlus * 2, size.Y + borderSizePlus * 2);
            }
            public Point CenterPt()
            {
                return new Point(pt.X + size.X / 2, pt.Y + size.Y / 2);
            }



        }



        class Me : GameObject, iMove  // 나
        {

            private int r;  // 반지름
            private Point startLoc;  // 시작 위치

            public int seeDir;  // 보는 방향
            public int imagePlus;   // 이미지크기 가중치
            public int lv;
            public PictureBox cut;

            Del Plus = new Del(MovePlus);
            Del Minus = new Del(MoveMinus);

            public Me(PanInfo pan)
            {
                imagePlus = 5;
                r = 10 + imagePlus;
                startLoc = new Point(100, -blockSize - r*2);  //  Y : 바닥크기만큼 빼고 거기서 더 빼면 더 올라감
                pt = new Point(pan.panLocPt.X + r + startLoc.X, pan.panSizePt.Y - r + startLoc.Y);   // 초기 pt

                seeDir = 1;   // 0왼쪽 1오른쪽
                lv = 1;
                image.Image = Properties.Resources.purin;

                image.Width = Rect().Width + imagePlus;
                image.Height = Rect().Height + imagePlus;

                cut = new PictureBox();
                cut.Image = Properties.Resources.cut;         
                cut.Width = 50;
                cut.Height = 50;
            }
            public override Rectangle Rect()
            {                                               
                return new Rectangle(pt.X - r, pt.Y - r, r * 2, r * 2);
            }
            public override Rectangle Rect(int borderSizePlus)
            { 
                return new Rectangle(pt.X - r - borderSizePlus, pt.Y - r - borderSizePlus, r * 2 + borderSizePlus * 2, r * 2 + borderSizePlus * 2);
            }
            public Rectangle RectY(int y)
            {
                return new Rectangle(pt.X - r, pt.Y - r + y, r * 2, r * 2);
            }
            public Rectangle CutRect()  // 근접공격용 사각형
            {
                if (seeDir == 1)
                {
                    cut.Image = Properties.Resources.cut;
                    cut.Width = 50;
                    cut.Height = 50;
                    return new Rectangle(pt.X + r, pt.Y - (cut.Height / 2), cut.Width, cut.Height);
                }
                else
                {
                    cut.Image = Properties.Resources.cut1;
                    cut.Width = 50;
                    cut.Height = 50;
                    return new Rectangle(pt.X - r - cut.Width, pt.Y - (cut.Height / 2), cut.Width, cut.Height);
                }
            }
            public Rectangle CutRect(int borderSizePlus)
            {
                if (seeDir == 1)
                {
                    cut.Image = Properties.Resources.cut;
                    cut.Width = 50;
                    cut.Height = 50;
                    return new Rectangle(pt.X + r - borderSizePlus, pt.Y - (cut.Height / 2) - borderSizePlus, cut.Width + borderSizePlus * 2, cut.Height + borderSizePlus * 2);
                }
                else
                {
                    cut.Image = Properties.Resources.cut1;
                    cut.Width = 50;
                    cut.Height = 50;
                    return new Rectangle(pt.X - r - cut.Width - borderSizePlus, pt.Y - (cut.Height / 2) - borderSizePlus, cut.Width + borderSizePlus * 2, cut.Height + borderSizePlus * 2);
                }
            }

            public void Move(String dir)  // 이동
            {
                switch (dir)
                {
                    case "Left":
                        pt.X = Minus(pt.X, perMoveDistance);
                        seeDir = 0;
                        break;
                    case "Right":
                        pt.X = Plus(pt.X, perMoveDistance);
                        seeDir = 1;
                        break;
                    case "Up":
                        pt.Y = Minus(pt.Y, perMoveDistance);
                        break;
                    case "Down":
                        pt.Y = Plus(pt.Y, perMoveDistance);
                        break;
                }
            }
            
        }


        class Block : GameObject, iMove
        {
            public bool bItem;  // 아이템 위에 있나?
            public bool bMon;   // 몹이 위에 있나?

            Del Plus = new Del(MovePlus);
            Del Minus = new Del(MoveMinus);

            public Block(Rectangle rt, int type)
            {
                pt.X = rt.X;
                pt.Y = rt.Y;
                size.X = rt.Width;
                size.Y = rt.Height;
                this.type = type;
                bItem = false;
                bMon = false;
                dir = 2;
                image.Image = Properties.Resources.tree;
            }


            public void Move(String dir)
            {
                switch (dir)
                {
                    case "Left":
                        pt.X = Minus(pt.X, perMoveDistance);
                        break;
                    case "Right":
                        pt.X = Plus(pt.X, perMoveDistance);
                        break;
                    case "Up":
                        pt.Y = Minus(pt.Y, perMoveDistance);
                        break;
                    case "Down":
                        pt.Y = Plus(pt.Y, perMoveDistance);
                        break;
                }
            
            }
        }


        class Item : GameObject
        {

            public Item(Rectangle rt, int type)
            {
                pt.X = rt.X;
                pt.Y = rt.Y;
                size.X = rt.Width;
                size.Y = rt.Height;
                this.type = type;
                dir = 0;


                if (type == 0)
                {
                    image.Image = Properties.Resources.gold;
                }
                else if (type == 1)
                {
                    image.Image = Properties.Resources.money;
                }
                else if (type == 2)
                {
                    image.Image = Properties.Resources.moneys;
                }
                else if (type == 3)
                {
                    image.Image = Properties.Resources.hp;
                }
                else if (type == 4)
                {
                    image.Image = Properties.Resources.mp;
                }
                image.Width = itemSize;
                image.Height = itemSize;
            }

        }


        class Bullet : GameObject, iMove
        {
            Del Plus = new Del(MovePlus);
            Del Minus = new Del(MoveMinus);

            public Bullet(Rectangle rt, int type)
            {
                pt.X = rt.X;
                pt.Y = rt.Y;
                size.X = rt.Width;
                size.Y = rt.Height;
                this.type = type;
                dir = 1;

                if (type == 0)
                {
                    image.Image = Properties.Resources.bullet1;
                    image.Width = bulletSize;
                    image.Height = bulletSize;
                }
                else if (type == 1)
                {
                    image.Image = Properties.Resources.bullet2;
                    image.Width = bulletSize;
                    image.Height = bulletSize;
                }
                else if (type == 2)
                {
                    image.Image = Properties.Resources.bullet3;
                    image.Width = bulletSize;
                    image.Height = bulletSize;
                }
                else if (type == 3)
                {
                    image.Image = Properties.Resources.bullet4;
                    image.Width = bulletSize;
                    image.Height = bulletSize;
                }
                else if (type == 4)  // 칼
                {
                    image.Image = Properties.Resources.Knife;
                    image.Width = knifeSizeX;
                    image.Height = knifeSizeY;
                }
                else if (type == 5)  // 적 총알
                {
                    image.Image = Properties.Resources.enemyBullet;
                    image.Width = knifeSizeX;
                    image.Height = knifeSizeY;
                }
            }

            public void Move(String dir)
            {
                switch (dir)
                {
                    case "Left":
                        pt.X = Minus(pt.X, perMoveDistance);
                        break;
                    case "Right":
                        pt.X = Plus(pt.X, perMoveDistance);
                        break;
                    case "Up":
                        pt.Y = Minus(pt.Y, perMoveDistance);
                        break;
                    case "Down":
                        pt.Y = Plus(pt.Y, perMoveDistance);
                        break;
                }
            }

        }


        class Mon : GameObject, iMove
        {
            Del Plus = new Del(MovePlus);
            Del Minus = new Del(MoveMinus);

            public Mon(Rectangle rt, int type)
            {
                pt.X = rt.X;
                pt.Y = rt.Y;
                size.X = rt.Width;
                size.Y = rt.Height;
                this.type = type;

                if (type == 0)
                {
                    image.Image = Properties.Resources.snake;
                }
                else if (type == 1)
                {
                    image.Image = Properties.Resources.tank;
                }
                else if (type == 2)
                {
                    image.Image = Properties.Resources.dragon;
                }
                image.Width = monSize;
                image.Height = monSize;

                dir = 0;
            }

            public Rectangle RectXY(int x, int y)
            {
                return new Rectangle(pt.X + x + blockSize, pt.Y + y, size.X, size.Y);
            }

            public void Move(String dir)
            {
                switch (dir)
                {
                    case "Left":
                        pt.X = Minus(pt.X, perMoveDistance);
                        break;
                    case "Right":
                        pt.X = Plus(pt.X, perMoveDistance);
                        break;
                    case "Up":
                        pt.Y = Minus(pt.Y, perMoveDistance);
                        break;
                    case "Down":
                        pt.Y = Plus(pt.Y, perMoveDistance);
                        break;
                }
            }

        }



        // 맵 정보
        class MapInfo
        {
            private const int length = 40;
            int[] info = new int[length]
            {
                0, 3, 5, 8, 10, 12, 15, 19, 21 ,25, 27, 30, 32, 36,
                37, 38, 40, 41, 42, 42 ,44, 47, 49, 52, 53, 53, 55, 55,
                57, 59, 60, 65, 67, 68, 70, 78, 80, 83, 84, 87
            };

            public int Length
            {
                get { return info.Length; }
            }
            public int this[int index]
            {
                get
                {
                    return info[index];
                }
                set
                {
                    info[index] = value;
                }
            }
        }

        // 맵 높이
        class MapHeight
        {
            private const int length = 20;
            int[] info = new int[length]
            {
                2,3,4,5,6,4,5,3,2,3,
                2,3,3,4,5,6,3,4,6,4
            };

            public int Length
            {
                get { return info.Length; }
            }
            public int this[int index]
            {
                get
                {
                    return info[index];
                }
                set
                {
                    info[index] = value;
                }
            }
        }


        class Save
        {
            public string id;
            public int lv;
            public int score;
        }



        public void ErrorMessage(Exception e)
        {
            using (StreamWriter writer = new StreamWriter(@"Error.txt"))
            {
                writer.WriteLine(e.Message);
            }
        }



        private void Pan_Paint(object sender, PaintEventArgs e)
        {
            // 겜 오버시
            if (over == true)
            {
                Pan.Visible = false;
                MakeScoreBoard();
            }

            // 아래에는 각 오브젝트별 paint

            e.Graphics.DrawImage(me.image.Image, me.Rect());

            for (int i = 0; i < blockList.Count; i++)
            {
                if (blockList[i].type != 1)
                {
                    e.Graphics.DrawImage(blockList[i].image.Image, blockList[i].Rect());
                }
            }

            // 근접공격시 
            if(bADown == true)
            {
                e.Graphics.DrawImage(me.cut.Image, me.CutRect(borderSizePlus));
            }


            for (int i = 0; i < itemList.Count; i++)
            {
                e.Graphics.DrawImage(itemList[i].image.Image, itemList[i].Rect());
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                e.Graphics.DrawImage(bulletList[i].image.Image, bulletList[i].Rect());
            }

            for (int i = 0; i < monList.Count; i++)
            {
                e.Graphics.DrawImage(monList[i].image.Image, monList[i].Rect());
            }

            for (int i = 0; i < enemyBulletList.Count; i++)
            {
                e.Graphics.DrawImage(enemyBulletList[i].image.Image, enemyBulletList[i].Rect());
            }

            for (int i = 0; i < knifeList.Count; i++)
            {
                e.Graphics.DrawImage(knifeList[i].image.Image, knifeList[i].Rect());
            }


            // 기타 리소스
            for (int x = 0; x < 26; x++)
            {
                e.Graphics.DrawImage(floor.Image, new Point (x * blockSize, pan.panSizePt.Y - blockSize - 2));
            }

        }

        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            Rectangle tmpRt = me.Rect(borderSizePlus);
            Rectangle tmpRt2 = me.CutRect(borderSizePlus);

            // 겜끝나고 점수판에서 enter누르면
            if(over == true && e.KeyCode == Keys.Enter)
            {
                SendProcess();
            }


            // 대쉬 이동
            if (e.KeyCode == Keys.Left && e.Control)
            {
                if (_mpBar.Value >= 10)
                {
                    _mpBar.Value -= 10;
                    tmpRt = me.Rect(borderSizePlus);
                    tmpRt2 = me.CutRect(borderSizePlus);
                    me.pt.X -= 100;
                    Pan.Invalidate(tmpRt); 
                    Pan.Invalidate(me.Rect(borderSizePlus));
                    Pan.Invalidate(tmpRt2);  
                    Pan.Invalidate(me.CutRect(borderSizePlus));
                }
            }
            else if (e.KeyCode == Keys.Right && e.Control)
            {
                if (_mpBar.Value >= 10)
                {
                    _mpBar.Value -= 10;
                    tmpRt = me.Rect(borderSizePlus);
                    tmpRt2 = me.CutRect(borderSizePlus);
                    me.pt.X += 100;
                    Pan.Invalidate(tmpRt);   
                    Pan.Invalidate(me.Rect(borderSizePlus));
                    Pan.Invalidate(tmpRt2); 
                    Pan.Invalidate(me.CutRect(borderSizePlus));
                }
            }
            else if (e.KeyCode == Keys.Up && e.Control)
            {
                if (_mpBar.Value >= 10)
                {
                    _mpBar.Value -= 10;
                    tmpRt = me.Rect(borderSizePlus);
                    tmpRt2 = me.CutRect(borderSizePlus);
                    me.pt.Y -= 100;
                    Pan.Invalidate(tmpRt);  
                    Pan.Invalidate(me.Rect(borderSizePlus));
                    Pan.Invalidate(tmpRt2);   
                    Pan.Invalidate(me.CutRect(borderSizePlus));
                }
            }
            else if (e.KeyCode == Keys.Down && e.Control)
            {
                if (_mpBar.Value >= 10)
                {
                    _mpBar.Value -= 10;
                    tmpRt = me.Rect(borderSizePlus);
                    tmpRt2 = me.CutRect(borderSizePlus);
                    me.pt.Y += 100;
                    Pan.Invalidate(tmpRt);  
                    Pan.Invalidate(me.Rect(borderSizePlus));
                    Pan.Invalidate(tmpRt2); 
                    Pan.Invalidate(me.CutRect(borderSizePlus));
                }
            }

            // 스킬 1
            if (e.KeyCode == Keys.Z)
            {
                if(_mpBar.Value >= 30)
                {
                    _mpBar.Value -= 30;
                    bSuperBody = true;
                    superBodyCounter = 9;  // 기본속도400ms x 5기준 = 2초
                }
            }

            // 스킬 2
            if (e.KeyCode == Keys.X)  // 딜레이만큼 칼 수 결정
            {
                if (_mpBar.Value >= 60)
                {
                    _mpBar.Value -= 60;

                    bKnifeField = true;
                    knifeFieldCounter = 17;
                }
            }

            // 스킬 3
            if (e.KeyCode == Keys.C)
            {
                if (_mpBar.Value >= 100)
                {
                    _mpBar.Value = 0;
                    bKeyDownNow = true;
                    keyDownCounter = 0;
                }
            }

            // 근접
            if (e.KeyCode == Keys.A && bACoolDown <= 0)
            {
                tmpRt2 = me.CutRect(borderSizePlus);
                bADown = true;
                bACounter = 2;
                Pan.Invalidate(tmpRt2);   // 이전 영역 다시 그리기
                Pan.Invalidate(me.CutRect(borderSizePlus));
            }

            // 사격
            if (e.KeyCode == Keys.Space)
            {
                if(bulletTimer.Enabled == false)
                    bulletTimer.Start();

                int x = 0;
                int y = 0;
                int dir = 0;


                if (me.seeDir == 0)     // 왼쪽 봄
                {
                    x = me.pt.X - me.Rect().Width / 2 - bulletSize ;
                    y = me.pt.Y - bulletSize / 2;
                    dir = 0;
                    
                }
                else if (me.seeDir == 1)  // 오른쪽 봄
                {
                    x = me.pt.X + me.Rect().Width / 2;
                    y = me.pt.Y - bulletSize / 2;
                    dir = 1;
                }

                Bullet bullet = new Bullet(new Rectangle(x, y, bulletSize, bulletSize), bulletType);  // 총알리스트에 생성된 총알 등록
                bullet.dir = dir;
                bulletList.Add(bullet);
                Pan.Invalidate(bullet.Rect(borderSizePlus)); // 다시 그리기
            }

            if (e.KeyCode == Keys.Left ||
                e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Down)            
            {
                int tmpNumber = 0;
                tmpRt = me.Rect(borderSizePlus);  // 이전 영역 킵
                tmpRt2 = me.CutRect(borderSizePlus);
                if (e.KeyCode == Keys.Left)
                {

                    for (int i = 0; i < perMoveDistance; i++)
                    {
                        me.Move("Left");

                        IsMeet(out tmpNumber);
                        if (tmpNumber == 1) // 이동해보고 닿으면 취소
                        {
                            me.Move("Right");
                            break;
                        }
                    }

                    if (IsMeetDown() == false && jumpTimer.Enabled == false)   // 떨어지는거 구현
                    {

                        perJumpDistance = 0;
                        bDown = 1;
                        jumpTimer.Start();  // 점프루틴을 tick처럼 연속호출시켜야
                                            // distance가 지속적으로 올라가서 작동됨
                    }
                }

                if (e.KeyCode == Keys.Right)
                {
                    for (int i = 0; i < perMoveDistance; i++)
                    {
                        me.Move("Right");

                        IsMeet(out tmpNumber);
                        if (tmpNumber == 1)
                        {
                            me.Move("Left");
                            break;
                        }

                    }

                    // 떨어질때
                    if (IsMeetDown()==false && jumpTimer.Enabled == false)
                    {
                        perJumpDistance = 0;
                        bDown = 1;
                        jumpTimer.Start();
                    }

                }

                if (e.KeyCode == Keys.Up && bUpDisabled == false)  // 점프
                {
                    jumpTimer.Enabled = true;
                    jumpTimer.Start();
                    bUpDisabled = true;     // 점프중 up 입력 x              
                }


                Pan.Invalidate(tmpRt);   // 이전 영역 다시 그리기
                Pan.Invalidate(me.Rect(borderSizePlus));  // 새 영역 다시 그리기
                Pan.Invalidate(tmpRt2);   // 이전 영역 다시 그리기 (칼)
                Pan.Invalidate(me.CutRect(borderSizePlus));
            }
        }




        public void GameOver()
        {
            MapTimer.Stop();
            blockMakeTimer.Stop();
            bulletTimer.Stop();
            jumpTimer.Stop();
            over = true;
            Invalidate();
        }



        public void MakeScoreBoard()  // 겜오버후 점수판
        {
            Panel ScoreBoard = new Panel();
            ScoreBoard.Size = new System.Drawing.Size(785, 334);
            ScoreBoard.Location = new Point(0, 0);
            ScoreBoard.BorderStyle = BorderStyle.Fixed3D;
            ScoreBoard.BackColor = Color.White;

            Label Lv = new Label();
            Lv.Size = new Size(38, 12);
            Lv.Location = new Point(282, 80);
            Lv.Text = "Lv";
            Lv.Visible = true;
            Label Score = new Label();
            Score.Size = Lv.Size;
            Score.Location = new Point(282, Lv.Location.Y + 55);
            Score.Text = "Score";
            Label Id = new Label();
            Id.Size = Lv.Size;
            Id.Location = new Point(282, Lv.Location.Y + 55 * 2);
            Id.Text = "Id";

            LvBox = new TextBox();
            LvBox.Size = new Size(100, 20);
            LvBox.Location = new Point(340, 77);
            LvBox.Text = textBox2.Text;
            LvBox.ReadOnly = true;
            ScoreBox = new TextBox();
            ScoreBox.Size = LvBox.Size;
            ScoreBox.Location = new Point(340, LvBox.Location.Y + 55);
            ScoreBox.Text = textBox1.Text;
            ScoreBox.ReadOnly = true;
            IdBox = new TextBox();
            IdBox.Size = LvBox.Size; ;
            IdBox.Location = new Point(340, LvBox.Location.Y + 55 * 2);
            

            Controls.Add(Lv);
            Controls.Add(Score);
            Controls.Add(Id);

            Controls.Add(LvBox);
            Controls.Add(ScoreBox);
            Controls.Add(IdBox);
            
        }




        
        public bool IsMeet(out int number)  // 블럭 또는 판의 바닥(안씀. 블럭만 해당) 1
                                            // 아이템은 2 
                                            // 몬스터는 3  // 몹끼리는 4 (별로 안중요함) 

        {
            for (int i = 0; i < blockList.Count; i++)
            {
                if(me.Rect().IntersectsWith(blockList[i].Rect()))  // Rect끼리의 교집합 여부를 기준으로 만났는지 판단.
                {
                    number = 1;
                    return true;
                }              
            }

            if (me.Rect().Y + me.Rect().Height >= pan.panLocPt.Y + pan.panSizePt.Y)
            {
                number = 1;
                return true;
            }

            for (int i = 0; i < itemList.Count; i++)
            {
                if (me.Rect().IntersectsWith(itemList[i].Rect(borderSizePlus)))
                {
                    Rectangle tmpRt = itemList[i].Rect(borderSizePlus);
                    Rectangle tmpRt2 = me.CutRect(borderSizePlus);

                    if (i >= 0 && i < itemList.Count)
                    {
                        try
                        {
                            if (itemList[i].type == 0)
                            {
                                score += 10;   // 스코어 증가
                                textBox1.Text = score.ToString();
                            }
                            else if (itemList[i].type == 1)
                            {
                                score += 50;
                                textBox1.Text = score.ToString();
                            }
                            else if (itemList[i].type == 2)
                            {
                                score += 100;
                                textBox1.Text = score.ToString();
                            }
                            else if (itemList[i].type == 3)
                            {
                                if (_hpBar.Value > meHp - 35) { _hpBar.Value = meHp; }
                                else _hpBar.Value += 35;
                            }
                            else if (itemList[i].type == 4)
                            {
                                if (_mpBar.Value > meMp - 50) { _mpBar.Value = meMp; }
                                else _mpBar.Value += 50;
                            }
                        }
                        catch (Exception e) { ErrorMessage(e);  throw;  }
                        
                    }

                    if(score >= 0 && score < 200)   // 레벨 증가별로 캐릭터가 진화함
                    {
                        me.lv = 1;
                        bulletType = 0;
                    }
                    else if (score >= 200 && score < 500)
                    {
                        me.lv = 2;
                        bulletType = 1;
                        bulletSize = 20; // 기본 20
                        bulletSpeed = 25; // 기본 20      
                        me.image.Image = Properties.Resources.pupurin;                 
                    }
                    else if (score >= 500 && score < 1000)
                    {
                        me.lv = 3;
                        bulletType = 2;
                        bulletSize = 28;
                        bulletSpeed = 30;
                        me.image.Image = Properties.Resources.pukrin;
                        
                    }
                    else if (score >= 1000 && score < 2000)
                    {
                        me.lv = 4;
                        bulletType = 3;
                        bulletSize = 33;
                        bulletSpeed = 40;                        
                    }
                    else if (score >= 2000 && score < 5000)
                    {
                        me.lv = 5;
                        //bulletType = 4;
                    }
                    else if (score >= 5000)
                    {
                        me.lv = 6;
                        //bulletType = 5;
                    }
                    textBox2.Text = me.lv.ToString();


                    itemList.RemoveAt(i);   // 아이템 먹고나면 사라짐.
                    Pan.Invalidate(tmpRt);
                    Pan.Invalidate(tmpRt2);
                    number = 2;
                    return true;
                }
            }


            for (int i = 0; i < monList.Count; i++)
            {
                if (me.Rect().IntersectsWith(monList[i].Rect()))
                {
                    if (bSuperBody == false)
                    {
                        Pan.Invalidate(monList[i].Rect(borderSizePlus + 0));
                        Pan.Invalidate(me.Rect(borderSizePlus + 0));
                        if (monList.Count > 0) monList.RemoveAt(i);       // 나와 몹이 닿으면 몹이 제거 되고         

                        if (_hpBar.Value <= meHpStep) { _hpBar.Value = 0; }
                        else _hpBar.Value -= meHpStep;   // 내 hp가 깎임

                        if (_hpBar.Value <= 0) GameOver();   // hp가 없으면 사망
                        number = 3;
                        return true;
                    }
                }
            }

            for (int i = 0; i < monList.Count; i++)
            {
                for (int j = 0; j < monList.Count; j++)
                {
                    if (monList[i].Rect().IntersectsWith(monList[j].Rect()))
                    {
                        number = 4;
                        return true;
                    }
                }
            }

            number = 0;
            return false;
        }

        public bool IsMeetDown()  // 하단이 블락과 닿아있을때 
        {
            for (int i = 0; i < blockList.Count; i++)
            {
                if (me.RectY(5).IntersectsWith(blockList[i].Rect()))
                {
                    return true;
                }           
            }
            return false;
        }

        public bool IsMeetDownMon(int j, String dir)  // 하단이 블락과 닿아있을때 (몹용)
        {
            try
            {
                for (int i = 0; i < blockList.Count; i++)
                {
                    if (i >= 0 && i < blockList.Count)
                    {

                        if (dir == "Left")
                        {
                            if (monList[j].RectXY(-blockSize, 5).IntersectsWith(blockList[i].Rect()))
                            {
                                return true;
                            }
                        }
                        if (dir == "Right")
                        {
                            if (monList[j].RectXY(blockSize, 5).IntersectsWith(blockList[i].Rect()))
                            {
                                return true;
                            }
                        }

                    }
                }
            }
            catch (Exception e) { ErrorMessage(e); throw; }
            return false;
        }

        public bool IsMeetFloor()    // 맨 밑 바닥에 닿았는지
        {
                if (me.Rect().Y + me.Rect().Height >= pan.panLocPt.Y + pan.panSizePt.Y - blockSize)
                {
                    return true;
                }
            return false;
        }


        public bool IsMeetNarrow()  // 중심이 고정된 상태에서 height가 줄어든 블럭과 조우했을때 
                                    // 끼임 방지용인데 바닥에 맞닿을때도 적용되는 버그때매 만듬
        {
            Rectangle rt;
            for (int i = 0; i < blockList.Count; i++)
            {
                rt = blockList[i].Rect();
                rt.Y = blockList[i].Rect().Y + blockSize / 4;
                rt.Height = blockSize / 2;

                if (me.Rect().IntersectsWith(rt))
                {
                    return true;
                }
            }
            return false;
        }

        public int IsMeetBullet()    // 총알과 만났는지
        {

            for (int i = 0; i < bulletList.Count; i++)
            {
                for (int j = 0; j < blockList.Count; j++)
                {
                    if (bulletList[i].Rect().IntersectsWith(blockList[j].Rect()))
                    {
                        if (bulletList.Count > 0) bulletList.RemoveAt(i);
                        return 0;
                    }
                }
            }

            try
            {
                for (int i = 0; i < bulletList.Count; i++)
                {
                    for (int j = 0; j < monList.Count; j++)
                    {
                        if (bulletList[i].Rect().IntersectsWith(monList[j].Rect()))
                        {
                            randNum = random.Next(100) + 1;   // 1~100 난수
                            if (randNum <= itemPercent && j >= 0 && j < monList.Count) ItemAppear(monList[j]); 
                             // 난수가 지정된 percent보다 작으면 아이템 발생. 

                            Pan.Invalidate(monList[j].Rect(borderSizePlus + 0));
                            if (bulletList.Count > 0) bulletList.RemoveAt(i);   // 몹과 총알이 닿으면 둘 다 제거
                            if (monList.Count > 0) monList.RemoveAt(j);
                            return 1;
                        }
                    }
                }
            }
            catch (Exception e) { ErrorMessage(e); throw; }

            return 0;
        }

        public int IsMeetEnemyBullet()
        {
            for (int i = 0; i < enemyBulletList.Count; i++)
            {
                if (me.Rect().IntersectsWith(enemyBulletList[i].Rect()))
                {
                    if (enemyBulletList.Count > 0) enemyBulletList.RemoveAt(i);   // 몹과 총알이 닿으면 둘 다 제거

                    if (_hpBar.Value <= meHpStep - 6) { _hpBar.Value = 0; }
                    else _hpBar.Value -= meHpStep - 6;   // 내 hp가 깎임

                    if (_hpBar.Value <= 0) GameOver();
                    return 0;
                }
            }

            for (int i = 0; i < enemyBulletList.Count; i++)
            {
                for (int j = 0; j < blockList.Count; j++)
                {
                    if (enemyBulletList[i].Rect().IntersectsWith(blockList[j].Rect()))
                    {
                        if (enemyBulletList.Count > 0) enemyBulletList.RemoveAt(i);
                        return 1;
                    }
                }
            }

            return 0;
        }

        public int IsMeetKnife()   // 칼(내 스킬로 생성되는)과 만났는지
        {
            try
            {
                int randNum = 0;
                for (int i = 0; i < knifeList.Count; i++)
                {
                    for (int j = 0; j < monList.Count; j++)
                    {
                        if (knifeList[i].Rect().IntersectsWith(monList[j].Rect()))
                        {
                            randNum = random.Next(100) + 1;
                            if (randNum <= itemPercent && j >= 0 && j < monList.Count) ItemAppear(monList[j]);

                            Pan.Invalidate(knifeList[i].Rect(borderSizePlus + 0));
                            Pan.Invalidate(monList[j].Rect(borderSizePlus + 0));
                            if (knifeList.Count > 0) knifeList.RemoveAt(i);   // 몹과 총알이 닿으면 둘 다 제거
                            if (monList.Count > 0) monList.RemoveAt(j);
                            return 1;
                        }
                    }
                }
            }
            catch (Exception e) { ErrorMessage(e); throw; }

            for (int i = 0; i < knifeList.Count; i++)
            {
                for (int j = 0; j < blockList.Count; j++)
                {
                    if (knifeList[i].Rect().IntersectsWith(blockList[j].Rect()))
                    {
                        if (knifeList.Count > 0) knifeList.RemoveAt(i);
                        return 1;
                    }
                }
            }

            return 0;
        }

        private int IsMeetSword()  // 검(내 근접 공격으로 생성되는) 과 만났는지
        {
            int randNum = 0;
            for (int i = 0; i < monList.Count; i++)
            {
                if (monList[i].Rect().IntersectsWith(me.CutRect()))
                {
                    randNum = random.Next(100) + 1;
                    if (randNum <= itemPercent && i >= 0 && i < monList.Count) ItemAppear(monList[i]);

                    Pan.Invalidate(monList[i].Rect(borderSizePlus + 0));
                    if (monList.Count > 0) monList.RemoveAt(i);
                    return 1;
                }
            }
            return 0;
        }

        private void jumpTimer_Tick(object sender, EventArgs e)
        {
            if (bDown == 0)  JumpRoutine("up");     // 위로 올라가는 중 
            if (bDown == 1)  JumpRoutine("down");   // 아래로 떨어지는 중
        }

        public void JumpRoutine(String upDown)
        {
            int bReverse = 0;
            int tmpNumber = 0;

            if (upDown == "up")

            {
                Rectangle tmpRt = me.Rect(borderSizePlus);
                Rectangle tmpRt2 = me.CutRect(borderSizePlus);

                for (int i = 0; i < perJumpDistance; i++)
                {
                    me.Move("Up");
                    IsMeet(out tmpNumber);
                    if (tmpNumber == 1)
                    {
                        me.Move("Down");
                        perJumpDistance = 0;  // 조잡한 가속도 구현
                        bReverse = perJumpDistanceDef - perJumpDistance;  // 점프하다 위에 부딪히면 부딪힌 상태의 가속도를
                                                                          // 아래로 떨어질때의 가속도로 엉성하게 전달
                        break;
                    }
                }

                Pan.Invalidate(tmpRt);
                Pan.Invalidate(me.Rect(borderSizePlus));
                Pan.Invalidate(tmpRt2);   // 이전 영역 다시 그리기
                Pan.Invalidate(me.CutRect(borderSizePlus));

                // perJumpDistance는 지속적으로 감소 // 가속도 구현할려고
                // jumpDistance = move 반복용 , 그냥 move값을 쓰면 이동거리가 클때 그 사이의 조건을 무시해버리는 문제 발생.
                // 그래서 단위이동거리로 이동하며 조건을 체크하기 위해 이동을 move와 jumpDistance 두단계로 분할.

                if (perJumpDistance <= 0)
                {
                    perJumpDistance = 1;                    
                    if(bReverse != 0) perJumpDistance = bReverse;
                    perJumpDistance = 0;
                    bDown = 1;           // 다운 발동         
                }
                perJumpDistance--;
            }

            else if (upDown == "down")
            {
                Rectangle tmpRt = me.Rect(borderSizePlus);
                Rectangle tmpRt2 = me.CutRect(borderSizePlus);
                for (int i = 0; i < perJumpDistance; i++)
                {
                    me.Move("Down");
                    IsMeet(out tmpNumber);
                    if (tmpNumber == 1)
                    {
                        me.Move("Up");
                        perJumpDistance = perJumpDistanceDef + 10; // 이거랑 밑에꺼 조정하면 얼마나 아래까지 박히는지 조정
                    }
                }

                Pan.Invalidate(tmpRt);
                Pan.Invalidate(me.Rect(borderSizePlus));
                Pan.Invalidate(tmpRt2);   // 이전 영역 다시 그리기
                Pan.Invalidate(me.CutRect(borderSizePlus));

                perJumpDistance++ ;                              
                if (perJumpDistance >= perJumpDistanceDef + 10) // +1로하면 딱 떨어지고 그 이상이면 더
                {                  
                    perJumpDistance = perJumpDistanceDef;  // 초기화 작업들              
                    jumpTimer.Stop();
                    jumpTimer.Enabled = false;  // 타이머 안 쓸땐 꺼둠
                    bUpDisabled = false;  // 중간에 키입력 금지
                    bDown = 0;
                }
            }
        }



        private void bulletTimer_Tick(object sender, EventArgs e)
        {
            Rectangle tmpRt;

            for (int i = 0; i < bulletList.Count; i++)
            {
                tmpRt = bulletList[i].Rect(borderSizePlus);

                if (bulletList[i].dir == 0)  // 총알 방향이 좌측이면 왼쪽으로 진행
                {
                    bulletList[i].pt.X -= bulletSpeed; 
                }
                else if (bulletList[i].dir == 1)  // 오른쪽이면 오른쪽
                {
                    bulletList[i].pt.X += bulletSpeed;
                }

                IsMeetBullet(); // 총알과 블락또는 몹이 만났는지 검사

                Pan.Invalidate(tmpRt);
                if (bulletList.Count > i)  // 인덱스 에러 방지
                    Pan.Invalidate(bulletList[i].Rect(borderSizePlus)); 
            }


            for (int i = 0; i < enemyBulletList.Count; i++)
            {
                tmpRt = enemyBulletList[i].Rect(borderSizePlus);
                if (enemyBulletList[i].dir == 0)  // 총알 방향이 좌측이면 왼쪽으로 진행
                {
                    enemyBulletList[i].pt.X -= bulletSpeed;
                }
                else if (enemyBulletList[i].dir == 1)  // 오른쪽이면 오른쪽
                {
                    enemyBulletList[i].pt.X += bulletSpeed;
                }

                IsMeetEnemyBullet(); // 총알과 블락또는 몹이 만났는지 검사

                Pan.Invalidate(tmpRt);

                if (enemyBulletList.Count > i)  // 인덱스 에러 방지
                    Pan.Invalidate(enemyBulletList[i].Rect(borderSizePlus));

            }


            for (int i = 0; i < knifeList.Count; i++)
            {
                tmpRt = knifeList[i].Rect(borderSizePlus);
                knifeList[i].pt.Y += knifeSpeed;

                IsMeetKnife(); // 칼과 블락또는 몹이 만났는지 검사

                Pan.Invalidate(tmpRt);
                if (knifeList.Count > i)  // 인덱스 에러 방지
                    Pan.Invalidate(knifeList[i].Rect(borderSizePlus));
            }

            if (bulletList.Count <= 0 && enemyBulletList.Count <= 0 && knifeList.Count <= 0)  // 총알이 필드에 없을땐 꺼둠
                bulletTimer.Stop();
        }



        private void MapTimer_Tick(object sender, EventArgs e)
        {
            if (me.pt.X < pan.panLocPt.X - 30)    // 맵 바깥 좌측으로 가면 사망
                GameOver();


            timeEllapse++; // 400ms 기준 5당 2초, 5*5면 10초
            if (timeEllapse == 5*5 *3)  // 30초 경과
            {
                monPercent += 10; // 몹 출현률 증가
            }
            else if (timeEllapse == 5 * 5   * 6)
            {
                monPercent += 10;
            }
            else if(timeEllapse == 5 * 5 * 9)
            {
                monPercent += 10;
            }
            else if(timeEllapse == 5 * 5 * 12)
            {
                monPercent += 10;
            }
            else if(timeEllapse == 5 * 5 * 18)
            {
                monPercent += 15; 
            }
            else if(timeEllapse == 5 * 5 * 30)
            {
                monPercent = 100; 
            }




            if (bACounter > 1)  // 휘두르는중
            {
                bACounter--;
                Invalidate(me.CutRect(borderSizePlus));
                IsMeetSword();
            }
            else if (bACounter == 1)   // 근접공격 쿨다운용
            {
                bADown = false;
                bACoolDown = 5;
                bACounter = 0;
            }
            bACoolDown--;


            if (bKeyDownNow == true) keyDownCounter++; // 다음 스킬 다시 쓰기전 까지 카운터 활용 가능 (키다운용)
            if (keyDownCounter >= 15) KeyDownToUp();// 400 * 15 = 6000. 6초
            if (bUltState == true) Ultimate();  // 궁극기 상태 유지
            if (ultimate > 1)
            {
                ultimate--;               
            }
            else if (ultimate == 1) // 0일땐 기본상태 , 1일땐 마무리 작업
            {
                ultimate = 0;
                bulletType = bulletTypeSave;
                bulletSpeed = bulletSpeedSave;
                bUltState = false;
                bSuperBody = false;

                background.Image.Dispose();
                background.Image = Properties.Resources.jungle;
                background.Width = pan.panSizePt.X;
                background.Height = pan.panSizePt.Y;

                Pan.BackgroundImage = background.Image;
                Pan.BackgroundImageLayout = ImageLayout.Stretch;
            }
    


            if (bKnifeField == true)  // 칼 떨어지는 스킬 발동중
            {
                knifeFieldCounter--;

                if (bulletTimer.Enabled == false)
                    bulletTimer.Start();
                int x = random.Next(pan.panSizePt.X - knifeSizeX);
                int y = pan.panLocPt.Y;

                Bullet knife = new Bullet(new Rectangle(x, y, knifeSizeX, knifeSizeY), 4);  // 총알리스트에 생성된 총알 등록
                knife.dir = 3;
                knifeList.Add(knife);
                Pan.Invalidate(knife.Rect(borderSizePlus));
            } 
            if (knifeFieldCounter <= 0) bKnifeField = false;



            if (bSuperBody == true)   //  슈퍼바디 스킬 발동중
                superBodyCounter--;
            if(superBodyCounter <= 0)
            {
                bSuperBody = false;
            }


            idleCounter++;  // 약 2초에 한번 전체 새로고침 (기본속도기준)  // 잡티 제거용
            if (idleCounter >= 5)
            {
                Invalidate();
                idleCounter = 0;
            }

            mpCounter++;
            if(mpCounter>=7)  // 약 3초에 한번씩 mp참
            {
                if (_mpBar.Value > meMp - meMpStep) { _mpBar.Value = meMp; }
                else _mpBar.Value += 7;  
                mpCounter = 0;
            }

            if (IsMeetDown() == false && jumpTimer.Enabled == false)  // 빈 공간에서 아래 블락없을때 캐릭터 내비두면 떨어지게 하는 용도
            {
                perJumpDistance = 0;
                bDown = 1;
                jumpTimer.Start();
            }

            Rectangle tmpRt;
            Block block = sendToMapTimer;


            if (block != null)
            {

                randNum = random.Next(100) + 1;    // 몬스터 출현률
                if (randNum <= monPercent) MonAppear(block);


                if (IsMeetNarrow())  // height를 줄인 사각형과 접할때(좌우 border의 center부분과 접할때)
                {                   // 이동하는 블럭에 끼임 방지
                                    // dir 적용은 필요하면   if (blockList[i].dir == 0)  형태로 추가
                    for (int j = 0; j < perMoveDistance * 3; j++) // 많이 곱할수록 띠용 튀어오름
                    {
                        me.Move("Up");
                  
                    }

                    if (IsMeetDown() == false && jumpTimer.Enabled == false)
                    {

                        perJumpDistance = 0;
                        bDown = 1;
                        jumpTimer.Start(); 
                    }
                }
            }


            // 모든 요소 전체 이동
            for (int i = 0; i < blockList.Count; i++)
            {
                // 블럭들 이동
                if (blockList.Count > i && i >= 0)
                {
                    tmpRt = blockList[i].Rect(borderSizePlus);
                    if (blockList[i].dir == 0)  // 일단 왼쪽으로만 이동
                    {
                        blockList[i].pt.X -= blockList[i].size.X;
                    }
                    if (blockList[i].pt.X < pan.panLocPt.X) blockList.RemoveAt(i);
                    Pan.Invalidate(tmpRt);
                    if (blockList.Count > i) Pan.Invalidate(blockList[i].Rect(borderSizePlus));
                }

                // 아이템들 이동
                if (itemList.Count > i && blockList.Count > i && i >= 0)
                {
                    tmpRt = itemList[i].Rect(borderSizePlus);
                    if (itemList[i].dir == 0) 
                    {
                        itemList[i].pt.X -= blockList[i].size.X;  // 그냥 임의 블락리스트 사이즈만큼 같이 이동
                    }
                    if (itemList[i].pt.X < pan.panLocPt.X) itemList.RemoveAt(i);
                    Pan.Invalidate(tmpRt);
                    if (itemList.Count > i) Pan.Invalidate(itemList[i].Rect(borderSizePlus));
                }

                // 몹들 이동
                if (monList.Count > i && blockList.Count > i && i >= 0)
                {
                    tmpRt = monList[i].Rect(borderSizePlus);
                    if (monList[i].dir == 0)
                    {
                        monList[i].pt.X -= blockList[i].size.X;
                    }
                    if (monList[i].pt.X < pan.panLocPt.X) monList.RemoveAt(i);
                    Pan.Invalidate(tmpRt);
                    if (monList.Count > i) Pan.Invalidate(monList[i].Rect(borderSizePlus));
                }
            }



            // 적 수 세기
            _enemy.Text = "enemy : " + monList.Count;




            // 맵 움직일때마다 몹 이동 수행
            MonMove();
            MonAttack();


            for (int j = 0; j < blockList.Count; j++)   // 블락 잡티 제거
            {
                Pan.Invalidate(blockList[j].Rect(borderSizePlus + 5));
            }


        }

        // 아이템 생성
        private void ItemAppear(Mon mon)
        {

            int x;
            int y;
            Item item;           

            x = mon.Rect().X;
            y = mon.Rect().Y;


            // x를 센터로 놓고싶으면 x + width / 2 - itemSize / 2
            item = new Item(new Rectangle(x, y + monSize - itemSize, itemSize, itemSize), random.Next(0, 5));
            // 0 : 10점, 1 : 50점, 2 : 100점, 3 : hp포션, 4 : mp포션  
            itemList.Add(item);
            item.dir = 0; // 걍 왼쪽
        }

        //몹 생성
        private void MonAppear(Block nowBlock)
        {
            int x;
            int y;
            int width;
            Mon mon;

            nowBlock.bMon = true;
            x = nowBlock.Rect().X;
            y = nowBlock.Rect().Y;
            width = nowBlock.Rect().Width;

            mon = new Mon(new Rectangle(x + width / 2 - monSize / 2, y - monSize, monSize, monSize), random.Next(0,3));
            monList.Add(mon);
            mon.dir = nowBlock.dir;

        }

        public void MonMove()
        {
            int randDir = 0;  // 0이면 좌  1이면 우
            int randMove = 0;  // 0이면 x  1이면 o
            int randMovDist = 0;  // 이동 거리

            Rectangle tmpRt;
            
            for (int i=0; i<monList.Count; i++)
            {
                tmpRt = monList[i].Rect(borderSizePlus);
                if (monList[i].type == 0 || monList[i].type == 1)
                {

                    randDir =  random.Next(2);
                    randMove = random.Next(2);
                    randMovDist = random.Next(10); 
                    if (randMove == 1)
                    {
                        if (randDir == 0)
                        {
                            for (int j = 0; j < randMovDist; j++)
                            {
                                if (i >= 0 && i < monList.Count)
                                {
                                    monList[i].Move("Left");
                                }
                                if (IsMeetDownMon(i, "Left") == false)
                                {
                                    if (i >= 0 && i < monList.Count)  monList[i].Move("Right");
                                    break;                         
                                }
                            }
                        }
                        else if (randDir == 1)
                        {
                            for (int j = 0; j < randMovDist; j++)
                            {
                                if (i >= 0 && i < monList.Count)
                                {
                                    monList[i].Move("Right");
                                }
                                if (IsMeetDownMon(i, "Right") == false)
                                {
                                    if (i >= 0 && i < monList.Count) monList[i].Move("Left");
                                    break;
                                }
                            }
                        }
                    }
                }

                // 드래곤은 날라다님
                else if (monList[i].type == 2)
                {
                    randDir = random.Next(8);  // 8방향 이동   쓸데없이 길게 짠듯
                    randMove = random.Next(2); 
                    randMovDist = random.Next(10);
                    if (randMove == 1)
                    {
                        if (randDir == 0)
                        {
                            for (int j = 0; j < randMovDist; j++)
                            {
                                if (i >= 0 && i < monList.Count)
                                { monList[i].Move("Left"); }
                            }
                        }
                        else if (randDir == 1)
                        {
                            for (int j = 0; j < randMovDist; j++)
                            {
                                if (i >= 0 && i < monList.Count)
                                { monList[i].Move("Right"); }
                            }
                        }
                        else if (randDir == 2)
                        {
                            for (int j = 0; j < randMovDist; j++)
                            {
                                if (i >= 0 && i < monList.Count)
                                { monList[i].Move("Up"); }
                            }
                        }
                        else if (randDir == 3)
                        {
                            for (int j = 0; j < randMovDist; j++)
                            {
                                if (i >= 0 && i < monList.Count)
                                { monList[i].Move("Down"); }
                            }
                        }
                        else if (randDir == 4)
                        {
                            for (int j = 0; j < randMovDist; j++)
                            {
                                if (i >= 0 && i < monList.Count)
                                { monList[i].Move("Left"); monList[i].Move("Up"); }
                            }
                        }
                        else if (randDir == 5)
                        {
                            for (int j = 0; j < randMovDist; j++)
                            {
                                if (i >= 0 && i < monList.Count)
                                { monList[i].Move("Left"); monList[i].Move("Down"); }
                            }
                        }
                        else if (randDir == 6)
                        {
                            for (int j = 0; j < randMovDist; j++)
                            {
                                if (i >= 0 && i < monList.Count)
                                { monList[i].Move("Left"); monList[i].Move("Up"); }
                            }
                        }
                        else if (randDir == 7)
                        {
                            for (int j = 0; j < randMovDist; j++)
                            {
                                if (i >= 0 && i < monList.Count)
                                { monList[i].Move("Left"); monList[i].Move("Down"); }
                            }
                        }
                    }
                
                }
                Pan.Invalidate(tmpRt);
                Pan.Invalidate(monList[i].Rect(borderSizePlus));
            }

        }
        // 몬스터 공격
        public void MonAttack()  
        {
            int randDir = 0;  // 0이면 좌  1이면 우
            int randAttack = 0;  // 0이면 x  1이면 o

            for (int i = 0; i < monList.Count; i++)
            {
                if(monList[i].type == 1)
                {
                    randDir = random.Next(2);
                    randAttack = random.Next(100) / 60; // 0~99를 60으로 나누면 30도안되는 확률
                    if (randAttack == 1)
                    {
                        if (randDir == 0)
                        {
                            if (bulletTimer.Enabled == false)
                                bulletTimer.Start();

                            int x = 0;
                            int y = 0;                   
                            x = monList[i].pt.X - monList[i].Rect().Width / 2 - bulletSize;
                            y = monList[i].pt.Y - bulletSize / 2;
                                
                            Bullet bullet = new Bullet(new Rectangle(x, y, 10, 10), 5);  // 총알리스트에 생성된 총알 등록
                            bullet.dir = 0;
                            //bullet.type = bulletType;
                            enemyBulletList.Add(bullet);
                            Pan.Invalidate(bullet.Rect(borderSizePlus));
                        }
                        else if (randDir == 1)
                        {
                            if (bulletTimer.Enabled == false)
                                bulletTimer.Start();

                            int x = 0;
                            int y = 0;
                            x = monList[i].pt.X + monList[i].Rect().Width / 2;
                            y = monList[i].pt.Y - bulletSize / 2;

                            Bullet bullet = new Bullet(new Rectangle(x, y, 10, 10), 5);  // 총알리스트에 생성된 총알 등록
                            bullet.dir = 1;
                            enemyBulletList.Add(bullet);
                            Pan.Invalidate(bullet.Rect(borderSizePlus));
                        }
                }   }
            }
        }


        //맵 만드는 타이머
        private void blockMakeTimer_Tick(object sender, EventArgs e)
        {
            blockMakeTimerCnt++; // -1부터 시작

            floorDeadCnt++;
            if (floorDeadCnt >= 5*4)    // 일정 시간 지나고 바닥 닿으면 사망
            {
                if(IsMeetFloor()==true)
                {
                    GameOver();
                }
            }

;
            Rectangle rt = new Rectangle();
            int dir = 0;
            int n = 0;


            // 맵은 시작, 끝 두 부분을 map인덱서에 전달하고,  해당 위치 블럭 각각의 높이는 mapHeight에 전달. (클래스 정의에서 수정가능)
            for (int i = 0; i < map.Length; i+=2)
            {
                if (blockMakeTimerCnt >= map[i]
                        && blockMakeTimerCnt <= map[i+1])
                {
                    if (blockMakeTimerCnt == map[map.Length - 1]) blockMakeTimerCnt = 0;
                    n = mapHeight[i/2];
                    rt = new Rectangle(pan.panSizePt.X, pan.panSizePt.Y - blockSize - blockSize * n, blockSize, blockSize);
                    break;
                }
            }

            // 최종 리턴
            sendToMapTimer = MakeBlock(rt, dir);
        }


        // 블럭 생성
        private Block MakeBlock(Rectangle rt, int dir)
        {
            Block block = new Block(rt, dir);
            blockList.Add(block);
            block.dir = dir;

            return block;
        }


        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }


        // 맵 변경
        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            background.Image.Dispose();
            background.Image = Properties.Resources.jungle;
            background.Width = pan.panSizePt.X;
            background.Height = pan.panSizePt.Y;
            
            Pan.BackgroundImage = background.Image;
            Pan.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            background.Image.Dispose();
            background.Image = Properties.Resources.ocean;
            background.Width = pan.panSizePt.X;
            background.Height = pan.panSizePt.Y;   
            Pan.BackgroundImage = background.Image;
            Pan.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            background.Image.Dispose();
            background.Image = Properties.Resources.field;
            background.Width = pan.panSizePt.X;
            background.Height = pan.panSizePt.Y;
            Pan.BackgroundImage = background.Image;
            Pan.BackgroundImageLayout = ImageLayout.Stretch;
        }



        // 속도 변경
        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            MapTimer.Interval = 600;
            blockMakeTimer.Interval = 600;
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            MapTimer.Interval = 400;
            blockMakeTimer.Interval = 400;
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            MapTimer.Interval = 200;
            blockMakeTimer.Interval = 200;
        }


        // 키다운용
        private void MyForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && bKeyDownNow == true)
                KeyDownToUp();

        }

        public void KeyDownToUp()
        {
            bKeyDownNow = false;  // keydownCounter 활용
            bUltState = true;
            //ultimate = 15; // 초기화 작업 // // 기본속도400ms x 5기준 = 2초
                                    // true인동안 작업 수행
            ultimate = keyDownCounter + 15;   // 400 x 10 = 4초 (기본 20)
            //bUltState = true;
            bSuperBody = true;

            bulletTypeSave = bulletType;
            bulletType = 3;
            bulletSpeedSave = bulletSpeed;
            bulletSpeed += 20;
            if (_hpBar.Value <= 70) _hpBar.Value += 30;
            else _hpBar.Value = 100;

        }




        // 궁극기
        public void Ultimate()
        {
            background.Image.Dispose();
            background.Image = Properties.Resources.magnetic;
            background.Width = pan.panSizePt.X;
            background.Height = pan.panSizePt.Y;

            Pan.BackgroundImage = background.Image;
            Pan.BackgroundImageLayout = ImageLayout.Stretch;

            int loop = 10 + keyDownCounter/3;


            for (int i = 0; i < monList.Count; i++)
            {
                for (int j = 0; j < loop; j++)
                {
                    if(me.pt.X  > monList[i].pt.X + blockSize / 2)
                    {
                            monList[i].Move("Right");
                    }
                    if (me.pt.X  < monList[i].pt.X + blockSize / 2)
                    {
                            monList[i].Move("Left");
                    }
                    if (me.pt.Y  > monList[i].pt.Y + blockSize / 2)
                    {
                            monList[i].Move("Down");
                    }
                    if (me.pt.Y < monList[i].pt.Y + blockSize / 2)
                    {
                            monList[i].Move("Up");
                    }
                }
            }
        }

        // 텍스트 파일 작업
        public void SendProcess()
        {
            String[] str = { "아이디 : " + IdBox.Text, "레벨 : " + LvBox.Text, "점수 : " + ScoreBox.Text, "", "" };
            File.AppendAllLines("test.txt", str);

            String []str1 = { ScoreBox.Text };
            File.AppendAllLines("test1.txt", str1);
            IdBox.Text = "저장 완료";

            int value = 100;
            int[] saveNumber = new int[value];
            int i = 0;
            using (StreamReader reader = new StreamReader(@"test1.txt"))
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    saveNumber[i] = int.Parse(line);
                    i++;
                }
            }

          
            var query = from tmp in saveNumber
                        where tmp >= 100
                        orderby tmp
                        select tmp;

            str = new String[50];
            foreach (var num in query)
            {
                str[i] = num.ToString();              
                i++;
            }

            File.AppendAllLines("100.txt", str);



            query = from tmp in saveNumber
                        where tmp >= 200
                        orderby tmp
                        select tmp;

            str = new String[20];
            foreach (var num in query)
            {
                str[i] = num.ToString();            
                i++;
            }

            File.AppendAllLines("200.txt", str);

        }

 
    }


}
