using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace MusicGame
{
    public partial class MainForm : Form
    {
        // 0 : 가사 보기, 1 : 노래 듣기 , 2 : 가사 듣기
        private int GAME_TYPE = 0;
        private SpeechSynthesizer speechSynthesizer;
        private Id3Utils id3Utils;
        private string[] lylics;
        private string[] resultPath;
        private Timer timer;
        private int MusicCount = 0;
        private int MusicMaxCount = 5;
        private int INDEXMUSIC = 0;
        private int MUSICAMOUNT = 0;
        private Dictionary<string, List<string>> result;
        //private delegate void EventHandler(string answer);
    



        private MusicPlayer musicPlayer;
        public MainForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            // 컨트롤 초기화
            InitControl();
            // 객체 초기화
            InitObject();
            // 이벤트 초기화
            InitEvent();
        }

        private void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MusicCount++;
            if (MusicCount == MusicMaxCount)
            {
                MusicCount = 0;
                // 음악 중지
                musicPlayer.StopMusic();
                timer.Stop();
                timer.Dispose();
            }
        }

        private void InitObject()
        {
            speechSynthesizer = new SpeechSynthesizer();
            id3Utils = new Id3Utils();
            musicPlayer = new MusicPlayer();
            result = new Dictionary<string, List<string>>();
        }

        private void InitEvent()
        {
            //오픈파일콜백
            this.ucOpenFile1.GetPath += new EventHandler(GetDirectory);
            //뮤직 타입
            //this.ucGameType1

            //ucOpenFile.CausesValidationChanged += BtnOpen_Click;
            //btnResult.Click += BtnResult_Click;
            //btnNext.Click += BtnNext_Click;
            //btnPrev.Click += BtnPrev_Click;


            //tkbCount.ValueChanged += TkbCount_ValueChanged;

            //콤보박스 상태 변경 이벤트
            //cbType.SelectedValueChanged += CbType_SelectedValueChanged;
        }

      

        //Button btnPlay;
        //private void CbType_SelectedValueChanged(object sender, EventArgs e)
        //{

        //    if (((ComboBox)sender).SelectedItem.Equals("가사 보기"))
        //    {
        //        GAME_TYPE = 0;
        //        tkbCount.Width = tkbCount.Width;

        //        // 버튼 되돌리기
        //        if (this.Controls.Contains(btnPlay) && btnPlay != null)
        //        {
        //            tkbCount.Width = tkbCount.Width + 100;

        //            this.Controls.Remove(btnPlay);
        //        }

        //    }
        //    else
        //    {
        //        GAME_TYPE = 1;
        //        tkbCount.Width = tkbCount.Width - 100;
        //        btnPlay = new Button();
        //        btnPlay.Location = new Point(880, 70);
        //        btnPlay.Width = 100;
        //        btnPlay.Height = 30;
        //        btnPlay.Text = "Play";
        //        this.Controls.Add(btnPlay);

        //        btnPlay.Click += BtnPlay_Click;
        //    }
        //    if (lylics != null)
        //    {
        //        SetTrackBar(lylics.Length);
        //    }

        //}

        ///// <summary>
        ///// 음악 재생
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void BtnPlay_Click(object sender, EventArgs e)
        //{
        //    if (resultPath == null || resultPath.Length == 0)
        //    {
        //        return;
        //    }

        //    musicPlayer.SetMusic(resultPath[INDEXMUSIC]);
        //    musicPlayer.PlayMusic();
        //    InitTimer();
        //}

        ///// <summary>
        ///// 트랙바 변경 이벤트
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void TkbCount_ValueChanged(object sender, EventArgs e)
        //{
        //    lbCount.Text = ((TrackBar)sender).Value.ToString();
        //    if (GAME_TYPE == 0)
        //    {

        //        if (lylics != null)
        //        {
        //            try
        //            {
        //                NexusTrackBar(lylics[((TrackBar)sender).Value]);
        //            }
        //            catch
        //            {
        //                //ignore
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MusicMaxCount = ((TrackBar)sender).Value;
        //    }
        //}

        private void InitControl()
        {
            lbMusicCount.Text = $"문제 {MUSICAMOUNT}개";


        }

        //private void SetTrackBar(int count = 0)
        //{
        //    if (GAME_TYPE == 0)
        //    {
        //        tkbCount.Maximum = count;
        //    }
        //    else
        //    {
        //        tkbCount.Maximum = 5;
        //    }
        //}

        //private void NexusTrackBar(string lylics)
        //{
        //    rtbContents.Text = lylics;
        //}



        //private void BtnPrev_Click(object sender, EventArgs e)
        //{
        //    // 이전 곡
        //    if (--INDEXMUSIC < 0)
        //    {
        //        INDEXMUSIC = MUSICAMOUNT -1 ;
        //    }

        //    SetGame(INDEXMUSIC);
        //}

        //private void BtnNext_Click(object sender, EventArgs e)
        //{
        //    // 다음 곡
        //    if (++INDEXMUSIC >= MUSICAMOUNT)
        //    {
        //        INDEXMUSIC = 0;
        //    }

        //    SetGame(INDEXMUSIC);
        //}



        private void SetGame(int position)
        {
            int filePosiion = 0;
            foreach (var item in result)
            {
                if (filePosiion < position)
                {
                    filePosiion++;
                }
                else
                {
                    lylics = SplitLylics(item.Value);

                    //this.ucGameContents1.Text = lylics[0];
                    //SetTrackBar(lylics.Length);
                    //  rtbContents.Text = item.Value[0];
                    // Tts(item.Value);
                    break;
                }

            }

            SetGameType();
        }

        private void SetGameType() 
        {
            //ucGameTypdp Lyric count 인자 넘기기 
            this.ucGameType1.SetGameType(lylics.Count());
            //game contents 보여주기
            SetGameContents();

        }
        private void SetGameContents() { }
        //    private void BtnResult_Click(object sender, EventArgs e)
        //    {
        //        // 결과 보여주기
        //        //Tts(lylics);
        //        //정답보여주기 
        //        Answer += new EventHandler(ShowAnswer);
        //        Action(INDEXMUSIC);

        //    }

        /// <summary>
        /// 가사 분리(줄 단위)
        /// </summary>
        /// <param name="lylics">가사</param>
        /// <returns>분리된 가사</returns>
        private string[] SplitLylics(List<string> lylics)
        {
            string tempItem = lylics[0];
            List<string> result = new List<string>();

            foreach (var item in tempItem.Split('\n'))
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        //    /// <summary>
        //    /// 음원에서 가사 추출
        //    /// </summary>
        //    /// <returns>가사</returns>
        //    private string MusicToLyrics()
        //    {
        //        return "";
        //    }

        //    /// <summary>
        //    /// 음성 듣기(tts)
        //    /// </summary>
        //    private bool Tts(string[] lyrics)
        //    {
        //        bool isSuccess = false;

        //        try
        //        {
        //            speechSynthesizer.SetOutputToDefaultAudioDevice();

        //            speechSynthesizer.SelectVoice("Microsoft Heami Desktop");

        //            //speechSynthesizer.Rate = -10;

        //            foreach (var text in lyrics)
        //            {
        //                //byte[] bytes = Encoding.Default.GetBytes(text);

        //                //string encodingText = Encoding.UTF8.GetString(bytes);
        //                //speechSynthesizer.Speak(encodingText);
        //                speechSynthesizer.Speak(text);
        //            }

        //            isSuccess = true;

        //        }
        //        catch (IOException e)
        //        {
        //            isSuccess = false;
        //        }
        //        catch (Exception ex)
        //        {
        //            isSuccess = false;
        //        }
        //        finally
        //        {
        //            speechSynthesizer.Dispose();
        //        }
        //        return isSuccess;
        //    }

        //public void ShowAnswer(string answer)
        //{
        //    //rtbContents.Text = answer;
        //}

        //private void Action(int index)
        //{
        //   //path 전달

        //        Answer(path);


        //}
        public void GetDirectory(string path)
        {
        
            result = id3Utils.GetId3Lylics(path).Item1;
            resultPath = id3Utils.GetId3Lylics(path).Item2;
            MUSICAMOUNT = result.Count();
            lbMusicCount.Text = $"문제 {MUSICAMOUNT}개";
            SetGame(INDEXMUSIC);
        }
    }
}
