namespace Snake
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.normal_Btn = new System.Windows.Forms.Button();
            this.Img = new System.Windows.Forms.PictureBox();
            this.helpBtn = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.replayBtn = new System.Windows.Forms.Button();
            this.orPanel = new System.Windows.Forms.Panel();
            this.deadImg = new System.Windows.Forms.PictureBox();
            this.lbScore = new System.Windows.Forms.Label();
            this.stopBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Img)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.orPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deadImg)).BeginInit();
            this.SuspendLayout();
            // 
            // normal_Btn
            // 
            this.normal_Btn.AutoSize = true;
            this.normal_Btn.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.normal_Btn.Location = new System.Drawing.Point(233, 119);
            this.normal_Btn.Name = "normal_Btn";
            this.normal_Btn.Size = new System.Drawing.Size(83, 38);
            this.normal_Btn.TabIndex = 0;
            this.normal_Btn.Text = "시   작";
            this.normal_Btn.UseVisualStyleBackColor = true;
            this.normal_Btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Img
            // 
            this.Img.Location = new System.Drawing.Point(11, 18);
            this.Img.MaximumSize = new System.Drawing.Size(200, 200);
            this.Img.MinimumSize = new System.Drawing.Size(200, 200);
            this.Img.Name = "Img";
            this.Img.Size = new System.Drawing.Size(200, 200);
            this.Img.TabIndex = 4;
            this.Img.TabStop = false;
            // 
            // helpBtn
            // 
            this.helpBtn.AutoSize = true;
            this.helpBtn.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.helpBtn.Location = new System.Drawing.Point(233, 180);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(83, 38);
            this.helpBtn.TabIndex = 5;
            this.helpBtn.Text = "도움말";
            this.helpBtn.UseVisualStyleBackColor = true;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.Img);
            this.mainPanel.Controls.Add(this.helpBtn);
            this.mainPanel.Controls.Add(this.normal_Btn);
            this.mainPanel.Location = new System.Drawing.Point(1, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(340, 243);
            this.mainPanel.TabIndex = 6;
            // 
            // replayBtn
            // 
            this.replayBtn.AutoSize = true;
            this.replayBtn.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.replayBtn.Location = new System.Drawing.Point(118, 186);
            this.replayBtn.Name = "replayBtn";
            this.replayBtn.Size = new System.Drawing.Size(102, 38);
            this.replayBtn.TabIndex = 7;
            this.replayBtn.Text = "다시하기";
            this.replayBtn.UseVisualStyleBackColor = true;
            this.replayBtn.Click += new System.EventHandler(this.replayBtn_Click);
            // 
            // orPanel
            // 
            this.orPanel.Controls.Add(this.backBtn);
            this.orPanel.Controls.Add(this.deadImg);
            this.orPanel.Controls.Add(this.lbScore);
            this.orPanel.Controls.Add(this.stopBtn);
            this.orPanel.Controls.Add(this.replayBtn);
            this.orPanel.Location = new System.Drawing.Point(0, 3);
            this.orPanel.Name = "orPanel";
            this.orPanel.Size = new System.Drawing.Size(341, 245);
            this.orPanel.TabIndex = 8;
            // 
            // deadImg
            // 
            this.deadImg.Location = new System.Drawing.Point(13, 12);
            this.deadImg.MaximumSize = new System.Drawing.Size(150, 150);
            this.deadImg.MinimumSize = new System.Drawing.Size(150, 150);
            this.deadImg.Name = "deadImg";
            this.deadImg.Size = new System.Drawing.Size(150, 150);
            this.deadImg.TabIndex = 10;
            this.deadImg.TabStop = false;
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbScore.Location = new System.Drawing.Point(177, 44);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(152, 96);
            this.lbScore.TabIndex = 9;
            this.lbScore.Text = "점수: 1\r\n단계: 1\r\n분발하세요~";
            // 
            // stopBtn
            // 
            this.stopBtn.AutoSize = true;
            this.stopBtn.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stopBtn.Location = new System.Drawing.Point(226, 186);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(102, 38);
            this.stopBtn.TabIndex = 8;
            this.stopBtn.Text = "그만하기";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.AutoSize = true;
            this.backBtn.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.backBtn.Location = new System.Drawing.Point(10, 186);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(102, 38);
            this.backBtn.TabIndex = 11;
            this.backBtn.Text = "게임선택";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(340, 243);
            this.Controls.Add(this.orPanel);
            this.Controls.Add(this.mainPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 290);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(358, 290);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Img)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.orPanel.ResumeLayout(false);
            this.orPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deadImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button normal_Btn;
        private System.Windows.Forms.PictureBox Img;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button replayBtn;
        private System.Windows.Forms.Panel orPanel;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.PictureBox deadImg;
        private System.Windows.Forms.Button backBtn;
    }
}