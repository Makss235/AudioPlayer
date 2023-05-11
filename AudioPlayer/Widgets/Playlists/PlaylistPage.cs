using AudioPlayer.Core;
using AudioPlayer.Widgets.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace AudioPlayer.Widgets.Playlists
{
    public class PlaylistPage : PageBase
    {
        public string PlaylistName { get; set; }
        public ObservableCollection<AudioInfo> AudioElements { get; set; }

        private Border mainBorder;

        public PlaylistPage(double width, double height, Visibility visibility) : 
            base(width, height, visibility)
        {
            AudioElements = APCore.QueueAudio;

            DataGridTextColumn dataGridColumn = new DataGridTextColumn()
            {
                Header = "Title",
                Binding = new Binding("Title")
            };
            DataGridTextColumn dataGridColumn1 = new DataGridTextColumn()
            {
                Header = "Duration",
                Binding = new Binding("Duration")
            };

            DataGrid dataGrid = new DataGrid();
            dataGrid.Columns.Add(dataGridColumn);
            dataGrid.Columns.Add(dataGridColumn1);
            dataGrid.ItemsSource = AudioElements;
            dataGrid.AutoGenerateColumns = false;

            Grid mainGrid = new Grid();
            mainGrid.Children.Add(dataGrid);

            mainBorder = new Border();
            mainBorder.Background = Brushes.Transparent;
            mainBorder.Child = mainGrid;
            Content = mainBorder;
        }
    }
}
