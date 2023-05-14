﻿using AudioPlayer.Core;
using AudioPlayer.Widgets.Base;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
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

        private DataGrid dataGrid;
        private Grid mainGrid;
        private Border mainBorder;

        public PlaylistPage(double width, double height, Visibility visibility, PlaylistInfo playlistInfo) : 
            base(width, height, visibility)
        {
            Info = playlistInfo;
            //InfoChanged += PlaylistPage_InfoChanged;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            RowDefinition infoPlaylistRow = new RowDefinition()
            { Height = new GridLength(188, GridUnitType.Pixel) };

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

            #region h

            int countAudio = Info.AudioCompositions.Count;
            string countAudioString = countAudio.ToString();
            string ddd = "трека";

            if ("1234".Intersect(countAudioString[countAudioString.Length - 1].ToString()).Any())
            {
                if (countAudioString.Length >= 2)
                {
                    if (countAudioString[countAudioString.Length - 2] == '1')
                    {
                        ddd = "треков";
                    }
                    else
                    {
                        ddd = "трека";
                    }
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
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.AliceBlue
            };

            Ellipse ellipse = new Ellipse()
            {
                Fill = Brushes.AliceBlue,
                Height = 8,
                Width = 8,
                Margin = new Thickness(15, 3, 15, 0)
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
            Grid.SetRow(stackPanel, 0);
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(stackPanel1);

            DataGridTextColumn dataGridColumn = new DataGridTextColumn()
            {
                Header = "Title",
                Binding = new Binding("Title")
            };
            DataGridTextColumn dataGridColumn2 = new DataGridTextColumn()
            {
                Header = "Autor",
                Binding = new Binding("Artists")
            };
            DataGridTextColumn dataGridColumn1 = new DataGridTextColumn()
            {
                Header = "Duration",
                Binding = new Binding("DurationString")
            };
            DataGridTextColumn dataGridColumn3 = new DataGridTextColumn()
            {
                Header = "IsLiked",
                Binding = new Binding("IsLiked")
            };

            var fff = new Style() { TargetType = typeof(DataGridCell)};
            fff.Setters.Add(new Setter(BackgroundProperty, Brushes.Transparent));

            dataGrid = new DataGrid();
            dataGrid.Columns.Add(dataGridColumn);
            dataGrid.Columns.Add(dataGridColumn2);
            dataGrid.Columns.Add(dataGridColumn1);
            dataGrid.Columns.Add(dataGridColumn3);
            dataGrid.ItemsSource = Info.AudioCompositions;
            dataGrid.AutoGenerateColumns = false;
            dataGrid.CellStyle = fff;
            Grid.SetRow(dataGrid, 2);

            mainGrid = new Grid();
            mainGrid.RowDefinitions.Add(infoPlaylistRow);
            mainGrid.RowDefinitions.Add(operationsRow);
            mainGrid.RowDefinitions.Add(audioCompositionsRow);
            mainGrid.Children.Add(stackPanel);
            mainGrid.Children.Add(dataGrid);

            mainBorder = new Border();
            mainBorder.Background = Brushes.Transparent;
            mainBorder.Child = mainGrid;

            Content = mainBorder;
            MessageBox.Show(Info.ID);
        }

        //private void PlaylistPage_InfoChanged()
        //{
        //    dataGrid.ItemsSource = Info.AudioCompositions;
        //    contentPresenter.Content = Info.TotalDurationString;
        //}
    }
}
