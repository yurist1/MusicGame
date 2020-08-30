namespace MusicGame
{
    partial class UcLyricTrackBar
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
            this.tkbCount = new System.Windows.Forms.TrackBar();
            this.lbCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tkbCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tkbCount
            // 
            this.tkbCount.Location = new System.Drawing.Point(-3, 15);
            this.tkbCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tkbCount.Name = "tkbCount";
            this.tkbCount.Size = new System.Drawing.Size(879, 56);
            this.tkbCount.TabIndex = 8;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(451, 56);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(45, 15);
            this.lbCount.TabIndex = 9;
            this.lbCount.Text = "label1";
            // 
            // UcLyricTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.tkbCount);
            this.Name = "UcLyricTrackBar";
            this.Size = new System.Drawing.Size(952, 100);
            ((System.ComponentModel.ISupportInitialize)(this.tkbCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tkbCount;
        private System.Windows.Forms.Label lbCount;
    }
}
