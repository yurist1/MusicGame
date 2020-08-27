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
        // 0 : 가사 보기, 1 : 노래 듣기
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
        private delegate void EventHandler(string answer);
        private event EventHandler Answer;

        private MusicPlayer musicPlayer;
        public MainForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            // 이벤트 초기화
            InitEvent();
            // 컨트롤 초기화
            InitControl();
            // 객체 초기화
            InitObject();
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
           
            btnOpen.Click += BtnOpen_Click;
            btnResult.Click += BtnResult_Click;
            btnNext.Click += BtnNext_Click;
            btnPrev.Click += BtnPrev_Click;
            

            tkbCount.ValueChanged += TkbCount_ValueChanged;

            // 콤보박스 상태 변경 이벤트
            cbType.SelectedValueChanged += CbType_SelectedValueChanged;
        }
        Button btnPlay;
        private void CbType_SelectedValueChanged(object sender, EventArgs e)
        {

            if (((ComboBox)sender).SelectedItem.Equals("가사 보기"))
            {
                GAME_TYPE = 0;
                tkbCount.Width = tkbCount.Width;

                // 버튼 되돌리기
                if (this.Controls.Contains(btnPlay) && btnPlay != null)
                {
                    tkbCount.Width = tkbCount.Width + 100;

                    this.Controls.Remove(btnPlay);
                }

            }
            else
            {
                GAME_TYPE = 1;
                tkbCount.Width = tkbCount.Width - 100;
                btnPlay = new Button();
                btnPlay.Location = new Point(880, 70);
                btnPlay.Width = 100;
                btnPlay.Height = 30;
                btnPlay.Text = "Play";
                this.Controls.Add(btnPlay);

                btnPlay.Click += BtnPlay_Click;
            }
            if (lylics != null)
            {
                SetTrackBar(lylics.Length);
            }

        }

        /// <summary>
        /// 음악 재생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (resultPath == null || resultPath.Length == 0)
            {
                return;
            }

            musicPlayer.SetMusic(resultPath[INDEXMUSIC]);
            musicPlayer.PlayMusic();
            InitTimer();
        }

        /// <summary>
        /// 트랙바 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TkbCount_ValueChanged(object sender, EventArgs e)
        {
            lbCount.Text = ((TrackBar)sender).Value.ToString();
            if (GAME_TYPE == 0)
            {
                
                if (lylics != null)
                {
                    try
                    {
                        NexusTrackBar(lylics[((TrackBar)sender).Value]);
                    }
                    catch
                    {
                        //ignore
                    }
                }
            }
            else
            {
                MusicMaxCount = ((TrackBar)sender).Value;
            }
        }

        private void InitControl()
        {
            lbCount.Text = "0";
            cbType.Items.Add("가사 보기");
            cbType.Items.Add("노래 듣기");

            cbType.SelectedIndex = 0;
        }

        private void SetTrackBar(int count = 0)
        {
            if (GAME_TYPE == 0)
            {
                tkbCount.Maximum = count;
            }
            else
            {
                tkbCount.Maximum = 5;
            }
        }

        private void NexusTrackBar(string lylics)
        {
            rtbContents.Text = lylics;
        }

        private void GetLylics()
        {

        }


        private void BtnPrev_Click(object sender, EventArgs e)
        {
            // 이전 곡
            if (--INDEXMUSIC < 0)
            {
                INDEXMUSIC = MUSICAMOUNT -1 ;
            }
            
            SetGame(INDEXMUSIC);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            // 다음 곡
            if (++INDEXMUSIC >= MUSICAMOUNT)
            {
                INDEXMUSIC = 0;
            }

            SetGame(INDEXMUSIC);
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            string path = string.Empty;

            // 디렉토리 오픈
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                path = folderBrowserDialog.SelectedPath;

                tbPath.Text = path;
            }

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            result = id3Utils.GetId3Lylics(path).Item1;
            resultPath = id3Utils.GetId3Lylics(path).Item2;
            MUSICAMOUNT = result.Count();

            SetGame(INDEXMUSIC);
      
        }

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

                rtbContents.Text = lylics[0];
                SetTrackBar(lylics.Length);
                    //  rtbContents.Text = item.Value[0];
                    // Tts(item.Value);
                    break;
                }
               
            }
        }
        private void BtnResult_Click(object sender, EventArgs e)
        {
            // 결과 보여주기
            //Tts(lylics);
            //정답보여주기 
            Answer += new EventHandler(ShowAnswer);
            Action(INDEXMUSIC);

        }

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

        /// <summary>
        /// 음원에서 가사 추출
        /// </summary>
        /// <returns>가사</returns>
        private string MusicToLyrics()
        {
            return "";
        }

        /// <summary>
        /// 음성 듣기(tts)
        /// </summary>
        private bool Tts(string[] lyrics)
        {
            bool isSuccess = false;

            try
            {
                speechSynthesizer.SetOutputToDefaultAudioDevice();

                speechSynthesizer.SelectVoice("Microsoft Heami Desktop");

                //speechSynthesizer.Rate = -10;

                foreach (var text in lyrics)
                {
                    //byte[] bytes = Encoding.Default.GetBytes(text);

                    //string encodingText = Encoding.UTF8.GetString(bytes);
                    //speechSynthesizer.Speak(encodingText);
                    speechSynthesizer.Speak(text);
                }

                isSuccess = true;

            }
            catch (IOException e)
            {
                isSuccess = false;
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            finally
            {
                speechSynthesizer.Dispose();
            }
            // string sample = "왜들 그리 다운돼있어? 뭐가 문제야 say something"
            //+ "분위기가 겁나 싸해 요새는 이런 게 유행인가"
            //+ "왜들 그리 재미없어? 아 그건 나도 마찬가지"
            //+ "Tell me what I got to do 급한 대로 블루투스 켜"
            //+ "아무 노래나 일단 틀어 아무거나 신나는 걸로"
            //+ "아무렇게나 춤춰 아무렇지 않아 보이게"
            //+ "아무 생각 하기 싫어 아무개로 살래 잠시"
            //+ "I'm sick and tired of my every day, keep it up 한 곡 더"
            //+ "아무 노래나 일단 틀어 아무렴 어때 it's so boring"
            //+ "아무래도 refresh가 시급한 듯해 쌓여가 스트레스가"
            //+ "배꼽 빠질 만큼만 폭소하고 싶은 날이야"
            //+ "What up my dawgs? 어디야 너희 올 때 병맥주랑 까까 몇 개 사 와 uh"
            //+ "클럽은 구미가 잘 안 당겨 우리 집 거실로 빨랑 모여"
            //+ "외부인은 요령껏 차단 시켜 밤새 수다 떨 시간도 모자라"
            //+ "누군 힘들어 죽겠고 누군 축제 괜히 싱숭생숭 I want my youth back"
            //+ "좀 전까지 왁자지껄 하다 한 명 두 명씩 자릴 떠"
            //+ "왜들 그리 다운돼있어? 뭐가 문제야 say something"
            //+ "분위기가 겁나 싸해 요새는 이런 게 유행인가"
            //+ "왜들 그리 재미없어? 아 그건 나도 마찬가지"
            //+ "Tell me what I got to do 급한 대로 블루투스 켜"
            //+ "아무 노래나 일단 틀어 아무거나 신나는 걸로"
            //+ "아무렇게나 춤춰 아무렇지 않아 보이게"
            //+ "아무 생각 하기 싫어 아무개로 살래 잠시"
            //+ "I'm sick and tired of my every day, keep it up 한 곡 더"
            //+ "떠나질 못할 바엔"
            //+ "창밖은 쳐다도 안 봐"
            //+ "회까닥해서 추태를 부려도"
            //+ "No worries at all 이미지 왜 챙겨 그래 봤자 우리끼린데"
            //+ "Ooh 늦기 전에 막판 스퍼트 20대가 얼마 안 남았어"
            //+ "편한 옷으로 갈아입어 you look nice, get 'em high"
            //+ "얼핏 보면 그냥 코미디 이렇게 무해한 파티 처음이지?"
            //+ "만감이 교차하는 새벽 2시경 술잔과 감정이 소용돌이쳐"
            //+ "왜들 그리 다운돼있어? 뭐가 문제야 say something"
            //+ "분위기가 겁나 싸해 요새는 이런 게 유행인가"
            //+ "왜들 그리 재미없어? 아 그건 나도 마찬가지"
            //+ "Tell me what I got to do 급한 대로 블루투스 켜"
            //+ "아무 노래나 일단 틀어 아무거나 신나는 걸로"
            //+ "아무렇게나 춤춰 아무렇지 않아 보이게"
            //+ "아무 생각 하기 싫어 아무개로 살래 잠시"
            //+ "I'm sick and tired of my every day, keep it up 한 곡 더"
            //+ "아무 노래나 일단"
            //+ "La - la - la, la - la - la, la - la - la - la"
            //+ "La - la - la, la - la - la, la - la - la - la"
            //+ "아무 노래 아무 노래 아무 노래나 틀어봐"
            //+ "아무 노래 아무 노래 아무 노래나 틀어봐"
            //+ "아무 노래 아무 노래 아무 노래나 틀어봐"
            //+ "아무 노래 아무 노래 아무 노래나 KOZ";

            //            speechSynthesizer.Speak(sample);

            return isSuccess;
        }

        private void ShowAnswer(string answer) 
        {
            rtbContents.Text = answer;
        }
        private void Action(int index) 
        {
            //int num = 0;
            //foreach (var item in result)
            //{
            //    if (num == index)
            //    {
            //        Answer($"정답: {item.Key}");
            //        break;
            //    }
            //    else { num++; }
            //}

            for (int i = 0; i < result.Count(); i++)
            {
                if (i == index) 
                {
                    Answer($"정답 : {result.Keys.ToList()[i]}");
                    break;
                }
            }
        }
    }
}
