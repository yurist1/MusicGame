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
    public partial class UcLyricTrackBar : UserControl
    {
        
        public UcLyricTrackBar()
        {
            InitializeComponent();
            init();
        }
        private void init() 
        {
            lbCount.Text = "0";
        }
    }
}
