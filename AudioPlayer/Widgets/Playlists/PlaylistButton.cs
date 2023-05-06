using System.Windows.Controls;
using System.Windows.Media;

namespace AudioPlayer.Widgets.Playlists
{
    public class PlaylistButton : UserControl
    {
        public PlaylistPage PlaylistPage { get; set; }

        private Border mainBorder;

        public PlaylistButton()
        {
            Height = 50;

            mainBorder = new Border();
            mainBorder.Background = Brushes.AliceBlue;
            Content = mainBorder;
        }
    }
}
