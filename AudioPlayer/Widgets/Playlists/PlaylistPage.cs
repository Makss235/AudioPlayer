using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace AudioPlayer.Widgets.Playlists
{
    public class PlaylistPage : Border
    {
        public string PlaylistName { get; set; }
        public ObservableCollection<MusicComposition> MusicCompositions { get; set; }

        public PlaylistPage()
        {

        }
    }
}
