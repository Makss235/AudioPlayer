using AudioPlayer.Widgets.Playlists;
using System.Windows.Controls;
using System.Windows;

namespace AudioPlayer.Windows.MainWindow
{
    public partial class MainWindow
    {
        private Grid mainFieldGrid;

        private Grid ICMainField()
        {
            mainFieldGrid = new Grid();
            mainFieldGrid.Children.Add(new PlaylistPage(mainFieldGrid.Width,
                mainFieldGrid.Height,
                Visibility.Visible));

            Grid.SetRow(mainFieldGrid, 0);
            Grid.SetColumn(mainFieldGrid, 2);
            return mainFieldGrid;
        }
    }
}
