using AudioPlayer.Core;
using AudioPlayer.Widgets.Base;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AudioPlayer.Widgets.Playlists
{
    public class PlaylistPage : PageBase
    {
        private PlaylistInfo _Info;
        public PlaylistInfo Info
        {
            get => _Info;
            set
            {
                _Info = value;
                //InfoChanged?.Invoke();
            }
        }

        //public event Action InfoChanged;

        //private DataGrid dataGrid;
        private Grid mainGrid;
        private Border mainBorder;

        public PlaylistPage(double width, double height, Visibility visibility, PlaylistInfo playlistInfo) : 
            base(width, height, visibility)
        {
            Info = playlistInfo;
            //InfoChanged += PlaylistPage_InfoChanged;

            //DataGridTextColumn dataGridColumn = new DataGridTextColumn()
            //{
            //    Header = "Title",
            //    Binding = new Binding("Title")
            //};
            //DataGridTextColumn dataGridColumn1 = new DataGridTextColumn()
            //{
            //    Header = "Duration",
            //    Binding = new Binding("DurationString")
            //};

            //dataGrid = new DataGrid();
            //dataGrid.Columns.Add(dataGridColumn);
            //dataGrid.Columns.Add(dataGridColumn1);
            //dataGrid.ItemsSource = Info.AudioCompositions;
            //dataGrid.AutoGenerateColumns = false;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            RowDefinition infoPlaylistRow = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            RowDefinition operationsRow = new RowDefinition()
            { Height = new GridLength(100, GridUnitType.Pixel) };

            RowDefinition audioCompositionsRow = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };

            Image image = new Image()
            {
                Source = Info.Icon,
                Width = 128,
                Height = 128,
                RenderSize = new Size(128, 128)
            };

            TextBlock textBlock = new TextBlock()
            {
                Text = Info.Name,
                FontFamily = new FontFamily("Arial"),
                FontSize = 25,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.AliceBlue
            };

            TextBlock textBlock2 = new TextBlock()
            {
                Text = String.Format($"{Info.AudioCompositions.Count} треков"),
                FontFamily = new FontFamily("Arial"),
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.AliceBlue
            };

            Ellipse ellipse = new Ellipse()
            {
                Fill = Brushes.AliceBlue,
                Height = 8,
                Width = 8,
                Margin = new Thickness(10, 3, 10, 0)
            };

            TextBlock textBlock3 = new TextBlock()
            {
                Text = String.Format($"Длительность: {Info.TotalDurationString}"),
                FontFamily = new FontFamily("Arial"),
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.AliceBlue
            };

            StackPanel stackPanel2 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            stackPanel2.Children.Add(textBlock2);
            stackPanel2.Children.Add(ellipse);
            stackPanel2.Children.Add(textBlock3);

            StackPanel stackPanel1 = new StackPanel()
            { 
                Orientation = Orientation.Vertical,
                Margin = new Thickness(30),
                VerticalAlignment = VerticalAlignment.Center
            };
            stackPanel1.Children.Add(textBlock);
            stackPanel1.Children.Add(stackPanel2);

            StackPanel stackPanel = new StackPanel()
            { 
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(30),
                Height = 128
            };
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(stackPanel1);

            mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(infoPlaylistRow);
            mainGrid.RowDefinitions.Add(operationsRow);
            mainGrid.RowDefinitions.Add(audioCompositionsRow);
            mainGrid.Children.Add(stackPanel);

            mainBorder = new Border();
            mainBorder.Background = Brushes.Transparent;
            mainBorder.Child = mainGrid;

            Content = mainBorder;
        }

        //private void PlaylistPage_InfoChanged()
        //{
        //    dataGrid.ItemsSource = Info.AudioCompositions;
        //    contentPresenter.Content = Info.TotalDurationString;
        //}
    }
}
