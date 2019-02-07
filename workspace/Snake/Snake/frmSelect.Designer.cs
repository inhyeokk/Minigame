namespace Snake
{
    partial class frmSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelect));
            this.snakeBtn = new System.Windows.Forms.Button();
            this.bgBtn = new System.Windows.Forms.Button();
            this.purinBtn = new System.Windows.Forms.Button();
            this.ddongBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // snakeBtn
            // 
            this.snakeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("snakeBtn.BackgroundImage")));
            this.snakeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.snakeBtn.Location = new System.Drawing.Point(0, -1);
            this.snakeBtn.Name = "snakeBtn";
            this.snakeBtn.Size = new System.Drawing.Size(215, 177);
            this.snakeBtn.TabIndex = 0;
            this.snakeBtn.UseVisualStyleBackColor = true;
            this.snakeBtn.Click += new System.EventHandler(this.snakeBtn_Click);
            // 
            // bgBtn
            // 
            this.bgBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bgBtn.BackgroundImage")));
            this.bgBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bgBtn.Location = new System.Drawing.Point(218, -1);
            this.bgBtn.Name = "bgBtn";
            this.bgBtn.Size = new System.Drawing.Size(215, 177);
            this.bgBtn.TabIndex = 1;
            this.bgBtn.UseVisualStyleBackColor = true;
            this.bgBtn.Click += new System.EventHandler(this.bgBtn_Click);
            // 
            // purinBtn
            // 
            this.purinBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("purinBtn.BackgroundImage")));
            this.purinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.purinBtn.Location = new System.Drawing.Point(0, 173);
            this.purinBtn.Name = "purinBtn";
            this.purinBtn.Size = new System.Drawing.Size(215, 177);
            this.purinBtn.TabIndex = 5;
            this.purinBtn.UseVisualStyleBackColor = true;
            this.purinBtn.Click += new System.EventHandler(this.purinBtn_Click);
            // 
            // ddongBtn
            // 
            this.ddongBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ddongBtn.BackgroundImage")));
            this.ddongBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ddongBtn.Location = new System.Drawing.Point(218, 173);
            this.ddongBtn.Name = "ddongBtn";
            this.ddongBtn.Size = new System.Drawing.Size(215, 177);
            this.ddongBtn.TabIndex = 6;
            this.ddongBtn.UseVisualStyleBackColor = true;
            this.ddongBtn.Click += new System.EventHandler(this.ddongBtn_Click);
            // 
            // frmSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 353);
            this.Controls.Add(this.ddongBtn);
            this.Controls.Add(this.purinBtn);
            this.Controls.Add(this.bgBtn);
            this.Controls.Add(this.snakeBtn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 400);
            this.Name = "frmSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "미니게임천국";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button snakeBtn;
        private System.Windows.Forms.Button bgBtn;
        private System.Windows.Forms.Button purinBtn;
        private System.Windows.Forms.Button ddongBtn;
    }
}