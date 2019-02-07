namespace Loginform1
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        ///
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.modebtt = new System.Windows.Forms.Button();
            this.exutbtt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.deadcountlb = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.restatrbtt = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.deadnumlb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("start.BackgroundImage")));
            this.start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.start.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.start.Location = new System.Drawing.Point(373, 67);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(158, 63);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click2);
            this.start.Click += new System.EventHandler(this.start_Click1);
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 75;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "처치점수 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(92, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "0";
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(296, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "40";
            // 
            // modebtt
            // 
            this.modebtt.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modebtt.Location = new System.Drawing.Point(26, 564);
            this.modebtt.Name = "modebtt";
            this.modebtt.Size = new System.Drawing.Size(75, 23);
            this.modebtt.TabIndex = 7;
            this.modebtt.Text = "단발";
            this.modebtt.UseVisualStyleBackColor = true;
            this.modebtt.Click += new System.EventHandler(this.modebtt_Click);
            // 
            // exutbtt
            // 
            this.exutbtt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exutbtt.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exutbtt.Location = new System.Drawing.Point(26, 593);
            this.exutbtt.Name = "exutbtt";
            this.exutbtt.Size = new System.Drawing.Size(75, 23);
            this.exutbtt.TabIndex = 8;
            this.exutbtt.Text = "끝내기";
            this.exutbtt.UseVisualStyleBackColor = true;
            this.exutbtt.Click += new System.EventHandler(this.exutbtt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(443, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Location = new System.Drawing.Point(371, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "발사 탄 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(249, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(423, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "※처치점수와 명중점수가 가까울수록 명사수입니다.※";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(371, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "처치점수";
            // 
            // deadcountlb
            // 
            this.deadcountlb.AutoSize = true;
            this.deadcountlb.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.deadcountlb.Location = new System.Drawing.Point(493, 215);
            this.deadcountlb.Name = "deadcountlb";
            this.deadcountlb.Size = new System.Drawing.Size(12, 12);
            this.deadcountlb.TabIndex = 14;
            this.deadcountlb.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(371, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "명중점수";
            // 
            // restatrbtt
            // 
            this.restatrbtt.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.restatrbtt.Location = new System.Drawing.Point(373, 296);
            this.restatrbtt.Name = "restatrbtt";
            this.restatrbtt.Size = new System.Drawing.Size(75, 23);
            this.restatrbtt.TabIndex = 16;
            this.restatrbtt.Text = "Restart";
            this.restatrbtt.UseVisualStyleBackColor = true;
            this.restatrbtt.Click += new System.EventHandler(this.restatrbtt_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(470, 296);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // deadnumlb
            // 
            this.deadnumlb.AutoSize = true;
            this.deadnumlb.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.deadnumlb.Location = new System.Drawing.Point(493, 253);
            this.deadnumlb.Name = "deadnumlb";
            this.deadnumlb.Size = new System.Drawing.Size(12, 12);
            this.deadnumlb.TabIndex = 18;
            this.deadnumlb.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(926, 681);
            this.Controls.Add(this.deadnumlb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.restatrbtt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.deadcountlb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exutbtt);
            this.Controls.Add(this.modebtt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(926, 681);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(926, 681);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Load += new System.EventHandler(this.Form1_Load1);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown1);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button modebtt;
        private System.Windows.Forms.Button exutbtt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label deadcountlb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button restatrbtt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label deadnumlb;

    }
}