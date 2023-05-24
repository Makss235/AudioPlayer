using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace AudioPlayer.Core
{
    public struct AudioInfo
    {
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artists { get; set; }
        public string DurationString { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsLiked { get; set; }
        public List<string> Playlists { get; set; }

        private TagLib.File audioFile;

        public AudioInfo(string filePath)
        {
            FilePath = filePath;
            audioFile = TagLib.File.Create(filePath);

            Title = audioFile.Tag.Title;
            if (String.IsNullOrEmpty(Title)) Title = "Unknown";

            Album = audioFile.Tag.Album;
            if (String.IsNullOrEmpty(Album)) Album = "Unknown";

            Artists = string.Join(", ", audioFile.Tag.Performers);
            if (String.IsNullOrEmpty(Artists)) Artists = "Unknown";

            Duration = audioFile.Properties.Duration;
            DurationString = Duration.ToString("mm\\:ss");
            IsLiked = false;
            Playlists = new List<string>();
        }
    }
}
