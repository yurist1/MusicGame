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
            this.tkbControl = new System.Windows.Forms.TrackBar();
            this.lbCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tkbControl)).BeginInit();
            this.SuspendLayout();
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "가사 보기",
            "노래 듣기"});
            this.cbType.Location = new System.Drawing.Point(14, 19);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 20);
            this.cbType.TabIndex = 0;
            // 
            // tkbControl
            // 
            this.tkbControl.Location = new System.Drawing.Point(141, 19);
            this.tkbControl.Name = "tkbControl";
            this.tkbControl.Size = new System.Drawing.Size(302, 45);
            this.tkbControl.TabIndex = 1;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(12, 52);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(9, 10);
            this.lbCount.TabIndex = 2;
            this.lbCount.Text = "0";
            // 
            // UcGameType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.tkbControl);
            this.Controls.Add(this.cbType);
            this.Name = "UcGameType";
            this.Size = new System.Drawing.Size(470, 80);
            ((System.ComponentModel.ISupportInitialize)(this.tkbControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TrackBar tkbControl;
        private System.Windows.Forms.Label lbCount;
    }
}
