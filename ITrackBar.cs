using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGame
{
    interface ITrackBar
    {
        void Init();
        void InitEvent();
        void TkbCount_ValueChanged(object sender, EventArgs e);
        
    }
}
