using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicGame
{
    public partial class UcMusicTrackBar : UserControl
    {
        private int MusicMaxCount = 5;
        public UcMusicTrackBar()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.lbCount.Text = "0";
            this.btnPlay.Text = MusicGame.Properties.Resources.play;
            this.tkbCount.Maximum = MusicMaxCount;
            //이벤트초기화
            InitEvent();
        }
        private void InitEvent()
        {
            tkbCount.ValueChanged += TkbCount_ValueChanged;

        }
        /// <summary>
        /// 트랙바 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TkbCount_ValueChanged(object sender, EventArgs e)
        {
            lbCount.Text = ((TrackBar)sender).Value.ToString();

        }
    }
}
