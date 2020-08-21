using Id3;
using Id3.InfoFx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGame
{
    public class Id3Utils
    {
        public string[] GetId3Path(string fileDiretory) 
        {
            string[] path = Directory.GetFiles(fileDiretory, "*.mp3");
            return path;
        }
        public (Dictionary<string, List<string>>, string[]) GetId3Lylics(string fileDiretory)
        {
            Dictionary<string, List<string>> dicMusics = new Dictionary<string, List<string>>();
            string[] musicFiles = Directory.GetFiles(fileDiretory, "*.mp3");
            foreach (string musicFile in musicFiles)
            {
                using (var mp3 = new Mp3(musicFile))
                {
                    Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2X);
                    
                    dicMusics.Add(tag.Title, tag.Lyrics.ToList().Select(d => d.Lyrics).ToList());
                }
            }

            return (dicMusics, musicFiles);
        }
    }
}
