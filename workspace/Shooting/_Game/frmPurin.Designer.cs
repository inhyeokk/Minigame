namespace _Game
{
    partial class MyForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Pan = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.jumpTimer = new System.Windows.Forms.Timer(this.components);
            this.bulletTimer = new System.Windows.Forms.Timer(this.components);
            this.hp = new System.Windows.Forms.ToolStripStatusLabel();
            this.hpBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mpBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.enemy = new System.Windows.Forms.ToolStripStatusLabel();
            this.MapTimer = new System.Windows.Forms.Timer(this.components);
            this.blockMakeTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._HP = new System.Windows.Forms.ToolStripStatusLabel();
            this._hpBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this._mpBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this._enemy = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pan
            // 
            this.Pan.BackColor = System.Drawing.Color.White;
            this.Pan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pan.Location = new System.Drawing.Point(0, 0);
            this.Pan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pan.Name = "Pan";
            this.Pan.Size = new System.Drawing.Size(897, 417);
            this.Pan.TabIndex = 0;
            this.Pan.Paint += new System.Windows.Forms.PaintEventHandler(this.Pan_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(107, 482);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(109, 25);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox2.Location = new System.Drawing.Point(107, 449);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(108, 25);
            this.textBox2.TabIndex = 2;
            // 
            // jumpTimer
            // 
            this.jumpTimer.Enabled = true;
            this.jumpTimer.Interval = 50;
            this.jumpTimer.Tick += new System.EventHandler(this.jumpTimer_Tick);
            // 
            // bulletTimer
            // 
            this.bulletTimer.Enabled = true;
            this.bulletTimer.Tick += new System.EventHandler(this.bulletTimer_Tick);
            // 
            // hp
            // 
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(23, 17);
            this.hp.Text = "HP";
            // 
            // hpBar
            // 
            this.hpBar.Name = "hpBar";
            this.hpBar.Size = new System.Drawing.Size(100, 16);
            this.hpBar.Value = 100;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel1.Text = "MP";
            // 
            // mpBar
            // 
            this.mpBar.Name = "mpBar";
            this.mpBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(432, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // enemy
            // 
            this.enemy.Name = "enemy";
            this.enemy.Size = new System.Drawing.Size(54, 17);
            this.enemy.Text = "Enemy : ";
            // 
            // MapTimer
            // 
            this.MapTimer.Enabled = true;
            this.MapTimer.Interval = 400;
            this.MapTimer.Tick += new System.EventHandler(this.MapTimer_Tick);
            // 
            // blockMakeTimer
            // 
            this.blockMakeTimer.Enabled = true;
            this.blockMakeTimer.Interval = 400;
            this.blockMakeTimer.Tick += new System.EventHandler(this.blockMakeTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Level";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._HP,
            this._hpBar,
            this.toolStripStatusLabel6,
            this._mpBar,
            this.toolStripStatusLabel7,
            this._enemy});
            this.statusStrip1.Location = new System.Drawing.Point(0, 550);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(896, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _HP
            // 
            this._HP.Name = "_HP";
            this._HP.Size = new System.Drawing.Size(29, 21);
            this._HP.Text = "HP";
            // 
            // _hpBar
            // 
            this._hpBar.Name = "_hpBar";
            this._hpBar.Size = new System.Drawing.Size(114, 20);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(32, 21);
            this.toolStripStatusLabel6.Text = "MP";
            // 
            // _mpBar
            // 
            this._mpBar.Name = "_mpBar";
            this._mpBar.Size = new System.Drawing.Size(114, 20);
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(519, 21);
            this.toolStripStatusLabel7.Spring = true;
            // 
            // _enemy
            // 
            this._enemy.Name = "_enemy";
            this._enemy.Size = new System.Drawing.Size(67, 21);
            this._enemy.Text = "enemy : ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(326, 436);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(117, 25);
            this.textBox3.TabIndex = 7;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Jungle";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox3_MouseClick);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(326, 470);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(117, 25);
            this.textBox4.TabIndex = 8;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Ocean";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox4_MouseClick);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(326, 504);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(117, 25);
            this.textBox5.TabIndex = 9;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "Field";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox5_MouseClick);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(514, 504);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(117, 25);
            this.textBox6.TabIndex = 12;
            this.textBox6.TabStop = false;
            this.textBox6.Text = "x 3";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox6_MouseClick);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(514, 470);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(117, 25);
            this.textBox7.TabIndex = 11;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "x 2";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox7_MouseClick);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(514, 436);
            this.textBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(117, 25);
            this.textBox8.TabIndex = 10;
            this.textBox8.TabStop = false;
            this.textBox8.Text = "x 1";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox8_MouseClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(657, 425);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(225, 119);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "←→ : 이동  ctrl + 방향키 : 회피\n↑ : 점프               z : 슈퍼바디\nSpace : 사격            x : " +
    "광역기\na : 근접공격             c : 궁극기\n                    (키다운시간비례)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Map";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Speed";
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 576);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Pan);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MyForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MyForm_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pan;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer jumpTimer;
        private System.Windows.Forms.Timer bulletTimer;
        private System.Windows.Forms.ToolStripStatusLabel hp;
        private System.Windows.Forms.ToolStripProgressBar hpBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar mpBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel enemy;
        private System.Windows.Forms.Timer MapTimer;
        private System.Windows.Forms.Timer blockMakeTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _HP;
        private System.Windows.Forms.ToolStripProgressBar _hpBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripProgressBar _mpBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel _enemy;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

