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
    public partial class UcGameContents : UserControl
    {
        public UcGameContents()
        {
            InitializeComponent();
            Init();
        }
        private void Init() 
        {
            this.rtbContents.Text = "";
        }
        public void SetGameContents(string contents) 
        {
            this.rtbContents.Text = contents;
        }
    }
}
