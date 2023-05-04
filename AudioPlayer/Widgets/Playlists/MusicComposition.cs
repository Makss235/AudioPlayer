using System.Collections.Generic;
using System.Windows.Controls;

namespace AudioPlayer.Widgets.Playlists
{
    public class MusicComposition : UserControl
    {
        public string CompositionName { get; set; }
        public string AlbumName { get; set; }
        public bool IsLiked { get; set; }
        public List<string> Playlists { get; set; }

        public MusicComposition()
        {

        }
    }
}
