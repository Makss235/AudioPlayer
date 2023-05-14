using AudioPlayer.Widgets.Playlists;
using System.Windows.Controls;

namespace AudioPlayer.Windows.MainWindow
{
    public partial class MainWindow
    {
        private Grid menuPlaylistsGrid;

        private Grid ICMenuPlaylists()
        {
            StackPanel stackPanel = new StackPanel()
            { Orientation = Orientation.Vertical };
            stackPanel.Children.Add(new PlaylistButton(pp));

            menuPlaylistsGrid = new Grid();
            menuPlaylistsGrid.Children.Add(new PlaylistButton(pp));

            Grid.SetRow(menuPlaylistsGrid, 0);
            Grid.SetColumn(menuPlaylistsGrid, 0);
            return menuPlaylistsGrid;
        }
    }
}