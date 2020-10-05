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
        static void onEvent1(object sender)
        {
            string objName = ((UcGameType)sender).Name;
            Console.WriteLine("Object's name: " + objName);
        }
        private void InitEvent()
        {
            //오픈파일콜백
            this.ucOpenFile1.GetPath += new EventHandler(GetDirectory);
            //뮤직 타입
            this.ucGameType1.MyEvent += new EventHandler(GetGameType);
            //정답
            this.ucGameResult1.GetResult += new EventHandler(GetResult);


        }


        private void InitControl()
        {
            lbMusicCount.Text = $"문제 {MUSICAMOUNT}개";


        }


        private void BtnPrev_Click()
        {
            // 이전 곡
            if (--INDEXMUSIC < 0)
            {
                INDEXMUSIC = MUSICAMOUNT - 1;
            }

            SetGame(INDEXMUSIC);
        }

        private void BtnNext_Click()
        {
            // 다음 곡
            if (++INDEXMUSIC >= MUSICAMOUNT)
            {
                INDEXMUSIC = 0;
            }

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

                    //this.ucGameContents1.Text = lylics[0];
                    //SetTrackBar(lylics.Length);
                    //  rtbContents.Text = item.Value[0];
                    // Tts(item.Value);
                    break;
                }

            }

            SetGameType();
        }


        //event 1개씩 만들기
        //
        //의존성(부모 -> 자식)역전
        //자식 -> 부모
        //


        private void SetGameType() 
        {
            if (lylics.Count() > 0) 
            {
            //ucGameTypdp Lyric count 인자 넘기기 
            this.ucGameType1.SetGameType(lylics.Count()-1);
            //game contents 보여주기
                SetGameContents(lylics[0]);
            }

        }
        private void SetGameContents(string contents) 
        {
            if ( GAME_TYPE == 0)
            {
                this.ucGameContents1.SetGameContents(contents);
            }
            else 
            {
                this.ucGameContents1.SetGameContents("PLAY 버튼을 눌러 노래 및 가사를 들어보세요~");
            }
            

        }
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
        public void GetResult(string answer) 
        {
            if(result != null)
            SetGameContents("정답 !!! "+result.Keys.ToList()[INDEXMUSIC]);
        }

        public void GetGameType(string gameType)
        {
            if (lylics != null)
            {
                if (gameType.Equals("++"))
                {
                    BtnNext_Click();
                }
                else if (gameType.Equals("--")) 
                {
                    BtnPrev_Click();
                }
                else if (gameType.Contains("/"))
                {
                    GAME_TYPE = int.Parse(gameType.Split('/').First());

                    if (GAME_TYPE == 0)
                    {
                        if (lylics.Count() > 0)
                            SetGameContents(lylics[int.Parse(gameType.Split('/').Last())]);
                    }
                    else if (GAME_TYPE == 1)
                    {
                        SetGameContents("");
                        if(gameType.Contains("play"))
                            PlayMusic();
                    }
                    else
                    {
                        SetGameContents("");
                        if (gameType.Contains("play"))
                            Tts(lylics);
                    }
         

                }
                else
                {
                    GAME_TYPE = int.Parse(gameType);
                    if (GAME_TYPE == 0)
                    {
                        if (lylics.Count() > 0)
                            SetGameContents(lylics[0]);
                    }
                    else if (GAME_TYPE == 1)
                    {
                        SetGameContents("");
                    }
                    else
                    {
                        SetGameContents("");
                    }


                }
            }
         
        }
        private void PlayMusic() 
        {
            if (resultPath == null || resultPath.Length == 0)
            {
                return;
            }

            musicPlayer.SetMusic(resultPath[INDEXMUSIC]);
            musicPlayer.PlayMusic();
            InitTimer();
        }
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
            return isSuccess;
        }
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
