using System.Windows.Controls;

namespace AudioPlayer.Windows.MainWindow
{
    public partial class MainWindow
    {
        private Grid audioStateGrid;

        private Grid ICAudioStateRow()
        {
            audioStateGrid = new Grid();
            return audioStateGrid;
        }
    }
}
