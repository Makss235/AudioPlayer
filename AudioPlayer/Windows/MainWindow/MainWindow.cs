using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AudioPlayer.Windows.MainWindow
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Height = 600;
            Width = 800;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ResizeMode = ResizeMode.CanResize;
            WindowStyle = WindowStyle.None;

            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            RowDefinition firstRD = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            RowDefinition audioStateRD = new RowDefinition()
            { Height = new GridLength(85, GridUnitType.Pixel) };

            ColumnDefinition menuPalylistsCD = new ColumnDefinition()
            {
                Width = new GridLength(250, GridUnitType.Pixel),
                MinWidth = 200,
                MaxWidth = 400
            };

            ColumnDefinition gridSplitterCD = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };

            ColumnDefinition mainFieldCD = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            GridSplitter gridSplitter = new GridSplitter()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                ResizeBehavior = GridResizeBehavior.PreviousAndNext,
                Width = 5
            };
            Grid.SetColumn(gridSplitter, 1);

            Grid firstRowGrid = new Grid();
            Grid.SetRow(firstRowGrid, 0);
            firstRowGrid.ColumnDefinitions.Add(menuPalylistsCD);
            firstRowGrid.ColumnDefinitions.Add(gridSplitterCD);
            firstRowGrid.ColumnDefinitions.Add(mainFieldCD);
            firstRowGrid.Children.Add(ICMenuPlaylists());
            firstRowGrid.Children.Add(gridSplitter);
            firstRowGrid.Children.Add(ICMainField());

            Grid mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(firstRD);
            mainGrid.RowDefinitions.Add(audioStateRD);
            mainGrid.Children.Add(firstRowGrid);
            mainGrid.Children.Add(ICAudioStateRow());

            Border mainBorder = new Border()
            {
                Background = new SolidColorBrush(new Color()
                { R = 14, G = 12, B = 30, A = 255 }),
                CornerRadius = new CornerRadius(10)
            };
            mainBorder.Child = mainGrid;

            Content = mainBorder;
        }
    }
}
