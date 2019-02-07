using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Game;
using Loginform1;
using Memory;

namespace Snake
{
    public partial class frmSelect : Form
    {
        private frmMenu fM2;

        public frmSelect()
        {
            InitializeComponent();
        }

        public frmSelect(frmMenu fM)
        {
            InitializeComponent();
            fM2 = fM;
        }

        private void snakeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fM2.musicStop();
            frmMain fN = new frmMain();
            fN.ShowDialog();
            this.Close();
        }

        private void purinBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fM2.musicStop();
            MyForm mf = new MyForm();
            mf.ShowDialog();
            this.Close();
        }

        private void ddongBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fM2.musicStop();
            Form2 mf2 = new Form2();
            mf2.ShowDialog();
            this.Close();
        }

        private void bgBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(fM2!=null)
                fM2.musicStop();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}
