using AudioPlayer.Widgets.Base;
using AudioPlayer.Widgets.Playlists.Audio;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AudioPlayer.Widgets.Playlists
{
    public class PlaylistPage : PageBase
    {
        public string PlaylistName { get; set; }
        public ObservableCollection<AudioElement> AudioElements { get; set; }

        private Border mainBorder;

        public PlaylistPage(double width, double height, Visibility visibility) : 
            base(width, height, visibility)
        {
            mainBorder = new Border();
            mainBorder.Background = Brushes.Bisque;
            mainBorder.BorderThickness = new Thickness(10);
            mainBorder.BorderBrush = Brushes.Black;
            Content = mainBorder;
        }
    }
}
