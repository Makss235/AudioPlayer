using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AudioPlayer.Widgets.Playlists
{
    public class PlaylistButton : UserControl
    {
        public PlaylistPage PlaylistPage { get; set; }

        private Grid mainGrid;
        private Border mainBorder;

        public PlaylistButton(PlaylistPage playlistPage)
        {
            PlaylistPage = playlistPage;

            Height = 80;

            Image image = new Image()
            {
                Source = PlaylistPage.Info.Icon,
                Width = 54,
                Height = 54,
                RenderSize = new Size(54, 54)
            };

            TextBlock textBlock = new TextBlock()
            {
                Text = PlaylistPage.Info.Name,
                FontFamily = new FontFamily("Arial"),
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.AliceBlue
            };

            #region h

            int countAudio = PlaylistPage.Info.AudioCompositions.Count;
            string countAudioString = countAudio.ToString();
            string ddd = "трека";

            if ("234".Intersect(countAudioString[countAudioString.Length - 1].ToString()).Any())
            {
                if (countAudioString.Length >= 2)
                {
                    if (countAudioString[countAudioString.Length - 2] == '1')
                        ddd = "треков";
                    else
                        ddd = "трека";
                }
            }
            else
            {
                ddd = "треков";
            }

            #endregion

            TextBlock textBlock2 = new TextBlock()
            {
                Text = String.Format($"{countAudio} {ddd}"),
                FontFamily = new FontFamily("Arial"),
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.AliceBlue,
                Margin = new Thickness(0, 5, 0, 0)
            };

            StackPanel stackPanel1 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(8),
                VerticalAlignment = VerticalAlignment.Center
            };
            stackPanel1.Children.Add(textBlock);
            stackPanel1.Children.Add(textBlock2);

            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness((Height - image.Height) / 2),
                Height = image.Height
            };
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(stackPanel1);

            mainGrid = new Grid();
            mainGrid.Children.Add(stackPanel);

            mainBorder = new Border();
            mainBorder.Background = Brushes.Transparent;
            mainBorder.Child = mainGrid;
            Content = mainBorder;
        }
    }
}
