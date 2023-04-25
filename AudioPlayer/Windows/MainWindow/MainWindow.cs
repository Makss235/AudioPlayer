using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AudioPlayer.Windows.MainWindow
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            MinHeight = 550;
            MinWidth = 750;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;

            RowDefinition rowDefinition1 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            RowDefinition rowDefinition2 = new RowDefinition()
            { Height = new GridLength(85, GridUnitType.Pixel) };

            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(250, GridUnitType.Pixel),
            MinWidth = 100,
            MaxWidth = 400};

            ColumnDefinition columnDefinition2 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };
            
            ColumnDefinition columnDefinition3 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            Button bc1 = new Button();
            bc1.Content = "222";

            Grid gc1 = new Grid();
            Grid.SetColumn(gc1, 0);
            //gc1.Children.Add(bc1);

            GridSplitter gridSplitter = new GridSplitter()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                ResizeBehavior = GridResizeBehavior.PreviousAndNext,
                Width = 5
            };
            Grid.SetColumn(gridSplitter, 1);

            Button bc2 = new Button();
            bc2.Content = "333";

            Grid gc3 = new Grid();
            Grid.SetColumn(gc3, 2);
            //gc3.Children.Add(bc2);

            Grid gr1 = new Grid();
            gr1.ColumnDefinitions.Add(columnDefinition1);
            gr1.ColumnDefinitions.Add(columnDefinition2);
            gr1.ColumnDefinitions.Add(columnDefinition3);
            Grid.SetRow(gr1, 0);
            gr1.Children.Add(gc1);
            gr1.Children.Add(gridSplitter);
            gr1.Children.Add(gc3);

            Button br2 = new Button();
            br2.Content = "111";

            Grid gr2 = new Grid();
            Grid.SetRow(gr2, 1);
            //gr2.Children.Add(br2);

            Grid grid = new Grid();
            grid.RowDefinitions.Add(rowDefinition1);
            grid.RowDefinitions.Add(rowDefinition2);
            grid.Children.Add(gr1);
            grid.Children.Add(gr2);

            Border border = new Border()
            {
                Background = Brushes.DarkSlateGray,
                CornerRadius = new CornerRadius(10)
            };
            border.Child = grid;

            Content = border;
        }
    }
}
