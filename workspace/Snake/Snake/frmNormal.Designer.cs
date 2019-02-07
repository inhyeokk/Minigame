namespace Snake
{
    partial class frmNormal
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
            this.lblMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMenu
            // 
            this.lblMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMenu.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenu.Location = new System.Drawing.Point(0, 0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(340, 243);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "SNAKE\r\n\r\n방향키를 이용해서 조작합니다\r\n일시정지하고싶다면 스페이스바를 누르세요\r\n\r\n게임설명: \r\n빨간먹이를 1개먹으면 뱀이 성장하고\r\n5" +
    "개를 먹으면 노란먹이가 나타납니다.\r\n노란먹이를 먹으면 단계가 올라갑니다\r\n\r\n엔터키를 누르면 시작합니다\r\n";
            this.lblMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 243);
            this.Controls.Add(this.lblMenu);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 290);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(358, 290);
            this.Name = "frmNormal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake - 점수: 1 1단계";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMenu;
    }
}

