namespace MusicGame
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.ucOpenFile1 = new MusicGame.UcOpenFile();
            this.ucGameResult1 = new MusicGame.UcGameResult();
            this.ucGameContents1 = new MusicGame.UcGameContents();
            this.ucGameType1 = new MusicGame.UcGameType();
            this.lbMusicCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // ucOpenFile1
            // 
            this.ucOpenFile1.Location = new System.Drawing.Point(-1, 1);
            this.ucOpenFile1.Name = "ucOpenFile1";
            this.ucOpenFile1.Size = new System.Drawing.Size(1134, 83);
            this.ucOpenFile1.TabIndex = 1;
            // 
            // ucGameResult1
            // 
            this.ucGameResult1.Location = new System.Drawing.Point(19, 457);
            this.ucGameResult1.Name = "ucGameResult1";
            this.ucGameResult1.Size = new System.Drawing.Size(1094, 150);
            this.ucGameResult1.TabIndex = 2;
            // 
            // ucGameContents1
            // 
            this.ucGameContents1.Location = new System.Drawing.Point(-1, 319);
            this.ucGameContents1.Name = "ucGameContents1";
            this.ucGameContents1.Size = new System.Drawing.Size(1129, 167);
            this.ucGameContents1.TabIndex = 3;
            // 
            // ucGameType1
            // 
            this.ucGameType1.Location = new System.Drawing.Point(-1, 81);
            this.ucGameType1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucGameType1.Name = "ucGameType1";
            this.ucGameType1.Size = new System.Drawing.Size(1406, 250);
            this.ucGameType1.TabIndex = 4;
            // 
            // lbMusicCount
            // 
            this.lbMusicCount.AutoSize = true;
            this.lbMusicCount.Location = new System.Drawing.Point(262, 288);
            this.lbMusicCount.Name = "lbMusicCount";
            this.lbMusicCount.Size = new System.Drawing.Size(45, 15);
            this.lbMusicCount.TabIndex = 5;
            this.lbMusicCount.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 598);
            this.Controls.Add(this.lbMusicCount);
            this.Controls.Add(this.ucGameType1);
            this.Controls.Add(this.ucGameContents1);
            this.Controls.Add(this.ucGameResult1);
            this.Controls.Add(this.ucOpenFile1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "노래 맞추자";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private UcOpenFile ucOpenFile1;
        private UcGameResult ucGameResult1;
        private UcGameContents ucGameContents1;
        private UcGameType ucGameType1;
        private System.Windows.Forms.Label lbMusicCount;
    }
}

