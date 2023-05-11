using AudioPlayer.Resources.Serialize;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace AudioPlayer.Core
{
    public struct PlaylistInfo
    {
        public string Name { get; set; }
        public BitmapImage Icon { get; set; }
        public string TotalDurationString { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public List<AudioInfo> AudioCompositions { get; set; }
        
        public PlaylistInfo(string name, BitmapImage icon,
            List<AudioInfo> audioCompositions)
        {
            Name = name;
            Icon = icon;
            AudioCompositions = audioCompositions;
            TotalDuration = new TimeSpan();
            TotalDurationString = string.Empty;

            CalculatingTotalDuration();
        }

        public PlaylistInfo(PlaylistObject playlistObject)
        {
            Name = playlistObject.Name;
            Icon = new BitmapImage(new Uri(playlistObject.IconPath, UriKind.Absolute));

            AudioCompositions = new List<AudioInfo>();
            foreach (var item in playlistObject.AudioPathes)
            {
                AudioCompositions.Add(new AudioInfo(item));
            }

            TotalDuration = new TimeSpan();
            TotalDurationString = string.Empty;

            CalculatingTotalDuration();
        }

        public void CalculatingTotalDuration()
        {
            TotalDuration = new TimeSpan();
            foreach (var item in AudioCompositions)
            {
                TotalDuration.Add(item.Duration);
            }
            TotalDurationString = TotalDuration.ToString("mm\\:ss");
        }
    }
}
