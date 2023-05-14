using AudioPlayer.Widgets.Playlists;
using System.Windows.Controls;
using System.Windows;
using AudioPlayer.Resources.Data;

namespace AudioPlayer.Windows.MainWindow
{
    public partial class MainWindow
    {
        private PlaylistPage pp;
        private Grid mainFieldGrid;

        private Grid ICMainField()
        {
            mainFieldGrid = new Grid();

            pp = new PlaylistPage(mainFieldGrid.Width,
                mainFieldGrid.Height,
                Visibility.Visible,
                PlaylistsData.PlaylistsInfo[0]);
            
            mainFieldGrid.Children.Add(pp);

            Grid.SetRow(mainFieldGrid, 0);
            Grid.SetColumn(mainFieldGrid, 2);
            return mainFieldGrid;
        }
    }
}
