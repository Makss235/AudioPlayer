using AudioPlayer.Infrastructure.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace AudioPlayer.Windows.MainWindow
{
    public partial class MainWindow : Window
    {
        private InputBinding dragMoveIB;
        private DropShadowEffect dropShadowEffect;

        public MainWindow()
        {
            Height = 650;
            Width = 850;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.None;

            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;

            dragMoveIB = new InputBinding(
                new DragMoveCommand(this), new MouseGesture()
                { MouseAction = MouseAction.LeftClick });
            InputBindings.Add(dragMoveIB);

            dropShadowEffect = new DropShadowEffect()
            {
                ShadowDepth = 5,
                BlurRadius = 15,
                Opacity = 0.5
            };
            Effect = dropShadowEffect;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            RowDefinition firstRD = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            RowDefinition audioStateRD = new RowDefinition()
            { Height = new GridLength(85, GridUnitType.Pixel) };

            ColumnDefinition menuPlaylistsCD = new ColumnDefinition()
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
            Grid.SetRow(gridSplitter, 0);
            Grid.SetColumn(gridSplitter, 1);

            Grid firstRowGrid = new Grid();
            Grid.SetRow(firstRowGrid, 0);
            firstRowGrid.ColumnDefinitions.Add(menuPlaylistsCD);
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
                CornerRadius = new CornerRadius(10),
                Width = 800,
                Height = 600
            };
            mainBorder.Child = mainGrid;

            Content = mainBorder;
        }
    }
}
