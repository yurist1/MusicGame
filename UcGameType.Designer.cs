namespace MusicGame
{
    partial class UcGameType
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.ucLyricTrackBar1 = new MusicGame.UcLyricTrackBar();
            this.ucMusicTrackBar1 = new MusicGame.UcMusicTrackBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "가사 보기",
            "노래 듣기",
            "가사 듣기"});
            this.cbType.Location = new System.Drawing.Point(16, 24);
            this.cbType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(138, 23);
            this.cbType.TabIndex = 0;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(16, 129);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(86, 100);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(124, 129);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 100);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // ucLyricTrackBar1
            // 
            this.ucLyricTrackBar1.Location = new System.Drawing.Point(190, 11);
            this.ucLyricTrackBar1.Name = "ucLyricTrackBar1";
            this.ucLyricTrackBar1.Size = new System.Drawing.Size(952, 100);
            this.ucLyricTrackBar1.TabIndex = 7;
            // 
            // ucMusicTrackBar1
            // 
            this.ucMusicTrackBar1.Location = new System.Drawing.Point(199, 0);
            this.ucMusicTrackBar1.Name = "ucMusicTrackBar1";
            this.ucMusicTrackBar1.Size = new System.Drawing.Size(1031, 111);
            this.ucMusicTrackBar1.TabIndex = 2;
            // 
            // UcGameType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucLyricTrackBar1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.ucMusicTrackBar1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UcGameType";
            this.Size = new System.Drawing.Size(1406, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbType;
        private UcMusicTrackBar ucMusicTrackBar1;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private UcLyricTrackBar ucLyricTrackBar1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
