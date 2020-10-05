using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MusicGame
{
    public delegate void EventHandler(string path);
 
    public partial class UcOpenFile : UserControl
    {
        public event EventHandler GetPath;

        public UcOpenFile()
        {
            InitializeComponent();
            //초기화
            init();
        }

        private void init() 
        {
            // 이벤트 초기화
            InitEvent();
        }
        private void InitEvent() 
        {
            //클릭이벤트 지정
            btnOpen.Click += BtnOpen_Click;
        }

        public void BtnOpen_Click(object sender, EventArgs e)
        {
            string path = string.Empty;

            // 디렉토리 오픈
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                path = folderBrowserDialog.SelectedPath;
                tbPath.Text = path;
                //이벤트 핸들러 액션
                Action(path);
            }
            //null check
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

        }
        public void Action(string path)
        {
            //path 전달

            GetPath(path);
        }

    }
}
