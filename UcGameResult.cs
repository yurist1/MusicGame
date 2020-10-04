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
    public partial class UcGameResult : UserControl
    {
        private MainForm mMainForm;
        public UcGameResult(MainForm mainForm)
        {
            mMainForm = mainForm;
            //이걸 쓰는 순간 의존성 역전이 됨.
            //결합관계가 강력해짐

            InitializeComponent();
        }
    }
}
