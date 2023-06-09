﻿using AudioPlayer.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace AudioPlayer.Windows.MainWindow
{
    public class AudioElement : ContentControl
    {
        public AudioInfo AudioInfo { get; set; }

        public AudioElement(AudioInfo audioInfo)
        {
            AudioInfo = audioInfo;

            Style style = new Style()
            { TargetType = typeof(TextBlock) };
            style.Setters.Add(new Setter(TextBlock.ForegroundProperty, Brushes.AliceBlue));
            style.Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Arial")));
            style.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)15));
            style.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.Bold));
            style.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.NoWrap));
            style.Setters.Add(new Setter(TextBlock.MarginProperty, new Thickness(10, 0, 10, 0)));

            TextBlock textBlock = new TextBlock()
            { 
                Width = 200, 
                Style = style,
                Text = AudioInfo.Title
            };
            

            TextBlock textBlock1 = new TextBlock()
            {
                Width = 150,
                Style = style,
                Text = AudioInfo.Artists
            };

            TextBlock textBlock2 = new TextBlock()
            {
                Width = 50,
                Style = style,
                Text = AudioInfo.DurationString
            };

            StackPanel stackPanel = new StackPanel()
            { Orientation = Orientation.Horizontal };
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(textBlock1);
            stackPanel.Children.Add(textBlock2);

            Margin = new Thickness(10);
            Content = stackPanel;
        }
    }
}
