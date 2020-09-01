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
    public partial class UcGameType : UserControl
    {
        // 0 : 가사 보기, 1 : 노래 듣기 , 2 : 가사 듣기
        private int GAME_TYPE = 0;
        int _LyricCount = 0; 
        public UcGameType()
        {
            InitializeComponent();
            Init();
        }
        private void Init() 
        {
            cbType.SelectedIndex = 0;
            //객체 초기화
            InitObject();
            //이벤트 초기화
            InitEvent();
            this.ucLyricTrackBar1.Visible = true;
            this.ucMusicTrackBar1.Visible = false;

        }
        private void InitObject()
        {

        }
        private void InitEvent()
        {
       
            //콤보박스 상태 변경 이벤트
            cbType.SelectedValueChanged += CbType_SelectedValueChanged;

        }
        private void CbType_SelectedValueChanged(object sender, EventArgs e)
        {

            if (((ComboBox)sender).SelectedItem.Equals("가사 보기"))
            {
                this.ucLyricTrackBar1.Visible = true;
                this.ucMusicTrackBar1.Visible = false;
                
                GAME_TYPE = 0;
                
            }
            else if (((ComboBox)sender).SelectedItem.Equals("노래 듣기"))
            {
                this.ucLyricTrackBar1.Visible = false;
                this.ucMusicTrackBar1.Visible = true;
                GAME_TYPE = 1;
            }
            else 
            {
                this.ucLyricTrackBar1.Visible = false;
                this.ucMusicTrackBar1.Visible = true;
                GAME_TYPE = 2;
            }
            //콜백으로 Main에 게임타입 전달하기 

        }

        public void SetGameType(int lyricCount) 
        {
            if (GAME_TYPE == 0)
            {
                if (lyricCount >= 0)
                {
                    this.ucLyricTrackBar1.SetMaxTrack(lyricCount);
                }
            }
         
            
        }
    }
}
