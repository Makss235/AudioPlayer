using System.Windows.Controls;

namespace AudioPlayer.Windows.MainWindow
{
    public partial class MainWindow
    {
        private Grid mainFieldGrid;

        private Grid ICMainField()
        {
            mainFieldGrid = new Grid();
            return mainFieldGrid;
        }
    }
}
