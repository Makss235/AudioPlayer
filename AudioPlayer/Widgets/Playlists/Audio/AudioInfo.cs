using System.Collections.Generic;

namespace AudioPlayer.Widgets.Playlists.Audio
{
    public struct AudioInfo
    {
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artists { get; set; }
        public string Duration { get; set; }
        public bool IsLiked { get; set; }
        public List<string> Playlists { get; set; }

        private TagLib.File audioFile;

        public AudioInfo(string filePath)
        {
            FilePath = filePath;

            audioFile = TagLib.File.Create(filePath);
            Title = audioFile.Tag.Title;
            Album = audioFile.Tag.Album;
            Artists = string.Join(", ", audioFile.Tag.Performers);
            Duration = audioFile.Properties.Duration.ToString("mm\\:ss");
            IsLiked = false;
            Playlists = new List<string>();
        }
    }
}
