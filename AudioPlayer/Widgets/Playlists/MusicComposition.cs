using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AudioPlayer.Widgets.Playlists
{
    public class MusicComposition : UserControl
    {
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artists { get; set; }
        public string Duration { get; set; }
        public bool IsLiked { get; set; }
        public List<string> Playlists { get; set; }

        private TagLib.File audioFile;

        public MusicComposition(string filePath)
        {
            FilePath = filePath;

            audioFile = TagLib.File.Create(filePath);
            Title = audioFile.Tag.Title;
            Album = audioFile.Tag.Album;
            Artists = string.Join(", ", audioFile.Tag.Performers);
            Duration = audioFile.Properties.Duration.ToString("mm\\:ss");
            IsLiked = false;
        }
    }
}
