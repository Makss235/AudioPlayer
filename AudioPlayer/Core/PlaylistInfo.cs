using AudioPlayer.Resources.Serialize;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace AudioPlayer.Core
{
    public struct PlaylistInfo
    {
        public string Name { get; set; }
        public string IconSource { get; set; }
        public BitmapImage Icon { get; set; }
        public string ID { get; set; }
        public string TotalDurationString { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public List<AudioInfo> AudioCompositions { get; set; }
        
        public PlaylistInfo(string name, string iconSource,
            string id, List<AudioInfo> audioCompositions)
        {
            Name = name;
            IconSource = iconSource;
            Icon = new BitmapImage(new Uri(iconSource, UriKind.Absolute));
            ID = id;
            AudioCompositions = audioCompositions;
            TotalDuration = new TimeSpan();
            TotalDurationString = string.Empty;

            CalculatingTotalDuration();
        }

        public PlaylistInfo(PlaylistObject playlistObject)
        {
            Name = playlistObject.Name;
            IconSource = playlistObject.IconPath;
            Icon = new BitmapImage(new Uri(playlistObject.IconPath, UriKind.Absolute));
            ID= playlistObject.ID;

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
                TotalDuration += item.Duration;
            }
            TotalDurationString = TotalDuration.ToString("hh\\:mm\\:ss");
        }
    }
}
