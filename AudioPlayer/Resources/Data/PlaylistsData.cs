using AudioPlayer.Core;
using AudioPlayer.Resources.Serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AudioPlayer.Resources.Data
{
    public static class PlaylistsData
    {
        public static List<PlaylistObject> PlaylistObjects { get; set; }
        public static List<PlaylistInfo> PlaylistsInfo { get; set; }

        public static void Initialize()
        {
            var str = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Data\\Playlists.json"));
            PlaylistObjects = JsonSerializer.Deserialize<List<PlaylistObject>>(str);

            PlaylistsInfo = new List<PlaylistInfo>();
            foreach (var item in PlaylistObjects)
            {
                PlaylistsInfo.Add(new PlaylistInfo(item));
            }
        }
    }
}
