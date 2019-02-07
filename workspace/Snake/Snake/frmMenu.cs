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
using _Game;
using Loginform1;

namespace Snake
{
    public partial class frmMenu : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public frmMenu()
        {
            InitializeComponent();
            Init();
        }

        public void musicStop()
        {
            player.controls.stop();
        }

        private void Init()
        {
            mainImg.Load("game_Main.jpg");
            mainImg.SizeMode = PictureBoxSizeMode.StretchImage;

            lbMain.BackColor = Color.Transparent;
            lbMain.Parent = mainImg;
            player.URL = "marble.mp3";
            player.controls.play();
        }

        private void frmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    this.Hide();
                    frmSelect fS = new frmSelect(this);
                    fS.ShowDialog();
                    this.Close();
                    break;
                case Keys.Space:
                    break;
            }
        }
    }
}
