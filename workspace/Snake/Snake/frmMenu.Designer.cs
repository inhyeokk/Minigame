namespace Snake
{
    partial class frmMenu
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
            this.mainImg = new System.Windows.Forms.PictureBox();
            this.lbMain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainImg)).BeginInit();
            this.SuspendLayout();
            // 
            // mainImg
            // 
            this.mainImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mainImg.Location = new System.Drawing.Point(0, 0);
            this.mainImg.Name = "mainImg";
            this.mainImg.Size = new System.Drawing.Size(432, 355);
            this.mainImg.TabIndex = 0;
            this.mainImg.TabStop = false;
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.Font = new System.Drawing.Font("휴먼아미체", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbMain.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbMain.Location = new System.Drawing.Point(56, 257);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(364, 87);
            this.lbMain.TabIndex = 1;
            this.lbMain.Text = "Press Enter";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 353);
            this.Controls.Add(this.lbMain);
            this.Controls.Add(this.mainImg);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 400);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "미니게임천국";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMenu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mainImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainImg;
        private System.Windows.Forms.Label lbMain;
    }
}