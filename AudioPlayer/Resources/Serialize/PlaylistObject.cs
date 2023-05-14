using System.Collections.Generic;

namespace AudioPlayer.Resources.Serialize
{
    public class PlaylistObject
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string ID { get; set; }
        public List<string> AudioPathes { get; set; }
    }
}
