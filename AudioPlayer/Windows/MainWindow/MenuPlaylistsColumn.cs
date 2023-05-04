using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AudioPlayer.Windows.MainWindow
{
    public partial class MainWindow
    {
        private Grid menuPlaylistsGrid;

        private Grid ICMenuPlaylists()
        {
            menuPlaylistsGrid = new Grid();
            return menuPlaylistsGrid;
        }
    }
}
